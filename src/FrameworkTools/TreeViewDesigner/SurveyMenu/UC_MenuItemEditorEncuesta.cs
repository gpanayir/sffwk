using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.HelperFunctions;


namespace Fwk.Tools.SurveyMenu
{

    public partial class UC_MenuItemEditor : UserControl
    {
        #region Declarations

        bool _CategoryChange = false;
        [Browsable(false)]
        public bool CategoryChange
        {
            get { return _CategoryChange; }
            set { _CategoryChange = value; }
        }
        string m_Image_Sel_Extension;
        string m_Image_Extension;
        string m_ImageType_Extension;
    
        /// <summary>
        /// Almacena la acción a realizar por el Pelsoftulario
        /// </summary>
        Action _ShowAction = Action.Query;

        /// <summary>
        /// Almacena la acción a realizar por el Pelsoftulario
        /// </summary>
        public Action ShowAction
        {
            get { return _ShowAction; }
            set
            {
                _ShowAction = value;
               

            }
        }

        MenuItem _MenuItemSelected;
        [Browsable(false)]
        public MenuItem MenuItemSelected
        {
            get { return _MenuItemSelected; }
            set { _MenuItemSelected = value; }
        }

        #endregion

        #region Constructor

        public UC_MenuItemEditor()
        {
            InitializeComponent();
        }

        #endregion

        /// <summary>
        /// Rellena el Menu item actual .-  
        /// </summary>
        public void FillMenuItem()
        {
            if (this.pictureBoxImage.Image != null && m_Image_Extension != null)
                _MenuItemSelected.NodeImage = Fwk.Tools.Helper.LoadImage(this.pictureBoxImage.Image, m_Image_Extension);
            
            if (this.pictureBoxImageSelected.Image != null && m_Image_Sel_Extension != null)
                _MenuItemSelected.NodeSelectedImage = Fwk.Tools.Helper.LoadImage(this.pictureBoxImageSelected.Image, m_Image_Sel_Extension);

            //if (this.pictureBoxTypeImage.Image != null && m_ImageType_Extension !=null)
            //    _MenuItemSelected.TypeImage = Fwk.Tools.Helper.LoadImage(this.pictureBoxTypeImage.Image, m_ImageType_Extension);

            _MenuItemSelected.AssemblyInfo = this.txtAssembly.Text;
            _MenuItemSelected.DisplayName = this.txtDisplayName.Text;
          
            _MenuItemSelected.ToolTipInfo = txtToolTipInfo.Text;
            _MenuItemSelected.Enabled = this.checkBoxEnabled.Enabled;
            //_MenuItemSelected.Category = txtCategory.Text;
        }


    
        /// <summary>
        /// Rellena los valores del menu    
        /// </summary>
        public void Populate()
        {

            this.txtDisplayName.Text = _MenuItemSelected.DisplayName;
            this.txtAssembly.Text = _MenuItemSelected.AssemblyInfo;
           
            this.txtToolTipInfo.Text = _MenuItemSelected.ToolTipInfo;
            this.checkBoxEnabled.Checked = _MenuItemSelected.Enabled;
            this.txtCategory.Text = _MenuItemSelected.Category;



            if (_MenuItemSelected.NodeSelectedImage != null)
                this.pictureBoxImageSelected.Image = TypeFunctions.ConvertByteArrayToImage(_MenuItemSelected.NodeSelectedImage);
            else
                pictureBoxImageSelected.Image = null;

            if (_MenuItemSelected.NodeImage != null)
                this.pictureBoxImage.Image = TypeFunctions.ConvertByteArrayToImage(_MenuItemSelected.NodeImage);
            else
                pictureBoxImage.Image = null;



            //if (_MenuItemSelected.TypeImage != null)
            //    this.pictureBoxTypeImage.Image = TypeFunctions.ConvertByteArrayToImage(_MenuItemSelected.TypeImage);
            //else
            //    pictureBoxTypeImage.Image = null;

            //SetCategoryEnabled(_MenuItemSelected.IsCategory);
            SetShowAction();
        }

        private void btnAssemblyinfo_Click(object sender, EventArgs e)
        {
            using (FRM_AssemblyExplorer frm = new FRM_AssemblyExplorer("QuestionControlBase"))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (frm.SelectedPelsoft != null)
                    {
                        txtAssembly.Text = frm.SelectedPelsoft.AssemblyInfo;
                       
                    }
                }
            }
        }

        private void btnSelImageType_Click(object sender, EventArgs e)
        {
            SelImage(this.pictureBoxTypeImage,ref m_ImageType_Extension);

        }
        private void btnSelectedImage_Click(object sender, EventArgs e)
        {
            SelImage(this.pictureBoxImageSelected, ref m_Image_Sel_Extension);
        }
        private void btnImage_Click(object sender, EventArgs e)
        {
            SelImage(this.pictureBoxImage, ref m_Image_Extension);
        }
       
        private void SelImage(PictureBox pPictureBox, ref string pImage_Extension)
        {

            if (_MenuItemSelected == null) return ;
            string imgFile = Fwk.HelperFunctions.FileFunctions.OpenFileDialog_Open(FileFunctions.OpenFilterEnums.OpenImageFilter);
            if (String.IsNullOrEmpty(imgFile)) return ; 



            pPictureBox.Image = new Bitmap(imgFile);
            pImage_Extension  = System.IO.Path.GetExtension(imgFile);
        }


        /// <summary>
        /// Habilita y deshabilita los controles
        /// </summary>
        /// <param name="pEnable"></param>
        void EnableControls(Boolean pEnable)
        {
            txtAssembly.Enabled = pEnable;
            txtDisplayName.Enabled = pEnable;
          
            txtToolTipInfo.Enabled = pEnable;

            //txtCategory.Enabled = pEnable && _MenuItemSelected.IsCategory;
            checkBoxEnabled.Enabled = pEnable;
            btnImage.Enabled = pEnable;
            btnSelectedImage.Enabled = pEnable;
            btnAssemblyinfo.Enabled = pEnable;

            btnSelImageType.Enabled = pEnable;
        }

        /// <summary>
        /// limpia todos los controles
        /// </summary>
        public void ClearControls()
        {
            txtAssembly.Text = String.Empty;
            txtDisplayName.Text = String.Empty;
         
            txtToolTipInfo.Text = String.Empty;
            checkBoxEnabled.Enabled = false;
            pictureBoxImageSelected.Image = null;
            pictureBoxImage.Image = null;
            pictureBoxTypeImage.Image = null;

        }


        void SetCategoryEnabled(bool pIsCategory)
        {
            txtAssembly.Enabled = !pIsCategory;
            txtCategory.Enabled = pIsCategory;
            btnAssemblyinfo.Enabled = !pIsCategory;
            btnSelImageType.Enabled = !pIsCategory;
        }

        void SetShowAction()
        {
            String wTitle = String.Empty;
            switch (_ShowAction)
            {
                case Action.Edit:
                    {
                        wTitle = "Menu updating";
                        EnableControls(true);
                        break;
                    }
                case Action.New:
                    {
                        wTitle = "Menu creating";
                        EnableControls(true);
                        break;
                    }
                case Action.Query:
                    {
                        wTitle = "Menu consulting";
                        EnableControls(false);
                        break;
                    }
            }
            if (this.ParentForm != null)
                this.ParentForm.Text = wTitle;
        
        }

      

        private void txtCategory_Validated(object sender, EventArgs e)
        {
            if (_MenuItemSelected.IsCategory && _ShowAction == Action.Edit)
            {
                if (string.IsNullOrEmpty(txtCategory.Text))
                {
                    errorProvider1.SetError((Control)sender, "Category value must not be empty");
                    return;
                }
                //Determina si la categoria fue modificada
                _CategoryChange = (string.Compare(txtCategory.Text, _MenuItemSelected.Category) != 0);
             
                errorProvider1.SetError((Control)sender, String.Empty);
            }
 
        }
    }
}
