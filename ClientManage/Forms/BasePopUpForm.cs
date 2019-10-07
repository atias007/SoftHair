using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using ClientManage.Library;

namespace ClientManage.Forms
{
    public partial class BasePopupForm : Form
    {
        #region Private

            #region Private Members

        private readonly Color _borderColor = Color.FromArgb(51, 55, 64);
        private readonly Color _subBorderColor = Color.FromArgb(225, 230, 235);
        private readonly Color _captionFromColor = Color.FromArgb(168, 185, 203);
        private readonly Color _captionToColor = Color.FromArgb(194, 212, 232);
        private readonly Color _innerBorderColor = Color.FromArgb(96, 106, 116);
        private const int AniEffect = 0x10;
        
        private const int Htcaption = 0x0002;
        private const int WmNclbuttondown = 0xA1;

            #endregion
            
            #region Win API Declaration

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int AnimateWindow(IntPtr hWnd, int dwTime, int dwFlag);

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

            #endregion

        #endregion

        #region Public
            
            #region Public Properties

        protected MyMessageBox MyMessageBox;

        private bool _closeFormByEsc;
        public bool CloseFormByEsc
        {
            get { return _closeFormByEsc; }
            set
            {
                _closeFormByEsc = value;
                this.KeyPreview = value;

                if (_closeFormByEsc)
                {
                    this.KeyDown += BaseMdiChildKeyDown;
                }
                else
                {
                    this.KeyDown -= BaseMdiChildKeyDown;
                }
            }
        }

        public DialogResult CloseButtonResult
        {
            get { return controlBox.DialogResult; }
            set { controlBox.DialogResult = value; }
        }

        private bool _canDragForm = true;
        public bool CanDragForm
        {
            get { return _canDragForm; }
            set { _canDragForm = value; }
        }

        private bool _animateWindow;
        public bool AnimateForm
        {
            get { return _animateWindow; }
            set { _animateWindow = value; }
        }

        private int _animateInterval = 75;
        public int AnimateInterval
        {
            get { return _animateInterval; }
            set { _animateInterval = value; }
        }

        public bool ShowMaximizeControl
        {
            get { return controlBox.ShowMaximize; }
            set { controlBox.ShowMaximize = value; }
        }

        public bool ShowMinimizeControl
        {
            get { return controlBox.ShowMinimize; }
            set { controlBox.ShowMinimize = value; }
        }

        public bool ShowControlBox
        {
            get { return controlBox.ShowControlBox; }
            set { controlBox.ShowControlBox = value; }
        }

        private Image _captionImage;
        public Image CaptionImage
        {
            get { return _captionImage; }
            set 
            { 
                _captionImage = value;
                lblCaption.Image = _captionImage;
                lblCaption.BringToFront();
            }
        }

        private ToolTip _tooltip;
        protected ToolTip Tooltip
        {
            get { return _tooltip ?? (_tooltip = new ToolTip()); }
        }

        #endregion

            #region Protected Methods

        public void CenterMe()
        {
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
        }

            #endregion

            #region Events

        public event EventHandler RequestForClose;

            #endregion

        #endregion

        #region Constructor

        public BasePopupForm()
        {
            InitializeComponent();
            lblCaption.BringToFront();
        }

        #endregion

        #region Form Events & Overrides

        protected override void OnPaint(PaintEventArgs e)
        {
            var rectBorder = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            var rectCaption = new Rectangle(2, 2, this.Width - 4, 24);
            var rectInner = new Rectangle(6, 26, this.Width - 13, this.Height - 33);
            var bgBrush = new SolidBrush(_captionToColor);
            var brushCap = new LinearGradientBrush(rectCaption, _captionFromColor, _captionToColor, LinearGradientMode.Vertical);

            e.Graphics.DrawRectangle(new Pen(_borderColor), rectBorder);
            e.Graphics.DrawRectangle(new Pen(_subBorderColor), rectBorder.Left + 1, rectBorder.Top + 1, rectBorder.Width - 2, rectBorder.Height - 2);
            e.Graphics.FillRectangle(brushCap, rectCaption);
            e.Graphics.DrawRectangle(new Pen(_subBorderColor), rectInner);
            e.Graphics.DrawRectangle(new Pen(_subBorderColor), rectInner);
            e.Graphics.DrawRectangle(new Pen(_innerBorderColor), rectInner.Left + 1, rectInner.Top + 1, rectInner.Width - 2, rectInner.Height - 2);
            e.Graphics.FillRectangle(bgBrush, 2, rectInner.Top, 4, rectInner.Height + 1);
            e.Graphics.FillRectangle(bgBrush, rectInner.Right + 1, rectInner.Top, 4, rectInner.Height + 1);
            e.Graphics.FillRectangle(bgBrush, 2, rectInner.Bottom + 1, this.Width - 4, 4);
            
            base.OnPaint(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            lblCaption.Text = this.Text;
            lblCaption.BringToFront();
        }

        protected override void OnLoad(EventArgs e)
        {
            if (_animateWindow)
            {
                AnimateWindow(this.Handle, _animateInterval, AniEffect);
            }
            base.OnLoad(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            var delat = (controlBox.ShowMaximize || controlBox.ShowMinimize) ? 0 : 51;
            lblCaption.Width = this.Width - 117 + delat;
            controlBox.Left = this.Width - 101;
            lblCaption.BringToFront();
            controlBox.SendToBack();
            this.Refresh();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (_canDragForm)
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, WmNclbuttondown, Htcaption, 0);
                }
            }
        }

        private void LblCaption_MouseDown(object sender, MouseEventArgs e)
        {
            if (_canDragForm)
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, WmNclbuttondown, Htcaption, 0);
                }
            }
        }

        void BaseMdiChildKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (RequestForClose != null) RequestForClose(this, new EventArgs());
            }
        }

        protected void TextBoxEnter(TextBox sender)
        {
            if (sender.ReadOnly) return;
            sender.BackColor = Color.LemonChiffon;
        }

        protected void TextBoxLeave(TextBox sender)
        {
            if (sender.ReadOnly) return;
            sender.BackColor = Color.White;
        }

        #endregion

        private void BasePopupForm_Activated(object sender, EventArgs e)
        {
            lblCaption.BringToFront();
        }
    }
}