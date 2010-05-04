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

namespace back.BackEnd.DAC
{
    public class SampleDAC :BaseDAC
    {
        public static SalesOrderDetailList Search(string pcompany)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;

            SalesOrderDetailList list;
            SalesOrderDetail sales;


            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(pcompany);
                wCmd = wDataBase.GetStoredProcCommand("SalesOrderDetail_s");




                wDataBase.ExecuteReader(wCmd);

                list = new SalesOrderDetailList();

                using (IDataReader reader = wDataBase.ExecuteReader(wCmd))
                {
                    while (reader.Read())
                    {
                        sales = new SalesOrderDetail();


                        sales.CarrierTrackingNumber = reader["CarrierTrackingNumber"].ToString();
                        sales.LineTotal = Convert.ToInt32(reader["LineTotal"]);
                        sales.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                        sales.ProductID = Convert.ToInt32(reader.GetOrdinal("ProductID")) ;
                        sales.OrderQty = Convert.ToInt32(reader["OrderQty"]);
                        sales.rowguid = (Guid) reader["rowguid"]; 
                        sales.SalesOrderDetailID = Convert.ToInt32(reader["SalesOrderDetailID"]); 
                        sales.SalesOrderID = Convert.ToInt32(reader["SalesOrderID"]); 
                        sales.SpecialOfferID = Convert.ToInt32(reader["SpecialOfferID"]);
                        sales.UnitPrice = Convert.ToDouble(reader["UnitPrice"]);
                        sales.UnitPriceDiscount = Convert.ToDouble(reader["UnitPriceDiscount"]); 


                        list.Add(sales);
                    }
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
