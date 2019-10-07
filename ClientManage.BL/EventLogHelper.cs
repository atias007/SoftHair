using ClientManage.Data;
using ClientManage.Interfaces;

namespace ClientManage.BL
{
    public class EventLogHelper
    {
        public static int AddEvent(LogInfo log)
        {
            return EventLogData.AddEvent(log);
        }
    }
}