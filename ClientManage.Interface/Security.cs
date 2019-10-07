using System;
using System.Data;
using System.Management;
using ClientManage.Interfaces.Schemas;
using System.Xml;

namespace ClientManage.Interfaces
{
    public class Security
    {
        private static Exception _lastException;
        private static string _cpuId;
        public enum ValidationResult { Ok, WrongCpuId, NowBeforeStart, NowAfterEnd, DateTraceError, LicenseNotFound, SoonExpire }

        public static Exception LastException
        {
            get { return _lastException; }
        }

        public static string CpuId
        {
            get
            {
                if (string.IsNullOrEmpty(_cpuId))
                {
                    var keyType = RegistryFactory.Read("KEYTYPE");

                    if (string.IsNullOrEmpty(keyType))
                    {
                        _cpuId = GetCpuId();
                        if (_cpuId.Length == 0)
                        {
                            _cpuId = GetVolumeSerial();
                            if (_cpuId.Length == 0)
                            {
                                _cpuId = GetNetworkMacAddress();
                                if (_cpuId.Length == 0)
                                {
                                    _cpuId = string.Empty;
                                }
                                else
                                {
                                    RegistryFactory.Write("KEYTYPE", "MAC");
                                }
                            }
                            else
                            {
                                RegistryFactory.Write("KEYTYPE", "VOL");
                            }
                        }
                        else
                        {
                            RegistryFactory.Write("KEYTYPE", "CPU");
                        }
                    }
                    else
                    {
                        switch (keyType)
                        {
                            default:
                            //case "CPU":
                                _cpuId = GetCpuId(); 
                                break;

                            case "MAC":
                                _cpuId = GetNetworkMacAddress();
                                break;

                            case "VOL":
                                _cpuId = GetVolumeSerial();
                                break;
                        }
                    }
                }
                return _cpuId;
            }
        }

        public static void ClearCpuId()
        {
            _cpuId = null;
        }

        private static string GetCpuId()
        {
            var ret = string.Empty;
            try
            {
                var theClass = new ManagementClass("Win32_Processor");
                var theCollectionOfResults = theClass.GetInstances();

                foreach (ManagementObject currentResult in theCollectionOfResults)
                {
                    if (ret.Length == 0)
                    {
                        ret = currentResult.Properties["ProcessorId"].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                _lastException = ex;
            }

            return ret;
        }

        private static string GetVolumeSerial()
        {
            var disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
            disk.Get();
            return disk["VolumeSerialNumber"].ToString();
        }

        private static string GetNetworkMacAddress()
        {
            var mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            var moc = mc.GetInstances();
            var macAddress = String.Empty;
            foreach (ManagementObject mo in moc)
            {
                if (macAddress == String.Empty)  // only return MAC Address from first card
                {
                    if ((bool)mo["IPEnabled"]) macAddress = mo["MacAddress"].ToString();
                }
                mo.Dispose();
            }
            macAddress = macAddress.Replace(":", "");
            return macAddress;
        }

        public static ProductLicense GetLicense(string key)
        {
            var doc = new XmlDocument();
            var lcn = new ProductLicense();

            try
            {
                doc.LoadXml(key);
                Crypt.DecryptXMLDoc(ref doc);
                lcn.ReadXml(new XmlNodeReader(doc));
            }
            catch(Exception ex)
            {
                _lastException = ex;
                return null;
            }

            if (lcn.License.Rows.Count == 0) return null;
            return lcn;
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

            doc.LoadXml(licence.GetXml());
            Crypt.EncryptXMLDoc(ref doc);
            var ret = doc.OuterXml;
            return ret;
        }

        public static ValidationResult IsLicenseValid(ProductLicense license)
        {
            var row = license.License[0];
            ValidationResult ret;
            if (CpuId == row.cpu_id)
            {
                if (row.from_date <= DateTime.Now)
                {
                    if (row.to_date >= DateTime.Now)
                    {
                        if (row.last_used <= DateTime.Now && row.last_used >= row.from_date && row.last_used <= row.to_date)
                        {
                            ret = ValidationResult.Ok;
                        }
                        else
                        {
                            ret = ValidationResult.DateTraceError;
                        }
                    }
                    else
                    {
                        ret = ValidationResult.NowAfterEnd;
                    }
                }
                else
                {
                    ret = ValidationResult.NowBeforeStart;
                }
            }
            else
            {
                ret = ValidationResult.WrongCpuId;
            }

            return ret;
        }

        public static string UpdateLastDateUse(ProductLicense license)
        {
            license.License[0].last_used = DateTime.Now.Date;
            return SaveLicence(license);
        }

        public static string EndLicense(ProductLicense license)
        {
            license.License[0].to_date = DateTime.Now.Date.AddDays(-1);
            return SaveLicence(license);
        }

        public static string UpdateLicense(ProductLicense license, DateTime fromDate, DateTime toDate)
        {
            if (license.License[0].to_date != toDate || 
                license.License[0].from_date != fromDate ||
                license.License[0].last_used != DateTime.Now.Date)
            {
                license.License[0].to_date = toDate;
                license.License[0].from_date = fromDate;
                license.License[0].last_used = DateTime.Now.Date;
                return SaveLicence(license);
            }

            return null;
        }

        public static string UpdateLicense(ProductLicense license, string cpuId)
        {
            if (license.License[0].cpu_id != cpuId)
            {
                license.License[0].cpu_id = cpuId;
                return SaveLicence(license);
            }

            return null;
        }

        public static int DaysLeftInLicense(ProductLicense license)
        {
            var ts = license.License[0].to_date.Subtract(DateTime.Now);
            return ts.Days + 1;
        }

        public static DataSet EncryptReport(ReportSchema report)
        {
            return Crypt.EncryptDataset(report);
        }

        public static ReportSchema DecryptReport(string xml)
        {
            var report = new ReportSchema();
            var doc = new XmlDocument();

            try
            {
                doc.LoadXml(xml);
                Crypt.DecryptXMLDoc(ref doc);
                report.ReadXml(new XmlNodeReader(doc));
                return report;
            }
            catch
            {
                return null;
            }
        }

    }
}
