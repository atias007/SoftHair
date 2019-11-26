using ClientManage.Interfaces;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace ClientManage.Data
{
    public class CalendarData
    {
        //private static OleDbDataAdapter adapter;
        //private static DataSet remDs;

        private static void SetAppointmentParameters(DbCommand cmd, BizCareAppointment app)
        {
            var clientId = app.ClientId;

            My.Database.AddInParameter(cmd, "subject", DbType.String, app.Text);
            My.Database.AddInParameter(cmd, "date_start", DbType.DateTime, app.StartDate);
            My.Database.AddInParameter(cmd, "date_end", DbType.DateTime, app.EndDate);
            My.Database.AddInParameter(cmd, "all_day_event", DbType.Boolean, app.IsAllDayEvent);
            My.Database.AddInParameter(cmd, "importance", DbType.Int32, Convert.ToInt32(app.Importance));
            My.Database.AddInParameter(cmd, "remainer_min", DbType.Int32, app.RemainderMinutes);
            My.Database.AddInParameter(cmd, "remark", DbType.String, app.Remark);
            My.Database.AddInParameter(cmd, "recurrence_id", DbType.Int32, app.RecurrenceId);
            My.Database.AddInParameter(cmd, "worker_id", DbType.Int32, app.WorkerId);
            My.Database.AddInParameter(cmd, "client_id", DbType.Int32, clientId);
            My.Database.AddInParameter(cmd, "cares", DbType.String, app.Cares);
            My.Database.AddInParameter(cmd, "has_alert", DbType.Boolean, app.HasAlert);
        }

        public static DataRow GetAppointment(string id)
        {
            var cmd = My.Database.GetStoredProcCommand("spGetAppointment");
            My.Database.AddInParameter(cmd, "id", DbType.Int32, Convert.ToInt32(id));
            var ds = My.Database.ExecuteDataSet(cmd);
            var row = ds.Tables[0].Rows.Count == 0 ? null : ds.Tables[0].Rows[0];
            return row;
        }

        public static DataSet GetDayCalendarEvents(DateTime currentDate)
        {
            var cmd = My.Database.GetStoredProcCommand("spGetDayCalendarEvents");
            My.Database.AddInParameter(cmd, "current_date", DbType.Date, currentDate);
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }

        public static DataSet GetDayCalendarEventsByWorker(DateTime currentDate, int workerId)
        {
            var cmd = My.Database.GetStoredProcCommand("spGetDayCalendarEventsByWorker");
            My.Database.AddInParameter(cmd, "current_date", DbType.Date, currentDate);
            My.Database.AddInParameter(cmd, "worker_id", DbType.Int32, workerId);
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }

        public static void UpdateAppointment(BizCareAppointment app)
        {
            var cmd = My.Database.GetStoredProcCommand("spUpdateAppointment");
            SetAppointmentParameters(cmd, app);
            My.Database.AddInParameter(cmd, "id", DbType.Int32, app.Id);
            My.Database.ExecuteNonQuery(cmd);
        }

        public static void AddAppointment(BizCareAppointment app)
        {
            var cmd = My.Database.GetStoredProcCommand("spAddAppointment");
            SetAppointmentParameters(cmd, app);

            var cnt = My.Database.ExecuteNonQuery(cmd);

            cmd = My.Database.GetStoredProcCommand("spGetMaxCalendarId");
            app.Id = My.Database.ExecuteScalar(cmd).ToString();
        }

        public static void OldDeleteAppointment(string id)
        {
            var cmd = My.Database.GetStoredProcCommand("spDeleteAppointment");
            My.Database.AddInParameter(cmd, "id", DbType.Int32, Convert.ToInt32(id));
            My.Database.ExecuteNonQuery(cmd);
            try
            {
                CascadeDeleteAppointment(id);
            }
            catch
            {
                Utils.CatchException();
            }
        }

        public static void DeleteAppointment(string id)
        {
            var cmd = My.Database.GetStoredProcCommand("spDeleteAppointment");
            My.Database.AddInParameter(cmd, "id", DbType.Int32, Convert.ToInt32(id));
            My.Database.ExecuteNonQuery(cmd);

            try
            {
                CascadeDeleteAppointment(id);
            }
            catch
            {
                Utils.CatchException();
            }
        }

        private static void CascadeDeleteAppointment(string id)
        {
            var sql = "UPDATE tblPhotoAlbum SET calendar_id=0 WHERE calendar_id = " + id;
            var cmd = My.Database.GetSqlStringCommand(sql);
            My.Database.ExecuteNonQuery(cmd);
        }

        public static DataRow GetClientPicture(int id)
        {
            var row = ClientData.CachedClientsTable.Rows.Find(id);
            return row;

            //DbCommand cmd = My.Database.GetStoredProcCommand("spGetClient4Appointment");
            //My.Database.AddInParameter(cmd, "id", DbType.Int32, id);
            //DataSet ds = My.Database.ExecuteDataSet(cmd);
            //return ds;
        }

        public static void SetClientToAppointment(string id, int clientId)
        {
            var cmd = My.Database.GetStoredProcCommand("spSetClientToAppointment");
            My.Database.AddInParameter(cmd, "client_id", DbType.Int32, clientId);
            My.Database.AddInParameter(cmd, "id", DbType.Int32, id);
            My.Database.ExecuteNonQuery(cmd);
        }

        //public static DataSet GetRemainderLines()
        //{
        //    remDs = new DataSet();
        //    if (adapter == null) InitAdapter();
        //    adapter.Fill(remDs);
        //    return remDs;
        //}

        public static DataSet GetRemainderValues()
        {
            var cmd = My.Database.GetStoredProcCommand("spGetRemainderValues");
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }

        //private static void InitAdapter()
        //{
        //    const string sqlSelect = "SELECT tblCalendar.id, tblCalendar.remainer_min, tblCalendar.date_start, tblCalendar.subject, tblCalendar.client_id, tblCalendar.cares, tblCalendar.remainder_dismiss, tblCalendar.remainder_snooze_min, tblCalendar.remainder_popup_date FROM tblCalendar " +
        //                             "WHERE tblCalendar.remainer_min>=0 And tblCalendar.remainder_dismiss=False And (DateDiff('d',Now(),[date_start])<=0) And Not (remainder_popup_date Is Not Null And remainder_snooze_min=-1) AND active=true;";
        //    var selectCommand = (OleDbCommand)My.Database.GetSqlStringCommand(sqlSelect);
        //    selectCommand.Connection = (OleDbConnection)My.Database.CreateConnection();

        //    adapter = new OleDbDataAdapter(selectCommand);
        //    var builder = new OleDbCommandBuilder(adapter);
        //    adapter.InsertCommand = builder.GetInsertCommand();
        //    adapter.UpdateCommand = builder.GetUpdateCommand();
        //    adapter.DeleteCommand = builder.GetDeleteCommand();
        //}

        //public static void UpdateRemainders()
        //{
        //    adapter.Update(remDs);
        //}

        //public static void SetRemainderDismiss(int id)
        //{
        //    for (var i = 0; i < remDs.Tables[0].Rows.Count; i++)
        //    {
        //        if (id == (int)remDs.Tables[0].Rows[i]["id"])
        //        {
        //            remDs.Tables[0].Rows[i]["remainder_dismiss"] = true;
        //            break;
        //        }
        //    }
        //    UpdateRemainders();
        //}

        //public static void SetRemainderSnooze(int id, int minutes)
        //{
        //    for (var i = 0; i < remDs.Tables[0].Rows.Count; i++)
        //    {
        //        if (id == (int)remDs.Tables[0].Rows[i]["id"])
        //        {
        //            remDs.Tables[0].Rows[i]["remainder_popup_date"] = DateTime.Now;
        //            remDs.Tables[0].Rows[i]["remainder_snooze_min"] = minutes;
        //            break;
        //        }
        //    }
        //    UpdateRemainders();
        //}

        //public static void ReLiveAppRemainder(string id)
        //{
        //    var cmd = My.Database.GetStoredProcCommand("spReLiveAppRemainder");
        //    My.Database.AddInParameter(cmd, "id", DbType.Int32, Convert.ToInt32(id));
        //    My.Database.ExecuteNonQuery(cmd);
        //}

        //public static DataRow GetRemainderFields(string id)
        //{
        //    var cmd = My.Database.GetStoredProcCommand("spGetRemainderFields");
        //    My.Database.AddInParameter(cmd, "id", DbType.Int32, Convert.ToInt32(id));
        //    var ds = My.Database.ExecuteDataSet(cmd);
        //    var row = ds.Tables[0].Rows.Count == 0 ? null : ds.Tables[0].Rows[0];
        //    return row;
        //}

        //public static DataSet GetAgregateRemarks(int clientId)
        //{
        //    var cmd = My.Database.GetStoredProcCommand("spGetAgregateRemarks");
        //    My.Database.AddInParameter(cmd, "client_id", DbType.Int32, clientId);
        //    var ds = My.Database.ExecuteDataSet(cmd);
        //    return ds;
        //}

        public static DataSet GetAllRemainderValues()
        {
            var cmd = My.Database.GetStoredProcCommand("spGetRemainderValues");
            var ds = new DataSet();
            My.Database.LoadDataSet(cmd, ds, "tblRemainderValues");
            return ds;
        }

        public static void UpdateRemainderValues(DataSet ds)
        {
            const string sqlInsert = "INSERT INTO tblRemainderValues (min_value, description) VALUES ([?min_value], [?description])";
            const string sqlUpdate = "UPDATE tblRemainderValues SET min_value = [?min_value], description = [?description] WHERE min_value = [?old_min_value]";
            const string sqlDelete = "DELETE FROM tblRemainderValues WHERE min_value=[?min_value]";

            var cmdInsert = My.Database.GetSqlStringCommand(sqlInsert);
            My.Database.AddInParameter(cmdInsert, "[?min_value]", DbType.Int32, "min_value", DataRowVersion.Current);
            My.Database.AddInParameter(cmdInsert, "[?description]", DbType.String, "description", DataRowVersion.Current);

            var cmdUpdate = My.Database.GetSqlStringCommand(sqlUpdate);
            My.Database.AddInParameter(cmdUpdate, "[?min_value]", DbType.Int32, "min_value", DataRowVersion.Current);
            My.Database.AddInParameter(cmdUpdate, "[?description]", DbType.String, "description", DataRowVersion.Current);
            My.Database.AddInParameter(cmdUpdate, "[?old_min_value]", DbType.Int32, "min_value", DataRowVersion.Original);

            var cmdDelete = My.Database.GetSqlStringCommand(sqlDelete);
            My.Database.AddInParameter(cmdDelete, "[?min_value]", DbType.Int32, "min_value", DataRowVersion.Current);

            My.Database.UpdateDataSet(ds, "tblRemainderValues", cmdInsert, cmdUpdate, cmdDelete, UpdateBehavior.Standard);
        }

        public static void SetAppointmentText(string text, string id)
        {
            var cmd = My.Database.GetStoredProcCommand("spSetAppointmentText");
            My.Database.AddInParameter(cmd, "[?subject]", DbType.String, text);
            My.Database.AddInParameter(cmd, "[?id]", DbType.Int32, Convert.ToInt32(id));
            My.Database.ExecuteNonQuery(cmd);
            //GmailService.Instance.SetAppoitmentText(id, text);
        }

        public static void SetAppointmentWorker(int workerId, string id)
        {
            var cmd = My.Database.GetStoredProcCommand("spSetAppointmentWorker");
            My.Database.AddInParameter(cmd, "[?worker_id]", DbType.Int32, workerId);
            My.Database.AddInParameter(cmd, "[?id]", DbType.Int32, Convert.ToInt32(id));
            My.Database.ExecuteNonQuery(cmd);
            //GmailService.Instance.SetAppoitmentWorkerId(id, workerId);
        }

        public static void UpdateAppointmentTime(DateTime start, DateTime end, string id)
        {
            var cmd = My.Database.GetStoredProcCommand("spUpdateAppointmentTime");
            My.Database.AddInParameter(cmd, "[?date_start]", DbType.DateTime, start);
            My.Database.AddInParameter(cmd, "[?date_end]", DbType.DateTime, end);
            My.Database.AddInParameter(cmd, "[id]", DbType.Int32, Convert.ToInt32(id));
            My.Database.ExecuteNonQuery(cmd);

            //GmailService.Instance.SetAppoitmentTime(id, start, end);
        }

        public static void UpdateAppointmentRemainder(int minutes, string id)
        {
            var cmd = My.Database.GetStoredProcCommand("spUpdateAppointmentRemainder");
            My.Database.AddInParameter(cmd, "[?remainer_min]", DbType.Int32, minutes);
            My.Database.AddInParameter(cmd, "[?id]", DbType.Int32, Convert.ToInt32(id));
            My.Database.ExecuteNonQuery(cmd);

            //    GmailService.Instance.SetAppoitmentReminderMin(id, minutes);
        }

        public static DataSet GetCares()
        {
            const string sql = "SELECT id, description, score, display_color, duration FROM tblCares ORDER BY score";
            var cmd = My.Database.GetSqlStringCommand(sql);
            var dsCares = new DataSet();
            My.Database.LoadDataSet(cmd, dsCares, "tblCares");
            return dsCares;
        }

        public static void UpdateCares(DataSet ds)
        {
            if (ds == null) return;

            const string sqlInsert = "INSERT INTO tblCares (description, score, display_color, duration) VALUES ([?description], [?score], [?display_color], [?duration])";
            const string sqlUpdate = "UPDATE tblCares SET description = [?description], score = [?score], display_color = [?display_color], duration = [?duration] WHERE id = [?id]";
            const string sqlDelete = "DELETE FROM tblCares WHERE id = [?id]";

            var insertCommand = My.Database.GetSqlStringCommand(sqlInsert);
            My.Database.AddInParameter(insertCommand, "[?description]", DbType.String, "description", DataRowVersion.Current);
            My.Database.AddInParameter(insertCommand, "[?score]", DbType.Int32, "score", DataRowVersion.Current);
            My.Database.AddInParameter(insertCommand, "[?display_color]", DbType.Int32, "display_color", DataRowVersion.Current);
            My.Database.AddInParameter(insertCommand, "[?duration]", DbType.Int32, "duration", DataRowVersion.Current);

            var deleteCommand = My.Database.GetSqlStringCommand(sqlDelete);
            My.Database.AddInParameter(deleteCommand, "[?id]", DbType.Int32, "id", DataRowVersion.Current);

            var updateCommand = My.Database.GetSqlStringCommand(sqlUpdate);
            My.Database.AddInParameter(updateCommand, "[?description]", DbType.String, "description", DataRowVersion.Current);
            My.Database.AddInParameter(updateCommand, "[?score]", DbType.Int32, "score", DataRowVersion.Current);
            My.Database.AddInParameter(updateCommand, "[?display_color]", DbType.Int32, "display_color", DataRowVersion.Current);
            My.Database.AddInParameter(updateCommand, "[?duration]", DbType.Int32, "duration", DataRowVersion.Current);
            My.Database.AddInParameter(updateCommand, "[?id]", DbType.Int32, "id", DataRowVersion.Current);

            My.Database.UpdateDataSet(ds, "tblCares", insertCommand, updateCommand, deleteCommand, UpdateBehavior.Standard);
        }

        public static void SetCaresToAppointment(string cares, string id)
        {
            var cmd = My.Database.GetStoredProcCommand("spSetCaresToAppointment");
            My.Database.AddInParameter(cmd, "[?cares]", DbType.String, cares);
            My.Database.AddInParameter(cmd, "[id]", DbType.Int32, Convert.ToInt32(id));

            My.Database.ExecuteNonQuery(cmd);
            //GmailService.Instance.SetAppoitmentCares(id, cares);
        }

        //public static DataSet GetTopClientsVisits(int clientId)
        //{
        //    //var cmd = My.Database.GetStoredProcCommand("spGetTopClientsVisits");
        //    //My.Database.AddInParameter(cmd, "[?client_id]", DbType.Int32, clientId);
        //    //return My.Database.ExecuteDataSet(cmd);
        //    return GmailService.Instance.GetClientTopVisits(clientId);
        //}

        //public static DataSet GetArchiveItems(DateTime? fromDate, DateTime? toDate, int option, bool excludeLast)
        //{
        //    string sql;
        //    var where = string.Empty;
        //    var ids = string.Empty;
        //    DbCommand cmd;

        //    if (excludeLast)
        //    {
        //        var ds = GetExcludeCalItemId();
        //        ids = Utils.GetDataSourceIds(ds.Tables[0]);
        //    }

        //    if (fromDate.HasValue && toDate.HasValue)
        //    {
        //        sql = "SELECT * FROM tblCalendar WHERE worker_id > 0 AND date_start BETWEEN [?fromDate] AND [?toDate]";
        //        if (option == 0) where += " AND date_end < Now()";
        //        if (option == 1) where += " AND active = False";
        //        sql += where;
        //        cmd = My.Database.GetSqlStringCommand(sql);
        //        My.Database.AddInParameter(cmd, "[?fromDate]", DbType.DateTime, fromDate);
        //        My.Database.AddInParameter(cmd, "[?toDate]", DbType.DateTime, toDate);
        //    }
        //    else
        //    {
        //        sql = "SELECT * FROM tblCalendar";
        //        where = "worker_id >= 0";
        //        if (option == 0) where += " AND date_end < Now()";
        //        if (option == 1) where += " AND active = False";
        //        if (excludeLast && ids.Length > 0) where += " AND id NOT IN(" + ids + ")";
        //        sql = sql + " WHERE " + where;
        //        cmd = My.Database.GetSqlStringCommand(sql);
        //    }

        //    return My.Database.ExecuteDataSet(cmd);
        //}

        //private static DataSet GetExcludeCalItemId()
        //{
        //    var cmd = My.Database.GetStoredProcCommand("Archive_GetLastVisitCalendarId");
        //    return My.Database.ExecuteDataSet(cmd);
        //}

        //public static void ClearArchivedItems(DateTime? fromDate, DateTime? toDate, int option, bool excludeLast)
        //{
        //    string sql;
        //    string where;
        //    var ids = string.Empty;
        //    DbCommand cmd;

        //    if (excludeLast)
        //    {
        //        var ds = GetExcludeCalItemId();
        //        ids = Utils.GetDataSourceIds(ds.Tables[0]);
        //    }

        //    if (fromDate.HasValue && toDate.HasValue)
        //    {
        //        sql = "DELETE FROM tblCalendar";
        //        where = "worker_id >= 0 AND date_start BETWEEN [?fromDate] AND [?toDate]";
        //        if (option == 0) where += " AND date_end < Now()";
        //        if (option == 1) where += " AND active = False";
        //        sql = sql + " WHERE " + where;
        //        cmd = My.Database.GetSqlStringCommand(sql);
        //        My.Database.AddInParameter(cmd, "[?fromDate]", DbType.DateTime, fromDate);
        //        My.Database.AddInParameter(cmd, "[?toDate]", DbType.DateTime, toDate);
        //    }
        //    else
        //    {
        //        sql = "DELETE FROM tblCalendar";
        //        where = "worker_id >= 0";
        //        if (option == 0) where += " AND date_end < Now()";
        //        if (option == 1) where += " AND active = False";
        //        if (excludeLast && ids.Length > 0) where += " AND id NOT IN(" + ids + ")";
        //        sql = sql + " WHERE " + where;
        //        cmd = My.Database.GetSqlStringCommand(sql);
        //    }

        //    My.Database.ExecuteNonQuery(cmd);
        //}

        //public static bool IsAppointmentExist(int id)
        //{
        //    var cmd = My.Database.GetStoredProcCommand("Archive_IsAppointmentExist");
        //    My.Database.AddInParameter(cmd, "[?id]", DbType.Int32, id);

        //    var count = (int)My.Database.ExecuteScalar(cmd);
        //    return count > 0;
        //}

        //public static DataSet GetMonthBoldedDates(int month, int year)
        //{
        //    var cmd = My.Database.GetStoredProcCommand("spGetMonthBoldedDates");

        //    My.Database.AddInParameter(cmd, "[?month]", DbType.Int32, month);
        //    My.Database.AddInParameter(cmd, "[?year]", DbType.Int32, year);

        //    var ds = My.Database.ExecuteDataSet(cmd);
        //    return ds;
        //}

        public static void SetCategory(int category, string id)
        {
            var cmd = My.Database.GetStoredProcCommand("Calendar_SetCategory");

            My.Database.AddInParameter(cmd, "[?category]", DbType.Int32, category);
            My.Database.AddInParameter(cmd, "[?id]", DbType.Int32, Convert.ToInt32(id));

            My.Database.ExecuteNonQuery(cmd);

            //    GmailService.Instance.SetAppoitmentCategotyId(id, category);
        }

        public static int AddCalendarAudit(string appointmentId, int auditType, string title)
        {
            var cmd = My.Database.GetStoredProcCommand("AddCalendarAudit");
            My.Database.AddInParameter(cmd, "[?audit_type]", DbType.Int32, auditType);
            My.Database.AddInParameter(cmd, "[?appointmentId]", DbType.String, appointmentId);
            My.Database.AddInParameter(cmd, "[?audit_title]", DbType.String, title);
            var count = My.Database.ExecuteNonQuery(cmd);
            return count;
        }

        public static DataSet GetAppointmentHistory(string appointmentId)
        {
            var query = string.Format("SELECT id, audit_date, audit_type, audit_title FROM tblCalendarAudit WHERE appointment_id='{0}' ORDER BY audit_date DESC", appointmentId);
            var cmd = My.Database.GetSqlStringCommand(query);
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }

        public static DataSet GetAllAppointmentHistory(bool onlyDeleted)
        {
            var where = onlyDeleted ? "WHERE audit_type = 2" : string.Empty;
            var query = string.Format("SELECT TOP 1000 id, audit_date, audit_type, audit_title FROM tblCalendarAudit {0} ORDER BY audit_date DESC", where);
            var cmd = My.Database.GetSqlStringCommand(query);
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }

        //public static void UpdateSyncEvents(string ids)
        //{
        //    const string sql = "UPDATE tblCalendar Set is_sync=true WHERE id IN({0});";
        //    var query = string.Format(sql, ids);
        //    var cmd = My.Database.GetSqlStringCommand(query);
        //    My.Database.ExecuteNonQuery(cmd);
        //}

        //public static void SetEventToBeSync(string id)
        //{
        //    const string sql = "UPDATE tblCalendar SET is_sync = false WHERE id={0}";
        //    var query = string.Format(sql, id);
        //    var cmd = My.Database.GetSqlStringCommand(query);
        //    My.Database.ExecuteNonQuery(cmd);
        //}
    }
}