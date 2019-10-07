using System;

namespace ClientManage.Interfaces
{
    public enum ImportanceLevel { None, High, Low }

    public class BizCareAppointment
    {
        private DateTime _startDate;
        private DateTime _endDate;
        private ImportanceLevel _importance = ImportanceLevel.None;
        private string _text = string.Empty;
        private string _remark = string.Empty;
        private int _remainderMinutes = -1;

        public string ToString(string clientName, string caresTitle, string workerName)
        {
            var result = string.Format("StartDate: {0:dd/MM/yyyy} {0:HH:mm}, EndDate: {1:dd/MM/yyyy} {1:HH:mm}, ClientId: {2}, Attendee: {3}, ClientEmail: {4}, Text: {5}, Remark: {6}, IsAllDayEvent: {7}, RemainderMinutes: {8}, WorkerId: {9}, Cares: {10}",
                StartDate, EndDate, ClientId, Attendee, ClientEmail, Text, Remark, IsAllDayEvent, RemainderMinutes, WorkerId, Cares);

            return result;
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        public DayOfWeek AppointmentDay
        {
            get { return _startDate.DayOfWeek; }
        }

        public TimeSpan Duration
        {
            get { return _endDate.Subtract(_startDate); }
        }

        public int ClientId { get; set; }

        public string Attendee { get; set; }

        public string ClientEmail { get; set; }

        public ImportanceLevel Importance
        {
            get { return _importance; }
            set { _importance = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        public bool IsAllDayEvent { get; set; }

        public int RemainderMinutes
        {
            get { return _remainderMinutes; }
            set { _remainderMinutes = value; }
        }

        public int RecurrenceId { get; set; }

        public string Id { get; set; }

        public int WorkerId { get; set; }

        public string Cares { get; set; }

        public bool HasAlert { get; set; }

        public bool ResetSmsAlert { get; set; }

        public string AlertKey { get; set; }
    }
}