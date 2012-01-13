using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Bases;
using Fwk.UI.Common;
using DevExpress.XtraEditors;

namespace Fwk.UI.Controls
{
    public partial class UC_SearchTypeComboBox : XtraUserControl
    {
        
        [Browsable(false)]
        [CategoryAttribute("Fwk.Factory"), Description("Tipo busqueda seleccionada")]
        public SearchtypeEnum Searchtype
        {
            get { return (SearchtypeEnum)Enum.Parse(typeof(SearchtypeEnum), cmbSearchType.Text); }
        }
        
        public ComboBoxBase BigBangControl
        {
            get { return cmbSearchType; }
        }
        
        public UC_SearchTypeComboBox()
        {
            InitializeComponent();

            foreach (string wName in Enum.GetNames(typeof(SearchtypeEnum)))
            {
                cmbSearchType.Items.Add(wName);
            }

           cmbSearchType.SelectedIndex = 0;
          
        }


              
        
    }
}
