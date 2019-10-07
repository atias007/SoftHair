using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BizCare.SoftHair.MonthCalendar
{
    internal class CalLabel : System.Windows.Forms.Label
    {
        public CalLabel() : base()
        {
            base.Paint += new PaintEventHandler(CalLabel_Paint);
        }

        public enum LabelDayMode { Current, Next, Last };

        private LabelDayMode _dayMode;
        public LabelDayMode DayMode
        {
            get { return _dayMode; }
            set 
            {
                _dayMode = value;
                switch (_dayMode)
                {
                    case LabelDayMode.Current:
                        if (_selected)
                        {
                            this.ForeColor = Common.ColorDay;
                        }
                        break;
                    case LabelDayMode.Last:
                    case LabelDayMode.Next:
                        this.Image = null;
                        this.ForeColor = Common.ColorNotMonthDay;
                        break;
                    default:
                        break;
                }
            }
        }

        private bool _selected;
        public bool Selected
        {
            get { return _selected; }
            set 
            {
                _selected = value;
                if (_selected)
                {
                    this.Image = Properties.Resources.mark;
                    this.ForeColor = Common.ColorSelectFg;
                }
                else
                {
                    if (_isBold)
                    {
                        this.Image = Properties.Resources.select;
                        this.ForeColor = Common.ColorBoldFg;
                    }
                    else
                    {
                        this.Image = null;
                        this.ForeColor = Common.ColorDay;
                    }
                }
            }
        }

        private bool _isToday = false;
        public bool IsToday
        {
            get { return _isToday; }
            set
            {
                _isToday = value;
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(Refresh));
                }
                else
                {
                    this.Refresh();
                }
            }
        }

        private bool _isBold = false;
        public bool IsBold
        {
            get { return _isBold; }
            set 
            {
                _isBold = value;
                if (_isBold)
                {
                    this.Image = Properties.Resources.select;
                    this.ForeColor = Common.ColorBoldFg;
                }
                else
                {
                    this.Image = null;
                    this.ForeColor = Common.ColorDay;
                }
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CalLabel
            // 
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CalLabel_Paint);
            this.ResumeLayout(false);

        }

        public void ClearStatus()
        {
            this.IsBold = false;
            this.Selected = false;
            this.IsToday = false;
        }

        #region Paint Methods

        // ************************************************** Selected ***************************************** //

        //Rectangle rect = new Rectangle(0,0, this.Width - 1, this.Height - 1);
        //LinearGradientBrush brush = new LinearGradientBrush(rect, Common.ColorBoldBgFrom, Common.ColorBoldBgTo, LinearGradientMode.Vertical);
        //e.Graphics.FillRectangle(brush, rect);
        //e.Graphics.DrawLine(new Pen(Common.ColorBoldBorderUp), 0, 0, this.Width, 0);
        //e.Graphics.DrawLine(new Pen(Common.ColorBoldBorderDown), 0, this.Height - 1, this.Width - 1, this.Height - 1);

        //Rectangle rect2 = new Rectangle(0, 0, 1, this.Height);
        //LinearGradientBrush brush2 = new LinearGradientBrush(rect2, Common.ColorBoldBorderUp, Common.ColorBoldBorderDown, LinearGradientMode.Vertical);
        //e.Graphics.FillRectangle(brush2, rect2);

        //Rectangle rect3 = new Rectangle(this.Width - 1, 0, 1, this.Height);
        //LinearGradientBrush brush3 = new LinearGradientBrush(rect3, Common.ColorBoldBorderUp, Common.ColorBoldBorderDown, LinearGradientMode.Vertical);
        //e.Graphics.FillRectangle(brush3, rect3);

        // ***************************************************************************************************** //

        #endregion

        private void CalLabel_Paint(object sender, PaintEventArgs e)
        {
            if (_isToday)
            {
                var pen = new Pen(Common.ColorToday);
                e.Graphics.DrawRectangle(Pens.Transparent, 0, 0, this.Width - 2, this.Height - 1);

                e.Graphics.DrawLine(pen, 2, 0, this.Width - 4, 0);
                e.Graphics.DrawLine(pen, 2, this.Height - 1, this.Width - 4, this.Height - 1);
                e.Graphics.DrawLine(pen, 0, 2, 0, this.Height - 3);
                e.Graphics.DrawLine(pen, this.Width - 2, 2, this.Width - 2, this.Height - 3);

                e.Graphics.DrawLine(pen, 1, 1, this.Width - 3, 1);
                e.Graphics.DrawLine(pen, 1, this.Height - 2, this.Width - 3, this.Height - 2);
                e.Graphics.DrawLine(pen, 1, 1, 1, this.Height - 2);
                e.Graphics.DrawLine(pen, this.Width - 3, 1, this.Width - 3, this.Height - 2);
            }
        }

    }
}
