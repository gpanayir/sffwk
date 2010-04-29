using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using System.Xml;
using Fwk.Security.BE;

namespace Fwk.Security.ISVC.UserAdditionalAttributesValues_Exist_ByUserAttributeId
{
    [Serializable]
    public class UserAdditionalAttributesValues_Exist_ByUserAttributeIdRequest : Request<Param>
    {
        public UserAdditionalAttributesValues_Exist_ByUserAttributeIdRequest()
        {
            this.ServiceName = "UserAdditionalAttributesValues_Exist_ByUserAttributeIdService";
        }
    }

    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {
        private Int32 _UserAttributeId;


        public Int32 UserAttributeId
        {
            get
            {
                return _UserAttributeId;
            }
            set
            {
                _UserAttributeId = value;
            }
        }

    }
    [Serializable]
    public class UserAdditionalAttributesValues_Exist_ByUserAttributeIdResponse : Response<Result>
    {

    }


    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {

        private Boolean _ExistAttributeValue;

        public Boolean ExistAttributeValue
        {
            get
            {
                return _ExistAttributeValue;
            }
            set
            {
                _ExistAttributeValue = value;
            }
        }

    }
}
