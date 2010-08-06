using System;
using System.Collections.Generic;
using System.Text;
using Fwk.Exceptions;

using Fwk.HelperFunctions;
using Fwk.Blocking;
using Fwk.Bases;
using Fwk.Caching;

namespace Fwk.Bases
{
    /// <summary>
    /// 
    /// </summary>
    public class ClientServiceBase 
    {
        //static IServiceWrapper _Wrapper;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="pServiceName"></param>
        /// <param name="pRequest">Request con datos de entrada para la  ejecución del servicio.</param>
        /// <returns></returns>
        public TResponse ExecuteService<TRequest, TResponse>(string pServiceName, TRequest pRequest)
            where TRequest : IServiceContract
            where TResponse : IServiceContract, new()
        {
            pRequest.ServiceName = pServiceName;
            return this.ExecuteService<TRequest, TResponse>(pRequest);

        }

        /// <summary>
        /// Ejecuta un servicio de negocio.
        /// </summary>
        /// <param name="pRequest">Request con datos de entrada para la  ejecución del servicio.</param>
        /// <returns>Dataset con datos de respuesta del servicio.</returns>
        /// <date>2007-08-24T00:00:00</date>
        /// <author>moviedo</author>
        public TResponse ExecuteService<TRequest, TResponse>(TRequest pRequest)
            where TRequest : IServiceContract
            where TResponse : IServiceContract, new()
        {

            return WrapperFactory.ExecuteService<TRequest, TResponse>(pRequest);
            //TResponse wResponse = new TResponse();

            //if (_Wrapper == null)
            //{
            //    try
            //    {
            //        _Wrapper =
            //            (IServiceWrapper)
            //            ReflectionFunctions.CreateInstance(Fwk.Bases.ConfigurationsHelper.WrapperSetting);
            //    }
            //    catch (Exception ex)
            //    {
            //        ServiceError wServiceError = ProcessConnectionsException.Process(ex);
            //        TechnicalException te = new TechnicalException(wServiceError.Assembly, wServiceError.Namespace, wServiceError.Class, wServiceError.Machine, wServiceError.UserName, wServiceError.Message);

            //        wResponse.Error = ProcessConnectionsException.Process(te);

            //    }

            //}
            //Boolean wExecuteOndispatcher = true;
            ////Si no ocurrio algun error
            //if (wResponse.Error == null)
            //{
            //    IServiceContract res = null;
            //    IRequest req = (IRequest)pRequest;
            //    // Caching del servicio.
            //    if (req.CacheSettings != null && req.CacheSettings.CacheOnClientSide) //--------------------------------------->>> Implement the cache factory
            //    {

            //        res = ServiceCacheMannager.Get(req);
            //        wResponse = (TResponse)res;
            //        //Si estaba en la cache no es necesario llamar al despachador de servicio
            //        if (wResponse != null)
            //            wExecuteOndispatcher = false;
                    
                            

            //    }


            //    if (wExecuteOndispatcher)
            //    {
            //        try
            //        {
            //            wResponse = _Wrapper.ExecuteService<TRequest, TResponse>(pRequest);
            //        }
            //        catch (Exception ex)
            //        {
            //            wResponse.Error = ProcessConnectionsException.Process(ex);

            //        }

            //        //Si aplica cache y se llamo a la ejecucion se debe almacenar en cache para proxima llamada
            //        if (req.CacheSettings != null && req.CacheSettings.CacheOnClientSide)
            //        {
            //            //Es posible que la ejecucion produzca algun error y por lo tanto no se permitira 
            //            //su almacen en cache
            //            if (wResponse.Error == null)
            //                ServiceCacheMannager.Add(req, wResponse);
            //        }
            //    }
            //}

            //return wResponse;
        }

       

        #region [ServiceConfiguration]
        /// <summary>
        /// Recupera la configuración de todos los servicios de negocio.
        /// </summary>
        /// <returns>Lista de configuraciones de servicios de negocio.</returns>
        /// <date>2006-02-10T00:00:00</date>
        /// <author>moviedo</author>
        public ServiceConfigurationCollection GetAllServices()
        {
          WrapperFactory.InitWrapper();

          return WrapperFactory._Wrapper.GetAllServices();
            
        }
        /// <summary>
        /// Recupera la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <returns>configuración del servicio de negocio.</returns>
        /// <date>2006-02-07T00:00:00</date>
        /// <author>moviedo</author>
        public ServiceConfiguration GetServiceConfiguration(string pServiceName)
        {
            WrapperFactory.InitWrapper();
            return WrapperFactory._Wrapper.GetServiceConfiguration(pServiceName);
        }
        /// <summary>
        /// Actualiza la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio de negocio.</param>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2006-02-10T00:00:00</date>
        /// <author>moviedo</author>
        public void SetServiceConfiguration(String  pServiceName ,ServiceConfiguration pServiceConfiguration)
        {
            WrapperFactory.InitWrapper();
            WrapperFactory._Wrapper.SetServiceConfiguration(pServiceName, pServiceConfiguration); 
        }

        /// <summary>
        /// Almacena la configuración de un nuevo servicio de negocio.
        /// </summary>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2006-02-13T00:00:00</date>
        /// <author>moviedo</author>
        public void AddServiceConfiguration(ServiceConfiguration pServiceConfiguration)
        {
            WrapperFactory.InitWrapper();
            WrapperFactory._Wrapper.AddServiceConfiguration(pServiceConfiguration); 
        }

        /// <summary>
        /// Elimina la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <date>2006-02-13T00:00:00</date>
        /// <author>moviedo</author>
        public void DeleteServiceConfiguration(string pServiceName)
        {
            WrapperFactory.InitWrapper();

            WrapperFactory._Wrapper.DeleteServiceConfiguration(pServiceName); 
        }
        #endregion [ServiceConfiguration]
    }
}
