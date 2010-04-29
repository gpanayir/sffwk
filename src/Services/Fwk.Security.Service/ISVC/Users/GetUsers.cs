
        using System;
        using System.Collections.Generic;
        using Fwk.Bases;
        using System.Xml.Serialization;
using Fwk.Security.BE;

namespace Fwk.Security.ISVC.GetUser
{

    [Serializable]
    public class GetUserReq : Request<Param>
    {
          
        public GetUserReq()
        {
            this.ServiceName = "GetUserService";
        }
    }
    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {
        private System.String _Username;

        #region [Username]

        public System.String Username
        {
            get { return _Username; }
            set { _Username = value; }
        }
        #endregion

        string _AppName;

        public string ApplicationName
        {
            get { return _AppName; }
            set { _AppName = value; }
        }
    }

    [Serializable]
    public class GetUserRes : Response<Result>
    {

    }
    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {
        Fwk.Security.Common.User _User;

        public Fwk.Security.Common.User User
        {
            get { return _User; }
            set { _User = value; }
        }
    }


    
}
         
        