using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System.Diagnostics;
using Fwk.HelperFunctions;

namespace Fwk.UI.Controls.Menu
{
    [ToolboxItem(true)]
    [Browsable(true),DefaultEvent("ToolBarButtonClick")]
    public partial class UC_ToolBarControl : UC_UserControlBase, IAuthorizationControl
    {

        #region [Private vars]
        private ToolBar _Buttons;
        #endregion

        #region [Public Properties]

        /// <summary>
        /// Obtiene u establece la
        /// lista de bottones que se muestran en la
        /// toolbar. 
        /// </summary>
        public ToolBar ToolBar
        {
            get { return _Buttons; }
            set { _Buttons = value; }
        }

        #endregion

        #region [Constructors]

        /// <summary>
        /// Inicializa una nueva instancia de la clase ToolBar
        /// </summary>
        public UC_ToolBarControl()
        {
            InitializeComponent();
        }

        #endregion

        #region [Control Events]

        public event ToolBarButtonClickHandler ToolBarButtonClick;

        /// <summary>
        /// Metodo utilizado para lanzar el evento
        /// ToolBarButtonClick
        /// </summary>
        /// <param name="pButtonClicked">Botón presionado</param>
        private void OnToolBarButtonClick(ButtonBase pButtonClicked)
        {
            if (ToolBarButtonClick != null)
            {
                ButtonClickArgs<ButtonBase> e = new ButtonClickArgs<ButtonBase>(pButtonClicked);
                if (pButtonClicked.GetType() == typeof(ButtonBase))
                {
                    if (!string.IsNullOrEmpty(((ButtonBase)pButtonClicked).AssemblyInfo))
                    {
                        XtraForm wFrm = (XtraForm)Fwk.HelperFunctions.ReflectionFunctions.CreateInstance(((ButtonBase)pButtonClicked).AssemblyInfo);
                        e.Form = wFrm;
                    }
                }

                ToolBarButtonClick(this, e);
            }

        }

        #endregion

        #region [Public Methods]

        /// <summary>
        /// Obtiene un menú de un archivo pasado por parametros
        /// y lo dibuja en el control.
        /// </summary>
        /// <param name="menuFilePath">Archivo del cual obtener el menú</param>
        public void LoadToolBarFromFile(string menuFilePath)
        {
            if (string.IsNullOrEmpty(menuFilePath))
                return;

            _Buttons = ToolBar.GetFromXml<ToolBar>(FileFunctions.OpenTextFile(menuFilePath)); //Fwk.UI.Controls.Menu.Helper.LoadToolBarFromFile(menuFilePath);

            DrawToolBar();
        }

        public void LoadToolBarFromXml(string pXml)
        {
            if (string.IsNullOrEmpty(pXml))
                return;

            _Buttons = ToolBar.GetFromXml<ToolBar>(pXml);

            DrawToolBar();
        }

        /// <summary>
        /// Redibuja el control y su contenido.
        /// </summary>
        public void RefreshToolBar()
        {
            DrawToolBar();
        }

        #endregion

        #region [Private Methods]
        
        private void DrawToolBar()
        {
            ctlToolBar.ClearLinks();

            if (_Buttons == null)
                return;

            PopupButton wPopupButton = null;
            PopupMenu wPopupMenu = null;
            BarLargeButtonItem wBarButtonItem = null;
            

            foreach (ButtonBase wButton in _Buttons)
            {                

                // Se arma un PopupButton
                if (wButton.GetType() == typeof(PopupButton))
                {
                    
                    wBarButtonItem = CreateButtonBase(wButton);

                    wPopupButton = (PopupButton)wButton;
                    wPopupMenu = new PopupMenu(this.components);
                    wPopupMenu.Manager = barManager1;
                    wBarButtonItem.DropDownControl = wPopupMenu;
                    wBarButtonItem.DropDownEnabled = true;
                    wBarButtonItem.ButtonStyle = BarButtonStyle.DropDown;
                    wBarButtonItem.ActAsDropDown = true;

                    foreach (ButtonBase item in wPopupButton.Buttons)
                    {
                        wPopupMenu.ItemLinks.Add(CreateButtonBase(item));
                    }

                    ctlToolBar.AddItem(wBarButtonItem);
                }
                else
                {
                    wBarButtonItem = CreateButtonBase(wButton);
                    //AAguirre - Se agrego esta linea y se comento la linea de arriba, el boton se agregaba en el bar manager y no en la toolbar
                    ctlToolBar.AddItem(wBarButtonItem);
                }

               

            }

        }


        /// <summary>
        /// Genera un BarLargeButtonItem
        /// </summary>
        /// <returns>BarLargeButtonItem</returns>
        /// <author>moviedo</author>
        BarLargeButtonItem CreateButtonBase(ButtonBase pButton)
        {
            BarLargeButtonItem wBarButtonItem = new BarLargeButtonItem();
            SuperToolTipSetupArgs wToolTipSetupArgs = null;

            if (pButton.Image != null)
                wBarButtonItem.Glyph = Fwk.HelperFunctions.TypeFunctions.ConvertByteArrayToImage(pButton.Image);

            wBarButtonItem.Caption = pButton.Caption;
            wBarButtonItem.CaptionAlignment = BarItemCaptionAlignment.Bottom;
            wBarButtonItem.Tag = pButton;
            wBarButtonItem.Hint = pButton.Hint;

            wBarButtonItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            wBarButtonItem.ItemClick += new ItemClickEventHandler(barButtonItem_ItemClick);
            wBarButtonItem.SuperTip = new SuperToolTip();
            wToolTipSetupArgs = new SuperToolTipSetupArgs();
            wToolTipSetupArgs.Contents.Text = pButton.ToolTipText;
            wBarButtonItem.SuperTip.Setup(wToolTipSetupArgs);

            return wBarButtonItem;
        }

        /// <summary>
        /// Responde al evento click de la toolbar
        /// lanzando el nuevo evento de la customtoolbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            OnToolBarButtonClick((ButtonBase)e.Item.Tag);
            Debug.Print(e.Item.Tag.GetType().Name);
        }

        #endregion

        #region IAuthorizationControl Members

        private bool _AllowCheckAuthorization = false;

        [Description("Determina si la toolbar está integrada y/o chequea reglas de seguridad")]
        public bool AllowCheckAuthorization
        {
            get { return _AllowCheckAuthorization; }
            set { _AllowCheckAuthorization = value; }
        }

        public void PerformAuthorization()
        {
            foreach (BarButtonItem barItem in barManager1.Items)
            {
                SetVisibility(barItem);

                if (barItem.Tag.GetType() == typeof(PopupButton))
                {
                    barItem.Visibility = BarItemVisibility.Never;

                    foreach (BarLargeButtonItemLink item in ((PopupMenu)barItem.DropDownControl).ItemLinks)
                    {
                        Boolean wResult = UC_UserControlBase.CheckRule(((ButtonBase)item.Item.Tag).AuthorizationRuleName);

                        if (wResult)
                        {
                            barItem.Visibility = BarItemVisibility.Always;
                            break;
                        }
                    }
                }
            }
        }


        void SetVisibility(BarButtonItem barItem)
        {
            ButtonBase wButtonBase = null;

            if (barItem.Tag.GetType() == typeof(ButtonBase))
            {
                wButtonBase = ((ButtonBase)barItem.Tag);
                wButtonBase.Enabled = UC_UserControlBase.CheckRule(wButtonBase.AuthorizationRuleName);

                if (!wButtonBase.Enabled)
                    barItem.Visibility = BarItemVisibility.Never;

            }
        }

        #endregion
    }

    public delegate void ToolBarButtonClickHandler(Object sender, ButtonClickArgs<ButtonBase> e);
}
