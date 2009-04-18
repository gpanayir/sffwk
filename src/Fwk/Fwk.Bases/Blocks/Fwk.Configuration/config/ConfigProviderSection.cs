using System;
using System.Configuration;
using System.Collections.Generic;

namespace Fwk.ConfigSection
{
    /// <summary>
    /// Sección 'ConfigProvider' del archivo de configuración App.Config.
    /// </summary>
    /// <date>2006/09/02</date>
    /// <author>moviedo</author>
    public class ConfigProviderSection : ConfigurationSection
    {
        #region <private members>
        ConfigProviderElement _ConfigProviderElement;
        #endregion

        #region <constructor>
        /// <summary>
        /// Constructor de ConfigProviderSection.
        /// </summary>
        public ConfigProviderSection()
        {
            _ConfigProviderElement = new ConfigProviderElement();
          
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
        public ConfigProviderCollection Providers
        {
            get
            {
                ConfigProviderCollection wConfigProviderCollection = (ConfigProviderCollection)base["Providers"];
                return wConfigProviderCollection;
            }
        }
        #endregion

        #region <public methods>
        /// <summary>
        /// Retorna un proveedor determinado
        /// </summary>
        /// <param name="pEventType">Tipo de evento.</param>
        /// <returns>Provider (Rule).</returns>
        public ConfigProviderElement GetProvider(string name)
        {
            foreach (ConfigProviderElement wElement in this.Providers)
            {
                if (name.CompareTo(wElement.Name) ==0)
                {
                    return wElement;
                }

            }
            return null;
        }

        ConfigProviderElement _DefaultProvider = null;

        public ConfigProviderElement DefaultProvider
        {
            get { return _DefaultProvider = this.GetProvider((string)base["defaultProviderName"]);  }

        }

        #endregion
    }
}
