using ClientManage.Interfaces;
using System;
using System.Data;

namespace ClientManage.Data
{
    public class SmsData
    {
        public static DataTable GetSMSMessages()
        {
            var cmd = My.Database.GetStoredProcCommand("spGetSMSMessages");
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds.Tables[0];
        }

        public static void DeleteSMSMessage(int id)
        {
            var cmd = My.Database.GetStoredProcCommand("spDeleteSMSMessage");
            My.Database.AddInParameter(cmd, "id", DbType.Int32, id);
            My.Database.ExecuteNonQuery(cmd);
        }

        public static void AddSMSMessage(string title, string msg)
        {
            var cmd = My.Database.GetStoredProcCommand("spAddSMSMessage");
            My.Database.AddInParameter(cmd, "title", DbType.String, title);
            My.Database.AddInParameter(cmd, "msg", DbType.String, msg);
            My.Database.ExecuteNonQuery(cmd);
        }

        public static int IsSMSTitleExist(string title)
        {
            var cmd = My.Database.GetStoredProcCommand("spIsSMSTitleExist");
            My.Database.AddInParameter(cmd, "title", DbType.String, title);
            var ret = Convert.ToInt32(My.Database.ExecuteScalar(cmd));
            return ret;
        }

        public static void UpdateSMSMessage(string title, string msg)
        {
            var cmd = My.Database.GetStoredProcCommand("spUpdateSMSMessage");
            My.Database.AddInParameter(cmd, "msg", DbType.String, msg);
            My.Database.AddInParameter(cmd, "title", DbType.String, title);
            My.Database.ExecuteNonQuery(cmd);
        }

        public static string GetSavedMessage(int id)
        {
            var cmd = My.Database.GetStoredProcCommand("SMS_GetSavedMessage");

            My.Database.AddInParameter(cmd, "?id", DbType.Int32, id);

            var msg = Convert.ToString(My.Database.ExecuteScalar(cmd));
            return msg;
        }

        public static bool LoadCredit(int id, int credit)
        {
            if (IsCreditExists(id)) return false;

            var query = "INSERT INTO [SmsCredit] (Id, Credit, UpdateDate) VALUES([?id], [?credit], [?update_date])";
            var cmd = My.Database.GetSqlStringCommand(query);
            My.Database.AddInParameter(cmd, "[?id]", DbType.Int32, id);
            My.Database.AddInParameter(cmd, "[?credit]", DbType.Int32, credit);
            My.Database.AddInParameter(cmd, "[?update_date]", DbType.DateTime, Utils.GetDateTimeValueForDB(DateTime.Now));
            var count = My.Database.ExecuteNonQuery(cmd);
            return count > 0;
        }

        public static void AddSmsLog(SmsMessage message, int credit, int totalCredit)
        {
            //var totlaCredit = AppSettingsHelper.GetParamValue<int>("SMS_CREDIT_VALUE");
            var query = "INSERT INTO SmsSendLog(MessageText,ToPhone,FromPhone,Credit,TotalCredit,SendDate) VALUES ([?MessageText],[?ToPhone],[?FromPhone],[?Credit],[?TotalCredit],[?SendDate])";
            var cmd = My.Database.GetSqlStringCommand(query);
            My.Database.AddInParameter(cmd, "[?MessageText]", DbType.String, message.MessageText);
            My.Database.AddInParameter(cmd, "[?ToPhone]", DbType.String, message.ToPhone);
            My.Database.AddInParameter(cmd, "[?FromPhone]", DbType.String, message.FromPhone);
            My.Database.AddInParameter(cmd, "[?Credit]", DbType.Int32, credit);
            My.Database.AddInParameter(cmd, "[?TotalCredit]", DbType.Int32, totalCredit);
            My.Database.AddInParameter(cmd, "[?SendDate]", DbType.DateTime, Utils.GetDateTimeValueForDB(DateTime.Now));
            My.Database.ExecuteNonQuery(cmd);
        }

        private static bool IsCreditExists(int id)
        {
            var query = "SELECT COUNT(*) FROM [SmsCredit] WHERE [Id]=[?id]";
            var cmd = My.Database.GetSqlStringCommand(query);
            My.Database.AddInParameter(cmd, "[?id]", DbType.Int32, id);
            var result = Convert.ToInt32(My.Database.ExecuteScalar(cmd));
            return result > 0;
        }
    }
}