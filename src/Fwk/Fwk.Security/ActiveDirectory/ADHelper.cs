﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using Fwk.Configuration;
using System.Runtime.InteropServices;
using System.Collections.Specialized;
using System.DirectoryServices.Protocols;
using System.DirectoryServices.ActiveDirectory;
using Fwk.Exceptions;
using System.DirectoryServices.AccountManagement;
using System.Reflection;
using Fwk.Security.Properties;
namespace Fwk.Security.ActiveDirectory
{

    /// <summary>
    /// Wrapper de Active Directory con funcionalidades para interactuar contra un controlador de dominio .-
    /// 
    /// </summary>
    public class ADHelper : DirectoryServicesBase, IDirectoryService
    {
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="domain"></param>
        public ADHelper(string domain)
        {
            _LDAPPath = string.Concat(@"LDAP://", domain);

            try
            {
                _directoryEntrySearchRoot = new DirectoryEntry(_LDAPPath, null, null, AuthenticationTypes.Secure);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            _LDAPDomain = domain;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="user"></param>
        /// <param name="pwd"></param>
        public ADHelper(string path, string user, string pwd)
        {
            _LDAPPath = path;

            _LDAPUser = FilterOutDomain(user);
            _LDAPPassword = pwd;

            try
            {
                _directoryEntrySearchRoot = new DirectoryEntry(_LDAPPath, _LDAPUser, _LDAPPassword, AuthenticationTypes.Secure);
             
                _LDAPDomain = GetValue(GetProperty(_directoryEntrySearchRoot, ADProperties.DISTINGUISHEDNAME), "DC");
            }
            catch (TechnicalException e)// Cuando el usuario no existe o clave erronea
            {
                Exception te1 = ProcessActiveDirectoryException(e);
                TechnicalException te = new TechnicalException(string.Format(Resource.AD_Impersonation_Error, te1.Message), te1.InnerException);
                ExceptionHelper.SetTechnicalException<ADHelper>(te);
                te.ErrorId = "4103";
                throw te;
            }

        }

       
        #endregion

        #region users
        ///// <summary>
        ///// Obtiene un usuario sin pasar clave.-
        ///// </summary>
        ///// <param name="userName"></param>
        ///// <returns></returns>
        SearchResult User_Get_Result(string userName)
        {
            DirectorySearcher deSearch = new DirectorySearcher(_directoryEntrySearchRoot);
            deSearch.Filter = "(&(objectClass=user)(sAMAccountName=" + FilterOutDomain(userName) + "))";
            deSearch.SearchScope = System.DirectoryServices.SearchScope.Subtree;
            SearchResult rs = deSearch.FindOne();
            deSearch.Dispose();
            return rs;

        }

        /// <summary>
        /// Busca un usuario con autenticacion 
        /// Returna como parametro el resultado de loging
        /// </summary>
        /// <param name="userName">nombre de loging de usuario</param>
        /// <param name="password">password</param>
        /// <param name="loginResult">resultado de loging</param>
        /// <returns>DirectoryEntry</returns>
        DirectoryEntry User_Get(string userName, string password, out LoginResult loginResult)
        {

            DirectoryEntry userDirectoryEntry = null;
            loginResult = LoginResult.LOGIN_OK; 
            SearchResult result = this.User_Get_Result(userName);

            //Si esl resultado de busqueda en nodes es nulo el usuario no exisate en el dominio
            if (result == null)
            {
                loginResult = LoginResult.LOGIN_USER_DOESNT_EXIST;
                return null;
            }

            //PasswordExpired
            if (ADHelper.GetProperty(result, ADProperties.PWDLASTSET) == "0")
            {
                loginResult = LoginResult.ERROR_PASSWORD_MUST_CHANGE;
                return null;
            }
            
          

            
            //string str = EnlistValue(results);
            //si result no es nulo se puede crear una DirectoryEntry
            if (result != null)
                 userDirectoryEntry = new DirectoryEntry(result.Path, userName, password);

            //Intenta obtener una propiedad para determinar si el usuario se logueo con clave correcta o no.-
            try
            {
                int userAccountControl = Convert.ToInt32(ADHelper.GetProperty(userDirectoryEntry, ADProperties.USERACCOUNTCONTROL));
            }
            catch (TechnicalException te)
            {
                if (te.ErrorId == "4101")
                {
                    loginResult = LoginResult.LOGIN_USER_OR_PASSWORD_INCORRECT;
                    return userDirectoryEntry;
                }
            }
           
            if (User_IsAccountActive(userDirectoryEntry) == false)
            {
                loginResult = LoginResult.LOGIN_USER_ACCOUNT_INACTIVE;
                return userDirectoryEntry;
            }

            if (User_IsAccountLockout(userDirectoryEntry))
            {
                loginResult = LoginResult.LOGIN_USER_ACCOUNT_LOCKOUT;
                return userDirectoryEntry;
            }


            return userDirectoryEntry;
        }


        
       /// <summary>
        /// Obtiene un usuario por nombre sin tener en cuenta las credenciales del usuario
       /// </summary>
       /// <param name="userName"></param>
       /// <returns></returns>
        DirectoryEntry User_Get(string userName)
        {

            DirectoryEntry userDirectoryEntry = null;
            DirectorySearcher deSearch = new DirectorySearcher(_directoryEntrySearchRoot);
            deSearch.Filter = "(&(objectClass=user)(sAMAccountName=" + FilterOutDomain(userName) + "))";
            //deSearch.Filter = "(&(objectClass=user)(cn=" + FilterOutDomain(userName) + "))";

            deSearch.SearchScope = System.DirectoryServices.SearchScope.Subtree;
            SearchResult results = deSearch.FindOne();
           
            //si result no es nulo se puede crear una DirectoryEntry
            if (results != null)
                userDirectoryEntry = new DirectoryEntry(results.Path);
            

            deSearch.Dispose();
            return userDirectoryEntry;

        }
       


        /// <summary>
        /// Obtiene un usuario por nombre sin tener en cuenta las credenciales del usuario
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public ADUser User_Get_ByName(String userName)
        {

            ADUser wADUser = null;
            DirectoryEntry userDirectoryEntry = null;
            try
            {
                userDirectoryEntry = this.User_Get(userName);
                if (userDirectoryEntry != null)
                {
                    wADUser = new ADUser(userDirectoryEntry);
                }
                
                return wADUser;
            }
            catch (Exception ex)
            {
                throw ProcessActiveDirectoryException(ex);
            }

        }

        /// <summary>
        /// Verifica si el usuario existe.- 
        /// </summary>
        /// <param name="userName">Nombre de loging de usuario</param>
        /// <returns></returns>
        public bool User_Exists(string userName)
        {

            //create instance fo the direcory searcher
            DirectorySearcher deSearch = new DirectorySearcher(_directoryEntrySearchRoot);

            //set the search filter
            deSearch.Filter = "(&(objectClass=user) (cn=" + FilterOutDomain(userName) + "))";

            //find the first instance
            SearchResultCollection results = deSearch.FindAll();

            //if the username and password do match, then this implies a valid login
            //if so then return the DirectoryEntry object
            if (results.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        /// <summary>
        /// Retorna los grupos a los que pertenece el usuario .-
        /// </summary>
        /// <param name="userName">Nombre completo del usuario</param>
        /// <returns></returns>
        public List<ADGroup> User_SearchGroupList(String userName)
        {
            List<ADGroup> list = null;
            DirectoryEntry directoryEntryUser = null;
            string filter = string.Format("(&(ObjectClass={0})(sAMAccountName={1}))", "person", userName);
            DirectorySearcher deSearch = new DirectorySearcher(_directoryEntrySearchRoot);
            deSearch.Filter = filter;
            try
            {

                SearchResult result = deSearch.FindOne();

                if (result != null)
                {
                    directoryEntryUser = result.GetDirectoryEntry();
                    list = new List<ADGroup>();
                    ADGroup aDGroup;
                    foreach (string grouInfo in directoryEntryUser.Properties["memberOf"])
                    {
                        foreach (string g in GetGroupFromMemberOf(grouInfo))
                        {
                            aDGroup = Group_GetByName(g);
                            if (aDGroup != null)
                                list.Add(aDGroup);
                        }
                    }
                    directoryEntryUser.Close();
                    directoryEntryUser.Dispose();
                }
                deSearch.Dispose();
                return list;

            }
            catch (Exception ex)
            {
                throw ProcessActiveDirectoryException(ex);
            }

        }

        /// <summary>
        /// Obtiene todo los usuarios pertenecientes al dominio.-
        /// Busca por cn nombre@mail retorna el sAMAccountName ejemplo: moviedo
        /// </summary>
        List<String> User_SearchGroupStringList(String userName)
        {
            DirectoryEntry directoryEntryUser = null;
            List<String> list = null;
            DirectorySearcher deSearch = new DirectorySearcher(_directoryEntrySearchRoot);

            string filter = string.Format("(&(ObjectClass={0})(sAMAccountName={1}))", "person", userName);
            try
            {

                deSearch.Filter = filter;
                SearchResult result = deSearch.FindOne();


                if (result != null)
                {
                    directoryEntryUser = result.GetDirectoryEntry();
                    list = new List<String>();
                    foreach (string grouInfo in directoryEntryUser.Properties["memberOf"])
                    {
                        foreach (string g in GetGroupFromMemberOf(grouInfo))
                        {
                            list.Add(g);
                        }
                    }
                    directoryEntryUser.Close();
                    directoryEntryUser.Dispose();
                }
                deSearch.Dispose();
                return list;
            }
            catch (Exception ex)
            {
                throw ProcessActiveDirectoryException(ex);
            }
        }

        /// <summary>
        /// Retorna la lista de usuarios pertenecientes a un determinado grupo
        /// </summary>
        /// <param name="groupName">Nombre del grupo</param>
        /// <returns></returns>
        public List<ADUser> Users_SearchByGroupName(String groupName)
        {

            List<ADUser> userlist = new List<ADUser>();
            ADUser wADUser = null;
            DirectoryEntry directoryEntryUser = null;
            try
            {
                DirectorySearcher deSearch = new DirectorySearcher(_directoryEntrySearchRoot);
                deSearch.Filter = "(&(objectClass=group)(SAMAccountName=" + groupName + "))";
                SearchResult results = deSearch.FindOne();
                if (results != null)
                {

                    DirectoryEntry deGroup = new DirectoryEntry(results.Path, LDAPUser, LDAPPassword);

                    System.DirectoryServices.PropertyCollection pColl = deGroup.Properties;

                    int count = pColl["member"].Count;



                    for (int i = 0; i < count; i++)
                    {

                        string respath = results.Path;

                        string[] pathnavigate = respath.Split("CN".ToCharArray());

                        respath = pathnavigate[0];

                        string objpath = pColl["member"][i].ToString();

                        string path = string.Concat(respath, objpath);

                        directoryEntryUser = new DirectoryEntry(path, LDAPUser, LDAPPassword);

                        wADUser = new ADUser(directoryEntryUser);

                        userlist.Add(wADUser);

                        directoryEntryUser.Close();
                        directoryEntryUser.Dispose();

                    }
                    deGroup.Close();
                    deGroup.Dispose();

                }
                deSearch.Dispose();
                return userlist;

            }

            catch (Exception ex)
            {
                throw ProcessActiveDirectoryException(ex);
            }



        }

        /// <summary>
        /// Retorna una lista de usuarios cuyo nombre comiense con fname.-
        /// Ejemplo: evel*
        /// </summary>
        /// <param name="fName"></param>
        /// <returns></returns>
        public List<ADUser> Users_Search_StartName(string fName)
        {
            List<ADUser> userlist = new List<ADUser>();
            DirectorySearcher deSearch = new DirectorySearcher(_directoryEntrySearchRoot);
            deSearch.Asynchronous = true;
            deSearch.CacheResults = true;

            //string filter = string.Format("(givenName={0}*", fName);
            //filter = "(&(objectClass=user)(objectCategory=person)" + filter + ")";
            string filter = "(&(objectClass=user)(objectCategory=person)(givenName=" + fName + "*))";

            deSearch.Filter = filter;
            try
            {
                SearchResultCollection userCollection = deSearch.FindAll();

                foreach (SearchResult users in userCollection)
                {
                    DirectoryEntry userEntry = new DirectoryEntry(users.Path, LDAPUser, LDAPPassword);
                    userlist.Add(new ADUser(userEntry));
                }
                deSearch.Dispose();
                return userlist;
            }
            catch (Exception ex)
            {
                throw ProcessActiveDirectoryException(ex);
            }
        }


        /// <summary>
        /// Este metodo permite determinar si un usuario puede loguearce en un dominio
        /// tambien chequea si la cuenta esta activa
        /// </summary>
        /// <param name="userName">Nombre de usuario a autenticar</param>
        /// <param name="password">Password del usuario.-</param>
        /// <returns></returns>
        public LoginResult User_CheckLogin(string userName, string password)
        {

            LoginResult rs;
            this.User_Get(userName, password, out rs);

            return rs;

        }
        
       

        #endregion

        #region users statics
        

        /// <summary>
        /// Este metodo realiza una aperacion logica con el valor userAccountControl para deternçminar si la cuenta de usuario 
        /// esta abilitada o no.-
        /// La bandera para determinar si la cuenta está activa es un valor binario (decimal = 2)
        /// Los valores predeterminados de UserAccountControl para  Usuario normal: 0x200 (512)
        /// </summary>
        /// <param name="de"></param>
        /// <returns></returns>
        public static bool User_IsAccountActive(DirectoryEntry de)
        {

            //Convierte UserAccountControl a la operacion logica
            int userAccountControl = Convert.ToInt32(ADHelper.GetProperty(de, ADProperties.USERACCOUNTCONTROL));

            int userAccountControl_Disabled = Convert.ToInt32(ADAccountOptions.UF_ACCOUNTDISABLE);
            int flagExists = userAccountControl & userAccountControl_Disabled;
            //Si coinciden, la bandera indicara Dehabilitao como indicador de control
            //if (flagExists > 0)
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}
          return flagExists == 0;//Si es = a 2 es por que esta DESHABILITADO (512 - 2) 
        }

        /// <summary>
        /// Este metodo realiza una aperacion logica con el valor userAccountControl para deternçminar si la cuenta de usuario 
        /// esta habilitada o no.-
        /// La bandera para determinar si la cuenta está bloqueada es un valor binario (decimal = 16)
        /// Los valores predeterminados de UserAccountControl para  Usuario normal: 0x200 (512)
        /// En un dominio basado en Windows Server 2003, LOCK_OUT y 
        /// PASSWORD_EXPIRED han sido reemplazados con un nuevo atributo denominado ms-DS-User-Account-Control-Computed
        /// </summary>
        /// <param name="de"></param>
        /// <returns></returns>
        public static bool User_IsAccountLockout(DirectoryEntry de)
        {
            //Convierte UserAccountControl a la operacion logica
            int userAccountControl = Convert.ToInt32(ADHelper.GetProperty(de, ADProperties.USERACCOUNTCONTROL));
            int flag = userAccountControl & Convert.ToInt32(ADAccountOptions.UF_LOCKOUT);
            //int flag2 = 528 & Convert.ToInt32(ADAccountOptions.UF_LOCKOUT); -- solo para test
            //if (flag == 0)
            //    return false;
            //else
            //    return true; 


            // UF_LOCKOUT = 16 en Decimal

            return !(flag == 0); // No estoy seguro de utilizar la return (flag == 16);  sentencia q apareentenmete seria =  ()
        }

     

        #endregion


        #region Groups
        /// <summary>
        /// Obtiene un ADGroup que reprecenta un grupo 
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        public ADGroup Group_GetByName(String pName)
        {
            string filter = string.Format("(&(ObjectClass={0})(sAMAccountName={1}))", "group", pName);

            DirectorySearcher deSearch = new DirectorySearcher(_directoryEntrySearchRoot);
            deSearch.Filter = filter;
            SearchResult result = deSearch.FindOne();
            if (result == null) return null;
            DirectoryEntry directoryEntry = result.GetDirectoryEntry();

            ADGroup wADGroup = new ADGroup(directoryEntry);
            directoryEntry.Close();
            directoryEntry.Dispose();
            deSearch.Dispose();
            return wADGroup;

        }


        /// <summary>
        /// Obtiene todo los grupos pertenecientes al dominio.-
        /// </summary>
        public List<ADGroup> Groups_GetAll()
        {
            List<ADGroup> pList = null;


            ADGroup group = null;
            pList = new List<ADGroup>();
            DirectoryEntry wDirectoryEntry = null;
            DirectorySearcher deSearch = new DirectorySearcher(_directoryEntrySearchRoot);
            deSearch.Filter = "(&(objectClass=group))";
            deSearch.Sort.PropertyName = "sAMAccountName";
            deSearch.Sort.Direction = System.DirectoryServices.SortDirection.Ascending;

            try
            {
                foreach (SearchResult result in deSearch.FindAll())
                {
                    wDirectoryEntry = result.GetDirectoryEntry();

                    //GetProperties(wDirectoryEntry, "pQuery");
                    if (wDirectoryEntry.Properties.Contains("sAMAccountName"))
                    {
                        group = new ADGroup(wDirectoryEntry);
                        pList.Add(group);
                    }
                }

                wDirectoryEntry.Close();
                wDirectoryEntry.Dispose();
                deSearch.Dispose();
                return pList;
            }
            catch (Exception ex)
            {
                throw ProcessActiveDirectoryException(ex);
            }

        }

        /// <summary>
        /// Lista simple de grupos de usuario
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        List<string> Group_GetUsersArray(string groupName)
        {
            SearchResult result;
            DirectorySearcher search = new DirectorySearcher();
            search.Filter = String.Format("(cn={0})", groupName);
            search.PropertiesToLoad.Add("member");
            result = search.FindOne();

            List<string> userNames = new List<string>();
            if (result != null)
            {
                foreach (string strMember in result.Properties["member"])
                {
                    userNames.Add(strMember);
                }
                //for (int counter = 0; counter <
                //         result.Properties["member"].Count; counter++)
                //{
                //    string user = (string)result.Properties["member"][counter];
                //    userNames.Add(user);
                //}

            }
            return userNames;
        }
        #endregion

        #region Functions
        /// <summary>
        /// Obtiene la lista de dominios
        /// </summary>
        /// <returns></returns>
        public StringCollection Domain_GetList1()
        {
            StringCollection domainList = new StringCollection();

            try
            {
                // Search for objectCategory type "Domain"
                DirectorySearcher srch = new DirectorySearcher(_directoryEntrySearchRoot, "objectCategory=Domain");
                SearchResultCollection coll = srch.FindAll();
                // Enumerate over each returned domain.
                foreach (SearchResult rs in coll)
                {
                    ResultPropertyCollection resultPropColl = rs.Properties;
                    foreach (object domainName in resultPropColl["name"])
                    {
                        domainList.Add(domainName.ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                ProcessActiveDirectoryException(ex);
            }
            return domainList;
        }

        /// <summary>
        /// Obtiene la lista de dominios
        /// </summary>
        /// <returns></returns>
        public static StringCollection Domain_GetList()
        {
            StringCollection domainList = new StringCollection();
            try
            {
                DomainCollection domains = Forest.GetCurrentForest().Domains;

                foreach (Domain domain in domains)
                {
                    domainList.Add(domain.Name);
                }

            }
            catch (Exception ex)
            {
                throw ProcessActiveDirectoryException(ex);
            }
            return domainList;
        }

        /// <summary>
        /// Lista de Global Catalog 
        /// Global Catalog : es una parte de la base de datos de nuestro Active Directory usado para realizar búsquedas en este.
        /// </summary>
        /// <param name="domainName"></param>
        /// <returns></returns>
        public GlobalCatalogCollection GlobalCatalogs(string domainName)
        {
            
            Forest f3 = Forest.GetCurrentForest();

            //return  f.GlobalCatalogs;
            DirectoryContext context = new DirectoryContext(DirectoryContextType.Domain, domainName, LDAPUser, LDAPPassword);
            Forest f = Forest.GetForest(context);

            //DomainController controller = System.DirectoryServices.ActiveDirectory.DomainController.FindOne(context);

            return f.GlobalCatalogs;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        static Exception ProcessActiveDirectoryException(Exception ex)
        {
            Fwk.Exceptions.TechnicalException te = new Fwk.Exceptions.TechnicalException(ex.Message, ex);
            ExceptionHelper.SetTechnicalException<ADHelper>(te);
            switch (ex.GetType().FullName)
            {
                case "System.Runtime.InteropServices.COMException"://((System.Runtime.InteropServices.COMException)(ex)) "El servidor no es operacional.\r\n"
                    {
                        te.ErrorId = "4100";
                        break;
                    }
                case "System.DirectoryServices.DirectoryServicesCOMException": //Error de inicio de sesión: nombre de usuario desconocido o contraseña incorrecta.
                    {
                        te.ErrorId = "4101";
                        break;
                    }
                default:
                    {
                        te.ErrorId = "4100";
                        break;
                    }

            }

            return te;
        }

      

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="nameValue"></param>
        /// <returns></returns>
        static string GetValue(string str, string nameValue)
        {
            foreach (string s in str.Split(','))
            {
                if (s.Contains(nameValue))
                    return s.Split('=')[1];
            }
            return string.Empty;
        }

        /// <summary>
        /// Obtiene un string con todas las propiedades de un objeto de AD
        /// </summary>
        /// <param name="pDirectoryEntry"></param>
        /// <returns></returns>
        static string GetStringProperties(DirectoryEntry pDirectoryEntry)
        {
            StringBuilder slist = new StringBuilder();

            foreach (string s in pDirectoryEntry.Properties.PropertyNames.Cast<string>())
            {
                slist.Append(s);
                slist.Append(" = ");
                slist.Append(GetProperty(pDirectoryEntry, s));
                slist.AppendLine(Environment.NewLine);

            }

            return slist.ToString();
        }
        /// <summary>
        /// Obtiene un string con todas las propiedades de un objeto de AD
        /// </summary>
        /// <param name="pDirectoryEntry"></param>
        /// <returns></returns>
        static string GetStringProperties(SearchResult pSearchResult)
        {
            StringBuilder slist = new StringBuilder();

            foreach (string s in pSearchResult.Properties.PropertyNames.Cast<string>())
            {
                slist.Append(s);
                slist.Append(" = ");
                slist.Append(GetProperty(pSearchResult, s));
                slist.AppendLine(Environment.NewLine);

            }

            return slist.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberOf"></param>
        /// <returns></returns>
        public static List<string> GetGroupFromMemberOf(string memberOf)
        {
            int i = 0;
            string[] propAux;
            List<String> list = new List<String>();
            foreach (string prop in memberOf.Split(','))
            {
                propAux = prop.Split('=');

                if (propAux[0].CompareTo("CN") == 0)
                {
                    list.Add(propAux[1]);
                    i++;
                }

            }
            return list;
        }

        /// <summary>
        /// Obtiene una propiedad del objeto de active directory .-
        /// </summary>
        /// <param name="userDetail"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static String GetProperty(DirectoryEntry userDetail, String propertyName)
        {
            try
            {
                if (userDetail.Properties.Contains(propertyName))
                {
                    return userDetail.Properties[propertyName][0].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }

            catch (Exception ex)
            {
                throw ProcessActiveDirectoryException(ex);
            }
        }

        /// <summary>
        /// Obtiene una propiedad del objeto de active directory .-
        /// </summary>
        /// <param name="result"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static String GetProperty(SearchResult result, String propertyName)
        {
            try
            {
                if (result.Properties.Contains(propertyName))
                {
                    return result.Properties[propertyName][0].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }

            catch (Exception ex)
            {
                throw ProcessActiveDirectoryException(ex);
            }
        }

        /// <summary>
        /// Quita el dominio en la especificacion del nombre de usuario, si es 
        /// que existe tal valor.-
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static string FilterOutDomain(string userName)
        {
            if (String.IsNullOrEmpty(userName)) return string.Empty;
            string result = string.Empty;

            if (userName.IndexOf("\\") > 0)
            {
                string UserName = string.Empty;
                int SlashSpot = 0;
                int NameLen = 0;

                SlashSpot = userName.IndexOf(@"\") + 1;

                NameLen = userName.Length - SlashSpot;

                UserName = userName.Substring(SlashSpot, NameLen);

                result = UserName;
            }
            else
            {
                result = userName;
            }

            return result;
        }
        #endregion

        public void ResetPwd(string pUserName, string pNewPwd, bool pForceChangeOnFirstLogon, bool pUnlockAccount)
        {
            // TODO, implementar reseteo aca, cut & paste from reseteo web
            throw new NotImplementedException();
        }
    }
}
