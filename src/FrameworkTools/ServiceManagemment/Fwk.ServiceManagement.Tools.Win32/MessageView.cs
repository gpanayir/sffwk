using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fwk.ServiceManagement.Tools.Win32
{
    public partial class MessageView : Form
    {

        /// <summary>
        /// Mensage a mostraR
        /// </summary>
        public string Message
        {

            set { txtMessage.Text = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool BtnOkVisible
        {
            set { btnOk.Visible = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool BtnCancelVisible
        {
            set { btnCancel.Visible = value; }
        }
       
        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public MessageView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pMessage"></param>
        /// <param name="pTitle"></param>
        /// <param name="pMessageBoxButtons"></param>
        /// <returns></returns>
        public static DialogResult Show(String pMessage,String pTitle, MessageBoxButtons pMessageBoxButtons)
        {
            
            
            using (MessageView wfrmMessageView = new MessageView())
            {
                wfrmMessageView.Text = pTitle;
                wfrmMessageView.Message = pMessage;
                switch (pMessageBoxButtons)
                {
                    case MessageBoxButtons.OK:
                        {
                            wfrmMessageView.BtnOkVisible = true;
                            break;
                        }
                    case MessageBoxButtons.OKCancel:
                        {
                            wfrmMessageView.BtnOkVisible = true;
                            wfrmMessageView.BtnCancelVisible = true;
                            break;
                        }
                }

                wfrmMessageView.ShowDialog();

                return wfrmMessageView.DialogResult;
            }
        }
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
    }
}