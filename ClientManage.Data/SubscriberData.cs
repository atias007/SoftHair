using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using ClientManage.Interfaces;
using System.Data;

namespace ClientManage.Data
{
    public class SubscriberData
    {
        public static DataSet GetSubscriber(int id)
        {
            var cmd = My.Database.GetStoredProcCommand("sub_GetSubscriber");
            My.Database.AddInParameter(cmd, "[?id]", DbType.Int32, id);
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }

        public static int AddSubscriber(Subscriber subscriber)
        {
            var id = -1;
            var cmd = My.Database.GetStoredProcCommand("sub_AddSubscriber");
            AddCommandParamaters(cmd, subscriber);
            if (My.Database.ExecuteNonQuery(cmd) > 0)
            {
                var sql = "SELECT MAX(id) FROM tblSubscribers";
                id = Convert.ToInt32(My.Database.ExecuteScalar(CommandType.Text, sql));
            }
            return id;
        }

        public static int UpdateSubscriber(Subscriber subscriber)
        {
            var cmd = My.Database.GetStoredProcCommand("sub_UpdateSubscriber");
            AddCommandParamaters(cmd, subscriber);
            My.Database.AddInParameter(cmd, "[?id]", DbType.Int32, subscriber.Id);
            var count = My.Database.ExecuteNonQuery(cmd);
            return count;
        }

        public static int DeleteSubscriber(int id)
        {
            var cmd = My.Database.GetStoredProcCommand("sub_DeleteSubscriber");
            My.Database.AddInParameter(cmd, "[?id]", DbType.Int32, id);
            return My.Database.ExecuteNonQuery(cmd);
        }

        private static void AddCommandParamaters(DbCommand cmd, Subscriber subscriber)
        {
            My.Database.AddInParameter(cmd, "[?client_id]", DbType.Int32, subscriber.ClientId);
            My.Database.AddInParameter(cmd, "[?sub_name]", DbType.String, subscriber.Name);
            My.Database.AddInParameter(cmd, "[?type]", DbType.Int32, Convert.ToInt32(subscriber.Type));
            My.Database.AddInParameter(cmd, "[?cares]", DbType.String, subscriber.Cares);
            My.Database.AddInParameter(cmd, "[?status_id]", DbType.Int32, Convert.ToInt32(subscriber.Status));
            My.Database.AddInParameter(cmd, "[?from_date]", DbType.DateTime, subscriber.FromDate);
            My.Database.AddInParameter(cmd, "[?to_date]", DbType.DateTime, subscriber.ToDate);
            My.Database.AddInParameter(cmd, "[?amount]", DbType.Int32, subscriber.Amount);
            My.Database.AddInParameter(cmd, "[?discount]", DbType.Decimal, subscriber.Discount);
            My.Database.AddInParameter(cmd, "[?remark]", DbType.String, subscriber.Remark);
            My.Database.AddInParameter(cmd, "[?date_create]", DbType.DateTime, Utils.FixEntLibDateTime(subscriber.DateCreate));
        }

        public static DataSet GetSubscriberUsages(int subscriberId)
        {
            var cmd = My.Database.GetStoredProcCommand("sub_GetSubscriberUsages");
            My.Database.AddInParameter(cmd, "[?subscriber_id]", DbType.Int32, subscriberId);
            var ds = new DataSet();
            My.Database.LoadDataSet(cmd, ds, "SubscriberUsages");
            return ds;
        }

        public static int SaveSubscriberUsages(DataSet ds)
        {
            var updateCommand = My.Database.GetStoredProcCommand("sub_UpdateUsageRemark");
            My.Database.AddInParameter(updateCommand, "[?remark]", DbType.String, "remark", DataRowVersion.Current);
            My.Database.AddInParameter(updateCommand, "[?id]", DbType.Int32, "id", DataRowVersion.Current);

            var deleteCommand = My.Database.GetStoredProcCommand("sub_DeleteSubscriberUsage");
            My.Database.AddInParameter(deleteCommand, "[?id]", DbType.Int32, "id", DataRowVersion.Original);
            My.Database.AddInParameter(deleteCommand, "[?id]", DbType.Int32);
            int count;
            foreach (DataRow row in ds.Tables["SubscriberUsages"].Rows)
            {
                if (row.RowState == DataRowState.Deleted)
                {
                    My.Database.SetParameterValue(deleteCommand, "[?id]", row["id", DataRowVersion.Original]);
                    count = My.Database.ExecuteNonQuery(deleteCommand);
                }
            }
            for (var i = 0; i < ds.Tables["SubscriberUsages"].Rows.Count; i++)
            {
                if (ds.Tables["SubscriberUsages"].Rows[i].RowState == DataRowState.Deleted)
                {
                    ds.Tables["SubscriberUsages"].Rows.RemoveAt(i--);
                }
            }

            var rowsAffected = My.Database.UpdateDataSet(ds, "SubscriberUsages", null, updateCommand, null, UpdateBehavior.Standard);
            return rowsAffected;
        }

        public static int AddSubscriberUsage(int subscriberId)
        {
            var cmd = My.Database.GetStoredProcCommand("sub_AddSubscriberUsage");
            My.Database.AddInParameter(cmd, "[?subscriber_id]", DbType.Int32, subscriberId);
            My.Database.AddInParameter(cmd, "[?date_usage]", DbType.DateTime, Utils.FixEntLibDateTime(DateTime.Now));
            return My.Database.ExecuteNonQuery(cmd);
        }

        public static int UpdateSubscriberStatus(int id, int status)
        {
            var cmd = My.Database.GetStoredProcCommand("sub_UpdateSubscriberStatus");
            My.Database.AddInParameter(cmd, "[?status_id]", DbType.Int32, status);
            My.Database.AddInParameter(cmd, "[?id]", DbType.Int32, id);
            var count = My.Database.ExecuteNonQuery(cmd);
            return count;
        }

        public static int DeleteSubscriberUsage(int id)
        {
            var cmd = My.Database.GetStoredProcCommand("sub_DeleteSubscriberUsage");
            My.Database.AddInParameter(cmd, "[?id]", DbType.Int32, id);
            return My.Database.ExecuteNonQuery(cmd);
        }

        public static DataSet GetSubscriptionList(int clientId)
        {
            var cmd = My.Database.GetStoredProcCommand("sub_GetSubscriptionList");
            My.Database.AddInParameter(cmd, "[?client_id]", DbType.Int32, clientId);
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }

        public static int FrozeSubscribe(int id)
        {
            var cmd = My.Database.GetStoredProcCommand("sub_FrozeSubscribe");
            My.Database.AddInParameter(cmd, "[?id]", DbType.Int32, id);
            var count = My.Database.ExecuteNonQuery(cmd);
            return count;
        }

        public static int UnFrozeSubscribe(int id)
        {
            var cmd = My.Database.GetStoredProcCommand("sub_UnFrozeSubscriber");
            My.Database.AddInParameter(cmd, "[?id]", DbType.Int32, id);
            var count = My.Database.ExecuteNonQuery(cmd);
            return count;
        }

        public static int GetUsageCount(int subscriberId)
        {
            var cmd = My.Database.GetStoredProcCommand("sub_GetUsageCount");
            My.Database.AddInParameter(cmd, "subscriber_id", DbType.Int32, subscriberId);
            var count = Convert.ToInt32(My.Database.ExecuteScalar(cmd));
            return count;
        }

        public static int GetAmount(int id)
        {
            var cmd = My.Database.GetStoredProcCommand("sub_GetAmount");
            My.Database.AddInParameter(cmd, "id", DbType.Int32, id);
            var count = Convert.ToInt32(My.Database.ExecuteScalar(cmd));
            return count;
        }

        public static void SetAllStatus()
        {
            var sql1 = "UPDATE tblSubscribers SET status_id = 3 WHERE to_date Is Not Null AND to_date < Now() AND status_id = 1";
            var sql2 = "UPDATE tblSubscribers SET status_id = 1 WHERE from_date <= Now() AND status_id = 2";
            My.Database.ExecuteNonQuery(CommandType.Text, sql1);
            My.Database.ExecuteNonQuery(CommandType.Text, sql2);
        }
    }
}
