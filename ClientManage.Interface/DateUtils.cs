using System;
namespace ClientManage.Interfaces
{
    /// <summary>
    /// Common DateTime Methods.
    /// </summary>
    /// 

    public enum Quarter
    {
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4
    }

    public enum Month
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }

    public class DateUtils
    {
        #region Quarters

        public static DateTime GetStartOfQuarter(int Year, Quarter Qtr)
        {
            if (Qtr == Quarter.First)    // 1st Quarter = January 1 to March 31
                return new DateTime(Year, 1, 1, 0, 0, 0, 0);
            else if (Qtr == Quarter.Second) // 2nd Quarter = April 1 to June 30
                return new DateTime(Year, 4, 1, 0, 0, 0, 0);
            else if (Qtr == Quarter.Third) // 3rd Quarter = July 1 to September 30
                return new DateTime(Year, 7, 1, 0, 0, 0, 0);
            else // 4th Quarter = October 1 to December 31
                return new DateTime(Year, 10, 1, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfQuarter(int Year, Quarter Qtr)
        {
            if (Qtr == Quarter.First)    // 1st Quarter = January 1 to March 31
                return new DateTime(Year, 3, DateTime.DaysInMonth(Year, 3), 23, 59, 59, 999);
            else if (Qtr == Quarter.Second) // 2nd Quarter = April 1 to June 30
                return new DateTime(Year, 6, DateTime.DaysInMonth(Year, 6), 23, 59, 59, 999);
            else if (Qtr == Quarter.Third) // 3rd Quarter = July 1 to September 30
                return new DateTime(Year, 9, DateTime.DaysInMonth(Year, 9), 23, 59, 59, 999);
            else // 4th Quarter = October 1 to December 31
                return new DateTime(Year, 12, DateTime.DaysInMonth(Year, 12), 23, 59, 59, 999);
        }

        public static Quarter GetQuarter(Month Month)
        {
            if (Month <= Month.March)
                // 1st Quarter = January 1 to March 31
                return Quarter.First;
            else if ((Month >= Month.April) && (Month <= Month.June))
                // 2nd Quarter = April 1 to June 30
                return Quarter.Second;
            else if ((Month >= Month.July) && (Month <= Month.September))
                // 3rd Quarter = July 1 to September 30
                return Quarter.Third;
            else // 4th Quarter = October 1 to December 31
                return Quarter.Fourth;
        }

        public static DateTime GetEndOfLastQuarter()
        {
            if ((Month)DateTime.Now.Month <= Month.March)
                return GetEndOfQuarter(DateTime.Now.Year - 1, Quarter.Fourth);
            else
                return GetEndOfQuarter(DateTime.Now.Year, (Quarter)(GetQuarter((Month)DateTime.Now.Month) - 1));
        }

        public static DateTime GetStartOfLastQuarter()
        {
            if ((Month)DateTime.Now.Month <= Month.March)
                return GetStartOfQuarter(DateTime.Now.Year - 1, Quarter.Fourth);
            else
                return GetStartOfQuarter(DateTime.Now.Year, (Quarter)(GetQuarter((Month)DateTime.Now.Month) - 1));
        }

        public static DateTime GetStartOfCurrentQuarter()
        {
            return GetStartOfQuarter(DateTime.Now.Year, GetQuarter((Month)DateTime.Now.Month));
        }

        public static DateTime GetEndOfCurrentQuarter()
        {
            return GetEndOfQuarter(DateTime.Now.Year, GetQuarter((Month)DateTime.Now.Month));
        }

        public static DateTime GetStartOfNextQuarter()
        {
            if ((Month)DateTime.Now.Month >= Month.October)
                return GetStartOfQuarter(DateTime.Now.Year + 1, Quarter.First);
            else 
                return GetStartOfQuarter(DateTime.Now.Year, (Quarter)(GetQuarter((Month)DateTime.Now.Month) + 1));
        }

        public static DateTime GetEndOfNextQuarter()
        {
            if ((Month)DateTime.Now.Month >= Month.October)
                return GetEndOfQuarter(DateTime.Now.Year + 1, Quarter.First);
            else
                return GetEndOfQuarter(DateTime.Now.Year, (Quarter)(GetQuarter((Month)DateTime.Now.Month) + 1));

        }

        #endregion

        #region Weeks

        public static DateTime GetStartOfLastWeek()
        {
            var DaysToSubtract = (int)DateTime.Now.DayOfWeek + 7;
            var dt = DateTime.Now.Subtract(System.TimeSpan.FromDays(DaysToSubtract));
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfLastWeek()
        {
            var dt = GetStartOfLastWeek().AddDays(6);
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
        }

        public static DateTime GetStartOfCurrentWeek()
        {
            var DaysToSubtract = (int)DateTime.Now.DayOfWeek;
            var dt =
              DateTime.Now.Subtract(System.TimeSpan.FromDays(DaysToSubtract));
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfCurrentWeek()
        {
            var dt = GetStartOfCurrentWeek().AddDays(6);
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
        }

        public static DateTime GetStartOfNextWeek()
        {
            var DaysToAdd = 7 - (int)DateTime.Now.DayOfWeek;
            var dt = DateTime.Now.Add(System.TimeSpan.FromDays(DaysToAdd));
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfNextWeek()
        {
            var dt = GetStartOfNextWeek().AddDays(6);
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
        }

        #endregion

        #region Months

        public static DateTime GetStartOfMonth(Month Month, int Year)
        {
            return new DateTime(Year, (int)Month, 1, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfMonth(Month Month, int Year)
        {
            return new DateTime(Year, (int)Month,
               DateTime.DaysInMonth(Year, (int)Month), 23, 59, 59, 999);
        }

        public static DateTime GetStartOfLastMonth()
        {
            if (DateTime.Now.Month == 1)
                return GetStartOfMonth((Month)12, DateTime.Now.Year - 1);
            else
                return GetStartOfMonth((Month)(DateTime.Now.Month - 1), DateTime.Now.Year);
        }

        public static DateTime GetEndOfLastMonth()
        {
            if (DateTime.Now.Month == 1)
                return GetEndOfMonth((Month)12, DateTime.Now.Year - 1);
            else
                return GetEndOfMonth((Month)(DateTime.Now.Month - 1), DateTime.Now.Year);
        }

        public static DateTime GetStartOfCurrentMonth()
        {
            return GetStartOfMonth((Month)DateTime.Now.Month, DateTime.Now.Year);
        }

        public static DateTime GetEndOfCurrentMonth()
        {
            return GetEndOfMonth((Month)DateTime.Now.Month, DateTime.Now.Year);
        }

        public static DateTime GetStartOfNextMonth()
        {
            if (DateTime.Now.Month == 12)
                return GetStartOfMonth((Month)1, DateTime.Now.Year + 1);
            else
                return GetStartOfMonth((Month)(DateTime.Now.Month + 1), DateTime.Now.Year);
        }

        public static DateTime GetEndOfNextMonth()
        {
            if (DateTime.Now.Month == 12)
                return GetEndOfMonth((Month)1, DateTime.Now.Year + 1);
            else
                return GetEndOfMonth((Month)(DateTime.Now.Month + 1), DateTime.Now.Year);
        }

        #endregion

        #region Years
        public static DateTime GetStartOfYear(int Year)
        {
            return new DateTime(Year, 1, 1, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfYear(int Year)
        {
            return new DateTime(Year, 12,
              DateTime.DaysInMonth(Year, 12), 23, 59, 59, 999);
        }

        public static DateTime GetStartOfLastYear()
        {
            return GetStartOfYear(DateTime.Now.Year - 1);
        }

        public static DateTime GetEndOfLastYear()
        {
            return GetEndOfYear(DateTime.Now.Year - 1);
        }

        public static DateTime GetStartOfCurrentYear()
        {
            return GetStartOfYear(DateTime.Now.Year);
        }

        public static DateTime GetEndOfCurrentYear()
        {
            return GetEndOfYear(DateTime.Now.Year);
        }

        public static DateTime GetStartOfNextYear()
        {
            return GetStartOfYear(DateTime.Now.Year + 1);
        }

        public static DateTime GetEndOfNextYear()
        {
            return GetEndOfYear(DateTime.Now.Year + 1);
        }

        #endregion

        #region Days
        public static DateTime GetStartOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month,
                                 date.Day, 23, 59, 59, 999);
        }

        public static DateTime GetStartOfCurrentDay()
        {
            return GetStartOfDay(DateTime.Now);
        }

        public static DateTime GetEndOfCurrentDay()
        {
            return GetEndOfDay(DateTime.Now);
        }

        public static DateTime GetStartOfLastDay()
        {
            return GetStartOfDay(DateTime.Now.AddDays(-1));
        }

        public static DateTime GetEndOfLastDay()
        {
            return GetEndOfDay(DateTime.Now.AddDays(-1));
        }

        public static DateTime GetStartOfNextDay()
        {
            return GetStartOfDay(DateTime.Now.AddDays(1));
        }

        public static DateTime GetEndOfNextDay()
        {
            return GetEndOfDay(DateTime.Now.AddDays(1));
        }

        #endregion

        public static DateDiffSummary GetDateDiffSum(DateTime fromDate, DateTime toDate)
        {
            return new DateDiffSummary(fromDate, toDate);
        }
    }

    public class DateDiffSummary
    {
        public DateDiffSummary(DateTime fromDate, DateTime toDate)
        {
            _fromDate = fromDate;
            _toDate = toDate;
            Calculate();
        }
        
        private int _years;
        public int Years
        {
            get { return _years; }
        }
        private int _months;
        public int Months
        {
            get { return _months; }
        }
        private int _days;
        public int Days
        {
            get { return _days; }
        }
        private DateTime _fromDate;
        public DateTime FromDate
        {
            get { return _fromDate; }
            set 
            { 
                _fromDate = value;
                Calculate();
            }
        }
        private DateTime _toDate;
        public DateTime ToDate
        {
            get { return _toDate; }
            set 
            { 
                _toDate = value;
                Calculate();
            }
        }

        private void Calculate()
        {           
            Clear();
            if (_fromDate < _toDate)
            {
                _years = _toDate.Year - _fromDate.Year;
                if (_fromDate.Month > _toDate.Month) _years--;

                _months = _toDate.Month - _fromDate.Month;
                if (_months < 0) _months += 12;
                if (_fromDate.Day > _toDate.Day) _months--;

                var ts = _toDate.Subtract(_fromDate.AddYears(_years).AddMonths(_months));
                _days = ts.Days;
            }
        }

        private void Clear()
        {
            _years = 0;
            _months = 0;
            _days = 0;
        }

        public override string ToString()
        {
            var desc = string.Empty;

            if (_years > 0)
            {
                desc = _years == 1 ? "שנה" : _years.ToString() + " שנים";
            }
            if (_months > 0)
            {
                if (desc.Length > 0) desc += ", ";
                desc += (_months == 1 ? "חודש" : _months.ToString() + " חודשים");
            }
            if (_days > 0)
            {
                if (desc.Length > 0) desc += ", ";
                desc += (_days == 1 ? "יום" : _days.ToString() + " ימים");
            }

            return desc;
        }
    }
}
