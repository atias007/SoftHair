using System;
using System.Collections.Generic;
using System.Text;

namespace ClientManage.Library
{
    public class StickerClient
    {
        private string _fullName = string.Empty;
        public string FullName
        {
            get { return _fullName; }
            set { if (value == null) _fullName = string.Empty; else _fullName = value; }
        }

        private string _address = string.Empty;
        public string Address
        {
            get { return _address; }
            set { if (value == null) _address = string.Empty; else _address = value; }
        }

        private string _city = string.Empty;
        public string City
        {
            get { return _city; }
            set { if (value == null) _city = string.Empty; else _city = value; }
        }

        private string _zipCode = string.Empty;
        public string ZipCode
        {
            get { return _zipCode; }
            set { if (value == null) _zipCode = string.Empty; else _zipCode = value; }
        }

        public override string ToString()
        {
            var res = _address;

            if (res.Length > 0 && _city.Length > 0) res += ", ";
            if (_city.Length > 0) res += _city;
            if (res.Length > 0 && _zipCode.Length > 0) res += ", ";
            if (_zipCode.Length > 0) res += "ойчег " + _zipCode;

            return res;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is StickerClient)) return false;
            var s = (StickerClient)obj;

            return
                s.Address == _address &&
                s.City == _city &&
                s.FullName == _fullName &&
                s.ZipCode == _zipCode;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool IsEmpty
        {
            get
            {
                return (_fullName.Length + _address.Length + _city.Length + _zipCode.Length == 0);
            }
        }

        public bool IsValid
        {
            get
            {
                if (string.IsNullOrEmpty(_fullName)) return false;
                else if (string.IsNullOrEmpty(_city) && string.IsNullOrEmpty(_address)) return false;
                return true;
            }
        }

    }
}
