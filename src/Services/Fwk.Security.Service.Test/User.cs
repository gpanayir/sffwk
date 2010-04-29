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

using Fwk.Security.ISVC.UserAdditionalAttributesValues_Exist_ByUserAttributeId;
using Fwk.Security.ISVC.GetUserAdditionalAttributesValues;
using Fwk.Security.ISVC.SaveUserAdditionalAttributesValues;
using Fwk.Security.ISVC.UpdateUserAdditionalAttributesValues;
using Fwk.Security.ISVC.UpdateUser;
using Fwk.Security.ISVC.SearchDomainsUrls;

using Fwk.HelperFunctions;
using Fwk.Security.ISVC.GetAllActiveUsersInfo;
using Fwk.Security.SVC;

namespace ServiceTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class User
    {
        TransactionScopeHandler _Tx;
        string _StrExceptionMessage = String.Empty;
        String xmlPath = @"\\Corrsf71bi01\BigBang\test";

        private TestContext testContextInstance;
        ClientServiceBase _ClientServiceBase = null;
    
        public User()
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
        public void GetAllActiveUsersInfo()
        {
            string strErrorResult = string.Empty;

            try
            {
                
                GetAllActiveUsersInfoService service =
                   new GetAllActiveUsersInfoService();

                GetAllActiveUsersInfoRequest request =new GetAllActiveUsersInfoRequest();

                GetAllActiveUsersInfoResponse response = new GetAllActiveUsersInfoResponse();

                response = service.Execute(request);
            }
            catch (Exception ex)
            {
                strErrorResult = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }

            Assert.AreEqual<String>(strErrorResult, string.Empty, strErrorResult);
        }

        [TestMethod]
        public void GetAllUserInfoByName()
        {
            string strErrorResult = string.Empty;

            try
            {

                GetUserInfoByName service =new GetUserInfoByName();

             GetUserInfoByNameRequest request =new GetUserInfoByNameRequest();

                GetUserInfoByNameResponse response =new GetUserInfoByNameResponse();

                request.BusinessData.Name = "sbiglia";

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

            req.BusinessData.ApplicationName = "xx";
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

            req.BusinessData.Name = "moviedo";
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
            UsersBE wUserBe = new UsersBE();
            wUserBe.Name = wszRandom;
            wUserBe.FirstName = "Juan";
            wUserBe.LastName = "Guastini";
            wUserBe.Password = "asd";
            wUserBe.Mail = "ads@asd.com";
            //wUserBe.PasswordQuestion = "asd";
            //wUserBe.Answer = "asd";
            wUserBe.IsApproved = true;


            wRequest.BusinessData.UsersBE = wUserBe;
            wResponse = wRequest.ExecuteService<CreateUsersRequest, CreateUsersResponse>(wRequest);
            _Tx.Abort();

            if (wResponse.Error != null)
            {
                strErrorResut =Fwk.Exceptions.ExceptionHelper.ProcessException(wResponse.Error).Message;
            }

            Assert.AreEqual<Fwk.Exceptions.ServiceError>(wResponse.Error, null, strErrorResut);

        }

        [TestMethod()]
        public void GetUnassignedUsersByParam()
        {
            Fwk.Security.ISVC.GetUnassignedUsersByParam.GetUnassignedUsersByParamRequest req = new Fwk.Security.ISVC.GetUnassignedUsersByParam.GetUnassignedUsersByParamRequest();


            req.BusinessData.LastName = "mono";
            req.BusinessData.FirstName = "mono";
            req.BusinessData.Name = "mono";
            req.BusinessData.SearchtypeName = Fwk.Bases.Enums.SearchtypeEnum.Contain;

            Fwk.Security.ISVC.GetUnassignedUsersByParam.GetUnassignedUsersByParamResponse res = _ClientServiceBase.ExecuteService<Fwk.Security.ISVC.GetUnassignedUsersByParam.GetUnassignedUsersByParamRequest,
                Fwk.Security.ISVC.GetUnassignedUsersByParam.GetUnassignedUsersByParamResponse>(req);
        
        }

        [TestMethod()]
        public void GetUserAdditionalAttributes_ByParam()
        {
            Fwk.Security.ISVC.GetUserAdditionalAttributes_ByParam.GetUserAdditionalAttributes_ByParamRequest req = new Fwk.Security.ISVC.GetUserAdditionalAttributes_ByParam.GetUserAdditionalAttributes_ByParamRequest();


            req.BusinessData.ActiveFlag = true;


            Fwk.Security.ISVC.GetUserAdditionalAttributes_ByParam.GetUserAdditionalAttributes_ByParamResponse res = _ClientServiceBase.ExecuteService<Fwk.Security.ISVC.GetUserAdditionalAttributes_ByParam.GetUserAdditionalAttributes_ByParamRequest,
                Fwk.Security.ISVC.GetUserAdditionalAttributes_ByParam.GetUserAdditionalAttributes_ByParamResponse>(req);

            if (res.Error != null)
                res.GetXml();
        }

        [TestMethod()]
        public void GetUserAdditionalAttributesValues_Exist_ByUserAttributesId()
        {
            UserAdditionalAttributesValues_Exist_ByUserAttributeIdRequest req = new UserAdditionalAttributesValues_Exist_ByUserAttributeIdRequest();


            req.BusinessData.UserAttributeId = 1;


            UserAdditionalAttributesValues_Exist_ByUserAttributeIdResponse res = _ClientServiceBase.ExecuteService<UserAdditionalAttributesValues_Exist_ByUserAttributeIdRequest,
            UserAdditionalAttributesValues_Exist_ByUserAttributeIdResponse>(req);

            ///TODO: Ver si realiza unit test
            if (req.Error != null)
                res.GetXml();
        }

        [TestMethod()]
        public void GetUserAdditionalAttributesValues()
        {
            GetUserAdditionalAttributesValues_ByParamRequest req = new GetUserAdditionalAttributesValues_ByParamRequest();

            req.BusinessData.UserId = 132;
            
            
            GetUserAdditionalAttributesValues_ByParamResponse res = _ClientServiceBase.ExecuteService<GetUserAdditionalAttributesValues_ByParamRequest,
            GetUserAdditionalAttributesValues_ByParamResponse>(req);
            ///TODO: Ver si realiza unit test
            if (res.Error != null)
                res.GetXml();
        }
        
        [TestMethod()]
        public void SaveUserAdditionalAttributesValues()
        {
            SaveUserAdditionalAttributesValuesRequest req = new SaveUserAdditionalAttributesValuesRequest();

            req.BusinessData.AdditionalAttributesValues = new UserAdditionalAttributesValuesBEList();
            req.BusinessData.AdditionalAttributesValues.Add(new UserAdditionalAttributesValuesBE());
            req.BusinessData.AdditionalAttributesValues[0].UserId = 132;
            req.BusinessData.AdditionalAttributesValues[0].Value = "Casado";
            req.BusinessData.AdditionalAttributesValues[0].UserAttributeId = 71;


            SaveUserAdditionalAttributesValuesResponse res = _ClientServiceBase.ExecuteService<SaveUserAdditionalAttributesValuesRequest,
            SaveUserAdditionalAttributesValuesResponse>(req);
            ///TODO: Ver si realiza unit test
            if (res.Error != null)
                res.GetXml();
        }

        [TestMethod()]
        public void UpdateUserAdditionalAttributesValues()
        {
            UpdateUserAdditionalAttributesValuesRequest req = new UpdateUserAdditionalAttributesValuesRequest();

            req.BusinessData.AdditionalAttributesValues = new UserAdditionalAttributesValuesBEList();
            req.BusinessData.AdditionalAttributesValues.Add(new UserAdditionalAttributesValuesBE());
            req.BusinessData.AdditionalAttributesValues[0].UserId = 132;
            req.BusinessData.AdditionalAttributesValues[0].Value = "soltero";
            req.BusinessData.AdditionalAttributesValues[0].UserAttributeId = 71;


            UpdateUserAdditionalAttributesValuesResponse res = _ClientServiceBase.ExecuteService<UpdateUserAdditionalAttributesValuesRequest,
            UpdateUserAdditionalAttributesValuesResponse>(req);
            ///TODO: Ver si realiza unit test
            if (res.Error != null)
                res.GetXml();
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
            req.BusinessData.UsersBE = new UsersBE();
            req.BusinessData.UsersBE.Name = "psoliz";

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

            req.BusinessData.UsersBE = new UsersBE();
            //BusinessData.UsersBE.Name = String.Format("lenny{0}", GenerarCadenaAleatoria(6));
            req.BusinessData.UsersBE.UserId = 234;
            req.BusinessData.UsersBE.Name = "charly";
            req.BusinessData.UsersBE.FirstName = "sarasa";
            req.BusinessData.UsersBE.LastName = "sarasa";


            req.BusinessData.UsersBE.DNI = "123456";
            req.BusinessData.UsersBE.Mail = "sarasa@b.com";
            req.BusinessData.UsersBE.IsApproved = true;
            req.BusinessData.UsersBE.ActiveFlag = true;
            req.BusinessData.UsersBE.ModifiedByUserId = 224;
            req.BusinessData.UsersBE.ModifiedDate = System.DateTime.Now;

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
