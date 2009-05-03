using System;
using System.Collections;
using Fwk.Configuration.Common;
using Fwk.Bases.Properties;
using Fwk.ConfigSection;

namespace Fwk.Configuration
{
	/// <summary>
	/// Clase principal que se utiliza para obtener cualquier configuracion tanto local como remota contenida
	/// en los archivos de configuracion.
	/// <remarks>Los parametros necesarios para su correcto funcionamiento son los que se
    /// allan en el App.Config que utilize el ConfigurationManager tales como:
    /// BaseConfigFile
    /// RemotingConfigFile : indica el archivo de configuracion necesario para la configuracion  del servicio remoto.
    /// IsLocal: determina si el ambito de configuracion es atravez del servicio remoto (Configuration Provider) 
    /// o es local (sin servicio alguno)
    /// </remarks>
	/// </summary>
    /// <Author>Marcelo Oviedo</Author>
	public class ConfigurationManager
	{

        static ConfigProviderSection _ConfigProvider;
        static ConfigProviderElement _DefaultProvider;

        public static ConfigProviderElement DefaultProvider
        {
            get { return ConfigurationManager._DefaultProvider; }
            
        }
        static ConfigurationManager()
        {
            _ConfigProvider = System.Configuration.ConfigurationManager.GetSection("FwkConfigProvider") as ConfigProviderSection;
            _DefaultProvider = _ConfigProvider.DefaultProvider;
            
        }
        /// <summary>
        /// Obtener un valor desde el archivo de configuración.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="psz_Group"></param>
        /// <param name="psz_Key"></param>
        /// <returns></returns>
        //private Nullable<T> GetValueFromConfigurationKey<T>(string psz_Group, string psz_Key) where T : struct
        //{
        //    string wzs_Value = string.Empty;

        //    try
        //    {
        //        wzs_Value = ConfigurationManager.GetProperty(psz_Group, psz_Key);
        //    }
        //    catch (Exception ex)
        //    {
        //        //Se asume como que el valor no fue establecido.
        //        //throw new TechnicalException(string.Format(@"Error al obtener la clave ""{1}"" del grupo ""{0}"".", psz_Group, psz_Key), ex);
        //    }

        //    try
        //    {
        //        Nullable<T> wo_Value;

        //        if (!string.IsNullOrEmpty(wzs_Value))
        //            wo_Value = new Nullable<T>((T)Convert.ChangeType(wzs_Value, typeof(T)));
        //        else
        //            wo_Value = new Nullable<T>();

        //        return wo_Value;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new TechnicalException(string.Format(@"Error al obtener la clave ""{1}"" del grupo ""{0}"": No se puede convertir el valor ""{2}"" al tipo ""{3}"".", psz_Group, psz_Key, wzs_Value, typeof(T).ToString()), ex);
        //    }
        //}

        /// <summary>
        /// Obtiene una propiedad determinada de un archivo de configuracion Usa proveedor de confuiguraciones establecido por defecto.-
        /// </summary>
        /// <param name="pGroupName">Nombre del grupo donde se encuentra la propiedad</param>
        /// <param name="pPropertyName">Nombre de la propiedad a obtener</param>
        /// <returns>String con la propiedad</returns>
        /// <Author>Marcelo Oviedo</Author>
        public static string GetProperty(string pGroupName, string pPropertyName)
        {
            return GetProperty(string.Empty, pGroupName, pPropertyName);
        }
        /// <summary>
        /// Obtiene una propiedad determinada de un archivo de configuracion .-
        /// </summary>
        /// <param name="pGroupName">Nombre del grupo donde se encuentra la propiedad</param>
        /// <param name="pPropertyName">Nombre de la propiedad a obtener</param>
        /// <returns>String con la propiedad</returns>
        /// <Author>Marcelo Oviedo</Author>
        public static string GetProperty(string pConfigProvider, string pGroupName, string pPropertyName)
        {
            if (IsLocal())
            {
                return LocalConfigurationManager.GetProperty(pConfigProvider,pGroupName, pPropertyName);
            }
            else
            {
                return RemoteConfigurationManager.GetProperty(pGroupName, pPropertyName);
            }
        }

      

        /// <summary>
        /// Obtiene un ConfigurationFile <see cref="ConfigurationFile" atravez de su nombre/>
        /// </summary>
        /// <param name="pFileName">Nombre del archivo xml con la configuracion</param>
        /// <returns><see cref="ConfigurationFile"/></returns>
        /// <Author>Marcelo Oviedo</Author>
        public static ConfigurationFile GetConfigurationFile(string pFileName)
        {

            if (IsLocal())
            {
                return LocalConfigurationManager.GetConfigurationFile(pFileName);
            }
            else
            {
                return RemoteConfigurationManager.GetConfigurationFile(pFileName);
            }
        }


        /// <summary>
        /// Obtiene un grupo determinado en el archivo de configuracion
        /// </summary>
        /// <param name="pGroupName"></param>
        /// <returns>Group</returns>
        /// <Author>Marcelo Oviedo</Author>
        public static Group GetGroup(string pConfigProvider, string pGroupName)
        {
            if (IsLocal())
            {
                return LocalConfigurationManager.GetGroup(pConfigProvider, pGroupName);
            }
            else
            {
                return RemoteConfigurationManager.GetGroup(pGroupName);
            }
        }

        /// <summary>
        /// Obtiene un grupo determinado en el archivo de configuracion
        /// </summary>
        /// <param name="pGroupName"></param>
        /// <returns>Group </returns>
        /// <Author>Marcelo Oviedo</Author>
        public static Group GetGroup(string pGroupName)
        {
            if (IsLocal())
            {
                return LocalConfigurationManager.GetGroup(pGroupName);
            }
            else
            {
                return RemoteConfigurationManager.GetGroup(pGroupName);
            }
        }

        #region Operaciones validas solo para configuraciones remotas.-

        /// <summary>
        /// Obtiene la vercion de un archivo de configuracion para determinar el estado en el que se
        /// encuentra
        /// </summary>
        /// <param name="pFileName">Nombre del archivo</param>
        /// <param name="pClientVersion">Version del archivo del lado del cliente</param>
        /// <returns>FileStatus <see cref="FileStatus"/></returns>
        /// <Author>Marcelo Oviedo</Author>
        public static Helper.FileStatus GetFileVersionStatus(string pFileName, string pClientVersion)
        {
            if (IsLocal())
            {
                throw new Exception("Operacion no valida en un ambito de configuracion local ");
            }

            return RemoteConfigurationManager.GetFileVersionStatus(pFileName, pClientVersion);
        }
        #endregion 


        #region Metodos privados
        /// <summary>
        /// Determina si se utilixara onfiguracion del lado del cliente (LOCAL) o atravez de un servicio de configuracion
        /// remota.
        /// La opcion local es muy util en el ambiente de desarrollo para que el programador no tenga que lidear 
        /// con aspectos tecnicos de los servicios de configuracion y deje esta tarea para mas adelante cuando tenga el desarrollo 
        /// finalizado simplemeto estableciendo la propiedad "IsLocal" iguan a false en el App.config de la aplicacion.
        /// </summary>
        /// <returns>True si ya esta configurado o False si no</returns>
        /// <Author>Marcelo Oviedo</Author>
        private static bool IsLocal()
        {
            return _DefaultProvider.IsLocal;
            
        }
        private static bool IsLocal(string pProviderName)
        {
            return _ConfigProvider.GetProvider(pProviderName).IsLocal;
          
        }

        /// <summary>
        /// Metodo que lee el en el App.Config la Key = BaseConfigFile para obtener el nombre del archivo de configuracion
        /// utilizado
        /// </summary>
        /// <returns>String con el nombre del archivo</returns>
        /// <Author>Marcelo Oviedo</Author>
        internal static string GetBaseConfigFileName()
        {

            if (_DefaultProvider.BaseConfigFile == string.Empty)
            {
                throw new Exception("No hay un nombre de archivo de configuración.");
            }

            return _DefaultProvider.BaseConfigFile;

        }   
        /// <summary>
        /// Metodo que lee el en el App.Config la Key = BaseConfigFile para obtener el nombre del archivo de configuracion
        /// utilizado
        /// </summary>
        /// <returns>String con el nombre del archivo</returns>
        /// <Author>Marcelo Oviedo</Author>
        internal static string GetBaseConfigFileName(string pProviderName)
        {
          
           if (_ConfigProvider.GetProvider(pProviderName).BaseConfigFile == string.Empty)
            {
                throw new Exception("No hay un nombre de archivo de configuración.");
            }

            return _ConfigProvider.GetProvider(pProviderName).BaseConfigFile;

        }
	    #endregion

    }
    

}
