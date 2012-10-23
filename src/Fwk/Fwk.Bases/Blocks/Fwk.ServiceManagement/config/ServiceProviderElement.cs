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
            set { this["name"] = value; }
        }

        /// <summary>
        /// Determina el tipo de origen de la metadata de sercvicios
        /// </summary>
        [ConfigurationProperty("type", IsRequired = true, IsKey = false)]
        public ServiceProviderType ProviderType
        {
            get
            {
                return (ServiceProviderType)this["type"];
            }
            set { this["type"] = value; }
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
            set { this["sourceinfo"] = value; }
        }

        /// <summary>
        /// Identificador de aplicacion para buscarlo en la base de datos
        /// </summary>
        [ConfigurationProperty("appid", IsRequired = true, IsKey = false), StringValidator(InvalidCharacters = @"~!@#$%^&*[]{};'""|")]
        public string ApplicationId
        {
            get
            {
                return (string)this["appid"];
            }
            set { this["appid"] = value; }
        }

        /// <summary>
        /// Proveedor de seguridad de usuarios reglas y roles, con la que ocorreran los servicios
        /// </summary>
        [ConfigurationProperty("securityProviderName", IsRequired = false, IsKey = false), StringValidator(InvalidCharacters = @"~!@#$%^&*[]{};'""|")]
        public string SecurityProviderName
        {
            get
            {
                return (string)this["securityProviderName"];
            }
            set { this["securityProviderName"] = value; }
        }

        /// <summary>
        ///Cultura por defecto en la que se ejecutan los servicios. Util para definir archivos de configuracion determinados para un lenguage enpesífico
        ///Valores posibles: 
        ///Puede ser cualquier nombre standar para definir la cultura
        ///
        /// </summary>
        [ConfigurationProperty("defaultCulture", IsRequired = false, IsKey = false), StringValidator(InvalidCharacters = @"~!@#$%^&*[]{};'""|")]
        public string DefaultCulture
        {
            get
            {
                return (string)this["defaultCulture"];
            }
            set { this["defaultCulture"] = value; }
        }
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
    }

    /// <summary>
    /// entidad serializable auxiliar de ServiceProviderElement para uso de herramientas 
    /// </summary>
    [XmlInclude(typeof(MetadataProvider)), Serializable]
    public class MetadataProvider : BaseEntity
    {
        string _ApplicationId;

        /// <summary>
        /// 
        /// </summary>
        public string ApplicationId
        {
            get { return _ApplicationId; }
            set { _ApplicationId = value; }
        }
        string _Name;

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        string _ConfigProviderType;

        /// <summary>
        /// 
        /// </summary>
        public string ConfigProviderType
        {
            get { return _ConfigProviderType; }
            set { _ConfigProviderType = value; }
        }
        string _SecurityProviderName;

        /// <summary>
        /// 
        /// </summary>
        public string SecurityProviderName
        {
            get { return _SecurityProviderName; }
            set { _SecurityProviderName = value; }
        }
        string _SourceInfo;

        /// <summary>
        /// 
        /// </summary>
        public string SourceInfo
        {
            get { return _SourceInfo; }
            set { _SourceInfo = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public MetadataProvider()
        { }
        string _DefaultCulture= string.Empty;


        /// <summary>
        /// Reprecenta la cultura con la que trabajara el proveedor de configurador de servicios .- Este valor es utilizado y esta disponible 
        /// en cada servicio desde la capa SVC hacia abajo 
        /// 
        /// Estas son las formas de poder obtenerlo en las capas BackEnd:
        /// 
        /// string cultura = Fwk.ServiceManagement.ServiceMetadata.ProviderSection.GetProvider(providerName).DefaultCulture;
        /// string cultura = pServiceRequest.ContextInformation.DefaultCulture;
        /// 
        /// </summary>
        public string DefaultCulture { get {return _DefaultCulture;} }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        public MetadataProvider(ServiceProviderElement provider)
        {
            _ApplicationId = provider.ApplicationId;
            _ConfigProviderType = provider.ProviderType.ToString();
            _Name = provider.Name;
            _SourceInfo = provider.SourceInfo;
            _SecurityProviderName = provider.SecurityProviderName;
            _DefaultCulture = provider.DefaultCulture;
        }
    }
}
