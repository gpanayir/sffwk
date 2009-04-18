using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Configuration.Test
{
    public partial class frmConfigurationTest : Form
    {
        public frmConfigurationTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = ConfigurationManager.GetProperty("RemoteProvider","ValidationExceptionMessage", "NullOrEmptyField");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();
            try
            {
                str.AppendLine("Provider 01 ");
                str.AppendLine(ConfigurationManager.GetProperty("ValidationExceptionMessage", "NullOrEmptyField"));
                str.AppendLine("Provider 02");
                str.AppendLine(ConfigurationManager.GetProperty("P2", "Config", "ApplicationServerWrapper"));

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

      

        }
    }
}