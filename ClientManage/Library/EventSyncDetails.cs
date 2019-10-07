using System;
using System.Data;
using ClientManage.BL;
using ClientManage.Interfaces;

namespace ClientManage.SmsFactoryCommon
{
    public partial class EventsSyncDetails
    {
        public EventsSyncDetails(DataRow row)
        {
            var reminderMin = Utils.GetDBValue<int>(row, "remainer_min");
            var active = Utils.GetDBValue<bool>(row, "active");
            this.CareIds = Utils.GetDBValue<string>(row, "cares");
            this.CategoryId = Utils.GetDBValue<int>(row, "recurrence_id");
            this.ClientId = Utils.GetDBValue<int>(row, "client_id");
            this.ClientTitle = Utils.GetDBValue<string>(row, "client_title");
            this.DateCreated = Utils.GetDBValue<DateTime>(row, "date_created"); //.ToUniversalTime();
            this.DateEnd = Utils.GetDBValue<DateTime>(row, "date_end"); //.ToUniversalTime();
            var value = Utils.GetDBValue<DateTime?>(row, "date_alerted");
            this.DateSmsNotified = value == null ? value : value.Value; //.ToUniversalTime();
            this.DateStart = Utils.GetDBValue<DateTime>(row, "date_start"); //.ToUniversalTime();
            this.HasSmsNotified = Utils.GetDBValue<bool>(row, "has_alert");
            this.Id = Utils.GetDBValue<int>(row, "id");
            this.Importance = Utils.GetDBValue<int>(row, "importance");
            this.IsAllDayEvent = Utils.GetDBValue<bool>(row, "all_day_event");
            this.ReminderMinutes = reminderMin;
            this.WorkerId = Utils.GetDBValue<int>(row, "worker_id");
            this.WorkerTitle = Utils.GetDBValue<string>(row, "worker_title");
            this.Location = this.WorkerTitle;
            this.Status = active ? 1 : 0;
            this.HasReminder = reminderMin >= 0;
            this.CareDescription = CalendarHelper.GetCaresDescription(this.CareIds);
            this.Title = Utils.GetDBValue<string>(row, "subject");

            //*** need to be last **//
            this.Description = GetSammery(row);
        }

        /// <summary>
        /// Gets the sammery.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <returns></returns>
        private string GetSammery(DataRow row)
        {
            var title = string.Empty;
            var subject = Utils.GetDBValue<string>(row, "subject");

            if (!string.IsNullOrEmpty(this.ClientTitle))
            {
                title = this.ClientTitle;
            }
            if (string.IsNullOrEmpty(this.ClientTitle) && !string.IsNullOrEmpty(subject))
            {
                title = subject;
            }
            if (string.IsNullOrEmpty(title))
            {
                title = "[ללא שם]";
            }
            title += ": ";

            if (!string.IsNullOrEmpty(this.CareIds))
            {
                title += this.CareDescription + " ";
            }
            
            if (title.EndsWith(": "))
            {
                title = title.Substring(0, title.Length - 2);
            }
            title = title.Trim();
            
            return title;
        }
    }
}
