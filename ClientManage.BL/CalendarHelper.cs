using ClientManage.BL.Library;
using ClientManage.Data;
using ClientManage.Interfaces;
using GmailSoftHairSync;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ClientManage.BL
{
    public class CalendarHelper
    {
        //public static event EventHandler SyncEvents;

        //internal static void OnSyncEvents(string id)
        //{
        //    CalendarData.SetEventToBeSync(id);
        //    if (SyncEvents != null)
        //    {
        //        SyncEvents(null, EventArgs.Empty);
        //    }
        //}

        public static bool IsGoogleCalendar
        {
            get
            {
                return string.IsNullOrEmpty(AppSettingsHelper.GetParamValue("CALENDAR_SOUND_FILE")) == false;
            }
        }

        public static void InitializeGoogleService()
        {
            EventMapper.DefaultWorkerId = WorkersData.GetDefaultWorkerId();

            if (IsGoogleCalendar)
            {
                if (CalendarService.IsInitialized == false)
                {
                    GmailService.CalendarId = AppSettingsHelper.GetParamValue("CALENDAR_SOUND_FILE");
                }
            }
        }

        public static DataSet GetDayCalendarEvents(DateTime currentDate)
        {
            DataSet ds;
            if (IsGoogleCalendar)
            {
                ds = CalendarService.Instance.GetAppointments(currentDate);
            }
            else
            {
                ds = CalendarData.GetDayCalendarEvents(currentDate);
            }

            AddHebrewEventToDataSet(currentDate, ds);
            return ds;
        }

        public static DataSet GetDayCalendarEvents(DateTime currentDate, int workerId)
        {
            DataSet ds;
            if (IsGoogleCalendar)
            {
                ds = CalendarService.Instance.GetAppointmentsToWorker(currentDate, workerId);
            }
            else
            {
                ds = CalendarData.GetDayCalendarEventsByWorker(currentDate, workerId);
            }

            AddHebrewEventToDataSet(currentDate, ds);
            return ds;
        }

        private static void AddHebrewEventToDataSet(DateTime currentDate, DataSet ds)
        {
            var info = HebrewEvent.GetHebrewEventInfo(currentDate);
            if (info.IsEvent)
            {
                var row = ds.Tables[0].NewRow();
                row["id"] = -1;
                row["subject"] = info.EventTitle;
                row["date_start"] = info.Date;
                row["date_end"] = info.Date;
                row["all_day_event"] = true;
                row["remainer_min"] = -1;
                row["recurrence_id"] = -1;
                row["worker_id"] = -1;
                row["client_id"] = 0;
                row["importance"] = 0;
                ds.Tables[0].Rows.Add(row);
            }
        }

        public static DataRow GetAppointment(string id)
        {
            DataRow row;
            if (IsGoogleCalendar)
            {
                row = CalendarService.Instance.GetAppointment(id);
            }
            else
            {
                row = CalendarData.GetAppointment(id);
            }

            return row;
        }

        public static void AddAttendees(string appointmentId, string email)
        {
            CalendarService.Instance.SetAppoitmentAttendees(appointmentId, email);
            CalendarData.AddCalendarAudit(appointmentId, 15, "נקבע משתתף לתור: " + email);
        }

        public static void AddAppointment(BizCareAppointment app)
        {
            app.ClientEmail = app.ClientId > 0 ? ClientHelper.GetClientEmail(app.ClientId) : string.Empty;
            if (Validation.IsEmailValid(app.ClientEmail, false) == false) app.ClientEmail = string.Empty;

            if (IsGoogleCalendar)
            {
                CalendarService.Instance.AddApointment(app);
            }
            else
            {
                CalendarData.AddAppointment(app);
            }

            CalendarData.AddCalendarAudit(app.Id, 1, "תור חדש נוצר: " + GetAppTitle(app));
        }

        private static string GetAppTitle(BizCareAppointment app)
        {
            var client = ClientHelper.GetClient(app.ClientId);
            var clientName = client == null ? "ללא לקוח" : client.FullName;
            var caresTitle = GetCaresDescription(app.Cares);
            var workerName = WorkersHelper.GetWorker(app.WorkerId).FullName;

            var result = string.Format("StartDate: {0:dd/MM/yyyy} {0:HH:mm}, EndDate: {1:dd/MM/yyyy} {1:HH:mm}, ClientId: {2} - {11}, Attendee: {3}, ClientEmail: {4}, Text: {5}, Remark: {6}, IsAllDayEvent: {7}, RemainderMinutes: {8}, WorkerId: {9} - {12}, Cares: {10} - {13}",
                app.StartDate, app.EndDate, app.ClientId, app.Attendee, app.ClientEmail, app.Text, app.Remark, app.IsAllDayEvent, app.RemainderMinutes, app.WorkerId, app.Cares, clientName, workerName, caresTitle);

            return result;
        }

        public static void DeleteAppointment(string id, string title)
        {
            if (IsGoogleCalendar)
            {
                CalendarService.Instance.DeleteAppointment(id);
            }
            else
            {
                CalendarData.DeleteAppointment(id);
            }

            CalendarData.AddCalendarAudit(id, 2, "נמחק תור מהיומן: " + title);
        }

        public static string[] GetClientPicture(int id)
        {
            var row = CalendarData.GetClientPicture(id);

            var ret = new string[3];
            if (row != null)
            {
                ret[0] = Utils.GetDBValue<string>(row, "FirstName");
                ret[1] = Utils.GetDBValue<string>(row, "LastName");
                ret[2] = Utils.GetDBValue<string>(row, "picture");
            }

            return ret;
        }

        public static void SetClientToAppointment(string appointmentId, int clientId, DateTime startDate)
        {
            if (IsGoogleCalendar)
            {
                CalendarService.Instance.SetAppoitmentClientId(appointmentId, clientId);
            }
            else
            {
                CalendarData.SetClientToAppointment(appointmentId, clientId);
            }

            var client = ClientHelper.GetClient(clientId);
            CalendarData.AddCalendarAudit(appointmentId, 3, "שיוך לקוח לתור עודכן ל: " + clientId + " - " + client.FullName);
        }

        public static void ClearClientFromAppointment(string appointmentId)
        {
            if (IsGoogleCalendar)
            {
                CalendarService.Instance.SetAppoitmentClientId(appointmentId, 0);
            }
            else
            {
                CalendarData.SetClientToAppointment(appointmentId, 0);
            }

            CalendarData.AddCalendarAudit(appointmentId, 4, "שיוך לקוח לתור אופס");
        }

        public static DataSet GetRemainderValues()
        {
            return CalendarData.GetRemainderValues();
        }

        public static void UpdateAppointment(BizCareAppointment app)
        {
            app.ClientEmail = app.ClientId > 0 ? ClientHelper.GetClientEmail(app.ClientId) : string.Empty;
            if (Validation.IsEmailValid(app.ClientEmail, false) == false) app.ClientEmail = string.Empty;

            if (app.ResetSmsAlert)
            {
                if (IsGoogleCalendar)
                {
                    var isClear = CalendarService.Instance.ClearHasAlertBeforeUpdate(app.Id, app.StartDate);
                    if (isClear)
                    {
                        CalendarData.AddCalendarAudit(app.Id, 5, "בוצע איפוס להתראת sms לפני עדכון פרטי התור");
                    }
                }
                else
                {
                    // todo: ***
                }
            }

            if (IsGoogleCalendar)
            {
                CalendarService.Instance.UpdateAppointment(app);
            }
            else
            {
                CalendarData.UpdateAppointment(app);
            }

            CalendarData.AddCalendarAudit(app.Id, 6, "פרטי התור עודכנו: " + GetAppTitle(app));

            //OnSyncEvents(app.Id);
        }

        public static DataSet GetAppointmentHistory(string appointmentId)
        {
            return CalendarData.GetAppointmentHistory(appointmentId);
        }

        public static DataSet GetAllAppointmentHistory(bool onlyDeleted)
        {
            return CalendarData.GetAllAppointmentHistory(onlyDeleted);
        }

        //public static void ReLiveAppRemainder(string id)
        //{
        //    CalendarData.ReLiveAppRemainder(id);
        //}

        //public static DateTime GetRemaindedDate(string id)
        //{
        //    var row = CalendarData.GetRemainderFields(id);
        //    if (
        //        row == null ||
        //        DBNull.Value.Equals(row["remainder_popup_date"]) ||
        //        (int)row["remainer_min"] == -1) return DateTime.MinValue;

        //    var popup = (DateTime)row["remainder_popup_date"];
        //    if ((bool)row["remainder_dismiss"]) return popup;
        //    return (int)row["remainder_snooze_min"] == -1 ? popup : DateTime.MinValue;
        //}

        //public static string GetAgregateRemarks(int clientId)
        //{
        //    var ds = CalendarData.GetAgregateRemarks(clientId);
        //    var ret = string.Empty;
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        ret += "היסטורית הערות\r\n";
        //        ret += "\n\r­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶" + "\r\n";

        //        foreach (DataRow row in ds.Tables[0].Rows)
        //        {
        //            ret += Utils.GetDBValue<DateTime>(row["date_start"]).ToString("dd/MM/yyyy") + "\t";
        //            ret += Utils.GetDBValue<string>(row, "remark").Replace("\r\n", "\r\n\t\t") + "\r\n\r\n";
        //        }

        //        ret = ret.Trim() + "\r\n";

        //        ret += "­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶­̶̶̶" + "\r\n\r\n";
        //    }

        //    return ret;
        //}

        public static void ImportEvents(DateTime date)
        {
            var result = CalendarData.GetDayCalendarEvents(date);
            foreach (DataRow row in result.Tables[0].Rows)
            {
                var app = EventMapper.GetAppointmentFromRow(row);
                CalendarService.Instance.AddApointment(app);
                CalendarData.OldDeleteAppointment(app.Id);
            }
        }

        public static void ClearTimeZone(DateTime date)
        {
            if (IsGoogleCalendar)
            {
                CalendarService.Instance.FixTimezone(date);
            }
        }

        public static DataSet GetAllRemainderValues()
        {
            return CalendarData.GetAllRemainderValues();
        }

        public static void UpdateRemainderValues(DataSet ds)
        {
            CalendarData.UpdateRemainderValues(ds);
        }

        public static void SetAppointmentText(string text, string id)
        {
            CalendarData.AddCalendarAudit(id, 7, "כותרת התור עודכנה ל: " + text);
            if (IsGoogleCalendar)
            {
                CalendarService.Instance.SetAppoitmentText(id, text);
            }
            else
            {
                CalendarData.SetAppointmentText(text, id);
            }
            //OnSyncEvents(id);
        }

        public static void SetAppointmentWorker(int workerId, string id)
        {
            if (IsGoogleCalendar)
            {
                CalendarService.Instance.SetAppoitmentWorkerId(id, workerId);
            }
            else
            {
                CalendarData.SetAppointmentWorker(workerId, id);
            }

            var worker = WorkersHelper.GetWorker(workerId);
            CalendarData.AddCalendarAudit(id, 8, "נקבע עובד לתור: " + workerId + " - " + worker.FullName);
            //OnSyncEvents(id);
        }

        public static void UpdateAppointmentTime(DateTime start, DateTime end, string id)
        {
            if (IsGoogleCalendar)
            {
                CalendarService.Instance.SetAppoitmentTime(id, start, end);
            }
            else
            {
                CalendarData.UpdateAppointmentTime(start, end, id);
            }

            CalendarData.AddCalendarAudit(id, 9, string.Format("תאריך/שעת התור עודכנה ל: {0:dd/MM/yyyy HH:mm} עד {1:dd/MM/yyyy HH:mm}", start, end));
            //OnSyncEvents(id);
        }

        public static void UpdateAppointmentRemainder(int minutes, string id)
        {
            if (IsGoogleCalendar)
            {
                CalendarService.Instance.SetAppoitmentReminderMin(id, minutes);
            }
            else
            {
                CalendarData.UpdateAppointmentRemainder(minutes, id);
            }

            CalendarData.AddCalendarAudit(id, 10, string.Format("נקבעה תזכורת לתור: {0}", minutes));
            //OnSyncEvents(id);
        }

        public static DataSet GetCares()
        {
            return CalendarData.GetCares();
        }

        public static void UpdateCares(DataSet ds)
        {
            CalendarData.UpdateCares(ds);
        }

        public static string GetCaresDescription(string cares)
        {
            if (string.IsNullOrEmpty(cares)) return string.Empty;

            var table = LookupHelper.GetLookupTable("tblCares", "score");
            var items = cares.Split(' ');
            var desc = string.Empty;

            // ReSharper disable ForCanBeConvertedToForeach
            for (var i = 0; i < items.Length; i++)
            // ReSharper restore ForCanBeConvertedToForeach
            {
                for (var j = 0; j < table.Rows.Count; j++)
                {
                    if (items[i].Equals(table.Rows[j]["id"].ToString()))
                    {
                        desc += table.Rows[j]["description"] + ", ";
                        break;
                    }
                }
            }
            if (desc.EndsWith(", ")) desc = desc.Substring(0, desc.Length - 2);
            return desc.Trim();
        }

        /// <summary>
        /// Gets the duration of the cares.
        /// </summary>
        /// <param name="cares">The cares.</param>
        /// <returns></returns>
        public static int GetCaresDuration(string cares)
        {
            if (string.IsNullOrEmpty(cares)) return 0;

            var table = LookupHelper.GetLookupTable("tblCares", "score");
            var items = cares.Split(' ');
            var result = 0;

            foreach (var t in items)
            {
                for (var j = 0; j < table.Rows.Count; j++)
                {
                    if (t.Equals(table.Rows[j]["id"].ToString()))
                    {
                        try
                        {
                            result += (int)table.Rows[j]["duration"];
                        }
                        catch
                        {
                            result += 0;
                        }
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the color of the cares.
        /// </summary>
        /// <param name="cares">The cares.</param>
        /// <returns></returns>
        public static int GetCaresColor(string cares)
        {
            if (string.IsNullOrEmpty(cares)) return 0;

            var table = LookupHelper.GetLookupTable("tblCares", "score");
            var items = cares.Split(' ');
            var result = 0;
            var maxScore = int.MaxValue;

            foreach (var t in items)
            {
                for (var j = 0; j < table.Rows.Count; j++)
                {
                    if (t.Equals(table.Rows[j]["id"].ToString()))
                    {
                        var score = (int)table.Rows[j]["score"];
                        if (score < maxScore)
                        {
                            maxScore = score;
                            var color = (int)table.Rows[j]["display_color"];
                            if (color != 0) result = color;
                        }
                        break;
                    }
                }
            }
            return result;
        }

        public static void NormalizeScore()
        {
            var table = LookupHelper.GetLookupTable("tblCares", "score");
            var min = -1;

            for (var j = 0; j < table.Rows.Count; j++)
            {
                var cur = (int)table.Rows[j]["score"];
                if (min == -1) min = cur;
                else if (cur < min) min = cur;
            }
            if (min > 0)
            {
                for (var j = 0; j < table.Rows.Count; j++)
                {
                    if (table.Rows[j]["score"] == null || table.Rows[j]["score"].Equals(DBNull.Value)) table.Rows[j]["score"] = 0;
                    if ((int)table.Rows[j]["score"] >= min)
                    {
                        table.Rows[j]["score"] = (int)table.Rows[j]["score"] - min;
                    }
                }
            }
        }

        public static void SetCaresToAppointment(string cares, string id, DateTime startDate)
        {
            if (IsGoogleCalendar)
            {
                CalendarService.Instance.SetAppoitmentCares(id, cares);
            }
            else
            {
                CalendarData.SetCaresToAppointment(cares, id);
            }

            var desc = GetCaresDescription(cares);
            CalendarData.AddCalendarAudit(id, 11, "נקבעו טיפולים לתור: " + cares + " - " + desc);
        }

        public static DataTable GetCalendarDateReport(DateTime? from, DateTime? to, int workerId)
        {
            DataTable table;

            if (IsGoogleCalendar)
            {
                table = CalendarService.Instance.GetCalendarDateReport(from, to, workerId).Tables[0];
            }
            else
            {
                return null;
            }

            var workers = WorkersData.GetWorkersForPick().Tables[0].AsEnumerable();

            for (var i = 0; i < table.Rows.Count; i++)
            {
                table.Rows[i]["worker_name"] = workers
                    .Where(r => Convert.ToString(r["id"]) == Convert.ToString(table.Rows[i]["worker_name"]))
                    .Select(r => r["ClientName"])
                    .FirstOrDefault();
            }

            return table;
        }

        public static DataTable GetCalendarCaresReport(DateTime? from, DateTime? to, string[] cares)
        {
            var table = CalendarService.Instance.GetCalendarDateReport(from, to, 0, 1000).Tables[0];

            if (cares.Length == 0 || cares[0] == string.Empty) return table;

            var deleted = new List<DataRow>();
            foreach (DataRow r in table.Rows)
            {
                var rc = r["cares_tofill"].ToString();
                if (rc == "-")
                {
                    deleted.Add(r);
                }
                else
                {
                    var rcl = rc.Split(' ');
                    var subst = rcl.Except(cares);
                    if (subst.Count() == rcl.Count())
                    {
                        deleted.Add(r);
                    }
                }
            }

            foreach (DataRow r in deleted)
            {
                table.Rows.Remove(r);
            }

            return table;
        }

        public static DataTable GetTopClientsVisits(int clientId)
        {
            var table = CalendarService.Instance.GetClientTopVisits(clientId).Tables[0];
            var workers = WorkersData.GetWorkersForPick().Tables[0].AsEnumerable();

            for (var i = 0; i < table.Rows.Count; i++)
            {
                var dStart = Utils.GetDBValue<DateTime>(table.Rows[i]["date_start"]);
                var dEnd = Utils.GetDBValue<DateTime>(table.Rows[i]["date_end"]);
                if (dStart.Hour == 0 && dEnd.Hour == 0)
                {
                    table.Rows[i]["scope"] = "כל היום";
                }
                else
                {
                    table.Rows[i]["scope"] = dEnd.ToString("HH:mm") + " - " + dStart.ToString("HH:mm");
                }
                table.Rows[i]["cares"] = GetCaresDescription(table.Rows[i]["cares"].ToString());
                table.Rows[i]["worker_name"] = workers
                    .Where(r => Convert.ToString(r["id"]) == Convert.ToString(table.Rows[i]["worker_name"]))
                    .Select(r => r["ClientName"])
                    .FirstOrDefault();
            }

            return table;
        }

        //public static int ArchiveCalendar(string filename, string remark, DateTime? fromDate, DateTime? toDate, int option, bool excludeLast)
        //{
        //    if (toDate.HasValue) toDate = toDate.Value.Date.AddDays(1).AddMinutes(-1);
        //    var table = CalendarData.GetArchiveItems(fromDate, toDate, option, excludeLast).Tables[0];

        //    var archive = new ArchiveCalendar();
        //    var general = archive.General.NewGeneralRow();

        //    var count = table.Rows.Count;
        //    if (count == 0) return 0;
        //    general.ClientId = AppSettingsHelper.GetParamValue<int>("APP_CLIENT_ID");
        //    general.DateArchive = DateTime.Now;
        //    general.Remark = remark;
        //    general.OnlyOld = option == 0;
        //    if (fromDate.HasValue) general.FromDate = Convert.ToDateTime(fromDate);
        //    if (toDate.HasValue) general.ToDate = Convert.ToDateTime(toDate);
        //    if (excludeLast)
        //    {
        //        general.Mode = 2;
        //    }
        //    else
        //    {
        //        if (fromDate.HasValue && toDate.HasValue) general.Mode = 3;
        //        else general.Mode = 1;
        //    }
        //    archive.General.Rows.Add(general);

        //    foreach (DataRow row in table.Rows)
        //    {
        //        var calItem = archive.CalendarItems.NewCalendarItemsRow();

        //        foreach (DataColumn col in table.Columns)
        //        {
        //            if (calItem.Table.Columns.Contains(col.ColumnName))
        //            {
        //                calItem[col.ColumnName] = row[col.ColumnName];
        //            }
        //        }

        //        archive.CalendarItems.Rows.Add(calItem);
        //    }

        //    Crypt.EncryptDataset(archive).WriteXml(filename);

        //    try
        //    {
        //        CalendarData.ClearArchivedItems(fromDate, toDate, option, excludeLast);
        //    }
        //    catch
        //    {
        //        try { File.Delete(filename); }
        //        catch { Utils.CatchException(); }
        //        throw;
        //    }

        //    return count;
        //}

        //public static DataSet GetArchiveDataSet(string filename)
        //{
        //    var reader = new StreamReader(filename, Encoding.Default);
        //    var xml = reader.ReadToEnd();
        //    reader.Close();

        //    return Crypt.DecryptXMLDataset(xml);
        //}

        //public static int LoadArchiveToCalendar(string filename, ref ProcProgress proc)
        //{
        //    var count = 0;
        //    var archive = GetArchiveDataSet(filename);
        //    var db = CalendarData.GetEmptyCalendarTable();

        //    foreach (DataRow row in archive.Tables[1].Rows)
        //    {
        //        if (!CalendarData.IsAppointmentExist(Convert.ToInt32(row["id"])))
        //        {
        //            var dbRow = db.Tables[0].NewRow();
        //            foreach (DataColumn col in db.Tables[0].Columns)
        //            {
        //                if (row.Table.Columns.Contains(col.ColumnName))
        //                {
        //                    dbRow[col.ColumnName] = row[col.ColumnName];
        //                }
        //            }
        //            db.Tables[0].Rows.Add(dbRow);
        //            count++;
        //        }
        //        proc.IncreaseValue();
        //    }

        //    CalendarData.SaveCalendarTable(db);
        //    try { File.Delete(filename); }
        //    catch { Utils.CatchException(); }

        //    return count;
        //}

        //public static ArchiveCalendar.GeneralRow GetArchiveFileParameters(string filename)
        //{
        //    var reader = new StreamReader(filename, Encoding.Default);
        //    var xml = reader.ReadToEnd();
        //    reader.Close();

        //    var archive = Crypt.DecryptXMLDataset(xml);

        //    var table = new ArchiveCalendar.GeneralDataTable();
        //    var general = table.NewGeneralRow();
        //    var row = archive.Tables[0].Rows[0];

        //    general.ClientId = (int)row["ClientId"];
        //    general.DateArchive = (DateTime)row["DateArchive"];
        //    general.FromDate = (DateTime)row["FromDate"];
        //    general.Remark = (string)row["Remark"];
        //    general.ToDate = (DateTime)row["ToDate"];

        //    return general;
        //}

        private static readonly Hashtable MonthBoldedDatesCache = new Hashtable();

        public static DateTime[] GetMonthBoldedDates(int month, int year)
        {
            var key = month + "-" + year;
            DateTime[] res = null;

            if (MonthBoldedDatesCache.Contains(key))
            {
                res = (DateTime[])MonthBoldedDatesCache[key];
            }
            else
            {
                try
                {
                    var filter = new HebrewEventFilter
                    {
                        Month = month,
                        Year = year,
                    };
                    var events = HebrewEvent.GetEvents(filter);
                    var result = events.Select(e => e.Date).ToArray();
                    return result;
                }
                catch (Exception ex)
                {
                    Utils.CatchException(ex);
                }
            }
            return res;
        }

        public static void SetCategory(int category, string id)
        {
            if (IsGoogleCalendar)
            {
                CalendarService.Instance.SetAppoitmentCategotyId(id, category);
            }
            else
            {
                CalendarData.SetCategory(category, id);
            }

            CalendarData.AddCalendarAudit(id, 12, string.Format("נקבעה קטגוריה/צבע לתור: {0}", category));
            //OnSyncEvents(id);
        }

        //public static DataTable GetSyncEvents()
        //{
        //    var ds = CalendarData.GetSyncEvents();
        //    return ds.Tables[0];
        //}

        //public static void UpdateSyncEvents(IEnumerable<int> ids)
        //{
        //    if (!ids.Any()) return;

        //    var prm = string.Empty;
        //    foreach (var id in ids)
        //    {
        //        prm += id + ",";
        //    }
        //    if (prm.EndsWith(",")) prm = prm.Substring(0, prm.Length - 1);
        //    CalendarData.UpdateSyncEvents(prm);
        //}
    }
}