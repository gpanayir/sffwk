using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Fwk.Security.ISVC.GetAllActiveUsersInfo;
using Fwk.Security.BC;


namespace Fwk.Security.SVC
{
    public class GetAllActiveUsersInfoService : BusinessService<GetAllActiveUsersInfoRequest, GetAllActiveUsersInfoResponse>
    {
        public override GetAllActiveUsersInfoResponse Execute(GetAllActiveUsersInfoRequest pServiceRequest)
        {
            GetAllActiveUsersInfoResponse response = new GetAllActiveUsersInfoResponse();
            UserBC userBC = new UserBC(pServiceRequest.ContextInformation.CompanyId, pServiceRequest.SecurityProviderName);

            response.BusinessData = userBC.GetAllActiveUsersInfo();

            return response;
        }
    }
}
