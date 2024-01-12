using System;
using System.Windows.Forms;
using store.BL;

namespace store
{
    public partial class frmCategoryModule : Form
    {
        frmCategory category;
        public frmCategoryModule(frmCategory category)
        {
            InitializeComponent();
            this.category = category;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are You sure You want to save this Category ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    Category.InsertCaregory(txtCategory.Text);
                    MessageBox.Show("Category has been saved");
                    category.LoadCategory();
                    this.Dispose();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to update this Category", "Update Category", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Category.UpdateCaregory(lblId.Text, txtCategory.Text);
                MessageBox.Show("Category has been updated");
                this.Dispose();
            }
        }
        public void OpenForUpdate(string Id, string Name)
        {
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            txtCategory.Text = Name;
            lblId.Visible = true;
            lblId.Text = Id;
        }
        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
