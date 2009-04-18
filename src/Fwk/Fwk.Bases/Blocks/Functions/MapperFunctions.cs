using System.IO;
using System.Xml;

namespace Fwk.HelperFunctions
{
	/// <summary>
	/// Summary description for MapperFunctions.
	/// </summary>
	public class MapperFunctions
	{
		/// <summary>
		/// 
		/// </summary>
		public MapperFunctions()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pXML"></param>
		/// <returns></returns>
		public static string ReformarXml(string pXML)
		{
			StringReader wReader = new StringReader(pXML);
			XmlTextReader wXmlReader = new XmlTextReader(wReader);
			wXmlReader.Namespaces = false;

			XmlDocument wDoc = new XmlDocument();
			wDoc.Load(wXmlReader);

			string wResult = ObtenerXmlNodo(wDoc.ChildNodes[0].ChildNodes[0]);

			return wResult;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pObject"></param>
		/// <returns></returns>
		public static string Serializar(object pObject)
		{
			string wResult = SerializationFunctions.SerializeToXml(pObject);
			XmlDocument wDoc = new XmlDocument();

			wDoc.LoadXml(wResult);

			wResult = ObtenerXmlNodo(wDoc.ChildNodes[0]);

			return wResult;
		}

		private static string ObtenerXmlNodo(XmlNode pNode)
		{
			string wResult = "<" + pNode.LocalName + ">" + pNode.InnerXml + "</" + pNode.LocalName + ">";
			return wResult;
		}
	}
}