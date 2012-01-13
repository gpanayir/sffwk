using System;
using System.Windows.Forms;
using Fwk.UI.Common;
using Fwk.UI.Forms;


namespace Fwk.UI.Security
{
    public partial class FRM_RoleNew : FormDialogBase
    {
        public string _RolName;
        private bool _IsLoading;
        private bool _RoleExists;

        public bool RoleExists
        {
            get { return _RoleExists; }
            set { _RoleExists = value; }
        }

        public FRM_RoleNew()
        {
            InitializeComponent();
        }

        void AceptForm()
        {
            try
            {
                    // Se validan todos los controles hijos, que implementen el metodo validating
                    if (uC_RoleNew1.ValidateChildren(ValidationConstraints.Enabled))
                    {
                        using (new WaitCursorHelper(this))
                        {
                            uC_RoleNew1.CreateNewRole();
                            _RolName = uC_RoleNew1.RolName;
                            _RoleExists = uC_RoleNew1.RoleExists;
                        }
                    }

            }
            catch (Exception ex)
            {
                base.MessageViewer.Show(ex);
            }

        }



        private void aceptCancelButtonBar1_ClickOkCancelEvent(object sender, DialogResult result)
        {
            if (result == DialogResult.OK)
            {
                AceptForm();
                this.DialogResult = result;
            }

            else
            {
                this.DialogResult = result;
                this.Close();
            }
        }

        private void FRM_RoleNew_Load(object sender, EventArgs e)
        {
            _IsLoading = true;
        }

        private void aceptCancelButtonBar1_Enter(object sender, EventArgs e)
        {
            if (_IsLoading)
            {
                uC_RoleNew1.SetFocus();
                _IsLoading = false;
            }
        }

    }
}
