using System.Collections.Generic;

namespace store.BL
{
    internal class UsersSettings
    {
        public static void InsertUser(string username, string password, string role, string fullname)
        {
            DataManager.ExecuteProcedure("InsertUser", new Dictionary<string, object> {
               {"@username",username },
               {"@password",password},
               {"@role",role },
               {"@fullname",fullname }
           });
        }
    }
}
