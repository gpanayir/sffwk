using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using Fwk.UI.Common;
using DevExpress.XtraEditors.Mask;
using System.Windows.Forms;

namespace Fwk.UI.Controls
{
    public partial class TextMemoEdit : MemoEdit
    {
        #region Declatarions

       

        private bool _CapitalOnly = false;
        private bool _Required;


        private string _RequiredErrorText;
        private String _NotAllowedCharacters = String.Empty;



        #endregion

        #region --[Propiedades]-
       
        [CategoryAttribute("Fwk.Factory"), Description("Gets or sets the maximum number of characters an end-user can enter into the editor.")]
        public int TexMaxLength
        {
            get { return this.Properties.MaxLength; }
            set
            {
                this.Properties.MaxLength = value;

            }
        }
       


        [CategoryAttribute("Fwk.Factory"), Description("Indica si el control es obligatorio o no. Si lo establece a true tambien espesifique el valor de RequiredErrorText ")]
        public bool Required
        {
            get
            {
                return _Required;

            }
            set { _Required = value; }
        }

        [CategoryAttribute("Fwk.Factory"), Description("Mensaje de error que se muestra cuando el campo es requerido y no se establecio valor alguno")]
        public string RequiredErrorText
        {
            get { return _RequiredErrorText; }
            set { _RequiredErrorText = value; }
        }

        [CategoryAttribute("Fwk.Factory"), Description("Editor de mascaras del editor de texto")]
        public MaskProperties TextMaskType
        {
            get
            {
                return base.Properties.Mask;
            }
        }

        [CategoryAttribute("Fwk.Factory"), Description("Caracteres no permitidos para ingreso en el text box")]
        public string NotAllowedCharacters
        {
            get { return _NotAllowedCharacters; }
            set { _NotAllowedCharacters = value; }
        }

        [CategoryAttribute("Fwk.Factory"), Description("Solo capital")]
        public bool CapitalOnly
        {
            get
            { return _CapitalOnly; }
            set
            { _CapitalOnly = value; }
        }




        /// <summary>
        ///  Indica el texto que se muestra en el combo cuando no se selecciono ningun valor
        /// </summary>
        [CategoryAttribute("Fwk.Factory"), Description("Indica el texto que se muestra en el text box cuando no se escribe ")]
        public String NullTextValue
        {
            get { return this.Properties.NullText; }
            set { this.Properties.NullText = value; }
        }

        #endregion

        public TextMemoEdit()
        {
            InitializeComponent();
        }

        public TextMemoEdit(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public bool ValidateValue()
        {

            if (_Required)
            {
                if (String.IsNullOrEmpty(this.Text.Trim()))
                {
                    if (string.IsNullOrEmpty(_RequiredErrorText))
                        this.ErrorText = Fwk.UI.Properties.Resources.msg_RequiredFiel;
                    else
                        this.ErrorText = _RequiredErrorText;

                    return false;

                }
            }
            //Si es NO es requerido y ademas esta vasio no se valida
            if (_Required == false && String.IsNullOrEmpty(this.Text)) return true;

           
            return true;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {


            if (!String.IsNullOrEmpty(_NotAllowedCharacters))
            {
                if (_NotAllowedCharacters.Contains(e.KeyChar))
                {
                    e.Handled = true;
                    return;
                }
            }
            base.OnKeyPress(e);
        }
    }
}
