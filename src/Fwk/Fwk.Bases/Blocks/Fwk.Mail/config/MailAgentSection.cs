using System;
using System.Configuration;
using System.Collections.Generic;
using Fwk.Logging;

namespace Fwk.ConfigSection
{
    /// <summary>
    /// Sección 'MailAgentSection' del archivo de configuración App.Config.
    /// </summary>
    /// <date>2009/08/31</date>
    /// <author>moviedo</author>
    public class MailAgentSection : ConfigurationSection
    {
        #region <private members>
        MailAgentElement _MailAgentElement;
        #endregion

        #region <constructor>
        /// <summary>
        /// Constructor de MailAgentSection.
        /// </summary>
        public MailAgentSection()
        {
            _MailAgentElement = new MailAgentElement();
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
        /// Colección de proveedores de configuracion de mail agents. 
        /// </summary>
        [ConfigurationProperty("Providers", IsDefaultCollection = false)]
        public MailAgentElementCollection Providers
        {
            get
            {
                MailAgentElementCollection wConfigProviderCollection = (MailAgentElementCollection)base["Providers"];
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
        public MailAgentElement GetProvider(string name)
        {
            foreach (MailAgentElement wElement in this.Providers)
            {
                if (name.CompareTo(wElement.Name) ==0)
                {
                    return wElement;
                }

            }
            return null;
        }

        MailAgentElement _DefaultProvider = null;

        public MailAgentElement DefaultProvider
        {
            get { return _DefaultProvider = this.GetProvider((string)base["defaultProviderName"]);  }

        }

        #endregion

        
    }
}
