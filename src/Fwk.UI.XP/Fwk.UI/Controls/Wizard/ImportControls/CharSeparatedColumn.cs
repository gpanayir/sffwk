using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;

namespace Fwk.UI.Controls.ImportControls
{
    /// <summary>
    /// Objeto que describe una columna de un archivo CSV.
    /// </summary>
    public class CharSeparatedColumn : Entity
    {
        #region [Fields]
        private string _name;
        private int _index;
        #endregion

        #region [Properties]
        /// <summary>
        /// Nombre de la columna del archivo
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// Indice de la columna dentro del archivo.
        /// </summary>
        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;
            }
        }
        #endregion
    }

    /// <summary>
    /// Colección de columnas de un archivo CSV
    /// </summary>
    public class CharSeparatedColumns : Entities<CharSeparatedColumn>
    {

    }
}
