using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using store.BL;

namespace store.DAL
{
    public partial class frmSales : Form
    {
        List<object> Casheirs;
        public frmSales()
        {
            InitializeComponent();
            LoadCashiers();
            if (UserInfo.Role != "Cashier") picClose.Visible = false;
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadSales();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            LoadSales();
        }



        public void LoadSales()
        {
            dgvSales.Rows.Clear();
            DataTable dt;
            if (UserInfo.Role == "Cashier")
            {
                 dt = Trans.SelectTrans(UserInfo.Id, dtpFrom.Value, dtpTo.Value);
            }
            else
            {
                 dt = Trans.SelectTrans(cmbCashier.SelectedValue, dtpFrom.Value, dtpTo.Value);

            }
            double total = 0;
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                dgvSales.Rows.Add(i,
                    row["id"].ToString(),
                    row["pid"].ToString(),
                    row["barcode"].ToString(),
                    row["product"].ToString(),
                    row["price"].ToString(),
                    row["qty"].ToString(),
                    double.Parse(row["dis"].ToString()).ToString("#,##0.00"),
                    double.Parse(row["total"].ToString()).ToString("#,##0.00")
                    );
                total += Convert.ToDouble(row["total"]);
            }
            double tax = Order.CalcTax(total);
            double totalWithTax = tax + total;
            lblTotal.Text = totalWithTax.ToString();
        }
        private void LoadCashiers()
        {
            Casheirs = new List<object>();
            if (UserInfo.Role == "Cashier")
            {
                Casheirs.Add(new { Value = UserInfo.Id, Display = UserInfo.UserName });
            }
            else
            {
                DataTable dt = Sales.SelectCashiers();
                Casheirs.Add(new { Value = "%", Display = "all cashiers" });

                foreach (DataRow row in dt.Rows)
                {
                    Casheirs.Add(new { Value = row["id"].ToString(), Display = row["username"].ToString() });
                }
            }
            cmbCashier.Items.Clear();
            cmbCashier.DataSource = Casheirs;
            cmbCashier.ValueMember = "Value";
            cmbCashier.DisplayMember = "Display";

        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmbCashier_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadSales();
        }

        private void dgvSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = dgvSales.Columns[e.ColumnIndex].Name;
            if (ColName == "Cancel")
            {
                if (MessageBox.Show("Are You Sure Cancel This Order","Cancel Order",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Order.CancelOrder(dgvSales[1, e.RowIndex].Value.ToString());
                    LoadSales();
                }
            }
        }
    }
}
