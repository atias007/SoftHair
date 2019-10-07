using BizCare.Calendar;
using BizCare.SoftHair.MonthCalendar;
namespace ClientManage.Forms
{
    partial class FormCalendar
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCalendar));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtPicker = new BizCare.SoftHair.MonthCalendar.SHMonthView();
            this.btnCarePick = new System.Windows.Forms.Button();
            this.pnlRemainder = new System.Windows.Forms.Panel();
            this.lblRemainder = new System.Windows.Forms.Label();
            this.chkRemainder = new System.Windows.Forms.CheckBox();
            this.btnOk = new ClientManage.UserControls.XPFlatButton();
            this.cmbEndHour = new System.Windows.Forms.ComboBox();
            this.cmbEndMin = new System.Windows.Forms.ComboBox();
            this.lblEndSep = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.cmbStartHour = new System.Windows.Forms.ComboBox();
            this.cmbStartMin = new System.Windows.Forms.ComboBox();
            this.lblStartSep = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.picView = new System.Windows.Forms.PictureBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.btnClearClient = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.imageComboBox1 = new ClientManage.UserControls.ImageComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblFNCap = new System.Windows.Forms.Label();
            this.lblClientCaption = new System.Windows.Forms.Label();
            this.lblLNCap = new System.Windows.Forms.Label();
            this.btnAttachClient = new System.Windows.Forms.Button();
            this.pnlAttachMsg = new System.Windows.Forms.Panel();
            this.btnAttach = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMsgWait1 = new System.Windows.Forms.Label();
            this.lblBaloon = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tbbNew = new System.Windows.Forms.ToolStripButton();
            this.tbbEdit = new System.Windows.Forms.ToolStripButton();
            this.tbbDelete = new System.Windows.Forms.ToolStripButton();
            this.tbbArchive = new System.Windows.Forms.ToolStripButton();
            this.tbbReport = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tbbToday = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbPrint = new System.Windows.Forms.ToolStripButton();
            this.tbbEmail = new System.Windows.Forms.ToolStripButton();
            this.tbbSendSMS = new System.Windows.Forms.ToolStripButton();
            this.splitPhone = new System.Windows.Forms.ToolStripSplitButton();
            this.tbbNext = new System.Windows.Forms.ToolStripButton();
            this.tbbPrev = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cal = new BizCare.Calendar.CalendarView();
            this.panel1.SuspendLayout();
            this.pnlRemainder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picView)).BeginInit();
            this.pnlAttachMsg.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.dtPicker);
            this.panel1.Controls.Add(this.btnCarePick);
            this.panel1.Controls.Add(this.pnlRemainder);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.cmbEndHour);
            this.panel1.Controls.Add(this.cmbEndMin);
            this.panel1.Controls.Add(this.lblEndSep);
            this.panel1.Controls.Add(this.lblEnd);
            this.panel1.Controls.Add(this.cmbStartHour);
            this.panel1.Controls.Add(this.cmbStartMin);
            this.panel1.Controls.Add(this.lblStartSep);
            this.panel1.Controls.Add(this.lblStart);
            this.panel1.Controls.Add(this.txtSubject);
            this.panel1.Controls.Add(this.lblSubject);
            this.panel1.Controls.Add(this.picView);
            this.panel1.Controls.Add(this.lblFirstName);
            this.panel1.Controls.Add(this.btnClearClient);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblLastName);
            this.panel1.Controls.Add(this.imageComboBox1);
            this.panel1.Controls.Add(this.lblFNCap);
            this.panel1.Controls.Add(this.lblClientCaption);
            this.panel1.Controls.Add(this.lblLNCap);
            this.panel1.Controls.Add(this.btnAttachClient);
            this.panel1.Location = new System.Drawing.Point(4, 45);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(175, 636);
            this.panel1.TabIndex = 10;
            this.panel1.SizeChanged += new System.EventHandler(this.Panel1SizeChanged);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1Paint);
            // 
            // dtPicker
            // 
            this.dtPicker.BackColor = System.Drawing.Color.White;
            this.dtPicker.BoldDates = null;
            this.dtPicker.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.dtPicker.Location = new System.Drawing.Point(6, 72);
            this.dtPicker.Month = 10;
            this.dtPicker.Name = "dtPicker";
            this.dtPicker.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtPicker.SelectedDate = new System.DateTime(2008, 10, 19, 0, 0, 0, 0);
            this.dtPicker.Size = new System.Drawing.Size(164, 170);
            this.dtPicker.TabIndex = 68;
            this.dtPicker.Year = 2008;
            this.dtPicker.SelectedDateChanged += new System.EventHandler(this.DtPickerDateChanged);
            this.dtPicker.MonthChanged += new System.EventHandler(this.DtPickerMonthChanged);
            // 
            // btnCarePick
            // 
            this.btnCarePick.Image = global::ClientManage.Properties.Resources.point;
            this.btnCarePick.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCarePick.Location = new System.Drawing.Point(5, 443);
            this.btnCarePick.Name = "btnCarePick";
            this.btnCarePick.Size = new System.Drawing.Size(165, 24);
            this.btnCarePick.TabIndex = 67;
            this.btnCarePick.Text = "       בחר טיפול לתור זה...";
            this.btnCarePick.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCarePick.UseVisualStyleBackColor = true;
            this.btnCarePick.Click += new System.EventHandler(this.BtnCarePickClick);
            // 
            // pnlRemainder
            // 
            this.pnlRemainder.BackColor = System.Drawing.Color.White;
            this.pnlRemainder.Controls.Add(this.lblRemainder);
            this.pnlRemainder.Controls.Add(this.chkRemainder);
            this.pnlRemainder.Location = new System.Drawing.Point(5, 584);
            this.pnlRemainder.Name = "pnlRemainder";
            this.pnlRemainder.Size = new System.Drawing.Size(166, 21);
            this.pnlRemainder.TabIndex = 53;
            this.pnlRemainder.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlRemainderPaint);
            // 
            // lblRemainder
            // 
            this.lblRemainder.BackColor = System.Drawing.Color.Transparent;
            this.lblRemainder.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblRemainder.Location = new System.Drawing.Point(89, 1);
            this.lblRemainder.Name = "lblRemainder";
            this.lblRemainder.Size = new System.Drawing.Size(59, 17);
            this.lblRemainder.TabIndex = 67;
            this.lblRemainder.Text = "תזכורת";
            this.lblRemainder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkRemainder
            // 
            this.chkRemainder.BackColor = System.Drawing.Color.Transparent;
            this.chkRemainder.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chkRemainder.Location = new System.Drawing.Point(143, 3);
            this.chkRemainder.Name = "chkRemainder";
            this.chkRemainder.Size = new System.Drawing.Size(21, 17);
            this.chkRemainder.TabIndex = 53;
            this.chkRemainder.UseVisualStyleBackColor = false;
            this.chkRemainder.CheckedChanged += new System.EventHandler(this.ChkRemainderCheckedChanged);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Snow;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Image = global::ClientManage.Properties.Resources.ok;
            this.btnOk.Location = new System.Drawing.Point(5, 500);
            this.btnOk.Name = "btnOk";
            this.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnOk.Size = new System.Drawing.Size(20, 23);
            this.btnOk.TabIndex = 53;
            this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
            // 
            // cmbEndHour
            // 
            this.cmbEndHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEndHour.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbEndHour.FormattingEnabled = true;
            this.cmbEndHour.Location = new System.Drawing.Point(5, 557);
            this.cmbEndHour.Name = "cmbEndHour";
            this.cmbEndHour.Size = new System.Drawing.Size(40, 22);
            this.cmbEndHour.TabIndex = 65;
            this.cmbEndHour.SelectedIndexChanged += new System.EventHandler(this.CmbEndHourSelectedIndexChanged);
            // 
            // cmbEndMin
            // 
            this.cmbEndMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEndMin.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbEndMin.FormattingEnabled = true;
            this.cmbEndMin.Items.AddRange(new object[] {
            "00",
            "15",
            "30",
            "45"});
            this.cmbEndMin.Location = new System.Drawing.Point(51, 557);
            this.cmbEndMin.Name = "cmbEndMin";
            this.cmbEndMin.Size = new System.Drawing.Size(40, 22);
            this.cmbEndMin.TabIndex = 64;
            this.cmbEndMin.SelectedIndexChanged += new System.EventHandler(this.CmbEndMinSelectedIndexChanged);
            // 
            // lblEndSep
            // 
            this.lblEndSep.Enabled = false;
            this.lblEndSep.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblEndSep.Location = new System.Drawing.Point(46, 560);
            this.lblEndSep.Name = "lblEndSep";
            this.lblEndSep.Size = new System.Drawing.Size(8, 19);
            this.lblEndSep.TabIndex = 66;
            this.lblEndSep.Text = ":";
            // 
            // lblEnd
            // 
            this.lblEnd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblEnd.Location = new System.Drawing.Point(97, 560);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(76, 23);
            this.lblEnd.TabIndex = 63;
            this.lblEnd.Text = "שעת סיום";
            // 
            // cmbStartHour
            // 
            this.cmbStartHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartHour.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbStartHour.FormattingEnabled = true;
            this.cmbStartHour.Location = new System.Drawing.Point(5, 529);
            this.cmbStartHour.Name = "cmbStartHour";
            this.cmbStartHour.Size = new System.Drawing.Size(40, 22);
            this.cmbStartHour.TabIndex = 61;
            this.cmbStartHour.SelectedIndexChanged += new System.EventHandler(this.CmbStartHourSelectedIndexChanged);
            // 
            // cmbStartMin
            // 
            this.cmbStartMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartMin.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbStartMin.FormattingEnabled = true;
            this.cmbStartMin.Items.AddRange(new object[] {
            "00",
            "15",
            "30",
            "45"});
            this.cmbStartMin.Location = new System.Drawing.Point(51, 529);
            this.cmbStartMin.Name = "cmbStartMin";
            this.cmbStartMin.Size = new System.Drawing.Size(40, 22);
            this.cmbStartMin.TabIndex = 60;
            this.cmbStartMin.SelectedIndexChanged += new System.EventHandler(this.CmbStartMinSelectedIndexChanged);
            // 
            // lblStartSep
            // 
            this.lblStartSep.Enabled = false;
            this.lblStartSep.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblStartSep.Location = new System.Drawing.Point(46, 532);
            this.lblStartSep.Name = "lblStartSep";
            this.lblStartSep.Size = new System.Drawing.Size(8, 19);
            this.lblStartSep.TabIndex = 62;
            this.lblStartSep.Text = ":";
            // 
            // lblStart
            // 
            this.lblStart.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblStart.Location = new System.Drawing.Point(97, 532);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(76, 23);
            this.lblStart.TabIndex = 59;
            this.lblStart.Text = "שעת התחלה";
            // 
            // txtSubject
            // 
            this.txtSubject.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtSubject.Location = new System.Drawing.Point(25, 500);
            this.txtSubject.MaxLength = 255;
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(145, 23);
            this.txtSubject.TabIndex = 53;
            this.txtSubject.Enter += new System.EventHandler(this.TxtSubjectEnter);
            this.txtSubject.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSubjectKeyDown);
            this.txtSubject.Leave += new System.EventHandler(this.TxtSubjectLeave);
            // 
            // lblSubject
            // 
            this.lblSubject.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblSubject.Location = new System.Drawing.Point(4, 486);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(169, 23);
            this.lblSubject.TabIndex = 53;
            this.lblSubject.Text = "תיאור התור (מלל חופשי)";
            // 
            // picView
            // 
            this.picView.BackColor = System.Drawing.Color.White;
            this.picView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picView.Cursor = System.Windows.Forms.Cursors.Default;
            this.picView.Location = new System.Drawing.Point(24, 286);
            this.picView.Name = "picView";
            this.picView.Size = new System.Drawing.Size(128, 96);
            this.picView.TabIndex = 54;
            this.picView.TabStop = false;
            this.picView.Tag = "0";
            this.picView.Click += new System.EventHandler(this.PicViewClick);
            // 
            // lblFirstName
            // 
            this.lblFirstName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblFirstName.Location = new System.Drawing.Point(7, 382);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(97, 17);
            this.lblFirstName.TabIndex = 57;
            this.lblFirstName.Text = "אאא בבב גגג";
            // 
            // btnClearClient
            // 
            this.btnClearClient.Image = global::ClientManage.Properties.Resources.delete_small;
            this.btnClearClient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearClient.Location = new System.Drawing.Point(6, 417);
            this.btnClearClient.Name = "btnClearClient";
            this.btnClearClient.Size = new System.Drawing.Size(165, 24);
            this.btnClearClient.TabIndex = 49;
            this.btnClearClient.Text = "       הסר שיוך לקוח מתור זה";
            this.btnClearClient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearClient.UseVisualStyleBackColor = true;
            this.btnClearClient.Visible = false;
            this.btnClearClient.Click += new System.EventHandler(this.BtnClearClientClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 14);
            this.label1.TabIndex = 50;
            this.label1.Text = "הצג תורים לעובד...";
            // 
            // lblLastName
            // 
            this.lblLastName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblLastName.Location = new System.Drawing.Point(7, 396);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(83, 17);
            this.lblLastName.TabIndex = 56;
            this.lblLastName.Text = "צוויגנבוים";
            // 
            // imageComboBox1
            // 
            this.imageComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.imageComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.imageComboBox1.FormattingEnabled = true;
            this.imageComboBox1.ImageList = this.imageList1;
            this.imageComboBox1.ItemHeight = 48;
            this.imageComboBox1.Location = new System.Drawing.Point(6, 16);
            this.imageComboBox1.Name = "imageComboBox1";
            this.imageComboBox1.Size = new System.Drawing.Size(164, 54);
            this.imageComboBox1.TabIndex = 49;
            this.imageComboBox1.SelectedIndexChanged += new System.EventHandler(this.ImageComboBox1SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "workers.jpg");
            this.imageList1.Images.SetKeyName(1, "worker_nopic.jpg");
            // 
            // lblFNCap
            // 
            this.lblFNCap.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblFNCap.Location = new System.Drawing.Point(88, 382);
            this.lblFNCap.Name = "lblFNCap";
            this.lblFNCap.Size = new System.Drawing.Size(67, 17);
            this.lblFNCap.TabIndex = 49;
            this.lblFNCap.Text = "שם פרטי:";
            // 
            // lblClientCaption
            // 
            this.lblClientCaption.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblClientCaption.ForeColor = System.Drawing.Color.Navy;
            this.lblClientCaption.Image = ((System.Drawing.Image)(resources.GetObject("lblClientCaption.Image")));
            this.lblClientCaption.Location = new System.Drawing.Point(1, 244);
            this.lblClientCaption.Name = "lblClientCaption";
            this.lblClientCaption.Size = new System.Drawing.Size(173, 33);
            this.lblClientCaption.TabIndex = 51;
            this.lblClientCaption.Text = "       פרטי התור";
            this.lblClientCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLNCap
            // 
            this.lblLNCap.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblLNCap.Location = new System.Drawing.Point(88, 396);
            this.lblLNCap.Name = "lblLNCap";
            this.lblLNCap.Size = new System.Drawing.Size(67, 17);
            this.lblLNCap.TabIndex = 55;
            this.lblLNCap.Text = "שם משפחה:";
            // 
            // btnAttachClient
            // 
            this.btnAttachClient.Image = ((System.Drawing.Image)(resources.GetObject("btnAttachClient.Image")));
            this.btnAttachClient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAttachClient.Location = new System.Drawing.Point(5, 417);
            this.btnAttachClient.Name = "btnAttachClient";
            this.btnAttachClient.Size = new System.Drawing.Size(165, 24);
            this.btnAttachClient.TabIndex = 58;
            this.btnAttachClient.Text = "       שייך לקוח לתור זה...";
            this.btnAttachClient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAttachClient.UseVisualStyleBackColor = true;
            this.btnAttachClient.Click += new System.EventHandler(this.BtnAttachClientClick);
            // 
            // pnlAttachMsg
            // 
            this.pnlAttachMsg.BackColor = System.Drawing.Color.White;
            this.pnlAttachMsg.Controls.Add(this.btnAttach);
            this.pnlAttachMsg.Controls.Add(this.label3);
            this.pnlAttachMsg.Controls.Add(this.lblMsgWait1);
            this.pnlAttachMsg.Controls.Add(this.lblBaloon);
            this.pnlAttachMsg.Controls.Add(this.button1);
            this.pnlAttachMsg.Location = new System.Drawing.Point(185, 331);
            this.pnlAttachMsg.Name = "pnlAttachMsg";
            this.pnlAttachMsg.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.pnlAttachMsg.Size = new System.Drawing.Size(173, 347);
            this.pnlAttachMsg.TabIndex = 52;
            this.pnlAttachMsg.Visible = false;
            this.pnlAttachMsg.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlAttachMsgPaint);
            // 
            // btnAttach
            // 
            this.btnAttach.Enabled = false;
            this.btnAttach.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnAttach.Image = global::ClientManage.Properties.Resources.ok;
            this.btnAttach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAttach.Location = new System.Drawing.Point(87, 277);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(83, 26);
            this.btnAttach.TabIndex = 92;
            this.btnAttach.Text = "אישור";
            this.btnAttach.UseVisualStyleBackColor = true;
            this.btnAttach.Click += new System.EventHandler(this.BtnAttachClick);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(0, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 70);
            this.label3.TabIndex = 91;
            this.label3.Text = "בחר בשעה הרצויה ביומן לקביעת התור ולחץ אישור.\r\nניתן גם להזין תיאור לתור על גבי הי" +
    "ומן.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMsgWait1
            // 
            this.lblMsgWait1.BackColor = System.Drawing.Color.Transparent;
            this.lblMsgWait1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMsgWait1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblMsgWait1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMsgWait1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMsgWait1.Location = new System.Drawing.Point(0, 127);
            this.lblMsgWait1.Name = "lblMsgWait1";
            this.lblMsgWait1.Size = new System.Drawing.Size(173, 68);
            this.lblMsgWait1.TabIndex = 89;
            this.lblMsgWait1.Text = "{0}\r\nממתין/ה לקביעת תור";
            this.lblMsgWait1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBaloon
            // 
            this.lblBaloon.BackColor = System.Drawing.Color.Transparent;
            this.lblBaloon.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBaloon.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblBaloon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBaloon.Image = ((System.Drawing.Image)(resources.GetObject("lblBaloon.Image")));
            this.lblBaloon.Location = new System.Drawing.Point(0, 8);
            this.lblBaloon.Name = "lblBaloon";
            this.lblBaloon.Size = new System.Drawing.Size(173, 119);
            this.lblBaloon.TabIndex = 90;
            this.lblBaloon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button1.Image = global::ClientManage.Properties.Resources.cancel_small;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(3, 277);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 26);
            this.button1.TabIndex = 49;
            this.button1.Text = "ביטול";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackgroundImage = global::ClientManage.Properties.Resources.toolbar_bg;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbNew,
            this.tbbEdit,
            this.tbbDelete,
            this.tbbArchive,
            this.tbbReport,
            this.toolStripButton1,
            this.tbbToday,
            this.toolStripSeparator2,
            this.tbbPrint,
            this.tbbEmail,
            this.tbbSendSMS,
            this.splitPhone,
            this.tbbNext,
            this.tbbPrev,
            this.toolStripSeparator1});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1024, 42);
            this.toolStrip.TabIndex = 47;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tbbNew
            // 
            this.tbbNew.AutoToolTip = false;
            this.tbbNew.Image = ((System.Drawing.Image)(resources.GetObject("tbbNew.Image")));
            this.tbbNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbNew.Name = "tbbNew";
            this.tbbNew.Size = new System.Drawing.Size(84, 39);
            this.tbbNew.Text = "קבע תור";
            this.tbbNew.ToolTipText = "פתיחת מסך קביעת תור חדש";
            this.tbbNew.Click += new System.EventHandler(this.TbbNewClick);
            // 
            // tbbEdit
            // 
            this.tbbEdit.AutoToolTip = false;
            this.tbbEdit.Image = global::ClientManage.Properties.Resources.tb_edit2;
            this.tbbEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbEdit.Name = "tbbEdit";
            this.tbbEdit.Size = new System.Drawing.Size(101, 39);
            this.tbbEdit.Text = "עדכן פרטים";
            this.tbbEdit.ToolTipText = "פתיחת מסך עדכון התור המסומן";
            this.tbbEdit.Click += new System.EventHandler(this.TbbEditClick);
            // 
            // tbbDelete
            // 
            this.tbbDelete.AutoToolTip = false;
            this.tbbDelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbDelete.ForeColor = System.Drawing.Color.SaddleBrown;
            this.tbbDelete.Image = global::ClientManage.Properties.Resources.tb_delete;
            this.tbbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbDelete.Name = "tbbDelete";
            this.tbbDelete.Size = new System.Drawing.Size(80, 39);
            this.tbbDelete.Text = "בטל תור";
            this.tbbDelete.ToolTipText = "מחיקת התור המסומן";
            this.tbbDelete.Click += new System.EventHandler(this.TbbDeleteClick);
            // 
            // tbbArchive
            // 
            this.tbbArchive.AutoToolTip = false;
            this.tbbArchive.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbArchive.Image = ((System.Drawing.Image)(resources.GetObject("tbbArchive.Image")));
            this.tbbArchive.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbArchive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbArchive.Name = "tbbArchive";
            this.tbbArchive.Size = new System.Drawing.Size(67, 39);
            this.tbbArchive.Text = "ארכיון";
            this.tbbArchive.ToolTipText = "העברת תורים לארכיון ו/או טעינתם חזרה אל היומן";
            this.tbbArchive.Visible = false;
            this.tbbArchive.Click += new System.EventHandler(this.TbbArchiveClick);
            // 
            // tbbReport
            // 
            this.tbbReport.AutoToolTip = false;
            this.tbbReport.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbReport.Image = global::ClientManage.Properties.Resources.report;
            this.tbbReport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbReport.Name = "tbbReport";
            this.tbbReport.Size = new System.Drawing.Size(111, 39);
            this.tbbReport.Text = "דוח תורים ליום";
            this.tbbReport.ToolTipText = "הצגת רשימה של כל התורים המתרחשים היום";
            this.tbbReport.Click += new System.EventHandler(this.TbbReportClick);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoToolTip = false;
            this.toolStripButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.Image = global::ClientManage.Properties.Resources.change;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(65, 39);
            this.toolStripButton1.Text = "רענן";
            this.toolStripButton1.ToolTipText = "רענון תצוגת התורים ביומן";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tbbToday
            // 
            this.tbbToday.AutoToolTip = false;
            this.tbbToday.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbToday.Image = ((System.Drawing.Image)(resources.GetObject("tbbToday.Image")));
            this.tbbToday.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbToday.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbToday.Name = "tbbToday";
            this.tbbToday.Size = new System.Drawing.Size(57, 39);
            this.tbbToday.Text = "היום";
            this.tbbToday.ToolTipText = "הצגת התורים של היום";
            this.tbbToday.Click += new System.EventHandler(this.TbbTodayClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 42);
            // 
            // tbbPrint
            // 
            this.tbbPrint.AutoSize = false;
            this.tbbPrint.AutoToolTip = false;
            this.tbbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbPrint.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tbbPrint.Image")));
            this.tbbPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbPrint.Name = "tbbPrint";
            this.tbbPrint.Size = new System.Drawing.Size(35, 39);
            this.tbbPrint.Text = "הדפס";
            this.tbbPrint.ToolTipText = "הדפסה של תמונת היומן הכוללת";
            this.tbbPrint.Click += new System.EventHandler(this.TbbPrintClick);
            // 
            // tbbEmail
            // 
            this.tbbEmail.AutoSize = false;
            this.tbbEmail.AutoToolTip = false;
            this.tbbEmail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbEmail.Image = global::ClientManage.Properties.Resources.mail;
            this.tbbEmail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbEmail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbEmail.Name = "tbbEmail";
            this.tbbEmail.Size = new System.Drawing.Size(35, 39);
            this.tbbEmail.Text = "שלח דוא\"ל";
            this.tbbEmail.ToolTipText = "שלח דוא\"ל";
            this.tbbEmail.Click += new System.EventHandler(this.TbbEmailClick);
            // 
            // tbbSendSMS
            // 
            this.tbbSendSMS.AutoSize = false;
            this.tbbSendSMS.AutoToolTip = false;
            this.tbbSendSMS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbSendSMS.Image = ((System.Drawing.Image)(resources.GetObject("tbbSendSMS.Image")));
            this.tbbSendSMS.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbSendSMS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbSendSMS.Name = "tbbSendSMS";
            this.tbbSendSMS.Size = new System.Drawing.Size(35, 39);
            this.tbbSendSMS.Text = "שלח הודעת SMS";
            this.tbbSendSMS.ToolTipText = "שלח הודעת SMS";
            this.tbbSendSMS.Click += new System.EventHandler(this.TbbSendSmsClick);
            // 
            // splitPhone
            // 
            this.splitPhone.AutoSize = false;
            this.splitPhone.AutoToolTip = false;
            this.splitPhone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.splitPhone.Image = global::ClientManage.Properties.Resources.tb_phone2;
            this.splitPhone.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.splitPhone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.splitPhone.Name = "splitPhone";
            this.splitPhone.Size = new System.Drawing.Size(40, 39);
            this.splitPhone.ToolTipText = "חיוג ללקוח";
            this.splitPhone.ButtonClick += new System.EventHandler(this.SplitPhoneButtonClick);
            this.splitPhone.DropDownOpening += new System.EventHandler(this.SplitPhoneDropDownOpening);
            // 
            // tbbNext
            // 
            this.tbbNext.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbbNext.AutoSize = false;
            this.tbbNext.AutoToolTip = false;
            this.tbbNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbNext.Image = global::ClientManage.Properties.Resources.prev;
            this.tbbNext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbNext.Margin = new System.Windows.Forms.Padding(4, 1, 0, 2);
            this.tbbNext.Name = "tbbNext";
            this.tbbNext.Size = new System.Drawing.Size(35, 39);
            this.tbbNext.Text = "עבור ליום הבא";
            this.tbbNext.ToolTipText = "עבור ליום הבא";
            this.tbbNext.Click += new System.EventHandler(this.TbbNextClick);
            // 
            // tbbPrev
            // 
            this.tbbPrev.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbbPrev.AutoSize = false;
            this.tbbPrev.AutoToolTip = false;
            this.tbbPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbPrev.Image = global::ClientManage.Properties.Resources.next;
            this.tbbPrev.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbPrev.Name = "tbbPrev";
            this.tbbPrev.Size = new System.Drawing.Size(35, 39);
            this.tbbPrev.Text = "עבור ליום הקודם";
            this.tbbPrev.ToolTipText = "עבור ליום הקודם";
            this.tbbPrev.Click += new System.EventHandler(this.TbbPrevClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 42);
            // 
            // cal
            // 
            this.cal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cal.BackColor = System.Drawing.Color.White;
            this.cal.CurrentDate = new System.DateTime(2008, 1, 1, 0, 0, 0, 0);
            this.cal.EndTime = "22:00";
            this.cal.Location = new System.Drawing.Point(183, 45);
            this.cal.Name = "cal";
            this.cal.Padding = new System.Windows.Forms.Padding(1);
            this.cal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cal.Size = new System.Drawing.Size(835, 636);
            this.cal.StartTime = "08:00";
            this.cal.TabIndex = 48;
            this.cal.TabStop = false;
            this.cal.SelectAppointment += new BizCare.Calendar.Library.EventDefinition.GeneralCubeEventHandler(this.CalSelectAppointment);
            this.cal.AddAppointment += new BizCare.Calendar.Library.EventDefinition.GeneralCubeEventHandler(this.CalAddAppointment);
            this.cal.PasteAppointment += new BizCare.Calendar.Library.EventDefinition.GeneralCubeEventHandler(this.CalPasteAppointment);
            this.cal.EditAppointment += new BizCare.Calendar.Library.EventDefinition.GeneralCubeEventHandler(this.CalEditAppointment);
            this.cal.DoubleClickAppointment += new BizCare.Calendar.Library.EventDefinition.GeneralCubeEventHandler(this.CalDoubleClickAppointment);
            this.cal.RemovedAppointment += new BizCare.Calendar.Library.EventDefinition.GeneralCubeEventHandler(this.CalRemovedAppointment);
            this.cal.TakePictureToAppointment += new BizCare.Calendar.Library.EventDefinition.GeneralCubeEventHandler(this.CalTakePictureToAppointment);
            this.cal.DoubleClickEmptyTimeline += new System.EventHandler(this.CalDoubleClickEmptyTimeLine);
            this.cal.DoubleClickAllDayEventSpace += new System.EventHandler(this.CalDoubleClickAllDayEventSpace);
            this.cal.CurrentDateChanged += new System.EventHandler(this.CalCurrentDateChanged);
            this.cal.CancelEditAppointment += new System.EventHandler(this.CalCancelEditAppointment);
            this.cal.WorkerExpanded += new System.EventHandler(this.CalWorkerExpanded);
            this.cal.MoveAppointment += new System.EventHandler(this.CalMoveAppointment);
            this.cal.SelectedScopeChanged += new System.EventHandler(this.CalSelectedScopeChanged);
            this.cal.BeforeRemoveAppointment += new System.ComponentModel.CancelEventHandler(this.CalBeforeRemovedAppointment);
            this.cal.DragDropCube += new System.EventHandler<BizCare.Calendar.Library.GeneralCubeEventArgs>(this.CalDragDropCube);
            this.cal.SendSmsReminder += new System.EventHandler(this.Cal_SendSmsReminder);
            this.cal.AddAttendees += new System.EventHandler(this.cal_AddAttendees);
            this.cal.ShowHistory += new System.EventHandler(this.cal_ShowHistory);
            // 
            // FormCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(1024, 686);
            this.Controls.Add(this.pnlAttachMsg);
            this.Controls.Add(this.cal);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "FormCalendar";
            this.Text = "frmCalendar";
            this.Load += new System.EventHandler(this.FrmCalendarLoad);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmCalendarPaint);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmCalendarKeyPress);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlRemainder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picView)).EndInit();
            this.pnlAttachMsg.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tbbPrint;
        private CalendarView cal;
        private ClientManage.UserControls.ImageComboBox imageComboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton tbbNew;
        private System.Windows.Forms.ToolStripButton tbbEdit;
        private System.Windows.Forms.ToolStripButton tbbDelete;
        private System.Windows.Forms.PictureBox picView;
        private System.Windows.Forms.Button btnClearClient;
        private System.Windows.Forms.Label lblLNCap;
        private System.Windows.Forms.Label lblFNCap;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Button btnAttachClient;
        internal System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblMsgWait1;
        private System.Windows.Forms.ToolStripButton tbbReport;
        private System.Windows.Forms.Panel pnlAttachMsg;
        private System.Windows.Forms.Label lblClientCaption;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.ComboBox cmbEndHour;
        private System.Windows.Forms.ComboBox cmbEndMin;
        private System.Windows.Forms.Label lblEndSep;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.ComboBox cmbStartHour;
        private System.Windows.Forms.ComboBox cmbStartMin;
        private System.Windows.Forms.Label lblStartSep;
        private System.Windows.Forms.CheckBox chkRemainder;
        private ClientManage.UserControls.XPFlatButton btnOk;
        private System.Windows.Forms.Label lblRemainder;
        private System.Windows.Forms.Panel pnlRemainder;
        private System.Windows.Forms.Label lblBaloon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.Button btnCarePick;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tbbEmail;
        private System.Windows.Forms.ToolStripButton tbbSendSMS;
        private System.Windows.Forms.ToolStripSplitButton splitPhone;
        private System.Windows.Forms.ToolStripButton tbbToday;
        private System.Windows.Forms.ToolStripButton tbbPrev;
        private System.Windows.Forms.ToolStripButton tbbNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbbArchive;
        private SHMonthView dtPicker;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}