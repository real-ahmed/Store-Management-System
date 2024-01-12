using System;
using System.Data;
using System.Windows.Forms;
using store.BL;

namespace store
{
    public partial class frmSupplier : Form
    {
        public frmSupplier()
        {
            InitializeComponent();
            LoadSupplier();
        }


        public void LoadSupplier()
        {
            dgvSupplier.Rows.Clear();
            DataTable dt = Supplier.SelectSupplier();
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                dgvSupplier.Rows.Add(i, row["id"].ToString(), row["Supplier"].ToString(), row["address"].ToString(), row["contactperson"].ToString(), row["phone"].ToString(), row["email"].ToString(), row["fax"].ToString());
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSupplierModule module = new frmSupplierModule(this);
            module.ShowDialog();
        }
        private void dgvSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = dgvSupplier.Columns[e.ColumnIndex].Name;

            if (ColName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this supplier ?", "Delete Supplier", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Supplier.DeleteSupplier(dgvSupplier[1, e.RowIndex].Value.ToString());
                    MessageBox.Show("supplier has been deleted");
                }
            }
            else if (ColName == "Edit")
            {
                frmSupplierModule ModuleForm = new frmSupplierModule(this);
                ModuleForm.OpenForUpdate(dgvSupplier[1, e.RowIndex].Value.ToString(), dgvSupplier[2, e.RowIndex].Value.ToString(), dgvSupplier[3, e.RowIndex].Value.ToString(), dgvSupplier[4, e.RowIndex].Value.ToString(), dgvSupplier[5, e.RowIndex].Value.ToString(), dgvSupplier[6, e.RowIndex].Value.ToString(), dgvSupplier[7, e.RowIndex].Value.ToString());
                ModuleForm.ShowDialog();
            }
            LoadSupplier();
        }
    }
}
