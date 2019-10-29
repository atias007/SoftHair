using System;
using ClientManage.Interfaces;
using ClientManage.Data;
using System.Xml.Linq;

namespace ClientManage.BL.Library
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

        public static int CalcCredit(string text)
        {
            var maxSmsChars = AppSettingsHelper.GetParamValue<int>("SMS_MAX_CHARS");
            var msgCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(text.Length) / maxSmsChars));

            return msgCount;
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
                    var text =
                        string.IsNullOrEmpty(package.DefaultMessageText) == false && string.IsNullOrEmpty(m.MessageText) ?
                        package.DefaultMessageText :
                        m.MessageText;

                    m.MessageText = text;

                    var result = proxy.SendSms("softhair", SmsToken, text, m.ToPhone, null, m.FromPhone);
                    var doc = XDocument.Parse(result);
                    var response = doc.Root.Element("Status").Value;
                    if (response == "1")
                    {
                        var credit = AppSettingsHelper.GetParamValue<int>("SMS_CREDIT_VALUE");
                        var sendCredit = CalcCredit(text);
                        AppSettingsHelper.SetParamValue("SMS_CREDIT_VALUE", credit - sendCredit, true);

                        try
                        {
                            SmsData.AddSmsLog(m, sendCredit, credit);
                        }
                        catch (Exception)
                        {
                            // *** do nothing *** //
                        }
                    }
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
            catch (Exception)
            {
                if (type == SmsMessageType.ManualForm)
                {
                    throw;
                }
            }

            return result;
        }

        #endregion Methods
    }
}