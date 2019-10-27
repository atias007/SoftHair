using System;
using ClientManage.BL;
using ClientManage.Interfaces;

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
            return result;
        }

        public static OnlineLicenseStatus GetLicenseOnline()
        {
            var clientId = AppSettingsHelper.GetParamValue<int>("APP_CLIENT_ID");
            var result = WebServices.GetOnlineLicense(clientId);
            if (result == null) return OnlineLicenseStatus.None;
            if (result.Allow == false) return OnlineLicenseStatus.Block;
            else return OnlineLicenseStatus.Valid;
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