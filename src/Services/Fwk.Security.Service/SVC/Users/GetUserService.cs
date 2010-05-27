using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using Fwk.Bases;
using Fwk.Security.ISVC.GetUser;
using Fwk.Security;
using Fwk.Security.Common;
using Fwk.Security.BC;

namespace Fwk.Security.SVC
{


    public class GetUserService : BusinessService<GetUserReq, GetUserRes>
    {
        public override GetUserRes Execute(GetUserReq pServiceRequest)
        {
            GetUserRes wRes = new GetUserRes();
            UserBC wBC = new UserBC(pServiceRequest.ContextInformation.CompanyId,pServiceRequest.SecurityProviderName);
            User wUser = new User(pServiceRequest.BusinessData.Username);
            
            //if (string.IsNullOrEmpty(pServiceRequest.BusinessData.ApplicationName))
            //    pServiceRequest.BusinessData.ApplicationName = Membership.ApplicationName;

            wRes.BusinessData.CustomUser = wBC.GetUser(pServiceRequest.BusinessData.Username,
                                                pServiceRequest.BusinessData.CustomParameters,
                                                pServiceRequest.BusinessData.CustomStoredProcedure,
                                                wUser);

            wRes.BusinessData.User = wUser;

            return wRes;
        }
    }
}
