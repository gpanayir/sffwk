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
        public static Groups GetConfig(string pFullFileName ,ConfigFileRegistry pConfigFileRegistry)
        {

            Groups wGroup;
            string wFileContent = Fwk.HelperFunctions.FileFunctions.OpenTextFile(pFullFileName);

            if (pConfigFileRegistry != null && pConfigFileRegistry.Encrypt)
            {
                wFileContent = Fwk.HelperFunctions.CryptographyFunctions.Encrypt(wFileContent);
                wGroup = new Groups();
            }
            else//Si no esta encriptado dezerializa el contenido
            {
                wGroup = Groups.GetFromXml<Groups>(wFileContent);
               
            }

            wGroup.FileName = pFullFileName;
            wGroup.FileContent = wFileContent;
            if (pConfigFileRegistry != null)
            {
                wGroup.TTL = pConfigFileRegistry.TTL;
                wGroup.Encrypted = pConfigFileRegistry.Encrypt;
                wGroup.ForceUpdate = pConfigFileRegistry.ForceUpdate;
                wGroup.CurrentVersion = pConfigFileRegistry.CurrentVersion;
                wGroup.BaseConfigFile = pConfigFileRegistry.BaseConfigFile;
                wGroup.Cacheable = pConfigFileRegistry.Cacheable;
            }
            else
            {
                wGroup.BaseConfigFile = true;
                wGroup.Cacheable = true;
            }

            return wGroup;
        }

   
    }
}
