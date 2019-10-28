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

        public static void ValidateTableExists(string tableName)
        {
            if (string.IsNullOrEmpty(tableName)) return;

            var query = $"SELECT COUNT(*) FROM [{tableName}]";
            var cmd = Database.GetSqlStringCommand(query);
            var exists = false;

            try
            {
                cmd.ExecuteNonQuery();
                exists = true;
            }
            catch (System.Exception)
            {
                // *** DO NOTHING *** //
            }

            query = null;

            if (exists == false)
            {
                switch (tableName.Trim())
                {
                    case "smscredit":
                        query = "create table SmsCredit(Id INTEGER CONSTRAINT CPK PRIMARY KEY, Credit INTEGER, UpdateDate DATETIME)";
                        break;

                    default:
                        break;
                }

                if (string.IsNullOrEmpty(query) == false)
                {
                    cmd = Database.GetSqlStringCommand(query);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}