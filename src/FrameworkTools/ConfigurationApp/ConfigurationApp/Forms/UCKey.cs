using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Configuration.Common;

namespace ConfigurationApp.Forms
{

    public partial class UCConfigElement : UserControlBase
    {
        Key _Key;
        Group _Group;
        public UCConfigElement()
        {
            InitializeComponent();
        }
        void RefreshData() 
        {
             _Key = null;
             _Group = null;
             
             groupKey.Visible = false;
        }

        public void Populate(Key pKey,string fileName,string grName)
        {
            RefreshData();
            groupKey.Visible = true;
       
            lblFileName.Text = fileName;
            txtGroupName.Text = grName;

            _Key = pKey;
            txtNewValue.Text = _Key.Value.Text;
            keyBindingSource.DataSource = _Key;
        }
        public void Populate(Group pGroup, string fileName)
        {
            RefreshData();
            
            lblFileName.Text = fileName;
            txtGroupName.Text = pGroup.Name;
       
           _Group = pGroup;

            
        }

        public Fwk.Bases.Entity Get()
        {
            if(_Key !=null)
                return _Key;

            if (_Group != null)
                return _Group;

            return null;
        }

        private void txtNewValue_TextChanged(object sender, EventArgs e)
        {
            _Key.Value.Text = txtNewValue.Text;
        }



        internal void Populate(string fileName)
        {
            RefreshData();

            lblFileName.Text = fileName;
        }
    }
}
