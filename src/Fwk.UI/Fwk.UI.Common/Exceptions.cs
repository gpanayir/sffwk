using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Exceptions;
using System.Windows.Forms;

namespace Fwk.UI.Common
{
    public class Exceptions
    {

        public class ExceptionEventArgs : EventArgs
        {
            private Exception _ex;
            public ExceptionEventArgs(Exception ex)
            {
                _ex = ex;
            }
            public Exception Ex
            {
                get { return _ex; }
                set { _ex = value; }
            }
        }

        public static Exception ProcessException(ServiceError err)
        {

            Exception ex = null;
            switch (err.Type)
            {
                case "FunctionalException":
                    ex = new FunctionalException(String.Concat(err.Message, Environment.NewLine, err.InnerMessageException));
                    ex.Source = err.Source;
                    ((FunctionalException)ex).ErrorId = err.ErrorId;
                    break;
                case "TechnicalException":
                    ex = new TechnicalException(String.Concat(err.Message, Environment.NewLine, err.InnerMessageException));
                    ex.Source = err.Source;
                    ((TechnicalException)ex).ErrorId = err.ErrorId;
                    break;
                default:
                    ex = new Exception(String.Concat(err.Message, Environment.NewLine, err.InnerMessageException));
                    ex.Source = err.Source;
                    break;
            }
            return ex;
        }

    }

}
