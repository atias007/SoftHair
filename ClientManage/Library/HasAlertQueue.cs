using ClientManage.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManage.Library
{
    internal static class HasAlertQueue
    {
        private const string paramKey = "SMS_HasAlertQueue";

        public static void Add(string id)
        {
            var list = AllItems;
            list.Add(id);
            SaveValue(list);
        }

        public static void Flush()
        {
            var fails = new List<string>();

            foreach (var item in AllItems)
            {
                try
                {
                    SmsHelper.UpdateCalendarAlert(item);
                }
                catch
                {
                    fails.Add(item);
                }
            }

            SaveValue(fails);
        }

        public static bool Contains(string id)
        {
            return AllItems.Contains(id);
        }

        private static List<string> AllItems
        {
            get
            {
                var value = AppSettingsHelper.GetParamValue(paramKey);
                return string.IsNullOrEmpty(value) ? new List<string>() : value.Split(',').ToList();
            }
        }

        private static void SaveValue(List<string> items)
        {
            var value = string.Join(",", items);
            AppSettingsHelper.SetParamValue(paramKey, value, true);
        }
    }
}