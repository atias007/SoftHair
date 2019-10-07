using System;
using System.Windows.Forms;
using ClientManage.BL;
using ClientManage.Interfaces;
using ClientManage.BL.Library;

namespace ClientManage.Library
{
    public class ScheduleTasks
    {
        private readonly TaskCollection _taskCol = new TaskCollection();
        private Remainder _events;
        private readonly Timer _taskTimer;
        private int _tickCount;
        public event EventHandler ExecuteTask;

        private bool _retryOnlineBackup;
        
        public bool RetryOnlineBackup
        {
            get { return _retryOnlineBackup; }
            set
            {
                _taskCol["Backup"].Enable = value;
                _retryOnlineBackup = value;
            }
        }

        public Remainder Events
        {
            get { return _events ?? (_events = new Remainder()); }
        }

        public TaskCollection Tasks
        {
            get { return _taskCol; }
        }

        public ScheduleTasks()
        {
            _taskTimer = new Timer();
            _taskTimer.Tick += TaskTimerTick;
            _taskTimer.Interval = 60000;
            _taskTimer.Enabled = true;

            // *** the order is very important! do not change it *** //
            _taskCol.Add(new Task("UpdateVersion", 360));
            _taskCol.Add(new Task("Remainder"));
            _taskCol.Add(new Task("TrafficEnter", 1, GetSpan("TRAFFIC_ENTER_TIME")));
            _taskCol.Add(new Task("TrafficLeave", 1, GetSpan("TRAFFIC_LEAVE_TIME")));
            _taskCol.Add(new Task("Birthday", 1, GetSpan("MAIN_BIRTHDAY_CHECK_TIME")));
            _taskCol.Add(new Task("Backup", 60, GetSpan("FTP_BACKUP_SPAN")));
            _taskCol.Add(new Task("SyncClients", 60));
            _taskCol.Add(new Task("SyncEvents", 60));
            _taskCol.Add(new Task("License", 360));
            _taskCol.Add(new Task("SMSCalendarNotify", 15));
            _taskCol.Add(new Task("SMSBirthday", 15));    // *** if remove also change "ResetTasks()"
            _taskCol.Add(new Task("SMSMarriedDate", 15)); // *** if remove also change "ResetTasks()"

            _taskCol["Birthday"].Enable = false;
            _taskCol["UpdateVersion"].FirstStart = 2;
            _taskCol["Remainder"].FirstStart = 2;
            _taskCol["SMSCalendarNotify"].FirstStart = 2;
            _taskCol["SMSBirthday"].FirstStart = 3;
            _taskCol["SMSMarriedDate"].FirstStart = 4;
            _taskCol["SyncClients"].FirstStart = 5;
        }

        public void DoStartupTasks()
        {
            MethodInvoker mi = StartTasks;
            mi.BeginInvoke(null, null);
        }

        private void StartTasks()
        {
            TaskTimerTick(_taskTimer, new EventArgs());
        }

        void TaskTimerTick(object sender, EventArgs e)
        {
            var now = DateTime.Now.TimeOfDay;
            _tickCount++;

            for (var i = 0; i < _taskCol.Count; i++)
            {
                var t = _taskCol[i];
                if (t.Enable && (t.FirstStart == 0 || t.FirstStart <= _tickCount))
                {
                    if (_tickCount % t.Interval == 0 || _tickCount == t.FirstStart)
                    {
                        if (t.ApplySpan == false)
                        {
                            if (ExecuteTask != null) ExecuteTask(t, new EventArgs());
                        }
                        else
                        {
                            if (now >= t.Span)
                            {
                                t.Enable = false;
                                if (ExecuteTask != null) ExecuteTask(t, new EventArgs());
                            }
                        }
                    }
                }
            }
            if (now.Hours == 0 && now.Minutes == 0) ResetTasks();
        }

        private static TimeSpan GetSpan(string dbParam)
        {
            var bCheck = Utils.GetIntArray(AppSettingsHelper.GetParamValue<string>(dbParam));
            return new TimeSpan(bCheck[0], bCheck[1], bCheck[2]);
        }

        public void CheckRemainders()
        {
            if (_events == null) _events = new Remainder();
            else Events.RefillEvents();

            var t = _taskCol["Remainder"];
            if (ExecuteTask != null) ExecuteTask(t, new EventArgs());
        }

        private void ResetTasks()
        {
            _retryOnlineBackup = false;
            _taskCol.ResetTasks();
            Events.RefillEvents();
            AppSettingsHelper.ClearHistory();
            _taskCol["SMSBirthday"].Enable = true;
            _taskCol["SMSMarriedDate"].Enable = true;
            _taskCol["SMSBirthday"].Span = new TimeSpan(9, 0, 0);
            _taskCol["SMSMarriedDate"].Span = new TimeSpan(9, 0, 0);
            if (ExecuteTask != null)
            {
                ExecuteTask(new Task("Reset"), new EventArgs());
                ExecuteTask(new Task("License"), new EventArgs());
            }
        }
    }
}
