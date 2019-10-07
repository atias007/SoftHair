using System;
using System.IO;
using ClientManage.Interfaces;
using Ionic.Zip;

namespace ClientManage.BL.Library
{
    public class BackupPlan
    {
        private const long MaxUploadImageSize = 512000;

        public static void FullBackup(string sourcePath, string targetPath)
        {
            var target = targetPath + "\\SoftHair_Backup_" + Utils.GetDateTimeIdString();

            try
            {
                if (!Directory.Exists(target))
                {
                    Directory.CreateDirectory(targetPath);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה ביצירת תיקיית גיבוי חדשה\n" + ex.Message);
            }

            try
            {
                CopyDirectory(Path.Combine(sourcePath, "AlbumImages"), Path.Combine(target, "AlbumImages"));
                CopyDirectory(Path.Combine(sourcePath, "ClientImages"), Path.Combine(target, "ClientImages"));
                CopyDirectory(Path.Combine(sourcePath, "MailTemlates"), Path.Combine(target, "MailTemlates"));
                File.Copy(Path.Combine(sourcePath, Utils.DataFilename), Path.Combine(target, Utils.DataFilename));
            }
            catch(Exception ex)
            {
                throw new Exception("שגיאה בהעתקת קבצי הגיבוי\n" + ex.Message);
            }
        }

        public static void DataBackup(string sourcePath)
        {
            var buPath = Path.Combine(sourcePath, "Backup");
            var upPath = Path.Combine(sourcePath, "Backup\\Upload");

            // Create the backup directory
            if (!Directory.Exists(buPath))
            {
                try{ Directory.CreateDirectory(buPath); }
                catch (Exception ex){ throw new Exception("שגיאה ביצירת מחיצת Backup\n" + ex.Message, ex); }
            }

            // Create the upload directory
            if (!Directory.Exists(upPath))
            {
                try { Directory.CreateDirectory(upPath); }
                catch (Exception ex) { throw new Exception("שגיאה ביצירת מחיצת Upload\n" + ex.Message, ex); }
            }

            // Copy the database file
            try { File.Copy(Path.Combine(sourcePath, Utils.DataFilename), Path.Combine(buPath, Utils.DataFilename), true); }
            catch (Exception ex) { throw new Exception("שגיאה בהעתקת קובץ הנתונים אל מחיצת הגיבוי\n" + ex.Message); }            

            // Delete old zip file
            const string filenamePattern = "data_backup_{0}.zip";
            var filename = string.Format(filenamePattern, DateTime.Now.Day);
            try { File.Delete(Path.Combine(upPath, filename)); }
            catch (Exception ex) { throw new Exception("שגיאה במחיקת קובץ ZIP ישן\n" + ex.Message); }

            // Create ZIP file
            try
            {
                var zipfile = new ZipFile(Path.Combine(upPath, filename));
                zipfile.AddFile(Path.Combine(buPath, Utils.DataFilename));
                zipfile.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                zipfile.Save();
            }
            catch (Exception ex) { throw new Exception("שגיאה ביצירת קובץ ZIP\n" + ex.Message, ex); }
        }

        //public static int GetFilesCountToFtp(string sourcePath)
        //{
        //    var path = Path.Combine(sourcePath, "Backup\\Upload");
        //    var cnt = Directory.GetFiles(path, "*.*").Length;
        //    return cnt;
        //}

        public static void PicturesBackup(string sourcePath, bool allPictures = false)
        {
            var source1 = Path.Combine(sourcePath, "AlbumImages");
            var source2 = Path.Combine(sourcePath, "ClientImages");
            var target = Path.Combine(sourcePath, "Backup\\Upload");
            string[] files;
            DateTime lastBackup;
            FileInfo fi;

            // Get the last backup date & time
            try { lastBackup = AppSettingsHelper.GetParamValue<DateTime>("FTP_LAST_BACKUP"); }
            catch (Exception ex) { throw new Exception("שגיאה בקריאת תאריך גיבוי אחרון\n" + ex.Message, ex); }

            // Create the upload directory
            if (!Directory.Exists(target))
            {
                try { Directory.CreateDirectory(target); }
                catch (Exception ex) { throw new Exception("שגיאה ביצירת מחיצת Upload\n" + ex.Message, ex); }
            }

            // Create the AlbumImages directory
            if (!Directory.Exists(source1))
            {
                try { Directory.CreateDirectory(source1); }
                catch (Exception ex) { throw new Exception("שגיאה ביצירת מחיצת AlbumImages\n" + ex.Message, ex); }
            }

            // Create the ClientImages directory
            if (!Directory.Exists(source2))
            {
                try { Directory.CreateDirectory(source2); }
                catch (Exception ex) { throw new Exception("שגיאה ביצירת מחיצת ClientImages\n" + ex.Message, ex); }
            }

            // get all new images from "AlbumImages"
            if (Directory.Exists(source1))
            {
                files = Directory.GetFiles(source1);
                foreach (var f in files)
                {
                    fi = new FileInfo(f);
                    if (allPictures || (fi.LastWriteTime >= lastBackup && fi.Length > MaxUploadImageSize))
                    {
                        try { fi.CopyTo(target + "\\" + fi.Name, true); } catch { Utils.CatchException(); }
                    }
                }
            }

            // get all new images from "ClientImages"
            if (Directory.Exists(source2))
            {
                files = Directory.GetFiles(source2);
                foreach (var f in files)
                {
                    fi = new FileInfo(f);
                    if (allPictures || (fi.LastWriteTime >= lastBackup && fi.Length <= MaxUploadImageSize))
                    {
                        try { fi.CopyTo(target + "\\" + fi.Name, true); }
                        catch { Utils.CatchException(); }
                    }
                }
            }
        }

        public static void DataAndPicturesBackup(string sourcePath)
        {
            DataBackup(sourcePath);
            PicturesBackup(sourcePath);
        }

        private static void CopyDirectory(string source, string destination)
        {
            CopyDirectory(new DirectoryInfo(source), new DirectoryInfo(destination));
        }
        
        private static void CopyDirectory(DirectoryInfo source, DirectoryInfo destination)
        {
            if (!destination.Exists) destination.Create();

            var files = source.GetFiles();
            foreach (var file in files)
            {
                file.CopyTo(Path.Combine(destination.FullName, file.Name));
            }

            var dirs = source.GetDirectories();
            foreach (var dir in dirs)
            {
                var destinationDir = Path.Combine(destination.FullName, dir.Name);
                CopyDirectory(dir, new DirectoryInfo(destinationDir));
            }
        }
    }
}