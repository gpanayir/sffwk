using System;
using System.Text;
using System.Configuration;
using System.Collections.Generic;
using Fwk.ConfigSection;
using Fwk.Logging.Targets;

namespace Fwk.Logging
{
   public static  class StaticLogger
    {
        
        #region <private members>
        private static LoggingSection _LoggingSection = null;
        #endregion

        #region <constructor>
        /// <summary>
        /// Constructor de Logger.
        /// </summary>
         static StaticLogger()
        {
            _LoggingSection = ConfigurationManager.GetSection("FwLogging") as LoggingSection;
        }
        #endregion

        #region <public properties>
        /// <summary>
        /// Escribe el log de un evento de tipo 'Debug'.
        /// </summary>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pText">Mensaje descriptivo del evento.</param>
        public static void Debug(string pSource, string pText)
        {
            // Escribe el log.
            WriteLog(EventType.Debug, pSource, pText);
        }

        /// <summary>
        /// Escribe el log de un evento de tipo 'Information'.
        /// </summary>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pText">Mensaje descriptivo del evento.</param>        
        public static void Information(string pSource, string pText)
        {
            // Escribe el log.
            WriteLog(EventType.Information, pSource, pText);
        }

        /// <summary>
        /// Escribe el log de un evento de tipo 'Warning'.
        /// </summary>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pText">Mensaje descriptivo del evento.</param>        
        public static void Warning(string pSource, string pText)
        {
            // Escribe el log.
            WriteLog(EventType.Warning, pSource, pText);
        }

        /// <summary>
        /// Escribe el log de un evento de tipo 'Error'.
        /// </summary>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pText">Mensaje descriptivo del evento.</param>        
        public static void Error(string pSource, string pText)
        {
            // Escribe el log.
            WriteLog(EventType.Error, pSource, pText);
        }

        /// <summary>
        /// Escribe el log de un evento de tipo 'Error'.
        /// </summary>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pText">Mensaje descriptivo del evento.</param>
        /// <param name="pUserName">Nombre usuario.</param>
        ///  <param name="pMachine">Nombre usuario.</param>    
        public static void Audit(string pSource, string pText, string pUserName, string pMachine)
        {
            // Escribe el log.
            //WriteLog(EventType.Audit, pSource, pText);
            // Crea un nuevo Event.
            Event wEvent = new Event(EventType.Audit, pSource, pText);
            wEvent.User = pUserName;
            wEvent.Machine = pMachine;
            WriteLog(wEvent);
     
        }
        #endregion

        #region <private methods>
        private static void WriteLog(EventType pEventType, string pSource, string pText)
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
        private static void WriteLog(Event pEvent)
        {
            // Obtiene la Rule asociada al EventType.
            RuleElement wRule = _LoggingSection.GetRuleByEventType(pEvent.Type);

            // Escribe el log según la Rule.
            Target wTarget = GetTargetByRule(wRule);
            wTarget.Write(pEvent);

            wRule = null;
            pEvent = null;
        }
        private static Target GetTargetByRule(RuleElement pRule)
        {
            switch (pRule.Target)
            {
                case TargetType.Console:
                    {
                        return new ConsoleTarget();
                    }
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
