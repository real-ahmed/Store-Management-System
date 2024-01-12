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
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
            CenterThePanel();
            SetDashboardInfo();

        }

        private void CenterThePanel()
        {
            CenterPanel.Location = new Point(
            this.ClientSize.Width / 2 - CenterPanel.Size.Width / 2);
            CenterPanel.Anchor = AnchorStyles.None;
        }

        public void SetDashboardInfo()
        {
            lblTotalDailySeles.Text = Dashboard.TotalDailySales().ToString("#,##0.00");
            lblTotalDailyOrders.Text = Dashboard.TotalDailyOrders().ToString();
            lblTotalDailyCancel.Text = Dashboard.TotalDailyCancel().ToString();
        }
    }
}
