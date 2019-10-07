using System;

namespace BizCare.SoftHair.UpdateVersion.Library
{
    public class Parameters
    {
        public string ClientVersion { get; set; }
        public string CurrentVersion { get; set; }
        public string ClientID { get; set; }
        public string ClientName { get; set; }
        public string UniqueId { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
    }
}
