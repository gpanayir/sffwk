using System;
using System.Data;
using System.Web.Security;
using System.Collections.Generic;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;
using Fwk.Security.ISVC.GetAllUsers;
using Fwk.Security.Common;
using Fwk.Security.DAC;
using Fwk.Security.BC;


namespace Fwk.Security.SVC
{
    public class GetAllUsersService : BusinessService<GetAllUsersReq, GetAllUsersRes>
    {
        public override GetAllUsersRes Execute(GetAllUsersReq pServiceRequest)
        {
            GetAllUsersRes wRes = new GetAllUsersRes();
            UserBC wBC = new UserBC(pServiceRequest.ContextInformation.CompanyId,pServiceRequest.SecurityProviderName);

            //if (string.IsNullOrEmpty(pServiceRequest.BusinessData.ApplicationName))
            //    pServiceRequest.BusinessData.ApplicationName = Membership.ApplicationName;

            wRes.BusinessData.UsersCustom = wBC.GetAllUser(wRes.BusinessData.UserList, pServiceRequest.BusinessData.CustomStoredProcedure);
            

            return wRes;
        }
    }
}