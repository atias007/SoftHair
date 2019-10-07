using System;
using System.Collections.Generic;
using System.Text;

namespace ClientManage.Interfaces
{
    public class WorkerTraffic
    {
        public enum TrafficFeed { System, Manual, Admin, None = -1 }

        private DateTime _enterDate = DateTime.MinValue;
        private DateTime _leaveDate = DateTime.MinValue;
        private TrafficFeed _enterFeed = TrafficFeed.None;
        private TrafficFeed _leaveFeed = TrafficFeed.None;
        private DateTime _createDate = DateTime.MinValue;
        private string _remark = string.Empty;

        public int Id { get; set; }

        public int WorkerId { get; set; }

        public DateTime EnterDate
        {
            get{return _enterDate;}
            set{_enterDate = value;}
        }
        public DateTime LeaveDate
        {
            get{return _leaveDate;}
            set{_leaveDate = value;}
        }
        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }
        public TrafficFeed EnterFeed
        {
            get{return _enterFeed;}
            set{_enterFeed = value;}
        }
        public TrafficFeed LeaveFeed
        {
            get{return _leaveFeed;}
            set{_leaveFeed = value;}
        }
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        public void SetSameEnterLeaveDate(DateTime date)
        {
            if(!(_leaveDate.Date.Equals(date.Date) || _leaveDate.Equals(DateTime.MinValue)))
                _leaveDate = new DateTime(date.Year, date.Month, date.Day, _leaveDate.Hour, _leaveDate.Minute, _leaveDate.Second);
            if (!(_enterDate.Date.Equals(date.Date) || _enterDate.Equals(DateTime.MinValue)))
                _enterDate = new DateTime(date.Year, date.Month, date.Day, _enterDate.Hour, _enterDate.Minute, _enterDate.Second);
        }
    }
}
