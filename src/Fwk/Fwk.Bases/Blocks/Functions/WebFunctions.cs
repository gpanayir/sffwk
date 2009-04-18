using System.IO;
using System.Web;
/*
using System.Web.UI.WebControls;
*/

namespace Fwk.HelperFunctions
{
	/// <summary>
	/// Funciones para paginas web.
	/// </summary>
	/// <Date>12-07-2004</Date>
	/// <Author>moviedo</Author>
	public class WebFunctions
	{
		/// <summary>
		/// Decodifica las url codificadas con el método UrlEncode.
		/// Sirve por ejemplo para decodificar las Urls de Pectra.
		/// </summary>
		/// <param name="pServer">Servidor.</param>
		/// <param name="pQSCodificada">Query string codificada.</param>
		/// <returns>Un string con la Url decodificada.</returns>
		/// <Date>12-07-2004</Date>
		/// <Author>moviedo</Author>
		public static string UrlDecode(HttpServerUtility pServer, string pQSCodificada)
		{
			StringWriter wStringWriter = new StringWriter();
			pServer.UrlDecode(pQSCodificada, wStringWriter);
			string wRet = wStringWriter.ToString();
			return wRet;
		}

		/// <summary>
		/// Toma un parámetro de una Url de Pectra.
		/// </summary>
		/// <param name="pRequest">Request.</param>
		/// <param name="pQueryString">QueryString.</param>
		/// <param name="pParamId">Id del parametro.</param>
		/// <returns>Un string con el parametro.</returns>
		/// <Date>12-07-2004</Date>
		/// <Author>moviedo</Author>
		public static string QSParameterGet(HttpRequest pRequest, string pQueryString, string pParamId)
		{
			int wBegin;
			int wEnd;
			int wLen;
			string wRep = string.Empty;
			if(pQueryString.ToString().Length == 0)
			{
				return string.Empty;
			}

			wBegin = pQueryString.IndexOf(pParamId);
			if(wBegin > 0)
			{
				wEnd = pQueryString.Length;
				// posicion del &
				if(pQueryString.IndexOf("&", wBegin) > 0)
				{
					wEnd = pQueryString.IndexOf("&", wBegin) - 1;
				}

				// largo de la cadena a cortar
				wLen = (wEnd - wBegin) + 1;

				// Obtiene 'Uno=111'
				if(wLen > 0)
				{
					wRep = pQueryString.Substring(wBegin, wLen);

					// Separa en 'Uno'='111', para obtener solo '111'
					wBegin = wRep.IndexOf("=");

					if (wBegin > 0)
					{
						wRep = wRep.Substring(wBegin + 1);
					}
				}
			}
			if (wRep.Length == 0)
			{
				wRep = pRequest.QueryString[pParamId];
			}

			// Retorno el Valor del Parametro
			return wRep;
		}
	
/*
		/// <summary>
		/// Indica si un item existe en un DropDownList,
		/// buscando por valor.
		/// </summary>
		/// <param name="pCombo">DropDownList.</param>
		/// <param name="pValue">Valor.</param>
		/// <returns>True: si el item existe.</returns>
		/// <Date>16-07-2004</Date>
		/// <Author>moviedo</Author>
		private bool ItemFindByValue(DropDownList pCombo, string pValue)
		{
			//Deselecciona el Item en el combo
			ListItem wListItem = pCombo.SelectedItem;
			wListItem.Selected = false;

			//Busca y selecciona el Item en el combo
			wListItem = pCombo.Items.FindByValue(pValue);
		
			//Si no encuentra el item
			if(wListItem == null) 
			{
				pCombo.SelectedIndex = 0;
				return false;
			}
			
			//si Encuentra el Item
			wListItem.Selected = true;
			return true;
		}
*/

/*
		/// <summary>
		/// Indica si un item existe en un DropDownList,
		/// buscando por texto.
		/// </summary>
		/// <param name="pCombo">DropDownList.</param>
		/// <param name="pText">Texto.</param>
		/// <returns>True: si el item existe.</returns>
		/// <Date>16-07-2004</Date>
		/// <Author>moviedo</Author>
		private bool ItemFindByText(DropDownList pCombo, string pText)
		{
			//Deselecciona el Item en el combo
			ListItem wListItem = pCombo.SelectedItem;
			wListItem.Selected = false;

			//Busca y selecciona el Item en el combo
			wListItem = pCombo.Items.FindByText(pText);
		
			//Si no encuentra el item
			if(wListItem == null) 
			{
				pCombo.SelectedIndex = 0;
				return false;
			}
			
			//si Encuentra el Item
			wListItem.Selected = true;
			return true;
		}
*/
	}
}
