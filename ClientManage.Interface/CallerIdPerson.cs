using System;

namespace ClientManage.Interfaces
{
    public class CallerIdPerson
    {
        public enum PersonGender { Male, Female };
        public enum PersonEntity { Client, Contact };

        public int Id { get; set; }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Picture { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Company { get; set; }

        public string JobTitle { get; set; }

        public DateTime? BirthDate { get; set; }

        public PersonGender Gender { get; set; }

        public PersonEntity Entity { get; set; }

        public string FullName
        {
            get
            {
                var name = _firstName + " " + _lastName;
                return name.Trim();
            }
        }
    }
}
