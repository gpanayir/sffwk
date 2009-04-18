//using System;
//using System.Collections.Generic;
//using System.Text;

//using Fwk.Bases.Test;
//using helper = Fwk.HelperFunctions;
//using NUnit.Framework;


//namespace Fwk.Bases.Test
//{
  
//    [TestFixture]
//    public class EntityTest
//    {
//        private ClienteBE wClienteBE1 = null;
//        private ClienteBE wClienteBE2 = null;
//        private ClienteCollectionBE wClienteCollectionBE = null;

//        [SetUp]
//        protected void SetUp()
//        {
//            FillEntity();
//        }

    

//        [Test]
//        public void TestEntityGetXML()
//        {
//            string strXML = String.Empty;
//            System.Xml.XmlDocument wXmlDocument = new System.Xml.XmlDocument();
//            strXML = wClienteBE1.GetXml();

//            wXmlDocument.LoadXml(strXML);

//            Assert.AreEqual(12, 12,"de lujiani");

//        }

//        [Test]
//        public void TestEntityGetDataset()
//        {
//            string strXML = String.Empty;
//            System.Xml.XmlDocument wXmlDocument = new System.Xml.XmlDocument();
//            strXML = wClienteBE1.GetDataSet().GetXml();

//            wXmlDocument.LoadXml(strXML);

//            Assert.AreEqual(12, 12);

            
            

//        }
//        [Test]
//        public void TestEntitiesRootName()
//        {
            
//            System.Xml.XmlDocument wXmlDocument = new System.Xml.XmlDocument();
//            wXmlDocument.LoadXml(wClienteCollectionBE.GetXml());
            
//            Assert.AreEqual(wXmlDocument.ChildNodes[0].Name, "ClienteCollectionBE");

//        }

//        [Test]
//        public void TestEntitiesSerializeDeserialize()
//        {
//            string strXML = wClienteCollectionBE.GetXml();

//            ClienteCollectionBE ClienteCollectionBE_New = (ClienteCollectionBE)
//                helper.SerializationFunctions.DeserializeFromXml(typeof(ClienteCollectionBE), strXML);
//           Assert.IsAssignableFrom(typeof(ClienteCollectionBE),helper.SerializationFunctions.DeserializeFromXml(typeof(ClienteCollectionBE), strXML),
//                "La deserializacion no produce un objeto igual al esperado");
//            Assert.AreEqual(wClienteCollectionBE[0].FechaNacimiento, ClienteCollectionBE_New[0].FechaNacimiento);
//            Assert.AreEqual(wClienteCollectionBE[0].Edad, ClienteCollectionBE_New[0].Edad);
//            Assert.AreEqual(wClienteCollectionBE[0].Apellido, ClienteCollectionBE_New[0].Apellido);
//            Assert.AreEqual(wClienteCollectionBE[0].Nombre, ClienteCollectionBE_New[0].Nombre);

//        }
//        [Test]
//        public void TestEntitiesLoadAndDeserialize()
//        {
//            string strXML = FillEntityWhithXml();

//            ClienteCollectionBE ClienteCollectionBE_New = (ClienteCollectionBE)
//                helper.SerializationFunctions.DeserializeFromXml(typeof(ClienteCollectionBE), strXML);
            
            
//            Assert.IsAssignableFrom(typeof(ClienteCollectionBE), helper.SerializationFunctions.DeserializeFromXml(typeof(ClienteCollectionBE), strXML),
//                 "La deserializacion no produce un objeto igual al esperado");
         

//        }
//        [Test]
//        [ExpectedException(typeof(InvalidOperationException))]
//        public void ExpectAnException()
//        {
//            throw new InvalidCastException();
            

//        }

//        private string  FillEntityWhithXml()
//        {
//            System.Text.StringBuilder sb = new System.Text.StringBuilder(5000);
//            sb.Append(@"<ClienteCollectionBE>");
//            sb.Append(Environment.NewLine);
//            sb.Append(@"  <ClienteBE>");
//            sb.Append(Environment.NewLine);
//            sb.Append(@"    <FechaNacimiento>1974-10-18</FechaNacimiento>");
//            sb.Append(Environment.NewLine);
//            sb.Append(@"    <Nombre>Marcelo</Nombre>");
//            sb.Append(Environment.NewLine);
//            sb.Append(@"    <ApellidoPaterno>Oviedo</ApellidoPaterno>");
//            sb.Append(Environment.NewLine);
//            sb.Append(@"    <Edad>32</Edad>");
//            sb.Append(Environment.NewLine);
//            sb.Append(@"  </ClienteBE>");
//            sb.Append(Environment.NewLine);
//            sb.Append(@"  <ClienteBE>");
//            sb.Append(Environment.NewLine);
//            sb.Append(@"    <FechaNacimiento>1976-10-18T00:00:00</FechaNacimiento>");
//            sb.Append(Environment.NewLine);
//            sb.Append(@"    <Nombre>Javier</Nombre>");
//            sb.Append(Environment.NewLine);
//            sb.Append(@"    <ApellidoPaterno>Oviedo</ApellidoPaterno>");
//            sb.Append(Environment.NewLine);
//            sb.Append(@"    <Edad>30</Edad>");
//            sb.Append(Environment.NewLine);
//            sb.Append(@"  </ClienteBE>");
//            sb.Append(Environment.NewLine);
//            sb.Append(@"</ClienteCollectionBE>");
//            sb.Append(Environment.NewLine);
//            return sb.ToString();
//        }


//        private void FillEntity()
//        {
//            wClienteCollectionBE = new ClienteCollectionBE();

//            wClienteBE1 = new ClienteBE();

//            wClienteBE1.Nombre = "Marcelo F Oviedo";
//            wClienteBE1.Apellido = "Pelsoft";
//            wClienteBE1.Edad = 32;
//            wClienteBE1.FechaNacimiento = new System.DateTime(1974, 12, 2);

//            wClienteBE2 = new ClienteBE();

//            wClienteBE2.Nombre = "Marcelo F Oviedo";
//            wClienteBE2.Apellido = "Pelsoft";
//            wClienteBE2.Edad = 32;
//            wClienteBE2.FechaNacimiento = new System.DateTime(1974, 12, 2);

//            wClienteCollectionBE.Add(wClienteBE1);
//            wClienteCollectionBE.Add(wClienteBE2);
//        }
//    }
//}
