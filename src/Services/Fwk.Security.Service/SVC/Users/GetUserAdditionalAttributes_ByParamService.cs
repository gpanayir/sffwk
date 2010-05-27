using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Fwk.Security.ISVC.GetUserAdditionalAttributes_ByParam;
using Fwk.Security;
using Fwk.Security.BC;


namespace Fwk.Security.SVC
{
    public class GetUserAdditionalAttributes_ByParamService : BusinessService<GetUserAdditionalAttributes_ByParamRequest, GetUserAdditionalAttributes_ByParamResponse>
    {
        public override GetUserAdditionalAttributes_ByParamResponse Execute(GetUserAdditionalAttributes_ByParamRequest pServiceRequest)
        {
            GetUserAdditionalAttributes_ByParamResponse wRes = new GetUserAdditionalAttributes_ByParamResponse();
            UserBC wUserBC = new UserBC(pServiceRequest.ContextInformation.CompanyId, pServiceRequest.SecurityProviderName);
             wRes.BusinessData.AdditionalAttributes = wUserBC.GetUserAdditionalAttributes_ByParam(pServiceRequest.BusinessData.ActiveFlag);

            return wRes;
        }
    }
}