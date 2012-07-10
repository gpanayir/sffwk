using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.Drawing;

using Fwk.Bases;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace Fwk.UI.Controls
{
    public partial class ComboBoxBase : System.Windows.Forms.ComboBox//, Fwk.UI.Controls.IStandardControl
    {

        #region Private members
        
        //public event BorderChangeHandler BorderChange;
        private const int WM_PAINT = 0xF;
        private bool _IAmOn;
        private Color _BorderColor;
        private Color _ArrowColor;
        private Color _ButtonColor;
       
        private Color _ActiveBorderColor = SystemColors.ControlDarkDark;
        private Color _InactiveBorderColor = SystemColors.ControlDark;
        private Color _ActiveArrowColor = SystemColors.ControlDarkDark;
        private Color _InactiveArrowColor = SystemColors.ControlDark;
        private Color _ActiveButtonColor = SystemColors.ControlDark;
        private Color _InactiveButtonColor = SystemColors.Control;
        private Color _ReadOnlyColor = SystemColors.Control;
        private Color _BackColor = SystemColors.Window;

        private Boolean _AutoComplete;
        
        private Boolean _KeysEnabledToAutoComplete;
        private string _RequiredErrorText;
        private Boolean _Required;
        private Boolean _ReadOnly;
        Boolean _ErrorIconRightToLeft = false;

        private String _NullTextValue;
        
        private Boolean _AllowNullTextValue = false;

        #endregion

        #region Events
        public delegate void ReadOnlyChangeHandler();
        public event ReadOnlyChangeHandler ReadOnlyChangeEvent;

        private void OnReadOnlyChangeEvent()
        {
            if (ReadOnlyChangeEvent != null)
                ReadOnlyChangeEvent();
        }

        public delegate void AutoCompleteChangeHandler();
        public event AutoCompleteChangeHandler AutoCompleteChangeEvent;
        private void OnAutoCompleteChangeEvent()
        {
            if (AutoCompleteChangeEvent != null)
                AutoCompleteChangeEvent();
        }
        #endregion

        #region Properties

       
        [BrowsableAttribute(false)]
        public bool IsON
        {
            get { return _IAmOn; }
        }


        /// <summary>
        /// Determina si el valor del combo es requerido
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("Determina si el valor del combo es requerido")]
        public bool Required
        {
            get { return _Required; }
            set { _Required = value; }
        }
        /// <summary>
        /// Texto que se muestra en el mensaje de error cuando el campo es requerido.-
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("Texto que se muestra en el mensaje de error cuando el campo es requerido.-")]
        public string RequiredErrorText
        {
            get { return _RequiredErrorText; }
            set { _RequiredErrorText = value; }
        }


        /// <summary>
        /// BackColor
        /// </summary>
        [Browsable(false)]
        [CategoryAttribute("Fwk.Factory")]
        public override Color BackColor
        {
            get { return _BackColor; }
            set { _BackColor = value; }
        }

        [CategoryAttribute("Fwk.Factory"), Description("Determina si el combo se autocompleta y admite entradas nuevas")]
        public bool AutoComplete
        {
            get { return _AutoComplete; }
            set { _AutoComplete = value; OnAutoCompleteChangeEvent(); }
        }

        /// <summary>
        /// Setea u Obtiene si el control es solo lectura.
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("Setea u obtiene si el control es solo lectura.")]
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value; OnReadOnlyChangeEvent();
                ComboPropertiesSet();
            }
        }

        [CategoryAttribute("Fwk.Factory"), Description("Color del borde del combo cuando esta activo o tiene el foco")]
        public Color ActiveBorderColor
        {
            get { return _ActiveBorderColor; }
            set { _ActiveBorderColor = value; }
        }

        [CategoryAttribute("Fwk.Factory"), Description("Color del borde del combo cuando esta inactivo o no tiene el foco")]
        public Color InactiveBorderColor
        {
            get { return _InactiveBorderColor; }
            set { _InactiveBorderColor = value; }
        }

        [CategoryAttribute("Fwk.Factory"), Description("Color del boton del combo cuando esta activo o tiene el foco")]
        public Color ActiveButtonColor
        {
            get { return _ActiveButtonColor; }
            set { _ActiveButtonColor = value; }
        }

        [CategoryAttribute("Fwk.Factory"), Description("Color del boton del combo cuando esta inactivo o no tiene el foco")]
        public Color InactiveButtonColor
        {
            get { return _InactiveButtonColor; }
            set { _InactiveButtonColor = value; }
        }

        [CategoryAttribute("Fwk.Factory"), Description("Color de flecha del combo cuando esta activo o tiene el foco")]
        public Color ActiveArrowColor
        {
            get { return _ActiveArrowColor; }
            set { _ActiveArrowColor = value; }
        }

        [CategoryAttribute("Fwk.Factory"), Description("Color de flecha del combo cuando este esta en modo inactivo o no tiene el foco")]
        public Color InactiveArrowColor
        {
            get { return _InactiveArrowColor; }
            set { _InactiveArrowColor = value; }
        }


        [CategoryAttribute("Fwk.Factory"), Description("Color que se muestra cuando el combo esta en modo ReadOnly = True")]
        public Color ReadOnlyColor
        {
            get { return _ReadOnlyColor; }
            set
            {
                _ReadOnlyColor = value;
                ComboPropertiesSet();
            }
        }
        /// <summary>
        ///  Indica la pocicion del icono de error
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("Indica la pocicion del icono de error")]
        public Boolean ErrorIconRightToLeft
        {
            get
            {
                return _ErrorIconRightToLeft;
            }
            set
            { _ErrorIconRightToLeft = value; }
        }

        /// <summary>
        ///  Indica el texto que se muestra en el combo cuando no se selecciono ningun valor
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("Indica el texto que se muestra en el combo cuando no se selecciono ningun valor")]
        public String NullTextValue
        {
            get { return _NullTextValue; }
            set { _NullTextValue = value; }
        }
        /// <summary>
        ///  Determina si se permite agregar un valor al combo que indique seleccion nula.-
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("AllowEmptyTextValue")]
        public Boolean AllowEmptyTextValue
        {
            get { return _AllowNullTextValue; }
            set { _AllowNullTextValue = value; }
        }
        #endregion

        public ComboBoxBase()
        {
            InitializeComponent();
        }

        public ComboBoxBase(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        
        #region protected override void On
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _IAmOn = true;
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _IAmOn = false;
            this.Invalidate();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            _IAmOn = true;
            this.Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            _IAmOn = false;
            ValidateValue();
            this.Invalidate();
        }

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            _IAmOn = true;
            this.Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseHover(e);
            _IAmOn = true;
            this.Invalidate();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            //No aplicamos el autocompletado 
            //si las teclas pulsadas son Suprimir o Borrar
            _KeysEnabledToAutoComplete = ((e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back));
            base.OnKeyDown(e);

        }


        protected override void OnDataSourceChanged(EventArgs e)
        {
            base.OnDataSourceChanged(e);

            //if (_AllowNullTextValue)
            // this.AddItemsCore(_NullTextValue);
        }


        /// <summary>
        /// Posiciona el combo  de acuerdo al texto pasado por parametros.
        /// </summary>
        /// <param name="pDisplayText"></param>
        public void PosicionarCombo(string pDisplayText)
        {
            int wiIndex;

            wiIndex = this.FindStringExact(pDisplayText);

            if (wiIndex > -1)
            {
                this.SelectedIndex = wiIndex;
                this.Text = pDisplayText;
            }
            else
            {
                this.Text = String.Empty;

            }
        }



        protected override void OnTextChanged(EventArgs e)
        {
            if (_AutoComplete && _KeysEnabledToAutoComplete)
            {
                string Texto = this.Text;
                //FindString localiza el primer ítem de la lista
                //cuyas primeras letras coinciden con las de su argumento
                //Está claro que es una función pensada 
                //para autocompletar el ComboBox.
                int Index = this.FindString(Texto);
                if (Index >= 0)
                {
                    //Al cargar la caja de texto con el ítem localizado
                    //se dispara otra vez el evento OnTextChanged
                    //o sea, este procedimiento,
                    //que volvería a cambiar el contenido de la caja de texto
                    //aunque fuera con el mismo texto,
                    //lo cual volvería a disparar el evento OnTextChanged
                    //formándose un ciclo sin fin.
                    //Por eso hay que Create una variable 
                    //de tipo booleano que haga de semáforo.
                    _AutoComplete = false;
                    this.SelectedIndex = Index;

                    _AutoComplete = true;

                    //Al ir autocompletando mantenemos seleccionado
                    //el fragmento que no se ha autocompletado.
                    //Esto permite autocompletar el ítem entero
                    //teclando sólo las letras de la palabra.
                    this.Select(Texto.Length, this.Text.Length);
                }
            }
            base.OnTextChanged(e);
        }

       
        #endregion

        public void ShareFocus(bool Focus)
        {
            _IAmOn = Focus;
            this.Invalidate();
        }

        public bool HasItems()
        {
            if (this.Items.Count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_PAINT)
            {
                //Definimos el rectángulo que abarca 
                //la caja de texto y el botón
                Graphics g = this.CreateGraphics();
                Rectangle wCliente = this.ClientRectangle;

                //Establecemos los colores
                if (_IAmOn)
                {
                    _BorderColor = _ActiveBorderColor;
                    _ArrowColor = _ActiveArrowColor;
                    _ButtonColor = _ActiveButtonColor;
                }
                else
                {
                    _BorderColor = _InactiveBorderColor;
                    _ArrowColor = _InactiveArrowColor;
                    _ButtonColor = _InactiveButtonColor;
                }

                //Pintamos el control entero de blanco para eliminar todo rastro de tres dimensiones
                g.FillRectangle(new SolidBrush(SystemColors.Window), wCliente);

                //Dibujamos el borde de todo el control
                g.DrawRectangle(new Pen(_BorderColor), 0, 0, wCliente.Width, wCliente.Height - 1);

                //Definimos la localización y el tamaño del botón
                Point wPunto = new Point(wCliente.Width - 18, 0);
                Size wArea = new Size(wCliente.Width - wPunto.X, wCliente.Height - wPunto.Y);

                Rectangle Boton = new Rectangle(wPunto, wArea);

                //y lo pintamos
                g.FillRectangle(new SolidBrush(_ButtonColor), Boton);

                //Movemos el eje de coordenadas a la esquina del botón
                //para dibujar más cómodamente
                g.TranslateTransform(Boton.X, Boton.Y);

                //Dibujamos el borde del botón
                g.DrawRectangle(new Pen(_BorderColor), 0, 0, Boton.Width - 1, Boton.Height - 1);

                //Definimos un GraphicsPath que contendrá el dibujo de la flecha
                GraphicsPath wFlecha = new GraphicsPath();

                PointF NO = new PointF(Boton.Width / 4, 9 * Boton.Height / 24);
                PointF NE = new PointF(3 * Boton.Width / 4, NO.Y);
                PointF SU = new PointF(Boton.Width / 2, 15 * Boton.Height / 24);

                wFlecha.AddLine(NO, NE);
                wFlecha.AddLine(NE, SU);

                //suavizamos los bordes en lo posible
                g.SmoothingMode = SmoothingMode.AntiAlias;

                //y dibujamos la flecha
                g.FillPath(new SolidBrush(_ArrowColor), wFlecha);

                g.Dispose();


                //if (BorderChange != null)
                //{
                //    BorderChange(this, new FlatBoxEventArgs(_BorderColor, _IAmOn));
                //}


            }
        }

        void ComboPropertiesSet()
        {
            if (_ReadOnly)
            {
                this.BackColor = _ReadOnlyColor;

            }
            else
            {

                this.BackColor = _BackColor;

            }

            base.Enabled = !_ReadOnly;
        }

        private bool ValidateValue()
        {
            errorProvider1.RightToLeft = _ErrorIconRightToLeft;
            if (_Required)
            {
                if (String.IsNullOrEmpty(this.Text))
                {
                    errorProvider1.SetError(this, _RequiredErrorText);
                    return false;

                }
            }

            errorProvider1.Clear();
            return true;
        }

        void FwkFlatComboBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateValue();
        }

        private void FwkFlatComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_ReadOnly)
            {
                e.Handled = true;
            }
            else
            {
                if (_AutoComplete && _KeysEnabledToAutoComplete)
                {
                    e.Handled = true;

                    //Añadimos al texto del control el carácter nuevo
                    string Texto = this.Text.Substring(0, this.Text.Length - this.SelectedText.Length) + e.KeyChar;

                    //Lo buscamos en la lista y si lo encontramos 
                    //permitimos que se una al texto

                    if (this.FindString(Texto) >= 0)
                    {
                        e.Handled = false;
                    }
                    else
                    {

                        //base.OnKeyPress(e);
                    }
                }
            }
        }
    }
}
