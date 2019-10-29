namespace ClientManage.Interfaces
{
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