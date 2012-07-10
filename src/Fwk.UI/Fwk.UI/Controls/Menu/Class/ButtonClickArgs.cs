using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;

namespace Fwk.UI.Controls.Menu
{
    /// <summary>
    /// Argumentos del evento MenuButtonClick
    /// </summary>
    public class ButtonClickArgs<T> : EventArgs
    {

        #region [Private Vars]

        XtraForm _Form;

        public XtraForm Form
        {
            get { return _Form; }
            set { _Form = value; }
        }

        private T _buttonClicked;

        /// <summary>
        /// Botón presionado.
        /// </summary>
        public T ButtonClicked
        {
            get { return _buttonClicked; }
        }

        #endregion

        #region [Constructors]
        /// <summary>
        /// Inicializa una nueva instancia de la clase MenuButtonClickArgs
        /// </summary>
        /// <param name="pButtonClicked"></param>
        public ButtonClickArgs(T pButtonClicked)
        {
            _buttonClicked = pButtonClicked;
            
        }
        #endregion

    }
}
