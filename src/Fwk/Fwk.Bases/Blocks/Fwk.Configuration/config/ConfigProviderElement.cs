using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Fwk.Logging.Targets;

namespace Fwk.ConfigSection
{
    /// <summary>
    /// ConfigProvider . 
    /// 
    ///
    /// </summary>
    /// <date>2006/09/02</date>
    /// <author>moviedo</author>
    public class ConfigProviderElement : ConfigurationElement
    {
        #region <constructor>
        /// <summary>
        /// Constructor de RuleElement.
        /// </summary>
        public ConfigProviderElement() { }
        #endregion

        #region <public properties>
        /// <summary>
        /// Nombre de la regla. Es el identificador de una regla
        /// por lo tanto este nombre no debe repetirse.
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true, IsKey = true), StringValidator(InvalidCharacters = @" ~!@#$%^&*()[]{}/;'""|\")]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
        }

        /// <summary>
        /// Determina si la configuracion se lee localmente
        /// </summary>
        [ConfigurationProperty("isLocal", IsRequired = true, IsKey = false)]
        public  Boolean IsLocal
        {
            get
            {
                return (bool)this["isLocal"];
            }
        }

 

        /// <summary>
        /// Archivo contenedor de la configuracion
        ///  
        /// </summary>
        [ConfigurationProperty("baseConfigFile", IsRequired = true, IsKey = false), 
         StringValidator(InvalidCharacters = @"~!@#$%^&*[]{};'""|")]
        public string BaseConfigFile
        {
            get
            {
                return (string)this["baseConfigFile"];
            }
        }

 

        /// <summary>
        /// En caso de que la configuracion sea remota se debe espesificar el nombre del  
        /// archivo de configuracion de remoting.-
        /// </summary>
        [ConfigurationProperty("remotingConfigFile", IsRequired = false, IsKey = false), 
         StringValidator(InvalidCharacters = @"~!@#$%^&*[]{};'""|")]
        public string RemotingConfigFile
        {
            get
            {
                return (string)this["remotingConfigFile"];
            }
        }

        /// <summary>
   
        /// </summary>
        [ConfigurationProperty("lifeTime", IsRequired = false, IsKey = false)     ]
        public int LifeTime
        {
            get
            {
                return (int)this["lifeTime"];
            }
        }
        #endregion
    }
}
