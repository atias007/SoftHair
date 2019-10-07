using System;
using System.Data;
using System.Diagnostics;
using ClientManage.Interfaces.Schemas;
using ClientManage.Interfaces;
using System.IO;

namespace BizCare.SoftHair.UpdateVersion.Library
{
    public class PersonalClientAction : ActionBase
    {
        private readonly SqlRunner _runner;
        private readonly Parameters _parameters;

        public PersonalClientAction(SqlRunner runner, Parameters parameters)
        {
            _runner = runner;
            _parameters = parameters;
        }

        public void DoAction()
        {
            AllClientsAction();

            switch (_parameters.ClientID)
            {
                case "90015":
                    #region Set all reports to be secure

                    var reports = _runner.GetAllReports();
                    ReportSchema r;
                    foreach (DataRow row in reports.Rows)
                    {
                        var id = ClientManage.Interfaces.Utils.GetDBValue<int>(row, "id");
                        var xml = ClientManage.Interfaces.Utils.GetDBValue<string>(row, "report_xml");
                        r = Security.DecryptReport(xml);
                        if (!r.General[0].IsSecureReport)
                        {
                            r.General[0].IsSecureReport = true;
                            _runner.UpdateReport(id, r);
                        }
                    }

                    OnLogCreated(new LogEntry("Do custom action for client " + _parameters.ClientID + ". Update all reports to be secured"));

                    #endregion
                    break;

                default:
                    break;
            }
        }

        public void AllClientsAction()
        {
            OnLogCreated(new LogEntry("Do custom action for all clients"));
            DeleteFile("OnlineUpdate.exe");
            DeleteFile("WebCam_Capture.dll");
            DeleteFile("OnlineUpdate.exe.config");
            DeleteFile("SHELL32.dll");
            DeleteDirectory("Upload");
            //if(_parameters.CurrentVersion == "3.6.0.0") RunFile("dotNetFx40_Full_setup.exe");
        }

        /// <summary>
        /// Runs the file.
        /// </summary>
        /// <param name="filename">The filename.</param>
        private void RunFile(string filename)
        {
            try
            {
                var path = Path.Combine(Properties.Resources.app_folder, filename);
                if (File.Exists(path))
                {
                    var process = Process.Start(path);
                    if (process != null) process.WaitForExit();
                    OnLogCreated(new LogEntry("Execute file " + filename));
                }
            }
            catch (Exception ex)
            {
                OnLogCreated(new LogEntry("Fail to execute file " + filename, LogEntry.LogType.Warning, ex));
            }
        }

        private void DeleteFile(string filename)
        {
            try
            {
                var path = Path.Combine(Properties.Resources.app_folder, filename);
                if (File.Exists(path))
                {
                    File.Delete(path);
                    OnLogCreated(new LogEntry("Delete file " + filename));
                }
            }
            catch (Exception ex)
            {
                OnLogCreated(new LogEntry("Fail to delete file " + filename, LogEntry.LogType.Warning, ex));
            }
        }

        private void DeleteDirectory(string name)
        {
            try
            {
                var path = Path.Combine(Properties.Resources.app_folder, name);
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                    OnLogCreated(new LogEntry("Delete directory " + name));
                }
            }
            catch (Exception ex)
            {
                OnLogCreated(new LogEntry("Fail to delete directory " + name, LogEntry.LogType.Warning, ex));
            }
        }
    }
}
