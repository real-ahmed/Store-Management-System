using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using store.BL;

namespace store.DAL.PL
{

    public partial class frmCashier : Form
    {
        public frmCashier()
        {
            InitializeComponent();
            lblUserName.Text = UserInfo.UserName;
            lblRole.Text = UserInfo.Name + " | " + UserInfo.Role;
            NewTrans();
            Cashier.frmcashier = this;
            

        }
        void Slide(Button btn)
        {
            panelSlide.BackColor = Color.White;
            panelSlide.Height = btn.Height;
            panelSlide.Top = btn.Top;
        }
        #region buttons

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Slide(btnSearch);
            frmSearchProduct frm = new frmSearchProduct();
            frm.ShowDialog();
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            Slide(btnDiscount);
            if (dgvCart.CurrentRow != null)
            {

                frmDiscount frm = new frmDiscount(this);
                frm.SetInfo(dgvCart.CurrentRow.Cells[1].Value.ToString(), dgvCart.CurrentRow.Cells[8].Value.ToString());
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Select Order", "Select Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            Slide(btnPay);
            if (dgvCart.Rows.Count == 0)
            {
                MessageBox.Show("You dosnt have any order to Stettle payment", "No orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                frmStettlePayment frmStettle = new frmStettlePayment(this);
                frmStettle.SetInfo(lblMainTotal.Text, lblTranNo.Text);
                frmStettle.ShowDialog();
            }

        }

        private void btnCleanCart_Click(object sender, EventArgs e)
        {
            Slide(btnCleanCart);
            if(MessageBox.Show("Remove all Items from cart", "Confirm", MessageBoxButtons.YesNo)== DialogResult.Yes)
            {
                Trans.DeleteTran(lblTranNo.Text);
                NewTrans();
            }
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            Slide(btnSales);
            frmSales dailySales = new frmSales();
            dailySales.ShowDialog();
        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            Slide(btnPass);
            frmChangePass frmChangePass = new frmChangePass();
            frmChangePass.ShowDialog();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close the Application ?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        #endregion
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }



        public void LoadCart()
        {
            dgvCart.Rows.Clear();
            DataTable dt = Order.ShowCart();
            double total = 0;
            double discount = 0;
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                dgvCart.Rows.Add(i,
                    row["id"].ToString(),
                    row["pid"].ToString(),
                    row["barcode"].ToString(),
                    row["product"].ToString(),
                    row["price"].ToString(),
                    row["qty"].ToString(),
                    double.Parse(row["dis"].ToString()).ToString("#,##0.00"),
                    double.Parse(row["total"].ToString()).ToString("#,##0.00")
                    );
                discount += Convert.ToDouble(row["dis"]);
                total += Convert.ToDouble(row["total"]);
            }
            double tax = Order.CalcTax(total);
            double totalWithTax = tax + total;
            lblTotalSales.Text = total.ToString("#,##0.00");
            lblTotalDiscound.Text = discount.ToString("#,##0.00");
            lblTax.Text = tax.ToString("#,##0.00");
            lblTotal.Text = totalWithTax.ToString("#,##0.00");
            lblMainTotal.Text = totalWithTax.ToString("#,##0.00");
        }


        public void NewTrans()
        {
            dgvCart.Rows.Clear();
            lblTranNo.Text = Trans.GenTranNo();
            lblTotalSales.Text = "0.00";
            lblTotalDiscound.Text = "0.00";
            lblTax.Text = "0.00";
            lblTotal.Text = "0.00";
            lblMainTotal.Text = "0.00";
        }

        private void txtBarCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBarCode.Text))
            {
                string pid = Product.SearchByBarcode(txtBarCode.Text);
                if (pid != string.Empty)
                {
                    Order.NewOrder(pid, int.Parse(txtQty.Text));
                    txtBarCode.Clear();
                    txtBarCode.Focus();
                    LoadCart();
                }
            }
            return;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Log.Logout(this);
        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = dgvCart.Columns[e.ColumnIndex].Name;
            if (ColName == "Plus")
            {
                Order.AddOneqty(dgvCart[2, e.RowIndex].Value.ToString(), dgvCart[1, e.RowIndex].Value.ToString());
                LoadCart();
            }
            else if(ColName == "Minus")
            {
                Order.RemoveOneqty(dgvCart[2, e.RowIndex].Value.ToString(), dgvCart[1, e.RowIndex].Value.ToString());
                LoadCart();
            }
            else if(ColName == "Cancel")
            {
                Order.DeleteOrder(dgvCart[1, e.RowIndex].Value.ToString());
                LoadCart();
            }
        }
    }
}
