using System;
using System.Collections.Generic;
using System.Text;

namespace ClientManage.Interfaces
{
    public class AutoSmsParameters
    {
        public AutoSmsParameters(string value)
        {
            var p = value.Split(',');
            _enable = Convert.ToBoolean(p[0]);
            _messageId = Convert.ToInt32(p[1]);
            if (p[2].Length > 0) _lastSubmit = Convert.ToDateTime(p[2]);
        }

        private DateTime _lastSubmit = DateTime.MinValue;

        public DateTime LastSubmit
        {
            get { return _lastSubmit; }
            set { _lastSubmit = value; }
        }

        private int _messageId;

        public int MessageId
        {
            get { return _messageId; }
            set { _messageId = value; }
        }

        private bool _enable;

        public bool Enable
        {
            get { return _enable; }
            set { _enable = value; }
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
            return _enable.ToString() + "," + _messageId.ToString() + "," + _lastSubmit.ToString();
        }
    }
}
