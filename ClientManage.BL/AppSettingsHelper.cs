using ClientManage.Data;
using System;
using System.Collections.Generic;

namespace ClientManage.BL
{
    public class AppSettingsHelper
    {
        private static bool _throwInvalidParamCast;

        public static bool ThrowInvalidParamCast
        {
            get { return _throwInvalidParamCast; }
            set { _throwInvalidParamCast = value; }
        }

        public static T GetParamValue<T>(string key)
        {
            var value = AppSettingsData.GetParamValue(key) ?? AppSettingsData.CreateValue<T>(key);

            var newValue = default(T);
            try
            {
                newValue = (T)Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                if (_throwInvalidParamCast) throw;
            }

            return newValue;
        }

        public static string GetParamValue(string key)
        {
            return GetParamValue<string>(key);
        }

        public static bool SetParamValue(string key, object value)
        {
            return SetParamValue(key, value, true);
        }

        public static bool SetParamValue(string key, object value, bool online)
        {
            var result = 0;

            if (value != null && value.ToString().Equals(GetParamValue<string>(key))) return true;
            if (value != null)
            {
                result = AppSettingsData.SetValue(key, value.ToString());
                if (online) AppSettingsData.SetOnlineValue(key, value.ToString());
            }

            return result > 0;
        }

        public static void ResetParams()
        {
            AppSettingsData.ResetParams();
        }

        public static void ClearHistory()
        {
            var last = GetParamValue<DateTime>("HISTORY_LAST_CLEAR");
            var ts = DateTime.Now.Subtract(last);

            if (ts.TotalDays >= 30)
            {
                AppSettingsData.ClearHistory();
                AppSettingsData.SetValue("HISTORY_LAST_CLEAR", DateTime.Now.ToString("dd/MM/yyyy"));
            }
        }

        public static void SetCustomDatabase(object db)
        {
            My.SetCustomDatabase(db);
        }

        public static string GetPrintTemplate(string key)
        {
            return AppSettingsData.GetPrintTemplate(key);
        }

        public static string GetPrintDefaultForm()
        {
            return AppSettingsData.GetPrintTemplate("DEFAULT_FORM");
        }

        public static void CheckDbConnection()
        {
            AppSettingsData.CheckDbConnection();
        }

        public static void MixDatabase()
        {
            AppSettingsData.MixDatabase();
        }

        private const string SyncDeletedClientsKey = "SYNC_DELETEDCLIENTS";

        public static List<int> GetDeletedClients()
        {
            var result = new List<int>();
            var deleted = GetParamValue(SyncDeletedClientsKey).Split(',');
            foreach (var d in deleted)
            {
                int value;
                if (int.TryParse(d, out value))
                {
                    result.Add(value);
                }
            }

            return result;
        }

        public static void AddDeletedClient(int id)
        {
            var deleted = GetParamValue(SyncDeletedClientsKey);
            deleted += id + ",";
            SetParamValue(SyncDeletedClientsKey, deleted);
        }

        public static void ClearDeletedClient()
        {
            SetParamValue(SyncDeletedClientsKey, string.Empty);
        }
    }
}