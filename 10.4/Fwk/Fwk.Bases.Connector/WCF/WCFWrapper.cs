using System;
using System.Collections.Generic;
using System.Text;
using Fwk.Bases;
using Fwk.Exceptions;
using System.Runtime.Remoting;
using Fwk.Remoting;
using Fwk.BusinessFacades.Utils;
using Fwk.ConfigSection;
using System.ServiceModel;
using Fwk.Bases.Connector.WCFServiceReference;
using Newtonsoft.Json;

namespace Fwk.Bases.Connector
{
    /// <summary>
    /// Wrapper espesializado para una conexión a travez de RemotingConfiguration
    /// </summary>
    [Serializable]
    public class WCFWrapper :IServiceWrapper
    {
        NetTcpBinding binding=null;
        EndpointAddress address = null;
        string _ProviderName;

        /// <summary>
        /// Proveedor del wrapper. Este valor debe coincidir con un proveedor de metadata en el dispatcher
        /// </summary>
        public string ProviderName
        {
            get { return _ProviderName; }
            set { _ProviderName = value; }
        }

        private string _URL = string.Empty;

        /// <summary>
        /// Direccion url del servicio web
        /// </summary>
        public string SourceInfo
        {
            get { return _URL; }
            set { _URL = value; }
        }

        //string _SourceInfo;

        ///// <summary>
        ///// Archivo de configuracion de remoting
        ///// </summary>
        //public string SourceInfo
        //{
        //    get { return _SourceInfo; }
        //    set { _SourceInfo = value; }
        //}

        string _ServiceMetadataProviderName = string.Empty;

        /// <summary>
        /// Proveedor del metadatos en el despachador de servicios
        /// </summary>
        public string ServiceMetadataProviderName
        {
            get { return _ServiceMetadataProviderName; }
            set { _ServiceMetadataProviderName = value; }
        }

        string _AppId = string.Empty;

        /// <summary>
        /// Identificador de aplicacion o de empresa
        /// </summary>
        public string AppId
        {
            get { return _AppId; }
            set { _AppId = value; }
        }
        string _DefaultCulture = string.Empty;

        /// <summary>
        /// DefaultCulture de empresa
        /// </summary>
        public string ConfigProviderNameWithCultureInfo
        {
            get { return _DefaultCulture; }
            set { _DefaultCulture = value; }
        }
        #region IServiceInterfaceWrapper Members

         /// <summary>
         /// 
         /// </summary>
         /// <param name="pServiceName"></param>
         /// <param name="pData"></param>
         /// <returns></returns>
        public string ExecuteService(string pServiceName, string pData)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ejecuta un servicio de negocio.
        /// Si se produce el error:
        /// The parameter is incorrect. (Exception from HRESULT: 0x80070057 (E_INVALIDARG))
        /// Se debe a un error que lanza una llamada asincrona en modo debug  
        /// </summary>
        /// <param name="req">Clase que imlementa la interfaz IServiceContract datos de entrada para la  ejecución del servicio.</param>
        /// <returns>Clase que imlementa la interfaz IServiceContract con datos de respuesta del servicio.</returns>
        /// <returns>response</returns>
        public TResponse ExecuteService<TRequest, TResponse>(TRequest req)
            where TRequest : IServiceContract
            where TResponse : IServiceContract, new()
        {

            InitHost();

            req.InitializeHostContextInformation();

            ExecuteServiceRequest wcfReq = new ExecuteServiceRequest();
            ExecuteServiceResponse wcfRes = null;
            //JsonSerializerSettings settings = null;

            wcfReq.serviceName = req.ServiceName;
            wcfReq.providerName = _ServiceMetadataProviderName;
            wcfReq.jsonRequets = Fwk.HelperFunctions.SerializationFunctions.SerializeObjectToJson<TRequest>(req);
            //wcfReq.jsonRequets = Newtonsoft.Json.JsonConvert.SerializeObject(req, Formatting.None);

            using (FwkServiceClient svcProxy = new WCFServiceReference.FwkServiceClient(binding, address))
            {
               
                svcProxy.Open();
                //settings = new JsonSerializerSettings();
                //settings.Formatting = Formatting.None;

                wcfRes = svcProxy.ExecuteService(wcfReq);
            }
            //TResponse response = Newtonsoft.Json.JsonConvert.DeserializeObject<TResponse>(wcfRes.ExecuteServiceResult, settings);
            //response = new TResponse();
            //response.SetXml(wcfRes.ExecuteServiceResult);
            TResponse response = (TResponse)Fwk.HelperFunctions.SerializationFunctions.DeSerializeObjectFromJson<TResponse>(wcfRes.ExecuteServiceResult);

            response.InitializeHostContextInformation();
            return response;
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
            InitHost();

            GetServicesListRequest wcfReq = new GetServicesListRequest();
            GetServicesListResponse wcfRes = null;

            wcfReq.providerName = _ServiceMetadataProviderName;
            wcfReq.ViewAsXml = true;

            using (FwkServiceClient svcProxy = new WCFServiceReference.FwkServiceClient(binding, address))
            {

                svcProxy.Open();
                wcfRes = svcProxy.GetServicesList(wcfReq);
            }
            ServiceConfigurationCollection wServiceConfigurationCollection = (ServiceConfigurationCollection)
           Fwk.HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(ServiceConfigurationCollection), wcfRes.GetServicesListResult);

            return wServiceConfigurationCollection;

        }

        /// <summary>
        /// Recupera la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <returns>configuración del servicio de negocio.</returns>
        /// <date>2008-04-07T00:00:00</date>
        /// <author>moviedo</author>
        public ServiceConfiguration GetServiceConfiguration(String pServiceName)
        {
            InitHost();

            GetServiceConfigurationRequest wcfReq = new GetServiceConfigurationRequest();
            GetServiceConfigurationResponse wcfRes = null;

            wcfReq.providerName = _ServiceMetadataProviderName;
            wcfReq.serviceName = pServiceName;

            using (FwkServiceClient svcProxy = new WCFServiceReference.FwkServiceClient(binding, address))
            {

                svcProxy.Open();
                wcfRes = svcProxy.GetServiceConfiguration(wcfReq);
            }
            ServiceConfiguration wServiceConfiguration = (ServiceConfiguration)
           Fwk.HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(ServiceConfiguration), wcfRes.GetServiceConfigurationResult);

            return wServiceConfiguration;
           
        }

        /// <summary>
        /// Actualiza la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio a actualizar.</param>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2008-04-10T00:00:00</date>
        /// <author>moviedo</author>
        public void SetServiceConfiguration(string pServiceName,ServiceConfiguration pServiceConfiguration)
        {
            throw new NotImplementedException();
            //wFwkRemoteObject.SetServiceConfiguration(_ServiceMetadataProviderName, pServiceName, pServiceConfiguration);
        }

        /// <summary>
        /// Almacena la configuración de un nuevo servicio de negocio.
        /// </summary>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2008-04-13T00:00:00</date>
        /// <author>moviedo</author>
        public void AddServiceConfiguration(ServiceConfiguration pServiceConfiguration)
        {
            throw new NotImplementedException();
            //wFwkRemoteObject.AddServiceConfiguration(_ServiceMetadataProviderName, pServiceConfiguration);
        }

        /// <summary>
        /// Elimina la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <date>2008-04-13T00:00:00</date>
        /// <author>moviedo</author>
        public void DeleteServiceConfiguration(String pServiceName)
        {
            throw new NotImplementedException();
            //wFwkRemoteObject.DeleteServiceConfiguration(_ServiceMetadataProviderName, pServiceName);
        }
        
        /// <summary>
        /// Obtiene una lista de todas las aplicaciones configuradas en el origen de datos configurado por el 
        /// proveedor
        /// </summary>
        /// <returns></returns>
        public  List<String> GetAllApplicationsId()
        {
            InitHost();

            GetAllApplicationsIdRequest wcfReq = new GetAllApplicationsIdRequest();
            GetAllApplicationsIdResponse wcfRes = null;

            wcfReq.providerName = _ServiceMetadataProviderName;
            
            
            using (FwkServiceClient svcProxy = new WCFServiceReference.FwkServiceClient(binding, address))
            {

                svcProxy.Open();
                wcfRes = svcProxy.GetAllApplicationsId(wcfReq);
            }
            List<String > list = new List<string> ();
            list.AddRange(wcfRes.GetAllApplicationsIdResult);
            return list;
        }
        /// <summary>
        /// Obtiene info del proveedor de metadata
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <returns></returns>
        public Fwk.ConfigSection.MetadataProvider GetProviderInfo(string providerName)
        {
            InitHost();

            GetProviderInfoRequest wcfReq = new GetProviderInfoRequest();
            GetProviderInfoResponse wcfRes = null;

            wcfReq.providerName = providerName;

            using (FwkServiceClient svcProxy = new WCFServiceReference.FwkServiceClient(binding, address))
            {

                svcProxy.Open();
                wcfRes = svcProxy.GetProviderInfo(wcfReq);
            }

            MetadataProvider wMetadataProvider = wcfRes.GetProviderInfoResult;
            return wMetadataProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DispatcherInfo RetriveDispatcherInfo()
        {
            InitHost();

            RetriveDispatcherInfoRequest wcfReq = new RetriveDispatcherInfoRequest();
            RetriveDispatcherInfoResponse wcfRes = null;

            using (FwkServiceClient svcProxy = new WCFServiceReference.FwkServiceClient(binding, address))
            {

                svcProxy.Open();
                wcfRes = svcProxy.RetriveDispatcherInfo(wcfReq);
            }

            DispatcherInfo wDispatcherInfo = wcfRes.RetriveDispatcherInfoResult;
            return wDispatcherInfo;
           
        }
        #endregion [ServiceConfiguration]

        const int factorSize = 5;
        void InitHost()
        {
            if (binding == null)
            {
                //El tamaño de los mensajes que se pueden recibir durante la conexión a los servicios mediante BasicHttpBinding
                this.binding = new NetTcpBinding();
                
                binding.Name = "tcp";
                binding.MaxReceivedMessageSize *= factorSize;
                binding.MaxBufferSize *= factorSize;
                binding.MaxBufferPoolSize *= factorSize;
                binding.ReaderQuotas.MaxStringContentLength = 2147483647;
                binding.ReaderQuotas.MaxArrayLength = 2147483647;
                binding.ReaderQuotas.MaxBytesPerRead = 2147483647;
                address = new EndpointAddress(_URL);
            }
        }



        public string CheckServiceAvailability()
        {
            throw new NotImplementedException();
        }
    }
}
