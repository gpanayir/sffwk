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
        string _ProviderName;

        public string ProviderName
        {
            get { return _ProviderName; }
            set { _ProviderName = value; }
        }
        /// <summary>
        /// Direccion url del servicio web
        /// </summary>
        public string SourceInfo
        {
            get { return msz_URL; }
            set { msz_URL = value; }
        }

	    private string msz_URL = string.Empty;
        /// <summary>
        /// Direccion url del servicio web
        /// </summary>
        //public static string _URL;
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

            using (singleservice.SingleService wService = new singleservice.SingleService())
			{
                wService.Url = msz_URL;//Fwk.Bases.ConfigurationsHelper.WebServiceDispatcherUrlSetting;
				wResult = wService.ExecuteService(pServiceName, pData);
			}

			return wResult;
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pServiceName"></param>
        /// <param name="pData"></param>
        public void ExecuteService_OneWay(string pServiceName, string pData)
        {
            

            using (singleservice.SingleService wService = new singleservice.SingleService())
            {

                wService.Url = msz_URL;//Fwk.Bases.ConfigurationsHelper.WebServiceDispatcherUrlSetting;
                wService.ExecuteService_OneWay(pServiceName, pData);

            }
         
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pServiceName"></param>
        /// <param name="pData"></param>
        /// <param name="callback"></param>
        public void ExecuteServiceAsynk(string pServiceName, string pData,Delegate callback)
        {
           

            using (singleservice.SingleService wService = new singleservice.SingleService())
            {

                wService.Url = msz_URL;// Fwk.Bases.ConfigurationsHelper.WebServiceDispatcherUrlSetting;
                
                wService.ExecuteServiceCompleted += new Fwk.Bases.Connector.singleservice.ExecuteServiceCompletedEventHandler(wService_ExecuteServiceCompleted);

            }

        }

        void wService_ExecuteServiceCompleted(object sender, Fwk.Bases.Connector.singleservice.ExecuteServiceCompletedEventArgs e)
        {
            
            throw new NotImplementedException();
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
                pReq.InitializeHostContextInformation();
                string wResult = ExecuteService(pServiceName ,pReq.GetXml());
                wResponse.SetXml(wResult);
                wResponse.InitializeHostContextInformation();
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
                pReq.InitializeHostContextInformation();
                string wResult = ExecuteService(pReq.ServiceName, pReq.GetXml());
                wResponse.SetXml(wResult);
                wResponse.InitializeHostContextInformation();
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

            using (singleservice.SingleService wService = new singleservice.SingleService())
            {
                wService.Url = msz_URL;//Fwk.Bases.ConfigurationsHelper.WebServiceDispatcherUrlSetting;
                
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
            
            using (singleservice.SingleService wService = new singleservice.SingleService())
            {
                wService.Url = msz_URL;
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
            Fwk.Bases.Connector.singleservice.ServiceConfiguration wServiceConfigurationProxy = 
                GetServiceConfigurationProxy(pServiceConfiguration);
            
            using (singleservice.SingleService wService = new singleservice.SingleService())
            {

                wService.Url = msz_URL;// Fwk.Bases.ConfigurationsHelper.WebServiceDispatcherUrlSetting;
                wService.SetServiceConfiguration(pServiceName,wServiceConfigurationProxy);

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
            Fwk.Bases.Connector.singleservice.ServiceConfiguration wServiceConfigurationProxy = 
                GetServiceConfigurationProxy(pServiceConfiguration);

            using (singleservice.SingleService wService = new singleservice.SingleService())
            {

                wService.Url = msz_URL;// Fwk.Bases.ConfigurationsHelper.WebServiceDispatcherUrlSetting;
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
            using (singleservice.SingleService wService = new singleservice.SingleService())
            {
                wService.Url = msz_URL;//Fwk.Bases.ConfigurationsHelper.WebServiceDispatcherUrlSetting;
                wService.DeleteServiceConfiguration(pServiceName);
            }
        }


        private static Fwk.Bases.Connector.singleservice.ServiceConfiguration GetServiceConfigurationProxy(ServiceConfiguration pServiceConfiguration)
        {
            Fwk.Bases.Connector.singleservice.ServiceConfiguration wServiceConfigurationProxy = null;

            wServiceConfigurationProxy = new Fwk.Bases.Connector.singleservice.ServiceConfiguration();
            wServiceConfigurationProxy.Audit = pServiceConfiguration.Audit;
            wServiceConfigurationProxy.name = pServiceConfiguration.Name;
            wServiceConfigurationProxy.Handler = pServiceConfiguration.Handler;
            wServiceConfigurationProxy.Request = pServiceConfiguration.Request;
            wServiceConfigurationProxy.Response = pServiceConfiguration.Response;
            wServiceConfigurationProxy.CreatedDateTime = pServiceConfiguration.CreatedDateTime;
            wServiceConfigurationProxy.ApplicationId = pServiceConfiguration.ApplicationId;
            wServiceConfigurationProxy.Available = pServiceConfiguration.Available;
            wServiceConfigurationProxy.Description = pServiceConfiguration.Description;
            wServiceConfigurationProxy.Audit = pServiceConfiguration.Audit;
            wServiceConfigurationProxy.CreatedUserName = pServiceConfiguration.CreatedUserName;
            String name = Enum.GetName(typeof(Fwk.Transaction.IsolationLevel), pServiceConfiguration.IsolationLevel);
            wServiceConfigurationProxy.IsolationLevel = (Fwk.Bases.Connector.singleservice.IsolationLevel)
                Enum.Parse(typeof(Fwk.Bases.Connector.singleservice.IsolationLevel), pServiceConfiguration.IsolationLevel.ToString());

            wServiceConfigurationProxy.TransactionalBehaviour = (Fwk.Bases.Connector.singleservice.TransactionalBehaviour)
                Enum.Parse(typeof(Fwk.Bases.Connector.singleservice.TransactionalBehaviour), pServiceConfiguration.TransactionalBehaviour.ToString());
           

            return wServiceConfigurationProxy;
        }
        #endregion [ServiceConfiguration]


        
    }
}

