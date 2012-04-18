using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.UI.Controls;


namespace Fwk.UI.Controls.Wizard
{
    [ToolboxItem(true)]
    public partial class UC_OrigenDeDatos : UC_UserControlBase
    {

        #region Properties

        public Object SelectedItem
        {
            get
            {
                return enumComboBox1.SelectedItem;
            }
        }

        public Int32 ComboSelectedIndex
        {
            get { return enumComboBox1.SelectedIndex; }
        }

        #endregion

        #region Constructor

        public UC_OrigenDeDatos()
        {
            InitializeComponent();
        }

        #endregion

        private void enumComboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (enumComboBox1.SelectedIndex < 0)
                e.Cancel = true;
        }
    }
}
