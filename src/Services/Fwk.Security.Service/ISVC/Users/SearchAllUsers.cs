using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using Fwk.Security.BE;
using System.Data;
using Fwk.Security.Common;
using System.Data.SqlClient;


namespace Fwk.Security.ISVC.SearchPelsofters
{

    [Serializable]
    public class SearchPelsoftersReq : Request<DummyContract>
    {
        public SearchPelsoftersReq()
        {
            this.ServiceName = "SearchPelsoftersService";
        }
    }

  

    [Serializable]
    public class SearchPelsoftersRes : Response<Result>
    {

    }

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {
        private UserList _UserList;        
       
        public UserList UserList
        {
            get { return _UserList; }
            set { _UserList = value; }
        }
    }
}
        