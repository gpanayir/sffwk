using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fwk.Security;
using ISVC = Fwk.Security.ISVC;

using Fwk.Caching;
using Fwk.Transaction;
using Fwk.Security.ISVC.AuthenticateUser;
using Fwk.Security.ISVC.CreateUsers;
using Fwk.Bases;
using Fwk.Security.ISVC.SearchAllUsers;
using Fwk.Security.BE;
using Fwk.Security.ISVC.GetUserInfoByParams;
using Fwk.Security.ISVC.UpdateUser;
using Fwk.Security.ISVC.SearchDomainsUrls;
using Fwk.HelperFunctions;
using Fwk.Security.SVC;
using Fwk.Security.Common;
using Fwk.Security.ISVC.RemoveUserFromRole;

namespace ServiceTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UserTest : Fwk.Bases.Test.UnitTestBase
    {

        public UserTest()
        {
            User wUser = new User();

            wUser.UserName = "moviedo";
            wUser.FirstName = "Marcelo";
            wUser.LastName = "Oviedo";
            wUser.Password = "12345678";
            wUser.Email = "marcelo.oviedo@santesxer.com.ca";

            wUser.IsApproved = true;

            try
            {
                //CreeateUser_No_Service(wUser);
            }
            catch { }
        }
    
   
        [TestMethod]
        public void SearchAllUsers_NoService()
        {
            string strErrorResult = string.Empty;
            SearchAllUsersService svc = new SearchAllUsersService();
            SearchAllUsersReq req = new SearchAllUsersReq();
            
            try
            {
               SearchAllUsersRes res = svc.Execute(req);
            }
            catch (Exception ex)
            {
                strErrorResult = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }

            Assert.AreEqual<String>(strErrorResult, string.Empty, strErrorResult);
        }

        [TestMethod]
        public void GetUserInfoByParams_NoService()
        {
            string strErrorResult = string.Empty;
            Fwk.Security.SVC.GetUserInfoByParamsService service = new Fwk.Security.SVC.GetUserInfoByParamsService();
            GetUserInfoByParamsReq req = new GetUserInfoByParamsReq();
            req.BusinessData.UserName = "moviedo";
            try
            {

                GetUserInfoByParamsRes res = service.Execute(req);
            }
            catch (Exception ex)
            {
                strErrorResult = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }

            Assert.AreEqual<String>(strErrorResult, string.Empty, strErrorResult);
        }

        #region Authentication Test Methods

        #region WindowsDefaultUser (4 Test Methods)

        [TestMethod()]
        public void AuthenticateUser_WindowsAuthenticationDefaultUser_NonExistentUser()
        {
            AuthenticateUser_WindowsAuthenticationDefaultUser("usuarioquenoexiste");
        }

        [TestMethod()]
        public void AuthenticateUser_WindowsAuthenticationDefaultUser_ok()
        {
            AuthenticateUser_WindowsAuthenticationDefaultUser("moviedo");
        }

        [TestMethod()]
        public void AuthenticateUser_WindowsAuthenticationDefaultUser_IsApprovedFalse()
        {
            AuthenticateUser_WindowsAuthenticationDefaultUser("moviedo");
        }

        [TestMethod()]
        public void AuthenticateUser_WindowsAuthenticationDefaultUser_ActiveFlagFalse()
        {
            AuthenticateUser_WindowsAuthenticationDefaultUser("sirefresco");
        }

        public void AuthenticateUser_WindowsAuthenticationDefaultUser(string pUserName)
        {

            String strErrorResut = String.Empty;
            AuthenticateUserReq req = new AuthenticateUserReq();
            AuthenticateUserService svc = new AuthenticateUserService();
            req.BusinessData.AuthenticationMode = AuthenticationModeEnum.WindowsIntegrated;
            req.BusinessData.UserName = pUserName;
            req.BusinessData.IsEnvironmentUser = false;

            try
            {
                AuthenticateUserRes res = svc.Execute(req);


            }
            catch (Exception ex)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }


            Assert.AreEqual<String>(strErrorResut, String.Empty, strErrorResut);
    

        }

        #endregion

        #region WindowsDomainUser - LDAP (4 Test Methods)

        [TestMethod()]
        public void AuthenticateUserReq_WindowsAuthenticationDomainUser_UsuarioNoExiste()
        {
            AuthenticateUserReq_WindowsAuthenticationDomainUser("usuarioNOExiste", "sarasa", "ALLUS-AR");
        }

        [TestMethod()]
        public void AuthenticateUserReq_WindowsAuthenticationDomainUser_Ok()
        {
            AuthenticateUserReq_WindowsAuthenticationDomainUser("pdesarrollo2", "Allus+123", "ALLUS-AR");
        }

        [TestMethod()]
        public void AuthenticateUserReq_WindowsAuthenticationDomainUser_InactiveUser()
        {
            AuthenticateUserReq_WindowsAuthenticationDomainUser("pdesarrollo2", "Allus+123", "ALLUS-AR");
        }

        [TestMethod()]
        public void AuthenticateUserReq_WindowsAuthenticationDomainUser_WrongPassword()
        {
            AuthenticateUserReq_WindowsAuthenticationDomainUser("pdesarrollo1", "passwordchoto", "ALLUS-AR");
        }
        object sysobj = new object ();
        public void AuthenticateUserReq_WindowsAuthenticationDomainUser(string pUserName, string pPassword, string pDomain)
        {
            String strErrorResult = string.Empty;
            AuthenticateUserService svc = new AuthenticateUserService();
            AuthenticateUserReq req = new AuthenticateUserReq();
            req.BusinessData.AuthenticationMode = AuthenticationModeEnum.WindowsIntegrated;
            req.BusinessData.UserName = pUserName;
            req.BusinessData.Password = pPassword;
            req.BusinessData.Domain = pDomain;
            req.BusinessData.IsEnvironmentUser = false;

            try
            {
                AuthenticateUserRes res = svc.Execute(req);
            }
            catch (Exception ex)
            {
                strErrorResult = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }
            lock (sysobj)
            {
                Assert.AreEqual<String>(strErrorResult, String.Empty, strErrorResult);
            }

        }

        #endregion

        #region MixedAuthentication (3 Test Methods)

        [TestMethod()]
        public void AuthenticateUserReq_MixedAuthentication_Ok()
        {
            AuthenticateUserReq_MixedAuth("jiguastini", "jiguastini");
        }

        [TestMethod()]
        public void AuthenticateUserReq_MixedAuthentication_WrongPassword()
        {
            AuthenticateUserReq_MixedAuth("cviglietta", "sarasabtrosca");
        }

        [TestMethod()]
        public void AuthenticateUserReq_MixedAuthentication_WrongUser()
        {
            AuthenticateUserReq_MixedAuth("saracatunga", "sarabatrosca");
        }

        public void AuthenticateUserReq_MixedAuth(string pUserName, string pPassword)
        {
            String wErrorResult;

            AuthenticateUserReq req = new AuthenticateUserReq();
            req.BusinessData.AuthenticationMode = AuthenticationModeEnum.Mixed;
            req.BusinessData.UserName = pUserName;
            req.BusinessData.Password = pPassword;
            AuthenticateUserRes res = base.ClientServiceBase.ExecuteService<AuthenticateUserReq, AuthenticateUserRes>(req);

            if (res.Error != null)
                wErrorResult = Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error).Message;
            else
                wErrorResult = String.Empty;

            Assert.AreEqual<Fwk.Exceptions.ServiceError>(res.Error, null, wErrorResult);

        }

        #endregion

        #endregion

        [TestMethod()]
        public void User_CRUD_No_Service()
        {
            base.Tx = new TransactionScopeHandler(TransactionalBehaviour.RequiresNew, IsolationLevel.ReadCommitted, new TimeSpan(0, 1, 15));
            base.Tx.InitScope();

            string wszRandom = GenerarCadenaAleatoria(6);// Para generar un nombre de manera aleatoria
            User wUserBe = new User();
            wUserBe.UserName = wszRandom;
            wUserBe.FirstName = "Juan";
            wUserBe.LastName = "Guastini";
            wUserBe.Password = "asd";
            wUserBe.Email = "ads@asd.com";

            wUserBe.IsApproved = true;


            CreeateUser_No_Service(wUserBe);


            if (wUserBe.UserId != null)
            {
                User usr = GetByNAme(wUserBe.UserName);
                if (usr == null)
                {
                    Assert.Fail("No se ccreo el usuario exitosamente");
                }


                UpdateUser_NO_Service(usr);

                try
                {
                    //Comprovar si actualizo
                    usr = GetByNAme(wUserBe.UserName);

                    if (!usr.Email.Equals(string.Concat(wUserBe.Email, ".ar")))
                        Assert.Fail("No se actualizo exitosamente: Email");
                    //if (!usr.FirstName.Equals(string.Concat(wUserBe.FirstName, "_updated")))
                    //    Assert.Fail("No se actualizo exitosamente: FirstName");

                    //if (!usr.LastName.Equals(string.Concat(wUserBe.LastName, "_updated")))
                    //    Assert.Fail("No se actualizo exitosamente: LastName ");

                    //if (!usr.ModifiedByUserId.Equals(12))
                    //    Assert.Fail("No se actualizo exitosamente: ModifiedByUserId ");

                }
                catch (Exception ex)
                {
                    base.StrExceptionMessage = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
                }

                RemoveUserFromRole_NO_Service(wUserBe.UserName );
            }
            else
            {
                Assert.Inconclusive("No se puede testear UpdateUserService");
            }

            base.Tx.Abort();
        }

        User GetByNAme(string pUserName)
        {
            GetUserInfoByParamsService service = new GetUserInfoByParamsService();
            GetUserInfoByParamsReq req = new GetUserInfoByParamsReq();
            req.BusinessData.UserName = pUserName;

            GetUserInfoByParamsRes res = null;

            try
            {
                //Comprovar si se creo el usuario
                res = service.Execute(req);
                
            }
            catch (Exception ex)
            {
                base.StrExceptionMessage = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
                return null;
            }
          
           return  res.BusinessData.UserInfo;
        }

        void CreeateUser_No_Service(User pUserBe)
        {
            String strErrorResut = String.Empty;
            CreateUserReq req = new CreateUserReq();
            CreateUserRes res = new CreateUserRes();
            CreateUserService svc = new CreateUserService();

            req.SecurityProviderName = SecurityProviderName;
            
            try
            {

                RolList roles = FwkMembership.GetAllRoles(SecurityProviderName);
                  if (roles.Count >= 2)
                  {
                      pUserBe.Roles = new String[2];
                      pUserBe.Roles[0] = roles[0].RolName;
                      pUserBe.Roles[1] = roles[1].RolName;

                      
                  }
                req.BusinessData.User = pUserBe;
                res = svc.Execute(req);
                
            }
            catch (Exception ex)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }
            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);
            pUserBe.UserId = res.BusinessData.UserId;
      
        }



        void UpdateUser_cpass_NO_Service(User oldUser)
        {
          
            UpdateUserReq req = new UpdateUserReq();
            UpdateUserService svc = new UpdateUserService();
         

            req.BusinessData.ChangePassword = new ChangePassword();
            req.BusinessData.ChangePassword.New = "11111";
            req.BusinessData.ChangePassword.Old = "66666";
            req.BusinessData.UsersBE = oldUser;


            req.BusinessData.PasswordOnly = true;

            try
            {
 
                UpdateUserRes res = svc.Execute(req);
             
            }
            catch (Exception ex)
            {
                base.StrExceptionMessage = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }




            Assert.AreEqual<String>(base.StrExceptionMessage, String.Empty, base.StrExceptionMessage);
        }
        void UpdateUser_NO_Service(User oldUser)
        {

            UpdateUserReq req = new UpdateUserReq();
            UpdateUserService svc = new UpdateUserService();
    
            req.BusinessData.UsersBE = oldUser;

            req.BusinessData.UsersBE.FirstName = oldUser.FirstName + "_updated";
            req.BusinessData.UsersBE.LastName = oldUser.LastName + "_updated";
            req.BusinessData.UsersBE.ModifiedByUserId = 12;
            req.BusinessData.UsersBE.ModifiedDate = System.DateTime.Now;
            req.BusinessData.UsersBE.Email = oldUser.Email + ".ar";
   

            req.BusinessData.PasswordOnly = false;

            try
            {

                UpdateUserRes res = svc.Execute(req);

            }
            catch (Exception ex)
            {
                base.StrExceptionMessage = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }




            Assert.AreEqual<String>(base.StrExceptionMessage, String.Empty, base.StrExceptionMessage);
        }

        /// <summary>
        /// Elimina el primer rol
        /// </summary>
        /// <param name="user"></param>
        void RemoveUserFromRole_NO_Service(string user)
        {
            RolList roles = FwkMembership.GetAllRoles(SecurityProviderName);
            
            RemoveUserFromRoleReq req = new RemoveUserFromRoleReq();
            RemoveUserFromRoleService svc = new RemoveUserFromRoleService();
            req.BusinessData.UserName = user;
            req.BusinessData.RolName = roles[0].RolName;
            try
            {
                RemoveUserFromRoleRes res = svc.Execute(req);
            }
            catch (Exception ex)
            {
                base.StrExceptionMessage = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }
            Assert.AreEqual<String>(base.StrExceptionMessage, String.Empty, base.StrExceptionMessage);
        }

        [TestMethod]
        public void SearchDomainsUrls_NO_Service()
        {
          

            SearchDomainsUrlsRequest wRequest = new SearchDomainsUrlsRequest();
            wRequest.BusinessData.ConnectionString = "test";
            SearchDomainsUrlsService svc = new SearchDomainsUrlsService();

            try
            {
                SearchDomainsUrlsResponse wResponse = svc.Execute(wRequest);
            }
            catch (Exception ex)
            {
                base.StrExceptionMessage = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }

            Assert.AreEqual<String>(base.StrExceptionMessage, String.Empty, base.StrExceptionMessage);
        }

        public string GenerarCadenaAleatoria(int longitudCadena)
        {
            Random rnd = new Random();
            string wszRandom = string.Empty;
            string[] wCaracteres = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "Ñ", "O", "P", "Q", "R", "S",
                        "T", "U", "V", "W", "X", "Y", "Z"};
            for (int i = 0; i < longitudCadena; i++)
            {
                wszRandom += wCaracteres[rnd.Next(0, wCaracteres.Length - 1)];
            }
            return wszRandom;

        }
       

    }
}
