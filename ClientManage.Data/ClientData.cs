using ClientManage.Interfaces;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace ClientManage.Data
{
    public class ClientData
    {
        private static DataSet _clientsTable;
        private static bool _cacheHasChanges;

        #region Cache Client Table

        public static DataTable CachedClientsTable
        {
            get
            {
                if (_clientsTable == null) return null;
                return _clientsTable.Tables[0];
            }
        }

        public static bool IsClientCacheHasChanges
        {
            get { return _cacheHasChanges; }
        }

        public static void ClientCacheAcceptChanges()
        {
            _cacheHasChanges = false;
        }

        public static void DoCacheClientsTable()
        {
            _clientsTable = FindUsers();
            CachedClientsTable.DefaultView.Sort = "ClientName";
            CachedClientsTable.PrimaryKey = new[] { CachedClientsTable.Columns["id"] };
            ClientCacheAcceptChanges();
        }

        public static void UpdateClientInCache(Client c, bool isNew)
        {
            if (CachedClientsTable == null) return;
            DataRow row;
            if (isNew)
            {
                row = CachedClientsTable.NewRow();
                row["create_date"] = c.CreateDate;
                row["id"] = c.Id;
            }
            else
            {
                row = CachedClientsTable.Rows.Find(c.Id);
            }

            row["ClientName"] = c.FullName;
            row["Phone"] = c.AllPhonesWithComma;
            row["Picture"] = c.Picture;
            row["client_address"] = c.Address + (c.Address.Length > 0 ? ", " + c.City : c.City);
            row["FirstName"] = c.FirstName;
            row["LastName"] = c.LastName;
            row["Street"] = c.Address;
            row["ClientPhones"] = c.AllPhoneDigits;
            if (isNew) CachedClientsTable.Rows.Add(row);

            CachedClientsTable.AcceptChanges();

            _cacheHasChanges = true;
        }

        public static void RemoveClientFromCache(int id)
        {
            var src = CachedClientsTable.Rows.Find(id);
            CachedClientsTable.Rows.Remove(src);
            _cacheHasChanges = true;
        }

        //private static DataRow GetClientToFromDbToCache(int id)
        //{
        //    var sql = "SELECT * FROM vwFindQueryView WHERE id = " + id;
        //    var cmd = My.Database.GetSqlStringCommand(sql);
        //    var ds = My.Database.ExecuteDataSet(cmd);
        //    DataRow row = null;
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        row = ds.Tables[0].Rows[0];
        //    }
        //    return row;
        //}

        public static DataSet FindUsers()
        {
            const string sql = "SELECT * FROM vwFindQueryView";
            var cmd = My.Database.GetSqlStringCommand(sql);
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }

        #endregion Cache Client Table

        public static DataRow GetClient(int id)
        {
            var cmd = My.Database.GetStoredProcCommand("spGetClient");
            My.Database.AddInParameter(cmd, "id", DbType.Int32, id);
            var ds = My.Database.ExecuteDataSet(cmd);
            if (ds.Tables[0].Rows.Count == 0) return null;
            return ds.Tables[0].Rows[0];
        }

        public static DataRow GetLastVisit(int clientId)
        {
            var cmd = My.Database.GetStoredProcCommand("spGetLastVisitForClient");
            My.Database.AddInParameter(cmd, "client_id", DbType.Int32, clientId);
            var ds = My.Database.ExecuteDataSet(cmd);
            if (ds.Tables[0].Rows.Count == 0) return null;
            return ds.Tables[0].Rows[0];
        }

        public static int AddClient(Client client)
        {
            var cmd = My.Database.GetStoredProcCommand("spAddClient");
            AddCommandClientParams(ref cmd, client);
            var cnt = My.Database.ExecuteNonQuery(cmd);
            var ret = 0;

            if (cnt > 0)
            {
                cmd = My.Database.GetStoredProcCommand("spGetLastClientId");
                ret = Convert.ToInt32(My.Database.ExecuteScalar(cmd));
                client.Id = ret;
                UpdateClientInCache(client, true);
            }

            return ret;
        }

        public static int UpdateClient(Client client)
        {
            var cmd = My.Database.GetStoredProcCommand("spUpdateClient");
            AddCommandClientParams(ref cmd, client);
            My.Database.AddInParameter(cmd, "id", DbType.Int32, client.Id);
            var cnt = My.Database.ExecuteNonQuery(cmd);

            UpdateClientInCache(client, false);
            SetContactToBeSync(client.Id);

            return cnt;
        }

        private static void AddCommandClientParams(ref DbCommand cmd, Client client)
        {
            My.Database.AddInParameter(cmd, "first_name", DbType.String, client.FirstName);
            My.Database.AddInParameter(cmd, "last_name", DbType.String, client.LastName);
            My.Database.AddInParameter(cmd, "home_phone", DbType.String, client.HomePhone);
            My.Database.AddInParameter(cmd, "work_phone", DbType.String, client.WorkPhone);
            My.Database.AddInParameter(cmd, "cell_phone_1", DbType.String, client.CellPhone1);
            My.Database.AddInParameter(cmd, "cell_phone_2", DbType.String, client.CellPhone2);
            My.Database.AddInParameter(cmd, "birth_date", DbType.DateTime, client.BirthDate);
            My.Database.AddInParameter(cmd, "address", DbType.String, client.Address);
            My.Database.AddInParameter(cmd, "city", DbType.String, client.City);
            My.Database.AddInParameter(cmd, "zipcode", DbType.String, client.ZipCode);
            My.Database.AddInParameter(cmd, "married_date", DbType.String, client.MarriedDate);
            My.Database.AddInParameter(cmd, "email", DbType.String, client.Email);
            My.Database.AddInParameter(cmd, "gender", DbType.Int32, Convert.ToInt32(client.Gender));
            My.Database.AddInParameter(cmd, "picture", DbType.String, client.Picture);
            My.Database.AddInParameter(cmd, "remark", DbType.String, client.Remark);
            My.Database.AddInParameter(cmd, "all_phones", DbType.String, client.AllPhoneDigits);
            My.Database.AddInParameter(cmd, "enable_sms", DbType.Boolean, client.EnableSMS);
            My.Database.AddInParameter(cmd, "enable_email", DbType.Boolean, client.EnableEmail);
            My.Database.AddInParameter(cmd, "worker_id", DbType.Int32, client.WorkerId);
            My.Database.AddInParameter(cmd, "client_type", DbType.Int32, client.ClientTypeId);
            My.Database.AddInParameter(cmd, "card_id", DbType.String, client.CardId);
        }

        public static void SetCreateDate(Client client)
        {
            const string sql = "UPDATE tblClients SET create_date = [?prm_create_date] where id = [?prm_id]";
            var cmd = My.Database.GetSqlStringCommand(sql);
            My.Database.AddInParameter(cmd, "[?prm_create_date]", DbType.DateTime, client.CreateDate);
            My.Database.AddInParameter(cmd, "[?prm_id]", DbType.Int32, client.Id);
            My.Database.ExecuteNonQuery(cmd);
        }

        public static int DeleteClient(int id)
        {
            var cmd = My.Database.GetStoredProcCommand("spDeleteClient");
            My.Database.AddInParameter(cmd, "id", DbType.Int32, id);
            var cnt = My.Database.ExecuteNonQuery(cmd);

            RemoveClientFromCache(id);
            return cnt;
        }

        public static DataSet GetUsersByCallerId(string callerId)
        {
            var cmd = My.Database.GetStoredProcCommand("spGetUsersByCallerId");
            My.Database.AddInParameter(cmd, "caller_id", DbType.String, callerId);
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }

        public static DataSet GetLastCalledClients()
        {
            var cmd = My.Database.GetStoredProcCommand("spGetLastCalledClients");
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }

        public static string GetFullName(int id)
        {
            var ret = string.Empty;
            var row = CachedClientsTable.Rows.Find(id);
            if (row != null) ret = Utils.GetDBValue<string>(row, "ClientName");
            return ret;
        }

        public static string GetPicture(int id)
        {
            var ret = string.Empty;
            var row = CachedClientsTable.Rows.Find(id);
            if (row != null) ret = Utils.GetDBValue<string>(row, "Picture");
            return ret;
        }

        public static string GetAllPhones(int id)
        {
            var ret = string.Empty;
            var row = CachedClientsTable.Rows.Find(id);
            if (row != null) ret = Utils.GetDBValue<string>(row, "ClientPhones");
            return ret;
        }

        public static DataRow GetCellPhone(int id)
        {
            var cmd = My.Database.GetStoredProcCommand("spGetClientCellPhone");
            My.Database.AddInParameter(cmd, "id", DbType.Int32, id);
            DataRow row = null;
            var ds = My.Database.ExecuteDataSet(cmd);

            if (ds.Tables[0].Rows.Count > 0) row = ds.Tables[0].Rows[0];
            return row;
        }

        public static void CascadeDeleteClient(int clientId)
        {
            var name = GetFullName(clientId).Replace("\"", string.Empty);
            var remark = "\"הלקוח " + name + " נמחק ממאגר הלקוחות\"";
            var sql1 = "UPDATE tblCalendar SET client_id = 0, subject = \"[" + name + "] \" + subject, remark = " + remark + " WHERE client_id = " + clientId;
            var sql2 = "UPDATE tblCallLog SET client_id = -1 WHERE client_id = " + clientId;
            var sql3 = "DELETE FROM tblClientComponents WHERE client_id = " + clientId;

            var cmd = My.Database.GetSqlStringCommand(sql1);
            My.Database.ExecuteNonQuery(cmd);
            cmd = My.Database.GetSqlStringCommand(sql2);
            My.Database.ExecuteNonQuery(cmd);
            cmd = My.Database.GetSqlStringCommand(sql3);
            My.Database.ExecuteNonQuery(cmd);
        }

        public static string GetClientEmail(int id)
        {
            var cmd = My.Database.GetStoredProcCommand("spGetClientEmail");
            My.Database.AddInParameter(cmd, "id", DbType.Int32, id);
            var ret = Utils.GetDBValue<string>(My.Database.ExecuteScalar(cmd));
            return ret;
        }

        public static int AddClientFromPhoneBook(int contactId)
        {
            var cmd = My.Database.GetStoredProcCommand("spAddClientFromPhoneBook");
            My.Database.AddInParameter(cmd, "[?id]", DbType.Int32, contactId);
            var cnt = My.Database.ExecuteNonQuery(cmd);
            var ret = 0;

            if (cnt > 0)
            {
                cmd = My.Database.GetStoredProcCommand("spGetLastClientId");
                ret = Convert.ToInt32(My.Database.ExecuteScalar(cmd));
                SetContactToBeSync(ret);
            }

            return ret;
        }

        public static DataSet GetClientTypeTable()
        {
            var dsCTypes = new DataSet();
            const string sql = "SELECT id, description FROM tblClientTypes";
            var cmd = My.Database.GetSqlStringCommand(sql);
            My.Database.LoadDataSet(cmd, dsCTypes, "tblClientTypes");

            return dsCTypes;
        }

        public static void UpdateClientTypeTable(DataSet ds)
        {
            if (ds == null) return;

            const string sqlInsert = "INSERT INTO tblClientTypes (description) VALUES ([?description])";
            const string sqlUpdate = "UPDATE tblClientTypes SET description = [?description] WHERE id = [?id]";
            const string sqlDelete = "DELETE FROM tblClientTypes WHERE id = [?id]";

            var insertCommand = My.Database.GetSqlStringCommand(sqlInsert);
            My.Database.AddInParameter(insertCommand, "[?description]", DbType.String, "description", DataRowVersion.Current);

            var deleteCommand = My.Database.GetSqlStringCommand(sqlDelete);
            My.Database.AddInParameter(deleteCommand, "[?id]", DbType.Int32, "id", DataRowVersion.Current);

            var updateCommand = My.Database.GetSqlStringCommand(sqlUpdate);
            My.Database.AddInParameter(updateCommand, "[?description]", DbType.String, "description", DataRowVersion.Current);
            My.Database.AddInParameter(updateCommand, "[?id]", DbType.Int32, "id", DataRowVersion.Current);

            My.Database.UpdateDataSet(ds, "tblClientTypes", insertCommand, updateCommand, deleteCommand, UpdateBehavior.Standard);
        }

        public static DataSet GetClientComponents(int clientId)
        {
            var dsComponents = new DataSet();
            var sql = GetClientComponentsSelectQuery();
            var cmd = My.Database.GetSqlStringCommand(sql);
            My.Database.AddInParameter(cmd, "[?client_id]", DbType.Int32, clientId);
            My.Database.LoadDataSet(cmd, dsComponents, "tblComponents");

            return dsComponents;
        }

        private static string GetClientComponentsSelectQuery()
        {
            string sql;

            if (AppSettingsData.Cache.ContainsKey("GetClientComponentsSelectQuery"))
            {
                sql = (string)AppSettingsData.Cache["GetClientComponentsSelectQuery"];
            }
            else
            {
                var count = GetComponentsConfig().Tables[0].Rows.Count;
                sql = "SELECT id, client_id";
                for (var i = 0; i < count; i++)
                {
                    sql += ", com" + i;
                }
                sql += " FROM tblClientComponents WHERE client_id=[?client_id];";
                AppSettingsData.Cache.Add("GetClientComponentsSelectQuery", sql);
            }

            return sql;
        }

        public static int UpdateComponents(DataSet ds)
        {
            var sqlSelect = GetClientComponentsSelectQuery();
            var adapter = new OleDbDataAdapter(sqlSelect, (OleDbConnection)My.Database.CreateConnection());
            var builder = new OleDbCommandBuilder(adapter);

            DbCommand insertCommand = builder.GetInsertCommand();
            DbCommand deleteCommand = builder.GetDeleteCommand();
            DbCommand updateCommand = builder.GetUpdateCommand();

            return My.Database.UpdateDataSet(ds, "tblComponents", insertCommand, updateCommand, deleteCommand, UpdateBehavior.Standard);
        }

        public static bool IsEnableSms(int id)
        {
            var sql = "SELECT enable_sms FROM tblClients WHERE id=" + id;
            var cmd = My.Database.GetSqlStringCommand(sql);
            var en = (bool)My.Database.ExecuteScalar(cmd);
            return en;
        }

        public static DataSet GetBirthdayClientIds(DateTime date)
        {
            var cmd = My.Database.GetStoredProcCommand("SMS_GetBirthdayClientIds");
            My.Database.AddInParameter(cmd, "[?prmDate]", DbType.DateTime, date.Date);
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }

        public static DataSet GetMarriedClientIds(DateTime date)
        {
            var cmd = My.Database.GetStoredProcCommand("SMS_GetMarriedClientIds");
            My.Database.AddInParameter(cmd, "[?prmDate]", DbType.DateTime, date.Date);
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }

        public static int GetClientIdByCardId(string cardId)
        {
            var cmd = My.Database.GetStoredProcCommand("Client_GetClientIdByCardId");
            My.Database.AddInParameter(cmd, "[?card_id]", DbType.String, cardId);
            var id = Utils.GetDBValue<int>(My.Database.ExecuteScalar(cmd));
            return id;
        }

        public static int GetClientIdByEmail(string email)
        {
            var query = "SELECT id FROM tblClients WHERE email = '" + email.ToLower() + "'";
            var cmd = My.Database.GetSqlStringCommand(query);
            var id = Utils.GetDBValue<int>(My.Database.ExecuteScalar(cmd));
            return id;
        }

        public static DataSet GetComponentsConfig()
        {
            DataSet ds;

            if (AppSettingsData.Cache.ContainsKey("GetComponentsConfig"))
            {
                ds = (DataSet)AppSettingsData.Cache["GetComponentsConfig"];
            }
            else
            {
                var cmd = My.Database.GetStoredProcCommand("Client_GetComponentsConfig");
                ds = new DataSet();
                My.Database.LoadDataSet(cmd, ds, "tblClientComponentsConfig");
                AppSettingsData.Cache.Add("GetComponentsConfig", ds);
            }

            return ds;
        }

        public static int SaveComponentsConfig()
        {
            var ds = GetComponentsConfig();
            var adapter = new OleDbDataAdapter("SELECT * FROM tblClientComponentsConfig", (OleDbConnection)My.Database.CreateConnection());
            var builder = new OleDbCommandBuilder(adapter);

            DbCommand insertCommand = builder.GetInsertCommand();
            DbCommand deleteCommand = builder.GetDeleteCommand();
            DbCommand updateCommand = builder.GetUpdateCommand();

            return My.Database.UpdateDataSet(ds, "tblClientComponentsConfig", insertCommand, updateCommand, deleteCommand, UpdateBehavior.Standard);
        }

        public static int GetComponentsMaxOrder()
        {
            var cmd = My.Database.GetStoredProcCommand("Client_GetComponentsMaxOrder");
            var maxId = Utils.GetDBValue<int>(My.Database.ExecuteScalar(cmd));
            return maxId;
        }

        public static int GetPhotosCount(int clientId)
        {
            var cmd = My.Database.GetStoredProcCommand("Client_GetPhotosCount");
            My.Database.AddInParameter(cmd, "[?client_id]", DbType.Int32, clientId);
            return Utils.GetDBValue<int>(My.Database.ExecuteScalar(cmd));
        }

        public static int GetSubscriptionCount(int clientId)
        {
            var cmd = My.Database.GetStoredProcCommand("Client_GetSubscriptionCount");
            My.Database.AddInParameter(cmd, "[?client_id]", DbType.Int32, clientId);
            return Utils.GetDBValue<int>(My.Database.ExecuteScalar(cmd));
        }

        public static DataSet GetSyncContacts()
        {
            var cmd = My.Database.GetStoredProcCommand("SYNC_GetSyncContacts");
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }

        public static void UpdateSyncContacts(string ids)
        {
            const string sql = "UPDATE tblClients Set is_sync=true WHERE id IN({0});";
            var query = string.Format(sql, ids);
            var cmd = My.Database.GetSqlStringCommand(query);
            My.Database.ExecuteNonQuery(cmd);
        }

        public static void SetContactToBeSync(int id)
        {
            const string sql = "UPDATE tblClients SET is_sync = false WHERE id={0}";
            var query = string.Format(sql, id);
            var cmd = My.Database.GetSqlStringCommand(query);
            My.Database.ExecuteNonQuery(cmd);
        }
    }
}