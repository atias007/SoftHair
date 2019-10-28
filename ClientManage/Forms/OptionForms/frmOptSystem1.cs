using System;
using System.ComponentModel;
using System.Drawing;
using ClientManage.BL.Library;
using ClientManage.Library;
using ClientManage.Interfaces;

namespace ClientManage.Forms.OptionForms
{
    public partial class FormOptSystem1 : BaseMdiOptionForm
    {
        public FormOptSystem1()
        {
            InitializeComponent();

            cmbDialArea.DataSource = Validation.LinePhonePrefix;
        }

        public override void SaveSettings()
        {
            txtWSpass.Text = txtWSpass.Text.Replace(",", string.Empty);
            txtWSuser.Text = txtWSuser.Text.Replace(",", string.Empty);
            if (cmbDateFormat.SelectedIndex < 0) cmbDateFormat.SelectedIndex = 0;

            base.SaveSettingValue("APP_CLIENT_ID", txtClientId.Text);
            base.SaveSettingValue("APP_CLIENT_NAME", txtClientName.Text);
            base.SaveSettingValue("APP_LOGIN_PASSWORD", txtLoginPass.Text);
            base.SaveSettingValue("APP_MASTER_PASSWORD", txtMasterPassword.Text);
            base.SaveSettingValue("WS_CRED_PASSWORD", txtWSpass.Text);
            base.SaveSettingValue("WS_CRED_USER", txtWSuser.Text);
            base.SaveSettingValue("SMS_WS_COMMON_URL", txtCommonWS.Text);
            base.SaveSettingValue("PHONE_AREA_CODE", cmbDialArea.Text);
            base.SaveSettingValue("APP_SHOW_PRINTER_DIALOG", chkShowPrintDialog.Checked);
            base.SaveSettingValue("MAIN_ENABLE_CALLERID", chkEnableCallerId.Checked);
            base.SaveSettingValue("APP_ENABLE_OUT_CALLS", chkEnableDial.Checked);
            base.SaveSettingValue("PHONE_LOG_CALLS", chkEnableCallLog.Checked);
            base.SaveSettingValue("MAIN_ENABLE_WEBCAM", chkEnableWebCam.Checked);
            base.SaveSettingValue("MAIN_SHOW_TODAY_BIRTHDAY", chkBirthDateRem.Checked);
            base.SaveSettingValue("PHONE_DIAL_AREA_CODE", chkDialPrefix.Checked);
            base.SaveSettingValue("APP_DATE_FORMAT", cmbDateFormat.Text);
            base.SaveSettingValue("SMS_UNIQUEID", txtUniqueId.Text);

            if (chkBirthDaySpan.Checked)
            {
                base.SaveSettingValue("MAIN_BIRTHDAY_CHECK_TIME", Convert.ToInt32(cmbBDateHour.Text) + "," + Convert.ToInt32(cmbBDayMin.Text) + ",0");
            }

            SaveXmlSupportFile();
        }

        public override void LoadSettings()
        {
            txtClientId.Text = LoadSettingValue<string>("APP_CLIENT_ID");
            txtClientName.Text = LoadSettingValue<string>("APP_CLIENT_NAME");
            txtLoginPass.Text = LoadSettingValue<string>("APP_LOGIN_PASSWORD");
            txtMasterPassword.Text = LoadSettingValue<string>("APP_MASTER_PASSWORD");
            txtWSpass.Text = LoadSettingValue<string>("WS_CRED_PASSWORD");
            txtWSuser.Text = LoadSettingValue<string>("WS_CRED_USER");
            txtCommonWS.Text = LoadSettingValue<string>("SMS_WS_COMMON_URL");
            cmbDialArea.SelectedIndex = cmbDialArea.FindString(LoadSettingValue<string>("PHONE_AREA_CODE"));
            chkShowPrintDialog.Checked = LoadSettingValue<bool>("APP_SHOW_PRINTER_DIALOG");
            chkEnableCallerId.Checked = LoadSettingValue<bool>("MAIN_ENABLE_CALLERID");
            chkEnableDial.Checked = LoadSettingValue<bool>("APP_ENABLE_OUT_CALLS");
            chkEnableCallLog.Checked = LoadSettingValue<bool>("PHONE_LOG_CALLS");
            chkEnableWebCam.Checked = LoadSettingValue<bool>("MAIN_ENABLE_WEBCAM");
            chkBirthDateRem.Checked = LoadSettingValue<bool>("MAIN_SHOW_TODAY_BIRTHDAY");
            chkDialPrefix.Checked = LoadSettingValue<bool>("PHONE_DIAL_AREA_CODE");
            cmbDateFormat.SelectedIndex = cmbDateFormat.FindString(base.LoadSettingValue<string>("APP_DATE_FORMAT"));
            txtDbVersion.Text = LoadSettingValue<string>("APP_VERSION");
            txtUniqueId.Text = LoadSettingValue<string>("SMS_UNIQUEID");

            lblDbVersion.Visible = (txtDbVersion.Text != System.Windows.Forms.Application.ProductVersion);
        }

        private void TxtLoginPassValidating(object sender, CancelEventArgs e)
        {
            var pass = txtLoginPass.Text;
            var msg = string.Empty;
            const string msg2 = "העדפות...";

            if (pass.Length > 0 && pass.Length < 4)
            {
                msg += "אורך סיסמת הכניסה חייב להיות לפחות 4 תווים\n";
            }
            if (pass.IndexOf(" ") >= 0)
            {
                msg += "הסיסמה מכילה רווחים. תו זה אינו חוקי";
            }

            if (msg.Length > 0)
            {
                txtLoginPass.BackColor = Validation.ErrorColor;
                MsgBox = new MyMessageBox(msg, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
                e.Cancel = true;
            }
            else
            {
                if (txtLoginPass.BackColor == Validation.ErrorColor)
                {
                    txtLoginPass.BackColor = Color.White;
                }
            }
        }

        private void SetBDateSpanData()
        {
            var bDateSpan = Utils.GetIntArray(LoadSettingValue<String>("MAIN_BIRTHDAY_CHECK_TIME"));

            if (bDateSpan[0] + bDateSpan[1] + bDateSpan[2] == 0)
            {
                chkBirthDaySpan.Checked = false;
            }
            else
            {
                cmbBDateHour.SelectedIndex = cmbBDateHour.FindString(bDateSpan[0].ToString("0#"));
                cmbBDayMin.SelectedIndex = cmbBDayMin.FindString(bDateSpan[1].ToString("0#"));
            }
        }

        private void ChkBirthDateRemCheckedChanged(object sender, EventArgs e)
        {
            chkBirthDaySpan.Enabled = chkBirthDateRem.Checked;
            chkBirthDaySpan.Checked = chkBirthDaySpan.Enabled;
        }

        private void ChkBirthDaySpanCheckedChanged(object sender, EventArgs e)
        {
            cmbBDateHour.Enabled = chkBirthDaySpan.Checked;
            cmbBDayMin.Enabled = chkBirthDaySpan.Checked;
            lblBdateSep.Enabled = chkBirthDaySpan.Checked;

            if (chkBirthDaySpan.Checked)
            {
                SetBDateSpanData();
            }
        }

        private void BtnValidUrlCommonClick(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                General.ShowErrorMessageDialog(this, "שירותי רשת כלליים", "בדיקת שירותי רשת", ex.Message, ex, null);
            }
        }

        private void BtnValidUrlHostClick(object sender, EventArgs e)
        {
            OpenUrl(txtHost.Text);
        }

        private void SaveXmlSupportFile()
        {
            try
            {
                var file = new SettingsFileHelper();
                file.SetSettingValue("ClientID", txtClientId.Text);
                file.SetSettingValue("ClientName", txtClientName.Text);
                file.Save();
            }
            catch { Utils.CatchException(); }
        }

        private void Button1Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                txtUniqueId.Clear();
                var msg = new MyMessageBox(ex.ToString(), "Error...", MyMessageBox.MyMessageType.Error, MyMessageBox.MyMessageButton.Ok);
                msg.Show(this);
            }
        }
    }
}