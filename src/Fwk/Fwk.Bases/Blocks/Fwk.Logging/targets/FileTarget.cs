using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Fwk.Exceptions;

namespace Fwk.Logging.Targets
{
    /// <summary>
    /// Destino de tipo archivo .log.
    /// </summary>
    /// <date>2006/09/02</date>
    /// <author>moviedo</author>
    public class FileTarget : Target
    {
        #region <constructor>
        /// <summary>
        /// Constructor de FileTarget.
        /// </summary>
        public FileTarget()
        {
            this.Type = TargetType.File;
        }
        #endregion
        #region <public overrides>
        /// <summary>
        /// Implementación de la escritura del log del evento
        /// en archivo .log.
        /// </summary>
        /// <param name="pEvent">Evento a loguear.</param>
        public override void Write(Event pEvent)
        {
            StreamWriter wStreamWriter;
            wStreamWriter = OpenStreamWriter();
            wStreamWriter.WriteLine(pEvent.ToString());
            wStreamWriter.Flush();
            wStreamWriter.Close();
            wStreamWriter = null;
        }
        #endregion

        #region <private methods>
        /// <summary>
        /// Retorna un StreamWriter según el FileName especificado 
        /// en la propiedad FileName.
        /// </summary>
        /// <returns>StreamWriter.</returns>
        private StreamWriter OpenStreamWriter()
        {
            StreamWriter wStreamWriter;

            if (this.FileName.Trim().Length == 0)
            {
                throw new TechnicalException("Debe especificar un FileName.");
            }

            FileInfo wFileInfo = new FileInfo(this.FileName);
            if (!wFileInfo.Exists)
            {
                if (!wFileInfo.Directory.Exists)
                {
                    Directory.CreateDirectory(wFileInfo.DirectoryName);
                }
            }
            wStreamWriter = new StreamWriter(this.FileName, true);
            return wStreamWriter;
        }
        #endregion
    }
}
