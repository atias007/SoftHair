using BizCare.Calendar.Library;
using ClientManage.BL;
using ClientManage.BL.Library;
using ClientManage.Interfaces;
using ClientManage.Library;
using ClientManage.UserControls;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ClientManage.Forms
{
    public partial class FormEventDetails : BaseMdiChild
    {
        #region Private

        #region Members

        private int _workerId;
        private int _clientId;

        //private int _aggregateLen;
        private int _iStart, _iEnd;

        private readonly string _strMsg = string.Empty;

        //private readonly bool _isAgregateRemark = AppSettingsHelper.GetParamValue<bool>("CALENDAR_AGREGATE_REMARK");
        private bool _ignoreKeyPress;

        private bool _inTimeSetProc;
        private bool _loadProc;
        private DateTime _eventStartDate;
        private DateTime _eventEndDate;
        private Appointment _app;
        private FormClientQuickSearch _fClientQuickSearch;
        private FormAttachMessage _fAttachMessage;
        private FormCalendarPreview _fCalendarPreview;
        private Image _calendarSnap;

        #endregion Members

        #region Functions

        private DateTime[] GetStartEndTimeV1(Appointment app)
        {
            var hour = int.Parse(cmbStartHour.Text);
            var min = int.Parse(cmbStartMin.Text);
            var dStart = dtpStartDate.Value.Date.AddHours(hour).AddMinutes(min);
            var dEnd = dStart.Add(app.Duration);
            var dCalEndDate = DateTime.Parse(dtpStartDate.Value.ToShortDateString() + " " + AppSettingsHelper.GetParamValue("CALENDAR_END_TIME"));

            // Validate start hour
            if (dEnd > dCalEndDate)
            {
                dStart = dCalEndDate.Subtract(app.Duration);
                dEnd = dCalEndDate;
            }

            return new[] { dStart, dEnd };
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

        private void SetValuesAtEndCombo()
        {
            // Set values at end hour combo
            cmbEndHour.Items.Clear();
            var iStart = Convert.ToInt32(cmbStartHour.Text);
            for (var i = iStart; i <= _iEnd; i++)
            {
                cmbEndHour.Items.Add(i.ToString().PadLeft(2, '0'));
            }
        }

        private void SetAppLengthString()
        {
            if (cbAllDay.Checked)
            {
                lblAppLength.Text = string.Empty;
                lblAppLength.Image = null;
                return;
            }

            var ret = string.Empty;
            try
            {
                var from = DateTime.Parse(GetSelectedStartTime());
                var to = DateTime.Parse(GetSelectedEndTime());
                var span = to.Subtract(from);

                if (span.TotalMinutes >= 15)
                {
                    if (span.Hours > 1) ret = span.Hours + " שעות ";
                    else if (span.Hours == 1) ret = "שעה ";

                    if (span.Minutes > 0)
                    {
                        if (span.Hours > 0) ret += "ו-";
                        ret += span.Minutes + " דקות";
                    }
                }
            }
            catch { Utils.CatchException(); }

            if (ret.Length > 0)
            {
                const string title = "משך התור: ";
                lblAppLength.Text = title + ret;
                lblAppLength.ForeColor = Color.FromArgb(122, 127, 133);
                lblAppLength.Image = null;
            }
            else
            {
                const string title = "     שגיאה בזמני התור!";
                lblAppLength.Text = title;
                lblAppLength.Image = Properties.Resources.field_error;
                lblAppLength.ForeColor = Color.Brown;
            }
        }

        private void LoadHoursCombos()
        {
            _iStart = Convert.ToInt32(AppSettingsHelper.GetParamValue("CALENDAR_START_TIME").Substring(0, 2));
            _iEnd = Convert.ToInt32(AppSettingsHelper.GetParamValue("CALENDAR_END_TIME").Substring(0, 2));

            for (var i = _iStart; i <= _iEnd; i++)
            {
                var item = i.ToString().PadLeft(2, '0');
                cmbStartHour.Items.Add(item);
                cmbEndHour.Items.Add(item);
            }
        }

        private void SetStartTime(DateTime date)
        {
            var start = date.ToShortTimeString();
            cmbStartMin.SelectedIndex = cmbStartMin.FindString(start.Substring(3, 2));
            cmbStartHour.SelectedIndex = cmbStartHour.FindString(start.Substring(0, 2));
            if (cmbStartHour.SelectedIndex == -1) cmbStartMin.SelectedIndex = -1;
        }

        private void SetEndTime(DateTime date)
        {
            var end = date.ToShortTimeString();
            cmbEndMin.SelectedIndex = cmbEndMin.FindString(end.Substring(3, 2));
            cmbEndHour.SelectedIndex = cmbEndHour.FindString(end.Substring(0, 2));
            if (cmbEndHour.SelectedIndex == -1) cmbEndMin.SelectedIndex = -1;
        }

        private string GetSelectedStartTime()
        {
            var res = string.Empty;
            if (cmbStartHour.SelectedIndex >= 0 && cmbStartMin.SelectedIndex >= 0)
            {
                res = cmbStartHour.Text + ":" + cmbStartMin.Text;
            }
            return res;
        }

        private string GetSelectedEndTime()
        {
            var res = string.Empty;
            if (cmbEndHour.SelectedIndex >= 0 && cmbEndMin.SelectedIndex >= 0)
            {
                res = cmbEndHour.Text + ":" + cmbEndMin.Text;
            }
            return res;
        }

        private bool CheckAllWorkers4AllDayEvent()
        {
            var ret = false;
            if (_workerId == -1 && string.IsNullOrEmpty(_app.Id))
            {
                if (cbAllDay.Checked)
                {
                    cbAllDay.Checked = false;
                    const string msg1 = "שים לב! לא ניתן לייצר אירוע של יום שלם לכל העובדים\nאירוע זה סומן כתור רגיל עם שעת התחלה ושעת סיום";
                    const string msg2 = "פרטי תור ביומן";
                    MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Information, MyMessageBox.MyMessageButton.Ok);
                    MsgBox.Show(this);
                    ret = true;
                }
            }
            return ret;
        }

        private void RefreshFormData()
        {
            if (string.IsNullOrEmpty(_app.Id))
            {
                chkRemainder.Checked = false;
                cmbRemainder.SelectedIndex = -1;
                cmbRemainder.Enabled = false;

                if (_app.IsAllDayEvent)
                {
                    cbAllDay.Checked = true;
                }
                else
                {
                    SetStartTime(_eventStartDate);
                    SetEndTime(_eventEndDate);
                }

                informationBar1.PanelText = "הוספת תור חדש ביומן";
                informationBar1.Image = Properties.Resources.new_small;
            }
            else
            {
                SetClientPicture(_clientId);
                txtSubject.Text = _app.Text;
                txtRemark.Text = _app.Remark;
                lblAttendee.Text = _app.Attendee;
                if (!_app.IsAllDayEvent)
                {
                    _loadProc = true;
                    SetStartTime(_app.StartDate);
                    SetEndTime(_app.EndDate);
                    _loadProc = false;
                }
                if (_app.RemainderMinutes >= 0)
                {
                    chkRemainder.Checked = true;
                    cmbRemainder.Enabled = true;
                    cmbRemainder.SelectedValue = _app.RemainderMinutes;
                }
                else
                {
                    chkRemainder.Checked = false;
                    cmbRemainder.SelectedIndex = -1;
                    cmbRemainder.Enabled = false;
                }

                cbAllDay.Checked = _app.IsAllDayEvent;

                //if (_isAgregateRemark)
                //{
                //    if (_app.ClientId != 0)
                //    {
                //        //var agg = CalendarHelper.GetAgregateRemarks(_app.ClientId);
                //        _aggregateLen = agg.Length;
                //        txtRemark.Text = agg + txtRemark.Text;
                //    }
                //}

                //var rem = CalendarHelper.GetRemaindedDate(_app.Id);
                //if (!rem.Equals(DateTime.MinValue))
                //{
                //    lnkRemMsg.Tag = _app.Id;
                //    lblMsgRemainder.Text = string.Format(_strMsg, rem.ToString("dd/MM/yyyy"), rem.ToShortTimeString());
                //    lblMsgRemainder.Visible = true;
                //}
                //else
                //{
                //    // do not remove this lines
                //    lblMsgRemainder.Visible = false;
                //    lnkRemMsg.Visible = false;
                //}

                var info = _app.ToString();
                informationBar1.PanelText = "עדכון פרטי תור: " + (info.Length > 60 ? info.Substring(0, 57) + "..." : info);
                informationBar1.Image = Properties.Resources.tb_edit_small;
            }

            lblMsgPast.Visible = (_eventStartDate < DateTime.Now);
            SelectCategory(_app.RecurrenceId);
            SetAppLengthString();
        }

        private void SelectWorder()
        {
            foreach (ImageComboBoxListItem item in cmbWorkers.Items)
            {
                if (Convert.ToInt32(item.Tag) == _workerId)
                {
                    cmbWorkers.SelectedItem = item;
                    return;
                }
            }

            var def = new ImageComboBoxListItem("בחר עובד\nמהרשימה", 2) { Tag = 0 };
            cmbWorkers.Items.Insert(0, def);
            cmbWorkers.SelectedIndex = 0;
        }

        public void ReloadWorkers()
        {
            var workerId = _workerId;
            cmbWorkers.Items.Clear();
            LoadWorkers();
            _workerId = workerId;

            SelectWorder();
        }

        private void LoadCategories()
        {
            var categories = new[] { "תכלת (ברירת מחדל)", "כתום", "סגול", "אדום", "ירוק", "כחול כהה", "אפור", "אפור כהה", "תורכיז" };
            for (var i = 0; i < categories.Length; i++)
            {
                var item = new ImageComboBoxListItem(categories[i], i) { Tag = i <= 1 ? -i : i - 1 };
                cmbCategory.Items.Add(item);
            }
        }

        private void SelectCategory(int recurrenceId)
        {
            foreach (ImageComboBoxListItem item in cmbCategory.Items)
            {
                if (recurrenceId.Equals(item.Tag))
                {
                    cmbCategory.SelectedItem = item;
                    break;
                }
            }
        }

        private void LoadWorkers()
        {
            ImageComboBoxListItem item;

            var workers = WorkersHelper.GetWorkersForCalendar();
            foreach (DataRow row in workers.Rows)
            {
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
                item.Tag = Convert.ToInt32(row["id"]);
                cmbWorkers.Items.Add(item);
            }

            if (string.IsNullOrEmpty(_app.Id))
            {
                item = new ImageComboBoxListItem("כל העובדים בעסק", 0) { Tag = -1 };
                cmbWorkers.Items.Add(item);
            }
        }

        private static Image LoadWorkerPicture(string filename)
        {
            Image ret;
            try
            {
                 ret = Image.FromFile(filename);
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
                btnClearClient.Visible = false;
                this.Tooltip.SetToolTip(picView, string.Empty);
            }
            else
            {
                var param = CalendarHelper.GetClientPicture(id);
                lblFirstName.Text = param[0];
                lblLastName.Text = param[1];
                this.Tooltip.SetToolTip(picView, "לחץ לחיצה כפולה על מנת להציג את כרטיס הלקוח");
                try
                {
                    picView.BackgroundImage = Image.FromFile(param[2]);
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

        private void DoAttachClient(int clientId)
        {
            _clientId = clientId;
            SetClientPicture(_clientId);

            //if (_isAgregateRemark)
            //{
            //    if (_aggregateLen > 0)
            //    {
            //        if (txtRemark.Text.Length >= _aggregateLen)
            //        {
            //            txtRemark.Text = txtRemark.Text.Substring(_aggregateLen);
            //            _aggregateLen = 0;
            //        }
            //    }

            //    if (_clientId > 0)
            //    {
            //        //var agg = CalendarHelper.GetAgregateRemarks(_clientId);
            //        //_aggregateLen = agg.Length;
            //        //txtRemark.Text = agg + txtRemark.Text;
            //    }
            //}
        }

        private BizCareAppointment GetAppointmentFromScreen()
        {
            if (chkRemainder.Checked && cmbRemainder.SelectedIndex == -1) chkRemainder.Checked = false;
            var dEndDate = DateTime.Parse(dtpStartDate.Value.ToString("dd/MM/yyyy") + " " + GetSelectedEndTime());
            var dStartDate = DateTime.Parse(dtpStartDate.Value.ToString("dd/MM/yyyy") + " " + GetSelectedStartTime());
            var category = cmbCategory.SelectedIndex == -1 ? 0 : (int)((ImageComboBoxListItem)cmbCategory.SelectedItem).Tag;
            var cares = carePicker1.GetSelectedItems();

            var remark = txtRemark.Text;
            //if (_isAgregateRemark)
            //{
            //    if (remark.Length >= _aggregateLen)
            //    {
            //        remark = remark.Substring(_aggregateLen);
            //    }
            //}

            var resetSmsAlert = false;
            resetSmsAlert |= (_app.ClientId != _clientId);
            resetSmsAlert |= (_app.StartDate != dStartDate);
            resetSmsAlert |= (_app.Cares != cares);

            _app.ClientId = _clientId;
            _app.EndDate = dEndDate;
            _app.IsAllDayEvent = cbAllDay.Checked;
            _app.WorkerId = _workerId;
            _app.RemainderMinutes = chkRemainder.Checked ? (int)cmbRemainder.SelectedValue : -1;
            _app.Remark = remark.Trim();
            _app.StartDate = dStartDate;
            _app.Text = txtSubject.Text;
            _app.RecurrenceId = category;
            _app.Cares = cares;

            if (_app.IsAllDayEvent)
            {
                _app.StartDate = _app.StartDate.Date;
                _app.EndDate = _app.EndDate.Date;
            }

            var bcApp = new BizCareAppointment
            {
                EndDate = _app.EndDate,
                Importance = (ImportanceLevel)Convert.ToInt32(_app.Importance),
                IsAllDayEvent = _app.IsAllDayEvent,
                WorkerId = _app.WorkerId,
                RemainderMinutes = _app.RemainderMinutes,
                Remark = _app.Remark,
                StartDate = _app.StartDate,
                Text = _app.Text,
                RecurrenceId = category,
                ClientId = _app.ClientId,
                Id = _app.Id,
                ResetSmsAlert = resetSmsAlert,
                Cares = cares,
            };

            return bcApp;
        }

        private bool SaveData()
        {
            var msg = ValidateForm();
            const string msg2 = "קביעת / עדכון תור ביומן...";

            if (msg.Length > 0)
            {
                informationBar1.LabelVisible = false;
                MsgBox = new MyMessageBox(msg, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
                return false;
            }

            var iRemainder = _app.RemainderMinutes;
            var bcApp = GetAppointmentFromScreen();

            //var autoDuration = AppSettingsHelper.GetParamValue<bool>("CAL_AUTO_SET_DURATION");
            //var autoColor = AppSettingsHelper.GetParamValue<bool>("CAL_AUTO_SET_COLOR");
            //if (autoColor || autoDuration)
            //{
            //    const string msg1 = "האם ברצונך לקבוע את משך התור\nו/או קטגורית התור אוטומטית?";
            //    MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo);
            //    var res = MsgBox.Show(this);
            //    if (res == DialogResult.Yes)
            //    {
            //        if (autoDuration)
            //        {
            //            var caresDuration = CalendarHelper.GetCaresDuration(bcApp.Cares);
            //            if (caresDuration > 15)
            //            {
            //                bcApp.EndDate = bcApp.StartDate.AddMinutes(caresDuration);
            //            }
            //        }
            //        if (autoColor)
            //        {
            //            var color = CalendarHelper.GetCaresColor(bcApp.Cares);
            //            bcApp.RecurrenceId = color;
            //        }
            //    }
            //}

            //int ret;
            if (string.IsNullOrEmpty(_app.Id))
            {
                if (_workerId == -1)
                {
                    #region Add To All Workers

                    foreach (ImageComboBoxListItem item in cmbWorkers.Items)
                    {
                        if (Convert.ToInt32(item.Tag) > 0)
                        {
                            bcApp.WorkerId = Convert.ToInt32(item.Tag);
                            try
                            {
                                CalendarHelper.AddAppointment(bcApp);
                            }
                            catch (Exception ex)
                            {
                                General.ShowCommunicationError(ex, this); ;
                            }
                        }
                    }

                    #endregion Add To All Workers
                }
                else
                {
                    #region Add To Single Worker

                    try
                    {
                        CalendarHelper.AddAppointment(bcApp);
                    }
                    catch (Exception ex)
                    {
                        General.ShowCommunicationError(ex, this);
                    }

                    #endregion Add To Single Worker
                }
            }
            else
            {
                try
                {
                    CalendarHelper.UpdateAppointment(bcApp);
                }
                catch (Exception ex)
                {
                    General.ShowCommunicationError(ex, this);
                    return false;
                }

                if (iRemainder >= 0 && iRemainder != bcApp.RemainderMinutes)
                {
                    //CalendarHelper.ReLiveAppRemainder(bcApp.Id);
                    if (RefreshRemainders != null) RefreshRemainders(this, new EventArgs());
                }
            }

            // TODO: gmail fix
            //if (false)
            //{
            //    const string title = "שגיאה ביומן...";
            //    const string head = "שמירת נתוני התור";
            //    const string desc = "שמירת נתוני התור נכשלה\nשים לב כי הנתונים בטופס לא נשמרו";
            //    General.ShowErrorMessageDialog(this, title, head, desc, null, "frmEventDetails");
            //    return false;
            //}

            if (string.IsNullOrEmpty(_app.Id) == false && EditAppointment != null) EditAppointment(this, new CalendarEventArgs(_app.Id, _app.ClientId));
            if (string.IsNullOrEmpty(_app.Id) && AddAppointment != null) AddAppointment(this, new CalendarEventArgs(_app.Id, _app.ClientId));
            return true;
        }

        private string ValidateForm()
        {
            if (chkRemainder.Checked && cmbRemainder.SelectedIndex == -1) chkRemainder.Checked = false;
            if (!string.IsNullOrEmpty(txtSubject.Text)) txtSubject.Text = txtSubject.Text.Trim();
            var msg = string.Empty;
            var strEndTime = GetSelectedEndTime();
            var strStarTime = GetSelectedStartTime();
            var selectedCares = carePicker1.GetSelectedItems();

            if (string.IsNullOrEmpty(txtSubject.Text) && string.IsNullOrEmpty(selectedCares) && _clientId == 0)
            {
                msg += "יש להזין לפחות אחד מהשדות הבאים: תיאור, שייוך לקוח, בחירת טיפול\n";
            }

            var worker = ((ImageComboBoxListItem)cmbWorkers.Items[cmbWorkers.SelectedIndex]).Tag;
            if (worker == null || (int)worker == 0)
            {
                msg += "אנא בחר עובד מטפל מהרשימה\n";
            }

            if (!cbAllDay.Checked)
            {
                var checkTime = true;

                if (strStarTime.Length == 0) { msg += "אנא בחר שעת התחלה לתור\n"; }
                if (strEndTime.Length == 0) { msg += "אנא בחר שעת סיום לתור\n"; }
                if (!Validation.IsTimeValid(strStarTime, true)) { msg += "שעת ההתחלה אינה חוקית\n"; checkTime = false; }
                if (!Validation.IsTimeValid(strEndTime, true)) { msg += "שעת הסיום אינה חוקית\n"; checkTime = false; }

                if (checkTime)
                {
                    var dtMin = DateTime.Parse(AppSettingsHelper.GetParamValue("CALENDAR_START_TIME"));
                    var dtMax = DateTime.Parse(AppSettingsHelper.GetParamValue("CALENDAR_END_TIME"));
                    var dtStart = DateTime.Parse(strStarTime);
                    var dtEnd = DateTime.Parse(strEndTime);

                    if (dtStart < dtMin)
                    {
                        msg += "שעת ההתחלה לתור אינה יכולה להיות לפני השעה " + AppSettingsHelper.GetParamValue("CALENDAR_START_TIME") + "\n";
                    }
                    if (dtEnd > dtMax)
                    {
                        msg += "שעת הסיום לתור אינה יכולה להיות אחרי השעה " + AppSettingsHelper.GetParamValue("CALENDAR_END_TIME") + "\n";
                    }
                    if (dtStart >= dtEnd)
                    {
                        msg += "שעת ההתחלה לתור אינה יכולה להיות שווה או מאוחרת משעת הסיום\n";
                    }
                    else if (dtStart.AddMinutes(15) > dtEnd)
                    {
                        msg += "משך התור חייב להיות לפחות 15 דקות\n";
                    }
                }
            }

            return msg.Trim();
        }

        private void ClearForm()
        {
            txtSubject.Text = string.Empty;
            txtSubject.BackColor = Color.White;
            cmbEndHour.SelectedIndex = -1;
            cmbEndMin.SelectedIndex = -1;
            cmbEndHour.BackColor = Color.White;
            cmbEndMin.BackColor = Color.White;
            cmbStartHour.SelectedIndex = -1;
            cmbStartMin.SelectedIndex = -1;
            cmbStartHour.BackColor = Color.White;
            cmbStartMin.BackColor = Color.White;
            //lblMsgRemainder.Visible = false;
            lblMsgPast.Visible = false;
            cbAllDay.Checked = false;

            _app = new Appointment
            {
                StartDate =
                               DateTime.Parse(dtpStartDate.Value.ToString("dd/MM/yyyy") + " " +
                                              AppSettingsHelper.GetParamValue("CALENDAR_START_TIME"))
            };
            _app.EndDate = _app.StartDate.AddMinutes(30);
            _clientId = _app.ClientId;
            _eventStartDate = _app.StartDate;
            _eventEndDate = _app.EndDate;
            SetStartTime(_eventStartDate);
            dtpStartDate.Value = _app.StartDate;
            RefreshFormData();
            SetClientPicture(0);
            carePicker1.ClearSelectedCares();
            txtSubject.Select();
        }

        private static DateTime NormalizeTime(DateTime date)
        {
            var iMin = date.Minute;
            for (var i = 0; i <= 60; i += 15)
            {
                if (iMin == i) return date;
                if (iMin < i) return date.AddMinutes(i - iMin);
            }
            return date;
        }

        #endregion Functions

        #endregion Private

        #region Public

        #region Events Declaration

        public event CalendarEventHandler RemoveAppointment;

        public event CalendarEventHandler EditAppointment;

        public event CalendarEventHandler AddAppointment;

        public event EventHandler RefreshRemainders;

        public event EventHandler CancelWaitingClient;

        public event DlgShowClientCardEventHandler ShowClientCard;

        #endregion Events Declaration

        #region Methods

        public void CheckForAutoAttachClient()
        {
            if (FormCalendar.WaitingClientArgs.ClientId > 0)
            {
                if (string.IsNullOrEmpty(_app.Id) == false) return;

                if (!(_fAttachMessage == null || _fAttachMessage.IsDisposed))
                {
                    _fAttachMessage = null;
                }
                _fAttachMessage = new FormAttachMessage(FormCalendar.WaitingClientArgs.ClientId);
                var res = _fAttachMessage.ShowDialog(this);
                if (res == DialogResult.Yes)
                {
                    DoAttachClient(FormCalendar.WaitingClientArgs.ClientId);
                }
                if (CancelWaitingClient != null) CancelWaitingClient(this, new EventArgs());
            }
        }

        #endregion Methods

        #region Properties

        public Image CalendarSnap
        {
            get { return _calendarSnap; }
            set { _calendarSnap = value; }
        }

        #endregion Properties

        #endregion Public

        #region Constructor

        public FormEventDetails(DateTime[] eventScopeDate, int workerId, bool isAllDayEvent)
        {
            InitializeComponent();
            dtpStartDate.CustomFormat = AppSettingsHelper.GetParamValue("APP_DATE_FORMAT");

            //_strMsg = lblMsgRemainder.Text;
            //lnkRemMsg.Visible = false;
            _workerId = workerId;
            _eventStartDate = NormalizeTime(eventScopeDate[0]);
            _eventEndDate = NormalizeTime(eventScopeDate[1]);
            _app = new Appointment
            {
                StartDate = _eventStartDate,
                EndDate = _eventEndDate,
                IsAllDayEvent = isAllDayEvent
            };
            tbbDelete.Enabled = false;
            SetClientPicture(0);
            cbAllDay.Checked = isAllDayEvent;
        }

        public FormEventDetails(Appointment appointment)
        {
            InitializeComponent();
            dtpStartDate.CustomFormat = AppSettingsHelper.GetParamValue("APP_DATE_FORMAT");

            //_strMsg = lblMsgRemainder.Text;
            _app = appointment;
            _workerId = _app.WorkerId;
            _clientId = _app.ClientId;
            _eventStartDate = NormalizeTime(_app.StartDate);
            _eventEndDate = NormalizeTime(_app.EndDate);
            if (appointment.IsAllDayEvent) cbAllDay.Checked = appointment.IsAllDayEvent;
        }

        #endregion Constructor

        #region Events Procedure

        private void PnlClientDetailsPaint(object sender, PaintEventArgs e)
        {
            var c = Color.FromArgb(192, 197, 203);
            e.Graphics.DrawRectangle(new Pen(c), 0, 0, pnlClientDetails.Width - 1, pnlClientDetails.Height - 1);
        }

        private void FrmEventDetailsLoad(object sender, EventArgs e)
        {
            _loadProc = true;
            LoadHoursCombos();
            LoadWorkers();
            SelectWorder();
            LoadCategories();
            carePicker1.SetData(LookupHelper.GetLookupTable("tblCares", "score"));
            this.Select();

            var table = CalendarHelper.GetRemainderValues().Tables[0];
            cmbRemainder.DataSource = table;
            cmbRemainder.DisplayMember = "description";
            cmbRemainder.ValueMember = "min_value";

            _loadProc = false;
            RefreshFormData();
            dtpStartDate.Value = _eventStartDate;
            this.Location = new Point(0, 0);
            txtSubject.Select();
        }

        private void TbbCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CbAllDayCheckedChanged(object sender, EventArgs e)
        {
            if (_loadProc) return;

            // === ATTENTION: do not move this line location ===
            if (CheckAllWorkers4AllDayEvent()) return;
            // =================================================

            _loadProc = true;
            var check = cbAllDay.Checked;

            cmbStartHour.Enabled = !check;
            cmbStartMin.Enabled = !check;
            cmbEndHour.Enabled = !check;
            cmbEndMin.Enabled = !check;

            if (check)
            {
                cmbStartHour.SelectedIndex = -1;
                cmbStartMin.SelectedIndex = -1;
                cmbEndHour.SelectedIndex = -1;
                cmbEndMin.SelectedIndex = -1;

                //if (_app != null && _app.IsAllDayEvent == false)
                //{
                //if (CalendarHelper.GetAllDayEventCount(dtpStartDate.Value, _workerId) >= Utils.MaxAlldayEventsCount)
                //{
                //    _loadProc = false;
                //    cbAllDay.Checked = false;
                //    var msg1 = "לא ניתן ליצור יותר מ- " + Utils.MaxAlldayEventsCount + " אירועים של יום שלם באותו היום";
                //    const string msg2 = "קבע אירוע של יום שלם...";
                //    MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                //    MsgBox.Show(this);
                //}
                //}
            }
            else
            {
                SetStartTime(_eventStartDate);
                SetEndTime(_eventEndDate);
            }

            _loadProc = false;
        }

        private void DtpStartDateValueChanged(object sender, EventArgs e)
        {
            lblDateEnd.Text = dtpStartDate.Value.ToString("dd/MM/yyyy");
        }

        private void BtnClearClientClick(object sender, EventArgs e)
        {
            DoAttachClient(0);
        }

        private void BtnAttachClientClick(object sender, EventArgs e)
        {
            var rect = btnClearClient.RectangleToScreen(btnClearClient.DisplayRectangle);

            if (_fClientQuickSearch == null || _fClientQuickSearch.IsDisposed)
            {
                this.Cursor = Cursors.WaitCursor;
                _fClientQuickSearch = new FormClientQuickSearch
                {
                    VisibleItems = 6,
                    Left = rect.Left,
                    Top = rect.Bottom
                };
                _fClientQuickSearch.ClientSelected += FClientQuickSearchClientSelected;
                _fClientQuickSearch.Show();
                this.Cursor = Cursors.Default;
            }
            else
            {
                _fClientQuickSearch.Left = rect.Left;
                _fClientQuickSearch.Top = rect.Bottom;
            }
            _fClientQuickSearch.Select();
        }

        private void FClientQuickSearchClientSelected(object sender, EventArgs e)
        {
            DoAttachClient(FormClientQuickSearch.SelectedClientId);
            txtSubject.Select();
        }

        private void CmbWorkersSelectedIndexChanged(object sender, EventArgs e)
        {
            _workerId = Convert.ToInt32(((ImageComboBoxListItem)cmbWorkers.SelectedItem).Tag);
            CheckAllWorkers4AllDayEvent();
            txtSubject.Select();
        }

        private void TbbDeleteClick(object sender, EventArgs e)
        {
            const string msg2 = "מחיקת תור...";

            if (_app == null) return;

            var msg1 = "האם אתה בטוח שברצונך למחוק את התור:\n" + _app;
            MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
            var res = MsgBox.Show(this);
            if (res == DialogResult.Yes)
            {
                try
                {
                    CalendarHelper.DeleteAppointment(_app.Id, FormCalendar.GetAppTitle(_app));
                }
                catch (Exception ex)
                {
                    General.ShowCommunicationError(ex, this);
                    return;
                }
                RemoveAppointment?.Invoke(this, new CalendarEventArgs(_app.Id, _app.ClientId));
                this.Close();
            }
        }

        private void TbbSaveClick(object sender, EventArgs e)
        {
            var ret = SaveData();

            if (ret) this.Close();
        }

        private void TbbSaveAndNewClick(object sender, EventArgs e)
        {
            if (SaveData())
            {
                informationBar1.LabelVisible = true;
                ClearForm();
                tbbShowCal.Enabled = false;
            }
        }

        private void CmbTimeEnter(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.White;
        }

        private void CmbTimeMouseDown(object sender, MouseEventArgs e)
        {
            ((Control)sender).BackColor = Color.White;
        }

        private void LblMsgPastPaint(object sender, PaintEventArgs e)
        {
            var color = Color.FromArgb(129, 135, 142);
            var rect = new Rectangle(0, -1, lblMsgPast.Width - 1, lblMsgPast.Height);
            e.Graphics.DrawRectangle(new Pen(color), rect);
        }

        private void LblMsgRemainderVisibleChanged(object sender, EventArgs e)
        {
            //lnkRemMsg.Visible = lblMsgRemainder.Visible;
            //lblMsgRemainder2.Visible = lblMsgRemainder.Visible;
        }

        private void LnkRemMsgLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //CalendarHelper.ReLiveAppRemainder(_app.Id);
            //lblMsgRemainder.Visible = false;
            if (RefreshRemainders != null) RefreshRemainders(this, new EventArgs());
        }

        private void TxtRemarkKeyPress(object sender, KeyPressEventArgs e)
        {
            if (_ignoreKeyPress)
            {
                _ignoreKeyPress = false;
                return;
            }

            //if (_isAgregateRemark)
            //{
            //    int len;

            //    if (txtRemark.SelectionStart < _aggregateLen)
            //    {
            //        len = txtRemark.SelectionLength - _aggregateLen;
            //        if (len < 0) len = 0;
            //        txtRemark.SelectionStart = _aggregateLen;
            //        txtRemark.SelectionLength = len;
            //    }
            //    if (txtRemark.SelectionStart == _aggregateLen && e.KeyChar == '\b')
            //    {
            //        len = txtRemark.SelectionLength - _aggregateLen;
            //        if (len < 0) len = 0;
            //        txtRemark.SelectionStart = _aggregateLen;
            //        txtRemark.SelectionLength = len;
            //        e.Handled = true;
            //    }
            //}
        }

        private void TxtRemarkKeyDown(object sender, KeyEventArgs e)
        {
            //if (_isAgregateRemark)
            //{
            //    if (e.Control && e.KeyCode == Keys.C)
            //    {
            //        _ignoreKeyPress = true;
            //        return;
            //    }

            //    if (e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.ShiftKey || e.KeyValue == 18) return;
            //    if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Up || e.KeyCode == Keys.Right || e.KeyCode == Keys.Down) return;

            //    if (txtRemark.SelectionStart < _aggregateLen)
            //    {
            //        var len = txtRemark.SelectionLength - _aggregateLen;
            //        if (len < 0) len = 0;
            //        txtRemark.SelectionStart = _aggregateLen;
            //        txtRemark.SelectionLength = len;
            //        e.Handled = true;
            //    }
            //}
        }

        protected void TextBoxFocus(object sender, EventArgs e)
        {
            base.TextBoxEnter((TextBox)sender);
        }

        protected void TextBoxLostFocus(object sender, EventArgs e)
        {
            base.TextBoxLeave((TextBox)sender);
        }

        #endregion Events Procedure

        private void TbbPrintClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var app = GetAppointmentFromScreen();
            var parameters = new string[11];
            var worker = WorkersHelper.GetWorker(_workerId);

            parameters[0] = app.Text;
            parameters[1] = app.StartDate.ToString("dd/MM/yyyy");
            parameters[2] = app.StartDate.ToShortTimeString();
            parameters[3] = app.EndDate.ToShortTimeString();
            parameters[4] = app.IsAllDayEvent ? "כן" : "לא";
            parameters[5] = cmbRemainder.Text;
            parameters[6] = app.Remark.Replace("\n", "<br />");
            parameters[7] = lblFirstName.Text + " " + lblLastName.Text;
            parameters[8] = CalendarHelper.GetClientPicture(_clientId)[2];
            parameters[9] = cmbWorkers.Text;
            parameters[10] = worker.Picture;
            var printer = new HtmlPrinter("EVENT_FORM", parameters);
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

        private void FrmEventDetailsRequestForClose(object sender, EventArgs e)
        {
            TbbCloseClick(null, null);
        }

        private void FrmEventDetailsFormClosing(object sender, FormClosingEventArgs e)
        {
            if (!(_fCalendarPreview == null || _fCalendarPreview.IsDisposed))
            {
                _fCalendarPreview.Hide();
                _fCalendarPreview.Close();
            }
            _fCalendarPreview = null;
        }

        private void TbbShowCalMouseDown(object sender, MouseEventArgs e)
        {
            if (_fCalendarPreview == null || _fCalendarPreview.IsDisposed)
            {
                var rect = toolStrip.RectangleToScreen(toolStrip.DisplayRectangle);
                _fCalendarPreview = new FormCalendarPreview(_calendarSnap)
                {
                    Top = rect.Top + toolStrip.Height - 6,
                    Left = rect.Left + tbbClose.Width + 6
                };
            }
            _fCalendarPreview.Show(this);
        }

        private void TbbShowCalMouseUp(object sender, MouseEventArgs e)
        {
            if (!(_fCalendarPreview == null || _fCalendarPreview.IsDisposed))
            {
                _fCalendarPreview.Hide();
            }
        }

        private void TbbShowCalMouseLeave(object sender, EventArgs e)
        {
            if (!(_fCalendarPreview == null || _fCalendarPreview.IsDisposed))
            {
                _fCalendarPreview.Hide();
            }
        }

        private void FrmEventDetailsKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.S:
                    if (e.Control && !e.Alt && !e.Shift)
                    {
                        if (tbbSave.Enabled) TbbSaveClick(null, null);
                    }
                    break;
            }
        }

        private void ChkRemainderCheckedChanged(object sender, EventArgs e)
        {
            if (_loadProc) return;
            if (chkRemainder.Checked)
            {
                cmbRemainder.SelectedValue = AppSettingsHelper.GetParamValue<int>("CALENDAR_REMAINDER_MIN");
            }
            else
            {
                cmbRemainder.SelectedIndex = -1;
            }
            cmbRemainder.Enabled = chkRemainder.Checked;
        }

        private void LblDateEndPaint(object sender, PaintEventArgs e)
        {
            var color = Color.FromArgb(202, 207, 213);
            e.Graphics.DrawRectangle(new Pen(color), 0, 0, lblDateEnd.Width - 1, lblDateEnd.Height - 1);
        }

        private void CmbEnabledChanged(object sender, EventArgs e)
        {
            var cb = (ComboBox)sender;
            cb.BackColor = cb.Enabled ? Color.White : Color.FromArgb(222, 227, 233);
        }

        private void CmbStartHourSelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStartHour.SelectedIndex == -1 || cmbStartMin.SelectedIndex == -1) return;
            if (_inTimeSetProc) { SetValuesAtEndCombo(); return; }

            var dates = GetStartEndTimeV1(_app);
            SetValuesAtEndCombo();
            if (!_loadProc) SetStartEndTime(dates);
            SetAppLengthString();
        }

        private void CmbEndHourSelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEndHour.SelectedIndex == -1 || cmbEndMin.SelectedIndex == -1) return;
            if (_inTimeSetProc) return;
            SetAppLengthString();
        }

        private void CmbStartMinSelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStartHour.SelectedIndex == -1 || cmbStartMin.SelectedIndex == -1) return;
            if (_inTimeSetProc) return;
            var dates = GetStartEndTimeV1(_app);
            if (!_loadProc) SetStartEndTime(dates);
            SetAppLengthString();
        }

        private void CmbEndMinSelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEndHour.SelectedIndex == -1 || cmbEndMin.SelectedIndex == -1) return;
            if (_inTimeSetProc) return;
            SetAppLengthString();
        }

        private void CarePicker1BindingComplete(object sender, EventArgs e)
        {
            carePicker1.ClearPointCare();
            carePicker1.SelectItems(_app.Cares);
        }

        private void PicViewClick(object sender, EventArgs e)
        {
            if (!picView.Tag.Equals(0))
            {
                var arg = new ShowClientCardEventArgs((int)picView.Tag, true)
                {
                    EnableCalendar = false,
                    EnableNavigate = false
                };
                if (ShowClientCard != null) ShowClientCard(this, arg);
            }
        }
    }
}