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
    public class WrapperProviderElement : ConfigurationElement
    {
        #region <constructor>
        /// <summary>
        /// Constructor de RuleElement.
        /// </summary>
        public WrapperProviderElement() { }
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
        /// Determina el tipo wrapper:
        /// LocalWrapper:
        /// WebServiceWrapper
        /// RemotingWrapper
        /// </summary>
        [ConfigurationProperty("type", IsRequired = true, IsKey = false)]
        public string WrapperProviderType
        {
            get
            {
                return (string)this["type"];
            }
        }

 

        /// <summary>
        /// pueden ser :
        /// LocalWrapper= ""
        /// WebServiceWrapper: url
        /// RemotingWrapper : ruta del remotingconfigfile.xml 
        /// </summary>
        [ConfigurationProperty("sourceinfo", IsRequired = true, IsKey = false), 
         StringValidator(InvalidCharacters = @"~!@#$%^&*[]{};'""|")]
        public string SourceInfo
        {
            get
            {
                return (string)this["sourceinfo"];
            }
        }

        
        

       
        #endregion
    }
}