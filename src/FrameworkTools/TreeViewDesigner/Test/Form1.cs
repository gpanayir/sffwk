using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Fwk.Tools.TreeView.FRM_MainDevExpress frm = new Fwk.Tools.TreeView.FRM_MainDevExpress();
            frm.imageList2 = this.imageList2;
            frm.ShowDialog();
        }
    }
}
