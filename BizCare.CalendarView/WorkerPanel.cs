using BizCare.Calendar.Library;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BizCare.Calendar
{
    internal partial class WorkerPanel : UserControl
    {
        internal WorkerPanel()
        {
            InitializeComponent();
            _lastSelectedScope[0] = -1;
            _lastSelectedScope[1] = -1;
        }

        #region Events

        internal event EventHandler DeselectAnyAppointment;

        internal event EventHandler DoubleClickEmptyTimeLine;

        internal event EventHandler CancelEditAppointment;

        internal event EventHandler ExpandWorker;

        internal event EventHandler UnExpandWorker;

        internal event EventHandler MoveCursorToNextWorkerPanel;

        internal event EventHandler MoveCursorToPrevWorkerPanel;

        internal event EventDefinition.GeneralCubeEventHandler SelectAppointment;

        internal event EventDefinition.GeneralCubeEventHandler DoubleClickAppointment;

        internal event EventDefinition.GeneralCubeEventHandler RemovedAppointment;

        internal event EventDefinition.GeneralCubeEventHandler AddAppointment;

        internal event EventDefinition.GeneralCubeEventHandler PasteAppointment;

        internal event EventDefinition.GeneralCubeEventHandler EditAppointment;

        internal event EventHandler DoubleClickAllDayEventSpace;

        internal event EventHandler MoveSelCurToNextWorkerPanel;

        internal event EventHandler MoveSelCurToPrevWorkerPanel;

        internal event EventHandler SelectedScopeChanged;

        internal event EventHandler AcceptChanges;

        internal event MouseEventHandler ShowContextMenu;

        internal event CancelEventHandler BeforeRemovedAppointment;

        internal event EventHandler<GeneralCubeEventArgs> DragDropCube;

        #endregion Events

        #region Private Members

        // --------- Enum ---------
        internal enum FocusControlType { None, Cube, TodayPanel, AllDayPanel }

        internal enum PanelColor { Blue, Orange, Yellow }

        // --------- Members ---------
        private readonly AppointmentsCollection _appointments = new AppointmentsCollection();

        private EventCube _selectedCube;
        private EditEventCube _editEventCube;
        private FocusControlType _lastFocusCtrl = FocusControlType.None;
        private PanelColor _lighted = PanelColor.Blue;
        private readonly Color _bgColor = Color.White;
        private Rectangle _originalBound = Rectangle.Empty;
        private Label _lblDragOver;
        private int[] _timeLines;
        private readonly int[] _lastSelectedScope = new int[2];
        private bool[] _paintLines;
        private bool _isMouseDown;
        private bool _isAllDaySelected;
        private bool _readOnly;
        private bool _isExpand;
        private bool _enableExpand = true;
        private bool _inProc;
        private int _selectedTimeLine = -1;

        //private int _selectedTimeLineCount;
        private int _totalColumns;

        private int _id; // the worker id
        private double _pixelsForMin;
        private int _pixelsForWidth;
        private int _pixelsForAllDayEvent;
        private const int AlldayStripHeight = 18;

        // --------- Properties ---------
        private EventCube SelectedCube
        {
            get { return _selectedCube; }
            set
            {
                _selectedCube = value;
                _Parent.SelectedCube = value;
            }
        }

        private CalendarView _Parent
        {
            get { return (CalendarView)this.Parent.Parent; }
        }

        private Label LblDragOver
        {
            get
            {
                if (_lblDragOver == null)
                {
                    _lblDragOver = new Label
                    {
                        BackColor = Color.FromKnownColor(KnownColor.Info),
                        Font = new Font("Tahoma", 8),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Size = new Size(78, 16),
                        RightToLeft = RightToLeft.No,
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    this.Controls.Add(_lblDragOver);
                }
                return _lblDragOver;
            }
        }

        internal AppointmentsCollection Appointments
        {
            get { return _appointments; }
        }

        internal Rectangle OriginalBound
        {
            get { return _originalBound; }
            set { _originalBound = value; }
        }

        internal int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        internal string Caption
        {
            get { return lblDayCaption2.Text; }
            set { lblDayCaption2.Text = value; }
        }

        internal PanelColor BorderColor
        {
            get { return _lighted; }
            set
            {
                _lighted = value;
                switch (_lighted)
                {
                    case PanelColor.Blue:
                        pnlDayTitle.BackgroundImage = Properties.Resources.cal_worker_bg;
                        this.BackColor = Color.FromArgb(93, 140, 201);
                        this.Padding = new Padding(1);
                        break;

                    case PanelColor.Orange:
                        pnlDayTitle.BackgroundImage = Properties.Resources.cal_worker_bg_ex;
                        this.BackColor = _Parent.ColorOrange;
                        this.Padding = new Padding(2, 1, 2, 2);
                        break;

                    case PanelColor.Yellow:
                        pnlDayTitle.BackgroundImage = Properties.Resources.cal_worker_bg_sn;
                        this.BackColor = Color.FromArgb(223, 210, 26);
                        this.Padding = new Padding(2, 1, 2, 2);
                        break;
                }
            }
        }

        internal bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                pnlTodayEvents.BackColor = _readOnly ? Color.Snow : Color.White;
            }
        }

        internal bool IsExpand
        {
            get { return _isExpand; }
            set { _isExpand = value; }
        }

        internal bool EnableExpand
        {
            get { return _enableExpand; }
            set { _enableExpand = value; }
        }

        internal FocusControlType LastFocusControl
        {
            get { return _lastFocusCtrl; }
        }

        #endregion Private Members

        #region Private Functions

        private void CalculatePixels()
        {
            if (_Parent.DaySpan.TotalMinutes == 0) return;

            var total = _appointments.GetAllDayEventsCount();
            _pixelsForAllDayEvent = total == 0 ? 0 : _Parent.CInt((this.Width - _Parent.AppSideSpace) / total);

            if (_totalColumns == 0) return;
            _pixelsForMin = (pnlTodayEvents.Height - 2) / _Parent.DaySpan.TotalMinutes;
            EventCube.DragMinutePixels = _pixelsForMin;
            _Parent.PixelsForMin = _pixelsForMin;
            _pixelsForWidth = _Parent.CInt((this.Width - _Parent.AppSideSpace) / _totalColumns);
            try
            {
                _Parent.TmrPointer.Interval = Convert.ToInt32(60000 / _pixelsForMin);
                _Parent.TmrPointer.Enabled = true;
            }
            catch
            {
                _Parent.TmrPointer.Enabled = false;
            }
        }

        private EventCube GetCubeById(string id)
        {
            EventCube ret = null;

            foreach (Control c in pnlTodayEvents.Controls)
            {
                if (c is EventCube)
                {
                    if (((EventCube)c).Appointment.Id == id)
                    {
                        ret = (EventCube)c;
                        break;
                    }
                }
            }
            if (ret == null)
            {
                foreach (Control c in pnlAllDayEvents.Controls)
                {
                    if (c is EventCube)
                    {
                        if (((EventCube)c).Appointment.Id == id)
                        {
                            ret = (EventCube)c;
                            break;
                        }
                    }
                }
            }
            return ret;
        }

        internal void PaintTimeLine(int timeLine, short displayTimeMode)
        {
            PaintTimeLine(pnlTodayEvents.CreateGraphics(), timeLine, displayTimeMode);
        }

        private void PaintTimeLine(Graphics g, int timeLine)
        {
            PaintTimeLine(g, timeLine, 0);
        }

        private void PaintTimeLine(Graphics g, int timeLine, short displayTimeMode)
        {
            if (timeLine >= 0)
            {
                // paint the line rectangle
                Brush brush = new SolidBrush(_Parent.ColorCursorColor);
                if (_timeLines == null) InitTimeLines();
                var top = _timeLines[timeLine] + 1;
                var height = _timeLines[timeLine + 1] - _timeLines[timeLine] - 1;
                g.FillRectangle(brush, new Rectangle(0, top, pnlTodayEvents.Width, height));
                _paintLines[timeLine] = true;

                string start;
                SizeF size;

                // print the time
                switch (displayTimeMode)
                {
                    case 1:
                        start = _Parent.GetStartDate().AddMinutes(timeLine * 30).ToShortTimeString();
                        size = g.MeasureString(start, _Parent.TimeLineFont);
                        g.DrawString(start, _Parent.TimeLineFont, _Parent.TimeLineBrush, (pnlTodayEvents.Width - size.Width) / 2, top + ((height - size.Height) / 2));
                        break;

                    case 2:
                        start = _Parent.GetStartDate().AddMinutes((timeLine + 1) * 30).ToShortTimeString();
                        size = g.MeasureString(start, _Parent.TimeLineFont);
                        g.DrawString(start, _Parent.TimeLineFont, _Parent.TimeLineBrush, (pnlTodayEvents.Width - size.Width) / 2, top + ((height - size.Height) / 2));
                        break;

                    default:
                        break;
                }
            }
        }

        private void ClearTimeLine(Graphics g, int timeLine)
        {
            if (_timeLines == null) InitTimeLines();
            if (timeLine >= 0 && timeLine + 1 < _timeLines.Length)
            {
                Brush brush = new SolidBrush(_bgColor);
                int top, height;
                top = _timeLines[timeLine] + 1;
                height = _timeLines[timeLine + 1] - _timeLines[timeLine] - 1;
                g.FillRectangle(brush, new Rectangle(0, top, pnlTodayEvents.Width, height));
                _paintLines[timeLine] = false;
            }
        }

        private void ClearSelected()
        {
            ClearSelected(pnlTodayEvents.CreateGraphics(), -1);
        }

        private void ClearSelected(Graphics g, int current)
        {
            if (_timeLines == null) InitTimeLines();
            for (var i = 0; i < _timeLines.Length; i++)
            {
                if (i != current)
                {
                    if (_paintLines[i])
                    {
                        ClearTimeLine(g, i);
                    }
                }
            }
            _lastSelectedScope[0] = -1;
            _lastSelectedScope[1] = -1;
        }

        internal void FocusArea()
        {
            switch (_lastFocusCtrl)
            {
                case FocusControlType.None:
                    break;

                case FocusControlType.Cube:
                    //pnlTodayEvents.Select();
                    if (_selectedCube != null) _selectedCube.Select();
                    break;

                case FocusControlType.TodayPanel:
                    pnlTodayEvents.Select();
                    break;

                case FocusControlType.AllDayPanel:
                    pnlAllDayEvents.Select();
                    break;

                default:
                    break;
            }
        }

        private void SetFocusControl(FocusControlType type)
        {
            SetFocusControl(type, null);
        }

        private void PaintScope(Graphics g, int fromLine, int toLine)
        {
            if (_lastSelectedScope[0] == fromLine && _lastSelectedScope[1] == toLine) return;
            _lastSelectedScope[0] = fromLine;
            _lastSelectedScope[1] = toLine;

            short status = 0;
            for (var i = 0; i < _paintLines.Length; i++)
            {
                if (i >= fromLine && i <= toLine)
                {
                    if (i == fromLine) status = 1; else if (i == toLine) status = 2; else status = 0;
                    PaintTimeLine(g, i, status);
                }
                else
                {
                    if (_paintLines[i]) ClearTimeLine(g, i);
                }
            }
            if (SelectedScopeChanged != null) SelectedScopeChanged(this, new EventArgs());
        }

        private void SetFocusControl(FocusControlType type, EventCube cube)
        {
            ClearSelected(); // clear panel today events
            if (SelectedCube != null) SelectedCube.DeselectCube(); // clear selected cube
            pnlAllDayEvents.BackColor = _Parent.ColorAllDayLostFocus; // clear panel all day event
            SelectedCube = null;
            _isAllDaySelected = false;

            switch (type)
            {
                case FocusControlType.None:
                    if (DeselectAnyAppointment != null) DeselectAnyAppointment(this, new EventArgs());
                    //if (SelectedScopeChanged != null) SelectedScopeChanged(this, new EventArgs());
                    _lastFocusCtrl = FocusControlType.None;
                    break;

                case FocusControlType.TodayPanel:
                    if (DeselectAnyAppointment != null) DeselectAnyAppointment(this, new EventArgs());
                    _lastFocusCtrl = FocusControlType.TodayPanel;
                    break;

                case FocusControlType.Cube:
                    cube.SelectCube();
                    SelectedCube = cube;
                    _lastFocusCtrl = FocusControlType.Cube;
                    try
                    {
                        if (cube.Parent.Equals(pnlAllDayEvents)) pnlAllDayEvents.BackColor = _Parent.ColorAllDayGotFocus;
                    }
                    catch { }
                    break;

                case FocusControlType.AllDayPanel:
                    pnlAllDayEvents.BackColor = _Parent.ColorAllDayGotFocus;
                    _isAllDaySelected = true;
                    _lastFocusCtrl = FocusControlType.AllDayPanel;
                    if (DeselectAnyAppointment != null) DeselectAnyAppointment(this, new EventArgs());
                    if (SelectedScopeChanged != null) SelectedScopeChanged(this, new EventArgs());
                    break;
            }
        }

        private int GetSelectedLine(int y)
        {
            var selected = -1;
            if (_timeLines == null) return -1;
            for (var i = 0; i < _timeLines.Length; i++)
            {
                if (_timeLines[i] > y)
                {
                    selected = i - 1;
                    break;
                }
            }
            return selected;
        }

        internal int[] GetSelectedScopePos()
        {
            int start = -1, end = -1;
            for (var i = 0; i < _paintLines.Length; i++)
            {
                if (_paintLines[i])
                {
                    if (start == -1) { start = i; end = i; }
                    else { end = i; }
                }
                else { if (end != -1) break; }
            }

            if (start == -1) return null;
            var ret = new int[] { start, end };
            return ret;
        }

        private void InitializeEditCube()
        {
            _editEventCube = new EditEventCube(_id);
            _editEventCube.EditCubeDone += new EventDefinition.EditCubeDoneHandler(_editEventCube_EditCubeDone);
        }

        private void InitTimeLines()
        {
            _timeLines = new int[_Parent.CInt(_Parent.DaySpan.TotalMinutes / 30) + 1];
            _paintLines = new bool[_timeLines.Length];
        }

        internal void DoEditAppointment()
        {
            DoEditAppointment(_selectedCube);
        }

        internal void DoEditAppointment(EventCube cube)
        {
            if (_readOnly) return;
            if (_editEventCube != null) return;
            if (cube == null || cube.Appointment == null) return;

            InitializeEditCube();
            _editEventCube.Mode = EditEventCube.CubeMode.Edit;
            _editEventCube.SourceCube = cube;
            _editEventCube.IsAllDayEventCube = cube.Appointment.IsAllDayEvent;

            if (_editEventCube.IsAllDayEventCube)
            {
                _editEventCube.Left = cube.Left - 1;
                _editEventCube.Width = cube.Width + 2;
                _editEventCube.Height = AlldayStripHeight + 3;
                _editEventCube.Top = pnlAllDayEvents.Top;
                _editEventCube.EventText = cube.Text;
                _editEventCube.Scope = new DateTime[] { cube.Appointment.StartDate, cube.Appointment.EndDate };
                _editEventCube.Visible = true;
                this.Controls.Add(_editEventCube);
            }
            else
            {
                _editEventCube.Left = cube.Left - 5;
                _editEventCube.Width = cube.Width + 10;
                if (_editEventCube.Width > pnlTodayEvents.Width + 1) _editEventCube.Width = pnlTodayEvents.Width + 1;
                if (_editEventCube.Left < -1) _editEventCube.Left = -1;
                _editEventCube.Height = cube.Height + 10;
                _editEventCube.Top = cube.Top - 5;
                _editEventCube.EventText = cube.Text;
                _editEventCube.Scope = new DateTime[] { cube.Appointment.StartDate, cube.Appointment.EndDate };
                _editEventCube.Visible = true;
                pnlTodayEvents.Controls.Add(_editEventCube);
            }
            _editEventCube.BringToFront();
            _editEventCube.Select();
        }

        #endregion Private Functions

        #region Internal Functions

        internal void ReorderAppointments()
        {
            _appointments.ReorderAppointments();
        }

        internal void AcceptEditCubeChanges()
        {
            if (_editEventCube != null) _editEventCube.AcceptChanges();
        }

        internal void SetCurrentCubeText(string text)
        {
            if (_selectedCube != null)
            {
                _selectedCube.Text = text;
            }
        }

        internal void RedrawPanel()
        {
            CalculatePixels();
            //EventCube cube;
            var cnt = 0;
            TimeSpan ts;
            Appointment ap;

            foreach (Control aCube in pnlAllDayEvents.Controls)
            {
                #region Redraw All Day Cube

                if (aCube is EventCube)
                {
                    aCube.Height = AlldayStripHeight;
                    aCube.Width = _pixelsForAllDayEvent - _Parent.AppHspace;
                    aCube.Top = 1;
                    aCube.Left = _pixelsForAllDayEvent * cnt + _Parent.AppHspace;
                    cnt++;
                }

                #endregion Redraw All Day Cube
            }

            foreach (Control tCube in pnlTodayEvents.Controls)
            {
                #region Redraw Regular Cube

                if (tCube is EventCube)
                {
                    ap = ((EventCube)tCube).Appointment;
                    ts = ap.StartDate.Subtract(_Parent.GetStartDate());
                    var topPos = _Parent.CInt((ts.TotalMinutes * _pixelsForMin));

                    tCube.Width = (_pixelsForWidth * ap.WidthUnit) - _Parent.AppHspace;
                    tCube.Left = (_pixelsForWidth * (ap.VerticalOrder - 1)) + _Parent.AppHspace;
                    tCube.Height = _Parent.CInt(_pixelsForMin * ap.Duration.TotalMinutes);
                    tCube.Top = topPos;
                }

                #endregion Redraw Regular Cube
            }

            base.Refresh();
        }

        internal void RefreshPanel()
        {
            TTip.RemoveAll();
            TTip.Active = true;
            RemoveAllEventCubes();
            CalculatePixels();

            EventCube cube;
            var cnt = 0;

            TimeSpan ts;

            foreach (Appointment ap in _appointments)
            {
                if (ap.IsOccurInDate(_Parent.CurrentDate))
                {
                    cube = new EventCube(ap);

                    if (ap.VerticalOrder == -1)
                    {
                        #region Create All Day Cube

                        cube.Height = AlldayStripHeight;
                        cube.Width = _pixelsForAllDayEvent - _Parent.AppHspace;
                        cube.Top = 1;
                        cube.Left = _pixelsForAllDayEvent * cnt + _Parent.AppHspace;
                        cube.Text = ap.Text;
                        cube.ClientName = ap.ClientName;
                        cube.CaresDescription = ap.CaresDescription;
                        pnlAllDayEvents.Controls.Add(cube);
                        cube.Visible = true;
                        cube.TabStop = false;
                        cnt++;

                        #endregion Create All Day Cube
                    }
                    else
                    {
                        #region Create Regular Cube

                        ts = ap.StartDate.Subtract(_Parent.GetStartDate());
                        var topPos = _Parent.CInt((ts.TotalMinutes * _pixelsForMin));

                        cube.ClientName = ap.ClientName;
                        cube.CaresDescription = ap.CaresDescription;
                        cube.Width = (_pixelsForWidth * ap.WidthUnit) - _Parent.AppHspace;
                        cube.Left = (_pixelsForWidth * (ap.VerticalOrder - 1)) + _Parent.AppHspace;
                        cube.Height = _Parent.CInt(_pixelsForMin * ap.Duration.TotalMinutes);
                        cube.Top = topPos;
                        cube.Text = ap.Text;
                        cube.Visible = true;
                        cube.TabStop = false;
                        pnlTodayEvents.Controls.Add(cube);

                        cube.DragDropCube += cube_DragDropCube;
                        cube.DragOverCube += cube_DragOverCube;

                        #endregion Create Regular Cube
                    }

                    if (SelectedCube != null && SelectedCube.Appointment.Id == ap.Id)
                    {
                        SetFocusControl(FocusControlType.Cube, cube);
                    }

                    var tooltip = ap.ToolTipScope;
                    if (tooltip.Length > 0) tooltip += " " + cube.VisibleText;
                    TTip.SetToolTip(cube.lblText, tooltip);
                    cube.EditCube += cube_EditCube;
                    cube.CubeMouseDown += cube_CubeMouseDown;
                    cube.CubeMouseDoubleClick += cube_CubeMouseDoubleClick;
                    cube.CubeDeleted += cube_EventCubeDeleted;
                    cube.CubeDeselected += cube_CubeDeselected;
                    cube.CubeTabbedNext += cube_CubeTabbedNext;
                    cube.CubeTabbedPrev += cube_CubeTabbedPrev;
                    cube.ShowContextMenu += cube_ShowContextMenu;
                    cube.MoveSelCurToNextWorkerPanel += cube_MoveSelCurToNextWorkerPanel;
                    cube.MoveSelCurToPrevWorkerPanel += cube_MoveSelCurToPrevWorkerPanel;
                    cube.VisibleTextChanged += cube_VisibleTextChanged;
                }
            }
            base.Refresh();
        }

        private void cube_DragOverCube(object sender, DragOverCubeEventArgs e)
        {
            var cube = (EventCube)sender;
            if (cube != null)
            {
                LblDragOver.Text = e.DragText;
                LblDragOver.Top = pnlTodayEvents.Top + cube.Top - LblDragOver.Height + 1;
                LblDragOver.Left = cube.Right - LblDragOver.Width + 1;
                LblDragOver.BringToFront();
                LblDragOver.Visible = true;
            }
        }

        private void cube_DragDropCube(object sender, GeneralCubeEventArgs e)
        {
            if (_lblDragOver != null)
            {
                this.Controls.Remove(_lblDragOver);
                _lblDragOver.Hide();
                Application.DoEvents();
                _lblDragOver = null;
            }

            if (e != null)
            {
                _appointments.ReorderAppointments();
                if (DragDropCube != null) DragDropCube(null, e);
            }
        }

        private void cube_VisibleTextChanged(object sender, EventArgs e)
        {
            var cube = (EventCube)sender;
            if (cube == null || cube.Appointment == null) return;

            var tooltip = cube.Appointment.ToolTipScope;
            if (tooltip.Length > 0) tooltip += " " + cube.VisibleText;
            TTip.SetToolTip(cube.lblText, tooltip);
        }

        private void cube_MoveSelCurToPrevWorkerPanel(object sender, EventArgs e)
        {
            if (!_isExpand)
            {
                if (MoveSelCurToPrevWorkerPanel != null) MoveSelCurToPrevWorkerPanel(this, new EventArgs());
            }
        }

        private void cube_MoveSelCurToNextWorkerPanel(object sender, EventArgs e)
        {
            if (!_isExpand)
            {
                if (MoveSelCurToNextWorkerPanel != null) MoveSelCurToNextWorkerPanel(this, e);
            }
        }

        internal void LoadAppointments(AppointmentsCollection appointments)
        {
            _appointments.Clear();
            foreach (Appointment app in appointments)
            {
                _appointments.Add(app);
            }
        }

        internal void BindAppointments()
        {
            _totalColumns = _appointments.SetVerticalOrder();
            _appointments.SetWidthUnit(_totalColumns);
        }

        internal void EditSelectedLines(string addEventText)
        {
            if (_readOnly) return;
            if (_editEventCube != null) return;
            if (_isAllDaySelected && pnlAllDayEvents.Controls.Count >= _Parent.AppMaxAlldayEvents) return;

            if (_isAllDaySelected)
            {
                InitializeEditCube();
                if (_editEventCube != null)
                {
                    _editEventCube.Left = 0;
                    _editEventCube.Height = AlldayStripHeight + 3;
                    _editEventCube.Width = pnlTodayEvents.Width + 2;
                    _editEventCube.Top = pnlAllDayEvents.Top;
                    _editEventCube.EventText = addEventText;
                    _editEventCube.Scope = new[] { _Parent.CurrentDate.Date, _Parent.CurrentDate.Date };
                    _editEventCube.IsAllDayEventCube = true;
                    this.Controls.Add(_editEventCube);
                }
            }
            else
            {
                var pos = GetSelectedScopePos();
                if (pos == null) return;

                InitializeEditCube();
                if (_editEventCube != null)
                {
                    _editEventCube.Left = -1;
                    _editEventCube.Height = _Parent.CInt((pos[1] - pos[0] + 1) * 30 * _pixelsForMin) + 10;
                    _editEventCube.Width = pnlTodayEvents.Width + 1;
                    _editEventCube.Top = _Parent.CInt(pos[0] * 30 * _pixelsForMin) - 5;
                    _editEventCube.EventText = addEventText;
                    _editEventCube.Scope = GetSelectedScope();
                    pnlTodayEvents.Controls.Add(_editEventCube);
                }
            }

            if (_editEventCube != null)
            {
                _editEventCube.BringToFront();
                _editEventCube.FocusTextBox();
            }
        }

        internal void ReBindAppointments()
        {
            _appointments.ClearLocationData();
            BindAppointments();
            ClearAnySelected();
        }

        internal void RemoveAllEventCubes()
        {
            pnlTodayEvents.Controls.Clear();
            pnlAllDayEvents.Controls.Clear();
            if (_editEventCube != null) pnlTodayEvents.Controls.Add(_editEventCube);
        }

        internal bool IsSelectedScope()
        {
            int start = -1, end = -1;
            for (var i = 0; i < _paintLines.Length; i++)
            {
                if (_paintLines[i])
                {
                    if (start == -1) { start = i; end = i; }
                    else { end = i; }
                }
                else { if (end != -1) break; }
            }

            return start >= 0;
        }

        internal DateTime[] GetSelectedScope()
        {
            int start = -1, end = -1;
            for (var i = 0; i < _paintLines.Length; i++)
            {
                if (_paintLines[i])
                {
                    if (start == -1) { start = i; end = i; }
                    else { end = i; }
                }
                else { if (end != -1) break; }
            }

            if (start == -1) return null;
            end++;
            var strRefStart = _Parent.CurrentDate.ToShortDateString() + " " + _Parent.FromTime;
            var dateStart = DateTime.Parse(strRefStart).AddMinutes(start * 30);
            var dateEnd = DateTime.Parse(strRefStart).AddMinutes(end * 30);

            var ret = new[] { dateStart, dateEnd };
            return ret;
        }

        internal void ClearAnySelected()
        {
            SetFocusControl(FocusControlType.None);
        }

        internal void HookKeyPress(object sender, KeyPressEventArgs e)
        {
            //if (char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == '\r' || char.IsPunctuation(e.KeyChar))
            //{
            //    EditSelectedLines(e.KeyChar.ToString());
            //}

            if (e.KeyChar == '\r')
            {
                EditSelectedLines(e.KeyChar.ToString());
            }

            if (e.KeyChar == 27 && _editEventCube == null)
            {
                if (GetSelectedScopePos() != null)
                {
                    SetFocusControl(FocusControlType.None);
                }
            }
        }

        internal bool SetAppointmentActive(string id)
        {
            foreach (Control cube in pnlTodayEvents.Controls)
            {
                if (cube is EventCube)
                {
                    if (((EventCube)cube).Appointment.Id == id)
                    {
                        ((EventCube)cube).SelectCube(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                        return true;
                    }
                }
            }
            foreach (Control cube in pnlAllDayEvents.Controls)
            {
                if (cube is EventCube)
                {
                    if (((EventCube)cube).Appointment.Id == id)
                    {
                        ((EventCube)cube).SelectCube(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion Internal Functions

        #region pnlTodayEvents Events

        private void pnlTodayEvents_Paint(object sender, PaintEventArgs e)
        {
            if (_Parent == null) return;

            // the dark blue line
            var penMain = new Pen(Color.FromArgb(165, 191, 225));

            // the light blue line
            var penSub = new Pen(Color.FromArgb(230, 237, 247));
            var penCur = penMain;

            // do calculations
            if (_Parent.DaySpan == TimeSpan.Zero) CalculatePixels();
            if (_timeLines == null) InitTimeLines();

            // draw lines
            for (var i = 30; i <= _Parent.DaySpan.TotalMinutes; i += 30)
            {
                penCur = penCur.Equals(penMain) ? penSub : penMain;
                var pos = _Parent.CInt(i * _pixelsForMin);
                e.Graphics.DrawLine(penCur, 0, pos, pnlTodayEvents.Width, pos);
            }

            // repaint the selected time lines
            if (!_readOnly)
            {
                short from = -1, to = -1;
                for (short i = 0; i < _timeLines.Length; i++)
                {
                    if (_paintLines[i])
                    {
                        if (from == -1) from = i;
                        else to = i;
                        PaintTimeLine(e.Graphics, i);
                    }
                }
                if (from != -1) PaintTimeLine(e.Graphics, from, 1);
                if (to != -1) PaintTimeLine(e.Graphics, to, 2);
            }
        }

        private void pnlTodayEvents_MouseDown(object sender, MouseEventArgs e)
        {
            if (_readOnly) return;
            this.Select();
            SetFocusControl(FocusControlType.TodayPanel);

            _isMouseDown = true;
            var selected = GetSelectedLine(e.Y);
            if (selected < 0) return;

            var g = pnlTodayEvents.CreateGraphics();
            ClearSelected(g, selected);

            //_selectedTimeLineCount = 1;
            _selectedTimeLine = selected;
            PaintTimeLine(g, selected, 1);
            if (SelectedScopeChanged != null) SelectedScopeChanged(this, new EventArgs());
            pnlTodayEvents.Select();

            if (e.Button != MouseButtons.Left)
                if (ShowContextMenu != null) ShowContextMenu(this, e);
        }

        private void pnlTodayEvents_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDown = false;
        }

        private void pnlTodayEvents_MouseMove(object sender, MouseEventArgs e)
        {
            if (_readOnly) return;
            if (_isMouseDown)
            {
                var selected = GetSelectedLine(e.Y);
                if (selected < 0) return;

                var g = pnlTodayEvents.CreateGraphics();
                var dist = selected - _selectedTimeLine;

                // Drag down related to start point
                if (dist >= 0)
                {
                    PaintScope(g, _selectedTimeLine, selected);
                }
                else
                {
                    PaintScope(g, selected, _selectedTimeLine);
                }
            }
        }

        // DoubleClick //
        private void pnlTodayEvents_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_readOnly) return;
            if (DoubleClickEmptyTimeLine != null) DoubleClickEmptyTimeLine(this, new EventArgs());
        }

        #endregion pnlTodayEvents Events

        #region pnlAllDayEvents Events

        private void pnlAllDayEvents_Paint(object sender, PaintEventArgs e)
        {
            if (_Parent == null) return;
            var color = _Parent.ColorLineBorder;
            switch (_lighted)
            {
                case PanelColor.Blue:
                    color = _Parent.ColorLineBorder;
                    break;

                case PanelColor.Orange:
                    color = _Parent.ColorOrange;
                    break;

                case PanelColor.Yellow:
                    color = Color.FromArgb(223, 210, 26);
                    break;
            }
            var pen = new Pen(color) { Width = 2 };
            e.Graphics.DrawLine(pen, 0, pnlAllDayEvents.Height - 1, pnlAllDayEvents.Width, pnlAllDayEvents.Height - 1);
        }

        private void pnlAllDayEvents_MouseDown(object sender, MouseEventArgs e)
        {
            if (_readOnly) return;
            this.Select();
            SetFocusControl(FocusControlType.AllDayPanel);
        }

        private void pnlAllDayEvents_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_readOnly) return;
            if (DoubleClickAllDayEventSpace != null) DoubleClickAllDayEventSpace(this, new EventArgs());
        }

        #endregion pnlAllDayEvents Events

        #region Cube Events

        private void cube_ShowContextMenu(object sender, MouseEventArgs e)
        {
            if (ShowContextMenu != null) ShowContextMenu(sender, e);
        }

        private void cube_CubeTabbedPrev(object sender, EventArgs e)
        {
            var pos = _appointments.IndexOf(((EventCube)sender).Appointment);
            if (pos <= 0)
            {
                //pos = _appointments.Count;
                e = null;
                cube_MoveSelCurToNextWorkerPanel(sender, e);
            }
            else
            {
                cube_CubeMouseDown(GetCubeById(_appointments[pos - 1].Id), null);
            }
        }

        private void cube_CubeTabbedNext(object sender, EventArgs e)
        {
            var pos = _appointments.IndexOf(((EventCube)sender).Appointment);
            if (pos >= _appointments.Count - 1)
            {
                //pos = -1;
                cube_MoveSelCurToPrevWorkerPanel(sender, e);
            }
            else
            {
                cube_CubeMouseDown(GetCubeById(_appointments[pos + 1].Id), null);
            }
        }

        private void cube_CubeMouseDown(object sender, MouseEventArgs e)
        {
            var c = (EventCube)sender;
            var app = c.Appointment;

            SetFocusControl(FocusControlType.Cube, c);

            if (app == null) return;
            if (SelectAppointment != null)
                SelectAppointment(this, new GeneralCubeEventArgs(app));

            SelectedCube = c;
        }

        private void cube_CubeDeselected(object sender, EventArgs e)
        {
            SetFocusControl(FocusControlType.None);
        }

        private void cube_CubeMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (DoubleClickAppointment != null)
            {
                var c = (EventCube)sender;
                DoubleClickAppointment(this, new GeneralCubeEventArgs(c.Appointment));
            }
        }

        private void cube_EventCubeDeleted(object sender, EventArgs e)
        {
            DoDeleteCube((EventCube)sender);
        }

        internal void DoDeleteCube(EventCube cube)
        {
            var args = new CancelEventArgs();
            if (BeforeRemovedAppointment != null) BeforeRemovedAppointment(this, args);
            if (args.Cancel) return;

            var app = cube.Appointment;
            _appointments.Remove(app);
            if (RemovedAppointment != null) RemovedAppointment(this, new GeneralCubeEventArgs(app));
            if (this.Parent != null)
            {
                ReBindAppointments();
                RefreshPanel();
            }
        }

        internal void DoDeleteCube2(EventCube cube)
        {
            var app = cube.Appointment;

            var exist = _appointments.Remove(app);
            if (RemovedAppointment != null) RemovedAppointment(this, new GeneralCubeEventArgs(app));
            if (this.Parent != null && exist)
            {
                ReBindAppointments();
                RefreshPanel();
            }
        }

        private void cube_EditCube(object sender, EventArgs e)
        {
            DoEditAppointment((EventCube)sender);
        }

        #endregion Cube Events

        #region EditEventCube Events

        private void _editEventCube_EditCubeDone(object sender, EditCubeDoneEventArgs e)
        {
            if (_inProc) return;
            _inProc = true;
            if (_editEventCube == null) return;
            // close the edit cube control
            if (_editEventCube.Parent != null) _editEventCube.Parent.Controls.Remove(_editEventCube);
            _editEventCube.Visible = false;
            _editEventCube = null;

            var editCube = (EditEventCube)sender;

            if (e.IsCancel)
            {
                if (editCube.Mode == EditEventCube.CubeMode.New)
                {
                    if (e.IsAllDayEvent) pnlAllDayEvents.Select();
                    else pnlTodayEvents.Select();
                }
                else
                {
                    if (_selectedCube != null) _selectedCube.Select();
                }
                if (CancelEditAppointment != null) CancelEditAppointment(this, new EventArgs());
            }
            else
            {
                if (e.Scope == null) return;

                if (editCube.Mode == EditEventCube.CubeMode.New)
                {
                    #region Create New Cube

                    var id = _Parent.GetNewAppointmentId();
                    var app = new Appointment(id, e.Scope[0], e.Scope[1], e.Text, e.OwnerId) { IsAllDayEvent = e.IsAllDayEvent };
                    _appointments.Add(app);
                    ReBindAppointments();
                    RefreshPanel();
                    var cube = GetCubeById(app.Id);
                    if (cube != null && e.IsLostFocus == false)
                    {
                        SetFocusControl(FocusControlType.Cube, cube);
                        if (SelectAppointment != null) SelectAppointment(this, new GeneralCubeEventArgs(cube.Appointment));
                        cube.Select();
                    }
                    if (AddAppointment != null) AddAppointment(this, new GeneralCubeEventArgs(app));

                    #endregion Create New Cube
                }
                else
                {
                    #region Edit Exist Cube

                    var id = editCube.SourceCube.Appointment.Id;
                    var app = _appointments.FindAppointment(id);
                    if (app != null)
                    {
                        app.Text = e.Text;
                        editCube.SourceCube.Text = e.Text;
                        TTip.SetToolTip(editCube.SourceCube.lblText, app.ToolTipScope);
                        if (EditAppointment != null) EditAppointment(this, new GeneralCubeEventArgs(app, GeneralCubeEventArgs.EditModeMember.Text));
                    }

                    #endregion Edit Exist Cube
                }
                if (editCube.SourceCube != null) editCube.SourceCube.Select();

                //if (e.IsLostFocus) ClearAnySelected();
            }

            _inProc = false;
        }

        #endregion EditEventCube Events

        private void WorkerPanel_Paint(object sender, PaintEventArgs e)
        {
            if (_Parent == null) return;

            // draw border to the pnlDayTitle
            var color = Color.FromArgb(141, 174, 217);

            switch (_lighted)
            {
                case PanelColor.Blue:
                    color = Color.FromArgb(141, 174, 217);
                    break;

                case PanelColor.Orange:
                    color = _Parent.ColorOrange;
                    break;

                case PanelColor.Yellow:
                    color = Color.FromArgb(223, 210, 26);
                    break;
            }

            var pen = new Pen(color);
            e.Graphics.DrawLine(pen, 0, 0, this.Width - 1, 0);
            e.Graphics.DrawLine(pen, 0, 0, 0, pnlDayTitle.Height - 1);
            e.Graphics.DrawLine(pen, this.Width - 1, 0, this.Width - 1, pnlDayTitle.Height - 1);

            // fill time lines pixel values
            if (_timeLines == null) InitTimeLines();
            var j = 1;
            for (var i = 30; i <= _Parent.DaySpan.TotalMinutes; i += 30)
            {
                _timeLines[j++] = _Parent.CInt(i * _pixelsForMin);
            }
        }

        private void lblDayCaption2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_editEventCube != null)
            {
                if (_editEventCube.Parent != null) _editEventCube.Parent.Controls.Remove(_editEventCube);
            }
            if (_enableExpand)
            {
                if (_isExpand)
                {
                    if (UnExpandWorker != null) UnExpandWorker(this, new EventArgs());
                }
                else
                {
                    if (ExpandWorker != null)
                    {
                        SetFocusControl(FocusControlType.None);
                        ExpandWorker(this, new EventArgs());
                    }
                }
            }
        }

        private void pnlTodayEvents_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            int[] pos;
            switch (e.KeyCode)
            {
                case Keys.Up:
                    pos = this.GetSelectedScopePos();
                    if (pos != null)
                    {
                        if (pos[0] <= 0) pos[0] = _timeLines.Length - 1;
                        {
                            ClearSelected();
                            PaintTimeLine(pnlTodayEvents.CreateGraphics(), pos[0] - 1, 1);
                            if (SelectedScopeChanged != null) SelectedScopeChanged(this, new EventArgs());
                        }
                    }
                    e.IsInputKey = true;
                    break;

                case Keys.Down:
                    pos = this.GetSelectedScopePos();
                    if (pos != null)
                    {
                        if (pos[1] >= _timeLines.Length - 2) pos[1] = -1;
                        ClearSelected();
                        PaintTimeLine(pnlTodayEvents.CreateGraphics(), pos[1] + 1, 1);
                        if (SelectedScopeChanged != null) SelectedScopeChanged(this, new EventArgs());
                    }
                    e.IsInputKey = true;
                    break;

                case Keys.Right:
                    if (MoveCursorToNextWorkerPanel != null) MoveCursorToNextWorkerPanel(this, new EventArgs());
                    e.IsInputKey = true;
                    break;

                case Keys.Left:
                    if (MoveCursorToPrevWorkerPanel != null) MoveCursorToPrevWorkerPanel(this, new EventArgs());
                    e.IsInputKey = true;
                    break;
            }
        }

        private void WorkerPanel_Enter(object sender, EventArgs e)
        {
            pnlTodayEvents.Select();
        }

        private void lblDayCaption2_MouseDown(object sender, MouseEventArgs e)
        {
            if (AcceptChanges != null) AcceptChanges(this, new EventArgs());
        }

        private void lblDayCaption2_MouseEnter(object sender, EventArgs e)
        {
            switch (_lighted)
            {
                case PanelColor.Blue:
                    pnlDayTitle.BackgroundImage = Properties.Resources.cal_worker_bg_light;
                    break;

                case PanelColor.Orange:
                    pnlDayTitle.BackgroundImage = Properties.Resources.cal_worker_bg_ex_light;
                    break;

                case PanelColor.Yellow:
                    pnlDayTitle.BackgroundImage = Properties.Resources.cal_worker_bg_sn_light;
                    break;

                default:
                    break;
            }
        }

        private void lblDayCaption2_MouseLeave(object sender, EventArgs e)
        {
            switch (_lighted)
            {
                case PanelColor.Blue:
                    pnlDayTitle.BackgroundImage = Properties.Resources.cal_worker_bg;
                    break;

                case PanelColor.Orange:
                    pnlDayTitle.BackgroundImage = Properties.Resources.cal_worker_bg_ex;
                    break;

                case PanelColor.Yellow:
                    pnlDayTitle.BackgroundImage = Properties.Resources.cal_worker_bg_sn;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Does the paste appointment.
        /// </summary>
        /// <param name="clipboard">The clipboard.</param>
        internal void DoPasteAppointment(CalendarClipboard clipboard)
        {
            var app = Serializer.Clone(clipboard.Appointment);

            app.WorkerId = _id;
            var dates = GetSelectedScope();
            var dur = app.Duration;
            app.StartDate = dates[0];
            app.EndDate = app.StartDate.Add(dur);

            _appointments.Add(app);
            ReBindAppointments();
            RefreshPanel();
            var cube = GetCubeById(app.Id);
            if (cube != null)
            {
                SetFocusControl(FocusControlType.Cube, cube);
                SelectAppointment?.Invoke(this, new GeneralCubeEventArgs(cube.Appointment));
                cube.Select();
            }
            PasteAppointment?.Invoke(this, new GeneralCubeEventArgs(app));
        }
    }
}