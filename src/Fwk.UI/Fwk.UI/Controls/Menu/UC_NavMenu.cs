using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Fwk.UI.Controls.Menu;
using DevExpress.XtraNavBar;
using Fwk.HelperFunctions;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using System.IO;

namespace Fwk.UI
{
    [DefaultEvent("MenuButtonClick")]
    public partial class UC_NavMenu : DevExpress.XtraNavBar.NavBarControl
    {
        int treeCount = 0;
        public bool IsOnDesignMode = false;
        Fwk.UI.Controls.Menu.MenuNavBar _MenuBar;

        public Fwk.UI.Controls.Menu.MenuNavBar MenuBar
        {
            get { return _MenuBar; }
            set { _MenuBar = value; }
        }

        #region [Control Events]
        [CategoryAttribute("Factory Tools"), Description("Click sobre un elemento de la navbar o treeview de una navbar")]
        public event MenuButtonClickHandler OnLinkButtonClick;
        [CategoryAttribute("Factory Tools"), Description("Click sobre un treeview de una navbar")]
        public event EventHandler OnTreeViewClick;
        /// <summary>
        /// Metodo utilizado para lanzar el evento
        /// MenuButtonClick
        /// </summary>
        /// <param name="pButtonClicked">Bot�n presionado</param>
        void LinkButtonClick(Fwk.UI.Controls.Menu.ButtonBase pButtonClicked)
        {
            if (OnLinkButtonClick != null)
            {
                ButtonClickArgs<Fwk.UI.Controls.Menu.ButtonBase> e = new ButtonClickArgs<Fwk.UI.Controls.Menu.ButtonBase>(pButtonClicked);
                OnLinkButtonClick(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void treeList_OnTreeViewClick(object sender, EventArgs e)
        {
            if (OnTreeViewClick != null)
                OnTreeViewClick(sender, new EventArgs());
        }
        #endregion

        public UC_NavMenu()
        {
            InitializeComponent();
            _MenuBar = new MenuNavBar();
        }


        #region [Methods]

        /// <summary>
        /// Obtiene un men� de un archivo pasado por parametros y lo dibuja en el control.
        /// </summary>
        /// <param name="menuFilePath">Archivo del cual obtener el men�</param>
        public void LoadFromFile(string pMenuFilePath)
        {
            if (string.IsNullOrEmpty(pMenuFilePath))
                return;

            _MenuBar = MenuNavBar.GetFromXml<MenuNavBar>(FileFunctions.OpenTextFile(pMenuFilePath));

            DrawMenuNavBar();
        }

        public void LoadFromXml(string pXml)
        {
            _MenuBar = MenuNavBar.GetFromXml<MenuNavBar>(pXml);
            DrawMenuNavBar();
        }
        public void Load(MenuNavBar pMenuNavBar)
        {
            _MenuBar = pMenuNavBar;
            DrawMenuNavBar();
        }

        public override void Refresh()
        {
            base.Refresh();
            DrawMenuNavBar();
        }
        public void Clear()
        {

            (((DevExpress.XtraNavBar.NavBarControl)(this))).Groups.Clear();
        }
        /// <summary>
        /// 
        /// </summary>
        private void DrawMenuNavBar()
        {
            if (_MenuBar == null)
                return;
            
            foreach (BarGroup wBarGroup in _MenuBar)
            {
                Add_BarGroup(wBarGroup, false);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pBarGroup"></param>
        public void Update_BarGroup(BarGroup pBarGroup)
        {
            BarGroup wOriginalBarGroup = (BarGroup)this.ActiveGroup.Tag;

            //Fwk.UI.Controls.Menu.BarGroup wOriginalBarGroup = _MenuBar.GetBy_Guid(pBarGroup.Guid);

            wOriginalBarGroup.Map(pBarGroup);
            this.BeginUpdate();
            this.ActiveGroup.Tag = pBarGroup;
            this.ActiveGroup.Caption = wOriginalBarGroup.Caption;
            this.ActiveGroup.GroupStyle = wOriginalBarGroup.GroupStyle;
            if (wOriginalBarGroup.Image == null)
                this.ActiveGroup.SmallImage = null;
            else
                this.ActiveGroup.SmallImage = new Bitmap(new MemoryStream(wOriginalBarGroup.Image));

            this.EndUpdate();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pBarGroup"></param>
        /// <param name="isNew">Solo indica si pBarGroup es nuevo para _MenuBar </param>
        /// <returns></returns>
        public DevExpress.XtraNavBar.NavBarGroup Add_BarGroup(BarGroup pBarGroup, bool isNew)
        {
            DevExpress.XtraNavBar.NavBarGroup navBarGroup = new DevExpress.XtraNavBar.NavBarGroup();
            if (isNew)
                _MenuBar.Add(pBarGroup);

            if (isNew)
                pBarGroup.Index = _MenuBar.Count-1;
            this.Groups.Add(navBarGroup);

            navBarGroup.Tag = pBarGroup;
            navBarGroup.Caption = pBarGroup.Caption;
            navBarGroup.GroupStyle = pBarGroup.GroupStyle;
          

            if (pBarGroup.Image == null)
                navBarGroup.SmallImage = null;
            else
                navBarGroup.SmallImage = new Bitmap(new MemoryStream(pBarGroup.Image));


            this.ActiveGroup = navBarGroup;
           
            if (pBarGroup.ContainTree)
            {
                if (pBarGroup.MenuBarTree != null)
                    Cretate_UC_TreeNavBar(navBarGroup);
            }
            else
            {
                if (pBarGroup.Buttons != null)
                    Cretate_ButtonBases(navBarGroup);
            }

            return navBarGroup;
        }






        void Cretate_UC_TreeNavBar(DevExpress.XtraNavBar.NavBarGroup navBarGroup)
        {

            BarGroup wBarGroup = (BarGroup)navBarGroup.Tag;

            NavBarGroupControlContainer navBarGroupControlContainer = new NavBarGroupControlContainer();
            navBarGroupControlContainer.SuspendLayout();
            this.Controls.Add(navBarGroupControlContainer);

            UC_TreeNavBar treeList = new UC_TreeNavBar();


            this.SuspendLayout();

            navBarGroup.GroupStyle = NavBarGroupStyle.ControlContainer;
            navBarGroupControlContainer.Controls.Add(treeList);
            navBarGroupControlContainer.Name = "navBarGroupControlContainer" + treeCount;
            navBarGroupControlContainer.Size = new System.Drawing.Size(176, 243);
            //navBarGroupControlContainer.TabIndex = treeCount;
            navBarGroup.ControlContainer = navBarGroupControlContainer;

            treeList.Populate(wBarGroup.MenuBarTree,this.IsOnDesignMode);

            treeList.Dock = System.Windows.Forms.DockStyle.Fill;
            treeList.Location = new System.Drawing.Point(0, 0);
            treeList.Name = string.Concat("treeList", treeCount);
            treeList.TabIndex = treeCount;
            treeList.Tag = wBarGroup.MenuBarTree;
            treeList.OnNodeClick += new OnNodeClickHandler(treeList_OnNodeClick);
            treeList.OnTreeViewClick += new EventHandler(treeList_OnTreeViewClick);
            SetTreeDesignMode(treeList);
            
            treeCount++;


            navBarGroupControlContainer.ResumeLayout(false);

            this.ResumeLayout(false);
        }
        void SetTreeDesignMode(UC_TreeNavBar treeList)
        {
            if (IsOnDesignMode)
            {
                treeList.AllowDrop = true;

                this.AllowDrop = true;
                
            }
        }
        void Update_UC_TreeNavBar(DevExpress.XtraNavBar.NavBarGroup navBarGroup, TreeNodeButton pMenuBarTreeNode)
        {
            BarGroup wBarGroup = (BarGroup)navBarGroup.Tag;

            wBarGroup.MenuBarTree.Add(pMenuBarTreeNode);
            UC_TreeNavBar treeList = (UC_TreeNavBar)((System.Windows.Forms.Control)(navBarGroup.ControlContainer)).Controls[0];
            //treeList = navBarGroup

            treeList.Populate(wBarGroup.MenuBarTree,this.IsOnDesignMode);

        }

        void Cretate_ButtonBases(DevExpress.XtraNavBar.NavBarGroup navBarGroup)
        {
            BarGroup wBarGroup = (BarGroup)navBarGroup.Tag;

            foreach (Fwk.UI.Controls.Menu.ButtonBase wButtonBase in wBarGroup.Buttons)
            {
                Add_ButtonBase(navBarGroup, wButtonBase, false);
            }
        }


        void Add_ButtonBase(DevExpress.XtraNavBar.NavBarGroup navBarGroup, Fwk.UI.Controls.Menu.ButtonBase pButtonBase, bool isNew)
        {
            DevExpress.XtraNavBar.NavBarItem navBarItem = new NavBarItem(); 
            BarGroup wBarGroup = (BarGroup)navBarGroup.Tag;

            if (isNew)
                wBarGroup.Buttons.Add(pButtonBase);



            if (pButtonBase.Image != null)
                navBarItem.SmallImage = Fwk.HelperFunctions.TypeFunctions.ConvertByteArrayToImage(pButtonBase.Image);

            if (pButtonBase.LargeImage != null)
                navBarItem.LargeImage = Fwk.HelperFunctions.TypeFunctions.ConvertByteArrayToImage(pButtonBase.LargeImage);

            navBarItem.Caption = pButtonBase.Caption;
            navBarItem.Tag = pButtonBase;
            navBarItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(wNavBarItem_LinkClicked);
            navBarGroup.ItemLinks.Add(navBarItem);

        }
        #endregion

        #region [Events]
        void treeList_OnNodeClick(TreeNodeButton node)
        {

            LinkButtonClick((Fwk.UI.Controls.Menu.ButtonBase)node);
        }

        void wNavBarItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            LinkButtonClick((Fwk.UI.Controls.Menu.ButtonBase)e.Link.Item.Tag);
        }

        void ctlMenu_ShowCustomizationMenu(object sender, RibbonCustomizationMenuEventArgs e)
        {
            e.ShowCustomizationMenu = false;
        }

      

        #endregion

        public void Add_ItemToGroup(NavBarGroup pNavBarGroup, Fwk.UI.Controls.Menu.ButtonBase buttonBase)
        {

            if (((BarGroup)pNavBarGroup.Tag).ContainTree)
            {
                Update_UC_TreeNavBar(pNavBarGroup, ((TreeNodeButton)buttonBase));
            }
            else
            {
                Add_ButtonBase(pNavBarGroup, buttonBase, true);
            }
        }

        /// <summary>
        /// Actualiza un simplebuton
        /// </summary>
        /// <param name="ButtonBase_Updated">ButtonBase o item con los nuevos valores
        /// conserva el GUID</param>
        public void Update_ItemFromGroup(Fwk.UI.Controls.Menu.ButtonBase buttonBase_Updated)
        {
            BarGroup wBarGroup = (BarGroup)this.ActiveGroup.Tag;

            //BarGroup wBarGroupX = _MenuBar.GetBy_Guid(wBarGroup.Guid);
            if ((wBarGroup).ContainTree)
            {
                Fwk.UI.Controls.Menu.TreeNodeButton originalButtonBase = wBarGroup.MenuBarTree.GetBy_Guid(buttonBase_Updated.Guid);
           
                originalButtonBase.Map((TreeNodeButton)buttonBase_Updated);
                //wBarGroup.MenuBarTree.
               UC_TreeNavBar treeList = (UC_TreeNavBar)((System.Windows.Forms.Control)(this.ActiveGroup.ControlContainer)).Controls[0];

               treeList.Refresh(); 
            }
            else
            {
                Fwk.UI.Controls.Menu.ButtonBase originalButtonBase = wBarGroup.Buttons.GetBy_Guid(buttonBase_Updated.Guid);
               
                originalButtonBase.Map(buttonBase_Updated);


                //Recorro los items de la ActiveGroup y actuaizo los datos del que tenga como tag el guid que se actualiza
                foreach (NavBarItem link in this.ActiveGroup.NavBar.Items)
                {
                    if (((Fwk.UI.Controls.Menu.ButtonBase)(link.Tag)).Guid.Equals(originalButtonBase.Guid))
                    {
                        if (originalButtonBase.Image != null)
                            link.SmallImage = Fwk.HelperFunctions.TypeFunctions.ConvertByteArrayToImage(originalButtonBase.Image);

                        link.Caption = originalButtonBase.Caption;
                    
                    }

                }
             
         
            }
        }

    }
}
