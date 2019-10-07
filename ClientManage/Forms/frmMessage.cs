using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ClientManage.Library;

namespace ClientManage.Forms
{
    public partial class FormMessage : BasePopupForm
    {
        private readonly MyMessageBox _myMessageBox;
        private Color _toColor = Color.Snow;
        private Timer _closeTimer;

        public FormMessage(MyMessageBox myMessageBox)
        {
            _myMessageBox = myMessageBox;
            InitializeComponent();
            InitializeMe();
        }

        private void FrmMessage_Paint(object sender, PaintEventArgs e)
        {
            var rectInner = new Rectangle(6, 26, this.Width - 13, this.Height - 33);
            var graRect = new Rectangle(rectInner.Left + 2, rectInner.Bottom - 61, rectInner.Width - 4, 60);
            var brush = new LinearGradientBrush(graRect, Color.White, _toColor, LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(brush, graRect);
            e.Graphics.DrawLine(Pens.Snow, graRect.Left, graRect.Y, graRect.Right, graRect.Y);
        }

        private void ArrangeButtons(Button b1)
        {
            pnlButtons.Controls.Add(b1);
            b1.Location = new Point(3, 3);
            pnlButtons.Width = b1.Left + b1.Width + 3;
            ArrangeButtonPannel();
        }

        private void ArrangeButtons(Button b1, Button b2)
        {
            pnlButtons.Controls.Add(b1);
            pnlButtons.Controls.Add(b2);
            b2.Location = new Point(3, 3);
            b1.Location = new Point(b2.Left + b2.Width + 3, 3);
            pnlButtons.Width = b1.Left + b1.Width + 3;
            ArrangeButtonPannel();
        }

        private void ArrangeButtons(Button b1, Button b2, Button b3)
        {
            pnlButtons.Controls.Add(b1);
            pnlButtons.Controls.Add(b2);
            pnlButtons.Controls.Add(b3);
            b3.Location = new Point(3, 3);
            b2.Location = new Point(b3.Left + b3.Width + 3, 3);
            b1.Location = new Point(b2.Left + b2.Width + 3, 3);
            pnlButtons.Width = b1.Left + b1.Width + 3;
            ArrangeButtonPannel();
        }

        private void ArrangeButtonPannel()
        {
            pnlButtons.Left = (this.Width - pnlButtons.Width) / 2;
        }

        public void InitializeMe()
        {
            #region Size & Location

            var g = this.CreateGraphics();
            var size = g.MeasureString(_myMessageBox.Text, _myMessageBox.MessageFont);

            lblMessage.Width = Convert.ToInt32(size.Width) + 55 + _myMessageBox.ExtraSize.Width;
            lblMessage.Height = Convert.ToInt32(size.Height) + 16 + _myMessageBox.ExtraSize.Height;
            if (lblMessage.Height < 52) lblMessage.Height = 52;
            if (lblMessage.Width < 200) lblMessage.Width = 200;

            if (_myMessageBox.MessageButtons != MyMessageBox.MyMessageButton.None)
            {
                pnlButtons.Top = lblMessage.Height + lblMessage.Top + 8;
            }
            else
            {
                pnlButtons.Top = lblMessage.Height + lblMessage.Top - pnlButtons.Height + 8;
            }

            this.Width = (lblMessage.Left * 2) + lblMessage.Width;
            this.Height = pnlButtons.Top + pnlButtons.Height + 16;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;

            this.MaximumSize = this.Size;

            #endregion

            #region Color & Icon & Sound

            switch (_myMessageBox.MessageType)
            {
                case MyMessageBox.MyMessageType.Stop:
                    lblMessage.Image = Properties.Resources.msg_att;
                    _toColor = Color.FromArgb(253, 211, 211);
                    break;

                case MyMessageBox.MyMessageType.Error:
                    lblMessage.Image = Properties.Resources.msg_err;
                    _toColor = Color.FromArgb(253, 211, 211);
                    break;

                case MyMessageBox.MyMessageType.Information:
                    lblMessage.Image = Properties.Resources.msg_inf;
                    _toColor = Color.FromArgb(204, 222, 232);
                    break;

                case MyMessageBox.MyMessageType.Question:
                    lblMessage.Image = Properties.Resources.msg_qst;
                    _toColor = Color.FromArgb(204, 222, 232);
                    break;

                case MyMessageBox.MyMessageType.Confirm:
                    lblMessage.Image = Properties.Resources.msg_ok;
                    _toColor = Color.FromArgb(191, 255, 173);
                    break;

                case MyMessageBox.MyMessageType.Warning:
                    lblMessage.Image = Properties.Resources.msg_wrn;
                    _toColor = Color.FromArgb(255, 255, 162);
                    break;
            }

            #endregion

            #region Buttons

            Button b1, b2;
            pnlButtons.Visible = true;

            switch (_myMessageBox.MessageButtons)
            {
                case MyMessageBox.MyMessageButton.None:
                    _closeTimer = new Timer {Interval = _myMessageBox.CloseInterval};
                    _closeTimer.Tick += CloseTimer_Tick;
                    _closeTimer.Enabled = true;
                    pnlButtons.Visible = false;
                    CloseButtonResult = DialogResult.None;
                    break;

                case MyMessageBox.MyMessageButton.Ok:
                    b1 = new Button {Size = new Size(87, 29), DialogResult = DialogResult.OK, Text = "אישור"};
                    ArrangeButtons(b1);
                    CloseButtonResult = DialogResult.OK;
                    break;

                case MyMessageBox.MyMessageButton.YesNo:
                    b1 = new Button {Size = new Size(87, 29), DialogResult = DialogResult.Yes, Text = "כן"};
                    b2 = new Button {Size = new Size(87, 29), DialogResult = DialogResult.No, Text = "לא"};
                    this.CancelButton = b2;
                    ArrangeButtons(b1, b2);
                    break;

                case MyMessageBox.MyMessageButton.YesNoCancel:
                    b1 = new Button {Size = new Size(87, 29), DialogResult = DialogResult.Yes, Text = "כן"};
                    b2 = new Button {Size = new Size(87, 29), DialogResult = DialogResult.No, Text = "לא"};
                    this.CancelButton = b2;
                    var b3 = new Button {Size = new Size(87, 29), DialogResult = DialogResult.Cancel, Text = "ביטול"};
                    ArrangeButtons(b1, b2, b3);
                    break;
            }

            if (_myMessageBox.MessageButtons != MyMessageBox.MyMessageButton.None)
            {
                if (pnlButtons.Controls.Count > 0)
                {
                    try
                    {
                        pnlButtons.Controls[Convert.ToInt32(_myMessageBox.MessageDefaultButton)].Select();
                    }
                    catch
                    {
                        pnlButtons.Controls[pnlButtons.Controls.Count - 1].Select();
                    }
                }
            }

            #endregion

            #region Text & Caption

            this.Text = _myMessageBox.Caption;
            lblMessage.Text = _myMessageBox.Text;
            lblMessage.Font = _myMessageBox.MessageFont;

            #endregion
        }

        void CloseTimer_Tick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            this.Close();
        }
    }
}