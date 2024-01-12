using System;
using System.Data;
using System.Windows.Forms;
using store.BL;

namespace store.DAL.PL
{
    public partial class frmSearchProduct : Form
    {
        public frmSearchProduct()
        {
            InitializeComponent();
            LoadProduct();
        }

        public void LoadProduct()
        {
            dgvProduct.Rows.Clear();
            DataTable dt = Product.SelectProductForCasher(txtSearch.Text);

            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                dgvProduct.Rows.Add(i,
                    row["id"].ToString(),
                    row["barcode"].ToString(),
                    row["product"].ToString(),
                    row["brand"].ToString(),
                    row["category"].ToString(),
                    row["price"].ToString(),
                    row["qty"].ToString()
                    );
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = dgvProduct.Columns[e.ColumnIndex].Name;

            if (ColName == "Select")
            {
                frmQty qty = new frmQty(dgvProduct[1, e.RowIndex].Value.ToString());
                qty.ShowDialog();
            }
        }
    }
}
