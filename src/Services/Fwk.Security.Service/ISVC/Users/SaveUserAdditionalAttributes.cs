using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using System.Xml;
using Fwk.Security.BE;

namespace Fwk.Security.ISVC.SaveUserAdditionalAttributes
{
    [Serializable]
    public class SaveUserAdditionalAttributesRequest: Request<Param>
    {
        public SaveUserAdditionalAttributesRequest()
        {
            this.ServiceName = "SaveUserAdditionalAttributesService";
        }
    }


    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {

        private UserAdditionalAttributesBEList _AdditionalAttributes;


        [XmlElement(ElementName = "UserAdditionalAttributesBEList", DataType = "UserAdditionalAttributesBEList")]
        public UserAdditionalAttributesBEList AdditionalAttributes
        {
            get
            {
                return _AdditionalAttributes;
            }
            set
            {
                _AdditionalAttributes = value;
            }
        }

    }

    [Serializable]
    public class SaveUserAdditionalAttributesResponse : Response<Result>
    {

    }


    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {


    }
}
