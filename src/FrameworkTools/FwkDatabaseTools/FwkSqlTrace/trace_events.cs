using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Fwk.Bases;

namespace FwkSqlTrace
{
    internal class sys_databases
    {

        string name;

        public int Name
        {
            get { return Name; }
            set { Name = value; }
        }
        int database_id;

        public int Database_id
        {
            get { return database_id; }
            set { database_id = value; }
        }
    }
    internal class trace_events
    { 

        int trace_event_id;

        public int Trace_event_id
        {
            get { return trace_event_id; }
            set { trace_event_id = value; }
        }
        int category_id;

        public int Category_id
        {
            get { return category_id; }
            set { category_id = value; }
        }
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }





    [XmlRoot("TraceViewList"), SerializableAttribute]
    public class TraceViewList : Entities<TraceView>
	{}

    [XmlInclude(typeof(TraceView)), Serializable]
	public class TraceView:Entity
	{
		#region [Private Members]
        private string _EventClassName;

       
        //private System.Int32 _RowNumber;

		private System.Int32? _EventClass;

		private System.String _TextData;

		private System.String _ApplicationName;

		private System.String _NTUserName;

		private System.String _LoginName;

		private System.Int32? _CPU;

		private System.Int32? _Reads;

		private System.Int32? _Writes;

		private long? _Duration;

		private System.Int32? _ClientProcessID;

		private System.Int32? _SPID;

		private System.DateTime? _StartTime;

		private System.DateTime? _EndTime;

        //private System.Byte[] _BinaryData;


		#endregion
		
		#region [Properties]
		#region [RowNumber]
        public string EventClassName
        {
            get { return _EventClassName; }
            set { _EventClassName = value; }
        }
        //public System.Int32 RowNumber
        //{
        //    get { return _RowNumber; }
        //    set { _RowNumber = value;}
        //}
		#endregion


		#region [EventClass]
		public System.Int32? EventClass
		{
			get { return _EventClass; }
			set { _EventClass = value;}
		}
		#endregion


		#region [TextData]
		public System.String TextData
		{
			get { return _TextData; }
			set { _TextData = value;}
		}
		#endregion


		#region [ApplicationName]
		public System.String ApplicationName
		{
			get { return _ApplicationName; }
			set { _ApplicationName = value;}
		}
		#endregion


		#region [NTUserName]
		public System.String NTUserName
		{
			get { return _NTUserName; }
			set { _NTUserName = value;}
		}
		#endregion


		#region [LoginName]
		public System.String LoginName
		{
			get { return _LoginName; }
			set { _LoginName = value;}
		}
		#endregion


		#region [CPU]
		public System.Int32? CPU
		{
			get { return _CPU; }
			set { _CPU = value;}
		}
		#endregion


		#region [Reads]
		public System.Int32? Reads
		{
			get { return _Reads; }
			set { _Reads = value;}
		}
		#endregion


		#region [Writes]
		public System.Int32? Writes
		{
			get { return _Writes; }
			set { _Writes = value;}
		}
		#endregion


		#region [Duration]
        public long? Duration
		{
			get { return _Duration; }
			set { _Duration = value;}
		}
		#endregion


		#region [ClientProcessID]
		public System.Int32? ClientProcessID
		{
			get { return _ClientProcessID; }
			set { _ClientProcessID = value;}
		}
		#endregion


		#region [SPID]
		public System.Int32? SPID
		{
			get { return _SPID; }
			set { _SPID = value;}
		}
		#endregion


		#region [StartTime]
		public System.DateTime? StartTime
		{
			get { return _StartTime; }
			set { _StartTime = value;}
		}
		#endregion


		#region [EndTime]
		public System.DateTime? EndTime
		{
			get { return _EndTime; }
			set { _EndTime = value;}
		}
		#endregion


		#region [BinaryData]
        //[System.Xml.Serialization.XmlElementAttribute("BinaryData",DataType = "[SCHEMATYPENAME]")]
        //public Byte[] BinaryData
        //{
        //    get { return _BinaryData; }
        //    set { _BinaryData = value;  }
        //}
		#endregion
		


		#endregion
		
	}
	

}



