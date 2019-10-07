using ClientManage.BL;
using ClientManage.Interfaces;
using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace ClientManage.Forms.OptionForms
{
    public partial class FormOptCalendar1 : BaseMdiOptionForm
    {
        public FormOptCalendar1()
        {
            InitializeComponent();
            LoadCombosAndGrids();
        }

        public override void LoadSettings()
        {
            var bCalStartSpan = LoadSettingValue<string>("CALENDAR_START_TIME").Split(':');
            var bCalEndSpan = LoadSettingValue<string>("CALENDAR_END_TIME").Split(':');
            txtCalId.Text = LoadSettingValue<string>("CALENDAR_SOUND_FILE");

            cmbCalStartHour.SelectedIndex = cmbCalStartHour.FindString(bCalStartSpan[0]);
            cmbCalStartMin.SelectedIndex = cmbCalStartMin.FindString(bCalStartSpan[1]);
            cmbCalEndHour.SelectedIndex = cmbCalEndHour.FindString(bCalEndSpan[0]);
            cmbCalEndMin.SelectedIndex = cmbCalEndMin.FindString(bCalEndSpan[1]);
            nudCalAttachTimeout.Value = LoadSettingValue<int>("CALENDAR_ATTACH_MSG_TIME");
            chkShowRemHistory.Checked = LoadSettingValue<bool>("CALENDAR_AGREGATE_REMARK");
            //chkSyncEvents.Checked = LoadSettingValue<bool>("CAL_SYNC_EVENTS");

            cmbCalRemainder.SelectedValue = LoadSettingValue<int>("CALENDAR_REMAINDER_MIN");
            //cmbCalSound.SelectedIndex = cmbCalSound.FindString(cSound.Substring(0, cSound.Length - 4));
        }

        public override void SaveSettings()
        {
            SaveSettingValue("CALENDAR_START_TIME", cmbCalStartHour.Text + ":" + cmbCalStartMin.Text);
            SaveSettingValue("CALENDAR_END_TIME", cmbCalEndHour.Text + ":" + cmbCalEndMin.Text);
            SaveSettingValue("CALENDAR_SOUND_FILE", txtCalId.Text);
            SaveSettingValue("CALENDAR_ATTACH_MSG_TIME", nudCalAttachTimeout.Value.ToString(CultureInfo.InvariantCulture));
            SaveSettingValue("CALENDAR_AGREGATE_REMARK", chkShowRemHistory.Checked);
            SaveSettingValue("CALENDAR_REMAINDER_MIN", cmbCalRemainder.SelectedValue.ToString());
            //SaveSettingValue("CAL_SYNC_EVENTS", chkSyncEvents.Checked);
        }

        private void LoadCombosAndGrids()
        {
            var table = CalendarHelper.GetRemainderValues().Tables[0];
            cmbCalRemainder.DataSource = table;
            cmbCalRemainder.DisplayMember = "description";
            cmbCalRemainder.ValueMember = "min_value";

            try
            {
                var files = Directory.GetFiles("Media", "*.wav");
                cmbCalSound.Items.Add("ללא צליל");
                foreach (var t in files)
                {
                    var file = t.Replace("Media\\", string.Empty);
                    file = file.Substring(0, file.Length - 4);
                    cmbCalSound.Items.Add(file);
                }
            }
            catch (Exception ex)
            {
                Utils.CatchException(ex);
            }
        }

        private void btnPlaySoundCal_Click(object sender, EventArgs e)
        {
            Utils.PlayWavFile(cmbCalSound.Text + ".wav");
        }

        private void cmbCalSound_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnPlaySoundCal.Enabled = cmbCalSound.SelectedIndex > 0;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            lblStatus.Text = string.Empty;
            int days = 0;
            int.TryParse(txtDays.Text, out days);
            if (days <= 0) return;

            var start = DateTime.Now.AddDays(-days);
            for (int i = 0; i <= days + 365; i++)
            {
                var cur = start.AddDays(i);
                lblStatus.Text = cur.ToShortDateString();
                Application.DoEvents();
                CalendarHelper.ImportEvents(cur);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var start = DateTime.Now.AddDays(2);
            for (int i = 0; i <= 6; i++)
            {
                var cur = start.AddDays(i);
                lblStatus.Text = cur.ToShortDateString();
                Application.DoEvents();
                CalendarHelper.ClearTimeZone(cur);
            }
        }
    }
}