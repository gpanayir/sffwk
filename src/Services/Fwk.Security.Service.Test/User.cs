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
using Fwk.Security.ISVC.GetAuthorizationRules;
using Fwk.Security.ISVC.CreateUsers;
using Fwk.Bases;
using Fwk.Security.ISVC.GetAllUsers;
using Fwk.Security.BE;
using Fwk.Security.ISVC.GetUserInfoByName;



using Fwk.Security.ISVC.UpdateUser;
using Fwk.Security.ISVC.SearchDomainsUrls;

using Fwk.HelperFunctions;

using Fwk.Security.SVC;
using Fwk.Security.Common;

namespace ServiceTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UserTest
    {
        TransactionScopeHandler _Tx;
        string _StrExceptionMessage = String.Empty;
        String xmlPath = @"\\Corrsf71bi01\BigBang\test";

        private TestContext testContextInstance;
        ClientServiceBase _ClientServiceBase = null;

        public UserTest()
        {
            _ClientServiceBase = new ClientServiceBase();


        }


        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

 

        [TestMethod]
        public void GetAllUserInfoByName()
        {
            string strErrorResult = string.Empty;

            try
            {

                GetUserInfoByName service =new GetUserInfoByName();

             GetUserInfoByNameRequest request =new GetUserInfoByNameRequest();

                GetUserInfoByNameResponse response =new GetUserInfoByNameResponse();

                request.BusinessData.UserName = "sbiglia";

                response = service.Execute(request);

            }
            catch (Exception ex)
            {
                strErrorResult = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }

            Assert.AreEqual<String>(strErrorResult, string.Empty, strErrorResult);
        }

        [TestMethod]
        public void GetAllUsersService()
        {
            string strErrorResult = string.Empty;
            GetAllUsersService service = new GetAllUsersService();

            GetAllUsersReq req = new GetAllUsersReq();

            
            try
            {
          

                GetAllUsersRes res = service.Execute(req);

               
            }
            catch (Exception ex)
            {
                strErrorResult = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }

            Assert.AreEqual<String>(strErrorResult, string.Empty, strErrorResult);
        }

        [TestMethod]
        public void GetUserInfoByNameService()
        {
            string strErrorResult = string.Empty;
            Fwk.Security.SVC.GetUserInfoByName service = new Fwk.Security.SVC.GetUserInfoByName();

            GetUserInfoByNameRequest req = new GetUserInfoByNameRequest();

            req.BusinessData.UserName = "moviedo";
            try
            {


                GetUserInfoByNameResponse res = service.Execute(req);


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
        public void AuthenticateUserReq_WindowsAuthenticationDefaultUser_NonExistentUser()
        {
            AuthenticateUserReq_WindowsAuthenticationDefaultUser("usuarioquenoexiste");
        }

        [TestMethod()]
        public void AuthenticateUserReq_WindowsAuthenticationDefaultUser_ok()
        {
            AuthenticateUserReq_WindowsAuthenticationDefaultUser("jiguastini");
        }

        [TestMethod()]
        public void AuthenticateUserReq_WindowsAuthenticationDefaultUser_IsApprovedFalse()
        {
            AuthenticateUserReq_WindowsAuthenticationDefaultUser("sinjefe");
        }

        [TestMethod()]
        public void AuthenticateUserReq_WindowsAuthenticationDefaultUser_ActiveFlagFalse()
        {
            AuthenticateUserReq_WindowsAuthenticationDefaultUser("sirefresco");
        }

        public void AuthenticateUserReq_WindowsAuthenticationDefaultUser(string pUserName)
        {
            String wErrorResult;

            AuthenticateUserReq req = new AuthenticateUserReq();
            req.BusinessData.AuthenticationMode = AuthenticationModeEnum.WindowsIntegrated;
            req.BusinessData.Name = pUserName;
            req.BusinessData.IsEnvironmentUser = true;
            AuthenticateUserRes res = _ClientServiceBase.ExecuteService<AuthenticateUserReq, AuthenticateUserRes>(req);

            if (res.Error != null)
                wErrorResult = Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error).Message;
            else
                wErrorResult = String.Empty;

            Assert.AreEqual<Fwk.Exceptions.ServiceError>(res.Error, null, wErrorResult);

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

        public void AuthenticateUserReq_WindowsAuthenticationDomainUser(string pUserName, string pPassword, string pDomain)
        {
            String wErrorResult;

            AuthenticateUserReq req = new AuthenticateUserReq();
            req.BusinessData.AuthenticationMode = AuthenticationModeEnum.WindowsIntegrated;
            req.BusinessData.Name = pUserName;
            req.BusinessData.Password = pPassword;
            req.BusinessData.Domain = pDomain;
            req.BusinessData.IsEnvironmentUser = false;
            AuthenticateUserRes res = _ClientServiceBase.ExecuteService<AuthenticateUserReq, AuthenticateUserRes>(req);

            if (res.Error != null)
                wErrorResult = Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error).Message;
            else
                wErrorResult = String.Empty;

            Assert.AreEqual<Fwk.Exceptions.ServiceError>(res.Error, null, wErrorResult);

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
            req.BusinessData.Name = pUserName;
            req.BusinessData.Password = pPassword;
            AuthenticateUserRes res = _ClientServiceBase.ExecuteService<AuthenticateUserReq, AuthenticateUserRes>(req);

            if (res.Error != null)
                wErrorResult = Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error).Message;
            else
                wErrorResult = String.Empty;

            Assert.AreEqual<Fwk.Exceptions.ServiceError>(res.Error, null, wErrorResult);

        }

        #endregion

        #endregion

        
        [TestMethod()]
        public void GetAuthorizationRulesService()
        {
            String strErrorResut = String.Empty;

            GetAuthorizationRulesReq req = new GetAuthorizationRulesReq();

            GetAuthorizationRulesRes res = _ClientServiceBase.ExecuteService<GetAuthorizationRulesReq, GetAuthorizationRulesRes>(req);

            if (res.Error != null)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error).Message;
            }

            Assert.AreEqual<Fwk.Exceptions.ServiceError>(res.Error, null, strErrorResut);
        }

        [TestMethod()]
        public void InsertUser()
        {
            _Tx = new TransactionScopeHandler(TransactionalBehaviour.Suppres, IsolationLevel.ReadCommitted, new TimeSpan(0, 0, 15));
            String strErrorResut = String.Empty;
            CreateUsersRequest wRequest = new CreateUsersRequest();
            CreateUsersResponse wResponse = new CreateUsersResponse();

             _Tx.InitScope();
           
            string wszRandom = GenerarCadenaAleatoria(6);// Para generar un nombre de manera aleatoria
            User wUserBe = new User();
            wUserBe.UserName = wszRandom;
            wUserBe.FirstName = "Juan";
            wUserBe.LastName = "Guastini";
            wUserBe.Password = "asd";
            wUserBe.Email = "ads@asd.com";
            //wUserBe.PasswordQuestion = "asd";
            //wUserBe.Answer = "asd";
            wUserBe.IsApproved = true;


            wRequest.BusinessData.User = wUserBe;
            wResponse = wRequest.ExecuteService<CreateUsersRequest, CreateUsersResponse>(wRequest);
            _Tx.Abort();

            if (wResponse.Error != null)
            {
                strErrorResut =Fwk.Exceptions.ExceptionHelper.ProcessException(wResponse.Error).Message;
            }

            Assert.AreEqual<Fwk.Exceptions.ServiceError>(wResponse.Error, null, strErrorResut);

        }


        [TestMethod()]
        public void UpdateUser_NO_Service()
        {
          


          
            _Tx = new TransactionScopeHandler(TransactionalBehaviour.RequiresNew, IsolationLevel.ReadCommitted, new TimeSpan(0, 0, 15));

            UpdateUserReq req = new UpdateUserReq();
            UpdateUserService svc = new UpdateUserService();
            //BusinessData.ChangePassword = new ChangePassword { Old = String.Empty, New = "11111" };

            req.BusinessData.ChangePassword = new ChangePassword();
            req.BusinessData.ChangePassword.New = "11111";
            req.BusinessData.ChangePassword.Old = "66666";
            req.BusinessData.UsersBE = new User("psoliz");
            

            req.BusinessData.PasswordOnly = true;

            try
            {
                _Tx.InitScope();

                UpdateUserRes res = svc.Execute(req);
                _Tx.Abort();
            }
            catch (Exception ex)
            {
                _StrExceptionMessage = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }




            Assert.AreEqual<String>(_StrExceptionMessage, String.Empty, _StrExceptionMessage);
        }

        [TestMethod]
        public void UpdateUserService()
        {
            
            UpdateUserReq req = new UpdateUserReq();
            UpdateUserService svc = new UpdateUserService();

            req.BusinessData.PasswordOnly = false;

            req.BusinessData.ChangePassword = new ChangePassword();
            req.BusinessData.ChangePassword.New = "hola";
            req.BusinessData.ChangePassword.Old = string.Empty;

            req.BusinessData.UsersBE = new User();
            //BusinessData.UsersBE.Name = String.Format("lenny{0}", GenerarCadenaAleatoria(6));
            req.BusinessData.UsersBE.UserId = 234;
            req.BusinessData.UsersBE.UserName = "charly";
            req.BusinessData.UsersBE.FirstName = "sarasa";
            req.BusinessData.UsersBE.LastName = "sarasa";


            req.BusinessData.UsersBE.Email = "sarasa@b.com";
            req.BusinessData.UsersBE.IsApproved = true;
            
           
           

            req.BusinessData.RolList = new Fwk.Security.Common.RolList();

            try
            {
                
                _ClientServiceBase.ExecuteService<UpdateUserReq, UpdateUserRes>(req);
                
                
            }
            catch (Exception ex)
            {
                _StrExceptionMessage = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }

            Assert.AreEqual<String>(_StrExceptionMessage, String.Empty, _StrExceptionMessage);

        }

        [TestMethod]
        public void SearchDomainsUrlsServiceTest()
        {
            String wErrorResult;

            SearchDomainsUrlsRequest wRequest = new SearchDomainsUrlsRequest();
            wRequest.BusinessData.ConnectionString = "BigBangConnectionString";
            SearchDomainsUrlsResponse wResponse = _ClientServiceBase.ExecuteService<SearchDomainsUrlsRequest, SearchDomainsUrlsResponse>(wRequest);

            if (wResponse.Error != null)
                wErrorResult =Fwk.Exceptions.ExceptionHelper.ProcessException(wRequest.Error).Message;
            else
                wErrorResult = String.Empty;

            Assert.AreEqual<Fwk.Exceptions.ServiceError>(wResponse.Error, null, wErrorResult);
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
