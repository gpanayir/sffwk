using System;
using Fwk.Bases;
namespace Fwk.Bases
{
    /// <summary>
    /// 
    /// </summary>
    public interface IClientServiceBase : IServiceWrapper
    {




        /// <summary>
        /// 
        /// </summary>
        IBaseEntity EntityResult
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        IBaseEntity EntityParam
        {
            get;
            set;
        }
        #region [ServiceConfiguration]
        /// <summary>
        /// Recupera la configuraci�n de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <returns>configuraci�n del servicio de negocio.</returns>
        /// <date>2006-02-07T00:00:00</date>
        /// <author>moviedo</author>
        ServiceConfiguration GetServiceConfiguration(string pServiceName);

        /// <summary>
        /// Recupera la configuraci�n de todos los servicios de negocio.
        /// </summary>
        /// <returns>Lista de configuraciones de servicios de negocio.</returns>
        /// <date>2006-02-10T00:00:00</date>
        /// <author>moviedo</author>
        ServiceConfigurationCollection GetAllServices();


        /// <summary>
        /// Actualiza la configuraci�n de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio a actualizar.</param>
        /// <param name="pServiceConfiguration">configuraci�n del servicio de negocio.</param>
        /// <date>2006-02-10T00:00:00</date>
        /// <author>moviedo</author>
        void SetServiceConfiguration(String pServiceName,ServiceConfiguration pServiceConfiguration);

        /// <summary>
        /// Almacena la configuraci�n de un nuevo servicio de negocio.
        /// </summary>
        /// <param name="pServiceConfiguration">configuraci�n del servicio de negocio.</param>
        /// <date>2006-02-13T00:00:00</date>
        /// <author>moviedo</author>
        void AddServiceConfiguration(ServiceConfiguration pServiceConfiguration);

        /// <summary>
        /// Elimina la configuraci�n de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <date>2006-02-13T00:00:00</date>
        /// <author>moviedo</author>
        void DeleteServiceConfiguration(string pServiceName);
        #endregion
    }
}
