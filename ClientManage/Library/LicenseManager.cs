using System;
using ClientManage.BL;
using ClientManage.Interfaces;
using ClientManage.SmsFactoryCommon;

namespace ClientManage.Library
{
    public static class LicenseManager
    {
        public enum OnlineLicenseStatus { None, Valid, Block }

        /// <summary>
        /// Checks for end license online.
        /// </summary>
        /// <returns></returns>
        public static OnlineLicenseStatus CheckForEndLicenseOnline()
        {
            var result = GetLicenseOnline();
            return result.Item2;
        }

        public static Tuple<CustomerLicense, OnlineLicenseStatus> GetLicenseOnline()
        {
            var result = WebServices.GetOnlineLicense();
            if (result == null) return new Tuple<CustomerLicense, OnlineLicenseStatus> (null, OnlineLicenseStatus.None);
            if (result.CustomerStatus == 0) return new Tuple<CustomerLicense, OnlineLicenseStatus> (result, OnlineLicenseStatus.Block);

            var lic = Utils.CurrentLicense.License[0];

            if (string.IsNullOrEmpty(result.LicenseKey) || result.LicenseKey == lic.cpu_id)
            {
                if (result.FromDate == null || result.FromDate.Value <= DateTime.Now.Date)
                {
                    if (result.ToDate == null || result.ToDate >= DateTime.Now.Date)
                    {
                        var from = result.FromDate.HasValue ? result.FromDate.Value : result.ServerDate.AddMonths(-1).AddDays(-result.ServerDate.Day + 1);
                        var to = result.ToDate.HasValue ? result.ToDate.Value : result.ServerDate.AddMonths(3).AddDays(-result.ServerDate.Day + 1);
                        UpdateLicense(from, to);
                        return new Tuple<CustomerLicense, OnlineLicenseStatus>(result, OnlineLicenseStatus.Valid);
                    }
                }
            }

            return new Tuple<CustomerLicense, OnlineLicenseStatus> (result, OnlineLicenseStatus.Block);
        }

        /// <summary>
        /// Updates the license.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        private static void UpdateLicense(DateTime fromDate, DateTime toDate)
        {
            var key = Security.UpdateLicense(Utils.CurrentLicense, fromDate, toDate);
            if (key != null)
            {
                LicenceHelper.UpdateLicense(key);
            }
        }

        /// <summary>
        /// Updates the license.
        /// </summary>
        /// <param name="cpuId">The CPU id.</param>
        public static void UpdateLicense(string cpuId)
        {
            var key = Security.UpdateLicense(Utils.CurrentLicense, cpuId);
            if (key != null)
            {
                LicenceHelper.UpdateLicense(key);
            }
        }
    }
}
