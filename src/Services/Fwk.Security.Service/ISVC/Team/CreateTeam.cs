
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
using Fwk.Bases;
using System.Xml.Serialization;

namespace Fwk.Security.ISVC.CreateTeam
{
    [Serializable]
    public class CreateTeamRequest : Request<TeamBEList>
    {
        public CreateTeamRequest()
        {
            this.ServiceName = "CreateTeamService";
        }
    }

    #region [BussinesData]

    [XmlRoot("TeamBEList"), SerializableAttribute]
    public class TeamBEList : Entities<TeamBE> { }

    [XmlInclude(typeof(TeamBE)), Serializable]
    public class TeamBE : Entity
    {
        private System.String _OrdenDeRegistros;
        private System.Int32? _TeamId;
        private System.Int32? _SuperiorId;
        private System.Int32? _UserId;
        private System.DateTime? _StartDate;
        private System.DateTime? _EndDate;
        private System.String _TeamName;
        private System.Boolean? _ActiveFlag;
        private System.Int32? _TeamLevel;

        #region [OrdenDeRegistros]
        [XmlElement(ElementName = "OrdenDeRegistros", DataType = "string")]
        public System.String OrdenDeRegistros
        {
            get { return _OrdenDeRegistros; }
            set { _OrdenDeRegistros = value; }
        }
        #endregion
        #region [TeamId]
        [XmlElement(ElementName = "TeamId", DataType = "int")]
        public System.Int32? TeamId
        {
            get { return _TeamId; }
            set { _TeamId = value; }
        }
        #endregion
        #region [SuperiorId]
        [XmlElement(ElementName = "SuperiorId", DataType = "int")]
        public System.Int32? SuperiorId
        {
            get { return _SuperiorId; }
            set { _SuperiorId = value; }
        }
        #endregion
        #region [UserId]
        [XmlElement(ElementName = "UserId", DataType = "int")]
        public System.Int32? UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
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
        #region [TeamName]
        [XmlElement(ElementName = "TeamName", DataType = "string")]
        public System.String TeamName
        {
            get { return _TeamName; }
            set { _TeamName = value; }
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
        #region [TeamLevel]
        [XmlElement(ElementName = "TeamLevel", DataType = "int")]
        public System.Int32? TeamLevel
        {
            get { return _TeamLevel; }
            set { _TeamLevel = value; }
        }
        #endregion

        /// <summary>
        /// Metodo estatico que retorna un objeto Team_gBE apartir de un xml.-
        /// </summary>
        /// <param name="pXml">String con el xml</param>
        /// <returns>Team_gBE</returns>
        public static TeamBE GetTeamBEFromXml(String pXml)
        {
            return (TeamBE)Entity.GetObjectFromXml(typeof(TeamBE), pXml);
        }
    }

    #endregion



    [Serializable]
    public class CreateTeamResponse : Response<Result>
    {
    }

    [Serializable]
    public class Result : Entity
    {
        BE.TeamBEList mTeamBEList;

        public BE.TeamBEList TeamBEList
        {
            get { return mTeamBEList; }
            set { mTeamBEList = value; }
        }
    }
}