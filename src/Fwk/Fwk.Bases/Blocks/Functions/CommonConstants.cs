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
        /// <summary>
        /// 
        /// </summary>
        public static class RegExpConstants
        {
            /// <summary>
            /// 
            /// </summary>
            public static string AlphaNumericNotAllowSimbols = "[^<>#$%*+/=?^`]*";
            /// <summary>
            /// 
            /// </summary>
            public static string Numeric = "";
            /// <summary>
            /// 
            /// </summary>
            public static string NumericDecimal = "";
            /// <summary>
            /// 
            /// </summary>
            public static string NumericDecimalWhitchPoint = "";
            /// <summary>
            /// 
            /// </summary>
            public static string Email = @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";
        }
    }
}
