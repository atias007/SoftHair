using ClientManage.Interfaces;
using System;
using System.IO;
using System.Text;

namespace ClientManage.BL.Library
{
    public class EventLogManager
    {
        public static void AddErrorMessage(string message)
        {
            AddErrorMessage(message, null);
        }

        public static void AddErrorMessage(string message, Exception ex)
        {
            AddExceptionToLogFile(ex);
        }

        public static void AddInformationMessage(string message)
        {
            AddInformationMessage(message, null);
        }

        public static void AddInformationMessage(string message, Exception ex)
        {
            AddExceptionToLogFile(new Exception(message, ex));
        }

        public static void WriteExceptionToFile(Exception ex)
        {
            var filename = Path.Combine(Utils.StartupPath, "LastException.txt");
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
                var filename = Path.Combine(Utils.StartupPath, "ExceptionLog.txt");
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