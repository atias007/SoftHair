using System.IO;
using System.Xml.Linq;
using ClientManage.Interfaces;

namespace ClientManage.Library
{
    public class SettingsFileHelper
    {
        private readonly XElement _node;
        private readonly XDocument _document;
        private readonly string _filename;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsFileHelper"/> class.
        /// </summary>
        public SettingsFileHelper()
        {
            _filename = Path.Combine(General.StartupPath, "QuickLaunch.xml");
            var xml = File.ReadAllText(_filename);
            if (xml.StartsWith("<?"))
            {
                xml = xml.Substring(xml.IndexOf("?>") + 2).Trim();
            }

            _document = XDocument.Parse(xml);
            
            _node = _document.Root;
            if (_node != null)
            {
                _node = _node.Name == "QuickLaunchSettings" ? _node.Element("Support") : null;
            }
        }

        /// <summary>
        /// Gets the setting value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public string GetSettingValue(string key)
        {
            if (_node == null) return null;

            return GetXmlValue(_node, key);
        }

        /// <summary>
        /// Sets the setting value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void SetSettingValue(string key, string value)
        {
            if (_node == null) return;

            SetXmlValue(_node, key, value);
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            _document.Save(_filename);
        }

        private static string GetXmlValue(XElement node, string fieldName)
        {
            var value = string.Empty;

            try
            {
                node = node.Element(fieldName);
                if (node != null)
                {
                    value = node.Value;
                }
            }
            catch { Utils.CatchException(); }

            return value ?? string.Empty;
        }

        private static void SetXmlValue(XElement node, string fieldName, string value)
        {
            try
            {
                var valueNode = node.Element(fieldName);
                if (valueNode == null)
                {
                    valueNode = new XElement(fieldName);
                    node.Add(valueNode);
                }
                valueNode.Value = value;
            }
            catch { Utils.CatchException(); }
        }
    }
}
