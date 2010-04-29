using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fwk.Security.ISVC.DeleteTeam;
using Fwk.Security.ISVC.GetTeamByParam;


namespace ServiceTest
{
    /// <summary>
    /// Summary description for Team
    /// </summary>
    [TestClass]
    public class Team
    {
        public Team()
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
        public void Delete()
        {
            string strErrorResult = String.Empty;
            DeleteTeamRequest wRequest = new DeleteTeamRequest();
            DeleteTeamResponse wResponse = new DeleteTeamResponse();

            wRequest.BusinessData.UsersIdList = new List<Int32>();
            wRequest.BusinessData.UsersIdList.Add(132);
            wRequest.BusinessData.UsersIdList.Add(127);

            wResponse = wRequest.ExecuteService<DeleteTeamRequest, DeleteTeamResponse>(wRequest);

            if (wResponse.Error != null)
            {
                strErrorResult =Fwk.Exceptions.ExceptionHelper.ProcessException(wResponse.Error).Message;
            }

            Assert.AreEqual<Fwk.Exceptions.ServiceError>(wResponse.Error, null, strErrorResult);
        }

        [TestMethod]
        public void GetTeamByParamTest()
        {
            Fwk.Security.BE.TeamBE wTeamBE = new Fwk.Security.BE.TeamBE();
            GetTeamByParamRequest wRequest = new GetTeamByParamRequest();
            GetTeamByParamResponse wResponse = new GetTeamByParamResponse();

            wRequest.BusinessData.ActiveFlag = null;
            wRequest.BusinessData.EndDate = null;
            wRequest.BusinessData.StartDate = null;
            wRequest.BusinessData.LastName = null;
            wRequest.BusinessData.FirstName = null;
            wRequest.BusinessData.UserName = null;
            wRequest.BusinessData.SearchtypeEnum = Fwk.Bases.Enums.SearchtypeEnum.Contain;

            wResponse = wRequest.ExecuteService<GetTeamByParamRequest, GetTeamByParamResponse>(wRequest);

            if (wResponse.Error != null)
            {
                
            }
           
        }


    }
}


