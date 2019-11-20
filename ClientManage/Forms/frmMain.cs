using BizCare.Calendar.Library;
using ClientManage.BL;
using ClientManage.BL.Library;
using ClientManage.Interfaces;
using ClientManage.Library;
using LukeSw.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO.Ports;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;
using Task = ClientManage.BL.Library.Task;

namespace ClientManage.Forms
{
    public partial class FormMain : Form
    {
        #region Window Caption Bar

        private readonly Color _borderColor = Color.FromArgb(51, 55, 64);
        private readonly Color _subBorderColor = Color.FromArgb(225, 230, 235);
        private readonly Color _captionFromColor = Color.FromArgb(168, 185, 203);
        private readonly Color _captionToColor = Color.FromArgb(194, 212, 232);
        private readonly Color _innerBorderColor = Color.FromArgb(96, 106, 116);

        protected override void OnPaint(PaintEventArgs e)
        {
            var rectBorder = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            var rectCaption = new Rectangle(2, 2, this.Width - 4, 24);
            var rectInner = new Rectangle(6, 26, this.Width - 13, this.Height - 33);
            var bgBrush = new SolidBrush(_captionToColor);
            var brushCap = new LinearGradientBrush(rectCaption, _captionFromColor, _captionToColor, LinearGradientMode.Vertical);

            e.Graphics.DrawRectangle(new Pen(_borderColor), rectBorder);
            e.Graphics.DrawRectangle(new Pen(_subBorderColor), rectBorder.Left + 1, rectBorder.Top + 1, rectBorder.Width - 2, rectBorder.Height - 2);
            e.Graphics.FillRectangle(brushCap, rectCaption);
            e.Graphics.DrawRectangle(new Pen(_subBorderColor), rectInner);
            e.Graphics.DrawRectangle(new Pen(_subBorderColor), rectInner);
            e.Graphics.DrawRectangle(new Pen(_innerBorderColor), rectInner.Left + 1, rectInner.Top + 1, rectInner.Width - 2, rectInner.Height - 2);
            e.Graphics.FillRectangle(bgBrush, 2, rectInner.Top, 4, rectInner.Height + 1);
            e.Graphics.FillRectangle(bgBrush, rectInner.Right + 1, rectInner.Top, 4, rectInner.Height + 1);
            e.Graphics.FillRectangle(bgBrush, 2, rectInner.Bottom + 1, this.Width - 4, 4);

            base.OnPaint(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            lblCaption.Text = this.Text;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            lblCaption.Width = this.Width - 117;
            controlBox.Left = this.Width - 101;
            this.Refresh();
            base.OnSizeChanged(e);
        }

        #endregion Window Caption Bar

        #region Events

        public event EventHandler ClosingApplication;

        #endregion Events

        #region Private Memebers

        #region Main Forms

        private FormClients _fClients;
        private FormIncomingCall _fIncomingCall;
        private FormDynamicReport _fReport;
        private FormSms _fSms;
        private FormLicense _fLicence;
        private FormBirthday _fBirthday;
        private FormPhonebook _fPhoneBook;
        private FormContactDetails _fContactDetails;
        private FormCalendar _fCalendar;
        private FormRemainder _fRemainder;
        private FormEventDetails _fEventDetails;
        private FormSearchClient _fSearchClient;
        private FormMailCampaign _fMailCampaign;
        private FormWorkersManage _fWorkersManage;
        private FormOptions _fPreferences;
        private FormWorkerDetails _fWorkerDetails;
        private FormClientsPopup _fClientsPopUp;
        private FormDialForm _fDialForm;
        private FormPhotoAlbum _fPhotoAlbum;
        private FormPhotoDetails _fPhotoDetails;
        private FormSubscription _fSubscription;

        #endregion Main Forms

        private int _selectedTabIndex = -1;             // contain the current selected tab index
        private bool _forceToShowClientCard;            // force the application to open client card even if the search form was last open
        private bool _firstActive = true;               // indicate that system is first time activate non modal form
        private MyMessageBox _myMessageBox;             // my message box object
        private ComPort _cid;                           // comm port for caller id
        private ScheduleTasks _scheduleTasks;           // class of all schedule task
        private Exception _tapiException;
        private ComPort.CommCallHandler _commCallerDelegate; // delegate to Invoke in case of income call
        private KeyPressPipe _keyPressPipe;

        private delegate void ShowFormHandler(Form form);

        #endregion Private Memebers

        #region Constructor

        // initialize form components
        public FormMain()
        {
            // initialize database password
            RegistryFactory.SubKeyName = Properties.Resources.reg_subKeyName;
            InitializeComponent();
            SubInitialize();
        }

        #endregion Constructor

        #region Private Functions

        internal void ShowStartupForm()
        {
            // ***** ATTENTION *****
            // ***** Any change in load frmClients should be refracted at ShowStartupForm() function!!! *****

            _fClients = new FormClients();
            _fClients.OpenForm += FormOpenForm;
            _fClients.SetAppointment += FClientsSetAppointment;
            _fClients.RefreshCalendar += FClientsRefreshCalendar;
            _fClients.ClientDeleted += FClientsClientDeleted;
            _fClients.ClientUpdated += FClientsClientUpdated;
            _fClients.RequestForUpdateClient += FClientsRequestForUpdateClient;
            _fClients.DialRequest += FormDialRequest;
            _fClients.ClientAdded += FClientsClientAdded;
            ShowFormInPanel(_fClients);
            TabStrip.SelectTab(0);
        }

        internal void InitializeScheduleTasks()
        {
            _scheduleTasks = new ScheduleTasks();
            _scheduleTasks.ExecuteTask += ScheduleTasksExecuteTask;
            _scheduleTasks.DoStartupTasks();
        }

        internal void CheckLicense()
        {
            CheckLicense(this);
        }

        internal void CheckLicense(Form parent)
        {
            var license = LicenseManager.CheckForEndLicenseOnline();

            // no license found or some fail to read it
            if (license == null)
            {
                using (_fLicence = new FormLicense(license))
                {
                    _fLicence.ShowDialog(parent);
                }

                Environment.Exit(0);
            }

            switch (license.Status)
            {
                default:
                case LicenseStatus.None:
                case LicenseStatus.Block:
                case LicenseStatus.OutOfDate:
                    using (_fLicence = new FormLicense(license))
                    {
                        var result = _fLicence.ShowDialog(parent);
                        Environment.Exit(0);
                    }
                    break;

                case LicenseStatus.Valid:
                    if (license.ExpireDays == 30 || license.ExpireDays <= 7)
                    {
                        using (_fLicence = new FormLicense(license))
                        {
                            var result = _fLicence.ShowDialog(parent);
                        }
                    }
                    break;
            }
        }

        internal bool InitializeTapi()
        {
            _tapiException = null;
            var isOk = true;
            var income = AppSettingsHelper.GetParamValue<bool>("MAIN_ENABLE_CALLERID");
            var outcome = AppSettingsHelper.GetParamValue<bool>("APP_ENABLE_OUT_CALLS");
            if (income || outcome)
            {
                try
                {
                    _cid = null;
                    _cid = new ComPort();
                    if (income)
                    {
                        _cid.CommIncomeData += CidCommIncomeData;
                        _commCallerDelegate = RaiseCallerEvent;
                    }
                    var setting = Utils.GetIntArray(AppSettingsHelper.GetParamValue<string>("APP_COMM_PORT1_SETTING"));
                    var init = AppSettingsHelper.GetParamValue("APP_COMM_PORT1_INIT");

                    _cid.Port.PortName = "COM" + setting[0];
                    _cid.Port.BaudRate = setting[1];
                    _cid.Port.Parity = (Parity)setting[2];
                    _cid.Port.DataBits = setting[3];
                    _cid.Port.StopBits = (StopBits)setting[4];
                    _cid.Connect();
                    _cid.SendCommand(init);
                }
                catch (Exception ex)
                {
                    var param = _cid == null ? string.Empty : " | PortName = " + _cid.Port.PortName;
                    _tapiException = string.IsNullOrEmpty(param) ? ex : new Exception(ex.Message + param, ex);
                    isOk = false;
                }
            }

            return isOk;
        }

        internal void InitTodayBirthday()
        {
            var bday = ReportHelper.GetTodayBirthday();
            var merr = ReportHelper.GetTodayMarried();
            if (bday.Rows.Count + merr.Rows.Count == 0) return;

            if (!(_fBirthday == null || _fBirthday.IsDisposed))
            {
                try { _fBirthday.Close(); }
                catch { Utils.CatchException(); }
            }

            _fBirthday = new FormBirthday(bday, merr);
            _fBirthday.ShowClientCard += FBirthdayShowClientCard;
            _fBirthday.ShowReport += FormShowReport;
            _fBirthday.OpenForm += FormOpenForm;
        }

        internal void InitKeyPressPipe()
        {
            var clientPattern = AppSettingsHelper.GetParamValue<string>("CARD_CLIENT_PATTERN");
            var workerPattern = AppSettingsHelper.GetParamValue<string>("CARD_WORKER_PATTERN");
            var patternSize = AppSettingsHelper.GetParamValue<int>("CARD_PATTERN_PIPE_SIZE");
            var delay = AppSettingsHelper.GetParamValue<int>("CARD_MATCH_DELAY");
            var pipeSize = (clientPattern.Length > workerPattern.Length ? clientPattern.Length : workerPattern.Length) + patternSize;

            General.ClientCardPattern = new KeyPressPattern(clientPattern, patternSize);
            General.WorkerCardPattern = new KeyPressPattern(workerPattern, patternSize);
            var patterns = new[] { General.ClientCardPattern, General.WorkerCardPattern };

            _keyPressPipe = new KeyPressPipe(patterns, pipeSize, delay);
            _keyPressPipe.MatchFound += KeyPressPipeMatchFound;
        }

        /// <summary>
        /// Handles the MatchFound event of the _keyPressPipe control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ClientManage.Interfaces.KeyPressPipeEventArgs"/> instance containing the event data.</param>
        private void KeyPressPipeMatchFound(object sender, KeyPressPipeEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Value) && e.Value == AppSettingsHelper.GetParamValue("CARD_MASTER_VALUE"))
            {
                if (TabStrip.SelectedIndex == 0)
                {
                    if (!(_fClients == null || _fClients.IsDisposed))
                    {
                        var clientId = _fClients.Client == null ? 0 : _fClients.Client.Id;
                        if (clientId >= 0)
                        {
                            if (_fClients.ProcessCurrentClientCard(clientId))
                            {
                                if (!(_fSearchClient == null || _fSearchClient.IsDisposed))
                                {
                                    FSearchClientHideForm(null, new OpenFormEventArgs("frmSearchClient"));
                                }
                                ShowClientCardForm();
                            }
                        }
                    }
                }
            }
            else if (e.Pattern == General.ClientCardPattern)
            {
                if (!(_fClients == null || _fClients.IsDisposed))
                {
                    bool registerSubscription;
                    if (_fClients.ProcessCard(e.Value, out registerSubscription))
                    {
                        if (!(_fSearchClient == null || _fSearchClient.IsDisposed))
                        {
                            FSearchClientHideForm(null, new OpenFormEventArgs("frmSearchClient"));
                        }
                        ShowClientCardForm();
                        if (registerSubscription)
                        {
                            if (!(_fSubscription == null || _fSubscription.IsDisposed))
                            {
                                if (_fSubscription.Status == FormSubscription.FormStatus.View)
                                {
                                    _fSubscription.RegisterSingleSubscription();
                                }
                            }
                        }
                    }
                }
            }
            else if (e.Pattern == General.WorkerCardPattern)
            {
                if (!(_fWorkerDetails == null || _fWorkerDetails.IsDisposed))
                {
                    _fWorkerDetails.ProcessCard(e.Value);
                }
                else
                {
                    if (_fWorkersManage == null || _fWorkersManage.IsDisposed)
                    {
                        _fWorkersManage = new FormWorkersManage();
                        _fWorkersManage.OpenForm += FormOpenForm;
                        _fWorkersManage.WorkerDeleted += FWorkersManageWorkerDeleted;
                        _fWorkersManage.DialRequest += FormDialRequest;
                        _fWorkersManage.SelectWorkerTab += FWorkersManageSelectWorkerTab;
                    }
                    _fWorkersManage.ProcessCard(e.Value);
                }
            }
        }

        private static string GetFormText()
        {
            const string caption = "    {0}  |   מספר לקוח {1}  |  גרסה {2}";
            var result = string.Format(caption,
                                       AppSettingsHelper.GetParamValue("APP_CLIENT_NAME"),
                                       AppSettingsHelper.GetParamValue("APP_CLIENT_ID"),
                                       Application.ProductVersion);
            return result;
        }

        private void SubInitialize()
        {
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            this.Text = GetFormText();

            Validation.CellPhonePrefix = Utils.GetStringArray(AppSettingsHelper.GetParamValue<string>("PHONE_CELL_PREFIX"));
            Validation.LinePhonePrefix = Utils.GetStringArray(AppSettingsHelper.GetParamValue<string>("PHONE_LINE_PREFIX"));
            HookKeyPress.KeyPress += HookKeyPressKeyPress;
            HookKeyPress.StartHook();
        }

        private void ShutDownApplication()
        {
            // Clear all forms
            if (!(_fCalendar == null || _fCalendar.IsDisposed)) _fCalendar.Close();
            if (!(_fClients == null || _fClients.IsDisposed))
            {
                try
                {
                    _fClients.SaveComponentsConfig();
                }
                catch { Utils.CatchException(); }
            }

            _fClients = null;
            _fIncomingCall = null;
            _fReport = null;
            _fSms = null;
            _fBirthday = null;
            _fPhoneBook = null;
            _fContactDetails = null;
            _fCalendar = null;
            _fRemainder = null;
            _fEventDetails = null;
            _fSearchClient = null;
            _fMailCampaign = null;
            _fWorkersManage = null;
            _fPreferences = null;
            _fWorkerDetails = null;
            _fClientsPopUp = null;
            _fDialForm = null;
            _fPhotoAlbum = null;
            _fPhotoDetails = null;
            _fSubscription = null;

            if (!(_fClientsPopUp == null || _fClientsPopUp.IsDisposed)) _fClientsPopUp.TerminateForm();

            // Clear objects
            _scheduleTasks = null;
            try { if (_cid != null) _cid.Disconnect(); }
            catch { Utils.CatchException(); }
            _cid = null;
            _commCallerDelegate = null;

            //CalendarHelper.SyncEvents -= SyncEvents;

            Environment.Exit(0);
        }

        private bool CheckForCloseApplication()
        {
            const string msg1 = "האם אתה בטוח שברצונך לצאת מהתוכנית";
            _myMessageBox = new MyMessageBox(msg1, Application.ProductName, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
            var res = _myMessageBox.Show(this);

            return (res == DialogResult.Yes);
        }

        private void ShowCallerIdForm(string callerId)
        {
            var show = (_fClients.Status == FormClients.FormStatus.View);
            if (_fIncomingCall == null || _fIncomingCall.IsDisposed)
            {
                _fIncomingCall = null;
                _fIncomingCall = new FormIncomingCall(callerId, show);
            }
            else
            {
                var table = _fIncomingCall.GetHistoryTable();
                _fIncomingCall.Close();
                _fIncomingCall = null;
                _fIncomingCall = new FormIncomingCall(callerId, show, table);
            }

            _fIncomingCall.ShowClientCard += FIncomingCallShowClientCard;
            _fIncomingCall.SetAppointment += FClientsSetAppointment;
            _fIncomingCall.CreateNewClient += FIncomingCallCreateNewClient;
            _fIncomingCall.Visible = false;

            try
            {
                _fIncomingCall.Show(this);
            }
            catch (Exception ex)
            {
                EventLogManager.AddErrorMessage("Error show incoming call id form", ex);
                _fIncomingCall = null;
            }
        }

        private bool ShowTodayBirthday()
        {
            var isOpen = false;

            InitTodayBirthday();
            if (!(_fBirthday == null || _fBirthday.IsDisposed))
            {
                _fBirthday.Show(this);
                _fBirthday.Select();
                isOpen = true;
            }

            return isOpen;
        }

        private void ShowClientCardForm()
        {
            _forceToShowClientCard = true;
            TabStrip.SelectTab(0);
            _fClients.Select();
            if (!(_fSearchClient == null || _fSearchClient.IsDisposed)) _fSearchClient.IsLastActive = false;
            _forceToShowClientCard = false;
        }

        private delegate void DoBackupHandler(Task task);

        private void DoBackupTask(Task task)
        {
            if (AppSettingsHelper.GetParamValue<bool>("FTP_ENABLE"))
            {
                if (_scheduleTasks.RetryOnlineBackup)
                {
                    task.Enable = false;
                    General.OnlineBackup(this);
                }
                else
                {
                    var dateLastBackup = AppSettingsHelper.GetParamValue<DateTime>("FTP_LAST_BACKUP");
                    var ts = DateTime.Now.Subtract(dateLastBackup);
                    var period = AppSettingsHelper.GetParamValue<int>("FTP_PERIOD");

                    if (ts.Days >= period)
                    {
                        task.Enable = false;
                        try
                        {
                            BackupPlan.DataAndPicturesBackup(General.StartupPath);
                        }
                        catch (Exception ex)
                        {
                            EventLogManager.AddErrorMessage("Error in backup scheduler", ex);
                            task.Enable = true;
                        }

                        try
                        {
                            General.OnlineBackup(this);
                            this.Invoke(
                                new MethodInvoker(
                                    delegate
                                    {
                                        this.Text = GetFormText() + @" | *** בוצע גיבוי בשעה " +
                                                    DateTime.Now.ToShortTimeString() + @" ***";
                                    }));
                        }
                        catch (Exception ex)
                        {
                            EventLogManager.AddErrorMessage("Error in backup scheduler", ex);
                            task.Enable = true;
                        }
                    }
                }
            }
        }

        private void ShowFormInPanel(Form form)
        {
            pnlForms.SuspendLayout();

            form.TopLevel = false;
            form.Location = new Point(0, 0);
            form.Size = pnlForms.Size;
            pnlForms.Controls.Add(form);
            while (pnlForms.Controls.Count > 1) pnlForms.Controls.RemoveAt(0);

            if (this.InvokeRequired)
            {
                this.Invoke(new ShowFormHandler(ShowForm), form);
            }
            else
            {
                ShowForm(form);
            }

            pnlForms.ResumeLayout(true);
        }

        private static void ShowForm(Form form)
        {
            form.Show();
            form.Select();
        }

        #endregion Private Functions

        #region Controls Event

        #region Other Forms Events

        #region fIncomingCall

        // open the client card
        private void FIncomingCallShowClientCard(object sender, ShowClientCardEventArgs e)
        {
            string msg1 = string.Empty, msg2 = string.Empty;
            this.Cursor = Cursors.WaitCursor;

            if (e.IsPopup)
            {
                #region PopupClients Form

                if (e.UserId > 0)
                {
                    if (_fClientsPopUp == null || _fClientsPopUp.IsDisposed)
                    {
                        _fClientsPopUp = new FormClientsPopup(e.UserId) { Icon = this.Icon };
                        _fClientsPopUp.ClientUpdated += FClientsPopUpClientUpdated;
                        _fClientsPopUp.OpenForm += FormOpenForm;
                        _fClientsPopUp.SetAppointment += FClientsSetAppointment;
                        _fClientsPopUp.RefreshCalendar += FClientsRefreshCalendar;
                        _fClientsPopUp.RequestForUpdateClient += FClientsPopUpRequestForUpdateClient;
                        _fClientsPopUp.NavigateNextClient += FClientsPopUpNavigateNextClient;
                        _fClientsPopUp.NavigatePreviousClient += FClientsPopUpNavigatePrevClient;
                        _fClientsPopUp.DialRequest += FormDialRequest;
                        //_fClientsPopUp.RefreshClient += FCalendarRefreshClient;
                    }
                    else
                    {
                        if (_fClientsPopUp.Status == FormClients.FormStatus.View)
                        {
                            if (_fClientsPopUp.Client.Id != e.UserId)
                            {
                                _fClientsPopUp.RefreshData(e.UserId);
                            }
                        }
                        else
                        {
                            msg1 = "כרטיס לקוח אחר נמצא כעת במערכת במצב\nעריכה ולא ניתן להציג כעת את כרטיס\nהלקוח של " + ClientHelper.GetFullName(e.UserId) + ".\n\nיש לשמור/לבטל את השינויים בטופס";
                            msg2 = "כרטיס לקוח...";
                        }
                    }

                    _fClientsPopUp.CalendarEnabled = e.EnableCalendar;
                    _fClientsPopUp.SetNavigateParameters(e.DataSource, e.CurrentIndex);
                    _fClientsPopUp.AllowNavigation = e.EnableNavigate;
                    _fClientsPopUp.WindowState = FormWindowState.Normal;
                    _fClientsPopUp.CenterMe();
                    try
                    {
                        _fClientsPopUp.Show(this);
                    }
                    catch
                    {
                        _fClientsPopUp.Show();
                    }

                    if (msg1.Length > 0)
                    {
                        this.Cursor = Cursors.Default;
                        _myMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                        _myMessageBox.Show(this);
                    }
                }

                #endregion PopupClients Form
            }
            else
            {
                #region Tab Client Form

                if (e.UserId > 0)
                {
                    if (!(_fClients == null || _fClients.IsDisposed))
                    {
                        _fClients.RefreshData(e.UserId);
                    }

                    if (!(_fSearchClient == null || _fSearchClient.IsDisposed))
                    {
                        FSearchClientHideForm(null, new OpenFormEventArgs("frmSearchClient"));
                    }

                    if (_fClients != null) _fClients.SetNavigateClientId(e.UserId);
                    try
                    {
                        ShowClientCardForm();
                    }
                    catch (Exception ex)
                    {
                        EventLogManager.AddErrorMessage("Error open client card", ex);
                    }
                }

                #endregion Tab Client Form
            }

            Utils.FocusWindow(this.Handle, true, Utils.FocusWindowState.Maximized);
            this.Cursor = Cursors.Default;
        }

        #endregion fIncomingCall

        #region fClients

        private void FClientsRefreshCalendar(object sender, EventArgs e)
        {
            if (!(_fCalendar == null || _fCalendar.IsDisposed))
            {
                _fCalendar.ReloadAppointments();
            }
        }

        private void FClientsSetAppointment(object sender, SetAppointmentEventArgs e)
        {
            FormCalendar.WaitingClientArgs = e;

            if (_fCalendar == null || _fCalendar.IsDisposed)
            {
                TabStrip.SelectTab(3);
                if (_fCalendar != null) _fCalendar.GoToday();
            }
            else
            {
                _fCalendar.GoToday();
                TabStrip.SelectTab(3);
            }
            if (_fCalendar != null) _fCalendar.ShowWaitClientMsg();

            if (!(_fEventDetails == null || _fEventDetails.IsDisposed))
            {
                const string msg1 = "שים לב כי חלון עריכת תור פתוח\nעל מנת לקבוע תור חדש יש לסגור חלון זה\nעל ידי שמירת השינויים או ביטולם";
                const string msg2 = "קביעת תור ללקוח...";
                _myMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                _myMessageBox.Show(this);
            }

            Utils.FocusWindow(this.Handle, true, Utils.FocusWindowState.Maximized);
            if (_fCalendar != null) _fCalendar.Select();
        }

        private void FClientsRequestForUpdateClient(object sender, ClientOperationEventArgs e)
        {
            if (!(_fClientsPopUp == null || _fClientsPopUp.IsDisposed))
            {
                if (_fClientsPopUp.Client.Id == e.ClientId)
                {
                    if (_fClientsPopUp.Status == FormClients.FormStatus.Edit || _fClientsPopUp.Status == FormClients.FormStatus.Delete)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void FClientsClientUpdated(object sender, ClientOperationEventArgs e)
        {
            if (!(_fClientsPopUp == null || _fClientsPopUp.IsDisposed))
            {
                if (_fClientsPopUp.Client.Id == e.ClientId)
                {
                    _fClientsPopUp.RefreshData();
                }
                else
                {
                    _fClientsPopUp.RefreshNavigateData();
                }
            }
        }

        private void FClientsClientDeleted(object sender, ClientOperationEventArgs e)
        {
            if (!(_fClientsPopUp == null || _fClientsPopUp.IsDisposed))
            {
                if (_fClientsPopUp.Client.Id == e.ClientId)
                {
                    _fClientsPopUp.TerminateForm();
                }
            }
        }

        #endregion fClients

        #region fCalendar

        private void FCalendarRefreshClient(object sender, ClientOperationEventArgs e)
        {
            if (!(_fClients == null || _fClients.IsDisposed))
            {
                if (_fClients.Client.Id == e.ClientId || e.ClientId == -1)
                {
                    _fClients.RefreshData();
                }
            }

            if (!(_fClientsPopUp == null || _fClientsPopUp.IsDisposed))
            {
                if (_fClientsPopUp.Client.Id == e.ClientId || e.ClientId == -1)
                {
                    _fClientsPopUp.RefreshData();
                }
            }
        }

        // remove remainder from remainders collection
        private void FCalendarRemoveRemainder(object sender, RemainderEventArgs e)
        {
            _scheduleTasks.CheckRemainders();
            if (!(_fRemainder == null || _fRemainder.IsDisposed))
            {
                _fRemainder.RemoveRemainder(e.Id);
            }
        }

        // check for new remainders
        private void FCalendarRefreshRemainder(object sender, EventArgs e)
        {
            _scheduleTasks.CheckRemainders();
        }

        #endregion fCalendar

        #region fClientsPopUp

        private void FClientsPopUpClientUpdated(object sender, ClientOperationEventArgs e)
        {
            if (!(_fClients == null || _fClients.IsDisposed))
            {
                if (_fClients.Client.Id == e.ClientId)
                {
                    _fClients.RefreshData();
                }
                else
                {
                    _fClients.RefreshNavigateData();
                }
            }
        }

        private void FClientsPopUpNavigatePrevClient(object sender, EventArgs e)
        {
            if (!(_fReport == null || _fReport.IsDisposed))
            {
                _fReport.SelectRowByKey(_fClientsPopUp.Client.Key);
            }
        }

        private void FClientsPopUpNavigateNextClient(object sender, EventArgs e)
        {
            if (!(_fReport == null || _fReport.IsDisposed))
            {
                _fReport.SelectRowByKey(_fClientsPopUp.Client.Key);
            }
        }

        private void FClientsPopUpRequestForUpdateClient(object sender, ClientOperationEventArgs e)
        {
            if (!(_fClients == null || _fClients.IsDisposed))
            {
                if (_fClients.Client.Id == e.ClientId)
                {
                    if (_fClients.Status == FormClients.FormStatus.Edit || _fClients.Status == FormClients.FormStatus.Delete)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        #endregion fClientsPopUp

        #region fBirthday

        // open the client card
        private void FBirthdayShowClientCard(object sender, ShowClientCardEventArgs e)
        {
            _fClients.RefreshData(e.UserId);
            _fClients.SetNavigateClientId(e.UserId);
            if (!(_fSearchClient == null || _fSearchClient.IsDisposed))
            {
                FSearchClientHideForm(null, new OpenFormEventArgs("frmSearchClient"));
            }
            ShowClientCardForm();
        }

        #endregion fBirthday

        #region fWorkerDetails

        private void FWorkerDetailsFormClosed(object sender, FormClosedEventArgs e)
        {
            if (_fWorkerDetails.ReturnToReportForm)
            {
                TabStrip.SelectTab(1);
                _fReport.Select();
            }
            else
            {
                ShowFormInPanel(_fWorkersManage);
            }
        }

        private void FWorkerDetailsWorkerChange(object sender, WorkerUpdateEventArgs e)
        {
            if (!(_fWorkersManage == null || _fWorkersManage.IsDisposed))
            {
                _fWorkersManage.RefreshGrids();
                _fWorkersManage.SelectWorker(e.Worker.Id);
            }
            if (!(_fCalendar == null || _fCalendar.IsDisposed)) _fCalendar.ReloadWorkers();
            if (!(_fEventDetails == null || _fEventDetails.IsDisposed)) _fEventDetails.ReloadWorkers();
            if (!(_fClients == null || _fClients.IsDisposed))
            {
                _fClients.RefreshWorkersList();
                _fClients.RefreshData();
            }
        }

        #endregion fWorkerDetails

        #region fSearchClient

        private void FSearchClientDeleteClient(object sender, EventArgs e)
        {
            var id = _fSearchClient.GetSelectedClientId();
            if (id > 0)
            {
                _fClients.DeleteUser(id);
            }
        }

        private void FSearchClientHideForm(object sender, OpenFormEventArgs e)
        {
            switch (e.FormName)
            {
                case "frmSearchClient":
                    _fSearchClient.Hide();
                    ShowFormInPanel(_fClients);

                    switch (Convert.ToString(e.Param))
                    {
                        case "NewClient":
                            _fClients.AddNewClient();
                            break;

                        case "EditClient":
                            _fClients.EditClient(e.Id);
                            break;
                    }

                    break;
            }
        }

        #endregion fSearchClient

        #region fEventDetails

        private void FEventDetailsCancelWaitingClient(object sender, EventArgs e)
        {
            if (!(_fCalendar == null || _fCalendar.IsDisposed))
            {
                _fCalendar.CancelWaitClient();
            }
        }

        private void FEventDetailsAddAppointment(object sender, CalendarEventArgs e)
        {
            if (!(_fCalendar == null || _fCalendar.IsDisposed))
            {
                _fCalendar.ReloadAppointments();
                _scheduleTasks.CheckRemainders();
                _fCalendar.TryLocateAppointment(e.AppointmentId);
                if (!(_fClients == null || _fClients.IsDisposed))
                {
                    if (_fClients.Client.Id == e.ClientId)
                    {
                        _fClients.RefreshData();
                    }
                }
            }
        }

        private void FEventDetailsRefreshRemainders(object sender, EventArgs e)
        {
            _scheduleTasks.CheckRemainders();
        }

        private void FEventDetailsEditAppointment(object sender, CalendarEventArgs e)
        {
            if (!(_fCalendar == null || _fCalendar.IsDisposed))
            {
                _fCalendar.ReloadAppointments();
                _fCalendar.TryLocateAppointment(e.AppointmentId);
                _scheduleTasks.CheckRemainders();
                if (!(_fClients == null || _fClients.IsDisposed))
                {
                    if (_fClients.Client.Id == e.ClientId)
                    {
                        _fClients.RefreshData();
                    }
                }
            }
        }

        private void FEventDetailsRemoveAppointment(object sender, CalendarEventArgs e)
        {
            if (!(_fCalendar == null || _fCalendar.IsDisposed))
            {
                _fCalendar.RemoveAppointment(e.AppointmentId);
            }
            if (!(_fClients == null || _fClients.IsDisposed))
            {
                if (_fClients.Client.Id == e.ClientId)
                {
                    _fClients.RefreshData();
                }
            }
        }

        private void FEventDetailsFormClosed(object sender, FormClosedEventArgs e)
        {
            ShowFormInPanel(_fCalendar);
            _fCalendar.FocusBack();
        }

        #endregion fEventDetails

        #region fContactDetails

        private void FContactDetailsFormClosed(object sender, FormClosedEventArgs e)
        {
            if (_fContactDetails.ReturnToReportForm)
            {
                TabStrip.SelectTab(1);
                _fReport.Select();
            }
            else
            {
                ShowFormInPanel(_fPhoneBook);
            }

            if (!(_fPhoneBook == null || _fPhoneBook.IsDisposed))
            {
                _fPhoneBook.FocusSelectedContact();
            }
        }

        // when contact person is updated in fContactDetails form
        private void FContactDetailsContactUpdate(object sender, ContactUpdateEventArgs e)
        {
            if (!(_fPhoneBook == null || _fPhoneBook.IsDisposed))
            {
                if (e.State == ContactUpdateEventArgs.ContactState.UpdatedContact)
                    _fPhoneBook.UpdateContact(e.Contact);
                else if (e.State == ContactUpdateEventArgs.ContactState.NewContact)
                    _fPhoneBook.AddContact(e.Contact);
                else if (e.State == ContactUpdateEventArgs.ContactState.DeleteContact)
                    _fPhoneBook.RemoveContact(e.Contact);
            }
        }

        #endregion fContactDetails

        #region fWorkersManage

        private void FWorkersManageWorkerDeleted(object sender, EventArgs e)
        {
            if (!(_fCalendar == null || _fCalendar.IsDisposed)) _fCalendar.ReloadWorkers();
            if (!(_fEventDetails == null || _fEventDetails.IsDisposed)) _fEventDetails.ReloadWorkers();
            if (!(_fClients == null || _fClients.IsDisposed))
            {
                _fClients.RefreshWorkersList();
                _fClients.RefreshData();
            }
        }

        #endregion fWorkersManage

        #region fPreference

        private void FPreferencesModemCommitCommand(object sender, ModemEventArgs e)
        {
            if (_cid != null && _cid.IsConnected)
            {
                _cid.SendCommand(e.OutputCommand);
            }
        }

        #endregion fPreference

        #endregion Other Forms Events

        #region Schedule Task Events

        // show birthday clients form
        private void CheckBirthday()
        {
            if (AppSettingsHelper.GetParamValue<bool>("MAIN_SHOW_TODAY_BIRTHDAY"))
            {
                try
                {
                    ShowTodayBirthday();
                }
                catch (Exception ex)
                {
                    EventLogManager.AddErrorMessage("Error execute ShowTodayBirthday", ex);
                    _scheduleTasks.Tasks["Birthday"].Enable = true;
                }
            }
        }

        private void CheckResetOprations()
        {
            if (!(_fWorkersManage == null || _fWorkersManage.IsDisposed))
            {
                _fWorkersManage.SetDate();
                _fWorkersManage.SetEnterMode();
            }

            if (!(_fClients == null || _fClients.IsDisposed)) _fClients.StartShowBulletsThread();
            //if (!(fClientsPopUp == null || fClientsPopUp.IsDisposed)) fClientsPopUp.ShowHideBirthdayIcon();
            if (!(_fCalendar == null || _fCalendar.IsDisposed)) _fCalendar.RedrawDtPicker();

            // set all subscribers status
            SubscriberHelper.SetAllStatus();
        }

        #endregion Schedule Task Events

        // initialize components & to some startup tasks
        private void Form1Load(object sender, EventArgs e)
        {
            if (_tapiException != null)
            {
                InitializeTapi();
                // ReSharper disable ConditionIsAlwaysTrueOrFalse
                if (_tapiException != null)
                // ReSharper restore ConditionIsAlwaysTrueOrFalse
                {
                    const string title = "שגיאה במערכת SoftHair...";
                    const string head = "איתחול המודם";
                    const string desc = "ארעה שגיאה באתחול המודם. וודא כי יישום אחר לא משתמש בו.\nלא תוכל לזהות שיחות נכנסות וכן לא תוכל לבצע שיחות יוצאות";
                    var res = General.ShowErrorMessageDialog(this, title, head, desc, _tapiException, "frmMain", true);
                    while (res == VDialogResult.Retry)
                    {
                        InitializeTapi();
                        res = General.ShowErrorMessageDialog(this, title, head, desc, _tapiException, "frmMain", true);
                    }
                    _tapiException = null;
                }
            }

            // show form of today birthday clients
            if (_fBirthday != null)
            {
                _fBirthday.Show(this);
                _fBirthday.Select();
            }

            _firstActive = false;
        }

        // when closing application, check for current sms job sending and shut down tapi listener
        private void FrmMainFormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            AppSettingsHelper.ClearHistory();
            try
            {
                EventLogHelper.AddEvent(new LogInfo(LogInfo.LogType.LogOff, string.Empty, string.Empty));
            }
            catch { Utils.CatchException(); }

            if (ClosingApplication != null) ClosingApplication(this, new EventArgs());
            ShutDownApplication();
        }

        private void FrmMainActivated(object sender, EventArgs e)
        {
            if (!_firstActive)
            {
                _firstActive = true;
                if (!(_fBirthday == null || _fBirthday.IsDisposed))
                {
                    _fBirthday.Select();
                }
            }
        }

        // when data recieved in comm port - another thread
        private void CidCommIncomeData(object sender, CommCallEventArgs e)
        {
            try
            {
                this.Invoke(_commCallerDelegate, new[] { sender, e });
            }
            catch { Utils.CatchException(); }
        }

        // when data recieved in comm port - current thread
        public void RaiseCallerEvent(object sender, CommCallEventArgs e)
        {
            Application.DoEvents();
            if (e.Type == CommCallEventArgs.CommCallEventType.Number)
            {
                var caller = e.EventData;
                if (caller.Length < 7) caller = string.Empty;
                if (caller.Equals(Properties.Resources.end_license_phone_no))
                {
                    _cid.SendCommand("ATA");
                    _cid = null;
                }
                else
                {
                    ShowCallerIdForm(caller);
                }
            }
            if (!(_fPreferences == null || _fPreferences.IsDisposed))
            {
                if (_fPreferences.IsListenToModem)
                {
                    _fPreferences.AddModemEvent(e.ModemData + "  [Type=" + e.Type + ", Parameters=" + e.EventData + "]");
                }
            }
        }

        private void PnlFormsSizeChanged(object sender, EventArgs e)
        {
            foreach (Form f in pnlForms.Controls)
            {
                f.Size = pnlForms.Size;
            }
        }

        private static char GetCharFromKeys(Keys keyData)
        {
            char keyValue;
            switch (keyData)
            {
                case Keys.Add:
                case Keys.Oemplus:
                    keyValue = '+';
                    break;

                case Keys.OemMinus:
                case Keys.Subtract:
                    keyValue = '-';
                    break;

                case Keys.OemQuestion | Keys.Shift:
                    keyValue = '?';
                    break;

                case Keys.OemQuestion:
                case Keys.Divide:
                    keyValue = '/';
                    break;

                default:
                    if ((0x60 <= (int)keyData) && (0x69 >= (int)keyData))
                    {
                        keyValue = (char)((int)keyData - 0x30);
                    }
                    else
                    {
                        keyValue = (char)keyData;
                    }
                    break;
            }
            return keyValue;
        }

        private void HookKeyPressKeyPress(Keys key)
        {
            if (_keyPressPipe == null) { return; }

            try
            {
                _keyPressPipe.Push(GetCharFromKeys(key));
            }
            catch { Utils.CatchException(); }
        }

        #endregion Controls Event

        //private int _cardId;

        private void TabStripMouseDoubleClick(object sender, MouseEventArgs e)
        {
#if DEBUG
            foreach (var c in "01012008900005555555555")
            {
                _keyPressPipe.Push(c);
            }
#endif
            //SendKeys.Send("0"); //"1012008900005555555555");            //SyncContacts();
            //var mode = RegistryFactory.Read("Mode");

            //_cardId++;
            //if(_cardId > 4) _cardId = 1;
            //_fWorkersManage.ProcessCard("0101200860000" + _cardId.ToString().PadLeft(10, '0'));

            //if (mode == "Debug")
            //{
            //var ps = "0544983874 0509205014 0525805608 0525555555".Split(' ');

            //Client c;
            //var rnd = new Random();
            //do
            //{
            //    c = ClientHelper.GetClient(rnd.Next(900));
            //} while (c == null);

            //ShowCallerIdForm(Utils.DistilPhone(c.CellPhone1));
            //ShowCallerIdForm("0551234567");
            //ShowCallerIdForm("private");
            //}
        }

        // open another form
        private void FormOpenForm(object sender, OpenFormEventArgs e)
        {
            Appointment app = null;
            DataTable table;

            switch (e.FormName)
            {
                case "frmBirthday":

                    #region "frmBirthday"

                    e.ReturnStatus = ShowTodayBirthday() ? 1 : 0;
                    break;

                #endregion "frmBirthday"

                case "frmSMS":

                    #region frmSMS

                    var list = (List<PostAddressee>)e.Param;

                    if (_fSms == null || _fSms.IsDisposed)
                    {
                        _fSms = new FormSms(list) { Icon = this.Icon, DefaultMessageId = e.Id };
                        _fSms.Show();
                    }
                    else
                    {
                        if (list.Count > 0)
                        {
                            var res = DialogResult.No;
                            if (_fSms.TotalClients > 0)
                            {
                                const string msg1 = "האם ברצונך להוסיף את הנמענים לאלה הנמצאים בחלון ה-SMS?\n\nלחץ כן להוספה.\nלחץ לא לסגירת החלון הקיים ופתיחת חלון חדש.\nלחץ ביטול לביטול הפעולה.";
                                const string msg2 = "שליחת הודעות SMS...";
                                _myMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNoCancel);
                                res = _myMessageBox.Show(this);
                            }
                            if (res == DialogResult.No) _fSms.RefreshClients(list);
                            else if (res == DialogResult.Yes) _fSms.AddPersonsRange(list);
                            else return;
                        }

                        if (e.Id > 0) _fSms.SelectMessage(e.Id);
                        Utils.FocusWindow(_fSms.Handle, true);
                    }
                    break;

                #endregion frmSMS

                case "frmEventDetails":

                    #region frmEventDetails

                    if (!(_fEventDetails == null || _fEventDetails.IsDisposed))
                    {
                        const string msg1 = "חלון קביעת תור פתוח ולא ניתן לפתוח חלון נוסף\nתחילה יש לשמור את השינויים ולסגור אותו";
                        const string msg2 = "הוספה / עדכון איש קשר...";

                        _myMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                        _myMessageBox.Show(this);
                        return;
                    }

                    app = (Appointment)e.Param;
                    var isAllDay = (e.Id == 1);

                    _fEventDetails = app == null ? new FormEventDetails(_fCalendar.SelectedScope, _fCalendar.CalendarFocusWorkerId, isAllDay) : new FormEventDetails(app);
                    _fEventDetails.FormClosed += FEventDetailsFormClosed;
                    _fEventDetails.RemoveAppointment += FEventDetailsRemoveAppointment;
                    _fEventDetails.EditAppointment += FEventDetailsEditAppointment;
                    _fEventDetails.AddAppointment += FEventDetailsAddAppointment;
                    _fEventDetails.RefreshRemainders += FEventDetailsRefreshRemainders;
                    _fEventDetails.CancelWaitingClient += FEventDetailsCancelWaitingClient;
                    _fEventDetails.ShowClientCard += FIncomingCallShowClientCard;

                    var sc = new ScreenCapture();
                    _fEventDetails.CalendarSnap = sc.CaptureWindow(_fCalendar.CalendarHandler);
                    ShowFormInPanel(_fEventDetails);
                    _fEventDetails.CheckForAutoAttachClient();
                    break;

                #endregion frmEventDetails

                case "frmCalendar":

                    #region frmCalendar

                    if (!(_fEventDetails == null || _fEventDetails.IsDisposed))
                    {
                        const string msg1 = "חלון קביעת תור פתוח ולא ניתן לפתוח חלון נוסף\nעבור אל לשונית יומן, שמור את השינויים וסגור את החלון";
                        const string msg2 = "הוספה / עדכון איש קשר...";

                        _myMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                        _myMessageBox.Show(this);
                        return;
                    }

                    if (TabStrip.SelectedIndex != 3) TabStrip.SelectTab(3);
                    app = (Appointment)e.Param;
                    _fCalendar.LocateAppointment(app);
                    if (this.WindowState == FormWindowState.Minimized)
                    {
                        this.WindowState = FormWindowState.Maximized;
                    }
                    if (!(_fClientsPopUp == null || _fClientsPopUp.IsDisposed))
                    {
                        _fClientsPopUp.WindowState = FormWindowState.Minimized;
                    }
                    if (e.Id == -1) Utils.FocusWindow(this.Handle, false, Utils.FocusWindowState.Maximized);
                    break;

                #endregion frmCalendar

                case "frmContactDetails":

                    #region frmContactDetails

                    if (_fPhoneBook == null || _fPhoneBook.IsDisposed)
                    {
                        _fPhoneBook = new FormPhonebook();
                        _fPhoneBook.OpenForm += FormOpenForm;
                        _fPhoneBook.DialRequest += FormDialRequest;
                    }

                    if (!(_fContactDetails == null || _fContactDetails.IsDisposed))
                    {
                        const string msg1 = "כרטיס איש קשר פתוח ולא ניתן לפתוח כרטיס נוסף\nתחילה יש לשמור את השינויים ולסגור אותו";
                        const string msg2 = "הוספה / עדכון איש קשר...";

                        _myMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                        _myMessageBox.Show(this);
                        return;
                    }
                    _fContactDetails = e.Id == 0 ? new FormContactDetails() : new FormContactDetails(e.Id);
                    _fContactDetails.ContactUpdate += FContactDetailsContactUpdate;
                    _fContactDetails.FormClosed += FContactDetailsFormClosed;
                    _fContactDetails.ReturnToReportForm = e.ReturnToReportForm;

                    ShowFormInPanel(_fContactDetails);
                    if (true.Equals(e.Param)) TabStrip.SelectTab(2);
                    break;

                #endregion frmContactDetails

                case "frmSearchClient":

                    #region frmSearchClient

                    var activeMe = true;
                    if (_fSearchClient == null || _fSearchClient.IsDisposed)
                    {
                        _fSearchClient = new FormSearchClient();
                        _fSearchClient.ShowClientCard += FIncomingCallShowClientCard;
                        _fSearchClient.HideForm += FSearchClientHideForm;
                        _fSearchClient.SetAppointment += FClientsSetAppointment;
                        _fSearchClient.DeleteClient += FSearchClientDeleteClient;
                        _fSearchClient.OpenForm += FormOpenForm;
                        _fSearchClient.DialRequest += FormDialRequest;
                        _fSearchClient.IsLastActive = true;
                        activeMe = false;
                    }
                    ShowFormInPanel(_fSearchClient);
                    _fSearchClient.Clear();
                    _fSearchClient.SelectClient(e.Id);
                    if (activeMe) _fSearchClient.ActivateMe();
                    break;

                #endregion frmSearchClient

                case "frmMailCampaign":

                    #region frmMailCampaign

                    table = (DataTable)e.DataSource;

                    if (_fMailCampaign == null || _fMailCampaign.IsDisposed)
                    {
                        _fMailCampaign = new FormMailCampaign(table) { Icon = this.Icon };
                        _fMailCampaign.Show();
                    }
                    else
                    {
                        if (table.Rows.Count == 1)
                        {
                            var row = table.Rows[0];
                            _fMailCampaign.AddPerson(Utils.GetDBValue<string>(row, "full_name"), Utils.GetDBValue<string>(row, "email"));
                        }
                        else if (table.Rows.Count > 1)
                        {
                            var res = DialogResult.No;
                            if (_fMailCampaign.TotalClients > 0)
                            {
                                const string msg1 = "האם ברצונך להוסיף את הנמענים לאלה הנמצאים בחלון הדוא\"ל?\n\nלחץ כן להוספה.\nלחץ לא לסגירת החלון הקיים ופתיחת חלון חדש.\nלחץ ביטול לביטול הפעולה.";
                                const string msg2 = "שליחת הודעות דוא\"ל...";
                                _myMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNoCancel);
                                res = _myMessageBox.Show(this);
                            }

                            if (res == DialogResult.No) _fMailCampaign.RefreshClients(table);
                            else if (res == DialogResult.Yes) _fMailCampaign.AddPersonsRange(table);
                            else return;
                        }
                        var state = this.WindowState == FormWindowState.Maximized ? Utils.FocusWindowState.Maximized : Utils.FocusWindowState.Normal;
                        Utils.FocusWindow(_fMailCampaign.Handle, true, state);
                    }

                    break;

                #endregion frmMailCampaign

                case "frmWorkerDetails":

                    #region frmWorkerDetails

                    if (_fWorkersManage == null || _fWorkersManage.IsDisposed)
                    {
                        _fWorkersManage = new FormWorkersManage();
                        _fWorkersManage.OpenForm += FormOpenForm;
                        _fWorkersManage.WorkerDeleted += FWorkersManageWorkerDeleted;
                        _fWorkersManage.DialRequest += FormDialRequest;
                        _fWorkersManage.SelectWorkerTab += FWorkersManageSelectWorkerTab;
                    }

                    if (!(_fWorkerDetails == null || _fWorkerDetails.IsDisposed))
                    {
                        const string msg1 = "כרטיס עובד פתוח ולא ניתן לפתוח כרטיס נוסף\nתחילה יש לשמור את השינויים ולסגור אותו";
                        const string msg2 = "הוספה / עדכון עובד...";

                        var box = new MyMessageBox
                        {
                            Text = msg1,
                            Caption = msg2,
                            MessageButtons = MyMessageBox.MyMessageButton.Ok,
                            MessageType = MyMessageBox.MyMessageType.Warning
                        };
                        var m = new FormMessage(box);
                        m.ShowDialog(this);
                        return;
                    }

                    _fWorkerDetails = e.Id == 0 ? new FormWorkerDetails() : new FormWorkerDetails(e.Id);
                    _fWorkerDetails.WorkerChange += FWorkerDetailsWorkerChange;
                    _fWorkerDetails.FormClosed += FWorkerDetailsFormClosed;
                    _fWorkerDetails.ReturnToReportForm = e.ReturnToReportForm;

                    ShowFormInPanel(_fWorkerDetails);
                    if (true.Equals(e.Param)) TabStrip.SelectTab(5);

                    break;

                #endregion frmWorkerDetails

                case "frmPhotoAlbum":

                    #region frmPhotoAlbum

                    if (!(_fPhotoAlbum == null || _fPhotoAlbum.IsDisposed))
                    {
                        try { _fPhotoAlbum.Close(); }
                        catch { Utils.CatchException(); }
                        _fPhotoAlbum = null;
                    }
                    _fPhotoAlbum = new FormPhotoAlbum(e.Id);
                    _fPhotoAlbum.DialRequest += FormDialRequest;
                    _fPhotoAlbum.OpenForm += FormOpenForm;
                    _fPhotoAlbum.RefreshClient += FCalendarRefreshClient;
                    _fPhotoAlbum.FormClosed += FPhotoAlbumFormClosed;
                    _fPhotoAlbum.RefreshClientBullets += FPhotoAlbumRefreshClientBullets;
                    _fPhotoAlbum.Show();
                    break;

                #endregion frmPhotoAlbum

                case "frmPhotoDetails":

                    #region frmPhotoDetails

                    ClientPhoto photo = null;

                    if (e.Param == null)
                    {
                        var appId = PhotoAlbumHelper.GetPhotoAppointmentId(e.Id);
                        DataRow row;
                        try
                        {
                            row = CalendarHelper.GetAppointment(appId);
                        }
                        catch (Exception ex)
                        {
                            General.ShowCommunicationError(ex, this);
                            return;
                        }
                        if (string.IsNullOrEmpty(appId) == false) app = FormCalendar.GetAppointmentFromDataRow(row);
                    }
                    else
                    {
                        if (e.Param is ClientPhoto) photo = (ClientPhoto)e.Param;
                        else if (e.Param is Appointment) app = (Appointment)e.Param;
                    }

                    if (!(_fPhotoDetails == null || _fPhotoDetails.IsDisposed))
                    {
                        _fPhotoDetails.SetAppointment(app);
                        _fPhotoDetails.RefreshData(photo);
                        // ReSharper disable RedundantCheckBeforeAssignment
                        if (_fPhotoDetails.WindowState != FormWindowState.Normal) _fPhotoDetails.WindowState = FormWindowState.Normal;
                        // ReSharper restore RedundantCheckBeforeAssignment
                        _fPhotoDetails.Select();
                        if (_fPhotoDetails.IsNewMode && photo != null)
                        {
                            const string msg1 = "חלון תמונת לקוח פתוח במצב הוספת תמונה חדשה\nשמור את השינויים וסגור את החלון";
                            const string msg2 = "תמונת לקוח...";
                            _myMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                            _myMessageBox.Show(_fPhotoDetails);
                        }
                    }
                    else
                    {
                        if (photo == null)
                        {
                            _fPhotoDetails = app == null ? new FormPhotoDetails(e.Id) : new FormPhotoDetails(app);
                        }
                        else
                        {
                            _fPhotoDetails = new FormPhotoDetails(photo);
                        }
                        _fPhotoDetails.MoveNext += FPhotoDetailsMoveNext;
                        _fPhotoDetails.MovePrevious += FPhotoDetailsMovePrev;
                        _fPhotoDetails.AddPhoto += FPhotoDetailsAddPhoto;
                        _fPhotoDetails.DeletePhoto += FPhotoDetailsDeletePhoto;
                        _fPhotoDetails.OpenForm += FormOpenForm;
                        _fPhotoDetails.Show();
                    }
                    break;

                #endregion frmPhotoDetails

                case "frmStickers":

                    var msg = new MyMessageBox("חלון לא נתמך", "שגיאה...");
                    msg.Show();
                    break;

                case "frmSubscription":

                    #region frmSubscription

                    if (!(_fSubscription == null || _fSubscription.IsDisposed))
                    {
                        if (_fSubscription.Status == FormSubscription.FormStatus.Edit)
                        {
                            const string msg3 = "ישנו חלון מנויים פתוח ובמצב עדכון\nסגור תחילה את החלון הפתוח";
                            _myMessageBox = new MyMessageBox(msg3, "חלון מנויים...", MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                            _myMessageBox.Show(this);
                            break;
                        }
                        _fSubscription.Close();
                        _fSearchClient = null;
                    }
                    _fSubscription = new FormSubscription((Client)e.Param);
                    _fSubscription.RefreshClientBullets += FSubscriptionRefreshClientBullets;
                    _fSubscription.Show(this);
                    break;

                    #endregion frmSubscription
            }
        }

        private void FPhotoAlbumRefreshClientBullets(object sender, EventArgs e)
        {
            _fClients.ShowBulletsTotals();
        }

        private void FSubscriptionRefreshClientBullets(object sender, EventArgs e)
        {
            _fClients.ShowBulletsTotals();
        }

        private void FPhotoDetailsDeletePhoto(object sender, PhotoAlbumEventArgs e)
        {
            if (_fPhotoAlbum == null || _fPhotoAlbum.IsDisposed) return;
            _fPhotoAlbum.DeletePhoto(e.Photo, _fPhotoDetails);
        }

        private void FPhotoDetailsAddPhoto(object sender, PhotoAlbumEventArgs e)
        {
            if (_fPhotoAlbum == null || _fPhotoAlbum.IsDisposed) return;
            _fPhotoAlbum.AddPhoto(e.Photo);
        }

        private void FPhotoDetailsMovePrev(object sender, EventArgs e)
        {
            if (_fPhotoAlbum == null || _fPhotoAlbum.IsDisposed) return;
            _fPhotoAlbum.MovePrevious();
            _fPhotoAlbum.ShowPhotoDetails();
        }

        private void FPhotoAlbumFormClosed(object sender, FormClosedEventArgs e)
        {
            if (!(_fPhotoDetails == null || _fPhotoDetails.IsDisposed)) _fPhotoDetails.Close();
            _fPhotoDetails = null;
        }

        private void FPhotoDetailsMoveNext(object sender, EventArgs e)
        {
            if (_fPhotoAlbum == null || _fPhotoAlbum.IsDisposed) return;
            _fPhotoAlbum.MoveNext();
            _fPhotoAlbum.ShowPhotoDetails();
        }

        // change the selected tab
        private void TabStripTabClick(object sender, EventArgs e)
        {
            if (_selectedTabIndex != 3)
            {
                if (!(_fCalendar == null || _fCalendar.IsDisposed))
                {
                    _fCalendar.AcceptCalendarChanges();
                }
            }

            switch (_selectedTabIndex)
            {
                case 3:
                    //CalendarHelper.UpdateCares();
                    break;

                case 5:
                    if (!(_fWorkersManage == null || _fWorkersManage.IsDisposed))
                    {
                        _fWorkersManage.CancelEditGrid();
                        _fWorkersManage.LogOffAdmin();
                    }
                    break;

                case 6:
                    if (!(_fPreferences == null || _fPreferences.IsDisposed))
                    {
                        if (TabStrip.SelectedIndex != 4 && TabStrip.SelectedIndex != 6)
                        {
                            _fPreferences.CloseForm();
                        }
                    }
                    break;
            }

            switch (TabStrip.SelectedIndex)
            {
                case 0:

                    #region frmClients + frmSearchClient

                    if ((!(_fSearchClient == null || _fSearchClient.IsDisposed)) && (!_forceToShowClientCard && _fSearchClient.IsLastActive))
                    {
                        FormOpenForm(null, new OpenFormEventArgs("frmSearchClient"));
                        return;
                    }
                    // ***** ATTENTION *****
                    // ***** Any change in load frmClients should be refrected at fIncomingCall_ShowClientCard Event!!! *****

                    if (_fClients == null || _fClients.IsDisposed)
                    {
                        _fClients = new FormClients();
                        _fClients.OpenForm += FormOpenForm;
                        _fClients.SetAppointment += FClientsSetAppointment;
                        _fClients.RefreshCalendar += FClientsRefreshCalendar;
                        _fClients.ClientDeleted += FClientsClientDeleted;
                        _fClients.ClientUpdated += FClientsClientUpdated;
                        _fClients.RequestForUpdateClient += FClientsRequestForUpdateClient;
                        _fClients.DialRequest += FormDialRequest;
                        _fClients.ClientAdded += FClientsClientAdded;
                    }
                    ShowFormInPanel(_fClients);
                    break;

                #endregion frmClients + frmSearchClient

                case 1:

                    #region frmDynamicReport

                    if (_fReport == null || _fReport.IsDisposed)
                    {
                        _fReport = new FormDynamicReport();
                        _fReport.ShowClientCard += FIncomingCallShowClientCard;
                        _fReport.OpenForm += FormOpenForm;
                    }
                    _fReport.RefreshImages();
                    ShowFormInPanel(_fReport);

                    break;

                #endregion frmDynamicReport

                case 2:

                    #region frmPhoneBook + frmContactDetails

                    if (!(_fContactDetails == null || _fContactDetails.IsDisposed))
                    {
                        ShowFormInPanel(_fContactDetails);
                    }
                    else
                    {
                        if (_fPhoneBook == null || _fPhoneBook.IsDisposed)
                        {
                            _fPhoneBook = new FormPhonebook();
                            _fPhoneBook.OpenForm += FormOpenForm;
                            _fPhoneBook.DialRequest += FormDialRequest;
                        }
                        ShowFormInPanel(_fPhoneBook);
                        _fPhoneBook.FocusSelectedContact();
                    }
                    break;

                #endregion frmPhoneBook + frmContactDetails

                case 3:

                    #region frmCalendar + frmEventDetails

                    if (!(_fEventDetails == null || _fEventDetails.IsDisposed))
                    {
                        ShowFormInPanel(_fEventDetails);
                        _fEventDetails.CheckForAutoAttachClient();
                    }
                    else
                    {
                        if (_fCalendar == null || _fCalendar.IsDisposed)
                        {
                            _fCalendar = new FormCalendar();
                            _fCalendar.RefreshRemainder += FCalendarRefreshRemainder;
                            _fCalendar.RemoveRemainder += FCalendarRemoveRemainder;
                            _fCalendar.OpenEventForm += FormOpenForm;
                            _fCalendar.RefreshClient += FCalendarRefreshClient;
                            _fCalendar.ShowClientCard += FIncomingCallShowClientCard;
                            _fCalendar.MainFormFocus += FCalendarMainFormFocus;
                            _fCalendar.OpenForm += FormOpenForm;
                            _fCalendar.DialRequest += FormDialRequest;
                            _fCalendar.ShowReport += FormShowReport;
                            _fCalendar.SendSmsReminder += CalendarSendSmsReminder;
                            _fCalendar.AddAttendees += _fCalendar_AddAttendees;
                            _fCalendar.ShowHistory += _fCalendar_ShowHistory;
                        }
                        ShowFormInPanel(_fCalendar);
                        _fCalendar.FocusBack();
                    }
                    break;

                #endregion frmCalendar + frmEventDetails

                case 4:

                    #region Exit

                    if (CheckForCloseApplication())
                    {
                        this.Close();
                    }
                    else
                    {
                        TabStrip.SelectTab(_selectedTabIndex);
                    }
                    break;

                #endregion Exit

                case 5:

                    #region frmWorkersManage + frmWorkerDetails

                    if (!(_fWorkerDetails == null || _fWorkerDetails.IsDisposed))
                    {
                        ShowFormInPanel(_fWorkerDetails);
                    }
                    else
                    {
                        if (_fWorkersManage == null || _fWorkersManage.IsDisposed)
                        {
                            _fWorkersManage = new FormWorkersManage();
                            _fWorkersManage.OpenForm += FormOpenForm;
                            _fWorkersManage.WorkerDeleted += FWorkersManageWorkerDeleted;
                            _fWorkersManage.DialRequest += FormDialRequest;
                            _fWorkersManage.SelectWorkerTab += FWorkersManageSelectWorkerTab;
                        }
                        ShowFormInPanel(_fWorkersManage);
                    }
                    break;

                #endregion frmWorkersManage + frmWorkerDetails

                case 6:

                    #region frmPreferences

                    if (_fPreferences == null || _fPreferences.IsDisposed)
                    {
                        _fPreferences = new FormOptions();
                        _fPreferences.ModemCommitCommand += FPreferencesModemCommitCommand;
                    }
                    else
                    {
                        _fPreferences.OpenForm();
                    }
                    ShowFormInPanel(_fPreferences);
                    break;

                    #endregion frmPreferences
            }

            _selectedTabIndex = TabStrip.SelectedIndex;
        }

        private void _fCalendar_ShowHistory(object sender, CalendarEventArgs e)
        {
            ////using (var f = new frmAudit(e.AppointmentId))
            ////{
            ////    f.ShowDialog(this);
            ////}
        }

        private void _fCalendar_AddAttendees(object sender, CalendarEventArgs e)
        {
            AddAttendees(e);
        }

        private void FClientsClientAdded(object sender, EventArgs e)
        {
            if (!(_fSearchClient == null || _fSearchClient.IsDisposed))
            {
                _fSearchClient.RefreshForm();
            }
        }

        private void FormShowReport(object sender, ShowReportEventArgs e)
        {
            TabStrip.SelectTab(1);
            _fReport.ShowReport(e.Group, e.ReportId, e.Paramaters);
            _fReport.Select();
        }

        private void FCalendarMainFormFocus(object sender, EventArgs e)
        {
            this.Select();
        }

        private void FWorkersManageSelectWorkerTab(object sender, EventArgs e)
        {
            TabStrip.SelectTab(5);
        }

        private void CalendarSendSmsReminder(object sender, CalendarEventArgs e)
        {
            SendSingleCalSms(e);
        }

        private void FormDialRequest(object sender, DialRequestEventArgs e)
        {
            const string msg2 = "חייג...";
            string msg1;

            if (!AppSettingsHelper.GetParamValue<bool>("APP_ENABLE_OUT_CALLS"))
            {
                msg1 = "האפשרות לחיוג (שיחות יוצאות) חסומה";
                _myMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                _myMessageBox.Show(this);
                return;
            }

            if (_cid == null || _cid.IsConnected == false)
            {
                msg1 = "החיבור אל המודם סגור\nהאם ברצונך לנסות ולפתוח אותו";
                _myMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo);
                var res = _myMessageBox.Show(this);
                if (res == DialogResult.Yes)
                {
                    InitializeTapi();
                }
            }

            if (_cid == null || _cid.IsConnected == false)
            {
                const string title = "שגיאה במערכת SoftHair...";
                const string head = "איתחול המודם";
                const string desc = "ארעה שגיאה באתחול המודם. וודא כי יישום אחר לא משתמש בו.\nלא תוכל לזהות שיחות נכנסות וכן לא תוכל לבצע שיחות יוצאות";
                General.ShowErrorMessageDialog(this, title, head, desc, null, "frmMain");
            }
            else
            {
                if (!(_fDialForm == null || _fDialForm.IsDisposed))
                {
                    try
                    {
                        _fDialForm.TerminateForm();
                    }
                    catch { Utils.CatchException(); }
                    _fDialForm = null;
                }
                _fDialForm = new FormDialForm(e, _cid);
                _fDialForm.AddDialCallLog += FDialFormAddDialCallLog;
                _fDialForm.Show(this);
            }
        }

        private static void FDialFormAddDialCallLog(object sender, DialRequestEventArgs e)
        {
            if (AppSettingsHelper.GetParamValue<bool>("PHONE_LOG_CALLS"))
            {
                PhoneHelper.AddCallLog(e.Id, e.PhoneNo, 1, e.Entity);
            }
        }

        private void ScheduleTasksExecuteTask(object sender, EventArgs e)
        {
            var task = (Task)sender;
            switch (task.Name)
            {
                case "TrafficLeave":
                    if (!(_fWorkersManage == null || _fWorkersManage.IsDisposed)) _fWorkersManage.SetLeaveMode();
                    else FormWorkersManage.NeedToSetLeave = true;
                    break;

                case "TrafficEnter":
                    if (!(_fWorkersManage == null || _fWorkersManage.IsDisposed)) _fWorkersManage.SetEnterMode();
                    break;

                case "Remainder":
                    var rows = _scheduleTasks.Events.GetCurrentEvents();
                    if (rows.Length > 0)
                    {
                        if (_fRemainder == null || _fRemainder.IsDisposed)
                        {
                            _fRemainder = new FormRemainder(rows);
                            _fRemainder.OpenForm += FormOpenForm;
                            _fRemainder.Show(this);
                            _fRemainder.Select();
                        }
                        else
                        {
                            _fRemainder.AddNewItems(rows);
                        }

                        _fRemainder.Select();
                    }
                    break;

                case "Birthday":
                    CheckBirthday();
                    break;

                case "License":
                    try
                    {
                        if (_fLicence == null || _fLicence.IsDisposed)
                        {
                            CheckLicense();
                        }
                    }
                    catch { Utils.CatchException(); }
                    break;

                case "Backup":
                    var del = new DoBackupHandler(DoBackupTask);
                    del.BeginInvoke(task, null, null);
                    break;

                case "Reset":
                    CheckResetOprations();
                    break;

                case "SMSBirthday":
                    if (SendAutoSms("SMS_BIRTHDAY_PARAMS", ClientHelper.GetAutoBirthdaySms(), SmsEngine.SmsMessageType.AutoBirthdate))
                    {
                        _scheduleTasks.Tasks["SMSBirthday"].Enable = false;
                    }
                    break;

                case "SMSMarriedDate":
                    if (SendAutoSms("SMS_MARRIED_PARAMS", ClientHelper.GetAutoMarriedSms(), SmsEngine.SmsMessageType.AutoMarriedDate))
                    {
                        _scheduleTasks.Tasks["SMSMarriedDate"].Enable = false;
                    }
                    break;

                case "SMSCalendarNotify":
                    var p1 = AppSettingsHelper.GetParamValue("SMS_CALENDAR_PARAMS");
                    var p2 = AppSettingsHelper.GetParamValue("SMS_CALENDAR_MESSAGE");
                    var param = new AutoCalSmsParams(p1, p2);
                    if (param.Enable) SentCalAutoSms(param);
                    else _scheduleTasks.Tasks["SMSCalendarNotify"].Enable = false;
                    break;

                case "SyncClients":
                    break;

                //case "SyncEvents":
                //    //BeginSyncEvents();
                //    break;

                case "UpdateVersion":
                    //var mi = new MethodInvoker(General.OnlineUpdate);
                    //mi.BeginInvoke(null, null);
                    break;
            }
        }

        /// <summary>
        /// Sends the auto SMS.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="data">The data.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        private static bool SendAutoSms(string key, DataTable data, SmsEngine.SmsMessageType type)
        {
            if (!SmsHelper.IsNowValidForAutoSms()) return false;
            if (data == null) return true;
            if (data.Rows.Count == 0) return true;
            var smsParams = new AutoSmsParameters(AppSettingsHelper.GetParamValue(key));
            if (!smsParams.Enable) return true;

            // get sms cell phones data from database
            var ids = Utils.GetDataSourceIds(data);
            var table = ReportHelper.GetClientsCellPhones(ids, false);
            var msg = SmsHelper.GetSavedMessage(smsParams.MessageId);
            var ok = false;

            var package = new SmsPackage { Messages = new List<SmsMessage>() };
            if (msg.Length > 0)
            {
                foreach (DataRow item in table.Rows)
                {
                    var name = Utils.GetFirstName(Utils.GetDBValue<string>(item, "full_name"));
                    var phone = Utils.DistilPhone(Utils.GetDBValue<string>(item, "cell_phone"));
                    var clientId = Utils.GetDBValue<int>(item, "id");

                    var sms = new SmsMessage
                    {
                        ToPhone = phone,
                        EntityId = clientId,
                        EntityType = (int)type,
                        MessageText = msg.Replace(Utils.AddUsername, name),
                        ReferenceId = "ClientId=" + clientId,
                    };
                    package.Messages.Add(sms);
                }

                var smsEngine = new SmsEngine();

                ok = smsEngine.SendMessage(package, type);
                if (ok)
                {
                    // save last submit parameter
                    smsParams.LastSubmit = DateTime.Now;
                    AppSettingsHelper.SetParamValue(key, smsParams.ToString(), true);
                }
            }

            return ok;
        }

        private void AddAttendees(CalendarEventArgs args)
        {
            if (args.ClientId == 0)
            {
                _myMessageBox = new MyMessageBox("לא ניתן לשלוח זימון\nלא משוייך לקוח לתור", "שליחת זימון ליומן לקוח", MyMessageBox.MyMessageType.Error, MyMessageBox.MyMessageButton.Ok);
                _myMessageBox.Show();
                return;
            }
            var client = ClientHelper.GetClient(args.ClientId);
            if (string.IsNullOrEmpty(client.Email))
            {
                _myMessageBox = new MyMessageBox("לא ניתן לשלוח זימון\nבכרטיס הלקוח אין כתובת דוא\"ל", "שליחת זימון ליומן לקוח", MyMessageBox.MyMessageType.Error, MyMessageBox.MyMessageButton.Ok);
                _myMessageBox.Show();
                return;
            }
            if (!Validation.IsEmailValid(Utils.DistilPhone(client.Email)))
            {
                _myMessageBox = new MyMessageBox("לא ניתן לשלוח זימון\nכתובת הדוא\"ל של הלקוח לא תקינה", "שליחת זימון ליומן לקוח", MyMessageBox.MyMessageType.Error, MyMessageBox.MyMessageButton.Ok);
                _myMessageBox.Show();
                return;
            }

            CalendarHelper.AddAttendees(args.AppointmentId, client.Email);
        }

        private void SendSingleCalSms(CalendarEventArgs args)
        {
            // *** ATTENTION: any changes to logic here must be reflected in SentCalAutoSms *** //
            if (args.ClientId == 0)
            {
                _myMessageBox = new MyMessageBox("לא ניתן לשלוח תזכורת\nלא משוייך לקוח לתור", "שליחת תזכורת", MyMessageBox.MyMessageType.Error, MyMessageBox.MyMessageButton.Ok);
                _myMessageBox.Show();
                return;
            }
            var client = ClientHelper.GetClient(args.ClientId);
            if (client.EnableSMS == false)
            {
                _myMessageBox = new MyMessageBox("לא ניתן לשלוח תזכורת\nהלקוח המשוייך חסום בכרטיס שלו להודעות SMS", "שליחת תזכורת", MyMessageBox.MyMessageType.Error, MyMessageBox.MyMessageButton.Ok);
                _myMessageBox.Show();
                return;
            }
            if (string.IsNullOrEmpty(client.CellPhone1))
            {
                _myMessageBox = new MyMessageBox("לא ניתן לשלוח תזכורת\nבכרטיס הלקוח אין מספר טלפון נייד", "שליחת תזכורת", MyMessageBox.MyMessageType.Error, MyMessageBox.MyMessageButton.Ok);
                _myMessageBox.Show();
                return;
            }
            if (!Validation.IsCellPhoneValid(Utils.DistilPhone(client.CellPhone1)))
            {
                _myMessageBox = new MyMessageBox("לא ניתן לשלוח תזכורת\nמספר הטלפון הנייד של הלקוח לא תקין", "שליחת תזכורת", MyMessageBox.MyMessageType.Error, MyMessageBox.MyMessageButton.Ok);
                _myMessageBox.Show();
                return;
            }
            var dbMessage = AppSettingsHelper.GetParamValue("SMS_MANUALMESSAGE");
            if (string.IsNullOrEmpty(dbMessage))
            {
                _myMessageBox = new MyMessageBox("לא הוגדר נוסח להודעת תזכורת", "שליחת תזכורת", MyMessageBox.MyMessageType.Error, MyMessageBox.MyMessageButton.Ok);
                _myMessageBox.Show();
                return;
            }

            var endTime = DateTime.Parse(AppSettingsHelper.GetParamValue("CALENDAR_END_TIME"));
            var package = new SmsPackage { Messages = new List<SmsMessage>() };
            DataTable table;
            try
            {
                table = SmsHelper.GetCalendarSms(args.AppointmentId);
            }
            catch (Exception ex)
            {
                General.ShowCommunicationError(ex, this);
                return;
            }

            if (table == null || table.Rows.Count == 0)
            {
                var message = string.Format("התור המבוקש (מזהה {0}) לא ניתן לשליפה", args.AppointmentId);
                General.ShowErrorMessageDialog(this, "שליחת תזכורת", "שליחת תזכורת", message, null, null);
                return;
            }
            var row = table.Rows[0];
            var dateStart = Utils.GetDBValue<DateTime>(row, "date_start");

            if (dateStart < DateTime.Now)
            {
                _myMessageBox = new MyMessageBox("תאריך ושעת תחילת התור כבר חלפו\nהאם בכל זאת לשלוח הודעת תזכורת?", "שליחת תזכורת", MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
                if (_myMessageBox.Show() == DialogResult.No) return;
            }

            var phone = Utils.GetDBValue<string>(row, "cell_phone");
            phone = Utils.DistilPhone(phone);

            // *** ATTENTION: any changes to logic here must be reflected in SentCalAutoSms *** //
            if (Validation.IsCellPhoneValid(phone, true))
            {
                var token = new StringTokenFormat();
                var msg = token.FormatString(dbMessage, row);
                msg = SmsHelper.SetSpecialParamaters(msg, row);
                var clientId = Utils.GetDBValue<int>(row, "client_id");
                var email = Utils.GetDBValue<string>(row, "email");

                var sms = new SmsMessage
                {
                    ToPhone = phone,
                    EntityId = clientId,
                    EntityType = (int)SmsEngine.SmsMessageType.AutoCalendarRemaind,
                    MessageText = msg,
                    ReferenceId = string.Format("id {0}, date {1:dd/MM/yyyy HH:mm}", args.AppointmentId, dateStart),
                };
                package.Messages.Add(sms);
            }

            var smsEngine = new SmsEngine();
            Exception smsException = null;

            try
            {
                if (smsEngine.SendMessage(package, SmsEngine.SmsMessageType.AutoCalendarRemaind))
                {
                    _myMessageBox = new MyMessageBox("התזכורת נשלחה בהצלחה", "שליחת תזכורת", MyMessageBox.MyMessageType.Confirm, MyMessageBox.MyMessageButton.None)
                    {
                        CloseInterval = 2000
                    };
                    _myMessageBox.Show();
                }
                else
                {
                    smsException = smsEngine.LastException;
                }
            }
            catch (Exception ex)
            {
                smsException = ex;
            }

            if (smsException != null)
            {
                General.ShowErrorMessageDialog(this, "שליחת תזכורת", "שליחת תזכורת", smsException.Message, smsException, null);
            }

            // *** ATTENTION: any changes to logic here must be reflected in SentCalAutoSms *** //
        }

        public void SentCalAutoSms(AutoCalSmsParams parameters)
        {
            HasAlertQueue.Flush();

            // *** ATTENTION: any changes to logic here must be reflected in SendSingleCalSms *** //
            if (!SmsHelper.IsNowValidForAutoSms()) return;

            var endTime = DateTime.Parse(AppSettingsHelper.GetParamValue("CALENDAR_END_TIME"));
            var package = new SmsPackage { Messages = new List<SmsMessage>() };
            DataTable table;
            try
            {
                table = SmsHelper.GetCalendarSms(parameters);
            }
            catch (Exception ex)
            {
                General.ShowCommunicationError(ex, this, false);
                return;
            }
            if (table == null || table.Rows.Count == 0) return;
            var smsEngine = new SmsEngine();

            // *** ATTENTION: any changes to logic here must be reflected in SendSingleCalSms *** //
            foreach (DataRow row in table.Rows)
            {
                var phone = Utils.GetDBValue<string>(row, "cell_phone");
                phone = Utils.DistilPhone(phone);

                if (Validation.IsCellPhoneValid(phone, true))
                {
                    var token = new StringTokenFormat();
                    var msg = token.FormatString(parameters.Message, row);
                    msg = SmsHelper.SetSpecialParamaters(msg, row);
                    var clientId = Utils.GetDBValue<int>(row, "client_id");
                    var appointmentId = Utils.GetDBValue<string>(row, "id");
                    var dateStart = Utils.GetDBValue<DateTime>(row, "date_start");
                    var email = Utils.GetDBValue<string>(row, "email");

                    var sms = new SmsMessage
                    {
                        ToPhone = phone,
                        EntityId = clientId,
                        EntityType = (int)SmsEngine.SmsMessageType.AutoCalendarRemaind,
                        MessageText = msg,
                        ReferenceId = string.Format("id {0}, date {1:dd/MM/yyyy HH:mm}", appointmentId, dateStart),
                    };
                    package.Messages.Clear();
                    package.Messages.Add(sms);

                    if (HasAlertQueue.Contains(appointmentId) == false)
                    {
                        var result = smsEngine.SendMessage(package, SmsEngine.SmsMessageType.AutoCalendarRemaind);
                        if (result == true)
                        {
                            parameters.LastSubmit = DateTime.Now;
                            AppSettingsHelper.SetParamValue("SMS_CALENDAR_PARAMS", parameters.ToString(), true);
                            try
                            {
                                SmsHelper.UpdateCalendarAlert(appointmentId);
                            }
                            catch (Exception ex)
                            {
                                HasAlertQueue.Add(appointmentId);
                                General.ShowCommunicationError(ex, this, false);
                                return;
                            }
                        }
                    }
                }
            }

            // *** ATTENTION: any changes to logic here must be reflected in SendSingleCalSms *** //

            // *** ATTENTION: any changes to logic here must be reflected in SendSingleCalSms *** //
        }

        private void FIncomingCallCreateNewClient(object sender, NewClientEventArgs e)
        {
            if (!(_fClients == null || _fClients.IsDisposed))
            {
                _fClients.AddNewClient(e.PhoneNumber);
                ShowClientCardForm();
            }
            Utils.FocusWindow(this.Handle, true, Utils.FocusWindowState.Maximized);
        }

        private void FormMainSizeChanged(object sender, EventArgs e)
        {
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }
    }
}