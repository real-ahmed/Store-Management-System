using System;
using System.Windows.Forms;
using store.BL;

namespace store
{
    public partial class frmSupplierModule : Form
    {
        frmSupplier supplier;
        public frmSupplierModule(frmSupplier supplier)
        {
            InitializeComponent();
            this.supplier = supplier;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are You sure You want to save this supplier ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Supplier.InsertSuplier(
                        txtSupplier.Text,
                        txtAddress.Text,
                        txtContactPerson.Text,
                        txtPhone.Text,
                        txtEmail.Text,
                        txtFax.Text);
                    MessageBox.Show("supplier has been saved");
                    supplier.LoadSupplier();
                    this.Dispose();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            if (MessageBox.Show("Are you sure you want to update this Supplier", "Update Supplier", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Supplier.UpdateSuplier(
                    lblId.Text,
                    txtSupplier.Text,
                    txtAddress.Text,
                    txtContactPerson.Text,
                    txtPhone.Text,
                    txtEmail.Text,
                    txtFax.Text);
                MessageBox.Show("Supplier has been updated");
                this.Dispose();
            }

        }
        public void OpenForUpdate(string Id, string Name, string Address, string ContactPerson, string Phone, string Email, string Fax)
        {
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            lblId.Visible = true;
            lblId.Text = Id;
            txtSupplier.Text = Name;
            txtAddress.Text = Address;
            txtContactPerson.Text = ContactPerson;
            txtPhone.Text = Phone;
            txtEmail.Text = Email;
            txtFax.Text = Fax;
        }
    }
}
