using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Collections.Generic;
using Fwk.Xml;
using Fwk.Exceptions;

namespace Fwk.Logging.Targets
{
    /// <summary>
    /// Destino de tipo archivo .Xml.
    /// </summary>
    /// <date>2006/09/02</date>
    /// <author>moviedo</author>
    public class XmlTarget : Target
    {
        public  static Logs Logs;
       
        #region <constructor>
        /// <summary>
        /// Constructor de XmlTarget.
        /// </summary>
        public XmlTarget()
        {
            this.Type = TargetType.Xml;
        }
        #endregion

        #region <public overrides>
        /// <summary>
        /// Implementación de la escritura del log del evento
        /// en archivo .Xml.
        /// </summary>
        /// <param name="pEvent">Evento a loguear.</param>
        public override void Write(Event pEvent)
        {

            LoadLogs();
            XmlTarget.Logs.Add(pEvent);
            Fwk.HelperFunctions.FileFunctions.SaveTextFile(this.FileName, XmlTarget.Logs.GetXml(), false);

       
           
        }
        #endregion

        #region <private methods>



        void LoadLogs()
        {
            if (XmlTarget.Logs == null )
                XmlTarget.Logs = OpenLogsFromFile();
        }

       
        /// <summary>
        /// Retorna un Logs asociado al archivo especificado
        /// en la propiedad FileName, si es que este existe. En caso
        /// contrario, retorna un 'nuevo' Logs.
        /// </summary>
        /// <returns>Logs.</returns>
         Logs OpenLogsFromFile()
        {
            

            #region validacion
            if (this.FileName.Trim().Length == 0)
            {
                TechnicalException te = new TechnicalException("Debe especificar un nombre de archivo para guardar el log.");
                te.Assembly = "Fwk.Logging.Targets";
                te.Class = "XmlTarget";
                te.ErrorId = "9000";
                te.Namespace = "Fwk.Logging";
                te.UserName = Environment.UserName;
                te.Machine = Environment.MachineName;
                throw te;
            }
            #endregion

            Logs wLog;
            

            if (!File.Exists(this.FileName))
            {
               

                return  new Logs();;
            }
            
            wLog = Logs.GetFromXml<Logs>(Fwk.HelperFunctions.FileFunctions.OpenTextFile(this.FileName));
            return wLog;
        }

        #endregion
    }
}
