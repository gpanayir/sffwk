using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Mail.Common;
using System.Configuration;

namespace Fwk.Mail
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ProtocolMailBase
    {
        private String _UserMail;
        private String _UserPassword;
        private Int32 _ConnectionId;        
        private ConnectionStatusEnum _Status;
        private String _URLInboxMail;
        private String _Host;
        private Boolean _SSL;
        Fwk.ConfigSection.MailAgentElement _MailAgentProvider;
       
        public ProtocolMailBase()
        {
            
                _MailAgentProvider = Fwk.ConfigSection.MailAgentFactory.GetProvider();
            
            _Host = _MailAgentProvider.HostMail;
            _SSL = _MailAgentProvider.UseSSL;
        }
        public ProtocolMailBase(string mailAgentProviderName)
        {

          _MailAgentProvider=  Fwk.ConfigSection.MailAgentFactory.GetProvider(mailAgentProviderName);
          _Host = _MailAgentProvider.HostMail;
          _SSL = _MailAgentProvider.UseSSL;
        }

        #region [Event - Handler]

        public event EventHandler<NewMessagesEventArgs> NewMessagesIncoming;

        protected virtual void OnNewMessagesIncoming(NewMessagesEventArgs e)
        {
            EventHandler<NewMessagesEventArgs> handler = NewMessagesIncoming;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        /// <summary>
        /// Current status of the connection
        /// </summary>
        public ConnectionStatusEnum Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }

        /// <summary>
        /// Get the status conection
        /// </summary>
        public Boolean IsConected
        {
            get
            {
                return _Status==ConnectionStatusEnum.Connected?true:false;
            }
        }

        /// <summary>
        /// Represent the Id of connection established
        /// </summary>
        public Int32 ConnectionId
        {
            get
            {
                return _ConnectionId;
            }
            set
            {
                _ConnectionId = value;
            }
        }

        /// <summary>
        /// User Password to log in
        /// </summary>
        public String UserPassword
        {
            get
            {
                return _UserPassword;
            }
            set
            {
                _UserPassword = value;
            }
        }

        /// <summary>
        /// User account email
        /// </summary>
        public String UserMail
        {
            get
            {
                return _UserMail;
            }
            set
            {
                _UserMail = value;
            }
        }

        /// <summary>
        /// URL a la bandeja de entrada
        /// </summary>
        public String URLInboxMail
        {
            get
            {
                return String.Format(_MailAgentProvider.InboxUrl, Host, _UserMail, _UserPassword);
            }
        }

        /// <summary>
        /// Host del servidor de correo
        /// </summary>
        public String Host
        {
            get
            {
                return _Host;
            }
            set
            {
                _Host = value;
            }
        }

        /// <summary>
        /// Indica si la conexion utiliza SSL
        /// </summary>
        public Boolean SSL
        {
            get
            {
                return _SSL;
            }
            set
            {
                _SSL = value;
            }
        }

       


        public abstract LoginResponseEnum Connect(String pUserMail, String pUserPassword);

        public abstract LoginResponseEnum Disconnect();

        public abstract Boolean AccountValidation(String pUserMail, String pUserPassword);

        public abstract List<Message> FetchNewMessage();

        public abstract Int32 GetUnseen();
       
  
    }
        

    public class NewMessagesEventArgs : EventArgs
    {

        private List<Message> mMessageList;

        public List<Message> MessageList
        {
            get { return MessageList; }
        }
        
        public NewMessagesEventArgs(List<Message> pMessageList)
        {
            mMessageList = pMessageList;
        }

    }

}
