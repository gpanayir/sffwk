using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fwk.Bases;
using Fwk.Security.ISVC.SearchAllRules;
using Fwk.Transaction;
using Fwk.Exceptions;
using Fwk.Security.SVC;






namespace Security
{
    /// <summary>
    /// Summary description for RulesTest
    /// </summary>
    [TestClass]
    public class RulesTest
    {
        TransactionScopeHandler _Tx;
        string _StrExceptionMessage = String.Empty;
        ClientServiceBase _ClientServiceBase = null;
        public RulesTest()
        {
            _ClientServiceBase = new ClientServiceBase();
        }

        private TestContext testContextInstance;

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


        #region service test
 

        [TestMethod]
        public void SearchAllRulesService_No_Service()
        {
            String strErrorResut = String.Empty;

            SearchAllRulesReq req = new SearchAllRulesReq();
            SearchAllRulesRes res = new SearchAllRulesRes();
            SearchAllRulesService svc = new SearchAllRulesService();
            res.ContextInformation.CompanyId = "bigbang";
            req.SecurityProviderName = "tesa";


            try
            {

                res = svc.Execute(req);


            }
            catch (Exception ex)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }


            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);


        }
        #endregion

    }
}
