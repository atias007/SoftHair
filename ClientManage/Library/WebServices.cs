using System.Collections.Generic;
using System.IO;

namespace ClientManage.Library
{
    public static class WebServices
    {
        public static CustomerLicense GetOnlineLicense(int clientId)
        {
            File.

            return new CustomerLicense { ClientId = clientId, Allow = true }; // TODO: ***
        }
    }

    public class SmsPackage
    {
        public string Title { get; set; }

        public List<SmsMessage> Messages { get; set; }

        public string DefaultMessageText { get; set; }
    }

    public class SmsMessage
    {
        public string ToPhone { get; set; }

        public int EntityId { get; set; }

        public int EntityType { get; set; }

        public string MessageText { get; set; }

        public string ReferenceId { get; set; }

        public string FromPhone { get; set; }
    }
}