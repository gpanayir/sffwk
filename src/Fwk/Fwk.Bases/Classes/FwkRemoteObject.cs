using System;
using System.Collections.Generic;
using System.Text;
using Fwk.BusinessFacades;
using Fwk.Bases;
using System.Diagnostics;

namespace Fwk.Remoting
{
    public class FwkRemoteObject : MarshalByRefObject
    {
        public IServiceContract ExecuteService(IServiceContract pReq)
        {

            SimpleFacade wSimpleFacade = new SimpleFacade();
            IServiceContract wRsponse = wSimpleFacade.ExecuteService(pReq);
            return wRsponse;

        }

        public IServiceContract ExecuteService(string pServiceName,IServiceContract pReq)
        {
            pReq.ServiceName = pServiceName;
            return this.ExecuteService(pReq);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pServiceName"></param>
        /// <returns></returns>
        public  ServiceConfiguration GetServiceConfiguration(string pServiceName)
        {
            SimpleFacade wSimpleFacade = new SimpleFacade();
            String xmlServices = wSimpleFacade.GetServiceConfiguration(pServiceName);
            return ServiceConfiguration.GetServiceConfigurationFromXml(xmlServices);
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ServiceConfigurationCollection GetServicesList()
        {
            SimpleFacade wSimpleFacade = new SimpleFacade();

            String xmlServices = wSimpleFacade.GetServicesList(true);
            ServiceConfigurationCollection wServiceConfigurationCollection = (ServiceConfigurationCollection)
                Fwk.HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(ServiceConfigurationCollection), xmlServices);

            return wServiceConfigurationCollection;
          

        }

        /// <summary>
        /// Actualiza la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <param name="pServiceName">Nombre del servicio a actualizar.</param>
        /// <date>2006-02-10T00:00:00</date>
        /// <author>moviedo</author>
        public void SetServiceConfiguration(String pServiceNamem,ServiceConfiguration pServiceConfiguration)
        {
            SimpleFacade wSimpleFacade = new SimpleFacade();
            wSimpleFacade.SetServiceConfiguration(pServiceNamem,pServiceConfiguration); 
        }

        /// <summary>
        /// Almacena la configuración de un nuevo servicio de negocio.
        /// </summary>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2006-02-13T00:00:00</date>
        /// <author>moviedo</author>
        public void AddServiceConfiguration(ServiceConfiguration pServiceConfiguration)
        {
            SimpleFacade wSimpleFacade = new SimpleFacade();
            wSimpleFacade.AddServiceConfiguration(pServiceConfiguration); 
        }

        /// <summary>
        /// Elimina la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <date>2006-02-13T00:00:00</date>
        /// <author>moviedo</author>
        public void DeleteServiceConfiguration(string pServiceName)
        {
            SimpleFacade wSimpleFacade = new SimpleFacade();
            wSimpleFacade.DeleteServiceConfiguration(pServiceName); 

        }
    }
}
