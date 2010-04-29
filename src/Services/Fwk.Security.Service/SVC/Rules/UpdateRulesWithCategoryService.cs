using System;
using System.Data;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;
using Fwk.Security.ISVC.RemoveUserFromRole;
using Fwk.Security;
using System.Web.Security;



namespace Fwk.Security.SVC
{
    class RemoveUserFromRoleService : BusinessService<RemoveUserFromRoleReq, RemoveUserFromRoleRes>
    {
        public override RemoveUserFromRoleRes Execute(RemoveUserFromRoleReq pServiceRequest)
        {
            RemoveUserFromRoleRes wRes = new RemoveUserFromRoleRes();

            if (string.IsNullOrEmpty(pServiceRequest.BusinessData.ApplicationName))
                pServiceRequest.BusinessData.ApplicationName = Membership.ApplicationName;


            FwkMembership.RemoveUserFromRole(pServiceRequest.BusinessData.UserName, pServiceRequest.BusinessData.RolName, pServiceRequest.SecurityProviderName);

            return wRes;
        }
    }
}
