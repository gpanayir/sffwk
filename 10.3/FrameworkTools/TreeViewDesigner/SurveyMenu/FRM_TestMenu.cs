using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Fwk.Tools.TreeView
{
    public partial class FRM_TestMenu : Form
    {

        #region Constructor

        public FRM_TestMenu(string file,ImageList imgList)
        {
            InitializeComponent();

            treeListMenuControl1.Populate(file,imgList);
        }

        #endregion


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(treeListMenuControl1.MenuItemSelected.GetXml());
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            treeListMenuControl1.ChangeView(true);
        }
        
    }
}
