using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using DevExpress.XtraEditors;

namespace WindowsLogViewer
{
    public partial class frmQuery : XtraForm
    {
        public frmQuery()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            using (frmFilter frm = new frmFilter())
            {
               // frm.Populate(null);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    frmMain.UserProfile.Filters.Add(frm.GetFilter());
                    Add_FilterControl(frm.GetFilter());
                }
            }
        }


        void Add_FilterControl(Filter pFilter)
        {
            tabControl1.TabPages.Add(pFilter.Name, pFilter.Name);
            QueryControl wQueryControl = new QueryControl();
            wQueryControl.MessageSelected += new EventHandler(wQueryControl_MessageSelected);
            wQueryControl.CloseEventLog += new EventHandler(wQueryControl_CloseEventLog);
            tabControl1.TabPages[pFilter.Name].Controls.Add(wQueryControl);
     
            wQueryControl.Dock = System.Windows.Forms.DockStyle.Fill;
            try
            {
                wQueryControl.Populate(pFilter);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Remove_AuditControl(wQueryControl, false);
                return;
            }
            tabControl1.SelectedTab = tabControl1.TabPages[tabControl1.TabPages.Count - 1];
        }

        void wQueryControl_CloseEventLog(object sender, EventArgs e)
        {
            Remove_AuditControl(((QueryControl)sender), true);
        }

        void wQueryControl_MessageSelected(object sender, EventArgs e)
        {
            txtMsg.Text = ((EventLog)sender).Message;
        }

        void Remove_AuditControl(QueryControl pQueryControl, bool asck)
        {
            if (asck)
                if (MessageBox.Show("Remove and this filter ?", "Windows event logs", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

            frmMain.UserProfile.Filters.Remove(pQueryControl.Filter);

            TabPage wTabPage = tabControl1.TabPages[pQueryControl.Filter.Name];
            wTabPage.Controls.Remove(pQueryControl);
            tabControl1.TabPages.Remove(wTabPage);


            Fwk.HelperFunctions.FileFunctions.SaveTextFile("Profile.xml", frmMain.UserProfile.GetXml(), false);
        }

      

        private void frmQuery_Load(object sender, EventArgs e)
        {
            foreach (Filter f in frmMain.UserProfile.Filters)
            {
                Add_FilterControl(f);
            }
        }
    }
}
