
        using System;
        using System.Collections.Generic;
        using Fwk.Bases;
        using System.Xml.Serialization;
using Fwk.Security.BE;
using System.Data;
using System.Data.SqlClient;
using Fwk.Security.Common;

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
        private List<SqlParameter> _CustomParameters;
        private String _CustomStoredProcedure;

        public System.String Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        public String CustomStoredProcedure
        {
            get { return _CustomStoredProcedure; }
            set { _CustomStoredProcedure = value; }
        }

        public List<SqlParameter> CustomParameters
        {
            get
            {
                return _CustomParameters;
            }
            set
            {
                _CustomParameters = value;
            }
        }
    }

    [Serializable]
    public class GetUserRes : Response<Result>
    {

    }

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {
        User _User;
        private DataSet _CustomUser;


		public DataSet CustomUser
		{
			get
			{
				return _CustomUser;
			}
			set
			{
				_CustomUser = value;
			}
		}

        public User User
        {
            get { return _User; }
            set { _User = value; }
        }
    }
    
}
         
        