using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.BL
{
    internal class Sales
    {
        public static DataTable SelectCashiers()
        {
            return DataManager.SelectData("SelectCashiers");
        }
    }
}
