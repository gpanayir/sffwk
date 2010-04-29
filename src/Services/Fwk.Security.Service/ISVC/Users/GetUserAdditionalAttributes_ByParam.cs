using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using System.Xml;
using Fwk.Security.BE;

namespace Fwk.Security.ISVC.GetUserAdditionalAttributes_ByParam
{
    [Serializable]
    public class GetUserAdditionalAttributes_ByParamRequest : Request<Param>
    {
        public GetUserAdditionalAttributes_ByParamRequest()
        {
            this.ServiceName = "GetUserAdditionalAttributes_ByParamService";
        }
    }

    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    { 
        private Boolean? _ActiveFlag;
        
		public Boolean? ActiveFlag
		{
			get
			{
				return _ActiveFlag;
			}
			set
			{
				_ActiveFlag = value;
			}
		}
    
    }

    [Serializable]
    public class GetUserAdditionalAttributes_ByParamResponse : Response<Result>
    {

    }


    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {

        private UserAdditionalAttributesBEList _AdditionalAttributes;

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
}
