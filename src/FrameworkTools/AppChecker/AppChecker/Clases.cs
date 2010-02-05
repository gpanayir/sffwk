﻿using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Data.SqlClient;
using AppChecker.Properties;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace AppChecker
{
    public class CheckMesage
    {

        public CheckMesage( string msg, Image img,Image img2,Image img3)
        {
            message = msg;
            if(img!=null)
                image = img;
            if (img2 != null)
            image2 = img2;
            if (img3 != null)
            image3 = img3;
        }
        public CheckMesage(string msg, Image img)
        {
            message = msg;

            if (img != null)
                image = img;
           
        }

        string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        Image image = Resources.WiteCell;

        public Image Image
        {
            get { return image; }
            set { image = value; }
        }
        Image image2 = Resources.WiteCell;

        public Image Image2
        {
            get { return image2; }
            set { image2 = value; }
        }
        Image image3 = Resources.WiteCell;

        public Image Image3
        {
            get { return image3; }
            set { image3 = value; }
        }
    }
  
    public class CnnString
    {
        private string _Name;
        private Boolean _WindowsAutentification;
        private string _DataSource = string.Empty;
        private string _InitialCatalog = string.Empty;
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
        /// Establece si la conexion admitira autorizacion integrada (true) o no (false)
        /// </summary>
       
        public System.Boolean WindowsAutentification
        {
            get { return _WindowsAutentification; }
            set { _WindowsAutentification = value; }
        }

        /// <summary>
        /// Nombre de server de datos
        /// </summary>
     
        public string DataSource
        {
            get { return _DataSource; }
            set { _DataSource = value; }
        }
        /// <summary>
        /// 
        /// </summary>
    
        public string User
        {
            get { return _User; }
            set { _User = value; }
        }
        /// <summary>
        /// Nombre de la base de datos
        /// </summary>
       
        public string InitialCatalog
        {
            get { return _InitialCatalog; }
            set { _InitialCatalog = value; }
        }

        /// <summary>
        /// Nombre de la cadena de conexion
        /// </summary>
     
        public string Name
        {
            get
            {

                if (string.IsNullOrEmpty(_Name))
                    _Name = string.Concat("Server: ", _InitialCatalog, "DB: ", _DataSource);
                return _Name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    _Name = string.Concat("Server: ", _InitialCatalog, "DB: ", _DataSource);
                else
                    _Name = value;

            }
        }

        /// <summary>
        /// Password de la cadena de conexion
        /// </summary>
      
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        /// <summary>
        /// Retorna la cadena de conexion
        /// </summary>
        /// <returns></returns>
      
        public override string ToString()
        {

            StringBuilder str = new StringBuilder();

            if (string.IsNullOrEmpty(_InitialCatalog))
            {
                //if (_WindowsAutentification)
                //{
                str.Append("Integrated Security=SSPI; Data Source=[ServerName]");
                //}
                //else
                //{
                //    str.Append("Data Source=[ServerName];User ID= [User] ;Password= [Password]");
                //    str.Replace("[User]", _User);
                //    str.Replace("[Password]", _Password);
                //}
            }
            else
            {
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCnnString"></param>
        /// <returns></returns>
        internal bool  TestConnection()
        {
            using (SqlConnection wCnn = new SqlConnection(this.ToString()))
            {
                try
                {

                    wCnn.Open();

                    wCnn.Close();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }

    internal static class Helper
    {
        /// <summary>
        /// Crea un nuevo archivo de texto
        ///   wDialog.AddExtension = true;
        ///   wDialog.RestoreDirectory = true;
        /// </summary>
        /// <param name="pFileName">Nombre sujerido para el archivo</param>
        /// <param name="pContent">Contenido del archivo</param>
        /// <param name="pFilter">Filtro ej: "(*.xml)|*.xml Puede utilizar la enumeracion ref<see cref="FileFunctions.OpenFilterEnums"/></param>
        /// <param name="pIsXml">Espesifica si el contenido es de un xml para almacenarlo con la indentacion correcta</param>
        /// <param name="pTitle">titulo personalizado del cuadro de diálogo</param>
        /// <returns></returns>
        public static String OpenFileDialog_New(String pFileName, String pContent)
        {
            using (SaveFileDialog wDialog = new SaveFileDialog())
            {
                wDialog.Title = "App check report";
                wDialog.FileName = pFileName;
                wDialog.AddExtension = true;
                wDialog.RestoreDirectory = true;
                wDialog.Filter = "Txt Files(*.txt)|*.txt|All files (*.*)|*.*";
                if (wDialog.ShowDialog() != DialogResult.OK)
                    return String.Empty;
                SaveTextFile(wDialog.FileName, pContent, false);
                return wDialog.FileName;
            }
        }
        public static string GetMachineIp()
        {
            try
            {
                IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
                System.Net.IPEndPoint Address = new IPEndPoint(ipEntry.AddressList[0], 0);
                return ipEntry.AddressList[1].ToString();
            }
            catch
            {
                return "---error geting ip --- ";
            }
        }
        /// <summary>
        /// Agrega el texto a un archivo. Si el archivo no existe, este método crea uno nuevo. 
        /// </summary>
        /// <param name="pFileName">Nombre completo del archivo</param>
        /// <param name="pContent">Contenido del archivo</param>
        /// <param name="pAppend">Determina si se van a agregar datos al archivo. 
        /// Si ya existe el archivo y append es false, el archivo se sobrescribirá. 
        /// Si ya existe el archivo y append es true, los datos se anexarán al archivo. De lo contrario, se crea un nuevo archivo. 
        /// </param>
        public static void SaveTextFile(string pFileName, string pContent, bool pAppend)
        {
            using (StreamWriter sw = new StreamWriter(pFileName, pAppend))
            {
                sw.Write(pContent);
                sw.Close();
            }
        }
    }
}
