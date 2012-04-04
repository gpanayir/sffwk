using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Fwk.UI.Common;

namespace Fwk.UI.Controls
{
    /// <summary>
    /// Componente de visualizacion de mensajes personalizados.-
    /// 
    /// </summary>
    [ToolboxItem(true), ToolboxBitmap(typeof(MessageViewerComponent), "MessageViewerComponent")]
    public partial class MessageViewerComponent : Component
    {
        #region [Properties]
        private MessageView _FwkMessageView;


        /// <summary>
        /// Icono a mostrar
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("Icono a mostrar")]
        public Image Icon
        {
            get { return _FwkMessageView.MessageIcon; }
        }
        //Fwk.Bases.FrontEnd.Controls.MessageBoxIcon _MessageBoxIcon;

        /// <summary>
        /// Icono a mostrar
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("Tipo Icono a mostrar")]
        public Fwk.UI.Common.MessageBoxIcon MessageBoxIcon
        {
            get { return _FwkMessageView.MessageBoxIcon; }
            set { _FwkMessageView.MessageBoxIcon = value; }
        }

      
        
        /// <summary>
        /// Tamaño del icono
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("Tamaño del icono")]
        public IconSize IconSize
        {
            get { return _FwkMessageView.IconSize; }
            set
            {
                _FwkMessageView.IconSize = value;
            
            }
        }

        /// <summary>
        /// Color de fondo del FwkMessageView .-
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("Color de fondo del FwkMessageView ")]
        public System.Drawing.Color BackColor
        {
            get { return _FwkMessageView.BackColor; }
            set { _FwkMessageView.BackColor = value; }
        }
        /// <summary>
        /// Color de fondo del mensaje. Color del text box.-
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("Color de fondo del mensaje. Color del text box.-")]
        public System.Drawing.Color TextMessageColor
        {
            get { return _FwkMessageView.TextMessageColor; }
            set { _FwkMessageView.TextMessageColor = value; }
        }
        /// <summary>
        /// Color del texto del mensaje
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("Color del texto del mensaje.-")]
        public System.Drawing.Color TextMessageForeColor
        {
            get { return _FwkMessageView.TextMessageForeColor; }
            set { _FwkMessageView.TextMessageForeColor = value; }
        }
        MessageBoxButtons _MessageBoxButtons;
        /// <summary>
        /// Espesifica que conjunto de botones se mostraran.
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("Espesifica que conjunto de botones se mostraran.")]
        public MessageBoxButtons MessageBoxButtons
        {
            get
            {
                return _MessageBoxButtons;
            }
            set
            {
                _MessageBoxButtons = value;
            }
        }

       
        /// <summary>
        /// Titulo
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("Titulo")]
        public String Title
        {
            get { return _FwkMessageView.Text ; }
            set { _FwkMessageView.Text = value; }
        }
        #endregion

        #region Constructor
        public MessageViewerComponent()
        {
            InitializeComponent();
            _FwkMessageView = new MessageView();
   
        }

        public MessageViewerComponent(IContainer container)
        {
            container.Add(this);


            InitializeComponent();
            _FwkMessageView = new MessageView();
        }

        #endregion

        /// <summary>
        /// Muestra el Mensaje
        /// </summary>
        /// <param name="pMessage">Mensaje a mostrar</param>
        /// <returns>DialogResult</returns>
        public DialogResult Show(String pMessage)
        {

            _FwkMessageView.Message = pMessage;
   
            _FwkMessageView.SetButtonsVisibility(_MessageBoxButtons);
            _FwkMessageView.ShowDialog();
           
            return _FwkMessageView.DialogResult;
        }

        /// <summary>
        /// Muestra el Mensaje
        /// </summary>
        /// <param name="e">Exception</param>
        /// <returns>DialogResult</returns>
        public DialogResult Show(Exception e)
        {
  
            _FwkMessageView.SetButtonsVisibility(_MessageBoxButtons);

            _FwkMessageView.Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e);

            _FwkMessageView.StartPosition = FormStartPosition.CenterParent;
            _FwkMessageView.ShowDialog();
            return _FwkMessageView.DialogResult;
        }
    }
}
