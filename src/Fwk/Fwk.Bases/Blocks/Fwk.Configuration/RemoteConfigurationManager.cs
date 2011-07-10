//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Text;
//using System.Runtime.Remoting;
//using System.Configuration;

//using Fwk.Configuration.Common;
//using Fwk.Bases.Properties;
//using Fwk.ConfigSection;

//namespace Fwk.Configuration
//{
//    internal  class RemoteConfigurationManager
//    {
//        /// <summary>
//        /// Determina si el objeto remoto ya fue obtenido de la configuracion de remoting o no
//        /// </summary>
//        /// <returns>True si ya esta configurado o False si no</returns>
//        private static bool IsConfigured()
//        {
//            bool wIs = false;

//            foreach (WellKnownClientTypeEntry wEntry in RemotingConfiguration.GetRegisteredWellKnownClientTypes())
//            {
//                if (wEntry.TypeName == typeof(ConfigurationHolder).FullName)
//                {
//                    wIs = true;
//                    break;
//                }
//            }

//            return wIs;
//        }

//        /// <summary>
//        /// Metodo que lee el en el App.Config la Key = BaseConfigFile para obtener el nombre del archivo de configuracion
//        /// utilizado
//        /// </summary>
//        /// <returns>String con el nombre del archivo</returns>
//        private static string GetBaseConfigFileName()
//        {
       
//            if (string.IsNullOrEmpty(ConfigurationManager.DefaultProvider.BaseConfigFile))
//            {
//                throw new Exception("No hay un nombre de archivo de configuración.");
//            }
      
//           return ConfigurationManager.DefaultProvider.BaseConfigFile;

//        }

//        private static void LoadConfigurationSettings()
//        {
//            if (!IsConfigured())
//            {
//                //Si no se encuentra algun nombre de archivo en el App.config
//                //if (string.IsNullOrEmpty(ConfigurationManager.DefaultProvider.RemotingConfigFile))
//                //{
//                //    throw new Exception("No hay ruta especificada para el archivo de configuración.");
//                //}
//                //else
//                //{
//                //    RemotingConfiguration.Configure(ConfigurationManager.DefaultProvider.RemotingConfigFile, false);
//                //}
//            }
//        }

//        private static ConfigurationHolder CreateConfigurationHolder()
//        {
//            LoadConfigurationSettings();

//            ConfigurationHolder wConfigHolder = new ConfigurationHolder();
//            return wConfigHolder;
//        }

//        /// <summary>
//        /// Obtiene una propiedad determinada de un archivo de configuracion .-
//        /// </summary>
//        /// <param name="pGroupName">Nombre del grupo donde se encuentra la propiedad</param>
//        /// <param name="pPropertyName">Nombre de la propiedad a obtener</param>
//        /// <returns>string</returns>
//        public static string GetProperty(string pGroupName, string pPropertyName)
//        {

//            ConfigurationHolder wConfigHolder = CreateConfigurationHolder();
//            string wBaseConfigFile = GetBaseConfigFileName();

//            string strProperty = wConfigHolder.GetProperty(wBaseConfigFile, pGroupName, pPropertyName);

//            if (strProperty.Length == 0)
//            {
//                /// no encontró nada, lanza excepcion
//                throw new Exception ("Ocurrió una excepción al buscar una propiedad. [" + pPropertyName + "] " +
//                    "La misma NO está configurada en ningún repositorio.");
//            }

//            return strProperty;
//        }


//        /// <summary>
//        /// Obtiene un ConfigurationFile <see cref="ConfigurationFile" atravez de su nombre/>
//        /// </summary>
//        /// <param name="pFileName">Nombre del archivo xml con la configuracion</param>
//        /// <returns><see cref="ConfigurationFile"/></returns>
//        public static ConfigurationFile GetConfigurationFile(string pFileName)
//        {
//            ConfigurationHolder wConfigHolder = CreateConfigurationHolder();
//            ConfigurationFile wResult = wConfigHolder.GetConfig(pFileName);
//            return wResult;
//        }

//        /// <summary>
//        /// Obtiene la vercion de un archivo de configuracion para determinar el estado en el que se
//        /// encuentra
//        /// </summary>
//        /// <param name="pFileName">Nombre del archivo</param>
//        /// <param name="pClientVersion">Version del archivo del lado del cliente</param>
//        /// <returns>FileStatus <see cref="FileStatus"/></returns>
//        public static Helper.FileStatus GetFileVersionStatus(string pFileName, string pClientVersion)
//        {
//            ConfigurationHolder wConfigHolder = CreateConfigurationHolder();
//            return wConfigHolder.GetFileVersionStatus(pFileName, pClientVersion);
            
//        }

//        /// <summary>
//        /// Obtiene un grupo determinado en el archivo de configuracion
//        /// </summary>
//        /// <param name="pGroupName"></param>
//        /// <returns>Group con los grupos contenidos en el archivo de configuracion</returns>
//        public static Group GetGroup(string pGroupName)
//        {
//            ConfigurationHolder wConfigHolder = CreateConfigurationHolder();
//            string wBaseConfigFile = GetBaseConfigFileName();

//            Group wGroup = wConfigHolder.GetGroup(wBaseConfigFile, pGroupName);

//            if (wGroup == null)
//            {
//                throw new Exception(
//                    "El grupo '" + pGroupName + "'no se encuentra " +
//                    "configurado en ninguno de los repositorios. " +
//                    "Archivo: '" + wBaseConfigFile + "'.");
//            }

//            return wGroup;
//        }

//        internal static object AddProperty(ConfigProviderElement provider, Key key, string groupName)
//        {
//            throw new NotImplementedException();
//        }

//        internal static object GetProperty(ConfigProviderElement provider, Group group)
//        {
//            throw new NotImplementedException();
//        }

//        internal static object AddGroup(ConfigProviderElement provider, Group group)
//        {
//            throw new NotImplementedException();
//        }

//        internal static void RemoveProperty(ConfigProviderElement provider, string groupName, string propertyName)
//        {
//            throw new NotImplementedException();
//        }

//        internal static void RemoveGroup(ConfigProviderElement provider, string groupName)
//        {
//            throw new NotImplementedException();
//        }

//        internal static void ChangeGroupName(ConfigProviderElement provider, string groupName, string newGroupName)
//        {
//            throw new NotImplementedException();
//        }

//        internal static void ChangeProperty(ConfigProviderElement provider, string groupName, Key property, string propertyName)
//        {
//            throw new NotImplementedException();
//        }

//        internal static ConfigurationFile RefreshConfigurationFile(ConfigProviderElement provider)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
