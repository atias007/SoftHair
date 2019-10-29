using ClientManage.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ClientManage.BL.Library
{
    public static class WebServices
    {
        public static CustomerLicense GetOnlineLicense()
        {
            // TODO: ***

            var clientId = AppSettingsHelper.GetParamValue<int>("APP_CLIENT_ID");

            try
            {
                var all = File.ReadAllText(@"C:\Temp\CM\softhair_license.txt");
                var lines = all.Trim().Split('\n').ToList();

                var licensces = lines.Select(l => new CustomerLicense(l.Trim()));
                var current = licensces.FirstOrDefault(l => l.ClientId == clientId);
                if (current == null)
                {
                    current = new CustomerLicense();
                }

                return current;
            }
            catch (Exception)
            {
                return new CustomerLicense { Allow = true, From = DateTime.Now.AddDays(-1), To = DateTime.Now.AddMonths(3) };
            }
        }

        public static List<SmsCredit> GetOnlineCredit()
        {
            var clientId = AppSettingsHelper.GetParamValue<int>("APP_CLIENT_ID");

            try
            {
                var all = File.ReadAllText(@"C:\Temp\CM\softhair_credit.txt");
                var lines = all.Trim().Split('\n').ToList();

                var credits = lines.Select(l => new SmsCredit(l.Trim())).ToList();
                var result = credits.Where(l => l.ClientId == clientId).ToList();

                return result;
            }
            catch (Exception)
            {
                return new List<SmsCredit>();
            }
        }
    }
}