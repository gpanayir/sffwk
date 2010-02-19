using System;
using Fwk.Bases;
using System.Collections.Generic;
using Fwk.HelperFunctions;
using Fwk.HelperFunctions.Caching;
using Fwk.Exceptions;

namespace Fwk.Bases
{
    /// <summary>
    /// Clase base de los request
    /// </summary>
    /// <example>
    /// <para>El siguiente ejemplo muestra un clase que hereda de la base Request que permite definir el contratode srvicio CrearCliente
    /// por lo  tanto recime la infotmacion de la entidad Clientes.-</para>
    /// <code>
    /// <![CDATA[
    ///  namespace Empresa.BackEnd.ISVC.CrearCliente.req
    ///       {
    ///   public class CrearClienteRequest : Request <Clientes>
    ///    {
    ///
    ///        public CrearClienteRequest()
    ///       {
    ///           this.ServiceName = "CrearClienteService";
    ///       }
    ///    }
    ///
    ///    #region [BussinesData]
    ///    [XmlRoot("ClientesList"), SerializableAttribute]
    ///    public class ClientesList : Entities
    ///    {
    ///        #region [Methods]
    ///        /// <summary>
    ///        /// Metodo estatico que retorna un objeto ClientesList apartir de un xml.-
    ///        /// </summary>
    ///        /// <param name="pXml">String con el xml</param>
    ///        /// <returns>ClientesList</returns>
    ///        public static ClientesList GetClientesListFromXml(String pXml)
    ///        {
    ///            return (ClientesList)Entity.GetObjectFromXml(typeof(ClientesList), pXml);
    ///        }
    ///        #endregion
    ///    }
    ///    [XmlInclude(typeof(Clientes)), Serializable]
    ///    public class Clientes : Entity
    ///    {
    ///        #region [Private Members]
    ///        private System.Int32? _IdCliente;
    ///        private System.Int64? _CUIT;
    ///        private System.String _RazonSocial;
    ///        #endregion
    ///        #region [Properties]
    ///
    ///        #region [IdCliente]
    ///        [XmlElement(ElementName = "IdCliente", DataType = "int")]
    ///        public int? IdCliente
    ///        {
    ///            get { return _IdCliente; }
    ///            set { _IdCliente = value; }
    ///        }
    ///        #endregion
    ///
    ///        #region [CUIT]
    ///
    ///        public Int64? CUIT
    ///        {
    ///            get { return _CUIT; }
    ///            set { _CUIT = value; }
    ///        }
    ///        #endregion
    ///
    ///        #region [RazonSocial]
    ///        [XmlElement(ElementName = "RazonSocial", DataType = "string")]
    ///        public String RazonSocial
    ///        {
    ///            get { return _RazonSocial; }
    ///            set { _RazonSocial = value; }
    ///        }
    ///        #endregion
    ///
    ///        #region [NombreFantasia]
    ///        [XmlElement(ElementName = "NombreFantasia", DataType = "string")]
    ///        public String NombreFantasia
    ///        {
    ///            get { return _NombreFantasia; }
    ///            set { _NombreFantasia = value; }
    ///        }
    ///        #endregion
    ///
    ///        #endregion
    ///
    ///       #region [Methods]
    ///        /// <summary>
    ///        /// Metodo estatico que retorna un objeto Clientes apartir de un xml.-
    ///        /// </summary>
    ///        /// <param name="pXml">String con el xml</param>
    ///        /// <returns>Clientes</returns>
    ///        public static Clientes GetClientesFromXml(String pXml)
    ///        {
    ///            return (Clientes)Entity.GetObjectFromXml(typeof(Clientes), pXml);
    ///        }
    ///        #endregion
    ///    }
    ///    #endregion
    /// }
    /// ]]>
    /// </code> 
    ///</example>
    /// <typeparam name="T">Cualquier objeto que implemente de IEntity <see cref="IEntity"/></typeparam>
    /// <date>2007-06-23T00:00:00</date> 
    /// <author>moviedo</author> 
    [Serializable]
    public abstract class Request<T> : ServiceContractBase<T>, IRequest
		where T : IEntity, new()
	{

        CacheSettings _CacheSettings = new CacheSettings ();

        /// <summary>
        /// Configuracion de cache del request
        /// </summary>
        public CacheSettings CacheSettings
        {
            get { return _CacheSettings; }
            set { _CacheSettings = value; }
        }

        private Boolean _Encrypt;

        /// <summary>
        /// Determina si el xml del request esta encriptado
        /// </summary>
        public Boolean Encrypt
        {
            get { return _Encrypt; }
            set { _Encrypt = value; }
        }
        
     
        /// <summary>
        /// Ejecuta un servicio de negocio.
        /// </summary>
        /// <param name="req">Dataset con datos de entrada para la  ejecuci�n del servicio.</param>
        /// <returns>Dataset con datos de respuesta del servicio.</returns>
        /// <date>2007-08-24T00:00:00</date>
        /// <author>moviedo</author>
        public virtual TResponse ExecuteService<TRequest, TResponse>(TRequest req)
            where TRequest : IServiceContract
            where TResponse : IServiceContract, new()
        {
            TResponse wResponse = new TResponse();

            if (WrapperFactory.Wrapper == null)
            {
                try
                {

                    WrapperFactory.TryCreateWrapper();
                }
                catch (Exception ex)
                {
                    wResponse.Error = ProcessConnectionsException.Process(ex);
                }
            }

            //Si no ocurrio algun error
            if (wResponse.Error == null)
            {

                wResponse = WrapperFactory.Wrapper.ExecuteService<TRequest, TResponse>(req);
            }

            return wResponse;
        }

       
    }
}
