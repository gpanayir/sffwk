using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using System.Web.Security;
using System.Security.Principal;
using Fwk.Security.Common;
using Fwk.Security.BE;
using Microsoft.Practices.EnterpriseLibrary.Security;
using Fwk.Security;
using Fwk.Bases;
using Fwk.UI.Controller;
using Fwk.UI.Common;
using Fwk.UI.Controls;

namespace Fwk.UI.Forms
{

    /// <summary>
    /// Formulario base del cual heredan todos los formularios de bignbang.- 
    /// Este formulario inicializa la seguridad y dispone de metodos y propiedades estaticos utiles para los demas
    /// componentes de Pelsoft.-
    /// 
    /// Realiza manejo de exepciones no controladas .-
    /// </summary>
    public partial class FormBase : XtraForm
    {
        #region [Public Properties]






        /// <summary>
        /// Obtiene El AssemblyQualifiedName de
        /// la clase.
        /// </summary>
        public string AssemblyInfo
        {
            get { return this.GetType().AssemblyQualifiedName; }
        }

        #region Authorization Factory

        internal static IAuthorizationProvider RuleProvider;
        public static IPrincipal Principal;
        public static string IdentityName;
        /// <summary>
        /// MAntiene un unico objeto SecurityController
        /// </summary>
        //static SingletonFactory<SecurityController> _Controllerfactory = new SingletonFactory<SecurityController>();
        public static User IndentityUserInfo;

        #endregion
        #endregion
        public FormBase(bool pHandleUnmanagedException)
        {
            InitializeComponent();
            if (pHandleUnmanagedException)
            {
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
        }
        /// <summary>
        /// Constructor del form base
        /// </summary>
        public FormBase()
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

        /// <summary>
        /// Establece el MessageViewer a sus valores por defecto (inforamcion y boton OK)
        /// </summary>
        protected void SetMessageViewInfoDefault()
        {
            MessageViewer.MessageBoxIcon = Fwk.UI.Common.MessageBoxIcon.Information;
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
            string wError;

            Exception wException = o as Exception;

            if (wException != null)
                wError = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(wException);
            else
                wError = o.ToString();

            System.Text.StringBuilder wStringBuilder = new System.Text.StringBuilder(5000);
            wStringBuilder.Append(@"Se detectaron anomalías en la aplicacion por favor chequee los siguientes errores: ");
            wStringBuilder.Append(Environment.NewLine);
            wStringBuilder.Append(Environment.NewLine);
            wStringBuilder.Append(@"{0}");
            wStringBuilder.Append(Environment.NewLine);
            wStringBuilder.Append("¿Desea salir de la aplicación?");

            wError = string.Format(wStringBuilder.ToString(), wError);

            ExceptionViewComponent wExceptionViewer = new ExceptionViewComponent();
            wExceptionViewer.ButtonsYesNoVisible = DevExpress.XtraBars.BarItemVisibility.Always;
            wExceptionViewer.Title = "Error no manejado";
            if (wException != null)
            {
                wExceptionViewer.Title = string.Concat(wExceptionViewer.Title, " : ", wException.Source);
            }
            #region Log del error en la base de datos o dicha configuracion
            bool wLogError = logError;

            if (logError)
            {
                //Si el error es del propio frqmework de logging no intentar loguear y evitaar asi la recursividad del error
                if (Fwk.Exceptions.ExceptionHelper.GetFwkExceptionTypes(wException) == Fwk.Exceptions.FwkExceptionTypes.TechnicalException)
                    if (((Fwk.Exceptions.TechnicalException)wException).ErrorId == "9004")
                        wLogError = false;
            }

            #endregion
            DialogResult wResult = wExceptionViewer.Show(wExceptionViewer.Title, wError, string.Empty, wLogError);

            if (wResult == DialogResult.OK)
                Application.Exit();
        }
        static bool logError = false;

        public static bool LogError
        {
            get { return logError; }
            set { logError = value; }
        }


        #region Authorization Factory

        /// <summary>
        /// Inicializa 
        ///     IAuthorizationProvider cargandole las reglas por medio de un servicio.-
        ///     IndentityUserInfo (servicio)
        ///     Genera el Principal (local) <see>GetGenericPrincipal</see> 
        /// </summary>
        public static void InitAuthorizationFactory()
        {
            string msgError;
            InitAuthorizationFactory(out msgError);
        }

        /// <summary>
        /// Inicializa: 
        ///     IAuthorizationProvider cargandole las reglas por medio de un servicio.-
        ///     IndentityUserInfo (servicio)
        ///     Genera el Principal (local) <see>GetGenericPrincipal</see>
        /// </summary>
        /// <param name="msgError">Mensage de error en caso de que se produzca alguno</param>
        public static void InitAuthorizationFactory(out string pMsgError)
        {
            pMsgError = string.Empty;
            // Inicializo Fwk Authorization provider y catching security provider
            // ASP.NET Membership y Profile providers no se inicializan de esta manera.
            try
            {
                if (FormBase.RuleProvider == null)
                {

                    FwkAuthorizationRuleList wFwkAuthorizationRuleList = new FwkAuthorizationRuleList();
                    wFwkAuthorizationRuleList.Populate(SecurityController.SearchAllRules());
                    FormBase.RuleProvider = new FwkAuthorizationRuleProvider(wFwkAuthorizationRuleList);
                }
                FormBase.IdentityName = FormBase.IndentityUserInfo.UserName;

                if (FormBase.Principal == null)
                {
                    GenericIdentity genericIdentity = new GenericIdentity(FormBase.IdentityName, "Database");
                    FormBase.Principal = new GenericPrincipal(genericIdentity, FormBase.IndentityUserInfo.Roles);
                }

                #region Este codigo se usaba cuando la aplicacion obtenia RuleProvider e IndentityUserInfo de manera local y sin servicios de fwk
                //if (FRM_FormBase.RuleProvider == null)
                //    FRM_FormBase.RuleProvider = AuthorizationFactory.GetAuthorizationProvider("RuleProvider_Fwk");
                //if (FRM_FormBase.IndentityUserInfo == null)
                //    FRM_FormBase.IndentityUserInfo = GetUserInfo(FRM_FormBase.IdentityName);
                #endregion

            }
            catch (Exception ex)
            {
                Fwk.Exceptions.TechnicalException wTechEx = new Fwk.Exceptions.TechnicalException("No se configuró correctamente el proveedor de autorización", ex);

                wTechEx.UserName = FormBase.IdentityName;
                throw wTechEx;
            }
        }


        /// <summary>
        /// Realiza la autenticacion del usuario para determinar si puede ingresar al sistema o no.-
        /// </summary>
        /// <param name="pName">Nombre de usuario ingresado en la pantalla de Login</param>
        /// <param name="pPassword">Clave</param>
        /// <param name="pAuthenticationMode">Modo de autenticación</param>
        /// <param name="pDomain">Dominio</param>
        /// <param name="pIsEnvironmentUser">Variable booleana que permite determinar si es el usuario que esta logueado en Windows</param>
        protected static void AuthenticateUser(String pName, String pPassword, AuthenticationModeEnum pAuthenticationMode, String pDomain, Boolean pIsEnvironmentUser)
        {
            //SecurityController controller = _Controllerfactory.GetObject();

            //Se saco la validación de abajo ya que ahora se ve si el usuario tiene roles y si no tiene se vuelve a la pantalla de Login 
            //y el FormBase.IndentityUserInfo tiene valores y no se volvería a recargar si se cambia de usuario en el Login.

            //if (FormBase.IndentityUserInfo == null)
            FormBase.IndentityUserInfo = SecurityController.AuthenticateUser(pName, pPassword, pAuthenticationMode, pDomain, pIsEnvironmentUser);
            if(FormBase.IndentityUserInfo!=null)
                FormBase.IndentityUserInfo.AuthenticationMode = pAuthenticationMode;
        }


        /// <summary>
        /// intenta autorizar el usuario registrado para la regla pasada por parametrio
        /// </summary>
        /// <param name="pRuleName">Nombre de la regla</param>
        /// <returns></returns>
        public static bool CheckRule(string pRuleName)
        {
            if (string.IsNullOrEmpty(pRuleName)) return true;

            if (FormBase.RuleProvider == null)
            {
                InitAuthorizationFactory();
            }

            return FormBase.RuleProvider.Authorize(FormBase.Principal, pRuleName);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        protected static User GetUserInfo(string userName)
        {

            //SecurityController controller = _Controllerfactory.GetObject();

            return SecurityController.GetUserInfoByName(userName);
        }



        #endregion

    }

}
