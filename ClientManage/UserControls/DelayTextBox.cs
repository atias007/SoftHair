using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Timers;

namespace ClientManage.UserControls
{
    public partial class DelayTextBox : System.Windows.Forms.TextBox
    {
        private readonly Timer delayTimer;
        private int _threshold = 1000;
        private bool keysPressed = false;
        private bool timerElapsed = false;
        public delegate void DelayOverHandler();

        public int Delay
        {
            get { return _threshold; }
            set{_threshold = value;}
        }

        public DelayTextBox()
        {
            if (_threshold > 0)
            {
                delayTimer = new System.Timers.Timer(_threshold);
                delayTimer.Elapsed += new ElapsedEventHandler(delayTimer_Elapsed);
            }
        }

        void delayTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (timerElapsed) return;

            delayTimer.Enabled = false;
            timerElapsed = true;

            this.Invoke(new DelayOverHandler(DelayOver), null);
        }

        public void ResetDelayTimer()
        {
            delayTimer.Enabled = false;
            timerElapsed = true;
        }

        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (_threshold > 0)
            {
                if (!delayTimer.Enabled)
                {
                    delayTimer.Enabled = true;
                }
                else
                {
                    delayTimer.Enabled = false;
                    delayTimer.Enabled = true;
                }

                keysPressed = true;
            }
            base.OnKeyPress(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (_threshold > 0)
            {
                if (timerElapsed || !keysPressed)
                {
                    timerElapsed = false;
                    keysPressed = false;
                    base.OnTextChanged(e);
                }
            }
            else
            {
                base.OnTextChanged(e);
            }
        }

        public void DelayOver()
        {
            if (_threshold > 0)
            {
                OnTextChanged(new EventArgs());
            }
        }
    }
}
