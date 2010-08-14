using System;
using System.Collections.Generic;
using System.Text;

namespace Fwk.Bases
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
	public class ContextInformation
	{
        string _CompanyId;
        
		string _UserName;
        string _HostName;
        string _ServerName;
        DateTime _ServerTime = new DateTime();
        DateTime _HostTime = new DateTime();


        /// <summary>
        /// Indica el host que inicio la peticion del servicio .-
        /// </summary>
        public string HostName
        {
            get { return _HostName; }
            set { _HostName = value; }
        }

        /// <summary>
        /// Indica fecha y hora de inicio o fin del servicio del lado del Cliente.-
        /// Para un Request  -->  fecha y hora de inicio del lado del cliente (horario de inicio desde el host).-
        /// Para un Response -->  fecha y hora de finalizacion del lado del cliente (horario de llegada al host)-
        /// </summary>
        public DateTime HostTime
        {
            get { return _HostTime; }
            set { _HostTime = value; }
        }

        /// <summary>
        /// Indica el server que atendio el servicio servicio .-
        /// </summary>
        public string ServerName
        {
            get { return _ServerName; }
            set { _ServerName = value; }
        }

        /// <summary>
        /// Indica fecha y hora de inicio o fin del servicio del lado del Servidor o despachador de servicio.-
        /// Para un Request  -->  fecha y hora de inicio del lado del server .-
        /// Para un Response -->  fecha y hora de finalizacion del lado del server .-
        /// </summary>
        public DateTime ServerTime
        {
            get { return _ServerTime; }
            set { _ServerTime = value; }
        }


        /// <summary>
        /// Indica el usuario logueado en el host que inicio el servicio.-
        /// </summary>
		public string UserName
		{
			get { return _UserName; }
			set { _UserName = value; }
		}

        /// <summary>
        /// Identificador de empresa, cliente donde este instalado o para quien este instalado.-
        /// Utiil para identificar logs, discriminar conecciones, etc.-
        /// </summary>
        public string CompanyId
        {
            get { return _CompanyId; }
            set { _CompanyId = value; }
        }
	}
}
