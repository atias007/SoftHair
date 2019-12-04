using BizCare.Calendar.Library;
using ClientManage.BL;
using ClientManage.BL.Library;
using ClientManage.Interfaces;
using ClientManage.Library;
using ClientManage.UserControls;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ClientManage.Forms
{
    public partial class FormCalendar : BaseMdiChild
    {
        #region Constructor

        public FormCalendar()
        {
            InitializeComponent();
            _strMsg = lblMsgWait1.Text;
            panel1.Controls.Add(pnlAttachMsg);
            pnlAttachMsg.Location = new Point(1, lblClientCaption.Top + lblClientCaption.Height);
            pnlAttachMsg.BringToFront();
            dtPicker.BoldDates = CalendarHelper.GetMonthBoldedDates(dtPicker.Month, dtPicker.Year);
        }

        #endregion Constructor

        #region Private

        #region Members

        private const string AppNoText = "ללא תיאור";

        private FormClientQuickSearch _fClientQuickSearch;
        private FormCarePick _fCarePick;
        private FormAttachMessage _fAttachMessage;
        private System.Windows.Forms.Timer _timer;
        private Thread _threadSetBoldDates;
        private bool _isLoadProc;
        private bool _inTimeSetProc;
        private bool _inFillAppDetailProc;
        private bool _isIgnoreEvent;
        private readonly string _strMsg = string.Empty;
        private string _detailsAppId = null;
        private int _iStart, _iEnd;

        #endregion Members

        #region Functions

        private bool IsReloadOk()
        {
            if ((_fClientQuickSearch == null || _fClientQuickSearch.IsDisposed) == false) return false;
            if ((_fCarePick == null || _fCarePick.IsDisposed) == false) return false;
            if (DateTime.Now.Subtract(LastActivity).TotalMinutes < 30) return false;
            return true;
        }

        private void ResetLastActivity()
        {
            LastActivity = DateTime.Now;
        }

        private void UpdatePartOfAppointment(GeneralCubeEventArgs e)
        {
            switch (e.EditMode)
            {
                case GeneralCubeEventArgs.EditModeMember.None:
                    break;

                case GeneralCubeEventArgs.EditModeMember.Text:
                    try
                    {
                        CalendarHelper.SetAppointmentText(e.Appointment.Text, e.Appointment.Id);
                    }
                    catch (Exception ex)
                    {
                        General.ShowCommunicationError(ex, this);
                    }
                    break;

                case GeneralCubeEventArgs.EditModeMember.WorkerId:
                    try
                    {
                        CalendarHelper.SetAppointmentWorker(e.Appointment.WorkerId, e.Appointment.Id);
                    }
                    catch (Exception ex)
                    {
                        General.ShowCommunicationError(ex, this);
                        return;
                    }
                    RefreshClient?.Invoke(this, new ClientOperationEventArgs("RefreshClient", e.Appointment.ClientId));
                    break;

                case GeneralCubeEventArgs.EditModeMember.Time:
                    try
                    {
                        CalendarHelper.UpdateAppointmentTime(e.Appointment.StartDate, e.Appointment.EndDate, e.Appointment.Id);
                    }
                    catch (Exception ex)
                    {
                        General.ShowCommunicationError(ex, this);
                        return;
                    }
                    RefreshClient?.Invoke(this, new ClientOperationEventArgs("RefreshClient", e.Appointment.ClientId));
                    break;

                case GeneralCubeEventArgs.EditModeMember.Remainder:
                    try
                    {
                        CalendarHelper.UpdateAppointmentRemainder(e.Appointment.RemainderMinutes, e.Appointment.Id);
                    }
                    catch (Exception ex)
                    {
                        General.ShowCommunicationError(ex, this);
                        return;
                    }
                    RefreshRemainder?.Invoke(this, new EventArgs());
                    break;

                case GeneralCubeEventArgs.EditModeMember.Category:
                    try
                    {
                        CalendarHelper.SetCategory(e.Appointment.RecurrenceId, e.Appointment.Id);
                    }
                    catch (Exception ex)
                    {
                        General.ShowCommunicationError(ex, this);
                        return;
                    }
                    break;
            }
        }

        private void CheckForEmptyNonWorkerPanel()
        {
            var exist = cal.Workers.Contains(0);
            if (exist && cal.Workers.Contains(0) == false)
            {
                cal.RedrawAllPanels();
            }
        }

        private void SelectWorkerComboItem(int workerId)
        {
            for (var i = 1; i < imageComboBox1.Items.Count; i++)
            {
                if (Convert.ToInt32(((ImageComboBoxListItem)imageComboBox1.Items[i]).Tag) == workerId)
                {
                    imageComboBox1.SelectedIndex = i;
                    break;
                }
            }
        }

        private void LoadAppointments(DateTime toDate)
        {
            DataSet ds;
            try
            {
                ds = CalendarHelper.GetDayCalendarEvents(toDate);
            }
            catch (Exception ex)
            {
                General.ShowCommunicationError(ex, this);
                return;
            }
            cal.Appointments.Clear();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                var app = GetAppointmentFromDataRow(row);
                if (app != null)
                {
                    cal.Appointments.Add(app);
                }
            }

            cal.RebindAppointments();
            cal.Select();
        }

        private void LoadWorkers()
        {
            imageComboBox1.Items.Clear();
            cal.Workers.Clear();

            var item = new ImageComboBoxListItem("כל העובדים\nבעסק", 0) { Tag = 0 };
            imageComboBox1.Items.Add(item);

            var workers = WorkersHelper.GetWorkersForCalendar();
            foreach (DataRow row in workers.Rows)
            {
                var id = (int)row["id"];
                var image = LoadWorkerPicture(Utils.GetDBValue<string>(row, "picture"));
                var text = Utils.GetDBValue<string>(row, "first_name") + "\n" + Utils.GetDBValue<string>(row, "last_name");
                if (image == null)
                {
                    item = new ImageComboBoxListItem(text, 1);
                }
                else
                {
                    imageList1.Images.Add(image);
                    item = new ImageComboBoxListItem(text, imageList1.Images.Count - 1);
                }
                item.Tag = id;
                imageComboBox1.Items.Add(item);
                cal.Workers.Add(new CalendarWorker(id, text.Replace("\n", " ")));
            }
        }

        private static Image LoadWorkerPicture(string filename)
        {
            Image ret = null;
            try
            {
                if (File.Exists(filename))
                {
                    ret = Image.FromFile(filename);
                }
            }
            catch
            {
                ret = null;
            }

            return ret;
        }

        private void SetClientPicture(int id)
        {
            if (id == 0)
            {
                picView.BackgroundImage = Properties.Resources.no_client_big;
                picView.Cursor = Cursors.Default;
                lblFirstName.Text = string.Empty;
                lblLastName.Text = string.Empty;
                this.Tooltip.SetToolTip(picView, string.Empty);
                btnClearClient.Visible = false;
            }
            else
            {
                var param = CalendarHelper.GetClientPicture(id);
                lblFirstName.Text = param[0];
                lblLastName.Text = param[1];
                this.Tooltip.SetToolTip(picView, "לחץ על מנת להציג את כרטיס הלקוח");
                try
                {
                    if (File.Exists(param[2]))
                    {
                        picView.BackgroundImage = Image.FromFile(param[2]);
                    }
                    else
                    {
                        picView.BackgroundImage = Properties.Resources.no_image_medium;
                    }
                }
                catch
                {
                    picView.BackgroundImage = Properties.Resources.no_image_medium;
                }
                btnClearClient.Visible = true;
                picView.Cursor = Cursors.Hand;
            }
            picView.Tag = id;
            this.Select();
        }

        private void DoAttachClientToAppointment(int clientId)
        {
            _detailsAppId = null;
            if (cal.SelectedAppointment == null)
            {
                var dates = cal.GetSelectedScope();
                if (dates != null)
                {
                    var app = new BizCareAppointment
                    {
                        EndDate = dates[1],
                        WorkerId = cal.SelectedWorkerId,
                        RemainderMinutes = -1,
                        StartDate = dates[0],
                        ClientId = clientId,
                    };

                    try
                    {
                        CalendarHelper.AddAppointment(app);
                    }
                    catch (Exception ex)
                    {
                        General.ShowCommunicationError(ex, this);
                    }
                    var id = app.Id;
                    ReloadAppointments();
                    cal.SetAppointmentActive(id);
                    if (RefreshClient != null) RefreshClient(this, new ClientOperationEventArgs("RefreshClient", clientId));
                }
            }
            else
            {
                cal.SelectedAppointment.ClientId = clientId;
                try
                {
                    CalendarHelper.SetClientToAppointment(cal.SelectedAppointment.Id, clientId, cal.SelectedAppointment.StartDate);
                }
                catch (Exception ex)
                {
                    General.ShowCommunicationError(ex, this);
                    return;
                }
                ClearAppointmentText(cal.SelectedAppointment);
                FillAppDetails(cal.SelectedAppointment);
                cal.AttachClientToSelectedAppointment(clientId, ClientHelper.GetFullName(clientId));
                if (RefreshClient != null) RefreshClient(this, new ClientOperationEventArgs("RefreshClient", clientId));
                cal.Focus();
            }
        }

        #endregion Functions

        #endregion Private

        #region Public

        #region Events Declaration

        public event EventHandler RefreshRemainder;

        public event RemainderEventHandler RemoveRemainder;

        public event OpenFormEventHandler OpenEventForm;

        public event ClientOperationEventHandler RefreshClient;

        public event DlgShowClientCardEventHandler ShowClientCard;

        public event EventHandler MainFormFocus;

        public event DialRequestEventHandler DialRequest;

        public event OpenFormEventHandler OpenForm;

        public event EventHandler<ShowReportEventArgs> ShowReport;

        public event EventHandler<CalendarEventArgs> SendSmsReminder;

        public event EventHandler<CalendarEventArgs> AddAttendees;

        public event EventHandler<CalendarEventArgs> ShowHistory;

        //public event EventHandler SyncEvents;

        #endregion Events Declaration

        #region Properies

        public IntPtr CalendarHandler
        {
            get { return cal.Handle; }
        }

        private static SetAppointmentEventArgs _waitingClientArgs;

        public static SetAppointmentEventArgs WaitingClientArgs
        {
            get { return _waitingClientArgs ?? (_waitingClientArgs = SetAppointmentEventArgs.Empty); }
            set { _waitingClientArgs = value; }
        }

        public static string WaitingPhoneNo { get; set; }

        public DateTime[] SelectedScope
        {
            get
            {
                var ret = cal.GetSelectedScope();
                if (ret == null)
                {
                    var dt = cal.CurrentDate;
                    if (dt.Date.Equals(DateTime.Now.Date))
                    {
                        var calEnd = cal.GetEndDate();
                        var calStart = cal.GetStartDate();
                        dt = dt.Date.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute);
                        if (dt.AddMinutes(30) > calEnd) dt = calEnd.AddMinutes(-30);
                        if (dt < calStart) dt = calStart;
                    }
                    else
                    {
                        var calStart = cal.GetStartDate();
                        dt = dt.Date.AddHours(calStart.Hour).AddMinutes(calStart.Minute);
                    }
                    ret = new[] { dt, dt.AddMinutes(30) };
                }
                return ret;
            }
        }

        #endregion Properies

        #region Methods

        public void ShowWaitClientMsg()
        {
            lblMsgWait1.Text = string.Format(_strMsg, ClientHelper.GetFullName(WaitingClientArgs.ClientId)).Trim();
            pnlAttachMsg.Tag = ClientHelper.GetPicture(WaitingClientArgs.ClientId);
            pnlAttachMsg.Visible = true;

            if (_timer == null)
            {
                _timer = new System.Windows.Forms.Timer
                {
                    Interval = AppSettingsHelper.GetParamValue<int>("CALENDAR_ATTACH_MSG_TIME") * 60000
                };
                _timer.Tick += TimerTick;
            }
            _timer.Enabled = false;
            _timer.Enabled = true;
        }

        public void CancelWaitClient()
        {
            WaitingClientArgs = null;
            WaitingPhoneNo = string.Empty;
            pnlAttachMsg.Visible = false;
            if (_timer != null) _timer.Enabled = false;
        }

        public void ClearSelected()
        {
            cal.ClearAnySelected();
        }

        public void CheckForAutoAttachClient()
        {
            if (WaitingClientArgs.ClientId > 0)
            {
                if (cal.SelectedAppointment == null) return;

                if (!(_fAttachMessage == null || _fAttachMessage.IsDisposed))
                {
                    _fAttachMessage = null;
                }

                using (_fAttachMessage = new FormAttachMessage(WaitingClientArgs.ClientId))
                {
                    var res = _fAttachMessage.ShowDialog(this);
                    if (res == DialogResult.Yes)
                    {
                        DoAttachClientToAppointment(WaitingClientArgs.ClientId);
                    }
                }
                CancelWaitClient();
            }
        }

        public int CalendarFocusWorkerId
        {
            get
            {
                return cal.SelectedWorkerId;
            }
        }

        public int SelectedWorkerId
        {
            get
            {
                var worker = Convert.ToInt32(((ImageComboBoxListItem)imageComboBox1.SelectedItem).Tag);
                return worker;
            }
        }

        public void RemoveAppointment(string appointmentId)
        {
            this.Cursor = Cursors.WaitCursor;
            cal.RemoveSelectedAppointment();
            this.Cursor = Cursors.Default;
        }

        public void ReloadAppointments()
        {
            _detailsAppId = null;
            LoadAppointments(cal.CurrentDate);
        }

        public void FocusBack()
        {
            cal.Select();
        }

        public void GoToday()
        {
            if (cal.CurrentDate.Date.Equals(DateTime.Now.Date))
            {
                cal.ClearAnySelected();
            }
            else
            {
                cal.CurrentDate = DateTime.Now;
            }
        }

        public void LocateAppointment(Appointment app)
        {
            if (app == null)
            {
                cal.ClearAnySelected();
                const string msg1 = "התור המבוקש אינו נמצא ביומן\nייתכן והוא נמחק";
                const string msg2 = "יומן תורים...";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
            }
            else
            {
                cal.CurrentDate = app.StartDate;
                cal.SetAppointmentActive(app.Id);
            }
        }

        public void TryLocateAppointment(string appointmentId)
        {
            cal.SetAppointmentActive(appointmentId);
        }

        public static Appointment GetAppointmentFromDataRow(DataRow row)
        {
            if (row == null) return null;
            var app = new Appointment
            {
                Id = Convert.ToString(row["id"]),
                Text = Utils.GetDBValue<string>(row, "subject"),
                StartDate = Utils.GetDBValue<DateTime>(row["date_start"]),
                EndDate = Utils.GetDBValue<DateTime>(row["date_end"]),
                IsAllDayEvent = Convert.ToBoolean(row["all_day_event"]),
                Importance = (Appointment.ImportanceLevel)Convert.ToInt32(row["importance"]),
                RemainderMinutes = Convert.ToInt32(row["remainer_min"]),
                Remark = Utils.GetDBValue<string>(row, "remark"),
                WorkerId = Convert.ToInt32(row["worker_id"]),
                ClientId = Convert.ToInt32(row["client_id"]),
                HasAlert = Utils.GetDBValue<bool>(row, "has_alert"),
                AlertKey = row.Table.Columns.Contains("alert_key") ? Convert.ToString(row["alert_key"]) : string.Empty,
                Attendee = row.Table.Columns.Contains("attendee") ? Convert.ToString(row["attendee"]) : string.Empty
            };
            app.ClientName = ClientHelper.GetFullName(app.ClientId);
            app.Cares = Utils.GetDBValue<string>(row, "cares");
            app.RecurrenceId = Utils.GetDBValue<int>(row["recurrence_id"]);
            app.CaresDescription = CalendarHelper.GetCaresDescription(app.Cares);
            app.CaresDuration = CalendarHelper.GetCaresDuration(app.Cares);

            if (app.Text == null) app.Text = string.Empty;
            if (app.Remark == null) app.Remark = string.Empty;

            return app;
        }

        public void ReloadWorkers()
        {
            _isLoadProc = true;

            var workerId = SelectedWorkerId;
            imageComboBox1.Items.Clear();
            LoadWorkers();
            cal.Initialize();
            ReloadAppointments();
            var index = 0;

            foreach (ImageComboBoxListItem item in imageComboBox1.Items)
            {
                if (Convert.ToInt32(item.Tag) == workerId)
                {
                    index = imageComboBox1.Items.IndexOf(item);
                    break;
                }
            }

            imageComboBox1.SelectedIndex = index;
            _isLoadProc = false;

            ImageComboBox1SelectedIndexChanged(null, null);
            cal.Select();
        }

        #endregion Methods

        #endregion Public

        #region Form & Controls Events

        #region Calendar Events

        //private void CalSizeChanged(object sender, EventArgs e)
        //{
        //cal.RefreshAllPanels();
        //}

        private void CalAddAppointment(object sender, GeneralCubeEventArgs e)
        {
            ResetLastActivity();
            //AutoCompleteAppointment ac = new AutoCompleteAppointment();
            //ac.Detect(e.Appointment);

            var app = new BizCareAppointment
            {
                EndDate = e.Appointment.EndDate,
                Importance = (ImportanceLevel)Convert.ToInt32(e.Appointment.Importance),
                IsAllDayEvent = e.Appointment.IsAllDayEvent,
                WorkerId = e.Appointment.WorkerId,
                RemainderMinutes = e.Appointment.RemainderMinutes,
                Remark = e.Appointment.Remark,
                StartDate = e.Appointment.StartDate,
                Text = e.Appointment.Text,
                RecurrenceId = e.Appointment.RecurrenceId,
                HasAlert = e.Appointment.HasAlert,
                AlertKey = e.Appointment.AlertKey,
            };

            try
            {
                CalendarHelper.AddAppointment(app);
            }
            catch (Exception ex)
            {
                General.ShowCommunicationError(ex, this);
                return;
            }
            e.Appointment.Id = app.Id;
            e.Appointment.WorkerId = app.WorkerId;

            CheckForAutoAttachClient();

            if (app.RemainderMinutes >= 0)
            {
                if (RefreshRemainder != null) RefreshRemainder(this, new EventArgs());
            }

            if (MainFormFocus != null) MainFormFocus(null, null);
            cal.Select();
        }

        private void CalPasteAppointment(object sender, GeneralCubeEventArgs e)
        {
            ResetLastActivity();
            var app = new BizCareAppointment
            {
                EndDate = e.Appointment.EndDate,
                Importance = (ImportanceLevel)Convert.ToInt32(e.Appointment.Importance),
                IsAllDayEvent = e.Appointment.IsAllDayEvent,
                WorkerId = e.Appointment.WorkerId,
                RemainderMinutes = e.Appointment.RemainderMinutes,
                Remark = e.Appointment.Remark,
                StartDate = e.Appointment.StartDate,
                Text = e.Appointment.Text,
                RecurrenceId = e.Appointment.RecurrenceId,
                HasAlert = e.Appointment.HasAlert,
                AlertKey = e.Appointment.AlertKey,
                ClientId = e.Appointment.ClientId,
                Cares = e.Appointment.Cares,
            };

            try
            {
                CalendarHelper.AddAppointment(app);
            }
            catch (Exception ex)
            {
                General.ShowCommunicationError(ex, this);
                return;
            }
            e.Appointment.Id = app.Id;
            e.Appointment.WorkerId = app.WorkerId;
            if (app.RemainderMinutes >= 0)
            {
                if (RefreshRemainder != null) RefreshRemainder(this, new EventArgs());
            }

            if (MainFormFocus != null) MainFormFocus(null, null);
            cal.Select();
        }

        private void CalRemovedAppointment(object sender, GeneralCubeEventArgs e)
        {
            ResetLastActivity();
            var clientId = e.Appointment.ClientId;
            try
            {
                CalendarHelper.DeleteAppointment(e.Appointment.Id, GetAppTitle(e.Appointment));
            }
            catch (Exception ex)
            {
                General.ShowCommunicationError(ex, this);
                return;
            }
            if (RemoveRemainder != null) RemoveRemainder(this, new RemainderEventArgs(e.Appointment.Id));
            CancelWaitClient();
            if (RefreshClient != null) RefreshClient(this, new ClientOperationEventArgs("RefreshClient", clientId));
            CheckForEmptyNonWorkerPanel();
            FillAppDetails();
        }

        public static string GetAppTitle(Appointment app)
        {
            var client = ClientHelper.GetClient(app.ClientId);
            var caresTitle = CalendarHelper.GetCaresDescription(app.Cares);
            var workerName = WorkersHelper.GetWorker(app.WorkerId).FullName;

            var result = string.Format("StartDate: {0:dd/MM/yyyy} {0:HH:mm}, EndDate: {1:dd/MM/yyyy} {1:HH:mm}, ClientId: {2} - {11}, Attendee: {3}, ClientEmail: {4}, Text: {5}, Remark: {6}, IsAllDayEvent: {7}, RemainderMinutes: {8}, WorkerId: {9} - {12}, Cares: {10} - {13}",
                app.StartDate, app.EndDate, app.ClientId, app.Attendee, client?.Email, app.Text, app.Remark, app.IsAllDayEvent, app.RemainderMinutes, app.WorkerId, app.Cares, client?.FullName, workerName, caresTitle);

            return result;
        }

        private void CalCurrentDateChanged(object sender, EventArgs e)
        {
            ResetLastActivity();
            cal.AcceptChanges();
            LoadAppointments(cal.CurrentDate);
            tbbToday.Checked = cal.CurrentDate.Date.Equals(DateTime.Now.Date);
            if (cal.CurrentDate.Date != dtPicker.SelectedDate.Date)
            {
                _isIgnoreEvent = true;
                dtPicker.SelectedDate = cal.CurrentDate;
                _isIgnoreEvent = false;
            }
        }

        //private void CalDeselectAnyAppointment(object sender, EventArgs e)
        //{
        //}

        private void CalSelectAppointment(object sender, GeneralCubeEventArgs e)
        {
            ResetLastActivity();
            FillAppDetails(e.Appointment);
            if (MainFormFocus != null) MainFormFocus(null, null);
            cal.Select();
        }

        private void CalDoubleClickAppointment(object sender, GeneralCubeEventArgs e)
        {
            ResetLastActivity();
            if (cal.SelectedAppointment.WorkerId != -1)
            {
                cal.EditSelectedAppointment();
                CancelWaitClient();
            }
        }

        private void CalDoubleClickEmptyTimeLine(object sender, EventArgs e)
        {
            ResetLastActivity();
            if (pnlAttachMsg.Visible)
            {
                BtnAttachClick(null, null);
            }
            else
            {
                cal.EditSelectedLines();
            }
        }

        private void CalDoubleClickAllDayEventSpace(object sender, EventArgs e)
        {
            ResetLastActivity();
            cal.EditSelectedLines();
        }

        private void CalWorkerExpanded(object sender, EventArgs e)
        {
            ResetLastActivity();
            _isLoadProc = true;
            if (sender == null)
            {
                imageComboBox1.SelectedIndex = 0;
            }
            else
            {
                SelectWorkerComboItem((int)sender);
            }
            _isLoadProc = false;
        }

        private void CalEditAppointment(object sender, GeneralCubeEventArgs e)
        {
            ResetLastActivity();
            UpdatePartOfAppointment(e);

            if (e.EditMode == GeneralCubeEventArgs.EditModeMember.UpdateForm)
            {
                TbbEditClick(null, null);
            }
            else if (e.EditMode == GeneralCubeEventArgs.EditModeMember.Category)
            {
                // Do Nothing
            }
            else
            {
                _detailsAppId = null;
                FillAppDetails(e.Appointment);
                if (MainFormFocus != null) MainFormFocus(null, null);
                cal.Select();
            }
        }

        private void CalCancelEditAppointment(object sender, EventArgs e)
        {
            ResetLastActivity();
            if (MainFormFocus != null) MainFormFocus(null, null);
            cal.Select();
        }

        private void CalMoveAppointment(object sender, EventArgs e)
        {
            ResetLastActivity();
            CheckForEmptyNonWorkerPanel();
        }

        #endregion Calendar Events

        private void TimerTick(object sender, EventArgs e)
        {
            CancelWaitClient();
        }

        private void FrmCalendarLoad(object sender, EventArgs e)
        {
            _isLoadProc = true;
            EnableAppDetails1Area(false);
            EnableAppDetails2Area(false);
            LoadHoursCombos();
            LoadWorkers();
            imageComboBox1.SelectedIndex = 0;
            Select();

            cal.StartTime = AppSettingsHelper.GetParamValue("CALENDAR_START_TIME");
            cal.EndTime = AppSettingsHelper.GetParamValue("CALENDAR_END_TIME");
            cal.Initialize();
            cal.CurrentDate = DateTime.Now;

            _isLoadProc = false;
            cal.Select();
        }

        private void LoadHoursCombos()
        {
            _iStart = Convert.ToInt32(AppSettingsHelper.GetParamValue("CALENDAR_START_TIME").Substring(0, 2));
            _iEnd = Convert.ToInt32(AppSettingsHelper.GetParamValue("CALENDAR_END_TIME").Substring(0, 2));

            for (var i = _iStart; i <= _iEnd; i++)
            {
                var item = i.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');
                cmbStartHour.Items.Add(item);
                cmbEndHour.Items.Add(item);
            }
        }

        public DateTime LastActivity { get; private set; }

        private void FrmCalendarKeyPress(object sender, KeyPressEventArgs e)
        {
            ResetLastActivity();
            if (this.ActiveControl is BizCare.Calendar.CalendarView)
            {
                if (pnlAttachMsg.Visible && e.KeyChar == 13)
                {
                    BtnAttachClick(null, null);
                }
                else
                {
                    cal.HookKeyPress(sender, e);
                }
            }
        }

        private void DtPickerDateChanged(object sender, EventArgs e)
        {
            ResetLastActivity();
            if (_isIgnoreEvent) return;
            cal.AcceptChanges();
            cal.CurrentDate = dtPicker.SelectedDate;
        }

        private void Panel1Paint(object sender, PaintEventArgs e)
        {
            var pen = new Pen(Color.FromArgb(101, 147, 207));
            var rect = new Rectangle(0, 0, panel1.Width - 1, panel1.Height - 1);
            e.Graphics.DrawRectangle(pen, rect);
        }

        private void FrmCalendarPaint(object sender, PaintEventArgs e)
        {
            var cFrom = Color.FromArgb(191, 219, 255);
            var cTo = Color.FromArgb(102, 146, 206);
            var rect = new Rectangle(0, toolStrip.Height - 4, this.Width, this.Height);
            var brush = new LinearGradientBrush(rect, cFrom, cTo, LinearGradientMode.Vertical);

            e.Graphics.FillRectangle(brush, rect);
        }

        private void ImageComboBox1SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isLoadProc)
            {
                if (imageComboBox1.SelectedIndex == 0) cal.UnexpandCurrentWorker();
                else cal.ExpandWorker(SelectedWorkerId);

                cal.Select();
                ResetLastActivity();
            }
        }

        private void Panel1SizeChanged(object sender, EventArgs e)
        {
            pnlAttachMsg.Height = panel1.Height - pnlAttachMsg.Top - 1;
            panel1.Refresh();
        }

        private void BtnClearClientClick(object sender, EventArgs e)
        {
            if (_tikcs + 20000000 > DateTime.Now.Ticks) return;
            Console.Write(DateTime.Now.Ticks - _tikcs);

            cal.AcceptChanges();
            if (cal.SelectedAppointment != null)
            {
                if (!cal.SelectedAppointment.CanClearClient) SetAppointmentNoText(cal.SelectedAppointment);
                var clientId = cal.SelectedAppointment.ClientId;
                try
                {
                    CalendarHelper.ClearClientFromAppointment(cal.SelectedAppointment.Id);
                }
                catch (Exception ex)
                {
                    General.ShowCommunicationError(ex, this);
                    return;
                }
                cal.SelectedAppointment.ClientId = 0;
                cal.AttachClientToSelectedAppointment(0, string.Empty);
                SetClientPicture(0);
                if (RefreshClient != null) RefreshClient(this, new ClientOperationEventArgs("RefreshClient", clientId));
            }
            cal.Select();
            ResetLastActivity();
        }

        private void SetAppointmentNoText(Appointment app)
        {
            txtSubject.Text = AppNoText;
            txtSubject.Tag = AppNoText;
            app.Text = AppNoText;
            cal.SetCurrentCubeText(AppNoText);
            UpdatePartOfAppointment(new GeneralCubeEventArgs(app, GeneralCubeEventArgs.EditModeMember.Text));
        }

        private void ClearAppointmentText(Appointment app)
        {
            if (app.ClientId > 0 || !string.IsNullOrEmpty(app.Cares))
            {
                if (app.Text.Trim().Equals(AppNoText))
                {
                    txtSubject.Text = string.Empty;
                    txtSubject.Tag = string.Empty;
                    app.Text = string.Empty;
                    cal.SetCurrentCubeText(string.Empty);
                    UpdatePartOfAppointment(new GeneralCubeEventArgs(app, GeneralCubeEventArgs.EditModeMember.Text));
                }
            }
        }

        private void TbbDeleteClick(object sender, EventArgs e)
        {
            ResetLastActivity();
            if (cal.SelectedAppointment == null)
            {
                const string msg1 = "לא נבחר תור מהיומן לביטול";
                const string msg2 = "ביטול תור...";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
            }
            else
            {
                string msg1;
                const string msg2 = "ביטול תור...";

                if (cal.SelectedAppointment.WorkerId == -1)
                {
                    msg1 = "לא ניתן לבטל את התור כיוון שהוא אירוע חג";
                    MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                    MsgBox.Show(this);
                }
                else
                {
                    msg1 = "האם אתה בטוח שאתה רוצה לבטל את התור:\n" + cal.SelectedAppointment;
                    MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
                    var res = MsgBox.Show(this);
                    if (res == DialogResult.Yes)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        cal.RemoveSelectedAppointment();
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        private void BtnAttachClientClick(object sender, EventArgs e)
        {
            ResetLastActivity();
            cal.AcceptChanges();
            if (cal.SelectedAppointment == null && cal.GetSelectedScope() == null)
            {
                cal.ClearAnySelected();
                return;
            }

            var rect = btnClearClient.RectangleToScreen(btnClearClient.DisplayRectangle);
            dtPicker.Freez();

            if (_fClientQuickSearch == null || _fClientQuickSearch.IsDisposed)
            {
                this.Cursor = Cursors.WaitCursor;
                _fClientQuickSearch = new FormClientQuickSearch { Left = rect.Left };
                _fClientQuickSearch.Top = rect.Top - _fClientQuickSearch.Height - 2;
                _fClientQuickSearch.ClientSelected += FClientQuickSearchClientSelected;
                _fClientQuickSearch.FormClosed += FClientQuickSearchFormClosed;
                _fClientQuickSearch.Show();
                this.Cursor = Cursors.Default;
            }
            else
            {
                _fClientQuickSearch.Left = rect.Left;
                _fClientQuickSearch.Top = rect.Top - _fClientQuickSearch.Height - 2;
            }
            _fClientQuickSearch.Select();
        }

        private void FClientQuickSearchFormClosed(object sender, FormClosedEventArgs e)
        {
            ResetLastActivity();
            cal.Select();
            MethodInvoker mi = UnFreezDtPicker;
            mi.BeginInvoke(null, null);
        }

        private void UnFreezDtPicker()
        {
            Thread.Sleep(750);
            dtPicker.UnFreez();
        }

        private void FClientQuickSearchClientSelected(object sender, EventArgs e)
        {
            ResetLastActivity();
            var clientId = FormClientQuickSearch.SelectedClientId;
            DoAttachClientToAppointment(clientId);
        }

        private void TbbNewClick(object sender, EventArgs e)
        {
            ResetLastActivity();
            this.Cursor = Cursors.WaitCursor;
            if (OpenEventForm != null) OpenEventForm(this, new OpenFormEventArgs("frmEventDetails"));
            this.Cursor = Cursors.Default;
        }

        private void TbbEditClick(object sender, EventArgs e)
        {
            ResetLastActivity();
            const string msg2 = "עדכון תור...";
            if (cal.SelectedAppointment == null)
            {
                const string msg1 = "לא נבחר תור מהיומן לעדכון";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
            }
            else
            {
                if (cal.SelectedAppointment.WorkerId == -1)
                {
                    const string msg1 = "לא ניתן לפתוח את פרטי התור כיוון שהוא אירוע חג";
                    MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                    MsgBox.Show(this);
                }
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (OpenEventForm != null) OpenEventForm(this, new OpenFormEventArgs("frmEventDetails", cal.SelectedAppointment));
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void TbbPrintClick(object sender, EventArgs e)
        {
            ResetLastActivity();
            this.Cursor = Cursors.WaitCursor;
            var parameters = new string[2];
            parameters[0] = "עבור: " + imageComboBox1.Text + ", לתאריך: " + dtPicker.SelectedDate.ToString("dd/MM/yyyy, ddd");
            var sc = new ScreenCapture();
            var image = sc.CaptureWindow(cal.Handle);
            string filename;
            try
            {
                filename = Utils.GetTempForderPath("shcalendar.bmp");
                image.Save(filename, System.Drawing.Imaging.ImageFormat.Bmp);
            }
            catch { filename = string.Empty; }
            parameters[1] = filename;

            var printer = new HtmlPrinter("CALENDAR_FORM", parameters);
            if (AppSettingsHelper.GetParamValue<bool>("APP_SHOW_PRINTER_DIALOG"))
            {
                printer.ShowPrintDialog();
                this.Cursor = Cursors.Default;
            }
            else
            {
                printer.Print();
                this.Cursor = Cursors.Default;
            }
        }

        private void TxtSubjectEnter(object sender, EventArgs e)
        {
            ResetLastActivity();
            base.TextBoxEnter((TextBox)sender);
        }

        private void TxtSubjectLeave(object sender, EventArgs e)
        {
            ResetLastActivity();
            base.TextBoxLeave((TextBox)sender);
            var value = Convert.ToString(txtSubject.Tag);
            if (txtSubject.Text != value)
            {
                txtSubject.Text = Convert.ToString(txtSubject.Tag);
            }
        }

        #endregion Form & Controls Events

        private void PnlAttachMsgPaint(object sender, PaintEventArgs e)
        {
            var cFrom = Color.FromArgb(255, 218, 124);
            var cTo = Color.FromArgb(230, 146, 23);
            var rect = new Rectangle(0, 0, pnlAttachMsg.Width, pnlAttachMsg.Height);
            var brush = new LinearGradientBrush(rect, cFrom, cTo, LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(brush, rect);

            Image image;
            try
            {
                image = Image.FromFile(Convert.ToString(pnlAttachMsg.Tag));
            }
            catch
            {
                image = Properties.Resources.no_image_big;
            }

            e.Graphics.DrawImage(image, new Rectangle(21, 12, 133, 100));
        }

        private void Button1Click(object sender, EventArgs e)
        {
            ResetLastActivity();
            CancelWaitClient();
            cal.Select();
        }

        // =========================================== New Panel Proc ===========================================

        private void CalSelectedScopeChanged(object sender, EventArgs e)
        {
            ResetLastActivity();
            FillAppDetails();
        }

        private void EnableAppDetails1Area(bool mode)
        {
            var color = mode ? Color.White : Color.FromArgb(250, 250, 250);
            txtSubject.Enabled = mode;
            lblSubject.Enabled = mode;
            lblFirstName.Enabled = mode;
            lblLastName.Enabled = mode;
            lblFNCap.Enabled = mode;
            lblLNCap.Enabled = mode;
            lblSubject.Enabled = mode;
            btnClearClient.Enabled = mode;
            btnOk.Enabled = mode;
            btnAttachClient.Enabled = mode;
            btnCarePick.Enabled = mode;

            //if (mode && cal.SelectedAppointment != null)
            //{
            //    if (!cal.SelectedAppointment.CanClearClient)
            //    {
            //        btnClearClient.Enabled = false;
            //        btnAttachClient.Enabled = false;
            //    }
            //}

            txtSubject.BackColor = color;
        }

        private void EnableAppDetails2Area(bool mode, bool onlyCombos = false)
        {
            var color = mode ? Color.White : Color.FromArgb(250, 250, 250);

            cmbEndHour.Enabled = mode;
            cmbEndMin.Enabled = mode;
            cmbStartHour.Enabled = mode;
            cmbStartMin.Enabled = mode;
            lblEnd.Enabled = mode;
            lblEndSep.Enabled = mode;
            lblStart.Enabled = mode;
            lblStartSep.Enabled = mode;

            cmbEndHour.BackColor = color;
            cmbEndMin.BackColor = color;
            cmbStartHour.BackColor = color;
            cmbStartMin.BackColor = color;

            if (!onlyCombos)
            {
                chkRemainder.Enabled = mode;
                lblRemainder.Enabled = mode;
            }
        }

        private void SetStartEndTime(DateTime[] dates)
        {
            _inTimeSetProc = true;
            var start = dates[0].ToShortTimeString();
            var end = dates[1].ToShortTimeString();
            cmbStartMin.SelectedIndex = cmbStartMin.FindString(start.Substring(3, 2));
            cmbStartHour.SelectedIndex = cmbStartHour.FindString(start.Substring(0, 2));
            cmbEndMin.SelectedIndex = cmbEndMin.FindString(end.Substring(3, 2));
            cmbEndHour.SelectedIndex = cmbEndHour.FindString(end.Substring(0, 2));
            _inTimeSetProc = false;
        }

        private DateTime[] GetStartEndTimeV1(Appointment app)
        {
            var hour = int.Parse(cmbStartHour.Text);
            var min = int.Parse(cmbStartMin.Text);
            var dStart = cal.CurrentDate.Date.AddHours(hour).AddMinutes(min);
            var dEnd = dStart.Add(app.Duration);
            var dCalEndDate = cal.GetEndDate();

            // Validate start hour
            if (dEnd > dCalEndDate)
            {
                dStart = cal.GetEndDate().Subtract(app.Duration);
                dEnd = dCalEndDate;
            }

            return new[] { dStart, dEnd };
        }

        private DateTime[] GetStartEndTimeV2(Appointment app)
        {
            var hour = int.Parse(cmbEndHour.Text);
            var min = int.Parse(cmbEndMin.Text);
            var dStart = app.StartDate;
            var dEnd = cal.CurrentDate.Date.AddHours(hour).AddMinutes(min);
            var dCalEndDate = cal.GetEndDate();
            DateTime[] ret = null;
            var hasChange = false;

            if (dEnd > dCalEndDate) { hasChange = true; dEnd = dCalEndDate; }
            if (dEnd < dStart.AddMinutes(15)) { hasChange = true; dEnd = dStart.AddMinutes(15); }

            if (hasChange) ret = new[] { dStart, dEnd };
            return ret;
        }

        private void SetValuesAtEndCombo()
        {
            // Set values at end hour combo
            cmbEndHour.Items.Clear();
            var iStart = Convert.ToInt32(cmbStartHour.Text);
            for (var i = iStart; i <= _iEnd; i++)
            {
                cmbEndHour.Items.Add(i.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0'));
            }
        }

        private void FillAppDetails(Appointment app = null)
        {
            _inFillAppDetailProc = true;
            DateTime[] dates = null;

            if (app == null)
            {
                dates = cal.GetSelectedScope();
                txtSubject.Text = string.Empty;
                txtSubject.Tag = string.Empty;
                chkRemainder.Checked = false;
                const string title = "תזכורת";
                chkRemainder.Text = title;

                if (dates == null)
                {
                    if (string.IsNullOrEmpty(_detailsAppId)) return;
                    _detailsAppId = string.Empty;
                    SetClientPicture(0);
                    cmbEndHour.SelectedIndex = -1;
                    cmbStartHour.SelectedIndex = -1;
                    cmbEndMin.SelectedIndex = -1;
                    cmbStartMin.SelectedIndex = -1;
                    EnableAppDetails1Area(false);
                    EnableAppDetails2Area(false);
                }
                else
                {
                    _detailsAppId = null;
                    SetClientPicture(0);
                    SetStartEndTime(dates);
                    EnableAppDetails1Area(true);
                    EnableAppDetails2Area(false);
                }
            }
            else
            {
                if (_detailsAppId == app.Id) return;
                _detailsAppId = app.Id;
                SetClientPicture(app.ClientId);
                txtSubject.Text = app.Text;
                txtSubject.Tag = app.Text;
                chkRemainder.Checked = (app.RemainderMinutes >= 0);
                if (!(app.IsAllDayEvent && app.WorkerId == -1))
                {
                    EnableAppDetails1Area(true);
                    EnableAppDetails2Area(true);
                }

                if (app.IsAllDayEvent)
                {
                    cmbEndHour.SelectedIndex = -1;
                    cmbStartHour.SelectedIndex = -1;
                    cmbEndMin.SelectedIndex = -1;
                    cmbStartMin.SelectedIndex = -1;
                    if (app.WorkerId == -1)
                    {
                        EnableAppDetails1Area(false);
                        EnableAppDetails2Area(false);
                    }
                    else
                    {
                        EnableAppDetails2Area(false, true);
                    }
                }
                else
                {
                    EnableAppDetails2Area(true, true);
                    SetStartEndTime(new[] { app.StartDate, app.EndDate });
                }
            }
            _inFillAppDetailProc = false;

            if (pnlAttachMsg.Visible)
            {
                btnAttach.Enabled = dates != null;
                btnCarePick.Enabled = btnAttach.Enabled;
            }
        }

        private void CmbStartHourSelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStartHour.SelectedIndex == -1 || cmbStartMin.SelectedIndex == -1) return;
            if (_inTimeSetProc) { SetValuesAtEndCombo(); cal.Select(); return; }
            var app = cal.SelectedAppointment;
            if (app == null) { cal.Select(); return; }

            var dates = GetStartEndTimeV1(app);
            SetValuesAtEndCombo();
            SetStartEndTime(dates);
            app.StartDate = dates[0];
            app.EndDate = dates[1];
            cal.RefreshWorker(app.WorkerId);
            cal.ReorderAppointments(app.WorkerId);
            UpdatePartOfAppointment(new GeneralCubeEventArgs(app, GeneralCubeEventArgs.EditModeMember.Time));

            cal.Select();
            ResetLastActivity();
        }

        private void CmbStartMinSelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStartHour.SelectedIndex == -1 || cmbStartMin.SelectedIndex == -1) return;
            if (_inTimeSetProc) { cal.Select(); return; }
            var app = cal.SelectedAppointment;
            if (app == null) { cal.Select(); return; }

            var dates = GetStartEndTimeV1(app);
            SetStartEndTime(dates);
            app.StartDate = dates[0];
            app.EndDate = dates[1];
            cal.RefreshWorker(app.WorkerId);
            cal.ReorderAppointments(app.WorkerId);
            UpdatePartOfAppointment(new GeneralCubeEventArgs(app, GeneralCubeEventArgs.EditModeMember.Time));

            cal.Select();
            ResetLastActivity();
        }

        private void CmbEndHourSelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEndHour.SelectedIndex == -1 || cmbEndMin.SelectedIndex == -1) return;
            if (_inTimeSetProc) { cal.Select(); return; }
            var app = cal.SelectedAppointment;
            if (app == null) { cal.Select(); return; }

            var dates = GetStartEndTimeV2(app);
            if (dates != null) SetStartEndTime(dates);

            var before = app.StartDate.ToString("HHmm") + app.EndDate.ToString("HHmm");
            app.StartDate = DateTime.Parse(cal.CurrentDate.ToShortDateString() + " " + cmbStartHour.Text + ":" + cmbStartMin.Text);
            app.EndDate = DateTime.Parse(cal.CurrentDate.ToShortDateString() + " " + cmbEndHour.Text + ":" + cmbEndMin.Text);
            var after = app.StartDate.ToString("HHmm") + app.EndDate.ToString("HHmm");
            if (!before.Equals(after))
            {
                cal.RefreshWorker(app.WorkerId);
                cal.ReorderAppointments(app.WorkerId);
                UpdatePartOfAppointment(new GeneralCubeEventArgs(app, GeneralCubeEventArgs.EditModeMember.Time));
            }

            cal.Select();
            ResetLastActivity();
        }

        private void CmbEndMinSelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEndHour.SelectedIndex == -1 || cmbEndMin.SelectedIndex == -1) return;
            if (_inTimeSetProc) { cal.Select(); return; }
            var app = cal.SelectedAppointment;
            if (app == null) { cal.Select(); return; }

            var dates = GetStartEndTimeV2(app);
            if (dates != null) SetStartEndTime(dates);
            var before = app.StartDate.ToString("HHmm") + app.EndDate.ToString("HHmm");
            app.StartDate = DateTime.Parse(cal.CurrentDate.ToShortDateString() + " " + cmbStartHour.Text + ":" + cmbStartMin.Text);
            app.EndDate = DateTime.Parse(cal.CurrentDate.ToShortDateString() + " " + cmbEndHour.Text + ":" + cmbEndMin.Text);
            var after = app.StartDate.ToString("HHmm") + app.EndDate.ToString("HHmm");
            if (!before.Equals(after))
            {
                cal.RefreshWorker(app.WorkerId);
                cal.ReorderAppointments(app.WorkerId);
                UpdatePartOfAppointment(new GeneralCubeEventArgs(app, GeneralCubeEventArgs.EditModeMember.Time));
            }

            cal.Select();
            ResetLastActivity();
        }

        private void ChkRemainderCheckedChanged(object sender, EventArgs e)
        {
            pnlRemainder.Refresh();
            if (_inFillAppDetailProc) return;
            var app = cal.SelectedAppointment;
            if (app != null)
            {
                if (chkRemainder.Checked)
                {
                    app.RemainderMinutes = AppSettingsHelper.GetParamValue<int>("CALENDAR_REMAINDER_MIN");
                }
                else
                {
                    cal.SelectedAppointment.RemainderMinutes = -1;
                }
                UpdatePartOfAppointment(new GeneralCubeEventArgs(app, GeneralCubeEventArgs.EditModeMember.Remainder));
            }
            cal.Select();
            ResetLastActivity();
        }

        private void PnlRemainderPaint(object sender, PaintEventArgs e)
        {
            if (chkRemainder.Checked)
            {
                var cFrom = Color.FromArgb(206, 226, 252);
                var cTo = Color.LightSteelBlue;
                var pen = new Pen(Color.FromArgb(166, 186, 212));
                var rect = new Rectangle(0, 0, pnlRemainder.Width - 1, pnlRemainder.Height - 1);
                var brush = new LinearGradientBrush(rect, cFrom, cTo, LinearGradientMode.Vertical);
                e.Graphics.FillRectangle(brush, rect);
                e.Graphics.DrawRectangle(pen, rect);
            }
            else
            {
                e.Graphics.Clear(Color.White);
            }
            ResetLastActivity();
        }

        private void BtnOkClick(object sender, EventArgs e)
        {
            ResetLastActivity();
            txtSubject.Text = txtSubject.Text.Trim();
            txtSubject.Tag = txtSubject.Text;
            if (chkRemainder.Enabled) // check if its new cube or existing
            {
                // update selected appointment text
                var app = cal.SelectedAppointment;
                if (app != null)
                {
                    if (txtSubject.Text.Length == 0 && !app.CanClearText)
                    {
                        txtSubject.Text = app.Text;
                        txtSubject.Tag = app.Text;
                        return;
                    }
                    app.Text = txtSubject.Text;
                    cal.SetCurrentCubeText(txtSubject.Text);
                    UpdatePartOfAppointment(new GeneralCubeEventArgs(app, GeneralCubeEventArgs.EditModeMember.Text));
                    cal.Select();
                }
            }
            else
            {
                if (txtSubject.Text.Trim().Length == 0) return;
                var dates = cal.GetSelectedScope();
                if (dates != null)
                {
                    var app = new BizCareAppointment
                    {
                        EndDate = dates[1],
                        WorkerId = cal.SelectedWorkerId,
                        RemainderMinutes = -1,
                        StartDate = dates[0],
                        Text = txtSubject.Text,
                    };

                    try
                    {
                        CalendarHelper.AddAppointment(app);
                    }
                    catch (Exception ex)
                    {
                        General.ShowCommunicationError(ex, this);
                    }
                    var id = app.Id;
                    ReloadAppointments();
                    cal.SetAppointmentActive(id);
                }
            }
        }

        private void TxtSubjectKeyDown(object sender, KeyEventArgs e)
        {
            ResetLastActivity();
            if (e.KeyCode == Keys.Enter)
            {
                BtnOkClick(null, null);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtSubject.Text = Convert.ToString(txtSubject.Tag);
            }
        }

        private void BtnAttachClick(object sender, EventArgs e)
        {
            ResetLastActivity();
            const string calledIdTemplate = "טלפון-{0} בתאריך {1:dd/MM/yyyy} בשעה {1:HH:mm}";
            var dates = cal.GetSelectedScope();
            if (dates != null && (WaitingClientArgs.ClientId > 0 || WaitingClientArgs.ClientId == -1))
            {
                var app = new BizCareAppointment
                {
                    EndDate = dates[1],
                    WorkerId = cal.SelectedWorkerId,
                    RemainderMinutes = -1,
                    StartDate = dates[0],
                    ClientId = (WaitingClientArgs.ClientId == -1 ? 0 : WaitingClientArgs.ClientId),
                    Text = (WaitingClientArgs.ClientId == -1 ? string.Format(calledIdTemplate, WaitingClientArgs.PhoneNumber, WaitingClientArgs.DateCreated) : string.Empty),
                };
                var clientName = ClientHelper.GetFullName(app.ClientId);

                try
                {
                    CalendarHelper.AddAppointment(app);
                }
                catch (Exception ex)
                {
                    General.ShowCommunicationError(ex, this);
                }
                var id = app.Id;
                ReloadAppointments();
                cal.SetAppointmentActive(id);
                CancelWaitClient();
                txtSubject.Select();

                var tmp = cal.SelectedAppointment;
                if (tmp != null)
                {
                    _detailsAppId = null;
                    FillAppDetails(tmp);
                }

                if (RefreshClient != null) RefreshClient(this, new ClientOperationEventArgs("RefreshClient", app.ClientId));
            }
        }

        //private void FrmCalendarFormClosing(object sender, FormClosingEventArgs e)
        //{
        //CalendarHelper.NormalizeScore();
        //CalendarHelper.UpdateCares();
        //}

        private long _tikcs;

        private void BtnCarePickClick(object sender, EventArgs e)
        {
            ResetLastActivity();
            _tikcs = DateTime.Now.Ticks;

            cal.AcceptChanges();
            if (cal.SelectedAppointment == null && cal.GetSelectedScope() == null)
            {
                cal.ClearAnySelected();
                return;
            }
            var rect = btnCarePick.RectangleToScreen(btnCarePick.DisplayRectangle);
            var selectCares = cal.SelectedAppointment == null ? string.Empty : cal.SelectedAppointment.Cares;

            if (_fCarePick == null || _fCarePick.IsDisposed)
            {
                this.Cursor = Cursors.WaitCursor;
                _fCarePick = new FormCarePick(selectCares) { Left = rect.Left };
                _fCarePick.Top = rect.Top - _fCarePick.Height - 2;
                _fCarePick.SetAppointmentCares += FCarePickSetAppointmentCares;
                _fCarePick.FormClosed += FCarePickFormClosed;
                _fCarePick.Show();
                this.Cursor = Cursors.Default;
            }
            else
            {
                _fCarePick.ClearSelected();
                _fCarePick.SelectCares(selectCares);
                _fCarePick.Left = rect.Left;
                _fCarePick.Top = rect.Top - _fCarePick.Height - 2;
            }
            _fCarePick.Select();
        }

        private void FCarePickSetAppointmentCares(object sender, EventArgs e)
        {
            var cares = FormCarePick.SelectedCares;
            if (cal.SelectedAppointment == null)
            {
                if (!string.IsNullOrEmpty(cares))
                {
                    var dates = cal.GetSelectedScope();
                    if (dates != null)
                    {
                        var app = new BizCareAppointment
                        {
                            EndDate = dates[1],
                            WorkerId = cal.SelectedWorkerId,
                            RemainderMinutes = -1,
                            StartDate = dates[0],
                            Cares = cares,
                        };

                        //XOXO//
                        if (AppSettingsHelper.GetParamValue<bool>("CAL_AUTO_SET_DURATION"))
                        {
                            var caresDuration = CalendarHelper.GetCaresDuration(cares);
                            if (caresDuration >= 15)
                            {
                                app.EndDate = app.StartDate.AddMinutes(caresDuration);
                            }
                        }
                        if (AppSettingsHelper.GetParamValue<bool>("CAL_AUTO_SET_COLOR"))
                        {
                            var color = CalendarHelper.GetCaresColor(cares);
                            app.RecurrenceId = color;
                        }

                        try
                        {
                            CalendarHelper.AddAppointment(app);
                        }
                        catch (Exception ex)
                        {
                            General.ShowCommunicationError(ex, this);
                        }
                        var id = app.Id;
                        ReloadAppointments();
                        cal.SetAppointmentActive(id);
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(cares) && cal.SelectedAppointment.ClientId == 0 && cal.SelectedAppointment.Text.Length == 0)
                {
                    SetAppointmentNoText(cal.SelectedAppointment);
                }
                try
                {
                    CalendarHelper.SetCaresToAppointment(cares, cal.SelectedAppointment.Id, cal.SelectedAppointment.StartDate);
                }
                catch (Exception ex)
                {
                    General.ShowCommunicationError(ex, this);
                    return;
                }
                var desc = CalendarHelper.GetCaresDescription(cares);
                cal.AttachCaresToSelectedAppointment(cares, desc);
                ClearAppointmentText(cal.SelectedAppointment);
                _detailsAppId = null;
                FillAppDetails(cal.SelectedAppointment);

                var refreshWorker = false;
                //XOXO//
                if (AppSettingsHelper.GetParamValue<bool>("CAL_AUTO_SET_DURATION"))
                {
                    var caresDuration = CalendarHelper.GetCaresDuration(cares);
                    if (caresDuration >= 15)
                    {
                        cal.SelectedAppointment.EndDate = cal.SelectedAppointment.StartDate.AddMinutes(caresDuration);
                        UpdatePartOfAppointment(new GeneralCubeEventArgs(cal.SelectedAppointment, GeneralCubeEventArgs.EditModeMember.Time));
                        refreshWorker = true;
                    }
                }
                if (AppSettingsHelper.GetParamValue<bool>("CAL_AUTO_SET_COLOR"))
                {
                    var color = CalendarHelper.GetCaresColor(cares);
                    cal.SelectedAppointment.RecurrenceId = color;
                    UpdatePartOfAppointment(new GeneralCubeEventArgs(cal.SelectedAppointment, GeneralCubeEventArgs.EditModeMember.Category));
                    refreshWorker = true;
                }

                if (refreshWorker)
                {
                    cal.RefreshWorker(cal.SelectedAppointment.WorkerId);
                    cal.ReorderAppointments(cal.SelectedAppointment.WorkerId);
                }

                cal.Select();
                if (RefreshClient != null) RefreshClient(this, new ClientOperationEventArgs("RefreshClient", cal.SelectedAppointment.ClientId));
            }
        }

        private void FCarePickFormClosed(object sender, FormClosedEventArgs e)
        {
            ResetLastActivity();
            //if (MainFormFocus != null) MainFormFocus(null, null);
            cal.Select();
        }

        private void PicViewClick(object sender, EventArgs e)
        {
            ResetLastActivity();
            if (!picView.Tag.Equals(0))
            {
                var arg = new ShowClientCardEventArgs((int)picView.Tag, true)
                {
                    EnableCalendar = false,
                    EnableNavigate = false
                };
                if (ShowClientCard != null) ShowClientCard(this, arg);
            }
            cal.Select();
        }

        private void TbbEmailClick(object sender, EventArgs e)
        {
            var app = cal.SelectedAppointment;
            var clientId = 0;

            if (app == null)
            {
                const string msg1 = "לשליחת הודעת דוא\"ל יש לבחור תחילה תור מהיומן";
                const string msg2 = "שליחת דוא\"ל...";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
            }
            else
            {
                clientId = app.ClientId;
                if (app.ClientId == 0)
                {
                    const string msg1 = "לתור המסומן לא משוייך לקוח";
                    const string msg2 = "שליחת דוא\"ל...";
                    MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                    MsgBox.Show(this);
                }
            }

            if (OpenForm != null)
            {
                this.Cursor = Cursors.WaitCursor;
                var table = General.GetEmailEntity(clientId, General.EntityType.Client);
                if (table != null) OpenForm(this, new OpenFormEventArgs("frmMailCampaign", table));
                this.Cursor = Cursors.Default;
            }
        }

        private void TbbSendSmsClick(object sender, EventArgs e)
        {
            var app = cal.SelectedAppointment;
            var clientId = 0;

            if (app == null)
            {
                const string msg1 = "לשליחת SMS ללקוח משוייך לתור\nבחר תחילה תור מהיומן";
                const string msg2 = "שליחת SMS...";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
            }
            else
            {
                clientId = app.ClientId;
                if (app.ClientId == 0)
                {
                    const string msg1 = "לתור המסומן לא משוייך לקוח";
                    const string msg2 = "שליחת SMS...";
                    MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                    MsgBox.Show(this);
                }
            }

            if (OpenForm != null)
            {
                this.Cursor = Cursors.WaitCursor;
                var table = General.GetSmsEntity(clientId, General.EntityType.Client);
                var list = General.TableToPostAddresseeList(table);

                if (table != null) OpenForm(this, new OpenFormEventArgs("frmSMS", list));
                this.Cursor = Cursors.Default;
            }
        }

        private void SplitPhoneButtonClick(object sender, EventArgs e)
        {
            ResetLastActivity();
            splitPhone.ShowDropDown();
        }

        private void SplitPhoneDropDownOpening(object sender, EventArgs e)
        {
            ResetLastActivity();
            var app = cal.SelectedAppointment;
            splitPhone.DropDownItems.Clear();

            if (app == null)
            {
                const string msg1 = "לא נבחר תור מהיומן";
                const string msg2 = "חיוג ללקוח...";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
            }
            else
            {
                if (app.ClientId == 0)
                {
                    const string msg1 = "לתור המסומן לא משוייך לקוח";
                    const string msg2 = "חיוג ללקוח...";
                    MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                    MsgBox.Show(this);
                    return;
                }

                // bulid phone toolStrip items
                var phones = ClientHelper.GetAllPhones(app.ClientId);
                var arrPhones = phones.Split(' ');

                if (arrPhones.Length > 0)
                {
                    foreach (var ph in arrPhones)
                    {
                        if (ph.Length > 0) splitPhone.DropDownItems.Add(ph, null, SplitPhoneItemButtonClick);
                    }
                }
            }
        }

        private void SplitPhoneItemButtonClick(object sender, EventArgs e)
        {
            ResetLastActivity();
            var app = cal.SelectedAppointment;

            if (app != null && app.ClientId > 0)
            {
                var phone = Utils.DistilPhone(((ToolStripDropDownItem)(sender)).Text);
                var name = ClientHelper.GetFullName(app.ClientId);
                var id = app.ClientId;

                if (DialRequest != null)
                {
                    var arg = new DialRequestEventArgs(phone, name, id);
                    DialRequest(this, arg);
                }
            }
        }

        private void TbbReportClick(object sender, EventArgs e)
        {
            if (ShowReport != null) ShowReport(this, new ShowReportEventArgs("יומן תורים", 10008, new object[] { new DateTime?[] { cal.CurrentDate, cal.CurrentDate }, -1 }));
        }

        private void TbbTodayClick(object sender, EventArgs e)
        {
            ResetLastActivity();
            dtPicker.SelectedDate = DateTime.Now;
        }

        private void CalDragDropCube(object sender, GeneralCubeEventArgs e)
        {
            ResetLastActivity();
            cal.RefreshWorker(e.Appointment.WorkerId);
            UpdatePartOfAppointment(new GeneralCubeEventArgs(e.Appointment, GeneralCubeEventArgs.EditModeMember.Time));
            _detailsAppId = null;
            FillAppDetails(e.Appointment);

            cal.Select();
        }

        private void TbbPrevClick(object sender, EventArgs e)
        {
            ResetLastActivity();
            cal.CurrentDate = cal.CurrentDate.AddDays(-1);
        }

        private void TbbNextClick(object sender, EventArgs e)
        {
            ResetLastActivity();
            cal.CurrentDate = cal.CurrentDate.AddDays(1);
        }

        private void TbbArchiveClick(object sender, EventArgs e)
        {
            const string caption = "פעולות ארכיון ביומן מצריכות הרשאות מנהל\nהזן את סיסמת מנהל...";
            var fPassword = new FormPassword(string.Empty, caption, true);
            var res = fPassword.ShowDialog(this);

            if (res == DialogResult.OK)
            {
                var fCalArchive = new FormCalArchive();
                fCalArchive.ReloadAppointments += FCalArchiveReloadAppointments;
                fCalArchive.ShowDialog(this);
            }
        }

        private void FCalArchiveReloadAppointments(object sender, EventArgs e)
        {
            ResetLastActivity();
            ReloadAppointments();
            if (RefreshClient != null) RefreshClient(this, new ClientOperationEventArgs("RefreshClient", -1));
        }

        private void CalTakePictureToAppointment(object sender, GeneralCubeEventArgs e)
        {
            ResetLastActivity();
            if (OpenForm != null)
            {
                OpenForm(this, new OpenFormEventArgs("frmPhotoAlbum", e.Appointment.ClientId));
                OpenForm(this, new OpenFormEventArgs("frmPhotoDetails", e.Appointment.ClientId, e.Appointment));
            }
        }

        private void CalBeforeRemovedAppointment(object sender, CancelEventArgs e)
        {
            ResetLastActivity();
            if (cal.SelectedAppointment != null)
            {
                var msg1 = "האם אתה בטוח שאתה רוצה לבטל את התור:\n" + cal.SelectedAppointment;
                const string msg2 = "ביטול תור...";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
                var res = MsgBox.Show(this);
                if (res == DialogResult.No) e.Cancel = true;
            }
        }

        private void DtPickerMonthChanged(object sender, EventArgs e)
        {
            ResetLastActivity();
            //dtPicker.BoldDates = CalendarHelper.GetMonthBoldedDates(dtPicker.Month, dtPicker.Year);
            cal.AcceptChanges();
            SetBoldDatesThread();
        }

        private void SetBoldDatesThread()
        {
            if (_threadSetBoldDates != null && _threadSetBoldDates.IsAlive) _threadSetBoldDates.Abort();
            _threadSetBoldDates = null;
            GC.Collect();
            _threadSetBoldDates = new Thread(SetBoldDates);
            _threadSetBoldDates.Start();
        }

        private void SetBoldDates()
        {
            Thread.Sleep(1000);
            dtPicker.BoldDates = CalendarHelper.GetMonthBoldedDates(dtPicker.Month, dtPicker.Year);
        }

        public void RedrawDtPicker()
        {
            dtPicker.ReDraw();
        }

        public void AcceptCalendarChanges()
        {
            cal.AcceptChanges();
        }

        private void Cal_SendSmsReminder(object sender, EventArgs e)
        {
            ResetLastActivity();
            if (SendSmsReminder != null)
            {
                var app = cal.SelectedAppointment;
                SendSmsReminder(this, new CalendarEventArgs(app.Id, app.ClientId));
            }
        }

        private void cal_AddAttendees(object sender, EventArgs e)
        {
            ResetLastActivity();
            if (AddAttendees != null)
            {
                var app = cal.SelectedAppointment;
                AddAttendees(this, new CalendarEventArgs(app.Id, app.ClientId));
            }
        }

        private void cal_ShowHistory(object sender, EventArgs e)
        {
            ResetLastActivity();
            if (ShowHistory != null)
            {
                var app = cal.SelectedAppointment;
                var id = app == null ? string.Empty : app.Id;
                ShowHistory(this, new CalendarEventArgs(id, 0));
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ResetLastActivity();
            SendKeys.SendWait("{ESC}");
            ReloadAppointments();
        }
    }
}