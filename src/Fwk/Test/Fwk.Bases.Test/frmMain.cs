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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (frmEntitiesTest frm = new frmEntitiesTest ())
            { frm.ShowDialog(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (frmEntityFromXmlWhitAttributes frm = new frmEntityFromXmlWhitAttributes())
            { frm.ShowDialog(); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (frmUndoRedoEntitiesTest frm = new frmUndoRedoEntitiesTest())
            { frm.ShowDialog(); }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            using (frmHelperFunctions frm = new frmHelperFunctions())
            { frm.ShowDialog(); }

        }

        private void btnExeptions_Click(object sender, EventArgs e)
        {
            using (frmException frm = new frmException())
            { frm.ShowDialog(); }
        }
    }
}
