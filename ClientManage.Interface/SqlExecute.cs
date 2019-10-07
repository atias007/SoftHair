using System;
using System.Data;
using System.Data.OleDb;

namespace ClientManage.Interfaces
{
    public class SqlExecute : IDisposable
    {
        private readonly OleDbConnection _conn;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlExecute"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public SqlExecute(string connectionString)
        {
            _conn = new OleDbConnection(connectionString);
        }

        /// <summary>
        /// Executes the SQL statement.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <returns></returns>
        public int ExecuteSqlStatement(string sql)
        {
            int res;
            using (var cmd = new OleDbCommand(sql, _conn))
            {
                cmd.CommandType = CommandType.Text;

                try
                {
                    _conn.Open();
                    res = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error execute SQL statement.\n" + ex.Message, ex);
                }
                finally
                {
                    _conn.Close();
                }
            }
            return res;
        }

        public void Dispose()
        {
            if(_conn != null)
            {
                _conn.Dispose();
            }
        }
    }
}
