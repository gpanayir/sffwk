using System;
using System.Text;
using Fwk.Exceptions;

using Fwk.BusinessFacades.Utils;
using Fwk.ServiceManagement;
using Fwk.Bases;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using Fwk.HelperFunctions;
using Fwk.Caching;
using Fwk.Logging;
using Fwk.Logging.Targets;

using System.Configuration;
using System.Collections.Generic;

namespace Fwk.BusinessFacades
{

	/// <summary>
	/// Fachada de servicio por defecto a utilizar por las aplicaciones.
	/// </summary>
	/// <remarks>Esta fachada realiza las siguientes tareas: 
	/// 
	/// <list type="number">
	/// <item>Audita la  ejecución del servicio.</item>
	/// <item>Provee seguridad de acceso al servicio.</item>
	/// <item>Verifica que el servicio está disponible para ser ejecutado.</item>
	/// <item>Ejecuta el servicio a través de MSDTC en caso de ser necesario.</item>
	/// </list>
	/// </remarks>
	/// <date>2008-04-07T00:00:00</date>
	/// <author>moviedo</author>
    public sealed class SimpleFacade : IBusinessFacade
    {

  
      
        #region < IBusinessFacade members >



        /// <summary>
        /// Ejecuta un servicio de negocio.
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <param name="pRequest">Request con datos de entrada para la  ejecución del servicio.</param>
        /// <returns>XML con el resultado de la  ejecución del servicio.</returns>
        /// <date>2008-04-07T00:00:00</date>
        /// <author>moviedo</author>
        public IServiceContract ExecuteService(string providerName, IServiceContract pRequest)
        {
            if(FacadeHelper.Stopped)
            {
                TechnicalException te = new TechnicalException("El despachador no puede responder debido a que ocurrieron problemas en la carga de la configuración del dispatcher");
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<SimpleFacade>(te);
                te.ErrorId = "7008";
                throw te;
            }
            IServiceContract wResult = null;
            if (string.IsNullOrEmpty(pRequest.ServiceName))
            {

                TechnicalException te = new TechnicalException("El despachador de servicio no pudo continuar debido\r\n a que el nombre del servicio no fue establecido");
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<SimpleFacade>(te);

                te.ErrorId = "7005";
                throw te;
            }
            Boolean wExecuteOndispatcher = true;

            IRequest req = (IRequest)pRequest;
            ServiceConfiguration wServiceConfiguration = FacadeHelper.GetServiceConfiguration(providerName, pRequest.ServiceName);


            
            //establezco el nombre del proveedor de seguridad al request
            req.SecurityProviderName = FacadeHelper.GetProviderInfo(providerName).SecurityProviderName;

            
            req.ContextInformation.SetProviderName(providerName);
            //if (String.IsNullOrEmpty(req.ContextInformation.DefaultCulture))
            //    req.ContextInformation.DefaultCulture = FacadeHelper.GetProviderInfo(providerName).DefaultCulture;

            // Validación de disponibilidad del servicio.
            FacadeHelper.ValidateAvailability(wServiceConfiguration, out wResult);
            if (wResult != null)
                if (wResult.Error != null) return wResult;

            // Caching del servicio.
            if (req.CacheSettings != null && req.CacheSettings.CacheOnServerSide) //--------->>> Implement the cache factory
            {

                wResult = GetCaheDataById(req, wServiceConfiguration);
                if (wResult != null) wExecuteOndispatcher = false;

            }
            // Realiza la ejecucion del servicio
            if (wExecuteOndispatcher)
            {
                //  ejecución del servicio.
                if (wServiceConfiguration.TransactionalBehaviour == Fwk.Transaction.TransactionalBehaviour.Suppres)
                    wResult = FacadeHelper.RunNonTransactionalProcess(pRequest, wServiceConfiguration);
                else
                    wResult = FacadeHelper.RunTransactionalProcess(pRequest, wServiceConfiguration);


            }

            return wResult;
        }    
           
        
   
     
        /// <summary>
		/// Ejecuta un servicio de negocio.
		/// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <param name="serviceName">Nombre del servicio de negocio.</param> 
        /// <param name="pXmlRequest">XML con datos de entrada para la  ejecución del servicio.</param>
		/// <returns>XML con el resultado de la  ejecución del servicio.</returns>
		/// <date>2008-04-07T00:00:00</date>
		/// <author>moviedo</author>
        public string ExecuteService(string providerName, string serviceName, string pXmlRequest)
        {
            string wResult;

            ServiceConfiguration wServiceConfiguration = FacadeHelper.GetServiceConfiguration(providerName, serviceName);

            IServiceContract wRequest = (IServiceContract)ReflectionFunctions.CreateInstance(wServiceConfiguration.Request);
            if (wRequest == null)
            {
                TechnicalException te = new TechnicalException(string.Concat("El despachador de servicio no pudo continuar debido\r\na que no construir el requets del servicio: ",
                    serviceName, "\r\nVerifique que se encuentre los componentes necesarios para su ejecucion esten en el servidor de aplicación. "));

                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<SimpleFacade>(te);
                te.Assembly = this.GetType().Assembly.FullName;
                te.Source = this.GetType().Assembly.FullName;
                te.Class = "SimpleFacade";
                te.Namespace = "Fwk.BusinessFacades";
                te.Machine = Environment.MachineName;
                if (string.IsNullOrEmpty(ConfigurationsHelper.HostApplicationName))
                    te.Source = "Despachador de servicios en " + Environment.MachineName;
                else
                    te.Source = ConfigurationsHelper.HostApplicationName;

                te.ErrorId = "7003";
                throw te;
            }
            wRequest.SetXml(pXmlRequest);

            wResult = ExecuteService(providerName, wRequest).GetXml();

            return wResult;


        }




	    #endregion




        #region --[Caching]--
        


        /// <summary>
        /// Obtiene la data de la cache. si no lo encuentra ejecuta el servicio y lo almacena en la cache para proximo busqueda
        /// </summary>
        /// <param name="pRequest"></param>
        /// <param name="pServiceConfiguration"></param>
        /// <returns>IServiceContract con el response</returns>
        private IServiceContract GetCaheDataById(IRequest pRequest,ServiceConfiguration pServiceConfiguration)
        {
            IServiceContract wResult;
            object wItemInCache = null;
            if (string.IsNullOrEmpty(pRequest.CacheSettings.ResponseCacheId))
                pRequest.CacheSettings.ResponseCacheId = pRequest.ServiceName;
            FwkCache wFwkCache = KwkCacheFactory.GetFwkCache(pRequest.CacheSettings.CacheManagerName);
            //TODO: Agregar manejo de error para catching
              wItemInCache = wFwkCache.GetItemFromCache(pRequest.CacheSettings.ResponseCacheId);
            

            if (wItemInCache == null)
            {
                wResult = null;
            }
            else
            {
                wResult = (IServiceContract)wItemInCache;
            }
            //Si no hay resultados en la cahce se procede a ejecurar el servicio y de obtener resultados sin error
            //se almacena en la cache
            if (wResult == null)
            {
                if (pServiceConfiguration.TransactionalBehaviour == Fwk.Transaction.TransactionalBehaviour.Suppres)
                    wResult = FacadeHelper.RunNonTransactionalProcess(pRequest, pServiceConfiguration);
                else
                    wResult = FacadeHelper.RunTransactionalProcess(pRequest, pServiceConfiguration);

                //Almaceno el resultado en la cache solo si no hay errores en la ejecucion del servicio
                if (wResult.Error == null)
                {

                    KwkCacheFactory.GetFwkCache(pRequest.CacheSettings.CacheManagerName).SaveItemInCache(
                        pRequest.CacheSettings.ResponseCacheId,
                        wResult,
                        pRequest.CacheSettings.Priority,
                        pRequest.CacheSettings.ExpirationTime, pRequest.CacheSettings.TimeMeasures, pRequest.CacheSettings.RefreshOnExpired);
                }
            }

            return wResult;
        }
       
        #endregion

        /// <summary>
        /// Obtiene la configuracion de un servicio
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de la metadata de szervicio</param>
        /// <param name="serviceName">Nombre del servicio a obtener</param>
        /// <returns>Informacion del servicio</returns>
        public String GetServiceConfiguration(String providerName, String serviceName)
        {
            ServiceConfiguration wServiceConfiguration = null;
            String wServiceInfo;
            try
            {
                wServiceConfiguration = FacadeHelper.GetServiceConfiguration(providerName,serviceName);

                wServiceInfo = wServiceConfiguration.ToString();
            }
            catch (System.NullReferenceException)
            {
                wServiceInfo = string.Concat("El servicio ", serviceName , " no se encuentra configurado");
            }
            catch (Exception e)
            {
                wServiceInfo = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e);
                
            }
            
            return wServiceInfo;
        }

        /// <summary>
        /// lista los servicios configurados
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <param name="pViewXML">Permite ver como xml todos los servicios y sus datos.
        /// Si se espesifuca false solo se vera una simple lista</param>
        /// <returns></returns>
        public String GetServicesList(String providerName, Boolean pViewXML)
        {
            ServiceConfigurationCollection wServiceConfigurationCollection = FacadeHelper.GetAllServices(providerName);
            StringBuilder strList = new StringBuilder();

            if (pViewXML)
            {
                strList.Append(Fwk.HelperFunctions.SerializationFunctions.SerializeToXml(wServiceConfigurationCollection));
            }
            else
            {
                foreach (ServiceConfiguration serviceConfiguration in wServiceConfigurationCollection)
                {
                    strList.AppendLine(serviceConfiguration.Name);
                }
            }

            return strList.ToString();
        }

        /// <summary>
        /// Actualiza la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <param name="serviceName"></param>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2010-08-10T00:00:00</date>
        /// <author>moviedo</author>
        public void SetServiceConfiguration(String providerName, String serviceName, ServiceConfiguration pServiceConfiguration)
        {
            FacadeHelper.SetServiceConfiguration(providerName,serviceName, pServiceConfiguration); 
        }

        /// <summary>
        /// Almacena la configuración de un nuevo servicio de negocio.
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2008-04-13T00:00:00</date>
        /// <author>moviedo</author>
        public void AddServiceConfiguration(String providerName, ServiceConfiguration pServiceConfiguration)
        { FacadeHelper.AddServiceConfiguration(providerName, pServiceConfiguration); }

        /// <summary>
        /// Elimina la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <param name="serviceName">Nombre del servicio.</param>
        /// <date>2008-04-13T00:00:00</date>
        /// <author>moviedo</author>
        public void DeleteServiceConfiguration(String providerName, string serviceName)
        {
            FacadeHelper.DeleteServiceConfiguration(providerName, serviceName);
        
        }

        /// <summary>
        /// Obtiene una lista de todas las aplicaciones configuradas en el origen de datos configurado por el 
        /// proveedor
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <returns></returns>
        public  List<String> GetAllApplicationsId(string providerName)
        {
            return FacadeHelper.GetAllApplicationsId(providerName);
        }

        /// <summary>
        /// Obtiene info del proveedor de metadata
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <returns></returns>
        public Fwk.ConfigSection.MetadataProvider GetProviderInfo(string providerName)
        {
            return FacadeHelper.GetProviderInfo(providerName);
        }

        /// <summary>
        /// Chequea la disponibilidad del despachador de servicio
        /// </summary>
        /// <returns>Mensaje en caso de que el servicio no esté disponible</returns>
        public String CheckServiceAvailability()
        {
            String strMessage = String.Empty;
            FacadeHelper.ReloadConfig(out strMessage);
            return strMessage;
        }
	}
}

