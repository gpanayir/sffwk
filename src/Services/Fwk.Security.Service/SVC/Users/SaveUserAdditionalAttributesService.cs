using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Fwk.Security.ISVC.GetUserAdditionalAttributes_ByParam;
using Fwk.Security;
using Fwk.Security.ISVC.SaveUserAdditionalAttributes;
using Fwk.Security.BC;

namespace Fwk.Security.SVC
{
    public class SaveUserAdditionalAttributesService : BusinessService<SaveUserAdditionalAttributesRequest, SaveUserAdditionalAttributesResponse>
    {
        public override SaveUserAdditionalAttributesResponse Execute(SaveUserAdditionalAttributesRequest pServiceRequest)
        {
            SaveUserAdditionalAttributesResponse wRes = new SaveUserAdditionalAttributesResponse();
            UserBC wUserBC = new UserBC(pServiceRequest.ContextInformation.CompanyId, pServiceRequest.SecurityProviderName);
            wUserBC.SaveUserAdditionalAttributes(pServiceRequest.BusinessData.AdditionalAttributes);

            return wRes;
        }
    }
}