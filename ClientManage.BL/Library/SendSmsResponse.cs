namespace ClientManage.BL.Library
{
    public class SendSmsResponse
    {
        public byte Status { get; set; }

        public string Description { get; set; }

        public byte NumberOfRecipients { get; set; }
    }
}