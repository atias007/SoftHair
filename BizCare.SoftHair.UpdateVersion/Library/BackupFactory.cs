using System;
using System.Collections.Generic;
using System.IO;

namespace BizCare.SoftHair.UpdateVersion.Library
{
    public class BackupFactory : ActionBase
    {
        private readonly List<string> _skipBackupFolders = new List<string>();

        public BackupFactory()
        {
            _skipBackupFolders.AddRange(Properties.Resources.skip_backup_folders.Split(','));
        }

        public string DoBackup()
        {
            var id = DateTime.Now.ToString("ddMMyyyyHHmmfff");
            var target = "c:\\SoftHair_Backup\\" + id;
            CopyDirectory(Properties.Resources.app_folder, target, true);
            OnLogCreated(new LogEntry("Backup application to " + target));
            return target;
        }

        public void Rollback(string backupPath)
        {
            try
            {
                CopyDirectory(backupPath, Properties.Resources.app_folder, true);
                OnLogCreated(new LogEntry("Rollback backup from " + backupPath));
            }
            catch (Exception ex)
            {
                OnLogCreated(new LogEntry("Fail rollback backup from " + backupPath, ex));
                throw new ApplicationException("שגיאה בשחזור קבצי הגיבוי", ex);
            }
        }

        public void RemoveBackup(string backupPath)
        {
            if (Directory.Exists(backupPath))
            {
                Directory.Delete(backupPath, true);
                OnLogCreated(new LogEntry("Remove backup folder " + backupPath));
            }
            if (Directory.Exists("c:\\SoftHair_Backup"))
            {
                Directory.Delete("c:\\SoftHair_Backup", true);
                OnLogCreated(new LogEntry("Remove backup folder c:\\SoftHair_Backup"));
            }
        }

        private void CopyDirectory(string sourcePath, string destinationPath, bool overwriteExisting)
        {
            if (IsToSkipFolder(sourcePath)) return;

            sourcePath = sourcePath.EndsWith(@"\") ? sourcePath : sourcePath + @"\";
            destinationPath = destinationPath.EndsWith(@"\") ? destinationPath : destinationPath + @"\";

            if (Directory.Exists(sourcePath))
            {
                if (Directory.Exists(destinationPath) == false)
                    Directory.CreateDirectory(destinationPath);

                foreach (var fls in Directory.GetFiles(sourcePath))
                {
                    var flinfo = new FileInfo(fls);
                    flinfo.CopyTo(destinationPath + flinfo.Name, overwriteExisting);
                }
                foreach (var drs in Directory.GetDirectories(sourcePath))
                {
                    var drinfo = new DirectoryInfo(drs);
                    CopyDirectory(drs, destinationPath + drinfo.Name, overwriteExisting);
                }
            }
        }

        private bool IsToSkipFolder(string folder)
        {
            var skip = false;

// ReSharper disable LoopCanBeConvertedToQuery
            foreach (var f in _skipBackupFolders)
// ReSharper restore LoopCanBeConvertedToQuery
            {
                if (folder.ToLower().EndsWith("\\" + f.ToLower()))
                {
                    skip = true;
                    break;
                }
            }

            return skip;
        }
    }
}
