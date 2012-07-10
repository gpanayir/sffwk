using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using DevExpress.XtraEditors.Controls;


namespace Fwk.UI.Controls
{
    public partial class EnumComboBox : ComboBoxDxBase, ISupportInitialize
    {
        #region [Constructor]

        public EnumComboBox()
        {
            InitializeComponent();
        }

        public EnumComboBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion

        #region [Private Vars]

        private Fwk.UI.Common.TypesEnum _enumType = Fwk.UI.Common.TypesEnum.AuthenticationModeEnum;
        
        #endregion

        #region [Properties]
        
        /// <summary>
        /// Obtiene u establece el objeto seleccionado en el combo
        /// a través de su identificador. 
        /// </summary>
        public Fwk.UI.Common.TypesEnum EnumType
        {
            get
            {
                return _enumType;
            }
            set
            {
                _enumType = value;
                if (!Fwk.HelperFunctions.EnvironmentFunctions.IsInDesigntime())
                {
                    RefreshData();
                }
            }
        }

        #endregion

        #region [Public Methods]

        /// <summary>
        /// Fuerza al control a recargar sus valores.
        /// </summary>
        public void RefreshData()
        {
            FillComboBox();
        }
        #endregion

        #region [Private Methods]

        /// <summary>
        /// Llena el combo con los valores de la enumeración
        /// seleccionada.
        /// </summary>
        private void FillComboBox()
        {

            try
            {
                ImageComboBoxItemCollection items = this.Properties.Items;
                items.Clear();
                Type enumType =
                    Fwk.HelperFunctions.ReflectionFunctions.CreateType(
                        Fwk.UI.Common.HelperFunctions.Enumerations.GetDescription(_enumType), "Fwk.UI.Common");

                items.AddEnum(enumType);

                foreach (ImageComboBoxItem item in items)
                {

                    item.Description = Fwk.UI.Common.HelperFunctions.Enumerations.GetDescription((Enum)item.Value);

                }

                this.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            }
            catch
            {
                this.EditValue = "Error obteniendo los valores";
                this.Properties.ReadOnly = true;
            }
        }

        /// <summary>
        /// Realiza las tareas de inicilización de las propiedades
        /// del control.
        /// </summary>
        private void InitializeControl()
        {
        }

        #endregion

        #region ISupportInitialize Members

        public void BeginInit()
        {
            return;
        }

        public void EndInit()
        {
            this.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.Properties.AutoComplete = true;
            this.Properties.NullText = "<Seleccione una opción...>";
            this.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            if (!Fwk.HelperFunctions.EnvironmentFunctions.IsInDesigntime())
            {
                FillComboBox();
            }
        }

        #endregion
    }
}
