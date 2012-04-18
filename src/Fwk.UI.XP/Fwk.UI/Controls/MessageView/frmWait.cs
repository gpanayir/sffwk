using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Fwk.UI.Controls
{
    public partial class frmWait : MessageBase
    {
        [Browsable(false)]
        public override string Message
        {
            set { this.lblTitle.Text = value; }
            get { return this.lblTitle.Text; }
        } 
            
        
        public frmWait()
        {
            InitializeComponent();
        }
       
        
    }
}