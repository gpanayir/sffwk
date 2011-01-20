using System;
using System.Collections.Generic;
using System.Text;
using Fwk.Bases;
using Fwk.BusinessFacades;
using Fwk.Exceptions;

namespace Fwk.Bases.Connector
{
    /// <summary>
    /// Rapper que realiza la ejecucion de servicios de forma local. Llama directamente al la facada de servicios
    /// </summary>
    public class LocalWrapper : IServiceWrapper
    {
        #region properties
        SimpleFacade _SimpleFacade;

        string _ProviderName;

        /// <summary>
        /// Proveedor del wrapper. Este valor debe coincidir con un proveedor de metadata en el dispatcher
        /// </summary>
        public string ProviderName
        {
            get { return _ProviderName; }
            set { _ProviderName = value; }
        }
        //string _SourceInfo;

        /// <summary>
        /// No se utiliza en un wrapper local
        /// </summary>
        public string SourceInfo
        {
            get { return null; }
            set {  }
        }
        string _SecurityProviderName = string.Empty;

        /// <summary>
        /// Proveedor del seguridad en el despachador de servicios
        /// </summary>
        public string SecurityProviderName
        {
            get { return _SecurityProviderName; }
            set { _SecurityProviderName = value; }
        }

        string _CompanyId = string.Empty;

        /// <summary>
        /// Identificador de empresa
        /// </summary>
        public string CompanyId
        {
            get { return _CompanyId; }
            set { _CompanyId = value; }
        }
        #endregion 

        /// <summary>
        /// Implementa la llamada al backend atravez de la ejecucion de la SimpleFacade. 
        /// Al llamar directamente a la SimpleFacade funciona como un despachador de servicios, esto lo hace
        /// debido  a aque se trata de un wrapper local.
        /// </summary>
        /// <param name="pReq">Clase request que implementa IServiceContract. No nececita pasarce el reprecentativo xml de tal
        /// objeto, esto es para evitar serializacion innecesaria</param>
        /// <returns>Response con los resultados del servicio</returns>
        private IServiceContract ExecuteService(string serviceMetadataProviderName,IServiceContract pReq)
        {
            if (_SimpleFacade == null)
                _SimpleFacade = CreateSimpleFacade();

            pReq.InitializeHostContextInformation();
            IServiceContract wResponse = _SimpleFacade.ExecuteService(serviceMetadataProviderName, pReq);
            wResponse.InitializeHostContextInformation();

            return wResponse;
        }

        /// <summary>
        /// Ejecuta un servicio de negocio.
        /// </summary>
        /// <param name="serviceMetadataProviderName">Nombre proveedor de megtadatos de servicios en el dispatcher</param>
        /// <param name="pReq">Clase que implementa IServiceContract con datos de entrada para la  ejecución del servicio.</param>
        /// <returns>Clase que implementa IServiceContract con datos de respuesta del servicio.</returns>
        /// <date>2007-06-23T00:00:00</date>
        /// <author>moviedo</author>
        public TResponse ExecuteService<TRequest, TResponse>(string serviceMetadataProviderName, TRequest pReq)
            where TRequest : IServiceContract
            where TResponse : IServiceContract, new()
        {

            TResponse wResponse = (TResponse)this.ExecuteService(serviceMetadataProviderName,pReq);
            return wResponse;
        }

        /// <summary>
        /// Ejecuta un servicio de negocio.
        /// </summary>
        /// <param name="pReq">Clase que implementa IServiceContract con datos de entrada para la  ejecución del servicio.</param>
        /// <returns>Clase que implementa IServiceContract con datos de respuesta del servicio.</returns>
        /// <date>2007-06-23T00:00:00</date>
        /// <author>moviedo</author>
        ////////public TResponse ExecuteService<TRequest, TResponse>(TRequest pReq)
        ////////    where TRequest : IServiceContract
        ////////    where TResponse : IServiceContract, new()
        ////////{
        ////////   return (TResponse)this.ExecuteService(pReq);
        ////////}

        /// <summary>
        /// Este metodo no esta implementado para un wrapper local.-
        /// Su ejecucion producira un error.-
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="pData"></param>
        /// <returns></returns>
        [Obsolete("The method or operation is not implemented on local wraper")]
        public string ExecuteService(string serviceMetadataProviderName, string serviceName, string pData)
        {
            throw new Exception("The method or operation is not implemented.");
        }


        #region [ServiceConfiguration]

        /// <summary>
        /// Recupera la configuración de todos los servicios de negocio.
        /// </summary>
        /// <returns>Lista de configuraciones de servicios de negocio.</returns>
        /// <date>2008-04-10T00:00:00</date>
        /// <author>moviedo</author>
        public ServiceConfigurationCollection GetAllServices()
        {
            SimpleFacade wSimpleFacade = CreateSimpleFacade();

            String xmlServices = wSimpleFacade.GetServicesList(_ProviderName,true);
            ServiceConfigurationCollection wServiceConfigurationCollection = (ServiceConfigurationCollection)
                Fwk.HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(ServiceConfigurationCollection), xmlServices);

            return wServiceConfigurationCollection;
        }

        /// <summary>
        /// Recupera la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="serviceName">Nombre del servicio.</param>
        /// <returns>configuración del servicio de negocio.</returns>
        /// <date>2008-04-07T00:00:00</date>
        /// <author>moviedo</author>
        public ServiceConfiguration GetServiceConfiguration(string serviceName)
        {
            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            String xmlServices = wSimpleFacade.GetServiceConfiguration(_ProviderName, serviceName);
            return ServiceConfiguration.GetServiceConfigurationFromXml(xmlServices);
           
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="serviceName"></param>
       /// <param name="pServiceConfiguration"></param>
        public void SetServiceConfiguration(String serviceName, ServiceConfiguration pServiceConfiguration)
        {
            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            wSimpleFacade.SetServiceConfiguration(_ProviderName, serviceName, pServiceConfiguration);
          
        }

        /// <summary>
        /// Almacena la configuración de un nuevo servicio de negocio.
        /// </summary>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2008-04-13T00:00:00</date>
        /// <author>moviedo</author>
        public void AddServiceConfiguration(ServiceConfiguration pServiceConfiguration)
        {
            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            wSimpleFacade.AddServiceConfiguration(_ProviderName, pServiceConfiguration);
           
        }

        /// <summary>
        /// Elimina la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="serviceName">Nombre del servicio.</param>
        /// <date>2008-04-13T00:00:00</date>
        /// <author>moviedo</author>
        public void DeleteServiceConfiguration(string serviceName)
        {
            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            wSimpleFacade.DeleteServiceConfiguration(_ProviderName, serviceName);
           
        }
        /// <summary>
        /// Obtiene una lista de todas las aplicaciones configuradas en el origen de datos configurado por el 
        /// proveedor
        /// </summary>
        /// <returns></returns>
        public  List<String> GetAllApplicationsId()
        {
            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            return   wSimpleFacade.GetAllApplicationsId(_ProviderName);
       
        }



        /// <summary>
        /// Obtiene info del proveedor de metadata
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <returns></returns>
        public  Fwk.ConfigSection.MetadataProvider GetProviderInfo(string providerName)
        {
            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            return wSimpleFacade.GetProviderInfo(_ProviderName);
        }

        /// <summary>
        /// Factory de SimpleFacade
        /// </summary>
        /// <returns></returns>
        SimpleFacade CreateSimpleFacade()
        {
            if(_SimpleFacade == null)
                _SimpleFacade = new SimpleFacade();

            return _SimpleFacade;
        }
        #endregion
    }
}
