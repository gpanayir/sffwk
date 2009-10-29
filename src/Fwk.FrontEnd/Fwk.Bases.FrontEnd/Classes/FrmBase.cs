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
    
         
        /// <summary>
        /// Establece el MessageViewer a sus valores por defecto
        /// </summary>
        protected void SetMessageViewInfoDefault()
        {
            MessageViewer.MessageBoxIcon = Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Information;
            MessageViewer.MessageBoxButtons = MessageBoxButtons.OK;

            
        }




        
        /// <summary>
        /// CLR ex no manejada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnUnhandledException(Object sender, UnhandledExceptionEventArgs e)
        {
            HandleUnhandledException(e.ExceptionObject);
        }

        /// <summary>
        /// Displays dialog with information about exceptions that occur in the application. 
        /// </summary>
        private static void AppThreadException(object source, System.Threading.ThreadExceptionEventArgs e)
        {
            HandleUnhandledException(e.Exception);
        }

        /// <summary>
        /// metodo que resuelve el msg a mostrar para ex no manejadas
        /// </summary>
        /// <param name="o"></param>
        public static void HandleUnhandledException(Object o)
        {
            string error;
            Exception ex = o as Exception;
            if (ex != null)
            {
                error = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }
            else
            {
                error = o.ToString();

            }

            System.Text.StringBuilder sb = new System.Text.StringBuilder(5000);
            sb.Append(@"Se detectaron anomalias en la aplicacion por favor chequee los siguientes errores: ");
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append(@"{0}");
            sb.Append(Environment.NewLine);
            sb.Append("Desea salir de la aplicacion ?");
            error = string.Format(sb.ToString(), error);
            Fwk.Bases.FrontEnd.Controls.FwkExceptionViewComponent wExceptionViewer = new Fwk.Bases.FrontEnd.Controls.FwkExceptionViewComponent();
             wExceptionViewer.Title = "";
            DialogResult result = wExceptionViewer.Show("",error, string.Empty);
            if (result == DialogResult.OK)
                Application.Exit();
        }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        /// <date>2007-08-23T00:00:00</date>
        /// <author>moviedo</author>
        public FrmBase()
        {
            InitializeComponent();
            try
            {
                // Me subscribo al manejador de ex no manejadas (CLR)
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(OnUnhandledException);

                //Redirigo las ex no manejadas a ThreadException
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(AppThreadException);
            }
            catch (Exception e)
            {
                HandleUnhandledException(e);
            }

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
        /// Recupera la configuración de todos los servicios de negocio.
        /// </summary>
        /// <returns>Lista de configuraciones de servicios de negocio.</returns>
        /// <date>2006-02-10T00:00:00</date>
        /// <author>moviedo</author>
        public ServiceConfigurationCollection GetAllServices()
        {
            return _ClientServiceBase.GetAllServices();
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
            return _ClientServiceBase.GetServiceConfiguration(pServiceName);
        }
        /// <summary>
        /// Actualiza la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <param name="pServiceName">Nombre del servicio a actualizar.</param>
        /// <date>2006-02-10T00:00:00</date>
        /// <author>moviedo</author>
        public void SetServiceConfiguration(String pServiceName,ServiceConfiguration pServiceConfiguration)
        { _ClientServiceBase.SetServiceConfiguration(pServiceName,pServiceConfiguration); }

        /// <summary>
        /// Almacena la configuración de un nuevo servicio de negocio.
        /// </summary>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2006-02-13T00:00:00</date>
        /// <author>moviedo</author>
        public void AddServiceConfiguration(ServiceConfiguration pServiceConfiguration)
        { _ClientServiceBase.AddServiceConfiguration(pServiceConfiguration); }

        /// <summary>
        /// Elimina la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
        /// <date>2006-02-13T00:00:00</date>
        /// <author>moviedo</author>
        public void DeleteServiceConfiguration(string pServiceName)
        { _ClientServiceBase.DeleteServiceConfiguration(pServiceName); }
        #endregion  [ServiceConfiguration]



       
    }
}