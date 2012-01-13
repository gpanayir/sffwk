using System;
using System.Linq;
using System.Windows.Forms;
using Fwk.Configuration;
using Fwk.Security.BE;
using DevExpress.XtraGrid.Views.Base;
using Fwk.UI.Controller;
using Fwk.UI.Controls.Menu;
using Fwk.Security.Common;
using DevExpress.XtraEditors;

namespace Fwk.UI.Security.Controls
{
    public partial class UC_UsersMain : UserControl
    {

        UserList _AllUsers = new UserList();
        User _CurrentUser;
        public UC_UsersMain()
        {
            InitializeComponent();
            if (!Fwk.HelperFunctions.EnvironmentFunctions.IsInDesigntime())
            {
                toolBarControl1.LoadToolBarFromFile(ConfigurationManager.GetProperty("ApplicationMenu", "SecurityUserToolbar"));
                FillGrid();
            }
        }

        private void FillGrid()
        {
    
           _AllUsers = SecurityController.UserList;
           FilterUsers();
        }

        private void toolBarControl1_ToolBarButtonClick(object sender, ButtonClickArgs<Fwk.UI.Controls.Menu.ButtonBase> e)
        {
            if (e.ButtonClicked.GetType() == typeof(SimpleButton))
            {
               
                switch (e.ButtonClicked.Id)
                {
                    case "btnNewUser":
                        ViewNewUser();
                        break;
                    case "btnEditUser":
                        ViewEditUser();
                        break;

                    case "PASS":
                        ResetPassword();
                        break;
                    default:
                        break;
                }
            }
        }

        


        private void ViewNewUser()
        {
            using (FRM_UserNew frmUserNew = new FRM_UserNew())
            {
                frmUserNew.Populate(null, Fwk.UI.Common.ActionTypes.Create);
                frmUserNew.ShowDialog();
                SecurityController.RefreshUsers();
                FillGrid();
            }
        }

        private void ViewEditUser()
        {
            using (FRM_UserNew wUserEdit = new FRM_UserNew())
            {
                wUserEdit.Text = string.Concat("Editar usuario");// : " + _CurenUser.FirstName + " " +_CurenUser.LastName);
                _CurrentUser = (User)bindingUsersList.Current;
                wUserEdit.Populate(_CurrentUser,Fwk.UI.Common.ActionTypes.Edit);

                wUserEdit.ShowDialog();
                FillGrid();
            }
        }

        private void ResetPassword()
        {
            using (FRM_UserResetPassword wResetPassword = new FRM_UserResetPassword(((UsersBE)(bindingUsersList.Current)).Name))
            {
                wResetPassword.ShowDialog();
            }
        }

        private void UC_UsersMain_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                toolBarControl1.PerformAuthorization();
            }
        }

        private void textFind1_OnFindTextBoxEnter(object sender, EventArgs e)
        {
            FilterUsers();
        }

        private void textFind1_OnFindClick(object sender, EventArgs e)
        {
            FilterUsers();
        }

        void FilterUsers()
        {
            bool? wIsApproved = !chkActiveFlag.Checked;
            if (chkActiveFlag.Checked)
                wIsApproved = null;//Si  esta chequeado mostrar TODOS
            else
                wIsApproved = true;//Si no esta chequeado mostrar solo vigentes
            

            string strToFind = textFind1.TextEditor.Text.ToLower().Trim();
            if (!string.IsNullOrEmpty(strToFind))
            {
                //Filtro de usuarios
                bindingUsersList.DataSource = _AllUsers.Where(u =>
                    (u.UserName.ToLower().Contains(strToFind)
                    ||
                    u.LastName.ToLower().Contains(strToFind)
                     ||
                    u.FirstName.ToLower().Contains(strToFind)
                     ||
                    u.Email.ToLower().Contains(strToFind))
                    &&
                    (wIsApproved == null || u.IsApproved == wIsApproved)
                    ).ToList<User>();
                 


            }
            else
            {
                bindingUsersList.DataSource = _AllUsers.Where(u =>
                  (wIsApproved == null || u.IsApproved == wIsApproved)
             ).ToList<User>();
            }

            grdUsers.RefreshDataSource();
        }

        private void chkActiveFlag_CheckedChanged(object sender, EventArgs e)
        {
            FilterUsers();
        }

       

    }




}
