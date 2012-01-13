using System;
using System.Windows.Forms;
using Fwk.UI.Common;
using Fwk.UI.Controls;
using Fwk.UI.Security.Controls;
using Fwk.UI.Forms;
using Fwk.Security.Common;

namespace Fwk.UI.Security
{

    public partial class FRM_UserNew : FormDialogBase
    {

        bool _IsPopulate;

        public FRM_UserNew()
        {
            InitializeComponent();
        }


        void Save()
        {
            try
            {
                // Se validan todos los controles hijos, que implementen el metodo validating
                if (uC_UserNew1.ValidateChildren(ValidationConstraints.ImmediateChildren | ValidationConstraints.Enabled))
                {

                    using (new Fwk.UI.Common.WaitCursorHelper(this))
                    {

                        if (uC_UserNew1.Action == ActionTypes.Create)
                        {
                            // Se guardan los cambios del usuario
                            if (!uC_UserNew1.CreateUser())
                                return;
                            
                            MessageViewer.MessageBoxButtons = MessageBoxButtons.YesNo;
                            MessageViewer.MessageBoxIcon = Fwk.UI.Common.MessageBoxIcon.Question;

                            // Se pregunta si se desea crear otro usuario, entonces se carga nuevamente el control,
                            // caso contrario se cierra el formulario
                            if (MessageViewer.Show(string.Concat(String.Format(Properties.Resources.security_UserCreatedMessage,
                                uC_UserNew1.UsersBE.UserName), Environment.NewLine, "¿Desea crear otro usuario?")) == DialogResult.Yes)
                            {
                                base.SetMessageViewInfoDefault();

                                
                                
                                //Volvemos a cargar la pantalla de usuarios
                                uC_UserNew1.Populate(null, ActionTypes.Create);
                            }
                            else
                            {
                                // no se desea crear otro usuario, se cierra el formulario
                                base.SetMessageViewInfoDefault();
                                Close();
                            }
                        }

                        if (uC_UserNew1.Action == ActionTypes.Edit)
                        {
                            //Se actualizaron los datos del usuario
                            if (!uC_UserNew1.UpdateUser())
                                return;
                            //Se guardan los atributos adicionales
                            

                            MessageViewer.Show(String.Format(Properties.Resources.security_UserUpdatedMessage, uC_UserNew1.UsersBE.UserName));

                            //Se cambio el this.Close() por la linea de abajo ya que se podia volver a guardar los cambios de edición y daba error.
                            this.Close();
                            //this.aceptCancelButtonBar1.CancelButtonText = "Salir";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageViewer.Show(ex);
            }
        }


        internal void Populate(User pUsersBE, Fwk.UI.Common.ActionTypes pAction)
        {
            _IsPopulate = true;
            uC_UserNew1.Populate(pUsersBE, pAction);

            
                xtraTabPage2.PageEnabled = false; 
        }


        private void aceptCancelButtonBar1_ClickOkCancelEvent(object sender, DialogResult result)
        {
            if (result == DialogResult.OK)
                Save();
            else
            {
                //Removemos los controles a mano porque da error
                RemoveControls();
                Close();
            }
        }

        private void RemoveControls()
        {
            foreach (Control wControl in uC_UserNew1.Controls)
            {
                uC_UserNew1.Controls.Remove(wControl);
            }
        }

        private void aceptCancelButtonBar1_Enter(object sender, EventArgs e)
        {
            if (_IsPopulate)
            {
                uC_UserNew1.TextUserFirstName.Focus();
                _IsPopulate = false;
            }
        }

        private void UserNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            RemoveControls();
        }


    }
}

