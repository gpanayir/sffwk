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

        //Solo para rellenar la base de datos
        [TestMethod]
        public void ImportToDB()
        {
            String strErrorResut = String.Empty;
            try
            {
                Fwk.ServiceManagement.XmlServiceConfigurationManager xml = new Fwk.ServiceManagement.XmlServiceConfigurationManager(@"..\..\..\Test\Fwk.UnitTest\bin\Debug\ServiceMetadataConfig.xml");
                Fwk.ServiceManagement.DatabaseServiceConfigurationManager data = new Fwk.ServiceManagement.DatabaseServiceConfigurationManager("test");
                ServiceConfigurationCollection services = data.GetAllServices();
                if (services.Count == 0)
                    foreach (ServiceConfiguration s in xml.GetAllServices())
                    {
                        data.AddServiceConfiguration(s);
                    }
            }
            catch (Exception e)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e);
            }

            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);
        }
        [TestMethod]
        public void XmlServiceConfigurationManager()
        {
            Fwk.ServiceManagement.XmlServiceConfigurationManager xml = new Fwk.ServiceManagement.XmlServiceConfigurationManager(@"..\..\..\Test\Fwk.UnitTest\bin\Debug\ServiceMetadataConfig.xml");
            IServiceConfigurationManager(xml);
        }

        [TestMethod]
        public void DataServiceConfigurationManager()
        {

            Fwk.ServiceManagement.DatabaseServiceConfigurationManager data = new Fwk.ServiceManagement.DatabaseServiceConfigurationManager("test");
            IServiceConfigurationManager(data);

        }

        public void IServiceConfigurationManager(IServiceConfigurationManager pIServiceConfigurationManager)
        {
            String strErrorResut = String.Empty;
            ServiceConfiguration wServiceConfigurationOriginal;
            ServiceConfiguration wServiceConfiguration;
            try
            {
                ServiceConfigurationCollection services = pIServiceConfigurationManager.GetAllServices();


                if (services.Count == 0)
                    Assert.Inconclusive("No existen servicios para realizar pruevas ");

                #region update
                wServiceConfigurationOriginal = pIServiceConfigurationManager.GetServiceConfiguration(services[0].Name);
                wServiceConfiguration = wServiceConfigurationOriginal.Clone();

                wServiceConfiguration.Audit = true;
                wServiceConfiguration.Name = wServiceConfigurationOriginal.Name + "_test";
                wServiceConfiguration.Description = wServiceConfigurationOriginal.Description + "_test";
                wServiceConfiguration.Request = wServiceConfigurationOriginal.Request + "_test";
                wServiceConfiguration.Response = wServiceConfigurationOriginal.Response + "_test";
                pIServiceConfigurationManager.SetServiceConfiguration(wServiceConfigurationOriginal.Name, wServiceConfiguration);
                #endregion

                #region CHEK update
                wServiceConfiguration = null;
                wServiceConfiguration = pIServiceConfigurationManager.GetServiceConfiguration(wServiceConfigurationOriginal.Name + "_test");

                if (!wServiceConfiguration.Name.Equals(string.Concat(wServiceConfigurationOriginal.Name, "_test"))
                   || !wServiceConfiguration.Response.Equals(string.Concat(wServiceConfigurationOriginal.Response, "_test"))
                   || !wServiceConfiguration.Request.Equals(string.Concat(wServiceConfigurationOriginal.Request, "_test"))
                    || !wServiceConfiguration.Description.Equals(string.Concat(wServiceConfigurationOriginal.Description, "_test")))
                {
                    Assert.Fail("La actualizacion en el metodo SetServiceConfiguration no se realizo con exito.-");
                }
                #endregion

                #region Add new service
                wServiceConfiguration = new ServiceConfiguration();

                wServiceConfiguration.Audit = true;
                wServiceConfiguration.Description = "desc_test";
                wServiceConfiguration.Name = "Name_test";
                wServiceConfiguration.Handler = "Handler_test";
                wServiceConfiguration.Request = "Request_test";
                wServiceConfiguration.Response = "Response_test";

                pIServiceConfigurationManager.AddServiceConfiguration(wServiceConfiguration);
                #endregion

                #region CHEK  Add new service
                wServiceConfiguration = null;
              
                wServiceConfiguration = pIServiceConfigurationManager.GetServiceConfiguration("Name_test");

                if (wServiceConfiguration == null)
                {
                    Assert.Fail("La creacion del servicio por medio  del metodo AddServiceConfiguration no se realizo con exito.-");
                }


                #endregion



                pIServiceConfigurationManager.DeleteServiceConfiguration("Name_test");
            }
            catch (Exception e)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e);
            }

            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);



        }

       



    }
}
