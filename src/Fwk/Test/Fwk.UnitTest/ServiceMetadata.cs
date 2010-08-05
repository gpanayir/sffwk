using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fwk.Bases;

namespace Fwk.UnitTest
{
    /// <summary>
    /// Summary description for ServiceMetadata
    /// </summary>
    [TestClass]
    public class ServiceMetadata
    {
        public ServiceMetadata()
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
        public void XmlServiceConfigurationManager()
        {
            String strErrorResut = String.Empty;
    

            try
            {
                Fwk.ServiceManagement.XmlServiceConfigurationManager xml = new Fwk.ServiceManagement.XmlServiceConfigurationManager(@"..\..\..\Test\Fwk.UnitTest\bin\Debug\ServiceMetadataConfig.xml");

                IServiceConfigurationManager(xml);
                


            }
            catch (Exception e)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e);
            }

         
        }
        [TestMethod]
        public void DataServiceConfigurationManager()
        {
            String strErrorResut = String.Empty;


            try
            {
                Fwk.ServiceManagement.DatabaseServiceConfigurationManager data = new Fwk.ServiceManagement.DatabaseServiceConfigurationManager("test");

                IServiceConfigurationManager(data);

            }
            catch (Exception e)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e);
            }


        }

        public void IServiceConfigurationManager(IServiceConfigurationManager pIServiceConfigurationManager)
        {
            String strErrorResut = String.Empty;
 

            try
            {
      

                ServiceConfigurationCollection services = pIServiceConfigurationManager.GetAllServices();


            }
            catch (Exception e)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e);
            }


        }

    }
}
