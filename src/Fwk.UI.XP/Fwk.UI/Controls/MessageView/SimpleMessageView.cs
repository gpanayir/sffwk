using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Fwk.UI.Common;


namespace Fwk.UI.Controls
{
    public partial class SimpleMessageView : MessageBase
    {
        public SimpleMessageView()
        {
            InitializeComponent();
        }

        #region [Properties]
        private Fwk.UI.Common.MessageBoxIcon _MessageBoxIcon = Fwk.UI.Common.MessageBoxIcon.Information;

        [CategoryAttribute("Fwk.Factory"), Description("Tipo de icono a mostrar")]
        public Fwk.UI.Common.MessageBoxIcon MessageBoxIcon
        {
            get { return _MessageBoxIcon; }
            set
            {
                _MessageBoxIcon = value;
                imgIcon.Image = MessageViewHelper.GetMessageBoxIcon(_MessageBoxIcon, _IconSize);
            }
        }


        [CategoryAttribute("Fwk.Factory"), Description("Icono a mostrar")]
        public Image MessageIcon
        {
            get { return imgIcon.Image; }
        }
        IconSize _IconSize = IconSize.Small;

        /// <summary>
        /// Tama�o del icono
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("Tama�o del icono"), DefaultValue(IconSize.Small)]
        public IconSize IconSize
        {
            get { return _IconSize; }
            set
            {
                _IconSize = value;
                if (_MessageBoxIcon == Fwk.UI.Common.MessageBoxIcon.None)
                    imgIcon.Image = null;
                else
                    imgIcon.Image = MessageViewHelper.GetMessageBoxIcon(_MessageBoxIcon, _IconSize);
            }
        }
        /// <summary>
        ///Color del texbox
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("")]
        public Color TextMessageColor
        {
            set { lblMessage.BackColor = value; }
            get { return lblMessage.BackColor; }
        }

        /// <summary>
        ///Color de texto del Mensaje
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("")]
        public Color TextMessageForeColor
        {
            set { lblMessage.ForeColor = value; }
            get { return lblMessage.ForeColor; }
        }
        /// <summary>
        /// Mensaje a mostrar
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("")]
        public override string Message
        {
            set { lblMessage.Text = value;}
            get { return lblMessage.Text;}
        }
        /// <summary>
        /// 
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("")]
        public bool BtnYesNoVisible
        {
            set
            {
                btnYes.Visible = value;
                btnNo.Visible = value;
                btnOk.Visible = !value;
                
            }
            get {
                return btnYes.Visible; 

            }
        }
       
        #endregion


        /// <summary>
        /// Muestra el Mensaje
        /// </summary>
        /// <param name="pMessage">Mensaje a mostrar</param>
        /// <param name="pMessageBoxButtons">Specifies constants defining which buttons to display on a System.Windows.Forms.MessageBox.</param>
        /// <param name="MessageBoxIcon">Specifies constants defining which information to display.</param>
        /// <returns>DialogResult</returns>
        public static DialogResult Show(String pMessage, String pTitle, MessageBoxButtons pMessageBoxButtons, Fwk.UI.Common.MessageBoxIcon pIcon)
        {
            using (SimpleMessageView wfrmMessageView = new SimpleMessageView())
            {
                wfrmMessageView.Text = pTitle;
                wfrmMessageView.Message = pMessage;
                wfrmMessageView.MessageBoxIcon = pIcon;
                wfrmMessageView.SetButtonsVisibility(pMessageBoxButtons);

                wfrmMessageView.ShowDialog();

                return wfrmMessageView.DialogResult;
            }
        }
        /// <summary>
        /// Muestra el Mensaje
        /// </summary>
        /// <param name="pMessage">Mensaje a mostrar</param>
        /// <param name="pMessageBoxButtons">Specifies constants defining which buttons to display on a System.Windows.Forms.MessageBox.</param>
        /// <param name="MessageBoxIcon">Specifies constants defining which information to display.</param>
        /// <returns>DialogResult</returns>
        public static DialogResult Show(Exception e, String pTitle, MessageBoxButtons pMessageBoxButtons, Fwk.UI.Common.MessageBoxIcon? pIcon)
        {
            using (SimpleMessageView wfrmMessageView = new SimpleMessageView())
            {
                wfrmMessageView.Text = pTitle;
                wfrmMessageView.Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e);

                if (pIcon == null)
                    pIcon = Fwk.UI.Common.MessageBoxIcon.Error;

                wfrmMessageView.MessageBoxIcon = pIcon.Value;
                wfrmMessageView.SetButtonsVisibility(pMessageBoxButtons);
                wfrmMessageView.ShowDialog();

                return wfrmMessageView.DialogResult;
            }
        }
        public void SetButtonsVisibility(MessageBoxButtons pMessageBoxButtons)
        {
            switch (pMessageBoxButtons)
            {
                case MessageBoxButtons.OK:
                    {
                        this.BtnYesNoVisible = false;
                        break;
                    }
               
                case MessageBoxButtons.YesNo:
                    {
                        this.BtnYesNoVisible = true;
                        break;
                    }
            }
        }
       

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        

    }
}