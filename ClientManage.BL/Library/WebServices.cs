using ClientManage.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace ClientManage.BL.Library
{
    public static class WebServices
    {
        public static CustomerLicense GetOnlineLicense()
        {
            CustomerLicense result;

            try
            {
                var json = AppSettingsHelper.GetParamValue("APP_LICENSE");
                if (string.IsNullOrEmpty(json)) { throw new NullReferenceException("json is null"); }
                result = JsonConvert.DeserializeObject<CustomerLicense>(json);
            }
            catch (Exception)
            {
                result = new CustomerLicense { Allow = true, From = DateTime.Now.AddDays(-1), To = DateTime.Now.AddDays(7) };
                var json = JsonConvert.SerializeObject(result);
                AppSettingsHelper.SetParamValue("APP_LICENSE", json, true);
            }

            System.Threading.Tasks.Task.Run(new Action(SetLicense));

            return result;
        }

        public static void SetLicense()
        {
            var clientId = AppSettingsHelper.GetParamValue<int>("APP_CLIENT_ID");
            var all = ReadFile(@"https://raw.githubusercontent.com/atias007/SoftHair/master/softhair_license.txt");
            var lines = all.Trim().Split('\n').ToList();

            var licensces = lines.Select(l => new CustomerLicense(l.Trim()));
            var current = licensces.FirstOrDefault(l => l.ClientId == clientId);
            if (current != null)
            {
                var json = JsonConvert.SerializeObject(current);
                AppSettingsHelper.SetParamValue("APP_LICENSE", json, true);
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
                client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");

                var content = client.GetStringAsync(path);
                return content.Result;
            }
        }
    }
}