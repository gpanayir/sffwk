using System;
using System.Text;
using System.Data.Common;
using System.Globalization;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Fwk.Exceptions;

namespace Fwk.Logging.Targets
{
    /// <summary>
    /// Destino de tipo base de datos.
    /// </summary>
    /// <date>2006/09/02</date>
    /// <author>moviedo</author>
    public class DatabaseTarget : Target
    {
        #region <private members>
        private string _CnnStringName;
        #endregion

        #region <constructor>
        /// <summary>
        /// Constructor de DatabaseTarget.
        /// </summary>
        public DatabaseTarget()
        {
            this.Type = TargetType.Database;
        }
        #endregion

        #region <public properties>
        /// <summary>
        /// Nombre de la conexión de la base de datos 
        /// en la cual se escribirá el log del evento.
        /// Esta conexión debe estar configurada en la 
        /// Sección 'connectionStrings' del archivo de
        /// configuración App.Config.
        /// </summary>
        public string CnnStringName
        {
            get { return _CnnStringName; }
            set { _CnnStringName = value; }
        }
        #endregion

        #region <public overrides>
        /// <summary>
        /// Implementación de la escritura del log del evento
        /// en base de datos.
        /// </summary>
        /// <param name="pEvent">Evento a loguear.</param>
        public override void Write(Event pEvent)
        {
            if (this.CnnStringName.Trim().Length == 0)
            {
                throw new TechnicalException("Debe especificar cnnStringName en el archivo de configuración.");
            }
            Database wDataBase = DatabaseFactory.CreateDatabase(this._CnnStringName);
            DbCommand wCmd = wDataBase.GetStoredProcCommand("Logs_i");
            wDataBase.AddInParameter(wCmd, "@Id", System.Data.DbType.String, pEvent.Id.ToString());
            wDataBase.AddInParameter(wCmd, "@Message", System.Data.DbType.String, pEvent.Message);
            wDataBase.AddInParameter(wCmd, "@Source", System.Data.DbType.String, pEvent.Source);
            wDataBase.AddInParameter(wCmd, "@Type", System.Data.DbType.String, pEvent.Type.ToString().ToUpper());
            wDataBase.AddInParameter(wCmd, "@Machine", System.Data.DbType.String, pEvent.Machine);
            wDataBase.AddInParameter(wCmd, "@DateTime", System.Data.DbType.DateTime, pEvent.DateAndTime.ToString("yyyy-MM-dd HH:mm:ss.ffff", CultureInfo.InvariantCulture));
            wDataBase.AddInParameter(wCmd, "@User", System.Data.DbType.String, pEvent.User);
            wDataBase.ExecuteNonQuery(wCmd);
        }
        #endregion
    }
}
