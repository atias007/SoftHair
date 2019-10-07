using System;
using System.Collections.Generic;
using System.Text;

namespace ClientManage.Interfaces
{
    public class PhoneBookContact
    {
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _company = string.Empty;
        private string _jobTitle = string.Empty;
        private string _phoneNo1 = string.Empty;
        private string _phoneNo2 = string.Empty;
        private string _phoneNo3 = string.Empty;
        private string _fax = string.Empty;
        private string _city = string.Empty;
        private string _notes = string.Empty;
        private string _mailCellNo = string.Empty;
        private string _zipCode = string.Empty;
        private string _street = string.Empty;
        private string _webSite = string.Empty;
        private string _email = string.Empty;
        private string _picture = string.Empty;

        public PhoneBookContact()
        {
        }

        public PhoneBookContact(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        public string Company
        {
            get
            {
                return _company;
            }
            set
            {
                _company = value;
            }
        }

        public string JobTitle
        {
            get
            {
                return _jobTitle;
            }
            set
            {
                _jobTitle = value;
            }
        }

        public string WebSite
        {
            get
            {
                return _webSite;
            }
            set
            {
                _webSite = value;
            }
        }

        public string PhoneNo1
        {
            get
            {
                return _phoneNo1;
            }
            set
            {
                _phoneNo1 = value;
            }
        }

        public string PhoneNo2
        {
            get
            {
                return _phoneNo2;
            }
            set
            {
                _phoneNo2 = value;
            }
        }

        public string PhoneNo3
        {
            get
            {
                return _phoneNo3;
            }
            set
            {
                _phoneNo3 = value;
            }
        }

        public string Fax
        {
            get
            {
                return _fax;
            }
            set
            {
                _fax = value;
            }
        }

        public string Street
        {
            get
            {
                return _street;
            }
            set
            {
                _street = value;
            }
        }

        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
            }
        }

        public string Notes
        {
            get
            {
                return _notes;
            }
            set
            {
                _notes = value;
            }
        }

        public string ZipCode
        {
            get
            {
                return _zipCode;
            }
            set
            {
                _zipCode = value;
            }
        }

        public string MailCellNo
        {
            get
            {
                return _mailCellNo;
            }
            set
            {
                _mailCellNo = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public string Picture
        {
            get
            {
                return _picture;
            }
            set
            {
                _picture = value;
            }
        }

        public DateTime DateCreated { get; set; }

        public string AllPhones
        {
            get
            {
                var ret = string.Empty;

                ret += " " + Utils.DistilPhone(_phoneNo1);
                ret += " " + Utils.DistilPhone(_phoneNo2);
                ret += " " + Utils.DistilPhone(_phoneNo3);

                return ret.Trim();
            }
        }
        public string[] GetPrintData()
        {
            var data = new string[16];

            data[0] = _picture;
            data[1] = _firstName;
            data[2] = _lastName;
            data[3] = _company;
            data[4] = _jobTitle;
            data[5] = _email;
            data[6] = _webSite;
            data[7] = _phoneNo1;
            data[8] = _phoneNo2;
            data[9] = _phoneNo3;
            data[10] = _fax;
            data[11] = _street;
            data[12] = _city;
            data[13] = _zipCode;
            data[14] = _mailCellNo;
            data[15] = _notes.Replace("\n", "<br />");

            return data;
        }

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
