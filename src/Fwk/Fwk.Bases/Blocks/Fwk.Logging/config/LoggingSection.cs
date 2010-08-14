using System;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;
using Fwk.Logging;
using Fwk.Exceptions;

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
            RuleElement wRule = null;
            foreach (RuleElement r in this.Rules)
            {
                if ( r.Events.Contains<EventType>(pEventType))
                wRule = r;
               
            }
            if(wRule  ==null)
            {

                TechnicalException te = new TechnicalException(String.Format("No se encuentra configurado el evento {0} en la seccion FwkLogging.", pEventType.ToString()));
                te.Assembly = "Fwk.Logging";
                te.Class = "LoginSection";
                te.ErrorId = "9001";
                te.Namespace = "Fwk.Logging";
                te.UserName = Environment.UserName;
                te.Machine = Environment.MachineName;
                throw te;
            }
            return wRule;
        }
        #endregion
    }
}
