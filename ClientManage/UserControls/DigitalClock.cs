using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace ClientManage.UserControls
{
    public enum ColonType { Circular, Rectangular };
    public enum ClockType { DigitalClock, Stopwatch, Countdown, Freeze };
    public enum DigitalColor { RedColor, BlueColor, GreenColor };
    // Clock format. For 12 hour format display 'A' (AM) or 'P' (PM)
    public enum ClockFormat { TwentyFourHourFormat, TwelveHourFormat };

    // DigitalClockCtrl is a control which displays a clock
    // Possible displays include a normal digital clock,
    //   a stop watch and a count down clock

    public partial class DigitalClock : UserControl
    {
        private Color digitsColor = Color.Red; // color of the digits displayed
        private Color countdownColor = Color.White; // background color after count down expires
        private ClockFormat clockDisplayFormat = ClockFormat.TwelveHourFormat;

        private DigitalDisplay[] DigitDisplay = null; // panels on which digits are displayed
        private DigitalDisplay[] ColonDisplay = null; // panels for displaying colons
        private DigitalDisplay AmPmDisplay = null; // panel for AM/PM display
        private DigitalDisplay MicroSecDisplay = null; // panel for displaying 1/10 of a second

        // type of clock to display (a normal clock, stop watch or count down)
        private ClockType clockType = ClockType.DigitalClock;

        // date time used to display stopwatch, count begins from this variable
        private DateTime stopwatchBegin = DateTime.Now;
        // count down in milli seconds, default of 10 seconds
        int countdownMiliSeconds = 10000;
        // whenever count down starts this time is set to Now + countDownMilliSeconds
        private DateTime countDownTo;

        // currently displayed numbers on the clock, useful to freeze
        int hour, min, sec, ms;
        char am_pm;

        // delegates called when the count down is finished
        public delegate void CountdownEventHandler();
        public event CountdownEventHandler CountdownDone = null;

        // delegates called when an alarm is set
        public delegate void AlarmEventHandler();
        public event AlarmEventHandler RaiseAlarm = null;
        private readonly ArrayList AlarmTimes = new ArrayList();

        // graphics surface for the control on which the clock is displayed
        private static Graphics graphics;

        public DigitalClock()
        {
            InitializeComponent();
        }

        private bool _showMilliseconds = true;
        public bool ShowMilliseconds
        {
            get { return _showMilliseconds; }
            set { _showMilliseconds = value; }
        }

        // set count down time in milli seconds
        public int CountdownTime
        {
            get { return countdownMiliSeconds; }
            set
            {
                if (value < 1000)
                    throw new Exception("Count down time cannot be less than 1000");
                else
                    countdownMiliSeconds = value;
            }
        }

        // set the alarm time
        public DateTime AlarmTime
        {
            set
            {
                if (value < DateTime.Now)
                    throw new Exception("Alarm time cannot be earlier.");
                else
                    AlarmTimes.Add(value);
            }
        }

        // set the display format, 12 Hr or 24 Hr
        public ClockFormat ClockDisplayFormat
        {
            get { return this.clockDisplayFormat; }
            set { this.clockDisplayFormat = value; }
        }

        // setting clock type
        // DigitalClock and StopWatch will automatically start the clock
        // For CountDown the number of seconds should be set before calling this property
        public ClockType SetClockType
        {
            get { return clockType; }
            set
            {
                clockType = value;
                switch (clockType)
                {
                    case ClockType.Stopwatch:
                        stopwatchBegin = DateTime.Now; // start stopwatch clock
                        break;
                    case ClockType.Countdown:
                        countDownTo = DateTime.Now.AddMilliseconds(countdownMiliSeconds);
                        break;
                }
            }
        }

        // set the color in which the digits are displayed
        public DigitalColor SetDigitalColor
        {
            set
            {
                this.Invalidate();
                DigitalDisplay.SetPenColor(value);
            }
        }

        private void DigitalClock_Paint(object sender, PaintEventArgs e)
        {
            lock (this)
            {
                DisplayTime(e.Graphics);
            }
        }

        // This function is aware which panel should display what number
        // and also the colons and PM and AM displays
        private bool blink = false; // toggle for blinking effect of colons
        private void DisplayTime(Graphics g)
        {
            var dt = DateTime.Now;
            if (clockType != ClockType.Freeze)
            {
                hour = dt.Hour;
                min = dt.Minute;
                sec = dt.Second;
                ms = dt.Millisecond;
                am_pm = ' ';
            }
            var ts = TimeSpan.Zero;

            // check if alarms are set, raise them
            for (var i = 0; i < AlarmTimes.Count; i++)
            {
                if (dt > (DateTime)AlarmTimes[i] && RaiseAlarm != null)
                {
                    AlarmTimes.RemoveAt(i);
                    RaiseAlarm();
                }
            }
            switch (clockType)
            {
                case ClockType.DigitalClock:
                    if (clockDisplayFormat == ClockFormat.TwelveHourFormat)
                        hour = dt.Hour % 12;
                    if (hour == 0) hour = 12;
                    switch (clockDisplayFormat)
                    {
                        case ClockFormat.TwentyFourHourFormat:
                            break;
                        case ClockFormat.TwelveHourFormat:
                            am_pm = (dt.Hour / 12 > 0) ? 'P' : 'A';
                            break;
                    }
                    break;
                case ClockType.Countdown:
                    ts = countDownTo.Subtract(dt);
                    if (ts < TimeSpan.Zero)
                    {
                        clockType = ClockType.DigitalClock;
                        ts = TimeSpan.Zero;
                        if (CountdownDone != null)
                            CountdownDone();
                    }
                    break;
                case ClockType.Stopwatch:
                    ts = dt.Subtract(this.stopwatchBegin);
                    break;
                case ClockType.Freeze:
                    break;
            }
            if (clockType != ClockType.DigitalClock &&
                clockType != ClockType.Freeze) // ts used for stopwatch or countdown
            {
                hour = ts.Hours;
                min = ts.Minutes;
                sec = ts.Seconds;
                ms = ts.Milliseconds;
            }
            try { DigitDisplay[0].Draw(hour / 10, g); } catch { }
            try { DigitDisplay[1].Draw(hour % 10, g); } catch { }
            try { DigitDisplay[2].Draw(min / 10, g); } catch { }
            try { DigitDisplay[3].Draw(min % 10, g); } catch { }
            try { DigitDisplay[4].Draw(sec / 10, g); } catch { }
            try { DigitDisplay[5].Draw(sec % 10, g); } catch { }
            try { if (_showMilliseconds) MicroSecDisplay.Draw(ms / 100, g); } catch { }
            if (am_pm == ' ')
                try { AmPmDisplay.Draw(g); } catch { }
            else
                try { AmPmDisplay.Draw(am_pm, g); } catch { }
        }

        // Timer used to refresh clock display
        private void OnClockTimer(object sender, System.EventArgs e)
        {
            DisplayTime(graphics);
        }

        // Keeping the colon timer, gives a special effect of colon blinking
        // independent of the seconds or 1/10 seconds display
        private void OnColonTimer(object sender, System.EventArgs e)
        {
            //display the 2 colons between the hours-minutes and minutes-seconds
            ColonDisplay[0].DrawColon(graphics, ColonType.Rectangular, blink);
            ColonDisplay[1].DrawColon(graphics, ColonType.Rectangular, blink);
            if (clockType == ClockType.Freeze)
                blink = false;
            else
                blink = !blink;
        }

        private void OnLoad(object sender, System.EventArgs e)
        {
            graphics = Graphics.FromHwnd(this.Handle);
            PreparePanels();
            ShowTimer.Interval = (_showMilliseconds ? 100 : 1000);
            ShowTimer.Start();  // digits are refreshed on timer count
            ColonTimer.Interval = 1000;
            ColonTimer.Start(); // this will blink the colon

            // adding the resize handler here so that it will be called
            // only after graphics variable is created
            this.Resize += new System.EventHandler(this.OnResize);
        }

        // function to prepare the digital clock panels by dividing the rectangle
        // It is assumed that the height of each digit is double that of it's width
        // Spacing betweent the digits is 10% of the width
        // The colon characters occupy 50% of width of the digits
        private void PreparePanels()
        {
            // from the above assumptions for height and width
            // the height should be 2.4 units and width 8.8 units :-)
            // check height and width whichever is dominant and adjust the other
            // and set up margins
            var rect = new Rectangle(0, 0, this.Width, this.Height);

            // widths, spacings and margins
            // height of colon display is same as a digit
            int DigitWidth, DigitHeight, ColonWidth, Spacing;
            float HMargin = 0, // left and right margin
                    VMargin = 0; // top and bottom margin

            // Calculate a digit width (which is our unit) from the above metrics
            // and settle for the least value
            var WidthUnit = (int)(rect.Width / 8.8F);
            var HeightUnit = (int)(rect.Height / 2.4F);
            DigitWidth = (WidthUnit < HeightUnit) ? WidthUnit : HeightUnit;

            DigitHeight = 2 * DigitWidth;  // height is twice of width
            ColonWidth = DigitWidth / 2;  // colon width is half of a digit
            Spacing = DigitWidth / 10;
            if (Spacing < 1) Spacing = 1; // atleast a spacing of 1 is required
            HMargin = (rect.Width - (8.8F * DigitWidth)) / 2;
            VMargin = (rect.Height - DigitHeight) / 2;

            // This is the basic rectangle, offset it as required
            var basicRect = new Rectangle(0, 0, (int)DigitWidth, (int)DigitHeight);
            int XOffset, YOffset;
            Rectangle calcRect;  // calculated rectangle for a panel
            // Y offset is same for all elements, expcept 1/10 second and AM/PM display
            YOffset = (int)(VMargin);

            // create digit panels.  6 digits
            if (DigitDisplay == null)
                DigitDisplay = new DigitalDisplay[6];
            for (var i = 0; i < 6; i++)
            {
                calcRect = basicRect;
                XOffset = (int)(HMargin + (Spacing * (i + 2 + (i / 2))) + (i * DigitWidth) + ((i / 2) * ColonWidth));
                calcRect.Offset(XOffset, YOffset);
                if (DigitDisplay[i] == null)
                    DigitDisplay[i] = new DigitalDisplay(calcRect);
                else
                    DigitDisplay[i].CalculateAllParameters(calcRect);
            }

            if (ColonDisplay == null)
                ColonDisplay = new DigitalDisplay[2];
            // for first colon
            calcRect = basicRect;
            calcRect.Width = (int)ColonWidth;
            XOffset = (int)(HMargin + 3 * Spacing + 2 * DigitWidth);
            calcRect.Offset(XOffset, YOffset);
            if (ColonDisplay[0] == null)
                ColonDisplay[0] = new DigitalDisplay(calcRect);
            else
                ColonDisplay[0].CalculateAllParameters(calcRect);

            // for second colon
            calcRect = basicRect;
            calcRect.Width = (int)ColonWidth;
            XOffset = (int)((6 * Spacing) + (4 * DigitWidth) + ColonWidth + HMargin);
            calcRect.Offset(XOffset, YOffset);
            if (ColonDisplay[1] == null)
                ColonDisplay[1] = new DigitalDisplay(calcRect);
            else
                ColonDisplay[1].CalculateAllParameters(calcRect);

            // for displaying 'A'(AM) or 'P' (PM)
            calcRect = basicRect;
            calcRect.Width = (int)ColonWidth;
            calcRect.Height = calcRect.Height / 2;
            XOffset = (int)((10 * Spacing) + (6 * DigitWidth) + (2 * ColonWidth) + HMargin);
            calcRect.Offset(XOffset, (int)(YOffset + DigitHeight / 2.0 + 1));
            if (AmPmDisplay == null)
                AmPmDisplay = new DigitalDisplay(calcRect);
            else
                AmPmDisplay.CalculateAllParameters(calcRect);

            // for displaying 1/10 of a second
            // reuse AM/PM display panel rectangle
            // only change Y coordinate, shift upwards
            calcRect.Y = YOffset - 1; // just to keep it apart from AM/PM display
            if (MicroSecDisplay == null)
                MicroSecDisplay = new DigitalDisplay(calcRect);
            else
                MicroSecDisplay.CalculateAllParameters(calcRect);
        }

        // On resize of control recalculate the rectangles for display
        // Also recreate the graphics so that the clipping region is updated
        private void OnResize(object sender, System.EventArgs e)
        {
            lock (this)
            {
                PreparePanels();
                graphics.Dispose();
                graphics = Graphics.FromHwnd(this.Handle);
                graphics.Clear(BackColor);
            }
        }
    }
}
