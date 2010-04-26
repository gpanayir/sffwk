using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
using Fwk.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Fwk.Mail.Common;
using Fwk.Mail;
using Fwk.Configuration;

namespace Fwk.Mail
{
    
    public partial class FwkMailAgent : Component
    {
        Pop3Services _Pop3;
        
        FwkCache _Cache;
        ObjCache _NewItemCache = null;
        ObjCache _ItemCache = null;
        System.Timers.Timer _Timer = null;
        private Boolean _IsConnected;
        private Int32 _UnSeenMessages = 0;
        private String _Provider;
        Fwk.ConfigSection.MailAgentElement _MailAgentProvider;

        [Category("Configuration")]
        [Browsable(true)]
        [Description("Allow select the default configuration provider")]
        public String Provider
        {
            get
            {
               return _Provider;
            }
            set
            {
                _Provider = value;
            }
        }

        [Category("Information")]
        [Browsable(true)]
        [Description("Information about the status with the mail server")]
        public Boolean IsConnected
        {
            get
            {
                return _IsConnected;
            }            
        }

       
        #region [Event - Handler]

        public event EventHandler<EventArgs> RequireAuthentication;
        protected virtual void OnRequireAuthentication(EventArgs e)
        {
            EventHandler<EventArgs> handler = RequireAuthentication;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<LoginEventArgs> LoginResponse;
        protected virtual void OnLoginResponse(LoginEventArgs e)
        {
            EventHandler<LoginEventArgs> handler = LoginResponse;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<NewReceivedMailEventArgs> NewReceivedMail;
        protected virtual void OnNewReceivedMail(NewReceivedMailEventArgs e)
        {
            EventHandler<NewReceivedMailEventArgs> handler = NewReceivedMail;
            if (handler != null)
            {
                handler(this, e);
            }
        }


        #endregion

        public FwkMailAgent()
        {
            InitializeComponent();
           
        }

        public FwkMailAgent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void Start(String pUser, String pPass)
        {
            NewMethod();

            // se verifica el tipo de servicio
            VerificationService(pUser, pPass);
            // se inicializa, ya se disponde de lso datos en cache
            InitializeMailService();
        }        

        public void Start()
        {

            NewMethod();
            // se inicializa
            InitializeMailService();
        }

        public void Stop()
        {
            if (ImapServices.Instance != null)
                ImapServices.Instance.Disconnect();

            if (_Pop3 != null)
                _Pop3.Disconnect();

        }

        private void NewMethod()
        {
            if (!this.DesignMode)
                if (string.IsNullOrEmpty(this.Provider))
                    _MailAgentProvider = Fwk.ConfigSection.MailAgentFactory.GetProvider();
                else
                    _MailAgentProvider = Fwk.ConfigSection.MailAgentFactory.GetProvider(this.Provider);
        }
        

        #region [CACHE]
        /// <summary>
        /// Obtiene los datos de la cache
        /// </summary>
        private void GetFromCache()
        {
            _ItemCache = new ObjCache();
           
            _Cache = new FwkCache();
           

            // Se obtiene el objeto con los datos de la cache
            _ItemCache = (ObjCache)_Cache.GetItemFromCache("MailAgentCache");
        }

        /// <summary>
        /// Inserta lso datos en la cache
        /// </summary>
        /// <param name="pItemCache">Data que se agregara a la cache</param>
        public void PutInCache(ObjCache pItemCache)
        {
            _ItemCache = new ObjCache();
            _Cache = new FwkCache();
            _Cache.RemoveItem("MailAgentCache");
            _Cache.SaveItemInCache("MailAgentCache", pItemCache, CacheItemPriority.Normal, 365, Fwk.HelperFunctions.DateFunctions.TimeMeasuresEnum.FromDays,false);
        }
        #endregion


        /// <summary>
        /// Inicializa el MailService
        /// </summary>
        private void InitializeMailService()
        {
         
            // se obtienen los datos de la cache yse guardan en wItemCache
            GetFromCache();

            if (_ItemCache == null)
            {   
                // se lanza evento, solicitando autenticación al usuario
                if(RequireAuthentication != null)
                    RequireAuthentication(this, new EventArgs());

                // Se cancela el inicio del servicio, se deben ingrensar parametros para la autenticacion del usuario
                return;
            }
            else // se procede con la inicialización del servicio
            {
                // si se logra la conexion, se procede a verificar los mails y al inicio del timer               
                if (VerificationNewMail())
                {
                    // Inicializa el timer
                    InitializeTimer();
                }
            }
        }

        /// <summary>
        /// Inicializa el timer
        /// </summary>
        private void InitializeTimer()
        {
          

            _Timer = new System.Timers.Timer();

            // Hook up the Elapsed event for the timer.
            _Timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);


            // Set the Interval to 2 seconds (2000 milliseconds)
            _Timer.Interval = (_MailAgentProvider.RefreshTime * 60) * 1000; //X minutos, expresado en milisecond
            _Timer.Enabled = true;
            _Timer.Start();

        }

        /// <summary>
        /// Realiza la verificacion de nuevo email.
        /// Este metodo lanza el evento NewReceivedMail,
        /// al que debera suscribirse para recibir la notificación.
        /// </summary>        
        /// <returns>True si se llevo a cabo la operacion</returns>
        private Boolean VerificationNewMail()
        {
            Int32 wNewMail = 0;

            // Verificacion de objeto en la cache
            if (_ItemCache == null)
            {   // se lanza evento, solicitando autenticación al usuario
                RequireAuthentication(this, new EventArgs());
                // Se cancela el inicio del servicio, se deben ingrensar parametros para la autenticacion del usuario
                return false;
            }


            if (_ItemCache.ConnectionType == ConnectionTypeEnum.IMAP)
            {
         
                ImapServices.Instance.UserMail = _ItemCache.UserMail;
                ImapServices.Instance.UserPassword = _ItemCache.UserPassword;


                LoginResponseEnum wResponse = new LoginResponseEnum();
                wResponse = ImapServices.Instance.Connect(_ItemCache.UserMail, _ItemCache.UserPassword);

                if ((wResponse == LoginResponseEnum.CONNECTION_FAIL) || (wResponse == LoginResponseEnum.LOGIN_FAIL))
                {
                    // Se lanza el evento, con el posible fallo en el login o el connect
                    // para que se re intente la operacion con nuevos parametros
                    _IsConnected = false;
                    
                    if(LoginResponse != null)
                        LoginResponse(this, new LoginEventArgs(wResponse));

                    return false;
                }

                _IsConnected = true;
                wNewMail = ImapServices.Instance.GetUnseen();

                // Se lanza evento con la cantidad de nuevos e-mails y la url para poder verlos
                if (wNewMail > 0)
                {
                    // Solo se lanza un evento si: 
                    // Se inicia por primera vez (unSeenMessages = 0)
                    // La cantidad de mails obtenidos es mayor que los no vistos desde el ultimo chequeo
                    // y solo se muestran cuando hay uno nuevo
                    if ((_UnSeenMessages == 0) || (wNewMail > _UnSeenMessages))
                    {
                        if(NewReceivedMail != null)
                            NewReceivedMail(this, new NewReceivedMailEventArgs(wNewMail, ImapServices.Instance.URLInboxMail));
                    }

                    _UnSeenMessages = wNewMail;
                }


                return true;
            }
            else
            {
                _Pop3 = Pop3Services.Instance;
                _Pop3.UserMail = _ItemCache.UserMail;
                _Pop3.UserPassword = _ItemCache.UserPassword;

                LoginResponseEnum wResponse = new LoginResponseEnum();
                wResponse = _Pop3.Connect(_ItemCache.UserMail, _ItemCache.UserPassword);

                if ((wResponse == LoginResponseEnum.CONNECTION_FAIL) || (wResponse == LoginResponseEnum.LOGIN_FAIL))
                {
                    // Se lanza el evento, con el posible fallo en el login o el connect
                    // para que se re intente la operacion con nuevos parametros
                    _IsConnected = false;
                    if (LoginResponse != null)
                        LoginResponse(this, new LoginEventArgs(wResponse));

                    return false;
                }

                _IsConnected = true;
                wNewMail = _Pop3.GetUnseen();

                // Se lanza evento con la cantidad de nuevos e-mails y la url para poder verlos
                if (wNewMail > 0)
                {
                    // Solo se lanza un evento si: 
                    // Se inicia por primera vez (unSeenMessages = 0)
                    // La cantidad de mails obtenidos es mayor que los no vistos desde el ultimo chequeo
                    // y solo se muestran cuando hay uno nuevo
                    if ((_UnSeenMessages == 0) || (wNewMail > _UnSeenMessages))
                    {
                        if (NewReceivedMail != null)
                            NewReceivedMail(this, new NewReceivedMailEventArgs(wNewMail, Pop3Services.Instance.URLInboxMail));
                    }

                    _UnSeenMessages = wNewMail;
                }

                return true;
            }
        }

        /// <summary>
        /// Verifica el tipo de servicio que corresponde al usuario.
        /// </summary>
        /// <param name="pUser">Mail del usuario</param>
        /// <param name="pPass">Password de la cuenta de mail</param>
        private void VerificationService(String pUser, String pPass)
        {
            // Se debe verificar el tipo de servicio de mail, IMAP o POP3
            Boolean wIsImap = false;
            Boolean wIsPop3 = false;

            // Se verifica primero el tipo Imap, ya que el mayor porcentaje de usuarios tendra Imap
                       
            wIsImap = ImapServices.Instance.AccountValidation(pUser, pPass);

            if (!wIsImap)// se verifica si es pop3
            {
                _Pop3 = Pop3Services.Instance; // obtiene instancia de Pop3Services
                _Pop3.Host = ImapServices.Instance.Host;

                wIsPop3 = _Pop3.AccountValidation(pUser, pPass);

                if (!wIsPop3)
                {
                    // se lanza evento, solicitando autenticación al usuario
                    if (RequireAuthentication != null)
                        RequireAuthentication(this, new EventArgs());

                    // Se cancela el inicio del servicio, se deben ingrensar parametros para la autenticacion del usuario
                    return;
                }
            }

            // se crea el objeto que se guardara en la cache
            _NewItemCache = new ObjCache();
            _NewItemCache.ConnectionType = wIsImap ? ConnectionTypeEnum.IMAP : ConnectionTypeEnum.POP3;
            _NewItemCache.UserMail = pUser;
            _NewItemCache.UserPassword = pPass;
            // se guarda un nuevo objeto en cache
            PutInCache(_NewItemCache);
        }
                
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            // Se lleva a cabo la verificación de los mails
            VerificationNewMail();

        }

    }


    public class LoginEventArgs : EventArgs
    {

        private LoginResponseEnum mLoginResponse;

        public LoginResponseEnum LoginResponse
        {
            get { return mLoginResponse; }
        }

        public LoginEventArgs(LoginResponseEnum pLoginResponse)
        {
            mLoginResponse = pLoginResponse;
        }

    }

    public class NewReceivedMailEventArgs : EventArgs
    {

        private Int32 mNewMailCount;
        private String mInboxUrl;

        /// <summary>
        /// Url que permite ingresar al Inbox del usuario
        /// </summary>
        public String InboxUrl
        {
            get
            {
                return mInboxUrl;
            }
        }
        /// <summary>
        /// Cantidad de nuevos mensajes en el Inbox del usuario
        /// </summary>
        public Int32 NewMailCount
        {
            get { return mNewMailCount; }
        }

        public NewReceivedMailEventArgs(Int32 pNewMailCount, String pInboxUrl)
        {
            mNewMailCount = pNewMailCount;
            mInboxUrl = pInboxUrl;
        }

    }

}
