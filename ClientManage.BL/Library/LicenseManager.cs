using ClientManage.Interfaces;
using System;

namespace ClientManage.BL.Library
{
    public static class LicenseManager
    {
        public static CustomerLicense CheckForEndLicenseOnline()
        {
            var result = WebServices.GetOnlineLicense();
            if (result == null)
            {
                result = new CustomerLicense { Allow = false };
            }

            if (result.Allow)
            {
                result.Status = LicenseStatus.Valid;
            }
            else
            {
                result.Status = LicenseStatus.Block;
            }

            var date = DateTimeUtil.GetServerDateTime().Date;
            result.ServerDate = date;

            if (result.Status == LicenseStatus.Valid)
            {
                if (result.From > date || result.To < date)
                {
                    result.Status = LicenseStatus.OutOfDate;
                }

                var expireDays = Convert.ToInt32(Math.Floor(result.To.Subtract(result.ServerDate).TotalDays));
                result.ExpireDays = expireDays;
            }

            return result;
        }
    }
}