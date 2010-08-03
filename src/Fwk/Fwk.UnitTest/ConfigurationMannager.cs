using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fwk.UnitTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ConfigurationMannager
    {
        public ConfigurationMannager()
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

       
        /// <summary>
        /// Check from database configuration mannager:
        /// AddGroup
        /// AddProperty
        /// GetProperty
        /// RemoveProperty
        /// RemoveGroup
        /// </summary>
        [TestMethod]
        public void ConfigurationMannager_Database()
        {
            String strErrorResut = String.Empty;
            String providerName = "database";
            Fwk.Configuration.Common.Group g = new Fwk.Configuration.Common.Group();
            g.Name = "Test01";
            Fwk.Configuration.Common.Key k;

            k = new Fwk.Configuration.Common.Key();
            k.Name = "K01";
            k.Value.Text = "Value_Key_01";
            g.Keys.Add(k);

            k = new Fwk.Configuration.Common.Key();
            k.Name = "K02";
            k.Value.Text = "Value_Key_02";
            g.Keys.Add(k);

            try
            {
                Fwk.Configuration.ConfigurationManager_CRUD.AddGroup(providerName, g);
            }
            catch (Exception e)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e);
            }

            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);

            if (!string.IsNullOrEmpty(strErrorResut)) return;

            k = new Fwk.Configuration.Common.Key();

            k.Name = "K03";
            k.Value.Text = "Value_Key_03";
            try
            {
                Fwk.Configuration.ConfigurationManager_CRUD.AddProperty(providerName, k, g.Name);
            }
            catch (Exception e)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e);
            }
            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);

            if (!string.IsNullOrEmpty(strErrorResut)) return;
            string kvalue = Fwk.Configuration.ConfigurationManager.GetProperty(providerName,g.Name, "K03");

            if (!kvalue.Equals("Value_Key_03", StringComparison.OrdinalIgnoreCase))
                Assert.Inconclusive("No se pudo obtener correctamente la propiedad", kvalue);



            try
            {
                Fwk.Configuration.ConfigurationManager_CRUD.RemoveProperty(providerName,  g.Name,"K03");
            }
            catch (Exception e)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e);
            }

            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);
            if (!string.IsNullOrEmpty(strErrorResut)) return;



            try
            {
                Fwk.Configuration.ConfigurationManager_CRUD.RemoveGroup(providerName, g.Name);
            }
            catch (Exception e)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e);
            }
            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);

        }
        /// <summary>
        /// Check from file configuration mannager:
        /// AddGroup
        /// AddProperty
        /// GetProperty
        /// RemoveProperty
        /// RemoveGroup
        /// </summary>
        [TestMethod]
        public void ConfigurationMannager_File()
        {
            String strErrorResut = String.Empty;
            String providerName = "localFile";
            Fwk.Configuration.Common.Group g = new Fwk.Configuration.Common.Group();
            g.Name = "Test01";
            Fwk.Configuration.Common.Key k;

            k = new Fwk.Configuration.Common.Key();
            k.Name = "K01";
            k.Value.Text = "Value_Key_01";
            g.Keys.Add(k);

            k = new Fwk.Configuration.Common.Key();
            k.Name = "K02";
            k.Value.Text = "Value_Key_02";
            g.Keys.Add(k);

            try
            {
                Fwk.Configuration.ConfigurationManager_CRUD.AddGroup(providerName, g);
            }
            catch (Exception e)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e);
            }

            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);

            if (!string.IsNullOrEmpty(strErrorResut)) return;

            k = new Fwk.Configuration.Common.Key();
            k.Name = "K03";
            k.Value.Text = "Value_Key_03";
            try
            {
                Fwk.Configuration.ConfigurationManager_CRUD.AddProperty(providerName, k, g.Name);
            }
            catch (Exception e)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e);
            }

            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);

            if (!string.IsNullOrEmpty(strErrorResut)) return;
            string kvalue = Fwk.Configuration.ConfigurationManager.GetProperty(providerName, "K03");

            if (!kvalue.Equals("Value_Key_03", StringComparison.OrdinalIgnoreCase))
                Assert.Inconclusive("No se pudo obtener correctamente la propiedad", kvalue);




            try
            {
                Fwk.Configuration.ConfigurationManager_CRUD.RemoveProperty(providerName, "K03", g.Name);
            }
            catch (Exception e)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e);
            }

            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);
            if (!string.IsNullOrEmpty(strErrorResut)) return;



            try
            {
                Fwk.Configuration.ConfigurationManager_CRUD.RemoveGroup(providerName, g.Name);
            }
            catch (Exception e)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e);
            }
            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);
        }

       
    }
}
