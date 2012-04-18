using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Fwk.UI.Common;

namespace Fwk.UI.Test
{
    public partial class MessageTest : DevExpress.XtraEditors.XtraForm
    {
        public MessageTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d =  simpleMessageViewComponent1.Show(textBox1.Text);
            MessageBox.Show(d.ToString());
            //SimpleMessageView.Show(textBox1.Text, "Test fwk ui libs", MessageBoxButtons.OK, Fwk.UI.Common.MessageBoxIcon.Error);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            messageViewerComponent1.Show(textBox1.Text);
        }
    }
}