using System;
using System.Data;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;
using Fwk.Security.ISVC.UpdateActiveFlagUser;
using Fwk.Security.BC;


namespace Fwk.Security.SVC
{

    public class UpdateActiveFlagUserService : BusinessService<UpdateActiveFlagUserReq, UpdateActiveFlagUserRes>
    {
        public override UpdateActiveFlagUserRes Execute(UpdateActiveFlagUserReq pServiceRequest)
        {
            UpdateActiveFlagUserRes wRes = new UpdateActiveFlagUserRes();


            UserBC wUserBC = new UserBC(pServiceRequest.ContextInformation.CompanyId, pServiceRequest.SecurityProviderName);

            wUserBC.ChangeActiveFlag(pServiceRequest.BusinessData.UserName, pServiceRequest.BusinessData.ActiveFlag);


            return wRes;
        }
    }
}
        