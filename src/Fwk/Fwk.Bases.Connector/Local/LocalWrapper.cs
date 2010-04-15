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
        SimpleFacade _SimpleFacade;
        /// <summary>
        /// Implementa la llamada al backend atravez de la ejecucion de la SimpleFacade. 
        /// Al llamar directamente a la SimpleFacade funciona como un despachador de servicios, esto lo hace
        /// debido  a aque se trata de un wrapper local.
        /// </summary>
        /// <param name="pReq">Clase request que implementa IServiceContract. No nececita pasarce el reprecentativo xml de tal
        /// objeto, esto es para evitar serializacion innecesaria</param>
        /// <returns>Response con los resultados del servicio</returns>
        private IServiceContract ExecuteService(IServiceContract pReq)
        {
            if (_SimpleFacade == null)
                _SimpleFacade = CreateSimpleFacade();

            pReq.InitializeHostContextInformation();
            IServiceContract wResponse = _SimpleFacade.ExecuteService(pReq);
            wResponse.InitializeHostContextInformation();

            return wResponse;
        }

        /// <summary>
        /// Ejecuta un servicio de negocio.
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
           
            pReq.ServiceName = pServiceName;
            
            TResponse wResponse = (TResponse)this.ExecuteService(pReq);
          


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
           

           return (TResponse)this.ExecuteService(pReq);


        }
        /// <summary>
        /// Este metodo no esta implementado para un wrapper local.-
        /// Su ejecucion producira un error.-
        /// </summary>
        /// <param name="pServiceName"></param>
        /// <param name="pData"></param>
        /// <returns></returns>
        [Obsolete("The method or operation is not implemented on local wraper")]
        public string ExecuteService(string pServiceName, string pData)
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

            String xmlServices = wSimpleFacade.GetServicesList(true);
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
            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            String xmlServices = wSimpleFacade.GetServiceConfiguration(pServiceName);
            return ServiceConfiguration.GetServiceConfigurationFromXml(xmlServices);
           
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="pServiceName"></param>
       /// <param name="pServiceConfiguration"></param>
        public void SetServiceConfiguration(String pServiceName, ServiceConfiguration pServiceConfiguration)
        {
            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            wSimpleFacade.SetServiceConfiguration(pServiceName,pServiceConfiguration);
            wSimpleFacade = null;
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
            wSimpleFacade.AddServiceConfiguration(pServiceConfiguration);
            wSimpleFacade = null;
        }

        /// <summary>
        /// Elimina la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <date>2008-04-13T00:00:00</date>
        /// <author>moviedo</author>
        public void DeleteServiceConfiguration(string pServiceName)
        {
            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            wSimpleFacade.DeleteServiceConfiguration(pServiceName);
            wSimpleFacade = null;
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
