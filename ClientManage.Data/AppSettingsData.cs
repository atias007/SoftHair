using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Collections;
using ClientManage.Interfaces;

namespace ClientManage.Data
{
    public class AppSettingsData
    {
        private static Hashtable _params = null;
        private static Hashtable _cache;

        public static Hashtable Cache
        {
            get { return _cache ?? (_cache = new Hashtable()); }
        }

        public static string GetParamValue(string key)
        {
            if (_params == null) LoadParams();
            return Utils.GetDBValue<string>(_params[key]);
        }

        public static int SetValue(string key, string value)
        {
            var cmd = My.Database.GetStoredProcCommand("spUpdateParameter");
            My.Database.AddInParameter(cmd, "value", DbType.String, value);
            My.Database.AddInParameter(cmd, "name", DbType.String, key);
            return My.Database.ExecuteNonQuery(cmd);
        }

        public static string CreateValue<T>(string key)
        {
            var value = default(T);
            var sql = string.Format("INSERT INTO tblParams (param_value, param_name) VALUES ('{0}', '{1}')", value, key);
            var cmd = My.Database.GetSqlStringCommand(sql);
            var count = My.Database.ExecuteNonQuery(cmd);
            if(count == 0) throw new ApplicationException("Error creating new parameter value in database");
            LoadParams();
            
            return GetParamValue(key);
        }

        public static void SetOnlineValue(string key, string value)
        {
            _params[key] = value;
        }

        private static void LoadParams()
        {
            var cmd = My.Database.GetStoredProcCommand("spGetParams");
            var ds = My.Database.ExecuteDataSet(cmd);
            _params = new Hashtable(ds.Tables[0].Rows.Count);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                _params.Add(row["param_name"].ToString(), row["param_value"]);
            }
        }

        public static void ClearHistory()
        {
            DbCommand cmd;
            var list = new List<Exception>();

            try
            {
                cmd = My.Database.GetStoredProcCommand("spClearOldCalendar");
                My.Database.AddInParameter(cmd, "clear_month", DbType.Int32, Convert.ToInt32(AppSettingsData.GetParamValue("HISTORY_CLEAR_CALENDAR")));
                My.Database.ExecuteNonQuery(cmd);
            }
            catch (Exception ex) 
            {
                EventLogData.AddEvent(new LogInfo(LogInfo.LogType.Error, "Fail to clear history appointments", Utils.GetExceptionMessage(ex)));
            }

            try
            {
                cmd = My.Database.GetStoredProcCommand("spClearCallLog");
                My.Database.AddInParameter(cmd, "clear_month", DbType.Int32, Convert.ToInt32(AppSettingsData.GetParamValue("HISTORY_CLEAR_CALLLOG")));
                My.Database.ExecuteNonQuery(cmd);
            }
            catch (Exception ex) 
            {
                EventLogData.AddEvent(new LogInfo(LogInfo.LogType.Error, "Fail to clear history call log", Utils.GetExceptionMessage(ex)));
            }

            try
            {
                cmd = My.Database.GetStoredProcCommand("spClearWorkersTraffic");
                My.Database.AddInParameter(cmd, "clear_month", DbType.Int32, Convert.ToInt32(AppSettingsData.GetParamValue("HISTORY_CLEAR_TRAFFIC")));
                My.Database.ExecuteNonQuery(cmd);
            }
            catch (Exception ex) 
            {
                EventLogData.AddEvent(new LogInfo(LogInfo.LogType.Error, "Fail to clear history traffic", Utils.GetExceptionMessage(ex)));
            }

            try
            {
                cmd = My.Database.GetStoredProcCommand("spClearSmsLog");
                My.Database.AddInParameter(cmd, "clear_month", DbType.Int32, Convert.ToInt32(AppSettingsData.GetParamValue("HISTORY_CLEAR_SMS")));
                My.Database.ExecuteNonQuery(cmd);
            }
            catch (Exception ex) 
            {
                EventLogData.AddEvent(new LogInfo(LogInfo.LogType.Error, "Fail to clear history sms log", Utils.GetExceptionMessage(ex)));
            }

            try
            {
                cmd = My.Database.GetStoredProcCommand("spClearEventLog");                
                My.Database.ExecuteNonQuery(cmd);
            }
            catch (Exception ex) 
            {
                EventLogData.AddEvent(new LogInfo(LogInfo.LogType.Error, "Fail to clear history event log", Utils.GetExceptionMessage(ex)));
            }
        }

        public static void ResetParams()
        {
            _params = null;
        }

        public static string GetPrintTemplate(string key)
        {
            var cmd = My.Database.GetStoredProcCommand("spGetPrintTemplate");
            My.Database.AddInParameter(cmd, "[?key]", DbType.String, key);
            var temp = Convert.ToString(My.Database.ExecuteScalar(cmd));
            return temp;
        }

        public static void CheckDbConnection()
        {
            var conn = My.Database.CreateConnection();
            conn.Open();
            conn.Close();
        }

        public static void MixDatabase()
        {
            var sql = "SELECT * FROM tblClients";
            var sql2 = "UPDATE tblClients SET first_name = [?first_name], last_name = [?last_name], city = [?city], address = [?address] where id=[?id]";
            var cmd = My.Database.GetSqlStringCommand(sql);
            var ds = My.Database.ExecuteDataSet(cmd);
            int id1, id2, id3;
            var rnd = new Random();

            var cmd2 = My.Database.GetSqlStringCommand(sql2);
            My.Database.AddInParameter(cmd2, "[?first_name]", DbType.String);
            My.Database.AddInParameter(cmd2, "[?last_name]", DbType.String);
            My.Database.AddInParameter(cmd2, "[?city]", DbType.String);
            My.Database.AddInParameter(cmd2, "[?address]", DbType.String);
            My.Database.AddInParameter(cmd2, "[?id]", DbType.Int32);

            for(var i=0; i< ds.Tables[0].Rows.Count; i++)
            {
                id1 = rnd.Next(ds.Tables[0].Rows.Count - 1);
                id2 = rnd.Next(ds.Tables[0].Rows.Count - 1);
                id3 = rnd.Next(ds.Tables[0].Rows.Count - 1);
                id3 = rnd.Next(ds.Tables[0].Rows.Count - 1);
                cmd2.Parameters[0].Value = ds.Tables[0].Rows[id1]["first_name"];
                cmd2.Parameters[1].Value = ds.Tables[0].Rows[id1]["last_name"];
                cmd2.Parameters[2].Value = ds.Tables[0].Rows[id2]["city"];
                cmd2.Parameters[3].Value = ds.Tables[0].Rows[id3]["address"];
                cmd2.Parameters[4].Value = ds.Tables[0].Rows[i]["id"];
                My.Database.ExecuteNonQuery(cmd2);
            }
        }
    }
}
