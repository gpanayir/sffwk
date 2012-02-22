using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Fwk.UI.Controls.Menu.Tree;


namespace Fwk.Tools.TreeView
{
    public partial class FRM_EditMenu : Form
    {
        public ImageList ImageList
        {
            get { return menuItemEditorSurvey1.imgList; }
               set { menuItemEditorSurvey1.imgList = value; }
        }

        #region Properties

        //[Browsable(false)]
        //public bool CategoryChange
        //{
        //    get { return menuItemEditorSurvey1.CategoryChange; }
        //}

        #endregion

        #region Constructor

        public FRM_EditMenu(TreeMenu menu, Fwk.UI.Controls.Menu.Tree.MenuItem  pMenuItemSurvey, Action pAction)
        {
            InitializeComponent();
            menuItemEditorSurvey1.ShowAction = pAction;
            menuItemEditorSurvey1.MenuItem = pMenuItemSurvey;
            menuItemEditorSurvey1.TreeMenu = menu;
            menuItemEditorSurvey1.Populate();
        }

        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            menuItemEditorSurvey1.FillMenuItem();
        }

     

    }
}
