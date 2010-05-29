using System;
using System.Data;
using System.Web.Security;
using System.Security.Principal;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security.ISVC.AuthenticateUser;
using Fwk.Security.Common;
using Fwk.Security;
using Fwk.Security.BC;


namespace Fwk.Security.SVC
{
     public class AuthenticateUserService : BusinessService<AuthenticateUserReq, AuthenticateUserRes>
    {
        public override AuthenticateUserRes Execute(AuthenticateUserReq pServiceRequest)
        {
            AuthenticateUserRes wRes = new AuthenticateUserRes();
            UserBC userBC = new UserBC(pServiceRequest.ContextInformation.CompanyId, pServiceRequest.SecurityProviderName);
            RolList wRolList = new RolList();
            User wUser = new User();
            if (pServiceRequest.BusinessData.AuthenticationMode == AuthenticationModeEnum.WindowsIntegrated)
            {
                // el modo de autenticación es integrada de windows (usuario por defecto o validación LDAP)
                if (pServiceRequest.BusinessData.IsEnvironmentUser)
                {

                    //TODO: ver AuthenticateUser sin pwd
                    // el usuario se toma por defecto del environment por tanto se recupera el user info sin necesidad de validar
                    ///wRes.BusinessData.UserCustomInfo = userBC.AuthenticateUser(pServiceRequest.BusinessData.UserName,out wRes.BusinessData.UserInfo);
                }
                else
                {
                    //Se debe validar el usuario en LDAP contra el dominio seleccionado
                      userBC.AuthenticateUser_AD(pServiceRequest.BusinessData.UserName,
                                                                          pServiceRequest.BusinessData.Password,
                                                                          pServiceRequest.BusinessData.Domain,
                                                                          out wRes.BusinessData.UserInfo );
                }
                
            }
            else
            {
                //utiliza autenticación mixta. Valida contra el usuario de bigbang
                wRes.BusinessData.UserCustomInfo = userBC.AuthenticateUser(pServiceRequest.BusinessData.UserName,
                                                                      pServiceRequest.BusinessData.Password,out wRes.BusinessData.UserInfo);
            }
             wRes.BusinessData.AuthenticationMode = pServiceRequest.BusinessData.AuthenticationMode;
             wRes.BusinessData.RolList = wRolList;


            return wRes;
        }
    }
}
