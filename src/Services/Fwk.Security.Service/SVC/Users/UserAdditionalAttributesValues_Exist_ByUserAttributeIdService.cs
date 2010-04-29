using System;
using System.Data;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;
using Fwk.Security.ISVC.UpdateUser;
using Fwk.Security;
using System.Web.Security;
using Fwk.Security.Common;
using Fwk.Security.ISVC.UserAdditionalAttributesValues_Exist_ByUserAttributeId;
using Fwk.Security.BC;

namespace Fwk.Security.SVC
{
    public class UserAdditionalAttributesValues_Exist_ByUserAttributeIdService : BusinessService<UserAdditionalAttributesValues_Exist_ByUserAttributeIdRequest, UserAdditionalAttributesValues_Exist_ByUserAttributeIdResponse>
    {
        public override UserAdditionalAttributesValues_Exist_ByUserAttributeIdResponse Execute(UserAdditionalAttributesValues_Exist_ByUserAttributeIdRequest pServiceRequest)
        {
            UserAdditionalAttributesValues_Exist_ByUserAttributeIdResponse wRes = new UserAdditionalAttributesValues_Exist_ByUserAttributeIdResponse();

            UserBC wUserBC = new UserBC(pServiceRequest.ContextInformation.CompanyId, pServiceRequest.SecurityProviderName);
             wRes.BusinessData.ExistAttributeValue = wUserBC.GetUserAdditionalAttributesValues_ByUserAttributeId(pServiceRequest.BusinessData.UserAttributeId);

            return wRes;
        }
    }
}