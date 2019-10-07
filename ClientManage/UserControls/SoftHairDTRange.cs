using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ClientManage.Interfaces;

namespace ClientManage.UserControls
{
    public partial class SoftHairDTRange : UserControl
    {
        public bool IsReportVisualFix = false;

        public SoftHairDTRange()
        {
            InitializeComponent();
        }

        private void lblPeriod_MouseEnter(object sender, EventArgs e)
        {
            lblPeriod.BackColor = Color.FromArgb(255, 231, 162);
        }

        private void lblPeriod_MouseLeave(object sender, EventArgs e)
        {
            lblPeriod.BackColor = Color.White;
        }

        private void mnuToday_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateUtils.GetStartOfCurrentDay();
            dtpTo.Value = dtpFrom.Value;
        }

        private void mnuWeek_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateUtils.GetStartOfCurrentWeek();
            dtpTo.Value = DateUtils.GetEndOfCurrentWeek();
        }

        private void mnuMonth_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateUtils.GetStartOfCurrentMonth();
            dtpTo.Value = DateUtils.GetEndOfCurrentMonth();
        }

        private void mnuQuarter_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateUtils.GetStartOfCurrentQuarter();
            dtpTo.Value = DateUtils.GetEndOfCurrentQuarter();
        }

        private void mnuYear_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateUtils.GetStartOfCurrentYear();
            dtpTo.Value = DateUtils.GetEndOfCurrentYear();
        }

        private void lblPeriod_MouseDown(object sender, MouseEventArgs e)
        {
            ctxMenu.Show(lblPeriod, new Point(0, lblPeriod.Height - 2), ToolStripDropDownDirection.BelowRight);
        }

        private void mnuYesterday_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateUtils.GetStartOfLastDay();
            dtpTo.Value = dtpFrom.Value;
        }

        private void mnuLastWeek_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateUtils.GetStartOfLastWeek();
            dtpTo.Value = DateUtils.GetEndOfLastWeek();
        }

        private void mnuLastMonth_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateUtils.GetStartOfLastMonth();
            dtpTo.Value = DateUtils.GetEndOfLastMonth();
        }

        private void mnuLastQuarter_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateUtils.GetStartOfLastQuarter();
            dtpTo.Value = DateUtils.GetEndOfLastQuarter();
        }

        private void mnuLastYear_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateUtils.GetStartOfLastYear();
            dtpTo.Value = DateUtils.GetEndOfLastYear();
        }

        private void mnuTomorrow_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateUtils.GetStartOfNextDay();
            dtpTo.Value = dtpFrom.Value;
        }

        private void mnuNextWeek_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateUtils.GetStartOfNextWeek();
            dtpTo.Value = DateUtils.GetEndOfNextWeek();
        }

        private void mnuNextMonth_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateUtils.GetStartOfNextMonth();
            dtpTo.Value = DateUtils.GetEndOfNextMonth();
        }

        private void mnuNextQuarter_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateUtils.GetStartOfNextQuarter();
            dtpTo.Value = DateUtils.GetEndOfNextQuarter();
        }

        private void mnuNextYear_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateUtils.GetStartOfNextYear();
            dtpTo.Value = DateUtils.GetEndOfNextYear();
        }

        private void mnuTillToday_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = null;
            dtpTo.Value = DateUtils.GetStartOfCurrentDay();
        }

        private void mnuFromToday_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateUtils.GetStartOfCurrentDay();
            dtpTo.Value = null;
        }

        private void mnuAlways_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = null;
            dtpTo.Value = null;
        }

        public void SetDefaultValues(DateTime?[] values)
        {
            if (values[0].HasValue) dtpFrom.DefaultValue = values[0].GetValueOrDefault();
            if (values[1].HasValue) dtpTo.DefaultValue = values[1].GetValueOrDefault();
        }

        public void SetNullsText()
        {
            dtpFrom.NullText = "< ללא תאריך התחלה >";
            dtpTo.NullText = "< ללא תאריך סיום >";
        }

        public void SetValues(DateTime?[] values)
        {
            dtpFrom.Value = values[0];
            dtpTo.Value = values[1];
        }

        public override string ToString()
        {
            var sRet = dtpFrom.Value.HasValue ? dtpFrom.Value.GetValueOrDefault().ToShortDateString() : dtpFrom.NullText;
            sRet += "," + (dtpTo.Value.HasValue ? dtpTo.Value.GetValueOrDefault().ToShortDateString() : dtpTo.NullText);

            return sRet;
        }

        public string DisplayString()
        {
            var sRet = dtpFrom.Value.HasValue ? dtpFrom.Value.GetValueOrDefault().ToShortDateString() : dtpFrom.NullText;
            sRet += " - " + (dtpTo.Value.HasValue ? dtpTo.Value.GetValueOrDefault().ToShortDateString() : dtpTo.NullText);

            return sRet;
        }

        public DateTime?[] ValueRange
        {
            get
            {
                var dRet = new DateTime?[2];
                dRet[0] = dtpFrom.Value;
                dRet[1] = dtpTo.Value;
                return dRet;
            }
        }

        private void SoftHairDTRange_SizeChanged(object sender, EventArgs e)
        {
            dtpFrom.Width = this.Width - 21;
            dtpTo.Width = this.Width - 21;
            dtpTo.Top = 25;
            dtpFrom.Left = 21;
            dtpTo.Left = 21;
            lblPeriod.Width = 21;

            if (IsReportVisualFix) lblPeriod.Top = -1;
        }

        private void SoftHairDTRange_Paint(object sender, PaintEventArgs e)
        {
            var c = Color.FromArgb(127, 157, 185);
            e.Graphics.DrawLine(new Pen(c), 11, 22, 11, 27);
        }

        public bool ValidateValues()
        {
            var valid = true;
            if (dtpFrom.Value.HasValue && dtpTo.Value.HasValue)
            {
                if (dtpTo.Value.GetValueOrDefault() < dtpFrom.Value.GetValueOrDefault())
                {
                    valid = false;
                }
            }
            return valid;
        }

        private void lblPeriod_Paint(object sender, PaintEventArgs e)
        {
            var c = Color.FromArgb(127, 157, 185);
            var rec = new Rectangle(0, 1, lblPeriod.Width, lblPeriod.Height - 2);
            e.Graphics.DrawRectangle(new Pen(c), rec);
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            var from = dtpFrom.Value;
            var to = dtpTo.Value;

            if (from.HasValue && to.HasValue)
            {
                if (from.GetValueOrDefault().Date > to.GetValueOrDefault().Date)
                {
                    dtpTo.Value = dtpFrom.Value;
                }
            }
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            var from = dtpFrom.Value;
            var to = dtpTo.Value;

            if (from.HasValue && to.HasValue)
            {
                if (from.GetValueOrDefault().Date > to.GetValueOrDefault().Date)
                {
                    dtpFrom.Value = dtpTo.Value;
                }
            }
        }
    }
}
