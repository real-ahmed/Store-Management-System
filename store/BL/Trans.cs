using System;
using System.Collections.Generic;
using System.Data;

namespace store.BL
{
    internal class Trans
    {
        public static string TransNo;

        public static string GenTranNo()
        {
            string tDate = DateTime.Now.ToString("yyyyMMdd");
            int count;
            DataTable dt = CheckForTrans(tDate);

            if (dt.Rows.Count > 0)
            {
                count = int.Parse(dt.Rows[0]["transno"].ToString().Substring(8));
                TransNo = tDate + (count + 1);
            }
            else
            {
                TransNo = tDate + "1001";
            }
            return TransNo;
        }

        private static DataTable CheckForTrans(string tDate)
        {
            return DataManager.SelectData("CheckForTrans", new Dictionary<string, object> { { "@transno", tDate } });
        }

        public static void ConfirmTran(string trasnno)
        {
            DataManager.ExecuteProcedure("ConfirmTrans", new Dictionary<string, object>
            {
                {"@transno",trasnno},
            });
        }
        public static void DeleteTran(string trasnno)
        {
            DataManager.ExecuteProcedure("DeleteTrans", new Dictionary<string, object>
            {
                {"@transno",trasnno},
            });
        }

        public static DataTable SelectTrans(object CahierId, DateTime FromDate, DateTime ToDate)
        {
            if (CahierId == null)
                CahierId = "%";else
                CahierId = CahierId.ToString();
            return DataManager.SelectData("SelectTrans", new Dictionary<string, object>
            {
                {"@cahierid",CahierId },
                {"@fromdate",FromDate },
                {"@todate",ToDate }
            });
        }
        public static DataTable SelectCanceledTrans(object CahierId, DateTime FromDate, DateTime ToDate)
        {
            if (CahierId == null)
                CahierId = "%";
            else
                CahierId = CahierId.ToString();
            return DataManager.SelectData("SelectCanceledTrans", new Dictionary<string, object>
            {
                {"@cahierid",CahierId },
                {"@fromdate",FromDate },
                {"@todate",ToDate }
            });
        }
    }
}
