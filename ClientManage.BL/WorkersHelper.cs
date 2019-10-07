using ClientManage.Data;
using ClientManage.Interfaces;
using System;
using System.Data;

namespace ClientManage.BL
{
    public class WorkersHelper
    {
        public static DataSet GetWorkersName()
        {
            return WorkersData.GetWorkersName();
        }

        public static DataSet GetWorkersNameForTraffic()
        {
            return WorkersData.GetWorkersNameForTraffic();
        }

        public static Worker GetWorker(int id)
        {
            var ds = WorkersData.GetWorker(id);
            Worker worker;

            if (ds.Tables[0].Rows.Count > 0)
            {
                var row = ds.Tables[0].Rows[0];
                worker = GetWorkerFromRow(row);
            }
            else worker = new Worker();

            return worker;
        }

        private static Worker GetWorkerFromRow(DataRow row)
        {
            var w = new Worker((int)row["id"])
                           {
                               IdNumber = Utils.GetDBValue<string>(row, "id_number"),
                               Picture = Utils.GetDBValue<string>(row, "picture"),
                               FirstName = Utils.GetDBValue<string>(row, "first_name"),
                               LastName = Utils.GetDBValue<string>(row, "last_name"),
                               Address = Utils.GetDBValue<string>(row, "address"),
                               City = Utils.GetDBValue<string>(row, "city"),
                               ZipCode = Utils.GetDBValue<string>(row, "zip_code"),
                               MailCell = Utils.GetDBValue<string>(row, "mail_cell"),
                               Email = Utils.GetDBValue<string>(row, "email"),
                               CellPhone1 = Utils.GetDBValue<string>(row, "phone_no_1"),
                               CellPhone2 = Utils.GetDBValue<string>(row, "phone_no_2"),
                               HomePhone = Utils.GetDBValue<string>(row, "phone_no_3"),
                               StartWorkDate = Utils.GetDBValue<DateTime>(row, "start_work_date"),
                               JobTitle = Utils.GetDBValue<string>(row, "job_title"),
                               PersonalPassword = Utils.GetDBValue<string>(row, "personal_password"),
                               CardId = Utils.GetDBValue<string>(row, "card_id"),
                               Remark = Utils.GetDBValue<string>(row, "remark"),
                               BirthDate = Utils.GetDBValue<DateTime?>(row["birth_date"]),
                               Gender = ((Worker.WorkerGender)Convert.ToInt32(row["gender"])),
                               CreateDate = Utils.GetDBValue<DateTime>(row["create_date"]),
                               IsActive = Convert.ToBoolean(row["is_active"]),
                               IsAdmin = Utils.GetDBValue<bool>(row["is_admin"]),
                               IsFillTraffic = Utils.GetDBValue<bool>(row["is_fill_traffic"]),
                               IsCalPresent = Utils.GetDBValue<bool>(row["is_cal_present"]),
                               EndWorkDate = Utils.GetDBValue<DateTime>(row["end_work_date"])
                           };

            return w;
        }

        public static bool SetEnterTraffic(WorkerTraffic traffic)
        {
            var ret = WorkersData.AddTraffic(traffic);
            return ret > 0;
        }

        public static bool SetLeaveTraffic(WorkerTraffic traffic)
        {
            int ret;
            var id = WorkersData.GetEnterTrafficId(traffic.WorkerId);
            if (id == 0)
            {
                ret = WorkersData.AddTraffic(traffic);
            }
            else
            {
                traffic.Id = id;
                ret = WorkersData.UpdateLeaveTraffic(traffic);
            }
            return ret > 0;
        }

        public static DataTable GetTrafficByDate(DateTime fromDate, DateTime toDate)
        {
            if (fromDate.Date.Equals(toDate.Date))
                return WorkersData.GetTrafficByDate(fromDate).Tables[0];

            return WorkersData.GetTrafficByDate(fromDate, toDate).Tables[0];
        }

        public static bool IsAdminPassword(string password)
        {
            return WorkersData.IsAdminPassword(password) > 0;
        }

        public static bool UpdateTraffic(WorkerTraffic traffic)
        {
            return WorkersData.UpdateTraffic(traffic) > 0;
        }

        public static bool DeleteTraffic(int id)
        {
            return WorkersData.DeleteTraffic(id) > 0;
        }

        public static DataTable GetWorkersForPick()
        {
            return WorkersData.GetWorkersForPick().Tables[0];
        }

        public static DataTable GetWorkersToManage(bool showAll)
        {
            return WorkersData.GetWorkersToManage(showAll).Tables[0];
        }

        public static DataTable GetWorkersToManage()
        {
            return GetWorkersToManage(false);
        }

        public static int AddWorker(Worker worker)
        {
            return WorkersData.AddWorker(worker);
        }

        public static bool UpdateWorker(Worker worker)
        {
            return WorkersData.UpdateWorker(worker) > 0;
        }

        public static bool DeleteWorker(int id)
        {
            var res = (WorkersData.DeleteWorker(id) > 0);
            WorkersData.CascadeDeleteWorker(id);
            return res;
        }

        public static bool IsWorkerIdExist(string id)
        {
            if (string.IsNullOrEmpty(id)) return false;
            return WorkersData.IsWorkerIdExist(id) > 0;
        }

        public static bool IsWorkerLastAdmin(int id)
        {
            return WorkersData.IsWorkerLastAdmin(id) == 0;
        }

        public static DataSet GetAllMagneticCards()
        {
            return WorkersData.GetAllMagneticCards();
        }

        public static void UpdateMagneticCards(DataSet ds)
        {
            WorkersData.UpdateMagneticCards(ds);
        }

        public static int GetDefaultWorkerId()
        {
            return WorkersData.GetDefaultWorkerId();
        }

        public static DataTable GetWorkersForCalendar()
        {
            return WorkersData.GetWorkersForCalendar().Tables[0];
        }

        public static void RemoveWorkerFromCalendar()
        {
            WorkersData.RemoveWorkerFromCalendar();
        }

        public static DataTable GetWorkersList()
        {
            var table = WorkersData.GetWorkersList().Tables[0];
            var row = table.NewRow();
            row["id"] = 0;
            row["full_name"] = "ללא עובד מטפל";
            table.Rows.InsertAt(row, 0);

            return table;
        }

        public static int GetCalendarWorkersCount(int curWorkerId)
        {
            return WorkersData.GetCalendarWorkersCount(curWorkerId);
        }

        public static int GetWorkerIdByCardId(string cardId)
        {
            return WorkersData.GetWorkerIdByCardId(cardId);
        }
    }
}