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
    public partial class frmMain: XtraForm
    {


        public static Profile UserProfile = new Profile();
       
        public frmMain()
        {
            InitializeComponent();
            eventLog1.EnableRaisingEvents = true;
        }

       
       


      

        private void button2_Click(object sender, EventArgs e)
        {
            //LogDAC.Insert(_LogList, eventLog1.Log, eventLog1.MachineName);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            using (frmNewLog frm = new frmNewLog())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    AuditMachine wAuditMachine = new AuditMachine(frm.WinLog, frm.AuditMachineName);

                    if (UserProfile.AuditMachineList.Exists(p => p.WinLog.Equals(frm.WinLog) && p.MachineName.Equals(frm.AuditMachineName)))
                    {
                        MessageBox.Show("This log already exist.");
                        return;
                    }
                    UserProfile.AuditMachineList.Add(wAuditMachine);
                    Add_AuditControl(wAuditMachine);
                }
            }
        }

        void Add_AuditControl(AuditMachine pAuditMachine)
        {
            tabControl1.TabPages.Add(string.Concat(pAuditMachine.MachineName, "_", pAuditMachine.WinLog), string.Concat(pAuditMachine.MachineName, ": ", pAuditMachine.WinLog));
            AuditControl wAuditControl = new AuditControl();
            wAuditControl.MessageSelected += new EventHandler(wAuditControl_MessageSelected);
            wAuditControl.CloseEventLog += new EventHandler(wAuditControl_CloseEventLog);
            tabControl1.TabPages[string.Concat(pAuditMachine.MachineName, "_", pAuditMachine.WinLog)].Controls.Add(wAuditControl);
            wAuditControl.BackColor = System.Drawing.Color.White;
            wAuditControl.Dock = System.Windows.Forms.DockStyle.Fill;
            try
            {
                wAuditControl.Populate(pAuditMachine);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Remove_AuditControl(wAuditControl,false);
            }

            tabControl1.SelectedTab = tabControl1.TabPages[tabControl1.TabPages.Count-1];
            
        }
        void Remove_AuditControl(AuditControl pAuditControl,bool asck)
        {
            if (asck)
            if (MessageBox.Show("Remove and stop log this log ?", "Windows event logs", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            pAuditControl.MessageSelected -= new EventHandler(wAuditControl_MessageSelected);
            string k = string.Concat(pAuditControl.AuditMachine.MachineName, "_", pAuditControl.AuditMachine.WinLog);

            UserProfile.AuditMachineList.Remove(pAuditControl.AuditMachine);

            TabPage wTabPage = tabControl1.TabPages[k];
            wTabPage.Controls.Remove(pAuditControl);
            tabControl1.TabPages.Remove(wTabPage);


            Fwk.HelperFunctions.FileFunctions.SaveTextFile("AuditMachineList.xml", UserProfile.AuditMachineList.GetXml(), false);
        }
        void wAuditControl_CloseEventLog(object sender, EventArgs e)
        {
           
            Remove_AuditControl(((AuditControl)sender),true);
        }


        void wAuditControl_MessageSelected(object sender, EventArgs e)
        {
            txtMsg.Text = ((EventLogEntry)sender).Message;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists("Profile.xml"))
            {
                string filecontent = Fwk.HelperFunctions.FileFunctions.OpenTextFile("Profile.xml");

                UserProfile = Profile.GetFromXml<Profile>(filecontent);
                foreach (AuditMachine wAuditMachine in UserProfile.AuditMachineList)
                {
                    Add_AuditControl(wAuditMachine);
                }

            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Fwk.HelperFunctions.FileFunctions.SaveTextFile("Profile.xml", UserProfile.GetXml(), false);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            using (frmQuery frm = new frmQuery())
            {

                if (frm.ShowDialog() == DialogResult.OK)
                { }
            }
        }
    }
}
