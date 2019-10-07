using System;
using System.Data;
using ClientManage.Interfaces;

namespace ClientManage.Data
{
    public class EventLogData
    {
        public static int AddEvent(LogInfo log)
        {
            //var cmd = My.Database.GetStoredProcCommand("EventLog_AddEvent");
            
            //My.Database.AddInParameter(cmd, "[?type]", DbType.Int32, Convert.ToInt32(log.Type));
            //My.Database.AddInParameter(cmd, "[?event_text]", DbType.String, log.EventText);
            //My.Database.AddInParameter(cmd, "[?parameters]", DbType.String, log.Parameters);

            //var count = My.Database.ExecuteNonQuery(cmd);
            //return count;
            return 1;
        }
    }
}
