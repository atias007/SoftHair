using System;

namespace BizCare.Calendar.Library
{
    public class Appointment
    {
        public Appointment()
        {
        }

        public Appointment(string id, DateTime startDate, DateTime endDate, string text, int workerId)
        {
            _startDate = startDate;
            _endDate = endDate;
            _text = text;
            Id = id;
            WorkerId = workerId;
        }

        public enum ImportanceLevel { None, High, Low }

        private DateTime _endDate;
        private int _clientId;
        private ImportanceLevel _importance = ImportanceLevel.None;
        private string _text = string.Empty;
        private string _remark = string.Empty;
        private string _clientName = string.Empty;
        private string _cares = string.Empty;
        private string _caresDescription = string.Empty;
        private bool _isAllDayEvent;
        private int _remainderMinutes = -1;
        private int _widthUnit = 1;

        private DateTime _startDate;

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

        public int ClientId
        {
            get { return _clientId; }
            set { _clientId = value; }
        }

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

        public string ClientName
        {
            get { return _clientName; }
            set { _clientName = value; }
        }

        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        public string Cares
        {
            get { return _cares; }
            set { _cares = value; }
        }

        public string CaresDescription
        {
            get { return _caresDescription; }
            set { _caresDescription = value; }
        }

        public int CaresDuration { get; set; }

        public bool IsAllDayEvent
        {
            get { return _isAllDayEvent; }
            set { _isAllDayEvent = value; }
        }

        public int RemainderMinutes
        {
            get { return _remainderMinutes; }
            set { _remainderMinutes = value; }
        }

        public string Id { get; set; }

        public int WorkerId { get; set; }

        public int RecurrenceId { get; set; }

        public bool HasAlert { get; set; }

        public string AlertKey { get; set; }

        public string Attendee { get; set; }

        public bool CanClearClient
        {
            get
            {
                return (_text.Trim().Length > 0 || !string.IsNullOrEmpty(_cares));
            }
        }

        public bool CanClearText
        {
            get
            {
                return (!string.IsNullOrEmpty(_cares) || _clientId > 0);
            }
        }

        internal int VerticalOrder { get; set; }

        internal int WidthUnit
        {
            get { return _widthUnit; }
            set { _widthUnit = value; }
        }

        internal string ToolTipScope
        {
            get
            {
                if (_isAllDayEvent)
                {
                    return string.Empty;
                }
                return _startDate.ToShortTimeString() + "-" + _endDate.ToShortTimeString();// +"  " + this.Text;
            }
        }

        internal bool IsOccurInDate(DateTime someDate)
        {
            var ret = _startDate.Date.Equals(someDate.Date);
            ret = ret || _endDate.Date.Equals(someDate.Date);

            return ret;
        }

        public override string ToString()
        {
            return GetAppointmentString(this.Text, _clientName, _caresDescription);
        }

        public static string GetAppointmentString(string subject, string clientName, string cares)
        {
            var text = string.Empty;
            if (clientName.Length > 0)
            {
                text = clientName;
            }
            if (!string.IsNullOrEmpty(cares))
            {
                if (text.Length > 0) text += " - ";
                text += cares;
            }
            if (string.IsNullOrEmpty(subject) == false)
            {
                text += " (" + subject + ")";
            }

            return text.Trim();
        }
    }
}