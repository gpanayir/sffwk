using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using Fwk.Configuration;

namespace Fwk.Security.ActiveDirectory
{
    

    public class ADHelper
    {

        DirectoryEntry _directoryEntry;
        string _LDAPPath;
        /// <summary>
        ///Ej: LDAP://domain/DC=xxx,DC=com
        /// </summary>
        private String LDAPPath
        {
            get
            {
                return _LDAPPath;
            }
            set
            {
                _LDAPPath = value;
            }
        }

        string _LDAPUser;
        /// <summary>
        ///LDAPUser property
        /// </summary>
        private String LDAPUser
        {
            get
            {
                return _LDAPUser;
            }
            set
            {
                _LDAPUser = value;
            }
        }
        string _LDAPPassword;

        /// <summary>
        /// LDAPPassword property
        ///This property is reading the LDAP Password from the config file.
        /// </summary>
        private String LDAPPassword
        {
            get
            {
                return _LDAPPassword;
            }
            set
            {
                _LDAPPassword = value;
            }
        }

        string _LDAPDomain;

        /// <summary>
        /// Dominio
        /// </summary>
        private String LDAPDomain
        {
            get
            {
                return _LDAPDomain;
            }
            set
            {
                _LDAPDomain = value;
            }
        }

        /// <summary>
        /// Search Root Property
        /// Es una DirectoryEntry a la raiz del active directory 
        /// Utiliza par ala coneccion LDAPUser, LDAPPAth, and LDAPPassword.  
        /// </summary>
        private DirectoryEntry SearchRoot
        {
            get
            {
                if (_directoryEntry == null)
                {
                    _directoryEntry = new DirectoryEntry(LDAPPath, LDAPUser, LDAPPassword, AuthenticationTypes.Secure);
                }
                return _directoryEntry;
            }

        }

        #region users

        /// <summary>
        /// This function will take a full name as input parameter and return AD user corresponding to that. 
        /// </summary>
        /// <param name="userName">Nombre completo del usuario</param>
        /// <returns></returns>
        public ADUser User_GetByFullName(String userName)
        {
            _directoryEntry = null;
            try
            {
                
                DirectorySearcher directorySearch = new DirectorySearcher(SearchRoot);
                directorySearch.Filter = "(&(objectClass=user)(cn=" + userName + "))";
                SearchResult results = directorySearch.FindOne();

                if (results != null)
                {
                    DirectoryEntry userDirectoryEntry = new DirectoryEntry(results.Path, LDAPUser, LDAPPassword);
                    return new ADUser(userDirectoryEntry);
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    

        /// <summary>
        /// Retorna la lista de usuarios pertenecientes a un determinado grupo
        /// </summary>
        /// <param name="groupName">Nombre del grupo</param>
        /// <returns></returns>
        public List<ADUser> Users_SearchByGroup(String groupName)
        {

            List<ADUser> userlist = new List<ADUser>();
            _directoryEntry = null;
            try
            {
                DirectorySearcher directorySearch = new DirectorySearcher(SearchRoot);
                directorySearch.Filter = "(&(objectClass=group)(SAMAccountName=" + groupName + "))";
                SearchResult results = directorySearch.FindOne();
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

                        string path = respath + objpath;

                        DirectoryEntry user = new DirectoryEntry(path, LDAPUser, LDAPPassword);

                        ADUser userobj = new ADUser(user);

                        userlist.Add(userobj);

                        user.Close();

                    }

                }

                return userlist;

            }

            catch (Exception ex)
            {

                return userlist;

            }



        }

        /// <summary>
        /// Retorna una lista de usuarios cuyo nombre comiense con fname.-
        /// Ejemplo: evel*
        /// </summary>
        /// <param name="fName"></param>
        /// <returns></returns>
        public List<ADUser> Users_Search_StarName(string fName)
        {

            //UserProfile user;

            List<ADUser> userlist = new List<ADUser>();


            _directoryEntry = null;

            DirectorySearcher directorySearch = new DirectorySearcher(SearchRoot);

            directorySearch.Asynchronous = true;

            directorySearch.CacheResults = true;

            //directorySearch.Filter = "(&(objectClass=user)(SAMAccountName=" + userName + "))";

            string filter = string.Format("(givenName={0}*", fName);

            //filter = "(&(objectClass=user)(objectCategory=person)" + filter + ")";

            filter = "(&(objectClass=user)(objectCategory=person)(givenName=" + fName + "*))";
           
            directorySearch.Filter = filter;

            SearchResultCollection userCollection = directorySearch.FindAll();

            foreach (SearchResult users in userCollection)
            {
                DirectoryEntry userEntry = new DirectoryEntry(users.Path, LDAPUser, LDAPPassword);
                userlist.Add(new ADUser(userEntry));

            }



            directorySearch.Filter = "(&(objectClass=group)(SAMAccountName=" + fName + "*))";

            SearchResultCollection results = directorySearch.FindAll();

            if (results != null)
            {
                foreach (SearchResult r in results)
                {
                    DirectoryEntry deGroup = new DirectoryEntry(r.Path, LDAPUser, LDAPPassword);

                    // ADUserDetail dhan = new ADUserDetail();
                    ADUser agroup = new ADUser(deGroup);
                    userlist.Add(agroup);
                }
            }
            return userlist;
        }


        /// <summary>
        ///  This function will take a user login name and add this to a group of AD.
        /// </summary>
        /// <param name="userlogin"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public bool User_AddToGroup(string userlogin, string groupName)
        {

            try
            {

                _directoryEntry = null;

                ADManager admanager = new ADManager(LDAPDomain, LDAPUser, LDAPPassword);

                admanager.AddUserToGroup(userlogin, groupName);

                return true;

            }

            catch (Exception ex)
            {

                return false;

            }

        }


        /// <summary>
        /// Obtiene todo los usuarios pertenecientes al dominio.-
        /// Busca por cn nombre@mail retorna el sAMAccountName ejemplo: moviedo
        /// </summary>
        List<String> User_GetGroups(String pUserName)
        {
            List<String> list = new List<String>();
            DirectorySearcher directorySearch = new DirectorySearcher(SearchRoot);

            string filter = string.Format("(&(ObjectClass={0})(sAMAccountName={1}))", "person", pUserName);


            directorySearch.Filter = filter;
            SearchResult result = directorySearch.FindOne();
            DirectoryEntry directoryEntryUser = result.GetDirectoryEntry();

            ///TODO:Ver grupos de usuarios
            foreach (string grouInfo in directoryEntryUser.Properties["memberOf"])
            {
                list.Add(grouInfo);
            }
            directoryEntryUser.Close();
            return list;
        }



        /// <summary>
        /// This function will take a user login name and remove this to a group of AD.
        /// </summary>
        /// <param name="userlogin"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public bool User_RemoveToGroup(string userlogin, string groupName)
        {

            try
            {

                _directoryEntry = null;

                ADManager admanager = new ADManager("xxx", LDAPUser, LDAPPassword);

                admanager.RemoveUserFromGroup(userlogin, groupName);

                return true;

            }

            catch (Exception ex)
            {

                return false;

            }

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public  bool User_Exists(string UserName)
        {

            

            //create instance fo the direcory searcher
            DirectorySearcher deSearch = new DirectorySearcher(SearchRoot);

            //set the search filter
            deSearch.Filter = "(&(objectClass=user) (cn=" + UserName + "))";

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
        /// This method will not actually log a user in, but will perform tests to ensure
        /// that the user account exists (matched by both the username and password), and also
        /// checks if the account is active.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public LoginResult User_Login(string userName, string password)
        {
            //first, check if the logon exists based on the username and password
            //DirectoryEntry de = GetUser(UserName,Password);

            if (User_IsValid(userName, password))
            {
                ADUser de = User_GetByFullName(userName);
       
                if (de != null)
                {
                    
                    //convert the accountControl value so that a logical operation can be performed
                    //to check of the Disabled option exists.
                    int userAccountControl = Convert.ToInt32(de.UserAccountControl);
                  

                    //if the disabled item does not exist then the account is active
                    if (!User_IsAccountActive(userAccountControl))
                    {
                        return LoginResult.LOGIN_USER_ACCOUNT_INACTIVE;
                    }
                    else
                    {
                        return LoginResult.LOGIN_OK;
                    }

                }
                else
                {
                    return LoginResult.LOGIN_USER_DOESNT_EXIST;
                }
            }
            else
            {
                return LoginResult.LOGIN_USER_DOESNT_EXIST;
            }
        }

        /// <summary>
        /// This will perfrom a logical operation on the userAccountControl values
        /// to see if the user account is enabled or disabled.  The flag for determining if the
        /// account is active is a bitwise value (decimal =2)
        /// </summary>
        /// <param name="userAccountControl"></param>
        /// <returns></returns>
        public  bool User_IsAccountActive(int userAccountControl)
        {
            int userAccountControl_Disabled = Convert.ToInt32(ADAccountOptions.UF_ACCOUNTDISABLE);
            int flagExists = userAccountControl & userAccountControl_Disabled;
            //if a match is found, then the disabled flag exists within the control flags
            if (flagExists > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// This method will attempt to log in a user based on the username and password
        /// to ensure that they have been set up within the Active Directory.  This is the basic UserName, Password
        /// check.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public  bool User_IsValid(string userName, string password)
        {
            try
            {
                //if the object can be created then return true
                DirectoryEntry deUser = User_Get(userName, password);
                deUser.Close();
                return true;
            }
            catch (Exception)
            {
                //otherwise return false
                return false;
            }
        }


        #endregion

        #region Groups
        /// <summary>
        /// Obtiene un FwkIdentity que reprecenta un grupo 
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        public ADGroup GetGroup(String pName)
        {
            string filter = string.Format("(&(ObjectClass={0})(sAMAccountName={1}))", "group", pName);

            DirectorySearcher directorySearch = new DirectorySearcher(SearchRoot);
            directorySearch.Filter = filter;
            SearchResult result = directorySearch.FindOne();
            if (result == null) return null;
            DirectoryEntry directoryEntry = result.GetDirectoryEntry();

            ADGroup wObjectDomainGroup = new ADGroup(directoryEntry, LDAPDomain);
        
            return wObjectDomainGroup;

        }


        #endregion

        /// <summary>
        /// This will return a DirectoryEntry object if the user does exist
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public DirectoryEntry User_Get(string UserName)
        {
            //create an instance of the DirectoryEntry
            DirectoryEntry de = GetDirectoryObject();

            //create instance fo the direcory searcher
            DirectorySearcher deSearch = new DirectorySearcher();

            deSearch.SearchRoot = de;
            //set the search filter
            deSearch.Filter = "(&(objectClass=user)(cn=" + UserName + "))";
            deSearch.SearchScope = SearchScope.Subtree;

            //find the first instance
            SearchResult results = deSearch.FindOne();

            //if found then return, otherwise return Null
            if (results != null)
            {
                de = new DirectoryEntry(results.Path, LDAPUser, LDAPPassword, AuthenticationTypes.Secure);
                //if so then return the DirectoryEntry object
                return de;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Override method which will perfrom query based on combination of username and password
        /// This is used with the login process to validate the user credentials and return a user
        /// object for further validation.  This is slightly different from the other GetUser... methods as this
        /// will use the UserName and Password supplied as the authentication to check if the user exists, if so then
        /// the users object will be queried using these credentials.s
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public DirectoryEntry User_Get(string UserName, string Password)
        {
            
            //create an instance of the DirectoryEntry
            DirectoryEntry de = GetDirectoryObject(UserName, Password);

            //create instance fo the direcory searcher
            DirectorySearcher deSearch = new DirectorySearcher();

            deSearch.SearchRoot = de;
            //set the search filter
            deSearch.Filter = "(&(objectClass=user)(cn=" + UserName + "))";
            deSearch.SearchScope = SearchScope.Subtree;

            //set the property to return
            //deSearch.PropertiesToLoad.Add("givenName");

            //find the first instance
            SearchResult results = deSearch.FindOne();

            //if a match is found, then create directiry object and return, otherwise return Null
            if (results != null)
            {
                //create the user object based on the admin priv.
                de = new DirectoryEntry(results.Path, LDAPUser, LDAPPassword, AuthenticationTypes.Secure);
                return de;
            }
            else
            {
                return null;
            }


        }


        public static String GetProperty(DirectoryEntry userDetail, String propertyName)
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

        /// <summary>
        /// This is an internal method for retreiving a new directoryentry object
        /// </summary>
        /// <returns></returns>
        private  DirectoryEntry GetDirectoryObject()
        {
            DirectoryEntry oDE;

            oDE = new DirectoryEntry(LDAPPath, LDAPUser, LDAPPassword, AuthenticationTypes.Secure);

            return oDE;
        }

        /// <summary>
        /// Override function that that will attempt a logon based on the users credentials
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        private  DirectoryEntry GetDirectoryObject(string UserName, string Password)
        {
            DirectoryEntry oDE;

            oDE = new DirectoryEntry(LDAPPath, UserName, Password, AuthenticationTypes.Secure);

            return oDE;
        }

        /// <summary>
        /// This will create the directory entry based on the domain object to return
        /// The DomainReference will contain the qualified syntax for returning an entry
        /// at the location rather than returning the root.  
        /// i.e. /CN=Users,DC=creditsights, DC=cyberelves, DC=Com
        /// </summary>
        /// <param name="DomainReference"></param>
        /// <returns></returns>
        private  DirectoryEntry GetDirectoryObject(string DomainReference)
        {
            DirectoryEntry oDE;

            oDE = new DirectoryEntry(LDAPPath + DomainReference, LDAPUser, LDAPPassword, AuthenticationTypes.Secure);

            return oDE;
        }

        /// <summary>
        /// Addition override that will allow ovject to be created based on the users credentials.
        /// This is useful for instances such as setting password etc.
        /// </summary>
        /// <param name="DomainReference"></param>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        private  DirectoryEntry GetDirectoryObject(string DomainReference, string UserName, string Password)
        {
            DirectoryEntry oDE;

            oDE = new DirectoryEntry(LDAPPath + DomainReference, UserName, Password, AuthenticationTypes.Secure);

            return oDE;
        }

    }


    #region Enumerations
    public enum ADAccountOptions
    {
        UF_TEMP_DUPLICATE_ACCOUNT = 0x0100,
        UF_NORMAL_ACCOUNT = 0x0200,
        UF_INTERDOMAIN_TRUST_ACCOUNT = 0x0800,
        UF_WORKSTATION_TRUST_ACCOUNT = 0x1000,
        UF_SERVER_TRUST_ACCOUNT = 0x2000,
        UF_DONT_EXPIRE_PASSWD = 0x10000,
        UF_SCRIPT = 0x0001,
        UF_ACCOUNTDISABLE = 0x0002,
        UF_HOMEDIR_REQUIRED = 0x0008,
        UF_LOCKOUT = 0x0010,
        UF_PASSWD_NOTREQD = 0x0020,
        UF_PASSWD_CANT_CHANGE = 0x0040,
        UF_ACCOUNT_LOCKOUT = 0X0010,
        UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED = 0X0080,
    }


    public enum LoginResult
    {
        LOGIN_OK = 0,
        LOGIN_USER_DOESNT_EXIST,
        LOGIN_USER_ACCOUNT_INACTIVE
    }

    #endregion
    
}
