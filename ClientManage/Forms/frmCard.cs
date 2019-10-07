using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace ClientManage.Forms
{
    public partial class FormCard : BasePopupForm
    {
        public enum CardEntityType { Client, Worke };
        private readonly CardEntityType _entityType;

        private const string EntityTitle1 = "לקוח";
        private const string EntityTitle2 = "עובד";

        private const string EntityCardTitle1 = "לקוח / מועדון";
        private const string EntityCardTitle2 = "עובד";

        public FormCard(CardEntityType entityType)
        {
            _entityType = entityType;
            InitializeComponent();

            switch (_entityType)
            {
                case CardEntityType.Client:
                    this.Text = string.Format(this.Text, EntityCardTitle1);
                    lblTitle.Text = string.Format(lblTitle.Text, EntityCardTitle1);
                    lblError.Text = string.Format(lblError.Text, EntityTitle1);
                    break;

                case CardEntityType.Worke:
                    this.Text = string.Format(this.Text, EntityCardTitle2);
                    lblTitle.Text = string.Format(lblTitle.Text, EntityCardTitle2);
                    lblError.Text = string.Format(lblError.Text, EntityTitle2);
                    break;

                default:
                    throw new ArgumentOutOfRangeException("entityType");
            }
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void Button1Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ShowErrorMessage(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
            timer1.Enabled = false;
            timer1.Enabled = true;
            
            SystemSounds.Beep.Play();
        }

        private void Timer1Tick(object sender, EventArgs e)
        {
            lblError.Visible = false;
            timer1.Enabled = false;
        }

        private void LblErrorPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(85, 22, 22)), 0, 0, lblError.Width - 1, lblError.Height - 1);
        }

        private void Button1Enter(object sender, EventArgs e)
        {
            textBox1.Select();
            textBox1.Focus();
        }

        private void Button1MouseUp(object sender, MouseEventArgs e)
        {
            textBox1.Select();
            textBox1.Focus();
        }
    }
}

