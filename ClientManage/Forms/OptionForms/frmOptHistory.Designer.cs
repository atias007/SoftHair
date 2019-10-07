namespace ClientManage.Forms.OptionForms
{
    partial class FormOptHistory
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
            this.cmbClearSMS = new System.Windows.Forms.ComboBox();
            this.label90 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.lblLastClean = new System.Windows.Forms.Label();
            this.cmbCleanTraffic = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.cmbCleanCallLog = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.cmbCleanCal = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbClearSMS
            // 
            this.cmbClearSMS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClearSMS.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbClearSMS.FormattingEnabled = true;
            this.cmbClearSMS.Items.AddRange(new object[] {
            "12",
            "18",
            "24",
            "30",
            "36",
            "32",
            "48"});
            this.cmbClearSMS.Location = new System.Drawing.Point(157, 134);
            this.cmbClearSMS.Name = "cmbClearSMS";
            this.cmbClearSMS.Size = new System.Drawing.Size(55, 22);
            this.cmbClearSMS.TabIndex = 47;
            // 
            // label90
            // 
            this.label90.Location = new System.Drawing.Point(218, 137);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(100, 19);
            this.label90.TabIndex = 49;
            this.label90.Text = "חודשים";
            // 
            // label91
            // 
            this.label91.Location = new System.Drawing.Point(12, 137);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(155, 19);
            this.label91.TabIndex = 48;
            this.label91.Text = "הסר רישום SMS לאחר";
            // 
            // lblLastClean
            // 
            this.lblLastClean.BackColor = System.Drawing.Color.Transparent;
            this.lblLastClean.ForeColor = System.Drawing.Color.Maroon;
            this.lblLastClean.Location = new System.Drawing.Point(12, 163);
            this.lblLastClean.Name = "lblLastClean";
            this.lblLastClean.Size = new System.Drawing.Size(613, 19);
            this.lblLastClean.TabIndex = 46;
            this.lblLastClean.Text = "ניקוי בסיס הנתונים בוצע לאחרונה בתאריך {0}";
            // 
            // cmbCleanTraffic
            // 
            this.cmbCleanTraffic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCleanTraffic.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbCleanTraffic.FormattingEnabled = true;
            this.cmbCleanTraffic.Items.AddRange(new object[] {
            "12",
            "18",
            "24",
            "30",
            "36",
            "32",
            "48"});
            this.cmbCleanTraffic.Location = new System.Drawing.Point(157, 109);
            this.cmbCleanTraffic.Name = "cmbCleanTraffic";
            this.cmbCleanTraffic.Size = new System.Drawing.Size(55, 22);
            this.cmbCleanTraffic.TabIndex = 39;
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(218, 112);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(100, 19);
            this.label31.TabIndex = 45;
            this.label31.Text = "חודשים";
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(12, 112);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(155, 19);
            this.label32.TabIndex = 44;
            this.label32.Text = "הסר דיווחי נוכחות לאחר";
            // 
            // cmbCleanCallLog
            // 
            this.cmbCleanCallLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCleanCallLog.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbCleanCallLog.FormattingEnabled = true;
            this.cmbCleanCallLog.Items.AddRange(new object[] {
            "12",
            "18",
            "24",
            "30",
            "36",
            "32",
            "48"});
            this.cmbCleanCallLog.Location = new System.Drawing.Point(157, 84);
            this.cmbCleanCallLog.Name = "cmbCleanCallLog";
            this.cmbCleanCallLog.Size = new System.Drawing.Size(55, 22);
            this.cmbCleanCallLog.TabIndex = 38;
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(218, 87);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(100, 19);
            this.label29.TabIndex = 43;
            this.label29.Text = "חודשים";
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(12, 87);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(155, 19);
            this.label30.TabIndex = 42;
            this.label30.Text = "הסר רישום שיחות לאחר";
            // 
            // cmbCleanCal
            // 
            this.cmbCleanCal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCleanCal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbCleanCal.FormattingEnabled = true;
            this.cmbCleanCal.Items.AddRange(new object[] {
            "12",
            "18",
            "24",
            "30",
            "36",
            "32",
            "48"});
            this.cmbCleanCal.Location = new System.Drawing.Point(157, 59);
            this.cmbCleanCal.Name = "cmbCleanCal";
            this.cmbCleanCal.Size = new System.Drawing.Size(55, 22);
            this.cmbCleanCal.TabIndex = 37;
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(218, 62);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(100, 19);
            this.label27.TabIndex = 41;
            this.label27.Text = "חודשים";
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(12, 62);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(155, 19);
            this.label28.TabIndex = 40;
            this.label28.Text = "הסר תורים מהיומן לאחר";
            // 
            // frmOptHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 620);
            this.Controls.Add(this.cmbClearSMS);
            this.Controls.Add(this.label90);
            this.Controls.Add(this.label91);
            this.Controls.Add(this.lblLastClean);
            this.Controls.Add(this.cmbCleanTraffic);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.cmbCleanCallLog);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.cmbCleanCal);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label28);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmOptHistory";
            this.Text = "frmHistory";
            this.Controls.SetChildIndex(this.label28, 0);
            this.Controls.SetChildIndex(this.label27, 0);
            this.Controls.SetChildIndex(this.cmbCleanCal, 0);
            this.Controls.SetChildIndex(this.label30, 0);
            this.Controls.SetChildIndex(this.label29, 0);
            this.Controls.SetChildIndex(this.cmbCleanCallLog, 0);
            this.Controls.SetChildIndex(this.label32, 0);
            this.Controls.SetChildIndex(this.label31, 0);
            this.Controls.SetChildIndex(this.cmbCleanTraffic, 0);
            this.Controls.SetChildIndex(this.lblLastClean, 0);
            this.Controls.SetChildIndex(this.label91, 0);
            this.Controls.SetChildIndex(this.label90, 0);
            this.Controls.SetChildIndex(this.cmbClearSMS, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbClearSMS;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.Label lblLastClean;
        private System.Windows.Forms.ComboBox cmbCleanTraffic;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.ComboBox cmbCleanCallLog;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox cmbCleanCal;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
    }
}