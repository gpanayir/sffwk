using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Fwk.Bases;


namespace Fwk.Bases.FrontEnd
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FrmBase : Form, IClientServiceBase
    {

        private ClientServiceBase _ClientServiceBase = new ClientServiceBase();
        private IEntity _EntityResult = null;

        /// <summary>
        /// 
        /// </summary>
        public IEntity EntityResult
        {
            get { return _EntityResult; }
            set { _EntityResult = value; }
        }
        private IEntity _EntityParam = null;

        /// <summary>
        /// 
        /// </summary>
        public IEntity EntityParam
        {
            get { return _EntityParam; }
            set { _EntityParam = value; }
        }
    

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        /// <date>2007-08-23T00:00:00</date>
        /// <author>moviedo</author>
        public FrmBase()
        {
            InitializeComponent();
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
            return _ClientServiceBase.ExecuteService<TRequest, TResponse>(pServiceName, req);
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
            return _ClientServiceBase.ExecuteService<TRequest, TResponse>(req);
        }
        #endregion


        #region [ServiceConfiguration]
        /// <summary>
        /// Recupera la configuraci�n de todos los servicios de negocio.
        /// </summary>
        /// <returns>Lista de configuraciones de servicios de negocio.</returns>
        /// <date>2006-02-10T00:00:00</date>
        /// <author>moviedo</author>
        public ServiceConfigurationCollection GetAllServices()
        {
            return _ClientServiceBase.GetAllServices();
        }
        /// <summary>
        /// Recupera la configuraci�n de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <returns>configuraci�n del servicio de negocio.</returns>
        /// <date>2006-02-07T00:00:00</date>
        /// <author>moviedo</author>
        public ServiceConfiguration GetServiceConfiguration(string pServiceName)
        {
            return _ClientServiceBase.GetServiceConfiguration(pServiceName);
        }
        /// <summary>
        /// Actualiza la configuraci�n de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceConfiguration">configuraci�n del servicio de negocio.</param>
        /// <param name="pServiceName">Nombre del servicio a actualizar.</param>
        /// <date>2006-02-10T00:00:00</date>
        /// <author>moviedo</author>
        public void SetServiceConfiguration(String pServiceName,ServiceConfiguration pServiceConfiguration)
        { _ClientServiceBase.SetServiceConfiguration(pServiceName,pServiceConfiguration); }

        /// <summary>
        /// Almacena la configuraci�n de un nuevo servicio de negocio.
        /// </summary>
        /// <param name="pServiceConfiguration">configuraci�n del servicio de negocio.</param>
        /// <date>2006-02-13T00:00:00</date>
        /// <author>moviedo</author>
        public void AddServiceConfiguration(ServiceConfiguration pServiceConfiguration)
        { _ClientServiceBase.AddServiceConfiguration(pServiceConfiguration); }

        /// <summary>
        /// Elimina la configuraci�n de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <date>2006-02-13T00:00:00</date>
        /// <author>moviedo</author>
        public void DeleteServiceConfiguration(string pServiceName)
        { _ClientServiceBase.DeleteServiceConfiguration(pServiceName); }
        #endregion  [ServiceConfiguration]



        #region  Members Blocking
       


        #endregion
    }
}