using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;

namespace Fwk.UI.Controls
{
    public partial class UC_FileSelection : DevExpress.XtraEditors.XtraUserControl
    {

        #region [Private Vars]

        //private string _openFileDialogTitle;
        private bool _validFileSelected;
        private FileExistValidationRule fileExistValidationRule;
        public event EventHandler OnSelectedOk;
        #endregion
        
        #region [Properties]
        
        /// <summary>
        /// Establece u obtiene el filtro de archivos mostrado
        /// en el dialogo, por ejemplo: "Archivo C# | *.cs | Todos los archivos | *.*"
        /// </summary>
        public string FileDialogFilter
        {
            get
            {
                return openFileDialog.Filter;
            }
            set
            {
                openFileDialog.Filter = value;
            }
        }

        public bool IsValidFile
        {
            get
            {
                return _validFileSelected;
            }
            set
            {
                _validFileSelected = value;
            }
        }

        /// <summary>
        /// T�tulo mostrado en la ventana de dialogo
        /// para seleccionar un archivo.
        /// </summary>
        public string OpenFileDialogTitle
        {
            get
            {
                return openFileDialog.Title;
            }
            set
            {
                openFileDialog.Title = value;
            }
        }

        /// <summary>
        /// Establece u obtiene el valor que determina si el 
        /// control funciona en modo solo lectura o no.
        /// </summary>
        public bool ReadOnly
        {
            get
            {
                return buttonEdit.Properties.ReadOnly;
            }
            set
            {
                buttonEdit.Properties.ReadOnly = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string NullText
        {
            get
            {
                return buttonEdit.Properties.NullText;
            }
            set
            {
                buttonEdit.Properties.NullText = value;
            }
        }
        #endregion

        #region [Public Methods]

        public UC_FileSelection()
        {
            InitializeComponent();
            InitializeValidationRules();
            InitializeOpenDialog();
        }


        public string GetSelectdFilePath()
        {
            if (dxValidationProvider.Validate())
                return buttonEdit.Text;

            return string.Empty;
        }

        public void ClearFileName()
        {
            buttonEdit.Text = string.Empty;
        }
        #endregion

        #region [Private Methods]
        
        /// <summary>
        /// Inicializa las reglas de validaci�n utilizadas
        /// por lo obtejos del control.
        /// </summary>
        private void InitializeValidationRules()
        {
            fileExistValidationRule = new FileExistValidationRule();
            
            fileExistValidationRule.ErrorText = "El archivo ingresado no existe.";
            fileExistValidationRule.ErrorType = ErrorType.Warning;
            
            dxValidationProvider.SetValidationRule(buttonEdit, fileExistValidationRule);
            dxValidationProvider.Validate();
            
            fileExistValidationRule.Validated += new ValidatedEventhandler(fileExistValidationRule_Validated);
            
            
        }

        /// <summary>
        /// Inicializa el FileDialog
        /// </summary>
        private void InitializeOpenDialog()
        {

            openFileDialog.AutoUpgradeEnabled = true;
            openFileDialog.CheckFileExists = true;
            openFileDialog.Multiselect = false;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.ValidateNames = true;

        }

        /// <summary>
        /// Responde al envento Validated de la regla de validaci�n fileExisValidationRule
        /// utilizada por el control buttonEdit
        /// </summary>
        /// <param name="sender">El objeto que lanza el evento</param>
        /// <param name="e">Parametros del evento</param>
        void fileExistValidationRule_Validated(object sender, ValidatedEventArgs e)
        {
            _validFileSelected = e.IsValid;
            
            if (_validFileSelected)
            {
                OnValidFileSelected();
            }
        }
        #endregion
        
        private void buttonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();

            if(result == DialogResult.OK)
            {
                this.buttonEdit.Text = openFileDialog.FileName;

                if (OnSelectedOk != null)
                    OnSelectedOk(sender, e);
            }
        }

        private void buttonEdit_EditValueChanged(object sender, EventArgs e)
        {
            openFileDialog.FileName = buttonEdit.Text;
        }

        public event EventHandler ValidFileSelected;

        private void OnValidFileSelected()
        {
            if (ValidFileSelected != null)
                ValidFileSelected(this, new EventArgs());
        }

    }

    /// <summary>
    /// Regla utilizada para validar la existencia del
    /// archivo ingresado en el buttonEdit.
    /// </summary>
    public class FileExistValidationRule: ValidationRule
    {

        #region [Class Events]
        public event ValidatedEventhandler Validated;
        
        private void OnValidated(bool isValid)
        {
            if(Validated != null)
                Validated(this, new ValidatedEventArgs(isValid));
        }

        #endregion  
        
        public override bool Validate(Control control, object value)
        {
            string fileName = (string)value;
            bool isValid = File.Exists(fileName);
            OnValidated(isValid);
            return isValid;
        }

    }

    #region [ValidatedEvent Delegates]
    
    public delegate void ValidatedEventhandler(object sender, ValidatedEventArgs e);

    #endregion

    /// <summary>
    /// Argumentos del evento Validated de la clase
    /// FileExistValidationRule
    /// </summary>
    public class ValidatedEventArgs : EventArgs
    {
        #region [Private Vars]

        private bool _isValid;

        #endregion

        #region [Properties]
        /// <summary>
        /// Obtiene el
        /// </summary>
        public bool IsValid
        {
            get { return _isValid; }
        }
        #endregion

        #region [Constructors]
        public ValidatedEventArgs(bool isValid)
        {
            _isValid = isValid;
        }
        #endregion
    }
}
