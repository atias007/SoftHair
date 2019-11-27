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

        private static void ValidateTableExists(string tableName)
        {
            if (string.IsNullOrEmpty(tableName)) return;

            var query = $"SELECT COUNT(*) FROM [{tableName}]";
            var cmd = Database.GetSqlStringCommand(query);
            var exists = false;

            try
            {
                _db.ExecuteNonQuery(cmd);
                exists = true;
            }
            catch (System.Exception)
            {
                // *** DO NOTHING *** //
            }

            query = null;

            if (exists == false)
            {
                switch (tableName.Trim().ToLower())
                {
                    case "smscredit":
                        query = "create table SmsCredit(Id INTEGER CONSTRAINT CPK PRIMARY KEY, Credit INTEGER, UpdateDate DATETIME)";
                        break;

                    case "smssendlog":
                        query = "create table SmsSendLog(MessageText MEMO, ToPhone VARCHAR(20), FromPhone VARCHAR(20), Credit INTEGER, TotalCredit INTEGER, SendDate DATETIME)";
                        break;

                    default:
                        break;
                }

                if (string.IsNullOrEmpty(query) == false)
                {
                    cmd = Database.GetSqlStringCommand(query);
                    Database.ExecuteNonQuery(cmd);
                }
            }
        }

        public static void ValidateTableExists()
        {
            ValidateTableExists("SmsCredit");
            ValidateTableExists("SmsSendLog");
        }
    }
}