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
                   _Filter= frm.GetFilter();
                    Populate(_Filter);
                }
            }
        }

        List<EventLog> evenList;
        public void Populate(Filter pFilter)
        {
            _Filter = pFilter;
            evenList = LogDAC.SearchByParam(_Filter.EventLog, null);
            eventLogBindingSource.DataSource = evenList;
            lblStatus.Text = evenList.Count().ToString();
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

        private void btnClear_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (MessageBox.Show("Are you sure you wont to remove all logs from database ", "Windows event logs", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                   LogDAC.Delete(evenList);
                Populate(_Filter);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
