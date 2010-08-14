using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WindowsLogViewer
{
    public partial class frmNewLog : XtraForm
    {

        public Filters AuditMachines
        {
            get { return ctrlFilter1.Filters; }

        }

        public frmNewLog()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ctrlFilter1.RefreshFilters();
            if (ctrlFilter1.Filters == null) return;
            if (ctrlFilter1.Filters.Count == 0)
            {
                MessageBox.Show("El nombre del server no puede faltar ", "Windows event logs");
                return;
            }
            if (ctrlFilter1.Filters[0].EventLog.WinLog == null)
            {
                MessageBox.Show("Seleccione un log para uditar.-", "Windows event logs");
                return;
            }
            this.DialogResult =DialogResult.OK;
            this.Close();
        }

       
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
