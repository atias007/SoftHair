using ClientManage.BL.Library;
using ClientManage.Data;
using ClientManage.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ClientManage.BL
{
    public class ClientHelper
    {
        public static DataTable CachedClientsTable
        {
            get { return ClientData.CachedClientsTable; }
        }

        public static void DoCacheClientsTable()
        {
            ClientData.DoCacheClientsTable();
        }

        public static bool IsClientCacheHasChanges
        {
            get { return ClientData.IsClientCacheHasChanges; }
        }

        public static void ClientCacheAcceptChanges()
        {
            ClientData.ClientCacheAcceptChanges();
        }

        public static Client GetClient(int id)
        {
            var row = ClientData.GetClient(id);
            var c = LoadClient(row, id);

            return c;
        }

        public static int AddClient(Client client)
        {
            return ClientData.AddClient(client);
        }

        public static int UpdateClient(Client client)
        {
            return ClientData.UpdateClient(client);
        }

        public static void SetCreateDate(Client client)
        {
            ClientData.SetCreateDate(client);
        }

        public static int DeleteClient(int id)
        {
            ClientData.CascadeDeleteClient(id);
            AppSettingsHelper.AddDeletedClient(id);
            return ClientData.DeleteClient(id);
        }

        private static Client LoadClient(DataRow row, int id)
        {
            Client c = null;

            if (row != null)
            {
                c = new Client(id)
                {
                    Address = Utils.GetDBValue<string>(row, "address"),
                    BirthDate = Utils.GetDBValue<DateTime?>(row, "birth_date"),
                    CellPhone1 = Utils.GetDBValue<string>(row, "cell_phone_1"),
                    CellPhone2 = Utils.GetDBValue<string>(row, "cell_phone_2"),
                    City = Utils.GetDBValue<string>(row, "city"),
                    CreateDate = Utils.GetDBValue<DateTime>(row["create_date"]),
                    Email = Utils.GetDBValue<string>(row, "email"),
                    FirstName = Utils.GetDBValue<string>(row, "first_name"),
                    Gender =
                                DBNull.Value.Equals(row["gender"])
                                    ? Client.ClientGender.Male
                                    : (Client.ClientGender)(Convert.ToInt32(row["gender"])),
                    HomePhone = Utils.GetDBValue<string>(row, "home_phone"),
                    LastName = Utils.GetDBValue<string>(row, "last_name"),
                    MarriedDate = Utils.GetDBValue<DateTime?>(row["married_date"]),
                    Picture = Utils.GetDBValue<string>(row, "picture"),
                    Remark = Utils.GetDBValue<string>(row, "remark"),
                    WorkPhone = Utils.GetDBValue<string>(row, "work_phone"),
                    ZipCode = Utils.GetDBValue<string>(row, "zipcode"),
                    EnableEmail = Utils.GetDBValue<bool>(row["enable_email"]),
                    EnableSMS = Utils.GetDBValue<bool>(row["enable_sms"]),
                    ClientTypeId = Utils.GetDBValue<int>(row["client_type"]),
                    ClientTypeName = Utils.GetDBValue<string>(row, "client_type_name"),
                    WorkerId = Utils.GetDBValue<int>(row["worker_id"]),
                    WorkerName = Utils.GetDBValue<string>(row, "worker_name"),
                    CardId = Utils.GetDBValue<string>(row, "card_id")
                };
            }

            return c;
        }

        private static CallerIdPerson LoadNativClient(DataRow row)
        {
            var c = new CallerIdPerson();

            if (row != null)
            {
                c.Id = Utils.GetDBValue<int>(row, "id");
                c.Address = Utils.GetDBValue<string>(row, "address");
                c.BirthDate = Utils.GetDBValue<DateTime?>(row["birth_date"]);
                c.City = Utils.GetDBValue<string>(row, "city");
                c.FirstName = Utils.GetDBValue<string>(row, "first_name");
                c.LastName = Utils.GetDBValue<string>(row, "last_name");
                c.Picture = Utils.GetDBValue<string>(row, "picture");
                c.Gender = (CallerIdPerson.PersonGender)Utils.GetDBValue<int>(row, "gender");
                c.Entity = CallerIdPerson.PersonEntity.Client;
            }

            return c;
        }

        public static Client GetFirstUser()
        {
            if (CachedClientsTable.Rows.Count == 0) return null;

            return GetClient((int)CachedClientsTable.Rows[0]["id"]);
        }

        public static string GetUserNameByCellPhone(string phone, out int id)
        {
            id = 0;
            var ds = ClientData.GetUsersByCallerId(phone);
            var ret = string.Empty;
            var row = ds.Tables[0].Rows.Count > 0 ? ds.Tables[0].Rows[0] : null;
            if (row != null)
            {
                id = Utils.GetDBValue<int>(row["id"]);
                ret = Utils.GetDBValue<string>(row, "first_name") + " " + Utils.GetDBValue<string>(row, "last_name");
            }
            return ret;
        }

        public static string GetUsersNamesByLinePhone(string phone, int curId)
        {
            var ds = ClientData.GetUsersByCallerId(phone);
            var ret = string.Empty;
            // ReSharper disable LoopCanBeConvertedToQuery
            foreach (DataRow row in ds.Tables[0].Rows)
            // ReSharper restore LoopCanBeConvertedToQuery
            {
                if (Utils.GetDBValue<int>(row["id"]) != curId)
                {
                    ret += Utils.GetDBValue<string>(row, "first_name") + " " + Utils.GetDBValue<string>(row, "last_name") + "\n";
                }
            }
            return ret;
        }

        public static CallerIdPerson[] GetUsersByCallerId(string callerId)
        {
            var ds = ClientData.GetUsersByCallerId(callerId);

            if (ds.Tables[0].Rows.Count == 0) return null;

            var clients = new CallerIdPerson[ds.Tables[0].Rows.Count];

            for (var i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                clients[i] = LoadNativClient(ds.Tables[0].Rows[i]);
            }

            return clients;
        }

        public static DataSet GetLastCalledClients()
        {
            return ClientData.GetLastCalledClients();
        }

        public static string GetFullName(int id)
        {
            return ClientData.GetFullName(id);
        }

        public static string GetPicture(int id)
        {
            return ClientData.GetPicture(id);
        }

        public static string GetCellPhone(int id)
        {
            var row = ClientData.GetCellPhone(id);
            var ret = Utils.GetDBValue<string>(row, "cell_phone_1");
            ret = Utils.DistilPhone(ret);
            return ret;
        }

        public static string GetClientEmail(int id)
        {
            return ClientData.GetClientEmail(id);
        }

        public static string GetAllPhones(int id)
        {
            return ClientData.GetAllPhones(id);
        }

        public static int AddClientFromPhoneBook(int contactId)
        {
            var id = ClientData.AddClientFromPhoneBook(contactId);

            if (id > 0)
            {
                var c = GetClient(id);
                var phone = Utils.DistilPhone(c.HomePhone);
                if (!Validation.IsLinePhoneValid(phone))
                {
                    if (Validation.IsCellPhoneValid(phone))
                    {
                        if (c.CellPhone1.Length == 0) { c.CellPhone1 = c.HomePhone; c.HomePhone = string.Empty; }
                        else if (c.CellPhone2.Length == 0) { c.CellPhone2 = c.HomePhone; c.HomePhone = string.Empty; }
                    }
                }

                UpdateClient(c);
            }

            return id;
        }

        public static DataTable GetClientsType()
        {
            var table = LookupHelper.GetLookupTable("tblClientTypes").Copy();
            var row = table.NewRow();
            row["id"] = 0;
            row["description"] = "ללא סיווג";
            table.Rows.InsertAt(row, 0);

            return table;
        }

        public static DataSet GetClientTypeTable()
        {
            return ClientData.GetClientTypeTable();
        }

        public static void UpdateClientTypeTable(DataSet ds)
        {
            ClientData.UpdateClientTypeTable(ds);
        }

        public static DataSet GetClientComponents(int clientId)
        {
            return ClientData.GetClientComponents(clientId);
        }

        public static int UpdateComponents(DataSet ds)
        {
            if (ds == null) return 0;
            return ClientData.UpdateComponents(ds);
        }

        public static bool IsEnableSms(int id)
        {
            return ClientData.IsEnableSms(id);
        }

        public static int GetTotalClients()
        {
            return ClientData.GetTotalClients();
        }

        public static DataTable GetAutoBirthdaySms()
        {
            DataTable table = null, tmpTable;
            var smsParams = new AutoSmsParameters(AppSettingsHelper.GetParamValue("SMS_BIRTHDAY_PARAMS"));
            if (!smsParams.Enable) return null;

            // check if auto sms already sent
            if (smsParams.LastSubmit.Date >= DateTime.Now.Date) return null;

            var span = DateTime.Now.Date.Subtract(smsParams.LastSubmit.Date);
            var days = 0;
            if (smsParams.LastSubmit != DateTime.MinValue) days = span.TotalDays >= 7 ? 6 : Convert.ToInt32(Math.Floor(span.TotalDays - 1));

            for (var i = 0; i <= days; i++)
            {
                tmpTable = ClientData.GetBirthdayClientIds(DateTime.Now.AddDays(-i)).Tables[0];
                if (table == null)
                {
                    table = tmpTable.Copy();
                }
                else
                {
                    foreach (DataRow row in tmpTable.Rows)
                    {
                        table.ImportRow(row);
                    }
                }
            }

            return table;
        }

        public static DataTable GetAutoMarriedSms()
        {
            DataTable table = null, tmpTable;
            var smsParams = new AutoSmsParameters(AppSettingsHelper.GetParamValue("SMS_MARRIED_PARAMS"));
            if (!smsParams.Enable) return null;

            // check if auto sms already sent
            if (smsParams.LastSubmit.Date >= DateTime.Now.Date) return null;

            var span = DateTime.Now.Date.Subtract(smsParams.LastSubmit.Date);
            var days = 0;
            if (smsParams.LastSubmit != DateTime.MinValue) days = span.TotalDays >= 7 ? 6 : Convert.ToInt32(Math.Floor(span.TotalDays - 1));
            for (var i = 0; i <= days; i++)
            {
                tmpTable = ClientData.GetMarriedClientIds(DateTime.Now.AddDays(-i)).Tables[0];
                if (table == null)
                {
                    table = tmpTable.Copy();
                }
                else
                {
                    foreach (DataRow row in tmpTable.Rows)
                    {
                        table.ImportRow(row);
                    }
                }
            }

            return table;
        }

        public static int GetClientIdByCardId(string cardId)
        {
            return ClientData.GetClientIdByCardId(cardId);
        }

        public static DataSet GetComponentsConfig()
        {
            return ClientData.GetComponentsConfig();
        }

        public static int SaveComponentsConfig()
        {
            return ClientData.SaveComponentsConfig();
        }

        public static int GetComponentsMaxOrder()
        {
            return ClientData.GetComponentsMaxOrder();
        }

        public static void SetTotalValues(Client client)
        {
            client.TotalPhotos = ClientData.GetPhotosCount(client.Id);
            client.TotalSubscriptions = ClientData.GetSubscriptionCount(client.Id);
        }

        public static int GetSubscriptionCount(int cilentId)
        {
            return ClientData.GetSubscriptionCount(cilentId);
        }

        public static DataTable GetSyncContacts()
        {
            var ds = ClientData.GetSyncContacts();
            return ds.Tables[0];
        }

        public static void UpdateSyncContacts(IEnumerable<int> ids)
        {
            if (ids.Count() == 0) return;

            var prm = string.Empty;
            foreach (var id in ids)
            {
                prm += id + ",";
            }
            if (prm.EndsWith(",")) prm = prm.Substring(0, prm.Length - 1);
            ClientData.UpdateSyncContacts(prm);
        }
    }
}