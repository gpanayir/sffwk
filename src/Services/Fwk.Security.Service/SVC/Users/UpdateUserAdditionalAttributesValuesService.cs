using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Fwk.Security.ISVC.GetUserAdditionalAttributes_ByParam;
using Fwk.Security;
using Fwk.Security.ISVC.UpdateUserAdditionalAttributesValues;
using Fwk.Security.BC;



namespace Fwk.Security.SVC
{
    public class UpdateUserAdditionalAttributesValuesService : BusinessService<UpdateUserAdditionalAttributesValuesRequest, UpdateUserAdditionalAttributesValuesResponse>
    {
        public override UpdateUserAdditionalAttributesValuesResponse Execute(UpdateUserAdditionalAttributesValuesRequest pServiceRequest)
        {
            UpdateUserAdditionalAttributesValuesResponse wRes = new UpdateUserAdditionalAttributesValuesResponse();
            UserBC wUserBC = new UserBC(pServiceRequest.ContextInformation.CompanyId, pServiceRequest.SecurityProviderName);
            wUserBC.UpdateUserAdditionalAttributes(pServiceRequest.BusinessData.AdditionalAttributesValues);

            return wRes;
        }
    }
}