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

        

    }

}
