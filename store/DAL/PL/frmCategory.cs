using System;
using System.Data;
using System.Windows.Forms;
using store.BL;

namespace store
{
    public partial class frmCategory : Form
    {
        public frmCategory()
        {
            InitializeComponent();
            LoadCategory();
        }

        public void LoadCategory()
        {
            dgvCategory.Rows.Clear();
            DataTable dt = Category.SelectCategory();
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                dgvCategory.Rows.Add(i, row["id"].ToString(), row["category"].ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCategoryModule categoryModule = new frmCategoryModule(this);
            categoryModule.ShowDialog();
        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = dgvCategory.Columns[e.ColumnIndex].Name;

            if (ColName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this Category ?", "Delete Category", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Category.DeleteCategory(dgvCategory[1, e.RowIndex].Value.ToString());
                    MessageBox.Show("Category has been deleted");
                }
            }
            else if (ColName == "Edit")
            {
                frmCategoryModule ModuleForm = new frmCategoryModule(this);
                ModuleForm.OpenForUpdate(dgvCategory[1, e.RowIndex].Value.ToString(), dgvCategory[2, e.RowIndex].Value.ToString());
                ModuleForm.ShowDialog();
            }
            LoadCategory();
        }
    }
}
