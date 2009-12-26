using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Wizard
{
    public partial class frmWizBase : Form
    {

        string solutionName;

        public string SolutionName
        {
            get { return solutionName; }
            set { solutionName = value; }
        }
        string solutionProjectName;

        public string SolutionProjectName
        {
            get { return solutionProjectName; }
            set { solutionProjectName = value; }
        }
        public frmWizBase()
        {
            InitializeComponent();
        }
    }
}
