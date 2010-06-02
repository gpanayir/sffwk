using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Security.Common;
using Fwk.Security.Admin.Controls;

namespace Fwk.Security.Admin
{
    public delegate void UserChangeHandler(User user, RolList roles);
    [DefaultEvent("OnUserChange")]
    public partial class UsersGrid : SecurityControlBase
    {
        public User CurrentUser;
        public event UserChangeHandler OnUserChange;
        List<User> userList;

        List<User> selectedUserList = new List<User> ();
        [Browsable(false)]
        public List<User> SelectedUserList
        {
            get
            {
                GetSelecteds();
                return selectedUserList;
            }

        }

        public UsersGrid()
        {
            InitializeComponent();
            userByAppBindingSource.DataSource = userList;

        }

        private void grdUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (grdUsers.CurrentRow == null) return;
            CurrentUser = ((User)grdUsers.CurrentRow.DataBoundItem);
            if (CurrentUser == null) return;

            if (OnUserChange != null)
            {
                OnUserChange(CurrentUser, FwkMembership.GetRolesForUser(CurrentUser.UserName, frmAdmin.Provider.Name));
            }


            
        }

        public override void Initialize()
        {
          
                userList = FwkMembership.GetAllUsers(frmAdmin.Provider.Name);
          
            grdUsers.DataSource = userList;
            grdUsers.Refresh();
        }



        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter) return;
            if (string.IsNullOrEmpty(textEdit1.Text))
            {
                grdUsers.DataSource = userList;
                grdUsers.Refresh();
            }
            string strFind = textEdit1.Text.ToUpper();
            var list = from u in userList
                       where
                        u.UserName.ToUpper().Contains(strFind) ||
                        u.Email.ToUpper().Contains(strFind)
                       select u;

            grdUsers.DataSource = list.ToList<User>();
            grdUsers.Refresh();
        }

        public void GetSelecteds()
        {
            selectedUserList.Clear();
            foreach (DataGridViewRow row in grdUsers.SelectedRows)
            {
                selectedUserList.Add(((User)row.DataBoundItem));
            }
            
        }

       
    }
}
