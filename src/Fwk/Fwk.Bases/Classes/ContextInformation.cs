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
        //string _SecurityProviderName;
		string _UserId;
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
        [Obsolete("UserName se dejara de utilizar en proximas versiones de fwk, en su lugar utilice UserId")]
		public string UserName
		{
			get { return _UserId; }
			set { _UserId = value; }
		}

        /// <summary>
        /// Indica el identificador usuario logueado en el host que inicio el servicio.-
        /// Aqui puede alojar valores de cualquier tipo (guid,int, string, etc) llevados a String.-
        /// </summary>
        public string UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
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

        ///// <summary>
        ///// 
        ///// </summary>
        //public string SecurityProviderName
        //{
        //    get { return _SecurityProviderName; }
        //    set { _SecurityProviderName = value; }
        //}
	}
}
