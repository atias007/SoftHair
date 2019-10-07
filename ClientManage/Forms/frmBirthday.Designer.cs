namespace ClientManage.Forms
{
    partial class FormBirthday
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBirthday));
            this.label1 = new System.Windows.Forms.Label();
            this.lblInfo1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnBdayReport = new ClientManage.UserControls.XPFlatButton();
            this.btnBdaySMS = new ClientManage.UserControls.XPFlatButton();
            this.pnlMarried = new System.Windows.Forms.Panel();
            this.xpFlatButton1 = new ClientManage.UserControls.XPFlatButton();
            this.xpFlatButton2 = new ClientManage.UserControls.XPFlatButton();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.lblInfo2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlBday = new System.Windows.Forms.Panel();
            this.lblDiv = new System.Windows.Forms.Label();
            this.pnlMarried.SuspendLayout();
            this.pnlBday.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Image = global::ClientManage.Properties.Resources.balloon;
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 146);
            this.label1.TabIndex = 1;
            // 
            // lblInfo1
            // 
            this.lblInfo1.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblInfo1.Location = new System.Drawing.Point(142, 11);
            this.lblInfo1.Name = "lblInfo1";
            this.lblInfo1.Size = new System.Drawing.Size(199, 27);
            this.lblInfo1.TabIndex = 3;
            this.lblInfo1.Text = "ל {0} לקוחות יש היום יום הולדת.\r\nבחר לקוח מהרשימה להצגת פרטיו";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(140, 41);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(196, 148);
            this.listBox1.TabIndex = 4;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // btnBdayReport
            // 
            this.btnBdayReport.BackColor = System.Drawing.Color.White;
            this.btnBdayReport.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBdayReport.Image = global::ClientManage.Properties.Resources.report_small;
            this.btnBdayReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBdayReport.Location = new System.Drawing.Point(31, 143);
            this.btnBdayReport.Name = "btnBdayReport";
            this.btnBdayReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBdayReport.Size = new System.Drawing.Size(103, 22);
            this.btnBdayReport.TabIndex = 59;
            this.btnBdayReport.Text = "       הצג דוח";
            this.btnBdayReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBdayReport.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // btnBdaySMS
            // 
            this.btnBdaySMS.BackColor = System.Drawing.Color.White;
            this.btnBdaySMS.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBdaySMS.Image = global::ClientManage.Properties.Resources.send_small;
            this.btnBdaySMS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBdaySMS.Location = new System.Drawing.Point(31, 167);
            this.btnBdaySMS.Name = "btnBdaySMS";
            this.btnBdaySMS.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBdaySMS.Size = new System.Drawing.Size(103, 22);
            this.btnBdaySMS.TabIndex = 60;
            this.btnBdaySMS.Text = "       שלח SMS...";
            this.btnBdaySMS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBdaySMS.Click += new System.EventHandler(this.BtnBdaySms_Click);
            // 
            // pnlMarried
            // 
            this.pnlMarried.Controls.Add(this.xpFlatButton1);
            this.pnlMarried.Controls.Add(this.xpFlatButton2);
            this.pnlMarried.Controls.Add(this.listBox2);
            this.pnlMarried.Controls.Add(this.lblInfo2);
            this.pnlMarried.Controls.Add(this.label2);
            this.pnlMarried.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMarried.Location = new System.Drawing.Point(8, 235);
            this.pnlMarried.Name = "pnlMarried";
            this.pnlMarried.Size = new System.Drawing.Size(348, 204);
            this.pnlMarried.TabIndex = 61;
            // 
            // xpFlatButton1
            // 
            this.xpFlatButton1.BackColor = System.Drawing.Color.White;
            this.xpFlatButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpFlatButton1.Image = global::ClientManage.Properties.Resources.send_small;
            this.xpFlatButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xpFlatButton1.Location = new System.Drawing.Point(31, 167);
            this.xpFlatButton1.Name = "xpFlatButton1";
            this.xpFlatButton1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.xpFlatButton1.Size = new System.Drawing.Size(103, 22);
            this.xpFlatButton1.TabIndex = 65;
            this.xpFlatButton1.Text = "       שלח SMS...";
            this.xpFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xpFlatButton1.Click += new System.EventHandler(this.XpFlatButton1_Click);
            // 
            // xpFlatButton2
            // 
            this.xpFlatButton2.BackColor = System.Drawing.Color.White;
            this.xpFlatButton2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpFlatButton2.Image = global::ClientManage.Properties.Resources.report_small;
            this.xpFlatButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xpFlatButton2.Location = new System.Drawing.Point(31, 143);
            this.xpFlatButton2.Name = "xpFlatButton2";
            this.xpFlatButton2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.xpFlatButton2.Size = new System.Drawing.Size(103, 22);
            this.xpFlatButton2.TabIndex = 64;
            this.xpFlatButton2.Text = "       הצג דוח";
            this.xpFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xpFlatButton2.Click += new System.EventHandler(this.XpFlatButton2_Click);
            // 
            // listBox2
            // 
            this.listBox2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Location = new System.Drawing.Point(140, 41);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(196, 148);
            this.listBox2.TabIndex = 63;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.ListBox2_SelectedIndexChanged);
            // 
            // lblInfo2
            // 
            this.lblInfo2.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblInfo2.Location = new System.Drawing.Point(142, 11);
            this.lblInfo2.Name = "lblInfo2";
            this.lblInfo2.Size = new System.Drawing.Size(199, 27);
            this.lblInfo2.TabIndex = 62;
            this.lblInfo2.Text = "ל {0} לקוחות יש היום יום נישואין.\r\nבחר לקוח מהרשימה להצגת פרטיו";
            // 
            // label2
            // 
            this.label2.Image = global::ClientManage.Properties.Resources.married;
            this.label2.Location = new System.Drawing.Point(8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 146);
            this.label2.TabIndex = 61;
            // 
            // pnlBday
            // 
            this.pnlBday.Controls.Add(this.btnBdaySMS);
            this.pnlBday.Controls.Add(this.listBox1);
            this.pnlBday.Controls.Add(this.btnBdayReport);
            this.pnlBday.Controls.Add(this.lblInfo1);
            this.pnlBday.Controls.Add(this.label1);
            this.pnlBday.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBday.Location = new System.Drawing.Point(8, 28);
            this.pnlBday.Name = "pnlBday";
            this.pnlBday.Size = new System.Drawing.Size(348, 204);
            this.pnlBday.TabIndex = 62;
            // 
            // lblDiv
            // 
            this.lblDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(149)))), ((int)(((byte)(171)))));
            this.lblDiv.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDiv.Location = new System.Drawing.Point(8, 232);
            this.lblDiv.Name = "lblDiv";
            this.lblDiv.Size = new System.Drawing.Size(348, 3);
            this.lblDiv.TabIndex = 63;
            // 
            // frmBirthday
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(364, 447);
            this.CloseFormByEsc = true;
            this.ControlBox = false;
            this.Controls.Add(this.pnlMarried);
            this.Controls.Add(this.lblDiv);
            this.Controls.Add(this.pnlBday);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBirthday";
            this.Padding = new System.Windows.Forms.Padding(8, 28, 8, 8);
            this.ShowInTaskbar = false;
            this.ShowMaximizeControl = false;
            this.ShowMinimizeControl = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "תזכורת יום הולדת ונישואין";
            this.RequestForClose += new System.EventHandler(this.FrmBirthday_RequestForClose);
            this.Controls.SetChildIndex(this.pnlBday, 0);
            this.Controls.SetChildIndex(this.lblDiv, 0);
            this.Controls.SetChildIndex(this.pnlMarried, 0);
            this.pnlMarried.ResumeLayout(false);
            this.pnlBday.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInfo1;
        private System.Windows.Forms.ListBox listBox1;
        private ClientManage.UserControls.XPFlatButton btnBdayReport;
        private ClientManage.UserControls.XPFlatButton btnBdaySMS;
        private System.Windows.Forms.Panel pnlMarried;
        private ClientManage.UserControls.XPFlatButton xpFlatButton1;
        private ClientManage.UserControls.XPFlatButton xpFlatButton2;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInfo2;
        private System.Windows.Forms.Panel pnlBday;
        private System.Windows.Forms.Label lblDiv;
    }
}