using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using ClientManage.Interfaces.Schemas;
using ClientManage.Interfaces;

namespace ClientManage.Data
{
    public class ReportsData
    {
        public static DataTable GetCities()
        {
            var cmd = My.Database.GetStoredProcCommand("spGetCities");
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds.Tables[0];
        }

        public static DataSet GetTodayBirthday()
        {
            var cmd = My.Database.GetStoredProcCommand("spGetTodayBirthday");
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }

        public static DataSet GetTodayMarried()
        {
            var cmd = My.Database.GetStoredProcCommand("spGetTodayMarried");
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }

        public static DataSet GetFieldQuery(string sql)
        {
            var cmd = My.Database.GetSqlStringCommand(sql);
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }

        public static DataSet GetReportsName(string group)
        {
            var cmd = My.Database.GetStoredProcCommand("spGetReportsName");
            My.Database.AddInParameter(cmd, "group", DbType.String, group);
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }

        public static DataSet GetReportsGroup()
        {
            var cmd = My.Database.GetStoredProcCommand("spGetReportsGroup");
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }

        public static string GetReport(int id)
        {
            var cmd = My.Database.GetStoredProcCommand("spGetReport");
            My.Database.AddInParameter(cmd, "id", DbType.Int32, id);
            var ret = Convert.ToString(My.Database.ExecuteScalar(cmd));
            return ret;
        }

        public static DataSet GetReportDataSource(string query, object[] parameters)
        {
            var cmd = My.Database.GetSqlStringCommand(query);
            DbType dbType;
            var i = 1;

            foreach (var param in parameters)
            {
                if (param is DateTime) dbType = DbType.Date;
                else if (param is int) dbType = DbType.Int32;
                else if (param is double) dbType = DbType.Double;
                else dbType = DbType.String;

                My.Database.AddInParameter(cmd, "param" + i.ToString(), dbType, param);
            }

            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }

        public static int UpdateReport(int id, ReportSchema report)
        {
            var row = report.General[0];
            var xml = Security.EncryptReport(report).GetXml();

            var cmd = My.Database.GetStoredProcCommand("spUpdateReport");
            My.Database.AddInParameter(cmd, "prmId", DbType.Int32, row.ReportId);
            My.Database.AddInParameter(cmd, "prmName", DbType.String, row.ReportName);
            My.Database.AddInParameter(cmd, "prmGroup", DbType.String, row.ReportGroup);
            My.Database.AddInParameter(cmd, "prmXml", DbType.String, xml);
            My.Database.AddInParameter(cmd, "prmOldId", DbType.Int32, id);
            var ret = My.Database.ExecuteNonQuery(cmd);
            
            SetGroupOrderTable();
            return ret;
        }

        public static int AddReport(ReportSchema report)
        {
            var row = report.General[0];
            var xml = Security.EncryptReport(report).GetXml();

            var cmd = My.Database.GetStoredProcCommand("spAddReport");
            My.Database.AddInParameter(cmd, "prmId", DbType.Int32, row.ReportId);
            My.Database.AddInParameter(cmd, "prmName", DbType.String, row.ReportName);
            My.Database.AddInParameter(cmd, "prmGroup", DbType.String, row.ReportGroup);
            My.Database.AddInParameter(cmd, "prmXml", DbType.String, xml);
            var ret = My.Database.ExecuteNonQuery(cmd);

            SetGroupOrderTable();
            return ret;
        }

        public static int AddOrUpdateReport(string xml)
        {
            var report = Security.DecryptReport(xml);
            var row = report.General[0];
            var ret = 0;
            if (IsReportExist(row.ReportId))
            {
                ret = UpdateReport(row.ReportId, report);
            }
            else
            {
                ret = AddReport(report);
            }
            return ret;
        }

        public static DataSet GetAllReports()
        {
            var cmd = My.Database.GetStoredProcCommand("spGetAllReports");
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }

        public static void UpdateReportGroup(string groupName, int order)
        {
            if (groupName.Length > 0)
            {
                var cmd = My.Database.GetStoredProcCommand("spUpdateReportGroupOrder");
                My.Database.AddInParameter(cmd, "[?group_order]", DbType.Int32, order);
                My.Database.AddInParameter(cmd, "[?group_name]", DbType.String, groupName);
                My.Database.ExecuteNonQuery(cmd);
            }
        }

        private static void SetGroupOrderTable()
        {
            var cmd = My.Database.GetStoredProcCommand("spSetGroupOrderTable");
            My.Database.ExecuteNonQuery(cmd);

            cmd = My.Database.GetStoredProcCommand("spDelGroupOrderTable");
            My.Database.ExecuteNonQuery(cmd);
        }

        private static bool IsReportExist(int id)
        {
            var cmd = My.Database.GetStoredProcCommand("spIsReportExist");
            My.Database.AddInParameter(cmd, "prmId", DbType.Int32, id);
            var ret = (int)My.Database.ExecuteScalar(cmd);
            return ret > 0;
        }

        public static DataSet GetFavReportsNames(string ids)
        {
            if (string.IsNullOrEmpty(ids)) ids = "-1";
            var sql = "SELECT id, report_name, report_group FROM tblReports WHERE id IN (" + ids + ") ORDER BY report_name";
            var cmd = My.Database.GetSqlStringCommand(sql);
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }

        // ------------------
        public static DataSet GetClientsAddresses(string ids)
        {
            if (string.IsNullOrEmpty(ids)) ids = "-1";
            var sql = "SELECT TRIM(first_name + \" \" + last_name) AS full_name, address, city, zipcode FROM tblClients WHERE id IN(" + ids + ") AND Len(address + city) > 0";
            var cmd = My.Database.GetSqlStringCommand(sql);
            return My.Database.ExecuteDataSet(cmd);
        }
        public static DataSet GetContactAddresses(string ids)
        {
            if (string.IsNullOrEmpty(ids)) ids = "-1";
            var sql = "SELECT TRIM(first_name + \" \" + last_name) AS full_name, street AS address, city, zip_code AS zipcode, IIf(mail_cell_no Is Null Or mail_cell_no=\"\",\"\",\"ú.ã. \" & mail_cell_no) AS m_cell FROM tblPhoneBook WHERE id IN(" + ids + ") AND Len(street + city) > 0";
            var cmd = My.Database.GetSqlStringCommand(sql);
            return My.Database.ExecuteDataSet(cmd);
        }
        public static DataSet GetWorkerAddresses(string ids)
        {
            if (string.IsNullOrEmpty(ids)) ids = "-1";
            var sql = "SELECT TRIM(first_name + \" \" + last_name) AS full_name, address, city, zip_code AS zipcode, IIf(mail_cell Is Null Or mail_cell=\"\",\"\",\"ú.ã. \" & mail_cell) AS m_cell FROM tblWorkers WHERE id IN(" + ids + ") AND Len(address + city) > 0";
            var cmd = My.Database.GetSqlStringCommand(sql);
            return My.Database.ExecuteDataSet(cmd);
        }
        public static DataSet GetCalendarAddress(string ids)
        {
            if (string.IsNullOrEmpty(ids)) ids = "-1";
            var sql = "SELECT TRIM(C.first_name + \" \" + C.last_name) AS full_name, C.address, C.city, C.zipcode, IIf(C.mail_cell Is Null Or C.mail_cell=\"\",\"\",\"ú.ã. \" & C.mail_cell) AS m_cell FROM tblCalendar CAL INNER JOIN tblClients C ON C.id = CAL.client_id WHERE CAL.id IN(" + ids + ") AND  Len(C.address + C.city) > 0";
            var cmd = My.Database.GetSqlStringCommand(sql);
            return My.Database.ExecuteDataSet(cmd);
        }

        // ------------------
        public static DataSet GetClientsCellPhones(string ids)
        {
            return GetClientsCellPhones(ids, true);
        }
        public static DataSet GetClientsCellPhones(string ids, bool getAll)
        {
            if (string.IsNullOrEmpty(ids)) ids = "-1";
            var where = getAll ? string.Empty : " AND Len(cell_phone_1) > 0";
            var sql = "SELECT id, 0 AS type, first_name, last_name, TRIM(first_name + \" \" + last_name) AS full_name, cell_phone_1 AS cell_phone FROM tblClients WHERE id IN(" + ids + ") AND enable_sms = true" + where;
            var cmd = My.Database.GetSqlStringCommand(sql);
            return My.Database.ExecuteDataSet(cmd);
        }
        public static DataSet GetContactsCellPhones(string ids)
        {
            if (string.IsNullOrEmpty(ids)) ids = "-1";
            var sql = "SELECT id, 1 AS type, first_name, last_name, TRIM(first_name + \" \" + last_name) AS full_name, phone_no_1 AS cell_phone FROM tblPhonebook WHERE id IN(" + ids + ")";
            var cmd = My.Database.GetSqlStringCommand(sql);
            return My.Database.ExecuteDataSet(cmd);
        }
        public static DataSet GetWorkersCellPhones(string ids)
        {
            if (string.IsNullOrEmpty(ids)) ids = "-1";
            var sql = "SELECT id, 2 AS type, first_name, last_name, TRIM(first_name + \" \" + last_name) AS full_name, phone_no_1 AS cell_phone FROM tblWorkers WHERE id IN(" + ids + ")";
            var cmd = My.Database.GetSqlStringCommand(sql);
            return My.Database.ExecuteDataSet(cmd);
        }
        public static DataSet GetCalendarCellPhones(string ids)
        {
            if (string.IsNullOrEmpty(ids)) ids = "-1";
            var sql = "SELECT C.id, 0 AS type, C.first_name, C.last_name, TRIM(C.first_name + \" \" + C.last_name) AS full_name, C.cell_phone_1 AS cell_phone FROM tblCalendar CAL INNER JOIN tblClients C ON C.id = CAL.client_id WHERE CAL.id IN(" + ids + ") AND C.enable_sms = true";
            var cmd = My.Database.GetSqlStringCommand(sql);
            return My.Database.ExecuteDataSet(cmd);
        }

        // ------------------
        public static DataSet GetClientsEmails(string ids)
        {
            if (string.IsNullOrEmpty(ids)) ids = "-1";
            var sql = "SELECT TRIM(first_name + \" \" + last_name) AS full_name, email FROM tblClients WHERE id IN(" + ids + ") AND enable_email = true AND Len(email) > 0";
            var cmd = My.Database.GetSqlStringCommand(sql);
            return My.Database.ExecuteDataSet(cmd);
        }
        public static DataSet GetContactsEmails(string ids)
        {
            if (string.IsNullOrEmpty(ids)) ids = "-1";
            var sql = "SELECT TRIM(first_name + \" \" + last_name) AS full_name, email FROM tblPhonebook WHERE id IN(" + ids + ") AND Len(email) > 0";
            var cmd = My.Database.GetSqlStringCommand(sql);
            return My.Database.ExecuteDataSet(cmd);
        }
        public static DataSet GetWorkersEmails(string ids)
        {
            if (string.IsNullOrEmpty(ids)) ids = "-1";
            var sql = "SELECT TRIM(first_name + \" \" + last_name) AS full_name, email FROM tblCalendar CAL INNER JOIN tblClients C ON C.id = CAL.client_id WHERE CAL.id IN(" + ids + ") AND Len(email) > 0";
            var cmd = My.Database.GetSqlStringCommand(sql);
            return My.Database.ExecuteDataSet(cmd);
        }
        public static DataSet GetCalendarEmails(string ids)
        {
            if (string.IsNullOrEmpty(ids)) ids = "-1";
            var sql = "SELECT TRIM(C.first_name + \" \" + C.last_name) AS full_name, C.email FROM tblCalendar CAL INNER JOIN tblClients C ON C.id = CAL.client_id WHERE CAL.id IN(" + ids + ") AND C.enable_email = true AND Len(C.email) > 0";
            var cmd = My.Database.GetSqlStringCommand(sql);
            return My.Database.ExecuteDataSet(cmd);
        }
    }
}
