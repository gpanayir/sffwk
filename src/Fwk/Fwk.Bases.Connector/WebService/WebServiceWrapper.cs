using System;
using Fwk.Bases;
using Fwk.Exceptions;

namespace Fwk.Bases.Connector
{

	/// <summary>
	/// Wrapper para interfaz de servicio implementada a través de un web service.
	/// </summary>
	/// <date>2007-06-23T00:00:00</date>
	/// <author>moviedo</author>
	public class WebServiceWrapper : IServiceWrapper
	{
	    private string msz_URL = string.Empty;

		#region IServiceInterfaceWrapper Members 

		/// <summary>
		/// Ejecuta un servicio de negocio.
		/// </summary>
		/// <param name="pServiceName">Nombre del servicio.</param>
		/// <param name="pData">XML con datos de entrada para la  ejecución del servicio.</param>
		/// <returns>XML con datos de salida del servicio.</returns>
		/// <date>2007-08-23T00:00:00</date>
		/// <author>moviedo</author>
		public string ExecuteService (string pServiceName, string pData)
		{
			string wResult = null;

            using (SingleService.SingleService wService = new SingleService.SingleService())
			{
			    
                wService.Url = Fwk.Bases.ConfigurationsHelper.WebServiceDispatcherUrlSetting;
                msz_URL = wService.Url;
				wResult = wService.ExecuteService(pServiceName, pData);
              
			}

			return wResult;
		}



        /// <summary>
        /// Ejecuta un servicio de negocio. (Metodo vigente solo por compatibilidad con versiones anteriores donde se pasaba el 
        /// nombre del servicio como parametro.-
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <param name="pReq">Clase que implementa IServiceContract con datos de entrada para la  ejecución del servicio.</param>
        /// <returns>Clase que implementa IServiceContract con datos de respuesta del servicio.</returns>
        /// <date>2007-06-23T00:00:00</date>
        /// <author>moviedo</author>
        public TResponse ExecuteService<TRequest, TResponse>(string pServiceName, TRequest pReq)
            where TRequest : IServiceContract
            where TResponse : IServiceContract, new()
        {
            pReq.InitializeHostContextInformation();

            TResponse wResponse = new TResponse();

            try
            {
                pReq.ServiceName = pServiceName;
                string wResult = ExecuteService(pServiceName ,pReq.GetXml());
                wResponse.SetXml(wResult);
            }
            catch(Exception ex)
            {
                wResponse.Error = ProcessConnectionsException.Process(ex, msz_URL);
            }

            wResponse.InitializeHostContextInformation();

            
            return wResponse;
            

        }

       

        /// <summary>
        /// Ejecuta un servicio de negocio.
        /// </summary>
        /// <param name="pReq">Clase que implementa IServiceContract con datos de entrada para la  ejecución del servicio.</param>
        /// <returns>Clase que implementa IServiceContract con datos de respuesta del servicio.</returns>
        /// <date>2007-06-23T00:00:00</date>
        /// <author>moviedo</author>
        public TResponse ExecuteService<TRequest, TResponse>(TRequest pReq)
            where TRequest : IServiceContract
            where TResponse : IServiceContract, new()
        {
            pReq.InitializeHostContextInformation();

            TResponse wResponse = new TResponse();

            try
            {
                string wResult = ExecuteService(pReq.ServiceName, pReq.GetXml());
                wResponse.SetXml(wResult);
            }
            catch (Exception ex)
            {
                wResponse.Error = ProcessConnectionsException.Process(ex, msz_URL);
            }

            wResponse.InitializeHostContextInformation();


            return wResponse;


        }
		#endregion





        #region [ServiceConfiguration]


        /// <summary>
        /// Recupera la configuración de todos los servicios de negocio.
        /// </summary>
        /// <returns>Lista de configuraciones de servicios de negocio.</returns>
        /// <date>2008-04-10T00:00:00</date>
        /// <author>moviedo</author>
        public ServiceConfigurationCollection GetAllServices()
        {
            string xmlServices = null;

            using (SingleService.SingleService wService = new SingleService.SingleService())
            {
                wService.Url = Fwk.Bases.ConfigurationsHelper.WebServiceDispatcherUrlSetting;
                msz_URL = wService.Url;
                xmlServices = wService.GetServicesList(true);

            }
            
            ServiceConfigurationCollection wServiceConfigurationCollection = (ServiceConfigurationCollection)
                Fwk.HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(ServiceConfigurationCollection), xmlServices);

            return wServiceConfigurationCollection;
            
        }
        /// <summary>
        /// Recupera la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <returns>configuración del servicio de negocio.</returns>
        /// <date>2008-04-07T00:00:00</date>
        /// <author>moviedo</author>
        public ServiceConfiguration GetServiceConfiguration(string pServiceName)
        {
            string xmlServices = null;
            
            using (SingleService.SingleService wService = new SingleService.SingleService())
            {
                xmlServices = wService.GetServiceConfiguration(pServiceName);
            }

            return ServiceConfiguration.GetServiceConfigurationFromXml(xmlServices); ;
        }

        /// <summary>
        /// Actualiza la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <param name="pServiceName">Nombre del servicio a actualizar.</param>
        /// <date>2008-04-10T00:00:00</date>
        /// <author>moviedo</author>
        public void SetServiceConfiguration(String pServiceName ,ServiceConfiguration pServiceConfiguration)
        {
            Fwk.Bases.Connector.SingleService.ServiceConfiguration wServiceConfigurationProxy = 
                GetServiceConfigurationProxy(pServiceConfiguration);
            
            using (SingleService.SingleService wService = new SingleService.SingleService())
            {

                wService.Url = Fwk.Bases.ConfigurationsHelper.WebServiceDispatcherUrlSetting;
                wService.SetServiceConfiguration(wServiceConfigurationProxy);

            }
        }

     

        /// <summary>
        /// Almacena la configuración de un nuevo servicio de negocio.
        /// </summary>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2008-04-13T00:00:00</date>
        /// <author>moviedo</author>
        public void AddServiceConfiguration(ServiceConfiguration pServiceConfiguration)
        {
            Fwk.Bases.Connector.SingleService.ServiceConfiguration wServiceConfigurationProxy = 
                GetServiceConfigurationProxy(pServiceConfiguration);

            using (SingleService.SingleService wService = new SingleService.SingleService())
            {

                wService.Url = Fwk.Bases.ConfigurationsHelper.WebServiceDispatcherUrlSetting;
                wService.AddServiceConfiguration(wServiceConfigurationProxy);

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
            using (SingleService.SingleService wService = new SingleService.SingleService())
            {
                wService.Url = Fwk.Bases.ConfigurationsHelper.WebServiceDispatcherUrlSetting;
                wService.DeleteServiceConfiguration(pServiceName);
            }
        }


        private static Fwk.Bases.Connector.SingleService.ServiceConfiguration GetServiceConfigurationProxy(ServiceConfiguration pServiceConfiguration)
        {
            Fwk.Bases.Connector.SingleService.ServiceConfiguration wServiceConfigurationProxy = null;

            wServiceConfigurationProxy = new Fwk.Bases.Connector.SingleService.ServiceConfiguration();
            wServiceConfigurationProxy.Audit = pServiceConfiguration.Audit;
            wServiceConfigurationProxy.name = pServiceConfiguration.Name;
            wServiceConfigurationProxy.Handler = pServiceConfiguration.Handler;
            wServiceConfigurationProxy.Request = pServiceConfiguration.Request;
            wServiceConfigurationProxy.Response = pServiceConfiguration.Response;
            wServiceConfigurationProxy.Cacheable = pServiceConfiguration.Cacheable;
            wServiceConfigurationProxy.FolderRepositoryKey = pServiceConfiguration.FolderRepositoryKey;
            wServiceConfigurationProxy.Available = pServiceConfiguration.Available;
            wServiceConfigurationProxy.Description = pServiceConfiguration.Description;
            wServiceConfigurationProxy.Audit = pServiceConfiguration.Audit;
            wServiceConfigurationProxy.Timeout = pServiceConfiguration.Timeout;
            String name = Enum.GetName(typeof(Fwk.Transaction.IsolationLevel), pServiceConfiguration.IsolationLevel);
            wServiceConfigurationProxy.IsolationLevel = (Fwk.Bases.Connector.SingleService.IsolationLevel)
                Enum.Parse(typeof(Fwk.Bases.Connector.SingleService.IsolationLevel), pServiceConfiguration.IsolationLevel.ToString());

            wServiceConfigurationProxy.TransactionalBehaviour = (Fwk.Bases.Connector.SingleService.TransactionalBehaviour)
                Enum.Parse(typeof(Fwk.Bases.Connector.SingleService.TransactionalBehaviour), pServiceConfiguration.TransactionalBehaviour.ToString());
           

            return wServiceConfigurationProxy;
        }
        #endregion [ServiceConfiguration]


        
    }
}

