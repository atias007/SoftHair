using System;
using System.Data;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using ClientManage.Interfaces;

namespace ClientManage.Data
{
    public class WorkersData
    {
        public static DataSet GetWorkersName()
        {
            var cmd = My.Database.GetStoredProcCommand("spGetWorkersName");
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }

        public static DataSet GetWorkersNameForTraffic()
        {
            var cmd = My.Database.GetStoredProcCommand("spGetWorkersNameForTraffic");
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }

        public static DataSet GetWorker(int id)
        {
            var cmd = My.Database.GetStoredProcCommand("spGetWorker");
            My.Database.AddInParameter(cmd, "id", DbType.Int32, id);
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }

        public static int AddTraffic(WorkerTraffic traffic)
        {
            var cmd = My.Database.GetStoredProcCommand("spAddTraffic");
            My.Database.AddInParameter(cmd, "worker_id", DbType.Int32, traffic.WorkerId);
            My.Database.AddInParameter(cmd, "enter_date", DbType.DateTime, Utils.GetDateTimeValueForDB(traffic.EnterDate));
            My.Database.AddInParameter(cmd, "enter_feed", DbType.Int32, Convert.ToInt32(traffic.EnterFeed));
            My.Database.AddInParameter(cmd, "leave_date", DbType.DateTime, Utils.GetDateTimeValueForDB(traffic.LeaveDate));
            My.Database.AddInParameter(cmd, "leave_feed", DbType.Int32, Convert.ToInt32(traffic.LeaveFeed));
            My.Database.AddInParameter(cmd, "remark", DbType.String, traffic.Remark);
            My.Database.AddInParameter(cmd, "create_date", DbType.DateTime, Utils.GetDateTimeValueForDB(traffic.CreateDate));

            return My.Database.ExecuteNonQuery(cmd);
        }

        public static int UpdateLeaveTraffic(WorkerTraffic traffic)
        {
            var cmd = My.Database.GetStoredProcCommand("spUpdateLeaveTraffic");
            My.Database.AddInParameter(cmd, "leave_date", DbType.DateTime, Utils.GetDateTimeValueForDB(traffic.LeaveDate));
            My.Database.AddInParameter(cmd, "leave_feed", DbType.Int32, Convert.ToInt32(traffic.LeaveFeed));
            My.Database.AddInParameter(cmd, "remark", DbType.String, traffic.Remark);
            My.Database.AddInParameter(cmd, "id", DbType.Int32, traffic.Id);

            return My.Database.ExecuteNonQuery(cmd);
        }

        public static int GetEnterTrafficId(int workerId)
        {
            var cmd = My.Database.GetStoredProcCommand("spGetEnterTrafficId");
            My.Database.AddInParameter(cmd, "worker_id", DbType.String, workerId);

            var ret = Utils.GetDBValue<int>(My.Database.ExecuteScalar(cmd));
            return ret;
        }

        public static DataSet GetTrafficByDate(DateTime fromDate, DateTime toDate)
        {
            var cmd = My.Database.GetStoredProcCommand("spGetTrafficByDateRange");
            My.Database.AddInParameter(cmd, "[?from_date]", DbType.DateTime, fromDate.Date);
            My.Database.AddInParameter(cmd, "[?to_date]", DbType.DateTime, toDate.Date);
            var ds = My.Database.ExecuteDataSet(cmd);

            return ds;
        }

        public static DataSet GetTrafficByDate(DateTime currentDate)
        {
            var cmd = My.Database.GetStoredProcCommand("spGetTrafficByDate");
            My.Database.AddInParameter(cmd, "[?cur_date]", DbType.DateTime, currentDate.Date);
            var ds = My.Database.ExecuteDataSet(cmd);

            return ds;
        }

        public static int IsAdminPassword(string password)
        {
            var cmd = My.Database.GetStoredProcCommand("spIsAdminPassword");
            My.Database.AddInParameter(cmd, "prm_password", DbType.String, password);
            var ret = Convert.ToInt32(My.Database.ExecuteScalar(cmd));
            return ret;
        }

        public static int UpdateTraffic(WorkerTraffic traffic)
        {
            var cmd = My.Database.GetStoredProcCommand("spUpdateTraffic");
            My.Database.AddInParameter(cmd, "enter_date", DbType.DateTime, Utils.GetDateTimeValueForDB(traffic.EnterDate));
            My.Database.AddInParameter(cmd, "leave_date", DbType.DateTime, Utils.GetDateTimeValueForDB(traffic.LeaveDate));
            My.Database.AddInParameter(cmd, "enter_feed", DbType.Int32, Convert.ToInt32(traffic.EnterFeed));
            My.Database.AddInParameter(cmd, "leave_feed", DbType.Int32, Convert.ToInt32(traffic.LeaveFeed));
            My.Database.AddInParameter(cmd, "remark", DbType.String, traffic.Remark);
            My.Database.AddInParameter(cmd, "id", DbType.Int32, traffic.Id);
            var ret = My.Database.ExecuteNonQuery(cmd);
            return ret;
        }

        public static int DeleteTraffic(int id)
        {
            var cmd = My.Database.GetStoredProcCommand("spDeleteTraffic");
            My.Database.AddInParameter(cmd, "id", DbType.Int32, id);
            var ret = My.Database.ExecuteNonQuery(cmd);
            return ret;
        }

        public static DataSet GetWorkersForPick()
        {
            var cmd = My.Database.GetStoredProcCommand("spGetWorkersForPick");
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }

        public static DataSet GetWorkersToManage(bool showAll)
        {
            var cmd = My.Database.GetStoredProcCommand("spGetWorkersToManage");
            My.Database.AddInParameter(cmd, "active_only", DbType.Boolean, showAll);
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }

        public static int AddWorker(Worker worker)
        {
            var cmd = My.Database.GetStoredProcCommand("spAddWorker");
            SetWorkerParamaters(cmd, worker);
            var ret = My.Database.ExecuteNonQuery(cmd);
            if (ret > 0)
            {
                var cmd2 = My.Database.GetStoredProcCommand("spGetMaxWorkerId");
                ret = Convert.ToInt32(My.Database.ExecuteScalar(cmd2));
            }
            return ret;
        }

        public static int UpdateWorker(Worker worker)
        {
            var cmd = My.Database.GetStoredProcCommand("spUpdateWorker");
            SetWorkerParamaters(cmd, worker);
            My.Database.AddInParameter(cmd, "id", DbType.Int32, worker.Id);
            var ret = My.Database.ExecuteNonQuery(cmd);
            return ret;
        }

        private static void SetWorkerParamaters(DbCommand cmd, Worker worker)
        {
            My.Database.AddInParameter(cmd, "id_number", DbType.String, worker.IdNumber);
            My.Database.AddInParameter(cmd, "picture", DbType.String, worker.Picture);
            My.Database.AddInParameter(cmd, "first_name", DbType.String, worker.FirstName);
            My.Database.AddInParameter(cmd, "last_name", DbType.String, worker.LastName);
            My.Database.AddInParameter(cmd, "address", DbType.String, worker.Address);
            My.Database.AddInParameter(cmd, "city", DbType.String, worker.City);
            My.Database.AddInParameter(cmd, "zip_code", DbType.String, worker.ZipCode);
            My.Database.AddInParameter(cmd, "mail_cell", DbType.String, worker.MailCell);
            My.Database.AddInParameter(cmd, "email", DbType.String, worker.Email);
            My.Database.AddInParameter(cmd, "phone_no_1", DbType.String, worker.CellPhone1);
            My.Database.AddInParameter(cmd, "phone_no_2", DbType.String, worker.CellPhone2);
            My.Database.AddInParameter(cmd, "phone_no_3", DbType.String, worker.HomePhone);
            My.Database.AddInParameter(cmd, "start_work_date", DbType.Date, Utils.GetDateTimeValueForDB(worker.StartWorkDate));
            My.Database.AddInParameter(cmd, "job_title", DbType.String, worker.JobTitle);
            My.Database.AddInParameter(cmd, "personal_password", DbType.String, worker.PersonalPassword);
            My.Database.AddInParameter(cmd, "card_id", DbType.String, worker.CardId);
            My.Database.AddInParameter(cmd, "remark", DbType.String, worker.Remark);
            My.Database.AddInParameter(cmd, "birth_date", DbType.Date, worker.BirthDate);
            My.Database.AddInParameter(cmd, "gender", DbType.Int32, Convert.ToInt32(worker.Gender));
            My.Database.AddInParameter(cmd, "is_active", DbType.Boolean, worker.IsActive);
            My.Database.AddInParameter(cmd, "is_admin", DbType.Boolean, worker.IsAdmin);
            My.Database.AddInParameter(cmd, "is_fill_traffic", DbType.Boolean, worker.IsFillTraffic);
            My.Database.AddInParameter(cmd, "is_cal_present", DbType.Boolean, worker.IsCalPresent);
            My.Database.AddInParameter(cmd, "end_work_date", DbType.DateTime, worker.EndWorkDate);
            My.Database.AddInParameter(cmd, "all_phones", DbType.String, worker.AllPhones);
        }

        public static int DeleteWorker(int id)
        {
            var cmd = My.Database.GetStoredProcCommand("spDeleteWorker");
            My.Database.AddInParameter(cmd, "[?id]", DbType.Int32, id);
            var ret = My.Database.ExecuteNonQuery(cmd);

            return ret;
        }

        public static void CascadeDeleteWorker(int workerId)
        {
            var sql = "DELETE FROM tblWorkersTraffic WHERE worker_id = " + workerId.ToString();

            var cmd = My.Database.GetSqlStringCommand(sql);
            My.Database.ExecuteNonQuery(cmd);
            RemoveWorkerFromCalendar();
        }

        public static void RemoveWorkerFromCalendar()
        {
            var cmd = My.Database.GetStoredProcCommand("spRemoveWorkerFromCalendar");
            My.Database.ExecuteNonQuery(cmd);
        }

        public static int IsWorkerIdExist(string id)
        {
            var cmd = My.Database.GetStoredProcCommand("spIsWorkerIdExist");
            My.Database.AddInParameter(cmd, "id_number", DbType.String, id);
            var ret = Convert.ToInt32(My.Database.ExecuteScalar(cmd));
            return ret;
        }

        public static int IsWorkerLastAdmin(int id)
        {
            var cmd = My.Database.GetStoredProcCommand("spIsWorkerLastAdmin");
            My.Database.AddInParameter(cmd, "id", DbType.Int32, id);
            var ret = Convert.ToInt32(My.Database.ExecuteScalar(cmd));
            return ret;
        }

        public static DataSet GetAllMagneticCards()
        {
            var cmd = My.Database.GetStoredProcCommand("spGetAllMagneticCards");
            var ds = new DataSet();
            My.Database.LoadDataSet(cmd, ds, "tblMagneticCards");
            return ds;
        }

        public static void UpdateMagneticCards(DataSet ds)
        {
            var sqlInsert = "INSERT INTO tblMagneticCards (card_id) VALUES ([?card_id])";
            var sqlUpdate = "UPDATE tblMagneticCards SET card_id = [?card_id] WHERE id=[?id]";
            var sqlDelete = "DELETE FROM tblMagneticCards WHERE id=[?id]";

            var cmdInsert = My.Database.GetSqlStringCommand(sqlInsert);
            My.Database.AddInParameter(cmdInsert, "[?card_id]", DbType.String, "card_id", DataRowVersion.Current);

            var cmdUpdate = My.Database.GetSqlStringCommand(sqlUpdate);
            My.Database.AddInParameter(cmdUpdate, "[?card_id]", DbType.String, "card_id", DataRowVersion.Current);
            My.Database.AddInParameter(cmdUpdate, "[?id]", DbType.Int32, "id", DataRowVersion.Current);

            var cmdDelete = My.Database.GetSqlStringCommand(sqlDelete);
            My.Database.AddInParameter(cmdDelete, "[?id]", DbType.Int32, "id", DataRowVersion.Current);

            My.Database.UpdateDataSet(ds, "tblMagneticCards", cmdInsert, cmdUpdate, cmdDelete, UpdateBehavior.Standard);        
        }

        public static int GetDefaultWorkerId()
        {
            const string sql = "SELECT TOP 1 id FROM tblWorkers WHERE is_active=True AND is_cal_present=True AND is_admin = True";
            var cmd = My.Database.GetSqlStringCommand(sql);
            var value = My.Database.ExecuteScalar(cmd);
            var result = Convert.ToInt32(value);
            return result;
        }

        public static DataSet GetWorkersForCalendar()
        {
            var cmd = My.Database.GetStoredProcCommand("spGetWorkersForCalendar");
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }

        public static DataSet GetWorkersList()
        {
            var cmd = My.Database.GetStoredProcCommand("spGetWorkersList");
            return My.Database.ExecuteDataSet(cmd);
        }

        public static int GetCalendarWorkersCount(int curWorkerId)
        {
            var cmd = My.Database.GetStoredProcCommand("spGetCalendarWorkersCount");
            My.Database.AddInParameter(cmd, "[?id]", DbType.Int32, curWorkerId);
            var cnt = 0;
            try { cnt = Convert.ToInt32(My.Database.ExecuteScalar(cmd)); }
            catch { }

            return cnt;
        }

        public static int GetWorkerIdByCardId(string cardId)
        {
            var cmd = My.Database.GetStoredProcCommand("Worker_GetWorkerIdByCardId");
            My.Database.AddInParameter(cmd, "[?card_id]", DbType.String, cardId);
            var id = Utils.GetDBValue<int>(My.Database.ExecuteScalar(cmd));
            return id;
        }
    }
}
