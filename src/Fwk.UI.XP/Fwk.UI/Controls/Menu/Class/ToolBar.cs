using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using System.Xml.Serialization;

namespace Fwk.UI.Controls.Menu
{
    [Serializable]
   [XmlInclude(typeof(ButtonBase))]
    [XmlInclude(typeof(PopupButton))]
    public class ToolBar : Entities<ButtonBase>
    {
    }
}
