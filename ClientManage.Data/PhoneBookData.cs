using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using ClientManage.Interfaces;

namespace ClientManage.Data
{
    public class PhoneBookData
    {
        public static DataSet GetAllContacts(int orderBy)
        {
            var cmd = My.Database.GetStoredProcCommand("spGetAllContacts");
            My.Database.AddInParameter(cmd, "by_first", DbType.Int32, orderBy);
            return My.Database.ExecuteDataSet(cmd);
        }

        public static int DeleteContact(int id)
        {
            var cmd = My.Database.GetStoredProcCommand("spDeleteContact");
            My.Database.AddInParameter(cmd, "id", DbType.Int32, id);
            return My.Database.ExecuteNonQuery(cmd);
        }

        public static int AddContact(ref PhoneBookContact c)
        {
            var cmd = My.Database.GetStoredProcCommand("spAddContact");
            AddContactParameters(cmd, ref c);
            var ret = My.Database.ExecuteNonQuery(cmd);

            cmd = My.Database.GetStoredProcCommand("spGetLastContactId");
            c.Id = Convert.ToInt32(My.Database.ExecuteScalar(cmd));
            return ret;
        }

        public static int UpdateContact(PhoneBookContact c)
        {
            var cmd = My.Database.GetStoredProcCommand("spUpdateContact");
            AddContactParameters(cmd, ref c);
            My.Database.AddInParameter(cmd, "id", DbType.Int32, c.Id);
            return My.Database.ExecuteNonQuery(cmd);
        }

        private static void AddContactParameters(DbCommand cmd, ref PhoneBookContact c)
        {
            My.Database.AddInParameter(cmd, "first_name", DbType.String, c.FirstName);
            My.Database.AddInParameter(cmd, "last_name", DbType.String, c.LastName);
            My.Database.AddInParameter(cmd, "company", DbType.String, c.Company);
            My.Database.AddInParameter(cmd, "job_title", DbType.String, c.JobTitle);
            My.Database.AddInParameter(cmd, "email", DbType.String, c.Email);
            My.Database.AddInParameter(cmd, "web_site", DbType.String, c.WebSite);
            My.Database.AddInParameter(cmd, "phone_no_1", DbType.String, c.PhoneNo1);
            My.Database.AddInParameter(cmd, "phone_no_2", DbType.String, c.PhoneNo2);
            My.Database.AddInParameter(cmd, "phone_no_3", DbType.String, c.PhoneNo3);
            My.Database.AddInParameter(cmd, "fax", DbType.String, c.Fax);
            My.Database.AddInParameter(cmd, "street", DbType.String, c.Street);
            My.Database.AddInParameter(cmd, "notes", DbType.String, c.Notes);
            My.Database.AddInParameter(cmd, "city", DbType.String, c.City);
            My.Database.AddInParameter(cmd, "zip_code", DbType.String, c.ZipCode);
            My.Database.AddInParameter(cmd, "mail_cell_no", DbType.String, c.MailCellNo);
            My.Database.AddInParameter(cmd, "picture", DbType.String, c.Picture);
            My.Database.AddInParameter(cmd, "all_phones", DbType.String, c.AllPhones);
        }

        public static DataSet GetContact(int id)
        {
            var cmd = My.Database.GetStoredProcCommand("spGetContact");
            My.Database.AddInParameter(cmd, "id", DbType.Int32, id);
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }

        public static DataSet GetContactsByCallerId(string callerId)
        {
            var cmd = My.Database.GetStoredProcCommand("spGetContactsByCallerId");
            My.Database.AddInParameter(cmd, "[?phone]", DbType.String, callerId);
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }
    }
}
