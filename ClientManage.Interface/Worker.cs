using System;
using System.Collections.Generic;
using System.Text;

namespace ClientManage.Interfaces
{
    public class Worker
    {
        public enum WorkerGender {Male, Female};

        private DateTime? _birthDate = null;
        private DateTime _createDate = DateTime.Now;
        private DateTime _startWorkDate = DateTime.MinValue;
        private DateTime _endWorkDate = DateTime.MinValue;
        private WorkerGender _gender = WorkerGender.Male;
        private string _idNumber        = string.Empty;
        private string _firstName       = string.Empty;
        private string _lastName        = string.Empty;
        private string _homePhone       = string.Empty;
        private string _cellPhone_1     = string.Empty;
        private string _cellPhone_2     = string.Empty;
        private string _address         = string.Empty;
        private string _city            = string.Empty;
        private string _zipcode         = string.Empty;   
        private string _mailCell        = string.Empty;
        private string _picture         = string.Empty;
        private string _remark          = string.Empty;
        private string _email           = string.Empty;
        private string _jobTitle        = string.Empty;
        private string _personalPassword = string.Empty;
        private string _cardId             = string.Empty;
        private bool _isActive          = true;
        private bool _isAdmin           = false;
        private bool _isFillTraffic     = true;
        private bool _isCalPresent = true;

        public Worker() { }
        public Worker(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public string IdNumber
        {
            get { return _idNumber; }
            set { _idNumber = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string HomePhone
        {
            get { return _homePhone; }
            set { _homePhone = value; }
        }

        public string CellPhone1
        {
            get { return _cellPhone_1; }
            set { _cellPhone_1 = value; }
        }        

        public string CellPhone2
        {
            get { return _cellPhone_2; }
            set { _cellPhone_2 = value; }
        }

        public DateTime? BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }

        public DateTime StartWorkDate
        {
            get { return _startWorkDate; }
            set { _startWorkDate = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public WorkerGender Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public string ZipCode
        {
            get { return _zipcode; }
            set { _zipcode = value; }
        }

        public string MailCell
        {
            get { return _mailCell; }
            set { _mailCell = value; }
        }

        public string Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }

        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string JobTitle
        {
            get { return _jobTitle; }
            set { _jobTitle = value; }
        }

        public string PersonalPassword
        {
            get { return _personalPassword; }
            set { _personalPassword = value; }
        }

        public string CardId
        {
            get { return _cardId; }
            set { _cardId = value; }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        public bool IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }

        public bool IsFillTraffic
        {
            get { return _isFillTraffic; }
            set { _isFillTraffic = value; }
        }

        public DateTime EndWorkDate
        {
            get { return _endWorkDate; }
            set { _endWorkDate = value; }
        }

        public bool IsCalPresent
        {
            get { return _isCalPresent; }
            set { _isCalPresent = value; }
        }

        public string AllPhones
        {
            get
            {
                var ret = string.Empty;

                ret += " " + Utils.DistilPhone(_homePhone);
                ret += " " + Utils.DistilPhone(_cellPhone_1);
                ret += " " + Utils.DistilPhone(_cellPhone_2);

                return ret.Trim();
            }
        }

        public string FullName
        {
            get
            {
                var name = _firstName + " " + _lastName;
                return name.Trim();
            }
        }

        public string[] GetPrintData()
        {
            var data = new string[24];

            data[0] = _picture;
            data[1] = _firstName;
            data[2] = _lastName;
            data[3] = _idNumber;
            data[4] = _email;
            data[5] = _birthDate.HasValue ? _birthDate.GetValueOrDefault().ToString("dd/MM/yyyy") : "ללא תאריך לידה";
            data[6] = _gender == WorkerGender.Male ? "זכר" : "נקבה";
            data[7] = _cellPhone_1;
            data[8] = _homePhone;
            data[9] = _cellPhone_2;
            data[10] = _personalPassword;
            data[11] = _address;
            data[12] = _city;
            data[13] = _zipcode;
            data[14] = _mailCell;
            data[15] = _jobTitle;
            data[16] = _cardId.ToString();
            data[17] = _startWorkDate.ToString("dd/MM/yyyy");
            data[18] = _endWorkDate.Equals(DateTime.MinValue) ? string.Empty : _endWorkDate.ToString("dd/MM/yyyy");
            data[19] = _isActive ? "כן" : "לא";
            data[20] = _isFillTraffic ? "כן" : "לא";
            data[21] = _isCalPresent ? "כן" : "לא";
            data[22] = _isAdmin ? "כן" : "לא";
            data[23] = _remark.Replace("\n", "<br />");


            return data;
        }
    }
}
