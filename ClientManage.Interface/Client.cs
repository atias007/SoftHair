using System;
using System.Data;

namespace ClientManage.Interfaces
{
    public class Client
    {
        public enum ClientGender { Male, Female };

        private int _key = -1;
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _homePhone = string.Empty;
        private string _workPhone = string.Empty;
        private string _cellPhone_1 = string.Empty;
        private string _cellPhone_2 = string.Empty;
        private DateTime? _birthDate = null;
        private DateTime _createDate = DateTime.Now;
        private string _address = string.Empty;
        private string _city = string.Empty;
        private ClientGender _gender = ClientGender.Male;
        private string _zipcode = string.Empty;
        private DateTime? _marriedDate = null;
        private string _picture = string.Empty;
        private string _remark = string.Empty;
        private string _email = string.Empty;
        private bool _enableSMS = true;
        private bool _enableEmail = true;
        private string _clientTypeName = string.Empty;
        private string _workerName = string.Empty;

        public Client()
        {
        }

        public Client(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

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

        public string WorkPhone
        {
            get { return _workPhone; }
            set { _workPhone = value; }
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

        public ClientGender Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public string ZipCode
        {
            get { return _zipcode; }
            set { _zipcode = value; }
        }

        public DateTime? MarriedDate
        {
            get { return _marriedDate; }
            set { _marriedDate = value; }
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

        public int NextClientId { get; set; }

        public int PrevClientId { get; set; }

        public int Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public string CardId { get; set; }

        public int TotalPhotos { get; set; }

        public int TotalSubscriptions { get; set; }

        public string AllPhones
        {
            get
            {
                var ret = string.Empty;

                ret += " " + Utils.DistilPhone(_homePhone);
                ret += " " + Utils.DistilPhone(_workPhone);
                ret += " " + Utils.DistilPhone(_cellPhone_1);
                ret += " " + Utils.DistilPhone(_cellPhone_2);

                return ret.Trim();
            }
        }

        public string AllPhoneDigits
        {
            get
            {
                var ret = string.Empty;

                ret += "," + Utils.DistilPhone(_homePhone);
                ret += "," + Utils.DistilPhone(_workPhone);
                ret += "," + Utils.DistilPhone(_cellPhone_1);
                ret += "," + Utils.DistilPhone(_cellPhone_2);

                ret = ret.Replace(" ", string.Empty);
                ret = ret.Replace("-", string.Empty);
                ret = ret.Replace(",", " ");

                return ret.ToString();
            }
        }

        public string AllPhonesWithComma
        {
            get
            {
                var ret = string.Empty;

                if (_homePhone.Length > 0) ret += _homePhone + ", ";
                if (_workPhone.Length > 0) ret += _workPhone + ", ";
                if (_cellPhone_1.Length > 0) ret += _cellPhone_1 + ", ";
                if (_cellPhone_2.Length > 0) ret += _cellPhone_2 + ", ";

                return ret.ToString();
            }
        }

        public string[] GetPrintData()
        {
            var data = new string[20];

            data[0] = _picture;
            data[1] = _firstName;
            data[2] = _lastName;
            data[3] = _homePhone;
            data[4] = _workPhone;
            data[5] = _cellPhone_1;
            data[6] = _cellPhone_2;
            data[7] = _birthDate.HasValue ? _birthDate.GetValueOrDefault().ToString("dd/MM/yyyy") : "ללא תאריך לידה";
            data[8] = _gender == ClientGender.Male ? "זכר" : "נקבה";
            data[9] = _address;
            data[10] = _city;
            data[11] = _zipcode;
            data[12] = _marriedDate.HasValue ? _marriedDate.GetValueOrDefault().ToString("dd/MM/yyyy") : "ללא תאריך נישואין";
            data[13] = _email;
            data[14] = _createDate.ToString("dd/MM/yyyy");
            data[15] = _workerName;
            data[16] = _clientTypeName;
            data[17] = _remark.Replace("\n", "<br />");
            data[18] = string.Empty;
            data[19] = string.Empty;

            return data;
        }

        public bool EnableSMS
        {
            get { return _enableSMS; }
            set { _enableSMS = value; }
        }

        public bool EnableEmail
        {
            get { return _enableEmail; }
            set { _enableEmail = value; }
        }

        public int ClientTypeId { get; set; }

        public string ClientTypeName
        {
            get { return _clientTypeName; }
            set { _clientTypeName = value; }
        }

        public int WorkerId { get; set; }

        public string WorkerName
        {
            get { return _workerName; }
            set { _workerName = value; }
        }

        public string FullName
        {
            get
            {
                var name = _firstName + " " + _lastName;
                return name.Trim();
            }
        }

        public bool IsTodayBirthday
        {
            get
            {
                var todayBDay = false;
                if (this.BirthDate.HasValue)
                {
                    var val = this.BirthDate.GetValueOrDefault();
                    todayBDay = (DateTime.Now.Day == val.Day && DateTime.Now.Month == val.Month);
                }
                return todayBDay;
            }
        }

        public bool IsTodayMarriedDay
        {
            get
            {
                var todayMarr = false;
                if (this.MarriedDate.HasValue)
                {
                    var val = this.MarriedDate.GetValueOrDefault();
                    todayMarr = (DateTime.Now.Day == val.Day && DateTime.Now.Month == val.Month);
                }
                return todayMarr;
            }
        }

        public DataTable GetSMSTable()
        {
            var table = new DataTable();
            table.Columns.Add("full_name", typeof(string));
            table.Columns.Add("cell_phone", typeof(string));
            table.Rows.Add(FullName, _cellPhone_1);
            return table;
        }

        public DataTable GetEmailTable()
        {
            var table = new DataTable();
            table.Columns.Add("full_name", typeof(string));
            table.Columns.Add("email", typeof(string));
            table.Rows.Add(FullName, _email);
            return table;
        }
    }
}