using System;

namespace BizCare.SoftHair.UpdateVersion.Library
{
    public class LogEntry
    {
        public enum LogType { Information, Error, Warning }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public LogType Type { get; set; }

        public LogEntry(string message)
        {
            Message = message;
            StackTrace = string.Empty;
            Type = LogType.Information;
        }

        public LogEntry(string message, LogType logType)
        {
            Message = message;
            StackTrace = string.Empty;
            Type = logType;
        }

        public LogEntry(string message, Exception ex)
        {
            Message = message;
            StackTrace = GetExceptionMessage(ex);
            Type = LogType.Error;
        }
        
        public LogEntry(string message, LogType logType, Exception ex)
        {
            Message = message;
            StackTrace = GetExceptionMessage(ex);
            Type = logType;
        }

        private static string GetExceptionMessage(Exception ex)
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

        public string GetHtml(bool isAlternative)
        {
            var html = "<tr style=\"background-color:{0};\">" +
                "<td><img alt=\"\" width=\"16px\" height=\"16px\" " +
                "src=\"http://smsfactorystorage.blob.core.windows.net/softhair/Admin/images/{1}.gif\" /></td>" +
                "<td>{2}</td></tr>";

            var color = isAlternative ? "White" : "#F7F6F3";
            string icon;
            switch (this.Type)
            {
                case LogType.Information:
                    icon = "ok";
                    break;
                case LogType.Error:
                    icon = "error";
                    break;
                case LogType.Warning:
                    icon = "warn";
                    break;
                default:
                    icon = string.Empty;
                    break;
            }
            html = string.Format(html, color, icon, this.Message);

            if (!string.IsNullOrEmpty(this.StackTrace))
            {
                var ex = "<tr class=\"style4\"><td colspan=\"2\">{0}</td></tr>";
                ex = string.Format(ex, this.StackTrace);
                html += ex;
            }

            return html;
        }

        public override string ToString()
        {
            return Type + " | " + Message;
        }

    }
}
