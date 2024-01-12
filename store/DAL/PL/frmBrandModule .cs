using System;
using System.Windows.Forms;
using store.BL;

namespace store
{
    public partial class BrandModule : Form
    {
        frmBrand brand;
        public BrandModule(frmBrand brand)
        {
            InitializeComponent();
            this.brand = brand;

        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are You sure You want to save this brand ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Brand.InsertBrand(txtBrand.Text);
                    MessageBox.Show("brand has been saved");
                    brand.LoadBrand();
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to update this brand", "Update Brand", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Brand.UpdateBrand(lblId.Text, txtBrand.Text);
                MessageBox.Show("Brand has been updated");
                this.Dispose();
            }
        }
        public void OpenForUpdate(string Id, string Name)
        {
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            txtBrand.Text = Name;
            lblId.Visible = true;
            lblId.Text = Id;
        }
    }
}
