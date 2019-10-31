using System;

namespace ClientManage.Interfaces
{
    public class SmsCredit
    {
        public SmsCredit(string fileLine)
        {
            var items = fileLine.Split(',');
            if (items.Length >= 3)
            {
                int id;
                int.TryParse(items[0], out id);
                Id = id;

                int credit;
                int.TryParse(items[1], out credit);
                Credit = credit;

                DateTime dateUpdate;
                DateTime.TryParse(items[2], out dateUpdate);
                DateUpdate = dateUpdate;
            }
        }

        public int Id { get; set; }

        public int Credit { get; set; }

        public DateTime DateUpdate { get; set; }
    }
}