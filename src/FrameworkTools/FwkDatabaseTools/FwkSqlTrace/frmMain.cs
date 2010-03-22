using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.DataBase;

namespace FwkSqlTrace
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {

        CnnString _CnnString = new CnnString();
        List<Trace> _TraceList;
        public frmMain()
        {
            InitializeComponent();
        }

        void Init()
        {
            TraceDAL.Connection = _CnnString;
            _TraceList = TraceDAL.GetAll();
            traceBindingSource.DataSource = _TraceList;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (connictionFormComponent1.Show() == DialogResult.OK)
            {
                if (connictionFormComponent1.ConnectionOK)
                {
                    _CnnString = connictionFormComponent1.CnnString.Clone<CnnString>();
                }
            }
            Init();
        }
    }
}
