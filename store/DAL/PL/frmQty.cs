using System.Windows.Forms;
using store.BL;

namespace store.DAL.PL
{
    public partial class frmQty : Form
    {


        private string ProductId;
        public frmQty(string ProductId)
        {
            InitializeComponent();
            this.ProductId = ProductId;
        }


        private void numQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && numQty.Value != 0)
            {
                Order.NewOrder(ProductId, (int)numQty.Value);
                Cashier.ReloudCart();
                this.Dispose();
            }
        }
    }
}
