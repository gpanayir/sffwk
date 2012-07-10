using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Practices.EnterpriseLibrary.Security.Configuration;
using Fwk.UI.Controls.Menu;
using Fwk.UI.Common;

namespace Fwk.Tools.Menu
{
    [ToolboxItem(false)]
    public partial class UC_MenuItemEditor : Fwk.UI.Controls.UC_UserControlBase
    {
        ActionTypes actionType = ActionTypes.Create;

        public ActionTypes ActionType
        {
            get { return actionType; }
            set { actionType = value; }
        }
        Boolean _OnInit = true;

        public Boolean OnInit
        {
            get { return _OnInit; }
            set { _OnInit = value; }
        }
        public UC_MenuItemEditor()
        {
            InitializeComponent();
        }
        public string AceptButtonText
        {

            get { return ButtonBase1.Text; }
            set { ButtonBase1.Text = value; }
        }
        //public event System.EventHandler EditorValueChanges;
        //protected void OnEditorValueChanges()
        //{
        //    if (EditorValueChanges != null && _OnInit == false)
        //    {
        //        EditorValueChanges(this, new EventArgs());
        //    }
        //}
        private AuthorizationRuleData _SelectedRule;

        [Browsable(false)]
        public AuthorizationRuleData SelectedRule
        {
            get { return _SelectedRule; }
            set { _SelectedRule = value; }
        }
        #region [Virtual Methods]
        /// <summary>
        /// Metodo que debe ser sobre escrito para realizar las acciones necesarias
        /// para guardar los datos modificados por el control al presionar el boton salvar.
        /// </summary>
        protected virtual void SaveModifications()
        {

            throw new NotImplementedException();
            
        }

        /// <summary>
        /// Metodo que debe ser sobreescrito para cancelar las modificaciones realizadas sobre
        /// el objeto cargado en el control, es ejecutado al presionar el bot�n cancelar. 
        /// </summary>
        protected virtual void CancelModifications()
        {

            throw new NotImplementedException();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="btn"></param>
        public virtual void LoadControl(Fwk.UI.Controls.Menu.MenuItemBase btn, object parent)
        { }
        #endregion

        #region [Controls Event Handling]
        /// <summary>
        /// Metodo que responde al evento Click del bot�n ButtonBase1
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento</param>
        /// <param name="e">Parametros del evento</param>
        private void ButtonBase1_Click(object sender, EventArgs e)
        {
            SaveModifications();
        }

        /// <summary>
        /// Metodo que responde al evento Click del bot�n ButtonBase2
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento</param>
        /// <param name="e">Parametros del evento.</param>
        private void ButtonBase2_Click(object sender, EventArgs e)
        {
            CancelModifications();
        }
        #endregion

        #region [Control Events]
        public event MenuItemSavedHandler MenuItemCancel;
        public event MenuItemSavedHandler MenuItemSaved;

        protected void OnMenuItemSaved(MenuItemSavedEventArgs e)
        {
            if(MenuItemSaved!=null)
            {
                MenuItemSaved(this, e);
            }
        }

        protected void OnMenuItemCancel(MenuItemSavedEventArgs e)
        {
            if (MenuItemCancel != null)
            {
                MenuItemCancel(this, e);
            }
        }
        #endregion

        


    }

    public delegate void MenuItemSavedHandler(object sender, MenuItemSavedEventArgs e);

    /// <summary>
    /// Clase con argumentos del evento MenuItemSaved
    /// </summary>
    public class MenuItemSavedEventArgs:EventArgs
    {
        #region [Private Vars]

        private MenuItemBase _menuItem;

        #endregion

        #region [Properties]
        /// <summary>
        /// MenuItem cuyos datos fueron guardados.
        /// </summary>
        public MenuItemBase MenuItem
        {
            get { return _menuItem; }
            set { _menuItem = value; }
        }
        #endregion

        #region [Constructors]

        /// <summary>
        /// Inicializa una nueva instancia de la clase MenuItemSavedEventArgs
        /// </summary>
        public MenuItemSavedEventArgs(MenuItemBase savedMenuItem)
        {
            _menuItem = savedMenuItem;
        }

        #endregion
    }
}
