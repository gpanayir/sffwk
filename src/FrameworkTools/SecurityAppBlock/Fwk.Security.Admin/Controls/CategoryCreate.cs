using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Security.Common;
using Microsoft.Practices.EnterpriseLibrary.Security;
using System.Web.Security;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Runtime.Remoting.Messaging;
  
namespace Fwk.Security.Admin.Controls
{
    public partial class CategoryCreate : SecurityControlBase
    {
        
      
       
        public override string AssemblySecurityControl
        {
            get
            {
                return typeof(CategoryCreate).AssemblyQualifiedName;
            }
        }


        public override void Initialize()
        {
            using (new WaitCursorHelper(this))
            {

              
                //lstBoxRules.DataSource = FwkMembership.GetRulesList(Membership.ApplicationName);
                //lstBoxRules.Refresh();
            }
        }

        public CategoryCreate()
        {
            InitializeComponent();
          
        }

       

        private void btnCreateNewRol_Click(object sender, EventArgs e)
        {


               
        }
     

        

        private void CategoryCreate_Load(object sender, EventArgs e)
        {
            
 
        }
        public delegate void DelegateWithOutAndRefParameters(out Exception ex);
        /// <summary>
        /// Carga de manera asincrona los Dominios relacionados entre si en la grilla.-
        /// </summary>
        public void PopulateAsync()
        {
           
           rulesInCategory1.Initialize();

          rulesInCategory1.PopulateAsync();

        }
       

       

       
        private void btnRemove_Click(object sender, EventArgs e)
        {
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void popupContainerEdit_AddText_QueryCloseUp(object sender, CancelEventArgs e)
        {

        }
       
    }
}
