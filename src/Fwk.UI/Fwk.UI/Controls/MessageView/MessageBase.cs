using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Fwk.UI.Controls
{
    /// <summary>
    /// Clase base de los visores de mensajes .-
    /// </summary>
    public partial class MessageBase : DevExpress.XtraEditors.XtraForm
    {
        Boolean _AceptEscape = false;
        /// <summary>
        /// Atributo que permite que se cierre la ventana del mensaje cuando se preciona la tecla Escape
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("")]
        public Boolean AceptEscape
        {
            get { return _AceptEscape; }
            set { _AceptEscape = value; }
        }
        /// <summary>
        /// Mensaje a mostrar .-
        /// </summary>
        private string _Message = String.Empty;

        public virtual string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        /// <summary>
        /// Titulo a mostrar .-
        /// </summary>
        //private string _Title = String.Empty;

        //public virtual string Title
        //{
        //    get { return _Title; }
        //    set { _Title = value; }
        //}
        /// <summary>
        /// Constructor de la clase base de los visores de mensajes .-
        /// </summary>
        public MessageBase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Permite que se cierre la ventana al precionar escape.-
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void FrmMsgBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && AceptEscape)
            {
                this.Close();
            }
        }
        
    }
}