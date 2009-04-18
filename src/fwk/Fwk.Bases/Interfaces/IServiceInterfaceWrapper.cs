using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Fwk.Bases
{

	/// <summary>
	/// Interfaz para clases que funcionan como wrappers de interfaces de servicio.
	/// </summary>
	/// <remarks>
	/// Las clases que implementen esta interfaz deben ser capaces de solicitar la  ejecución de servicios de negocio a través de métodos de la intefaz de servicio utilizada, y devolver el resultado del mismo como resultado de la  ejecución.
	/// </remarks>
	/// <date>2007-06-23T00:00:00</date>
    /// <author>moviedo</author>
	public interface IServiceInterfaceWrapper
	{


		/// <summary>
		/// Ejecuta un servicio de negocio.
		/// </summary>
		/// <param name="pServiceName">Nombre del servicio.</param>
		/// <param name="pData">XML con datos de entrada para la  ejecución del servicio.</param>
		/// <returns>XML con datos de salida del servicio.</returns>
		/// <date>2007-06-23T00:00:00</date>
		/// <author>moviedo</author>
		string ExecuteService(string pServiceName, string pData);

       

        /// <summary>
        /// Ejecuta un servicio de negocio. Este metodo no debe ser mas utilizado solo se deja por compatibilidad
        /// con verciones anteriores.
        /// El establecimiento del nombre del servicio directamente se debe hacer por medio de la clase TRequest
        /// 
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <param name="pData">Clase que imlementa la interfaz IServiceContract datos de entrada para la  ejecución del servicio.</param>
        /// <returns>Clase que imlementa la interfaz IServiceContract con datos de respuesta del servicio.</returns>
        /// <date>2007-06-23T00:00:00</date>
        /// <author>moviedo</author>
        TResponse ExecuteService<TRequest, TResponse>(string pServiceName, TRequest pData)
            where TRequest : IServiceContract
            where TResponse : IServiceContract, new();

        /// <summary>
        /// Ejecuta un servicio de negocio.
        /// </summary>
        /// <param name="pData">Clase que imlementa la interfaz IServiceContract datos de entrada para la  ejecución del servicio.</param>
        /// <returns>Clase que imlementa la interfaz IServiceContract con datos de respuesta del servicio.</returns>
        /// <date>2007-06-23T00:00:00</date>
        /// <author>moviedo</author>
        TResponse ExecuteService<TRequest, TResponse>( TRequest pData)
            where TRequest : IServiceContract
            where TResponse : IServiceContract, new();

        #region [ServiceConfiguration]

        /// <summary>
        /// Recupera la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <returns>configuración del servicio de negocio.</returns>
        /// <date>2008-04-07T00:00:00</date>
        /// <author>moviedo</author>
        ServiceConfiguration GetServiceConfiguration(string pServiceName);

        /// <summary>
        /// Recupera la configuración de todos los servicios de negocio.
        /// </summary>
        /// <returns>Lista de configuraciones de servicios de negocio.</returns>
        /// <date>2008-04-10T00:00:00</date>
        /// <author>moviedo</author>
        ServiceConfigurationCollection GetAllServices();


        /// <summary>
        /// Actualiza la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <param name="pServiceName">Nombre del servicio a actualizar.</param>
        /// <date>2008-04-10T00:00:00</date>
        /// <author>moviedo</author>
        void SetServiceConfiguration(String pServiceName, ServiceConfiguration pServiceConfiguration);

        /// <summary>
        /// Almacena la configuración de un nuevo servicio de negocio.
        /// </summary>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2008-04-13T00:00:00</date>
        /// <author>moviedo</author>
        void AddServiceConfiguration(ServiceConfiguration pServiceConfiguration);

        /// <summary>
        /// Elimina la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <date>2008-04-13T00:00:00</date>
        /// <author>moviedo</author>
        void DeleteServiceConfiguration(string pServiceName);

        #endregion
    }
}
