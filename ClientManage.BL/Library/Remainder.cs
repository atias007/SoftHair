using ClientManage.Interfaces;
using System;
using System.Collections;
using System.Data;

namespace ClientManage.BL.Library
{
    public delegate void EventPopupHandler(object sender, EventPopupEventArgs e);

    public class Remainder
    {
        public Remainder()
        {
            SoundFile = AppSettingsHelper.GetParamValue<string>("CALENDAR_SOUND_FILE");
        }

        private static string _soundFile = string.Empty;

        //private DataSet _ds;

        //private DataTable RemaindLines
        //{
        //    get
        //    {
        //        if (_ds == null) _ds = CalendarHelper.GetRemainderLines();
        //        return _ds.Tables[0];
        //    }
        //}

        public static string SoundFile
        {
            get { return _soundFile; }
            set { _soundFile = value; }
        }

        public void RefillEvents()
        {
            //_ds = CalendarHelper.GetRemainderLines();
        }

        public RemainderItem[] GetCurrentEvents()
        {
            //var now = DateTime.Now;
            //var list = new ArrayList();

            //for (var i = 0; i < RemaindLines.Rows.Count; i++)
            //{
            //    var row = RemaindLines.Rows[i];
            //    var isOk = Convert.ToBoolean(row["remainder_dismiss"]) == false &&
            //                (DBNull.Value.Equals(row["remainder_popup_date"]) || Convert.ToInt32(row["remainder_snooze_min"]) > 0);

            //    if (isOk)
            //    {
            //        DateTime dRef;
            //        var isSnnoze = false;
            //        int iRef;
            //        if (DBNull.Value.Equals(row["remainder_popup_date"]))
            //        {
            //            iRef = Convert.ToInt32(row["remainer_min"]);
            //            dRef = Utils.GetDBValue<DateTime>(row["date_start"]).AddMinutes(-iRef);
            //        }
            //        else
            //        {
            //            iRef = Convert.ToInt32(row["remainder_snooze_min"]);
            //            dRef = Utils.GetDBValue<DateTime>(row["remainder_popup_date"]).AddMinutes(iRef);
            //            isSnnoze = true;
            //        }
            //        if (dRef <= now)
            //        {
            //            if (isSnnoze) row["remainder_snooze_min"] = -1;
            //            else row["remainder_popup_date"] = DateTime.Now;
            //            var item = new RemainderItem(row, Utils.GetDBValue<DateTime>(row["date_start"]).Subtract(now));
            //            list.Add(item);
            //        }
            //    }
            //}

            //if (list.Count > 0) CalendarHelper.UpdateRemainders();

            //list.Sort();
            //var ret = new RemainderItem[list.Count];
            //list.CopyTo(ret);
            //return ret;
            return new RemainderItem[0];
        }
    }

    public class RemainderItem : IComparable
    {
        private readonly DataRow _row;
        private readonly TimeSpan _dueTime;

        public RemainderItem(DataRow eventRow, TimeSpan dueTime)
        {
            _row = eventRow;
            _dueTime = dueTime;
        }

        public DataRow EventRow
        {
            get { return _row; }
        }

        public TimeSpan DueMinutes
        {
            get { return _dueTime; }
        }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            var rItem = (RemainderItem)obj;
            var res = this.DueMinutes.CompareTo(rItem.DueMinutes);
            return res;
        }

        #endregion IComparable Members
    }

    public class EventPopupEventArgs : EventArgs
    {
        private readonly RemainderItem[] _events;

        public EventPopupEventArgs(RemainderItem[] events)
        {
            _events = events;
        }

        public RemainderItem[] Events
        {
            get
            {
                return _events;
            }
        }
    }
}