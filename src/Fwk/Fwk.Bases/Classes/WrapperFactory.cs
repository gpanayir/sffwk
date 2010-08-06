using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.HelperFunctions;
using Fwk.Exceptions;
using Fwk.Caching;

namespace Fwk.Bases
{
    /// <summary>
    /// Esta clace es utilizada por la clase generica Request la cual permite compartir un wrapper estatico entre 
    /// todos los request.-
    /// Cuando las llamadas a servicios es a travez de la clase request se utiliza esta clase
    /// </summary>
    internal static class WrapperFactory
    {
        /// <summary>
        /// Con un wrapper estatico evitamos la generacion de multiples instancias del wraper en el cliente atravez de las 
        /// multipoles llamadas desde la clase que implementa Request> 
        /// </summary>
        internal static IServiceWrapper _Wrapper = null;

        /// <summary>
        /// Intenta levantar por reflection un objeto wrapper determinado por la configuracion en el appsetting de la aplicacion host.-
        /// </summary>
        //internal static void TryCreateWrapper()
        //{

        //    InitWrapper();

        //}


        /// <summary>
        /// Ejecuta un servicio de negocio.
        /// </summary>
        /// <param name="pRequest">Request con datos de entrada para la  ejecución del servicio.</param>
        /// <returns>Dataset con datos de respuesta del servicio.</returns>
        /// <date>2007-08-24T00:00:00</date>
        /// <author>moviedo</author>
        public static TResponse ExecuteService<TRequest, TResponse>(TRequest pRequest)
            where TRequest : IServiceContract
            where TResponse : IServiceContract, new()
        {
            TResponse wResponse = new TResponse();
  
            InitWrapper();

            Boolean wExecuteOndispatcher = true;
            //Si no ocurrio algun error
            if (wResponse.Error == null)
            {
                IServiceContract res = null;
                IRequest req = (IRequest)pRequest;
                // Caching del servicio.
                if (req.CacheSettings != null && req.CacheSettings.CacheOnClientSide) //--------------------------------------->>> Implement the cache factory
                {

                    res = ServiceCacheMannager.Get(req);
                    wResponse = (TResponse)res;
                    //Si estaba en la cache no es necesario llamar al despachador de servicio
                    if (wResponse != null)
                        wExecuteOndispatcher = false;



                }


                if (wExecuteOndispatcher)
                {
                    try
                    {
                        wResponse = _Wrapper.ExecuteService<TRequest, TResponse>(pRequest);
                    }
                    catch (Exception ex)
                    {
                        wResponse.Error = ProcessConnectionsException.Process(ex);

                    }

                    //Si aplica cache y se llamo a la ejecucion se debe almacenar en cache para proxima llamada
                    if (req.CacheSettings != null && req.CacheSettings.CacheOnClientSide)
                    {
                        //Es posible que la ejecucion produzca algun error y por lo tanto no se permitira 
                        //su almacen en cache
                        if (wResponse.Error == null)
                            ServiceCacheMannager.Add(req, wResponse);
                    }
                }
            }

            return wResponse;
        }




        /// <summary>
        /// Este  metodo si no puede inicialiar el wrapper lanza una Ex
        /// </summary>
        internal static void InitWrapper()
        {
            if (_Wrapper == null)
            {
                try
                {
                    _Wrapper =
                        (IServiceWrapper)
                        ReflectionFunctions.CreateInstance(Fwk.Bases.ConfigurationsHelper.WrapperSetting);
                }
                catch (Exception ex)
                {
                    ServiceError wServiceError = ProcessConnectionsException.Process(ex);
                    TechnicalException te = new TechnicalException(wServiceError.Assembly, wServiceError.Namespace, wServiceError.Class, wServiceError.Machine, wServiceError.UserName, wServiceError.Message);

                    throw te;

                }

            }
        }

    }
}
