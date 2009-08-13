using System;
using System.Xml;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Web.Services.Protocols;
using Fwk.Configuration;

namespace Fwk.Exceptions
{
    /// <summary>
    /// Excepcion Funcional.
    /// </summary>
    /// <Author>moviedo</Author>
    /// <Date>28-12-2005</Date>
    [ComVisible(false)]
    [Serializable()]
    public class FunctionalException : ApplicationException
    {
        

        #region --[Public Enums]--
        /// <summary>
        /// Severidad del error.
        /// </summary>
        public enum ExceptionSeverity
        {
            /// <summary>
            /// Severidad alta.
            /// </summary>
            High,
            /// <summary>
            /// Severidad media.
            /// </summary>
            Medium,
            /// <summary>
            /// Severidad baja.
            /// </summary>
            Low,
            /// <summary>
            /// Severidad desconocida.
            /// </summary>
            Unknown
        } 
        #endregion

        #region --[Protected Vars]--
        private Exception mex_InternalException = null;

        /// <summary>
        /// 
        /// </summary>
        protected Exception InternalException
        {
            get { return mex_InternalException; }
            set { mex_InternalException = value; }
        }
        private string[] _ParamsArray;

      
        /// <summary>
        /// Grupo en ConfigurationManager de Fwk
        /// </summary>
        protected String _GroupExceptionName = String.Empty;

        /// <summary>
        /// Key en ConfigurationManager del Fwk
        /// </summary>
        private String _KeyExceptionName = String.Empty;

      
        /// <summary>
        /// Message.
        /// </summary>
        protected string _Message = String.Empty;

        /// <summary>
        /// Id del error
        /// </summary>
        protected string _ErrorId;

        /// <summary>
        /// Severity.
        /// </summary>
        protected ExceptionSeverity mSeverity = ExceptionSeverity.High;
        #endregion

        #region --[Public Properties]--
        /// <summary>
        /// 
        /// </summary>
        protected string[] ParamsArray
        {
            get { return _ParamsArray; }
            set { _ParamsArray = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        protected String KeyExceptionName
        {
            get { return _KeyExceptionName; }
            set { _KeyExceptionName = value; }
        }


        /// <summary>
        /// Mensaje de error.
        /// </summary>
        public override string Message
        {
            get { return _Message; }
        }

        /// <summary>
        /// Identificador del error funcional en la base de conocimmiento del sistema.-
        /// </summary>
        public  string ErrorId
        {
            get { return _ErrorId; }
            set { _ErrorId = value; }
        }

        /// <summary>
        /// Severidad del error.
        /// </summary>
        public ExceptionSeverity Severity
        {
            get { return mSeverity; }
            set { mSeverity = value; }
        }

        /// <summary>
        /// Nombre del grupo donde obtener los mensages. Por defecto es el grupo FunctionalExceptionMassage
        /// </summary>
        public String GroupExceptionName
        {
            get { return _GroupExceptionName; }
            set { _GroupExceptionName = value; }
        }
        #endregion

        #region --[Constructors]--
        /// <summary>
        /// FunctionalException.
        /// </summary>
        /// <param name="pMessage"></param>
        public FunctionalException(string pMessage)
        {
            _Message = pMessage;
        }
        /// <summary>
        /// FunctionalException.
        /// </summary>
        /// <param name="pMessage"></param>
        public FunctionalException(int? errorId, string pMessage)
        {
            if (errorId != null)
                _ErrorId = errorId.ToString();
            _Message = pMessage;
        }

        /// <summary>
        /// Excepcion funcional.
        /// </summary>
        /// <param name="pinfo">The System.Runtime.Serialization.SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="pcontext">The System.Runtime.Serialization.StreamingContext that contains contextual information about the source or destination.</param>
        protected FunctionalException(SerializationInfo pinfo, StreamingContext pcontext): base(pinfo, pcontext)
        {
            _Message = pinfo.GetString("mMsg");
        }

        /// <summary>
        /// Excepcion funcional.
        /// Ej:
        /// throw new FunctionalException(1000,"SaldoInsuficiente","SaldoCliente")
        /// throw new FunctionalException(null,"SaldoInsuficiente","SaldoCliente")
        /// </summary>
        /// <param name="errorId">Id. del error del</param>
        /// <param name="keyExceptionName">Id. del mensaje en el Configuration Manager</param>
        /// <param name="pparams">Parametros a incluir en el mensaje de error. Reemplaza todos los {} deacuerdo al orden especificado</param>
        public FunctionalException(int? errorId, string keyExceptionName, params string[] pparams)
        {
            if (errorId != null)
                _ErrorId = errorId.ToString();
            _KeyExceptionName = keyExceptionName;
            _ParamsArray = pparams;
            _GroupExceptionName = Enum.GetName(typeof(FwkExceptionTypes), FwkExceptionTypes.FunctionalException) + "Message";
            SetMessage();
        }
        ///// <summary>
        ///// Excepcion funcional.
        ///// Ej:
        ///// throw new FunctionalException("SaldoInsuficiente","SaldoCliente")
        ///// </summary>
        ///// <param name="keyExceptionName">Id. del mensaje en el Configuration Manager</param>
        ///// <param name="pparams">Parametros a incluir en el mensaje de error. Reemplaza todos los {} deacuerdo al orden especificado</param>
        //public FunctionalException(string keyExceptionName, params string[] pparams)
        //    //: this(keyExceptionName, null, pparams)
        //{
        //    _KeyExceptionName = keyExceptionName;
        //    _ParamsArray = pparams;
        //    _GroupExceptionName = Enum.GetName(typeof(FwkExceptionTypes), FwkExceptionTypes.FunctionalException) + "Message";
        //    SetMessage();
        //}

        /// <summary>
        /// Excepcion funcional.
        /// throw new FunctionalException(70008,"SaldoInsuficiente","FunctionalExceptionGorup","SaldoCliente")
        /// </summary>
        /// <param name="errorId">Id del error funcional</param>
        /// <param name="keyExceptionName">Id. del mensaje en el Configuration Manager</param>
        /// <param name="groupExceptionName">Nombre del grupo donde se encuentran los mensages funcionales, 
        /// si este valor esta vacio se tomara uno por defecto llamadoFunctionalExceptionMessage
        /// </param>
        /// <param name="pparams">Parametros a incluir en el mensaje de error. Reemplaza todos los {} deacuerdo al orden especificado</param>
        public FunctionalException(int? errorId, string keyExceptionName, string groupExceptionName, params string[] pparams)
        {
            if (errorId != null) 
                _ErrorId = errorId.ToString();
            _KeyExceptionName = keyExceptionName;
            _ParamsArray = pparams;
            if (groupExceptionName.Trim().Length == 0)
                _GroupExceptionName = Enum.GetName(typeof(FwkExceptionTypes), FwkExceptionTypes.FunctionalException) + "Message";
            else
                _GroupExceptionName = groupExceptionName;

            SetMessage();

        }

        ///// <summary>
        ///// Excepcion funcional.
        ///// Ej:
        ///// throw new FunctionalException("SaldoInsuficiente","FunctionalExceptionGorup","SaldoCliente")
        ///// throw new FunctionalException("SaldoInsuficiente",String.Empty,"SaldoCliente")
        ///// </summary>
        ///// <param name="keyExceptionName">Id. del mensaje en el Configuration Manager</param>
        ///// <param name="groupExceptionName">Nombre del grupo donde se encuentran los mensages funcionales, 
        ///// si este valor esta vacio se tomara uno por defecto llamadoFunctionalExceptionMessage
        ///// </param>
        ///// <param name="pparams">Parametros a incluir en el mensaje de error. Reemplaza todos los {} deacuerdo al orden especificado</param>
        //public FunctionalException(string keyExceptionName, string groupExceptionName, params string[] pparams)

        //{
        //    _KeyExceptionName = keyExceptionName;
        //    _ParamsArray = pparams;
        //    if (groupExceptionName.Trim().Length == 0)
        //        _GroupExceptionName = Enum.GetName(typeof(FwkExceptionTypes), FwkExceptionTypes.FunctionalException) + "Message";
        //    else
        //        _GroupExceptionName = groupExceptionName;

        //    SetMessage();

        //}
        
            /// <summary>
        /// Excepcion funcional.
        /// </summary>
        /// <param name="errorId">Id del error funcional</param>
        /// <param name="keyExceptionName">Id. del mensaje.</param>
        /// <param name="pinner">Excepcion original.</param>
        /// <param name="pparams">Parametros a incluir en el mensaje de error.</param>
        public FunctionalException(int? errorId, string keyExceptionName, Exception pinner, params string[] pparams)
            : base(String.Empty, pinner)
        {
            if (errorId != null)
                _ErrorId = errorId.ToString();
            _KeyExceptionName = keyExceptionName;
            _ParamsArray = pparams;
            mex_InternalException = pinner;
            _GroupExceptionName = Enum.GetName(typeof(FwkExceptionTypes), FwkExceptionTypes.FunctionalException) + "Message";
            SetMessage();
        }

        ///// <summary>
        ///// Excepcion funcional.
        ///// </summary>
        ///// <param name="keyExceptionName">Id. del mensaje.</param>
        ///// <param name="pinner">Excepcion original.</param>
        ///// <param name="pparams">Parametros a incluir en el mensaje de error.</param>
        //public FunctionalException(string keyExceptionName, Exception pinner, params string[] pparams)
        //    : base(String.Empty, pinner)
        //{
        //    _KeyExceptionName = keyExceptionName;
        //    _ParamsArray = pparams;
        //    mex_InternalException = pinner;
        //    _GroupExceptionName = Enum.GetName(typeof(FwkExceptionTypes), FwkExceptionTypes.FunctionalException) + "Message";
        //    SetMessage();
        //}

        /// <summary>
        /// Excepcion funcional.
        /// </summary>
        /// <param name="errorId">Id del error funcional</param>
        /// <param name="keyExceptionName">Id. del mensaje.</param>
        /// <param name="pinner">Excepcion original.</param>
        /// <param name="groupExceptionName">Nombre del grupo donde obtener los mensages. Por defecto es el grupo FunctionalExceptionMassage</param>
        /// <param name="pparams">Parametros a incluir en el mensaje de error.</param>
        public FunctionalException(int? errorId, string keyExceptionName, Exception pinner, String groupExceptionName, params string[] pparams)
            : base(String.Empty, pinner)
        {
            if (errorId != null)
                _ErrorId = errorId.ToString();
            _KeyExceptionName = keyExceptionName;
            _ParamsArray = pparams;
            _GroupExceptionName = groupExceptionName;
            mex_InternalException = pinner;
            SetMessage();


        }

        ///// <summary>
        ///// Excepcion funcional.
        ///// </summary>
        ///// <param name="keyExceptionName">Id. del mensaje.</param>
        ///// <param name="pinner">Excepcion original.</param>
        ///// <param name="groupExceptionName">Nombre del grupo donde obtener los mensages. Por defecto es el grupo FunctionalExceptionMassage</param>
        ///// <param name="pparams">Parametros a incluir en el mensaje de error.</param>
        //public FunctionalException(string keyExceptionName, Exception pinner, String groupExceptionName, params string[] pparams)
        //    : base(String.Empty, pinner)
        //{

        //    _KeyExceptionName = keyExceptionName;
        //    _ParamsArray = pparams;
        //    _GroupExceptionName = groupExceptionName;
        //    mex_InternalException = pinner;
        //    SetMessage();

            
        //}

        ///// <summary>
        ///// Excepcion funcional.
        ///// </summary>
        ///// <param name="pinner">Excepcion original.</param>
        ///// <param name="pmessage">Mensaje de error.</param>
        //public FunctionalException(Exception pinner, string pmessage): base(pmessage, pinner)
        //{

        //    _Message = pmessage;
        //}

        /// <summary>
        /// Excepcion funcional.
        /// </summary>
        /// <param name="errorId">Id del error funcional</param>
        /// <param name="pinner">Excepcion original.</param>
        /// <param name="pmessage">Mensaje de error.</param>
        public FunctionalException(int? errorId, Exception pinner, string pmessage)
            : base(pmessage, pinner)
        {
            if (errorId != null)
                _ErrorId = errorId.ToString();
            _Message = pmessage;
        }

        /// <summary>
        /// Excepcion funcional.
        /// </summary>
        /// <param name="psoapEx">SoapException.</param>
        public FunctionalException(SoapException psoapEx)
        {
            XmlElement elem = psoapEx.Detail as XmlElement;
            string message = String.Empty;

            if (elem != null && elem.SelectSingleNode("Message") != null)
            {
                message = elem.SelectSingleNode("Message").InnerText;
            }

            _Message = message;
        }

        /// <summary>
        /// Este metodo intenta establecer el mensage desde ConfigurationManager (Grupo,Clave) 
        /// reemplaza los parametros por el String[]  -- Es decir
        /// </summary>
        void SetMessage()
        {
            string wMessage = String.Empty;

            try
            {
                // Obtiene el mensaje del Configuration Manager.
                try
                {
                    wMessage = ConfigurationManager.GetProperty(_GroupExceptionName, _KeyExceptionName);
                }
                catch (Exception ex)
                {
                    // Si no encuentra el mensaje de error explica el
                    // problema. De todos modos muestra el mensaje que ya
                    // venia en la excepcion.
                    
                    wMessage = string .Concat("El Mensaje de error no se encuentra disponible. \n", "Descripcion Tecnica: " , 
                        ExceptionHelper.GetAllMessageException(ex));

                    _ErrorId = FunctionalExceptionEnums.MsgErrorInConfigMannagerNotFount.ToString();
                }

         
                SetParametersToMessage(wMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Assigna los parametros que vienen en un strinh[] a la cadena 
        /// </summary>
        /// <param name="message"></param>
        void SetParametersToMessage(string message)
        {
            int wParamsNumber = ((_ParamsArray == null) ? 0 : _ParamsArray.Length);
           
            // Asigna los valores a cada parametro.
            for (int i = 0; i < wParamsNumber; i++)
            {
                message = message.Replace("{" + i.ToString() + "}", _ParamsArray[i]);
            }
            _Message = message;
        }
        
        #endregion

        #region --[Public Methods]--
        /// <summary>
        /// Sets the System.Runtime.Serialization.SerializationInfo with information about the exception.
        /// </summary>
        /// <param name="pinfo">The System.Runtime.Serialization.SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="pcontext">The System.Runtime.Serialization.StreamingContext that contains contextual information about the source or destination.</param>
        public override void GetObjectData(SerializationInfo pinfo, StreamingContext pcontext)
        {
            base.GetObjectData(pinfo, pcontext);

            pinfo.AddValue("mMsg", _Message);
        }
        #endregion
    }
}