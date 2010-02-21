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
        /// <summary>
        /// LDAPPath property
        ///This property is reading the LDAPPath from config file. 
        /// </summary>
        private String LDAPPath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["LDAPPath"];
            }
        }

        /// <summary>
        ///LDAPUser property
        ///This property is reading the LDAP user from the config file.
        /// </summary>
        private String LDAPUser
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["LDAPUser"];
            }
        }

        /// <summary>
        /// LDAPPassword property
        ///This property is reading the LDAP Password from the config file.
        /// </summary>
        private String LDAPPassword
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["LDAPPassword"];
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private String LDAPDomain
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["LDAPDomain"];
            }
        }

        /// <summary>
        /// Search Root Property
        ///This Property is initializing the Directory entry by passing the LDAPUser, LDAPPAth, and LDAPPassword.  
        ///This property is creating a new instance DirectoryEntry and returning that.
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
            try
            {
                _directoryEntry = null;
                DirectorySearcher directorySearch = new DirectorySearcher(SearchRoot);
                directorySearch.Filter = "(&(objectClass=user)(cn=" + userName + "))";
                SearchResult results = directorySearch.FindOne();

                if (results != null)
                {
                    DirectoryEntry user = new DirectoryEntry(results.Path, LDAPUser, LDAPPassword);
                    return ADUser.GetUser(user);
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
    

        /// <summary>
        /// This function will take a group name as input and return list of AD User in that group.
        /// </summary>
        /// <param name="groupName">Nombre del grupo</param>
        /// <returns></returns>
        public List<ADUser> Users_GetFromGroup(String groupName)
        {

            List<ADUser> userlist = new List<ADUser>();

            try
            {

                _directoryEntry = null;

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

                        ADUser userobj = ADUser.GetUser(user);

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
        /// This function will return Users and Group information from AD on basis of first characters. Wild character * is used to filter the criteria. 
        /// </summary>
        /// <param name="fName"></param>
        /// <returns></returns>
        public List<ADUser> User_GetByFirstName(string fName)
        {

            //UserProfile user;

            List<ADUser> userlist = new List<ADUser>();

            string filter = "";



            _directoryEntry = null;

            DirectorySearcher directorySearch = new DirectorySearcher(SearchRoot);

            directorySearch.Asynchronous = true;

            directorySearch.CacheResults = true;

            //directorySearch.Filter = "(&(objectClass=user)(SAMAccountName=" + userName + "))";

            filter = string.Format("(givenName={0}*", fName);

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
                    ADUser agroup = ADUser.GetUser(deGroup);
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

        #endregion

        #region Groups
        /// <summary>
        /// Obtiene un FwkIdentity que reprecenta un grupo 
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        public ObjectDomainGroup GetGroup(String pName)
        {
            string filter = string.Format("(&(ObjectClass={0})(sAMAccountName={1}))", "group", pName);


            _Searcher.Filter = filter;
            SearchResult result = _Searcher.FindOne();
            if (result == null) return null;
            DirectoryEntry directoryEntry = result.GetDirectoryEntry();

            Fwk.Security.Common.ObjectDomainGroup wObjectDomainGroup = new ObjectDomainGroup(directoryEntry);
            wObjectDomainGroup.Domain = _Domain;
            return wObjectDomainGroup;

        }


        #endregion




        private static String GetProperty(DirectoryEntry userDetail, String propertyName)
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
    }
}
