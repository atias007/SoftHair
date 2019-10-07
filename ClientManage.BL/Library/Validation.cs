using System;
using System.Drawing;
using System.Text.RegularExpressions;
using ClientManage.Interfaces;

namespace ClientManage.BL.Library
{
    public class Validation
    {
        // constant of the error backcolor of text boxes
        private static readonly Color InnerErrorColor = Color.FromArgb(255, 192, 192);
        private static Regex _rx;
        private static string[] _cellPhonesPrefix;
        private static string[] _linePhonesPrefix;

        public static string[] CellPhonePrefix
        {
            set { _cellPhonesPrefix = value; }
        }
        public static string[] LinePhonePrefix
        {
            get { return _linePhonesPrefix; }
            set { _linePhonesPrefix = value; }
        }

        public static Color ErrorColor
        {
            get { return InnerErrorColor; }
        }

        public static bool IsEmailValid(string email, bool isRequired)
        {
            var ret = !isRequired;
            if (!string.IsNullOrEmpty(email))
            {
                _rx = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
                ret = _rx.IsMatch(email);
            }
            return ret;
        }

        public static bool IsEmailValid(string email)
        {
            return IsEmailValid(email, false);
        }

        public static bool IsZipCodeValid(string zipcode, bool isRequired)
        {
            var ret = !isRequired;
            if (!string.IsNullOrEmpty(zipcode))
            {
                _rx = new Regex(@"^\d{5}$");
                ret = _rx.IsMatch(zipcode);
            }
            return ret;
        }

        public static bool IsZipCodeValid(string zipcode)
        {
            return IsZipCodeValid(zipcode, false);
        }

        public static string FormatPhone(string phone)
        {
            phone = Utils.DistilPhone(phone);
            foreach (var s in _cellPhonesPrefix)
            {
                if (phone.StartsWith(s))
                {
                    phone = phone.Substring(0, s.Length) + "-" + phone.Substring(s.Length);
                    return phone;
                }
            }
            foreach (var s in _linePhonesPrefix)
            {
                if (phone.StartsWith(s))
                {
                    phone = phone.Substring(0, s.Length) + "-" + phone.Substring(s.Length);
                    return phone;
                }
            }
            return phone;
        }

         public static bool IsPhoneValid(string phone)
        {
            return IsPhoneValid(phone, false);
        }
        public static bool IsPhoneValid(string phone, bool isRequired)
        {
            return IsCellPhoneValid(phone, isRequired) || IsLinePhoneValid(phone, isRequired);
        }

        public static bool IsCellPhoneValid(string phone)
        {
            return IsCellPhoneValid(phone, false);
        }
        public static bool IsCellPhoneValid(string phone, bool isRequired)
        {
            var ret = !isRequired;

            if (!string.IsNullOrEmpty(phone))
            {
                ret = false;
                foreach (var p in _cellPhonesPrefix)
                {
                    if (phone.StartsWith(p))
                    {
                        _rx = new Regex(@"^\d{7}$");
                        ret = _rx.IsMatch(phone.Substring(p.Length));
                        break;
                    }
                }
            }
            return ret; 
        }
        
        public static bool IsLinePhoneValid(string phone)
        {
            return IsLinePhoneValid(phone, false);
        }
        public static bool IsLinePhoneValid(string phone, bool isRequired)
        {
            var ret = !isRequired;

            if (!string.IsNullOrEmpty(phone))
            {
                ret = false;
                foreach (var p in _linePhonesPrefix)
                {
                    if (phone.StartsWith(p))
                    {
                        _rx = new Regex(@"^\d{7}$");
                        ret = _rx.IsMatch(phone.Substring(p.Length));
                        break;
                    }
                }
            }
            return ret; 
        }

        public static bool IsTimeValid(string time, bool isRequired)
        {
            var ret = !isRequired;
            if (!string.IsNullOrEmpty(time))
            {
                _rx = new Regex("^([0-1]?[0-9]|[2][0-3]):([0-5][0-9])$");
                ret = _rx.IsMatch(time);
            }
            return ret;
        }
        public static bool IsTimeValid(string time)
        {
            return IsTimeValid(time, false);
        }

        public static bool IsPersonIdNumberValid(string id, bool isRequired)
        {
            var ret = !isRequired;
            if (!string.IsNullOrEmpty(id))
            {
                if (id.Length == 9)
                {
                    var sum = 0;
                    var mult = 1;
                    try
                    {
                        for (var i = 0; i < id.Length - 1; i++)
                        {

                            var tmp = Convert.ToInt32(id.Substring(i, 1)) * mult;
                            if (tmp > 9) tmp = 1 + tmp - 10;
                            sum += tmp;
                            mult = mult == 2 ? 1 : 2;
                        }
                        sum += Convert.ToInt32(id.Substring(id.Length - 1, 1));
                        ret = (sum > 0 && sum % 10 == 0);
                    }
                    catch { Utils.CatchException(); }
                }
                else { ret = false; }
            }
            return ret;
        }
        public static bool IsPersonIdNumberValid(string id)
        {
            return IsPersonIdNumberValid(id, false);
        }
    }
}
