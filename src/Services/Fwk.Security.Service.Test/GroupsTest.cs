using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fwk.Security.ISVC.CreateRulesCategory;

using  Fwk.Security.ISVC.GetAllRulesCategory;
using Fwk.Security.ISVC;
using Fwk.Security.BE;

using Fwk.Security.ISVC.GetRulesCategoryByParam;
using Fwk.Security;

namespace Security
{
    /// <summary>
    /// Summary description for GroupsTest
    /// </summary>
    [TestClass]
    public class GroupsTest
    {
        public GroupsTest()
        {
            //
            // TODO: Add constructor logic here
            //
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
        public void GetAllRulesCategoryService()
        {            
            String strErrorResut = String.Empty;

            GetAllRulesCategoryReq wReq = new GetAllRulesCategoryReq();
            GetAllRulesCategoryRes wRes;

            // se llama al servicio
            wRes = wReq.ExecuteService<GetAllRulesCategoryReq, GetAllRulesCategoryRes>(wReq);


            if (wRes.Error != null)
            {
                if (typeof(Fwk.Exceptions.FunctionalException).Name.CompareTo(wRes.Error.Type) != 0)
                {
                    strErrorResut = Fwk.Exceptions.ExceptionHelper.ProcessException(wRes.Error).Message;
                }
                else
                {
                    wRes.Error = null;
                }
            }

            Assert.AreEqual<Fwk.Exceptions.ServiceError>(wRes.Error, null, strErrorResut);

        }

        [TestMethod]
        public void GetRulesCategoryByParamService()
        {
            
            String strErrorResut = String.Empty;

         GetRulesCategoryByParamReq wReq = new GetRulesCategoryByParamReq();
            GetRulesCategoryByParamRes wRes = new GetRulesCategoryByParamRes();


            wReq.BusinessData.CategoryId = 3;

            // se llama al servicio
            wRes = wReq.ExecuteService<Fwk.Security.ISVC.GetRulesCategoryByParam.GetRulesCategoryByParamReq, Fwk.Security.ISVC.GetRulesCategoryByParam.GetRulesCategoryByParamRes>(wReq);


            if (wRes.Error != null)
            {
                if (typeof(Fwk.Exceptions.FunctionalException).Name.CompareTo(wRes.Error.Type) != 0)
                {
                    strErrorResut =Fwk.Exceptions.ExceptionHelper.ProcessException(wRes.Error).Message;
                }
                else
                {
                    wRes.Error = null;
                }
            }

            Assert.AreEqual<Fwk.Exceptions.ServiceError>(wRes.Error, null, strErrorResut);

        }
                
        [TestMethod]
        public void CreateRulesCategoryService()
        {

            FwkCategory wRC = new FwkCategory();
            String strErrorResut = String.Empty;


                  



            Fwk.Security.ISVC.CreateRulesCategory.CreateRulesCategoryReq wReq = new Fwk.Security.ISVC.CreateRulesCategory.CreateRulesCategoryReq();
            Fwk.Security.ISVC.CreateRulesCategory.CreateRulesCategoryRes wRes = new Fwk.Security.ISVC.CreateRulesCategory.CreateRulesCategoryRes();




            // se llama al servicio
            wRes = wReq.ExecuteService<CreateRulesCategoryReq,CreateRulesCategoryRes>(wReq);


            if (wRes.Error != null)
            {
                if (typeof(Fwk.Exceptions.FunctionalException).Name.CompareTo(wRes.Error.Type) != 0)
                {
                    strErrorResut =Fwk.Exceptions.ExceptionHelper.ProcessException(wRes.Error).Message;
                }
                else
                {
                    wRes.Error = null;
                }
            }

            Assert.AreEqual<Fwk.Exceptions.ServiceError>(wRes.Error, null, strErrorResut);

        }
    }
}
