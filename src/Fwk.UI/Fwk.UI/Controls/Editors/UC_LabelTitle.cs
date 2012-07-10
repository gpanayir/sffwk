using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;


namespace Fwk.UI.Controls
{
    [Designer(typeof(Designers.FwkControlDesigner))]
    public partial class UC_LabelTitle : DevExpress.XtraEditors.XtraUserControl
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

        [Category("Fwk.Factory")]
        public  Color TitleBackColor
        {
            get { return this.lblTitle.BackColor; }
            set { 
                this.lblTitle.BackColor = value;
                this.BackColor = value;
            }
        }

        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        //public LabelControl Working_LabelControl
        //{
        //    get { return this.lblTitle; }
        //    set { this.lblTitle = value; }
        //}
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PictureBox Working_Image
        {
            get { return this.pictureBox1; }
            set { this.pictureBox1 = value; }
        }
        public UC_LabelTitle()
        {
            InitializeComponent();
        }

    }
}
