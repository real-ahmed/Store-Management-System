using System;
using System.Windows.Forms;
using store.BL;

namespace store.DAL.PL
{

    public partial class frmLogin : Form
    {
        public static Form instance;
        public frmLogin()
        {
            InitializeComponent();
            instance = this;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Log.Login(txtUser.Text, txtPass.Text);
            Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void picClose_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Clear()
        {
            txtUser.Clear();
            txtPass.Clear();
        }
    }
}
