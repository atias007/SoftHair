using System;
using System.Collections.Generic;
using System.Text;

namespace ClientManage.Interfaces
{
    public class AutoCalSmsParams
    {
        public AutoCalSmsParams(string value, string message)
        {
            var p = value.Split(',');
            _enable = Convert.ToBoolean(p[0]);
            _upMin = Convert.ToInt32(p[1]);
            _daysBefore = Convert.ToInt32(p[2]);
            if (p[3].Length > 0) _lastSubmit = Convert.ToDateTime(p[3]);
            Message = message;
        }

        private DateTime _lastSubmit = DateTime.MinValue;
        public DateTime LastSubmit
        {
            get { return _lastSubmit; }
            set { _lastSubmit = value; }
        }

        public string Message { get; set; }

        private bool _enable;
        public bool Enable
        {
            get { return _enable; }
            set { _enable = value; }
        }

        private int _daysBefore;
        public int DaysBefore
        {
            get { return _daysBefore; }
            set { _daysBefore = value; }
        }

        private int _upMin;
        public int UpMin
        {
            get { return _upMin; }
            set { _upMin = value; }
        }

        public string GetLastSubmitCaption()
        {
            if (_lastSubmit == DateTime.MinValue)
            {
                return "< לא נשלח מעולם >";
            }
            else
            {
                return _lastSubmit.ToString("dd/MM/yyyy HH:mm");
            }
        }

        public override string ToString()
        {
            return _enable.ToString() + "," + _upMin.ToString() + "," + _daysBefore + "," + _lastSubmit.ToString();
        }
    }
}
