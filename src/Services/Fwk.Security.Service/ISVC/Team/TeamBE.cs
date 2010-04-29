using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;



namespace Fwk.Security.BE
{
	[XmlRoot("TeamBEList"), SerializableAttribute]
	public class TeamBEList :Entities<TeamBE>
	{
		
		/// <summary>
		/// Metodo estatico que retorna un objeto Team_gList apartir de un xml.-
		/// </summary>
		/// <param name="pXml">String con el xml</param>
		/// <returns>Team_gList</returns>
        public static TeamBEList GetTeamBEListFromXml(String pXml)
		{
			return GetFromXml<TeamBEList>( pXml);
		}
		
	}
	
	[XmlInclude(typeof(TeamBE)), Serializable]
	public class TeamBE:Entity
	{
		
		private System.String _OrdenDeRegistros;
		private System.Int32? _TeamId;
		private System.Int32? _SuperiorId;
		private System.Int32? _UserId;
		private System.DateTime? _StartDate;
		private System.DateTime? _EndDate;
		private System.String _TeamName;
		private System.Boolean? _ActiveFlag;
        private System.String _UserName;
        private System.String _FirstName;
        private System.String _LastName;
        private System.DateTime? _StartDateUser;
        private EntityUpdateEnum _Estado = EntityUpdateEnum.NONE;
        private System.Int32? _TeamLevel;
        private System.Int32? _CantidadHijos;

						 
		public String FullName
		 {
			get
			{
                return String.Format("{0} {1}", _FirstName, _LastName);
			}
		 }

        public System.Int32? CantidadHijos
        {
            get { return _CantidadHijos; }
            set { _CantidadHijos = value; }
        }

        #region Estado
        public EntityUpdateEnum Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
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

        #region [OrdenDeRegistros]
        [XmlElement(ElementName = "OrdenDeRegistros", DataType = "string")]
		public System.String OrdenDeRegistros
		{
			get { return _OrdenDeRegistros; }
			set { _OrdenDeRegistros = value;  }
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
			set { _SuperiorId = value;  }
		}
		#endregion
		#region [UserId]
		[XmlElement(ElementName = "UserId", DataType = "int")]
		public System.Int32? UserId
		{
			get { return _UserId; }
			set { _UserId = value;  }
		}
		#endregion
		#region [StartDate]
		[XmlElement(ElementName = "StartDate", DataType = "dateTime")]
		public System.DateTime? StartDate
		{
			get { return _StartDate; }
			set { _StartDate = value;  }
		}
		#endregion

        #region [StartDateUser]
        [XmlElement(ElementName = "StartDateUser", DataType = "dateTime")]
        public System.DateTime? StartDateUser
        {
            get { return _StartDateUser; }
            set { _StartDateUser = value; }
        }
        #endregion
		#region [EndDate]
		[XmlElement(ElementName = "EndDate", DataType = "dateTime")]
		public System.DateTime? EndDate
		{
			get { return _EndDate; }
			set { _EndDate = value;  }
		}
		#endregion
		#region [TeamName]
		[XmlElement(ElementName = "TeamName", DataType = "string")]
		public System.String TeamName
		{
			get { return _TeamName; }
			set { _TeamName = value;  }
		}
		#endregion
		#region [ActiveFlag]
		[XmlElement(ElementName = "ActiveFlag", DataType = "boolean")]
		public System.Boolean? ActiveFlag
		{
			get { return _ActiveFlag; }
			set { _ActiveFlag = value;  }
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
        
        #region [UserName]
        [XmlElement(ElementName = "UserName", DataType = "string")]
        public System.String UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
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
		/// <summary>
		/// Metodo estatico que retorna un objeto Team_gBE apartir de un xml.-
		/// </summary>
		/// <param name="pXml">String con el xml</param>
		/// <returns>Team_gBE</returns>
		public static TeamBE GetTeamBEFromXml(String pXml)
		{
			return (TeamBE) Entity.GetObjectFromXml(typeof(TeamBE), pXml);
		}

		
	}
	
}