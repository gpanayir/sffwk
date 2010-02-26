using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.HelperFunctions
{
    /// <summary>
    /// 
    /// </summary>
    public static class Constants
    {
        public static class RegExpConstants
        {
            public static string AlphaNumericNotAllowSimbols = "[^<>#$%*+/=?^`]*";
            public static string Numeric = "";
            public static string NumericDecimal = "";
            public static string NumericDecimalWhitchPoint = "";
            public static string Email = @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";
        }
    }
}
