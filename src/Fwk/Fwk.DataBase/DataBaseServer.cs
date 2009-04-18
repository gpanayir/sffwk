using System;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient; 
using System.Data; 
using System.Xml;
using System.Text ;
using Fwk.HelperFunctions;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;

namespace Fwk.DataBase 
{
	/// <summary>
	/// Descripción breve de SetDataBase.
	/// </summary>
	internal class DataBaseServer
	{
	

		#region Miembros Privados


        private const string symmProvider = "CnnCryptProvider";
		private  SqlConnection _Cnn = new SqlConnection ();
    

        private CnnString _CnnString = null;
      

        public CnnStringList CnnStringList
        {
            get { return _DataBaseConnections.Connections; }
           
        }


        private DataBaseConnections _DataBaseConnections = new DataBaseConnections();
		

        private DataTable _SQLServerInfo = null;

        private int _ServerVersion = 0;

		
		#endregion

        /// <summary>
        /// Constructor que llama InitializeConfig(), el cual Permite leer nuevamente el archivo de configuracion 
        /// donde esta el acceso a la BD para recargar la coneccion.-
        /// </summary>
		private  DataBaseServer()
		{
           
			InitializeConfig();
			
		}
        /// <summary>
        /// Constructor que llama InitializeConfig(), el cual Permite leer nuevamente el archivo de configuracion 
        /// donde esta el acceso a la BD para recargar la coneccion.-
        /// </summary>
        public DataBaseServer(bool pInitializeConfig)
        {
            if (pInitializeConfig)
                InitializeConfig();

        }
		#region [Propiedades]

        /////// <summary>
        /////// Reprecenta si la coneccion usa autentificacion de windows o no.-
        /////// </summary>
        ////public  bool WindowsAutChecked
        ////{
        ////    get
        ////    {
        ////        return _WindowsAutChecked ;
        ////    }
        ////}
        ///// <summary>
        ///// Password para la coneccion .-
        ///// </summary>
        ////public  string Password
        ////{
        ////    set
        ////    {
        ////        try
        ////        {
        ////            _Password = value.Trim();//Cryptographer.EncryptSymmetric(symmProvider, value.Trim());
        ////        }

        ////        catch (Exception ex)
        ////        {
        ////            throw new DataBaseExeption(ex, DataBaseExeption.ExeptionsEnums.CryptographicFile);
        ////        }
        ////    }
        ////    get 
        ////    {
        ////        return  _Password.Trim();
               
        ////    }
        ////}

        /////// <summary>
        /////// Nombre de la instancio de SQL.-
        /////// </summary>
        ////public  string SQLServer
        ////{
        ////    get
        ////    {
        ////        return  _SQLServer;
        ////    }
        ////    set
        ////    {
        ////        _SQLServer = value.Trim();
        ////    }
        ////}

        ///// <summary>
        /////// Nombre de usuario.-
        /////// </summary>
        ////public string UserName
        ////{
        ////    get
        ////    {
        ////        return  _UserName; //_Node.SelectSingleNode("User").InnerXml;

        ////    }
        ////    set
        ////    {
        ////        _UserName = value.Trim();
        ////    }
        ////}

        public int ServerVersion
        {
            get
            {

                if (_SQLServerInfo == null)
                    SetServerInfo();

                if (_ServerVersion == 0)
                {
                    System.Data.DataRow[] oRows = _SQLServerInfo.Select("Name = 'FileVersion'");
                    _ServerVersion = Convert.ToInt32(oRows[0]["Character_Value"].ToString().Trim().Substring(0, 4));
                }

                return _ServerVersion;


            }

        }

        ///// <summary>
        ///// Nombre de Base de datos.-
        ///// </summary>
        //public  string DataBaseName
        //{
        //    get
        //    {
        //        return  _DataBase;
        //    }
        //    set
        //    {
        //        _DataBase = value.Trim();
        //    }
        //}

        /// <summary>
        /// Cadena de coneccion actual
        /// </summary>
        public CnnString CnnString
        {
            get { return _CnnString; }
        }
		
        /// <summary>
        /// SqlConnection
        /// </summary>
		internal  SqlConnection Cnn
		{
			get { return _Cnn;}
		}

		#endregion

		#region TestConnection
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		public System.Boolean TestConnection()
		{
			try
			{
				ConnectDatabase();
				
				return true;
			}
            catch (Exception ex)
            {
                throw new DataBaseExeption(ex, _CnnString);
            }
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCnnString"></param>
        /// <returns></returns>
        public static bool TestConnection(CnnString pCnnString)
        {
            using (SqlConnection wCnn = new SqlConnection(pCnnString.ToString()))
            {
                try
                {

                    wCnn.Open();

                    wCnn.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new DataBaseExeption(ex, pCnnString);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pServerName"></param>
        /// <param name="pUserName"></param>
        /// <param name="pPassword"></param>
        /// <param name="pWindowsAutChecked"></param>
        /// <returns></returns>
		public static bool TestConnection (string pServerName, string pUserName, string pPassword, bool pWindowsAutChecked)
		{
		    CnnString cnn = GetCnnStringToMaster(pServerName, pUserName, pPassword, pWindowsAutChecked);

            return TestConnection(cnn);
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pServerName"></param>
        /// <param name="pUserName"></param>
        /// <param name="pPassword"></param>
        /// <param name="pWindowsAutChecked"></param>
        /// <returns></returns>
        private static CnnString GetCnnStringToMaster(string pServerName, string pUserName, string pPassword, bool pWindowsAutChecked)
        {
            CnnString _CnnStringToMapper = new CnnString();
            _CnnStringToMapper.DataSource = pServerName;
            _CnnStringToMapper.InitialCatalog = "master";
            _CnnStringToMapper.User = pUserName;
            _CnnStringToMapper.Password = pPassword;
            _CnnStringToMapper.WindowsAutentification = pWindowsAutChecked;
            return _CnnStringToMapper;
        }

        private static CnnString GetCnnStringToMaster(CnnString pCnnString)
        {
            CnnString _CnnStringToTest = new CnnString();

            _CnnStringToTest.DataSource = pCnnString.DataSource;
            _CnnStringToTest.InitialCatalog = "master";
            _CnnStringToTest.User = pCnnString.User;
            _CnnStringToTest.Password = pCnnString.Password;
            _CnnStringToTest.WindowsAutentification = pCnnString.WindowsAutentification;
            return _CnnStringToTest;
        }


	    /// <summary>
		/// Permite leer nuevamente el archivo de configuracion donde esta el acceso a la BD para recargar la coneccion.-
		/// </summary>
		public  void InitializeConfig()
		{

            try
            {
                _DataBaseConnections.Load();
                _CnnString = _DataBaseConnections.Connections[0];
               
            }

            catch (FileNotFoundException)
            {
                string msg = "No se encuentra el archivo de configuracion de base de datos:";
                throw new System.Exception(msg);
            }
            catch (System.Security.Cryptography.CryptographicException e)
            {

                _CnnString.Password = String.Empty;
                throw new DataBaseExeption(e, _CnnString);
            }
            catch (Exception)
            {
                string msg = "Verifique que el archivo de configuracion tiene seteado el archivo de conecciones a la base de datos.-";
                throw new System.Exception(msg);
            }
        
		}
			
		
		#endregion
		
		#region --[Save Settings]--

		

        /// <summary>
        /// Almacena la configuracion cun los datos que se pasan como parametros.-
        /// </summary>
        /// <param name="pCnnString">Coneccion</param>
        ///   <param name="pAppend">Agrega nuevo elemento</param>
        public void SaveSetting(CnnString pCnnString,bool pAppend)
		{
            _CnnString = pCnnString;
            if (pAppend)
                _DataBaseConnections.Connections.Add(pCnnString);
            else
            {
                foreach (CnnString cnn in _DataBaseConnections.Connections)
                {
                    if (cnn.Name == pCnnString.Name)
                    {
                        cnn.Password = pCnnString.Password;
                        cnn.DataSource = pCnnString.DataSource;
                        cnn.User = pCnnString.User;
                        cnn.WindowsAutentification = pCnnString.WindowsAutentification;
                        cnn.InitialCatalog = pCnnString.InitialCatalog; 
                    }
                }
            }
            _DataBaseConnections.Save();
			
		}

		/// <summary>
		/// Almacena la configuracion cun los datos preceteados en el objeto DataBaseServer;
		/// </summary>
		/// <param name="pWindowsAutChecked">Determina si la configuracion debe alamacenartce en un App.config o en un archivo xml externo</param>
		public  void SaveSetting(bool pWindowsAutChecked)
		{
            _CnnString.WindowsAutentification = pWindowsAutChecked;
            _DataBaseConnections.Save();
            
			
		}

        /// <summary>
        /// Almacena la configuracion cun los datos que se pasan como parametros.-
        /// </summary>
        /// <param name="pSQLServer">Nombre de la instancio de SQL.-</param>
        /// <param name="pDataBaseName">Nombre de Base de datos.-</param>
        /// <param name="pUserName">Nombre de usuario.-</param>
        /// <param name="pPassword">Password para la coneccion .-</param>
        /// <param name="pWindowsAutChecked">Determina si la configuracion debe alamacenartce en un App.config o en un archivo xml externo</param>
        private void SaveSettingExternalXML(string pSQLServer, string pDataBaseName, string pUserName, string pPassword, bool pWindowsAutChecked)
        {

            //StringBuilder str = new StringBuilder();
            //if (pWindowsAutChecked)//Autentificacion de Windows
            //{
            //    str.Append("Persist Security Info=False; Integrated Security=SSPI;Data Source= [SERVER];Initial Catalog=[DATABASE]");
            //    pPassword = String.Empty;
            //    pUserName = String.Empty;
            //}
            //else //Autentificacion de SQL Server
            //{
            //    str.Append("Data Source=[SERVER];Initial Catalog=[DATABASE];User ID=[USER];Password=[PASSWORD]");

            //    str.Replace("[USER]", pUserName);
            //    str.Replace("[PASSWORD]", pPassword);

            //}

            //str.Replace("[SERVER]", pSQLServer);
            //str.Replace("[DATABASE]", pDataBaseName);

            //String wDataBaseConfig = ConfigurationManager.AppSettings["DataBaseConfig"];
            //if (string.IsNullOrEmpty(wDataBaseConfig))
            //{
            //    string msg = "Verifique que el archivo de configuracion tiene seteado el archivo de conecciones a la base de datos.-";
            //    throw new System.Exception(msg);
            //}


            //String wDataBaseConfigFullName = AppDomain.CurrentDomain.BaseDirectory + System.IO.Path.DirectorySeparatorChar + wDataBaseConfig;
            //if (!File.Exists(wDataBaseConfigFullName))
            //{
            //    return;
            //}
            //doc.Load(wDataBaseConfigFullName);

            //_Node = doc.DocumentElement;

            //XmlNode oNewChild = _Node.SelectSingleNode("ConnectionString");
            //oNewChild.InnerXml = str.ToString();

            //oNewChild = _Node.SelectSingleNode("DataBase");
            //oNewChild.InnerXml = pDataBaseName;

            //oNewChild = _Node.SelectSingleNode("SQLServer");
            //oNewChild.InnerXml = pSQLServer;

            //oNewChild = _Node.SelectSingleNode("User");
            //oNewChild.InnerXml = pUserName;

            //oNewChild = _Node.SelectSingleNode("Password");
            //try
            //{
            //    oNewChild.InnerXml = pPassword.Trim();//Cryptographer.EncryptSymmetric(symmProvider, pPassword.Trim());
            //}
            //catch (Exception ex)
            //{
            //    throw new DataBaseExeption(ex, DataBaseExeption.ExeptionsEnums.CryptographicFile);
            //}

            //oNewChild = _Node.SelectSingleNode("WindowsAutChecked");
            //oNewChild.InnerXml = pWindowsAutChecked.ToString();

            //doc.Save(AppDomain.CurrentDomain.BaseDirectory + System.IO.Path.DirectorySeparatorChar + System.Configuration.ConfigurationManager.AppSettings["DataBaseConfig"]);
        }

		
		#endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		public  DataTable GetDataBases()
		{
            CnnString cnn = GetCnnStringToMaster(_CnnString);
            using (SqlConnection wCnn = new SqlConnection(cnn.ToString()))
            using (SqlCommand wCmd = new SqlCommand())
            {
                try
                {

                    wCnn.Open();
                    wCmd.Connection = wCnn;
                    wCmd.CommandType = CommandType.StoredProcedure;
                    wCmd.CommandText = "sp_databases";

                    DataSet wDs = new DataSet();
                    SqlDataAdapter wDa = new SqlDataAdapter(wCmd);

                    wDa.Fill(wDs);
                    wCnn.Close();
                    return wDs.Tables[0];
                }
                catch (SqlException ex)
                {
                    throw ex;

                }
            }
		}



        public void ConnectDatabase()
        {
            InitializeConfig();
            using (SqlConnection wCnn = new SqlConnection(_CnnString.ToString()))
            {
                try
                {
                    wCnn.Open();
                    
                    wCnn.Close();
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
        }



        public void SetServerInfo()
        {

            using (SqlConnection wCnn = new SqlConnection(_CnnString.ToString()))
            using (SqlCommand wCmd = new SqlCommand())
            {
                try
                {
                    wCnn.Open();
                    wCmd.Connection = wCnn;
                    DataSet wDs = new DataSet();

                    wCmd.CommandType = CommandType.Text;
                    wCmd.CommandText = "exec master..xp_msver ";
                    SqlDataAdapter wDa = new SqlDataAdapter(wCmd);

                    wDa.Fill(wDs);
                    wCnn.Close();

                    _SQLServerInfo = wDs.Tables[0];

                    //--------------[Columns]--------
                    //ProductName
                    //ProductVersion
                    //Language
                    //Platform
                    //Comments
                    //CompanyName
                    //FileDescription
                    //FileVersion
                    //InternalName
                    //LegalCopyright
                    //LegalTrademarks
                    //OriginalFilename
                    //PrivateBuild
                    //SpecialBuild
                    //WindowsVersion
                    //ProcessorCount
                    //ProcessorActiveMask
                    //ProcessorType
                    //PhysicalMemory
                    //Product ID
                }
                catch (SqlException ex)
                {
                    throw ex;

                }
            }
        }

       
	}
}

