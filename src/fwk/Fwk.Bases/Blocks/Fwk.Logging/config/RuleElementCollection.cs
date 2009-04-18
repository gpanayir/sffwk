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
    /// <date>2006/09/02</date>
    /// <author>moviedo</author>
    public class RuleElementCollection : ConfigurationElementCollection
    {
        #region <constructor>
        /// <summary>
        /// Constructor de RuleElementCollection.
        /// </summary>
        public RuleElementCollection(){}
        #endregion

        #region <protected overrides>
        /// <summary>
        /// Crea un nuevo RuleElement en la colección.
        /// </summary>
        /// <returns>ConfigurationElement.</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new RuleElement();
        }

        /// <summary>
        /// Obtiene el key de un RuleElement.
        /// </summary>
        /// <param name="element">RuleElement del cual se desea conocer su key.</param>
        /// <returns>RuleElement.</returns>
        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((RuleElement)element).Name;
        }
        #endregion

        #region <public properties>
        /// <summary>
        /// Cantidad de reglas de logueo.
        /// </summary>
        public new int Count
        {

            get { return base.Count; }

        }

        /// <summary>
        /// Retorna una regla de logueo según si índice.
        /// </summary>
        /// <param name="pIndex">índice de la regla de logueo que se desea obtener.</param>
        /// <returns>Regla de logueo.</returns>
        public RuleElement this[int pIndex]
        {
            get
            {
                return (RuleElement)BaseGet(pIndex);
            }
        }
        #endregion

        #region <public methods>
        /// <summary>
        /// Retorna el índice de determinada regla de logueo.
        /// </summary>
        /// <param name="pRuleElement">Regla de logueo de la cual se desea conocer su </param>
        /// <returns>índice de la regla de logueo.</returns>
        public int IndexOf(RuleElement pRuleElement)
        {
            return BaseIndexOf(pRuleElement);
        }
        #endregion
    }
}
