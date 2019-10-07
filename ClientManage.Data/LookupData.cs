using System.Data;


namespace ClientManage.Data
{
    public class LookupData
    {
        public static DataSet GetLookupTable(string tableName, string orderBy)
        {
            var sql = "SELECT * FROM " + tableName;
            if (!string.IsNullOrEmpty(orderBy)) sql += " ORDER BY " + orderBy;
            var cmd = My.Database.GetSqlStringCommand(sql);
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }
    }
}
