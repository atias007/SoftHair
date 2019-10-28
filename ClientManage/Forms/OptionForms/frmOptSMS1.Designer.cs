namespace ClientManage.Forms.OptionForms
{
    partial class FormOptSms1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOptSms1));
            this.lblCheckStatus = new System.Windows.Forms.Label();
            this.cmbMarrSMSMsg = new System.Windows.Forms.ComboBox();
            this.cmbBdaySMSMsg = new System.Windows.Forms.ComboBox();
            this.chkAutoMarrSMS = new System.Windows.Forms.CheckBox();
            this.chkAutoBdaySMS = new System.Windows.Forms.CheckBox();
            this.txtSmsWS2 = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.txtSmsPassword = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.txtSmsUserName = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.txtSmsFrom = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.txtSmsMaxChars = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.btnResetBday = new System.Windows.Forms.Button();
            this.btnResetMarried = new System.Windows.Forms.Button();
            this.chkAutoCalSms = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblCalLastSend = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSmsTo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSmsFrom = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCalMessage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.txtCheckException = new System.Windows.Forms.TextBox();
            this.lblLastMer = new System.Windows.Forms.Label();
            this.txtCalRemindMessage = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUniqueId = new System.Windows.Forms.TextBox();
            this.btnUniqueId = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblBdayLast = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCheckStatus
            // 
            this.lblCheckStatus.AutoEllipsis = true;
            this.lblCheckStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblCheckStatus.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblCheckStatus.ForeColor = System.Drawing.Color.Black;
            this.lblCheckStatus.Location = new System.Drawing.Point(13, 454);
            this.lblCheckStatus.Name = "lblCheckStatus";
            this.lblCheckStatus.Size = new System.Drawing.Size(772, 19);
            this.lblCheckStatus.TabIndex = 64;
            this.lblCheckStatus.Text = "התקשורת עם השרת תקינה ({0} הודעות בחשבון)";
            this.lblCheckStatus.Visible = false;
            // 
            // cmbMarrSMSMsg
            // 
            this.cmbMarrSMSMsg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarrSMSMsg.Enabled = false;
            this.cmbMarrSMSMsg.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbMarrSMSMsg.FormattingEnabled = true;
            this.cmbMarrSMSMsg.Items.AddRange(new object[] {
            "AT+VCID=1",
            "AT#CID=1",
            "AT%CCID=1",
            "AT#CC1",
            "AT*ID1"});
            this.cmbMarrSMSMsg.Location = new System.Drawing.Point(223, 234);
            this.cmbMarrSMSMsg.Name = "cmbMarrSMSMsg";
            this.cmbMarrSMSMsg.Size = new System.Drawing.Size(211, 22);
            this.cmbMarrSMSMsg.TabIndex = 62;
            this.cmbMarrSMSMsg.Tag = "SuperUser";
            // 
            // cmbBdaySMSMsg
            // 
            this.cmbBdaySMSMsg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBdaySMSMsg.Enabled = false;
            this.cmbBdaySMSMsg.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbBdaySMSMsg.FormattingEnabled = true;
            this.cmbBdaySMSMsg.Location = new System.Drawing.Point(223, 209);
            this.cmbBdaySMSMsg.Name = "cmbBdaySMSMsg";
            this.cmbBdaySMSMsg.Size = new System.Drawing.Size(211, 22);
            this.cmbBdaySMSMsg.TabIndex = 61;
            this.cmbBdaySMSMsg.Tag = "SuperUser";
            // 
            // chkAutoMarrSMS
            // 
            this.chkAutoMarrSMS.Enabled = false;
            this.chkAutoMarrSMS.Location = new System.Drawing.Point(15, 237);
            this.chkAutoMarrSMS.Name = "chkAutoMarrSMS";
            this.chkAutoMarrSMS.Size = new System.Drawing.Size(208, 17);
            this.chkAutoMarrSMS.TabIndex = 60;
            this.chkAutoMarrSMS.Tag = "SuperUser";
            this.chkAutoMarrSMS.Text = "שלח הודעת יום נישואין אוטומטית";
            this.chkAutoMarrSMS.UseVisualStyleBackColor = true;
            this.chkAutoMarrSMS.CheckedChanged += new System.EventHandler(this.ChkAutoMarrSmsCheckedChanged);
            // 
            // chkAutoBdaySMS
            // 
            this.chkAutoBdaySMS.Enabled = false;
            this.chkAutoBdaySMS.Location = new System.Drawing.Point(15, 212);
            this.chkAutoBdaySMS.Name = "chkAutoBdaySMS";
            this.chkAutoBdaySMS.Size = new System.Drawing.Size(208, 17);
            this.chkAutoBdaySMS.TabIndex = 59;
            this.chkAutoBdaySMS.Tag = "SuperUser";
            this.chkAutoBdaySMS.Text = "שלח הודעת יום הולדת אוטומטית";
            this.chkAutoBdaySMS.UseVisualStyleBackColor = true;
            this.chkAutoBdaySMS.CheckedChanged += new System.EventHandler(this.ChkAutoBdaySmsCheckedChanged);
            // 
            // txtSmsWS2
            // 
            this.txtSmsWS2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSmsWS2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtSmsWS2.Location = new System.Drawing.Point(223, 159);
            this.txtSmsWS2.Name = "txtSmsWS2";
            this.txtSmsWS2.ReadOnly = true;
            this.txtSmsWS2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSmsWS2.Size = new System.Drawing.Size(535, 22);
            this.txtSmsWS2.TabIndex = 56;
            this.txtSmsWS2.Tag = "SuperUser";
            // 
            // label43
            // 
            this.label43.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label43.Location = new System.Drawing.Point(12, 162);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(211, 19);
            this.label43.TabIndex = 55;
            this.label43.Text = "כתובת עבור שירות שליחת SMS:";
            // 
            // txtSmsPassword
            // 
            this.txtSmsPassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSmsPassword.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtSmsPassword.Location = new System.Drawing.Point(223, 134);
            this.txtSmsPassword.Name = "txtSmsPassword";
            this.txtSmsPassword.PasswordChar = '*';
            this.txtSmsPassword.ReadOnly = true;
            this.txtSmsPassword.Size = new System.Drawing.Size(211, 22);
            this.txtSmsPassword.TabIndex = 52;
            this.txtSmsPassword.Tag = "SuperUser";
            // 
            // label41
            // 
            this.label41.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label41.Location = new System.Drawing.Point(12, 137);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(211, 19);
            this.label41.TabIndex = 51;
            this.label41.Text = "סיסמה עבור שרת ה-SMS:";
            // 
            // txtSmsUserName
            // 
            this.txtSmsUserName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSmsUserName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtSmsUserName.Location = new System.Drawing.Point(223, 109);
            this.txtSmsUserName.Name = "txtSmsUserName";
            this.txtSmsUserName.ReadOnly = true;
            this.txtSmsUserName.Size = new System.Drawing.Size(211, 22);
            this.txtSmsUserName.TabIndex = 50;
            this.txtSmsUserName.Tag = "SuperUser";
            // 
            // label42
            // 
            this.label42.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label42.Location = new System.Drawing.Point(12, 112);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(211, 19);
            this.label42.TabIndex = 49;
            this.label42.Text = "שם משתמש עבור שרת ה-SMS:";
            // 
            // txtSmsFrom
            // 
            this.txtSmsFrom.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtSmsFrom.Location = new System.Drawing.Point(223, 84);
            this.txtSmsFrom.Name = "txtSmsFrom";
            this.txtSmsFrom.ReadOnly = true;
            this.txtSmsFrom.Size = new System.Drawing.Size(211, 22);
            this.txtSmsFrom.TabIndex = 48;
            this.txtSmsFrom.Tag = "SuperUser";
            // 
            // label39
            // 
            this.label39.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label39.Location = new System.Drawing.Point(12, 87);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(211, 19);
            this.label39.TabIndex = 47;
            this.label39.Text = "מספר ו/או שם השולח:";
            // 
            // txtSmsMaxChars
            // 
            this.txtSmsMaxChars.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtSmsMaxChars.Location = new System.Drawing.Point(223, 59);
            this.txtSmsMaxChars.MaxLength = 3;
            this.txtSmsMaxChars.Name = "txtSmsMaxChars";
            this.txtSmsMaxChars.ReadOnly = true;
            this.txtSmsMaxChars.Size = new System.Drawing.Size(55, 22);
            this.txtSmsMaxChars.TabIndex = 46;
            this.txtSmsMaxChars.Tag = "SuperUser";
            // 
            // label38
            // 
            this.label38.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label38.Location = new System.Drawing.Point(12, 62);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(211, 19);
            this.label38.TabIndex = 45;
            this.label38.Text = "מקסימום תווים להודעה:";
            // 
            // button7
            // 
            this.button7.Enabled = false;
            this.button7.Image = global::ClientManage.Properties.Resources.ok;
            this.button7.Location = new System.Drawing.Point(757, 158);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(23, 24);
            this.button7.TabIndex = 58;
            this.button7.Tag = "Admin";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Button7Click);
            // 
            // btnResetBday
            // 
            this.btnResetBday.Enabled = false;
            this.btnResetBday.Location = new System.Drawing.Point(686, 207);
            this.btnResetBday.Name = "btnResetBday";
            this.btnResetBday.Size = new System.Drawing.Size(94, 24);
            this.btnResetBday.TabIndex = 65;
            this.btnResetBday.Tag = "SuperUser";
            this.btnResetBday.Text = "אפס תאריך";
            this.btnResetBday.UseVisualStyleBackColor = true;
            this.btnResetBday.Click += new System.EventHandler(this.BtnResetBdayClick);
            // 
            // btnResetMarried
            // 
            this.btnResetMarried.Enabled = false;
            this.btnResetMarried.Location = new System.Drawing.Point(686, 232);
            this.btnResetMarried.Name = "btnResetMarried";
            this.btnResetMarried.Size = new System.Drawing.Size(94, 24);
            this.btnResetMarried.TabIndex = 66;
            this.btnResetMarried.Tag = "SuperUser";
            this.btnResetMarried.Text = "אפס תאריך";
            this.btnResetMarried.UseVisualStyleBackColor = true;
            this.btnResetMarried.Click += new System.EventHandler(this.BtnResetMarriedClick);
            // 
            // chkAutoCalSms
            // 
            this.chkAutoCalSms.Checked = true;
            this.chkAutoCalSms.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoCalSms.Location = new System.Drawing.Point(15, 260);
            this.chkAutoCalSms.Name = "chkAutoCalSms";
            this.chkAutoCalSms.Size = new System.Drawing.Size(263, 17);
            this.chkAutoCalSms.TabIndex = 67;
            this.chkAutoCalSms.Tag = "";
            this.chkAutoCalSms.Text = "שלח תזכורת SMS אוטומטית לתורים ביומן";
            this.chkAutoCalSms.UseVisualStyleBackColor = true;
            this.chkAutoCalSms.CheckedChanged += new System.EventHandler(this.ChkAutoCalSmsCheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.lblCalLastSend);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmbSmsTo);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbSmsFrom);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtCalMessage);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(16, 283);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(769, 110);
            this.panel1.TabIndex = 68;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Location = new System.Drawing.Point(446, 79);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(63, 24);
            this.btnRefresh.TabIndex = 66;
            this.btnRefresh.Tag = "Admin";
            this.btnRefresh.Text = "רענן";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefreshClick);
            // 
            // lblCalLastSend
            // 
            this.lblCalLastSend.BackColor = System.Drawing.Color.Transparent;
            this.lblCalLastSend.ForeColor = System.Drawing.Color.Maroon;
            this.lblCalLastSend.Location = new System.Drawing.Point(450, 84);
            this.lblCalLastSend.Name = "lblCalLastSend";
            this.lblCalLastSend.Size = new System.Drawing.Size(283, 19);
            this.lblCalLastSend.TabIndex = 69;
            this.lblCalLastSend.Text = "נשלח לאחרונה ב: {0}";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(305, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(211, 19);
            this.label5.TabIndex = 67;
            this.label5.Text = "לפני התור";
            // 
            // cmbSmsTo
            // 
            this.cmbSmsTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSmsTo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbSmsTo.FormattingEnabled = true;
            this.cmbSmsTo.Location = new System.Drawing.Point(522, 55);
            this.cmbSmsTo.Name = "cmbSmsTo";
            this.cmbSmsTo.Size = new System.Drawing.Size(110, 22);
            this.cmbSmsTo.TabIndex = 66;
            this.cmbSmsTo.Tag = "";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(522, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(211, 19);
            this.label6.TabIndex = 65;
            this.label6.Text = "ועד";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(305, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(211, 19);
            this.label4.TabIndex = 64;
            this.label4.Text = "ימים לפני התור";
            // 
            // cmbSmsFrom
            // 
            this.cmbSmsFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSmsFrom.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbSmsFrom.FormattingEnabled = true;
            this.cmbSmsFrom.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.cmbSmsFrom.Location = new System.Drawing.Point(522, 30);
            this.cmbSmsFrom.Name = "cmbSmsFrom";
            this.cmbSmsFrom.Size = new System.Drawing.Size(110, 22);
            this.cmbSmsFrom.TabIndex = 63;
            this.cmbSmsFrom.Tag = "";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(522, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(211, 19);
            this.label3.TabIndex = 51;
            this.label3.Text = "החל מ-";
            // 
            // txtCalMessage
            // 
            this.txtCalMessage.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtCalMessage.Location = new System.Drawing.Point(5, 5);
            this.txtCalMessage.Name = "txtCalMessage";
            this.txtCalMessage.Size = new System.Drawing.Size(627, 22);
            this.txtCalMessage.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(522, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 19);
            this.label2.TabIndex = 50;
            this.label2.Text = "תוכן ההודעה:";
            // 
            // btnCheck
            // 
            this.btnCheck.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnCheck.Image")));
            this.btnCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheck.Location = new System.Drawing.Point(15, 399);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(146, 51);
            this.btnCheck.TabIndex = 70;
            this.btnCheck.Text = "בדוק שירות ";
            this.btnCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.BtnCheckClick);
            // 
            // txtCheckException
            // 
            this.txtCheckException.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCheckException.BackColor = System.Drawing.Color.White;
            this.txtCheckException.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtCheckException.Location = new System.Drawing.Point(13, 473);
            this.txtCheckException.Multiline = true;
            this.txtCheckException.Name = "txtCheckException";
            this.txtCheckException.ReadOnly = true;
            this.txtCheckException.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCheckException.Size = new System.Drawing.Size(772, 177);
            this.txtCheckException.TabIndex = 71;
            this.txtCheckException.Visible = false;
            // 
            // lblLastMer
            // 
            this.lblLastMer.BackColor = System.Drawing.Color.Transparent;
            this.lblLastMer.ForeColor = System.Drawing.Color.Maroon;
            this.lblLastMer.Location = new System.Drawing.Point(440, 237);
            this.lblLastMer.Name = "lblLastMer";
            this.lblLastMer.Size = new System.Drawing.Size(340, 19);
            this.lblLastMer.TabIndex = 63;
            this.lblLastMer.Text = "נשלח לאחרונה ב: {0}";
            this.lblLastMer.Visible = false;
            // 
            // txtCalRemindMessage
            // 
            this.txtCalRemindMessage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCalRemindMessage.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtCalRemindMessage.Location = new System.Drawing.Point(223, 184);
            this.txtCalRemindMessage.Name = "txtCalRemindMessage";
            this.txtCalRemindMessage.ReadOnly = true;
            this.txtCalRemindMessage.Size = new System.Drawing.Size(557, 22);
            this.txtCalRemindMessage.TabIndex = 72;
            this.txtCalRemindMessage.Tag = "SuperUser";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label7.Location = new System.Drawing.Point(12, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(211, 19);
            this.label7.TabIndex = 55;
            this.label7.Text = "תוכן הודעת תזכורת תור ביומן:";
            // 
            // txtUniqueId
            // 
            this.txtUniqueId.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUniqueId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtUniqueId.Location = new System.Drawing.Point(436, 109);
            this.txtUniqueId.Name = "txtUniqueId";
            this.txtUniqueId.ReadOnly = true;
            this.txtUniqueId.Size = new System.Drawing.Size(322, 22);
            this.txtUniqueId.TabIndex = 73;
            this.txtUniqueId.Tag = "SuperUser";
            // 
            // btnUniqueId
            // 
            this.btnUniqueId.Enabled = false;
            this.btnUniqueId.Image = global::ClientManage.Properties.Resources.ok;
            this.btnUniqueId.Location = new System.Drawing.Point(757, 108);
            this.btnUniqueId.Name = "btnUniqueId";
            this.btnUniqueId.Size = new System.Drawing.Size(23, 24);
            this.btnUniqueId.TabIndex = 74;
            this.btnUniqueId.Tag = "SuperUser";
            this.btnUniqueId.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(167, 399);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 51);
            this.button1.TabIndex = 75;
            this.button1.Text = "סנכרן אנשי קשר";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.BackColor = System.Drawing.Color.Transparent;
            this.lblCount.ForeColor = System.Drawing.Color.Maroon;
            this.lblCount.Location = new System.Drawing.Point(319, 431);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(466, 19);
            this.lblCount.TabIndex = 76;
            // 
            // lblBdayLast
            // 
            this.lblBdayLast.BackColor = System.Drawing.Color.Transparent;
            this.lblBdayLast.ForeColor = System.Drawing.Color.Maroon;
            this.lblBdayLast.Location = new System.Drawing.Point(440, 212);
            this.lblBdayLast.Name = "lblBdayLast";
            this.lblBdayLast.Size = new System.Drawing.Size(340, 19);
            this.lblBdayLast.TabIndex = 63;
            this.lblBdayLast.Text = "נשלח לאחרונה ב: {0}";
            this.lblBdayLast.Visible = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(319, 399);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 51);
            this.button2.TabIndex = 77;
            this.button2.Text = "סנכרן יומן";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // FormOptSms1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 657);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtUniqueId);
            this.Controls.Add(this.txtCalRemindMessage);
            this.Controls.Add(this.txtCheckException);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkAutoCalSms);
            this.Controls.Add(this.btnResetMarried);
            this.Controls.Add(this.btnResetBday);
            this.Controls.Add(this.lblCheckStatus);
            this.Controls.Add(this.lblLastMer);
            this.Controls.Add(this.lblBdayLast);
            this.Controls.Add(this.cmbMarrSMSMsg);
            this.Controls.Add(this.cmbBdaySMSMsg);
            this.Controls.Add(this.chkAutoMarrSMS);
            this.Controls.Add(this.chkAutoBdaySMS);
            this.Controls.Add(this.txtSmsWS2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.txtSmsPassword);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.txtSmsUserName);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.txtSmsFrom);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.txtSmsMaxChars);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.btnUniqueId);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormOptSms1";
            this.Text = "frmOptSMS1";
            this.Controls.SetChildIndex(this.btnUniqueId, 0);
            this.Controls.SetChildIndex(this.button7, 0);
            this.Controls.SetChildIndex(this.label38, 0);
            this.Controls.SetChildIndex(this.txtSmsMaxChars, 0);
            this.Controls.SetChildIndex(this.label39, 0);
            this.Controls.SetChildIndex(this.txtSmsFrom, 0);
            this.Controls.SetChildIndex(this.label42, 0);
            this.Controls.SetChildIndex(this.txtSmsUserName, 0);
            this.Controls.SetChildIndex(this.label41, 0);
            this.Controls.SetChildIndex(this.txtSmsPassword, 0);
            this.Controls.SetChildIndex(this.label43, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtSmsWS2, 0);
            this.Controls.SetChildIndex(this.chkAutoBdaySMS, 0);
            this.Controls.SetChildIndex(this.chkAutoMarrSMS, 0);
            this.Controls.SetChildIndex(this.cmbBdaySMSMsg, 0);
            this.Controls.SetChildIndex(this.cmbMarrSMSMsg, 0);
            this.Controls.SetChildIndex(this.lblBdayLast, 0);
            this.Controls.SetChildIndex(this.lblLastMer, 0);
            this.Controls.SetChildIndex(this.lblCheckStatus, 0);
            this.Controls.SetChildIndex(this.btnResetBday, 0);
            this.Controls.SetChildIndex(this.btnResetMarried, 0);
            this.Controls.SetChildIndex(this.chkAutoCalSms, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnCheck, 0);
            this.Controls.SetChildIndex(this.txtCheckException, 0);
            this.Controls.SetChildIndex(this.txtCalRemindMessage, 0);
            this.Controls.SetChildIndex(this.txtUniqueId, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.lblCount, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCheckStatus;
        private System.Windows.Forms.ComboBox cmbMarrSMSMsg;
        private System.Windows.Forms.ComboBox cmbBdaySMSMsg;
        private System.Windows.Forms.CheckBox chkAutoMarrSMS;
        private System.Windows.Forms.CheckBox chkAutoBdaySMS;
        private System.Windows.Forms.TextBox txtSmsWS2;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox txtSmsPassword;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox txtSmsUserName;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox txtSmsFrom;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox txtSmsMaxChars;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnResetBday;
        private System.Windows.Forms.Button btnResetMarried;
        private System.Windows.Forms.CheckBox chkAutoCalSms;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCalMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSmsTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSmsFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCalLastSend;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TextBox txtCheckException;
        private System.Windows.Forms.Label lblLastMer;
        private System.Windows.Forms.TextBox txtCalRemindMessage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUniqueId;
        private System.Windows.Forms.Button btnUniqueId;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblBdayLast;
        private System.Windows.Forms.Button button2;
    }
}