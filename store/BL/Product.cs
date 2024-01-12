using System.Collections.Generic;
using System.Data;

namespace store.BL
{
    internal class Product
    {
        public static DataTable SelectProduct(string search)
        {
            return DataManager.SelectData("SelectProduct", new Dictionary<string, object> {
                { "@search", search } });
        }
        public static DataTable SelectProductForCasher(string search)
        {
            return DataManager.SelectData("SelectProductForCasher", new Dictionary<string, object> { { "@search", search } });
        }
        public static DataTable SelectProductForStockIn(string search)
        {
            return DataManager.SelectData("SelectProductForStockIn", new Dictionary<string, object> { { "@search", search } });
        }
        public static void DeleteProduct(string id)
        {
            DataManager.ExecuteProcedure("DeleteProduct", new Dictionary<string, object> { { "@id", id } });
        }

        public static void UpdateProduct(string Id, string BarCode, string Peoduct, string b_id, string c_id, double price)
        {
            DataManager.ExecuteProcedure("UpdateProduct", new Dictionary<string, object> {
                { "@id", Id },
                { "@barcode", BarCode },
                { "@product", Peoduct },
                { "@b_id", b_id },
                { "@c_id", c_id },
                { "@price", price }
            });
        }

        public static void InsertProduct(string BarCode, string Peoduct, string b_id, string c_id, double price)
        {
            DataManager.ExecuteProcedure("InsertProduct", new Dictionary<string, object> {
                { "@barcode", BarCode },
                { "@product", Peoduct },
                { "@b_id", b_id },
                { "@c_id", c_id },
                { "@price", price }
            });
        }

        public static string SearchByBarcode(string Barcode)
        {
            DataTable dt = DataManager.SelectData("SelectProductByBarcode", new Dictionary<string, object> { { "@barcode", Barcode } });
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["id"].ToString();
            }
            return string.Empty;
        }
    }
}
