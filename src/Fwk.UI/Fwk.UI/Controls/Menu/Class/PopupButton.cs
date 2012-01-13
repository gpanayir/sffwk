using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.UI.Controls.Menu
{
    [Serializable]
    public class PopupButton : ButtonBase
    {
        #region [Private Methods]

        private ButtonBaseList _ButtonBaseList = new ButtonBaseList();

        #endregion

        #region [Public Properties]

        public ButtonBaseList Buttons
        {
            get { return _ButtonBaseList; }
            set { _ButtonBaseList = value; }
        }

        #endregion
    }
}
