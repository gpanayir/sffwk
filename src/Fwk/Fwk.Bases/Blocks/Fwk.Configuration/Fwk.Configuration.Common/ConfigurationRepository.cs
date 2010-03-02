using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Collections.ObjectModel;
using Fwk.Bases;
using System.Xml;
using System.Reflection;
using System.IO;
using Fwk.HelperFunctions;
using System.ComponentModel;
namespace Fwk.Configuration.Common
{



    /// <summary>
    /// Clase contenedora de archivos de configuracion y sus estados. Esta clase permite cachear en memoria las configuraciones que
    /// son requeridas por las aplicacioenes. 
    /// </summary>
    /// <Author>Marcelo Oviedo</Author>
    public class ConfigurationRepository
    {

        private System.Collections.Generic.Dictionary<string, ConfigurationFile> _DictionaryFiles;


        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public ConfigurationRepository()
        {
         
            _DictionaryFiles = new System.Collections.Generic.Dictionary<string, ConfigurationFile>();
        }

        /// <summary>
        /// Agrega un configuration file al hashtable.
        /// </summary>
        /// <param name="pConfigurationFile">ConfigurationFile configurado.</param>
        public void AddConfigurationFile(ConfigurationFile pConfigurationFile)
        {
            if (pConfigurationFile == null)
            {
                throw new Exception("No hay datos para configurar.");
            }

            if (_DictionaryFiles.ContainsKey(pConfigurationFile.FileName))
            {
                throw new Exception("El archivo ya se encuentra configurado");
            }

            _DictionaryFiles.Add(pConfigurationFile.FileName, pConfigurationFile);

        }


        /// <summary>
        /// Obtiene un ConfigurationFile del hashtable.
        /// </summary>
        /// <param name="pFileName">Nombre de archivo.</param>
        /// <returns><see cref="ConfigurationFile"/></returns>
        public ConfigurationFile GetConfigurationFile(string pFileName)
        {
            if (_DictionaryFiles.ContainsKey(pFileName))
                return (ConfigurationFile)_DictionaryFiles[pFileName];
            else
                return null;
        }

        /// <summary>
        /// Agrega un configuration file al hashtable.
        /// </summary>
        /// <param name="pConfigurationFile">ConfigurationFile configurado.</param>
        public void RemoveConfigurationFile(ConfigurationFile pConfigurationFile)
        {
            if (pConfigurationFile == null)
            {
                throw new Exception("ConfigurationFile no puede ser nulo.");
            }

            if (!_DictionaryFiles.ContainsKey(pConfigurationFile.FileName))
            {
                throw new Exception("El archivo no existe");
            }

            _DictionaryFiles.Remove(pConfigurationFile.FileName);


        }

        public bool ExistConfigurationFile(string pFileName)
        {
           return _DictionaryFiles.ContainsKey(pFileName);

        }
    }

    /// <summary>
    /// Reprecenta un archivo de confuguracion y sus estados en memoria.-
    /// </summary>
    /// <Author>Marcelo Oviedo</Author>
    [XmlRoot("ConfigurationFile"), SerializableAttribute]
    public class ConfigurationFile:Entity
    {
        #region ConfigurationFile properties
       
        bool _Encrypted;
        string _FileName;
        int _TTL;
        bool _ForceUpdate;
        bool _BaseConfigFile = true;
       
        string _CurrentVersion;

        //Fwk.Xml.CData _FileContent = new Fwk.Xml.CData();

        //[XmlElement("FileContent", Type = typeof(Fwk.Xml.CData))]
        //public Fwk.Xml.CData FileContent
        //{
        //    get { return _FileContent; }
        //    set { _FileContent = value; }
        //}
      
      
        public bool Encrypted
        {
            get { return _Encrypted; }
            set { _Encrypted = value; }
        }

        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }

        public int TTL
        {
            get { return _TTL; }
            set { _TTL = value; }
        }

        public bool ForceUpdate
        {
            get { return _ForceUpdate; }
            set { _ForceUpdate = value; }
        }

        public bool BaseConfigFile
        {
            get { return _BaseConfigFile; }
            set { _BaseConfigFile = value; }
        }

        //public bool Cacheable
        //{
        //    get { return _Cacheable; }
        //    set { _Cacheable = value; }
        //}

        public string CurrentVersion
        {
            get { return _CurrentVersion; }
            set { _CurrentVersion = value; }
        }
        #endregion

        Groups _Groups;
        private DateTime _TimeStamp;
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public ConfigurationFile()
        {
            _TimeStamp = new DateTime(0);
        }
        /// <summary>
        /// Resultado de la invocacíon al webservice.
        /// </summary>
        public Groups Groups
        {
            get
            {
                return _Groups;
            }
            set
            {
                _Groups = value;
                _TimeStamp = DateTime.Now;
            }
        }


        /// <summary>
        /// Fecha y hora de la obtención de la configuración.
        /// </summary>
        public DateTime TimeStamp
        {
            get
            {
                return _TimeStamp;
            }
        }


        

        /// <summary>
        /// Chequea si el archivo expiró.
        /// </summary>
        /// <returns>bool</returns>
        public bool CheckExpiration()
        {
            bool wResult = (TTL != 0 && this._TimeStamp.AddSeconds(TTL) < DateTime.Now);
            return wResult;
        }

        /// <summary>
        /// Devuelve el estado del ConfigurationFile
        /// </summary>
        /// <returns>FileStatus</returns>
        public Helper.FileStatus CheckFileStatus()
        {
            Helper.FileStatus wStatus;

            if (_TimeStamp == new DateTime(0))
                wStatus = Helper.FileStatus.Inconsistent;
            else if (CheckExpiration())
                wStatus = Helper.FileStatus.Expired;
            else
                wStatus = Helper.FileStatus.Ok;

            return wStatus;

        }

    }
    

    [XmlRoot("Groups"), SerializableAttribute]
    public class Groups : Entities<Group>
    {

        public Group GetFirstByName(string pName)
        {

            IEnumerable<Group> wItem = this.Where(p => p.Name == pName);
            if (wItem.Count<Group>() == 0) return null;

            return wItem.First<Group>();
        }

        #region IXmlSerializable Members

        //public System.Xml.Schema.XmlSchema GetSchema()
        //{
        //    // A little too complicated for my taste
        //    return null;
        //}

        //public void ReadXml(XmlReader reader)
        //{
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(reader);
        //    XmlElement docElem = doc.DocumentElement;

        //    // Reflect the [XmlAttribute]'s
        //    PropertyInfo[] props = this.GetType().GetProperties();
        //    foreach (PropertyInfo prop in props)
        //    {
        //        object[] attrs = prop.GetCustomAttributes(typeof(XmlElementAttribute), false);
        //        if (attrs != null && attrs.Length == 1)
        //        {
        //            string name = (attrs[0] as XmlElementAttribute).ElementName ?? prop.Name;

        //            if (docElem.Attributes[name] != null)
        //                prop.GetSetMethod().Invoke(this, new object[] { docElem.Attributes[name].Value });
        //        }
        //    }
        //    XmlElement elem ;
        //    // Deserialize the collection members
        //    XmlNodeList nodes = docElem.SelectNodes("./*");
        //    foreach (XmlNode node in nodes)
        //    {
        //        // Make sure it isn't a text node or something
        //        if (node is XmlElement)
        //        {
                  
        //            System.Type wPropType = ReflectionFunctions.GetPropertieType(this, node.Name);
        //            if(wPropType == null)
        //                elem = doc.CreateElement(typeof(Group).Name);
        //            else
        //             elem = doc.CreateElement(wPropType.Name);
        //            elem.InnerXml = node.InnerXml;
        //            //foreach (XmlAttribute xmlAttr in (node as XmlElement).Attributes)
        //            //{
        //            //    XmlAttribute newAttr = doc.CreateAttribute(xmlAttr.Name);
        //            //    newAttr.Value = xmlAttr.Value;
        //            //    elem.AppendChild(newAttr);
        //            //}

        //            this.Add(Serializer.DeserializeFromXml<Group>(elem.InnerXml));
        //        }
        //    }
        //}

        //public void WriteXml(XmlWriter writer)
        //{
        //    // Reflect the [XmlAttribute]'s
           
        //    foreach (PropertyInfo prop in this.GetType().GetProperties())
        //    {
        //        //object[] attrs = prop.GetCustomAttributes(typeof(XmlAttributeAttribute), false);
        //        object[] attrs = prop.GetCustomAttributes(typeof(XmlElementAttribute), false);
        //        if (attrs != null && attrs.Length == 1)
        //        {
        //            string name = (attrs[0] as XmlElementAttribute).ElementName;
        //            if (name == null) name = prop.Name;

        //            object value = prop.GetGetMethod().Invoke(this, null);
        //            if (value != null)
        //                writer.WriteElementString(name, value.ToString());
        //        }
        //    }

        //     //Serialize the collection members
        //    foreach (Group item in this)
        //    {
        //        string itemName = arrayItemName ?? typeof(Group).Name;

        //        //XmlElement serializedItem = Serializer.Serialize<Group>(item);
        //        string serializedItem = Serializer.SerializeToXml<Group>(item);
                
        //        //writer.WriteStartElement(itemName);
        //        //foreach (XmlAttribute xmlAttr in serializedItem.Attributes)
        //        //{
        //        //    // We don't want to write the xsd/xsi namespace attributes
        //        //    if (!(xmlAttr.Name.StartsWith("xmlns:xsd") || xmlAttr.Name.StartsWith("xmlns:xsi")))
        //        //        writer.WriteElementString(xmlAttr.Name, xmlAttr.Value);
        //        //}
        //        writer.WriteRaw(serializedItem);
        //        //writer.WriteEndElement();
        //    }
        //}
        #endregion

    }




    [XmlInclude(typeof(Group)), Serializable]
    public class Group : Fwk.Bases.Entity
    {
        string _name;
        [XmlAttribute("name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        Keys _Keys = new Keys();

        public Keys Keys
        {
            get { return _Keys; }
            set { _Keys = value; }
        }


       
 

    }
    /// <summary>
    /// 
    /// </summary>
    [XmlRoot("Keys"), SerializableAttribute]
    public class Keys : Fwk.Bases.Entities<Key>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        public Key GetFirstByName(string pName)
        {

            IEnumerable<Key> wItem = this.Where(p => p.Name == pName);
            if (wItem.Count<Key>() == 0) return null;

            return wItem.First<Key>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        public int GetCountByName(string pName)
        {
            IEnumerable<Key> wItem = this.Where(p => p.Name == pName);
            return wItem.Count<Key>();
        }
    }

    [XmlInclude(typeof(Key)), Serializable]
    public class Key : Fwk.Bases.Entity
    {
        string _Name;
        [XmlAttribute("name")]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        bool _Encrypted = false;

        [XmlAttribute("encrypted")]
        public bool Encrypted
        {
            get { return _Encrypted; }
            set { _Encrypted = value; }
        }

        //[XmlIgnore]
        //public string _Value;
        //public XmlCDataSection Value
        //{

        //    get
        //    {
        //        XmlDataDocument doc = new XmlDataDocument();
        //        XmlCDataSection cd = doc.CreateCDataSection(this._Value);
        //        return cd;
        //    }

        //    set
        //    {
        //        this._Value = value.Value;
        //    }
        //}



        Fwk.Xml.CData _Value = new Fwk.Xml.CData();

        [XmlElement("Value", Type = typeof(Fwk.Xml.CData))]
        public Fwk.Xml.CData Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

       
        
    }



    public static class Serializer
    {
        public static T Deserialize<T>(XmlElement node) where T : new()
        {
            T customType = new T();
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            XmlDocument doc = new XmlDocument();
            //doc.AppendChild(doc.CreateXmlDeclaration("1.0", "utf-8", String.Empty));
            doc.AppendChild(doc.ImportNode(node, true));

            using (MemoryStream stream = new MemoryStream())
            using (StreamWriter writer = new StreamWriter(stream))
            using (StreamReader reader = new StreamReader(stream))
            {
                doc.Save(writer);
                stream.Position = 0;
                customType = (T)serializer.Deserialize(reader);
            }

            return customType;
        }
        public static T DeserializeFromXml<T>(string pXml)
        {
            XmlSerializer wSerializer;
            StringReader wStrSerializado = new StringReader(pXml);
            XmlTextReader wXmlReader = new XmlTextReader(wStrSerializado);
         
            object wResObj = null;

          
            wSerializer = new XmlSerializer(typeof(T));
            wResObj = wSerializer.Deserialize(wXmlReader);

            return (T)wResObj;
        }
        public static XmlElement Serialize<T>(T t) where T : new()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            XmlElement elem;
            using (MemoryStream stream = new MemoryStream())
            using (StreamWriter writer = new StreamWriter(stream))
            using (StreamReader reader = new StreamReader(stream))
            {
                serializer.Serialize(writer, t);

                XmlDocument doc = new XmlDocument();
                stream.Position = 0;
                doc.Load(reader);
                elem = doc.DocumentElement;
            }

            return elem;
        }
        public static string SerializeToXml<T>(T pObj)
        {



            XmlSerializer wSerializer;
            StringWriter wStrSerializado = new StringWriter();
            XmlTextWriter wXmlWriter = new XmlTextWriter(wStrSerializado);

            XmlSerializerNamespaces wNameSpaces = new XmlSerializerNamespaces();

            wXmlWriter.Formatting = Formatting.Indented;
            wNameSpaces.Add(String.Empty, String.Empty);
            wSerializer = new XmlSerializer(typeof(T));
            wSerializer.Serialize(wXmlWriter, pObj, wNameSpaces);


         



            return wStrSerializado.ToString().Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", String.Empty);
        }
    }

   

}
