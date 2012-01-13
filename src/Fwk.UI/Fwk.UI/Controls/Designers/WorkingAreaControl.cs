

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.UI.Controls.Designers
{
	[
    Designer(typeof(Fwk.UI.Controls.Designers.WorkingAreaDesigner))
	]
	public partial class WorkingAreaControl : Panel
	{


        [Browsable(true)]
		public DockStyle Docking
		{
			get
			{
				return this.Dock;
			}
			set
			{
                this.Dock = value;
			}
		}


		public WorkingAreaControl()
		{
			InitializeComponent();
			
		}


	}
}
