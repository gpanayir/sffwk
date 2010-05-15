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
namespace WindowsLogViewer
{
    public class EventLog
    {
        public EventLog(System.Diagnostics.EventLogEntry pEventLogEntry)
        {
            _Message = pEventLogEntry.Message;

            _EntryType = pEventLogEntry.EntryType;
            _Source = pEventLogEntry.Source;

            _MachineName = pEventLogEntry.MachineName;
            _TimeGenerated = pEventLogEntry.TimeGenerated;
            _TimeWritten = pEventLogEntry.TimeWritten;
            _MachineName = pEventLogEntry.MachineName;

            _UserName = pEventLogEntry.UserName;

            _Category = pEventLogEntry.Category;
            //_EventID = pEventLogEntry.EventID;
            _Index = pEventLogEntry.Index;

        }
        public EventLog()
        { }




        public Image EventImage
        {
            get { return GetImage(); }

        }

        #region [Private Members]
        string _AuditMachineName;

        WindowsLogsType? _WinLog;
        int _Index;

        private System.String _Message;

        private System.Int32? _EventID;

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


        #region [EventID]
        public System.Int32? EventID
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





