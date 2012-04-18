using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.UI.Controls
{
    public interface IAuthorizationControl
    {
        bool AllowCheckAuthorization
        {
            get;
            set;
        }
        void PerformAuthorization();

    }
}
