using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Fwk.Configuration.Common;
using Fwk.Bases.Properties;
using Fwk.HelperFunctions;
      
namespace Fwk.Configuration
{
    /// <summary>
    /// Clase que permite obtener informacion de un archivo de configuracion ubicado localmente donde la aplicacion
    /// esta corriendo sin nececidad de configurar y tener disponible los servicios de configuracion :
    /// < Configuration Provider (Win Service que hostea la clase remota ConfigurationHolder<see cref="ConfigurationHolder"/>)
    /// Configuration Service (Web Service)
    /// <remarks>
    /// Es necesario para que funcione la configuracion local tener en la aplicacion cliente un archivo de configuracion valido en disco
    /// y en la ruta donde esta corriendo la aplicacion. 
    /// </remarks>
    /// </summary>
    /// <Author>Marcelo Oviedo</Author>
    internal  class LocalConfigurationManager
    {
        private static LocalHolder m_ConfigHolder = null;

        /// <summary>
        /// Obtiene una propiedad determinada de un archivo de configuracion .-
        /// </summary>
        /// <param name="pGroupName">Nombre del grupo donde se encuentra la propiedad</param>
        /// <param name="pPropertyName">Nombre de la propiedad a obtener</param>
        /// <returns>String con la propiedad</returns>
        /// <Author>Marcelo Oviedo</Author>
        internal static string GetProperty(string pGroupName, string pPropertyName)
        {

            return GetProperty(String.Empty, pGroupName, pPropertyName);

        }

        /// <summary>
        /// Obtiene una propiedad determinada de un archivo de configuracion .-
        /// </summary>
        /// <param name="pConfigProvider">Proveedor de configuuracion</param>
        /// <param name="pGroupName">Nombre del grupo donde se encuentra la propiedad</param>
        /// <param name="pPropertyName">Nombre de la propiedad a obtener</param>
        /// <returns>String con la propiedad</returns>
        /// <Author>Marcelo Oviedo</Author>
        internal static string GetProperty(string pConfigProvider, string pGroupName, string pPropertyName)
        {
            string wBaseConfigFile = String.Empty;
            m_ConfigHolder = CreateConfigurationHolder();

            if (string.IsNullOrEmpty(pConfigProvider))
                wBaseConfigFile = ConfigurationManager.GetBaseConfigFileName();
            else
                wBaseConfigFile = ConfigurationManager.GetBaseConfigFileName(pConfigProvider);


            string wResult = m_ConfigHolder.GetProperty(wBaseConfigFile, pGroupName, pPropertyName);


            if (wResult.Length == 0)
            {
                /// no encontró nada, lanza excepcion
                throw new Exception("Ocurrió una excepción al buscar una propiedad [" + pPropertyName + "]" +
                    "La misma NO está configurada en ningún repositorio.");
            }

            return wResult;

        }
       
      
        /// <summary>
        /// Obtiene un ConfigurationFile <see cref="ConfigurationFile" atravez de su nombre/>
        /// </summary>
        /// <param name="pFileName">Nombre del archivo xml con la configuracion</param>
        /// <returns><see cref="ConfigurationFile"/></returns>
        /// <Author>Marcelo Oviedo</Author>
        internal static ConfigurationFile GetConfigurationFile(string pFileName)
        {
            m_ConfigHolder = CreateConfigurationHolder();

            ConfigurationFile wResult = m_ConfigHolder.GetConfig(pFileName);
            return wResult;
        }

        //public static FileStatus GetFileVersionStatus(string pFileName, string pClientVersion)
        //{
        //    m_ConfigHolder = CreateConfigurationHolder();

        //    FileStatus wResult = m_ConfigHolder.GetFileVersionStatus(pFileName, pClientVersion);
        //    return wResult;
        //}

        /// <summary>
        /// Obtiene un grupo determinado en el archivo de configuracion
        /// </summary>
        /// <param name="pGroupName"></param>
        /// <returns>Hashtable con los grupos contenidos en el archivo de configuracion</returns>
        /// <Author>Marcelo Oviedo</Author>
        internal static Hashtable GetGroup(string pGroupName)
        {
            return GetGroup(pGroupName);
           
        }
             /// <summary>
        /// Obtiene un grupo determinado en el archivo de configuracion
        /// </summary>
        /// <param name="pConfigProvider">Proveedor de configuuracion</param>
        /// <param name="pGroupName"></param>
        /// <returns>Hashtable con los grupos contenidos en el archivo de configuracion</returns>
        /// <Author>Marcelo Oviedo</Author>
        internal static Hashtable GetGroup(string pConfigProvider, string pGroupName)
        {
            m_ConfigHolder = CreateConfigurationHolder();
            string wBaseConfigFile = string.Empty;

            if (string.IsNullOrEmpty(pConfigProvider))
                wBaseConfigFile = ConfigurationManager.GetBaseConfigFileName();
            else
                wBaseConfigFile = ConfigurationManager.GetBaseConfigFileName(pConfigProvider);

            Hashtable wResult = m_ConfigHolder.GetGroup(wBaseConfigFile, pGroupName);

            if (wResult == null)
            {
                throw new Exception("Ocurrió un error cuando se trataba de obtener " +
                    "el grupo '" + pGroupName + "'. El grupo no se encuentra " +
                    "configurado en ninguno de los repositorios. " +
                    "Grupo: '" + pGroupName + "'.");
            }

            return wResult;
        }

        
        #region [Private members]


        /// <summary>
        /// Operacion que retorna una instancia de la clase <see cref="LocalHolder"/> 
        /// utilizando un patron Singlenton
        /// </summary>
        /// <returns><see cref="LocalHolder"/> </returns>
        /// <Author>Marcelo Oviedo</Author>
        private static LocalHolder CreateConfigurationHolder()
        {
            if (m_ConfigHolder == null)
            {
                m_ConfigHolder = new LocalHolder();
            }
            return m_ConfigHolder;
        }
        #endregion
    }


    /// <summary>
    /// Esta clase tiene la funcionalidad del ConfigurationHolder <see cref="ConfigurationHolder"/> clase remoeable que esta hosteada en el servicio de windows Configuration Provider
    /// por otro lado y almismo tiempo realiza las tareas que soportan los web metodos del servicio web Configuration Service.
    /// Estas tareas se agrupan en la clase LocalHolder para que todo lo que concierna a configuracion sea llevado acabo localmente y 
    /// no alla nececidad de servicios adicionales.-
    /// </summary>
    /// <Author>Marcelo Oviedo</Author>
    internal class LocalHolder
    {
        private ConfigurationRepository _ConfigData;

        /// <summary>
        /// Devuelve el contenido completo de un archivo de configuración
        /// dado el nombre de archivo.
        /// </summary>
        /// <param name="pFileName">Nombre de archivo</param>
        /// <returns>ConfigurationFile</returns>
        /// <Author>Marcelo Oviedo</Author>
        internal ConfigurationFile GetConfig(string pFileName)
        {

            string wFileContent = string.Empty;
            bool wIsNewFile = false;

            if (_ConfigData == null)
            {
                _ConfigData = new ConfigurationRepository();
            }

            ConfigurationFile wConfigurationFile = _ConfigData.GetConfigurationFile(pFileName);

            if (wConfigurationFile == null)
            {
                wConfigurationFile = new ConfigurationFile();
                wIsNewFile = true;
            }

            //Si se opto por configuracion local no es necesario chequear el stado
            if (wConfigurationFile.CheckFileStatus() != FileStatus.Ok)
            {
                this.SetConfigurationFile(wConfigurationFile, pFileName);
                if (wIsNewFile && wConfigurationFile.ConfigResult.Cacheable)
                {
                    _ConfigData.AddConfigurationFile(wConfigurationFile);
                }
            }


            return wConfigurationFile;

        }

        /// <summary>
        /// Devuelve una propidedad de un grupo de un BaseConfigFile
        /// </summary>
        /// <param name="pBaseConfigFileName">Nombre de archivo</param>
        /// <param name="pGroupName">Nombre de grupo</param>
        /// <param name="pPropertyName">Nombre de propiedad</param>
        /// <returns>String con la propiedad</returns>
        internal string GetProperty(string pBaseConfigFileName, string pGroupName, string pPropertyName)
        {
            ConfigurationFile wConfigurationFile = this.GetConfig(pBaseConfigFileName);

            //if (!wConfigurationFile.ConfigResult.BaseConfigFile)
            //{
            //    throw new Exception("El archivo solicitado no es un archivo de configuración válido.");
            //}


            XmlDocument wDoc = new XmlDocument();


            wDoc.LoadXml(wConfigurationFile.DecryptedFileContent);


            string wResult = String.Empty;

            /// verifica que haya un nodo padre para todos
            /// los grupos
            if (wDoc.DocumentElement != null)
            {
                /// prepara la consulta XPath
                StringBuilder sbXPath = new StringBuilder("Group[@name='");
                sbXPath.Append(pGroupName);
                sbXPath.Append("']/Key[@name='");
                sbXPath.Append(pPropertyName);
                sbXPath.Append("']");

                /// realiza la consulta
                XmlElement wNode = (XmlElement)wDoc.DocumentElement.SelectSingleNode(sbXPath.ToString());

                if (wNode != null)
                    wResult = wNode.InnerText;

                wNode = null;
                sbXPath = null;

            }

            wConfigurationFile = null;
            wDoc = null;

            return wResult;

        }

        /// <summary>
        /// Devuelve un elemento representativo de un grupo.
        /// </summary>
        /// <param name="pDocument">Documento xml</param>
        /// <param name="pGroupName">Nombre del grupo</param>
        /// <returns>XmlElement con el contenido del grupo</returns>
        /// <Author>Marcelo Oviedo</Author>
        private  XmlElement GetGroupElement(XmlDocument pDocument, string pGroupName)
        {
            XmlElement retNode;

            if (pDocument.DocumentElement == null)
                return null;

            StringBuilder sbXPath = new StringBuilder("Group[@name='");
            sbXPath.Append(pGroupName);
            sbXPath.Append("']");

            retNode = (XmlElement)pDocument.DocumentElement.SelectSingleNode(sbXPath.ToString());

            return retNode;
        }

        /// <summary>
        /// Devuelve un grupo de un BaseConfigFile
        /// </summary>
        /// <param name="pBaseConfigFileName">Nombre del archivo</param>
        /// <param name="pGroupName">Nombre del grupo</param>
        /// <returns>Hashtable</returns>
        /// <Author>Marcelo Oviedo</Author>
        internal Hashtable GetGroup(string pBaseConfigFileName, string pGroupName)
        {
            Hashtable ht = null;
            
            ConfigurationFile wConfigurationFile = this.GetConfig(pBaseConfigFileName);

            if (!wConfigurationFile.ConfigResult.BaseConfigFile)
            {
                throw new Exception("El archivo solicitado no es un archivo de configuración válido.");
            }

            XmlDocument wDoc = new XmlDocument();
            wDoc.LoadXml(wConfigurationFile.DecryptedFileContent);

            XmlElement wGroupElement = this.GetGroupElement(wDoc, pGroupName);

            if (wGroupElement != null)
            {
                string valueToRet;
                // heurística de la capacidad de las tablas de hash
                ht = new Hashtable(Convert.ToInt32(wGroupElement.ChildNodes.Count * 1.75));
                foreach (XmlElement elem in wGroupElement.ChildNodes)
                {
                    // toma el valor devuelto
                    valueToRet = elem.InnerText;

                    // agrego el valor
                    ht.Add(elem.GetAttribute("name"), valueToRet);
                }
            }

            return ht;

        }

        /// <summary>
        /// Configura un ConfigurationFile.
        /// </summary>
        /// <param name="pConfigurationFile">Objeto a configurar.</param>
        /// <param name="pFileName">Nombre de archivo.</param>
        /// <Author>Marcelo Oviedo</Author>
        internal void SetConfigurationFile(ConfigurationFile pConfigurationFile, string pFileName)
        {
            string wResultGetConfig;
            if (System.IO.File.Exists(pFileName))
            {
                wResultGetConfig =
                    Common.Utils.GetConfig(pFileName,String.Empty);
            }
            else
            {
                wResultGetConfig =
                  Common.Utils.GetConfig(pFileName,
                                         Environment.CurrentDirectory + System.IO.Path.DirectorySeparatorChar);
            }

            Fwk.Configuration.Common.ConfigurationResponse.Result wResult =
                (Fwk.Configuration.Common.ConfigurationResponse.Result)
                SerializationFunctions.Deserialize(typeof(Fwk.Configuration.Common.ConfigurationResponse.Result),
                    wResultGetConfig);
            pConfigurationFile.ConfigResult = wResult;
            wResult = null;
        }

    }
}
