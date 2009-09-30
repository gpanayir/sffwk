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
            _LoggingSection = ConfigurationManager.GetSection("FwkLogging") as LoggingSection;
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
            WriteLog(EventType.Debug, pSource, pText,string.Empty);
        }

        /// <summary>
        /// Escribe el log de un evento de tipo 'Debug'.
        /// </summary>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pText">Mensaje descriptivo del evento.</param>
       /// <param name="path">ruta donde se guardaran los logs</param>
        public static void Debug(string pSource, string pText,string path)
        {
           
            // Escribe el log.
            WriteLog(EventType.Debug, pSource, pText, path);
        }

        /// <summary>
        /// Escribe el log de un evento de tipo 'Information'.
        /// </summary>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pText">Mensaje descriptivo del evento.</param>        
        public static void Information(string pSource, string pText)
        {
            // Escribe el log.
            WriteLog(EventType.Information, pSource, pText,string.Empty);
        }
        /// <summary>
        /// Escribe el log de un evento de tipo 'Information'.
        /// </summary>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pText">Mensaje descriptivo del evento.</param>   
        /// <param name="path">ruta donde se guardaran los logs</param>
        public static void Information(string pSource, string pText, string path)
        {
            // Escribe el log.---------
            WriteLog(EventType.Information, pSource, pText, path);
        }
        /// <summary>
        /// Escribe el log de un evento de tipo 'Information'.
        /// </summary>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pText">Mensaje descriptivo del evento.</param>   
        /// <param name="path">ruta donde se guardaran los logs</param>
        /// <param name="fileNamePrefix">Prefijo del nombre del archivo que se configuro para el evento
        /// Ej si se configuro Log.xml se almacenara bajo el patron:
        /// [fileNamePrefix]+Log.xml</param>
        public static void Information(string pSource, string pText, string path, string fileNamePrefix)
        {
            // Escribe el log.---------
            WriteLog(EventType.Information, pSource, pText, path, fileNamePrefix);
        }

        /// <summary>
        /// Escribe el log de un evento de tipo 'Warning'.
        /// </summary>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pText">Mensaje descriptivo del evento.</param>        
        public static void Warning(string pSource, string pText)
        {
            // Escribe el log.
            WriteLog(EventType.Warning, pSource, pText,string.Empty);
        }

        /// <summary>
        /// Escribe el log de un evento de tipo 'Warning'.
        /// </summary>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pText">Mensaje descriptivo del evento.</param>  
        /// <param name="path">ruta donde se guardaran los logs</param>
        public static void Warning(string pSource, string pText,string path)
        {
            // Escribe el log.
            WriteLog(EventType.Warning, pSource, pText, path);
        }
        /// <summary>
        /// Escribe el log de un evento de tipo 'Warning'.
        /// </summary>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pText">Mensaje descriptivo del evento.</param>  
        /// <param name="path">ruta donde se guardaran los logs</param>
        /// <param name="fileNamePrefix">Prefijo del nombre del archivo que se configuro para el evento
        /// Ej si se configuro Log.xml se almacenara bajo el patron:
        /// [fileNamePrefix]+Log.xml</param>
        public static void Warning(string pSource, string pText, string path, string fileNamePrefix)
        {
            // Escribe el log.
            WriteLog(EventType.Warning, pSource, pText, path, fileNamePrefix);
        }
      
        /// <summary>
        /// Escribe el log de un evento de tipo 'Error'.
        /// </summary>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pText">Mensaje descriptivo del evento.</param>        
        public static void Error(string pSource, string pText)
        {
            // Escribe el log.
            WriteLog(EventType.Error, pSource, pText,string.Empty);
        }


        /// <summary>
        /// Escribe el log de un evento de tipo 'Error'.
        /// </summary>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pText">Mensaje descriptivo del evento.</param>  
        /// <param name="path">ruta donde se guardaran los logs</param>
        public static void Error(string pSource, string pText, string path)
        {
            // Escribe el log.
            WriteLog(EventType.Error, pSource, pText, path);
        }
        /// <summary>
        /// Escribe el log de un evento de tipo 'Error'.
        /// </summary>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pText">Mensaje descriptivo del evento.</param>  
        /// <param name="path">ruta donde se guardaran los logs</param>
        /// <param name="fileNamePrefix">Prefijo del nombre del archivo que se configuro para el evento
        /// Ej si se configuro Log.xml se almacenara bajo el patron:
        /// [fileNamePrefix]+Log.xml</param>
        public static void Error(string pSource, string pText, string path, string fileNamePrefix)
        {
            // Escribe el log.
            WriteLog(EventType.Error, pSource, pText, path, fileNamePrefix);
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
            WriteLog(wEvent,string.Empty);
     
        }
        /// <summary>
        /// Escribe el log de un evento de tipo 'Error'.
        /// </summary>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pText">Mensaje descriptivo del evento.</param>
        /// <param name="pUserName">Nombre usuario.</param>
        ///  <param name="pMachine">Nombre usuario.</param>    
        /// <param name="path">ruta donde se guardaran los logs</param>
        public static void Audit(string pSource, string pText, string pUserName, string pMachine, string path)
        {
            // Escribe el log.
            //WriteLog(EventType.Audit, pSource, pText);
            // Crea un nuevo Event.
            Event wEvent = new Event(EventType.Audit, pSource, pText);
            wEvent.User = pUserName;
            wEvent.Machine = pMachine;
            WriteLog(wEvent, path);

        }
        #endregion

        #region <private methods>


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEventType">tipo de evente <see cref="EventType"/></param>
        /// <param name="pSource">origen del evento</param>
        /// <param name="pText">contenido del log</param>
        /// <param name="path">ruta</param>
        private static void WriteLog(EventType pEventType, string pSource, string pText,string path)
        {
            // Crea un nuevo Event.
            Event wEvent = new Event(pEventType, pSource, pText);

            // Obtiene la Rule asociada al EventType.
            RuleElement wRule = _LoggingSection.GetRuleByEventType(pEventType);

            // Escribe el log según la Rule.
            Target wTarget = GetTargetByRule(wRule, path,string.Empty);
            wTarget.Write(wEvent);  

            // Limpieza.
            wEvent = null;
            wRule = null;
        }

       /// <summary>
       /// 
       /// </summary>
        /// <param name="pEventType">tipo de evente <see cref="EventType"/></param>
       /// <param name="pSource">origen del evento</param>
       /// <param name="pText">contenido del log</param>
       /// <param name="path">ruta</param>
       /// <param name="fileNamePrefix">Prefijo del nombre del archivo que se configuro para el evento
       /// Ej si se configuro Log.xml se almacenara bajo el patron:
        /// [fileNamePrefix]+Log.xml</param>
        private static void WriteLog(EventType pEventType, string pSource, string pText, string path,string fileNamePrefix)
        {
            // Crea un nuevo Event.
            Event wEvent = new Event(pEventType, pSource, pText);

            // Obtiene la Rule asociada al EventType.
            RuleElement wRule = _LoggingSection.GetRuleByEventType(pEventType);

            // Escribe el log según la Rule.
            Target wTarget = GetTargetByRule(wRule, path, fileNamePrefix);
            wTarget.Write(wEvent);

            // Limpieza.
            wEvent = null;
            wRule = null;
        }

        private static void WriteLog(Event pEvent, string path)
        {
            // Obtiene la Rule asociada al EventType.
            RuleElement wRule = _LoggingSection.GetRuleByEventType(pEvent.Type);

            // Escribe el log según la Rule.
            Target wTarget = GetTargetByRule(wRule, path, string.Empty);
            wTarget.Write(pEvent);

            wRule = null;
            pEvent = null;
        }

       /// <summary>
        /// Reinicio los logs para que Xmltarget lo busque 
       /// en el archivo correspondiente o genere uno nuevo
       /// </summary>
        public static void ClearXmlTargetEvents()
        {
            XmlTarget.Logs = null;
        }
       static string currentFileName = string.Empty;
        private static Target GetTargetByRule(RuleElement pRule,string path,string fileNamePrefix)
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

                        if (string.IsNullOrEmpty(path))
                            wFile.FileName = string.Concat(fileNamePrefix, pRule.FileName);
                        else
                            wFile.FileName = System.IO.Path.Combine(path, string.Concat(fileNamePrefix, pRule.FileName));

                        //Si cambio el nombre del archivo de log reinicio los logs para que Xmltarget lo busque 
                        // en el archivo correspondiente o genere uno nuevo
                        if (string.Compare(wFile.FileName, currentFileName) != 0)
                        {
                            ClearXmlTargetEvents();
                            currentFileName = wFile.FileName;

                        }
                        return wFile;
                    }
                case TargetType.WindowsEvent:
                    {
                        return new WindowsEventTarget();
                    }
                case TargetType.Xml:
                    {
                        XmlTarget wXml = new XmlTarget();
                        if (string.IsNullOrEmpty(path))
                            wXml.FileName = string.Concat(fileNamePrefix, pRule.FileName);
                        else
                            wXml.FileName = System.IO.Path.Combine(path, string.Concat(fileNamePrefix, pRule.FileName));

                        //Si cambio el nombre del archivo de log reinicio los logs para que Xmltarget lo busque 
                        // en el archivo correspondiente o genere uno nuevo
                        if (string.Compare(wXml.FileName, currentFileName) != 0)
                        {
                            ClearXmlTargetEvents();
                            currentFileName = wXml.FileName;
                        }
                        return wXml;


                    }


            }
            return null;
        }
        #endregion
    }
}
