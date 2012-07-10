using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Fwk.UI.Forms
{
    public partial class FormBaseNotify : FormBase
    {
        
        bool _OnInit = true;
        private bool _InitFormVisible;
 
        [CategoryAttribute("Fwk.Factory"), Description("Determina si el formulario se inicia de manera visible o no")]
        public bool InitFormVisible
        {
            get { return _InitFormVisible; }
            set { _InitFormVisible = value; }
        }

        [CategoryAttribute("Fwk.Factory"), Description("Texto del notificador de aplicación")]
        public string NotifyText
        {
            get { return notifyIcon1.Text; }
            set { notifyIcon1.Text = value; }
        }

        private System.Windows.Forms.ContextMenuStrip _ContextMenu = null;
        [Browsable(true)]
        public System.Windows.Forms.ContextMenuStrip IconContextMenu
        {
            get { return _ContextMenu; }
            set { _ContextMenu = value; }
        }

        public FormBaseNotify(bool pHandleUnmanagedException)
            : base(pHandleUnmanagedException) 
        {
            InitializeComponent();
        }
        public FormBaseNotify()
        {
            InitializeComponent();
        }

        private void frmBaseNotify_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                // se inicia minimizado SI _InitFormVisible = FALSE    
                if (_InitFormVisible == false)
                    MinimizeInTray();
                notifyIcon1.Visible = true;
                if (_ContextMenu != null)
                    notifyIcon1.ContextMenuStrip = _ContextMenu;

        
            }

        }

      

       
        
        private void frmBaseNotify_Activated(object sender, EventArgs e)
        {
            if (_OnInit)
            {
                _OnInit = false;
                this.Visible = _InitFormVisible;


            }
        }

        private void frmBaseNotify_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
        }
        
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            ForceShow();

        }
        public void ForceShow()
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Activate();

            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;

        }

        public void ForceClose()
        {
            // Cuando se va a cerrar el formulario...
            // eliminar el objeto de la barra de tareas
            this.notifyIcon1.Visible = false;
            // esto es necesario, para que no se quede el icono en la barra de tareas
            // (el cual se quita al pasar el ratón por encima)
            this.notifyIcon1 = null;
            // de paso eliminamos el menú contextual
            _ContextMenu = null;
            this.Close();
            // finaliza todos los mensjaes de la aplicación
            Application.Exit();

        }

        protected override void OnClosing(CancelEventArgs e)
        {

            // The window must only be minimized in tray
            e.Cancel = true;
            MinimizeInTray();
            base.OnClosing(e);

        }

        // funcion que minimiza el formulario al systemTray (al lado de la hora)
        private void MinimizeInTray()
        {
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
        }

       
     


        


    }
}
