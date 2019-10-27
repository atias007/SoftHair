using System;
using System.Data;
using ClientManage.BL;
using ClientManage.Interfaces;
using System.Text;
using System.Web;
using System.Net;
using System.IO;

namespace ClientManage.Library
{
    public class SmsEngine
    {
        private const string SmsToken = "DbSzRYSDFqsT";

        // *** each new enum must be implemented in ReportHelper.AddCustomFieldsToDsReportDataTable *** //
        public enum SmsMessageType { None, ManualForm, AutoBirthdate, AutoMarriedDate, AutoCalendarRemaind }

        /// <summary>
        /// Gets or sets the last exception.
        /// </summary>
        /// <value>The last exception.</value>
        public Exception LastException { get; private set; }

        private static string _from;

        /// <summary>
        /// Gets from.
        /// </summary>
        /// <value>From.</value>
        public static string From
        {
            get { return _from ?? (_from = AppSettingsHelper.GetParamValue("SMS_FROM")); }
        }

        /// <summary>
        /// Sends the SMS package.
        /// </summary>
        /// <param name="package">The package.</param>
        /// <param name="type">The type.</param>
        private static void SendSmsPackage(SmsPackage package, SmsMessageType type)
        {
            if (package == null) return;

            package.Title = type.ToString();
            var proxy = new SmsService.SendMessageSoapClient();

            foreach (var m in package.Messages)
            {
                try
                {
                    m.FromPhone = From;

                    var sbXml = new StringBuilder();
                    sbXml.Append("<Inforu>");
                    sbXml.Append("<User>");
                    sbXml.Append("<Username>softhair</Username>");
                    sbXml.Append("<ApiToken>" + SmsToken + "</ApiToken>");
                    sbXml.Append("</User>");
                    sbXml.Append("<Content Type=\"sms\">");
                    sbXml.Append("<Message>" + m.MessageText + "</Message>");
                    sbXml.Append("</Content>");
                    sbXml.Append("<Recipients>");
                    sbXml.Append("<PhoneNumber>" + m.ToPhone + "</PhoneNumber>");
                    sbXml.Append("</Recipients>");
                    sbXml.Append("<Settings>");
                    sbXml.Append("<Sender>" + m.FromPhone + "</Sender>");
                    sbXml.Append("</Settings>");
                    sbXml.Append("</Inforu >");

                    var strXML = HttpUtility.UrlEncode(sbXml.ToString(), System.Text.Encoding.UTF8);
                    var result = proxy.SendSms("softhair", SmsToken, m.MessageText, m.ToPhone, null, m.FromPhone);
                }
                catch (Exception ex)
                {
                    EventLogManager.AddErrorMessage("Error sending SMS package", ex);
                    throw;
                }
            }
        }

        #region Methods

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="package">The package.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public bool SendMessage(SmsPackage package, SmsMessageType type)
        {
            var result = false;

            try
            {
                SendSmsPackage(package, type);
                result = true;
            }
            catch (Exception ex)
            {
                if (type == SmsMessageType.ManualForm)
                {
                    General.ShowErrorMessageDialog(null, "שליחת SMS", "שליחת הודעות SMS", "שליחת ההודעה/ות לשרת נכשלו אנא נסה שוב מאוחר יותר", ex, "SMS");
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the credit.
        /// </summary>
        /// <returns></returns>
        public int GetCredit()
        {
            int ret;

            try
            {
                var cred = Credentials;
                ret = Sender.GetCredit(cred);
            }
            catch (Exception ex)
            {
                ret = -1;
                this.LastException = ex;
            }

            return ret;
        }

        #endregion Methods
    }
}