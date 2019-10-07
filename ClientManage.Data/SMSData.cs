using ClientManage.Interfaces;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Text;

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

        //public static void SaveLog(SMSLog log)
        //{
        //    DbCommand cmd = My.Database.GetStoredProcCommand("SMS_SaveLog");

        //    My.Database.AddInParameter(cmd, "?date_send", DbType.DateTime, Utils.GetDateTimeValueForDB(log.DateSend));
        //    My.Database.AddInParameter(cmd, "?message_status", DbType.Boolean, log.Status);
        //    My.Database.AddInParameter(cmd, "?message_text", DbType.String, log.Text);
        //    My.Database.AddInParameter(cmd, "?phone_no", DbType.String, log.PhoneNo);
        //    My.Database.AddInParameter(cmd, "?message_type", DbType.Int32, Convert.ToInt32(log.MessageType));

        //    My.Database.ExecuteNonQuery(cmd);
        //}

        public static string GetSavedMessage(int id)
        {
            var cmd = My.Database.GetStoredProcCommand("SMS_GetSavedMessage");

            My.Database.AddInParameter(cmd, "?id", DbType.Int32, id);

            var msg = Convert.ToString(My.Database.ExecuteScalar(cmd));
            return msg;
        }

        //public static DataSet GetCalendarSms(DateTime fromDate, DateTime toDate)
        //{
        //    //var cmd = My.Database.GetStoredProcCommand("SMS_GetCalendarSMS");
        //    //My.Database.AddInParameter(cmd, "[?from_date]", DbType.DateTime, Utils.GetDateTimeValueForDB(fromDate));
        //    //My.Database.AddInParameter(cmd, "[?to_date]", DbType.DateTime, Utils.GetDateTimeValueForDB(toDate));
        //    //var ds = My.Database.ExecuteDataSet(cmd);
        //    //return ds;
        //    var ds = GmailService.Instance.GetCalendarSms(fromDate, toDate);
        //    return ds;
        //}

        //public static DataSet GetCalendarSms(string appointmentId)
        //{
        //    var cmd = My.Database.GetStoredProcCommand("SMS_GetCalendarSMS2");
        //    My.Database.AddInParameter(cmd, "[?id]", DbType.Int32, Convert.ToInt32(appointmentId));
        //    var ds = My.Database.ExecuteDataSet(cmd);
        //    return ds;
        //}

        //public static void UpdateCalendarAlert(string id)
        //{
        //    //var cmd = My.Database.GetStoredProcCommand("SMS_UpdateCalendarAlert");
        //    //My.Database.AddInParameter(cmd, "[?id]", DbType.Int32, Convert.ToInt32(id));
        //    //var result = My.Database.ExecuteNonQuery(cmd);
        //    //return result;
        //    GmailService.Instance.SetAppoitmentHasAlert(id, false);
        //}

        public static int CheckCalendarFailSMS(string phone)
        {
            var cmd = My.Database.GetStoredProcCommand("SMS_CheckCalendarFailSMS");
            My.Database.AddInParameter(cmd, "[?phone_no]", DbType.String, phone);
            var count = Utils.GetDBValue<int>(My.Database.ExecuteScalar(cmd));
            return count;
        }

        //public static int ClearHasAlertBeforeUpdate(string id, DateTime startDate)
        //{
        //    //var cmd = My.Database.GetStoredProcCommand("SMS_ClearHasAlertBeforeUpdate");
        //    //My.Database.AddInParameter(cmd, "[?id]", DbType.Int32, Convert.ToInt32(id));
        //    //My.Database.AddInParameter(cmd, "[?date_start]", DbType.DateTime, startDate);
        //    //var count = My.Database.ExecuteNonQuery(cmd);
        //    //return count;

        //    return 0;
        //}
    }
}