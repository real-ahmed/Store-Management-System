using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using store.DAL.PL;

namespace store.BL
{
    internal class Log
    {


        public static void Login(string UserName, string Password)
        {
            DataTable dt = DataManager.SelectData("CheckLoginData", new Dictionary<string, object>
            {
                {"@username", UserName},
                {"@password", Password}
            });
            if (dt.Rows.Count != 0)
            {
                UserInfo.UserName = UserName;
                UserInfo.Name = dt.Rows[0]["fullname"].ToString();
                UserInfo.Role = dt.Rows[0]["role"].ToString();
                UserInfo.Id = dt.Rows[0]["id"].ToString();
                if (UserInfo.Role == "Cashier")
                {
                    frmCashier frmCashier = new frmCashier();
                    frmCashier.Show();
                    StoreInfo.GetStoreInfo();
                    frmLogin.instance.Hide();
                }
                else
                {
                    frmAdmin frmAdmin = new frmAdmin();
                    frmAdmin.Show();
                    StoreInfo.GetStoreInfo();
                    frmLogin.instance.Hide();
                }
            }
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }
        }
        public static void Logout(Form frm)
        {
            if (MessageBox.Show("Are you sure", "logout", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                UserInfo.UserName = string.Empty;
                UserInfo.Name = string.Empty;
                UserInfo.Role = string.Empty;
                frm.Dispose();
                frmLogin.instance.Show();
            }
        }
    }
}
