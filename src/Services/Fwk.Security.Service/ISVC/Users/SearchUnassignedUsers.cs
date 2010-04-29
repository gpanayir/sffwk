using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using System.Xml;
using Fwk.Security.BE;

namespace Fwk.Security.ISVC.SearchUnassignedUsers
{
    [Serializable]
    public class SearchUnassignedUsersRequest : Request<Param>
    {
        public SearchUnassignedUsersRequest()
        {
            this.ServiceName = "SearchUnassignedUsersService";
        }
    }


    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {
        private string wDummy;

        public string WDummy
        {
            get { return wDummy; }
            set { wDummy = value; }
        }
    }
    [Serializable]
    public class SearchUnassignedUsersResponse : Response<BE.UsersBEList>
    {
        BE.UsersBEList _UsersBEList;

        [XmlElement(ElementName = "UsersBEList", DataType = "UsersBEList")]
        public BE.UsersBEList UsersBEList
        {
            get { return _UsersBEList; }
            set { _UsersBEList = value; }
        }
    }
}

