using System;
using System.Data;
using System.Windows.Forms;
using store.BL;

namespace store
{
    public partial class frmProductList : Form
    {
        public frmProductList()
        {
            InitializeComponent();
            LoadProduct();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductModule module = new frmProductModule(this);
            module.ShowDialog();
        }



        public void LoadProduct()
        {
            dgvProduct.Rows.Clear();
            DataTable dt = Product.SelectProduct(txtSearch.Text);

            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                dgvProduct.Rows.Add(i, row["id"].ToString(), row["barcode"].ToString(), row["product"].ToString(), row["brand"].ToString(), row["category"].ToString(), row["price"].ToString());
            }

        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = dgvProduct.Columns[e.ColumnIndex].Name;

            if (ColName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this Product ?", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Product.DeleteProduct(dgvProduct[1, e.RowIndex].Value.ToString());
                    MessageBox.Show("Product has been deleted");
                }
            }
            else if (ColName == "Edit")
            {
                frmProductModule ModuleForm = new frmProductModule(this);
                ModuleForm.OpenForUpdate(dgvProduct[1, e.RowIndex].Value.ToString(), dgvProduct[2, e.RowIndex].Value.ToString(), dgvProduct[3, e.RowIndex].Value.ToString(), dgvProduct[4, e.RowIndex].Value.ToString(), dgvProduct[5, e.RowIndex].Value.ToString(), dgvProduct[6, e.RowIndex].Value.ToString());
                ModuleForm.ShowDialog();
            }
            LoadProduct();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }
    }

}
