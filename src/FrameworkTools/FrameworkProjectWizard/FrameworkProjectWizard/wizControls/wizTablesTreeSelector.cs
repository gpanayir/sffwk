using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;

namespace Fwk.Wizard
{
    public partial class wizTablesTreeSelector : wizBase
    {
        Table _SelectedTable;

        public Table SelectedTable
        {
            get { return ctrlTreeViewTables1.SelectedTable; }
           
        }

        public wizTablesTreeSelector()
        {
            InitializeComponent();
        }

        public void Populate(CnnString pCnn)
        {
            this.ctrlTreeViewTables1.Populate(pCnn);
        }

       
       

        private void btnOk_Click(object sender, EventArgs e)
        {
            base.DoEvent(ctrlTreeViewTables1.SelectedTable, WizardBotoon.Ok);
        }

      

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DoEvent(null, WizardBotoon.Cancel);
        }

       

        private void btnBack_Click(object sender, EventArgs e)
        {
            base.DoEvent(null, WizardBotoon.Back);
        }

    }
}
