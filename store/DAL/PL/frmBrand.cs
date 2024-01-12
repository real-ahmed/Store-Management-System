using System;
using System.Data;
using System.Windows.Forms;
using store.BL;

namespace store
{

    public partial class frmBrand : Form
    {

        public frmBrand()
        {
            InitializeComponent();
            LoadBrand();
        }

        public void LoadBrand()
        {
            dgvBrand.Rows.Clear();
            DataTable dt = Brand.SelectBrands();
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                dgvBrand.Rows.Add(i, row["id"].ToString(), row["brand"].ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BrandModule ModuleForm = new BrandModule(this);
            ModuleForm.ShowDialog();

        }

        private void dgvBrand_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = dgvBrand.Columns[e.ColumnIndex].Name;

            if (ColName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this brand ?", "Delete Brand", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Brand.DeleteBrand(dgvBrand[1, e.RowIndex].Value.ToString());
                }
            }
            else if (ColName == "Edit")
            {
                BrandModule ModuleForm = new BrandModule(this);
                ModuleForm.OpenForUpdate(dgvBrand[1, e.RowIndex].Value.ToString(), dgvBrand[2, e.RowIndex].Value.ToString());
                ModuleForm.ShowDialog();
            }
            LoadBrand();
        }
    }
}
