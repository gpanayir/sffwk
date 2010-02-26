using System;
using System.Text;
using System.Configuration;
using System.Collections.Generic;

using Fwk.Logging.Targets;
using Fwk.ConfigSection;
using Fwk.Exceptions;

namespace Fwk.Logging
{
    /// <summary>
    /// Clase que administra la escritura de logs de eventos (Event) 
    /// en el destino (Target) correspondiente.
    /// </summary>
    /// <date>2006/09/02</date>
    /// <author>moviedo</author>
    public class Logger
    {
        #region <private members>
        private LoggingSection _LoggingSection = null;
        #endregion

        #region <constructor>
        /// <summary>
        /// Constructor de Logger.
        /// </summary>
        public Logger()
        {
            try
            {
                _LoggingSection = ConfigurationManager.GetSection("FwkLogging") as LoggingSection;
            }
            catch (System.Configuration.ConfigurationException ex)
            {

                TechnicalException te = new
                    TechnicalException("Hay problemas al intentar cargar la configuracion FwkLogging. \r\n ", ex);
                te.Assembly = "Fwk.Logging";
                te.Class = "LoginSection";
                te.ErrorId = "9002";
                te.Namespace = "Fwk.Logging";
                te.UserName = Environment.UserName;
                te.Machine = Environment.MachineName;
                throw te;
            }
        }
        #endregion

        #region <public properties>
        /// <summary>
        /// Escribe el log de un evento de tipo 'Debug'.
        /// </summary>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pText">Mensaje descriptivo del evento.</param>
        public void Debug(string pSource, string pText)
        {
            // Escribe el log.
            WriteLog(EventType.Debug, pSource, pText);
        }

        /// <summary>
        /// Escribe el log de un evento de tipo 'Information'.
        /// </summary>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pText">Mensaje descriptivo del evento.</param>        
        public void Information(string pSource, string pText)
        {
            // Escribe el log.
            WriteLog(EventType.Information, pSource, pText);
        }

        /// <summary>
        /// Escribe el log de un evento de tipo 'Warning'.
        /// </summary>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pText">Mensaje descriptivo del evento.</param>        
        public void Warning(string pSource, string pText)
        {
            // Escribe el log.
            WriteLog(EventType.Warning, pSource, pText);
        }

        /// <summary>
        /// Escribe el log de un evento de tipo 'Error'.
        /// </summary>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pText">Mensaje descriptivo del evento.</param>        
        public void Error(string pSource, string pText)
        {
            // Escribe el log.
            WriteLog(EventType.Error, pSource, pText);
        }

        /// <summary>
        /// Escribe el log de un evento de tipo 'audit'.
        /// </summary>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pText">Mensaje descriptivo del evento.</param>
        /// <param name="pUserName">Nombre usuario.</param>
        ///  <param name="pMachine">Nombre usuario.</param>
        public void Audit(string pSource, string pText, string pUserName, String pMachine)
        {
            // Escribe el log.
            WriteLog(EventType.Audit, pSource, pText);
            // Crea un nuevo Event.
            Event wEvent = new Event( EventType.Audit   , pSource, pText);
            wEvent.UserLoginName = pUserName;
            wEvent.Machine = pMachine;
            WriteLog(wEvent);
     
        }
        #endregion

        #region <private methods>
        private void WriteLog(EventType pEventType, string pSource, string pText)
        {
            // Crea un nuevo Event.
            Event wEvent = new Event(pEventType, pSource, pText);

            // Obtiene la Rule asociada al EventType.
            RuleElement wRule = _LoggingSection.GetRuleByEventType(pEventType);

            // Escribe el log según la Rule.
            Target wTarget = GetTargetByRule(wRule);
            wTarget.Write(wEvent);  

            // Limpieza.
            wEvent = null;
            wRule = null;
        }
        /// <summary>
        /// Escribe un log
        /// </summary>
        /// <param name="pEvent"></param>
        private void WriteLog(Event pEvent)
        {
            // Obtiene la Rule asociada al EventType.
            RuleElement wRule = _LoggingSection.GetRuleByEventType(pEvent.LogType);

            // Escribe el log según la Rule.
            Target wTarget = GetTargetByRule(wRule);
            wTarget.Write(pEvent);

            wRule = null;
            pEvent = null;
        }
        private Target GetTargetByRule(RuleElement pRule)
        {
            switch (pRule.Target)
            {
               
                case TargetType.Database:
                    {
                        DatabaseTarget wDatabase = new DatabaseTarget();
                        wDatabase.CnnStringName = pRule.CnnStringName;
                        return wDatabase;
                    }
                case TargetType.File:
                    {
                        FileTarget wFile = new FileTarget();
                        wFile.FileName = pRule.FileName;
                        return wFile;
                    }
                case TargetType.WindowsEvent:
                    {
                        return new WindowsEventTarget();
                    }
                case TargetType.Xml:
                    {
                        XmlTarget wXml = new XmlTarget();
                        wXml.FileName = pRule.FileName;
                        return wXml;
                    }
               
                    
            }
            return null;
        }
        #endregion
    }
}
