//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a Prominente Code Generator.
//     Runtime Version:1.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//
//</auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using System.Xml;
using Fwk.Security.BE;
using Fwk.Security.Common;
using System.Data;
using System.Data.SqlClient;

namespace Fwk.Security.ISVC.CreateUser
{

    [Serializable]
    public class CreateUserReq : Request<Param>
    {
        public CreateUserReq()
        {
            this.ServiceName = "CreateUserService";
        }
    }

    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {
        private User _User;
        private RolList _RolList = new RolList();


        #region [Properties]

        public User User
        {
            get { return _User; }
            set { _User = value; }
        }

        public RolList RolList
        {
            get { return _RolList; }
            set { _RolList = value; }
        }
        
       

        #endregion

    }

    [Serializable]
    public class CreateUserRes : Response<Result>
    {
    }

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {
        private User _UserBE;
        public User UserBE
        {
            get { return _UserBE; }
            set { _UserBE = value; }
        }
    }    
}
