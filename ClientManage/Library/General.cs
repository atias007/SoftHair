using ClientManage.BL;
using ClientManage.Forms;
using ClientManage.Interfaces;
using ClientManage.SmsFactoryCommon;
using LukeSw.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace ClientManage.Library
{
    public class General
    {
        public const string UpdateUrl = "http://smsfactorystorage.blob.core.windows.net/softhair/Admin/update.exe";

        private static VDialog _dialog;
        private static Exception _laseException;
        private static frmBackup _fBackup;

        public static double ScreenResolutionFactorWidth { get; set; }

        //public static double ScreenResolutionFactorHeight { get; set; }
        public static KeyPressPattern ClientCardPattern { get; set; }

        public static KeyPressPattern WorkerCardPattern { get; set; }

        private static string _startupPath;

        public static string StartupPath
        {
            get { return _startupPath; }
            set
            {
                _startupPath = value;
                CreateFolder("AlbumImages");
                CreateFolder("ClientImages");
                CreateFolder("Backup");
                CreateFolder("Media");
                CreateFolder("Backup\\Upload");
            }
        }

        public static string GetUpdateLocalFilename()
        {
            var path = Path.Combine(StartupPath, "Media");
            CreateFolder(path);
            var filename = string.Format("Update_{0}.exe", DateTime.Now.Ticks);
            var localFilename = Path.Combine(path, filename);
            return localFilename;
        }

        public static void CreateFolder(string folder, bool throwException = false)
        {
            var source = Path.Combine(_startupPath, folder);
            if (!Directory.Exists(source))
            {
                try { Directory.CreateDirectory(source); }
                catch (Exception)
                {
                    if (throwException) throw;
                }
            }
        }

        public enum EntityType { Client, Contact, Worker };

        public static DataTable GetSmsEntity(int id, EntityType entity)
        {
            DataTable table = null;
            const string msg1 = "����� SMS...";
            string msg2;
            MyMessageBox myMessageBox;

            switch (entity)
            {
                case EntityType.Client:

                    #region Client Section

                    var c = ClientHelper.GetClient(id);
                    if (c == null) table = ReportHelper.GetClientsCellPhones(id.ToString());
                    else
                    {
                        if (c.CellPhone1.Length == 0)
                        {
                            msg2 = "����� " + c.FullName + " ��� ���� ����� ������";
                            myMessageBox = new MyMessageBox(msg2, msg1, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                            myMessageBox.Show();
                            table = ReportHelper.GetClientsCellPhones("-1");
                        }
                        else
                        {
                            if (!c.EnableSMS)
                            {
                                msg2 = "����� " + c.FullName + " ���� ������ SMS\n��� ��� ��� ����� ����� SMS �����?";
                                myMessageBox = new MyMessageBox(msg2, msg1, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
                                var res = myMessageBox.Show();
                                if (res == DialogResult.Yes)
                                {
                                    table = c.GetSMSTable();
                                }
                            }
                            else
                            {
                                table = ReportHelper.GetClientsCellPhones(id.ToString());
                            }
                        }
                    }

                    #endregion Client Section

                    break;

                case EntityType.Contact:

                    #region Contact Section

                    var t = PhoneBookHelper.GetContact(id);
                    if (t != null && t.PhoneNo1.Length == 0)
                    {
                        msg2 = "���� ���� " + t.FullName + " ��� ���� ����� ������";
                        myMessageBox = new MyMessageBox(msg2, msg1, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                        myMessageBox.Show();
                        table = ReportHelper.GetContactsCellPhones("-1");
                    }
                    else
                    {
                        table = ReportHelper.GetContactsCellPhones(id.ToString());
                    }

                    #endregion Contact Section

                    break;

                case EntityType.Worker:

                    #region Worker Section

                    var w = WorkersHelper.GetWorker(id);
                    if (w != null && w.CellPhone1.Length == 0)
                    {
                        msg2 = "����� " + w.FullName + " ��� ���� ����� ������";
                        myMessageBox = new MyMessageBox(msg2, msg1, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                        myMessageBox.Show();
                        table = ReportHelper.GetWorkersCellPhones("-1");
                    }
                    else
                    {
                        table = ReportHelper.GetWorkersCellPhones(id.ToString());
                    }

                    #endregion Worker Section

                    break;

                default:
                    break;
            }

            return table;
        }

        public static DataTable GetEmailEntity(int id, EntityType entity)
        {
            DataTable table = null;
            const string msg1 = "����� ���\"�...";
            string msg2;
            MyMessageBox myMessageBox;

            switch (entity)
            {
                case EntityType.Client:

                    #region Client Section

                    var c = ClientHelper.GetClient(id);
                    if (c == null) table = ReportHelper.GetClientsEmails(id.ToString());
                    else
                    {
                        if (c.Email.Length == 0)
                        {
                            msg2 = "����� " + c.FullName + " ��� ����� ���\"�";
                            myMessageBox = new MyMessageBox(msg2, msg1, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                            myMessageBox.Show();
                            table = ReportHelper.GetClientsEmails("-1");
                        }
                        else
                        {
                            if (!c.EnableEmail)
                            {
                                msg2 = "����� " + c.FullName + " ���� ������ ���\"�\n��� ��� ��� ����� ����� ���\"� �����?";
                                myMessageBox = new MyMessageBox(msg2, msg1, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
                                var res = myMessageBox.Show();
                                if (res == DialogResult.Yes)
                                {
                                    table = c.GetEmailTable();
                                }
                            }
                            else
                            {
                                table = ReportHelper.GetClientsEmails(id.ToString());
                            }
                        }
                    }

                    #endregion Client Section

                    break;

                case EntityType.Contact:

                    #region Contact Section

                    var t = PhoneBookHelper.GetContact(id);
                    if (t != null && t.Email.Length == 0)
                    {
                        msg2 = "���� ���� " + t.FullName + " ��� ����� ���\"�";
                        myMessageBox = new MyMessageBox(msg2, msg1, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                        myMessageBox.Show();
                        table = ReportHelper.GetContactsEmails("-1");
                    }
                    else
                    {
                        table = ReportHelper.GetContactsEmails(id.ToString());
                    }

                    #endregion Contact Section

                    break;

                case EntityType.Worker:

                    #region Worker Section

                    var w = WorkersHelper.GetWorker(id);
                    if (w != null && w.Email.Length == 0)
                    {
                        msg2 = "����� " + w.FullName + " ��� ����� ���\"�";
                        myMessageBox = new MyMessageBox(msg2, msg1, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                        myMessageBox.Show();
                        table = ReportHelper.GetWorkersEmails("-1");
                    }
                    else
                    {
                        table = ReportHelper.GetWorkersEmails(id.ToString());
                    }

                    #endregion Worker Section

                    break;

                default:
                    break;
            }

            return table;
        }

        public static DataTable GetStickerEntity(int id, EntityType entity)
        {
            DataTable table = null;
            const string msg1 = "����� ������...";
            string msg2;
            MyMessageBox myMessageBox;

            switch (entity)
            {
                case EntityType.Client:

                    #region Client Section

                    var c = ClientHelper.GetClient(id);
                    if (c == null) table = ReportHelper.GetClientsAddresses(id.ToString());
                    else
                    {
                        if (c.Address.Length + c.City.Length == 0)
                        {
                            msg2 = "����� " + c.FullName + " ��� ����� ������";
                            myMessageBox = new MyMessageBox(msg2, msg1, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                            myMessageBox.Show();
                            table = ReportHelper.GetClientsAddresses("-1");
                        }
                        else
                        {
                            table = ReportHelper.GetClientsAddresses(id.ToString());
                        }
                    }

                    #endregion Client Section

                    break;

                case EntityType.Contact:

                    #region Contact Section

                    var t = PhoneBookHelper.GetContact(id);
                    if (t != null && t.Street.Length + t.City.Length == 0)
                    {
                        msg2 = "���� ���� " + t.FullName + " ��� ����� ������";
                        myMessageBox = new MyMessageBox(msg2, msg1, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                        myMessageBox.Show();
                        table = ReportHelper.GetContactAddresses("-1");
                    }
                    else
                    {
                        table = ReportHelper.GetContactAddresses(id.ToString());
                    }

                    #endregion Contact Section

                    break;

                case EntityType.Worker:

                    #region Worker Section

                    var w = WorkersHelper.GetWorker(id);
                    if (w != null && w.Address.Length + w.City.Length == 0)
                    {
                        msg2 = "����� " + w.FullName + " ��� ����� ������";
                        myMessageBox = new MyMessageBox(msg2, msg1, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                        myMessageBox.Show();
                        table = ReportHelper.GetWorkerAddresses("-1");
                    }
                    else
                    {
                        table = ReportHelper.GetWorkerAddresses(id.ToString());
                    }

                    #endregion Worker Section

                    break;

                default:
                    break;
            }

            return table;
        }

        public static VDialogResult ShowErrorMessageDialog(IWin32Window owner, string title, string process, string msg, Exception ex, string logCategory)
        {
            return ShowErrorMessageDialog(owner, title, process, msg, ex, logCategory, false);
        }

        public static void ShowCommunicationError(Exception ex, IWin32Window owner, bool showDialog = true)
        {
            try
            {
                AddExceptionToLogFile(ex);
            }
            catch { Utils.CatchException(); }

            if (showDialog)
            {
                ShowErrorMessageDialog(owner, "����� ������", "����� ���� ���� ������", "���� �� ��� ����� ���� �������� ���� ��� �� ������", ex, "Gmail");
            }
            try
            {
                File.AppendAllText("c:\\softhair\\CalendarLog.log", string.Format("------------------------\r\n{0:dd/MM/yyyy HH:mm}\r\n------------------------\r\n{1}", DateTime.Now, ex));
            }
            catch
            {
                Utils.CatchException();
            }
        }

        public static VDialogResult ShowErrorMessageDialog(IWin32Window owner, string title, string process, string msg, Exception ex, string logCategory, bool withRetry)
        {
            if (ex == null) ex = new Exception("No exception was provided");
            _laseException = ex;

            if (owner != null)
            {
                try { ((Form)owner).Cursor = Cursors.Default; }
                catch { Utils.CatchException(); }
            }

            try
            {
                var prm = msg + "\n\n" + Utils.GetExceptionMessage(ex);
                EventLogHelper.AddEvent(new LogInfo(LogInfo.LogType.Error, logCategory, prm));
            }
            catch { Utils.CatchException(); }

            try
            {
                AddExceptionToLogFile(ex);
            }
            catch { Utils.CatchException(); }

            //EventLogManager.AddErrorMessage(msg, logCategory, ex);
            //WebServices.CommonWS.ReportErrorAsync(GetSecuritySchema(), ex.Message, ex.StackTrace, Convert.ToString(ex.TargetSite));

            _dialog = new VDialog();
            _dialog.LinkClicked += DialogLinkClicked;
            _dialog.Owner = owner;
            _dialog.Buttons =
                withRetry ?
                new[] { new VDialogButton(VDialogResult.OK), new VDialogButton(VDialogResult.Retry) } :
                new[] { new VDialogButton(VDialogResult.OK) };

            _dialog.WindowTitle = title;
            _dialog.MainInstruction = "���� ����� ������ " + process;
            _dialog.MainIcon = VDialogIcon.Error;
            _dialog.Content = msg + "\n\n��� ��� ���� ����� �� ����� ����.\n�� ������ ����� ��� �� ����� �������.";
            _dialog.FooterIcon = VDialogIcon.Information;
            _dialog.FooterText = "����� ��� ��� ���";
            _dialog.FooterLinks.Add(_dialog.FooterText.IndexOf("��� ���"), 7);
            _dialog.FooterLinks[0].Name = "ContactUs";

            _dialog.ExpandedInformation = ex.Message + "\n����";
            _dialog.ExpandedInformationLinks.Add(_dialog.ExpandedInformation.IndexOf("����"), 4);
            _dialog.ExpandedInformationLinks[0].Name = "Copy";
            _dialog.CollapsedControlText = "��� ���� �����";
            _dialog.ExpandedControlText = "���� ���� �����";
            _dialog.ExpandFooterArea = false;
            _dialog.ExpandedByDefault = false;

            _dialog.RightToLeft = RightToLeft.Yes;
            _dialog.RightToLeftLayout = true;
            return _dialog.Show();
        }

        private static void DialogLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            switch (e.Link.Name)
            {
                case "Copy":
                    try
                    {
                        var filename = Path.Combine(StartupPath, "LastException.txt");
                        var message = Utils.GetExceptionMessage(_laseException);
                        using (var writer = new StreamWriter(filename, false, Encoding.Default))
                        {
                            writer.Write(message);
                            writer.Close();
                        }
                        Process.Start(filename);
                    }
                    catch { Utils.CatchException(); }
                    break;

                case "ContactUs":
                    break;

                default:
                    break;
            }
        }

        public static List<PostAddressee> TableToPostAddresseeList(DataTable table)
        {
            if (table == null) return null;

            var list = new List<PostAddressee>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(new PostAddressee(row));
            }
            return list;
        }

        public static string GetResource(string filename)
        {
            var asm = Assembly.GetExecutingAssembly();
            var val = string.Empty;

            // resources are named using a fully qualified name
            using (var stream = asm.GetManifestResourceStream(filename))
            {
                if (stream != null)
                {
                    // read the contents of the embedded file
                    var reader = new StreamReader(stream, Encoding.Default);
                    val = reader.ReadToEnd();
                    reader.Close();
                }
            }

            return val;
        }

        public static string ConnectionString { get; set; }

        public static void SetGridColumnsWidthByResolutionFactor(DataGridView grid)
        {
            foreach (DataGridViewColumn column in grid.Columns)
            {
                if (!(column.GetType() == typeof(DataGridViewImageColumn)))
                {
                    column.Width = Convert.ToInt32(column.Width * ScreenResolutionFactorWidth);
                }
            }
        }

        public static bool OnlineBackup(Form parent)
        {
            var path = Path.Combine(StartupPath, "Backup\\Upload");
            var files = Directory.GetFiles(path, "*.*");
            var clientId = AppSettingsHelper.GetParamValue("APP_CLIENT_ID");
            //var storage = new BlobStorage("smsfactorystorage", "KWPzj0m/1JR6gr8Hk21P4pk0I7JxBMbTm1H8b5WfIltIMzBnhCnA4LoUb05WLENKhd9f0ns/Q0plxzSEaRdgJA==");
            //storage.UploadAction += handler;
            //storage.ThrowExceptions = false;

            foreach (var file in files)
            {
                var fi = new FileInfo(file);
                var name = clientId + "\\" + fi.Name;
            }

            foreach (var f in files)
            {
                try
                {
                    File.Delete(f);
                }
                catch (Exception ex)
                {
                    //** ignore error ***//
                    Utils.CatchException(ex);
                }
            }

            if (parent != null)
            {
                if (parent.InvokeRequired)
                {
                    var h = new ShowBackupFormHandler(ShowBackupForm);
                    parent.Invoke(h, parent);
                }
                else
                {
                    ShowBackupForm(parent);
                }
            }

            return true;
        }

        private delegate void ShowBackupFormHandler(Form parent);

        private static void ShowBackupForm(Form parent)
        {
            if (!(_fBackup == null || _fBackup.IsDisposed))
            {
                _fBackup.Close();
            }
            _fBackup = new frmBackup();
            _fBackup.Show(parent);
        }

        public static void WriteExceptionToFile(Exception ex)
        {
            var filename = Path.Combine(StartupPath, "LastException.txt");
            var message = Utils.GetExceptionMessage(ex);
            using (var writer = new StreamWriter(filename, false, Encoding.Default))
            {
                writer.Write(message);
                writer.Close();
            }
        }

        public static void AddExceptionToLogFile(Exception ex)
        {
            if (ex == null) return;

            try
            {
                var filename = Path.Combine(StartupPath, "ExceptionLog.txt");
                var message = Utils.GetExceptionMessage(ex);
                using (var writer = new StreamWriter(filename, false, Encoding.Default))
                {
                    writer.Write(message);
                    writer.Close();
                }
            }
            catch { Utils.CatchException(); }
        }
    }
}