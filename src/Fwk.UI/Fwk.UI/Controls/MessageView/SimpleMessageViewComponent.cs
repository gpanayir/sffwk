using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

using System.Drawing;
using Fwk.UI.Common;


namespace Fwk.UI.Controls
{
    public partial class SimpleMessageViewComponent : Component
    {

        #region [Properties]
        private SimpleMessageView _FwkSimpleMessageView;

        /// <summary>
        /// Icono a mostrar
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("Icono a mostrar")]
        public Image Icon
        {
            get { return _FwkSimpleMessageView.MessageIcon; }
        }

        /// <summary>
        /// Icono a mostrar
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("Tipo Icono a mostrar")]
        public MessageBoxIcon MessageBoxIcon
        {
            get { return _FwkSimpleMessageView.MessageBoxIcon; }
            set { _FwkSimpleMessageView.MessageBoxIcon = value; }
        }

        /// <summary>
        /// Tamaño del icono
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("Tamaño del icono")]
        public Common.IconSize IconSize
        {
            get { return _FwkSimpleMessageView.IconSize; }
            set{ _FwkSimpleMessageView.IconSize = value;}
        }

        /// <summary>
        /// Color de fondo del FwkMessageView .-
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("Color de fondo del FwkMessageView.")]
        public System.Drawing.Color BackColor
        {
            get { return _FwkSimpleMessageView.BackColor; }
            set { _FwkSimpleMessageView.BackColor = value; }
        }

        /// <summary>
        /// Color de fondo del mensaje. Color del text box.-
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("Color de fondo del mensaje. Color del text box.")]
        public System.Drawing.Color TextMessageColor
        {
            get { return _FwkSimpleMessageView.TextMessageColor; }
            set { _FwkSimpleMessageView.TextMessageColor = value; }
        }

        /// <summary>
        /// Color del texto del mensaje
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("Color del texto del mensaje.")]
        public System.Drawing.Color TextMessageForeColor
        {
            get { return _FwkSimpleMessageView.TextMessageForeColor; }
            set { _FwkSimpleMessageView.TextMessageForeColor = value; }
        }

        System.Windows.Forms.MessageBoxButtons _MessageBoxButtons;
        /// <summary>
        /// Espesifica que conjunto de botones se mostraran.
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("Espesifica que conjunto de botones se mostraran.")]
        public System.Windows.Forms.MessageBoxButtons MessageBoxButtons
        {
            get { return _MessageBoxButtons; }
            set
            {
                if (value == System.Windows.Forms.MessageBoxButtons.OK || value == System.Windows.Forms.MessageBoxButtons.YesNo)
                    _MessageBoxButtons = value;
              
               
            }

        }

        /// <summary>
        /// Titulo
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("Titulo")]
        public  String Title
        {
            get { return _FwkSimpleMessageView.Text; }
            set { _FwkSimpleMessageView.Text = value; }
        }

        #endregion

        #region Constructores

        public SimpleMessageViewComponent()
        {
            InitializeComponent();
            _FwkSimpleMessageView = new SimpleMessageView();
        }

        public SimpleMessageViewComponent(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            _FwkSimpleMessageView = new SimpleMessageView();
        }

        #endregion

        /// <summary>
        /// Muestra el Mensaje
        /// </summary>
        /// <param name="pMessage">Mensaje a mostrar</param>
        /// <returns>DialogResult</returns>
        public System.Windows.Forms.DialogResult Show(String pMessage)
        {
            _FwkSimpleMessageView.Message = pMessage;
            _FwkSimpleMessageView.SetButtonsVisibility(_MessageBoxButtons);
            _FwkSimpleMessageView.ShowDialog();

            return _FwkSimpleMessageView.DialogResult;
        }

        /// <summary>
        /// Muestra el Mensaje
        /// </summary>
        /// <param name="e">Exception</param>
        /// <returns>DialogResult</returns>
        public System.Windows.Forms.DialogResult Show(Exception e)
        {
            _FwkSimpleMessageView.Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e);
            _FwkSimpleMessageView.SetButtonsVisibility(_MessageBoxButtons);
            _FwkSimpleMessageView.ShowDialog();

            return _FwkSimpleMessageView.DialogResult;
        }
    }

}
