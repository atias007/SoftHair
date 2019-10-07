using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClientManage.BL;
using ClientManage.Interfaces;

namespace ClientManage.Forms.OptionForms
{
    public partial class FormOptReports : BaseMdiOptionForm
    {
        private string _reportGroup;
        private ListViewItem lvItem;

        public FormOptReports()
        {
            InitializeComponent();
        }

        public override void LoadSettings()
        {
            lstGroup.Items.Clear();
            lstExistReports.Items.Clear();
            var table = ReportHelper.GetReportsGroup();
            _reportGroup = string.Empty;
            
            foreach (DataRow row in table.Rows)
            {
                lstGroup.Items.Add(Utils.GetDBValue<string>(row, "report_group"));
                _reportGroup += Utils.GetDBValue<string>(row, "report_group") + ",";
            }
            
            if (lstGroup.Items.Count > 0) lstGroup.Items[0].Selected = true;

            table = ReportHelper.GetAllReports();
            foreach (DataRow row in table.Rows)
            {
                lvItem = new ListViewItem(row["id"].ToString());
                lvItem.SubItems.Add(Utils.GetDBValue<string>(row, "report_group"));
                lvItem.SubItems.Add(Utils.GetDBValue<string>(row, "report_name"));
                lstExistReports.Items.Add(lvItem);
            }
            if (lstExistReports.Items.Count > 0) lstExistReports.Items[0].Selected = true;

            nudReportAdminTimeout.Value = LoadSettingValue<int>("REPORT_ADMIN_TIMEOUT");
        }

        public override void SaveSettings()
        {
            var groups = string.Empty;
            foreach (ListViewItem item in lstGroup.Items)
            {
                groups += item.Text + ",";
            }
            if (groups != _reportGroup)
            {
                ReportHelper.UpdateReportGroup(groups);
            }

            SaveSettingValue("REPORT_ADMIN_TIMEOUT", nudReportAdminTimeout.Value.ToString());
        }

        private void lstGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstGroup.SelectedIndices.Count > 0)
            {
                btnUpGroup.Enabled = lstGroup.SelectedIndices[0] > 0;
                btnDownGroup.Enabled = lstGroup.SelectedIndices[0] < lstGroup.Items.Count - 1;
            }
        }

        private void btnUpGroup_Click(object sender, EventArgs e)
        {
            lstGroup.SuspendLayout();
            if (lstGroup.SelectedIndices.Count > 0)
            {
                var selectedIndex = lstGroup.SelectedIndices[0];
                var temp = lstGroup.Items[selectedIndex];
                lstGroup.Items.RemoveAt(selectedIndex);
                lstGroup.Items.Insert(selectedIndex - 1, temp);
                lstGroup_SelectedIndexChanged(null, null);
            }
            lstGroup.Select();
            lstGroup.ResumeLayout(true);
        }

        private void btnDownGroup_Click(object sender, EventArgs e)
        {
            lstGroup.SuspendLayout();
            if (lstGroup.SelectedIndices.Count > 0)
            {
                var selectedIndex = lstGroup.SelectedIndices[0];
                var temp = lstGroup.Items[selectedIndex];
                lstGroup.Items.RemoveAt(selectedIndex);
                lstGroup.Items.Insert(selectedIndex + 1, temp);
                lstGroup_SelectedIndexChanged(null, null);
            }
            lstGroup.Select();
            lstGroup.ResumeLayout(true);
        }
    }
}