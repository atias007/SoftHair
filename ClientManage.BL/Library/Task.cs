using System;

namespace ClientManage.BL.Library
{
    public class Task
    {
        public Task(string name) : this(name, 1, TimeSpan.Zero) { ApplySpan = false; }
        public Task(string name, int interval) : this(name, interval, TimeSpan.Zero) { ApplySpan = false; }
        public Task(string name, int interval, TimeSpan span)
        {
            Enable = true;
            Name = name;
            Interval = interval;
            _span = span;
            ApplySpan = true;
        }

        public bool Enable { get; set; }

        public string Name { get; private set; }

        private TimeSpan _span = TimeSpan.Zero;
        public TimeSpan Span
        {
            get { return _span; }
            set
            {
                _span = value;
                ApplySpan = true;
            }
        }

        public int Interval { get; set; }

        public bool ApplySpan { get; set; }

        public int FirstStart { get; set; }
    }
}
