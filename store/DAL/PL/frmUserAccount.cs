using System;
using System.Windows.Forms;
using store.BL;

namespace store
{
    public partial class frmUserAccount : Form
    {

        public frmUserAccount()
        {
            InitializeComponent();
            txtChangePassUser.Text = UserInfo.UserName;
        }

        private void btnAccSave_Click(object sender, EventArgs e)
        {
            if (txtPass.Text != txtRePass.Text) { MessageBox.Show("passwords not mached"); return; }
            try
            {
                UsersSettings.InsertUser(txtUserName.Text, txtPass.Text, cmbRole.Text, txtFullName.Text);
                MessageBox.Show("User has been saved");
                Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAccCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void Clear()
        {
            txtFullName.Clear();
            txtPass.Clear();
            txtRePass.Clear();
            txtUserName.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtNewPass.Text == txtReNewPass.Text)
                UserInfo.ChangeUserPassword(txtCurrentPass.Text, txtNewPass.Text);
            else MessageBox.Show("your passwords don’t match");
        }
    }
}
