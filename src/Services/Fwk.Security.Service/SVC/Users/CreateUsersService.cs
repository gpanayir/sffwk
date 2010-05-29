
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a Prominente Code Generator.
//     Runtime Version:1.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//
//</auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;

using Fwk.Security.ISVC.CreateUsers;
using Fwk.Security.BC;


namespace Fwk.Security.SVC
{

    public class CreateUsersService : BusinessService<CreateUsersRequest, CreateUsersResponse>
    {
        public override CreateUsersResponse Execute(CreateUsersRequest pServiceRequest)
        {

            CreateUsersResponse wRes = new CreateUsersResponse();
            UserBC wUserBC = new UserBC(pServiceRequest.ContextInformation.CompanyId, pServiceRequest.SecurityProviderName);

            wUserBC.Create(pServiceRequest.BusinessData.User,pServiceRequest.BusinessData.RolList);

            wRes.BusinessData.UserBE = pServiceRequest.BusinessData.User;
            

            return wRes;
        }
    }
}
