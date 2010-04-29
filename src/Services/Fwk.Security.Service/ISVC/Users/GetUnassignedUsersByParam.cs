using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using System.Xml;
using Fwk.Security.BE;


namespace Fwk.Security.ISVC.GetUnassignedUsersByParam
{
    [Serializable]
    public class GetUnassignedUsersByParamRequest : Request<UsersBE>
    {
        public GetUnassignedUsersByParamRequest()
        {
            this.ServiceName = "GetUnassignedUsersByParamService";
        }
    }

    [XmlInclude(typeof(UsersBE)), Serializable]
    public class UsersBE : Entity
    {
        #region [Private Members]

        private System.Int32? mi_UserId;
        private System.String msz_Name;
        private System.String msz_Mail;
        private System.String msz_Password;
        private System.String _PasswordQuestion;
        private System.String _Answer;

        private System.Boolean? _ActiveFlag;
        private System.DateTime? _StartDate;
        private System.DateTime? _ModifiedDate;
        private System.Int32? _ModifiedByUserId;

        private System.Boolean? _IsApproved;
        private System.Boolean? _IsLockedOut;
        private System.String _FirstName;
        private System.String _LastName;
        private System.String _DNI;
        // Tipo de busqueda que se utilizara por defecto
        Fwk.Bases.Enums.SearchtypeEnum _SearchtypeName = Fwk.Bases.Enums.SearchtypeEnum.Equal;       

        #endregion

        #region [Properties]
        public System.String DNI
        {
            get { return _DNI; }
            set { _DNI = value; }
        }
        #region [UserId]
        [XmlElement(ElementName = "UserId", DataType = "int")]
        public System.Int32? UserId
        {
            get { return mi_UserId; }
            set { mi_UserId = value; }
        }
        #endregion

        #region [Name]
        [XmlElement(ElementName = "Name", DataType = "string")]
        public System.String Name
        {
            get { return msz_Name; }
            set { msz_Name = value; }
        }
        #endregion

        #region [ActiveFlag]
        [XmlElement(ElementName = "ActiveFlag", DataType = "boolean")]
        public System.Boolean? ActiveFlag
        {
            get { return _ActiveFlag; }
            set { _ActiveFlag = value; }
        }
        #endregion

        #region [ModifiedDate]
        [XmlElement(ElementName = "ModifiedDate", DataType = "dateTime")]
        public System.DateTime? ModifiedDate
        {
            get { return _ModifiedDate; }
            set { _ModifiedDate = value; }
        }
        #endregion

        #region [CreatedDate]
        [XmlElement(ElementName = "CreatedDate", DataType = "dateTime")]
        public System.DateTime? StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; }
        }
        #endregion

        #region [ModifiedByUserId]

        public System.Int32? ModifiedByUserId
        {
            get { return _ModifiedByUserId; }
            set { _ModifiedByUserId = value; }
        }
        #endregion

      

        #region [Password]
        [XmlElement(ElementName = "Password", DataType = "string")]
        public System.String Password
        {
            get { return msz_Password; }
            set { msz_Password = value; }
        }
        #endregion

        #region [Mail]
        [XmlElement(ElementName = "Mail", DataType = "string")]
        public System.String Mail
        {
            get { return msz_Mail; }
            set { msz_Mail = value; }
        }
        #endregion

        #region [PasswordQuestion]
        [XmlElement(ElementName = "PasswordQuestion", DataType = "string")]
        public System.String PasswordQuestion
        {
            get { return _PasswordQuestion; }
            set { _PasswordQuestion = value; }
        }
        #endregion

        #region [Answer]
        [XmlElement(ElementName = "Answer", DataType = "string")]
        public System.String Answer
        {
            get { return _Answer; }
            set { _Answer = value; }
        }
        #endregion

        #region [IsApproved]

        public System.Boolean? IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
        }
        #endregion
        #region [IsLockedOut]
        public System.Boolean? IsLockedOut
        {
            get { return _IsLockedOut; }
            set { _IsLockedOut = value; }
        }
        #endregion

        #region [FirstName]
        [XmlElement(ElementName = "FirstName", DataType = "string")]
        public System.String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        #endregion

        #region [LastName]
        [XmlElement(ElementName = "LastName", DataType = "string")]
        public System.String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        #endregion


        [XmlIgnore]
        public System.String FullName
        {
            get { return string.Concat(_FirstName, ", ", _LastName); }

        }

        public Fwk.Bases.Enums.SearchtypeEnum SearchtypeName
        {
            get { return _SearchtypeName; }
            set { _SearchtypeName = value; }
        }
        #endregion


    }

    [Serializable]
    public class GetUnassignedUsersByParamResponse : Response<BE.UsersBEList>
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
