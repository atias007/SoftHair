using System;
using System.Windows.Forms;

namespace BizCareAdmin
{
    public partial class frmSelectReportcs : Form
    {
        public static int id = 0;

        public frmSelectReportcs()
        {
            InitializeComponent();
        }

        private void frmSelectReportcs_Load(object sender, EventArgs e)
        {
            var cmd = Common.DB.GetSqlStringCommand("SELECT id, CSTR(id) + \" - \" + report_group + \": \" + report_name  AS report FROM tblReports ORDER BY id");
            var ds = Common.DB.ExecuteDataSet(cmd);
            lstReports.DataSource = ds.Tables[0];
            lstReports.DisplayMember = "report";
            lstReports.ValueMember = "id";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (lstReports.SelectedIndex >= 0)
            {
                id = (int)lstReports.SelectedValue;
            }
            else id = 0;
        }

        private void lstReports_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstReports.SelectedIndex >= 0)
            {
                id = (int)lstReports.SelectedValue;
            }
            else id = 0;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void lstReports_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}