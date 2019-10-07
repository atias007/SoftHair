using System;
using System.Collections.Generic;
using System.Text;

namespace ClientManage.Interfaces
{
    public class LogInfo
    {
        public enum LogType { Error, LogIn, LogOff, SendSMS, SendEmail, DbBackup, AutoUpdate, Information }

        public LogInfo(LogType type, string eventText, string parameters)
        {
            Type = type;
            EventText = eventText;
            Parameters = parameters;
        }

        public LogType Type { get; set; }

        public string EventText { get; set; }

        public string Parameters { get; set; }
    }
}
