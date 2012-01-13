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
    public partial class LabelBase : LabelControl
    {

        [CategoryAttribute("Fwk.Factory"), Description("Indicates how the image is displayed.")]
        public System.Windows.Forms.PictureBoxSizeMode SizeMode
        {
            get { return this.pictureBox1.SizeMode; }
            set { this.pictureBox1.SizeMode = value; }
        }

        [CategoryAttribute("Fwk.Factory"), Description("Imagen a mostrar")]
        public Image Image
        {
            get { return this.pictureBox1.Image; }
            set { this.pictureBox1.Image = value; }
        }
        [CategoryAttribute("Fwk.Factory"), Description("Indica si se muestra la imagen")]
        public Boolean IconVisible
        {
            get { return this.pictureBox1.Visible; }
            set { this.pictureBox1.Visible = value; }
        }
        [CategoryAttribute("Fwk.Factory"), Description("Titulo")]
        public String Title
        {
            get { return this.lblTitle.Text; }
            set { this.lblTitle.Text = value; }
        }
        [CategoryAttribute("Fwk.Factory"), Description("Color del texto.-")]
        public Color TitleForeColor
        {
            get { return this.lblTitle.ForeColor; }
            set { this.lblTitle.ForeColor = value; }
        }
        [CategoryAttribute("Fwk.Factory"), Description("Fuente del texto")]
        public Font TitleFont
        {
            get { return this.lblTitle.Font; }
            set { this.lblTitle.Font = value; }
        }
        [CategoryAttribute("Fwk.Factory"), Description("")]
        public int SpaceBetweenImageAndText
        {
            get { return this.lblSep.Text.Length; }

            set
            {
                StringBuilder str = new StringBuilder();

                for (int i = 1; i <= value; i++)
                {
                    str.Append(" ");
                }
                this.lblSep.Text = str.ToString();
            }
        }
        public LabelBase()
        {
            InitializeComponent();
        }
    }
}
