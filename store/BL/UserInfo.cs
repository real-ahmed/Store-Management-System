using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace store.BL
{
    internal class UserInfo
    {
        public static string UserName { get; set; }
        public static string Name { get; set; }
        public static string Role { get; set; }
        public static string Id { get; set; }

        public static bool CheckUserPassword(string Password)
        {
            DataTable dt = DataManager.SelectData("CheckLoginData", new Dictionary<string, object>
            {
                {"@username" ,UserName},
                {"@password", Password}
            });
            if (dt.Rows.Count != 0) return true; else return false;
        }

        public static void ChangeUserPassword(string CurrentPass, string NewPass)
        {
            if (CheckUserPassword(CurrentPass))
                DataManager.ExecuteProcedure("ChangeUserPassword", new Dictionary<string, object>
                {
                    {"@username" ,UserName},
                    {"@password", NewPass}
                });
            else MessageBox.Show("your password is incorrect");

        }



    }
}
