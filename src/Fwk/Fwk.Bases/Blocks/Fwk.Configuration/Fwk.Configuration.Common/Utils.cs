using System;

using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Security.Cryptography;
using System.IO;
using Fwk.HelperFunctions;




namespace Fwk.Configuration.Common
{

	

	/// <summary>
	/// Es una clase de ayuda que abstrae al sistema de configuracion de complejidades tecnicas reutilizables.
	/// </summary>
    /// <Author>Marcelo Oviedo</Author>
    public class Helper
	{
        [FlagsAttribute]
        public enum FileVersionStatus
        {
            Ok = 1,
            OptionalUpdate = 2,
            RequiredUpdate = 4
        }

        [FlagsAttribute]
        public enum FileStatus
        {
            Ok = 1,
            Expired = 2,
            Inconsistent = 4
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
        public static ConfigurationFile GetConfig(string pFullFileName, ConfigFileRegistry pConfigFileRegistry)
        {

            ConfigurationFile wConfigurationFile;
            string wFileContent = Fwk.HelperFunctions.FileFunctions.OpenTextFile(pFullFileName);

            if (pConfigFileRegistry != null && pConfigFileRegistry.Encrypt)
            {
                wFileContent = Fwk.HelperFunctions.CryptographyFunctions.Encrypt(wFileContent);
                wConfigurationFile = new ConfigurationFile();
            }
            else//Si no esta encriptado dezerializa el contenido
            {
                wConfigurationFile = ConfigurationFile.GetFromXml<ConfigurationFile>(wFileContent);
               
            }

            wConfigurationFile.FileName = pFullFileName;
            //wConfigurationFile.FileContent.Text = wFileContent;
            if (pConfigFileRegistry != null)
            {
                wConfigurationFile.TTL = pConfigFileRegistry.TTL;
                wConfigurationFile.Encrypted = pConfigFileRegistry.Encrypt;
                wConfigurationFile.ForceUpdate = pConfigFileRegistry.ForceUpdate;
                wConfigurationFile.CurrentVersion = pConfigFileRegistry.CurrentVersion;
                wConfigurationFile.BaseConfigFile = pConfigFileRegistry.BaseConfigFile;
               
            }
            else
            {
                wConfigurationFile.BaseConfigFile = true;
             
            }

            return wConfigurationFile;
        }

   
    }
}
