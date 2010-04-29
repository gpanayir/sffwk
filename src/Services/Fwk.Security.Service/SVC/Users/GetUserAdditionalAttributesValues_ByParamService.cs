using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Fwk.Security.ISVC.GetUserAdditionalAttributes_ByParam;
using Fwk.Security;
using Fwk.Security.ISVC.GetUserAdditionalAttributesValues;
using Fwk.Security.BC;


namespace Fwk.Security.SVC
{
    public class GetUserAdditionalAttributesValues_ByParamService : BusinessService<GetUserAdditionalAttributesValues_ByParamRequest, GetUserAdditionalAttributesValues_ByParamResponse>
    {
        public override GetUserAdditionalAttributesValues_ByParamResponse Execute(GetUserAdditionalAttributesValues_ByParamRequest pServiceRequest)
        {
            GetUserAdditionalAttributesValues_ByParamResponse wRes = new GetUserAdditionalAttributesValues_ByParamResponse();
            UserBC wUserBC = new UserBC(pServiceRequest.ContextInformation.CompanyId, pServiceRequest.SecurityProviderName);
             wRes.BusinessData.AttributesValues = wUserBC.GetUserAdditionalAttributesValues_ByParam(pServiceRequest);

            return wRes;
        }
    }
}