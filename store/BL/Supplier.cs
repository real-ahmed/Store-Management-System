using System.Collections.Generic;
using System.Data;

namespace store.BL
{
    internal class Supplier
    {

        public static DataTable SelectSupplier()
        {
            return DataManager.SelectData("SelectSupplier");
        }

        public static void DeleteSupplier(string id)
        {
            DataManager.ExecuteProcedure("DeleteSupplier", new Dictionary<string, object> { { "@id", id } });
        }

        public static void InsertSuplier(string supplier, string address, string contactperson, string phone, string email, string fax)
        {
            DataManager.ExecuteProcedure("InsertSuplier", new Dictionary<string, object> {
                {"@supplier",supplier },
                {"@address",address },
                {"@contactperson",contactperson },
                {"@phone",phone },
                {"@email",email },
                {"@fax",fax }
            });
        }

        public static void UpdateSuplier(string id, string supplier, string address, string contactperson, string phone, string email, string fax)
        {
            DataManager.ExecuteProcedure("UpdateSuplier", new Dictionary<string, object> {
                {"@id",id},
                {"@supplier",supplier },
                {"@address",address },
                {"@contactperson",contactperson },
                {"@phone",phone },
                {"@email",email },
                {"@fax",fax }
            });
        }


    }
}
