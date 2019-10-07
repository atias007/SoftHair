using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ClientManage.Interfaces;
using ClientManage.BL;
using ClientManage.Library;

namespace ClientManage.Forms.OptionForms
{
    public partial class FormOptWorkers : BaseMdiOptionForm
    {
        public event EventHandler ClientsDSChanged;

        public FormOptWorkers()
        {
            InitializeComponent();

            grdMagneticCards.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8);
            try
            {
                var files = Directory.GetFiles("Media", "*.wav");
                cmbWorkSound.Items.Add("ללא צליל");
                string file;
                for (var i = 0; i < files.Length; i++)
                {
                    file = files[i].Replace("Media\\", string.Empty);
                    file = file.Substring(0, file.Length - 4);
                    cmbWorkSound.Items.Add(file);
                }
            }
            catch { }
        }

        private DataSet _dsMagneticCards;
        public DataSet DSMagneticCards
        {
            get { return _dsMagneticCards; }
            set { _dsMagneticCards = value; }
        }


        public override void LoadSettings()
        {
            var bWorkEnterTime = Utils.GetIntArray(LoadSettingValue<string>("TRAFFIC_ENTER_TIME"));
            var bWorkLeaveTime = Utils.GetIntArray(LoadSettingValue<string>("TRAFFIC_LEAVE_TIME"));
            var wSound = LoadSettingValue<string>("TRAFFIC_SOUND_FILE");

            cmbWorkEnterHour.SelectedIndex = cmbWorkEnterHour.FindString(bWorkEnterTime[0].ToString("0#"));
            cmbWorkEnterMin.SelectedIndex = cmbWorkEnterMin.FindString(bWorkEnterTime[1].ToString("0#"));
            cmbWorkLeaveHour.SelectedIndex = cmbWorkLeaveHour.FindString(bWorkLeaveTime[0].ToString("0#"));
            cmbWorkLeaveMin.SelectedIndex = cmbWorkLeaveMin.FindString(bWorkLeaveTime[1].ToString("0#"));
            cmbWorkSound.SelectedIndex = cmbWorkSound.FindString(wSound.Substring(0, wSound.Length - 4));

            if (_dsMagneticCards == null) _dsMagneticCards = WorkersHelper.GetAllMagneticCards();
             grdMagneticCards.DataSource = _dsMagneticCards;
            grdMagneticCards.DataMember = "tblMagneticCards";
        }

        public override void SaveSettings()
        {
            SaveSettingValue("TRAFFIC_ENTER_TIME", Convert.ToInt32(cmbWorkEnterHour.Text).ToString() + "," + Convert.ToInt32(cmbWorkEnterMin.Text).ToString() + ",0");
            SaveSettingValue("TRAFFIC_LEAVE_TIME", Convert.ToInt32(cmbWorkLeaveHour.Text).ToString() + "," + Convert.ToInt32(cmbWorkLeaveMin.Text).ToString() + ",0");
            SaveSettingValue("TRAFFIC_SOUND_FILE", cmbWorkSound.Text + ".wav");

            if (_dsMagneticCards.HasChanges())
            {
                if (ClientsDSChanged != null) ClientsDSChanged(_dsMagneticCards, new EventArgs());
            }
        }

        public override void ResetForm()
        {
            _dsMagneticCards = null;
            base.ResetForm();
        }

        private void btnPlaySoundWork_Click(object sender, EventArgs e)
        {
            Utils.PlayWavFile(cmbWorkSound.Text + ".wav");
        }

        private void cmbWorkSound_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnPlaySoundWork.Enabled = cmbWorkSound.SelectedIndex > 0;
        }

        private void grdMagneticCards_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (IsGridContainsValue(grdMagneticCards, e.FormattedValue.ToString(), 1, e.RowIndex))
            {
                var msg1 = "מזהה כרטיס " + e.FormattedValue.ToString() + " כבר קיים";
                var msg2 = "כרטיסים מגנטיים...";
                if (e.FormattedValue.ToString().Length == 0) msg1 = "לא הוזן טיפול. אנא הזן שם טיפול או לחץ Esc לביטול";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
                e.Cancel = true;
            }
        }
    }
}