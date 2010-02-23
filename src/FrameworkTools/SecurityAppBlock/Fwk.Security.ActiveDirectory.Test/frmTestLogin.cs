using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Security.ActiveDirectory.Test
{
    public partial class frmTestLogin : Form
    {
        public frmTestLogin()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
           lblCheckResult.Text = ADHelper.User_Login(txtDomain.Text,txtLoginName.Text, txtPassword.Text).ToString();
        }

       

       
    }
}
