using System.Collections.Generic;

namespace ClientManage.Interfaces
{
    public class SmsPackage
    {
        public string Title { get; set; }

        public List<SmsMessage> Messages { get; set; }

        public string DefaultMessageText { get; set; }
    }
}