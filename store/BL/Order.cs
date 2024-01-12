using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace store.BL
{
    internal class Order
    {
        public static bool CheckQty(string pid,int orderqty)
        {
            int qty = int.Parse(DataManager.SelectData("CheckQty", new Dictionary<string, object>
            {
                {"@pid",pid },
            }).Rows[0]["qty"].ToString());

            if (qty >= orderqty)
            {
                return true;
            }
            else
            {
                MessageBox.Show("The required quantity is not available");
                return false;
            }
        }
        public static void NewOrder(string ProductId, int Qyt)
        {
            if (CheckQty(ProductId, Qyt)) 
            {
                DataManager.ExecuteProcedure("InsertOrder", new Dictionary<string, object> {
                {"@pid",ProductId },
                {"@transno",Trans.TransNo },
                {"@qty",Qyt},
                {"@cashier",UserInfo.UserName},
                {"@sdate", DateTime.Now}

            });
            }

        }
        public static void AddOneqty(string ProductId, string OrderId)
        {
            if (CheckQty(ProductId, 1))
            {
                DataManager.ExecuteProcedure("AddOneqty", new Dictionary<string, object> {
                {"@id",OrderId }
            });
            }
        }
        public static void RemoveOneqty(string ProductId, string OrderId)
        {
            if (CheckQty(ProductId, 1))
            {
                DataManager.ExecuteProcedure("RemoveOneqty", new Dictionary<string, object> {
                {"@id",OrderId }
            });
            }
        }

        public static void DeleteOrder(string OrderId)
        {
            DataManager.ExecuteProcedure("DeleteOrder", new Dictionary<string, object> { { "@id", OrderId } });
        }
        public static void CancelOrder(string OrderId)
        {
            DataManager.ExecuteProcedure("CancelOrder", new Dictionary<string, object> { { "@id", OrderId } });
        }

        public static DataTable ShowCart()
        {
            return DataManager.SelectData("SelectCart", new Dictionary<string, object> {
                {"@transno",Trans.TransNo}
            });
        }

        public static double CalcTax(double total)
        {
            return (total * StoreInfo.Tax);
        }



        public static void AddDiscount(string OrderId, double dis)
        {
            DataManager.ExecuteProcedure("AddDiscount", new Dictionary<string, object>
            {
                {"@id",OrderId },
                {"@disc_percent", dis * 0.01}
            });
        }

    }
}
