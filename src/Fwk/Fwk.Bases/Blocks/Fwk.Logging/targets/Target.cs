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
    public abstract class Target : Fwk.Logging.Targets.ITarget
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

        /// <summary>
        /// Busca eventos bajo los parametros indicadosdesde el origen de datos 
        /// que puede ser un Xml o una bas d edatos .-
        /// No es aplicable a eventos provenientes de visor de evento
        /// </summary>
        /// <param name="pEvent">Event como parametro de filtros</param>
        /// <returns></returns>
        public abstract Events SearchByParam(Event pEvent);
        /// <summary>
        /// Busca eventos bajo los parametros indicadosdesde el origen de datos 
        /// que puede ser un Xml o una bas d edatos .-
        /// No es aplicable a eventos provenientes de visor de evento
        /// </summary>
        /// <param name="pEvent">Event como parametro de filtros</param>
        /// <param name="pEndDate">Fecha limite de fin de busqueda</param>
        /// <returns></returns>
        public abstract Events SearchByParam(Event pEvent, DateTime pEndDate);
        #endregion



      
    }
}
