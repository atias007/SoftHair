using System;

namespace BizCareAdmin
{
    public class CClient
    {
        public CClient(string data)
        {
            

        }

        public string Type { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Picture { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string HomePhone { get; set; }

        public string CellPhone { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime CreateDate { get; set; }

        public int Gender { get; set; }
    }
}
