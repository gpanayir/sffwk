//using System;
//using System.Configuration;
//using System.Xml;
//using Fwk.Configuration.Common;
//using Fwk.Configuration;
//using Fwk.HelperFunctions;
//namespace FrontArchitecture
//{
//    /// <summary>
//    /// Summary description for CheckConfigurationManager.
//    /// </summary>
//    public class CheckConfigurationManager
//    {
//        private String _strFilePath  = @"C:\moviedo\Test\TestMercurioArchitecture\FrontArchitecture\bin\Debug\ConfigurationManagerRemotingServer.xml";
//        public const String CONFIG_FILE_NAME_KEY = "BaseConfigfile";
//        public CheckConfigurationManager()
//        {
           
//            _strFilePath = AppDomain.CurrentDomain.BaseDirectory + 
//                System.IO.Path.DirectorySeparatorChar + ConfigurationSettings.AppSettings["BaseConfigFile"];
				
//            _strFilePath = _strFilePath.Replace("/", "\\");

//        }

//        public void GetFileContent()
//        {
//            bool wEncrypted ;
			

//            FileVersionStatus wFileVersionStatus = new  FileVersionStatus();
//            String wFileContent ;
//            XmlElement wElementFileInfo  ;
//            XmlDocument wXmlDocument = new XmlDocument();
//            XmlDocument wXmlTmpDocument = new XmlDocument();

//            if( !System.IO.File.Exists(_strFilePath)) 
//            {
//                wFileContent = WriteConfigManager();
//            }
//            else
//            {
//                //CArgo el archivo .xml que tengo en disco
//                wXmlDocument.Load(_strFilePath);

//                //Obtengo el FileInfo desde el archivo en disco .-
//                wElementFileInfo = (XmlElement) wXmlDocument.SelectSingleNode("/Groups/Group/FileInfo");

//                //Desencripto  los datos de FileInfo
//                DecryptFileInfo(wElementFileInfo);

//                //Obtengo el estado del arrchivo que se encuentra en el server .-
//                wFileVersionStatus = ConfigurationManager.GetFileVersionStatus(ConfigurationSettings.AppSettings[CONFIG_FILE_NAME_KEY], wElementFileInfo.SelectSingleNode("CurrentVersion").InnerText);

//                wEncrypted = Convert.ToBoolean(wXmlDocument.SelectSingleNode("/Groups/Group/Encrypted").InnerText);
//                wFileContent = wXmlDocument.DocumentElement.InnerXml;// wXmlDocument.SelectSingleNode("/ConfigManager/FileContent").InnerXml;

//                wFileContent = WriteConfigManager();

//                if(  wFileVersionStatus == FileVersionStatus.RequiredUpdate || 
//                    wFileVersionStatus == FileVersionStatus.OptionalUpdate )
//                {
//                    wFileContent = WriteConfigManager();
//                }
//                else
//                {
				
//                    if (wEncrypted)
//                    {
//                        wFileContent = Utils.Decrypt(wFileContent);
//                    }
					
//                    wXmlTmpDocument.LoadXml(wFileContent);
//                    wFileContent = wXmlTmpDocument.DocumentElement.InnerXml;
			
//                }
//            }
//        }


//        /// <summary>
//        /// Busca el archivo .xml al server de archivos de configuracion .-
//        /// </summary>
//        /// <returns></returns>
//        private string WriteConfigManager()
//        {
//            System.Text.StringBuilder wXml = new System.Text.StringBuilder();
//            XmlDocument wDoc = new XmlDocument();
//            XmlDocument wFileDoc = new XmlDocument();

			

//            try
//            {
//                ConfigurationFile wConfigurationFile  = 
//                ConfigurationManager.GetConfigurationFile(ConfigurationSettings.AppSettings[CONFIG_FILE_NAME_KEY]);
				
				
//                #region [Append FileContent]
//                wDoc.LoadXml(wConfigurationFile.ConfigResult.FileContent);
//                #endregion

//                #region [Append File info]

//                wXml.Append("<Encrypted>" + wConfigurationFile.ConfigResult.Encrypted + "</Encrypted>");
//                wXml.Append("<FileInfo>");

//                wXml.Append("  <CurrentVersion><![CDATA[" + Utils.Encrypt(wConfigurationFile.ConfigResult.CurrentVersion) + "]]></CurrentVersion>");
//                wXml.Append("  <TimeStamp><![CDATA[" + Utils.Encrypt(wConfigurationFile.TimeStamp.ToString("s")) + "]]></TimeStamp>");
//                wXml.Append("  <TTL><![CDATA[" + Utils.Encrypt(wConfigurationFile.ConfigResult.TTL.ToString()) + "]]></TTL>");

//                wXml.Append("</FileInfo>");

//                XmlNode wFileContentNode = wDoc.SelectSingleNode(@"Groups");
				
//                //Agrego FileInfo al wFileContentNode (Agrego un nuevo nodo Group con info del archivo).-
//                NodeCreateAndAdd( wFileContentNode ,"Group",wXml.ToString());

//                //Busco el nodo padre que contiene los datos info del archivo
//                XmlNode wFileInfoNodeParent = wDoc.SelectSingleNode(@"Groups/Group/FileInfo").ParentNode;
//                XmlAttribute att = wDoc.CreateAttribute("name");
//                att.Value = "ConfigManager";
//                wFileInfoNodeParent.Attributes.Append(att);
//                #endregion

//                //Guardo El archivo en disco				
//                wDoc.Save(_strFilePath);

				
//                wFileDoc.LoadXml(wConfigurationFile.DecryptedFileContent);
//                return wFileDoc.DocumentElement.InnerXml;
//            }
//            catch(Exception ex)
//            {
//                throw ex;
//            }
			

//        }

//        private void DecryptFileInfo(XmlElement pFileInfo )
//        {
//            foreach( XmlNode wNode in pFileInfo.ChildNodes)
//            {
//                wNode.InnerText = Utils.Decrypt(wNode.InnerText);
//            }
//        }

		
//        public void GetFileContentXXXXXXXXXXXXXXx()
//        {
//            bool wEncrypted ;
			

//            FileVersionStatus wFileVersionStatus = new  FileVersionStatus();
//            String wFileContent ;
//            XmlElement wElementFileInfo  ;
//            XmlDocument wXmlDocument = new XmlDocument();
//            XmlDocument wXmlTmpDocument = new XmlDocument();

//            if( !System.IO.File.Exists(_strFilePath)) 
//            {
//                wFileContent = WriteConfigManager();
//            }
//            else
//            {
//                //CArgo el archivo .xml que tengo en disco
//                wXmlDocument.Load(_strFilePath);

//                //Obtengo el FileInfo desde el archivo en disco .-
//                wElementFileInfo = (XmlElement) wXmlDocument.SelectSingleNode("/ConfigManager/FileInfo");
//                //Desencripto  los datos de FileInfo
//                DecryptFileInfo(wElementFileInfo);

//                //Obtengo el estado del arrchivo que se encuentra en el server .-
//                wFileVersionStatus = ConfigurationManager.GetFileVersionStatus(ConfigurationSettings.AppSettings[CONFIG_FILE_NAME_KEY], wElementFileInfo.SelectSingleNode("CurrentVersion").InnerText);

//                wEncrypted = Convert.ToBoolean(wXmlDocument.SelectSingleNode("/ConfigManager/Encrypted").InnerText);
//                wFileContent = wXmlDocument.SelectSingleNode("/ConfigManager/FileContent").InnerXml;

//                if(  wFileVersionStatus == FileVersionStatus.RequiredUpdate || 
//                    wFileVersionStatus == FileVersionStatus.OptionalUpdate )
//                {
//                    wFileContent = WriteConfigManager();
//                }
//                else
//                {
				
//                    if (wEncrypted)
//                    {
//                        wFileContent = Utils.Decrypt(wFileContent);
//                    }
					
//                    wXmlTmpDocument.LoadXml(wFileContent);
//                    wFileContent = wXmlTmpDocument.DocumentElement.InnerXml;
			
//                }
//            }
//        }


//        /// <summary>
//        /// Busca el archivo .xml al server de archivos de configuracion .-
//        /// </summary>
//        /// <returns></returns>
//        private string WriteConfigManagerXXXXXXXXXXXXXX()
//        {
//            XmlDocument wDoc = new XmlDocument();
//            XmlDocument wFileDoc = new XmlDocument();

//            XmlElement wExplorerBarConfigElement  = XmlFunctions.ElementCreateAndAdd(ref wDoc, "ConfigManager");

//            try
//            {
//                ConfigurationFile wConfigurationFile  = ConfigurationManager.GetConfigurationFile(ConfigurationSettings.AppSettings[CONFIG_FILE_NAME_KEY]);

//                System.Text.StringBuilder wXml = new System.Text.StringBuilder();

//                wXml.Append("<Encrypted>" + wConfigurationFile.ConfigResult.Encrypted + "</Encrypted>");
//                wXml.Append("<FileInfo>");

//                wXml.Append("  <CurrentVersion><![CDATA[" + Utils.Encrypt(wConfigurationFile.ConfigResult.CurrentVersion) + "]]></CurrentVersion>");
//                wXml.Append("  <TimeStamp><![CDATA[" + Utils.Encrypt(wConfigurationFile.TimeStamp.ToString("s")) + "]]></TimeStamp>");
//                wXml.Append("  <TTL><![CDATA[" + Utils.Encrypt(wConfigurationFile.ConfigResult.TTL.ToString()) + "]]></TTL>");

//                wXml.Append("</FileInfo>");
//                wXml.Append("<FileContent>" + wConfigurationFile.ConfigResult.FileContent +  "</FileContent>");

//                wExplorerBarConfigElement.InnerXml = wXml.ToString();

//                wDoc.Save(_strFilePath);

//                wFileDoc.LoadXml(wConfigurationFile.DecryptedFileContent);
//                return wFileDoc.DocumentElement.InnerXml;
//            }
//            catch(Exception ex)
//            {
//                throw ex;
//            }
			

//        }



//        private  XmlNode NodeCreateAndAdd(XmlNode pNode, string pNewNodeName, string pNewNodeValue)
//        {
//            XmlNode wNewNode = pNode.OwnerDocument.CreateNode(XmlNodeType.Element, pNewNodeName,"");
//            wNewNode.InnerXml = pNewNodeValue;
//            return pNode.AppendChild(wNewNode);
//        }
//    }
//}
