using System;
using System.IO;

namespace BizCare.SoftHair.UpdateVersion.Library
{
    public class FileRunOver : ActionBase
    {
        public string SourceFolder { get; private set; }
        public string TargetFolder { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileRunOver"/> class.
        /// </summary>
        /// <param name="sourcefolder">The sourcefolder.</param>
        /// <param name="targetfolder">The targetfolder.</param>
        public FileRunOver(string sourcefolder, string targetfolder)
        {
            SourceFolder = sourcefolder;
            TargetFolder = targetfolder;
        }

        /// <summary>
        /// Runs the over.
        /// </summary>
        public void RunOver()
        {
            CopyFiles();
            CopyFolders();
        }

        private void CopyFiles()
        {
            string[] files;
            try
            {
                files = Directory.GetFiles(SourceFolder);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Fail to read source file list", ex);
            }

            FileInfo fi;
            foreach (var f in files)
            {
                fi = new FileInfo(f);
                var target = Path.Combine(TargetFolder, fi.Name);

                try
                {
                    File.Copy(fi.FullName, target, true);
                    OnLogCreated(new LogEntry("Copy " + target));
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Fail copy file " + fi.Name, ex);
                }
            }
        }

        private void CopyFolders()
        {
            string[] folders;
            try
            {
                folders = Directory.GetDirectories(SourceFolder);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Fail to read folders", ex);
            }

            DirectoryInfo di;
            foreach (var d in folders)
            {
                di = new DirectoryInfo(d);
                var target = Path.Combine(TargetFolder, di.Name);

                try
                {
                    CopyDirectory(di.FullName, target, true);
                    OnLogCreated(new LogEntry("Copy directory " + target));
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Fail copy directory " + target, ex);
                }
            }
        }

        private void CopyDirectory(string sourcePath, string destinationPath, bool overwriteExisting)
        {
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
                    OnLogCreated(new LogEntry("Copy " + destinationPath + flinfo.Name));
                }
                foreach (var drs in Directory.GetDirectories(sourcePath))
                {
                    var drinfo = new DirectoryInfo(drs);
                    CopyDirectory(drs, destinationPath + drinfo.Name, overwriteExisting);
                }
            }
        }
    }
}