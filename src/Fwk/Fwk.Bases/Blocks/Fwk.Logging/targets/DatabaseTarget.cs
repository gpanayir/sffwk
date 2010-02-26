using System;
using System.Text;
using System.Data.Common;
using System.Globalization;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Fwk.Exceptions;
using System.Data;

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
            Database wDataBase = DatabaseFactory.CreateDatabase(_CnnStringName);
            DbCommand wCmd = wDataBase.GetStoredProcCommand("Logs_i");
            wDataBase.AddInParameter(wCmd, "@Id", System.Data.DbType.Guid, pEvent.Id);
            wDataBase.AddInParameter(wCmd, "@Message", System.Data.DbType.String, pEvent.Message.Text);
            wDataBase.AddInParameter(wCmd, "@Source", System.Data.DbType.String, pEvent.Source);
            wDataBase.AddInParameter(wCmd, "@LogType", System.Data.DbType.String, pEvent.LogType.ToString());
            wDataBase.AddInParameter(wCmd, "@Machine", System.Data.DbType.String, pEvent.Machine);
            wDataBase.AddInParameter(wCmd, "@LogDate", System.Data.DbType.DateTime, pEvent.LogDate);
            wDataBase.AddInParameter(wCmd, "@UserLoginName", System.Data.DbType.String, pEvent.UserLoginName);

            wDataBase.ExecuteNonQuery(wCmd);
        }

        /// <summary>
        /// SearchByParam
        /// </summary>
        ///<param name="pEvent">Event</param>
        /// <returns>LogsList</returns>
        /// <Date>2010-02-26T10:05:27</Date>
        /// <Author>moviedo</Author>
        public  List<Event> SearchByParam(Event pEvent)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;


            List<Event> wEventList = new List<Event>();
            Event wEvent;


            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(_CnnStringName);
                wCmd = wDataBase.GetStoredProcCommand("Logs_sp");

                wDataBase.AddInParameter(wCmd, "Message", System.Data.DbType.String, pEvent.Message);

                wDataBase.AddInParameter(wCmd, "Source", System.Data.DbType.String, pEvent.Source);

                wDataBase.AddInParameter(wCmd, "LogType", System.Data.DbType.String, pEvent.LogType);

                wDataBase.AddInParameter(wCmd, "Machine", System.Data.DbType.String, pEvent.Machine);

                wDataBase.AddInParameter(wCmd, "LogDate", System.Data.DbType.DateTime, pEvent.LogDate);

                wDataBase.AddInParameter(wCmd, "UserLoginName", System.Data.DbType.String, pEvent.UserLoginName);

                using (IDataReader reader = wDataBase.ExecuteReader(wCmd))
                {
                    while (reader.Read())
                    {
                        wEvent = new Event();

                        wEvent.Message.Text = reader["Message"].ToString();
                        wEvent.Source = reader["Source"].ToString();
                        wEvent.LogType = (EventType)reader["LogType"];
                        wEvent.Machine = reader["Machine"].ToString();
                        wEvent.LogDate = Convert.ToDateTime(reader["Machine"]);
                        wEvent.UserLoginName = reader["UserLoginName"].ToString();
                        wEventList.Add(wEvent);
                    }
                }

                return wEventList;

            }
            catch (Exception ex)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }

        }

        #endregion
    }
}
