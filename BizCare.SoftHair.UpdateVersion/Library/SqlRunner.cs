using System;
using System.Data.OleDb;
using System.Data;
using ClientManage.Interfaces.Schemas;
using ClientManage.Interfaces;

namespace BizCare.SoftHair.UpdateVersion.Library
{
    public class SqlRunner : ActionBase
    {
        private OleDbConnection _conn;
        private OleDbCommand _cmd;
        private OleDbDataAdapter _adp;
        public string ConnectionString { get; private set; }

        public SqlRunner(string connectionString) 
        {
            ConnectionString = connectionString;
        }

        public void InitilizeDbConnection()
        {
            _conn = new OleDbConnection(ConnectionString);
            _conn.Open();
            _conn.Close();
            OnLogCreated(new LogEntry("Initilize database connection"));
        }

        public int ExecuteSqlStatement(string sql)
        {
            _cmd = new OleDbCommand(sql, _conn) {CommandType = CommandType.Text};
            int res;

            try
            {
                _conn.Open();
                res = _cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה בביצוע שאילתה\n", ex);
            }
            finally 
            { 
                if(_conn != null) _conn.Close(); 
            }
            return res;
        }

        public string GetParameter(string name)
        {
            var sql = "SELECT param_value FROM tblParams WHERE param_name = \"" + name + "\"";
            string ret;
            _cmd = new OleDbCommand(sql, _conn) {CommandType = CommandType.Text};

            try
            {
                _conn.Open();
                ret = Convert.ToString(_cmd.ExecuteScalar());
                OnLogCreated(new LogEntry("Read parameter " + name + " (value = " + ret + ")"));
            }
            catch(Exception ex)
            {
                throw new ApplicationException("Fail to read parameter " + name, ex);
            }
            finally 
            { 
                _conn.Close(); 
            }

            return ret;
        }

        public DataSet GetDataSet(string commandText, CommandType commandType)
        {
            _cmd = new OleDbCommand(commandText, _conn) {CommandType = commandType};
            _adp = new OleDbDataAdapter(_cmd);
            var ds = new DataSet();
            _adp.Fill(ds);
            return ds;
        }

        public DataTable GetAllReports()
        {
            return GetDataSet("SELECT id, report_xml FROM tblReports", CommandType.Text).Tables[0];
        }

        public void UpdateReport(int id, ReportSchema report)
        {
            var row = report.General[0];
            var xml = Security.EncryptReport(report).GetXml();

            _cmd = new OleDbCommand("spUpdateReport", _conn) {CommandType = CommandType.StoredProcedure};
            _cmd.Parameters.AddWithValue("prmId", row.ReportId);
            _cmd.Parameters.AddWithValue("prmName", row.ReportName);
            _cmd.Parameters.AddWithValue("prmGroup", row.ReportGroup);
            _cmd.Parameters.AddWithValue("prmXml", xml);
            _cmd.Parameters.AddWithValue("prmOldId", id);
            _conn.Open();
            _cmd.ExecuteNonQuery();
            _conn.Close();
        }

        public void AddUpdateReport(string html)
        {
            const string sql = "INSERT INTO tblUpdateVersionReports (report_text) VALUES ([?report_text])";
            _cmd = new OleDbCommand(sql, _conn) {CommandType = CommandType.Text};
            _cmd.Parameters.AddWithValue("report_text", html);
            _conn.Open();
            _cmd.ExecuteNonQuery();
            _conn.Close();
        }
    }
}
