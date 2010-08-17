using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Fwk.Logging.Targets;
using System.Xml.Serialization;
using Fwk.Bases;

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

    [XmlInclude(typeof(MetadataProvider)), Serializable]
    public class MetadataProvider : BaseEntity
    {
        string _ApplicationId;

        public string ApplicationId
        {
            get { return _ApplicationId; }
            set { _ApplicationId = value; }
        }
        string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        string _ConfigProviderType;

        public string ConfigProviderType
        {
            get { return _ConfigProviderType; }
            set { _ConfigProviderType = value; }
        }
        string _SourceInfo;

        public string SourceInfo
        {
            get { return _SourceInfo; }
            set { _SourceInfo = value; }
        }
        public MetadataProvider()
        { }
        public MetadataProvider(ServiceProviderElement provider)
        {
            _ApplicationId = provider.ApplicationId;
            _ConfigProviderType = provider.ConfigProviderType.ToString();
            _Name = provider.Name;
            _SourceInfo = provider.SourceInfo;

        }
    }
}
