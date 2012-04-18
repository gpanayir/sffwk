using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using System.Xml.Serialization;

namespace Fwk.UI.Controls.Menu
{

    [Serializable]
    public abstract class MenuItemBase : Entity
    {

        #region [Private Vars]
        Guid _Guid;


        private string _Id = string.Empty;
        private string _Caption = string.Empty;
        private string _ToolTipText = string.Empty;
        private Byte[] _Image;

        bool _Enabled = true;
        
        #endregion

        #region [Properties]
        public Guid Guid
        {
            get { return _Guid; }
            
        }
        /// <summary>
        /// Obtiene o establece el 
        /// identificador del Menu
        /// </summary>
        public string Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el caption
        /// del Menu
        /// </summary>
        public string Caption
        {
            get
            {
                return _Caption;
            }
            set
            {
                _Caption = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el ToolTipText
        /// que mostrará el Menu.
        /// </summary>
        public string ToolTipText
        {
            get { return _ToolTipText; }
            set { _ToolTipText = value; }
        }

        [XmlElementAttribute("Image", DataType = "base64Binary")]
        public Byte[] Image
        {
            get { return _Image; }
            set { _Image = value; }
        }

        public bool Enabled
        {
            get { return _Enabled; }
            set { _Enabled = value; }
        }
        #endregion

        public MenuItemBase()
        {
            _Guid = Guid.NewGuid();
        }

        public virtual void Map(MenuItemBase pButtonBase)
        {
            this.Caption = pButtonBase.Caption;
            this.Id = pButtonBase.Id;

            this.ToolTipText = pButtonBase.ToolTipText;
            this.Image = pButtonBase.Image;
            this.Enabled = pButtonBase.Enabled;
           
        }
    }

    [Serializable]
    public  class ButtonBase : MenuItemBase
    {
        #region [Private Vars]
        
         Byte[] _LargeImage;
         string _Hint = string.Empty;
         string _Shortcut = string.Empty;
         string _AuthorizationRuleName = String.Empty;
         string _AssemblyInfo = String.Empty;

        
        #endregion
       
        #region [Properties]
      
        public string AuthorizationRuleName
        {
            get { return _AuthorizationRuleName; }
            set { _AuthorizationRuleName = value; }
        }

        public string AssemblyInfo
        {
            get { return _AssemblyInfo; }
            set { _AssemblyInfo = value; }
        }


        [XmlElementAttribute("LargeImage", DataType = "base64Binary")]
        public Byte[] LargeImage
        {
            get { return _LargeImage; }
            set { _LargeImage = value; }
        }

        public string Hint
        {
            get { return _Hint; }
            set { _Hint = value; }
        }

        public string Shortcut
        {
            get { return _Shortcut; }
            set { _Shortcut = value; }
        }

       

        #endregion
        public  void Map(ButtonBase pButtonBase)
        {
            this.Shortcut = pButtonBase.Shortcut;
            this.Hint = pButtonBase.Hint;
            this.LargeImage = pButtonBase.LargeImage;
            this.AuthorizationRuleName = pButtonBase.AuthorizationRuleName;
            this.AssemblyInfo = pButtonBase.AssemblyInfo;

            base.Map(pButtonBase);
        }
    }


    [Serializable]
    public class TreeNodeButton : ButtonBase
    {
        
      
        string _ParentID;
        public string ParentID
        {
            get { return _ParentID; }
            set { _ParentID = value; }
        }


       
    }
    [Serializable]
    public class ButtonBaseList : Entities<ButtonBase>
    {
        public ButtonBase GetBy_Guid(Guid pGuid)
        {

            var wButtonBase = from item in this where (item.Guid == pGuid) select item;

            return wButtonBase.FirstOrDefault<ButtonBase>();
        }
        public bool Exist(string Id)
        {
            Boolean wExist;
            wExist = (this.Where<ButtonBase>(p => p.Id.Equals(Id.Trim(), StringComparison.OrdinalIgnoreCase)).Count() > 0);
            
            return wExist;
        }
    }
    [Serializable]
    public class TreeNodeButtons : Entities<TreeNodeButton>
    {
        public TreeNodeButton GetBy_Guid(Guid pGuid)
        {
            var wTreeNodeButton = from item in this where (item.Guid == pGuid) select item;

            return wTreeNodeButton.FirstOrDefault<TreeNodeButton>();
        }
        public bool Exist(string Id)
        {
            Boolean wExist;
            wExist = (this.Where<TreeNodeButton>(p => p.Id.Equals(Id.Trim(), StringComparison.OrdinalIgnoreCase)).Count() > 0);
            
            return wExist;
        }
    }
}
