using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.HelperFunctions;

namespace Fwk.Tools.SurveyMenu
{
    public partial class frmImageList : Form
    {
        public frmImageList()
        {
            InitializeComponent();
        }

     TreeMenu   _menu = null;
        public void Populate(TreeMenu menu)
        {

            _menu = menu;
           
            foreach (MenuImage mi in menu.ImageList.OrderBy<MenuImage, int>(p => p.Index))
            {
                imageList1.Images.Add(mi.Image);
            }
        
            menuImageListBindingSource.DataSource = _menu.ImageList;
            gridView1.RefreshData();
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            SelImage();
     
        }

        private void SelImage()
        {
            
            string imgFileName = Fwk.HelperFunctions.FileFunctions.OpenFileDialog_Open(FileFunctions.OpenFilterEnums.OpenImageFilter);
             if (String.IsNullOrEmpty(imgFileName)) 
                 return;
             
            MenuImage menuImage = new MenuImage ();
            Image image=Image.FromFile(imgFileName);

            menuImage.Index = _menu.ImageList.Count+1;
            menuImage.SetIamge(image, System.IO.Path.GetExtension(imgFileName));
            _menu.ImageList.Add(menuImage);
            gridView1.RefreshData();

            
        }


        public MenuImage SelectedImage { get; set; }
        
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            SelectedImage = ((MenuImage)gridControl1.FocusedView.GetRow(gridView1.FocusedRowHandle));
            pictureBoxImageSelected.Image = SelectedImage.Image;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            SelectedImage = ((MenuImage)gridControl1.FocusedView.GetRow(gridView1.FocusedRowHandle));
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
           
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SelectedImage = ((MenuImage)gridControl1.FocusedView.GetRow(gridView1.FocusedRowHandle));
            pictureBoxImageSelected.Image = SelectedImage.Image;
        }

        private void btnAcepc_Click(object sender, EventArgs e)
        {
            SelectedImage = ((MenuImage)gridControl1.FocusedView.GetRow(gridView1.FocusedRowHandle));
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
