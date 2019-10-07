using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using ClientManage.Interfaces;
using System.Xml;
using System.Windows.Forms;
using BizCare.SoftHair.PatchApplication;

namespace ClientManage.Interfaces
{
    public class Security
    {
        public static ProductLicense GetLicense(string key)
        {
            var doc = new XmlDocument();
            var lcn = new ProductLicense();

            try
            {
                doc.LoadXml(key);
                Crypt.DecryptXmlDoc(ref doc);
                lcn.ReadXml(new XmlNodeReader(doc));
            }
            catch(Exception)
            {
                return null;
            }

            if (lcn.License.Rows.Count == 0) return null;
            return (ProductLicense)lcn;
        }
        
        public static ProductLicense GetNewLicense()
        {
            var lcn = new ProductLicense();
            var row = lcn.License.NewLicenseRow();
            lcn.License.Rows.Add(row);
            return lcn;
        }
        
        public static string SaveLicence(ProductLicense licence)
        {
            var doc = new XmlDocument();
            var ret = string.Empty;

            doc.LoadXml(licence.GetXml());
            Crypt.EncryptXmlDoc(ref doc);
            ret = doc.OuterXml;
            return ret;
        }

        public static string EndLicense(ProductLicense license)
        {
            license.License[0].to_date = DateTime.Now.Date.AddDays(-1);
            return SaveLicence(license);
        }
    }
}
