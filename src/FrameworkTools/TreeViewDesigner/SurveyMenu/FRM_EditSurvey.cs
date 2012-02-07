using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;


namespace Fwk.Tools.SurveyMenu
{
    public partial class FRM_EditSurvey : Form
    {

        #region Properties

        [Browsable(false)]
        public bool CategoryChange
        {
            get { return menuItemEditorSurvey1.CategoryChange; }
        }

        #endregion

        #region Constructor

        public FRM_EditSurvey(MenuItem pMenuItemSurvey, Action pAction)
        {
            InitializeComponent();
            menuItemEditorSurvey1.ShowAction = pAction;
            menuItemEditorSurvey1.MenuItemSelected = pMenuItemSurvey;
            menuItemEditorSurvey1.Populate();
        }

        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            menuItemEditorSurvey1.FillMenuItem();
        }

    }
}
