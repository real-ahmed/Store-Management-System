using System.Collections.Generic;
using System.Data;

namespace store.BL
{
    internal class Brand
    {

        public static DataTable SelectBrands()
        {
            return DataManager.SelectData("SelectBrands");
        }

        public static void UpdateBrand(string Id, string Name)
        {
            DataManager.ExecuteProcedure("UpdateBrand", new Dictionary<string, object> { { "@id", Id }, { "@brand", Name } });
        }
        public static void DeleteBrand(string BrandId)
        {
            DataManager.ExecuteProcedure("DeleteBrand", new Dictionary<string, object> { { "@id", BrandId } });
        }
        public static void InsertBrand(string BrandName)
        {
            DataManager.ExecuteProcedure("InsertBrand", new Dictionary<string, object> { { "@brand", BrandName } });
        }
    }
}
