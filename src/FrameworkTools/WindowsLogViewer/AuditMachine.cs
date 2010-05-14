using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Fwk.Bases;

namespace WindowsLogViewer
{
    [XmlInclude(typeof(AuditMachine)), Serializable]
    public  class AuditMachine :Fwk.Bases.Entity
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
    public class AuditMachineList : Entities<AuditMachine>
    {
    }
}
