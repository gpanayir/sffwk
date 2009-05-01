using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;


namespace Fwk.HelperFunctions
{
	/// <summary>
	/// Funciones para realizar conversiones.
	/// </summary>
	/// <Date>12-07-2009</Date>
	/// <Author>moviedo</Author>
	public class FormatFunctions
	{
		#region --[NullToString]--
		/// <summary>
		/// Retorna vacio si el nombre del campo es igual a NULL.-
		/// </summary>
		/// <param name="pFieldName">El nombre del campo.-</param>
		public static string NullToString(string pFieldName)
		{
			if(pFieldName == null) return String.Empty;
			return pFieldName;
		}

		#endregion

		#region --[ObjectToBytes]--
		/// <summary>
		/// Convierte un valor de tipo object en un array de bytes.
		/// </summary>
		/// <param name="pObjectToConvert">El objeto a convertir</param>
		/// <returns>Un array de bytes</returns>
		/// <Date>12-05-2009</Date>
		/// <Author>moviedo</Author>
		public static byte[] ObjectToBytes(object pObjectToConvert)
		{
			BinaryFormatter wBF = new BinaryFormatter();
			MemoryStream wMS = new MemoryStream();
			wBF.Serialize(wMS,pObjectToConvert);
			return wMS.GetBuffer();
		}

		#endregion

		#region --[ToDDMMYYY]--
		/// <summary>
		/// Aplica a una fecha el formato "DDMMYYYY" y la retorna.
		/// </summary>
		/// <param name="pDate">Fecha a formatear.</param>
		/// <param name="pSeparator">Separador a emplear en el nuevo formato.</param>
		/// <returns>Texto con la fecha formateada.</returns>
		/// <Date>12-07-2009</Date>
		/// <Author>moviedo</Author>
		public static string ToDDMMYYYY(DateTime pDate, char pSeparator)
		{
			StringBuilder sbFormat = new StringBuilder();
			sbFormat.Append("dd");
			sbFormat.Append(pSeparator);
			sbFormat.Append("MM");
			sbFormat.Append(pSeparator);
			sbFormat.Append("yyyy");
			return pDate.ToString(sbFormat.ToString());
		}

		/// <summary>
		/// Aplica a una fecha el formato "DDMMYYYY" y la retorna.
		/// </summary>
		/// <param name="pDate">Fecha a formatear.</param>
		/// <param name="pSeparator">Separador a emplear en el nuevo formato.</param>
		/// <returns>Texto con la fecha formateada.</returns>
		/// <Date>12-07-2009</Date>
		/// <Author>moviedo</Author>
		public static string ToDDMMYYYY(string pDate, char pSeparator)
		{
			if(pDate.Length == 0) return String.Empty;
			try
			{
				DateTime wDate = Convert.ToDateTime(pDate);
				return ToDDMMYYYY(wDate, pSeparator);
			}
			catch
			{
				return String.Empty;
			}
		}
		#endregion

		#region --[ToYYYYMMDD]--
		/// <summary>
		/// Aplica a una fecha el formato "YYYYMMDD" y la retorna.
		/// </summary>
		/// <param name="pDate">Texto de la fecha a formatear.</param>
		/// <param name="pSeparator">Separador a emplear en el nuevo formato.</param>
		/// <returns>Texto con la fecha formateada.</returns>
		/// <Date>12-07-2009</Date>
		/// <Author>moviedo</Author>
		public static string ToYYYYMMDD(string pDate, char pSeparator)
		{
			StringBuilder wReturn = new StringBuilder();
			wReturn.Append("1899");
			wReturn.Append(pSeparator);
			wReturn.Append("12");
			wReturn.Append(pSeparator);
			wReturn.Append("31");

			if(pDate.Length == 0) return wReturn.ToString();
			try
			{
				DateTime wDate = Convert.ToDateTime(pDate);
				return ToYYYYMMDD(wDate, pSeparator);
			}
			catch 
			{
				return wReturn.ToString();
			}
		}
		/// <summary>
		/// Aplica a una fecha el formato "YYYYMMDD" y la retorna.
		/// </summary>
		/// <param name="pDate">Fecha a formatear.</param>
		/// <param name="pSeparator">Separador a emplear en el nuevo formato.</param>
		/// <returns>Texto con la fecha formateada.</returns>
		/// <Date>12-07-2009</Date>
		/// <Author>moviedo</Author>
		public static string ToYYYYMMDD(DateTime pDate, char pSeparator)
		{
			StringBuilder wFormat = new StringBuilder();
			wFormat.Append("yyyy");
			wFormat.Append(pSeparator);
			wFormat.Append("MM");
			wFormat.Append(pSeparator);
			wFormat.Append("dd");

			return pDate.ToString(wFormat.ToString());
		}
		#endregion

		#region --[IntDefault]--
		/// <summary>
		/// Retorna el valor por defecto de un entero
		/// cuando el texto es vacio.
		/// </summary>
		/// <param name="pValue">Valor a analizar.</param>
		/// <returns>Valor por defecto.</returns>
		/// <Date>12-07-2009</Date>
		/// <Author>moviedo</Author>
		public static string IntDefault(string pValue)
		{
			if(pValue.Trim().Length > 0 ) return pValue;
			return "0";
		}

		#endregion

		#region -- Culture --

        ///// <summary>
        ///// devuelve un objeto CultureInfo, tomando de la configuracion (ConfigurationManager) la
        ///// información de la cultura que utiliza el AppServer
        ///// </summary>
        ///// <returns>objeto CultureInfo</returns>
        //public static CultureInfo GetApplicationServerCultureInfo()
        //{
        //    string culture = ConfigurationManager.GetProperty("Config", "ApplicationServerCultureName");
        //    CultureInfo ci = new CultureInfo(culture);
        //    return ci;
        //}

		#endregion


		#region -- RUT --

		/// <summary>
		/// Devuelve el Rut pasado por parametro formateado con los separadores de mil.
		/// </summary>
		/// <param name="pRUT"></param>
		/// <returns></returns>
		public static string FormatearRUT (string pRUT) 
		{
			pRUT = pRUT.Replace(" ", "");

			string wParteFicticia = String.Empty;
			string wParteInicial = pRUT.Substring(0, pRUT.IndexOf("-"));
			string wDigitoVerificador  = pRUT.Substring(pRUT.IndexOf("-"));

			foreach(char wChar in wParteInicial.ToCharArray())
			{
				if (TypeFunctions.IsAlpha(wChar.ToString())) 
				{
					wParteFicticia += wChar.ToString();
				}
				else 
				{
					break;
				}
			}

			if (wParteFicticia.Length > 0)
				wParteInicial = wParteInicial.Replace(wParteFicticia, "");

			string wResult = wParteFicticia;

			if (wParteInicial.Length > 0)
			{
				wResult += string.Format("{0:#,###,###,###,##0}", Convert.ToInt32(wParteInicial));
			}
				
			wResult += wDigitoVerificador;

			return wResult;
		}

		#endregion

        /// <summary>
        /// Obtiene la letra correspondiente al numero enviado 
        /// Solo valido para enteros entre 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public static String GetCharacterFromNumber(int pCode)
        {
            String wLetter = String.Empty;
            pCode = pCode + 64;
            if (pCode >= 65 || pCode <= 90) //entre A y Z
                wLetter = Enum.GetName(typeof(Keys),  64);

            return wLetter;
        }
	}
}
