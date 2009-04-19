
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Fwk.Configuration.Common;
using Fwk.Configuration.Common.ConfigurationResponse;

namespace ConfigurationApp
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
    internal class ConfigManagerEngine
    {
        private static LocalHolder m_ConfigHolder = null;

        internal static Boolean ExistConfiguration(String pFileName)
        {
            if (m_ConfigHolder == null)
                return false;

            if (m_ConfigHolder.ConfigData.GetConfigurationFile(pFileName) == null)
                return false;

            return true;
        }





        /// <summary>
        /// Obtiene un ConfigurationFile <see cref="ConfigurationFile" atravez de su nombre/>
        /// </summary>
        /// <param name="pFileName">Nombre del archivo xml con la configuracion</param>
        /// <returns><see cref="ConfigurationFile"/></returns>
        /// <Author>Marcelo Oviedo</Author>
        internal static ConfigurationFile GetConfigurationFile(string pFullFileName)
        {
            String wPath = System.IO.Path.GetDirectoryName(pFullFileName) + System.IO.Path.DirectorySeparatorChar; ;
            String wFileName = System.IO.Path.GetFileName(pFullFileName);

            m_ConfigHolder = CreateConfigurationHolder();

            ConfigurationFile wResult = m_ConfigHolder.GetConfig(wFileName, wPath);
            return wResult;
        }

        /// <summary>
        /// Quita un ConfigurationFile del diccionario<see cref="ConfigurationFile" atravez de su nombre/>
        /// </summary>
        /// <param name="pFileName">Nombre del archivo xml con la configuracion</param>
        /// <returns><see cref="ConfigurationFile"/></returns>
        /// <Author>Marcelo Oviedo</Author>
        internal static void RemoveConfigurationFile(string wFipeName)
        {


            m_ConfigHolder.RemoveConfigManager(wFipeName);


        }

       

        /// <summary>
        /// Marca las Key que estan repetidas dentro de un grupo
        /// </summary>
        /// <param name="pGroupElement"></param>
        internal static void SetKeyRepetidos(XmlNode pGroupElement)
        {
            //XmlElement wGroupElement = m_ConfigHolder.GetGroupElement(wDoc, pGroupName);
            Int32 wCount = 0;
            String wName1;
            String wName2;
            if (pGroupElement != null)
            {
                for (int i = 0; i < pGroupElement.ChildNodes.Count; i++)
                {
                    if (pGroupElement.ChildNodes[i].Attributes != null)
                    {
                        wName1 = pGroupElement.ChildNodes[i].Attributes["name"].Value;

                        for (int j = i + 1; j < pGroupElement.ChildNodes.Count; j++)
                        {
                            if (pGroupElement.ChildNodes[j].Attributes != null)
                            {
                                wName2 = pGroupElement.ChildNodes[j].Attributes["name"].Value;

                                if (wName2 == wName1)
                                {
                                    pGroupElement.ChildNodes[j].Attributes["name"].Value = wName1 + "_Valor_Repetido_" +
                                                                                           wCount++;
                                }
                            }
                        }
                    }
                    wCount = 0;
                }
            }
        }

        internal static void DisposeHolder()
        {
            m_ConfigHolder = null;
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

        public ConfigurationRepository ConfigData
        {
            get { return _ConfigData; }
            set { _ConfigData = value; }
        }

        /// <summary>
        /// Devuelve el contenido completo de un archivo de configuración
        /// dado el nombre de archivo.
        /// </summary>
        /// <param name="pFileName">Nombre de archivo</param>
        /// <returns>ConfigurationFile</returns>
        /// <Author>Marcelo Oviedo</Author>
        internal ConfigurationFile GetConfig(string pFileName, string pPath)
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
                this.SetConfigurationFile(wConfigurationFile, pFileName, pPath);
                if (wIsNewFile && wConfigurationFile.ConfigResult.Cacheable)
                {
                    _ConfigData.AddConfigurationFile(wConfigurationFile);
                }
            }


            return wConfigurationFile;

        }

        

        /// <summary>
        /// Devuelve un elemento representativo de un grupo.
        /// </summary>
        /// <param name="pDocument">Documento xml</param>
        /// <param name="pGroupName">Nombre del grupo</param>
        /// <returns>XmlElement con el contenido del grupo</returns>
        /// <Author>Marcelo Oviedo</Author>
        internal XmlElement GetGroupElement(XmlDocument pDocument, string pGroupName)
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
        /// Configura un ConfigurationFile.
        /// </summary>
        /// <param name="pConfigurationFile">Objeto a configurar.</param>
        /// <param name="pFileName">Nombre de archivo.</param>
        /// <Author>Marcelo Oviedo</Author>
        internal void SetConfigurationFile(ConfigurationFile pConfigurationFile, string pFileName, string pPath)
        {
            string wResultGetConfig = Utils.GetConfig(pFileName, pPath);

            Result wResult = (Result)Fwk.HelperFunctions.SerializationFunctions.Deserialize(typeof(Result), wResultGetConfig);

            pConfigurationFile.ConfigResult = wResult;

            wResult = null;
        }

        internal void RemoveConfigManager(string pFileName)
        {
            ConfigurationFile wConfigurationFile = _ConfigData.GetConfigurationFile(pFileName);
            _ConfigData.RemoveConfigurationFile(wConfigurationFile);
        }
    }
}
