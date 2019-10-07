using ClientManage.Data;

namespace ClientManage.BL
{
    public class PhoneHelper
    {
        public static bool AddCallLog(int clientId, string phoneNo, int callType, int entity)
        {
            var ret = PhoneData.AddCallLog(clientId, phoneNo, callType, entity);

            return (ret > 0);
        }
    }
}