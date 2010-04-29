using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Fwk.Security.ISVC.GetUserAdditionalAttributes_ByParam;
using Fwk.Security;
using Fwk.Security.ISVC.SaveUserAdditionalAttributes;
using Fwk.Security.ISVC.SaveUserAdditionalAttributesValues;
using Fwk.Security.BC;

namespace Fwk.Security.SVC
{
    public class SaveUserAdditionalAttributesValuesService : BusinessService<SaveUserAdditionalAttributesValuesRequest, SaveUserAdditionalAttributesValuesResponse>
    {
        public override SaveUserAdditionalAttributesValuesResponse Execute(SaveUserAdditionalAttributesValuesRequest pServiceRequest)
        {
            SaveUserAdditionalAttributesValuesResponse wRes = new SaveUserAdditionalAttributesValuesResponse();
            UserBC wUserBC = new UserBC(pServiceRequest.ContextInformation.CompanyId, pServiceRequest.SecurityProviderName);
            wUserBC.SaveUserAdditionalAttributesValues(pServiceRequest.BusinessData.AdditionalAttributesValues);

            return wRes;
        }
    }
}
