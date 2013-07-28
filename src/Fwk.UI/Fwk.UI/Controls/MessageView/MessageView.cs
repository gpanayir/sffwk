using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Fwk.UI.Common;
using System.Globalization;
using System.Threading;

namespace Fwk.UI.Controls
{

    public partial class MessageView : MessageBase
    {
        #region [Properties]
        private Fwk.UI.Common.MessageBoxIcon _MessageBoxIcon = Fwk.UI.Common.MessageBoxIcon.Information;

        [CategoryAttribute("Fwk.Factory"), Description("Tipo icono a mostrar")]
        public Fwk.UI.Common.MessageBoxIcon MessageBoxIcon
        {
            get { return _MessageBoxIcon; }
            set
            {
                _MessageBoxIcon = value;
                imgIcon.Image= MessageViewHelper.GetMessageBoxIcon(_MessageBoxIcon, _IconSize);
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
        [CategoryAttribute("Fwk.Factory"), Description("Tamaño del icono"), DefaultValue(IconSize.Small)]
        public Fwk.UI.Common.IconSize IconSize
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
            set { txtMessage.BackColor = value; }
            get { return txtMessage.BackColor; }
        }

        /// <summary>
        ///Color de texto del Mensaje
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("")]
        public Color TextMessageForeColor
        {
            set { txtMessage.ForeColor = value; }
            get { return txtMessage.ForeColor; }
        }
        /// <summary>
        /// Mensaje a mostraR
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("")]
        public override string Message
        {
            set { txtMessage.Text = value; }
            get { return txtMessage.Text; }
        }

        /// <summary>
        /// 
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("")]
        public bool BtnOkVisible
        {
            set { btnOk.Visible = value; }
            get { return btnOk.Visible; }
        }

        /// <summary>
        /// 
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("")]
        public bool BtnCancelVisible
        {
            set { btnCancel.Visible = value; }
            get { return btnCancel.Visible; }
        }
        /// <summary>
        /// 
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("")]
        public bool BtnYesVisible
        {
            set { btnYes.Visible = value; }
            get { return btnYes.Visible; }
        }
        /// <summary>
        /// 
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("")]
        public bool BtnNoVisible
        {
            set { btnNo.Visible = value; }
            get { return btnNo.Visible; }
        }

        #endregion

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        /// 
        public MessageView()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName);
             
            InitializeComponent();
        }
        /// <summary>
        /// Muestra el Mensaje
        /// </summary>
        /// <param name="pMessage">Mensaje a mostrar</param>
        /// <param name="pMessageBoxButtons">Specifies constants defining which buttons to display on a System.Windows.Forms.MessageBox.</param>
        /// <param name="MessageBoxIcon">Specifies constants defining which information to display.</param>
        /// <returns>DialogResult</returns>
        public static DialogResult Show(String pMessage, String pTitle,
            MessageBoxButtons pMessageBoxButtons, Fwk.UI.Common.MessageBoxIcon pIcon)
        {


            using (MessageView wfrmMessageView = new MessageView())
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
        public static DialogResult Show(Exception e, String pTitle,
            MessageBoxButtons pMessageBoxButtons, Fwk.UI.Common.MessageBoxIcon? pIcon)
        {


            using (MessageView wfrmMessageView = new MessageView())
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
            SetButtonsVisibleFalse();
            switch (pMessageBoxButtons)
            {
                case MessageBoxButtons.OK:
                    {
                        this.BtnOkVisible = true;
                        break;
                    }
                case MessageBoxButtons.OKCancel:
                    {
                        this.BtnOkVisible = true;
                        this.BtnCancelVisible = true;
                        break;
                    }
                case MessageBoxButtons.YesNo:
                    {
                        this.BtnYesVisible = true;
                        this.BtnNoVisible = true;
                        break;
                    }
                case MessageBoxButtons.YesNoCancel:
                    {
                        this.BtnYesVisible = true;
                        this.BtnNoVisible = true;
                        this.BtnCancelVisible = true;
                        break;
                    }
            }
        }

        #region btn -  events

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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

        private void SetButtonsVisibleFalse()
        {
            this.BtnOkVisible = false;
            this.BtnCancelVisible = false;
            this.BtnYesVisible = false;
            this.BtnNoVisible = false;

        }
        #endregion

       
    }
}