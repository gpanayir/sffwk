using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Wizard
{
    public partial class wizTablesTreeSelector : wizBase
    {
        
        public wizTablesTreeSelector()
        {
            InitializeComponent();
        }

        public void Populate(CnnString pCnn)
        {
            this.ctrlTreeViewTables1.Populate(pCnn);
        }

        public void Populate()
        { }

    }
}
