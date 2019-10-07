using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace SoftHairQuickLanch
{
    public class Settings
    {
        private readonly XmlDocument _doc;
        private readonly bool _loadProc = false;

        public Settings(XmlDocument doc)
        {
            _doc = doc;

            try
            {
                XmlNode node = doc.DocumentElement;
                if (node.Name == "QuickLaunchSettings")
                {
                    _loadProc = true;
                    node = node["Support"];
                    this.ID = GetXmlValue("ID");
                    this.ClientId = GetXmlValue("ClientID");
                    this.ClientName = GetXmlValue("ClientName");
                    this.PhoneNo = GetXmlValue("PhoneNo");
                    _loadProc = false;
                }
            }
            catch { }
        }

        private string _clientId = "00000";
        public string ClientId
        {
            get { return _clientId; }
            set 
            { 
                _clientId = value;
                SetXmlValue("ClientID", value);
            }
        }
        private string _ID;
        public string ID
        {
            get { return _ID; }
            set 
            { 
                _ID = value;
                SetXmlValue("ID", value);
            }
        }
        private string _clientName = "NO NAME";
        public string ClientName
        {
            get { return _clientName; }
            set 
            { 
                _clientName = value;
                SetXmlValue("ClientName", value);
            }
        }
        private string _phoneNo = string.Empty;
        public string PhoneNo
        {
            get { return _phoneNo; }
            set 
            { 
                _phoneNo = value;
                SetXmlValue("PhoneNo", value);
            }
        }

        public string Password { get; set; }

        private string _remark = string.Empty;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        private int _credit = 0;
        public int Credit
        {
            get { return _credit; }
            set { _credit = value; }
        }

        private string GetXmlValue(string field)
        {
            var value = string.Empty;

            try
            {
                XmlNode node = _doc.DocumentElement;
                if (node.Name == "QuickLaunchSettings")
                {
                    node = node["Support"][field];
                    if (node.ChildNodes.Count > 0)
                    {
                        value = Convert.ToString(node.ChildNodes[0].Value);
                    }
                }
                
            }
            catch { }

            return value;
        }

        private void SetXmlValue(string field, string value)
        {
            if (_loadProc) return;
            try
            {
                XmlNode node = _doc.DocumentElement;
                if (node.Name == "QuickLaunchSettings")
                {
                    node = node["Support"][field];
                    if (node.ChildNodes.Count == 0)
                    {
                        node.AppendChild(_doc.CreateNode(XmlNodeType.Text, "#text", string.Empty));
                    }
                    node.ChildNodes[0].Value = value;
                }
            }
            catch { }
        }

        public override string ToString()
        {
            var text =
                   ClientId + " " +
                   (ClientName.Length <= 10 ? ClientName : ClientName.Substring(0, 10)) +
                   " ID:" + ID.Replace(" ", string.Empty) +
                   " PW:" + Password +
                   " CD:" + _credit.ToString() +
                   " PH:" + _phoneNo.Replace("-", string.Empty).Replace(" ", string.Empty);

            return text.Trim();
        }
    }
}
