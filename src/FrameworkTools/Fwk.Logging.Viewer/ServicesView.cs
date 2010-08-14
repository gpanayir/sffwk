using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Logging.Viewer
{
    public partial class ServicesView : UserControl
    {
       
        public ServicesView()
        {
            InitializeComponent();
        }

       public  void Populate(Message pMessage)
        {
            txtMessage1.Text = pMessage.Request;
            txtMessage2.Text = pMessage.Response;
        }
    }
}
