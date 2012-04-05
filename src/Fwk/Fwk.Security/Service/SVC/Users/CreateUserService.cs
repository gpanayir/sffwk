
using System;
using System.Data;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;

using Fwk.Security.ISVC.CreateUsers;
using Fwk.Security.BC;


namespace Fwk.Security.SVC
{
    /// <summary>
    /// Servicio que crea un usuario en las memberships
    /// </summary>
    public class CreateUserService : BusinessService<CreateUserReq, CreateUserRes>
    {
        public override CreateUserRes Execute(CreateUserReq pServiceRequest)
        {

            CreateUserRes wRes = new CreateUserRes();
            UserBC wUserBC = new UserBC(pServiceRequest.ContextInformation.CompanyId, pServiceRequest.SecurityProviderName);

            wUserBC.Create(pServiceRequest.BusinessData.User);

            //TODO: Ver por que se çretorna la entidad completa
            wRes.BusinessData.UserId = pServiceRequest.BusinessData.User.UserId.Value;
            

            return wRes;
        }
    }
}
