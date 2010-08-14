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
	/// <Date>12-07-2009</Date>
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
		/// <Date>12-07-2009</Date>
		/// <Author>moviedo</Author>
		public static string UrlDecode(HttpServerUtility pServer, string pQSCodificada)
		{
			StringWriter wStringWriter = new StringWriter();
			pServer.UrlDecode(pQSCodificada, wStringWriter);
			string wRet = wStringWriter.ToString();
			return wRet;
		}

		


	}
}
