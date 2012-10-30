using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Bases.Test
{
    public partial class frmException : Form
    {
        public frmException()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "Hoa {0} hoy es un gran {1}";
            

            Fwk.Exceptions.FunctionalException fw = new Fwk.Exceptions.FunctionalException(null, "RecordSetsNull","ValidationExceptionMessage", new string[] { "parametro 1", "parametro 2" });
            fw.ConfigProviderName = "localFile";
            
            MessageBox.Show(fw.Message);
        }
    }
}
