using System;
using System.Collections.Generic;
using System.Text;
using Fwk.Bases;
using Fwk.Exceptions;
using System.Runtime.Remoting;
using Fwk.Remoting;

namespace Fwk.Bases.Connector
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class RemotingWrapper :IServiceWrapper
    {

        string _ProviderName;

        /// <summary>
        /// Proveedor del wrapper. Este valor debe coincidir con un proveedor de metadata en el dispatcher
        /// </summary>
        public string ProviderName
        {
            get { return _ProviderName; }
            set { _ProviderName = value; }
        }
        string _SourceInfo;

        /// <summary>
        /// Archivo de configuracion de remoting
        /// </summary>
        public string SourceInfo
        {
            get { return _SourceInfo; }
            set { _SourceInfo = value; }
        }

        string _ServiceMetadataProviderName = string.Empty;

        /// <summary>
        /// Proveedor del metadatos en el despachador de servicios
        /// </summary>
        public string ServiceMetadataProviderName
        {
            get { return _ServiceMetadataProviderName; }
            set { _ServiceMetadataProviderName = value; }
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

        #region IServiceInterfaceWrapper Members

        /// <summary>
        /// Metodo no implementado
        /// </summary>
        public string ExecuteService(string serviceMetadataProviderName,string pServiceName, string pData)
        {
            throw new Exception("The method or operation is not implemented in remoting execution. It's obsolete");
        }

        /// <summary>
        /// Ejecuta un servicio de negocio.
        /// </summary>
        /// <param name="serviceMetadataProviderName">Nombre proveedor de megtadatos de servicios en el dispatcher</param>
        /// <param name="req">Clase que imlementa la interfaz IServiceContract datos de entrada para la  ejecución del servicio.</param>
        /// <returns>Clase que imlementa la interfaz IServiceContract con datos de respuesta del servicio.</returns>
        /// <returns></returns>
        public TResponse ExecuteService<TRequest, TResponse>(string serviceMetadataProviderName, TRequest req)
            where TRequest : IServiceContract
            where TResponse : IServiceContract, new()
        {

            FwkRemoteObject wFwkRemoteObject = CreateRemoteObject();

            req.InitializeHostContextInformation();
            TResponse response = (TResponse)wFwkRemoteObject.ExecuteService(serviceMetadataProviderName, req);
            response.InitializeHostContextInformation();

            return response;

            //return this.ExecuteService<TRequest, TResponse>(serviceMetadataProviderName,req);
        }

        ///// <summary>
        ///// Ejecucion del servicio
        ///// </summary>
        ///// <typeparam name="TRequest"></typeparam>
        ///// <typeparam name="TResponse"></typeparam>
        ///// <param name="pReq"></param>
        ///// <returns></returns>
        //public TResponse ExecuteService<TRequest, TResponse>(TRequest pReq)
        //    where TRequest : IServiceContract
        //    where TResponse : IServiceContract, new()
        //{
        //    FwkRemoteObject wFwkRemoteObject = CreateRemoteObject();

        //    pReq.InitializeHostContextInformation();
        //    TResponse response = (TResponse)wFwkRemoteObject.ExecuteService(_ProviderName, pReq);
        //    response.InitializeHostContextInformation();

        //    return response;
        //}



        #endregion


        /// <summary>
        /// Objeto de interbloqueo concurrente
        /// </summary>
        protected static readonly object singletonLock = new object();

        private static bool IsConfigured()
        {
            //Seccion protegida por la posibilidad de multiples procesos intentar levantar la configuracion
            lock (singletonLock)
            {
                bool wResult = false;

                foreach (WellKnownClientTypeEntry wEntry in RemotingConfiguration.GetRegisteredWellKnownClientTypes())
                {
                    if (wEntry.TypeName == typeof(FwkRemoteObject).FullName)
                    {
                        wResult = true;
                        break;
                    }
                }

                return wResult;
            }
        }

       
		

        /// <summary>
        /// Crea en este caso SimpleFacaddeRemoteObject .-
        /// </summary>
        /// <returns>Instancia de SimpleFacaddeRemoteObject</returns>
        private  FwkRemoteObject CreateRemoteObject()
		{
            //Carga la configuracion de remoting en el archivo indicado por RemotingConfigFile en _SourceInfo
            if (!IsConfigured())
            {
                //Si no se encuentra algun nombre de archivo en el App.config
                if (_SourceInfo == string.Empty)
                {
                    throw new Exception("No hay ruta especificada para el archivo de configuración.");
                }
                else
                {
                    RemotingConfiguration.Configure(_SourceInfo, false);
                }
            }

            FwkRemoteObject wFwkRemoteObject = new FwkRemoteObject();
            return wFwkRemoteObject;
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
            FwkRemoteObject wFwkRemoteObject = CreateRemoteObject();

            return wFwkRemoteObject.GetServicesList(_ProviderName);
          
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
            FwkRemoteObject wFwkRemoteObject = CreateRemoteObject();
            return wFwkRemoteObject.GetServiceConfiguration(_ProviderName, pServiceName);
           
        }

        /// <summary>
        /// Actualiza la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <param name="pServiceName">Nombre del servicio a actualizar.</param>
        /// <date>2008-04-10T00:00:00</date>
        /// <author>moviedo</author>
        public void SetServiceConfiguration(string pServiceName,ServiceConfiguration pServiceConfiguration)
        {
            FwkRemoteObject wFwkRemoteObject = CreateRemoteObject();
            wFwkRemoteObject.SetServiceConfiguration(_ProviderName, pServiceName, pServiceConfiguration);
        }

        /// <summary>
        /// Almacena la configuración de un nuevo servicio de negocio.
        /// </summary>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2008-04-13T00:00:00</date>
        /// <author>moviedo</author>
        public void AddServiceConfiguration(ServiceConfiguration pServiceConfiguration)
        {
            FwkRemoteObject wFwkRemoteObject = CreateRemoteObject();
            wFwkRemoteObject.AddServiceConfiguration(_ProviderName, pServiceConfiguration);
        }

        /// <summary>
        /// Elimina la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <date>2008-04-13T00:00:00</date>
        /// <author>moviedo</author>
        public void DeleteServiceConfiguration(String  pServiceName)
        {
            FwkRemoteObject wFwkRemoteObject = CreateRemoteObject();
            wFwkRemoteObject.DeleteServiceConfiguration(_ProviderName, pServiceName);
        }
        
        /// <summary>
        /// Obtiene una lista de todas las aplicaciones configuradas en el origen de datos configurado por el 
        /// proveedor
        /// </summary>
        /// <returns></returns>
        public  List<String> GetAllApplicationsId()
        {
            FwkRemoteObject wFwkRemoteObject = CreateRemoteObject();
            return wFwkRemoteObject.GetAllApplicationsId(_ProviderName);
            
        }
        /// <summary>
        /// Obtiene info del proveedor de metadata
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <returns></returns>
        public Fwk.ConfigSection.MetadataProvider GetProviderInfo(string providerName)
        {
            FwkRemoteObject wFwkRemoteObject = CreateRemoteObject();
            return wFwkRemoteObject.GetProviderInfo(_ProviderName);
        }
        #endregion [ServiceConfiguration]

        
    }
}
