using System;
using System.Data;
using System.Data.OleDb;

namespace BizCareAdmin
{
    public class SqlExecute
    {
        private OleDbConnection _conn;
        private OleDbCommand _cmd;

        public void InitilizeDBConnection(string filename)
        {
            var connString = Properties.Resources.ConnectionString;
            connString = string.Format(connString, filename);

            try
            {
                _conn = new OleDbConnection(connString);
                _conn.Open();
                _conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error initialize database connection", ex);
            }
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
                throw new Exception("Error execute SQL statement.\n" + ex.Message, ex);
            }
            finally { _conn.Close(); }
            return res;
        }

        public DataSet ExecuteDataset(string sql)
        {
            var adp = new OleDbDataAdapter(sql, _conn);

            var ds = new DataSet();
            adp.Fill(ds);
            return ds;
        }

        public DataTable GetSchema(string schema)
        {
            _conn.Open();
            var table = _conn.GetSchema(schema);
            _conn.Close();
            return table;
        }
        public DataTable GetSchema()
        {
            _conn.Open();
            var table = _conn.GetSchema();
            _conn.Close();
            return table;
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
            }
            catch (Exception ex)
            {
                throw new Exception("Error while try to get parameter \"" + name + "\"", ex);
            }
            finally { _conn.Close(); }

            return ret;
        }
    }
}
