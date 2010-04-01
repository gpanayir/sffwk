using System;
using System.Text;
using System.Configuration;
using System.Collections.Generic;
using Fwk.ConfigSection;
using Fwk.Logging.Targets;

namespace Fwk.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public static class StaticLogger
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
        ///  Escribe el log de un evento .. Este metodo utiliza la configuracion del appsetting
        /// </summary>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pText">Mensaje descriptivo del evento.</param>
        /// <param name="pUserName">Nombre usuario.</param>
        ///  <param name="pMachine">Nombre usuario.</param>    
        public static void Log(EventType type, string pSource, string pText, string pUserName, string pMachine)
        {
            // Escribe el log.
            //WriteLog(EventType.Audit, pSource, pText);
            // Crea un nuevo Event.
            Event wEvent = new Event(type, pSource, pText);
            wEvent.UserLoginName = pUserName;
            wEvent.Machine = pMachine;
            WriteLog(wEvent, string.Empty, string.Empty);

        }
        /// <summary>
        /// Escribe el log de un evento .. Este metodo utiliza la configuracion del appsetting
        /// </summary>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pText">Mensaje descriptivo del evento.</param>
        /// <param name="pUserName">Nombre usuario.</param>
        ///  <param name="pMachine">Nombre usuario.</param>    
        public static void Log(EventType type, string pSource, string pText, string pUserName, string pMachine, string path, string fileNamePrefix)
        {
            // Escribe el log.
            //WriteLog(EventType.Audit, pSource, pText);
            // Crea un nuevo Event.
            Event wEvent = new Event(type, pSource, pText);
            wEvent.UserLoginName = pUserName;
            wEvent.Machine = pMachine;
            WriteLog(wEvent, path, fileNamePrefix);

        }


        #endregion

        #region <private methods>


        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEvent"></param>
        /// <param name="path"></param>
        /// <param name="fileNamePrefix">Prefijo del nombre de archivo</param>
        private static void WriteLog(Event pEvent, string path, string fileNamePrefix)
        {
            // Obtiene la Rule asociada al EventType.
            RuleElement wRule = _LoggingSection.GetRuleByEventType(pEvent.LogType);

            // Escribe el log según la Rule.
            Target wTarget = GetTargetByRule(wRule, path, fileNamePrefix);
            wTarget.Write(pEvent);

            wRule = null;
            pEvent = null;
        }

        /// <summary>
        /// Escrive un log sin utilizar la configuracion AppSettings
        /// </summary>
        /// <param name="pTargetType"></param>
        /// <param name="fullFileName"></param>
        /// <param name="pCnnStringName">Prefijo del nombre de archivo</param>
        private static void WriteLog(TargetType pTargetType, Event pEvent, string fullFileName, string pCnnStringName)
        {
            // Escribe el log según la Rule.
            Target wTarget = GetTargetByRule(pTargetType, fullFileName, pCnnStringName);
            wTarget.Write(pEvent);

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pRule"></param>
        /// <param name="path"></param>
        /// <param name="fileNamePrefix"></param>
        /// <returns></returns>
        private static Target GetTargetByRule(RuleElement pRule, string path, string fileNamePrefix)
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pTargetType"></param>
        /// <param name="pFullFileName"></param>
        /// <param name="pCnnStringName"></param>
        /// <returns></returns>
        private static Target GetTargetByRule(TargetType pTargetType, string pFullFileName, string pCnnStringName)
        {
            switch (pTargetType)
            {

                case TargetType.Database:
                    {
                        DatabaseTarget wDatabase = new DatabaseTarget();
                        wDatabase.CnnStringName = pCnnStringName;
                        return wDatabase;
                    }
                case TargetType.File:
                    {
                        FileTarget wFile = new FileTarget();


                        wFile.FileName = pFullFileName;
                       

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
                       
                            wXml.FileName = pFullFileName;
                       

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
