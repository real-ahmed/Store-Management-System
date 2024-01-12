using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.BL
{
    internal class Dashboard
    {
        public static double TotalDailySales()
        {
            return double.Parse(DataManager.SelectData("TotalDailySales").Rows[0][0].ToString());
        }

        public static int TotalDailyOrders()
        {
            return int.Parse(DataManager.SelectData("TotalDailyOrders").Rows[0][0].ToString());
        }
        public static int TotalDailyCancel()
        {
            return int.Parse(DataManager.SelectData("TotalDailyCancel").Rows[0][0].ToString());
        }
    }
}
