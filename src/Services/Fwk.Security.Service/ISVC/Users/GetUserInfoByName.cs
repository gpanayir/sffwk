using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Fwk.Security.Common;
using System.Data.SqlClient;

namespace Fwk.Security.ISVC.GetUserInfoByName
{
    [Serializable]
    public class GetUserInfoByNameRequest : Request<Params>
    {
        public GetUserInfoByNameRequest()
        {
            this.ServiceName = "GetUserInfoByName";
        }
    }

    [Serializable]
    public class Params : Entity
    {
        /// <summary>
        /// No utilizado para la llamada al servicio solo se pone
        /// por que se debe utilizar si o si una clase en el request.
        /// </summary>
        public string Name;
        private List<SqlParameter> _CustomParameters;
        private String _CustomStoredProcedure;
        
        public List<SqlParameter> CustomParameters
        {
            get { return _CustomParameters; }
            set { _CustomParameters = value; }
        }        

        public String CustomStoredProcedure
        {
            get { return _CustomStoredProcedure; }
            set { _CustomStoredProcedure = value; }
        }

    }


    [Serializable]
    public class GetUserInfoByNameResponse : Response<Result>
    { }

    public class Result : Entity
    {
        private System.Data.DataSet _UserCustomInfo;
        private Fwk.Security.Common.RolList _RolList;
        private User _UserInfo;


		public User UserInfo
		{
			get
			{
				return _UserInfo;
			}
			set
			{
				_UserInfo = value;
			}
		}

		public Fwk.Security.Common.RolList RolList
		{
			get
			{
				return _RolList;
			}
			set
			{
				_RolList = value;
			}
		}

        public System.Data.DataSet UserCustomInfo
		{
			get
			{
                return _UserCustomInfo;
			}
			set
			{
                _UserCustomInfo = value;
			}
		}
    
    }
}

