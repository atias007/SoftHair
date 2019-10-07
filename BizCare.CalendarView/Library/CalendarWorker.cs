using System;
using System.Collections.Generic;
using System.Text;

namespace BizCare.Calendar.Library
{
    public class CalendarWorker
    {
        private string _name = string.Empty;
        private bool _enableExpand = true;

        public CalendarWorker(int id, string name)
        {
            Id = id;
            _name = name;
        }

        public int Id { get; set; }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public bool ReadOnly { get; set; }

        public bool EnableExpand
        {
            get { return _enableExpand; }
            set { _enableExpand = value; }
        }
    }
}
