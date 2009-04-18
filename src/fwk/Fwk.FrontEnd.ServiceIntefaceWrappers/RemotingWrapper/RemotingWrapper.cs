using System;
using System.Collections.Generic;
using System.Text;
using Fwk.Bases;
using Fwk.Exceptions;
using System.Runtime.Remoting;
using Fwk.Remoting.RemoteTypes;

namespace Fwk.FrontEnd.ServiceIntefaceWrappers
{
    /// <summary>
    /// 
    /// </summary>
    public class RemotingWrapper :IServiceInterfaceWrapper
    {
        #region IServiceInterfaceWrapper Members

        /// <summary>
        /// Metodo no implementado
        /// </summary>
        /// <param name="pServiceName"></param>
        /// <param name="pData"></param>
        /// <returns></returns>
        public string ExecuteService(string pServiceName, string pData)
        {
            throw new Exception("The method or operation is not implemented in remoting execution. It's obsolete");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="pServiceName"></param>
        /// <param name="pData"></param>
        /// <returns></returns>
        public TResponse ExecuteService<TRequest, TResponse>(string pServiceName, TRequest pData)
            where TRequest : IServiceContract
            where TResponse : IServiceContract, new()
        {
            pData.ServiceName = pServiceName;
            
            return this.ExecuteService<TRequest, TResponse>(pData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="pData"></param>
        /// <returns></returns>
        public TResponse ExecuteService<TRequest, TResponse>(TRequest pData)
            where TRequest : IServiceContract
            where TResponse : IServiceContract, new()
        {
            FwkRemoteObject wFwkRemoteObject = CreateClaseRemota();

            return (TResponse)wFwkRemoteObject.ExecuteService(pData);
        }



        #endregion




         private static bool IsConfigured()
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

        
        /// <summary>
        /// Carga la configuracion de remoting en el archivo indicado por RemotingConfigFile
        /// </summary>
        private static void LoadRemotingConfigSettings()
		{
			if (!IsConfigured())
			{
                //Si no se encuentra algun nombre de archivo en el App.config
				if (Fwk.Bases.ConfigurationsHelper.RemotingConfigFilePathSetting == string.Empty)
				{
					throw new Exception("No hay ruta especificada para el archivo de configuración.");
				}
				else
				{
                    RemotingConfiguration.Configure(Fwk.Bases.ConfigurationsHelper.RemotingConfigFilePathSetting, false);
				}
			}
		}

        /// <summary>
        /// Crea en este caso SimpleFacaddeRemoteObject .-
        /// </summary>
        /// <returns>Instancia de SimpleFacaddeRemoteObject</returns>
        private static FwkRemoteObject CreateClaseRemota()
		{
            LoadRemotingConfigSettings();

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
            FwkRemoteObject wFwkRemoteObject = CreateClaseRemota();

            return wFwkRemoteObject.GetServicesList();
          
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
            FwkRemoteObject wFwkRemoteObject = CreateClaseRemota();
            return wFwkRemoteObject.GetServiceConfiguration(pServiceName);
           
        }

        /// <summary>
        /// Actualiza la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <param name="pServiceName">Nombre del servicio a actualizar.</param>
        /// <date>2008-04-10T00:00:00</date>
        /// <author>moviedo</author>
        public void SetServiceConfiguration(string pServiceName,ServiceConfiguration pServiceConfiguration)
        { }

        /// <summary>
        /// Almacena la configuración de un nuevo servicio de negocio.
        /// </summary>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2008-04-13T00:00:00</date>
        /// <author>moviedo</author>
        public void AddServiceConfiguration(ServiceConfiguration pServiceConfiguration)
        { }

        /// <summary>
        /// Elimina la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <date>2008-04-13T00:00:00</date>
        /// <author>moviedo</author>
        public void DeleteServiceConfiguration(String  pServiceName)
        {
            FwkRemoteObject wFwkRemoteObject = CreateClaseRemota();

        }
        #endregion [ServiceConfiguration]
    }
}
