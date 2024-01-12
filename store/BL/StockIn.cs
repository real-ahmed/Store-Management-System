using System;
using System.Collections.Generic;
using System.Data;

namespace store.BL
{
    internal class StockIn
    {
        public static string GenReferenceNo()
        {
            Random rand = new Random();
            return rand.Next().ToString();
        }
        public static DataTable SelectSuplierForStock()
        {
            return DataManager.SelectData("SelectSuplierForStock");
        }
        public static string[] SelectSupplierInfo(string supllier)
        {
            string[] ret = new string[2];
            DataTable dt = DataManager.SelectData("SelectSupplierInfo", new Dictionary<string, object> { { "@supplier", supllier } });
            if (dt.Rows.Count > 0)
            {
                ret[0] = dt.Rows[0]["address"].ToString();
                ret[1] = dt.Rows[0]["contactperson"].ToString(); ;
            }

            return ret;

        }

        public static void InsertStockin(string ReferenceNo, string Supllier, string productId, DateTime date)
        {
            DataManager.ExecuteProcedure("InsertStockin", new Dictionary<string, object>
            {
                {"@refno",ReferenceNo },
                {"@supplier_username",Supllier },
                {"@sdate",date},
                {"@pid",productId },
                {"@stockinby_username",UserInfo.UserName},
            });
        }

        public static DataTable SelectStockIn()
        {
            return DataManager.SelectData("SelectStockIn");
        }

        public static DataTable SelectStockInRecord()
        {
            return DataManager.SelectData("SelectStockInRecord");
        }
        public static void ConfirmStockIn(string id, string qty)
        {
            DataManager.ExecuteProcedure("ConfirmStockIn", new Dictionary<string, object> {
                {"@id",id },
                {"@qty",qty }
            });
        }
    }
}
