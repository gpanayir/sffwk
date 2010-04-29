using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;


namespace Fwk.Security.BE
{
    [XmlRoot("UserAdditionalAttributesBEList"), SerializableAttribute]
    public class UserAdditionalAttributesBEList : Entities<UserAdditionalAttributesBE>
    {

    }

    [XmlInclude(typeof(UserAdditionalAttributesBE)), Serializable]
    public class UserAdditionalAttributesBE : Entity
    {
        private Int32 _UserAttributeId;
        private String _Name;
        private DateTime _ModifiedDate;
        private Int32 _ModifiedByUserId;
        private Int32 _Order;
        private Boolean _Required;
        private Boolean _ActiveFlag;
        private EntityState _AttributesState;


		public EntityState AttributesState
		{
			get
			{
                return _AttributesState;
			}
			set
			{
                _AttributesState = value;
			}
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

        
        public Int32 ModifiedByUserId
        {
            get
            {
                return _ModifiedByUserId;
            }
            set
            {
                _ModifiedByUserId = value;
            }
        }

        
        public DateTime ModifiedDate
        {
            get
            {
                return _ModifiedDate;
            }
            set
            {
                _ModifiedDate = value;
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


    public enum AttributesUpdate
    {

        // Summary:
        //     Entity is unchanged
        Unchanged = 0,
        //
        // Summary:
        //     Entity is new
        Added = 1,
        //
        // Summary:
        //     Entity has been modified
        Changed = 2,
        //
        // Summary:
        //     Entity has been deleted
        Deleted = 3,
    }
}
