using ClientManage.Data;
using ClientManage.Interfaces;
using System;
using System.Data;

namespace ClientManage.BL
{
    public class SubscriberHelper
    {
        public static DataTable GetSubscriptionList(int clientId)
        {
            var table = SubscriberData.GetSubscriptionList(clientId).Tables[0];
            table.Columns.Add("c_remain_desc", typeof(string));
            table.Columns.Add("c_type_desc", typeof(string));
            FormatSubscriptionList(table);
            return table;
        }

        public static void FormatSubscriptionList(DataTable table)
        {
            FormatSubscriptionList(table, -1);
        }

        public static void FormatSubscriptionList(DataTable table, int id)
        {
            foreach (DataRow row in table.Rows)
            {
                if (id == -1 || id.Equals(row["id"])) FormatSubscriptionRow(row);
            }
        }

        private static void FormatSubscriptionRow(DataRow row)
        {
            int remain;
            var toDate = Utils.GetDBValue<DateTime?>(row, "to_date_real");
            var fromDate = Utils.GetDBValue<DateTime?>(row, "from_date");
            var iType = Utils.GetDBValue<int>(row, "type");
            var iStatus = Utils.GetDBValue<int>(row, "status_id");

            switch (iType)
            {
                case 1:
                    row["c_type_desc"] = "תקופתי";
                    if (iStatus == 1 || iStatus == 4) row["c_remain_desc"] = GetDateDiffDesc(DateTime.Now.Date, toDate);
                    else if (iStatus == 2) row["c_remain_desc"] = GetDateDiffDesc(fromDate, toDate);
                    else if (iStatus == 3) row["c_remain_desc"] = "מנוי הסתיים";
                    break;

                case 2:
                    row["c_type_desc"] = "כמותי";
                    if (iStatus == 3) row["c_remain_desc"] = "מנוי הסתיים";
                    else
                    {
                        remain = Utils.GetDBValue<int>(row, "amount") - Utils.GetDBValue<int>(row, "used");
                        row["c_remain_desc"] = remain + " ביקורים";
                    }
                    break;

                case 3:
                    row["c_type_desc"] = "כמותי / תקופתי";
                    if (iStatus == 3) row["c_remain_desc"] = "מנוי הסתיים";
                    else
                    {
                        remain = Utils.GetDBValue<int>(row, "amount") - Utils.GetDBValue<int>(row, "used");
                        row["c_remain_desc"] = remain + " ביקורים\r\n";
                        if (iStatus == 1 || iStatus == 4) row["c_remain_desc"] += GetDateDiffDesc(DateTime.Now.Date, toDate);
                        else if (iStatus == 2) row["c_remain_desc"] += GetDateDiffDesc(fromDate, toDate);
                    }
                    break;

                default:
                    break;
            }
        }

        private static string GetDateDiffDesc(DateTime? fromDate, DateTime? toDate)
        {
            string desc;

            if (fromDate.HasValue == false || toDate.HasValue == false) desc = "ללא הגבלה";
            else desc = DateUtils.GetDateDiffSum(fromDate.Value, toDate.Value).ToString();

            return desc;
        }

        public static DataSet GetSubscriberUsages(int subscriberId)
        {
            return SubscriberData.GetSubscriberUsages(subscriberId);
        }

        public static int GetUsageCount(int subscriberId)
        {
            var usage = SubscriberData.GetUsageCount(subscriberId);
            return usage;
        }

        public static bool AddSubscriberUsage(int subscriberId)
        {
            var ok = SubscriberData.AddSubscriberUsage(subscriberId) > 0;
            if (ok)
            {
                var amount = SubscriberData.GetAmount(subscriberId);
                if (amount > 0)
                {
                    var usage = SubscriberData.GetUsageCount(subscriberId);
                    if (usage >= amount)
                    {
                        UpdateSubscriberStatus(subscriberId, 3);
                    }
                }
            }
            return ok;
        }

        public static int SaveSubscriberUsages(DataSet ds)
        {
            var ret = -1;
            if (ds != null)
            {
                ret = SubscriberData.SaveSubscriberUsages(ds);
            }
            return ret;
        }

        public static bool UpdateSubscriberStatus(int id, int status)
        {
            return SubscriberData.UpdateSubscriberStatus(id, status) > 0;
        }

        public static bool FrozeSubscribe(int id)
        {
            return SubscriberData.FrozeSubscribe(id) > 0;
        }

        public static bool UnFrozeSubscribe(int id)
        {
            return SubscriberData.UnFrozeSubscribe(id) > 0;
        }

        public static void SetAllStatus()
        {
            SubscriberData.SetAllStatus();
        }

        public static Subscriber GetSubscriber(int id)
        {
            Subscriber sub = null;
            var table = SubscriberData.GetSubscriber(id).Tables[0];
            if (table.Rows.Count > 0) sub = GetSubscriberFromRow(table.Rows[0]);
            return sub;
        }

        private static Subscriber GetSubscriberFromRow(DataRow row)
        {
            var sub = new Subscriber
                          {
                              Amount = Utils.GetDBValue<int>(row, "amount"),
                              Cares = Utils.GetDBValue<string>(row, "cares"),
                              ClientId = Utils.GetDBValue<int>(row, "client_id"),
                              DateCreate = Utils.GetDBValue<DateTime>(row, "date_create"),
                              DateFrozen = Utils.GetDBValue<DateTime?>(row, "date_frozen"),
                              DateUpdate = Utils.GetDBValue<DateTime?>(row, "date_update"),
                              Discount = Utils.GetDBValue<decimal>(row, "discount"),
                              FromDate = Utils.GetDBValue<DateTime>(row, "from_date"),
                              Id = Utils.GetDBValue<int>(row, "id"),
                              Name = Utils.GetDBValue<string>(row, "sub_name"),
                              Remark = Utils.GetDBValue<string>(row, "remark"),
                              Status = (Subscriber.SubscribeStatus)Utils.GetDBValue<int>(row, "status_id"),
                              StatusTitle = Utils.GetDBValue<string>(row, "status_title"),
                              ToDate = Utils.GetDBValue<DateTime?>(row, "to_date"),
                              Type = (Subscriber.SubscribeType)Utils.GetDBValue<int>(row, "type")
                          };

            sub.ResetChanges();
            return sub;
        }

        public static int AddSubscriber(Subscriber subscriber)
        {
            return SubscriberData.AddSubscriber(subscriber);
        }

        public static bool UpdateSubscriber(Subscriber subscriber)
        {
            return SubscriberData.UpdateSubscriber(subscriber) > 0;
        }

        public static bool DeleteSubscriber(int id)
        {
            return SubscriberData.DeleteSubscriber(id) > 0;
        }
    }
}