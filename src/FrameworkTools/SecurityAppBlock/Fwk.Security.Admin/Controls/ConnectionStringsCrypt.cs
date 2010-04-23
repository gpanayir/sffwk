using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Security.Admin.Controls
{
    public partial class ConnectionStringsCrypt : SecurityControlBase
    {
        /// <summary>
        /// Representa la informacion del tipo de control a instanciar 
        /// 
        /// </summary>
        public override string AssemblySecurityControl
        {
            get
            {
                return typeof(RulesAssingControl).AssemblyQualifiedName;
            }
        }
        public ConnectionStringsCrypt()
        {
            InitializeComponent();
        }
    }
}
