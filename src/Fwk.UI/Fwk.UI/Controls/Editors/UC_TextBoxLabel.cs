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
    [ToolboxItem(true)]
    [Designer(typeof(Designers.FwkControlDesigner))]
    public partial class UC_TextBoxLabel : DevExpress.XtraEditors.XtraUserControl
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
            get
            {

                
                return this.pictureBox1.Visible;

            }
            set {

                SetIconVisible(value);
                this.pictureBox1.Visible = value; 
            }
        }

        private void SetIconVisible(bool value)
        {
            if (value)
                lblTitle.Left = pictureBox1.Width + 2;
            else
                lblTitle.Left = pictureBox1.Location.X;

        }
       
        [Category("Fwk.Factory")]
        public Color CaptionForeColor
        {
            get { return this.lblTitle.ForeColor; }
            set { this.lblTitle.ForeColor = value; }
        }
        [Category("Fwk.Factory")]
        public Font CaptionFont
        {
            get { return this.lblTitle.Font; }
            set { this.lblTitle.Font = value; }
        }


        [Category("Fwk.Factory")]
        public Label CaptionControl
        {
            get { return this.lblTitle; }
            set { this.lblTitle = value; }
        }

        [Category("Fwk.Factory")]
        public Fwk.UI.Controls.TextBox TextBoxControl
        {
            get { return this.TextBoxCtrl; }
            set { this.TextBoxCtrl = value; }
        }
        [Category("Fwk.Factory")]
        public string Caption
        {
            get { return this.lblTitle.Text   ; }
            set { this.lblTitle.Text = value; }
        }
       


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Browsable(false)]
        public Panel WorkingArea_Control
        {
            get
            {
                return this.Control_workingArea;
            }
        }
        public UC_TextBoxLabel()
        {
            InitializeComponent();
        }

       
    }
}
