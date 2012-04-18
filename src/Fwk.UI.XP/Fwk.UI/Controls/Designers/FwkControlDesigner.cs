
// ******************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.Design;
using System.Drawing;
using System.ComponentModel;

namespace Fwk.UI.Controls.Designers
{
    public class FwkControlDesigner : ParentControlDesigner
    {
        System.Windows.Forms.BorderStyle currentBorderStyle;
        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);


            if (this.Control is UC_TextFindContainer)
            {
                #region manejo los anchors de las areas debido a que en tiempo de dise�o cuando se usa el control los anchors se alteran

                ((UC_TextFindContainer)this.Control).WorkingArea_Find.Anchor =
            ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));

                ((UC_TextFindContainer)this.Control).WorkingArea_Control.Anchor =
                    ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));

                //((TextFindContainer)this.Control).btnSep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                //       | System.Windows.Forms.AnchorStyles.Right)));

                #endregion

                this.EnableDesignMode(((UC_TextFindContainer)this.Control).WorkingArea_Control, "WorkingArea_Control");
                this.EnableDesignMode(((UC_TextFindContainer)this.Control).WorkingArea_Find, "WorkingArea_Find");
            }



            if (this.Control is UC_LabelTitle)
            {
                //this.EnableDesignMode(((UC_ComboBoxLabel)this.Control).Working_LabelControl, "Working_LabelControl");
                this.EnableDesignMode(((UC_LabelTitle)this.Control).Working_Image, "Working_Image");
            }
            if (this.Component is UC_TextBoxLabel)
            {
                this.EnableDesignMode(((UC_TextBoxLabel)this.Control).WorkingArea_Control, "WorkingArea_Control");
            }
            currentBorderStyle = ((DevExpress.XtraEditors.XtraUserControl)this.Control).BorderStyle;
        }

        public override bool CanParent(System.Windows.Forms.Control control)
        {
            return control is System.Windows.Forms.Control;
        }

        public override bool CanParent(System.Windows.Forms.Design.ControlDesigner controlDesigner)
        {
            if (controlDesigner != null && controlDesigner.Control is System.Windows.Forms.Control)
            {
                return true;
            }
            return false;
        }
        protected override void OnMouseHover()
        {
            if (this.Component is UC_TextBoxLabel)
            {
                ((UC_TextBoxLabel)this.Control).WorkingArea_Control.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            }
            base.OnMouseHover();
        }

        protected override void OnMouseLeave()
        {
            if (this.Component is UC_TextBoxLabel)
            {
                ((UC_TextBoxLabel)this.Control).WorkingArea_Control.BorderStyle = currentBorderStyle;

            }
            base.OnMouseLeave();
        }
    }
}
