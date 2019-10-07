using ClientManage.BL.Library;
using ClientManage.Data;
using ClientManage.Interfaces;
using GmailSoftHairSync;
using System;
using System.Data;

namespace ClientManage.BL
{
    public class SmsHelper
    {
        public static DataTable GetSmsMessages()
        {
            return SmsData.GetSMSMessages();
        }

        public static void DeleteSmsMessage(int id)
        {
            SmsData.DeleteSMSMessage(id);
        }

        public static void AddSmsMessage(string title, string msg)
        {
            SmsData.AddSMSMessage(title, msg);
        }

        public static bool IsSmsTitleExist(string title)
        {
            return SmsData.IsSMSTitleExist(title) > 0;
        }

        public static void UpdateSmsMessage(string title, string msg)
        {
            SmsData.UpdateSMSMessage(title, msg);
        }

        //public static void SaveLog(SMSLog log)
        //{
        //    bool ok = true;
        //    if (log.MessageType == SMSLog.SMSMessageType.AutoCalendarRemaind)
        //    {
        //        ok = (SmsData.CheckCalendarFailSMS(log.PhoneNo) == 0);
        //    }

        //    if(ok) SmsData.SaveLog(log);
        //}

        public static string GetSavedMessage(int id)
        {
            return SmsData.GetSavedMessage(id).Trim();
        }

        public static DataTable GetCalendarSms(AutoCalSmsParams param)
        {
            var fromDate = DateTime.Now.AddMinutes(param.UpMin);
            var toDate = DateTime.Now.Date.AddDays(param.DaysBefore + 1).AddSeconds(-1);
            if (toDate.DayOfWeek == DayOfWeek.Saturday) toDate = toDate.AddDays(1);

            var table = CalendarService.Instance.GetCalendarSms(fromDate, toDate).Tables[0];
            return table;
        }

        public static DataTable GetCalendarSms(string appointmentId)
        {
            return CalendarService.Instance.GetCalendarSms(appointmentId).Tables[0];
        }

        public static void UpdateCalendarAlert(string id)
        {
            CalendarService.Instance.SetAppoitmentHasAlert(id, true);
            CalendarData.AddCalendarAudit(id, 13, "בוצע איפוס לתזכורת SMS של התור");
            //CalendarHelper.OnSyncEvents(id);
        }

        public static bool IsNowValidForAutoSms()
        {
            var ok = false;

            if (DateTime.Now.DayOfWeek != DayOfWeek.Saturday)
            {
                var startTime = AppSettingsHelper.GetParamValue("CALENDAR_START_TIME");
                var endTime = AppSettingsHelper.GetParamValue("CALENDAR_END_TIME");

                var dStart = DateTime.Parse(startTime);
                var dEnd = DateTime.Parse(endTime);

                ok = (DateTime.Now >= dStart && DateTime.Now <= dEnd);
            }

            return ok;
        }

        public static DataTable GetCalSmsTime()
        {
            var table = new DataTable();
            table.Columns.Add("value", typeof(int));
            table.Columns.Add("title", typeof(string));

            table.Rows.Add(15, "15 דקות");
            table.Rows.Add(30, "30 דקות");
            table.Rows.Add(45, "45 דקות");
            table.Rows.Add(60, "שעה");
            table.Rows.Add(90, "שעה וחצי");
            table.Rows.Add(120, "שעתיים");
            table.Rows.Add(150, "שעתיים וחצי");

            table.Rows.Add(180, "שלוש שעות");
            table.Rows.Add(210, "3 שעות וחצי");
            table.Rows.Add(240, "4 שעות");
            table.Rows.Add(270, "4 שעות וחצי");
            table.Rows.Add(300, "5 שעות");

            return table;
        }

        public static string SetSpecialParamaters(string msg, DataRow row)
        {
            string desc;

            if (msg.IndexOf("<DAY>") >= 0)
            {
                var date = Utils.GetDBValue<DateTime>(row, "date_start").Date;
                var now = DateTime.Now.Date;
                var span = date.Subtract(now);

                if (span.TotalDays == 0) desc = "היום";
                else if (span.Days == 1) desc = "מחר";
                else desc = date.ToString("ב-dd/MM");

                msg = msg.Replace("<DAY>", desc);
            }

            if (msg.IndexOf("<CARES>") >= 0)
            {
                desc = CalendarHelper.GetCaresDescription(Utils.GetDBValue<string>(row, "cares"));
                msg = msg.Replace("<CARES>", desc);
            }

            return msg;
        }
    }
}