using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsLogViewer
{
    public partial class frmNewLog : Form
    {

        public string WinLog
        {
            get { return comboBox1.Text; ; }
            
        }

        public string AuditMachineName
        {
            get { return textBox1.Text; }
   
        } 
        public frmNewLog()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;

            //textBox1.AutoCompleteCustomSource = 
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
