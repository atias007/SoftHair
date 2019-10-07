namespace ClientManage.UserControls
{
    partial class DigitalClock
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            ShowTimer.Stop();
            ColonTimer.Stop();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            ShowTimer.Dispose();
            ColonTimer.Dispose();
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ColonTimer = new System.Windows.Forms.Timer(this.components);
            this.ShowTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ColonTimer
            // 
            this.ColonTimer.Interval = 10000;
            this.ColonTimer.Tick += new System.EventHandler(this.OnColonTimer);
            // 
            // ShowTimer
            // 
            this.ShowTimer.Interval = 10000;
            this.ShowTimer.Tick += new System.EventHandler(this.OnClockTimer);
            // 
            // DigitalClock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Name = "DigitalClock";
            this.Size = new System.Drawing.Size(354, 70);
            this.Load += new System.EventHandler(this.OnLoad);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DigitalClock_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer ColonTimer;
        private System.Windows.Forms.Timer ShowTimer;
    }
}
