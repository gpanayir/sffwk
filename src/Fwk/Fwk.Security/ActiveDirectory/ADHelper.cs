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
        private String LDAPDomain
        {

            get
            {

                return System.Configuration.ConfigurationManager.AppSettings["LDAPDomain"];

            }

        }

 

        /// <summary>
        /// Search Root Property
        ///This Property is initializing the Directory entry by passing the LDAPUser, LDAPPAth, and LDAPPassword.  This property is creating a new instance DirectoryEntry and returning that.
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


        /// <summary>
        /// This function will take a full name as input parameter and return AD user corresponding to that. 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public ADUserDetail GetUserByFullName(String userName)
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
                    return ADUserDetail.GetUser(user);
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

        ///// <summary>
        ///// This function will return AD user. This takes Login name as input parameter. 
        ///// </summary>
        ///// <param name="userName"></param>
        ///// <returns></returns>
        //public ADUserDetail GetUserByLoginName(String userName)
        //{

        //    try
        //    {

        //        _directoryEntry = null;

        //        DirectorySearcher directorySearch = new DirectorySearcher(SearchRoot);

        //        directorySearch.Filter = "(&(objectClass=user)(SAMAccountName=" + userName + "))";

        //        SearchResult results = directorySearch.FindOne();



        //        if (results != null)
        //        {

        //            DirectoryEntry user = new DirectoryEntry(results.Path, LDAPUser, LDAPPassword);

        //            return ADUserDetail.GetUser(user);

        //        }

        //        return null;

        //    }

        //    catch (Exception ex)
        //    {

        //        return null;

        //    }

        //}

        /// <summary>
        /// This function will take a group name as input and return list of AD User in that group.
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public List<ADUserDetail> GetUserFromGroup(String groupName)
        {

            List<ADUserDetail> userlist = new List<ADUserDetail>();

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

                        ADUserDetail userobj = ADUserDetail.GetUser(user);

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
        public List<ADUserDetail> GetUsersByFirstName(string fName)
        {

            //UserProfile user;

            List<ADUserDetail> userlist = new List<ADUserDetail>();

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

                ADUserDetail userInfo = ADUserDetail.GetUser(userEntry);





                userlist.Add(userInfo);

            }



            directorySearch.Filter = "(&(objectClass=group)(SAMAccountName=" + fName + "*))";

            SearchResultCollection results = directorySearch.FindAll();

            if (results != null)
            {
                foreach (SearchResult r in results)
                {
                    DirectoryEntry deGroup = new DirectoryEntry(r.Path, LDAPUser, LDAPPassword);

                    // ADUserDetail dhan = new ADUserDetail();
                    ADUserDetail agroup = ADUserDetail.GetUser(deGroup);
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
        public bool AddUserToGroup(string userlogin, string groupName)
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
        /// This function will take a user login name and remove this to a group of AD.
        /// </summary>
        /// <param name="userlogin"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public bool RemoveUserToGroup(string userlogin, string groupName)
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
    }
}
