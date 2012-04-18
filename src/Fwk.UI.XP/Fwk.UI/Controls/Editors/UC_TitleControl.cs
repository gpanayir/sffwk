using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Fwk.UI.Controls
{
    public partial class UC_TitleControl : DevExpress.XtraEditors.XtraUserControl
    {
        [Category("Fwk.Factory")]
        public Image Image
        {
            get { return this.pictureBox1.Image; }
            set { this.pictureBox1.Image = value; }
        }
        [Category("Fwk.Factory")]
        public Boolean IconVisible
        {
            get { return this.pictureBox1.Visible; }
            set { this.pictureBox1.Visible = value; }
        }
        [Category("Fwk.Factory")]
        public String TitleText
        {
            get { return this.lblTitle.Text; }
            set { this.lblTitle.Text = value; }
        }
        [Category("Fwk.Factory")]
        public Color TitleForeColor
        {
            get { return this.lblTitle.ForeColor; }
            set { this.lblTitle.ForeColor = value; }
        }
        [Category("Fwk.Factory")]
        public Font TitleFont
        {
            get { return this.lblTitle.Font; }
            set { this.lblTitle.Font = value; }
        }
        public UC_TitleControl()
        {
            InitializeComponent();
        }

    }
}
