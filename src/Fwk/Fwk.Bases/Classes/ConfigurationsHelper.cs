using System;
using System.Collections.Generic;
using System.Text;

namespace Fwk.Bases
{
    /// <summary>
    /// 
    /// </summary>
    public static class ConfigurationsHelper
    {
        private static string _HostApplicationNname;

        /// <summary>
        /// Indica el nombre de la aplicacion que esta corriendo y utilizando el framework
        /// Ejemplo: Nombre de un servicio, nombre de sitio web, nombre de aplicacion de windows
        /// Este nombre lo utilizanlos componentes del framework para establecer el source u origen de 
        /// eventos lanzado por la aplicacion
        /// </summary>
        public static string HostApplicationNname
        {
            get { return _HostApplicationNname; }
            set { _HostApplicationNname = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static String WrapperSetting
        {
            get { return Properties.Settings.Default.Wrapper; }
            
        }


        
        /// <summary>
        /// 
        /// </summary>
        public static String RemotingConfigFilePathSetting
        {
            get { return Properties.Settings.Default.DispatcherRemotingConfigFilePath; }
            
        }
        /// <summary>
        /// 
        /// </summary>
        public static String WebServiceDispatcherUrlSetting
        {
            get { return Properties.Settings.Default.WebServiceDispatcherUrl; }

        }


        /// <summary>
        /// ServiceConfigurationFilePath
        /// </summary>
        public static String ServiceConfigurationSourceName
        {
            get { return Properties.Settings.Default.ServiceConfigurationSourceName; }

        }
        /// <summary>
        /// ServiceConfigurationManagerType
        /// </summary>
        public static String ServiceConfigurationManagerType
        {
            get { return Properties.Settings.Default.ServiceConfigurationManagerType; }

        }
        
    }
}
