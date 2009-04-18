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
