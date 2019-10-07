using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ClientManage.BL;

namespace ClientManage.UserControls
{
    public partial class SoftHairDtPicker : UserControl
    {
        private bool _isNullValue = true;
        private DateTime _defaultValue = DateTime.Now.Date;
        public event EventHandler ValueChanged;

        public SoftHairDtPicker()
        {
            InitializeComponent();
            dtpDate.Value = _defaultValue;

            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                dtpDate.CustomFormat = AppSettingsHelper.GetParamValue("APP_DATE_FORMAT");
            }
        }

        private bool IsNullValue
        {
            get { return _isNullValue; }
            set 
            { 
                _isNullValue = value;
                lblNoDate.Visible = _isNullValue;
            }
        }
        public string NullText
        {
            get { return lblNoDate.Text; }
            set { lblNoDate.Text = value; }
        }
        public DateTime DefaultValue
        {
            get { return _defaultValue; }
            set
            {
                _defaultValue = value;
                dtpDate.Value = _defaultValue;
            }
        }
        public DateTime? Value
        {
            get
            {
                if (IsNullValue) return null;
                return dtpDate.Value;
            }
            set
            {
                if (value == null)
                {
                    IsNullValue = true;
                }
                else
                {
                    dtpDate.Value = value.GetValueOrDefault();
                    IsNullValue = false;
                }
            }
        }

        public bool ClearButtonEnable
        {
            get { return lblClear.Enabled; }
            set { lblClear.Enabled = value; }
        }

        public bool ClearButtonVisible
        {
            get { return lblClear.Visible; }
            set { lblClear.Visible = value; }
        }

        private void ResizeMe()
        {
            dtpDate.Width = this.Width - 21 - this.Padding.Horizontal;
            this.Height = dtpDate.Height + this.Padding.Vertical;
            lblNoDate.Left = dtpDate.Left + 26;
            lblNoDate.Top = dtpDate.Top + 2;
            lblNoDate.Width = dtpDate.Width - 28;
            lblNoDate.Height = dtpDate.Height - 4;
        }

        private void DtpDateValueChanged(object sender, EventArgs e)
        {
            IsNullValue = false;
            if (ValueChanged != null) ValueChanged(this, e);
        }

        private void SoftHairDtPickerSizeChanged(object sender, EventArgs e)
        {
            ResizeMe();
        }

        private void LblClearMouseEnter(object sender, EventArgs e)
        {
            lblClear.BackColor = Color.FromArgb(255, 231, 162);
        }

        private void LblClearMouseLeave(object sender, EventArgs e)
        {
            lblClear.BackColor = Color.White;
        }

        private void LblClearClick(object sender, EventArgs e)
        {
            if(!IsNullValue) IsNullValue = true;
        }

        private void DtpDateValidating(object sender, CancelEventArgs e)
        {
            OnValidating(e);
        }

        private void LblClearPaint(object sender, PaintEventArgs e)
        {
            var c = Color.FromArgb(127, 157, 185);
            var rect = new Rectangle(0, 0, lblClear.Width, lblClear.Height - 1);
            e.Graphics.DrawRectangle(new Pen(c), rect);
        }

        private void SoftHairDtPickerPaddingChanged(object sender, EventArgs e)
        {
            ResizeMe();
        }

        private void DtpDateCloseUp(object sender, EventArgs e)
        {
            if (!dtpDate.Value.Equals(this.Value))
            {
                DtpDateValueChanged(null, null);
            }
        }

        private void LblNoDateMouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Value = _defaultValue;
        }

        private void SoftHairDtPickerEnabledChanged(object sender, EventArgs e)
        {
            lblNoDate.BackColor = this.Enabled ? Color.White : Color.FromKnownColor(KnownColor.Control);
        }
    }
}
