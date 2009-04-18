//using System;
//using System.Data;
//using System.Collections.Generic;
//using System.Text;
//using Fwk.Bases;

//namespace Fwk.Bases.FrontEnd
//{
//    /// <summary>
//    /// Interfaz para clases que funcionan como wrappers de interfaces de servicio.
//    /// </summary>
//    /// <remarks>
//    /// Las clases que implementen esta interfaz deben ser capaces de solicitar la ejecuci�n de servicios de negocio a trav�s de m�todos de la intefaz de servicio utilizada, y devolver el resultado del mismo como resultado de la ejecuci�n.
//    /// </remarks>
//    /// <date>2007-06-23T00:00:00</date>
//    /// <author>moviedo</author>
//    public interface IServiceInterfaceWrapper2
//    {
//        /// <summary>
//        /// Ejecuta un servicio de negocio.
//        /// </summary>
//        /// <param name="pServiceName">Nombre del servicio.</param>
//        /// <param name="pData">XML con datos de entrada para la ejecuci�n del servicio.</param>
//        /// <returns>XML con datos de salida del servicio.</returns>
//        /// <date>2007-06-23T00:00:00</date>
//        /// <author>moviedo</author>
//        string ExecuteService(string pServiceName, string pData);

//        /// <summary>
//        /// Ejecuta un servicio de negocio.
//        /// </summary>
//        /// <param name="pServiceName">Nombre del servicio.</param>
//        /// <param name="pData">Dataset con datos de entrada para la ejecuci�n del servicio.</param>
//        /// <returns>Dataset con datos de respuesta del servicio.</returns>
//        /// <date>2007-06-23T00:00:00</date>
//        /// <author>moviedo</author>
//        TResponse ExecuteService<TRequest, TResponse>(string pServiceName, TRequest pData)
//            where TRequest : Entity
//            where TResponse : Entity, new();

//    }
//}
