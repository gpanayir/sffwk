using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fwk.Security.ActiveDirectory;
using Fwk.Exceptions;
using Fwk.CentralizedSecurity.Contracts;

namespace Fwk.CentralizedSecurity.Service
{
    public class ActiveDirectoryService
    {
       public static string CnnStringName =  "ActiveDirectory";


        internal static LoogonUserResult User_Logon(string userName, string password, string domain)
        {
            LoogonUserResult loogonUserResult = new LoogonUserResult();
            loogonUserResult.Autenticated = false;
            try
            {
                LDAPHelper _ADHelper = new LDAPHelper(domain, ActiveDirectoryService.CnnStringName, true, false);
                TechnicalException logError = null;

                loogonUserResult.LogResult = _ADHelper.User_Logon(userName, password, out logError).ToString();

                if (logError != null)
                    loogonUserResult.ErrorMessage = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(logError);
                else
                {
                    loogonUserResult.ErrorMessage = string.Empty;
                    loogonUserResult.Autenticated = true;
                }


            }
            catch (Exception ex)
            {
                loogonUserResult.ErrorMessage = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);


            }
            return loogonUserResult;
        }

        internal static ActiveDirectoryGroup[] GetGroupsFromUser(string userName, string domain)
        {
            ADHelper ad = new ADHelper(domain, ActiveDirectoryService.CnnStringName);
     
            List<ADGroup> list = ad.User_SearchGroupList(userName);

            if (list.Count != 0)
            {
                var activeDirectoryGroupList = from g in list select new ActiveDirectoryGroup(g);

                return activeDirectoryGroupList.ToArray<ActiveDirectoryGroup>();
            }
            else
                return null;
        }


        internal static ActiveDirectoryUser[] GetUsersFromGroup(string groupName, string domain)
        {
            ADHelper ad = new ADHelper(domain, ActiveDirectoryService.CnnStringName);

            List<ADUser> list = ad.Users_SearchByGroupName(groupName);

            if (list.Count != 0)
            {
                var userList = from u in list select new ActiveDirectoryUser(u);

                return userList.ToArray<ActiveDirectoryUser>();
            }
            else
                return null;
        }


        internal static bool UserExist(string userName, string domain)
        {
            ADHelper ad = new ADHelper(domain, ActiveDirectoryService.CnnStringName);

            return ad.User_Exists(userName);
            
        }

        internal static ActiveDirectoryGroup[] GetGroups(string domain)
        {
           ADHelper ad = new ADHelper(domain, ActiveDirectoryService.CnnStringName);
     
            List<ADGroup> list = ad.Groups_GetAll();

            if (list.Count != 0)
            {
                var userList = from u in list select new ActiveDirectoryGroup(u);

                return userList.ToArray<ActiveDirectoryGroup>();
            }
            else
                return null;
        }

       

        internal static void User_Unlock(string userName, string domain)
        {
            ADHelper ad = new ADHelper(domain, ActiveDirectoryService.CnnStringName);

            ad.User_Unlock(userName);
        }

        internal static void User_Lock(string userName, string domain)
        {
            ADHelper ad = new ADHelper(domain, ActiveDirectoryService.CnnStringName);

            ad.User_SetLockedStatus(userName,true);
        }



        internal static void User_SetActivation(string userName, bool disabled, string domain)
        {
             ADHelper ad = new ADHelper(domain, ActiveDirectoryService.CnnStringName);

             ad.User_SetActivation(userName, disabled);
        }

        internal static void User_Reset_Password(string userName, string newPassword, string domain)
        {
            ADHelper ad = new ADHelper(domain, ActiveDirectoryService.CnnStringName);

            ad.User_ResetPwd(userName, newPassword ,true);
        }





        internal static Fwk.CentralizedSecurity.Contracts.DomainsUrl[] GetAllDomainsUrl()
        {

            List<DomainUrlInfo> auxlist = ADHelper.DomainsUrl_GetList2(ActiveDirectoryService.CnnStringName);

            if (auxlist.Count != 0)
            {
                var list = from d in auxlist select new Fwk.CentralizedSecurity.Contracts.DomainsUrl(d);

                return list.ToArray<Fwk.CentralizedSecurity.Contracts.DomainsUrl>();
            }
            else
                return null;


        }

    }

    
}
