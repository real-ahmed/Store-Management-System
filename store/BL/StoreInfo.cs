using System;
using System.Data;
using System.Collections.Generic;

namespace store.BL
{
    internal class StoreInfo
    {
        public static string Name { get; private set; }
        public static string Address { get; private set; }
        public static double Tax { get; private set; }


        public static void GetStoreInfo()
        {
            DataTable td = DataManager.SelectData("SelectStoreInfo");
            Name = td.Rows[0]["StoreName"].ToString();
            Address = td.Rows[0]["StoreAddress"].ToString();
            Tax = Convert.ToDouble(td.Rows[0]["tax"]);
        }
        public static void SetStoreInfo(string StoreName,string StoreAddress,string tax)
        {
            DataManager.ExecuteProcedure("UpdateStoreSetting", new Dictionary<string, object>
            {
                {"@StoreName",StoreName},
                {"@StoreAddress",StoreAddress },
                {"@tax",double.Parse(tax)*0.01}
            });
            GetStoreInfo();
        }
    }
}
