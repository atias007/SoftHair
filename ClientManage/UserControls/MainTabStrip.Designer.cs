namespace ClientManage
{
    partial class MainTabStrip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainTabStrip));
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblClient = new System.Windows.Forms.Label();
            this.lblExit = new System.Windows.Forms.Label();
            this.lblCalendar = new System.Windows.Forms.Label();
            this.lblPhoneBook = new System.Windows.Forms.Label();
            this.lblReport = new System.Windows.Forms.Label();
            this.lblWorkers = new System.Windows.Forms.Label();
            this.lblBO = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(214)))), ((int)(((byte)(246)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(949, 5);
            this.label1.TabIndex = 7;
            this.label1.Paint += new System.Windows.Forms.PaintEventHandler(this.label1_Paint);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            // 
            // lblLogo
            // 
            this.lblLogo.BackColor = System.Drawing.Color.Transparent;
            this.lblLogo.Image = ((System.Drawing.Image)(resources.GetObject("lblLogo.Image")));
            this.lblLogo.Location = new System.Drawing.Point(7, 4);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(140, 35);
            this.lblLogo.TabIndex = 13;
            this.lblLogo.Click += new System.EventHandler(this.lblLogo_Click);
            // 
            // lblClient
            // 
            this.lblClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClient.BackColor = System.Drawing.Color.Transparent;
            this.lblClient.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblClient.Image = global::ClientManage.Properties.Resources.tab_client_dis;
            this.lblClient.Location = new System.Drawing.Point(831, 12);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(115, 38);
            this.lblClient.TabIndex = 8;
            this.lblClient.Click += new System.EventHandler(this.Tab_Click);
            // 
            // lblExit
            // 
            this.lblExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExit.BackColor = System.Drawing.Color.Transparent;
            this.lblExit.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblExit.Image = global::ClientManage.Properties.Resources.tab_exit_dis;
            this.lblExit.Location = new System.Drawing.Point(214, 12);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(115, 38);
            this.lblExit.TabIndex = 12;
            this.lblExit.Click += new System.EventHandler(this.Tab_Click);
            // 
            // lblCalendar
            // 
            this.lblCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCalendar.BackColor = System.Drawing.Color.Transparent;
            this.lblCalendar.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblCalendar.Image = global::ClientManage.Properties.Resources.tab_calendar_dis;
            this.lblCalendar.Location = new System.Drawing.Point(715, 12);
            this.lblCalendar.Name = "lblCalendar";
            this.lblCalendar.Size = new System.Drawing.Size(115, 38);
            this.lblCalendar.TabIndex = 11;
            this.lblCalendar.Click += new System.EventHandler(this.Tab_Click);
            // 
            // lblPhoneBook
            // 
            this.lblPhoneBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhoneBook.BackColor = System.Drawing.Color.Transparent;
            this.lblPhoneBook.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblPhoneBook.Image = ((System.Drawing.Image)(resources.GetObject("lblPhoneBook.Image")));
            this.lblPhoneBook.Location = new System.Drawing.Point(599, 12);
            this.lblPhoneBook.Name = "lblPhoneBook";
            this.lblPhoneBook.Size = new System.Drawing.Size(115, 38);
            this.lblPhoneBook.TabIndex = 10;
            this.lblPhoneBook.Click += new System.EventHandler(this.Tab_Click);
            // 
            // lblReport
            // 
            this.lblReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReport.BackColor = System.Drawing.Color.Transparent;
            this.lblReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblReport.Image = global::ClientManage.Properties.Resources.tab_reports_dis;
            this.lblReport.Location = new System.Drawing.Point(367, 12);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(115, 38);
            this.lblReport.TabIndex = 9;
            this.lblReport.Click += new System.EventHandler(this.Tab_Click);
            // 
            // lblWorkers
            // 
            this.lblWorkers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWorkers.BackColor = System.Drawing.Color.Transparent;
            this.lblWorkers.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblWorkers.Image = global::ClientManage.Properties.Resources.tab_workers_dis;
            this.lblWorkers.Location = new System.Drawing.Point(483, 12);
            this.lblWorkers.Name = "lblWorkers";
            this.lblWorkers.Size = new System.Drawing.Size(115, 38);
            this.lblWorkers.TabIndex = 14;
            this.lblWorkers.Click += new System.EventHandler(this.Tab_Click);
            // 
            // lblBO
            // 
            this.lblBO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBO.BackColor = System.Drawing.Color.Transparent;
            this.lblBO.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblBO.Image = global::ClientManage.Properties.Resources.tab_opt_dis;
            this.lblBO.Location = new System.Drawing.Point(330, 12);
            this.lblBO.Name = "lblBO";
            this.lblBO.Size = new System.Drawing.Size(36, 38);
            this.lblBO.TabIndex = 15;
            this.lblBO.Click += new System.EventHandler(this.Tab_Click);
            // 
            // MainTabStrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.lblCalendar);
            this.Controls.Add(this.lblPhoneBook);
            this.Controls.Add(this.lblReport);
            this.Controls.Add(this.lblLogo);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.lblWorkers);
            this.Controls.Add(this.lblBO);
            this.Name = "MainTabStrip";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(949, 48);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainTabStrip_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label lblReport;
        private System.Windows.Forms.Label lblPhoneBook;
        private System.Windows.Forms.Label lblCalendar;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblWorkers;
        private System.Windows.Forms.Label lblBO;
    }
}
