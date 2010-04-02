﻿using System;
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

        #region Metodos para generar log usando AppSetting

        /// <summary>
        /// Escribe el log de un evento .. Este metodo utiliza la configuracion del appsetting
        /// </summary>
        /// <param name="eventType"></param>
        public static void Log(Event eventType)
        {
            WriteLog(eventType, string.Empty, string.Empty);
        }
        /// <summary>
        /// Escribe el log de un evento .. Este metodo utiliza la configuracion del appsetting
        /// </summary>
        /// <param name="ev"></param>
        /// <param name="path">Ruta donde se desea almacenar el log</param>
        /// <param name="fileNamePrefix">prefijo (obcional) del archivo </param>
        public static void Log(Event ev, string path, string fileNamePrefix)
        {
            WriteLog(ev, path, fileNamePrefix);
        }

        ///// <summary>
        /////  Escribe el log de un evento .. Este metodo utiliza la configuracion del appsetting
        ///// </summary>
        ///// <param name="pSource">Origen del evento.</param>
        ///// <param name="pText">Mensaje descriptivo del evento.</param>
        ///// <param name="userName">Nombre usuario.</param>
        /////  <param name="machine">Nombre pc.</param>    
        //public static void Log(EventType eventType, string pSource, string pText, string userName, string machine)
        //{
        //    Event wEvent = new Event(eventType, pSource, pText);
        //    wEvent.UserLoginName = userName;
        //    wEvent.Machine = machine;
        //    WriteLog(wEvent, string.Empty, string.Empty);
        //}


        /// <summary>
        ///  Escribe el log de un evento .. Este metodo utiliza la configuracion del appsetting
        /// </summary>
        /// <param name="type">Tupo de evento <see cref="EventType"/></param>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pText">Mensaje descriptivo del evento.</param>
        /// <param name="userName">Nombre usuario.</param>
        ///  <param name="machine">Nombre pc.</param> 
        /// <param name="path">Ruta donde se desea almacenar el log</param>
        /// <param name="fileNamePrefix">prefijo (obcional) del archivo </param>
        //public static void Log(EventType type, string pSource, string pText, string userName, string machine, string path, string fileNamePrefix)
        //{

        //    Event wEvent = new Event(type, pSource, pText);
        //    wEvent.UserLoginName = userName;
        //    wEvent.Machine = machine;
        //    WriteLog(wEvent, path, fileNamePrefix);

        //}


        #endregion

        #region Metodos para generar log directamente sin usar AppSetting

        /// <summary>
        /// Escribe el log de un evento .. Este metodo utiliza la configuracion del appsetting
        /// </summary>
        /// <param name="targetType">Objetivo de log.</param>
        /// <param name="eventType"></param>
        /// <param name="fullFileName">Nombre completo del archivo</param>
        /// <param name="cnnStringName">Prefijo del nombre de archivo</param>
        public static void Log(TargetType targetType, Event eventType, string fullFileName, string cnnStringName)
        {
            WriteLogNoConfig(targetType, eventType, fullFileName, cnnStringName);
        }

        /// <summary>
        ///  Escribe el log de un evento .. Este metodo utiliza la configuracion del appsetting
        /// </summary>
        /// <param name="targetType">Objetivo de log.</param>
        /// <param name="eventType">Objetivo de log.</param>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pText">Mensaje descriptivo del evento.</param>
        /// <param name="userName">Nombre usuario.</param>
        ///  <param name="machine">Nombre pc.</param>    
        //public static void Log(TargetType targetType, EventType eventType, string pSource, string pText, string userName, string machine)
        //{

        //    Event wEvent = new Event(eventType, pSource, pText);
        //    wEvent.UserLoginName = userName;
        //    wEvent.Machine = machine;
        //    WriteLogNoConfig(targetType, wEvent, string.Empty, string.Empty);

        //}





        #endregion
        #region <private methods>



        /// <summary>
        /// Escrive un log.- Utiliza AppSetting. Es desir la informaciòn del archivo de configuración
        /// </summary>
        /// <param name="ev"></param>
        /// <param name="path"></param>
        /// <param name="fileNamePrefix">Prefijo del nombre de archivo</param>
        private static void WriteLog(Event ev, string path, string fileNamePrefix)
        {
            // Obtiene la Rule asociada al EventType.
            RuleElement wRule = _LoggingSection.GetRuleByEventType(ev.LogType);

            // Escribe el log según la Rule.
            Target wTarget = GetTargetByRule(wRule, path, fileNamePrefix);
            wTarget.Write(ev);

            wRule = null;
            ev = null;
        }

        /// <summary>
        /// Escrive un log sin utilizar la configuracion AppSettings
        /// </summary>
        /// <param name="targetType"></param>
        /// <param name="ev"></param>
        /// <param name="fullFileName">Nombre completo del archivo</param>
        /// <param name="cnnStringName">Prefijo del nombre de archivo</param>
        private static void WriteLogNoConfig(TargetType targetType, Event ev, string fullFileName, string cnnStringName)
        {
            // Escribe el log según la Rule.
            Target wTarget = GetTargetByRule_NoConfig(targetType, fullFileName, cnnStringName);
            wTarget.Write(ev);

            ev = null;
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
        /// <param name="rule"></param>
        /// <param name="path"></param>
        /// <param name="fileNamePrefix"></param>
        /// <returns></returns>
        private static Target GetTargetByRule(RuleElement rule, string path, string fileNamePrefix)
        {
            ITarget target = null;
            switch (rule.Target)
            {

                case TargetType.Database:
                    {
                        target = Target.TargetFactory(TargetType.Database, rule.CnnStringName);
                        break;
                    }
                case TargetType.File:
                    {
                        string fileName;
                        if (string.IsNullOrEmpty(path))
                            fileName = string.Concat(fileNamePrefix, rule.FileName);
                        else
                            fileName = System.IO.Path.Combine(path, string.Concat(fileNamePrefix, rule.FileName));

                        //Si cambio el nombre del archivo de log reinicio los logs para que Xmltarget lo busque 
                        // en el archivo correspondiente o genere uno nuevo
                        if (string.Compare(fileName, currentFileName) != 0)
                        {
                           
                            currentFileName = fileName;

                        }
                        target = Target.TargetFactory(TargetType.File, rule.FileName);
                        break;
                    }
                case TargetType.WindowsEvent:
                    {
                        target = Target.TargetFactory(TargetType.File, "WindowsEvent");
                        break;
                    }
                case TargetType.Xml:
                    {
                        string fileName;
                        if (string.IsNullOrEmpty(path))
                            fileName = string.Concat(fileNamePrefix, rule.FileName);
                        else
                            fileName = System.IO.Path.Combine(path, string.Concat(fileNamePrefix, rule.FileName));

                        //Si cambio el nombre del archivo de log reinicio los logs para que Xmltarget lo busque 
                        // en el archivo correspondiente o genere uno nuevo
                        if (string.Compare(fileName, currentFileName) != 0)
                        {
                            ClearXmlTargetEvents();
                            currentFileName = fileName;
                        }
                        target = Target.TargetFactory(TargetType.Xml, fileName);
                        break;
                    }
            }
            return (Target)target;
        }

        /// <summary>
        /// Configura y retorna un Target.- Llama Target.FactoryTarget quien es el encargado de crear realmente 
        /// el Target o retornar uno ya creado.-
        /// </summary>
        /// <param name="targetType">Tipo de target</param>
        /// <param name="fullFileName">Nombre de archivo (opcional)</param>
        /// <param name="cnnStringName">Cadena de coneccion</param>
        /// <returns></returns>
        private static Target GetTargetByRule_NoConfig(TargetType targetType, string fullFileName, string cnnStringName)
        {
            ITarget target = null;
            switch (targetType)
            {

                case TargetType.Database:
                    {
                        target = Target.TargetFactory(TargetType.Database, cnnStringName);
                        break;
                    }
                case TargetType.File:
                    {
                        //Si cambio el nombre del archivo de log reinicio los logs para que Xmltarget lo busque 
                        // en el archivo correspondiente o genere uno nuevo
                        if (string.Compare(fullFileName, currentFileName) != 0)
                        {
                            currentFileName = fullFileName;
                        }
                        target = Target.TargetFactory(TargetType.Xml, fullFileName);
                        break;
                    }
                case TargetType.WindowsEvent:
                    {
                        target = Target.TargetFactory(TargetType.File, "WindowsEvent");
                        break;
                    }
                case TargetType.Xml:
                    {
                        target = Target.TargetFactory(TargetType.Xml, fullFileName);
                        //Si cambio el nombre del archivo de log reinicio los logs para que Xmltarget lo busque 
                        // en el archivo correspondiente o genere uno nuevo
                        if (string.Compare(fullFileName, currentFileName) != 0)
                        {
                            ClearXmlTargetEvents();
                            currentFileName = fullFileName;
                        }
                        break;
                    }


            }
            return (Target)target;
        }
        #endregion
    }
}
