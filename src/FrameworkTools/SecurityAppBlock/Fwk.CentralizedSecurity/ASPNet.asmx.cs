using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Fwk.BusinessFacades;
using Fwk.Bases;
using System.Web.Services.Protocols;
using Fwk.ConfigSection;

namespace Fwk.CentralizedSecurity
{
    /// <summary>
    /// Summary description for ASPNet
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ASPNet : System.Web.Services.WebService
    {

        SimpleFacade _SimpleFacade;


        /// <summary>
        /// Ejecuta un service de negocio.
        /// </summary>
        ///<param name="providerName">Proveedor de metadata. Este parametro lo establece el cliente desde su configuracion de wrapper</param>
        /// <param name="pServiceName">Nombre del service.</param>
        /// <param name="pData">XML con datos de entrada para la ejecución del servicio.</param>
        /// <returns>XML con datos de salida del servicio.</returns>
        [WebMethod]
        public string ExecuteService(string providerName, string pServiceName, string pData)
        {

            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            string wResult = wSimpleFacade.ExecuteService(providerName, pServiceName, pData);
            return wResult;
        }

        /// <summary>
        /// Ejecuta un service de negocio.
        /// </summary>
        ///<param name="providerName">Proveedor de metadata. Este parametro lo establece el cliente desde su configuracion de wrapper</param>
        /// <param name="serviceName">Nombre del service.</param>
        /// <returns>Detalle informativo del servicio.</returns>
        [WebMethod]
        public string GetServiceConfiguration(string providerName, string serviceName)
        {
            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            return wSimpleFacade.GetServiceConfiguration(providerName, serviceName);
        }

        /// <summary>
        ///  Lista los servicios configurados
        /// </summary>
        ///<param name="providerName">Proveedor de metadata. Este parametro lo establece el cliente desde su configuracion de wrapper</param>
        /// <param name="ViewAsXml">Permite ver como xml todos los servicios y sus datos.
        /// Si se espesifuca false solo se vera una simple lista</param>
        /// <returns>Lista de servicios configurados</returns>
        [WebMethod]
        public string GetServicesList(string providerName, Boolean ViewAsXml)
        {

            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            return wSimpleFacade.GetServicesList(providerName, ViewAsXml);

        }


        /// <summary>
        /// Obtiene info del proveedor de metadata
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <returns></returns>
        [WebMethod]
        public MetadataProvider GetProviderInfo(string providerName)
        {
            SimpleFacade wSimpleFacade = CreateSimpleFacade();
            return wSimpleFacade.GetProviderInfo(providerName);

        }
        /// <summary>
        /// Factory de SimpleFacade
        /// </summary>  
        /// <returns></returns>
        SimpleFacade CreateSimpleFacade()
        {
            if (_SimpleFacade == null)
                _SimpleFacade = new SimpleFacade();

            return _SimpleFacade;
        }
    }
}
