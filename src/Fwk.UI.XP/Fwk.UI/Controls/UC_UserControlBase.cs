using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using System.Security.Principal;
using System.Web.Security;
using Fwk.UI.Forms;

namespace Fwk.UI.Controls
{

    /// <summary>
    /// User control base. Este componente base se utiliza como herencia de componentes de negocio (bussiness views) en los casos de uso
    /// </summary>
    [ToolboxItem(false)]
    public partial class UC_UserControlBase : DevExpress.XtraEditors.XtraUserControl
    {
        #region Properties
        private Button _acceptButton;
        private Button _cancelButton;

        public event EventHandler<EventArgs> AcceptEvent;
        public event EventHandler<EventArgs> CancelEvent;

        [Browsable(true)]
        public Button AcceptButton
        {
            get { return _acceptButton; }
            set { _acceptButton = value; }
        }

        [Browsable(true)]
        public Button CancelButton
        {
            get { return _cancelButton; }
            set { _cancelButton = value; }
        }
        #endregion

        public UC_UserControlBase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method is called during message preprocessing to handle command keys. 
        /// Command keys are keys that always take precedence over regular input keys
        /// The ProcessCmdKey method first determines whether the control has a ContextMenu, 
        /// and if so, enables the ContextMenu to process the command key. If the command key is not a menu shortcut and the control has a parent, 
        /// the key is passed to the parent's ProcessCmdKey method. The net effect is that command keys are "bubbled" up the control hierarchy. 
        /// In addition to the key the user pressed, the key data also indicates which, if any, 
        /// modifier keys were pressed at the same time as the key. Modifier keys include the SHIFT, CTRL, and ALT keys.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (msg.WParam.ToInt32() == (int)Keys.Enter)
            {
                OnAcceptEvent(EventArgs.Empty);

                if (_acceptButton != null)
                    _acceptButton.PerformClick();
            }

            if (msg.WParam.ToInt32() == (int)Keys.Escape)
            {
                OnCancelEvent(EventArgs.Empty);

                if (_cancelButton != null)
                    _cancelButton.PerformClick();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected virtual void OnAcceptEvent(EventArgs args)
        {
            if (AcceptEvent != null)
                AcceptEvent(this, args);
        }

        protected virtual void OnCancelEvent(EventArgs args)
        {
            if (CancelEvent != null)
                CancelEvent(this, args);
        }

        /// <summary>
        ///  Establece el MessageViewer a sus valores por defecto (inforamcion y boton OK)
        /// </summary>
        protected void SetMessageViewInfoDefault()
        {
            MessageViewer.MessageBoxIcon = Fwk.UI.Common.MessageBoxIcon.Information;
            MessageViewer.MessageBoxButtons = MessageBoxButtons.OK;
        }

        #region Authorization Factory

        //public static  void InitAuthorizationFactory()
        //{            
        //    //FormBase.InitAuthorizationFactory();
        //}

        /// <summary>
        /// intenta autorizar el usuario registrado para la regla pasada por parametrio
        /// </summary>
        /// <param name="pRuleName">Nombre de la regla</param>
        /// <returns></returns>
        public static bool CheckRule(string pRuleName)
        {
            return FormBase.CheckRule(pRuleName);
        }
        #endregion
    }
}