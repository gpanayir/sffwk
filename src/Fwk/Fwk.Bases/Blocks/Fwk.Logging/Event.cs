using System;
using System.Xml;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using System.Xml.Serialization;
using Fwk.Xml;


namespace Fwk.Logging
{
    /// <summary>
    /// Clase que modela el evento a loguear.
    /// </summary>
    /// <date>200609/02</date>
    /// <author>moviedo</author>
    [XmlInclude(typeof(Event)), Serializable]
    public class Event:Fwk.Bases.Entity
    {
        #region <private members>
        private String _Source;
        private EventType _Type;
        private Guid _Id;
        private string _User;
        private string _Machine;
        private CData _Message = new CData ();
        private DateTime _DateAndTime;
        #endregion

        #region <constructor>
        /// <summary>
        /// Constructor de Event.
        /// </summary>
        public Event(){}
        /// <summary>
        /// Constructor de Event.
        /// </summary>
        /// <param name="pType">Tipo de evento.</param>
        /// <param name="pSource">Origen del evento.</param>
        /// <param name="pMessage">Mensaje descriptivo del evento.</param>
        public Event(EventType pType, string pSource, string pMessage)
        {
            _Id = Guid.NewGuid();
            _Type = pType;
            _Source = pSource;
            _Message.Text = pMessage;
            _Machine = Environment.MachineName;
            _User = Environment.UserName;
            _DateAndTime = DateTime.Now;
        }
        #endregion

        #region <public properties>
        /// <summary>
        /// Mensaje descriptivo del evento.
        /// </summary>
        [XmlElement("Message", Type = typeof(Fwk.Xml.CData))]
        public CData Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        /// <summary>
        /// Fecha y hora en la que se produce el evento.
        /// </summary>
        [XmlAttribute("DateAndTime")]
        public DateTime DateAndTime
        {
            get { return _DateAndTime; }
            set { _DateAndTime = value; }
        }
        /// <summary>
        /// Equipo donde se origina el evento.
        /// </summary>
        [XmlAttribute("Machine")]
        public string Machine
        {
            get { return _Machine; }
            set { _Machine = value; }
        }

        /// <summary>
        /// Usuario que origina el evento.
        /// </summary>
        [XmlAttribute("User")]
        public string User
        {
            get { return _User; }
            set { _User = value; }
        }

        /// <summary>
        /// Identificador único del evento.
        /// </summary>
        [XmlAttribute("Id")]
        public Guid Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        /// <summary>
        /// Tipo de evento.
        /// </summary>
        [XmlAttribute("Type")]
        public EventType Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        /// <summary>
        /// Origen del evento.
        /// </summary>
        [XmlAttribute("Source")]
        public String Source
        {
            get { return _Source; }
            set { _Source = value; }
        }


        #endregion

        #region <public methods>
        /// <summary>
        /// Recopila la información de todos los atributos y 
        /// genera una cadena de texto con ella.
        /// </summary>
        /// <returns>Cadena de texto.</returns>
        public override string ToString()
        {
            StringBuilder wStringBuilder = new StringBuilder();
            wStringBuilder.Append(string.Concat("Log Id: ",this._Id));
            wStringBuilder.AppendLine();
            wStringBuilder.Append(" | Date: ");
            wStringBuilder.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff", CultureInfo.InvariantCulture));
            wStringBuilder.AppendLine(string.Concat(" Type: ",_Type.ToString().ToUpper()));

            wStringBuilder.AppendLine("Message: ");
            wStringBuilder.AppendLine(this._Message.Text);
            wStringBuilder.AppendLine(" Source: ");
            wStringBuilder.Append(this._Source);
            wStringBuilder.AppendLine(" User: ");
            wStringBuilder.Append(this._User);
            wStringBuilder.AppendLine(" Machine: ");
            wStringBuilder.Append(this._Machine);
            return wStringBuilder.ToString();
        }

  
        #endregion
    }
    
    [XmlRoot("Events"), SerializableAttribute]
    public class Events : Fwk.Bases.Entities<Event>
    { 
    
    }
}
