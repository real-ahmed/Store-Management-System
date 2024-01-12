using store.DAL.PL;

namespace store.BL
{

    internal class Cashier
    {
        public static frmCashier frmcashier { get; set; }

        public static void ReloudCart()
        {
            frmcashier.LoadCart();
        }

    }
}
