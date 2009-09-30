using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Fwk.Logging;

namespace Fwk.ConfigSection
{
    /// <summary>
    /// Colección de reglas de logueo.
    /// </summary>
    /// <date>2009/08/31</date>
    /// <author>moviedo</author>
    public class MailAgentElementCollection : ConfigurationElementCollection
    {
        #region <constructor>
        /// <summary>
        /// Constructor de RuleElementCollection.
        /// </summary>
        public MailAgentElementCollection() { }
        #endregion

        #region <protected overrides>
        /// <summary>
        /// Crea un nuevo MailAgentElement en la colección.
        /// </summary>
        /// <returns>ConfigurationElement.</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new MailAgentElement();
        }

        /// <summary>
        /// Obtiene el key de un RuleElement.
        /// </summary>
        /// <param name="element">RuleElement del cual se desea conocer su key.</param>
        /// <returns>RuleElement.</returns>
        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((MailAgentElement)element).Name;
        }
        #endregion

        #region <public properties>
        /// <summary>
        /// Cantidad 
        /// </summary>
        public new int Count
        {

            get { return base.Count; }

        }

        /// <summary>
        /// Retorna MailAgent
        /// </summary>
        /// <param name="pIndex">índice .</param>
        /// <returns></returns>
        public MailAgentElement this[int pIndex]
        {
            get
            {
                return (MailAgentElement)BaseGet(pIndex);
            }
        }
        #endregion

        #region <public methods>
        /// <summary>
        /// Retorna el índice de determinada 
        /// </summary>
        /// <param name="pMailAgentElement"> </param>
        /// <returns>índice de la regla de logueo.</returns>
        public int IndexOf(MailAgentElement pMailAgentElement)
        {
            return BaseIndexOf(pMailAgentElement);
        }
        #endregion
    }
}
