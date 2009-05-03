using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Collections.ObjectModel;
using Fwk.Bases;
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

            if (_DictionaryFiles.ContainsKey(pConfigurationFile.Groups.FileName))
            {
                throw new Exception("El archivo ya se encuentra configurado");
            }

            _DictionaryFiles.Add(pConfigurationFile.Groups.FileName, pConfigurationFile);

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

    }

    /// <summary>
    /// Reprecenta un archivo de confuguracion y sus estados en memoria.-
    /// </summary>
    /// <Author>Marcelo Oviedo</Author>
    [Serializable]
    public class ConfigurationFile
    {
        //private ConfigurationResponse.Result _ConfigResult;
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
        /// Contenido del archivo desencriptado.
        /// </summary>
        public string DecryptedFileContent
        {
            get
            {
                string wStr;

                if (_Groups.Encrypted)
                    wStr = Fwk.HelperFunctions.CryptographyFunctions.Decrypt(_Groups.FileContent);
                else
                    wStr = _Groups.FileContent;

                return wStr;
            }
        }

        /// <summary>
        /// Chequea si el archivo expiró.
        /// </summary>
        /// <returns>bool</returns>
        public bool CheckExpiration()
        {
            bool wResult = (_Groups.TTL != 0 && this._TimeStamp.AddSeconds(_Groups.TTL) < DateTime.Now);
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
    //public class Groups : KeyedCollection<string, Group> 
    public class Groups : Entities<Group>
    {
        #region properties
        string _FileContent;

        public string FileContent
        {
            get { return _FileContent; }
            set { _FileContent = value; }
        }
        bool _Encrypted;

        public bool Encrypted
        {
            get { return _Encrypted; }
            set { _Encrypted = value; }
        }
        string _FileName;

        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }

        int _TTL;

        public int TTL
        {
            get { return _TTL; }
            set { _TTL = value; }
        }

        bool _ForceUpdate;

        public bool ForceUpdate
        {
            get { return _ForceUpdate; }
            set { _ForceUpdate = value; }
        }
        bool _BaseConfigFile;

        public bool BaseConfigFile
        {
            get { return _BaseConfigFile; }
            set { _BaseConfigFile = value; }
        }
        bool _Cacheable;

        public bool Cacheable
        {
            get { return _Cacheable; }
            set { _Cacheable = value; }
        }

        string _CurrentVersion;
        public string CurrentVersion
        {
            get { return _CurrentVersion; }
            set { _CurrentVersion = value; }
        }
        #endregion

        public Group GetFirstByName(string pName)
        {
            return this.First(p => p.Name == pName);
        }
        //public string GetXml()
        //{
           
        //   string str =  HelperFunctions.SerializationFunctions.SerializeToXml(this);
        //    return str;
        //}

        //public static Groups GetFromXml(string xml)
        //{
        //    Groups wGroups = (Groups)HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(Groups), xml);

        //    return wGroups;
        //}

        //protected override string GetKeyForItem(Group pItem)
        //{
        //       return pItem.Name;
        //}
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

    [XmlRoot("Keys"), SerializableAttribute]
    public class Keys : Fwk.Bases.Entities<Key>
    {
        public Key GetFirstByName(string pName)
        {
            return this.First(p => p.Name == pName);
        }
    }

    [XmlInclude(typeof(Key)), Serializable]
    public class Key:Fwk .Bases.Entity 
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




        Fwk.Xml.CData _Value = new Fwk.Xml.CData ();

        [XmlElement("Value", Type = typeof(Fwk.Xml.CData))]
        public Fwk.Xml.CData Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
    }
}
