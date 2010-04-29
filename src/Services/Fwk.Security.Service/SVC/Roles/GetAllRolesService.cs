
using System;
using System.Data;
using Fwk.Bases;
using Fwk.Security;
using Fwk.Security.BE;
using Fwk.Security;

using System.Web.Security;
using System.Collections.Generic;
using Fwk.Security.ISVC.GetAllRoles;




namespace Fwk.Security.SVC
{
    public class GetAllRolesService : BusinessService<GetAllRolesReq, GetAllRolesRes>
    {
        public override GetAllRolesRes Execute(GetAllRolesReq pServiceRequest)
        {
            GetAllRolesRes wRes = new GetAllRolesRes();

       

             wRes.BusinessData = new Result();

            if(string.IsNullOrEmpty( pServiceRequest.BusinessData.UserName))
                wRes.BusinessData.RolList = FwkMembership.GetAllRoles(pServiceRequest.SecurityProviderName);
            else
                wRes.BusinessData.RolList = FwkMembership.GetRolesForUser(pServiceRequest.BusinessData.UserName, pServiceRequest.SecurityProviderName);



            return wRes;
        }
    }
}
