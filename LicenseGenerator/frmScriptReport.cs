using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BizCareAdmin
{
    public partial class FrmScriptReport : Form
    {
        public FrmScriptReport()
        {
            InitializeComponent();
        }

        private void FrmScriptReport_Load(object sender, EventArgs e)
        {
            var cmd = Common.DB.GetSqlStringCommand("SELECT id, CSTR(id) + \" - \" + report_group + \": \" + report_name  AS report FROM tblReports ORDER BY id");
            var ds = Common.DB.ExecuteDataSet(cmd);
            lstReports.DataSource = ds.Tables[0];
            lstReports.DisplayMember = "report";
            lstReports.ValueMember = "id";
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            var ids = string.Empty;

            foreach (var item in lstReports.CheckedItems)
            {
                ids += ((DataRowView)item)["id"] + ",";
            }

            if (ids.Length > 0)
            {
                ids = ids.Substring(0, ids.Length - 1);
                var sql = "SELECT * FROM tblReports WHERE id IN(" + ids + ")";
                var cmd = Common.DB.GetSqlStringCommand(sql);
                var ds = Common.DB.ExecuteDataSet(cmd);

                var script = string.Empty;
                if (rbUpdate.Checked)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        script += "UPDATE tblReports SET" +
                            " report_name = '" + row["report_name"] + "'" +
                            ",report_group = '" + row["report_group"] + "'" +
                            ",report_xml = '" + row["report_xml"] + "'" +
                            "WHERE id = " + row["id"] +
                            ";\r\n\r\n";
                    }
                }
                else
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        script += "INSERT INTO tblReports (id,report_name,report_group,report_xml) VALUES (" +
                            " '" + row["id"] + "'" +
                            ",'" + row["report_name"] + "'" +
                            ",'" + row["report_group"] + "'" +
                            ",'" + row["report_xml"] + "')" +
                            ";\r\n\r\n";
                    }
                }

                var writer = new StreamWriter("script.txt", false, Encoding.Default);
                writer.Write(script);
                writer.Close();
                System.Diagnostics.Process.Start("script.txt");
            }
        }
    }
}
