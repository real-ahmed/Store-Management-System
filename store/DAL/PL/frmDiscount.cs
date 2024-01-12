using System;
using System.Windows.Forms;
using store.BL;

namespace store.DAL.PL
{
    public partial class frmDiscount : Form
    {
        private string pid;
        frmCashier frmCasher;
        public frmDiscount(frmCashier frmCasher)
        {
            InitializeComponent();
            this.frmCasher = frmCasher;

        }

        public void SetInfo(string pid, string total)
        {
            this.pid = pid;
            txtTotal.Text = total;
            txtdis.Focus();
        }

        private void txtdis_TextChanged(object sender, EventArgs e)
        {
            CalcDis();
        }
        private void CalcDis()
        {

            if (txtdis.Text != string.Empty)
            {
                txtDisAmount.Text = (double.Parse(txtTotal.Text) * (double.Parse(txtdis.Text) * 0.01)).ToString("#,##0.00");
            }

        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

            Order.AddDiscount(pid, double.Parse(txtdis.Text));
            frmCasher.LoadCart();
            this.Dispose();



        }

        private void txtdis_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataValidators.TakeOnlyInt(sender, e);

        }
    }
}
