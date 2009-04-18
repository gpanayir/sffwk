using System;

using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Security.Cryptography;
using System.IO;
using Fwk.HelperFunctions;




namespace Fwk.Configuration.Common
{

	[FlagsAttribute]
	public enum FileVersionStatus
	{
		Ok = 1,
		OptionalUpdate = 2,
		RequiredUpdate = 4
	}

	/// <summary>
	/// Es una clase de ayuda que abstrae al sistema de configuracion de complejidades tecnicas reutilizables.
	/// </summary>
    /// <Author>Marcelo Oviedo</Author>
    public class Utils
	{


        

     

        #region d

        /// <summary>
        /// Obtiene un String con el contenido del archivo xml de configuracion. 
        /// </summary>
        /// <param name="pFileName">Nombre del archivo</param>
        /// <param name="pPath">Ruta donde se encuentra el archivo</param>
        /// <returns>String con el contenido del archivo xml de configuracion  </returns>
        /// <Author>Marcelo Oviedo</Author>
        public static String GetConfig(string pFileName,String pPath)
        {
            return GetConfig( pFileName, pPath,null);
        }

        /// <summary>
        /// Obtiene un String con el contenido del archivo xml de configuracion. 
        /// Si este metodo es accedido desde el servicio web extrae la informacion de estado del archivo:
        /// Encrypt
        /// TTL
        /// ForceUpdate
        /// CurrentVersion
        /// BaseConfigFile
        /// Cacheable
        /// </summary>
        /// <param name="pFileName">Nombre del archivo</param>
        /// <param name="pPath">Ruta donde se encuentra el archivo</param>
        /// <param name="pCatalogEntry">XmlElement que contiene informacion del catalogo de arhivos utilizado por el 
        /// servicio web Configuration Service</param>
        /// <returns>String con el contenido del archivo xml de configuracion  </returns>
        /// <Author>Marcelo Oviedo</Author>
	    public static String GetConfig(string pFileName,String pPath,XmlElement pCatalogEntry)
        {

            //XmlElement wCatalogEntry = this.GetCatalogEntry(pFileName);

            //if (!Convert.ToBoolean(GetChildNodeText(wCatalogEntry, "Available")))
            //{
            //    throw new Exception("El archivo de configuración solicitado no está disponible.");
            //}

            System.IO.StreamReader wReader = new System.IO.StreamReader(pPath + pFileName);
            string wFileContent = wReader.ReadToEnd();
            wReader.Close();


            if (pCatalogEntry != null && Convert.ToBoolean(GetChildNodeText(pCatalogEntry, "Encrypt")))
            {
                wFileContent = Fwk.HelperFunctions.CryptographyFunctions.Encrypt(wFileContent);
            }

            ConfigurationResponse.Result wResult = new ConfigurationResponse.Result();
            wResult.FileName = pFileName;
            wResult.FileContent = wFileContent;
            if(pCatalogEntry !=null)
            {
                wResult.TTL = Convert.ToInt32(GetChildNodeText(pCatalogEntry, "TTL"));
                wResult.Encrypted = Convert.ToBoolean(GetChildNodeText(pCatalogEntry, "Encrypt"));
                wResult.ForceUpdate = Convert.ToBoolean(GetChildNodeText(pCatalogEntry, "ForceUpdate"));
                wResult.CurrentVersion = GetChildNodeText(pCatalogEntry, "CurrentVersion");
                wResult.BaseConfigFile = Convert.ToBoolean(GetChildNodeText(pCatalogEntry, "BaseConfigFile"));
                wResult.Cacheable = Convert.ToBoolean(GetChildNodeText(pCatalogEntry, "Cacheable"));
            }
            else
            {
                wResult.BaseConfigFile = true;
                wResult.Cacheable = true;
            }
            string wXml = SerializationFunctions.SerializeToXml(wResult);

            wReader = null;
            wResult = null;
            pCatalogEntry = null;

            return wXml;
        }

        //private static XmlElement GetCatalogEntry(string pFileName)
        //{
        //    XmlDocument wDoc = new XmlDocument();
        //    wDoc.Load(Server.MapPath("~/ConfigurationFiles/Catalog.xml"));

        //    StringBuilder sbXPath = new StringBuilder("CatalogEntry[@name='");
        //    sbXPath.Append(pFileName);
        //    sbXPath.Append("']");
        //    XmlElement wNode = (XmlElement)wDoc.DocumentElement.SelectSingleNode(sbXPath.ToString());

        //    wDoc = null;
        //    sbXPath = null;

        //    return wNode;
        //}

        public static string GetChildNodeText(XmlElement pNode, string pChildName)
        {
            string wResult = pNode.SelectSingleNode(pChildName).InnerText;
            return wResult;
        }    
        #endregion
    }
}
