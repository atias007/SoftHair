using System;

namespace ClientManage.BL.Library
{
    public class DateTimeUtil
    {
        public static DateTime GetServerDateTime()
        {
            try
            {
                var properties = new RestProperties { Method = HttpMethod.Get, Url = new Uri(@"http://worldclockapi.com/api/json/utc/now") };
                var response = Rest.Call<DateTimeInfo>(properties);
                return DateTime.Parse(response.currentDateTime);
            }
            catch (Exception)
            {
                return DateTime.Now;
            }
        }
    }

    public class DateTimeInfo
    {
        public string id { get; set; }
        public string currentDateTime { get; set; }
        public string utcOffset { get; set; }
        public bool isDayLightSavingsTime { get; set; }
        public string dayOfTheWeek { get; set; }
        public string timeZoneName { get; set; }
        public long currentFileTime { get; set; }
        public string ordinalDate { get; set; }
        public object serviceResponse { get; set; }
    }
}