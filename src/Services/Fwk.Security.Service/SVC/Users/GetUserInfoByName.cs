using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Fwk.Security.ISVC.GetUserInfoByName;

using Fwk.Security;
using Fwk.Security.BC;
using Fwk.Security.Common;

namespace Fwk.Security.SVC
{
    public class GetUserInfoByName : BusinessService<GetUserInfoByNameRequest, GetUserInfoByNameResponse>
    {
        public override GetUserInfoByNameResponse Execute(GetUserInfoByNameRequest pServiceRequest)
        {
            GetUserInfoByNameResponse wRes = new GetUserInfoByNameResponse();
            UserBC userBC = new UserBC(pServiceRequest.ContextInformation.CompanyId, pServiceRequest.SecurityProviderName);

            RolList wRolList = new RolList();

            userBC.GetUserInfoByName(pServiceRequest.BusinessData.UserName, out wRes.BusinessData.UserInfo, out wRolList);
            wRes.BusinessData.RolList = wRolList;
            
            return wRes;
        }
    }
}