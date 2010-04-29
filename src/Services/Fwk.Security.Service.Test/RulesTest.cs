using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fwk.Bases;

using Fwk.Security.ISVC.GetAllRules;
using Fwk.Bases;
using Fwk.Transaction;
using Fwk.Exceptions;





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

        [TestMethod]
        public void GetAllRulesService()
        {
            String strErrorResut = String.Empty;


            GetAllRulesReq wReq = new GetAllRulesReq();
            GetAllRulesRes wRes = new GetAllRulesRes();



             wRes.ContextInformation.CompanyId ="bigbang";





             if (wRes.Error != null)
            {
                if (typeof(Fwk.Exceptions.FunctionalException).Name.CompareTo(wRes.Error.Type) != 0)
                {
                    strErrorResut = ExceptionHelper.ProcessException(wRes.Error).Message;
                }
            }

             Assert.AreEqual<Fwk.Exceptions.ServiceError>(wRes.Error, null, strErrorResut);

        }

    }
}
