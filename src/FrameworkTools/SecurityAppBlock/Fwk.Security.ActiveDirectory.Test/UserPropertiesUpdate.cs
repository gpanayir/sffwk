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
    public partial class UserPropertiesUpdate : Form
    {
        public UserPropertiesUpdate()
        {
            InitializeComponent();
        }

        void Connect()
        {
            ADHelper _ADHelper = new ADHelper ("LDAP://CORRSF71NT13.allus.ar/DC=allus,DC=ar","moviedo","Lincelin9");

            _ADHelper.User_Get_ByName("moviedo");

            _ADHelper.User_ChangeEmail("moviedo","marcelo.oviedo@allus.com.ar");

        }
    }
}
