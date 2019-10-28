using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;
using ClientManage.Library;
using System.Diagnostics;
using System.Threading;

namespace ClientManage.Forms.OptionForms
{
    public partial class FormOptOnlineUpdate : BaseMdiOptionForm
    {
        private readonly string _lastUpdateFormat = string.Empty;

        public FormOptOnlineUpdate()
        {
            InitializeComponent();

            _lastUpdateFormat = lblLastUpdate.Text;
        }

        public override void LoadSettings()
        {
            chkEnableOnlineUpdate.Checked = LoadSettingValue<bool>("ONLINE_UPDATE_ENABLE");
            var val = LoadSettingValue<string>("ONLINE_LAST_UPDATE");
            val = !string.IsNullOrEmpty(val) ? Convert.ToDateTime(val).ToString("dd/MM/yyyy") : "< לא בוצע מעולם >";
            lblLastUpdate.Text = string.Format(_lastUpdateFormat, val);
        }

        public override void SaveSettings()
        {
            SaveSettingValue("ONLINE_UPDATE_ENABLE", chkEnableOnlineUpdate.Checked);
        }

        private void BtnValidUrlUpdateClick(object sender, EventArgs e)
        {
            OpenUrl(txtOnlineUpdateURL.Text);
        }

        private static string _updateFile;

        private void BtnOnlineUpdateClick(object sender, EventArgs e)
        {
            pbarDownload.Value = 0;
            lblDownload.Visible = true;
            pbarDownload.Visible = true;
            Application.DoEvents();

            try
            {
                _updateFile = General.GetUpdateLocalFilename();
                var webClient = new WebClient();
                webClient.DownloadProgressChanged += WebClientDownloadProgressChanged;
                webClient.DownloadFileCompleted += WebClientDownloadFileCompleted;
                webClient.DownloadFileAsync(new Uri(General.UpdateUrl), _updateFile);
            }
            catch (Exception ex)
            {
                _updateFile = null;
                MessageBox.Show(ex.Message, @"Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblDownload.Visible = false;
                pbarDownload.Visible = false;
            }
        }

        private void WebClientDownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null) throw e.Error;

                Application.DoEvents();
                Thread.Sleep(1000);
                Application.DoEvents();
                Process.Start(_updateFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _updateFile = null;
                lblDownload.Visible = false;
                pbarDownload.Visible = false;
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            pbarDownload.Value = e.ProgressPercentage;
            Application.DoEvents();
        }
    }
}