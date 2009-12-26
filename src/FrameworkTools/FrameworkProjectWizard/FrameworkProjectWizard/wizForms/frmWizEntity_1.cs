using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Wizard;

namespace Fwk.Wizard
{
    public partial class frmWizEntity_1 : frmWizBase
    {
        public frmWizEntity_1()
        {
            InitializeComponent();
        }

       

        private void wizDBSelect1_OnWizardFinalizeEvent(object arg, WizardBotoon result)
        {
            if (result == WizardBotoon.Next)
            { 
                using(frmWizEntity_2 frm = new frmWizEntity_2 (wizDBSelect1.Cnn))
                {
                    frm.ShowDialog();
                }
            }
        }

    }
}