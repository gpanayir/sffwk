using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Fwk.Exceptions;
using Fwk.Bases;




namespace Fwk.Exceptions
{
    /// <summary>
    /// Contiene informacion del error de un servicio.-
    /// </summary>
    [XmlRoot("Error"), SerializableAttribute]
    public class ServiceError : BaseEntity
    {
        #region --[Protected Vars]--
        private String _Message;
        private String _InnerMessageException;
        private String _Source;
        private String _ErrorId;
        private String _Severity;
        private String _Type;

        /// <summary>
        /// Retorna el tipo de excepcion 
        /// </summary>
        public String Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        /// <summary>
        /// Assembly.
        /// </summary>
        protected string m_Assembly;

        /// <summary>
        /// Namespace.
        /// </summary>
        protected string m_Namespace;

        /// <summary>
        /// Class.
        /// </summary>
        protected string m_Class;

        /// <summary>
        /// Machine.
        /// </summary>
        protected string m_Machine;

        /// <summary>
        /// UserName.
        /// </summary>
        protected string m_UserName;

      
        #endregion

        #region --[Public Properties]--
        /// <summary>
        /// Assembly donde se produce la excepcion.
        /// </summary>
        public string Assembly
        {
            get { return m_Assembly; }
            set { m_Assembly = value; }
        }
        /// <summary>
        /// Namespace de la clase donde se produce la excepcion.
        /// </summary>
        public string Namespace
        {
            get { return m_Namespace; }
            set { m_Namespace = value; }
        }

        /// <summary>
        /// Clase donde se produce la excepcion.
        /// </summary>
        public string Class
        {
            get { return m_Class; }
            set { m_Class = value; }
        }

        /// <summary>
        /// Nombre del Equipo del cliente donde se produce la excepcion.
        /// </summary>
        public string Machine
        {
            get { return m_Machine; }
            set { m_Machine = value; }
        }

        /// <summary>
        /// Nombre del usuario cliente.
        /// </summary>
        public string UserName
        {
            get { return m_UserName; }
            set { m_UserName = value; }
        }

        /// <summary>
        /// Determina el grado de severidad del la exepción.-
        /// </summary>
        public String Severity
        {
            get { return _Severity; }
            set { _Severity = value; }
        }


        /// <summary>
        /// Indica el origen del error.-
        /// </summary>
        public String Source
        {
            get { return _Source; }
            set { _Source = value; }
        }

        /// <summary>
        /// Mensaje  descriptivo del error
        /// </summary>
        public String Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

        /// <summary>
        /// Trace de las excepciones producidas asta capturar el error
        /// </summary>
        public String InnerMessageException
        {
            get { return _InnerMessageException; }
            set { _InnerMessageException = value; }
        }

        /// <summary>
        /// Identificador del error
        /// </summary>
        public String ErrorId
        {
            get { return _ErrorId; }
            set { _ErrorId = value; }
        }

        #endregion

  

    
    }
}
