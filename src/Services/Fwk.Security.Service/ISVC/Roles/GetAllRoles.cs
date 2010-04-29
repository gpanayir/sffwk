using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;


namespace Fwk.Security.ISVC.GetAllRoles
{
    [Serializable]
    public class GetAllRolesReq : Request<Param>
    {
        public GetAllRolesReq()
		{
            this.ServiceName = "GetAllRolesService";
		}
    }

    #region [BussinesData]

    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {
        
    private System.String _UserName;

    public System.String UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        private System.String _ApplicationName;

        public System.String ApplicationName
        {
            get { return _ApplicationName; }
            set { _ApplicationName = value; }
        }
        
                

    }

    #endregion

    [Serializable]
    public class GetAllRolesRes : Response<Result>
    {
    }

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {
        Fwk.Security.Common.RolList _RolList;

        public Fwk.Security.Common.RolList RolList
        {
            get { return _RolList; }
            set { _RolList = value; }
        }

    }
}
