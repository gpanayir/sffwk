using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using System.Xml;
using Fwk.Security.BE;

namespace Fwk.Security.ISVC.SaveUserAdditionalAttributesValues
{
    [Serializable]
    public class SaveUserAdditionalAttributesValuesRequest: Request<Param>
    {
        public SaveUserAdditionalAttributesValuesRequest()
        {
            this.ServiceName = "SaveUserAdditionalAttributesValuesService";
        }
    }


    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {

        private UserAdditionalAttributesValuesBEList _AdditionalAttributesValues;


        [XmlElement(ElementName = "UserAdditionalAttributesValuesBEList", DataType = "UserAdditionalAttributesValuesBEList")]
        public UserAdditionalAttributesValuesBEList AdditionalAttributesValues
        {
            get
            {
                return _AdditionalAttributesValues;
            }
            set
            {
                _AdditionalAttributesValues = value;
            }
        }

    }

    [Serializable]
    public class SaveUserAdditionalAttributesValuesResponse : Response<Result>
    {

    }


    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {


    }
}
