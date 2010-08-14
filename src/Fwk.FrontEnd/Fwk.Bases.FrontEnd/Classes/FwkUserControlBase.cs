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
        /// <param name="pServiceName"></param>
        /// <param name="pData"></param>
        /// <returns></returns>
        public string ExecuteService(string pServiceName, string pData)
        { throw new Exception("Metodo no implementado"); }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="pServiceName"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        public TResponse ExecuteService<TRequest, TResponse>(string pServiceName, TRequest req)
            where TRequest : Fwk.Bases.IServiceContract
            where TResponse : Fwk.Bases.IServiceContract, new()
        {
            return _ClientServiceBase.ExecuteService<TRequest, TResponse>(_ProviderName, req);
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
            return _ClientServiceBase.ExecuteService<TRequest, TResponse>(_ProviderName, req);
        }
        #endregion

        #region [ServiceConfiguration]
        /// <summary>
        /// Recupera la configuración de todos los servicios de negocio.
        /// </summary>
        /// <returns>Lista de configuraciones de servicios de negocio.</returns>
        /// <date>2006-02-10T00:00:00</date>
        /// <author>moviedo</author>
        public ServiceConfigurationCollection GetAllServices()
        {
            return _ClientServiceBase.GetAllServices(_ProviderName);
        }
        /// <summary>
        /// Recupera la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <returns>configuración del servicio de negocio.</returns>
        /// <date>2006-02-07T00:00:00</date>
        /// <author>moviedo</author>
        public ServiceConfiguration GetServiceConfiguration(string pServiceName)
        {
            return _ClientServiceBase.GetServiceConfiguration(_ProviderName, pServiceName);
        }
        /// <summary>
        /// Actualiza la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <param name="pServiceName">Nombre del servicio a actualizar.</param>
        /// <date>2006-02-10T00:00:00</date>
        /// <author>moviedo</author>
        public void SetServiceConfiguration(String pServiceName, ServiceConfiguration pServiceConfiguration)
        { _ClientServiceBase.SetServiceConfiguration(_ProviderName, pServiceName, pServiceConfiguration); }

        /// <summary>
        /// Almacena la configuración de un nuevo servicio de negocio.
        /// </summary>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2006-02-13T00:00:00</date>
        /// <author>moviedo</author>
        public void AddServiceConfiguration(ServiceConfiguration pServiceConfiguration)
        { _ClientServiceBase.AddServiceConfiguration(_ProviderName, pServiceConfiguration); }

        /// <summary>
        /// Elimina la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <date>2006-02-13T00:00:00</date>
        /// <author>moviedo</author>
        public void DeleteServiceConfiguration(string pServiceName)
        { _ClientServiceBase.DeleteServiceConfiguration(_ProviderName, pServiceName); }
        #endregion  [ServiceConfiguration]





        #region IServiceWrapper Members


        string _ProviderName;

        /// <summary>
        /// 
        /// </summary>
        public string ProviderName
        {
            get { return _ProviderName; }
            set { _ProviderName = value; }
        }
        string _SourceInfo;

        /// <summary>
        /// 
        /// </summary>
        public string SourceInfo
        {
            get { return _SourceInfo; }
            set { _SourceInfo = value; }
        }
        #endregion
    }
}
