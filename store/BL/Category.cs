using System.Collections.Generic;
using System.Data;

namespace store.BL
{
    internal class Category
    {
        public static DataTable SelectCategory()
        {
            return DataManager.SelectData("SelectCategory");
        }
        public static void DeleteCategory(string id)
        {
            DataManager.ExecuteProcedure("DeleteCategory", new Dictionary<string, object> { { "@id", id } });
        }

        public static void UpdateCaregory(string Id, string Name)
        {
            DataManager.ExecuteProcedure("UpdateCaregory", new Dictionary<string, object> { { "@id", Id },
                { "@category", Name } });
        }
        public static void InsertCaregory(string Name)
        {
            DataManager.ExecuteProcedure("InsertCaregory", new Dictionary<string, object> { { "@category", Name } });
        }

    }
}
