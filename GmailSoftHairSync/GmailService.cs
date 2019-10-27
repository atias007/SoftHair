using ClientManage.Interfaces;
using ClientManage.Interfaces.Calendar;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;

namespace GmailSoftHairSync
{
    public class GmailService
    {
        public event EventHandler<ClientNameRequestEventArgs> GetClientName;

        public event EventHandler<CaresDescriptionRequestEventArgs> GetCaresDescription;

        //mp0tbncc2mu6mtp9fgis13pjbk@group.calendar.google.com
        // Eti David - 84tkn3jop9qoghk0qc5t7aba4o@group.calendar.google.com

        private static string _calendarId { get; set; }

        public static string CalendarId
        {
            get
            {
                return _calendarId;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.EndsWith(".wav"))
                {
                    _calendarId = "primary";
                }
                else
                {
                    _calendarId = value;
                }

#if DEBUG
                _calendarId = "tsahiatias@gmail.com";
                _calendarId = "suruhqkoimncoabqpmnq7n86ag@group.calendar.google.com";
#endif
            }
        }

        private string OnGetClientName(int clientId)
        {
            var result = string.Empty;
            if (GetClientName != null)
            {
                var args = new ClientNameRequestEventArgs { ClientId = clientId };
                GetClientName(this, args);
                result = args.ClientName;
            }
            return result;
        }

        private string OnGetCaresDescription(string cares)
        {
            var result = string.Empty;
            if (GetCaresDescription != null)
            {
                var args = new CaresDescriptionRequestEventArgs { Cares = cares };
                GetCaresDescription(this, args);
                result = args.CaresDescription;
            }
            return result;
        }

        private string GetLocation(int clientId, string cares)
        {
            var clientName = OnGetClientName(clientId);
            var caresDescription = OnGetCaresDescription(cares);

            if (string.IsNullOrEmpty(clientName)) clientName = "ללא שם";
            if (string.IsNullOrEmpty(caresDescription)) caresDescription = "ללא טיפול";

            var result = string.Format("{0} - {1}", clientName, caresDescription);
            return result;
        }

        public DataRow GetAppointment(string id)
        {
            var ev = GetGmailEvent(id);
            var row = EventMapper.ConvertEvent(ev);
            return row;
        }

        public DataSet GetAppointments(DateTime date)
        {
            var filter = new CalendarFilter
            {
                FromDate = date.Date,
                ToDate = date.Date.AddDays(1),
            };
            var list = GetGmailEvents(filter);
            var ds = EventMapper.ConvertEvents(list);
            return ds;
        }

        public DataSet GetClientTopVisits(int clientId)
        {
            List<Event> list;
            if (clientId >= 0)
            {
                var filter = new CalendarFilter
                {
                    MaxResults = 50,
                    FromDate = DateTime.Now.AddMonths(-18),
                };
                filter.ExtendedProperties.Add("ClientId=" + clientId.ToString());
                list = GetGmailEvents(filter);
                list = list.OrderByDescending(e => e.Start.DateTime).ToList();
            }
            else
            {
                list = new List<Event>();
            }

            var ds = EventMapper.GetTopVisitsDataSet(list);
            return ds;
        }

        public DataSet GetCalendarDateReport(DateTime? from, DateTime? to, int workerId, int maxResults = 250)
        {
            var filter = new CalendarFilter
            {
                MaxResults = maxResults,
                FromDate = from,
                ToDate = to,
            };
            if (workerId > 0)
            {
                filter.ExtendedProperties.Add("WorkerId=" + workerId);
            }
            if (filter.ToDate.HasValue)
            {
                filter.ToDate = filter.ToDate.Value.AddDays(1).AddMilliseconds(-1);
            }
            var list = GetGmailEvents(filter);
            list = list.OrderBy(e => e.Start.DateTime).ToList();
            var ds = EventMapper.MapCalendarDateReport(list);
            return ds;
        }

        public DataSet GetCalendarSms(DateTime fromDate, DateTime toDate)
        {
            var filter = new CalendarFilter
            {
                FromDate = fromDate,
                ToDate = toDate,
            };
            //filter.ExtendedProperties.Add("HasAlert=false");
            var list = GetGmailEvents(filter);
            var ds = EventMapper.GetCalendarSmsDataSet(list);
            return ds;
        }

        public DataSet GetCalendarSms(string appointmentId)
        {
            var ev = GetGmailEvent(appointmentId);
            var list = new List<Event> { ev };
            var ds = EventMapper.GetCalendarSmsDataSet(list, true);
            return ds;
        }

        public bool ClearHasAlertBeforeUpdate(string appointmentId, DateTime startDate)
        {
            var ev = GetGmailEvent(appointmentId);
            var hasAlert = Convert.ToBoolean(ev.ExtendedProperties.Private__["HasAlert"]);
            if (hasAlert == false) return false;
            if (ev.Start.DateTime == null) return false;
            var diff = startDate.Subtract(ev.Start.DateTime.Value).TotalMinutes;
            if (diff == 0) return false;
            ev.ExtendedProperties.Private__["HasAlert"] = "false";
            ev.ExtendedProperties.Private__["AlertKey"] = string.Empty;
            UpdateEvent(ev);
            return true;
        }

        public void SetAppoitmentText(string id, string text)
        {
            var ev = GetGmailEvent(id);
            ev.Summary = text;
            UpdateEvent(ev);
        }

        public void SetAppoitmentTime(string id, DateTime start, DateTime end)
        {
            var ev = GetGmailEvent(id);
            ev.Start = EventMapper.GetEventDateTime(start);
            ev.End = EventMapper.GetEventDateTime(end);
            ev.ExtendedProperties.Private__["HasAlert"] = "false";
            ev.ExtendedProperties.Private__["AlertKey"] = string.Empty;
            UpdateEvent(ev);
        }

        public void SetAppoitmentClientId(string id, int clientId)
        {
            var ev = GetGmailEvent(id);
            var location = GetLocation(clientId, ev.ExtendedProperties.Private__["Cares"]);
            ev.Location = location;
            ClearAttendees(ev);

            var current = ev.ExtendedProperties.Private__["ClientId"];

            if (current != clientId.ToString())
            {
                ev.ExtendedProperties.Private__["ClientId"] = clientId.ToString();
                ev.ExtendedProperties.Private__["HasAlert"] = "false";
                ev.ExtendedProperties.Private__["AlertKey"] = string.Empty;
                UpdateEvent(ev);
            }
        }

        private void ClearAttendees(Event @event)
        {
            if (@event.Attendees != null)
            {
                @event.Attendees.Clear();
            }
        }

        public void SetAppoitmentCares(string id, string cares)
        {
            var ev = GetGmailEvent(id);
            var clientId = Convert.ToInt32(ev.ExtendedProperties.Private__["ClientId"]);
            var location = GetLocation(clientId, cares);
            ev.Location = location;
            var current = ev.ExtendedProperties.Private__["Cares"];
            if (current != cares)
            {
                ev.ExtendedProperties.Private__["Cares"] = cares;
                UpdateEvent(ev);
            }
        }

        public void SetAppoitmentAttendees(string id, string email)
        {
            var ev = GetGmailEvent(id);
            if (ev.Attendees != null && ev.Attendees.Count > 0)
            {
                ev.Attendees.Clear();
            }
            if (ev.Attendees == null) ev.Attendees = new List<EventAttendee>();
            ev.Attendees.Add(new EventAttendee { Email = email });
            UpdateEvent(ev);
        }

        public void SetAppoitmentWorkerId(string id, int workerId)
        {
            var ev = GetGmailEvent(id);
            ev.ExtendedProperties.Private__["WorkerId"] = workerId.ToString();
            UpdateEvent(ev);
        }

        public void SetAppoitmentCategotyId(string id, int categoryId)
        {
            var ev = GetGmailEvent(id);
            ev.ExtendedProperties.Private__["RecurrenceId"] = categoryId.ToString();
            UpdateEvent(ev);
        }

        public void SetAppoitmentReminderMin(string id, int minutes)
        {
            var ev = GetGmailEvent(id);
            EventMapper.SetEventRemainder(ev, minutes);
            UpdateEvent(ev);
        }

        public void SetAppoitmentHasAlert(string id, bool hasAlert)
        {
            var ev = GetGmailEvent(id);
            ev.ExtendedProperties.Private__["HasAlert"] = hasAlert.ToString().ToLower();
            if (hasAlert)
            {
                ev.ExtendedProperties.Private__["AlertKey"] = ev.Start.DateTime.GetValueOrDefault().ToString("ddMMyyyyHHmm");
            }
            else
            {
                ev.ExtendedProperties.Private__["AlertKey"] = string.Empty;
            }
            UpdateEvent(ev);
        }

        public DataSet GetAppointmentsToWorker(DateTime day, int workerId)
        {
            var events = GetGmailEvents(new CalendarFilter { FromDate = day.Date, ToDate = day.Date.AddDays(1).AddMilliseconds(-1) });
            var apps = EventMapper.MapEvents(events);
            var workerApps = apps.Where(a => a.WorkerId == workerId);
            var result = EventMapper.MapAppoitments(workerApps);
            var ds = EventMapper.ConvertEvents(result);
            return ds;
        }

        public void UpdateAppointment(BizCareAppointment appointment)
        {
            var ev = GetGmailEvent(appointment.Id);
            EventMapper.MapAppoitment(appointment, ev);

            var clientId = Convert.ToInt32(ev.ExtendedProperties.Private__["ClientId"]);
            var cares = ev.ExtendedProperties.Private__["Cares"];
            var location = GetLocation(clientId, cares);
            ev.Location = location;
            UpdateEvent(ev);
        }

        public void AddApointment(BizCareAppointment appointment)
        {
            var ev = EventMapper.MapAppoitment(appointment);
            //if (string.IsNullOrEmpty(ev.Summary) && string.IsNullOrEmpty(ev.Location)) ev.Summary = "[ללא תיאור]";
            var location = GetLocation(appointment.ClientId, appointment.Cares);
            ev.Location = location;

            var result = InsertEvent(ev);
            appointment.Id = result.Id;
        }

        public void DeleteAppointment(string id)
        {
            DeleteEvent(id);
        }

        public void ClearTimeZone(string eventId)
        {
            var ev = GetGmailEvent(eventId);
            ev.Start.TimeZone = null;
            ev.End.TimeZone = null;
            UpdateEvent(ev);
        }

        public void FixTimezone(DateTime date)
        {
            var filter = new CalendarFilter
            {
                FromDate = date.Date,
                ToDate = date.Date.AddDays(1),
            };
            var list = GetGmailEvents(filter);
            foreach (var item in list)
            {
                item.Start = EventMapper.GetEventDateTime(item.Start.DateTime.Value.AddHours(-1));
                item.End = EventMapper.GetEventDateTime(item.End.DateTime.Value.AddHours(-1));
                UpdateEvent(item);
            }
        }

        // --------------------------------------------------------------------------------  //

        private static string[] Scopes = { CalendarService.Scope.Calendar };
        private static string ApplicationName = "Google Calendar API Quickstart";

        private CalendarService GetService()
        {
            UserCredential credential;

            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, Scopes,
                  "user", CancellationToken.None, new FileDataStore(credPath, true)).Result;
            }

            // Create Calendar Service.
            var service = new Google.Apis.Calendar.v3.CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            return service;
        }

        private static object _locker = new object();
        private CalendarService _service;

        private CalendarService Service
        {
            get
            {
                lock (_locker)
                {
                    if (_service == null)
                    {
                        _service = GetService();
                    }
                    return _service;
                }
            }
        }

        public void RecycleService()
        {
            lock (_locker)
            {
                _service = null;
            }
        }

        private static object InvokeLocker = new object();

        private TResult InvokeWithRetry<TResult, TInput>(Func<TResult> func)
        {
            lock (InvokeLocker)
            {
                try
                {
                    var result = func.Invoke();
                    return result;
                }
                catch
                {
                    RecycleService();
                    Thread.Sleep(100);
                }

                try
                {
                    var result = func.Invoke();
                    return result;
                }
                catch
                {
                    RecycleService();
                    Thread.Sleep(500);
                }

                var result2 = func.Invoke();
                return result2;
            }
        }

        private Event GetGmailEvent(string eventId)
        {
            var request = Service.Events.Get(CalendarId, eventId);
            var result = InvokeWithRetry<Event, EventsResource.GetRequest>(() => { return request.Execute(); });
            if (EventMapper.ImportEvent(result))
            {
                UpdateEventAsync(result);
            }
            return result;
        }

        private List<Event> GetGmailEvents(CalendarFilter filter)
        {
            var request = Service.Events.List(CalendarId);
            request.TimeMin = filter.FromDate;
            request.TimeMax = filter.ToDate;
            request.ShowDeleted = filter.ShowDeleted;
            request.SingleEvents = filter.SingleEvents;
            request.MaxResults = filter.MaxResults;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            if (filter.ExtendedProperties.Count > 0)
            {
                request.PrivateExtendedProperty = new Google.Apis.Util.Repeatable<string>(filter.ExtendedProperties);
            }

            var events = InvokeWithRetry<Events, EventsResource.ListRequest>(() => { return request.Execute(); }).Items.ToList();

            foreach (var e in events)
            {
                if (EventMapper.ImportEvent(e))
                {
                    UpdateEventAsync(e);
                }
            }

            return events;
        }

        // https://developers.google.com/google-apps/calendar/v3/reference/events/insert
        private Event InsertEvent(Event @event)
        {
            FixCreated(@event);
            FixExtendedProperties(@event);
            var request = Service.Events.Insert(@event, CalendarId);
            var result = InvokeWithRetry<Event, EventsResource.InsertRequest>(() => { return request.Execute(); });
            return result;
        }

        // https://developers.google.com/google-apps/calendar/v3/reference/events/delete
        private void DeleteEvent(string eventId)
        {
            var request = Service.Events.Delete(CalendarId, eventId);
            InvokeWithRetry<string, EventsResource.DeleteRequest>(() => { return request.Execute(); });
        }

        private Event UpdateEvent(Event @event)
        {
            FixCreated(@event);
            FixExtendedProperties(@event);
            var request = Service.Events.Update(@event, CalendarId, @event.Id);
            var result = InvokeWithRetry<Event, EventsResource.UpdateRequest>(() => { return request.Execute(); });
            return result;
        }

        private void UpdateEventAsync(Event @event)
        {
            var func = new Func<Event, Event>(UpdateEvent);
            func.BeginInvoke(@event, null, null);
        }

        private void FixExtendedProperties(Event @event)
        {
            var keys = @event.ExtendedProperties.Private__.Keys;
            for (var i = 0; i < keys.Count; i++)
            {
                var key = keys.ElementAt(i);
                var value = @event.ExtendedProperties.Private__[key];
                if (value == null)
                {
                    @event.ExtendedProperties.Private__[key] = string.Empty;
                }
            }
            if (keys.Contains("AlertKey") == false)
            {
                @event.ExtendedProperties.Private__.Add("AlertKey", string.Empty);
            }
        }

        private static void FixCreated(Event @event)
        {
            if (@event.Created == null)
            {
                @event.Created = DateTime.Now;
            }
        }
    }
}