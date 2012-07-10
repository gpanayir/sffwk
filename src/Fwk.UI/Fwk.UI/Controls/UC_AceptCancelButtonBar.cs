using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Fwk.UI.Common;
namespace Fwk.UI.Controls
{
    
    [ToolboxItem(true)]
    [DefaultEvent("ClickOkCancelEvent")]
    public partial class UC_AceptCancelButtonBar : XtraUserControl
    {
        /// <summary>
        /// Evento que se dispara al hacer click en cualquiera de los botones
        /// </summary>
        public event ClickOkCancelHandler ClickOkCancelEvent;

        //[Category("Fwk.Factory")]
        //public Image ButtonBarIcon
        //{
        //    get { return this.btnImage.Image; }
        //    set { this.btnImage.Image = value; }
        //}
        //[Category("Fwk.Factory")]
        //public Boolean IconVisible
        //{
        //    get { return this.btnImage.Visible; }
        //    set { this.btnImage.Visible = value; }
        //}
       
        [Category("Fwk.Factory")]
        public Boolean BottomsVisible
        {
            get { return this.btn_Acept.Visible; }
            set
            {
                this.btn_Acept.Visible = value;
                this.btn_Cancel.Visible = value;
            }
        }
        [Category("Fwk.Factory")]
        public bool CancelButtonVisible
        {
            get
            {
                return btn_Cancel.Visible;
            }
            set
            {
               
                btn_Cancel.Visible = value;
            }
        }
        [Category("Fwk.Factory")]
        public string CancelButtonText
        {
            get
            {
                return btn_Cancel.Text;
            }
            set
            {
            
                btn_Cancel.Text = value;
            }
        }
        [Category("Fwk.Factory")]
        public bool CancelButtonEnabled
        {
            get
            {
                return btn_Cancel.Enabled;
            }
            set
            {
               
                btn_Cancel.Enabled = value;
            }
        }
        [Category("Fwk.Factory")]
        public string AceptButtonText
        {
            get
            {
                return btn_Acept.Text;
            }
            set
            {
             
                btn_Acept.Text = value;
            }
        }
        [Category("Fwk.Factory")]
        public bool AceptButtonEnabled
        {
            get
            {
                return btn_Acept.Enabled;
            }
            set
            {
              
                btn_Acept.Enabled = value;
            }
        }
        [Category("Fwk.Factory")]
        public bool AceptButtonVisible
        {
            get
            {
                return btn_Acept.Visible;
            }
            set
            {
          
                btn_Acept.Visible = value;
            }
        }

 
        public UC_AceptCancelButtonBar()
        {
            InitializeComponent();
        }

     

        private void ButtonBase_Acept_Click(object sender, EventArgs e)
        {
            if (ClickOkCancelEvent != null)
                ClickOkCancelEvent(this, DialogResult.OK);
            
        }

        private void ButtonBase_Cancel_Click(object sender, EventArgs e)
        {
            if (ClickOkCancelEvent != null)
                ClickOkCancelEvent(this, DialogResult.Cancel);
        }

      

        private void btnHelp_Click(object sender, EventArgs e)
        {

        }
    }
}
