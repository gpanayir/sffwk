using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Fwk.Security.ISVC.GetUser;

using Fwk.Security;
using Fwk.Security;
using Fwk.Security.Common;
using System.Web.Security;

namespace Fwk.Security.SVC
{


    public class GetUserService : BusinessService<GetUserReq, GetUserRes>
    {
        public override GetUserRes Execute(GetUserReq pServiceRequest)
        {
            GetUserRes res = new GetUserRes();

            if (string.IsNullOrEmpty(pServiceRequest.BusinessData.ApplicationName))
                pServiceRequest.BusinessData.ApplicationName = Membership.ApplicationName;

            res.BusinessData.User = FwkMembership.GetUser(pServiceRequest.BusinessData.Username, pServiceRequest.ContextInformation.CompanyId);

            return res;
        }
    }
}
