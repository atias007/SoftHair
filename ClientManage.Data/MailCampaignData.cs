using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using ClientManage.Interfaces.Schemas;
using ClientManage.Interfaces;

namespace ClientManage.Data
{
    public class MailCampaignData
    {
        public static DataSet GetMailTemplates()
        {
            var cmd = My.Database.GetStoredProcCommand("spGetMailTemplates");
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }

        public static string GetMailTemplateHtml(int id)
        {
            var cmd = My.Database.GetStoredProcCommand("spGetMailTemplateHtml");
            My.Database.AddInParameter(cmd, "prmId", DbType.String, id);
            var ret = Utils.GetDBValue<string>(My.Database.ExecuteScalar(cmd));
            return ret;
        }

        public static DataSet GetAllMailTemplates()
        {
            var cmd = My.Database.GetStoredProcCommand("spGetAllMailTemplates");
            var ds = My.Database.ExecuteDataSet(cmd);
            return ds;
        }
    }
}
