using System;
using System.Configuration;
using System.Collections.Generic;
using Fwk.Logging;

namespace Fwk.ConfigSection
{
    /// <summary>
    /// Sección 'Logging' del archivo de configuración App.Config.
    /// </summary>
    /// <date>2006/09/02</date>
    /// <author>moviedo</author>
    public class LoggingSection : ConfigurationSection
    {
        #region <private members>
        RuleElement _RuleElement;
        #endregion

        #region <constructor>
        /// <summary>
        /// Constructor de LoggingSection.
        /// </summary>
        public LoggingSection()
        {
            _RuleElement = new RuleElement();
        }
        #endregion

        #region <public properties>
        /// <summary>
        /// Colección de reglas de logueo. 
        /// </summary>
        [ConfigurationProperty("Rules", IsDefaultCollection = false)]
        public RuleElementCollection Rules
        {
            get
            {
                RuleElementCollection wRuleElementCollection = (RuleElementCollection)base["Rules"];
                return wRuleElementCollection;
            }
        }
        #endregion

        #region <public methods>
        /// <summary>
        /// Retorna la regla (Rule) que corresponde a determinado
        /// tipo de evento.
        /// </summary>
        /// <param name="pEventType">Tipo de evento.</param>
        /// <returns>Regla (Rule).</returns>
        public RuleElement GetRuleByEventType(EventType pEventType)
        {
            foreach (RuleElement wRule in this.Rules)
            {
                foreach (EventType wEvent in wRule.Events)
                {
                    if (pEventType == wEvent)
                    {
                        return wRule;
                    }
                }
            }
            return null;
        }
        #endregion
    }
}
