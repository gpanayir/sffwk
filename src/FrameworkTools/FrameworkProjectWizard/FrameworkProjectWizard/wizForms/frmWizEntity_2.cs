using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Wizard;
using Microsoft.SqlServer.Management.Smo;

namespace Fwk.Wizard
{
    public partial class frmWizEntity_2 : frmWizBase
    {
        public frmWizEntity_2()
        {
            InitializeComponent();
        }
        public frmWizEntity_2(CnnString Cnn)
        {
            InitializeComponent();
            wizTablesTreeSelector1.Populate(Cnn);
        }

        private void wizTablesTreeSelector1_OnWizardFinalizeEvent(object arg, WizardBotoon result)
        {
            if (result == WizardBotoon.Ok)
            {
                string gen = FwkGeneratorHelper.Gen_Entity((Table)arg);
            }

            if (result == WizardBotoon.Back)
            {
                this.Close();
            }
        }

    }
}
