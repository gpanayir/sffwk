using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Fwk.HelperFunctions
{
	/// <summary>
	/// Esta clase ayuda con los problemas que tienen que ver
	/// con la serialización de objetos.
	/// </summary>
	public class SerializationFunctions
	{
		#region -- Binary Serialization --

		/// <summary>
		/// Serializa un objeto a un archivo binario.
		/// </summary>
		/// <param name="fileName">Ruta del archivo en el cual depositar los bytes</param>
		/// <param name="objToSerialize">Objeto en memoria a transformar en bytes</param>
		public static void SerializeToBin(string fileName, object objToSerialize)
		{
			if (objToSerialize == null)
			{
				throw new Exception("El objeto a serializar no debe ser nulo.");
			}

			// Creo el archivo de destino y lo devuelvo a un fileStream
			FileStream fs = File.Create(fileName);

			// Creo un BinaryFormatter que me sirve como serializador
			BinaryFormatter serializer = new BinaryFormatter();

			// Le digo al serializador que guarde los bytes en un archivo
			// binario, representado por el FileStream
			serializer.Serialize(fs, objToSerialize);

			// Cierro el FileStream
			fs.Close();
		}

		/// <summary>
		/// Deserializa un objeto a partir del contenido de un archivo binario
		/// </summary>
		/// <param name="fileName">Archivo desde donde toma los bytes que se
		/// encuentran serializados</param>
		/// <returns>objeto deserializado</returns>
		public static object DeserializeFromBin(string fileName)
		{
			if (!File.Exists(fileName))
			{
				throw new Exception("El archivo de origen para deserializar " +
					"no existe. No se encuentra la ruta '" + fileName + "'");
			}

			// Abro el archivo de origen y lo devuelvo a un fileStream
			FileStream fs = File.OpenRead(fileName);

			// Creo un BinaryFormatter que me sirve como deserializador
			BinaryFormatter deserializer = new BinaryFormatter();

			// Le digo al deserializador que me devuelva el objeto a partir
			// del FileStream
			object objDeserialized = deserializer.Deserialize(fs);

			// Cierro el FileStream
			fs.Close();

			// Devuelvo el objeto deserializado
			return objDeserialized;
		}

		#endregion

		#region -- Xml Serialization using DataSet --

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pObject"></param>
		/// <param name="pDataSet"></param>
		public static void SerializeToXml(object pObject, ref DataSet pDataSet)
		{
			XmlSerializer wSerializer;
			MemoryStream wStream = new MemoryStream();

			if (pDataSet == null)
				pDataSet = new DataSet();

			wSerializer = new XmlSerializer(pObject.GetType());

			wSerializer.Serialize(wStream, pObject);

			wStream.Position = 0;
			pDataSet.ReadXml(wStream);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pObj"></param>
		/// <param name="pDataSet"></param>
		public static void Serialize(object pObj, ref DataSet pDataSet)
		{
			XmlSerializer serializer;
			MemoryStream ms = new MemoryStream();

			if(pDataSet == null)
				pDataSet = new DataSet();

			serializer = new XmlSerializer(pObj.GetType());
			serializer.Serialize(ms, pObj);

			ms.Position = 0;
			pDataSet.ReadXml(ms);
		}	
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pObjType"></param>
		/// <param name="pDataSet"></param>
		/// <param name="pTableName"></param>
		/// <returns></returns>
		public static object Deserialize(Type pObjType, DataSet pDataSet, string pTableName)
		{
			XmlDocument wDom = new XmlDocument();
			wDom.LoadXml(pDataSet.GetXml());
			return Deserialize(pObjType, wDom.GetElementsByTagName(pTableName).Item(0).OuterXml);
		}

		#endregion

		#region -- Xml Serialization using Xml --

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pObjType"></param>
		/// <param name="pXmlData"></param>
		/// <returns></returns>
		public static object Deserialize(Type pObjType, string pXmlData)
		{
			XmlSerializer wSerializer;
			UTF8Encoding wEncoder = new UTF8Encoding();
			MemoryStream wStream = new MemoryStream(wEncoder.GetBytes(pXmlData));

			wSerializer = new XmlSerializer(pObjType);
			return wSerializer.Deserialize(wStream);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pObjType"></param>
		/// <param name="pXmlData"></param>
		/// <param name="pXPath"></param>
		/// <returns></returns>
		public static object Deserialize(Type pObjType, string pXmlData, string pXPath)
		{
			XmlDocument wDom = new XmlDocument();
			wDom.LoadXml(pXmlData);
			return Deserialize(pObjType, wDom.DocumentElement.SelectSingleNode(pXPath).OuterXml);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pTipo"></param>
		/// <param name="pXml"></param>
		/// <returns></returns>
		public static object DeserializeFromXml(Type pTipo, string pXml)
		{
			XmlSerializer wSerializer;
			StringReader wStrSerializado = new StringReader(pXml);
			XmlTextReader wXmlReader = new XmlTextReader(wStrSerializado);
            //XmlSerializerNamespaces wNameSpaces = new XmlSerializerNamespaces();
			object wResObj = null;

            //wNameSpaces.Add(String.Empty, String.Empty);
			wSerializer = new XmlSerializer(pTipo);
			wResObj = wSerializer.Deserialize(wXmlReader);

			return wResObj;
		}
       
      
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pObj"></param>
		/// <returns></returns>
        public static string SerializeToXml(object pObj)
        {
            XmlSerializer wSerializer;
            StringWriter wStwSerializado = new StringWriter();
            XmlTextWriter wXmlWriter = new XmlTextWriter(wStwSerializado);
            XmlSerializerNamespaces wNameSpaces = new XmlSerializerNamespaces();

            wXmlWriter.Formatting = Formatting.Indented;
            wNameSpaces.Add(String.Empty, String.Empty);

            wSerializer = new XmlSerializer(pObj.GetType());
            wSerializer.Serialize(wXmlWriter, pObj, wNameSpaces);


            return wStwSerializado.ToString().Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", String.Empty);
        }

		/// <summary>
		/// Serializa un objeto.
		/// </summary>
		/// <param name="pObj">Objeto a serializar</param>
		/// <returns>Representación en XML del objeto</returns>
		public static string Serialize(object pObj)
		{
			return Serialize(pObj, false);
		}

		/// <summary>
		/// Serializa un objeto.
		/// </summary>
		/// <param name="pObj">Objeto a serializar</param>
		/// <param name="pRemoveDeclaration">Indica si se debe remover el nodo de declaración</param>
		/// <returns>Representación en XML del objeto</returns>
		public static string Serialize(object pObj, bool pRemoveDeclaration)
		{
			XmlDocument wDoc = new XmlDocument();
			wDoc.Load(GetStream(pObj));

			if (pRemoveDeclaration && wDoc.ChildNodes.Count > 0 && wDoc.FirstChild.NodeType == XmlNodeType.XmlDeclaration)
			{
				wDoc.RemoveChild(wDoc.FirstChild);
			}

			return wDoc.InnerXml;
		}


		/// <summary>
		/// Devuelve un stream formado a partir del objeto enviado por parámetro.
		/// </summary>
		/// <param name="pObj">Objeto para extraer stream</param>
		/// <returns>MemoryStream</returns>
		public static MemoryStream GetStream(object pObj)
		{
			XmlSerializer wSerializer;
			MemoryStream wStream = new MemoryStream();

			wSerializer = new XmlSerializer(pObj.GetType());
			wSerializer.Serialize(wStream, pObj);

			wStream.Position = 0;

			return wStream;
		}

		#endregion

        /// <summary>
        /// Serealiza pobject to json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeObjectToJson<T>( object obj)
        {
            MemoryStream stream1 = new MemoryStream();
            System.Runtime.Serialization.Json.DataContractJsonSerializer ser = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(T));
            ser.WriteObject(stream1, obj);

            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            return sr.ReadToEnd();
        }

   
          
        
        /// <summary>
        /// deserialize an instance of type T from JSON
        /// </summary>
        /// <param name="t"></param>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static T DeSerializeObjectFromJson<T>(string json)
        {
            var instance = Activator.CreateInstance<T>();
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(instance.GetType());
                return (T)serializer.ReadObject(ms);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pTypeNameOld"></param>
        /// <param name="pTypeNameNew"></param>
        /// <param name="pXml"></param>
        /// <returns></returns>
        public static string ReplaseTypeNameForSerialization(Type pTypeNameOld, Type pTypeNameNew, String pXml)
        {
            System.Text.StringBuilder strXml = new System.Text.StringBuilder(pXml);

            strXml.Replace("<" + pTypeNameOld.Name + ">", "<" + pTypeNameNew.Name + ">");
            strXml.Replace("</" + pTypeNameOld.Name + @">", "</" + pTypeNameNew.Name + @">");

            return strXml.ToString();
        }
	}
}