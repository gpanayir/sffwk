using System;
using System.Data;

namespace Fwk.HelperFunctions
{

	/// <summary>
	/// Utilidades para fechas.
	/// </summary>
	public class DateFunctions
	{
        public enum TimeMeasuresEnum
        {
            FromDays,
            FromHours,
            FromMinutes,
            FromSeconds
        }
		/// <summary>
		/// Algoritmo que determina si hay o no InterSección entre dos rangos de fechas
		/// </summary>
		/// <param name="D1">Fecha Desde del primer rango</param>
		/// <param name="H1">Fecha Hasta del primer rango</param>
		/// <param name="D2">Fecha Desde del segundo rango</param>
		/// <param name="H2">Fecha Hasta del segundo rango</param>
		/// <returns>Retorna el rango de InterSección en una DataRow un bool que dice si hay o no interseccion</returns>
        /// <Date>29-03-2006</Date>
        /// <Author>moviedo</Author>
		public static DataTable Interseccion(DateTime D1,DateTime H1,DateTime D2,DateTime H2)
		{

			DateTime Dr;
			DateTime Hr;

			bool wInterseccion ;

			if(D1 < D2 )
			{
				//D1-----------H1
				// D2-------------H2
				if (D2 > H1)
				{
					Dr = new DateTime(1899,12,31);
					Hr = new DateTime(1899,12,31);
					wInterseccion = false ;
				}
				else
				{
					//D1-----------H1
					// D2-------------H2
					if (H1 < H2)
					{ 
						Dr =D2;
						Hr = H1;
						wInterseccion = true;
					}
					else
					{
						//D1--------------------------H1
						// D2-------------H2
						Dr = D2;
						Hr = H2;
						wInterseccion = true;
					}
				}
			}
			else
			{ // D1-------------H1
				//D2-------------H2
				if (D1>H2)
				{
					Dr = new DateTime(1899,12,31);
					Hr = new DateTime(1899,12,31);
					wInterseccion = false ;
				}
				else
				{
					// D1-------------H1
					//D2-------------H2
					if (H2 < H1)
					{
						Dr =D1;
						Hr = H2;
						wInterseccion = true;
					}
					else
					{ //D1---------------------------------H1
						// D2-------------H2
						Dr = D1;
						Hr = H1;
						wInterseccion = true;
					}
				}
			}
			DataTable wDtt = new DataTable ();
			DataColumn wDC = new DataColumn ();
			wDC.ColumnName ="Dr";
			wDtt.Columns .Add (wDC);
			wDC = new DataColumn ();
			wDC.ColumnName ="Hr";
			wDtt.Columns .Add (wDC);
			wDC = new DataColumn ();
			wDC.ColumnName ="Interseccion";
			wDtt.Columns .Add (wDC);
			DataRow wDtr = wDtt.NewRow ();
			wDtr["Dr"]= Dr;
			wDtr["Hr"]= Hr;
			wDtr["Interseccion"]= wInterseccion;
			wDtt.Rows.Add (wDtr); 
			return wDtt;
		}

        /// <summary>
        /// Retorna un string con el formato hh:mm:ss.-
        /// Por ejemplo si la acantidad de horas se superace en una unidad de 
        /// las 24 horas, el valor retornado es por ejemplo: 26:00:01
        /// </summary>
        /// <param name="pSeconds"></param>
        /// <returns>String con el formato hh:mm:ss</returns>
        /// <Date>18-01-2007</Date>
        /// <Author>moviedo</Author>
        public static string GetHH_MM_SS_FromInt32(Int32 pSeconds)
        {
            Int32 hours = pSeconds / 3600;
            Int32 minutes = (pSeconds - (hours * 3600)) / 60;
            pSeconds = pSeconds - (hours * 3600 + minutes * 60);
            return String.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, pSeconds);
        }

        /// <summary>
        /// Retorna una fecha con dia mes año actual mas el parceo pSeconds a hh:mm:ss
        /// </summary>
        /// <param name="pSeconds"></param>
        /// <returns></returns>
        /// <Date>18-03-2008</Date>
        /// <Author>moviedo</Author>
        public static DateTime GetDateTimeFromSeconds(int pSeconds)
        {
            Int32 hours = pSeconds / 3600;
            Int32 minutes = (pSeconds - (hours * 3600)) / 60;
            pSeconds = pSeconds - (hours * 3600 + minutes * 60);
            DateTime wDatetime = System.DateTime.Today;
            wDatetime.AddHours(hours);
            wDatetime.AddMinutes(minutes);
            wDatetime.AddSeconds(pSeconds);
            return wDatetime;
        }

        /// <summary>
        /// Retorna el 1° día del Mes. Por ejemplo: 01/08/1978 11:59:59
        /// </summary>
        /// <param name="pMonth">Mes del que se desea obtener el primer día</param>
        /// <param name="pYear">Año del que se desea obtener</param>
        /// <returns>DateTime del 1° dia del mes. Por Ej: 01/10/2008 11:59:59</returns>
        /// <Date>15-01-2009</Date>
        /// <Author>Andres Aguirre</Author>
        public static DateTime GetFirstDayOfMonth(Int16 pMonth, Int16 pYear)
        {
            return (new DateTime(pYear, pMonth, 1));
        }

        /// <summary>
        /// Retorna el último dia del Mes. Por Ejemplo: 31/08/2009 11:59:59
        /// </summary>
        /// <param name="pMonth">Mes del que se desea obtener el primer día</param>
        /// <param name="pYear">Año del que se desea obtener</param>
        /// <returns>DateTime del último dia del mes. Por Ej: 31/01/2008 11:59:59</returns>
        /// <Date>15-01-2009</Date>
        /// <Author>Andres Aguirre</Author>
        public static DateTime GetLastDayOfMonth(Int16 pMonth, Int16 pYear)
        {
            return GetFirstDayOfMonth(pYear, pMonth).AddMonths(1).AddTicks(-1); 
        }

        /// <summary>
        /// Retorna un string con la fecha en formato ISO. Por Ejemplo: 2009-07-14T15:43:25.683
        /// </summary>
        /// <param name="pDateTime">Fecha</param>
        /// <returns>String en formato ISO del DateTime pasado. Por Ej: 2009-07-14T15:43:25.683</returns>
        /// <Date>23-07-2009</Date>
        /// <Author>Marcelo Oviedo</Author>
        public static string ToDateTimeISO(DateTime pDateTime)
        {
            return string.Format("{0:s}", pDateTime);
        }

	}

}