using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using ClientManage.Interfaces;

namespace ClientManage.Data
{
    public class PhoneData
    {
        public static int AddCallLog(int clientId, string phoneNo, int callType, int entity)
        {
            var cmd = My.Database.GetStoredProcCommand("spAddCallLog");
            My.Database.AddInParameter(cmd, "prm_client_id", DbType.Int32, clientId);
            My.Database.AddInParameter(cmd, "prm_phone_no", DbType.String, phoneNo);
            My.Database.AddInParameter(cmd, "prm_call_date", DbType.DateTime, Utils.GetDateTimeValueForDB(DateTime.Now));
            My.Database.AddInParameter(cmd, "prm_call_type", DbType.Int32, callType);
            My.Database.AddInParameter(cmd, "prm_entity_type", DbType.Int32, entity);

            return My.Database.ExecuteNonQuery(cmd);
        }
    }
}
