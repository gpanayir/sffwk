using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Drawing;
using WindowsLogViewer.Properties;
using Fwk.HelperFunctions;
namespace WindowsLogViewer
{
    public class EventLog
    {
        public EventLog(System.Diagnostics.EventLogEntry pEventLogEntry, string pAuditMachineName)
        {
            _Message = pEventLogEntry.Message;

            _EntryType = pEventLogEntry.EntryType;
            _Source = pEventLogEntry.Source;

            _MachineName = pEventLogEntry.MachineName;
            _TimeGenerated = pEventLogEntry.TimeGenerated;
            _TimeWritten = pEventLogEntry.TimeWritten;

            _AuditMachineName = pAuditMachineName;

            _UserName = pEventLogEntry.UserName;

            _Category = pEventLogEntry.Category;
            _EventID = pEventLogEntry.InstanceId;
            _Index = pEventLogEntry.Index;

        }
        public EventLog()
        { }




  

        #region [Private Members]
        string _AuditMachineName;

        WindowsLogsType? _WinLog;
        int _Index;

        private System.String _Message;

        private System.Int64? _EventID;

        private System.String _Category;

        private System.String _MachineName;

        private System.String _Source;

        private System.DateTime? _TimeWritten;

        private System.DateTime? _TimeGenerated;

        private System.String _UserName;

        System.Diagnostics.EventLogEntryType? _EntryType;
        Guid _EventGuid;

        

        #endregion

        #region [Properties]

        public Guid EventGuid
        {
            get { return _EventGuid; }
            set { _EventGuid = value; }
        }

        #region [Message]
        public System.String Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        #endregion
        public Image EventImage
        {
            get { return GetImage(); }

        }

        #region [EventID]
        public System.Int64? EventID
        {
            get { return _EventID; }
            set { _EventID = value; }
        }
        #endregion


        #region [Category]
        public System.String Category
        {
            get { return _Category; }
            set { _Category = value; }
        }
        #endregion


        #region [MachineName]
        public System.String MachineName
        {
            get { return _MachineName; }
            set { _MachineName = value; }
        }
        #endregion


        #region [Source]
        public System.String Source
        {
            get { return _Source; }
            set { _Source = value; }
        }
        #endregion


        #region [TimeWritten]
        public System.DateTime? TimeWritten
        {
            get { return _TimeWritten; }
            set { _TimeWritten = value; }
        }
        #endregion


        #region [TimeGenerated]
        public System.DateTime? TimeGenerated
        {
            get { return _TimeGenerated; }
            set { _TimeGenerated = value; }
        }
        #endregion


        #region [UserName]
        public System.String UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        #endregion


        #region [EventLogEntryType]
        public EventLogEntryType? EntryType
        {
            get { return _EntryType; }
            set { _EntryType = value; }
        }
        #endregion

        public WindowsLogsType? WinLog
        {
            get { return _WinLog; }
            set { _WinLog = value; }
        }

        public string AuditMachineName
        {
            get { return _AuditMachineName; }
            set { _AuditMachineName = value; }
        }
        public int Index
        {
            get { return _Index; }
            set { _Index = value; }
        }

        #endregion

        Image GetImage()
        {
            switch (_EntryType)
            {
                case EventLogEntryType.Error:
                case EventLogEntryType.FailureAudit:
                    {
                        return (Image)Resources.error_16;

                    }
                case EventLogEntryType.Information:
                case EventLogEntryType.SuccessAudit:
                    {
                        return (Image)Resources.info;

                    }
                case EventLogEntryType.Warning:
                    {
                        return (Image)Resources.warning_16;

                    }


            }
            return null;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            if (!string.IsNullOrEmpty(_AuditMachineName))
                str.Append(string.Concat(_AuditMachineName, ":"));

            if (_WinLog != null)
                str.Append(string.Concat(_WinLog, ":"));

            if (_EntryType != null)
                str.Append(string.Concat(_EntryType, ":"));


            if (_EventID != null)
                str.Append(string.Concat(" event Id:",_EventID));

            if (!string.IsNullOrEmpty(_MachineName))
                str.Append(string.Concat(" PC:", _MachineName));


            if (!string.IsNullOrEmpty(_UserName))
                str.Append(string.Concat(" user:", _UserName));

            if (!string.IsNullOrEmpty(_Category))
                str.Append(string.Concat(" category:", _Category));


            if (!string.IsNullOrEmpty(_Source))
                str.Append(string.Concat(" source:", _Source));




            return str.ToString();
        }

        public string GetId()
        {
            StringBuilder str = new StringBuilder();
            if (!string.IsNullOrEmpty(_AuditMachineName))
                str.Append(string.Concat(_AuditMachineName, ":"));

            if (_WinLog != null)
                str.Append(string.Concat(_WinLog, ":"));

            if (_EntryType != null)
                str.Append(string.Concat(_EntryType, ":"));


            if (_EventID != null)
                str.Append(string.Concat( _EventID,":"));

            if (!string.IsNullOrEmpty(_MachineName))
                str.Append(string.Concat( _MachineName,":"));


            if (!string.IsNullOrEmpty(_UserName))
                str.Append(string.Concat(_UserName, ":"));

            if (!string.IsNullOrEmpty(_Category))
                str.Append(string.Concat(_Category, ":"));

            if (!string.IsNullOrEmpty(_Source))
                str.Append(string.Concat(_Source, ":"));


            if (!string.IsNullOrEmpty(_Source))
                str.Append(string.Concat(_Source, ":"));

            if (!string.IsNullOrEmpty(_Source))
                str.Append(string.Concat(_TimeWritten, ":"));
           
            return str.ToString();
        }


       
    }


    public class EventLogFilter
    {
        public EventLogFilter(System.Diagnostics.EventLogEntry pEventLogEntry, string pAuditMachineName)
        {
            _Message = pEventLogEntry.Message;

            _EntryType = pEventLogEntry.EntryType;
            _Source = pEventLogEntry.Source;

            _MachineName = pEventLogEntry.MachineName;
            _TimeGenerated = pEventLogEntry.TimeGenerated;
            _TimeWritten = pEventLogEntry.TimeWritten;

            _AuditMachineName = pAuditMachineName;

            _UserName = pEventLogEntry.UserName;

            _Category = pEventLogEntry.Category;
            _EventID.Add(pEventLogEntry.InstanceId);
            _Index = pEventLogEntry.Index;

        }
        public EventLogFilter()
        { }






        #region [Private Members]
        string _AuditMachineName;

        WindowsLogsType? _WinLog;
        int _Index;

        private System.String _Message;

        private List<System.Int64> _EventID = new List<long> ();

        private System.String _Category;

        private System.String _MachineName;

        private System.String _Source;

        private System.DateTime? _TimeWritten;

        private System.DateTime? _TimeGenerated;

        private System.String _UserName;

        System.Diagnostics.EventLogEntryType? _EntryType;


        #endregion

        #region [Properties]
        #region [Message]
        public System.String Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        #endregion
        public Image EventImage
        {
            get { return GetImage(); }

        }

        #region [EventID]
        public List<System.Int64> EventID
        {
            get { return _EventID; }
            set { _EventID = value; }
        }
        #endregion


        #region [Category]
        public System.String Category
        {
            get { return _Category; }
            set { _Category = value; }
        }
        #endregion


        #region [MachineName]
        public System.String MachineName
        {
            get { return _MachineName; }
            set { _MachineName = value; }
        }
        #endregion


        #region [Source]
        public System.String Source
        {
            get { return _Source; }
            set { _Source = value; }
        }
        #endregion


        #region [TimeWritten]
        public System.DateTime? TimeWritten
        {
            get { return _TimeWritten; }
            set { _TimeWritten = value; }
        }
        #endregion


        #region [TimeGenerated]
        public System.DateTime? TimeGenerated
        {
            get { return _TimeGenerated; }
            set { _TimeGenerated = value; }
        }
        #endregion


        #region [UserName]
        public System.String UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        #endregion


        #region [EventLogEntryType]
        public EventLogEntryType? EntryType
        {
            get { return _EntryType; }
            set { _EntryType = value; }
        }
        #endregion

        public WindowsLogsType? WinLog
        {
            get { return _WinLog; }
            set { _WinLog = value; }
        }

        public string AuditMachineName
        {
            get { return _AuditMachineName; }
            set { _AuditMachineName = value; }
        }
        public int Index
        {
            get { return _Index; }
            set { _Index = value; }
        }

        #endregion

        Image GetImage()
        {
            switch (_EntryType)
            {
                case EventLogEntryType.Error:
                case EventLogEntryType.FailureAudit:
                    {
                        return (Image)Resources.error_16;

                    }
                case EventLogEntryType.Information:
                case EventLogEntryType.SuccessAudit:
                    {
                        return (Image)Resources.info;

                    }
                case EventLogEntryType.Warning:
                    {
                        return (Image)Resources.warning_16;

                    }


            }
            return null;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            if (!string.IsNullOrEmpty(_AuditMachineName))
                str.Append(string.Concat(_AuditMachineName, ":"));

            if (_WinLog != null)
                str.Append(string.Concat(_WinLog, ":"));

            if (_EntryType != null)
                str.Append(string.Concat(_EntryType, ":"));


            if (_EventID != null)
                str.Append(string.Concat(" event Id:", string.Concat(FormatFunctions.GetStringBuilderWhitSeparator<Int64>(_EventID, ','), ":")));

            if (!string.IsNullOrEmpty(_MachineName))
                str.Append(string.Concat(" PC:", _MachineName));


            if (!string.IsNullOrEmpty(_UserName))
                str.Append(string.Concat(" user:", _UserName));

            if (!string.IsNullOrEmpty(_Category))
                str.Append(string.Concat(" category:", _Category));


            if (!string.IsNullOrEmpty(_Source))
                str.Append(string.Concat(" source:", _Source));

            if (_TimeGenerated != null)
                str.Append(string.Concat(string.Format("{0:dd-MM-yyy}", _TimeGenerated.Value), ":"));



            return str.ToString();
        }

        public string GetId()
        {
            StringBuilder str = new StringBuilder();
            if (!string.IsNullOrEmpty(_AuditMachineName))
                str.Append(string.Concat(_AuditMachineName, ":"));

            if (_WinLog != null)
                str.Append(string.Concat(_WinLog, ":"));

            if (_EntryType != null)
                str.Append(string.Concat(_EntryType, ":"));


            if (_EventID.Count > 0)
                str.Append(string.Concat(FormatFunctions.GetStringBuilderWhitSeparator<Int64>(_EventID, ','), ":"));

            if (!string.IsNullOrEmpty(_MachineName))
                str.Append(string.Concat(_MachineName, ":"));


            if (!string.IsNullOrEmpty(_UserName))
                str.Append(string.Concat(_UserName, ":"));

            if (!string.IsNullOrEmpty(_Category))
                str.Append(string.Concat(_Category, ":"));

            if (!string.IsNullOrEmpty(_Source))
                str.Append(string.Concat(_Source, ":"));


            if (_TimeGenerated != null)
                str.Append(string.Concat(string.Format("{0:dd-MM-yyy}", _TimeGenerated.Value), ":"));



            return str.ToString();
        }

        public void FillEventId(string[] stringArray)
        {
            _EventID.Clear();
            foreach (string s in stringArray)
            {
                if (!string.IsNullOrEmpty(s))
                {
                    _EventID.Add(Convert.ToInt64(s));
                }
            }
        }


    }

    public enum WindowsLogsType
    { 
            Application,
            ODiag,
            InternetExplorer,
            OSession,
            Security,
            System,
            TuneUp
    }
}





