using System;
using System.Text;
using System.Configuration;
using System.Collections.Generic;

namespace Fwk.Bases
{
    /// <summary>
    /// Table Data Gateway.
    /// </summary>
	public abstract class TableDataGateway
    {
       
        private  static string _CnnStringKey = String.Empty;

        /// <summary>
        /// Clave de configuracion para la cadena de coneccion de la base de datos.-
        /// </summary>
        public static string CnnStringKey
        {
            get { return _CnnStringKey; }
            set { _CnnStringKey = value; }
        }
    }
}
