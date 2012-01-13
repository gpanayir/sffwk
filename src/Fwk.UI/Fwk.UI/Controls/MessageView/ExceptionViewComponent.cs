using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Security;
using System.Security.Permissions;
using System.Drawing.Design;
using System.ComponentModel.Design;
using Fwk.UI.Common;
using DevExpress.XtraBars;
using Fwk.Logging;

namespace Fwk.UI.Controls
{
    [ToolboxItem(true),
    ToolboxBitmap(typeof(ExceptionViewComponent))]
    public partial class ExceptionViewComponent : Component
    {

        #region [Properties]
        private ExceptionView _FwkMessageView;
        public BarItemVisibility ButtonsYesNoVisible
        {
            get { return _FwkMessageView.ButtonsYesNoVisible; }
            set { _FwkMessageView.ButtonsYesNoVisible = value; }
        }
        public System.Drawing.Color BackColor
        {
            get { return _FwkMessageView.BackColor; }
            set { _FwkMessageView.BackColor = value; }
        }
        public System.Drawing.Color TextMessageColor
        {
            get { return _FwkMessageView.TextMessageColor; }
            set { _FwkMessageView.TextMessageColor = value; }
        }
        public System.Drawing.Color TextMessageForeColorColor
        {
            get { return _FwkMessageView.TextMessageForeColor; }
            set { _FwkMessageView.TextMessageForeColor = value; }
        }
       
        /// <summary>
        /// Titulo
        /// </summary>
        public String Title
        {
            get { return _FwkMessageView.Text; }
            set { _FwkMessageView.Text = value; }
        }
        #endregion


        public ExceptionViewComponent()
        {
            InitializeComponent();
            _FwkMessageView = new ExceptionView();
            
        }

        public ExceptionViewComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            _FwkMessageView = new ExceptionView();
        }



        
        /// <summary>
        /// Muestra el mensage
        /// </summary>
        /// <param name="pMessage">Mensage a mostrar</param>
        /// <returns>DialogResult</returns>
        public DialogResult Show(String pSource, String pMessage, String pDetail, bool pLogError)
        {
            _FwkMessageView.Source = pSource;
            _FwkMessageView.Message = pMessage;
            _FwkMessageView.Detail = pDetail;
            _FwkMessageView.ShowDialog();


            if (pLogError)
            {
                Event wEvent = new Event(EventType.Error, Fwk.Bases.ConfigurationsHelper.HostApplicationName, _FwkMessageView.Detail);
                wEvent.AppId = Fwk.Bases.ConfigurationsHelper.HostApplicationName;
                wEvent.Source = Fwk.Bases.ConfigurationsHelper.HostApplicationName;
                StaticLogger.Log(wEvent);
            }
            return _FwkMessageView.DialogResult;
        }
        /// <summary>
        /// Muestra el Mensaje
        /// </summary>
        /// <param name="e">Exception</param>
        /// <returns>DialogResult</returns>
        public DialogResult Show(Exception e)
        {
           

            _FwkMessageView.Source = e.Source;
            
             _FwkMessageView.Detail =string.Concat("Codigo de error : ",Fwk.Exceptions.ExceptionHelper.GetFwkErrorId(e),Environment.NewLine, Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e));
            _FwkMessageView.Message = e.Message ;

            _FwkMessageView.ShowDialog();
            return _FwkMessageView.DialogResult;
        }
    }




    


}
