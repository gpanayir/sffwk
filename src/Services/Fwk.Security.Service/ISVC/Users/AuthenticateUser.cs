using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Fwk.Security.BE;
using System.Xml.Serialization;



namespace Fwk.Security.ISVC.AuthenticateUser
{
    [Serializable]
    public class AuthenticateUserReq : Request<Params>
    {
        public AuthenticateUserReq()
        {
            this.ServiceName = "AuthenticateUserService";
        }
    }

    [XmlInclude(typeof(Params)), Serializable]
    public class Params : Entity
    {
        /// <summary>
        /// No utilizado para la llamada al servicio solo se pone
        /// por que se debe utilizar si o si una clase en el request.
        /// </summary>
        string _Name;
        string _Password;
        AuthenticationModeEnum _AuthenticationMode;
        bool _IsEnvironmentUser;
        string _Domain;

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }
        public AuthenticationModeEnum AuthenticationMode
        {
            get
            {
                return _AuthenticationMode;
            }
            set
            {
                _AuthenticationMode = value;
            }
        }
        public bool IsEnvironmentUser
        {
            get
            {
                return _IsEnvironmentUser;
            }
            set
            {
                _IsEnvironmentUser = value;
            }
        }
        public string Domain
        {
            get
            {
                return _Domain;
            }
            set
            {
                _Domain = value;
            }
        }



    }

    [Serializable]
    public class AuthenticateUserRes : Response<Result>
    {
    }

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {
        #region Members
        private System.Boolean _IsAuthenticated;
        UserInfo _UserInfo;
        #endregion

        #region Properties

        #region [IsAuthenticated]

        public bool IsAuthenticated
        {
            get { return _IsAuthenticated; }
            set { _IsAuthenticated = value; }
        }
        #endregion

        #region UserInfo
        public UserInfo UserInfo
        {
            get { return _UserInfo; }
            set { _UserInfo = value; }
        }
        #endregion

        #endregion
    }
}

