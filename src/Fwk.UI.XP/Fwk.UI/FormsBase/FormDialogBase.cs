using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fwk.UI.Forms
{
    /// <summary>
    /// Dialogo utilizado como base para todos los ABMs.
    /// Este formulario solo tiene configuraciones de como se debe mostrar .-
    /// 
    /// </summary>
    public partial class FormDialogBase : FormBase
    {
        public FormDialogBase()
        {
            InitializeComponent();
        }

        #region [Events]

        /// <summary>
        /// Evento lanzado cuando se presiona el botón Help del form.
        /// </summary>
        public event EventHandler HelpButtonClick;

        /// <summary>
        /// Metodo llamado cuando se desea lanzar el evento HelpButtonClick
        /// </summary>
        private void OnHelpButtonClick()
        {
            if (HelpButtonClick != null)
            {
                HelpButtonClick(this, new EventArgs());
            }
        }

        #endregion

        

        #region [Form Event Handling]



        /// <summary>
        /// Metodo llamado cuando se presiona el botón Help del form.
        /// </summary>
        private void ctlButtonBar_HelpButtonClick(object sender, EventArgs e)
        {
            OnHelpButtonClick();
        }



        #endregion

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
    
        }
    }

}
