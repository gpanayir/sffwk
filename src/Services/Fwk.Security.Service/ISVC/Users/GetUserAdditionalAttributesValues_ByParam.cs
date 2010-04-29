using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using System.Xml;
using Fwk.Security.BE;

namespace Fwk.Security.ISVC.GetUserAdditionalAttributesValues
{
    [Serializable]
    public class GetUserAdditionalAttributesValues_ByParamRequest : Request<Param>
    {
        public GetUserAdditionalAttributesValues_ByParamRequest()
        {
            this.ServiceName = "GetUserAdditionalAttributesValues_ByParamService";
        }
    }

    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    { 
        private Int32? _UserId;
        private Int32? _UserAttributeId;
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
		public Int32? UserAttributeId
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
		public Int32? UserId
		{
			get
			{
				return _UserId;
			}
			set
			{
				_UserId = value;
			}
		}
    
    }



    [Serializable]
    public class GetUserAdditionalAttributesValues_ByParamResponse : Response<Result>
    {

    }


    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {

        private UserAdditionalAttributesValuesBEList _AttributesValuesBEList;

        public UserAdditionalAttributesValuesBEList AttributesValues
        {
            get
            {
                return _AttributesValuesBEList;
            }
            set
            {
                _AttributesValuesBEList = value;
            }
        }

    }
}