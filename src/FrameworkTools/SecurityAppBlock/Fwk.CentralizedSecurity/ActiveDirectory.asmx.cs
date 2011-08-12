using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Fwk.CentralizedSecurity.Contracts;
using Fwk.CentralizedSecurity.Service;

namespace Fwk.CentralizedSecurity
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class ActiveDirectory : System.Web.Services.WebService
    {

        [WebMethod]
        public LoogonUserResult Autenticate(string userName, string password, string domain)
        {
            return ActiveDirectoryService.User_Logon(userName, password, domain);
        }

        [WebMethod]
        public bool User_Exist(string userName, string domain)
        {
            return ActiveDirectoryService.UserExist(userName,  domain);
        }

        [WebMethod]
        public ActiveDirectoryGroup[] Retrive_User_Groups(string userName, string domain)
        {
            return ActiveDirectoryService.GetGroupsFromUser(userName, domain);
        }

        [WebMethod]
        public ActiveDirectoryUser[] Retrive_Users_By_Group(string groupName,string domain)
        {
            return ActiveDirectoryService.GetUsersFromGroup(groupName,domain);
        }


        [WebMethod]
        public ActiveDirectoryGroup[] Retrive_Groups(string domain)
        {
            return ActiveDirectoryService.GetGroups( domain);
        }


       

        [WebMethod]
        public Fwk.CentralizedSecurity.Contracts.DomainsUrl[] Retrive_DomainsUrl()
        {
            return ActiveDirectoryService.GetAllDomainsUrl();
        }

        [WebMethod]
        public void User_Reset_Password(string userName,string newPassword,string domain)
        {
            ActiveDirectoryService.User_Reset_Password(userName, newPassword, domain);
        }


        [WebMethod]
        public void User_SetActivation(string userName, bool disabled, string domain)
        {
            ActiveDirectoryService.User_SetActivation(userName, disabled, domain);
        }

        [WebMethod]
        public void User_Unlock(string userName, string domain)
        {
            ActiveDirectoryService.User_Unlock(userName, domain);
        }

        [WebMethod]
        public void User_Lock(string userName, string domain)
        {
            ActiveDirectoryService.User_Lock(userName, domain);
        }
    }
}
