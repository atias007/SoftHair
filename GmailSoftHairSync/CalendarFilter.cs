﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailSoftHairSync
{
    public class CalendarFilter
    {
        public CalendarFilter()
        {
            MaxResults = 250;
            SingleEvents = true;
            ExtendedProperties = new List<string>();
        }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public int MaxResults { get; set; }

        public bool ShowDeleted { get; set; }

        public bool SingleEvents { get; set; }

        public List<string> ExtendedProperties { get; private set; }
    }
}