using System;

namespace ClientManage.Interfaces
{
    public enum LicenseStatus { None, Valid, Block, OutOfDate }

    public class CustomerLicense
    {
        public CustomerLicense(string fileLine)
        {
            var items = fileLine.Split(',');
            if (items.Length == 5)
            {
                int clientId;
                int.TryParse(items[0], out clientId);
                ClientId = clientId;

                Title = items[1];

                bool allow;
                bool.TryParse(items[2], out allow);
                Allow = allow;

                DateTime from;
                DateTime.TryParse(items[3], out from);
                From = from;

                DateTime to;
                DateTime.TryParse(items[4], out to);
                To = to;
            }
        }

        public CustomerLicense()
        {
            Title = "לקוח ללא רשיון";
            Allow = false;
        }

        public int ClientId { get; set; }

        public string Title { get; set; }

        public bool Allow { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public DateTime ServerDate { get; set; }

        public LicenseStatus Status { get; set; }

        public int ExpireDays { get; set; }
    }
}