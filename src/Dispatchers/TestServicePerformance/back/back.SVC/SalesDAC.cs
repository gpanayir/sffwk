using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Exceptions;
using Fwk.Bases;
using back.BackEnd.DAC;
using back.Common.BE;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Collections;

namespace back.BackEnd.DAC
{
    public class SampleDAC : BaseDAC
    {
        public static SalesOrderDetailList Searchzz(string pcompany, out double mappingTiem, out  double sqlCallTie)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;
            SalesOrderDetailList list;
            SalesOrderDetail sales;
            Stopwatch watch = new Stopwatch();
            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(pcompany);
                wCmd = wDataBase.GetStoredProcCommand("SalesOrderDetail_s");



                watch.Start();
                IDataReader reader = wDataBase.ExecuteReader(wCmd);
                watch.Stop();
                sqlCallTie = watch.Elapsed.TotalMilliseconds;


                watch.Reset();
                watch.Start();
                list = new SalesOrderDetailList();


                while (reader.Read())
                {
                    sales = new SalesOrderDetail();


                    sales.CarrierTrackingNumber = reader["CarrierTrackingNumber"].ToString();
                    sales.LineTotal = Convert.ToInt32(reader["LineTotal"]);
                    sales.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                    sales.ProductID = Convert.ToInt32(reader.GetOrdinal("ProductID"));
                    sales.OrderQty = Convert.ToInt32(reader["OrderQty"]);
                    sales.rowguid = (Guid)reader["rowguid"];
                    sales.SalesOrderDetailID = Convert.ToInt32(reader["SalesOrderDetailID"]);
                    sales.SalesOrderID = Convert.ToInt32(reader["SalesOrderID"]);
                    sales.SpecialOfferID = Convert.ToInt32(reader["SpecialOfferID"]);
                    sales.UnitPrice = Convert.ToDouble(reader["UnitPrice"]);
                    sales.UnitPriceDiscount = Convert.ToDouble(reader["UnitPriceDiscount"]);


                    list.Add(sales);
                }
                reader.Close();
                reader.Dispose();

                watch.Stop();
                mappingTiem = watch.Elapsed.TotalMilliseconds;

                return list;
            }
            catch (Exception ex)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }
        }


        public static SalesOrderDetailList Search(string pcompany, out double mappingTiem, out  double sqlCallTie)
        {
            SqlConnection conn = new SqlConnection(GetCnnstring_App(pcompany));
            conn.StatisticsEnabled = true;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SalesOrderDetail_s";

            SalesOrderDetailList list;
            SalesOrderDetail sales;
            Stopwatch watch = new Stopwatch();
            try
            {
                conn.Open();
             

                watch.Start();
                IDataReader reader = cmd.ExecuteReader();
                watch.Stop();
                sqlCallTie = watch.Elapsed.TotalMilliseconds;


                watch.Reset();
                watch.Start();
                list = new SalesOrderDetailList();


                while (reader.Read())
                {
                    sales = new SalesOrderDetail();


                    sales.CarrierTrackingNumber = reader["CarrierTrackingNumber"].ToString();
                    sales.LineTotal = Convert.ToInt32(reader["LineTotal"]);
                    sales.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                    sales.ProductID = Convert.ToInt32(reader.GetOrdinal("ProductID"));
                    sales.OrderQty = Convert.ToInt32(reader["OrderQty"]);
                    sales.rowguid = (Guid)reader["rowguid"];
                    sales.SalesOrderDetailID = Convert.ToInt32(reader["SalesOrderDetailID"]);
                    sales.SalesOrderID = Convert.ToInt32(reader["SalesOrderID"]);
                    sales.SpecialOfferID = Convert.ToInt32(reader["SpecialOfferID"]);
                    sales.UnitPrice = Convert.ToDouble(reader["UnitPrice"]);
                    sales.UnitPriceDiscount = Convert.ToDouble(reader["UnitPriceDiscount"]);


                    list.Add(sales);
                }
                reader.Close();
                reader.Dispose();

                watch.Stop();
                mappingTiem = watch.Elapsed.TotalMilliseconds;

                //Recojo las estadísticas
                Hashtable htStats = (Hashtable)conn.RetrieveStatistics();
                StringBuilder s = new StringBuilder();
                foreach (string stat in htStats.Keys)
                {
                    s.AppendLine("- " + stat + " = " + htStats[stat].ToString());
                }
                return list;
            }
            catch (Exception ex)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }
        }
    }
}
