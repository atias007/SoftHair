using System;
using System.Windows.Forms;
using ClientManage.Interfaces;
using ClientManage.BL.Library;
using ClientManage.Library;

namespace ClientManage.Forms.OptionForms
{
    public partial class FormOptBackup : BaseMdiOptionForm
    {
        private readonly string _lastBackupFormat = string.Empty;

        public FormOptBackup()
        {
            InitializeComponent();

            _lastBackupFormat = lblLastBackup.Text;
        }

        public override void LoadSettings()
        {
            //txtFTPPass.Text = LoadSettingValue<string>("FTP_PASSWORD");
            //txtFTPPort.Text = LoadSettingValue<string>("FTP_DIRECTORY");
            //txtLog.Text = LoadSettingValue<string>("FTP_URL");
            //txtFTPUser.Text = LoadSettingValue<string>("FTP_USERNAME");
            var span = Utils.GetStringArray(LoadSettingValue<string>("FTP_BACKUP_SPAN"));
            cmbFTPHour.SelectedIndex = cmbFTPHour.FindString(span[0]);
            cmbFTPMin.SelectedIndex = cmbFTPMin.FindString(span[1]);
            cmbFTPPeriod.SelectedIndex = cmbFTPPeriod.FindString(LoadSettingValue<string>("FTP_PERIOD"));
            chkFTPFreez.Checked = LoadSettingValue<bool>("FTP_ENABLE");
            chkFtpMinimize.Checked = LoadSettingValue<bool>("FTP_MINIMIZE");
            SetFtpLastBackupLabel();
        }

        public override void SaveSettings()
        {
            //SaveSettingValue("FTP_PASSWORD", txtFTPPass.Text);
            //SaveSettingValue("FTP_DIRECTORY", txtFTPPort.Text);
            //SaveSettingValue("FTP_URL", txtLog.Text);
            //SaveSettingValue("FTP_USERNAME", txtFTPUser.Text);
            SaveSettingValue("FTP_BACKUP_SPAN", Convert.ToInt32(cmbFTPHour.Text) + "," + Convert.ToInt32(cmbFTPMin.Text) + ",0");
            SaveSettingValue("FTP_PERIOD", cmbFTPPeriod.Text);
            SaveSettingValue("FTP_ENABLE", chkFTPFreez.Checked);
            SaveSettingValue("FTP_MINIMIZE", chkFtpMinimize.Checked);
        }

        public void SetFtpLastBackupLabel()
        {
            var dt = LoadSettingValue<DateTime>("FTP_LAST_BACKUP");
            var val = dt.ToString("dd/MM/yyyy HH:mm:ss");
            if (dt == DateTime.MinValue) val = "< לא בוצע מעולם >";
            //else if (val.Length > 10) val = val.Substring(0, 10);
            lblLastBackup.Text = string.Format(_lastBackupFormat, val);
        }

        private void ChkFtpFreezCheckedChanged(object sender, EventArgs e)
        {
            cmbFTPHour.Enabled = chkFTPFreez.Checked;
            cmbFTPMin.Enabled = chkFTPFreez.Checked;
            cmbFTPPeriod.Enabled = chkFTPFreez.Checked;
            lblFtp1.Enabled = chkFTPFreez.Checked;
            lblFtp2.Enabled = chkFTPFreez.Checked;
            lblFtp3.Enabled = chkFTPFreez.Checked;
            chkFtpMinimize.Enabled = chkFTPFreez.Checked;
        }

        private void Button3Click(object sender, EventArgs e)
        {
            var res = fBrowserDialog.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                const string msg2 = "גיבוי נתונים...";

                try
                {
                    BackupPlan.FullBackup(General.StartupPath, fBrowserDialog.SelectedPath);
                }
                catch (Exception ex)
                {
                    const string title = "שגיאה במסך העדפות...";
                    const string head = "ביצוע גיבוי נתונים מלא";
                    const string desc = "גיבוי הנתונים נכשל\nוודא כי המדיה מאפשרת כתיבה. נסה לגבות במיקום או כונן אחר";
                    General.ShowErrorMessageDialog(this, title, head, desc, ex, "frmPreferences");
                    return;
                }

                this.Cursor = Cursors.Default;
                const string msg1 = "גיבוי הנתונים הושלם בהצלחה";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Confirm, MyMessageBox.MyMessageButton.None);
                MsgBox.Show(this);
            }
        }

        private void BtnFtpBackupClick(object sender, EventArgs e)
        {
            txtLog.Clear();
            Application.DoEvents();
            try
            {
                AddBackupLog(null,  "Copy backup files (1)... ");
                BackupPlan.DataBackup(General.StartupPath);
                AddBackupLog(null,  "done\r\n");
                AddBackupLog(null,  "Copy backup files (2)... ");
                BackupPlan.PicturesBackup(General.StartupPath, chkAllPictures.Checked);
                AddBackupLog(null,  "done\r\n");
            }
            catch (Exception ex)
            {
                AddBackupLog(null, "Error!\r\n" + ex);
                const string title = "שגיאה במסך העדפות...";
                const string head = "גיבוי נתונים ברשת";
                const string desc = "גיבוי הנתונים ברשת נכשל\nלא ניתן להעתיק את בסיס הנתונים ותמונות הלקוחות למחיצת הגיבוי ברשת";
                General.ShowErrorMessageDialog(this, title, head, desc, ex, "frmPreferences");

                return;
            }
            General.OnlineBackup(this);
            SetFtpLastBackupLabel();
        }

        private void AddBackupLog(object sender, string args)
        {
            Application.DoEvents();
            txtLog.AppendText(args);
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
            Application.DoEvents();
        }

        private void FormOptBackupEnter(object sender, EventArgs e)
        {
            SetFtpLastBackupLabel();
        }
    }
}