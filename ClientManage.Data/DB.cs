using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ClientManage.Data
{
    public class My
    {
        private static Database _db;

        public static Database Database
        {
            get { return _db ?? (_db = DatabaseFactory.CreateDatabase()); }
        }

        public static void SetCustomDatabase(object db)
        {
            _db = (Database)db;
        }
    }
}
