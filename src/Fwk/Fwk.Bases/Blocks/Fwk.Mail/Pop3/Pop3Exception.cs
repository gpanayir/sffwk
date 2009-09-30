using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.Mail.Pop3
{
    public class Pop3Exception : System.ApplicationException
    {
        public Pop3Exception(string str)
            : base(str)
        {
        }
    }
}