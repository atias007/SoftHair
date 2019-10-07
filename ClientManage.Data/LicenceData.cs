using System.Data;
using ClientManage.Interfaces;

namespace ClientManage.Data
{
    public class LicenceData
    {
        // add licence row to licence tables
        public static int AddLicense(string key)
        {
            int count;
            var cmd = My.Database.GetSqlStringCommand("DELETE FROM tblLicenses");
            My.Database.ExecuteNonQuery(cmd);
            cmd = My.Database.GetStoredProcCommand("spAddLicense");
            My.Database.AddInParameter(cmd, "prm_key", DbType.String, key);
            count = My.Database.ExecuteNonQuery(cmd);
            return count;
        }

        // read the last licence from licences table
        public static string GetLicense()
        {
            var cmd = My.Database.GetStoredProcCommand("spGetLicense");
            var key = Utils.GetDBValue<string>(My.Database.ExecuteScalar(cmd));
            return key;
        }

        // Update license key
        public static int UpdateLicense(string key)
        {
            var cmd = My.Database.GetStoredProcCommand("spUpdateLicence");
            My.Database.AddInParameter(cmd, "prm_key", DbType.String, key);

            return My.Database.ExecuteNonQuery(cmd);
        }

        public static int UpdateLicense(int id, string key)
        {
            var sql = "UPDATE tblLicenses SET license_key = [?key] WHERE id=" + id;
            var cmd = My.Database.GetSqlStringCommand(sql);
            My.Database.AddInParameter(cmd, "[?key]", DbType.String, key);
            return My.Database.ExecuteNonQuery(cmd);
        }

        public static int DeleteLicense(int id)
        {
            var sql = "DELETE FROM tblLicenses WHERE id=" + id;
            var cmd = My.Database.GetSqlStringCommand(sql);
            return My.Database.ExecuteNonQuery(cmd);
        }

        public static DataSet GetAllLicences()
        {
            var cmd = My.Database.GetStoredProcCommand("spGetAllLicences");
            return My.Database.ExecuteDataSet(cmd);
        }

        public static void ClearAllLicenses()
        {
            const string sql = "DELETE FROM tblLicenses";
            var cmd = My.Database.GetSqlStringCommand(sql);
            My.Database.ExecuteNonQuery(cmd);
        }
    }
}
