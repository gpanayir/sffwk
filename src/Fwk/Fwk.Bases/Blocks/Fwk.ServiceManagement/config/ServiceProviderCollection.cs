using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;


namespace Fwk.ServiceManagement
{
    /// <summary>
    /// Colección ServiceProviderElement 
    /// </summary>
    /// <date>2010/09/02</date>
    /// <author>moviedo</author>
    public class ServiceProviderCollection : ConfigurationElementCollection
    {
        #region <constructor>
        /// <summary>
        /// Constructor de ConfigElementCollection.
        /// </summary>
        public ServiceProviderCollection() { }
        #endregion

        #region <protected overrides>
        /// <summary>
        /// Crea un nuevo ConfigProviderElement en la colección.
        /// </summary>
        /// <returns>ConfigurationElement.</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new ServiceProviderElement();
        }

        /// <summary>
        /// Obtiene el key de un RuleElement.
        /// </summary>
        /// <param name="element">ConfigProviderElement del cual se desea conocer su key.</param>
        /// <returns>ConfigProviderElement.</returns>
        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((ServiceProviderElement)element).Name;
        }
        #endregion

        #region <public properties>
        /// <summary>
        /// Cantidad de proveedores de configuracion .
        /// </summary>
        public new int Count
        {

            get { return base.Count; }

        }

        /// <summary>
        /// Retorna un proveedor de configuracion según si índice.
        /// </summary>
        /// <param name="pIndex">índice del proveedor de configuracion que se desea obtener.</param>
        /// <returns>proveedor de configuracion</returns>
        public ServiceProviderElement this[int pIndex]
        {
            get
            {
                return (ServiceProviderElement)BaseGet(pIndex);
            }
        }
        #endregion

        #region <public methods>
        /// <summary>
        /// Retorna el índice del proveedor de configuracion.
        /// </summary>
        /// <param name="configProviderElement">ConfigProviderElement que se desea conocer su </param>
        /// <returns>índice</returns>
        public int IndexOf(ServiceProviderElement configProviderElement)
        {
            return BaseIndexOf(configProviderElement);
        }
        #endregion
    }
}
