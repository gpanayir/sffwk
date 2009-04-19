using System;
using System.Data.SqlClient;
using System.Runtime.Remoting;
using System.Web.Services.Protocols;
using System.Xml;
using System.Text;

namespace Fwk.Exceptions
{
    /// <summary>
    /// Enumeracion que reprecenta los tipos de excepciones de pelsoft
    /// </summary>
    public enum FwkExceptionTypes
    {
        /// <summary>
        /// TechnicalException
        /// </summary>
        TechnicalException = 0,
        /// <summary>
        /// FunctionalException
        /// </summary>
        FunctionalException = 1,
        /// <summary>
        /// DispatcherTecnicalExeption
        /// </summary>
        DispatcherTecnicalExeption = 2,
        /// <summary>
        /// WrapperConnectionsException
        /// </summary>
        WrapperConnectionsException = 3,
        /// <summary>
        /// BlockingFunctionalException
        /// </summary>
        BlockingFunctionalException = 4
    }
    /// <summary>
    /// Clase que procesa excepciones.
    /// </summary>
    /// <Author>moviedo</Author>
    /// <Date>28-12-2005</Date>
    public class ExceptionHelper
    {
        #region --[Public Static Methods]--
        /// <summary>
        /// Procesa la excepcion original y la retorna.
        /// </summary>
        /// <param name="pexception">Excepcion original.</param>
        /// <returns>Excepcion procesada.</returns>
        public static Exception ProcessException(Exception pexception)
        {
            return ProcessException(pexception, null);
        }

        /// <summary>
        /// Procesa la excepcion original y la retorna.
        /// </summary>
        /// <param name="pexception">Excepcion original.</param>
        /// <param name="psourceObject">Origen.</param>
        /// <returns>Excepcion procesada.</returns>
        public static Exception ProcessException(Exception pexception, object psourceObject)
        {
            // Si la excepcion es de SQL Server evalua si debe retornar
            // una FunctionalException o una TechnicalException.
            if (pexception is SqlException && ((SqlException)pexception).Number >= 50000)
            {
                string[] wParams;
                string wMsgId = ProcessRaiseErrorMsg(pexception.Message, out wParams);
                return new FunctionalException(wMsgId, wParams);
            }

            // Si la excepcion es FunctionalException, o TechnicalException,
            // simplemente la retorna.
            else if (pexception is FunctionalException || pexception is TechnicalException)
            {
                return pexception;
            }

            // Si es cualquier otro tipo de Excepcion, retorna una
            // TechnicalException.
            else
            {
                if (psourceObject == null)
                {
                    return new TechnicalException(pexception.Message, pexception.InnerException);
                }
                else
                {
                    return new TechnicalException(psourceObject.GetType().AssemblyQualifiedName
                        , psourceObject.GetType().Namespace
                        , psourceObject.GetType().Name
                        , Environment.MachineName
                        , Environment.UserName
                        , pexception);
                }
            }
        }

        /// <summary>
        /// <para>Transforma una excepción funcional en una SoapException,
        /// para poder serializarla a través de Soap.</para>
        /// </summary>
        /// <param name="pfex"></param>
        /// <param name="pabosoluteURI"></param>
        /// <returns></returns>
        public static SoapException ToSoapException(FunctionalException pfex, string pabosoluteURI)
        {
            return GetSoapException(pfex, pabosoluteURI);
        }

        /// <summary>
        /// Determina si una SoapException es de tipo funcional.
        /// </summary>
        /// <param name="psoapEx">SoapException.</param>
        /// <returns>Verdadero si la SoapException es de tipo funcional.</returns>
        public static bool IsFunctionalException(SoapException psoapEx)
        {
            string type = GetExceptionType(psoapEx);
            if (type == typeof(FunctionalException).FullName)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determina si una RemotingException es de tipo funcional.
        /// </summary>
        /// <param name="premEx">RemotingException.</param>
        /// <returns>Verdadero si la RemotingException es de tipo funcional.</returns>
        public static bool IsFunctionalException(RemotingException premEx)
        {
            if (premEx.GetType() == typeof(FunctionalException))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Genera un string con el contenido del InnerException .-
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static String GetAllMessageException(Exception ex)
        {
            StringBuilder wMessage = new StringBuilder();
            wMessage.Append(ex.Message);
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                wMessage.AppendLine("Source: ");
                wMessage.AppendLine(ex.Source);
                wMessage.AppendLine();
                wMessage.AppendLine("Message: ");
                wMessage.AppendLine(ex.Message);
            }
            return wMessage.ToString();
        }

        /// <summary>
        /// Genera un string con el contenido del InnerException .-
        /// </summary>
        /// <param name="pExceptions">Array de excepciones</param>
        /// <returns></returns>
        public static String GetAllMessageException(Exception[] pExceptions)
        {
            StringBuilder wMessage = new StringBuilder();
            Exception inner;
            foreach (Exception ex in pExceptions)
            {
                wMessage.Append(ex.Message);
                while (ex.InnerException != null)
                {
                    inner = ex.InnerException;
                    wMessage.AppendLine("Source: ");
                    wMessage.AppendLine(inner.Source);
                    wMessage.AppendLine();
                    wMessage.AppendLine("Message: ");
                    wMessage.AppendLine(inner.Message);
                }
            }
            return wMessage.ToString();
        }



        /// <summary>
        /// Retorna el tipo de una SoapException.
        /// </summary>
        /// <param name="psoapEx">SoapException</param>
        /// <returns>Tipo de la SoapException.</returns>
        private static string GetExceptionType(SoapException psoapEx)
        {
            XmlElement elem = psoapEx.Detail as XmlElement;
            string type = String.Empty;

            if (elem != null && elem.SelectSingleNode("Type") != null)
                type = elem.SelectSingleNode("Type").InnerText;

            return type;
        }

        #endregion

        #region --[Private Static Methods]--

        /// <summary>
        /// Procesa los de SqlServer con el formato "Identificador_Mensaje;Param1;Param2...".
        /// </summary>
        /// <param name="pSqlEx">Mensaje de error con formato "Identificador_Mensaje;Param1;Param2...".</param>
        /// <param name="pParams">Parametros a reemplazar en el mensaje.</param>
        /// <returns>Mensaje de error.</returns>
        private static string ProcessRaiseErrorMsg(string pSqlEx, out string[] pParams)
        {
            try
            {
                /* Formato RAISEERROR: "Identificador_Mensaje;Param1;Param2 */
                string[] wRaiseErrorMsg = pSqlEx.Split(';');
                int wParamsLenght = wRaiseErrorMsg.Length - 1;

                // Obtiene los parametros;
                pParams = new string[wParamsLenght];
                for (int i = 0; i < wParamsLenght; i++)
                {
                    pParams[i] = wRaiseErrorMsg[i + 1];
                }

                // Retorna el MsgId.
                return wRaiseErrorMsg[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene una SoapException.
        /// </summary>
        /// <param name="pexception">Excepcion original.</param>
        /// <param name="pabosoluteURI">URI.</param>
        /// <returns>SoapException.</returns>
        private static SoapException GetSoapException(Exception pexception, string pabosoluteURI)
        {
            // Build the detail element of the SOAP fault.
            XmlDocument doc = new XmlDocument();
            XmlNode node = doc.CreateNode(XmlNodeType.Element,
                SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);

            XmlElement elem;

            elem = doc.CreateElement("Type");
            elem.InnerText = pexception.GetType().FullName;
            node.AppendChild(elem);

            elem = doc.CreateElement("Message");
            elem.InnerText = pexception.Message;
            node.AppendChild(elem);

            elem = doc.CreateElement("StackTrace");
            elem.InnerText = pexception.StackTrace;
            node.AppendChild(elem);


            // Throw the exception
            return new SoapException("Fault occurred",
                SoapException.ClientFaultCode, pabosoluteURI, node);
        }
      
        #endregion

     


    }
}
