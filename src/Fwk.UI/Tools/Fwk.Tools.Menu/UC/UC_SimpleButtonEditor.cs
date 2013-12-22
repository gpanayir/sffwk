using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Fwk.HelperFunctions;
using System.Drawing.Imaging;
using Fwk.UI.Forms;
using Fwk.UI.Security.Controls;
using Fwk.UI.Controls.Menu;
using Fwk.UI.Controls;
          
namespace Fwk.Tools.Menu
{
    [ToolboxItem(false)]
    public partial class UC_ButtonBaseEditor : UC_MenuItemEditor
    {
        private Fwk.UI.Controls.Menu.ButtonBase _CopyButton;
        private Fwk.UI.Controls.Menu.ButtonBase _OriginalButton;
        BarGroup _ParentGroup;


        public UC_ButtonBaseEditor()
        {
            InitializeComponent();
        }

        #region [Controls Event Handling]
        private void txtAssemblyInfo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Type[] filterTypes = new Type[] { typeof(FormBase), typeof(UC_UserControlBase) };

            FRM_AssemblyExplorer assemblyExplorer = new FRM_AssemblyExplorer(filterTypes);

            if (assemblyExplorer.ShowDialog() == DialogResult.OK)
            {
                txtAssemblyInfo.Text = assemblyExplorer.SelectedForm.AssemblyInfo;
                //((Button) editingObject).AssemblyInfo = assemblyExplorer.SelectedForm.AssemblyInfo;
            }
        }

        private void btnLoadIcon_Click(object sender, EventArgs e)
        {
            GetImage(pctSmallImage);

            _CopyButton.Image = TypeFunctions.ConvertImageToByteArray(pctSmallImage.Image, ImageFormat.Png);
        }

        private void btnLoadLargeImage_Click(object sender, EventArgs e)
        {
            GetImage(pctLargeImage);
            _CopyButton.LargeImage = TypeFunctions.ConvertImageToByteArray(pctLargeImage.Image, ImageFormat.Png);
        }
        void GetImage(DevExpress.XtraEditors.PictureEdit pctImage)
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
            catch(Exception ex)
            {
                this.ExceptionViewer.Show("Menu Designer",
                     "Error intentando abrir el archivo de la imagen",
                    Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex),false);
                                
            }
        }
        #endregion

        #region [Public Methods]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btn"></param>
        public override void LoadControl(Fwk.UI.Controls.Menu.MenuItemBase btn, object parent)
        {
            _ParentGroup = (BarGroup)parent;
            _OriginalButton = (Fwk.UI.Controls.Menu.ButtonBase)btn;
            _CopyButton = _OriginalButton.Clone<Fwk.UI.Controls.Menu.ButtonBase>();

            txtId.Text = _CopyButton.Id;
            txtCaption.Text = _CopyButton.Caption;
            txtToolTip.Text = _CopyButton.ToolTipText;
            txtAssemblyInfo.Text = _CopyButton.AssemblyInfo;
            txtShortCut.Text = _CopyButton.Shortcut;
            SetControlVisibility(btn);

            //grpImages.Enabled Significa que se trata de NavBarItem y NO TreeView
            if (grpImages.Enabled)
            {
                if (this.ActionType == Fwk.UI.Common.ActionTypes.Edit)//Solo si es Edit se le asignan valores a pctSmallImage
                {
                    if (_CopyButton.Image == null)
                        pctSmallImage.Image = null;
                    else
                        pctSmallImage.Image = new Bitmap(new MemoryStream(_CopyButton.Image));

                    if (_CopyButton.LargeImage == null)
                        pctLargeImage.Image = null;
                    else
                        pctLargeImage.Image = new Bitmap(new MemoryStream(_CopyButton.LargeImage));
                }
            }

            if (ActionType == Fwk.UI.Common.ActionTypes.Create)
            {
                base.AceptButtonText = "Agregar elemento";
            }
            if (ActionType == Fwk.UI.Common.ActionTypes.Edit)
            {
                base.AceptButtonText = "Aplicar cambio al item";
            }
        }
        #endregion

        #region [MenuItemEditor Overrides]

        protected override void SaveModifications()
        {
            bool exist= false;
            if (ActionType == Fwk.UI.Common.ActionTypes.Create)
            {
                if (_ParentGroup != null) // se debe validar ya que si no tiene otros nodos el parent es null
                {
                    if (_ParentGroup.ContainTree)
                        exist = _ParentGroup.MenuBarTree.Exist(txtId.Text);
                    else
                        exist = _ParentGroup.Buttons.Exist(txtId.Text);
                }


                if (exist)
                {
                    if (SimpleMessageView.Show(string.Concat("Ya existe un ID = ", txtId.Text, ". ¿Desea sobre escribir este item de menú?"),
                                                "Menu", MessageBoxButtons.YesNo, Fwk.UI.Common.MessageBoxIcon.Question) == DialogResult.No)
                    {
                        txtId.SelectAll();
                        txtId.Focus();
                        return;
                    }


                    List<Fwk.UI.Controls.Menu.ButtonBase> a = (from item in _ParentGroup.Buttons
                                                                   where item.Id.Equals(txtId.Text.Trim(), StringComparison.OrdinalIgnoreCase)
                                                                   select item).ToList<Fwk.UI.Controls.Menu.ButtonBase>();

                    _CopyButton = a[0];

                }

            }
                _CopyButton.Id = txtId.Text;
                _CopyButton.AssemblyInfo = txtAssemblyInfo.Text;
                _CopyButton.Caption = txtCaption.Text;
                _CopyButton.Shortcut = txtShortCut.Text;
                _CopyButton.ToolTipText = txtToolTip.Text;
                       

            if (pctSmallImage.Image != null)
            {
                _CopyButton.Image = TypeFunctions.ConvertImageToByteArray(pctSmallImage.Image, ImageFormat.Png);
            }
            if (pctLargeImage.Image != null)
            {
                _CopyButton.LargeImage = TypeFunctions.ConvertImageToByteArray(pctLargeImage.Image, ImageFormat.Png);
            }

           OnMenuItemSaved(new MenuItemSavedEventArgs(_CopyButton));

        }

        protected override void CancelModifications()
        {
            OnMenuItemCancel(new MenuItemSavedEventArgs(_OriginalButton));
        }

        #endregion

        private void btnAuthorizationRule_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FRM_RuleSelector wRuleSelectorForm = new FRM_RuleSelector();
            wRuleSelectorForm.OnSelectRule += new EventHandler(wRuleSelectorForm_OnSelectRule);
            wRuleSelectorForm.AllowRulesMultiSelect = false;
            wRuleSelectorForm.ShowDialog();
        }

        void wRuleSelectorForm_OnSelectRule(object sender, EventArgs e)
        {
            btnAuthorizationRule.Text = ((FRM_RuleSelector)sender).SelectedRule.Name;// wRuleSelectorForm.se //((FwkAuthorizationRule)sender).Name; 
        }
       
        private void buttonsBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            //OnEditorValueChanges();
        }

        private void btnAuthorizationRule_EditValueChanged(object sender, EventArgs e)
        {

        }

        void SetControlVisibility(MenuItemBase btn)
        {
            grpImages.Enabled = !(btn.GetType() == typeof(TreeNodeButton));
                
        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

      

        
    }
}
