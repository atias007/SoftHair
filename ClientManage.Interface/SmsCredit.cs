using System;

namespace ClientManage.Interfaces
{
    public class SmsCredit
    {
        public SmsCredit(string fileLine)
        {
            var items = fileLine.Split(',');
            if (items.Length == 4)
            {
                int id;
                int.TryParse(items[0], out id);
                Id = id;

                int clientId;
                int.TryParse(items[1], out clientId);
                ClientId = clientId;

                int credit;
                int.TryParse(items[2], out credit);
                Credit = credit;

                DateTime dateUpdate;
                DateTime.TryParse(items[3], out dateUpdate);
                DateUpdate = dateUpdate;
            }
        }

        public int Id { get; set; }

        public int ClientId { get; set; }

        public int Credit { get; set; }

        public DateTime DateUpdate { get; set; }
    }
}