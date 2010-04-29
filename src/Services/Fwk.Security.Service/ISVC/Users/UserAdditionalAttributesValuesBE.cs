using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;


namespace Fwk.Security.BE
{
    [XmlRoot("UserAdditionalAttributesValuesBEList"), SerializableAttribute]
    public class UserAdditionalAttributesValuesBEList : Entities<UserAdditionalAttributesValuesBE>
    {

    }

    [XmlInclude(typeof(UserAdditionalAttributesValuesBE)), Serializable]
    public class UserAdditionalAttributesValuesBE : Entity
    {
        private Int32 _UserAttributeId;
        private Int32 _UserId;
        private String _Value;
        private Int32 _Order;
        private Boolean _Required;
        private Boolean _ActiveFlag;
        private String _Name;



		public String Value
		{
			get
			{
				return _Value;
			}
			set
			{
				_Value = value;
			}
		}

        public Int32 UserAttributeId
        {
            get { return _UserAttributeId; }
            set { _UserAttributeId = value; }
        }

        public Int32 UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }

        public Boolean ActiveFlag
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
        
        public Boolean Required
        {
            get
            {
                return _Required;
            }
            set
            {
                _Required = value;
            }
        }
        
        public Int32 Order
        {
            get
            {
                return _Order;
            }
            set
            {
                _Order = value;
            }
        }

        public String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
    }
}
