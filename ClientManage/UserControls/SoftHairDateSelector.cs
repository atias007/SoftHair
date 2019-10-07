using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ClientManage.Interfaces;
using ClientManage.BL.Library;

namespace ClientManage.UserControls
{
    public partial class SoftHairDateSelector : UserControl
    {
        private DateTime? _value;

        //public event EventHandler ValueChanged;

        public SoftHairDateSelector()
        {
            InitializeComponent();
            cmbDay.SelectedIndex = -1;
            cmbMonth.SelectedIndex = -1;

            var year = DateTime.Now.Year;
            cmbYear.Items.Add(string.Empty);
            for (var i = year - 99; i <= year; i++)
            {
                cmbYear.Items.Add(i);
            }
        }

        private Color _errorColor = Validation.ErrorColor;
        public Color ErrorColor
        {
            get { return _errorColor; }
            set { _errorColor = value; }
        }


        public DateTime? Value
        {
            get { Validate(); return _value; }
            set { SetDate(value); }
        }
        
        private void SetDate(DateTime? value)
        {
            _value = value;
            if (value == null)
            {
                cmbYear.Text = string.Empty;
                cmbYear.SelectedIndex = -1;
                cmbDay.SelectedIndex = -1;
                cmbMonth.SelectedIndex = -1;
            }
            else
            {
                var dt = value.Value;
                cmbDay.SelectedIndex = dt.Day - 1;
                cmbMonth.SelectedIndex = dt.Month - 1;

                if (dt.Year == Utils.DefaultBdayYear)
                {
                    cmbYear.Text = string.Empty;
                    cmbYear.SelectedIndex = -1;
                }
                else
                {
                    var index = cmbYear.FindString(dt.Year.ToString());
                    if (index == -1) cmbYear.Text = dt.Year.ToString();
                    else cmbYear.SelectedIndex = index;
                }
            }
            cmbYear.BackColor = Color.White;
            cmbMonth.BackColor = Color.White;
            cmbDay.BackColor = Color.White;
            cmbDay.Select();
        }

        private void lblClear_MouseEnter(object sender, EventArgs e)
        {
            lblClear.BackColor = Color.FromArgb(255, 231, 162);
        }

        private void lblClear_MouseLeave(object sender, EventArgs e)
        {
            lblClear.BackColor = Color.White;
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            SetDate(null);
            cmbDay.Select();
        }

        public new bool Validate()
        {
            var valid = true;

            if (cmbYear.SelectedIndex == -1 && cmbMonth.SelectedIndex == -1 && cmbDay.SelectedIndex == -1)
            {
                _value = null;
            }
            else
            {
                var year = cmbYear.Text.Length == 0 ? Utils.DefaultBdayYear : Convert.ToInt32(cmbYear.Text);
                var month = 0;
                var day = 0;
                
                int.TryParse(cmbDay.Text, out day);
                int.TryParse(cmbMonth.Text, out month);

                if (day == 0 || month == 0)
                {
                    _value = null;
                    valid = false;
                }
                else
                {
                    _value = null;
                    DateTime tmp;
                    valid = DateTime.TryParse(day.ToString() + "/" + month.ToString() + "/" + year.ToString(), out tmp);
                    if (valid) _value = tmp;
                }
            }

            if (!valid)
            {
                if (cmbYear.Text.Length > 0) cmbYear.BackColor = _errorColor;
                if (cmbMonth.Text.Length > 0) cmbMonth.BackColor = _errorColor;
                if (cmbDay.Text.Length > 0) cmbDay.BackColor = _errorColor;
            }
            else
            {
                cmbYear.BackColor = Color.White;
                cmbMonth.BackColor = Color.White;
                cmbDay.BackColor = Color.White;
            }

            return valid;
        }

        private void cmbYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void lblClear_Paint(object sender, PaintEventArgs e)
        {
            var c = Color.FromArgb(127, 157, 185);
            var rect = new Rectangle(0, 0, lblClear.Width, lblClear.Height - 1);
            e.Graphics.DrawRectangle(new Pen(c), rect);
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbYear.Select();
            lblYear.Visible = false;
        }

        private void cmbDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDay.Visible = (cmbDay.SelectedIndex == -1);
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMonth.Visible = (cmbMonth.SelectedIndex == -1);
        }

        private void cmbYear_Enter(object sender, EventArgs e)
        {
            cmbYear.BackColor = Color.White;
            lblYear.Visible = false;
        }

        private void cmbYear_Leave(object sender, EventArgs e)
        {
            lblYear.Visible = (cmbYear.Text.Length == 0);
        }

        private void lblMonth_MouseDown(object sender, MouseEventArgs e)
        {
            cmbMonth.Select();
            Utils.OpenComboBox(cmbMonth.Handle);
        }

        private void lblYear_MouseDown(object sender, MouseEventArgs e)
        {
            cmbYear.Select();
        }

        private void lblDay_MouseDown(object sender, MouseEventArgs e)
        {
            cmbDay.Select();
            Utils.OpenComboBox(cmbDay.Handle);
        }

        private void SoftHairDateSelector_Enter(object sender, EventArgs e)
        {
            //cmbDay.Select();
        }

        private void cmbMonth_Enter(object sender, EventArgs e)
        {
            cmbMonth.BackColor = Color.White;
        }

        private void cmbDay_Enter(object sender, EventArgs e)
        {
            cmbDay.BackColor = Color.White;
        }
    }
}
