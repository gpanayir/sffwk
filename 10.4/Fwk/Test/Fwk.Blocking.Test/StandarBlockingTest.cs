﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fwk.Blocking;
using Fwk.Configuration;


namespace Test.Blocking
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class StandarBlockingTest
    {
        BlockingMarkBase _BlockingMarkBase = null;
        public StandarBlockingTest()
        {
            _BlockingMarkBase = new BlockingMarkBase();
            _BlockingMarkBase.Process = "Test";
            _BlockingMarkBase.User = Environment.UserName;
            try
            {
                if (ConfigurationManager.GetProperty("BlockingModel", "TestTTL") != null)
                    _BlockingMarkBase.TTL = Convert.ToInt32(ConfigurationManager.GetProperty("BlockingModel", "TTLInfo"));
            }
            catch
            {
                _BlockingMarkBase.TTL = 10;
            }
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
        public void StantarBlockingEngine()
        {
            FwkBlockingEngine wFwkBlockingEngine = new FwkBlockingEngine();

   

      

            wFwkBlockingEngine.Create(_BlockingMarkBase);

        }
    }
}
