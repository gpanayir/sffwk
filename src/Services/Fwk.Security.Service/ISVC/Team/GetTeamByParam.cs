
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a Prominente Code Generator.
//     Runtime Version:1.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//
//</auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Fwk;
using Fwk.Bases;
using System.Xml.Serialization;

namespace Fwk.Security.ISVC.GetTeamByParam
{

    [Serializable]
    public class GetTeamByParamRequest : Request<TeamBE>
    {
        public GetTeamByParamRequest()
        {
            this.ServiceName = "GetTeamByParamService";
        }
    }


    [XmlInclude(typeof(TeamBE)), Serializable]
    public class TeamBE : Entity
    {

        private System.String _OrdenDeRegistros;

        private System.DateTime? _StartDate;
        private System.DateTime? _EndDate;

        private System.Boolean? _ActiveFlag;
        private System.String _FirstName;
        private System.String _LastName;
        private System.String _UserName;
        
        // Tipo de busqueda que se utilizara por defecto
        Fwk.Bases.Enums.SearchtypeEnum _Searchtype = Fwk.Bases.Enums.SearchtypeEnum.Equal;

        public Fwk.Bases.Enums.SearchtypeEnum SearchtypeEnum
        {
            get { return _Searchtype; }
            set { _Searchtype = value; }
        }

        #region [OrdenDeRegistros]
        [XmlElement(ElementName = "OrdenDeRegistros", DataType = "string")]
        public System.String OrdenDeRegistros
        {
            get { return _OrdenDeRegistros; }
            set { _OrdenDeRegistros = value; }
        }
        #endregion


        #region [StartDate]
        [XmlElement(ElementName = "StartDate", DataType = "dateTime")]
        public System.DateTime? StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; }
        }
        #endregion
        #region [EndDate]
        [XmlElement(ElementName = "EndDate", DataType = "dateTime")]
        public System.DateTime? EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
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

        #region [UserName]
        [XmlElement(ElementName = "UserName", DataType = "string")]
        public System.String UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        #endregion

        /// <summary>
        /// Metodo estatico que retorna un objeto Team_gBE apartir de un xml.-
        /// </summary>
        /// <param name="pXml">String con el xml</param>
        /// <returns>Team_gBE</returns>
        public static TeamBE GetTeamBEFromXml(String pXml)
        {
            return Entity.GetFromXml<TeamBE>(pXml);
        }


    }




    [Serializable]
    public class GetTeamByParamResponse : Response<BE.TeamBEList>
    {
        BE.TeamBEList _TeamBEList;

        [XmlElement(ElementName = "TeamBEList", DataType = "TeamBEList")]
        public BE.TeamBEList TeamBEList
        {
            get { return _TeamBEList; }
            set { _TeamBEList = value; }
        }
    }


    /*
    [XmlRoot("Result"), SerializableAttribute]
    public class Result : Entity
    {
        BE.TeamBEList _TeamBEList;

        [XmlElement(ElementName = "TeamBEList", DataType = "TeamBEList")]
        public BE.TeamBEList TeamBEList
        {
            get { return _TeamBEList; }
            set { _TeamBEList = value; }
        }
        
        BE.UsersBEList _UsersBEList;

        [XmlElement(ElementName = "UsersBEList", DataType = "UsersBEList")]
        public BE.UsersBEList UsersBEList
        {
            get { return _UsersBEList; }
            set { _UsersBEList = value; }
        }
        */

}
