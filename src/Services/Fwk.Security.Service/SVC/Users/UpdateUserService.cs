using System;
using System.Data;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;
using Fwk.Security.ISVC.UpdateUser;
using System.Web.Security;
using Fwk.Security.Common;
using Fwk.Security.BC;


namespace Fwk.Security.SVC
{
    public class UpdateUserService : BusinessService<UpdateUserReq, UpdateUserRes>
    {
        public override UpdateUserRes Execute(UpdateUserReq pServiceRequest)
        {
            UpdateUserRes wRes = new UpdateUserRes();
            UserBC wUserBC = new UserBC(pServiceRequest.ContextInformation.CompanyId, pServiceRequest.SecurityProviderName);
            if (pServiceRequest.BusinessData.ChangePassword != null)
            {
                wUserBC.ChangePassword(pServiceRequest.BusinessData.UsersBE.Name, pServiceRequest.BusinessData.ChangePassword.Old, pServiceRequest.BusinessData.ChangePassword.New);
            }
            //Si solo se actualiza la password
            if (!pServiceRequest.BusinessData.PasswordOnly )
            {

                wUserBC.Update(pServiceRequest.BusinessData.UsersBE, pServiceRequest.BusinessData.RolList);
            }

            return wRes;
        }
    }
}
