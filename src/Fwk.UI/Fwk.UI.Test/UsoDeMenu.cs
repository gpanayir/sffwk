using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Fwk.UI.Test
{
    public partial class UsoDeMenu : DevExpress.XtraEditors.XtraForm
    {
        public UsoDeMenu()
        {
            InitializeComponent();
        }

        private void UsoDeMenu_Load(object sender, EventArgs e)
        {
            uC_NavMenu1.LoadFromFile("MenuTest.xml");
            
        }
        void uC_NavMenu1_OnLinkButtonClick(object sender, Fwk.UI.Controls.Menu.ButtonClickArgs<Fwk.UI.Controls.Menu.ButtonBase> e)
        {
            propertyGrid1.SelectedObject = e.ButtonClicked;
        }
       
    }
}