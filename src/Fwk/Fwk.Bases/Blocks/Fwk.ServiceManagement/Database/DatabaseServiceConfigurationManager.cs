using System;
using System.Collections.Generic;
using System.Text;

using Fwk.Transaction;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Fwk.Bases;
using System.Data;
using Fwk.Exceptions;


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
            _DatabaseCnnString = cnnStringName;
        }
		/// <summary>
		/// Constructor por defecto
		/// </summary>
		/// <date>2008-04-10T00:00:00</date>
		/// <author>moviedo</author>
        //public DatabaseServiceConfigurationManager()
        //{

        //    _DatabaseCnnString = Fwk.Bases.ConfigurationsHelper.ServiceConfigurationSourceName;
        //}

	

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

            Database wBPConfig = DatabaseFactory.CreateDatabase(_DatabaseCnnString);
            System.Data.Common.DbCommand dbCommand = wBPConfig.GetStoredProcCommand("fwk_Service_g_Name");
            wBPConfig.AddInParameter(dbCommand, "Name", System.Data.DbType.String, pServiceName);
            try
            {
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
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException("Problemas con Fwk.ServiceManagement  al realizar operaciones con la base de datos \r\n", ex);
                ExceptionHelper.SetTechnicalException<DatabaseServiceConfigurationManager>(te);
                te.ErrorId = "7200";
                throw te;

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
            Database wBPConfig = DatabaseFactory.CreateDatabase(_DatabaseCnnString);
         
			ServiceConfigurationCollection wServiceConfigurationCollection = new ServiceConfigurationCollection();
            System.Data.Common.DbCommand dbCommand = wBPConfig.GetStoredProcCommand("fwk_Service_s_All");
            try
            {
                using (IDataReader dataReader = wBPConfig.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        ServiceConfiguration wServiceConfiguration = GetServiceConfigurationFromRow(dataReader);
                        wServiceConfigurationCollection.Add(wServiceConfiguration);
                    }
                }
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException("Problemas con Fwk.ServiceManagement  al realizar operaciones con la base de datos \r\n", ex);
                ExceptionHelper.SetTechnicalException<DatabaseServiceConfigurationManager>(te);
                te.ErrorId = "7200";
                throw te;

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
			Database wBPConfig = DatabaseFactory.CreateDatabase(_DatabaseCnnString);

            if (GetServiceConfiguration(pServiceName) == null)
            {
                Fwk.Exceptions.TechnicalException wTex = new Fwk.Exceptions.TechnicalException("El servicio " + pServiceConfiguration.Name + " no se actualizó por que no se encontro configurado en la base de datos.");
                wTex.ErrorId = "7002";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<DatabaseServiceConfigurationManager>(wTex);
                throw wTex;
            }
            try
            {
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
                    wBPConfig.AddInParameter(wCmd, "ApplicationId", System.Data.DbType.String, pServiceConfiguration.ApplicationId);
                    wBPConfig.AddInParameter(wCmd, "CreatedUserName", System.Data.DbType.String, pServiceConfiguration.CreatedUserName);
                    wBPConfig.AddInParameter(wCmd, "CreatedDateTime", System.Data.DbType.DateTime, pServiceConfiguration.CreatedDateTime);

                    int wAffected = wBPConfig.ExecuteNonQuery(wCmd);

                    if (wAffected == 0)
                    {
                        Fwk.Exceptions.TechnicalException wTex = new Fwk.Exceptions.TechnicalException("El servicio " + pServiceConfiguration.Name + " no se actualizó por que no se encontro configurado en la base de datos.");
                        wTex.ErrorId = "7002";
                        Fwk.Exceptions.ExceptionHelper.SetTechnicalException<DatabaseServiceConfigurationManager>(wTex);
                        throw wTex;
                    }

                }
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException("Problemas con Fwk.ServiceManagement  al realizar operaciones con la base de datos \r\n", ex);
                ExceptionHelper.SetTechnicalException<DatabaseServiceConfigurationManager>(te);
                te.ErrorId = "7200";
                throw te;

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
			Database wBPConfig = DatabaseFactory.CreateDatabase(_DatabaseCnnString);
            try
            {
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

                    wBPConfig.AddInParameter(wCmd, "ApplicationId", System.Data.DbType.String, pServiceConfiguration.ApplicationId);
                    wBPConfig.AddInParameter(wCmd, "CreatedUserName", System.Data.DbType.String, pServiceConfiguration.CreatedUserName);
                    wBPConfig.AddInParameter(wCmd, "CreatedDateTime", System.Data.DbType.DateTime, pServiceConfiguration.CreatedDateTime);

                    wBPConfig.ExecuteNonQuery(wCmd);
                }
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException("Problemas con Fwk.ServiceManagement  al realizar operaciones con la base de datos \r\n", ex);
                ExceptionHelper.SetTechnicalException<DatabaseServiceConfigurationManager>(te);
                te.ErrorId = "7200";
                throw te;

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
            Database wBPConfig = DatabaseFactory.CreateDatabase(_DatabaseCnnString);
            try
            {
                using (System.Data.Common.DbCommand wCmd = wBPConfig.GetStoredProcCommand("fwk_Service_d"))
                {
                    wBPConfig.AddInParameter(wCmd, "Name", System.Data.DbType.String, pServiceName);

                    int wAffected = wBPConfig.ExecuteNonQuery(wCmd);

                    if (wAffected == 0)
                    {
                      
                        TechnicalException te = new TechnicalException("El servicio " + pServiceName + " no se eliminó por no encontrarse configurado.");
                        ExceptionHelper.SetTechnicalException<DatabaseServiceConfigurationManager>(te);
                        te.ErrorId = "7002";
                        throw te;
                    }
                }
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException("Problemas con Fwk.ServiceManagement  al realizar operaciones con la base de datos \r\n", ex);
                ExceptionHelper.SetTechnicalException<DatabaseServiceConfigurationManager>(te);
                te.ErrorId = "7200";
                throw te;

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

            wServiceConfiguration.CreatedUserName = Convert.ToString(pServiceRow["CreatedUserName"]);
            wServiceConfiguration.CreatedDateTime = Convert.ToDateTime(pServiceRow["CreatedDateTime"]);
            wServiceConfiguration.ApplicationId = Convert.ToString(pServiceRow["ApplicationId"]);
            
			return wServiceConfiguration;
		}
		#endregion






       
       
    }
}
