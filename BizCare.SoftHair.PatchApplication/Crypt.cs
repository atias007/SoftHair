using System;
using System.Data;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace BizCare.SoftHair.PatchApplication
{
    public class Crypt
    {
        private const string CryptKey = "FhG/3ME/OF7ZR8e9Yd6uubQBrbtW0CK+";


        internal static void EncryptXmlDoc(ref XmlDocument xmlDoc)
        {
            var tDeSkey = new TripleDESCryptoServiceProvider {Key = Convert.FromBase64String(CryptKey)};
            var exml = new EncryptedXml(xmlDoc);
            var ed = new EncryptedData();

            var xmlEm = xmlDoc.DocumentElement;
            if (xmlEm == null) return;
            var encDoc = exml.EncryptData(xmlEm, tDeSkey, false);

            ed.Type = EncryptedXml.XmlEncElementUrl;
            ed.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncTripleDESUrl);
            ed.CipherData = new CipherData {CipherValue = encDoc};

            EncryptedXml.ReplaceElement(xmlEm, ed, false);
        }

        internal static void DecryptXmlDoc(ref XmlDocument xmlDoc)
        {
            var encryptedElement = (XmlElement)xmlDoc.GetElementsByTagName("EncryptedData")[0];
            var ed2 = new EncryptedData();
            var tDeSkey = new TripleDESCryptoServiceProvider {Key = Convert.FromBase64String(CryptKey)};
            ed2.LoadXml(encryptedElement);
            var exml2 = new EncryptedXml();
            var decryptedBilling = exml2.DecryptData(ed2, tDeSkey);
            
            exml2.ReplaceData(encryptedElement, decryptedBilling);
        }

        public static DataSet EncryptDataset(DataSet ds)
        {
            var doc = new XmlDocument();
            var ret = new DataSet();

            try
            {
                doc.LoadXml(ds.GetXml());
                EncryptXmlDoc(ref doc);
                ret.ReadXml(new XmlNodeReader(doc));
                return ret;
            }
            catch
            {
                return null;
            }
        }

        public static DataSet DecryptXmlDataset(string xml)
        {
            var doc = new XmlDocument();
            var ret = new DataSet();

            try
            {
                doc.LoadXml(xml);
                DecryptXmlDoc(ref doc);
                ret.ReadXml(new XmlNodeReader(doc));
                return ret;
            }
            catch
            {
                return null;
            }
        }

    }
}
