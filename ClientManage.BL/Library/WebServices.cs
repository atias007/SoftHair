using ClientManage.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace ClientManage.BL.Library
{
    public static class WebServices
    {
        public static CustomerLicense GetOnlineLicense()
        {
            var clientId = AppSettingsHelper.GetParamValue<int>("APP_CLIENT_ID");

            try
            {
                var all = ReadFile(@"https://raw.githubusercontent.com/atias007/SoftHair/master/softhair_license.txt");
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
                var all = ReadFile($@"https://raw.githubusercontent.com/atias007/SoftHair/master/softhair_credit_{clientId}.txt");
                var lines = all.Trim().Split('\n').ToList();

                var credits = lines.Select(l => new SmsCredit(l.Trim())).ToList();

                return credits;
            }
            catch (Exception)
            {
                return new List<SmsCredit>();
            }
        }

        private static string ReadFile(string path)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "C# console program");

                var content = client.GetStringAsync(path);
                return content.Result;
            }
        }
    }
}