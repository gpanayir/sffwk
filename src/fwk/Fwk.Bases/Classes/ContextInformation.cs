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
		string m_UserName;
        string m_HostName;
        string m_ServerName;
        DateTime m_ServerTime = new DateTime();
        DateTime m_HostTime = new DateTime();


        /// <summary>
        /// Indica el host que inicio la peticion del servicio .-
        /// </summary>
        public string HostName
        {
            get { return m_HostName; }
            set { m_HostName = value; }
        }

        /// <summary>
        /// Indica fecha y hora de inicio o fin del servicio del lado del Cliente.-
        /// Para un Request  -->  fecha y hora de inicio del lado del cliente (horario de inicio desde el host).-
        /// Para un Response -->  fecha y hora de finalizacion del lado del cliente (horario de llegada al host)-
        /// </summary>
        public DateTime HostTime
        {
            get { return m_HostTime; }
            set { m_HostTime = value; }
        }

        /// <summary>
        /// Indica el server que atendio el servicio servicio .-
        /// </summary>
        public string ServerName
        {
            get { return m_ServerName; }
            set { m_ServerName = value; }
        }

        /// <summary>
        /// Indica fecha y hora de inicio o fin del servicio del lado del Servidor o despachador de servicio.-
        /// Para un Request  -->  fecha y hora de inicio del lado del server .-
        /// Para un Response -->  fecha y hora de finalizacion del lado del server .-
        /// </summary>
        public DateTime ServerTime
        {
            get { return m_ServerTime; }
            set { m_ServerTime = value; }
        }


        /// <summary>
        /// Indica el usuario logueado en el host que inicio el servicio.-
        /// </summary>
		public string UserName
		{
			get { return m_UserName; }
			set { m_UserName = value; }
		}

	}
}
