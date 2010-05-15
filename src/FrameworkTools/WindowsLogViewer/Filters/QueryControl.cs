using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WindowsLogViewer
{
    public partial class QueryControl : XtraUserControl
    {
        public event EventHandler MessageSelected;
        public event EventHandler CloseEventLog;
        Filter _Filter;

        public Filter Filter
        {
            get { return _Filter; }
            set { _Filter = value; }
        }
        public QueryControl()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private void btnRefilter_Click(object sender, EventArgs e)
        {
            using (frmFilter frm = new frmFilter(false))
            {
                frm.Populate(_Filter);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                   _Filter= frm.Filter;
                    Populate(_Filter);
                }
            }
        }


        public void Populate(Filter pFilter)
        {
            _Filter = pFilter;
            eventLogBindingSource.DataSource = LogDAC.SearchByParam(_Filter.EventLog, null);

            gridControl1.RefreshDataSource();
            gridView1.RefreshData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseEventLog(this, new EventArgs());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Populate(_Filter);
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
          
            EventLog l  = (EventLog)((System.Windows.Forms.BindingSource)gridControl1.DataSource).Current;
            if(l!= null)
            {
                MessageSelected(l, new EventArgs());
            }
        }
    }
}
