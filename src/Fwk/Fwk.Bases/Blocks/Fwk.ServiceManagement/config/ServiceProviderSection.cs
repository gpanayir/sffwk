using System;
using System.Configuration;
using System.Collections.Generic;

namespace Fwk.ConfigSection
{
    /// <summary>
    /// Sección 'ServiceProviderSection' del archivo de configuración App.Config.
    /// </summary>
    /// <date>2010/09/02</date>
    /// <author>moviedo</author>
    public class ServiceProviderSection : ConfigurationSection
    {
        #region <private members>
        ServiceProviderElement _ServiceProviderElement;
        #endregion

        #region <constructor>
        /// <summary>
        /// Constructor de ConfigProviderSection.
        /// </summary>
       public ServiceProviderSection()
        {
            _ServiceProviderElement = new ServiceProviderElement();
          
        }
        #endregion

        #region <public properties>
        [ConfigurationProperty("defaultProviderName", DefaultValue = "defaultProvider")]
        public string DefaultProviderName
        {
            get
            {
                return (string)base["defaultProviderName"];
              
            }
            set
            {
                base["defaultProviderName"] = value;
            }
        }

        /// <summary>
        /// Colección de proveedores de coneccion. 
        /// </summary>
        [ConfigurationProperty("Providers", IsDefaultCollection = false)]
        public ServiceProviderCollection Providers
        {
            get
            {
               return (ServiceProviderCollection)base["Providers"];
            }
        }
        #endregion

        #region <public methods>
        /// <summary>
        /// Retorna un proveedor determinado
        /// </summary>
        /// <param name="pEventType">Tipo de evento.</param>
        /// <returns>Provider (Rule).</returns>
        public ServiceProviderElement GetProvider(string name)
        {
            if (string.IsNullOrEmpty(name))
                return this.DefaultProvider;
            foreach (ServiceProviderElement wElement in this.Providers)
            {
                if (name.CompareTo(wElement.Name) ==0)
                {
                    return wElement;
                }

            }
            return null;
        }
       

        ServiceProviderElement _DefaultProvider = null;

        public ServiceProviderElement DefaultProvider
        {
            get { return _DefaultProvider = this.GetProvider((string)base["defaultProviderName"]);  }

        }

        #endregion
    }

    /// <summary>
    /// Enumeracion que defino los tipos de 
    /// </summary>
    public enum ServiceProviderType
    { 
        /// <summary>
        /// Lee de un archivo local, puede ser carpeta compartida en la red.-
        /// </summary>
        xml,
        /// <summary>
        /// Utiliza la configuracion distribuida provista por el framework
        /// </summary>
        sqldatabase
       
    }
}
