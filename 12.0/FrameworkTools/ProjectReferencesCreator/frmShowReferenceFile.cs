using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectReferencesCreator
{
    public partial class frmShowReferenceFile : Form
    {
        ReferenceFile _Reference;
        public frmShowReferenceFile(ReferenceFile pReference)
        {
            InitializeComponent();
            _Reference = pReference;
        }
        public frmShowReferenceFile()
        {
            InitializeComponent();
        }

        private void frmShowReferenceFile_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = _Reference;
        }

    }
}
