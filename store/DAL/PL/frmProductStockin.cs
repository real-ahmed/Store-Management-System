using System;
using System.Data;
using System.Windows.Forms;
using store.BL;


namespace store.DAL.PL
{
    public partial class frmProductStockin : Form
    {
        private string ReferenceNo;
        private string Supllier;
        DateTime date;
        frmStockIn frmstockin;
        public frmProductStockin(frmStockIn frmstockin)
        {
            InitializeComponent();
            LoadProduct();
            this.frmstockin = frmstockin;
        }
        public void SetData(string ReferenceNo, string Supllier, DateTime date)
        {
            this.ReferenceNo = ReferenceNo;
            this.Supllier = Supllier;
            this.date = date;
        }
        public void LoadProduct()
        {
            dgvProduct.Rows.Clear();
            DataTable dt = Product.SelectProductForStockIn(txtSearch.Text);

            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                dgvProduct.Rows.Add(i,
                    row["id"].ToString(),
                    row["barcode"].ToString(),
                    row["product"].ToString(),
                    row["p_qty"].ToString()
                    );
            }

        }
        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = dgvProduct.Columns[e.ColumnIndex].Name;

            if (ColName == "Select")
            {
                if (MessageBox.Show("Are you sure you want to select this Product ?", "Select product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    StockIn.InsertStockin(
                        ReferenceNo,
                        Supllier,
                        dgvProduct[1, e.RowIndex].Value.ToString(),
                        date);
                    frmstockin.LoadStockIn();
                }
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
    }
}
