﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.HelperFunctions;
using Fwk.Exceptions;
using Fwk.Caching;
using System.Configuration;
using Fwk.ConfigSection;

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
        //internal static IServiceWrapper _Wrapper = null;

        /// <summary>
        /// Representa los diferentes wrapers de la aplicacion cliente
        /// se crea uno por FwkWrapperProvider
        /// </summary>
        internal static Dictionary<string, IServiceWrapper> _WraperPepository;

        /// <summary>
        /// Seccion FwkWrapper
        /// </summary>
        static WrapperProviderSection _ProviderSection;

        /// <summary>
        /// Levanta la seccion FwkWrapper.-
        /// Inicialisa el repositorio de wrappers. (no lo llena con los wrappers)
        /// </summary>
        static WrapperFactory()
        {
            try
            {
                _ProviderSection = ConfigurationManager.GetSection("FwkWrapper") as WrapperProviderSection;

            }
            catch (System.Configuration.ConfigurationErrorsException e)
            {
                
                TechnicalException te = new TechnicalException(string.Concat("No se puede cargar la configuracion del wrapper en el cliente la propiedad verifique en el archivo de configuracion si existe la seccion FwkWrapper"));
                te.ErrorId = "6000";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(WrapperFactory));
                throw te;
            }


            if (_WraperPepository == null)
            {
                _WraperPepository = new Dictionary<string, IServiceWrapper>();
            }

           
        }

        /// <summary>
        /// Ejecuta un servicio de negocio
        /// </summary>
        /// <typeparam name="TRequest">Tipo del Request</typeparam>
        /// <typeparam name="TResponse">Tipo del Response</typeparam>
        /// <param name="providerName">Proveedor del wrapper. Este valor debe coincidir con un proveedor de metadata en el dispatcher</param>
        /// <param name="pRequest">Objeto request del tipo <see cref="TRequest"/></param>
        /// <returns></returns>
        public static TResponse ExecuteService<TRequest, TResponse>(string providerName,TRequest pRequest)
            where TRequest : IServiceContract
            where TResponse : IServiceContract, new()
        {
            TResponse wResponse = new TResponse();

            InitWrapper(providerName);

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
                        wResponse = _WraperPepository[providerName].ExecuteService<TRequest, TResponse>(pRequest);
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
        /// Ejecuta un servicio de negocio con el proveedor de wrapper por defecto
        /// </summary>
        /// <param name="pRequest">Request con datos de entrada para la  ejecución del servicio.</param>
        /// <returns>Dataset con datos de respuesta del servicio.</returns>
        /// <date>2007-08-24T00:00:00</date>
        /// <author>moviedo</author>
        public static TResponse ExecuteService<TRequest, TResponse>(TRequest pRequest)
            where TRequest : IServiceContract
            where TResponse : IServiceContract, new()
        {
            return ExecuteService<TRequest, TResponse>(string.Empty, pRequest);
        }



        
        /// <summary>
        /// Inicializa un wrapper deacuerdo el nombre del proveedor
        /// Carga al wrapper el nombre
        /// </summary>
        /// <param name="providerName"></param>
        internal static void InitWrapper(string providerName)
        {
            if (!_WraperPepository.ContainsKey(providerName))
            {
                try
                {
                    WrapperProviderElement provider = _ProviderSection.GetProvider(providerName);

                    if (provider == null)
                    {
                        TechnicalException te;
                        if(String.IsNullOrEmpty(providerName))
                            te = new TechnicalException(string.Concat("El proveedor de configuracion del wrapper por defecto del lado del cliente, no existe, verifique en el archivo de configuracion si existe la seccion FwkWrapper y el proveedor por defecto"));
                        else
                            te = new TechnicalException(string.Concat("El proveedor de configuracion del wrapper ", providerName, " del lado del cliente, no existe, verifique en el archivo de configuracion si existe la seccion FwkWrapper y el proveedor mencionado"));

                        te.ErrorId = "6000";
                        Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(WrapperFactory));
                        throw te;
                    }
                    
                    IServiceWrapper w =(IServiceWrapper)ReflectionFunctions.CreateInstance(provider.WrapperProviderType);
                    w.ProviderName = providerName;
                    w.SourceInfo = provider.SourceInfo;
                    _WraperPepository.Add(providerName, w);
                    
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
