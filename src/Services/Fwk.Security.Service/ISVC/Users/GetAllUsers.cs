using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using Fwk.Security.BE;
using System.Data;
using Fwk.Security.Common;
using System.Data.SqlClient;


namespace Fwk.Security.ISVC.GetAllUsers
{

    [Serializable]
    public class GetAllUsersReq : Request<Param>
    {
        public GetAllUsersReq()
        {
            this.ServiceName = "GetAllUsersService";
        }
    }

    #region [BussinesData]



    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {
        private List<SqlParameter> _CustomParameters;
        private String _CustomStoredProcedure;

        
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


    #endregion


    [Serializable]
    public class GetAllUsersRes : Response<Result>
    {

    }

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {
        private UserList _UserList;        
        private DataSet _UsersCustom;

		public DataSet UsersCustom
		{
			get
			{
				return _UsersCustom;
			}
			set
			{
				_UsersCustom = value;
			}
		}

        public UserList UserList
        {
            get { return _UserList; }
            set { _UserList = value; }
        }
    }
}
        