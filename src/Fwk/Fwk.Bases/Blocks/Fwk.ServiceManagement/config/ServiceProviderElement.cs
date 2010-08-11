using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Fwk.Logging.Targets;

namespace Fwk.ConfigSection
{
    /// <summary>
    /// ConfigProvider . 
    /// </summary>
    /// <date>2010/09/02</date>
    /// <author>moviedo</author>
    public class ServiceProviderElement : ConfigurationElement
    {
        #region <constructor>
        /// <summary>
        /// 
        /// </summary>
        public ServiceProviderElement() { }
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
        /// Determina el tipo de origen de la metadata de sercvicios
        /// </summary>
        [ConfigurationProperty("type", IsRequired = true, IsKey = false)]
        public ServiceProviderType ConfigProviderType
        {
            get
            {
                return (ServiceProviderType)this["type"];
            }
        }

 

        /// <summary>
        /// Archivo contenedor de la configuracion
        ///  
        /// </summary>
        [ConfigurationProperty("sourceinfo", IsRequired = true, IsKey = false), StringValidator(InvalidCharacters = @"~!@#$%^&*[]{};'""|")]
        public string SourceInfo
        {
            get
            {
                return (string)this["sourceinfo"];
            }
        }
        [ConfigurationProperty("appid", IsRequired = true, IsKey = false), StringValidator(InvalidCharacters = @"~!@#$%^&*[]{};'""|")]
        public string ApplicationId
        {
            get
            {
                return (string)this["appid"];
            }
        }
        #endregion
    }
}
