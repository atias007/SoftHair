using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using BizCare.SoftHair.UpdateVersion.Library;
using System.Runtime.InteropServices;
using BizCare.SoftHair.UpdateVersion.SmsFactoryCommon;
using Application = System.Windows.Forms.Application;

namespace BizCare.SoftHair.UpdateVersion
{
    public partial class Form1 : Form
    {
        #region Private Members

        [DllImport("user32.dll")]
// ReSharper disable InconsistentNaming
        private static extern int EnableMenuItem(IntPtr hMenu, int wIDEnableItem, int wEnable);
// ReSharper restore InconsistentNaming

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevent);

        private const int ScClose = 0xf060;
        private const int MfGrayed = 0x1;

        private readonly Utils _utils;
        private readonly List<LogEntry> _logs = new List<LogEntry>();
        private readonly Parameters _parameters = new Parameters();
        private SqlRunner _runner;
        private string _backupFolder;
        private bool _isStart;
        
        #endregion

        #region Constuctor

        public Form1()
        {
            InitializeComponent();

            _utils = new Utils();
            _utils.LogCreated += ItemLogCreated;
        }

        #endregion

        private UserCredentials _userCredentials;
        public UserCredentials UserCredentials
        {
            get { return _userCredentials ?? (_userCredentials = new UserCredentials { UniqueId = "12b758bb-5db0-4208-b35b-4cdf3b888a9c" }); }
        }

        private static void DisableCloseFormButton(IntPtr handle)
        {
            EnableMenuItem(GetSystemMenu(handle, false), ScClose, MfGrayed);
        }

        private void UpdateVersion()
        {
            _parameters.StartAt = DateTime.Now;
            AddLogEntry(new LogEntry("Start update process at " + _parameters.StartAt));
            AddLogEntry(new LogEntry("Current update version " + Application.ProductVersion));

            if (StartProcess())
            {
                SetFinalStep();
                StartApplicationsProcess();
                RemoveBackup();
            }
            else
            {
                SetFinalStep();
                RollbackBackup();
                StartApplicationsProcess();
            }

            _parameters.EndAt = DateTime.Now;
            AddLogEntry(new LogEntry("End update process at " + _parameters.EndAt));

            this.Hide();

            if (Environment.CommandLine.EndsWith("/Debug"))
            {
                ShowReport();
            }
            else
            {
                SendReportMail();
            }
        }

        private void IncreaseStep()
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value += 1;
                Application.DoEvents();
            }
        }

        private void SetFinalStep()
        {
            progressBar1.Value = progressBar1.Maximum;
            Application.DoEvents();
        }

        private bool StartProcess()
        {
            var success = false;

            if (InitilizeDbConnection())
            {
                if (ReadParameters())
                {
                    if (!IsVersionOld())
                    {
                        AddLogEntry(new LogEntry("There is no need to update version", LogEntry.LogType.Warning));
                        return true;
                    }

                    if (IsCustomerRestricted())
                    {
                        AddLogEntry(new LogEntry("Customer is restricted from updating", LogEntry.LogType.Warning));
                        var result = UpdateVersionNo();
                        return result;
                    }

                    if (CloseApplicationsProcess())
                    {
                        if (CreateBackup())
                        {
                            if (RunVersionScript())
                            {
                                if (CopyFiles())
                                {
                                    DoClientCustomAction();

                                    if (UpdateVersionNo())
                                    {
                                        success = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return success;
        }

        private void AddLogEntry(LogEntry log)
        {
            _logs.Add(log);
            Application.DoEvents();
        }

        private bool CloseApplicationsProcess()
        {
            IncreaseStep();
            var success = true;

            try
            {
                _utils.CloseQuickLaunch();
                AddLogEntry(new LogEntry("Close QuickLaunch process"));
                _utils.CloseSoftHair();
                AddLogEntry(new LogEntry("Close SoftHair process"));
            }
            catch (Exception ex)
            {
                AddLogEntry(new LogEntry("Fail to close applications process", ex));
                success = false;
            }

            return success;
        }
        
        private void StartApplicationsProcess()
        {
            IncreaseStep();
            try
            {
                _utils.StartQuickLaunch();
                AddLogEntry(new LogEntry("Start QuickLaunch process"));
                _utils.StartSoftHair();
                AddLogEntry(new LogEntry("Start SoftHair process"));
            }
            catch (Exception ex)
            {
                AddLogEntry(new LogEntry("Fail to close applications", LogEntry.LogType.Warning, ex));
            }
        }

        private bool CreateBackup()
        {
            IncreaseStep();
            var success = true;

            try
            {
                var bu = new BackupFactory();
                bu.LogCreated += ItemLogCreated;
                _backupFolder = bu.DoBackup();
            }
            catch (Exception ex)
            {
                AddLogEntry(new LogEntry("Fail to create backup", ex));
                _backupFolder = null;
                success = false;
            }

            return success;
        }

        private void RemoveBackup()
        {
            try
            {
                if (!string.IsNullOrEmpty(_backupFolder))
                {
                    var bu = new BackupFactory();
                    bu.LogCreated += ItemLogCreated;
                    bu.RemoveBackup(_backupFolder);
                }
            }
            catch (Exception ex)
            {
                AddLogEntry(new LogEntry("Fail to remove backup", LogEntry.LogType.Warning, ex));
            }
        }

        private void RollbackBackup()
        {
            try
            {
                if (!string.IsNullOrEmpty(_backupFolder))
                {
                    var bu = new BackupFactory();
                    bu.LogCreated += ItemLogCreated;
                    bu.Rollback(_backupFolder);
                    bu.RemoveBackup(_backupFolder);
                }
            }
            catch (Exception ex)
            {
                AddLogEntry(new LogEntry("Fail to rollback backup", ex));
            }
        }

        private bool InitilizeDbConnection()
        {
            IncreaseStep();
            var success = true;

            try
            {
                _runner = new SqlRunner(_utils.GetConnectionString());
                _runner.LogCreated += ItemLogCreated;
                _runner.InitilizeDbConnection();

            }
            catch (Exception ex)
            {
                AddLogEntry(new LogEntry("Fail to open connection to database", ex));
                success = false;
                _runner = null;
            }

            return success;
        }

        private bool ReadParameters()
        {
            IncreaseStep();
            var success = true;
            
            try
            {
                _parameters.CurrentVersion = Application.ProductVersion;
                _parameters.ClientVersion = _runner.GetParameter("APP_VERSION");
                _parameters.ClientID = _runner.GetParameter("APP_CLIENT_ID");
                _parameters.ClientName = _runner.GetParameter("APP_CLIENT_NAME");
                _parameters.UniqueId = _runner.GetParameter("SMS_UNIQUEID");
            }
            catch (Exception ex)
            {
                AddLogEntry(new LogEntry(ex.Message, ex));
                success = false;
            }

            return success;
        }

        private bool IsVersionOld()
        {
            IncreaseStep();
            bool isOld;

            try
            {
                isOld = _utils.IsVersionGreater(_parameters.CurrentVersion, _parameters.ClientVersion);
            }
            catch (Exception ex)
            {
                isOld = true;
                AddLogEntry(new LogEntry("Error while check version number", LogEntry.LogType.Warning, ex));
            }

            return isOld;
        }

        private bool IsCustomerRestricted()
        {
            // ***** change also \ClientManage\Library\General.cs ******
            var restricted = new[] {"90011", "90033", "90102", "90103"};
            return restricted.Contains(_parameters.ClientID);
        }

        private bool RunVersionScript()
        {
            IncreaseStep();
            var success = true;
            var script = string.Empty;

            try
            {
                script = _utils.GetVersionScript(_parameters.ClientVersion);
            }
            catch (Exception ex)
            {
                AddLogEntry(new LogEntry("Error while get version script", ex));
                success = false;
            }

            if (success)
            {
                try
                {
                    var se = new ScriptExecuter(script, _runner);
                    se.LogCreated += ItemLogCreated;
                    se.Execute();
                }
                catch (Exception ex)
                {
                    AddLogEntry(new LogEntry(ex.Message, ex));
                    success = false;
                }
            }

            return success;
        }

        private bool CopyFiles()
        {
            IncreaseStep();
            var success = true;

            try
            {
                var fr = new FileRunOver(_utils.GetFilesFolder(), Properties.Resources.app_folder);
                fr.LogCreated += ItemLogCreated;
                fr.RunOver();
            }
            catch (Exception ex)
            {
                AddLogEntry(new LogEntry(ex.Message, ex));
                success = false;
            }

            return success;
        }

        private bool UpdateVersionNo()
        {
            var result = false;

            try
            {
                var script = "UPDATE tblParams SET param_value = '" + _parameters.CurrentVersion + "' WHERE param_name = 'APP_VERSION'";
                var se = new ScriptExecuter(script, _runner);
                se.LogCreated += ItemLogCreated;
                se.Execute();
                result = true;
            }
            catch (Exception ex)
            {
                AddLogEntry(new LogEntry("Fail to update version no (Client DB)", ex));
            }

            try
            {
                var client = new CommonServicesClient();
                client.SetCustomerVersion(this.UserCredentials, _parameters.UniqueId, _parameters.CurrentVersion);
            }
            catch(Exception ex)
            {
                AddLogEntry(new LogEntry("Fail to update version no (Server)", ex));
            }

            return result;
        }

        private void DoClientCustomAction()
        {
            IncreaseStep();
            try
            {
                var act = new PersonalClientAction(_runner, _parameters);
                act.LogCreated += ItemLogCreated;
                act.DoAction();
            }
            catch (Exception ex)
            {
                AddLogEntry(new LogEntry("Fail to do custom action for current client", LogEntry.LogType.Warning, ex));
            }
        }

        void ItemLogCreated(object sender, UpdateEventArgs e)
        {
            AddLogEntry(e.Log);
            Application.DoEvents();
        }

        private string GetLogReport()
        {
            var template = _utils.GetReportTemplate();
            var content = string.Empty;
            var isAlternative = false;

            foreach (var log in _logs)
            {
                content += log.GetHtml(isAlternative);
                isAlternative = !isAlternative;
            }

            var status = GetReportStatus();
            var icon = "http://smsfactorystorage.blob.core.windows.net/softhair/Admin/images/{0}.gif";
            var message = string.Empty;
            switch (status)
            {
                case LogEntry.LogType.Information:
                    icon = string.Format(icon, "ok");
                    message = "Update process end successfully";
                    break;
                case LogEntry.LogType.Error:
                    icon = string.Format(icon, "error");
                    message = "Update process fail";
                    break;
                case LogEntry.LogType.Warning:
                    icon = string.Format(icon, "warn");
                    message = "Update process end with one or more warnings";
                    break;
            }

            template = template.Replace("{0}", _parameters.CurrentVersion);
            template = template.Replace("{1}", _parameters.ClientID);
            template = template.Replace("{2}", _parameters.ClientName);
            template = template.Replace("{3}", _parameters.StartAt.ToString(CultureInfo.InvariantCulture));
            template = template.Replace("{4}", _parameters.EndAt.ToString(CultureInfo.InvariantCulture));
            template = template.Replace("{5}", icon);
            template = template.Replace("{6}", message);
            template = template.Replace("{7}", content);

            return template;
        }

        private LogEntry.LogType GetReportStatus()
        {
            var status = LogEntry.LogType.Information;
            foreach (var log in _logs)
            {
                if (log.Type == LogEntry.LogType.Warning)
                {
                    status = LogEntry.LogType.Warning;
                }
                else if(log.Type == LogEntry.LogType.Error)
                {
                    status = LogEntry.LogType.Error;
                    break;
                }
            }
            return status;
        }

        private void ShowReport()
        {
            var writer = new StreamWriter("log_report.htm", false, Encoding.UTF8);
            writer.Write(GetLogReport());
            writer.Close();
            Process.Start("log_report.htm");
        }

        private void SendReportMail()
        {
            var html = string.Empty;
            try
            {
                html = GetLogReport();

                var srv = new CommonServicesClient("BasicHttpBinding_ICommonServices", "http://smsfactoryservice.cloudapp.net/services/CommonServices.svc");
                var mail = new EmailMessage
                {
                    To = new[] { new EmailAddress { Address = "tsahiatias@gmail.com", DisplayName = "SoftHair Administrator" } },
                    From = new EmailAddress { Address = "atias007@gmx.com", DisplayName = "SoftHair Update System" },
                    Body = html,
                    IsBodyHtml = true,
                    Subject = "Client " + _parameters.ClientID + " - " + _parameters.ClientName + " Update Version",
                };

                srv.SendEmailAsync(this.UserCredentials, mail);
            }
            catch
            {
                try
                {
                    _runner.AddUpdateReport(html);
                }
                catch { Utils.HandleException(); }
            }

            //try
            //{
            //    var srv = new CommonServicesClient("BasicHttpBinding_ICommonServices", "http://smsfactoryservice.cloudapp.net/services/CommonServices.svc");
            //    srv.SetCustomerUpToDateVersion(this.UserCredentials, _parameters.UniqueId);
            //}
            //catch { Utils.HandleException(); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            const string title = "עדכון גרסה מספר ";
            this.Text = title + Application.ProductVersion;
            DisableCloseFormButton(this.Handle);
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (_isStart) return;
            _isStart = true;
            this.Visible = true;
            this.Show();
            Application.DoEvents();
            Thread.Sleep(1000);
            Application.DoEvents();
            UpdateVersion();
            Environment.Exit(0);
        }
    }
}
