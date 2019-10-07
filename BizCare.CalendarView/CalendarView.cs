using BizCare.Calendar.Library;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BizCare.Calendar
{
    public partial class CalendarView : UserControl
    {
        #region Constructor

        public CalendarView()
        {
            InitializeComponent();
            TmrPointer.Tick += TmrPointer_Tick;
            _appointments.AppointmentsClear += Appointments_AppointmentsClear;
        }

        #endregion Constructor

        #region Events

        public event EventDefinition.GeneralCubeEventHandler SelectAppointment;

        public event EventDefinition.GeneralCubeEventHandler AddAppointment;

        public event EventDefinition.GeneralCubeEventHandler PasteAppointment;

        public event EventDefinition.GeneralCubeEventHandler EditAppointment;

        public event EventDefinition.GeneralCubeEventHandler DoubleClickAppointment;

        public event EventDefinition.GeneralCubeEventHandler RemovedAppointment;

        public event EventDefinition.GeneralCubeEventHandler TakePictureToAppointment;

        public event EventHandler DoubleClickEmptyTimeline;

        public event EventHandler DoubleClickAllDayEventSpace;

        public event EventHandler CurrentDateChanged;

        public event EventHandler DeselectAnyAppointment;

        public event EventHandler CancelEditAppointment;

        public event EventHandler WorkerExpanded;

        public event EventHandler MoveAppointment;

        public event EventHandler SelectedScopeChanged;

        public event CancelEventHandler BeforeRemoveAppointment;

        public event EventHandler<GeneralCubeEventArgs> DragDropCube;

        public event EventHandler SendSmsReminder;

        public event EventHandler AddAttendees;

        public event EventHandler ShowHistory;

        #endregion Events

        #region Private Members

        private readonly AppointmentsCollection _appointments = new AppointmentsCollection();
        private readonly CalendarWorkersCollection _workers = new CalendarWorkersCollection();
        private WorkerPanel _currentWorkerPanel;
        private double _pixelsForMin;

        //private int _expandedWorkerId;
        private DateTime _currentDate = DateTime.MinValue;

        private TimeSpan _daySpan = TimeSpan.Zero;
        private bool _inProc;
        private const int AppMinColSize = 75;

        internal EventCube SelectedCube;
        internal int AppHspace = 1;
        internal int AppSideSpace = 9;
        internal int AppMaxAlldayEvents = 2;
        internal string FromTime = "07:00";
        internal string ToTime = "22:00";
        internal Timer TmrPointer = new Timer();
        internal Font TimeLineFont = new Font("Arial", 10);
        internal SolidBrush TimeLineBrush = new SolidBrush(Color.FromArgb(158, 174, 195));

        internal Color ColorLineBorder = Color.FromArgb(101, 147, 207);
        internal Color ColorCursorColor = Color.FromArgb(41, 76, 122);
        internal Color ColorOrange = Color.FromArgb(238, 147, 17);
        internal Color ColorAllDayLostFocus = Color.FromArgb(165, 191, 225);
        internal Color ColorAllDayGotFocus = Color.FromArgb(91, 126, 172);

        private CalendarClipboard _clipboard;

        #endregion Private Members

        #region Public Properties

        internal string GetNewAppointmentId()
        {
            return Guid.NewGuid().ToString();
        }

        internal TimeSpan DaySpan
        {
            get
            {
                if (_daySpan == TimeSpan.Zero)
                {
                    _daySpan = GetEndDate().Subtract(GetStartDate());
                }
                return _daySpan;
            }
        }

        internal double PixelsForMin
        {
            get { return _pixelsForMin; }
            set { _pixelsForMin = value; }
        }

        public AppointmentsCollection Appointments
        {
            get { return _appointments; }
        }

        public CalendarWorkersCollection Workers
        {
            get { return _workers; }
        }

        public string StartTime
        {
            get { return FromTime; }
            set { FromTime = value; }
        }

        public string EndTime
        {
            get { return ToTime; }
            set { ToTime = value; }
        }

        public DateTime CurrentDate
        {
            get { return _currentDate; }
            set
            {
                if (_currentDate.Date != value.Date)
                {
                    _currentDate = value;
                    lblDayCaption.Text = _currentDate.ToString("dddd, d ·MMMM yyyy");
                    if (_currentDate.Date.Equals(DateTime.Now.Date))
                    {
                        lblDayCaption.ForeColor = Color.Maroon;
                        lblDayCaption.Text += @" (‰ÈÂÌ)";
                    }
                    else
                    {
                        lblDayCaption.ForeColor = Color.Black;
                    }
                    if (CurrentDateChanged != null) CurrentDateChanged(this, new EventArgs());
                    if (SelectedScopeChanged != null) SelectedScopeChanged(this, new EventArgs());
                    EventCube.StartTime = GetStartDate();
                }
            }
        }

        public Appointment SelectedAppointment
        {
            get
            {
                var ret = SelectedCube == null ? null : SelectedCube.Appointment;
                return ret;
            }
        }

        public int SelectedWorkerId
        {
            get
            {
                if (_currentWorkerPanel == null) return 0;
                if (_currentWorkerPanel.IsExpand) return _currentWorkerPanel.Id;
                switch (_currentWorkerPanel.LastFocusControl)
                {
                    case WorkerPanel.FocusControlType.None:
                        return 0;

                    case WorkerPanel.FocusControlType.AllDayPanel:
                    case WorkerPanel.FocusControlType.Cube:
                        return _currentWorkerPanel.Id;

                    case WorkerPanel.FocusControlType.TodayPanel:
                        if (GetSelectedScope() == null) return 0;
                        return _currentWorkerPanel.Id;

                    default:
                        return 0;
                }
            }
        }

        #endregion Public Properties

        #region Private Functions

        private void AcceptWorkerPanelChanges()
        {
            foreach (WorkerPanel wp in pnlWorkers.Controls)
            {
                wp.AcceptEditCubeChanges();
            }
        }

        private void ResizeWorkerPanels()
        {
            //if (pnlWorkers == null) return;
            var left = 1;
            var width = CInt((pnlWorkers.Width - 2) / _workers.Count);
            if (width < AppMinColSize) width = AppMinColSize;
            pnlWorkers.SuspendLayout();
            foreach (WorkerPanel wp in pnlWorkers.Controls)
            {
                wp.Width = width;
                wp.Height = pnlWorkers.Height - 1;
                wp.Top = 0;
                wp.Left = left;
                left += width;
            }
            var delta = width * _workers.Count - pnlWorkers.Width + 2;
            if (delta != 0 && width > AppMinColSize)
            {
                pnlWorkers.Controls[pnlWorkers.Controls.Count - 1].Width -= delta;
            }
            pnlWorkers.ResumeLayout(true);
        }

        private void CreateWorkerPanel(CalendarWorker worker)
        {
            var wp = new WorkerPanel();
            pnlWorkers.Controls.Add(wp);
            wp.Caption = worker.Name;
            wp.Id = worker.Id;
            wp.ReadOnly = worker.ReadOnly;
            wp.EnableExpand = worker.EnableExpand;
            wp.BorderColor = worker.ReadOnly ? WorkerPanel.PanelColor.Orange : WorkerPanel.PanelColor.Blue;
            wp.TabStop = false;
            wp.Enter += wp_Enter;
            wp.ExpandWorker += wp_ExpandWorker;
            wp.UnExpandWorker += wp_UnExpandWorker;
            wp.RemovedAppointment += wp_RemovedAppointment;
            wp.AddAppointment += wp_AddAppointment;
            wp.PasteAppointment += wp_PasteAppointment;
            wp.EditAppointment += Wp_EditAppointment;
            wp.SelectAppointment += wp_SelectAppointment;
            wp.DoubleClickAppointment += wp_DoubleClickAppointment;
            wp.DoubleClickAllDayEventSpace += wp_DoubleClickAllDayEventSpace;
            wp.DoubleClickEmptyTimeLine += wp_DoubleClickEmptyTimeLine;
            wp.DeselectAnyAppointment += wp_DeselectAnyAppointment;
            wp.CancelEditAppointment += wp_CancelEditAppointment;
            wp.MoveCursorToNextWorkerPanel += Wp_MoveCursorToNextWorkerPanel;
            wp.MoveCursorToPrevWorkerPanel += wp_MoveCursorToPrevWorkerPanel;
            wp.ShowContextMenu += Wp_ShowContextMenu;
            wp.MoveSelCurToNextWorkerPanel += Wp_MoveSelCurToNextWorkerPanel;
            wp.MoveSelCurToPrevWorkerPanel += Wp_MoveSelCurToPrevWorkerPanel;
            wp.SelectedScopeChanged += wp_SelectedScopeChanged;
            wp.AcceptChanges += wp_AcceptChanges;
            wp.DragDropCube += wp_DragDropCube;
            wp.BeforeRemovedAppointment += Wp_BeforeRemovedAppointment;

            return;
        }

        private void Wp_BeforeRemovedAppointment(object sender, CancelEventArgs e)
        {
            if (BeforeRemoveAppointment != null) BeforeRemoveAppointment(this, e);
        }

        private void wp_DragDropCube(object sender, GeneralCubeEventArgs e)
        {
            if (DragDropCube != null) DragDropCube(this, e);
        }

        private void wp_AcceptChanges(object sender, EventArgs e)
        {
            AcceptWorkerPanelChanges();
        }

        private void wp_SelectedScopeChanged(object sender, EventArgs e)
        {
            if (SelectedScopeChanged != null) SelectedScopeChanged(this, e);
        }

        private void HideWorker(int workerId)
        {
            foreach (ToolStripItem item in mnuMove.DropDownItems)
            {
                item.Visible = !(workerId.Equals(item.Tag));
            }
        }

        private void BindWorkers()
        {
            _currentWorkerPanel = null;
            pnlWorkers.Controls.Clear();
            mnuMove.DropDownItems.Clear();
            if (_workers.Count == 0) _workers.Add(new CalendarWorker(0, "ÏÏ‡ ÚÂ·„"));
            if (_workers.Count == 1) _workers[0].EnableExpand = false;

            foreach (CalendarWorker worker in _workers)
            {
                CreateWorkerPanel(worker);
                Image image = Properties.Resources.worker_tiny;
                if (worker.Id > 0)
                {
                    mnuMove.DropDownItems.Add(worker.Name, image, MnuWorker_Click);
                    mnuMove.DropDownItems[mnuMove.DropDownItems.Count - 1].Tag = worker.Id;
                }
            }
        }

        //private void RemoveAllEventCubes()
        //{
        //    foreach (WorkerPanel wp in pnlWorkers.Controls)
        //    {
        //        wp.RemoveAllEventCubes();
        //    }
        //}

        internal int CInt(double value)
        {
            value = Math.Ceiling(value);
            return Convert.ToInt32(value);
        }

        private void SpreadAppointments()
        {
            foreach (WorkerPanel wp in pnlWorkers.Controls)
            {
                for (var i = 0; i < _appointments.Count; i++)
                {
                    if (wp.Id.Equals(_appointments[i].WorkerId) || _appointments[i].WorkerId == -1)
                    {
                        wp.Appointments.Add(_appointments[i]);
                    }
                }
            }
        }

        private void BindAppointments()
        {
            foreach (WorkerPanel wp in pnlWorkers.Controls)
            {
                wp.BindAppointments();
            }

            RefreshAllPanels();
        }

        private WorkerPanel GetWorkerPanel(int workerId)
        {
            WorkerPanel worker = null;
            foreach (WorkerPanel wp in pnlWorkers.Controls)
            {
                if (wp.Id == workerId)
                {
                    worker = wp;
                    break;
                }
            }
            return worker;
        }

        private void ExpandWorker(WorkerPanel panel)
        {
            //_expandedWorkerId = panel.Id;
            pnlWorkers.SuspendLayout();
            WorkerPanel lastWp = null;

            if (_currentWorkerPanel != null)
            {
                _currentWorkerPanel.ClearAnySelected();
                if (SelectedScopeChanged != null) SelectedScopeChanged(this, new EventArgs());
                if (_currentWorkerPanel.IsExpand) lastWp = _currentWorkerPanel;
            }

            foreach (WorkerPanel wp in pnlWorkers.Controls)
            {
                wp.Visible = false;
            }

            _currentWorkerPanel = panel;
            _currentWorkerPanel.Visible = true;
            _currentWorkerPanel.OriginalBound = new Rectangle(_currentWorkerPanel.Location, _currentWorkerPanel.Size);
            _currentWorkerPanel.Width = pnlWorkers.Width;
            _currentWorkerPanel.Height = pnlWorkers.Height;
            _currentWorkerPanel.Location = new Point(0, 0);
            _currentWorkerPanel.IsExpand = true;
            if (!_currentWorkerPanel.ReadOnly) _currentWorkerPanel.BorderColor = WorkerPanel.PanelColor.Yellow;
            _currentWorkerPanel.RedrawPanel();
            if (lastWp != null) UnExpandWorkerPanel(lastWp);
            pnlWorkers.ResumeLayout(true);
            pnlHours.Refresh();

            if (WorkerExpanded != null) WorkerExpanded(_currentWorkerPanel.Id, new EventArgs());
        }

        private void UnExpandWorkerPanel(WorkerPanel wp)
        {
            wp.Size = wp.OriginalBound.Size;
            wp.Location = wp.OriginalBound.Location;
            wp.IsExpand = false;
            if (!wp.ReadOnly) wp.BorderColor = WorkerPanel.PanelColor.Blue;
            wp.RedrawPanel();

            if (WorkerExpanded != null) WorkerExpanded(null, new EventArgs());
        }

        private void MoveAppointmentToWorker(EventCube cube, int workerId)
        {
            var source = (WorkerPanel)(((EventCube)ctxMenu.Tag).Parent.Parent);
            var target = GetWorkerPanel(workerId);
            var id = cube.Appointment.Id;

            if (source != null && target != null)
            {
                var app = source.Appointments.FindAppointment(id);

                if (app != null)
                {
                    app.WorkerId = workerId;
                    target.Appointments.Add(app);
                    source.Appointments.Remove(app);
                    if (EditAppointment != null) EditAppointment(this, new GeneralCubeEventArgs(app, GeneralCubeEventArgs.EditModeMember.WorkerId));
                }

                source.ReBindAppointments();
                target.ReBindAppointments();
                source.RefreshPanel();
                target.RefreshPanel();
                if (!source.IsExpand) target.SetAppointmentActive(id);
                if (MoveAppointment != null) MoveAppointment(this, new EventArgs());
            }
        }

        #endregion Private Functions

        #region Public Methods

        public void SetCurrentCubeText(string text)
        {
            if (_currentWorkerPanel != null)
            {
                _currentWorkerPanel.SetCurrentCubeText(text);
            }
        }

        public void UnexpandCurrentWorker()
        {
            if (_currentWorkerPanel == null) return;
            if (_currentWorkerPanel.IsExpand == false) return;
            pnlWorkers.SuspendLayout();

            UnExpandWorkerPanel(_currentWorkerPanel);

            foreach (WorkerPanel wpl in pnlWorkers.Controls)
            {
                wpl.Visible = true;
            }

            pnlWorkers.ResumeLayout(true);
            pnlHours.Refresh();
        }

        public void ExpandWorker(int workerId)
        {
            var wp = GetWorkerPanel(workerId);

            if (wp != null && wp.EnableExpand)
            {
                wp.ClearAnySelected();
                ExpandWorker(wp);
            }
        }

        public void Initialize()
        {
            lblDayCaption.Text = _currentDate.ToString("dddd d ·MMMM yyyy");
            BindWorkers();
            ResizeWorkerPanels();
            RebindAppointments();
            RefreshAllPanels();
        }

        public void AttachClientToSelectedAppointment(int clientId, string clientName)
        {
            if (SelectedCube == null) return;

            SelectedAppointment.ClientId = clientId;
            SelectedAppointment.ClientName = clientName;

            SelectedCube.ClientName = clientName;
            SelectedCube.RefreshText();
        }

        public void AttachCaresToSelectedAppointment(string cares, string caresDescription)
        {
            if (SelectedCube == null) return;

            SelectedAppointment.Cares = cares;
            SelectedAppointment.CaresDescription = caresDescription;

            SelectedCube.CaresDescription = caresDescription;
            SelectedCube.RefreshText();
        }

        public void SetTextToSelectedAppointment(string text)
        {
            if (SelectedCube == null) return;

            //            Appointment app = _selectedCube.Appointment;

            SelectedAppointment.Text = text;
            SelectedCube.Text = text;
            SelectedCube.RefreshText();
        }

        public void ClearAnySelected()
        {
            foreach (WorkerPanel wp in pnlWorkers.Controls)
            {
                wp.ClearAnySelected();
            }
            if (SelectedScopeChanged != null) SelectedScopeChanged(this, new EventArgs());
        }

        public void HookKeyPress(object sender, KeyPressEventArgs e)
        {
            if (_currentWorkerPanel != null)
            {
                _currentWorkerPanel.HookKeyPress(sender, e);
                if (e.KeyChar == 27) if (SelectedScopeChanged != null) SelectedScopeChanged(this, new EventArgs());
            }
        }

        public void RebindAppointments()
        {
            _appointments.ClearLocationData();
            SpreadAppointments();
            BindAppointments();
            ClearAnySelected();
        }

        public void RefreshAllPanels()
        {
            foreach (WorkerPanel wp in pnlWorkers.Controls)
            {
                wp.RefreshPanel();
            }

            base.Refresh();
        }

        public void RedrawAllPanels()
        {
            foreach (WorkerPanel wp in pnlWorkers.Controls)
            {
                wp.RedrawPanel();
            }

            base.Refresh();
        }

        public void RefreshWorker(int workerId)
        {
            var wp = GetWorkerPanel(workerId);
            if (wp != null)
            {
                var app = SelectedAppointment;
                wp.ReBindAppointments();
                wp.RefreshPanel();
                if (app != null) SetAppointmentActive(app.Id);
            }
        }

        public void ReorderAppointments(int workerId)
        {
            var wp = GetWorkerPanel(workerId);
            if (wp != null)
            {
                wp.ReorderAppointments();
            }
        }

        public void ReorderAppointments()
        {
            _appointments.ReorderAppointments();
        }

        public bool IsSelectedScope()
        {
            if (_currentWorkerPanel != null)
            {
                return _currentWorkerPanel.IsSelectedScope();
            }
            return false;
        }

        public DateTime[] GetSelectedScope()
        {
            if (_currentWorkerPanel != null)
            {
                return _currentWorkerPanel.GetSelectedScope();
            }
            return null;
        }

        public void EditSelectedLines()
        {
            EditSelectedLines(string.Empty);
        }

        public void EditSelectedLines(string addEventText)
        {
            if (_currentWorkerPanel != null)
            {
                _currentWorkerPanel.EditSelectedLines(addEventText);
            }
        }

        public void EditSelectedAppointment()
        {
            if (_currentWorkerPanel != null)
            {
                _currentWorkerPanel.DoEditAppointment();
            }
        }

        public void RemoveSelectedAppointment()
        {
            if (SelectedCube == null) return;

            var app = SelectedCube.Appointment;
            _appointments.Remove(app);

            if (_currentWorkerPanel != null)
            {
                _currentWorkerPanel.Appointments.Remove(app);
                _currentWorkerPanel.ReBindAppointments();
                _currentWorkerPanel.RefreshPanel();
            }
            if (RemovedAppointment != null) RemovedAppointment(this, new GeneralCubeEventArgs(app));
        }

        public void LoadWorker(CalendarWorker worker)
        {
            if (_workers.Count == 0) return;
            if (_workers.Contains(worker.Id)) return;
            _workers.Add(worker);
            Image image = Properties.Resources.worker_tiny;
            if (worker.Id > 0)
            {
                mnuMove.DropDownItems.Add(worker.Name, image, MnuWorker_Click);
                mnuMove.DropDownItems[mnuMove.DropDownItems.Count - 1].Tag = worker.Id;
            }
            ResizeWorkerPanels();
        }

        public void UnloadWorker(int workerId)
        {
            var wp = GetWorkerPanel(workerId);
            _workers.Remove(workerId);
            if (wp == null) return;
            pnlWorkers.Controls.Remove(wp);
            _currentWorkerPanel = null;
            for (var i = 0; i < mnuMove.DropDownItems.Count; i++)
            {
                if (workerId.Equals(mnuMove.DropDownItems[i].Tag))
                {
                    mnuMove.DropDownItems.RemoveAt(i);
                    break;
                }
            }
            if (mnuMove.DropDownItems.Count == 0) mnuMove.Enabled = false;
            ResizeWorkerPanels();

            pnlWorkers.Controls[pnlWorkers.Controls.Count - 1].Select();
        }

        public DateTime GetStartDate()
        {
            return DateTime.Parse(_currentDate.ToShortDateString() + " " + FromTime);
        }

        public DateTime GetEndDate()
        {
            return DateTime.Parse(_currentDate.ToShortDateString() + " " + ToTime);
        }

        #endregion Public Methods

        #region Worker Panel Events

        private void Wp_EditAppointment(object sender, GeneralCubeEventArgs e)
        {
            _appointments.FindAppointment(e.Appointment.Id).Text = e.Appointment.Text;
            if (EditAppointment != null) EditAppointment(this, e);
        }

        private void wp_AddAppointment(object sender, GeneralCubeEventArgs e)
        {
            _appointments.Add(e.Appointment);
            if (AddAppointment != null) AddAppointment(this, e);
        }

        private void wp_PasteAppointment(object sender, GeneralCubeEventArgs e)
        {
            _appointments.Add(e.Appointment);
            if (PasteAppointment != null) PasteAppointment(this, e);
        }

        private void wp_RemovedAppointment(object sender, GeneralCubeEventArgs e)
        {
            _appointments.Remove(e.Appointment);
            if (RemovedAppointment != null) RemovedAppointment(this, e);
        }

        private void wp_Enter(object sender, EventArgs e)
        {
            if (_inProc) return;
            var wp = (WorkerPanel)sender;
            if (_currentWorkerPanel != null)
            {
                if (_currentWorkerPanel.Id == wp.Id) return;
                _currentWorkerPanel.ClearAnySelected();
            }
            _currentWorkerPanel = wp;
        }

        private void wp_CancelEditAppointment(object sender, EventArgs e)
        {
            if (CancelEditAppointment != null) CancelEditAppointment(this, e);
        }

        private void wp_DeselectAnyAppointment(object sender, EventArgs e)
        {
            if (DeselectAnyAppointment != null) DeselectAnyAppointment(this, e);
        }

        private void wp_DoubleClickEmptyTimeLine(object sender, EventArgs e)
        {
            if (DoubleClickEmptyTimeline != null) DoubleClickEmptyTimeline(this, e);
        }

        private void wp_DoubleClickAllDayEventSpace(object sender, EventArgs e)
        {
            if (DoubleClickAllDayEventSpace != null) DoubleClickAllDayEventSpace(this, e);
        }

        private void wp_DoubleClickAppointment(object sender, GeneralCubeEventArgs e)
        {
            if (DoubleClickAppointment != null) DoubleClickAppointment(this, e);
        }

        private void wp_SelectAppointment(object sender, GeneralCubeEventArgs e)
        {
            if (SelectAppointment != null) SelectAppointment(this, e);
        }

        private void wp_UnExpandWorker(object sender, EventArgs e)
        {
            UnexpandCurrentWorker();
        }

        private void wp_ExpandWorker(object sender, EventArgs e)
        {
            ExpandWorker(((WorkerPanel)sender));
        }

        private void wp_MoveCursorToPrevWorkerPanel(object sender, EventArgs e)
        {
            var loc = pnlWorkers.Controls.IndexOf((Control)sender);
            if (loc > 0)
            {
                var pos = ((WorkerPanel)sender).GetSelectedScopePos();
                if (pos != null)
                {
                    var wp = (WorkerPanel)pnlWorkers.Controls[loc - 1];
                    if (!wp.ReadOnly)
                    {
                        wp.PaintTimeLine(pos[0], 1);
                        wp.Select();
                    }
                }
            }
        }

        private void Wp_MoveCursorToNextWorkerPanel(object sender, EventArgs e)
        {
            var loc = pnlWorkers.Controls.IndexOf((Control)sender);
            if (loc < pnlWorkers.Controls.Count - 1)
            {
                var pos = ((WorkerPanel)sender).GetSelectedScopePos();
                if (pos != null)
                {
                    var wp = (WorkerPanel)pnlWorkers.Controls[loc + 1];
                    if (!wp.ReadOnly)
                    {
                        wp.PaintTimeLine(pos[0], 1);
                        wp.Select();
                    }
                }
            }
        }

        private void Wp_MoveSelCurToPrevWorkerPanel(object sender, EventArgs e)
        {
            short steps = 0;
            if (_appointments.Count <= 1) return;
            var pos = pnlWorkers.Controls.IndexOf((WorkerPanel)sender);

            WorkerPanel wp;
            do
            {
                if (pos <= 0) pos = pnlWorkers.Controls.Count;
                pos--;
                wp = (WorkerPanel)pnlWorkers.Controls[pos];
                if (steps > pnlWorkers.Controls.Count) break;
                steps++;
            } while (wp.Appointments.Count == 0);
            wp.SetAppointmentActive(wp.Appointments[0].Id);
            wp.Select();
        }

        private void Wp_MoveSelCurToNextWorkerPanel(object sender, EventArgs e)
        {
            short steps = 0;
            if (_appointments.Count <= 1) return;
            var pos = pnlWorkers.Controls.IndexOf((WorkerPanel)sender);

            WorkerPanel wp;
            do
            {
                if (pos >= pnlWorkers.Controls.Count - 1) pos = -1;
                pos++;
                wp = (WorkerPanel)pnlWorkers.Controls[pos];
                if (steps > pnlWorkers.Controls.Count) break;
                steps++;
            } while (wp.Appointments.Count == 0);
            var appPos = (e == null ? wp.Appointments.Count - 1 : 0);
            wp.SetAppointmentActive(wp.Appointments[appPos].Id);
            wp.Select();
        }

        private void Wp_ShowContextMenu(object sender, MouseEventArgs e)
        {
            mnuMove.Enabled = true;
            mnuPic.Enabled = false;
            ctxMenu.Tag = sender;
            var vis = (sender is EventCube);
            if (vis && ((EventCube)sender).Appointment.WorkerId == -1) return;
            var id = (vis ? ((EventCube)sender).Appointment.WorkerId : ((WorkerPanel)sender).Id);
            HideWorker(id);
            if (id != 0)
            {
                if (mnuMove.DropDownItems.Count <= 1) mnuMove.Enabled = false;
            }

            foreach (ToolStripItem item in ctxMenu.Items)
            {
                if (item.Tag == null)
                {
                    item.Visible = vis;
                }
                else
                {
                    item.Visible = !vis;
                }
            }
            mnuPaste.Enabled = _clipboard != null;
            mnuDiv2.Visible = true;
            mnuHistory.Visible = true;

            if (vis)
            {
                var app = ((EventCube)sender).Appointment;
                mnuSendSms.Enabled = (app.ClientId > 0);

                // hide or show the "take picture" menu
                if (app.ClientId > 0)
                {
                    if (DateTime.Now >= app.StartDate)
                    {
                        mnuPic.Enabled = true;
                    }
                }

                // select the current category
                foreach (ToolStripMenuItem item in mnuCategory.DropDownItems)
                {
                    item.Checked = (item.Tag.ToString() == app.RecurrenceId.ToString());
                }
            }

            ctxMenu.Show((Control)sender, e.X + 4, e.Y);
        }

        #endregion Worker Panel Events

        #region Control Events

        private void TmrPointer_Tick(object sender, EventArgs e)
        {
            try
            {
                pnlHours.Refresh();
            }
            catch { }
        }

        public void SetAppointmentActive(string id)
        {
            foreach (WorkerPanel wp in pnlWorkers.Controls)
            {
                if (wp.SetAppointmentActive(id)) break;
            }
        }

        private void PnlHours_Paint(object sender, PaintEventArgs e)
        {
            var penMain = new Pen(ColorLineBorder);
            Brush brushMain = new SolidBrush(ColorLineBorder);
            var from = Convert.ToInt32(FromTime.Substring(0, FromTime.IndexOf(":")));
            const int heightDelta = 41;
            var font = new Font("Tahoma", 12);
            var fontSmall = new Font("Arial", 8);

            var start = GetStartDate();
            if (DateTime.Now.Date == start.Date && DateTime.Now.TimeOfDay >= start.TimeOfDay)
            {
                var dt = DateTime.Parse(DateTime.Now.ToShortDateString() + " " + start.ToShortTimeString());
                var ts = DateTime.Now.Subtract(dt);
                var top = CInt(ts.TotalMinutes * _pixelsForMin) + heightDelta;
                var rec = new Rectangle(5, top - 9, pnlHours.Width - 5, 9);
                var cTo = Color.FromArgb(249, 204, 97);
                var cFrom = Color.FromArgb(230, 235, 238);
                var brush = new LinearGradientBrush(rec, cFrom, cTo, LinearGradientMode.Vertical);
                e.Graphics.FillRectangle(brush, rec);
                e.Graphics.DrawLine(new Pen(Color.FromArgb(187, 85, 3)), 5, top, pnlHours.Width, top);
            }

            for (var i = 0; i <= _daySpan.TotalMinutes; i += 60)
            {
                var margLeft = (i == 0 || i + 60 > _daySpan.TotalMinutes) ? 0 : 5;
                var hour = (from < 10) ? "0" + from : from.ToString();
                var pos = CInt(i * _pixelsForMin) + heightDelta;
                e.Graphics.DrawLine(penMain, margLeft, pos, pnlHours.Width - margLeft, pos);
                e.Graphics.DrawString(hour, font, brushMain, new PointF(5, pos + 3));
                e.Graphics.DrawString("00", fontSmall, brushMain, new PointF(26, pos + 2));
                from++;
            }
        }

        private void CalendarView_Enter(object sender, EventArgs e)
        {
            if (_currentWorkerPanel != null)
            {
                _inProc = true;
                _currentWorkerPanel.Select();
                _currentWorkerPanel.FocusArea();
                _inProc = false;
            }
        }

        #endregion Control Events

        private void Appointments_AppointmentsClear(object sender, EventArgs e)
        {
            foreach (WorkerPanel wp in pnlWorkers.Controls)
            {
                wp.Appointments.Clear();
            }
        }

        private void CalendarView_Paint(object sender, PaintEventArgs e)
        {
            var rec = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            e.Graphics.DrawRectangle(new Pen(ColorLineBorder), rec);
        }

        private void PnlWorkers_Paint(object sender, PaintEventArgs e)
        {
            var pen = new Pen(ColorLineBorder);
            e.Graphics.DrawLine(pen, 0, 0, 0, pnlWorkers.Height);
            e.Graphics.DrawLine(pen, pnlWorkers.Width - 1, 0, pnlWorkers.Width - 1, pnlWorkers.Height);
        }

        private void MnuEdit_Click(object sender, EventArgs e)
        {
            if (ctxMenu.Tag is EventCube)
            {
                var wp = (WorkerPanel)(((EventCube)ctxMenu.Tag).Parent.Parent);
                if (wp != null)
                {
                    var cube = (EventCube)ctxMenu.Tag;
                    if (cube.Appointment.WorkerId != -1)
                    {
                        wp.DoEditAppointment(cube);
                    }
                }
            }
        }

        private void MnuDelete_Click(object sender, EventArgs e)
        {
            if (ctxMenu.Tag is EventCube)
            {
                var wp = (WorkerPanel)(((EventCube)ctxMenu.Tag).Parent.Parent);
                if (wp != null)
                {
                    wp.DoDeleteCube((EventCube)ctxMenu.Tag);
                }
            }
        }

        private void MnuWorker_Click(object sender, EventArgs e)
        {
            if (ctxMenu.Tag is EventCube)
            {
                var cube = (EventCube)ctxMenu.Tag;
                var workerId = (int)((ToolStripItem)sender).Tag;
                MoveAppointmentToWorker(cube, workerId);
            }
        }

        private void LblDayCaption_MouseDown(object sender, MouseEventArgs e)
        {
            AcceptWorkerPanelChanges();
        }

        private void PnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            AcceptWorkerPanelChanges();
        }

        private void PnlHours_MouseDown(object sender, MouseEventArgs e)
        {
            AcceptWorkerPanelChanges();
        }

        private void MnuPic_Click(object sender, EventArgs e)
        {
            if (ctxMenu.Tag is EventCube)
            {
                TakePictureToAppointment?.Invoke(this, new GeneralCubeEventArgs(((EventCube)ctxMenu.Tag).Appointment));
            }
        }

        private void MnuCat_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(((ToolStripMenuItem)sender).Tag);

            if (ctxMenu.Tag is EventCube)
            {
                var cube = (EventCube)ctxMenu.Tag;
                cube.SetCategory(id);
                EditAppointment?.Invoke(this, new GeneralCubeEventArgs(cube.Appointment, GeneralCubeEventArgs.EditModeMember.Category));
            }
        }

        private void MnuUpdate_Click(object sender, EventArgs e)
        {
            if (ctxMenu.Tag is EventCube)
            {
                var cube = (EventCube)ctxMenu.Tag;
                EditAppointment?.Invoke(this, new GeneralCubeEventArgs(cube.Appointment, GeneralCubeEventArgs.EditModeMember.UpdateForm));
            }
        }

        private void MnuSendSms_Click(object sender, EventArgs e)
        {
            if (ctxMenu.Tag is EventCube)
            {
                SendSmsReminder?.Invoke(this, EventArgs.Empty);
            }
        }

        public void AcceptChanges()
        {
            AcceptWorkerPanelChanges();
        }

        private void MnuCopy_Click(object sender, EventArgs e)
        {
            if (ctxMenu.Tag is EventCube)
            {
                var wp = (WorkerPanel)(((EventCube)ctxMenu.Tag).Parent.Parent);
                if (wp != null)
                {
                    var app = ((EventCube)ctxMenu.Tag).Appointment;
                    _clipboard = new CalendarClipboard(app, CalendarClipboard.ClipboardAction.Copy);
                }
            }
        }

        private void MnuPaste_Click(object sender, EventArgs e)
        {
            if (ctxMenu.Tag is WorkerPanel)
            {
                var wp = ctxMenu.Tag as WorkerPanel;

                if (_clipboard != null)
                {
                    wp.DoPasteAppointment(_clipboard);
                    if (_clipboard.Action == CalendarClipboard.ClipboardAction.Cut)
                    {
                        if (_clipboard.Panel != null && _clipboard.Cube != null)
                        {
                            _clipboard.Panel.DoDeleteCube2(_clipboard.Cube);
                        }
                    }
                }
            }
        }

        private void Mnu_Cut_Click(object sender, EventArgs e)
        {
            if (ctxMenu.Tag is EventCube)
            {
                var wp = (WorkerPanel)(((EventCube)ctxMenu.Tag).Parent.Parent);
                if (wp != null)
                {
                    var cube = (EventCube)ctxMenu.Tag;
                    _clipboard = new CalendarClipboard(cube.Appointment, CalendarClipboard.ClipboardAction.Cut)
                    {
                        Cube = cube,
                        Panel = wp,
                    };
                }
            }
        }

        private void mnuAddAttedee_Click(object sender, EventArgs e)
        {
            if (ctxMenu.Tag is EventCube)
            {
                AddAttendees?.Invoke(this, EventArgs.Empty);
            }
        }

        private void mnuHistory_Click(object sender, EventArgs e)
        {
            ShowHistory?.Invoke(this, EventArgs.Empty);
        }
    }
}