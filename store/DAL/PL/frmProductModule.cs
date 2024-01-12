using System;
using System.Windows.Forms;
using store.BL;

namespace store
{
    public partial class frmProductModule : Form
    {


        frmProductList productList;
        public frmProductModule(frmProductList productList)
        {
            InitializeComponent();
            LoadCategory();
            LoadBrand();
            this.productList = productList;
        }

        private void LoadCategory()
        {
            cmbCategory.Items.Clear();
            cmbCategory.DataSource = Category.SelectCategory();
            cmbCategory.DisplayMember = "category";
            cmbCategory.ValueMember = "id";
        }
        private void LoadBrand()
        {
            cmbBrand.Items.Clear();
            cmbBrand.DataSource = Brand.SelectBrands();
            cmbBrand.DisplayMember = "brand";
            cmbBrand.ValueMember = "id";
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure You want to save this Product ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                Product.InsertProduct(txtBarcode.Text,
                    txtProductName.Text,
                    cmbBrand.SelectedValue.ToString(),
                    cmbCategory.SelectedValue.ToString(),
                    double.Parse(txtPeice.Text));

                MessageBox.Show("Product has been saved");
                productList.LoadProduct();
                this.Dispose();

            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("Are you sure you want to update this Product", "Update Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Product.UpdateProduct(lblId.Text,
                        txtBarcode.Text,
                        txtProductName.Text,
                        cmbBrand.SelectedValue.ToString(),
                        cmbCategory.SelectedValue.ToString(),
                        double.Parse(txtPeice.Text));
                    MessageBox.Show("Product has been updated");
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void OpenForUpdate(string Id, string Barcode, string ProductName, string Brand, string Category, string Price)
        {
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            lblId.Visible = true;
            lblId.Text = Id;
            txtBarcode.Text = Barcode;
            txtProductName.Text = ProductName;
            cmbBrand.Text = Brand;
            cmbCategory.Text = Category;
            txtPeice.Text = Price;
        }

        private void txtPeice_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataValidators.TakeOnlyNubers(sender,e);
        }
    }
}
