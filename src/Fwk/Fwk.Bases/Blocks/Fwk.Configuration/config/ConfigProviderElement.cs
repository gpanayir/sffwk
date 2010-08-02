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
        /// Determina el tipo de origen de configuracion 
        /// </summary>
        [ConfigurationProperty("type", IsRequired = true, IsKey = false)]
        public ConfigProviderType ConfigProviderType
        {
            get
            {
                return (ConfigProviderType)this["type"];
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
        /// Nombre de cadena de coneccion
        ///  
        /// </summary>
        [ConfigurationProperty("cnnStringName", IsRequired = false, IsKey = false),
         StringValidator(InvalidCharacters = @"~!@#$%^&*[]{};'""|")]
        public string CnnStringName
        {
            get
            {
                return (string)this["cnnStringName"];
            }
        }
        [ConfigurationProperty("applicationId", IsRequired = false, IsKey = false),
         StringValidator(InvalidCharacters = @"~!@#$%^&*[]{};'""|")]
        public string ApplicationId
        {
            get
            {
                return (string)this["applicationId"];
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
        /// 
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
