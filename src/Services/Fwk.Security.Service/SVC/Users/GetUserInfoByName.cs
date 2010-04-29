using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Fwk.Security.ISVC.GetUserInfoByName;

using Fwk.Security;
using Fwk.Security.BC;

namespace Fwk.Security.SVC
{
    public class GetUserInfoByName : BusinessService<GetUserInfoByNameRequest, GetUserInfoByNameResponse>
    {
        public override GetUserInfoByNameResponse Execute(GetUserInfoByNameRequest pServiceRequest)
        {
            GetUserInfoByNameResponse response = new GetUserInfoByNameResponse();
            UserBC userBC = new UserBC(pServiceRequest.ContextInformation.CompanyId, pServiceRequest.SecurityProviderName);

            response.BusinessData = userBC.GetUserInfoByName(pServiceRequest.BusinessData.Name);

            return response;
        }
    }
}