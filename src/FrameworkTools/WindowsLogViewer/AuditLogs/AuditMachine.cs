using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Fwk.Bases;

namespace WindowsLogViewer
{
    [XmlInclude(typeof(AuditMachine)), Serializable]
    public class AuditMachine : Fwk.Bases.BaseEntity
    {
        public AuditMachine(string pWinlog, string pAuditMachineName)
        {
            _MachineName = pAuditMachineName;
            _WinLog = pWinlog;
        }

        public AuditMachine()
        {

        }

        string _MachineName;

        public string MachineName
        {
            get { return _MachineName; }
            set { _MachineName = value; }
        }

        string _WinLog;
        public string WinLog
        {
            get { return _WinLog; }
            set { _WinLog = value; }
        }
    }


    [XmlRoot("AuditMachineList"), SerializableAttribute]
    public class AuditMachineList : BaseEntities<AuditMachine>
    {
    }
    [XmlRoot("Filters"), SerializableAttribute]
    public class Filters : BaseEntities<Filter>
    {
    }
    [XmlInclude(typeof(Filter)), Serializable]
    public class Filter:BaseEntity
    {
        string _Name ;

        public string Name
        {
            get { return _EventLog.ToString(); }
        }


        public string Id
        {
            get { return _EventLog.GetId(); }
        }


        EventLog _EventLog = new EventLog ();

        public EventLog EventLog
        {
            get { return _EventLog; }
            set { _EventLog = value; }
        }

        

    }
    [XmlInclude(typeof(Profile)), Serializable]
    public class Profile : BaseEntity
    {
        //AuditMachineList _AuditMachineList = new AuditMachineList ();

        //public AuditMachineList AuditMachineList
        //{
        //    get { return _AuditMachineList; }
        //    set { _AuditMachineList = value; }
        
        //}


        Filters _AuditMachineList = new Filters();

        public Filters AuditMachineList
        {
            get { return _AuditMachineList; }
            set { _AuditMachineList = value; }
        }


        Filters _Filters = new Filters ();

        public Filters Filters
        {
            get { return _Filters; }
            set { _Filters = value; }
        }
    }
}

