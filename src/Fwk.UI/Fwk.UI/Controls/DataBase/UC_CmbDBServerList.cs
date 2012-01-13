using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Fwk.UI.Controls.DataBase
{
    [ToolboxItem(true)]    
    public partial class UC_CmbDBServerList : XtraUserControl
    {

        public UC_CmbDBServerList()
        {
            InitializeComponent();
        }


        public void Populate(String pServerName)
        {
        }

        public void Populate()
        {

        }
    }
}
