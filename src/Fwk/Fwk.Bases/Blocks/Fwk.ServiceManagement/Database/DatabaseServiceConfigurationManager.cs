using System;
using System.Collections.Generic;
using System.Text;

using Fwk.Transaction;
using Datablock = Microsoft.Practices.EnterpriseLibrary.Data;
using Fwk.Bases;
using System.Data;


namespace Fwk.ServiceManagement
{
	/// <summary>
    /// Manejador de configuración de servicios que trabaja con una base de datos relacional como repositorio de configuración.
	/// </summary>
	/// <remarks>
	/// La base de datos que sirve de repositorio puede estar creada en cualquier producto que sea accesible por los componentes de acceso a datos de Microsoft Enterprise Library.
	/// </remarks>
	/// <date>2008-04-07T00:00:00</date>
	/// <author>moviedo</author>
	public sealed class DatabaseServiceConfigurationManager: IServiceConfigurationManager
	{
        string _DatabaseCnnString = String.Empty;

        /// <summary>
        /// Constructor manual sin archivo de configuracion.- No utiliza ServiceConfigurationSourceName
        /// </summary>
        /// <param name="cnnStringName">Nombre de la cadena de conexion</param>
        /// <date>2008-04-10T00:00:00</date>
        /// <author>moviedo</author>
        public DatabaseServiceConfigurationManager(string cnnStringName)
        {

            _DatabaseCnnString = System.Configuration.ConfigurationManager.ConnectionStrings[cnnStringName].ConnectionString;
        }
		/// <summary>
		/// Constructor por defecto
		/// </summary>
		/// <date>2008-04-10T00:00:00</date>
		/// <author>moviedo</author>
		public DatabaseServiceConfigurationManager()
		{

            _DatabaseCnnString = System.Configuration.ConfigurationManager.ConnectionStrings[Fwk.Bases.ConfigurationsHelper.ServiceConfigurationSourceName].ConnectionString;
		}

		#region < Fields >
		
		#endregion

		#region < IServiceConfigurationManager Members >

		/// <summary>
        /// Devuelve la configuración de un servicio buscóndolo en la base de datos de configuracón.
		/// </summary>
		/// <param name="pServiceName">Nombre del servicio</param>
        /// <returns>Configuración del servicio</returns>
		/// <date>2008-04-07T00:00:00</date>
		/// <author>moviedo</author>
        public ServiceConfiguration GetServiceConfiguration(string pServiceName)
		{
            ServiceConfiguration wServiceConfiguration = null; ;

            Datablock.Database wBPConfig = Datablock.DatabaseFactory.CreateDatabase(_DatabaseCnnString);
            System.Data.Common.DbCommand dbCommand = wBPConfig.GetStoredProcCommand("fwk_Service_g_Name");
            wBPConfig.AddInParameter(dbCommand, "Name", System.Data.DbType.String, pServiceName);
            
            using (IDataReader dataReader = wBPConfig.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    wServiceConfiguration = GetServiceConfigurationFromRow(dataReader);
                }


                if (wServiceConfiguration == null)
                {
                    throw new Fwk.Exceptions.TechnicalException("El servicio " + pServiceName + " no se encuentra configurado.");
                }
                
            }

            return wServiceConfiguration;
		}

		/// <summary>
        /// Recupera la configuración de todos los servicios de negocio.
		/// </summary>
		/// <returns>Lista de configuraciones de servicios de negocio.</returns>
		/// <date>2008-04-13T00:00:00</date>
		/// <author>moviedo</author>
        public ServiceConfigurationCollection GetAllServices()
		{

            Datablock.Database wBPConfig = Datablock.DatabaseFactory.CreateDatabase(_DatabaseCnnString);
         
			ServiceConfigurationCollection wServiceConfigurationCollection = new ServiceConfigurationCollection();
            System.Data.Common.DbCommand dbCommand = wBPConfig.GetStoredProcCommand("fwk_Service_s_All");


            using (IDataReader dataReader = wBPConfig.ExecuteReader(dbCommand))
			{

                while (dataReader.Read())
                {
                    ServiceConfiguration wServiceConfiguration = GetServiceConfigurationFromRow(dataReader);
                    wServiceConfigurationCollection.Add(wServiceConfiguration);

                }
			}

			return wServiceConfigurationCollection;
		}

       
		/// <summary>
        /// Almacena la configuración de un servicio de negocio.
		/// </summary>
        /// <param name="pServiceConfiguration">Configuración del servicio de negocio.</param>
        /// <param name="pServiceName">Nombre del servicio a actualizar.</param>
		/// <date>2008-04-10T00:00:00</date>
		/// <author>moviedo</author>
        public void SetServiceConfiguration(String pServiceName,ServiceConfiguration pServiceConfiguration)
		{
			Datablock.Database wBPConfig = Datablock.DatabaseFactory.CreateDatabase(_DatabaseCnnString);

            if (GetServiceConfiguration(pServiceName) == null)
            {
                Fwk.Exceptions.TechnicalException wTex =
                    new Fwk.Exceptions.TechnicalException("El servicio " + pServiceConfiguration.Name + " no se encuentra configurado en la base de datos.");
                wTex.ErrorId = "7002";
                wTex.Namespace = "Fwk.ServiceManagement";
                wTex.Class = "DatabaseServiceConfigurationManager";
                wTex.Assembly = "Fwk.ServiceManagement";
                throw wTex;
            }

            using (System.Data.Common.DbCommand wCmd = wBPConfig.GetStoredProcCommand("fwk_Service_u"))
			{

                wBPConfig.AddInParameter(wCmd, "UpdateServiceName", System.Data.DbType.String, pServiceName);
				wBPConfig.AddInParameter(wCmd, "Name", System.Data.DbType.String, pServiceConfiguration.Name);
				wBPConfig.AddInParameter(wCmd, "Description", System.Data.DbType.String, pServiceConfiguration.Description);
				wBPConfig.AddInParameter(wCmd, "Handler", System.Data.DbType.String, pServiceConfiguration.Handler);
				wBPConfig.AddInParameter(wCmd, "Request", System.Data.DbType.String, pServiceConfiguration.Request);
				wBPConfig.AddInParameter(wCmd, "Response", System.Data.DbType.String, pServiceConfiguration.Response);
				wBPConfig.AddInParameter(wCmd, "Available", System.Data.DbType.String, pServiceConfiguration.Available);
				wBPConfig.AddInParameter(wCmd, "Audit", System.Data.DbType.String, pServiceConfiguration.Audit);
                wBPConfig.AddInParameter(wCmd, "TransactionalBehaviour", System.Data.DbType.String, Enum.GetName(typeof(TransactionalBehaviour), pServiceConfiguration.TransactionalBehaviour));
                wBPConfig.AddInParameter(wCmd, "IsolationLevel", System.Data.DbType.String, Enum.GetName(typeof(Fwk.Transaction.IsolationLevel), pServiceConfiguration.IsolationLevel));
				wBPConfig.AddInParameter(wCmd, "Timeout", System.Data.DbType.Int32, pServiceConfiguration.Timeout);
                wBPConfig.AddInParameter(wCmd, "Cacheable", System.Data.DbType.Int32, pServiceConfiguration.Cacheable);
                wBPConfig.AddInParameter(wCmd, "FolderRepositoryKey", System.Data.DbType.String, pServiceConfiguration.FolderRepositoryKey);
                
				int wAffected = wBPConfig.ExecuteNonQuery(wCmd);

				if (wAffected == 0)
				{
					throw new Fwk.Exceptions.TechnicalException("El servicio " + pServiceConfiguration.Name + " no se actualizó por no encontrarse configurado.");
				}

			}
			
		}

		/// <summary>
        /// Almacena la configuración de un nuevo servicio de negocio.
		/// </summary>
        /// <param name="pServiceConfiguration">Configuración del servicio de negocio.</param>
		/// <date>2008-04-13T00:00:00</date>
		/// <author>moviedo</author>
		public void AddServiceConfiguration(ServiceConfiguration pServiceConfiguration)
		{
			Datablock.Database wBPConfig = Datablock.DatabaseFactory.CreateDatabase(_DatabaseCnnString);

            using (System.Data.Common.DbCommand wCmd = wBPConfig.GetStoredProcCommand("fwk_Service_i"))
			{
				wBPConfig.AddInParameter(wCmd, "Name", System.Data.DbType.String, pServiceConfiguration.Name);
				wBPConfig.AddInParameter(wCmd, "Description", System.Data.DbType.String, pServiceConfiguration.Description);
				wBPConfig.AddInParameter(wCmd, "Handler", System.Data.DbType.String, pServiceConfiguration.Handler);
				wBPConfig.AddInParameter(wCmd, "Request", System.Data.DbType.String, pServiceConfiguration.Request);
				wBPConfig.AddInParameter(wCmd, "Response", System.Data.DbType.String, pServiceConfiguration.Response);
				wBPConfig.AddInParameter(wCmd, "Available", System.Data.DbType.String, pServiceConfiguration.Available);
				wBPConfig.AddInParameter(wCmd, "Audit", System.Data.DbType.String, pServiceConfiguration.Audit);
                wBPConfig.AddInParameter(wCmd, "TransactionalBehaviour", System.Data.DbType.String, Enum.GetName(typeof(TransactionalBehaviour), pServiceConfiguration.TransactionalBehaviour));
                wBPConfig.AddInParameter(wCmd, "IsolationLevel", System.Data.DbType.String, Enum.GetName(typeof(Fwk.Transaction.IsolationLevel), pServiceConfiguration.IsolationLevel));
				wBPConfig.AddInParameter(wCmd, "Timeout", System.Data.DbType.Int32, pServiceConfiguration.Timeout);
                wBPConfig.AddInParameter(wCmd, "Cacheable", System.Data.DbType.Int32, pServiceConfiguration.Cacheable);
                wBPConfig.AddInParameter(wCmd, "FolderRepositoryKey", System.Data.DbType.String, pServiceConfiguration.FolderRepositoryKey);
                
				wBPConfig.ExecuteNonQuery(wCmd);
			}
		}

		/// <summary>
        /// Elimina la configuración de un servicio de negocio.
		/// </summary>
		/// <param name="pServiceName">Nombre del servicio.</param>
		/// <date>2008-04-13T00:00:00</date>
		/// <author>moviedo</author>
		public void DeleteServiceConfiguration(string pServiceName)
		{
			Datablock.Database wBPConfig = Datablock.DatabaseFactory.CreateDatabase(_DatabaseCnnString);

            using (System.Data.Common.DbCommand wCmd = wBPConfig.GetStoredProcCommand("fwk_Service_d"))
			{
				wBPConfig.AddInParameter(wCmd, "Name", System.Data.DbType.String, pServiceName);

				int wAffected = wBPConfig.ExecuteNonQuery(wCmd);

				if (wAffected == 0)
				{
					throw new Fwk.Exceptions.TechnicalException("El servicio " + pServiceName + " no se eliminó por no encontrarse configurado.");
				}
			}
		}

		#endregion

		#region < Private methods >

		/// <summary>
        /// Mapea los campos de una datarow a propiedades de una configuración de servicio.
		/// </summary>
		/// <returns>Configuracion de servicio de negocio.</returns>
		/// <date>2008-04-13T00:00:00</date>
		/// <author>moviedo</author>
        private ServiceConfiguration GetServiceConfigurationFromRow(IDataReader pServiceRow)
		{
			ServiceConfiguration wServiceConfiguration = new ServiceConfiguration();

			wServiceConfiguration.Name = Convert.ToString(pServiceRow["name"]);
			wServiceConfiguration.Description = Convert.ToString(pServiceRow["Description"]);
			wServiceConfiguration.Handler = Convert.ToString(pServiceRow["Handler"]);
			wServiceConfiguration.Request = Convert.ToString(pServiceRow["Request"]);
			wServiceConfiguration.Response = Convert.ToString(pServiceRow["Response"]);
			wServiceConfiguration.Available = Convert.ToBoolean(pServiceRow["Available"]);
			wServiceConfiguration.Audit = Convert.ToBoolean(pServiceRow["Audit"]);
            wServiceConfiguration.TransactionalBehaviour = (TransactionalBehaviour)Enum.Parse(typeof(TransactionalBehaviour), pServiceRow["TransactionalBehaviour"].ToString());
            wServiceConfiguration.IsolationLevel = (Fwk.Transaction.IsolationLevel)Enum.Parse(typeof(Fwk.Transaction.IsolationLevel), pServiceRow["IsolationLevel"].ToString());
            

			wServiceConfiguration.Timeout = Convert.ToInt32(pServiceRow["Timeout"]);
            wServiceConfiguration.Cacheable = Convert.ToBoolean(pServiceRow["Cacheable"]);
            wServiceConfiguration.FolderRepositoryKey = Convert.ToString(pServiceRow["FolderRepositoryKey"]);
            
			return wServiceConfiguration;
		}
		#endregion






       

        public string Tag
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                //throw new Exception("The method or operation is not implemented.");
            }
        }

       
    }
}
