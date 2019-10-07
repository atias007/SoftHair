using ClientManage.Data;
using ClientManage.Interfaces;
using System.Data;

namespace ClientManage.BL
{
    public class PhoneBookHelper
    {
        public static DataSet GetAllContacts(int orderBy)
        {
            return PhoneBookData.GetAllContacts(orderBy);
        }

        public static int DeleteContact(int id)
        {
            return PhoneBookData.DeleteContact(id);
        }

        public static int AddContact(ref PhoneBookContact c)
        {
            return PhoneBookData.AddContact(ref c);
        }

        public static int UpdateContact(PhoneBookContact c)
        {
            return PhoneBookData.UpdateContact(c);
        }

        public static PhoneBookContact GetContact(int id)
        {
            PhoneBookContact c = null;
            var ds = PhoneBookData.GetContact(id);
            if (ds.Tables[0].Rows.Count > 0)
            {
                c = new PhoneBookContact(id);
                var row = ds.Tables[0].Rows[0];
                c.City = Utils.GetDBValue<string>(row, "city");
                c.Company = Utils.GetDBValue<string>(row, "company");
                c.Email = Utils.GetDBValue<string>(row, "email");
                c.Fax = Utils.GetDBValue<string>(row, "fax");
                c.FirstName = Utils.GetDBValue<string>(row, "first_name");
                c.JobTitle = Utils.GetDBValue<string>(row, "job_title");
                c.LastName = Utils.GetDBValue<string>(row, "last_name");
                c.MailCellNo = Utils.GetDBValue<string>(row, "mail_cell_no");
                c.Notes = Utils.GetDBValue<string>(row, "notes");
                c.PhoneNo1 = Utils.GetDBValue<string>(row, "phone_no_1");
                c.PhoneNo2 = Utils.GetDBValue<string>(row, "phone_no_2");
                c.PhoneNo3 = Utils.GetDBValue<string>(row, "phone_no_3");
                c.Street = Utils.GetDBValue<string>(row, "street");
                c.WebSite = Utils.GetDBValue<string>(row, "web_site");
                c.ZipCode = Utils.GetDBValue<string>(row, "zip_code");
                c.Picture = Utils.GetDBValue<string>(row, "picture");
            }

            return c;
        }

        public static CallerIdPerson[] GetContactsByCallerId(string callerId)
        {
            var ds = PhoneBookData.GetContactsByCallerId(callerId);

            if (ds.Tables[0].Rows.Count == 0) return null;

            var contacts = new CallerIdPerson[ds.Tables[0].Rows.Count];

            for (var i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                contacts[i] = LoadNativContact(ds.Tables[0].Rows[i]);
            }

            return contacts;
        }

        private static CallerIdPerson LoadNativContact(DataRow row)
        {
            var c = new CallerIdPerson();

            if (row != null)
            {
                c.Id = Utils.GetDBValue<int>(row["id"]);
                c.Company = Utils.GetDBValue<string>(row, "company");
                c.JobTitle = Utils.GetDBValue<string>(row, "job_title");
                c.FirstName = Utils.GetDBValue<string>(row, "first_name");
                c.LastName = Utils.GetDBValue<string>(row, "last_name");
                c.Picture = Utils.GetDBValue<string>(row, "picture");
                c.Entity = CallerIdPerson.PersonEntity.Contact;
            }

            return c;
        }
    }
}