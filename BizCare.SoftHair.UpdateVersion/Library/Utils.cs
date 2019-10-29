using System;
using System.Text;
using System.Diagnostics;
using System.IO;
using BizCare.SoftHair.UpdateVersion.Schemas;
using System.Xml;

namespace BizCare.SoftHair.UpdateVersion.Library
{
    public class Utils : ActionBase
    {
        public void CreateSchemaFileSample()
        {
            var ds = new dsConfig();
            var row = ds.VersionsMap.NewVersionsMapRow();
            row.FromVersion = "1";
            row.ToVersion = "2";
            row.Filename = "XX";
            ds.VersionsMap.Rows.Add(row);

            row = ds.VersionsMap.NewVersionsMapRow();
            row.FromVersion = "3";
            row.ToVersion = "4";
            row.Filename = "YY";
            ds.VersionsMap.Rows.Add(row);

            ds.WriteXml("c:\\VersionsMap.xml");
        }

        public string GetConnectionString()
        {
            var conn = Properties.Resources.connection_string;
            conn = string.Format(conn, Path.Combine(Properties.Resources.app_folder, Properties.Resources.data_filename));
            return conn;
        }

        public string GetFilesFolder()
        {
            var asm = System.Reflection.Assembly.GetExecutingAssembly();
            string folder = null;

            if (asm.Location != null)
            {
                var fi = new FileInfo(asm.Location);
                if (fi.Directory != null)
                {
                    folder = Path.Combine(fi.Directory.FullName, Properties.Resources.files_location);
                }
            }
            return folder;
        }

        public void CloseQuickLaunch()
        {
            var procs = Process.GetProcessesByName("QuickLaunch");

            foreach (var p in procs)
            {
                p.Kill();
            }
        }

        public void StartQuickLaunch()
        {
            var si = new ProcessStartInfo
            {
                FileName = Path.Combine(Properties.Resources.app_folder, "QuickLaunch.exe"),
                WorkingDirectory = Properties.Resources.app_folder
            };
            Process.Start(si);
        }

        public void CloseSoftHair()
        {
            var procs = Process.GetProcessesByName("SoftHair");

            foreach (var p in procs)
            {
                p.Kill();
            }
        }

        public void StartSoftHair()
        {
            var si = new ProcessStartInfo
            {
                FileName = Path.Combine(Properties.Resources.app_folder, "SoftHair.exe"),
                WorkingDirectory = Properties.Resources.app_folder
            };
            Process.Start(si);
        }

        public string GetReportTemplate()
        {
            return GetResource("BizCare.SoftHair.UpdateVersion.ReportTemplate.htm");
        }

        private static string GetResource(string filename)
        {
            var asm = System.Reflection.Assembly.GetExecutingAssembly();

            //' resources are named using a fully qualified name
            var strm = asm.GetManifestResourceStream(filename);

            //' read the contents of the embedded file
            var val = string.Empty;
            if (strm != null)
            {
                var reader = new StreamReader(strm, Encoding.Default);
                val = reader.ReadToEnd();
                reader.Close();
            }
            return val;
        }

        public string GetVersionScript(string currentVersion)
        {
            var script = string.Empty;
            var xml = GetResource("BizCare.SoftHair.UpdateVersion.Schemas.VersionsMap.xml");
            var ds = new dsConfig();
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            ds.ReadXml(new XmlNodeReader(doc));
            var index = -1;

            foreach (var row in ds.VersionsMap)
            {
                if (row.FromVersion == currentVersion)
                {
                    index = ds.VersionsMap.Rows.IndexOf(row);
                    break;
                }
            }

            if (index >= 0)
            {
                for (var i = index; i < ds.VersionsMap.Rows.Count; i++)
                {
                    script += GetResource("BizCare.SoftHair.UpdateVersion.Scripts." + ds.VersionsMap[i].Filename);
                }
            }
            else
            {
                OnLogCreated(new LogEntry("No script found for version " + currentVersion, LogEntry.LogType.Warning));
            }

            return script;
        }

        public bool IsVersionGreater(string currentVersion, string clientVersion)
        {
            var arrOnline = currentVersion.Split('.');
            var arrClient = clientVersion.Split('.');

            if (arrOnline.Length != arrClient.Length) return true;
            for (var i = 0; i < arrOnline.Length; i++)
            {
                if (string.IsNullOrEmpty(arrOnline[i])) arrOnline[i] = "0";
                if (string.IsNullOrEmpty(arrClient[i])) arrClient[i] = "0";
                var iOnline = Convert.ToInt32(arrOnline[i]);
                var iClient = Convert.ToInt32(arrClient[i]);
                if (iOnline > iClient) return true;
                if (iOnline < iClient) return false;
            }

            return false;
        }

        public static void HandleException(Exception ex = null)
        {
            // do nothing //
        }
    }
}