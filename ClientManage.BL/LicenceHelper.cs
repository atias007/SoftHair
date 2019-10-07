using ClientManage.Data;
using ClientManage.Interfaces;
using System;
using System.Data;

namespace ClientManage.BL
{
    public class LicenceHelper
    {
        // add license row to license tables
        public static bool AddLicense(string key)
        {
            return (LicenceData.AddLicense(key) == 1);
        }

        // read the last license from licenses table
        public static string GetLicenseKey()
        {
            var ret = LicenceData.GetLicense();
            if (string.IsNullOrEmpty(ret))
            {
                ret = CreateTempLicense();
            }
            return ret;
        }

        private static string CreateTempLicense()
        {
            var licence = Security.GetNewLicense();
            var row = licence.License[0];

            row.cpu_id = Security.CpuId;
            row.from_date = DateTime.Now.Date.AddDays(-1);
            row.to_date = DateTime.Now.Date.AddDays(7);
            row.last_used = DateTime.Now.Date;
            row.type = "Standard";
            row.key = "1";

            var key = Security.SaveLicence(licence);
            AddLicense(key);
            var result = LicenceData.GetLicense();
            return result;
        }

        // Update license key
        public static bool UpdateLicense(string key)
        {
            return (LicenceData.UpdateLicense(key) == 1);
        }

        public static DataTable GetAllLicences()
        {
            return LicenceData.GetAllLicences().Tables[0];
        }

        public static bool UpdateLicense(int id, string key)
        {
            return LicenceData.UpdateLicense(id, key) > 0;
        }

        public static bool DeleteLicense(int id)
        {
            return LicenceData.DeleteLicense(id) > 0;
        }

        public static void ClearAllLicenses()
        {
            LicenceData.ClearAllLicenses();
        }
    }
}