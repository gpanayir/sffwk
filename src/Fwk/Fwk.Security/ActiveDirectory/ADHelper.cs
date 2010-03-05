using System;
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

namespace Fwk.Security.ActiveDirectory
{

    /// <summary>
    /// 
    /// </summary>
    public class ADHelper
    {
        #region Properties
        DirectoryEntry _directoryEntrySearchRoot;
        string _LDAPPath;
        string _LDAPDomain;
        string _LDAPUser;

        /// <summary>
        ///Ej: 
        ///LDAP://domain/DC=xxx,DC=com
        ///LDAP://CORRSF71NT13.actionlinecba.org/DC=actionlinecba,DC=org
        ///LDAP://Corba362nt01.alcomovistar.com.ar/OU=Movistar Sabattini,dc=alcomovistar,dc=com,dc=ar
        /// </summary>
        public String LDAPPath
        {
            get
            {
                return _LDAPPath;
            }

        }


        /// <summary>
        ///LDAPUser property
        /// </summary>
        public String LDAPUser
        {
            get
            {
                return _LDAPUser;
            }

        }
        string _LDAPPassword;

        /// <summary>
        /// LDAPPassword property
        ///This property is reading the LDAP Password from the config file.
        /// </summary>
        public String LDAPPassword
        {
            get
            {
                return _LDAPPassword;
            }

        }


        /// <summary>
        /// Dominio
        /// </summary>
        public String LDAPDomain
        {
            get
            {
                return _LDAPDomain;
            }

        }
        #endregion

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
                //	= CN=CORRSF71TS01,OU=Domain Controllers,DC=actionlinecba,DC=org
                _LDAPDomain = GetValue(GetProperty(_directoryEntrySearchRoot, ADProperties.DISTINGUISHEDNAME), "DC");
            }
            catch (Exception e)// Cuando el usuario no existe o clave erronea
            {
                StringBuilder strErrMessage = new StringBuilder("Error de impersonalizacion de active directory.- Detalle del problema : ");


                DirectoryEntry userDirectoryEntry = GetUser(_LDAPUser);

                if (userDirectoryEntry == null)
                {
                    strErrMessage.AppendLine(LoginResult.LOGIN_USER_DOESNT_EXIST.ToString());
                }
                else
                {
                    int userAccountControl = Convert.ToInt32(ADHelper.GetProperty(userDirectoryEntry, ADProperties.USERACCOUNTCONTROL));
                    if (!User_IsAccountActive(userAccountControl))
                    {
                        strErrMessage.AppendLine(LoginResult.LOGIN_USER_ACCOUNT_INACTIVE.ToString());

                    }
                    if (User_IsAccountLockout(userAccountControl))
                        strErrMessage.AppendLine(LoginResult.LOGIN_USER_ACCOUNT_LOCKOUT.ToString());
                }
                TechnicalException te = new TechnicalException(strErrMessage.ToString(), e.InnerException);

                SetError(te);
                te.ErrorId = "15003";





                throw te;
            }



        }

        /// <summary>
        /// Obtiene un usuario sin pasar clave,.- solo con la url _LDAPPath 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        DirectoryEntry GetUser(string userName)
        {
            DirectoryEntry d = new DirectoryEntry(_LDAPPath, null, null, AuthenticationTypes.Secure);
            DirectoryEntry userDirectoryEntry = null;
            DirectorySearcher deSearch = new DirectorySearcher(d);
            deSearch.Filter = "(&(objectClass=user)(sAMAccountName=" + FilterOutDomain(userName) + "))";


            deSearch.SearchScope = System.DirectoryServices.SearchScope.Subtree;


            SearchResult results = deSearch.FindOne();


            if (results != null)
            {
                userDirectoryEntry = new DirectoryEntry(results.Path, null, null);
            }
            d.Close();
            d.Dispose();
            deSearch.Dispose();
            return userDirectoryEntry;
        }
        #endregion

        #region users


        /// <summary>
        /// Override method which will perfrom query based on combination of username and password
        /// This is used with the login process to validate the user credentials and return a user
        /// object for further validation.  This is slightly different from the other GetUser... methods as this
        /// will use the UserName and Password supplied as the authentication to check if the user exists, if so then
        /// the users object will be queried using these credentials.s
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        DirectoryEntry User_Get(string userName, string password)
        {

            DirectoryEntry userDirectoryEntry = null;
            DirectorySearcher deSearch = new DirectorySearcher(_directoryEntrySearchRoot);
            deSearch.Filter = "(&(objectClass=user)(sAMAccountName=" + FilterOutDomain(userName) + "))";
            //deSearch.Filter = "(&(objectClass=user)(cn=" + FilterOutDomain(userName) + "))";

            deSearch.SearchScope = System.DirectoryServices.SearchScope.Subtree;


            SearchResult results = deSearch.FindOne();

            //si result no es nulo se puede crear una DirectoryEntry
            if (results != null)
                userDirectoryEntry = new DirectoryEntry(results.Path, userName, password);


            deSearch.Dispose();
            return userDirectoryEntry;

        }

       


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public ADUser User_Get_ByName(String userName)
        {

            ADUser wADUser = null;
            DirectoryEntry userDirectoryEntry = null;
            try
            {

                //DirectorySearcher deSearch = new DirectorySearcher(_directoryEntrySearchRoot);
                //deSearch.Filter = string.Format("(&(ObjectClass={0})(name={1}))", "person", FilterOutDomain(userName));
                //SearchResult results = deSearch.FindOne();
                userDirectoryEntry = this.User_Get(userName, null);
                if (userDirectoryEntry != null)
                {
                    //userDirectoryEntry = new DirectoryEntry(results.Path, userName, null);
                    wADUser = new ADUser(userDirectoryEntry);
                    //userDirectoryEntry.Close();
                    //userDirectoryEntry.Dispose();
                }
                //deSearch.Dispose();
                return wADUser;
            }
            catch (Exception ex)
            {
                throw ProcessActiveDirectoryException(ex);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserName"></param>
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
        /// This function will take a full name as input parameter and return AD user corresponding to that. 
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
        List<String> User_SearchGroupStringList(String pUserName)
        {
            DirectoryEntry directoryEntryUser = null;
            List<String> list = null;
            DirectorySearcher deSearch = new DirectorySearcher(_directoryEntrySearchRoot);

            string filter = string.Format("(&(ObjectClass={0})(sAMAccountName={1}))", "person", pUserName);
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
            DirectoryEntry de;
            int userAccountControl;
            try
            {
                de = this.User_Get(userName, password);

            }
            catch (Fwk.Exceptions.TechnicalException te)
            {
                if (te.ErrorId == "15002")
                    //Error de inicio de sesión: nombre de usuario desconocido o contraseña incorrecta.
                    return LoginResult.LOGIN_USER_DOESNT_EXIST;
                else
                    throw te;
            }

            if (de != null)
            {

                try
                {
                    //Convierte UserAccountControl a la operacion logica
                    userAccountControl = Convert.ToInt32(ADHelper.GetProperty(de, ADProperties.USERACCOUNTCONTROL));
                }
                catch (Fwk.Exceptions.TechnicalException te)
                {
                    if (te.ErrorId == "15002")
                        //Error de inicio de sesión: nombre de usuario desconocido o contraseña incorrecta.
                        return LoginResult.LOGIN_USER_OR_PASSWORD_INCORRECT;
                    else
                        throw te;
                }
                if (User_IsAccountActive(userAccountControl))
                {
                    return LoginResult.LOGIN_OK;
                }
                else
                {
                    return LoginResult.LOGIN_USER_ACCOUNT_INACTIVE;

                }

            }
            else
            {
                return LoginResult.LOGIN_USER_DOESNT_EXIST;
            }


        }

     

   

        #endregion

        #region users statics
        /// <summary>
        /// Obtiene un usuario 
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        static DirectoryEntry User_Get(string domain, string userName, string password)
        {
            SearchResult results = null;

            DirectoryEntry root = new DirectoryEntry(string.Concat(@"LDAP://", domain), FilterOutDomain(userName), password, AuthenticationTypes.Secure);


            DirectoryEntry userDirectoryEntry = null;

            DirectorySearcher deSearch = new DirectorySearcher(root);

            deSearch.Filter = "(&(objectClass=user)(sAMAccountName=" + FilterOutDomain(userName) + "))";
            deSearch.SearchScope = System.DirectoryServices.SearchScope.Subtree;

            try
            {
                results = deSearch.FindOne();
            }
            catch (Exception ex)
            {
                // {"El servidor no es operacional.\r\n"}
                throw ProcessActiveDirectoryException(ex);
            }

            //si result no es nulo se puede crear una DirectoryEntry
            if (results != null)
                userDirectoryEntry = new DirectoryEntry(results.Path, FilterOutDomain(userName), password);

            root.Close();
            root.Dispose();
            deSearch.Dispose();
            return userDirectoryEntry;

        }

        /// <summary>
        /// Este metodo permite determinar si un usuario puede loguearce en un dominio
        /// tambien chequea si la cuenta esta activa
        /// </summary>
        /// <param name="domain">Dominio contra el cual chequear </param>
        /// <param name="userName">Nombre de usuario a autenticar</param>
        /// <param name="password">Password del usuario.-</param>
        /// <returns></returns>
        public static LoginResult User_CheckLogin(string domain, string userName, string password)
        {
            //first, check if the logon exists based on the username and password
            DirectoryEntry de = null;

            try
            {
                de = ADHelper.User_Get(domain, userName, password);
            }
            catch (Fwk.Exceptions.TechnicalException te)
            {
                if (te.ErrorId == "15002")
                    //Error de inicio de sesión: nombre de usuario desconocido o contraseña incorrecta.
                    return LoginResult.LOGIN_USER_DOESNT_EXIST;
                else
                    throw te;
            }
            if (de != null)
            {
                //Convierte UserAccountControl a la operacion logica
                int userAccountControl = Convert.ToInt32(ADHelper.GetProperty(de, ADProperties.USERACCOUNTCONTROL));

                if (User_IsAccountActive(userAccountControl))
                {
                    return LoginResult.LOGIN_OK;
                }
                else
                {
                    return LoginResult.LOGIN_USER_ACCOUNT_INACTIVE;

                }

            }
            else
            {
                return LoginResult.LOGIN_USER_DOESNT_EXIST;
            }

        }


        /// <summary>
        /// Este metodo realiza una aperacion logica con el valor userAccountControl para deternçminar si la cuenta de usuario 
        /// esta abilitada o no.-
        /// La bandera para determinar si la cuenta está activa es un valor binario (decimal = 2)
        /// Los valores predeterminados de UserAccountControl para  Usuario normal: 0x200 (512)
        /// </summary>
        /// <param name="userAccountControl"></param>
        /// <returns></returns>
        public static bool User_IsAccountActive(int userAccountControl)
        {
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
        /// <param name="userAccountControl"></param>
        /// <returns></returns>
        public static bool User_IsAccountLockout(int userAccountControl)
        {

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
        /// Obtiene un FwkIdentity que reprecenta un grupo 
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
            SearchResultEntry entry;
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
                ProcessActiveDirectoryException(ex);
            }
            return domainList;
        }

        /// <summary>
        /// 
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
        /// Busca la lista de dominios en una base de datos
        /// </summary>
        /// <param name="cnnStringName">Nombre de la cadena de coneccion configurada</param>
        /// <returns>Lista de DomainsUrl</returns>
        public static List<DomainUrlInfo> DomainsUrl_GetList(string cnnStringName)
        {
            return DomainsUrl_GetList2(System.Configuration.ConfigurationManager.ConnectionStrings[cnnStringName].ConnectionString);
        }
        /// <summary>
        /// Busca la lista de dominios en una base de datos.- A diferencia de DomainsUrl_GetList. Este metodo recive como parametro 
        /// la cadena de coneccion y no su nombre de App.config
        /// </summary>
        /// <param name="cnnString">Cadena de coneccion</param>
        /// <returns>Lista de DomainsUrl</returns>
        public static List<DomainUrlInfo> DomainsUrl_GetList2(string cnnString)
        {
            try
            {
                using (SqlDomainURLDataContext dc = new SqlDomainURLDataContext(cnnString))
                {
                    IEnumerable<DomainUrlInfo> list = from s in dc.DomainsUrls
                                                   select
                                                       new DomainUrlInfo
                                                       {
                                                           DomainName = s.DomainName,
                                                           LDAPPath = s.LDAPPath,
                                                           Usr = s.Usr,
                                                           Pwd = s.Pwd
                                                       };

                    return list.ToList<DomainUrlInfo>();
                }
            }
            catch (Exception ex)
            {
                Fwk.Exceptions.TechnicalException te = new Fwk.Exceptions.TechnicalException("Error al intentar obtener la lista de dominios desde la base de datos: ", ex);
                ADHelper.SetError(te);
                te.ErrorId = "15004";
                throw te;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        static Exception ProcessActiveDirectoryException(Exception ex)
        {
            Fwk.Exceptions.TechnicalException te = new Fwk.Exceptions.TechnicalException(ex.Message, ex);
            SetError(te);
            switch (ex.GetType().FullName)
            {
                case "System.Runtime.InteropServices.COMException"://((System.Runtime.InteropServices.COMException)(ex)) "El servidor no es operacional.\r\n"
                    {
                        te.ErrorId = "15001";
                        break;
                    }
                case "System.DirectoryServices.DirectoryServicesCOMException": //Error de inicio de sesión: nombre de usuario desconocido o contraseña incorrecta.
                    {
                        te.ErrorId = "15002";
                        break;
                    }
                default:
                    {
                        te.ErrorId = "15000";
                        break;
                    }

            }

            return te;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="te"></param>
        static void SetError(Fwk.Exceptions.TechnicalException te)
        {
            te.Namespace = typeof(ADHelper).Namespace;
            te.Source = "Constructor fwk active directory component";
            te.UserName = Environment.UserName;
            te.UserName = Environment.MachineName;
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
        /// 
        /// </summary>
        /// <param name="pDirectoryEntry"></param>
        /// <returns></returns>
        static string EnlistValue(DirectoryEntry pDirectoryEntry)
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
        /// 
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
        /// Filters out the domain if one is passed in
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
    }


    #region Enumerations
    public enum ADAccountOptions
    {
        /// <summary>
        /// 
        /// </summary>
        UF_TEMP_DUPLICATE_ACCOUNT = 0x0100,
        /// <summary>
        /// 
        /// </summary>
        UF_NORMAL_ACCOUNT = 0x0200,
        /// <summary>
        /// Dec = 512 
        /// </summary>
        UF_INTERDOMAIN_TRUST_ACCOUNT = 0x0800,
        /// <summary>
        /// Dec =2048
        /// </summary>
        UF_WORKSTATION_TRUST_ACCOUNT = 0x1000,
        /// <summary>
        /// 
        /// </summary>
        UF_SERVER_TRUST_ACCOUNT = 0x2000,
        /// <summary>
        /// 
        /// </summary>
        UF_DONT_EXPIRE_PASSWD = 0x10000,
        /// <summary>
        /// 
        /// </summary>
        UF_SCRIPT = 0x0001,
        /// <summary>
        /// ACCOUNTDISABLE: la cuenta de usuario está desactivada. (dec = 2)
        /// </summary>
        UF_ACCOUNTDISABLE = 0x0002,
        /// <summary>
        /// HOMEDIR_REQUIRED: se requiere la carpeta principal. 
        /// </summary>
        UF_HOMEDIR_REQUIRED = 0x0008,
        /// <summary>
        /// 16
        /// </summary>
        UF_LOCKOUT = 0x0010,
        /// <summary>
        /// 
        /// </summary>
        UF_PASSWD_NOTREQD = 0x0020,
        /// <summary>
        /// 
        /// </summary>
        UF_PASSWD_CANT_CHANGE = 0x0040,
        /// <summary>
        /// 16
        /// </summary>
        UF_ACCOUNT_LOCKOUT = 0X0010,
        /// <summary>
        /// 
        /// </summary>
        UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED = 0X0080,
    }

    /// <summary>
    /// Determina el resultado de loging de usuario
    /// </summary>
    public enum LoginResult
    {
        /// <summary>
        /// Logoing exitoso
        /// </summary>
        LOGIN_OK = 0,

        /// <summary>
        /// Uario no existe
        /// </summary>
        LOGIN_USER_DOESNT_EXIST,

        /// <summary>
        /// Cuenta inactiva
        /// </summary>
        LOGIN_USER_ACCOUNT_INACTIVE,

        /// <summary>
        /// Clave incorrecta
        /// </summary>
        LOGIN_USER_OR_PASSWORD_INCORRECT,

        /// <summary>
        /// Cuenta de usuario bloqueada
        /// </summary>
        LOGIN_USER_ACCOUNT_LOCKOUT,
    }

    #endregion

}
