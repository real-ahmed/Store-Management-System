using System;
using System.Data;
using System.Windows.Forms;
using store.BL;

namespace store.DAL.PL
{
    public partial class frmStockIn : Form
    {
        public frmStockIn()
        {
            InitializeComponent();
            LoadSuplier();
            LoadStockIn();
            LoadStockInRecord();
            txtRefrenceNo.Text = StockIn.GenReferenceNo();
            txtStockBy.Text = UserInfo.UserName;
            metroTabControl1.SelectedIndex = 0;
        }

        private void linkGenerate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtRefrenceNo.Text = StockIn.GenReferenceNo();
        }

        private void linkProductBrowse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmProductStockin frm = new frmProductStockin(this);
            frm.SetData(txtRefrenceNo.Text, cmbSuplier.Text, dtpStockInDate.Value);
            frm.ShowDialog();
        }
        private void LoadSuplier()
        {
            cmbSuplier.Items.Clear();
            cmbSuplier.DataSource = StockIn.SelectSuplierForStock();
            cmbSuplier.DisplayMember = "supplier";
        }

        public void LoadStockIn()
        {
            dgvStockIn.Rows.Clear();
            DataTable dt = StockIn.SelectStockIn();

            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                dgvStockIn.Rows.Add(i,
                    row["id"].ToString(),
                    row["refno"].ToString(),
                    row["pid"].ToString(),
                    row["product"].ToString(),
                    row["qty"].ToString(),
                    row["sdate"].ToString(),
                    row["username"].ToString(),
                    row["supplier"].ToString(),
                    row["status"].ToString()
                    );
            }
        }

        public void LoadStockInRecord()
        {
            dgvStockInRecord.Rows.Clear();
            DataTable dt = StockIn.SelectStockInRecord();

            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                dgvStockInRecord.Rows.Add(i,
                    row["id"].ToString(),
                    row["refno"].ToString(),
                    row["pid"].ToString(),
                    row["product"].ToString(),
                    row["qty"].ToString(),
                    row["sdate"].ToString(),
                    row["username"].ToString(),
                    row["supplier"].ToString(),
                    row["status"].ToString()
                    );
            }
        }

        private void cmbSuplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSupplierInfo();
        }
        private void SetSupplierInfo()
        {
            string[] info = StockIn.SelectSupplierInfo(cmbSuplier.Text.ToString());
            txtAddress.Text = info[0];
            txtContactPerson.Text = info[1];


        }

        private void btnEntry_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to confirm this stockin", "confirm stockin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int DataRow = 0; DataRow < dgvStockIn.Rows.Count; DataRow++)
                {
                    StockIn.ConfirmStockIn(
                        dgvStockIn[1, DataRow].Value.ToString(),
                         dgvStockIn[5, DataRow].Value.ToString()
                        );
                }
                txtRefrenceNo.Text = StockIn.GenReferenceNo();

                LoadStockIn();
            }
        }

        private void metroTabControl1_Selected(object sender, TabControlEventArgs e)
        {
            LoadStockInRecord();
        }
    }
}
