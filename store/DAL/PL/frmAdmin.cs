using System;
using System.Windows.Forms;
using store.BL;
using store.DAL;
using store.DAL.PL;

namespace store
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
            CustomizeDesing();
            OpenChildForm(new frmDashboard());
            lblUserName.Text = UserInfo.UserName;
        }

        private Form ActiveForm = null;
        private void OpenChildForm(Form ChildForm)
        {
            if (ActiveForm != null)
                ActiveForm.Close();
            ActiveForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            lblTitle.Text = ChildForm.Text.ToString().ToUpper();
            panelMain.Controls.Add(ChildForm);
            panelMain.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }


        private void CustomizeDesing()
        {
            panelSubProduct.Visible = false;
            panelSubRecord.Visible = false;
            panelSubSetting.Visible = false;
        }

        private void HideSubMenu()
        {
            if (panelSubProduct.Visible)
                panelSubProduct.Visible = false;
            if (panelSubRecord.Visible)
                panelSubRecord.Visible = false;
            if (panelSubSetting.Visible)
                panelSubSetting.Visible = false;
        }

        private void ShowSubMenu(Panel SubMenu)
        {
            HideSubMenu();
            if (!SubMenu.Visible)
            {
                SubMenu.Visible = true;
            }
            else
            {
                SubMenu.Visible = false;
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            HideSubMenu();
            OpenChildForm(new frmDashboard());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelSubProduct);
        }



        private void btnSetting_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelSubSetting);
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelSubRecord);
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            HideSubMenu();
            OpenChildForm(new frmSupplier());
        }

        private void btnBrand_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmBrand());
            HideSubMenu();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmCategory());
            HideSubMenu();
        }

        private void ProductList_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmProductList());
            HideSubMenu();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmUserAccount());
            HideSubMenu();
        }

        private void btnStackEntry_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmStockIn());
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Log.Logout(this);
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmSales());
        }

        private void btnCanceled_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmCanceled());
        }

        private void btnStoreSettings_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmStoreSettings());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
