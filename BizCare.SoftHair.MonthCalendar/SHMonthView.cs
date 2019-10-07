using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BizCare.SoftHair.MonthCalendar
{
    public partial class SHMonthView : UserControl
    {
        private readonly Color cap1 = Color.FromArgb(197, 220, 250);
        private readonly Color cap2 = Color.FromArgb(135, 173, 228);
        private readonly Color cap3 = Color.FromArgb(105, 143, 198);

        private bool _ignoreEvent = false;
        private int _advance = 0;
        private bool _freez = false;

        public event EventHandler SelectedDateChanged;
        public event EventHandler MonthChanged;

        public SHMonthView()
        {
            InitializeComponent();
            SetDays();
            SetHeader();
            SetFooter();
            CheckMenu();

            c1.ForeColor = cap3;
            c2.ForeColor = cap3;
            c3.ForeColor = cap3;
            c4.ForeColor = cap3;
            c5.ForeColor = cap3;
            c6.ForeColor = cap3;
            c7.ForeColor = cap3;

            btnNext.Left = 5;
            btnPrev.Left = this.Width - 25;
            lblToday.Text = DateTime.Now.Day.ToString();
            SelectDayLabel(_selectedDate.Day, true);
        }

        private int _month = DateTime.Now.Month;
        public int Month
        {
            get { return _month; }
            set 
            {
                if (value == _month) return;
                var delta = value - _month;
                _month = value;
                CheckMenu();
                ClearCurrentSelected();
                SetDays(); 
                SetHeader();
                this.SelectedDate = this.SelectedDate.AddMonths(delta);
                if (MonthChanged != null) MonthChanged(this, new EventArgs());
            }
        }

        private int _year = DateTime.Now.Year;
        public int Year
        {
            get { return _year; }
            set 
            {
                if (value == _year) return;
                var delta = value - _year;
                _year = value;
                _ignoreEvent = true;
                yearUpDn.Value = Year;
                _ignoreEvent = false;
                ClearCurrentSelected();
                SetDays();
                SetHeader();
                this.SelectedDate = this.SelectedDate.AddYears(delta);
                if (MonthChanged != null) MonthChanged(this, new EventArgs());
            }
        }

        private DateTime _selectedDate = DateTime.Now.Date;
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                if (value == _selectedDate) return;

                // clear the selected date
                SelectDayLabel(_selectedDate.Day, false);
                
                // set the new current date
                _selectedDate = value.Date;

                SetMonthYear(value.Month, value.Year);
                SelectDayLabel(value.Day, true);

                if (SelectedDateChanged != null) SelectedDateChanged(this, new EventArgs());
            }
        }

        private DateTime[] _boldDates = null;
        public DateTime[] BoldDates
        {
            get { return _boldDates; }
            set 
            { 
                _boldDates = value;
                SetBoldDates();
                if(pnlDays.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(pnlDays.Refresh));
                }
                else 
                {
                    pnlDays.Refresh();
                }
            }
        }

        private void SetMonthYear(int month, int year)
        {
            if (this.Month == month && this.Year == year) return;
            _month = month;
            _year = year;
            if (MonthChanged != null) MonthChanged(this, new EventArgs());

            _ignoreEvent = true;
            yearUpDn.Value = Year;
            _ignoreEvent = false;

            CheckMenu();
            ClearCurrentSelected();
            SetDays();
            SetHeader();
        }

        public void NextMonth()
        {
            //TODO: limit the year value
            this.SelectedDate = this.SelectedDate.AddMonths(1);
        }

        public void PrevMonth()
        {
            //TODO: limit the year value
            this.SelectedDate = this.SelectedDate.AddMonths(-1);
        }

        public void NextYear()
        {
            //TODO: limit the year value
            ClearCurrentSelected();
            this.Year++;
        }

        public void PrevYear()
        {
            //TODO: limit the year value
            ClearCurrentSelected();
            this.Year--;
        }

        private void SetDays()
        {
            var firstDay = new DateTime(this.Year, this.Month, 1);
            var lastDay = firstDay.AddMonths(1).AddDays(-1);
            var lastMonthDay = (int)firstDay.AddDays(-1).Day;
            string strControl;
            CalLabel control;

            _advance = (int)firstDay.DayOfWeek;
            if (_advance == 0) _advance = 7;
            _advance++;

            for (var i = _advance - 1; i > 0; i--)
            {
                strControl = "d" + i.ToString();
                control = ((CalLabel)pnlDays.Controls[strControl]);
                control.ClearStatus();
                control.Text = Convert.ToString(lastMonthDay);
                control.DayMode = CalLabel.LabelDayMode.Last;
                lastMonthDay--;
            }

            var chackForToday = (this.Month == DateTime.Now.Month && this.Year == DateTime.Now.Year);
            for (var i = 0; i < lastDay.Day; i++)
            {
                strControl = "d" + Convert.ToString(i + _advance);
                control = ((CalLabel)pnlDays.Controls[strControl]);
                control.ClearStatus();
                control.Text = Convert.ToString(i + 1);
                control.DayMode = CalLabel.LabelDayMode.Current;

                if (chackForToday) control.IsToday = (i + 1 == DateTime.Now.Day);
                else control.IsToday = false;
            }

            var counter = 1;
            for (var i = lastDay.Day + _advance; i <= 42; i++)
            {
                strControl = "d" + i.ToString();
                control = ((CalLabel)pnlDays.Controls[strControl]);
                control.ClearStatus();
                control.Text = Convert.ToString(counter);
                control.DayMode = CalLabel.LabelDayMode.Next;
                counter++;
            }
        }

        private void SetBoldDates()
        {
            var strControl = string.Empty;
            CalLabel control;

            if (_boldDates != null)
            {
                foreach (var var in _boldDates)
                {
                    if (var.Month == this.Month && var.Year == this.Year)
                    {
                        strControl += "d" + Convert.ToString(var.Day + _advance - 1) + " ";
                    }
                }
            }

            foreach (Control c in pnlDays.Controls)
            {
                if (c is CalLabel)
                {
                    control = ((CalLabel)c);
                    if (strControl.Contains(c.Name + " "))
                    {
                        if (!control.IsBold) control.IsBold = true;
                    }
                    else
                    {
                        if (control.IsBold) control.IsBold = false;
                    }
                    if (control.Selected)
                    {
                        SelectDayLabel(control, true);
                    }
                }
            }
        }

        private void SetHeader()
        {
            lblHeader.Text = new DateTime(this.Year, this.Month, 1).ToString("MMMM yyyy");
            lblHeader.Left = (this.Width - lblHeader.Width) / 2;
        }

        private void SetFooter()
        {
            lblFooter.Text = "διεν: " + DateTime.Now.Date.ToString("dd/MM/yyyy");
        }

        private void SelectDayLabel(int day, bool value)
        {
            var label = (CalLabel)pnlDays.Controls["d" + Convert.ToString(_advance + day - 1)];
            SelectDayLabel(label, value);
        }

        private void SelectDayLabel(CalLabel label, bool value)
        {
            label.Selected = value;
        }

        private void ClearCurrentSelected()
        {
            var label = (CalLabel)pnlDays.Controls["d" + Convert.ToString(_advance + SelectedDate.Day - 1)];
            label.Selected = false;
        }
        
        private void HideYearUpDn()
        {
            if (this.Year != yearUpDn.Value) this.Year = Convert.ToInt32(yearUpDn.Value);
            yearUpDn.Visible = false;
        }

        private void CheckMenu()
        {
            for (var i = 1; i <= 12; i++)
            {
                ((ToolStripMenuItem)contextMenuStrip1.Items["mnu" + i.ToString()]).Checked = false;
            }
            ((ToolStripMenuItem)contextMenuStrip1.Items["mnu" + this.Month.ToString()]).Checked = true;
        }

        private void lblFooter_Click(object sender, EventArgs e)
        {
            if (_freez) return;
            SetFooter();
            SelectedDate = DateTime.Now.Date;
        }

        private void d_MouseDown(object sender, MouseEventArgs e)
        {
            if (_freez) return;
            HideYearUpDn();
            var label = (CalLabel)sender;
            if (label.Selected) return;

            ClearCurrentSelected();
            label.Selected = true;
        }

        private void d_MouseUp(object sender, MouseEventArgs e)
        {
            if (_freez) return;
            var label = (CalLabel)sender;
            var day = Convert.ToInt32(label.Text);

            if (label.DayMode != CalLabel.LabelDayMode.Current) label.Selected = false;

            if (label.DayMode == CalLabel.LabelDayMode.Next) NextMonth();
            else if (label.DayMode == CalLabel.LabelDayMode.Last) PrevMonth();

            SelectedDate = new DateTime(this.Year, this.Month, day);
        }

        private void lblHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (_freez) return;
            if (e.X > 40)
            {
                HideYearUpDn();
                contextMenuStrip1.Show(lblHeader, new Point(lblHeader.Width, lblHeader.Height));
            }
            else
            {
                yearUpDn.Visible = true;
                yearUpDn.BringToFront();
                yearUpDn.Select();
                yearUpDn.Focus();
            }
        }

        private void mnu_Click(object sender, EventArgs e)
        {
            var month = Convert.ToInt32(((ToolStripMenuItem)sender).Tag);
            this.Month = month;
        }

        private void yearUpDn_ValueChanged(object sender, EventArgs e)
        {
            if (_freez) return;
            if (_ignoreEvent) return;
            this.Year = Convert.ToInt32(yearUpDn.Value);
        }

        private void lblHeader_LocationChanged(object sender, EventArgs e)
        {
            yearUpDn.Left = lblHeader.Left - 16;
        }

        private void GenHideControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (_freez) return;
            HideYearUpDn();
        }

        private void yearUpDn_Leave(object sender, EventArgs e)
        {
            if (_freez) return;
            HideYearUpDn();
        }
        
        private void SHMonthView_Paint(object sender, PaintEventArgs e)
        {
            var rect = new Rectangle(0, 0, this.Width, 31);
            var brush = new LinearGradientBrush(rect, cap1, cap2, LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(brush, rect);

            rect = new Rectangle(0, lblFooter.Top, lblFooter.Width, lblFooter.Height);
            brush = new LinearGradientBrush(rect, cap1, cap2, LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(brush, rect);

            rect = new Rectangle(lblToday.Location, lblToday.Size);
            rect.Inflate(-2, -2);
            var bs = new SolidBrush(Color.FromArgb(180, 255, 255, 255));
            e.Graphics.FillRectangle(bs, rect);
        }

        private void pnlDays_Paint(object sender, PaintEventArgs e)
        {
            var height = c1.Bottom;
            e.Graphics.DrawLine(Pens.Black, 5, height, pnlDays.Width - 11, height);
        }

        private void btnNext_MouseDown(object sender, MouseEventArgs e)
        {
            if (_freez) return;
            btnNext.Image = Properties.Resources.prev_light;
        }

        private void btnNext_MouseUp(object sender, MouseEventArgs e)
        {
            if (_freez) return;
            btnNext.Image = Properties.Resources.prev;
        }

        private void btnPrev_MouseUp(object sender, MouseEventArgs e)
        {
            if (_freez) return;
            btnPrev.Image = Properties.Resources.next;
        }

        private void btnPrev_MouseDown(object sender, MouseEventArgs e)
        {
            if (_freez) return;
            btnPrev.Image = Properties.Resources.next_light;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_freez) return;
            PrevMonth();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_freez) return;
            NextMonth();
        }

        public void ReDraw()
        {
            SetDays();
            SetFooter();
            SelectDayLabel(_selectedDate.Day, true);
            SetBoldDates();
            lblToday.Text = DateTime.Now.Day.ToString();
            if (pnlDays.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(pnlDays.Refresh));
            }
            else
            {
                pnlDays.Refresh();
            }
        }

        public void Freez()
        {
            _freez = true;
        }

        public void UnFreez()
        {
            _freez = false;
        }
    }
}