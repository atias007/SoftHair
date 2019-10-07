using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using ClientManage.BL;
using ClientManage.Interfaces;

namespace ClientManage.Library
{
    public class EventLogManager
    {
        public static void AddErrorMessage(string message)
        {
            AddErrorMessage(message, null);
        }

        public static void AddErrorMessage(string message, Exception ex)
        {
            General.AddExceptionToLogFile(ex);
        }

        public static void AddInformationMessage(string message)
        {
            AddInformationMessage(message, null);
        }

        public static void AddInformationMessage(string message, Exception ex)
        {
            General.AddExceptionToLogFile(new Exception(message, ex));
        }
    }
}