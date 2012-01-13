using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.UI.Controls
{
    public class FindEventArg : EventArgs
    {
        bool _IsAdvancedFind = false;

        public bool IsAdvancedFind
        {
            get { return _IsAdvancedFind; }
            set { _IsAdvancedFind = value; }
        }
        string _Text;

        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }
    }
}
