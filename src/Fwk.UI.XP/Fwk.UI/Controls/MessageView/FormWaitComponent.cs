using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Fwk.UI.Controls
{
    [ToolboxItem(true),
    ToolboxBitmap(typeof(ExceptionViewComponent))]
    public partial class FormWaitComponent : Component
    {
        frmWait _Wait;
        [CategoryAttribute("Fwk.Factory"), Description("Mensaje a mostrar")]
        public String Message
        {
            get { return _Wait.Message; }
            set { _Wait.Message = value; }
        }
        public FormWaitComponent()
        {
            InitializeComponent();
            _Wait = new frmWait();
        }



        public FormWaitComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            _Wait = new frmWait();
        }

        public void Show()
        {
          
            _Wait.ShowDialog();

        }
        /// <summary>
        /// Muestra el mensaje
        /// </summary>
        /// <param name="pMessage">mensaje a mostrar</param>
        public void Show(String pMessage)
        {
            _Wait.Message = pMessage;
            _Wait.ShowDialog();

        }
        /// <summary>
        /// Oculta el mensaje
        /// </summary>
        public void Hide()
        {
            _Wait.Close();
        }
    }
}
