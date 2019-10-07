namespace BizCare.Calendar
{
    partial class WorkerPanel
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkerPanel));
            this.pnlTodayEvents = new System.Windows.Forms.Panel();
            this.pnlAllDayEvents = new System.Windows.Forms.Panel();
            this.pnlDayTitle = new System.Windows.Forms.Panel();
            this.lblDayCaption2 = new System.Windows.Forms.Label();
            this.TTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlDayTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTodayEvents
            // 
            this.pnlTodayEvents.BackColor = System.Drawing.Color.White;
            this.pnlTodayEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTodayEvents.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.pnlTodayEvents.Location = new System.Drawing.Point(1, 41);
            this.pnlTodayEvents.Name = "pnlTodayEvents";
            this.pnlTodayEvents.Size = new System.Drawing.Size(230, 473);
            this.pnlTodayEvents.TabIndex = 101;
            this.pnlTodayEvents.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTodayEvents_Paint);
            this.pnlTodayEvents.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pnlTodayEvents_MouseDoubleClick);
            this.pnlTodayEvents.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTodayEvents_MouseDown);
            this.pnlTodayEvents.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTodayEvents_MouseMove);
            this.pnlTodayEvents.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlTodayEvents_MouseUp);
            this.pnlTodayEvents.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pnlTodayEvents_PreviewKeyDown);
            // 
            // pnlAllDayEvents
            // 
            this.pnlAllDayEvents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(191)))), ((int)(((byte)(225)))));
            this.pnlAllDayEvents.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAllDayEvents.Location = new System.Drawing.Point(1, 19);
            this.pnlAllDayEvents.Name = "pnlAllDayEvents";
            this.pnlAllDayEvents.Size = new System.Drawing.Size(230, 22);
            this.pnlAllDayEvents.TabIndex = 100;
            this.pnlAllDayEvents.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlAllDayEvents_Paint);
            this.pnlAllDayEvents.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pnlAllDayEvents_MouseDoubleClick);
            this.pnlAllDayEvents.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlAllDayEvents_MouseDown);
            // 
            // pnlDayTitle
            // 
            this.pnlDayTitle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlDayTitle.BackgroundImage")));
            this.pnlDayTitle.Controls.Add(this.lblDayCaption2);
            this.pnlDayTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDayTitle.Location = new System.Drawing.Point(1, 1);
            this.pnlDayTitle.Name = "pnlDayTitle";
            this.pnlDayTitle.Size = new System.Drawing.Size(230, 18);
            this.pnlDayTitle.TabIndex = 101;
            // 
            // lblDayCaption2
            // 
            this.lblDayCaption2.BackColor = System.Drawing.Color.Transparent;
            this.lblDayCaption2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDayCaption2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblDayCaption2.Location = new System.Drawing.Point(0, 0);
            this.lblDayCaption2.Name = "lblDayCaption2";
            this.lblDayCaption2.Size = new System.Drawing.Size(230, 18);
            this.lblDayCaption2.TabIndex = 102;
            this.lblDayCaption2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblDayCaption2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lblDayCaption2_MouseDoubleClick);
            this.lblDayCaption2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblDayCaption2_MouseDown);
            this.lblDayCaption2.MouseEnter += new System.EventHandler(this.lblDayCaption2_MouseEnter);
            this.lblDayCaption2.MouseLeave += new System.EventHandler(this.lblDayCaption2_MouseLeave);
            // 
            // TTip
            // 
            this.TTip.AutomaticDelay = 1;
            this.TTip.AutoPopDelay = 10000;
            this.TTip.InitialDelay = 1;
            this.TTip.IsBalloon = true;
            this.TTip.ReshowDelay = 1;
            this.TTip.ShowAlways = true;
            this.TTip.StripAmpersands = true;
            this.TTip.UseAnimation = false;
            this.TTip.UseFading = false;
            // 
            // WorkerPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(140)))), ((int)(((byte)(201)))));
            this.Controls.Add(this.pnlTodayEvents);
            this.Controls.Add(this.pnlAllDayEvents);
            this.Controls.Add(this.pnlDayTitle);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Name = "WorkerPanel";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(232, 515);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.WorkerPanel_Paint);
            this.Enter += new System.EventHandler(this.WorkerPanel_Enter);
            this.pnlDayTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTodayEvents;
        private System.Windows.Forms.Panel pnlAllDayEvents;
        private System.Windows.Forms.Panel pnlDayTitle;
        private System.Windows.Forms.Label lblDayCaption2;
        internal System.Windows.Forms.ToolTip TTip;
    }
}
