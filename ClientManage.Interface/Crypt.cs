using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Xml;


namespace ClientManage.Interfaces
{
    public class Crypt
    {
        private static string CRYPT_KEY = "FhG/3ME/OF7ZR8e9Yd6uubQBrbtW0CK+";


        internal static void EncryptXMLDoc(ref XmlDocument xmlDoc)
        {
            var tDESkey = new TripleDESCryptoServiceProvider();
            tDESkey.Key = Convert.FromBase64String(CRYPT_KEY);
            var exml = new EncryptedXml(xmlDoc);
            var ed = new EncryptedData();

            var xmlEm = xmlDoc.DocumentElement;
            var encDoc = exml.EncryptData(xmlEm, tDESkey, false);

            ed.Type = EncryptedXml.XmlEncElementUrl;
            ed.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncTripleDESUrl);
            ed.CipherData = new CipherData();
            ed.CipherData.CipherValue = encDoc;

            EncryptedXml.ReplaceElement(xmlEm, ed, false);
        }

        internal static void DecryptXMLDoc(ref XmlDocument xmlDoc)
        {
            var encryptedElement = (XmlElement)xmlDoc.GetElementsByTagName("EncryptedData")[0];
            var ed2 = new EncryptedData();
            var tDESkey = new TripleDESCryptoServiceProvider();
            tDESkey.Key = Convert.FromBase64String(CRYPT_KEY);
            ed2.LoadXml(encryptedElement);
            var exml2 = new EncryptedXml();
            var decryptedBilling = exml2.DecryptData(ed2, tDESkey);
            
            exml2.ReplaceData(encryptedElement, decryptedBilling);
        }

        public static DataSet EncryptDataset(DataSet ds)
        {
            var doc = new XmlDocument();
            var ret = new DataSet();

            try
            {
                doc.LoadXml(ds.GetXml());
                EncryptXMLDoc(ref doc);
                ret.ReadXml(new XmlNodeReader(doc));
                return ret;
            }
            catch
            {
                return null;
            }
        }

        public static DataSet DecryptXMLDataset(string xml)
        {
            var doc = new XmlDocument();
            var ret = new DataSet();

            try
            {
                doc.LoadXml(xml);
                DecryptXMLDoc(ref doc);
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
