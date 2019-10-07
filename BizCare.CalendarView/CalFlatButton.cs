using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ClientManage.UserControls
{
    [System.ComponentModel.DefaultEvent("Click")]
    public partial class CalFlatButton : Label
    {
        private bool _isButtonLight = false;
        private Color _srcColor;

        public CalFlatButton()
        {
            InitializeComponent();
        }

        private void XPFlatButton_Paint(object sender, PaintEventArgs e)
        {
            var pen = _isButtonLight ?
                new Pen(Color.FromArgb(255, 189, 105)) :
                new Pen(Color.FromArgb(162, 188, 213));

            e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.BackColor = _srcColor;
            _isButtonLight = false;
            base.OnMouseLeave(e);
        }


        protected override void OnMouseEnter(EventArgs e)
        {
            if (!_isButtonLight)
            {
                _srcColor = Color.FromArgb(this.BackColor.A, this.BackColor.R, this.BackColor.G, this.BackColor.B);
                this.BackColor = Color.FromArgb(255, 231, 162);
                _isButtonLight = true;
            }
            base.OnMouseEnter(e);
        }
    }
}
