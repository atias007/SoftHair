using BizCare.Calendar.Library;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BizCare.Calendar
{
    internal partial class EventCube : UserControl
    {
        internal EventCube(Appointment appointment)
        {
            InitializeComponent();
            _appointment = appointment;
            _colorSet = CubeColorSet.GetColorSet((CubeColorSet.ColorSetTypes)_appointment.RecurrenceId);
            lblAlert.Visible = _appointment.HasAlert;
            lblText.ForeColor = _colorSet.TextColor;
            lblAlert.BackColor = _colorSet.BorderColor;
        }

        internal event EventHandler CubeDeleted;

        internal event EventHandler CubeDeselected;

        internal event MouseEventHandler CubeMouseDown;

        internal event MouseEventHandler CubeMouseDoubleClick;

        internal event EventHandler EditCube;

        internal event EventHandler CubeTabbedNext;

        internal event EventHandler CubeTabbedPrev;

        internal event EventHandler MoveSelCurToNextWorkerPanel;

        internal event EventHandler MoveSelCurToPrevWorkerPanel;

        internal event EventHandler VisibleTextChanged;

        internal event MouseEventHandler ShowContextMenu;

        internal event EventHandler<DragOverCubeEventArgs> DragOverCube;

        internal event EventHandler<GeneralCubeEventArgs> DragDropCube;

        private readonly Appointment _appointment;
        private CubeColorSet _colorSet;
        private bool _selected;
        private int _dragDelta;
        private string _clientName = string.Empty;
        private string _caresDescription = string.Empty;

        internal static double DragMinutePixels;
        internal static DateTime StartTime;

        internal Appointment Appointment
        {
            get
            {
                return _appointment;
            }
        }

        public string ClientName
        {
            get { return _clientName; }
            set { _clientName = value.Trim(); RefreshText(); }
        }

        public string CaresDescription
        {
            get { return _caresDescription; }
            set { _caresDescription = value; RefreshText(); }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value.Trim();
                RefreshText();
            }
        }

        internal bool Selected
        {
            get { return _selected; }
        }

        internal string VisibleText
        {
            get { return lblText.Text; }
        }

        internal void RefreshText()
        {
            //string _text = string.Empty;
            //if (_clientName.Length > 0)
            //{
            //    _text = _clientName;
            //}
            // if (_caresDescription.Length > 0)
            //{
            //    if (_text.Length > 0) _text += " - ";
            //    _text += _caresDescription;
            //}
            //if (this.Text.Length > 0)
            //{
            //    _text += " (" + this.Text + ")";
            //}

            //lblText.Text = _text.Trim();

            lblText.Text = _appointment.ToString();
            if (VisibleTextChanged != null) VisibleTextChanged(this, new EventArgs());
        }

        private void EventCube_MouseDown(object sender, MouseEventArgs e)
        {
            SelectCube(e);
            if (e.Button == MouseButtons.Right)
            {
                if (ShowContextMenu != null) ShowContextMenu(this, e);
            }
        }

        private void EventCube_Paint(object sender, PaintEventArgs e)
        {
            //Color fromColor = Color.FromArgb(251, 252, 254);
            //Color toColor = Color.FromArgb(192, 213, 235);
            //Color borderColor = Color.FromArgb(93, 140, 201);
            var rect = new Rectangle(1, 1, this.Width - 2, this.Height - 2);
            var brush = new LinearGradientBrush(rect, _colorSet.FromColor, _colorSet.ToColor, LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(brush, rect);

            if (_selected)
            {
                var p = new Pen(Color.Black) { Width = 2 };
                e.Graphics.DrawRectangle(p, 1, 1, this.Width - 2, this.Height - 2);
            }
            else
            {
                e.Graphics.DrawRectangle(new Pen(_colorSet.BorderColor), 0, 0, this.Width - 1, this.Height - 1);
            }
        }

        internal void DeselectCube()
        {
            _selected = false;
            this.Refresh();
        }

        internal void SelectCube()
        {
            SelectCube(null);
        }

        internal void SetCategory(int category)
        {
            var cc = (CubeColorSet.ColorSetTypes)category;
            _appointment.RecurrenceId = category;
            _colorSet = CubeColorSet.GetColorSet(cc);
            lblText.ForeColor = _colorSet.TextColor;
            lblAlert.BackColor = _colorSet.BorderColor;
            this.Refresh();
        }

        internal void SelectCube(MouseEventArgs e)
        {
            this.Select();
            if (!_selected)
            {
                _selected = true;
                this.Refresh();
                this.BringToFront();

                if (e != null) if (CubeMouseDown != null) CubeMouseDown(this, e);
            }
        }

        private void EventCube_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    if (_appointment.WorkerId != -1)
                    {
                        if (CubeDeleted != null) CubeDeleted(this, new EventArgs());
                    }
                    break;

                case Keys.Enter:
                    EventCube_MouseDoubleClick(null, new MouseEventArgs(MouseButtons.Left, 2, 0, 0, 0));
                    break;

                case Keys.Escape:
                    DeselectCube();
                    if (CubeDeselected != null) CubeDeselected(this, new EventArgs());
                    break;

                case Keys.F2:
                    if (_selected && _appointment.WorkerId != -1)
                    {
                        if (EditCube != null) EditCube(this, new EventArgs());
                    }
                    break;
            }
        }

        private void EventCube_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (CubeMouseDoubleClick != null) CubeMouseDoubleClick(this, e);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int wmKeydown = 0x100;
            const int wmSyskeydown = 0x104;

            if ((msg.Msg == wmKeydown) || msg.Msg == wmSyskeydown)
            {
                switch (keyData)
                {
                    case Keys.Left:
                        if (MoveSelCurToPrevWorkerPanel != null) MoveSelCurToPrevWorkerPanel(null, new EventArgs());
                        return true;

                    case Keys.Right:
                        if (MoveSelCurToNextWorkerPanel != null) MoveSelCurToNextWorkerPanel(null, new EventArgs());
                        return true;

                    case Keys.Down:
                    case Keys.Tab:
                        if (_selected && CubeTabbedNext != null) CubeTabbedNext(this, new EventArgs());
                        return true;

                    case Keys.Up:
                    case Keys.Shift | Keys.Tab:
                        if (_selected && CubeTabbedPrev != null) CubeTabbedPrev(this, new EventArgs());
                        return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private string GetDragOverTooltip(Appointment app)
        {
            return app.StartDate.AddMinutes(_dragDelta * 15).ToShortTimeString() +
                " - " + app.EndDate.AddMinutes(_dragDelta * 15).ToShortTimeString();
        }

        private void EventCube_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !Appointment.IsAllDayEvent)
            {
                int topPos;
                TimeSpan ts;
                if (e.Y < 0)
                {
                    this.Cursor = Cursors.NoMoveVert;
                    lblText.Cursor = Cursors.NoMoveVert;
                    ts = _appointment.StartDate.Subtract(StartTime);
                    topPos = Convert.ToInt32(Math.Ceiling(DragMinutePixels * (ts.TotalMinutes + ((_dragDelta - 1) * 15))));
                    if (topPos >= 0)
                    {
                        this.BringToFront();
                        this.Top = topPos;
                        _dragDelta--;
                        if (DragOverCube != null) DragOverCube(this, new DragOverCubeEventArgs(GetDragOverTooltip(Appointment)));
                    }
                }
                else if (e.Y > this.Height)
                {
                    this.Cursor = Cursors.NoMoveVert;
                    lblText.Cursor = Cursors.NoMoveVert;
                    ts = _appointment.StartDate.Subtract(StartTime);
                    topPos = Convert.ToInt32(Math.Ceiling(DragMinutePixels * (ts.TotalMinutes + ((_dragDelta + 1) * 15))));
                    if (topPos + this.Height <= this.Parent.Height)
                    {
                        this.BringToFront();
                        this.Top = topPos;
                        _dragDelta++;
                        if (DragOverCube != null) DragOverCube(this, new DragOverCubeEventArgs(GetDragOverTooltip(Appointment)));
                    }
                }
            }
        }

        private void LblTextMouseMove(object sender, MouseEventArgs e)
        {
            EventCube_MouseMove(sender, e);
        }

        private void EventCube_MouseUp(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblText.Cursor = Cursors.Default;

            if (DragDropCube != null)
            {
                GeneralCubeEventArgs arg = null;
                if (_dragDelta != 0)
                {
                    Appointment.StartDate = Appointment.StartDate.AddMinutes(_dragDelta * 15);
                    Appointment.EndDate = Appointment.EndDate.AddMinutes(_dragDelta * 15);
                    arg = new GeneralCubeEventArgs(Appointment);
                }
                DragDropCube(null, arg);
            }

            _dragDelta = 0;
        }

        private void LblTextMouseUp(object sender, MouseEventArgs e)
        {
            EventCube_MouseUp(sender, e);
        }
    }
}