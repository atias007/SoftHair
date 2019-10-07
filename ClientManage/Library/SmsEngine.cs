using System;
using System.Data;
using ClientManage.BL;
using ClientManage.Interfaces;
using ClientManage.SmsFactoryService;

namespace ClientManage.Library
{
    public class SmsEngine
    {
        // *** each new enum must be implemented in ReportHelper.AddCustomFieldsToDsReportDataTable *** //
        public enum SmsMessageType { None, ManualForm, AutoBirthdate, AutoMarriedDate, AutoCalendarRemaind }

        /// <summary>
        /// Gets or sets the last exception.
        /// </summary>
        /// <value>The last exception.</value>
        public Exception LastException {get; private set;}

        private static string _from;
        /// <summary>
        /// Gets from.
        /// </summary>
        /// <value>From.</value>
        public static string From
        {
            get { return _from ?? (_from = AppSettingsHelper.GetParamValue("SMS_FROM")); }
        }

        private static SmsServiceClient _sender;
        /// <summary>
        /// Gets the sender.
        /// </summary>
        /// <value>The sender.</value>
        private static SmsServiceClient Sender
        {
            get { return _sender ?? (_sender = new SmsServiceClient("BasicHttpBinding_ISmsService", AppSettingsHelper.GetParamValue("SMS_WS_SEND_URL"))); }
        }
        
        private static CustomerCredentials _credentials;
        /// <summary>
        /// Gets the credentials.
        /// </summary>
        /// <value>The credentials.</value>
        public static CustomerCredentials Credentials
        {
            get
            {
                return _credentials ?? (_credentials = new CustomerCredentials
                                                           {
                                                               ApplicationId = 1,
                                                               Password =
                                                                   AppSettingsHelper.GetParamValue("SMS_PASSWORD"),
                                                               Username =
                                                                   AppSettingsHelper.GetParamValue("SMS_USERNAME")
                                                           });
            }
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
            package.Credentials = Credentials;

            foreach (var m in package.Messages) m.FromPhone = From;

            try
            {
                Sender.SendPackage(package);
            }
            catch (Exception ex)
            {
                EventLogManager.AddErrorMessage("Error sending SMS package", ex);
                throw;
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
            catch(Exception ex)
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
            catch(Exception ex)
            {
                ret = -1;
                this.LastException = ex;
            }

            return ret;
        }

        /// <summary>
        /// Gets the total messages per day report.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public DataSet GetTotalMessagesPerDayReport(TotalMessagesPerDayFilter filter)
        {
            var cred = Credentials;
            var result = Sender.GetTotalMessagesPerDay(cred, filter);
            return result.ToDataSet();
        }

        /// <summary>
        /// Gets the messages details report.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public DataSet GetMessagesDetailsReport(HistoryMessageFilter filter)
        {
            var cred = Credentials;
            var result = Sender.GetHistoryMessages(cred, filter);
            return result.ToDataSet();
        }

        #endregion
    }
}
