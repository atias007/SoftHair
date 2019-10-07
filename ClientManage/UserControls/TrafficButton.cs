using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ClientManage.UserControls
{
    public partial class TrafficButton : UserControl
    {
        private int Wt = 0;
        private int Ht = 0;
        private bool blnCursor = false;
        private bool blnOnOffstate = false;
        private string _caption = "TrafficButton";
        private readonly bool _isInit = false;

        public TrafficButton()
        {
            InitializeComponent();
            _isInit = true;
        }

        public string Caption
        {
            get { return _caption; }
            set
            {
                var g = this.CreateGraphics();
                _caption = value;
                FillButtonUp(ref g);
                DrawText(ref g);
                DrawBorder(ref g);
                g.Dispose();
            }
        }

        public bool Value
        {
            get { return blnOnOffstate; }
        }

        private void DrawBorder(ref Graphics g)
        {
            var p = new Pen(Color.FromArgb(98, 98, 98), 1);
            Point[] Pts = {new Point(2, 0), 
                    new Point(Wt - 2, 0), 
                    new Point(Wt, 2), 
                    new Point(Wt, Ht - 2), 
                    new Point(Wt - 2, Ht), 
                    new Point(2, Ht), 
                    new Point(0, Ht - 2), 
                    new Point(0, 2), 
                    new Point(2, 0)};
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawLines(p, Pts);
            p.Dispose();
        }

        private void FillButtonUp(ref Graphics g)
        {
            Color fromColor;
            Color toColor;

            if (blnOnOffstate)
            {
                //fromColor = Color.FromArgb(255, 191, 194);
                fromColor = Color.FromArgb(255, 211, 214);
                //toColor = Color.FromArgb(212, 145, 139);
                toColor = Color.FromArgb(192, 125, 119);
            }
            else
            {
                fromColor = Color.FromArgb(250, 250, 250);
                //toColor = Color.FromArgb(214, 208, 197);
                toColor = Color.FromArgb(203, 209, 215);
            }

            var b = new LinearGradientBrush(new Point(0, 0), new Point(0, Ht), fromColor, toColor);
            var pts = new Point[] { new Point(2, 0), 
                    new Point(Wt - 2, 0), 
                    new Point(Wt, 2), 
                    new Point(Wt, Ht - 2), 
                    new Point(Wt - 2, Ht), 
                    new Point(2, Ht), 
                    new Point(0, Ht - 2), 
                    new Point(0, 2), 
                    new Point(2, 0)};
            blnCursor = false;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillPolygon(b, pts);
            b.Dispose();
        }

        private void FillButtonDown(ref Graphics g)
        {
            var b = new LinearGradientBrush(new Point(0, 0), new Point(0, (int)(Ht / 0.66)), Color.FromArgb(209, 204, 193), Color.FromArgb(234, 233, 227));
            var Pts = new Point[] {new Point(2, 0), 
                    new Point(Wt - 2, 0), 
                    new Point(Wt, 2), 
                    new Point(Wt, Ht - 2), 
                    new Point(Wt - 2, Ht), 
                    new Point(2, Ht), 
                    new Point(0, Ht - 2), 
                    new Point(0, 2), 
                    new Point(2, 0)};
            blnCursor = false;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillPolygon(b, Pts);
            b.Dispose();
        }

        private void DrawShadow(ref Graphics g)
        {
            var P = new Pen(Color.FromArgb(162, 158, 150), 1);
            var Shd = new Point[] {new Point(Wt + 1, 3), 
            new Point(Wt + 1, Ht - 2), 
            new Point(Wt - 2, Ht + 1), 
            new Point(2, Ht + 1)};
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawLines(P, Shd);
        }

        private void DrawCursor(ref Graphics g)
        {
            Color cColor;

            if (blnOnOffstate)
            {
                cColor = Color.FromArgb(207, 115, 130);
            }
            else
            {
                cColor = Color.FromArgb(165, 195, 238);
            }

            var p = new Pen(cColor, 2);
            var pts = new Point[] {new Point(2, 1), 
                    new Point(Wt - 2, 1), 
                    new Point(Wt - 1, 2), 
                    new Point(Wt - 1, Ht - 2), 
                    new Point(Wt - 2, Ht - 1), 
                    new Point(2, Ht - 1), 
                    new Point(1, Ht - 2), 
                    new Point(1, 2), 
                    new Point(2, 1)};
            blnCursor = true;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawLines(p, pts);
            p.Dispose();
        }

        private void DrawText(ref Graphics g)
        {
            DrawText(ref g, 0);
        }
        
        private void DrawText(ref Graphics g, int delta)
        {
            SizeF textSize;
            int posX, posY;
            var brush = new SolidBrush(this.ForeColor);

            textSize = g.MeasureString(_caption, this.Font);
            posX = Convert.ToInt32(((this.Width - textSize.Width) / 2) + delta);
            posY = Convert.ToInt32(((this.Height - textSize.Height) / 2) + delta);
            g.DrawString(_caption, this.Font, brush, posX, posY);
        }

        public void SetState(bool value)
        {
            if (value != blnOnOffstate)
            {
                var g = this.CreateGraphics();

                blnOnOffstate = value;
                FillButtonUp(ref g);
                DrawBorder(ref g);
                DrawText(ref g);
                g.Dispose();
            }
        }



        protected override void OnResize(EventArgs e)
        {
            if (!_isInit) return;

            Wt = this.Width - 3;
            Ht = this.Height - 3;
            this.Refresh();
            base.OnResize(e);
        }

        private void TrafficButton_Load(object sender, EventArgs e)
        {
            Wt = this.Width - 3;
            Ht = this.Height - 3;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            var g = this.CreateGraphics();

            FillButtonUp(ref g);
            DrawBorder(ref g);
            DrawText(ref g);
            g.Dispose();
            base.OnMouseLeave(e);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            if (!_isInit) return;
            var g = this.CreateGraphics();

            FillButtonUp(ref g);
            DrawBorder(ref g);
            DrawText(ref g);
            g.Dispose();
            base.OnFontChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            FillButtonUp(ref g);
            DrawBorder(ref g);
            DrawShadow(ref g);
            DrawText(ref g);
            g.Dispose();
            base.OnPaint(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            var g = this.CreateGraphics();

            FillButtonDown(ref g);
            DrawBorder(ref g);
            DrawText(ref g, 1);
            g.Dispose();
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!blnCursor && e.Button == MouseButtons.None)
            {
                var g = this.CreateGraphics();

                DrawCursor(ref g);
                DrawBorder(ref g);
                g.Dispose();
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            var g = this.CreateGraphics();

            FillButtonUp(ref g);
            DrawBorder(ref g);
            DrawText(ref g);
            g.Dispose();
            base.OnMouseUp(e);
        }        
    }
}
