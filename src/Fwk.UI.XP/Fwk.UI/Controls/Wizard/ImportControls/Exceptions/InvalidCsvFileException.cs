using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Fwk.UI.Controls.ImportControls.Exceptions
{
    /// <summary>
    /// Excepsión lansada cuando un archivo CSV que se
    /// intenta procesar no es valido.
    /// </summary>
    public class InvalidCharSeparatedFileException : Exception
    {

        #region [Fields]
        private string _message = "El archivo de texto separado por un caracter no es valido.";
        #endregion

        #region [Constructors]
        public InvalidCharSeparatedFileException()
        {
            
        }
        public InvalidCharSeparatedFileException(string message)
            : base(message)
        {
            _message = message;
        }
        public InvalidCharSeparatedFileException(string message, Exception innerException)
            : base(message, innerException)
        {
            _message = message;
        }
        protected InvalidCharSeparatedFileException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }

        public override string Message
        {
            get
            {
                return _message;
            }
        }
        #endregion

    }
}
