using System;
using System.Windows.Forms;
using store.BL;

namespace store.DAL.PL
{
    public partial class frmChangePass : Form
    {
        public frmChangePass()
        {
            InitializeComponent();
            txtChangePassUser.Text = UserInfo.UserName;
            txtCurrentPass.Focus();
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtNewPass.Text == txtReNewPass.Text)
                UserInfo.ChangeUserPassword(txtCurrentPass.Text, txtNewPass.Text);
            else MessageBox.Show("your passwords don’t match");
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
