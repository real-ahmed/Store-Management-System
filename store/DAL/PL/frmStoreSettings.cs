using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using store.BL;

namespace store.DAL.PL
{
    public partial class frmStoreSettings : Form
    {
        public frmStoreSettings()
        {
            InitializeComponent();
            GetStoreSettings();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            StoreInfo.SetStoreInfo(txtStoreName.Text, txtStoreAddress.Text, txtTax.Text);
        }

        private void GetStoreSettings()
        {
            txtStoreName.Text = StoreInfo.Name;
            txtStoreAddress.Text = StoreInfo.Address;
            txtTax.Text = (StoreInfo.Tax * 100).ToString();
        }

        private void txtTax_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataValidators.TakeOnlyInt(sender, e);
        }
    }
}
