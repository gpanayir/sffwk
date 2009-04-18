using System;

namespace Fwk.HelperFunctions
{
	/// <summary>
	/// Funciones que obtienen datos del Sistema Operativo.
	/// </summary>
	public class EnvironmentFunctions
	{
        static char _Dot;
        static System.Globalization.NumberFormatInfo _NumberFormatInfo = null;
        static char _Coma;

        /// <summary>
        /// Valor constante que reoprecenta el separador '.'
        /// </summary>
        public static char Dot
        {
            get { return EnvironmentFunctions._Dot; }
            set { EnvironmentFunctions._Dot = value; }
        }
        /// <summary>
        /// /// Valor constante que reoprecenta el separador ','
        /// </summary>
        public static char Coma
        {
            get { return EnvironmentFunctions._Coma; }
            set { EnvironmentFunctions._Coma = value; }
        }

        /// <summary>
        /// Indica el separador decimal actual
        /// </summary>
        public static char NumberDecimalSeparator
        {
            get { return Convert.ToChar(_NumberFormatInfo.NumberDecimalSeparator); }
        }

        /// <summary>
        /// Indica el separador miles.-
        /// </summary>
        public static char NumberGroupSeparator
        {
            get { return Convert.ToChar(_NumberFormatInfo.NumberGroupSeparator); }
        }

        static EnvironmentFunctions()
        {
            System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.InstalledUICulture;
            _NumberFormatInfo = (System.Globalization.NumberFormatInfo)ci.NumberFormat.Clone();
            _Dot = Convert.ToChar(".");
            _Coma = Convert.ToChar(",");
        }
        public static Boolean IsValidDecimalSeparator(string value)
        {
            return _NumberFormatInfo.NumberDecimalSeparator == value;
        }
	

        /// <summary>
        /// Determina si una aplicacione se encuentra en tiempo de diceño o no.
        /// </summary>
        /// <returns>Boolean</returns>
        /// <Author>Marcelo Oviedo</Author>
        public static Boolean IsInDesigntime()
        {
            return (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime ) ? true:false;
        }
	}

    
}


