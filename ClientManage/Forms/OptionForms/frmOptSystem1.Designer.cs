namespace ClientManage.Forms.OptionForms
{
    partial class FormOptSystem1
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
            this.txtCommonWS = new System.Windows.Forms.TextBox();
            this.label88 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.btnValidUrlHost = new System.Windows.Forms.Button();
            this.btnValidUrlCommon = new System.Windows.Forms.Button();
            this.txtLoginPass = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDialArea = new System.Windows.Forms.ComboBox();
            this.txtWSpass = new System.Windows.Forms.TextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.txtWSuser = new System.Windows.Forms.TextBox();
            this.label73 = new System.Windows.Forms.Label();
            this.cmbBDateHour = new System.Windows.Forms.ComboBox();
            this.cmbBDayMin = new System.Windows.Forms.ComboBox();
            this.chkBirthDaySpan = new System.Windows.Forms.CheckBox();
            this.chkBirthDateRem = new System.Windows.Forms.CheckBox();
            this.chkEnableCallLog = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkEnableWebCam = new System.Windows.Forms.CheckBox();
            this.chkEnableDial = new System.Windows.Forms.CheckBox();
            this.chkEnableCallerId = new System.Windows.Forms.CheckBox();
            this.chkShowPrintDialog = new System.Windows.Forms.CheckBox();
            this.txtMasterPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtClientId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBdateSep = new System.Windows.Forms.Label();
            this.chkDialPrefix = new System.Windows.Forms.CheckBox();
            this.cmbDateFormat = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDbVersion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDbVersion = new System.Windows.Forms.Label();
            this.txtUniqueId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCommonWS
            // 
            this.txtCommonWS.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCommonWS.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtCommonWS.Location = new System.Drawing.Point(160, 269);
            this.txtCommonWS.Name = "txtCommonWS";
            this.txtCommonWS.ReadOnly = true;
            this.txtCommonWS.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCommonWS.Size = new System.Drawing.Size(538, 22);
            this.txtCommonWS.TabIndex = 6;
            this.txtCommonWS.Tag = "Lock";
            // 
            // label88
            // 
            this.label88.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label88.Location = new System.Drawing.Point(14, 299);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(117, 20);
            this.label88.TabIndex = 74;
            this.label88.Text = "כתובת מארח:";
            // 
            // label87
            // 
            this.label87.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label87.Location = new System.Drawing.Point(14, 273);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(143, 20);
            this.label87.TabIndex = 73;
            this.label87.Text = "כתובת שירותי רשת:";
            // 
            // txtHost
            // 
            this.txtHost.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtHost.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtHost.Location = new System.Drawing.Point(160, 295);
            this.txtHost.Name = "txtHost";
            this.txtHost.ReadOnly = true;
            this.txtHost.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtHost.Size = new System.Drawing.Size(538, 22);
            this.txtHost.TabIndex = 7;
            this.txtHost.Tag = "Lock";
            // 
            // btnValidUrlHost
            // 
            this.btnValidUrlHost.Enabled = false;
            this.btnValidUrlHost.Image = global::ClientManage.Properties.Resources.ok;
            this.btnValidUrlHost.Location = new System.Drawing.Point(698, 294);
            this.btnValidUrlHost.Name = "btnValidUrlHost";
            this.btnValidUrlHost.Size = new System.Drawing.Size(27, 24);
            this.btnValidUrlHost.TabIndex = 56;
            this.btnValidUrlHost.Tag = "Admin";
            this.btnValidUrlHost.UseVisualStyleBackColor = true;
            this.btnValidUrlHost.Click += new System.EventHandler(this.BtnValidUrlHostClick);
            // 
            // btnValidUrlCommon
            // 
            this.btnValidUrlCommon.Enabled = false;
            this.btnValidUrlCommon.Image = global::ClientManage.Properties.Resources.ok;
            this.btnValidUrlCommon.Location = new System.Drawing.Point(698, 268);
            this.btnValidUrlCommon.Name = "btnValidUrlCommon";
            this.btnValidUrlCommon.Size = new System.Drawing.Size(27, 24);
            this.btnValidUrlCommon.TabIndex = 54;
            this.btnValidUrlCommon.Tag = "Admin";
            this.btnValidUrlCommon.UseVisualStyleBackColor = true;
            this.btnValidUrlCommon.Click += new System.EventHandler(this.BtnValidUrlCommonClick);
            // 
            // txtLoginPass
            // 
            this.txtLoginPass.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLoginPass.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtLoginPass.Location = new System.Drawing.Point(160, 116);
            this.txtLoginPass.MaxLength = 255;
            this.txtLoginPass.Name = "txtLoginPass";
            this.txtLoginPass.PasswordChar = '*';
            this.txtLoginPass.ReadOnly = true;
            this.txtLoginPass.Size = new System.Drawing.Size(327, 22);
            this.txtLoginPass.TabIndex = 2;
            this.txtLoginPass.Tag = "Admin";
            this.txtLoginPass.Validating += new System.ComponentModel.CancelEventHandler(this.TxtLoginPassValidating);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label7.Location = new System.Drawing.Point(14, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 20);
            this.label7.TabIndex = 72;
            this.label7.Tag = "";
            this.label7.Text = "סיסמת כניסה:";
            // 
            // cmbDialArea
            // 
            this.cmbDialArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDialArea.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbDialArea.FormattingEnabled = true;
            this.cmbDialArea.Location = new System.Drawing.Point(160, 322);
            this.cmbDialArea.Name = "cmbDialArea";
            this.cmbDialArea.Size = new System.Drawing.Size(92, 22);
            this.cmbDialArea.TabIndex = 8;
            // 
            // txtWSpass
            // 
            this.txtWSpass.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtWSpass.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtWSpass.Location = new System.Drawing.Point(160, 194);
            this.txtWSpass.MaxLength = 255;
            this.txtWSpass.Name = "txtWSpass";
            this.txtWSpass.PasswordChar = '*';
            this.txtWSpass.ReadOnly = true;
            this.txtWSpass.Size = new System.Drawing.Size(327, 22);
            this.txtWSpass.TabIndex = 5;
            this.txtWSpass.Tag = "SuperUser";
            // 
            // label74
            // 
            this.label74.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label74.Location = new System.Drawing.Point(14, 198);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(117, 20);
            this.label74.TabIndex = 69;
            this.label74.Tag = "";
            this.label74.Text = "סיסמת רשת:";
            // 
            // txtWSuser
            // 
            this.txtWSuser.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtWSuser.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtWSuser.Location = new System.Drawing.Point(160, 168);
            this.txtWSuser.MaxLength = 255;
            this.txtWSuser.Name = "txtWSuser";
            this.txtWSuser.PasswordChar = '*';
            this.txtWSuser.ReadOnly = true;
            this.txtWSuser.Size = new System.Drawing.Size(327, 22);
            this.txtWSuser.TabIndex = 4;
            this.txtWSuser.Tag = "SuperUser";
            // 
            // label73
            // 
            this.label73.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label73.Location = new System.Drawing.Point(14, 171);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(143, 20);
            this.label73.TabIndex = 66;
            this.label73.Tag = "";
            this.label73.Text = "שם משתמש ברשת:";
            // 
            // cmbBDateHour
            // 
            this.cmbBDateHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBDateHour.Enabled = false;
            this.cmbBDateHour.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbBDateHour.FormattingEnabled = true;
            this.cmbBDateHour.Items.AddRange(new object[] {
            "00",
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
            this.cmbBDateHour.Location = new System.Drawing.Point(425, 529);
            this.cmbBDateHour.Name = "cmbBDateHour";
            this.cmbBDateHour.Size = new System.Drawing.Size(42, 22);
            this.cmbBDateHour.TabIndex = 18;
            // 
            // cmbBDayMin
            // 
            this.cmbBDayMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBDayMin.Enabled = false;
            this.cmbBDayMin.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbBDayMin.FormattingEnabled = true;
            this.cmbBDayMin.Items.AddRange(new object[] {
            "00",
            "05",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55"});
            this.cmbBDayMin.Location = new System.Drawing.Point(376, 529);
            this.cmbBDayMin.Name = "cmbBDayMin";
            this.cmbBDayMin.Size = new System.Drawing.Size(42, 22);
            this.cmbBDayMin.TabIndex = 19;
            // 
            // chkBirthDaySpan
            // 
            this.chkBirthDaySpan.Enabled = false;
            this.chkBirthDaySpan.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chkBirthDaySpan.Location = new System.Drawing.Point(49, 530);
            this.chkBirthDaySpan.Name = "chkBirthDaySpan";
            this.chkBirthDaySpan.Size = new System.Drawing.Size(339, 20);
            this.chkBirthDaySpan.TabIndex = 17;
            this.chkBirthDaySpan.Text = "תזמן הצגת תזכורת יום הולדת ללקוחות בכל יום בשעה";
            this.chkBirthDaySpan.UseVisualStyleBackColor = true;
            this.chkBirthDaySpan.CheckedChanged += new System.EventHandler(this.ChkBirthDaySpanCheckedChanged);
            // 
            // chkBirthDateRem
            // 
            this.chkBirthDateRem.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chkBirthDateRem.Location = new System.Drawing.Point(17, 509);
            this.chkBirthDateRem.Name = "chkBirthDateRem";
            this.chkBirthDateRem.Size = new System.Drawing.Size(453, 20);
            this.chkBirthDateRem.TabIndex = 16;
            this.chkBirthDateRem.Text = "הצג חלון תזכורת יום הולדת ללקוחות";
            this.chkBirthDateRem.UseVisualStyleBackColor = true;
            this.chkBirthDateRem.CheckedChanged += new System.EventHandler(this.ChkBirthDateRemCheckedChanged);
            // 
            // chkEnableCallLog
            // 
            this.chkEnableCallLog.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chkEnableCallLog.Location = new System.Drawing.Point(17, 467);
            this.chkEnableCallLog.Name = "chkEnableCallLog";
            this.chkEnableCallLog.Size = new System.Drawing.Size(453, 20);
            this.chkEnableCallLog.TabIndex = 14;
            this.chkEnableCallLog.Text = "אפשר מעקב ורישום שיחות נכנסות/יוצאות";
            this.chkEnableCallLog.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(14, 351);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 20);
            this.label5.TabIndex = 57;
            this.label5.Text = "פורמט תאריך:";
            // 
            // chkEnableWebCam
            // 
            this.chkEnableWebCam.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chkEnableWebCam.Location = new System.Drawing.Point(17, 488);
            this.chkEnableWebCam.Name = "chkEnableWebCam";
            this.chkEnableWebCam.Size = new System.Drawing.Size(453, 20);
            this.chkEnableWebCam.TabIndex = 15;
            this.chkEnableWebCam.Text = "אפשר הפעלת מצלמת אינטרנט";
            this.chkEnableWebCam.UseVisualStyleBackColor = true;
            // 
            // chkEnableDial
            // 
            this.chkEnableDial.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chkEnableDial.Location = new System.Drawing.Point(17, 446);
            this.chkEnableDial.Name = "chkEnableDial";
            this.chkEnableDial.Size = new System.Drawing.Size(453, 20);
            this.chkEnableDial.TabIndex = 13;
            this.chkEnableDial.Text = "אפשר חיוג באמצעות קו הטלפון (שיחות יוצאות)";
            this.chkEnableDial.UseVisualStyleBackColor = true;
            // 
            // chkEnableCallerId
            // 
            this.chkEnableCallerId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chkEnableCallerId.Location = new System.Drawing.Point(17, 426);
            this.chkEnableCallerId.Name = "chkEnableCallerId";
            this.chkEnableCallerId.Size = new System.Drawing.Size(453, 20);
            this.chkEnableCallerId.TabIndex = 12;
            this.chkEnableCallerId.Text = "אפשר זיהוי שיחת טלפון נכנסת";
            this.chkEnableCallerId.UseVisualStyleBackColor = true;
            // 
            // chkShowPrintDialog
            // 
            this.chkShowPrintDialog.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chkShowPrintDialog.Location = new System.Drawing.Point(17, 405);
            this.chkShowPrintDialog.Name = "chkShowPrintDialog";
            this.chkShowPrintDialog.Size = new System.Drawing.Size(453, 20);
            this.chkShowPrintDialog.TabIndex = 11;
            this.chkShowPrintDialog.Text = "הצג תיבת דוח שיח \"הגדרות הדפסה\" בעת שליחה להדפסה";
            this.chkShowPrintDialog.UseVisualStyleBackColor = true;
            // 
            // txtMasterPassword
            // 
            this.txtMasterPassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMasterPassword.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtMasterPassword.Location = new System.Drawing.Point(160, 142);
            this.txtMasterPassword.MaxLength = 255;
            this.txtMasterPassword.Name = "txtMasterPassword";
            this.txtMasterPassword.PasswordChar = '*';
            this.txtMasterPassword.ReadOnly = true;
            this.txtMasterPassword.Size = new System.Drawing.Size(327, 22);
            this.txtMasterPassword.TabIndex = 3;
            this.txtMasterPassword.Tag = "Admin";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(14, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 20);
            this.label4.TabIndex = 49;
            this.label4.Tag = "";
            this.label4.Text = "סיסמת Master:";
            // 
            // txtClientName
            // 
            this.txtClientName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtClientName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtClientName.Location = new System.Drawing.Point(160, 90);
            this.txtClientName.MaxLength = 255;
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.ReadOnly = true;
            this.txtClientName.Size = new System.Drawing.Size(327, 22);
            this.txtClientName.TabIndex = 1;
            this.txtClientName.Tag = "SuperUser";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(14, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 20);
            this.label3.TabIndex = 46;
            this.label3.Tag = "";
            this.label3.Text = "שם לקוח:";
            // 
            // txtClientId
            // 
            this.txtClientId.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtClientId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtClientId.Location = new System.Drawing.Point(160, 64);
            this.txtClientId.MaxLength = 255;
            this.txtClientId.Name = "txtClientId";
            this.txtClientId.ReadOnly = true;
            this.txtClientId.Size = new System.Drawing.Size(327, 22);
            this.txtClientId.TabIndex = 0;
            this.txtClientId.Tag = "SuperUser";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(14, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 44;
            this.label1.Tag = "";
            this.label1.Text = "מספר לקוח:";
            // 
            // lblBdateSep
            // 
            this.lblBdateSep.Enabled = false;
            this.lblBdateSep.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblBdateSep.Location = new System.Drawing.Point(415, 532);
            this.lblBdateSep.Name = "lblBdateSep";
            this.lblBdateSep.Size = new System.Drawing.Size(9, 20);
            this.lblBdateSep.TabIndex = 64;
            this.lblBdateSep.Text = ":";
            // 
            // chkDialPrefix
            // 
            this.chkDialPrefix.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chkDialPrefix.Location = new System.Drawing.Point(17, 383);
            this.chkDialPrefix.Name = "chkDialPrefix";
            this.chkDialPrefix.Size = new System.Drawing.Size(453, 20);
            this.chkDialPrefix.TabIndex = 10;
            this.chkDialPrefix.Text = "חייג את קידומת המספר אם היא שייכת לאיזור החיוג שלי";
            this.chkDialPrefix.UseVisualStyleBackColor = true;
            // 
            // cmbDateFormat
            // 
            this.cmbDateFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDateFormat.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbDateFormat.FormattingEnabled = true;
            this.cmbDateFormat.Items.AddRange(new object[] {
            "dd/MM/yyyy",
            "yyyy/MM/dd"});
            this.cmbDateFormat.Location = new System.Drawing.Point(160, 348);
            this.cmbDateFormat.Name = "cmbDateFormat";
            this.cmbDateFormat.Size = new System.Drawing.Size(92, 22);
            this.cmbDateFormat.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(14, 325);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 57;
            this.label2.Text = "איזור חיוג:";
            // 
            // txtDbVersion
            // 
            this.txtDbVersion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDbVersion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtDbVersion.Location = new System.Drawing.Point(160, 219);
            this.txtDbVersion.MaxLength = 255;
            this.txtDbVersion.Name = "txtDbVersion";
            this.txtDbVersion.ReadOnly = true;
            this.txtDbVersion.Size = new System.Drawing.Size(327, 22);
            this.txtDbVersion.TabIndex = 5;
            this.txtDbVersion.Tag = "SuperUser";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(14, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 20);
            this.label6.TabIndex = 69;
            this.label6.Tag = "";
            this.label6.Text = "גרסת בסיס נתונים:";
            // 
            // lblDbVersion
            // 
            this.lblDbVersion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblDbVersion.ForeColor = System.Drawing.Color.Maroon;
            this.lblDbVersion.Image = global::ClientManage.Properties.Resources.field_error;
            this.lblDbVersion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDbVersion.Location = new System.Drawing.Point(493, 222);
            this.lblDbVersion.Name = "lblDbVersion";
            this.lblDbVersion.Size = new System.Drawing.Size(232, 20);
            this.lblDbVersion.TabIndex = 69;
            this.lblDbVersion.Tag = "";
            this.lblDbVersion.Text = "      חוסר התאמה! יש להריץ עדכון";
            this.lblDbVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDbVersion.Visible = false;
            // 
            // txtUniqueId
            // 
            this.txtUniqueId.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUniqueId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtUniqueId.Location = new System.Drawing.Point(160, 244);
            this.txtUniqueId.MaxLength = 255;
            this.txtUniqueId.Name = "txtUniqueId";
            this.txtUniqueId.ReadOnly = true;
            this.txtUniqueId.Size = new System.Drawing.Size(327, 22);
            this.txtUniqueId.TabIndex = 75;
            this.txtUniqueId.Tag = "Lock";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label8.Location = new System.Drawing.Point(14, 250);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 20);
            this.label8.TabIndex = 76;
            this.label8.Tag = "";
            this.label8.Text = "מזהה ייחודי:";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Image = global::ClientManage.Properties.Resources.ok;
            this.button1.Location = new System.Drawing.Point(487, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 24);
            this.button1.TabIndex = 77;
            this.button1.Tag = "Admin";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // FormOptSystem1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 620);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtUniqueId);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbDateFormat);
            this.Controls.Add(this.chkDialPrefix);
            this.Controls.Add(this.txtClientName);
            this.Controls.Add(this.txtClientId);
            this.Controls.Add(this.txtCommonWS);
            this.Controls.Add(this.label88);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label87);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.btnValidUrlHost);
            this.Controls.Add(this.btnValidUrlCommon);
            this.Controls.Add(this.txtLoginPass);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbDialArea);
            this.Controls.Add(this.txtDbVersion);
            this.Controls.Add(this.txtWSpass);
            this.Controls.Add(this.lblDbVersion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label74);
            this.Controls.Add(this.txtWSuser);
            this.Controls.Add(this.label73);
            this.Controls.Add(this.cmbBDateHour);
            this.Controls.Add(this.cmbBDayMin);
            this.Controls.Add(this.chkBirthDateRem);
            this.Controls.Add(this.chkEnableCallLog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkEnableWebCam);
            this.Controls.Add(this.chkEnableDial);
            this.Controls.Add(this.chkEnableCallerId);
            this.Controls.Add(this.chkShowPrintDialog);
            this.Controls.Add(this.txtMasterPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblBdateSep);
            this.Controls.Add(this.chkBirthDaySpan);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormOptSystem1";
            this.Text = "frmOptSystem1";
            this.Controls.SetChildIndex(this.chkBirthDaySpan, 0);
            this.Controls.SetChildIndex(this.lblBdateSep, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtMasterPassword, 0);
            this.Controls.SetChildIndex(this.chkShowPrintDialog, 0);
            this.Controls.SetChildIndex(this.chkEnableCallerId, 0);
            this.Controls.SetChildIndex(this.chkEnableDial, 0);
            this.Controls.SetChildIndex(this.chkEnableWebCam, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.chkEnableCallLog, 0);
            this.Controls.SetChildIndex(this.chkBirthDateRem, 0);
            this.Controls.SetChildIndex(this.cmbBDayMin, 0);
            this.Controls.SetChildIndex(this.cmbBDateHour, 0);
            this.Controls.SetChildIndex(this.label73, 0);
            this.Controls.SetChildIndex(this.txtWSuser, 0);
            this.Controls.SetChildIndex(this.label74, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.lblDbVersion, 0);
            this.Controls.SetChildIndex(this.txtWSpass, 0);
            this.Controls.SetChildIndex(this.txtDbVersion, 0);
            this.Controls.SetChildIndex(this.cmbDialArea, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtLoginPass, 0);
            this.Controls.SetChildIndex(this.btnValidUrlCommon, 0);
            this.Controls.SetChildIndex(this.btnValidUrlHost, 0);
            this.Controls.SetChildIndex(this.txtHost, 0);
            this.Controls.SetChildIndex(this.label87, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label88, 0);
            this.Controls.SetChildIndex(this.txtCommonWS, 0);
            this.Controls.SetChildIndex(this.txtClientId, 0);
            this.Controls.SetChildIndex(this.txtClientName, 0);
            this.Controls.SetChildIndex(this.chkDialPrefix, 0);
            this.Controls.SetChildIndex(this.cmbDateFormat, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtUniqueId, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCommonWS;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Button btnValidUrlHost;
        private System.Windows.Forms.Button btnValidUrlCommon;
        private System.Windows.Forms.TextBox txtLoginPass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbDialArea;
        private System.Windows.Forms.TextBox txtWSpass;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.TextBox txtWSuser;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.ComboBox cmbBDateHour;
        private System.Windows.Forms.ComboBox cmbBDayMin;
        private System.Windows.Forms.CheckBox chkBirthDaySpan;
        private System.Windows.Forms.CheckBox chkBirthDateRem;
        private System.Windows.Forms.CheckBox chkEnableCallLog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkEnableWebCam;
        private System.Windows.Forms.CheckBox chkEnableDial;
        private System.Windows.Forms.CheckBox chkEnableCallerId;
        private System.Windows.Forms.CheckBox chkShowPrintDialog;
        private System.Windows.Forms.TextBox txtMasterPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtClientId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBdateSep;
        private System.Windows.Forms.CheckBox chkDialPrefix;
        private System.Windows.Forms.ComboBox cmbDateFormat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDbVersion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDbVersion;
        private System.Windows.Forms.TextBox txtUniqueId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;

    }
}