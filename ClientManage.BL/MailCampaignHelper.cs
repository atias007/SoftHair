using ClientManage.Data;
using ClientManage.Interfaces;
using System.Data;

namespace ClientManage.BL
{
    public class MailCampaignHelper
    {
        public static DataTable GetMailTemplates()
        {
            return MailCampaignData.GetMailTemplates().Tables[0];
        }

        public static string GetMailTemplateHtml(int id)
        {
            var html = MailCampaignData.GetMailTemplateHtml(id);
            html = html.Replace(Utils.AddClientname, AppSettingsHelper.GetParamValue<string>("APP_CLIENT_NAME"));
            return html;
        }

        public static DataTable GetAllMailTemplates()
        {
            return MailCampaignData.GetAllMailTemplates().Tables[0];
        }
    }
}