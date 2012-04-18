using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Fwk.HelperFunctions;
using System.Drawing.Imaging;
using Fwk.UI.Controls.Menu;
using System.Drawing.Design;

namespace Fwk.Tools.Menu
{
   
    public partial class UC_PopupButtonEditor : UC_MenuItemEditor
    {
        
        private PopupButton _Button;
        private PopupButton _OriginalButton;

       
        
        public UC_PopupButtonEditor()
        {
            InitializeComponent();
        }
               
        private void ButtonBase3_Click(object sender, EventArgs e)
        {

            String file = Fwk.UI.Controls.Menu.Helper.OpenFile("(*.gif;*.jpg;*.jpeg;*.bmp;*.png)|*.gif;*.jpg;*.jpeg;*.bmp;*.png");

            if (string.IsNullOrEmpty(file))
            {
                return;
            }

            try
            {

                pctImage.Image = new Bitmap(file);
            }
            catch
            {
                MessageBox.Show("Error intentando abrir el archivo de la imagen", "Menu Designer", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectToLoad"></param>
        public void LoadControl(PopupButton objectToLoad)
        {
            _Button = objectToLoad;
            _OriginalButton =objectToLoad;

            buttonsBindingSource.DataSource = _Button;
            buttonsBindingSource.ResetBindings(true);

            if (_Button.Image == null)
            {
                pctImage.Image = null;
            }
            else
            {
                pctImage.Image = new Bitmap(new MemoryStream(_Button.Image));
            }

        }
        
       
        protected override void SaveModifications()
        {
            //_OriginalButton.BeginGroup = _Button.BeginGroup;
            _OriginalButton.Caption = _Button.Caption;
            _OriginalButton.Hint = _Button.Hint;
            _OriginalButton.Id = _Button.Id;
            if (pctImage.Image != null)
            {
                _OriginalButton.Image = TypeFunctions.ConvertImageToByteArray(pctImage.Image, ImageFormat.Png);
            }
            _OriginalButton.Shortcut = _Button.Shortcut;
            _OriginalButton.ToolTipText = _Button.ToolTipText;

            OnMenuItemSaved(new MenuItemSavedEventArgs(_OriginalButton));

        }

        protected override void CancelModifications()
        {
            //LoadControl(_originalButton);
        }
 

        
        private void buttonsBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            //OnEditorValueChanges();
        }

        private void txtId_EditValueChanged(object sender, EventArgs e)
        {

        }

    }
}
