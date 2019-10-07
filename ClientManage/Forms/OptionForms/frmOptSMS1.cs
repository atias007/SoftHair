using ClientManage.BL;
using ClientManage.Interfaces;
using ClientManage.Library;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ClientManage.Forms.OptionForms
{
    public partial class FormOptSms1 : BaseMdiOptionForm
    {
        private readonly string _lastSmsSend = string.Empty;
        private readonly string _checkStatus;

        public FormOptSms1()
        {
            InitializeComponent();

            _lastSmsSend = lblBdayLast.Text;
            var msgTable = SmsHelper.GetSmsMessages();
            if (msgTable.Rows.Count > 0) msgTable.Rows[0]["msg_title"] = "בחר הודעה...";

            cmbBdaySMSMsg.DataSource = msgTable;
            cmbBdaySMSMsg.DisplayMember = "msg_title";
            cmbBdaySMSMsg.ValueMember = "id";

            cmbMarrSMSMsg.DataSource = msgTable.Copy();
            cmbMarrSMSMsg.DisplayMember = "msg_title";
            cmbMarrSMSMsg.ValueMember = "id";

            cmbSmsTo.DataSource = SmsHelper.GetCalSmsTime();
            cmbSmsTo.DisplayMember = "title";
            cmbSmsTo.ValueMember = "value";

            _checkStatus = lblCheckStatus.Text;
            lblCheckStatus.Text = string.Empty;
        }

        public override void LoadSettings()
        {
            txtSmsFrom.Text = LoadSettingValue<string>("SMS_FROM");
            txtSmsMaxChars.Text = LoadSettingValue<string>("SMS_MAX_CHARS");
            txtSmsPassword.Text = LoadSettingValue<string>("SMS_PASSWORD");
            txtSmsUserName.Text = LoadSettingValue<string>("SMS_USERNAME");
            txtSmsWS2.Text = LoadSettingValue<string>("SMS_WS_SEND_URL");
            txtUniqueId.Text = LoadSettingValue<string>("SMS_UNIQUEID");
            txtCalRemindMessage.Text = LoadSettingValue<string>("SMS_MANUALMESSAGE");

            var smsParams = new AutoSmsParameters(LoadSettingValue<string>("SMS_BIRTHDAY_PARAMS"));
            cmbBdaySMSMsg.SelectedValue = smsParams.MessageId;
            if (cmbMarrSMSMsg.SelectedIndex < 0) cmbMarrSMSMsg.SelectedIndex = 0;
            chkAutoBdaySMS.Checked = smsParams.Enable;
            lblBdayLast.Text = string.Format(_lastSmsSend, smsParams.GetLastSubmitCaption());

            smsParams = new AutoSmsParameters(LoadSettingValue<string>("SMS_MARRIED_PARAMS"));
            cmbMarrSMSMsg.SelectedValue = smsParams.MessageId;
            if (cmbMarrSMSMsg.SelectedIndex < 0) cmbMarrSMSMsg.SelectedIndex = 0;
            chkAutoMarrSMS.Checked = smsParams.Enable;
            lblLastMer.Text = string.Format(_lastSmsSend, smsParams.GetLastSubmitCaption());

            var smsCalParams = new AutoCalSmsParams(
                LoadSettingValue<string>("SMS_CALENDAR_PARAMS"),
                LoadSettingValue<string>("SMS_CALENDAR_MESSAGE"));

            txtCalMessage.Text = smsCalParams.Message;
            chkAutoCalSms.Checked = smsCalParams.Enable;
            cmbSmsFrom.SelectedIndex = cmbSmsFrom.FindString(smsCalParams.DaysBefore.ToString(CultureInfo.InvariantCulture));
            cmbSmsTo.SelectedValue = smsCalParams.UpMin;
            lblCalLastSend.Text = string.Format(_lastSmsSend, smsCalParams.GetLastSubmitCaption());
        }

        public override void SaveSettings()
        {
            SaveSettingValue("SMS_FROM", txtSmsFrom.Text);
            SaveSettingValue("SMS_MAX_CHARS", txtSmsMaxChars.Text);
            SaveSettingValue("SMS_PASSWORD", txtSmsPassword.Text);
            SaveSettingValue("SMS_USERNAME", txtSmsUserName.Text);
            SaveSettingValue("SMS_WS_SEND_URL", txtSmsWS2.Text);
            SaveSettingValue("SMS_CALENDAR_MESSAGE", txtCalMessage.Text);
            SaveSettingValue("SMS_MANUALMESSAGE", txtCalRemindMessage.Text);
            SaveSettingValue("SMS_UNIQUEID", txtUniqueId.Text);

            var smsParams = new AutoSmsParameters(LoadSettingValue<string>("SMS_BIRTHDAY_PARAMS"));
            if (cmbBdaySMSMsg.SelectedIndex <= 0) chkAutoBdaySMS.Checked = false;
            smsParams.Enable = chkAutoBdaySMS.Checked;
            smsParams.MessageId = cmbBdaySMSMsg.SelectedValue == null ? 0 : Convert.ToInt32(cmbBdaySMSMsg.SelectedValue);
            SaveSettingValue("SMS_BIRTHDAY_PARAMS", smsParams.ToString());

            smsParams = new AutoSmsParameters(LoadSettingValue<string>("SMS_MARRIED_PARAMS"));
            if (cmbMarrSMSMsg.SelectedIndex <= 0) chkAutoMarrSMS.Checked = false;
            smsParams.Enable = chkAutoMarrSMS.Checked;
            smsParams.MessageId = cmbMarrSMSMsg.SelectedValue == null ? 0 : Convert.ToInt32(cmbMarrSMSMsg.SelectedValue);
            SaveSettingValue("SMS_MARRIED_PARAMS", smsParams.ToString());

            var smsCalParams = new AutoCalSmsParams(
                LoadSettingValue<string>("SMS_CALENDAR_PARAMS"),
                LoadSettingValue<string>("SMS_CALENDAR_MESSAGE"))
                                   {
                                       Message = txtCalMessage.Text,
                                       Enable = chkAutoCalSms.Checked,
                                       DaysBefore = int.Parse(cmbSmsFrom.Text),
                                       UpMin = (int)cmbSmsTo.SelectedValue
                                   };
            SaveSettingValue("SMS_CALENDAR_PARAMS", smsCalParams.ToString());
            SaveSettingValue("SMS_CALENDAR_MESSAGE", smsCalParams.Message);

            SaveXmlSupportFile();
        }

        private void Button7Click(object sender, EventArgs e)
        {
            OpenUrl(txtSmsWS2.Text);
        }

        private void ChkAutoBdaySmsCheckedChanged(object sender, EventArgs e)
        {
            //if (chkAutoBdaySMS.Checked) cmbBdaySMSMsg.Enabled = true;
            //else
            //{
            //    cmbBdaySMSMsg.SelectedIndex = 0;
            //    cmbBdaySMSMsg.Enabled = false;
            //}
        }

        private void ChkAutoMarrSmsCheckedChanged(object sender, EventArgs e)
        {
            //if (chkAutoMarrSMS.Checked) cmbMarrSMSMsg.Enabled = true;
            //else
            //{
            //    cmbMarrSMSMsg.SelectedIndex = 0;
            //    cmbMarrSMSMsg.Enabled = false;
            //}
        }

        private void BtnResetMarriedClick(object sender, EventArgs e)
        {
            var smsParams = new AutoSmsParameters(LoadSettingValue<string>("SMS_MARRIED_PARAMS")) { LastSubmit = DateTime.Now.Date.AddDays(-1) };
            SaveSettingValue("SMS_MARRIED_PARAMS", smsParams.ToString());
            lblLastMer.Text = string.Format(_lastSmsSend, smsParams.GetLastSubmitCaption());
        }

        private void BtnResetBdayClick(object sender, EventArgs e)
        {
            var smsParams = new AutoSmsParameters(LoadSettingValue<string>("SMS_BIRTHDAY_PARAMS")) { LastSubmit = DateTime.Now.Date.AddDays(-1) };
            SaveSettingValue("SMS_BIRTHDAY_PARAMS", smsParams.ToString());
            lblBdayLast.Text = string.Format(_lastSmsSend, smsParams.GetLastSubmitCaption());
        }

        private void ChkAutoCalSmsCheckedChanged(object sender, EventArgs e)
        {
            panel1.Enabled = chkAutoCalSms.Checked;
        }

        private void BtnRefreshClick(object sender, EventArgs e)
        {
            var smsCalParams = new AutoCalSmsParams(AppSettingsHelper.GetParamValue("SMS_CALENDAR_PARAMS"), string.Empty);
            lblCalLastSend.Text = string.Format(_lastSmsSend, smsCalParams.GetLastSubmitCaption());
        }

        private void SaveXmlSupportFile()
        {
            try
            {
                var file = new SettingsFileHelper();
                if (string.IsNullOrEmpty(file.GetSettingValue("PhoneNo")))
                {
                    file.SetSettingValue("PhoneNo", txtSmsFrom.Text);
                }
                file.Save();
            }
            catch { Utils.CatchException(); }

            try
            {
                var file = new SettingsFileHelper();
                file.SetSettingValue("SMS_UNIQUEID", txtUniqueId.Text);
                file.Save();
            }
            catch { Utils.CatchException(); }
        }

        private void BtnCheckClick(object sender, EventArgs e)
        {
            txtCheckException.Text = string.Empty;
            lblCheckStatus.Visible = false;
            txtCheckException.Visible = false;
            Application.DoEvents();

            this.Cursor = Cursors.WaitCursor;
            var smsEngine = new SmsEngine();
            var credit = smsEngine.GetCredit();

            if (credit == -1)
            {
                lblCheckStatus.Text = smsEngine.LastException.Message;
                txtCheckException.Text = smsEngine.LastException.ToString();
                lblCheckStatus.ForeColor = Color.Red;
                txtCheckException.Visible = true;
            }
            else
            {
                lblCheckStatus.Text = string.Format(_checkStatus, credit);
                lblCheckStatus.ForeColor = Color.Green;
            }

            this.Cursor = Cursors.Default;
            lblCheckStatus.Visible = true;
        }

        private void BtnUniqueId_Click(object sender, EventArgs e)
        {
            var credentials = new SmsFactoryCommon.CustomerCredentials
            {
                ApplicationId = SmsEngine.Credentials.ApplicationId,
                Username = SmsEngine.Credentials.Username,
                Password = SmsEngine.Credentials.Password
            };

            try
            {
                var id = WebServices.CommonWs.GetCustomerUniqueId(credentials);
                txtUniqueId.Text = id;
            }
            catch (Exception ex)
            {
                General.ShowErrorMessageDialog(this, "בדיקת מזהה לקוח", "בדיקת מזהה לקוח", string.Empty, ex, null);
            }

            SaveXmlSupportFile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtCheckException.Show();
            txtCheckException.Clear();
            Application.DoEvents();
            var table = ClientHelper.GetSyncContacts();
            var count = table.Rows.Count > 500 ? "500 מתוך " + table.Rows.Count : table.Rows.Count.ToString(CultureInfo.InvariantCulture);
            txtCheckException.AppendText(count + @" אנשי קשר... ");
            try
            {
                General.SyncContacts(true);
                txtCheckException.AppendText("הסתיים");
            }
            catch (Exception ex)
            {
                txtCheckException.AppendText(ex.ToString());
            }
        }
    }
}