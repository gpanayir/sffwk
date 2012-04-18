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
using DevExpress.XtraEditors.Controls;
using Fwk.UI.Common;


namespace Fwk.UI.Controls
{
    public partial class ComboBoxDxBase : DevExpress.XtraEditors.ImageComboBoxEdit
    {

        #region Private members
        
        private bool _IAmOn;
        
        //private Boolean _AutoComplete;
        
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
            set
            {
                this.Properties.NullText = value;
                _NullTextValue = value;
            }
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

        /// <summary>
        /// Setea u Obtiene si el control es solo lectura.
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("Setea u obtiene si el control es solo lectura.")]
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value; 
                OnReadOnlyChangeEvent();
                ComboPropertiesSet();
            }
        }
        #endregion

        #region Constructors
        public ComboBoxDxBase()
        {
            InitializeComponent();
        }

        public ComboBoxDxBase(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #endregion

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
        
        #endregion

        #region Public Methods
        
        public void ShareFocus(bool Focus)
        {
            _IAmOn = Focus;
            this.Invalidate();
        }

        /// <summary>
        /// Indica si el comboBox contiene items.
        /// </summary>
        /// <returns></returns>
        public bool HasItems()
        {
            return (this.Properties.Items.Count > 0);
        }
        

        public void PopulateWithEnum(Type enumType)
        {
            if(enumType.GetType().BaseType == typeof(System.Enum))
            {
                throw new ArgumentException("El argumento typeEnum debe ser del tipo System.Enum");
            }

            this.Properties.Items.AddEnum(enumType);

            foreach (ImageComboBoxItem item in this.Properties.Items)
            {
                item.Description = Fwk.UI.Common.HelperFunctions.Enumerations.GetDescription((Enum)item.Value);
            }
        }

        #endregion
      
        private void ComboPropertiesSet()
        {
            if (!_ReadOnly)
            {
                base.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            }
            else
            {
                base.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            }
        }

        private bool ValidateValue()
        {
            errorProvider1.RightToLeft = _ErrorIconRightToLeft;
            
            if (_Required)
            {
                if (this.SelectedItem == null || String.IsNullOrEmpty(this.Text))
                {
                    errorProvider1.SetError(this, _RequiredErrorText);
                    return false;

                }
            }

            errorProvider1.Clear();
            return true;
        }

        private void FwkFlatComboBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateValue();
        }

        private void FwkFlatComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_ReadOnly)
            {
                e.Handled = true;
            }

        }
    }
}
