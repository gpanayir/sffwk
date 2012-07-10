using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;

namespace Fwk.UI.Controls.Menu
{
    public delegate void MenuButtonClickHandler(Object sender, ButtonClickArgs<ButtonBase> e);

    [Serializable]
    public class BarGroup : MenuItemBase
    {
      
        #region [Private Vars]
        DevExpress.XtraNavBar.NavBarGroupStyle _GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsList;

        public DevExpress.XtraNavBar.NavBarGroupStyle GroupStyle
        {
            get { return _GroupStyle; }
            set { _GroupStyle = value; }
        }
        private ButtonBaseList _Buttons = null;
        bool containTree = false;
        TreeNodeButtons _MenuBarTree = new TreeNodeButtons();
        int _Index = 0;

       
        #endregion

        #region [Properties]
        public int Index
        {
            get { return _Index; }
            set { _Index = value; }
        }
        public bool ContainTree
        {
            get { return containTree; }
            set { containTree = value; }
        }

        public ButtonBaseList Buttons
        {
            get { return _Buttons; }
            set { _Buttons = value; }
        }
       

        public TreeNodeButtons MenuBarTree
        {
            get { return _MenuBarTree; }
            set { _MenuBarTree = value; }
        }
        #endregion
        public void Map(BarGroup pBarGroup)
        {
            this.Index = pBarGroup.Index;
            this.GroupStyle = pBarGroup.GroupStyle;
            base.Map(pBarGroup);
        }
    }

    [Serializable]
    public class MenuNavBar: Entities<BarGroup>
    {
        public BarGroup GetBy_Guid(Guid pGuid)
        {

            var wBarGroup = from item in this where (item.Guid == pGuid) select item;

            return wBarGroup.FirstOrDefault<BarGroup>();
        }

        public BarGroup GetBy_Index(int pIndex)
        {

            var wBarGroup = from item in this where (item.Index == pIndex) select item;

            return wBarGroup.FirstOrDefault<BarGroup>();
        }

        public bool Exist(string Id)
        {
            return (this.Where<BarGroup>(p => p.Id.Equals(Id.Trim(), StringComparison.OrdinalIgnoreCase)).Count() > 0);
        }
    }
}
