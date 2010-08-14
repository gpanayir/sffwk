using System;
using System.Collections.Generic;
using System.Text;
using Fwk.Bases;
using System.Xml.Serialization;
namespace RestoreDatabase
{
    [XmlInclude(typeof(ConfigSetting)), Serializable]
    public class ConfigSetting : Entity
    {

        string name;

        public string Name
        {
            get
            {
                string[] sss = new String[] { _Server, " ", _DataBaseName, " ", _BackUpSource };
                return string.Concat(sss);
            }
            set { name = value; }
        }

        string _BackUpSource;

        public string BackUpSource
        {
            get { return _BackUpSource; }
            set { _BackUpSource = value; }
        }
        string _ConnectionStrings;

        public string ConnectionStrings
        {
            get { return _ConnectionStrings; }
            set { _ConnectionStrings = value; }
        }
        string _DataBaseName;

        public string DataBaseName
        {
            get { return _DataBaseName; }
            set { _DataBaseName = value; }
        }
        string _User;

        public string User
        {
            get { return _User; }
            set { _User = value; }
        }
        string _Server;

        public string Server
        {
            get { return _Server; }
            set { _Server = value; }
        }
        string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        bool _WindowsAutentification;

        public bool WindowsAutentification
        {
            get { return _WindowsAutentification; }
            set { _WindowsAutentification = value; }
        }




    }
    [XmlRoot("ConfigSettings"), SerializableAttribute]
    public class ConfigSettings : Entities<ConfigSetting>
    { }
}
