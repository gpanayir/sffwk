using System;
using System.Collections.Generic;
using System.Text;

namespace Fwk.Logging.Targets
{
    /// <summary>
    /// Representa genéricamente los destinos de la escritura
    /// de los logs de eventos. 
    /// Es la clase base de los destinos.
    /// </summary>
    /// <date>2006/09/02</date>
    /// <author>moviedo</author>
    public abstract class Target
    {
        #region <private members>
        private TargetType _Type;
        private string _FileName;
        #endregion

        #region <public properties>
        /// <summary>
        /// Tipo de destino.
        /// </summary>
        public TargetType Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        /// <summary>
        /// Nombre de archivo sobre el cual se escribirá 
        /// el log del evento.
        /// </summary>
        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }
        #endregion

        #region <public abstract methods>
        /// <summary>
        /// método que escribe el log del evento sobre el
        /// destino.
        /// </summary>
        /// <param name="pEvent">Evento a loguear.</param>
        public abstract void Write(Event pEvent);
        #endregion
    }
}
