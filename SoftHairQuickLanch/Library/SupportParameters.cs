using System;

namespace SoftHairQuickLanch.Library
{
    internal class SupportParameters
    {
        internal SupportParameters()
        {
            try
            {
                var helper = new SettingsFileHelper();

                _clientId = helper.GetSettingValue("ClientID");
                _clientName = helper.GetSettingValue("ClientName");
                _customerUniqueId = helper.GetSettingValue("SMS_UNIQUEID");
                this.PhoneNo = helper.GetSettingValue("PhoneNo");

                DateTime lastCall;
                DateTime.TryParse(helper.GetSettingValue("LastCall"), out lastCall);
                this.LastCall = lastCall;
            }
            catch { }
        }

        private readonly string _clientId = "00000";
        public string ClientId
        {
            get { return _clientId; }
        }
        private readonly string _clientName = "[NO NAME]";
        public string ClientName
        {
            get { return _clientName; }
        }
        private string _customerUniqueId;
        public string CustomerUniqueId
        {
            get { return _customerUniqueId; }
            set
            {
                _customerUniqueId = value;
                var helper = new SettingsFileHelper();
                helper.SetSettingValue("SMS_UNIQUEID", value);
                helper.Save();
            }
        }
        private string _phoneNo = string.Empty;
        public string PhoneNo
        {
            get { return _phoneNo; }
            set
            {
                _phoneNo = value;
                var helper = new SettingsFileHelper();
                helper.SetSettingValue("PhoneNo", value);
                helper.Save();
            }
        }
        private DateTime _lastCall = DateTime.MinValue;
        public DateTime LastCall
        {
            get { return _lastCall; }
            set 
            { 
                _lastCall = value;
                var helper = new SettingsFileHelper();
                helper.SetSettingValue("LastCall", value.ToString());
                helper.Save();
            }
        }

        private string _remark = string.Empty;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        private int _credit;
        public int Credit
        {
            get { return _credit; }
            set { _credit = value; }
        }

        public override string ToString()
        {
            var text =
                    "[" + _credit + "] " +
                    ClientId + " " +
                    (ClientName.Length <= 10 ? ClientName : ClientName.Substring(0, 10)) +
                    " PH:" + _phoneNo.Replace("-", string.Empty).Replace(" ", string.Empty);

            var remain = 70 - text.Trim().Length;
            if (remain > 5)
            {
                text += " " + (_remark.Length > remain ? _remark.Substring(0, remain) : _remark);
            }

            return text.Trim();
        }
    }
}