using System;
using System.Text;
using Fwk.Exceptions;

using Fwk.BusinessFacades.Utils;
using Fwk.ServiceManagement;
using Fwk.Bases;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using Fwk.HelperFunctions;
using Fwk.HelperFunctions.Caching;
using Fwk.Logging;
using Fwk.Logging.Targets;

using System.Configuration;

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

        FwkCacheCollectionMannager _FwkCacheCollectionMannager = null;
            
        /// <summary>
        /// 
        /// </summary>
        public SimpleFacade()
        {

            //Inicializa la cache con la configuracion por defecto
            _FwkCacheCollectionMannager = new FwkCacheCollectionMannager ();
        }
        #region < IBusinessFacade members >






        /// <summary>
        /// Ejecuta un servicio de negocio.
        /// </summary>
        /// <param name="pRequest">Request con datos de entrada para la  ejecución del servicio.</param>
        /// <returns>XML con el resultado de la  ejecución del servicio.</returns>
        /// <date>2008-04-07T00:00:00</date>
        /// <author>moviedo</author>
        public IServiceContract ExecuteService(IServiceContract pRequest)
        {
            IServiceContract wResult = null;
            if (string.IsNullOrEmpty(pRequest.ServiceName))
            {
                System.Text.StringBuilder wMessage = new StringBuilder();
                wMessage.Append("El despachador de servicio no pudo continuar debido  \r\n");
                wMessage.Append("a que el nombre del servicio no fue establecido");
                TechnicalException te = new TechnicalException(wMessage.ToString());
                te.Assembly = "Fwk.BusinessFacades";
                te.Class = "FacadeHelper";
                te.Namespace = "Fwk.BusinessFacades";
                te.ErrorId = "7005";
                throw te;
            }
            Boolean wExecuteOndispatcher = true;
         
            try
            {
                IRequest req = (IRequest)pRequest;
                ServiceConfiguration wServiceConfiguration = FacadeHelper.GetServiceConfiguration(pRequest.ServiceName);


                // Validación de disponibilidad del servicio.
                FacadeHelper.ValidateAvailability(wServiceConfiguration);


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
            catch (Exception ex)
            {
                throw ExceptionHelper.ProcessException(ex);
            }
           
        }

     

       

     
        /// <summary>
		/// Ejecuta un servicio de negocio.
		/// </summary>
		/// <param name="pServiceName">Nombre del servicio de negocio.</param>
        /// <param name="pXmlRequest">XML con datos de entrada para la  ejecución del servicio.</param>
		/// <returns>XML con el resultado de la  ejecución del servicio.</returns>
		/// <date>2008-04-07T00:00:00</date>
		/// <author>moviedo</author>
        public string ExecuteService(string pServiceName ,string pXmlRequest)
        {
            string wResult;
            try
            {
                ServiceConfiguration wServiceConfiguration = FacadeHelper.GetServiceConfiguration(pServiceName);

                IServiceContract wRequest = (IServiceContract)ReflectionFunctions.CreateInstance(wServiceConfiguration.Request);
                
                wRequest.SetXml(pXmlRequest);

                wResult =  ExecuteService(wRequest).GetXml();
                
                return wResult;
            }
            catch (Exception ex)
            {
                throw ExceptionHelper.ProcessException(ex);
            }
            
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
            object wAux = null;
            if (string.IsNullOrEmpty(pRequest.CacheSettings.ResponseCacheId))
                pRequest.CacheSettings.ResponseCacheId = pRequest.ServiceName;

            //TODO: Agregar manejo de error para catching
            if (_FwkCacheCollectionMannager.CacheCollection.ContainsKey(pRequest.CacheSettings.CacheManagerName))
            {
                wAux = _FwkCacheCollectionMannager.GetFwkCache(pRequest.CacheSettings.CacheManagerName).
                    GetItemFromCache(pRequest.CacheSettings.ResponseCacheId);
            }

            if (wAux == null)
            {
                wResult = null;
            }
            else
            {
                wResult = (IServiceContract)wAux;
            }
            //Si no hay resultados en la cahce se procede a ejecurar el servicio y de obtener resultados sin error
            //se almacena en la cache
            if (wResult == null)
            {
                if (pServiceConfiguration.TransactionalBehaviour == Fwk.Transaction.TransactionalBehaviour.Suppres)
                    wResult = FacadeHelper.RunNonTransactionalProcess(pRequest, pServiceConfiguration);
                else
                    wResult = FacadeHelper.RunTransactionalProcess(pRequest, pServiceConfiguration);

                if (wResult.Error == null)
                {
                    //Almaceno el resultado en la cache
                    _FwkCacheCollectionMannager.GetFwkCache(pRequest.CacheSettings.CacheManagerName).SaveItemInCache(
                        pRequest.CacheSettings.ResponseCacheId,
                        wResult,
                        pRequest.CacheSettings.Priority,
                        pRequest.CacheSettings.DaysForExpiration);
                }
            }

            return wResult;
        }
       
        #endregion

        /// <summary>
        /// Obtiene la configuracion de un servicio
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio a obtener</param>
        /// <returns>Informacion del servicio</returns>
        public String GetServiceConfiguration(String pServiceName)
        {
            ServiceConfiguration wServiceConfiguration = null;
            String wServiceInfo;
            try
            {
                wServiceConfiguration = FacadeHelper.GetServiceConfiguration(pServiceName);
                wServiceInfo = wServiceConfiguration.ToString();
            }
            catch (System.NullReferenceException)
            {
                wServiceInfo = "El servicio " + pServiceName + " no se encuentra configurado";
            }
            catch (Exception e)
            {
                wServiceInfo = e.Message;
                
            }
            
            return wServiceInfo;
        }

        /// <summary>
        /// lista los servicios configurados
        /// </summary>
        /// <param name="pViewXML">Permite ver como xml todos los servicios y sus datos.
        /// Si se espesifuca false solo se vera una simple lista</param>
        /// <returns></returns>
        public String GetServicesList(Boolean pViewXML)
        {
            ServiceConfigurationCollection wServiceConfigurationCollection = FacadeHelper.GetAllServices();
            StringBuilder strList = new StringBuilder();

            if (pViewXML)
            {
                strList.Append(Fwk.HelperFunctions.SerializationFunctions.SerializeToXml(
                                   wServiceConfigurationCollection));
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
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2008-04-10T00:00:00</date>
        /// <author>moviedo</author>
        public void SetServiceConfiguration(String pServiceName, ServiceConfiguration pServiceConfiguration)
        {
            FacadeHelper.SetServiceConfiguration(pServiceName,pServiceConfiguration); 
        }

        /// <summary>
        /// Almacena la configuración de un nuevo servicio de negocio.
        /// </summary>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2008-04-13T00:00:00</date>
        /// <author>moviedo</author>
        public void AddServiceConfiguration(ServiceConfiguration pServiceConfiguration)
        { FacadeHelper.AddServiceConfiguration(pServiceConfiguration); }

        /// <summary>
        /// Elimina la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <date>2008-04-13T00:00:00</date>
        /// <author>moviedo</author>
        public void DeleteServiceConfiguration(string pServiceName)
        {
            FacadeHelper.DeleteServiceConfiguration(pServiceName);
        
        }
	}
}

