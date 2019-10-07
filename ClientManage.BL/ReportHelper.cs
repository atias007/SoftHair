using ClientManage.Data;
using ClientManage.Interfaces;
using ClientManage.Interfaces.Schemas;
using System;
using System.Data;

namespace ClientManage.BL
{
    public class ReportHelper
    {
        public static DataTable GetCities()
        {
            return ReportsData.GetCities();
        }

        public static DataTable GetFieldQuery(string sql)
        {
            var ds = ReportsData.GetFieldQuery(sql);
            return ds.Tables[0];
        }

        public static DataTable GetTodayBirthday()
        {
            return ReportsData.GetTodayBirthday().Tables[0];
        }

        public static DataTable GetTodayMarried()
        {
            return ReportsData.GetTodayMarried().Tables[0];
        }

        public static DataTable GetConstantsTableFromRows(DataRow[] rows)
        {
            var table = new DataTable();
            table.Columns.Add("text", Type.GetType("System.String"));
            table.Columns.Add("value", Type.GetType("System.String"));

            foreach (var row in rows)
            {
                table.Rows.Add(row["Text"], row["Value"]);
            }
            return table;
        }

        public static DataTable GetReportsName(string group)
        {
            var table = ReportsData.GetReportsName(group).Tables[0];
            return table;
        }

        public static DataTable GetReportsGroup()
        {
            var table = ReportsData.GetReportsGroup().Tables[0];
            return table;
        }

        public static string GetReport(int id)
        {
            return ReportsData.GetReport(id);
        }

        public static DataTable GetReportDataSource(string query, object[] parameters)
        {
            var table = ReportsData.GetReportDataSource(query, parameters).Tables[0];
            AddTableUniqueRowNumber(ref table);
            return table;
        }

        public static int UpdateReport(int id, ReportSchema report)
        {
            return ReportsData.UpdateReport(id, report);
        }

        public static int AddReport(ReportSchema report)
        {
            return ReportsData.AddReport(report);
        }

        public static int AddOrUpdateReport(string xml)
        {
            return ReportsData.AddOrUpdateReport(xml);
        }

        public static DataTable GetAllReports()
        {
            return ReportsData.GetAllReports().Tables[0];
        }

        public static void UpdateReportGroup(string groups)
        {
            var items = groups.Split(',');

            for (var i = 0; i < items.Length; i++)
            {
                ReportsData.UpdateReportGroup(items[i], i);
            }
        }

        private static void AddTableUniqueRowNumber(ref DataTable table)
        {
            table.Columns.Add("unique_row_number", typeof(int));
            for (var i = 0; i < table.Rows.Count; i++)
            {
                table.Rows[i]["unique_row_number"] = i;
            }
            table.AcceptChanges();
        }

        public static void AttachEntityToDataTable(DataTable table)
        {
            if (table.Columns.Contains("EntityID") && table.Columns.Contains("EntityType"))
            {
                var clients = ClientHelper.CachedClientsTable;
                table.Columns.Add("full_name", typeof(string));
                table.Columns.Add("picture", typeof(string));

                foreach (DataRow row in table.Rows)
                {
                    var id = Utils.GetDBValue<int>(row, "EntityID");
                    var matchRow = clients.Rows.Find(id);

                    if (matchRow != null)
                    {
                        row["full_name"] = matchRow["ClientName"];
                        row["picture"] = matchRow["Picture"];
                    }
                    else
                    {
                        row["full_name"] = string.Empty;
                        row["picture"] = "[NO PICTURE]";
                    }
                }
            }
        }

        public static void AddCustomFieldsToDsReportDataTable(string service, DataTable table)
        {
            switch (service)
            {
                case "GetMessagesDetailsReport":
                    table.Columns.Add("SuccessTitle", typeof(string));
                    var lookupStatus = LookupHelper.GetLookupTable("tblSMSTypes");

                    foreach (DataRow row in table.Rows)
                    {
                        var id = Utils.GetDBValue<int>(row, "StatusId");
                        var type = Utils.GetDBValue<int>(row, "EntityType");

                        if (id == 1) row["SuccessTitle"] = "הצליח";
                        else row["SuccessTitle"] = "נכשל";

                        try
                        {
                            row["PackageTitle"] = LookupHelper.GetLookupFieldValue<string>(lookupStatus, type, "Caption");
                        }
                        catch
                        {
                            row["PackageTitle"] = string.Empty;
                        }
                    }
                    break;

                default:
                    break;
            }
        }

        //public static void SetCustomFilterToDsReportDataTable(string service, ref DataTable table, object[] parameters)
        //{
        //    var filter = string.Empty;

        //    switch (service)
        //    {
        //        case "GetMessagesDetailsReport":
        //            if(!parameters[2].Equals("-1"))
        //            {
        //                filter += "AND SuccessState = " + parameters[2];
        //            }
        //            if (!parameters[3].Equals(0))
        //            {
        //                filter += "AND EntityType = " + parameters[3];
        //            }
        //            break;

        //        default:
        //            break;
        //    }

        //    if (filter.Length > 0)
        //    {
        //        filter = filter.Substring(4);
        //        var ret = table.Clone();
        //        var col = table.Select(filter);
        //        foreach (var row in col)
        //        {
        //            ret.ImportRow(row);
        //        }

        //        table = ret;
        //    }
        //}

        public static DataTable GetFavReportsNames(string ids)
        {
            var ds = ReportsData.GetFavReportsNames(ids);
            return ds.Tables[0];
        }

        // ------------------
        public static DataTable GetClientsAddresses(string ids)
        {
            return ReportsData.GetClientsAddresses(ids).Tables[0];
        }

        public static DataTable GetContactAddresses(string ids)
        {
            return ReportsData.GetContactAddresses(ids).Tables[0];
        }

        public static DataTable GetWorkerAddresses(string ids)
        {
            return ReportsData.GetWorkerAddresses(ids).Tables[0];
        }

        public static DataTable GetCalendarAddress(string ids)
        {
            return ReportsData.GetCalendarAddress(ids).Tables[0];
        }

        // ------------------
        public static DataTable GetClientsCellPhones(string ids)
        {
            return ReportsData.GetClientsCellPhones(ids).Tables[0];
        }

        public static DataTable GetClientsCellPhones(string ids, bool getAll)
        {
            return ReportsData.GetClientsCellPhones(ids, getAll).Tables[0];
        }

        public static DataTable GetContactsCellPhones(string ids)
        {
            return ReportsData.GetContactsCellPhones(ids).Tables[0];
        }

        public static DataTable GetWorkersCellPhones(string ids)
        {
            return ReportsData.GetWorkersCellPhones(ids).Tables[0];
        }

        public static DataTable GetCalendarCellPhones(string ids)
        {
            return ReportsData.GetClientsCellPhones(ids).Tables[0];
        }

        // ------------------
        public static DataTable GetClientsEmails(string ids)
        {
            return ReportsData.GetClientsEmails(ids).Tables[0];
        }

        public static DataTable GetContactsEmails(string ids)
        {
            return ReportsData.GetContactsEmails(ids).Tables[0];
        }

        public static DataTable GetWorkersEmails(string ids)
        {
            return ReportsData.GetWorkersEmails(ids).Tables[0];
        }

        public static DataTable GetCalendarEmails(string ids)
        {
            //return ReportsData.GetCalendarEmails(ids).Tables[0];
            return new DataTable();
        }
    }
}