using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Fwk.CodeGenerator.Common
{
	/// <summary>
	/// Colección de reglas de mapeo.
	/// </summary>
	
	/// <author>Marcelo Oviedo</author>
	public class DBTypeElementCollection : ConfigurationElementCollection
    {
        #region [Protected overrides]

        /// <summary>
		/// Crea un nuevo DBTypeElement en la colección.
        /// </summary>
        /// <returns>ConfigurationElement.</returns>
		
		/// <author>Marcelo Oviedo</author>
        protected override ConfigurationElement CreateNewElement()
        {
            return new DBTypeElement();
        }

        /// <summary>
		/// Obtiene el key de una regla de mapeo.
        /// </summary>
		/// <param name="element">DBTypeElement del cual se desea conocer su key.</param>
		/// <returns>Key de regla de mapeo.</returns>
		
		/// <author>Marcelo Oviedo</author>
        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((DBTypeElement)element).Name;
        }
        #endregion

        #region [Public properties]
        /// <summary>
        /// Cantidad de reglas de mapeo.
        /// </summary>
		
		/// <author>Marcelo Oviedo</author>
        public new int Count
        {

            get { return base.Count; }

        }

        /// <summary>
        /// Retorna una regla de mapeo según si índice.
        /// </summary>
        /// <param name="pIndex">índice de la regla de mapeo que se desea obtener.</param>
        /// <returns>Regla de mapeo.</returns>
		/// <author>Marcelo Oviedo</author>
        public DBTypeElement this[int pIndex]
        {
            get
            {
                return (DBTypeElement)BaseGet(pIndex);
            }
        }
        #endregion

        #region [Public methods]
        /// <summary>
        /// Retorna el índice de determinada regla de mapeo.
        /// </summary>
		/// <param name="pRuleElement">Regla de mapeo de la cual se desea conocer su índice</param>
		/// <returns>índice de la regla de mapeo.</returns>
		
		/// <author>Marcelo Oviedo</author>
		public int IndexOf(DBTypeElement pRuleElement)
        {
            return BaseIndexOf(pRuleElement);
        }
        #endregion
    }
}
