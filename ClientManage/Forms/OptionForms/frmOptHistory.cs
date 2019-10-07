using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClientManage.Forms.OptionForms
{
    public partial class FormOptHistory : BaseMdiOptionForm
    {
        private readonly string _lastCleanFormat = string.Empty;

        public FormOptHistory()
        {
            InitializeComponent();

            _lastCleanFormat = lblLastClean.Text;
        }

        public override void LoadSettings()
        {
            cmbCleanCal.SelectedIndex = cmbCleanCal.FindString(LoadSettingValue<string>("HISTORY_CLEAR_CALENDAR"));
            cmbCleanCallLog.SelectedIndex = cmbCleanCallLog.FindString(LoadSettingValue<string>("HISTORY_CLEAR_CALLLOG"));
            cmbCleanTraffic.SelectedIndex = cmbCleanTraffic.FindString(LoadSettingValue<string>("HISTORY_CLEAR_TRAFFIC"));
            cmbClearSMS.SelectedIndex = cmbClearSMS.FindString(LoadSettingValue<string>("HISTORY_CLEAR_SMS"));
            var date = LoadSettingValue<string>("HISTORY_LAST_CLEAR");
            if(string.IsNullOrEmpty(date)) date = "< לא בוצע מעולם >";
            lblLastClean.Text = string.Format(_lastCleanFormat, date);
        }

        public override void SaveSettings()
        {
            SaveSettingValue("HISTORY_CLEAR_CALENDAR", cmbCleanCal.Text);
            SaveSettingValue("HISTORY_CLEAR_CALLLOG", cmbCleanCallLog.Text);
            SaveSettingValue("HISTORY_CLEAR_TRAFFIC", cmbCleanTraffic.Text);
            SaveSettingValue("HISTORY_CLEAR_SMS", cmbClearSMS.Text);
        }
    }
}