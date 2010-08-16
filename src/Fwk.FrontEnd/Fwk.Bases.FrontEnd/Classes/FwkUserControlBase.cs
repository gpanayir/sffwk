using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Fwk.Bases;

namespace Fwk.Bases.FrontEnd
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class FwkUserControlBase : UserControl, IClientServiceBase
    {

        #region UserControlBase Properties

        private ClientServiceBase _ClientServiceBase = null;

        private IBaseEntity _EntityResult = null;

        /// <summary>
        /// 
        /// </summary>
        public IBaseEntity EntityResult
        {
            get { return _EntityResult; }
            set { _EntityResult = value; }
        }
        private IBaseEntity _EntityParam = null;

        /// <summary>
        /// 
        /// </summary>
        public IBaseEntity EntityParam
        {
            get { return _EntityParam; }
            set { _EntityParam = value; }
        }
        #endregion


        /// <summary>
        /// 
        /// </summary>
        public FwkUserControlBase()
        {
            InitializeComponent();
            _ClientServiceBase = new ClientServiceBase();
        }

        #region IClientServiceBase Members

       
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        ///<param name="providerName">Proveedor del wrapper. Este valor debe coincidir con un proveedor de metadata en el dispatcher</param>
        /// <param name="req"></param>
        /// <returns></returns>
        public TResponse ExecuteService<TRequest, TResponse>(string providerName, TRequest req)
            where TRequest : Fwk.Bases.IServiceContract
            where TResponse : Fwk.Bases.IServiceContract, new()
        {
            return _ClientServiceBase.ExecuteService<TRequest, TResponse>(providerName, req);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="req"></param>
        /// <returns></returns>
        public TResponse ExecuteService<TRequest, TResponse>(TRequest req)
            where TRequest : Fwk.Bases.IServiceContract
            where TResponse : Fwk.Bases.IServiceContract, new()
        {
            return _ClientServiceBase.ExecuteService<TRequest, TResponse>(string.Empty, req);
        }
        #endregion

        #region [ServiceConfiguration]
        /// <summary>
        /// Recupera la configuraci�n de todos los servicios de negocio.
        /// </summary>
        ///<param name="providerName">Proveedor del wrapper. Este valor debe coincidir con un proveedor de metadata en el dispatcher</param>
        /// <returns>Lista de configuraciones de servicios de negocio.</returns>
        /// <date>2006-02-10T00:00:00</date>
        /// <author>moviedo</author>
        public ServiceConfigurationCollection GetAllServices(string providerName)
        {
            return _ClientServiceBase.GetAllServices(providerName);
        }
        /// <summary>
        /// Recupera la configuraci�n de un servicio de negocio.
        /// </summary>
        ///<param name="providerName">Proveedor del wrapper. Este valor debe coincidir con un proveedor de metadata en el dispatcher</param>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <returns>configuraci�n del servicio de negocio.</returns>
        /// <date>2006-02-07T00:00:00</date>
        /// <author>moviedo</author>
        public ServiceConfiguration GetServiceConfiguration(string providerName ,string pServiceName)
        {
            return _ClientServiceBase.GetServiceConfiguration(providerName, pServiceName);
        }
        /// <summary>
        /// Actualiza la configuraci�n de un servicio de negocio.
        /// </summary>
        ///<param name="providerName">Proveedor del wrapper. Este valor debe coincidir con un proveedor de metadata en el dispatcher</param>
        /// <param name="pServiceConfiguration">configuraci�n del servicio de negocio.</param>
        /// <param name="pServiceName">Nombre del servicio a actualizar.</param>
        /// <date>2006-02-10T00:00:00</date>
        /// <author>moviedo</author>
        public void SetServiceConfiguration(string providerName,String pServiceName, ServiceConfiguration pServiceConfiguration)
        { _ClientServiceBase.SetServiceConfiguration(providerName, pServiceName, pServiceConfiguration); }

        /// <summary>
        /// Almacena la configuraci�n de un nuevo servicio de negocio.
        /// </summary>
        ///<param name="providerName">Proveedor del wrapper. Este valor debe coincidir con un proveedor de metadata en el dispatcher</param>
        /// <param name="pServiceConfiguration">configuraci�n del servicio de negocio.</param>
        /// <date>2006-02-13T00:00:00</date>
        /// <author>moviedo</author>
        public void AddServiceConfiguration(string providerName,ServiceConfiguration pServiceConfiguration)
        { _ClientServiceBase.AddServiceConfiguration(providerName, pServiceConfiguration); }

        /// <summary>
        /// Elimina la configuraci�n de un servicio de negocio.
        /// </summary>
        ///<param name="providerName">Proveedor del wrapper. Este valor debe coincidir con un proveedor de metadata en el dispatcher</param>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <date>2006-02-13T00:00:00</date>
        /// <author>moviedo</author>
        public void DeleteServiceConfiguration(string providerName,string pServiceName)
        { _ClientServiceBase.DeleteServiceConfiguration(providerName, pServiceName); }
        #endregion  [ServiceConfiguration]





        
    }
}
