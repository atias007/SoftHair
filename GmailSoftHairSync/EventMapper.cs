using ClientManage.Data;
using ClientManage.Interfaces;
using Google.Apis.Calendar.v3.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailSoftHairSync
{
    public static class EventMapper
    {
        public static int DefaultWorkerId { get; set; }

        public static DataRow ConvertEvent(Event @event)
        {
            var table = GetAppointmentTable();
            var row = table.NewRow();
            MapEventRow(@event, row);
            table.Rows.Add(row);
            return row;
        }

        public static DataSet ConvertEvents(IEnumerable<Event> events)
        {
            var table = GetAppointmentTable();
            foreach (var e in events)
            {
                var row = table.NewRow();
                MapEventRow(e, row);
                table.Rows.Add(row);
            }
            var result = new DataSet();
            result.Tables.Add(table);
            return result;
        }

        public static DataSet ConvertAppointments(IEnumerable<BizCareAppointment> appointment)
        {
            var table = GetAppointmentTable();
            foreach (var e in appointment)
            {
                var row = table.NewRow();
                MapAppointmentRow(e, row);
                table.Rows.Add(row);
            }
            var result = new DataSet();
            result.Tables.Add(table);
            return result;
        }

        private static DataRow MapEventRow(Event @event, DataRow row)
        {
            var app = MapEvent(@event);
            MapAppointmentRow(app, row);
            return row;
        }

        private static void MapAppointmentRow(BizCareAppointment appointment, DataRow row)
        {
            row["id"] = appointment.Id;
            row["subject"] = appointment.Text;
            row["date_start"] = appointment.StartDate;
            row["date_end"] = appointment.EndDate;
            row["all_day_event"] = appointment.IsAllDayEvent;
            row["importance"] = appointment.Importance;
            row["remainer_min"] = appointment.RemainderMinutes;
            row["remark"] = appointment.Remark;
            row["worker_id"] = appointment.WorkerId;
            row["client_id"] = appointment.ClientId;
            row["cares"] = appointment.Cares;
            row["recurrence_id"] = appointment.RecurrenceId;
            row["has_alert"] = appointment.HasAlert;
            row["alert_key"] = appointment.AlertKey;
            row["attendee"] = appointment.Attendee;
        }

        public static BizCareAppointment GetAppointmentFromRow(DataRow row)
        {
            var appointment = new BizCareAppointment();
            appointment.Id = Utils.GetDBValue<string>(row["id"]);
            appointment.Text = Utils.GetDBValue<string>(row["subject"]);
            appointment.StartDate = Utils.GetDBValue<DateTime>(row["date_start"]);
            appointment.EndDate = Utils.GetDBValue<DateTime>(row["date_end"]);
            appointment.IsAllDayEvent = Utils.GetDBValue<bool>(row["all_day_event"]);
            appointment.Importance = (ImportanceLevel)Utils.GetDBValue<int>(row["importance"]);
            appointment.RemainderMinutes = Utils.GetDBValue<int>(row["remainer_min"]);
            appointment.Remark = Utils.GetDBValue<string>(row["remark"]);
            appointment.WorkerId = Utils.GetDBValue<int>(row["worker_id"]);
            appointment.ClientId = Utils.GetDBValue<int>(row["client_id"]);
            appointment.Cares = Utils.GetDBValue<string>(row["cares"]);
            appointment.RecurrenceId = Utils.GetDBValue<int>(row["recurrence_id"]);

            if (appointment.Text == null) appointment.Text = string.Empty;
            if (appointment.Remark == null) appointment.Remark = string.Empty;
            if (appointment.Cares == null) appointment.Cares = string.Empty;

            return appointment;
        }

        private static DataTable GetAppointmentTable()
        {
            var table = new DataTable();
            table.Columns.Add("id", typeof(string));
            table.Columns.Add("subject", typeof(string));
            table.Columns.Add("date_start", typeof(DateTime));
            table.Columns.Add("date_end", typeof(DateTime));
            table.Columns.Add("all_day_event", typeof(bool));
            table.Columns.Add("importance", typeof(int));
            table.Columns.Add("remainer_min", typeof(int));
            table.Columns.Add("remark", typeof(string));
            table.Columns.Add("worker_id", typeof(int));
            table.Columns.Add("client_id", typeof(int));
            table.Columns.Add("cares", typeof(string));
            table.Columns.Add("recurrence_id", typeof(int));
            table.Columns.Add("has_alert", typeof(bool));
            table.Columns.Add("alert_key", typeof(string));
            table.Columns.Add("attendee", typeof(string));

            return table;
        }

        internal static DataSet GetTopVisitsDataSet(List<Event> events)
        {
            var table = new DataTable();
            table.Columns.Add("id", typeof(string));
            table.Columns.Add("date_end", typeof(DateTime));
            table.Columns.Add("worker_name", typeof(string));
            table.Columns.Add("date_start", typeof(DateTime));
            table.Columns.Add("scope", typeof(string));
            table.Columns.Add("cares", typeof(string));

            foreach (var e in events)
            {
                var row = table.NewRow();
                row["id"] = e.Id;
                row["date_end"] = GetDateTime(e.End);
                row["worker_name"] = e.ExtendedProperties.Private__["WorkerId"];
                row["date_start"] = GetDateTime(e.Start);
                row["scope"] = string.Empty;
                row["cares"] = e.ExtendedProperties.Private__["Cares"];
                table.Rows.Add(row);
            }

            var ds = new DataSet();
            ds.Tables.Add(table);
            return ds;
        }

        internal static DataSet MapCalendarDateReport(List<Event> events)
        {
            var table = new DataTable();
            table.Columns.Add("id", typeof(string));
            table.Columns.Add("picture", typeof(string));
            table.Columns.Add("client_name", typeof(string));
            table.Columns.Add("client_id", typeof(string));
            table.Columns.Add("time_start", typeof(DateTime));
            table.Columns.Add("time_end", typeof(DateTime));
            table.Columns.Add("worker_name", typeof(string));
            table.Columns.Add("cares_tofill", typeof(string));
            table.Columns.Add("subject", typeof(string));
            table.Columns.Add("date_created", typeof(string));

            foreach (var e in events)
            {
                var row = table.NewRow();
                row["id"] = e.Id;
                row["picture"] = "[NO PICTURE]";
                row["worker_name"] = e.ExtendedProperties.Private__["WorkerId"];
                row["client_name"] = "[ללא שיוך לקוח]";
                row["client_id"] = e.ExtendedProperties.Private__["ClientId"];
                row["time_start"] = GetDateTime(e.Start);
                row["time_end"] = GetDateTime(e.End);
                row["cares_tofill"] = e.ExtendedProperties.Private__["Cares"];
                row["subject"] = e.Summary;
                row["date_created"] = e.Created;

                var clientId = e.ExtendedProperties.Private__["ClientId"];
                if (clientId != "0" && !string.IsNullOrEmpty(clientId))
                {
                    var client = ClientData.GetClient(int.Parse(clientId));
                    if (client != null)
                    {
                        row["client_name"] = string.Format("{0} {1}", client["first_name"], client["last_name"]).Trim();
                        row["picture"] = client["picture"];
                    }
                }

                if (Convert.ToString(row["client_name"]) == "0") row["client_name"] = "[ללא שיוך לקוח]";

                table.Rows.Add(row);
            }

            var ds = new DataSet();
            ds.Tables.Add(table);
            return ds;
        }

        internal static DataSet GetCalendarSmsDataSet(List<Event> events, bool skipValidation = false)
        {
            var table = new DataTable();
            table.Columns.Add("id", typeof(string));
            table.Columns.Add("cell_phone", typeof(string));
            table.Columns.Add("client_id", typeof(int));
            table.Columns.Add("date_start", typeof(DateTime));
            table.Columns.Add("email", typeof(string));
            table.Columns.Add("cares", typeof(string));
            table.Columns.Add("first_name", typeof(string));
            table.Columns.Add("worker_first_name", typeof(string));
            table.Columns.Add("has_alert", typeof(bool));
            table.Columns.Add("alert_key", typeof(string));

            foreach (var e in events)
            {
                if (e.Start.DateTime == null) continue;
                if (!skipValidation && e.Created == null)
                {
                    e.Created = DateTime.MinValue;
                }

                var diff = DateTime.Now.Subtract(e.Created.Value).TotalMinutes;
                if (!skipValidation && diff < 30) continue;

                var clientId = Convert.ToInt32(e.ExtendedProperties.Private__["ClientId"]);
                if (!skipValidation && clientId == 0) continue;

                var client = ClientData.GetClient(clientId);
                if (!skipValidation && client == null) continue;

                var enableSms = Utils.GetDBValue<bool>(client["enable_sms"]);
                if (!skipValidation && enableSms == false) continue;

                var smsCellPhone = Utils.GetDBValue<string>(client["cell_phone_1"]);
                if (!skipValidation && string.IsNullOrEmpty(smsCellPhone)) continue;

                var hasAlert = Convert.ToBoolean(e.ExtendedProperties.Private__["HasAlert"]);
                var alertKey =
                    e.ExtendedProperties.Private__.Keys.Contains("AlertKey") ?
                    Convert.ToString(e.ExtendedProperties.Private__["AlertKey"]) :
                    string.Empty;
                var key = e.Start.DateTime.GetValueOrDefault().ToString("ddMMyyyyHHmm");
                var predicate = (hasAlert == true) && (alertKey == key);
                if (!skipValidation && predicate) continue;

                smsCellPhone = Utils.DistilPhone(smsCellPhone);

                var row = table.NewRow();
                row["id"] = e.Id;
                row["client_id"] = clientId;
                row["date_start"] = GetDateTime(e.Start);
                row["cares"] = e.ExtendedProperties.Private__["Cares"];
                row["first_name"] = client["first_name"];
                row["cell_phone"] = smsCellPhone;
                row["email"] = client["email"];
                table.Rows.Add(row);
            }

            var ds = new DataSet();
            ds.Tables.Add(table);
            return ds;
        }

        private static void InitializeExtendedProperties(Event @event)
        {
            if (@event.ExtendedProperties == null)
            {
                @event.ExtendedProperties = new Event.ExtendedPropertiesData();
            }
            if (@event.ExtendedProperties.Private__ == null)
            {
                @event.ExtendedProperties.Private__ = new Dictionary<string, string>();
            }
        }

        // --------------------------------------------  //

        public static bool ImportEvent(Event @event)
        {
            var result = false;
            InitializeExtendedProperties(@event);
            if (@event.ExtendedProperties.Private__.Count == 0)
            {
                result = true;
                var clientId = ImportClientId(@event);
                var app = new BizCareAppointment { WorkerId = DefaultWorkerId, ClientId = clientId };
                FillEventExtendedProperties(@event, app);
            }
            return result;
        }

        public static Event MapAppoitment(BizCareAppointment appointment)
        {
            var @event = new Event();
            AppoitmentToEvent(appointment, @event);
            InitializeExtendedProperties(@event);
            FillEventExtendedProperties(@event, appointment);
            return @event;
        }

        public static void MapAppoitment(BizCareAppointment appointment, Event @event)
        {
            AppoitmentToEvent(appointment, @event);
            InitializeExtendedProperties(@event);
            FillEventExtendedProperties(@event, appointment);
        }

        private static void AppoitmentToEvent(BizCareAppointment appointment, Event @event)
        {
            @event.Id = appointment.Id;
            @event.Start = appointment.IsAllDayEvent ? GetEventDate(appointment.StartDate) : GetEventDateTime(appointment.StartDate);
            @event.End = appointment.IsAllDayEvent ? GetEventDate(appointment.EndDate) : GetEventDateTime(appointment.EndDate);
            @event.Summary = appointment.Text;
            @event.Description = appointment.Remark;
            //if (string.IsNullOrEmpty(appointment.ClientEmail) == false)
            //{
            //    @event.Attendees = new List<EventAttendee> { new EventAttendee { Email = appointment.ClientEmail } };
            //}
        }

        public static BizCareAppointment MapEvent(Event @event)
        {
            var result = new BizCareAppointment
            {
                Id = @event.Id,
                StartDate = GetDateTime(@event.Start),
                EndDate = GetDateTime(@event.End),
                Text = @event.Summary,
                Remark = @event.Description,
            };
            if (@event.Attendees != null && @event.Attendees.Count > 0)
            {
                result.Attendee = @event.Attendees[0].Email;
            }
            FillAppointment(result, @event);
            return result;
        }

        public static IEnumerable<BizCareAppointment> MapEvents(IEnumerable<Event> events)
        {
            var result = new List<BizCareAppointment>();
            foreach (var e in events)
            {
                result.Add(MapEvent(e));
            }
            return result;
        }

        public static IEnumerable<Event> MapAppoitments(IEnumerable<BizCareAppointment> appointment)
        {
            var result = new List<Event>();
            foreach (var e in appointment)
            {
                result.Add(MapAppoitment(e));
            }
            return result;
        }

        public static EventDateTime GetEventDateTime(DateTime date)
        {
            var result = new EventDateTime { DateTime = date, TimeZone = "Israel" };
            return result;
        }

        public static EventDateTime GetEventDate(DateTime date)
        {
            var result = new EventDateTime { Date = date.ToString("yyyy-MM-dd"), TimeZone = "Israel" };
            return result;
        }

        public static DateTime GetDateTime(EventDateTime date)
        {
            var result = date.DateTime == null ? DateTime.ParseExact(date.Date, "yyyy-MM-dd", CultureInfo.CurrentCulture) : date.DateTime.GetValueOrDefault();
            return result;
        }

        private static void FillAppointment(BizCareAppointment app, Event @event)
        {
            app.ClientId = Convert.ToInt32(@event.ExtendedProperties.Private__["ClientId"]);
            app.Importance = (ImportanceLevel)Enum.Parse(typeof(ImportanceLevel), @event.ExtendedProperties.Private__["Importance"]);
            app.IsAllDayEvent = Convert.ToBoolean(@event.ExtendedProperties.Private__["IsAllDayEvent"]);
            app.RecurrenceId = Convert.ToInt32(@event.ExtendedProperties.Private__["RecurrenceId"]);
            app.RemainderMinutes = GetEventRemainder(@event);
            app.Cares = @event.ExtendedProperties.Private__["Cares"];
            app.HasAlert = Convert.ToBoolean(@event.ExtendedProperties.Private__["HasAlert"]);
            app.AlertKey = SafeGetExtendedProperty(@event, "AlertKey");
            app.ResetSmsAlert = Convert.ToBoolean(@event.ExtendedProperties.Private__["ResetSmsAlert"]);
            app.WorkerId = Convert.ToInt32(@event.ExtendedProperties.Private__["WorkerId"]);

            if (app.Cares == null) app.Cares = string.Empty;
        }

        private static string SafeGetExtendedProperty(Event @event, string key)
        {
            if (@event.ExtendedProperties.Private__.ContainsKey(key))
            {
                return @event.ExtendedProperties.Private__[key];
            }
            return string.Empty;
        }

        internal static void FillEventExtendedProperties(Event @event, BizCareAppointment appointment)
        {
            @event.ExtendedProperties.Private__.Clear();
            @event.ExtendedProperties.Private__.Add("ClientId", Convert.ToString(appointment.ClientId));
            @event.ExtendedProperties.Private__.Add("Importance", Convert.ToString(appointment.Importance));
            @event.ExtendedProperties.Private__.Add("IsAllDayEvent", Convert.ToString(appointment.IsAllDayEvent));
            @event.ExtendedProperties.Private__.Add("RecurrenceId", Convert.ToString(appointment.RecurrenceId));
            @event.ExtendedProperties.Private__.Add("Cares", appointment.Cares == null ? "-" : appointment.Cares);
            @event.ExtendedProperties.Private__.Add("HasAlert", Convert.ToString(appointment.HasAlert).ToLower());
            @event.ExtendedProperties.Private__.Add("AlertKey", appointment.AlertKey);
            @event.ExtendedProperties.Private__.Add("ResetSmsAlert", Convert.ToString(appointment.ResetSmsAlert));
            @event.ExtendedProperties.Private__.Add("WorkerId", Convert.ToString(appointment.WorkerId));
            //@event.ExtendedProperties.Private__.Add("AlertKey", appointment.AlertKey);

            SetEventRemainder(@event, appointment.RemainderMinutes);
        }

        private static int ImportClientId(Event @event)
        {
            var result = 0;
            if (@event.Attendees == null) return 0;
            if (@event.Attendees.Count == 0) return 0;
            foreach (var e in @event.Attendees)
            {
                if (string.IsNullOrEmpty(e.Email)) continue;
                var clientId = ClientData.GetClientIdByEmail(e.Email);
                if (clientId > 0)
                {
                    result = clientId;
                    break;
                }
            }
            return result;
        }

        //internal static void SetAppointmentRemainder(BizCareAppointment appointment, Event @event)
        //{
        //}

        internal static void SetEventRemainder(Event @event, int minutes)
        {
            if (@event.Reminders == null)
            {
                @event.Reminders = new Event.RemindersData { UseDefault = false };
            }
            if (@event.Reminders.Overrides == null)
            {
                @event.Reminders.Overrides = new List<EventReminder>();
            }
            if (minutes == -1)
            {
                @event.Reminders.Overrides.Clear();
                return;
            }
            var current = @event.Reminders.Overrides.FirstOrDefault(r => r.Method == "popup");
            if (current == null)
            {
                current = new EventReminder { Method = "popup" };
                @event.Reminders.Overrides.Add(current);
            }
            current.Minutes = minutes;
            @event.Reminders.UseDefault = false;
        }

        internal static int GetEventRemainder(Event @event)
        {
            if (@event.Reminders == null) return -1;
            if (@event.Reminders.Overrides == null) return -1;
            var current = @event.Reminders.Overrides.FirstOrDefault(r => r.Method == "popup");
            if (current == null) return -1;
            var result = current.Minutes.HasValue ? current.Minutes.GetValueOrDefault() : -1;
            return result;
        }
    }
}