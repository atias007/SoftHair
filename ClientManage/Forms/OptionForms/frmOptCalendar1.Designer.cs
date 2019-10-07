namespace ClientManage.Forms.OptionForms
{
    partial class FormOptCalendar1
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
            this.cmbCalSound = new System.Windows.Forms.ComboBox();
            this.chkShowRemHistory = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.nudCalAttachTimeout = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbCalRemainder = new System.Windows.Forms.ComboBox();
            this.cmbCalEndHour = new System.Windows.Forms.ComboBox();
            this.cmbCalEndMin = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbCalStartHour = new System.Windows.Forms.ComboBox();
            this.cmbCalStartMin = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnPlaySoundCal = new System.Windows.Forms.Button();
            this.chkSyncEvents = new System.Windows.Forms.CheckBox();
            this.txtCalId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudCalAttachTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCalSound
            // 
            this.cmbCalSound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCalSound.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbCalSound.FormattingEnabled = true;
            this.cmbCalSound.Location = new System.Drawing.Point(208, 536);
            this.cmbCalSound.Name = "cmbCalSound";
            this.cmbCalSound.Size = new System.Drawing.Size(146, 22);
            this.cmbCalSound.TabIndex = 48;
            this.cmbCalSound.Visible = false;
            this.cmbCalSound.SelectedIndexChanged += new System.EventHandler(this.cmbCalSound_SelectedIndexChanged);
            // 
            // chkShowRemHistory
            // 
            this.chkShowRemHistory.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chkShowRemHistory.Location = new System.Drawing.Point(12, 568);
            this.chkShowRemHistory.Name = "chkShowRemHistory";
            this.chkShowRemHistory.Size = new System.Drawing.Size(388, 19);
            this.chkShowRemHistory.TabIndex = 34;
            this.chkShowRemHistory.Text = "הצג היסטורית הערות ללקוח, בחלון פרטי תור";
            this.chkShowRemHistory.UseVisualStyleBackColor = true;
            this.chkShowRemHistory.Visible = false;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(12, 539);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(155, 19);
            this.label21.TabIndex = 47;
            this.label21.Text = "צליל בהופעת תזכורת";
            this.label21.Visible = false;
            // 
            // nudCalAttachTimeout
            // 
            this.nudCalAttachTimeout.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.nudCalAttachTimeout.Location = new System.Drawing.Point(221, 116);
            this.nudCalAttachTimeout.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudCalAttachTimeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCalAttachTimeout.Name = "nudCalAttachTimeout";
            this.nudCalAttachTimeout.Size = new System.Drawing.Size(45, 23);
            this.nudCalAttachTimeout.TabIndex = 33;
            this.nudCalAttachTimeout.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(269, 119);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(208, 19);
            this.label19.TabIndex = 46;
            this.label19.Text = "דקות (שבהן לא בוצע שיוך כלשהו)";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(12, 119);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(221, 19);
            this.label20.TabIndex = 45;
            this.label20.Text = "הסתר הודעת שיוך לקוח לתור לאחר";
            // 
            // cmbCalRemainder
            // 
            this.cmbCalRemainder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCalRemainder.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbCalRemainder.FormattingEnabled = true;
            this.cmbCalRemainder.Location = new System.Drawing.Point(208, 508);
            this.cmbCalRemainder.Name = "cmbCalRemainder";
            this.cmbCalRemainder.Size = new System.Drawing.Size(146, 22);
            this.cmbCalRemainder.TabIndex = 42;
            this.cmbCalRemainder.Visible = false;
            // 
            // cmbCalEndHour
            // 
            this.cmbCalEndHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCalEndHour.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbCalEndHour.FormattingEnabled = true;
            this.cmbCalEndHour.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.cmbCalEndHour.Location = new System.Drawing.Point(259, 85);
            this.cmbCalEndHour.Name = "cmbCalEndHour";
            this.cmbCalEndHour.Size = new System.Drawing.Size(42, 22);
            this.cmbCalEndHour.TabIndex = 43;
            // 
            // cmbCalEndMin
            // 
            this.cmbCalEndMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCalEndMin.Enabled = false;
            this.cmbCalEndMin.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbCalEndMin.FormattingEnabled = true;
            this.cmbCalEndMin.Items.AddRange(new object[] {
            "00"});
            this.cmbCalEndMin.Location = new System.Drawing.Point(208, 84);
            this.cmbCalEndMin.Name = "cmbCalEndMin";
            this.cmbCalEndMin.Size = new System.Drawing.Size(42, 22);
            this.cmbCalEndMin.TabIndex = 41;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label15.Location = new System.Drawing.Point(249, 87);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(8, 19);
            this.label15.TabIndex = 44;
            this.label15.Text = ":";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(360, 511);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(100, 19);
            this.label18.TabIndex = 39;
            this.label18.Text = "לפני התרחשותו";
            this.label18.Visible = false;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(12, 511);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(155, 19);
            this.label17.TabIndex = 40;
            this.label17.Text = "קבע תזכורת לתור חדש";
            this.label17.Visible = false;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(12, 88);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(203, 19);
            this.label16.TabIndex = 38;
            this.label16.Text = "שעת סיום של יום עבודה ביומן";
            // 
            // cmbCalStartHour
            // 
            this.cmbCalStartHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCalStartHour.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbCalStartHour.FormattingEnabled = true;
            this.cmbCalStartHour.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.cmbCalStartHour.Location = new System.Drawing.Point(259, 57);
            this.cmbCalStartHour.Name = "cmbCalStartHour";
            this.cmbCalStartHour.Size = new System.Drawing.Size(42, 22);
            this.cmbCalStartHour.TabIndex = 36;
            // 
            // cmbCalStartMin
            // 
            this.cmbCalStartMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCalStartMin.Enabled = false;
            this.cmbCalStartMin.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbCalStartMin.FormattingEnabled = true;
            this.cmbCalStartMin.Items.AddRange(new object[] {
            "00"});
            this.cmbCalStartMin.Location = new System.Drawing.Point(208, 57);
            this.cmbCalStartMin.Name = "cmbCalStartMin";
            this.cmbCalStartMin.Size = new System.Drawing.Size(42, 22);
            this.cmbCalStartMin.TabIndex = 35;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label13.Location = new System.Drawing.Point(249, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(8, 19);
            this.label13.TabIndex = 37;
            this.label13.Text = ":";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(12, 62);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(203, 19);
            this.label12.TabIndex = 32;
            this.label12.Text = "שעת התחלה של יום עבודה ביומן";
            // 
            // btnPlaySoundCal
            // 
            this.btnPlaySoundCal.Image = global::ClientManage.Properties.Resources.play2;
            this.btnPlaySoundCal.Location = new System.Drawing.Point(354, 535);
            this.btnPlaySoundCal.Name = "btnPlaySoundCal";
            this.btnPlaySoundCal.Size = new System.Drawing.Size(23, 24);
            this.btnPlaySoundCal.TabIndex = 49;
            this.btnPlaySoundCal.UseVisualStyleBackColor = true;
            this.btnPlaySoundCal.Visible = false;
            this.btnPlaySoundCal.Click += new System.EventHandler(this.btnPlaySoundCal_Click);
            // 
            // chkSyncEvents
            // 
            this.chkSyncEvents.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chkSyncEvents.Location = new System.Drawing.Point(12, 589);
            this.chkSyncEvents.Name = "chkSyncEvents";
            this.chkSyncEvents.Size = new System.Drawing.Size(388, 19);
            this.chkSyncEvents.TabIndex = 34;
            this.chkSyncEvents.Tag = "SuperUser";
            this.chkSyncEvents.Text = "סנכרן אירועים לשרת";
            this.chkSyncEvents.UseVisualStyleBackColor = true;
            this.chkSyncEvents.Visible = false;
            // 
            // txtCalId
            // 
            this.txtCalId.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCalId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtCalId.Location = new System.Drawing.Point(83, 144);
            this.txtCalId.MaxLength = 255;
            this.txtCalId.Name = "txtCalId";
            this.txtCalId.ReadOnly = true;
            this.txtCalId.Size = new System.Drawing.Size(383, 22);
            this.txtCalId.TabIndex = 50;
            this.txtCalId.Tag = "SuperUser";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 14);
            this.label2.TabIndex = 51;
            this.label2.Text = "מזהה יומן";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 14);
            this.label3.TabIndex = 52;
            this.label3.Text = "ייבא תורים";
            // 
            // txtDays
            // 
            this.txtDays.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDays.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtDays.Location = new System.Drawing.Point(83, 172);
            this.txtDays.MaxLength = 255;
            this.txtDays.Name = "txtDays";
            this.txtDays.ReadOnly = true;
            this.txtDays.Size = new System.Drawing.Size(69, 22);
            this.txtDays.TabIndex = 53;
            this.txtDays.Tag = "SuperUser";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 14);
            this.label4.TabIndex = 54;
            this.label4.Text = "ימים אחרונים";
            // 
            // btnImport
            // 
            this.btnImport.Enabled = false;
            this.btnImport.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnImport.Image = global::ClientManage.Properties.Resources.change;
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.Location = new System.Drawing.Point(15, 200);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(137, 51);
            this.btnImport.TabIndex = 56;
            this.btnImport.Tag = "SuperUser";
            this.btnImport.Text = "ייבא תורים   ";
            this.btnImport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(12, 254);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(283, 24);
            this.lblStatus.TabIndex = 57;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button1.Image = global::ClientManage.Properties.Resources.change;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(158, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 51);
            this.button1.TabIndex = 58;
            this.button1.Tag = "SuperUser";
            this.button1.Text = "נקה אזור זמן";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormOptCalendar1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 620);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDays);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCalId);
            this.Controls.Add(this.cmbCalSound);
            this.Controls.Add(this.chkSyncEvents);
            this.Controls.Add(this.chkShowRemHistory);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.nudCalAttachTimeout);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.cmbCalRemainder);
            this.Controls.Add(this.cmbCalEndHour);
            this.Controls.Add(this.cmbCalEndMin);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cmbCalStartHour);
            this.Controls.Add(this.cmbCalStartMin);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnPlaySoundCal);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormOptCalendar1";
            this.Text = "frmCalendar1";
            this.Controls.SetChildIndex(this.btnPlaySoundCal, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.cmbCalStartMin, 0);
            this.Controls.SetChildIndex(this.cmbCalStartHour, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.label17, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.cmbCalEndMin, 0);
            this.Controls.SetChildIndex(this.cmbCalEndHour, 0);
            this.Controls.SetChildIndex(this.cmbCalRemainder, 0);
            this.Controls.SetChildIndex(this.label20, 0);
            this.Controls.SetChildIndex(this.label19, 0);
            this.Controls.SetChildIndex(this.nudCalAttachTimeout, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.chkShowRemHistory, 0);
            this.Controls.SetChildIndex(this.chkSyncEvents, 0);
            this.Controls.SetChildIndex(this.cmbCalSound, 0);
            this.Controls.SetChildIndex(this.txtCalId, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtDays, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.btnImport, 0);
            this.Controls.SetChildIndex(this.lblStatus, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nudCalAttachTimeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCalSound;
        private System.Windows.Forms.CheckBox chkShowRemHistory;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown nudCalAttachTimeout;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbCalRemainder;
        private System.Windows.Forms.ComboBox cmbCalEndHour;
        private System.Windows.Forms.ComboBox cmbCalEndMin;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbCalStartHour;
        private System.Windows.Forms.ComboBox cmbCalStartMin;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnPlaySoundCal;
        private System.Windows.Forms.CheckBox chkSyncEvents;
        private System.Windows.Forms.TextBox txtCalId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button button1;
    }
}