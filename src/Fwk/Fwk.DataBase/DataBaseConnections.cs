using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Fwk.HelperFunctions;
using System.Xml.Serialization;
using Fwk.Bases;
using System.IO;

namespace Fwk.DataBase
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class DataBaseConnections
    {
        private const string DATABASE_CONFIG_FILE = "DataBaseConfig.xml";


        CnnStringList _Connections = new CnnStringList();

        /// <summary>
        /// Contiene las conecciones a bases de datos
        /// </summary>

        public CnnStringList Connections
        {
            get { return _Connections; }

        }

        /// <summary>
        /// 
        /// </summary>
        public void Save()
        {
            if (_Connections.Count >10)
            { 
              _Connections.Remove(_Connections[0]);
            }


            String wDataBaseConfigFullName = AppDomain.CurrentDomain.BaseDirectory + System.IO.Path.DirectorySeparatorChar + DATABASE_CONFIG_FILE;
            FileFunctions.SaveTextFile(wDataBaseConfigFullName, _Connections.GetXml(),false);



        }
        internal void Load()
        {
            String wDataBaseConfigFullName = AppDomain.CurrentDomain.BaseDirectory + System.IO.Path.DirectorySeparatorChar + DATABASE_CONFIG_FILE;

            try
            {
                String xml = FileFunctions.OpenTextFile(wDataBaseConfigFullName);
                _Connections = CnnStringList.GetCnnStringListFromXml(xml);
            }
            catch (FileNotFoundException)
            {
                CnnString cnn = new CnnString();
                cnn.DataSource = "DataSourceEmty";
                cnn.Name = "ConnactionName";
                cnn.Password = String.Empty;
                cnn.User = "sa";
                cnn.WindowsAutentification = true;
                cnn.InitialCatalog = String.Empty;

                _Connections.Add(cnn);
                FileFunctions.SaveTextFile(wDataBaseConfigFullName, _Connections.GetXml());
            }
           
        }
    }


    /// <summary>
    /// Clase que reprecenta una conexión
    /// Data Source=pcpde0369\SQLEXPRESS;Initial Catalog=Gastos;Integrated Security=True
    /// Data Source=pcpde0369\SQLEXPRESS;Initial Catalog=Gastos;User ID=sa
    /// </summary>
    [XmlInclude(typeof(CnnString)), Serializable]
    public class CnnString : Fwk.Bases.Entity
    {
        private string _Name;
        private Boolean _WindowsAutentification;
        private string _DataSource;
        private string _InitialCatalog;
        private string _User;
        private string _Password;
        /// <summary>
        /// 
        /// </summary>
        public CnnString()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pConnectionString"></param>
        public CnnString(String pName, String pConnectionString)
        {
            _Name = pName;
            ParceCnnString(pConnectionString);

        }
        /// <summary>
        /// 
        /// </summary>
        [Description("Establece si la conexion admitira autorizacion integrada (true) o no (false)")]
        public System.Boolean WindowsAutentification
        {
            get { return _WindowsAutentification; }
            set { _WindowsAutentification = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("Nombre de server de datos")]
        public string DataSource
        {
            get { return _DataSource; }
            set { _DataSource = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("Nombre usuario de sql server. Este atributo se setea solo en el caso de una conexión con seguridad de SQL Server")]
        public string User
        {
            get { return _User; }
            set { _User = value; }
        }
        /// <summary>
        /// Nombre de la base de datos
        /// </summary>
        [Description("Nombre de la base de datos")]
        public string InitialCatalog
        {
            get { return _InitialCatalog; }
            set { _InitialCatalog = value; }
        }

        /// <summary>
        /// Nombre de la cadena de conexion
        /// </summary>
        [Description("Nombre de la cadena de conexion")]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// Password de la cadena de conexion
        /// </summary>
        [Description("Password de la cadena de conexion")]
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        /// <summary>
        /// Retorna la cadena de conexion
        /// </summary>
        /// <returns></returns>
        [Description("Retorna la cadena de conexion")]
        public override string ToString()
        {

            StringBuilder str = new StringBuilder();

            if (_WindowsAutentification)
            {
                str.Append("Initial Catalog = [DatabaseName];Data Source=[ServerName];Integrated Security=True;");
            }
            else
            {
                str.Append("Initial Catalog = [DatabaseName];Data Source=[ServerName];User ID= [User] ;Password= [Password]");
                str.Replace("[User]", _User);
                str.Replace("[Password]", _Password);
            }
            str.Replace("[ServerName]", _DataSource);
            str.Replace("[DatabaseName]", _InitialCatalog);


            return str.ToString();
        }

        /// <summary>
        /// Setea los miembros de la clase desde una cadena de conexion
        /// </summary>
        /// <param name="pConnectionString"></param>
        private void ParceCnnString(String pConnectionString)
        {

            List<string> list = new List<string>(pConnectionString.Split(';'));
            _InitialCatalog = GetValue(list, "Initial Catalog");
            if (_InitialCatalog.Length == 0)
                _InitialCatalog = GetValue(list, "Database");

            _DataSource = GetValue(list, "Data Source");
            if (_DataSource.Length == 0)
                _DataSource = GetValue(list, "Server");

            _User = GetValue(list, "User ID");
            if (_User.Length == 0)
                _User = GetValue(list, "User");

            _Password = GetValue(list, "Password");
            if (_Password.Length == 0)
                _Password = GetValue(list, "pwd");

            String wIntegratedSecurity = GetValue(list, "Integrated Security");
            if (wIntegratedSecurity.Trim().ToLower() == "true" || wIntegratedSecurity.Trim().ToLower() == "SSPI")
                _WindowsAutentification = true;
            else
                _WindowsAutentification = false;

        }


        /// <summary>
        /// Obtiene un valor o parametro de cadena de conexion 
        /// Ej: Data Source=10.10.65.12\SQLEXPRESS;
        /// Ej: Server = =10.10.65.12\SQLEXPRESS;
        /// </summary>
        /// <param name="pCnnStringList"></param>
        /// <param name="pValueName"></param>
        /// <returns></returns>
        private string GetValue(List<string> pCnnStringList, String pValueName)
        {
            String[] val = null;
            foreach (String s in pCnnStringList)
            {
                if (s.Contains(pValueName))
                {
                    val = s.Split('=');
                    if (String.Equals(val[0].Trim().ToLower(), pValueName.Trim().ToLower()))
                        return val[1].Trim();
                    else
                        return val[0].Trim();
                }
            }
            return String.Empty;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [XmlRoot("CnnStringList"), SerializableAttribute]
    public class CnnStringList : Entities<CnnString>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pXml"></param>
        /// <returns></returns>
        public static CnnStringList GetCnnStringListFromXml(String pXml)
        {
            return CnnStringList.GetFromXml<CnnStringList>(pXml);
        }
    }
}
