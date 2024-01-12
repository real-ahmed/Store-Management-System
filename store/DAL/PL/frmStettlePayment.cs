using System;
using System.Windows.Forms;
using store.BL;

namespace store.DAL.PL
{
    public partial class frmStettlePayment : Form
    {
        string transno;
        frmCashier frmCashier;
        public frmStettlePayment(frmCashier frmCashier)
        {
            InitializeComponent();
            this.frmCashier = frmCashier;
        }
        public void SetInfo(string total, string transno)
        {
            this.transno = transno;
            txtTotal.Text = total;
        }
        #region Buttons
        private void btnOne_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnOne.Text;
        }

        private void btnTow_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnTow.Text;
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnThree.Text;
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnFour.Text;
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnFive.Text;
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnSix.Text;
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnSeven.Text;

        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnEight.Text;
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnNine.Text;
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnZero.Text;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnDot.Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCash.Clear();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if ((double.Parse(txtTotal.Text)) > (double.Parse("0" + txtCash.Text)))
            {
                MessageBox.Show("Please enter valid cash amount");
            }
            else
            {
                Trans.ConfirmTran(transno);
                frmCashier.NewTrans();
                this.Dispose();
            }
            
        }
        #endregion

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            txtCharge.Text = ((double.Parse("0" + txtCash.Text)) - (double.Parse(txtTotal.Text))).ToString("#,##0.00");
        }

        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {
                DataValidators.TakeOnlyNubers(sender, e);
        }
    }
}
