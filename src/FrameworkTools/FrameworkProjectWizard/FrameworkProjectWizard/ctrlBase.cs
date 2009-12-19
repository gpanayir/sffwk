using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Wizard
{
    public delegate void OnWizardFinalizeHandler(object arg, WizartBotoon result);
    [DefaultEvent("OnWizardFinalizeEvent")]
    public partial class ctrlWizBase : UserControl
    {

        public bool Button_OK_Visible
        {
            get {return  btnOk.Visible; }
            set { btnOk.Visible = value; }
        }
        public bool Button_Next_Visible
        {
            get { return btnNext.Visible; }
            set { btnNext.Visible = value; }
        }
        public bool Button_Cancel_Visible
        {
            get { return btnCancel.Visible; }
            set { btnCancel.Visible = value; }
        }
        public bool Button_Back_Visible
        {
            get { return btnBack.Visible; }
            set { btnBack.Visible = value; }
        }
        public event OnWizardFinalizeHandler OnWizardFinalizeEvent;
        public void DoEvent(object o, WizartBotoon r)
        {
            if (OnWizardFinalizeEvent != null)
                OnWizardFinalizeEvent(o,r);
        }
        public ctrlWizBase()
        {
            InitializeComponent();
        }
    }
}
