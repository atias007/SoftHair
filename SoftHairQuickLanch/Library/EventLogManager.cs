using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace SoftHairQuickLanch
{
    public class EventLogManager
    {
        private static string EV_LOG = "SoftHair";

        public static void AddErrorMessage(string message, string source)
        {
            AddErrorMessage(message, source, null);
        }
        public static void AddErrorMessage(string message, string source, Exception ex)
        {
            CreateSource(source, EV_LOG);
            if (ex != null) message += "\n\n" + GetExceptionMessage(ex);
            EventLog.WriteEntry(source, message, EventLogEntryType.Error);
        }

        public static void AddInformationMessage(string message, string source)
        {
            AddInformationMessage(message, source, null);
        }
        public static void AddInformationMessage(string message, string source, Exception ex)
        {
            CreateSource(source, EV_LOG);
            if (ex != null) message += "\n\n" + GetExceptionMessage(ex);
            EventLog.WriteEntry(source, message, EventLogEntryType.Information);
        }

        private static void CreateSource(string source, string log)
        {
            if (!EventLog.SourceExists(source)) EventLog.CreateEventSource(source, log);
        }

        public static string GetExceptionMessage(Exception ex)
        {
            var result = string.Empty;
            if (ex != null)
            {
                result = "Message:\r\n\t" + ex.Message + 
                    "\r\nStack Trace:\r\n\t" + ex.StackTrace +
                    "\r\nTargetSite\r\n\t" + Convert.ToString(ex.TargetSite);
                if (ex.InnerException != null)
                {
                    result += "\r\n\r\n========== Inner Exception ==========\r\n" +
                    GetExceptionMessage(ex.InnerException) + "\r\n\r\n";
                }
            }
            return result;
        }
    }
}
