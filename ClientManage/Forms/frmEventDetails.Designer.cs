namespace ClientManage.Forms
{
    partial class FormEventDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEventDetails));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tbbSave = new System.Windows.Forms.ToolStripButton();
            this.tbbSaveAndNew = new System.Windows.Forms.ToolStripButton();
            this.tbbPrint = new System.Windows.Forms.ToolStripButton();
            this.tbbDelete = new System.Windows.Forms.ToolStripButton();
            this.tbbClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbShowCal = new System.Windows.Forms.ToolStripButton();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cbAllDay = new System.Windows.Forms.CheckBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlClientDetails = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.picView = new System.Windows.Forms.PictureBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.btnClearClient = new System.Windows.Forms.Button();
            this.lblLastName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAttachClient = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbRemainder = new System.Windows.Forms.ComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMsgPast = new System.Windows.Forms.Label();
            this.cmbWorkers = new ClientManage.UserControls.ImageComboBox();
            this.informationBar1 = new ClientManage.UserControls.InformationBar();
            this.pnlRemark = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.carePicker1 = new ClientManage.UserControls.CarePicker();
            this.chkRemainder = new System.Windows.Forms.CheckBox();
            this.lblDateEnd = new System.Windows.Forms.Label();
            this.cmbEndHour = new System.Windows.Forms.ComboBox();
            this.cmbEndMin = new System.Windows.Forms.ComboBox();
            this.lblEndSep = new System.Windows.Forms.Label();
            this.cmbStartHour = new System.Windows.Forms.ComboBox();
            this.cmbStartMin = new System.Windows.Forms.ComboBox();
            this.lblStartSep = new System.Windows.Forms.Label();
            this.lblAppLength = new System.Windows.Forms.Label();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.cmbCategory = new ClientManage.UserControls.ImageComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblAttendee = new System.Windows.Forms.Label();
            this.toolStrip.SuspendLayout();
            this.pnlClientDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picView)).BeginInit();
            this.pnlRemark.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackgroundImage = global::ClientManage.Properties.Resources.toolbar_bg;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbSave,
            this.tbbSaveAndNew,
            this.tbbPrint,
            this.tbbDelete,
            this.tbbClose,
            this.toolStripSeparator1,
            this.tbbShowCal});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1024, 42);
            this.toolStrip.TabIndex = 57;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tbbSave
            // 
            this.tbbSave.AutoToolTip = false;
            this.tbbSave.Image = global::ClientManage.Properties.Resources.Floppy;
            this.tbbSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbSave.Name = "tbbSave";
            this.tbbSave.Size = new System.Drawing.Size(63, 39);
            this.tbbSave.Text = "שמור";
            this.tbbSave.ToolTipText = "שמירה וסגירת החלון  (Ctrl + S)";
            this.tbbSave.Click += new System.EventHandler(this.TbbSaveClick);
            // 
            // tbbSaveAndNew
            // 
            this.tbbSaveAndNew.AutoToolTip = false;
            this.tbbSaveAndNew.Image = ((System.Drawing.Image)(resources.GetObject("tbbSaveAndNew.Image")));
            this.tbbSaveAndNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbSaveAndNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbSaveAndNew.Name = "tbbSaveAndNew";
            this.tbbSaveAndNew.Size = new System.Drawing.Size(96, 39);
            this.tbbSaveAndNew.Text = "שמור וחדש";
            this.tbbSaveAndNew.ToolTipText = "שמירה ופתיחת תור חדש";
            this.tbbSaveAndNew.Click += new System.EventHandler(this.TbbSaveAndNewClick);
            // 
            // tbbPrint
            // 
            this.tbbPrint.AutoToolTip = false;
            this.tbbPrint.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tbbPrint.Image")));
            this.tbbPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbPrint.Name = "tbbPrint";
            this.tbbPrint.Size = new System.Drawing.Size(67, 39);
            this.tbbPrint.Text = "הדפס";
            this.tbbPrint.ToolTipText = "הדפסת פרטי התור";
            this.tbbPrint.Click += new System.EventHandler(this.TbbPrintClick);
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
            this.tbbDelete.Text = "מחק תור";
            this.tbbDelete.ToolTipText = "מחיקת התור הנוכחי";
            this.tbbDelete.Click += new System.EventHandler(this.TbbDeleteClick);
            // 
            // tbbClose
            // 
            this.tbbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbbClose.AutoToolTip = false;
            this.tbbClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbClose.Image = global::ClientManage.Properties.Resources.close_form2;
            this.tbbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbClose.Name = "tbbClose";
            this.tbbClose.Size = new System.Drawing.Size(125, 39);
            this.tbbClose.Text = "סגור / בטל עדכון";
            this.tbbClose.ToolTipText = "סגירת החלון וביטול כל השינויים  (Esc)";
            this.tbbClose.Click += new System.EventHandler(this.TbbCloseClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 42);
            // 
            // tbbShowCal
            // 
            this.tbbShowCal.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbbShowCal.AutoToolTip = false;
            this.tbbShowCal.Image = ((System.Drawing.Image)(resources.GetObject("tbbShowCal.Image")));
            this.tbbShowCal.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbShowCal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbShowCal.Name = "tbbShowCal";
            this.tbbShowCal.Size = new System.Drawing.Size(79, 39);
            this.tbbShowCal.Text = "הצג יומן";
            this.tbbShowCal.ToolTipText = "הצצה ליומן (החזק לחוץ)";
            this.tbbShowCal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TbbShowCalMouseDown);
            this.tbbShowCal.MouseLeave += new System.EventHandler(this.TbbShowCalMouseLeave);
            this.tbbShowCal.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TbbShowCalMouseUp);
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtSubject.Location = new System.Drawing.Point(199, 99);
            this.txtSubject.MaxLength = 255;
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(698, 23);
            this.txtSubject.TabIndex = 0;
            this.txtSubject.Enter += new System.EventHandler(this.TextBoxFocus);
            this.txtSubject.Leave += new System.EventHandler(this.TextBoxLostFocus);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(843, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 20);
            this.label1.TabIndex = 58;
            this.label1.Text = "תיאור:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(902, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 61;
            this.label2.Text = "שעת התחלה:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpStartDate.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.dtpStartDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(199)))), ((int)(((byte)(255)))));
            this.dtpStartDate.CustomFormat = "yyyy/MM/dd";
            this.dtpStartDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(765, 128);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.RightToLeftLayout = true;
            this.dtpStartDate.Size = new System.Drawing.Size(132, 22);
            this.dtpStartDate.TabIndex = 1;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.DtpStartDateValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(902, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 65;
            this.label4.Text = "שעת סיום:";
            // 
            // cbAllDay
            // 
            this.cbAllDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAllDay.AutoSize = true;
            this.cbAllDay.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cbAllDay.Location = new System.Drawing.Point(544, 157);
            this.cbAllDay.Name = "cbAllDay";
            this.cbAllDay.Size = new System.Drawing.Size(123, 18);
            this.cbAllDay.TabIndex = 5;
            this.cbAllDay.Text = "אירוע של יום שלם";
            this.cbAllDay.UseVisualStyleBackColor = true;
            this.cbAllDay.CheckedChanged += new System.EventHandler(this.CbAllDayCheckedChanged);
            // 
            // txtRemark
            // 
            this.txtRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemark.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtRemark.Location = new System.Drawing.Point(170, 0);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemark.Size = new System.Drawing.Size(700, 351);
            this.txtRemark.TabIndex = 8;
            this.txtRemark.Enter += new System.EventHandler(this.TextBoxFocus);
            this.txtRemark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtRemarkKeyDown);
            this.txtRemark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtRemarkKeyPress);
            this.txtRemark.Leave += new System.EventHandler(this.TextBoxLostFocus);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(921, 289);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 73;
            this.label6.Text = "הערות:";
            // 
            // pnlClientDetails
            // 
            this.pnlClientDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(227)))), ((int)(((byte)(233)))));
            this.pnlClientDetails.Controls.Add(this.label10);
            this.pnlClientDetails.Controls.Add(this.picView);
            this.pnlClientDetails.Controls.Add(this.lblFirstName);
            this.pnlClientDetails.Controls.Add(this.btnClearClient);
            this.pnlClientDetails.Controls.Add(this.lblLastName);
            this.pnlClientDetails.Controls.Add(this.label7);
            this.pnlClientDetails.Controls.Add(this.label8);
            this.pnlClientDetails.Controls.Add(this.btnAttachClient);
            this.pnlClientDetails.Location = new System.Drawing.Point(27, 85);
            this.pnlClientDetails.Name = "pnlClientDetails";
            this.pnlClientDetails.Padding = new System.Windows.Forms.Padding(1);
            this.pnlClientDetails.Size = new System.Drawing.Size(164, 195);
            this.pnlClientDetails.TabIndex = 9;
            this.pnlClientDetails.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlClientDetailsPaint);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(207)))), ((int)(((byte)(213)))));
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(107)))), ((int)(((byte)(113)))));
            this.label10.Location = new System.Drawing.Point(1, 1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(162, 17);
            this.label10.TabIndex = 59;
            this.label10.Text = "לקוח משוייך לתור";
            // 
            // picView
            // 
            this.picView.BackColor = System.Drawing.Color.White;
            this.picView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picView.Location = new System.Drawing.Point(19, 29);
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
            this.lblFirstName.Location = new System.Drawing.Point(2, 125);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(97, 17);
            this.lblFirstName.TabIndex = 57;
            this.lblFirstName.Text = "אאא בבב גגג";
            // 
            // btnClearClient
            // 
            this.btnClearClient.Image = global::ClientManage.Properties.Resources.delete_small;
            this.btnClearClient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearClient.Location = new System.Drawing.Point(18, 160);
            this.btnClearClient.Name = "btnClearClient";
            this.btnClearClient.Size = new System.Drawing.Size(128, 24);
            this.btnClearClient.TabIndex = 0;
            this.btnClearClient.Text = "    הסר לקוח מהתור";
            this.btnClearClient.UseVisualStyleBackColor = true;
            this.btnClearClient.Visible = false;
            this.btnClearClient.Click += new System.EventHandler(this.BtnClearClientClick);
            // 
            // lblLastName
            // 
            this.lblLastName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblLastName.Location = new System.Drawing.Point(2, 139);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(83, 17);
            this.lblLastName.TabIndex = 56;
            this.lblLastName.Text = "צוויגנבוים";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label7.Location = new System.Drawing.Point(83, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 17);
            this.label7.TabIndex = 49;
            this.label7.Text = "שם פרטי:";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label8.Location = new System.Drawing.Point(83, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 17);
            this.label8.TabIndex = 55;
            this.label8.Text = "שם משפחה:";
            // 
            // btnAttachClient
            // 
            this.btnAttachClient.Image = ((System.Drawing.Image)(resources.GetObject("btnAttachClient.Image")));
            this.btnAttachClient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAttachClient.Location = new System.Drawing.Point(18, 160);
            this.btnAttachClient.Name = "btnAttachClient";
            this.btnAttachClient.Size = new System.Drawing.Size(128, 24);
            this.btnAttachClient.TabIndex = 58;
            this.btnAttachClient.Text = "    שייך לקוח לתור...";
            this.btnAttachClient.UseVisualStyleBackColor = true;
            this.btnAttachClient.Click += new System.EventHandler(this.BtnAttachClientClick);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label9.Location = new System.Drawing.Point(921, 227);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 20);
            this.label9.TabIndex = 77;
            this.label9.Text = "עובד מטפל:";
            // 
            // cmbRemainder
            // 
            this.cmbRemainder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRemainder.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbRemainder.FormattingEnabled = true;
            this.cmbRemainder.Location = new System.Drawing.Point(199, 131);
            this.cmbRemainder.Name = "cmbRemainder";
            this.cmbRemainder.Size = new System.Drawing.Size(180, 22);
            this.cmbRemainder.TabIndex = 6;
            this.cmbRemainder.EnabledChanged += new System.EventHandler(this.CmbEnabledChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "workers.jpg");
            this.imageList1.Images.SetKeyName(1, "worker_nopic.jpg");
            this.imageList1.Images.SetKeyName(2, "select_worker2.jpg");
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(187)))), ((int)(((byte)(193)))));
            this.label14.Location = new System.Drawing.Point(199, 192);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(799, 1);
            this.label14.TabIndex = 80;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(187)))), ((int)(((byte)(193)))));
            this.label3.Location = new System.Drawing.Point(198, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(799, 1);
            this.label3.TabIndex = 81;
            // 
            // lblMsgPast
            // 
            this.lblMsgPast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(220)))), ((int)(((byte)(227)))));
            this.lblMsgPast.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMsgPast.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblMsgPast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMsgPast.Image = global::ClientManage.Properties.Resources.info;
            this.lblMsgPast.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMsgPast.Location = new System.Drawing.Point(170, 351);
            this.lblMsgPast.Name = "lblMsgPast";
            this.lblMsgPast.Size = new System.Drawing.Size(700, 19);
            this.lblMsgPast.TabIndex = 88;
            this.lblMsgPast.Text = "       שים לב! תור זה התרחש בעבר";
            this.lblMsgPast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMsgPast.Visible = false;
            this.lblMsgPast.Paint += new System.Windows.Forms.PaintEventHandler(this.LblMsgPastPaint);
            // 
            // cmbWorkers
            // 
            this.cmbWorkers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbWorkers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbWorkers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkers.FormattingEnabled = true;
            this.cmbWorkers.ImageList = this.imageList1;
            this.cmbWorkers.ItemHeight = 48;
            this.cmbWorkers.Location = new System.Drawing.Point(733, 224);
            this.cmbWorkers.Name = "cmbWorkers";
            this.cmbWorkers.Size = new System.Drawing.Size(164, 54);
            this.cmbWorkers.TabIndex = 7;
            this.cmbWorkers.SelectedIndexChanged += new System.EventHandler(this.CmbWorkersSelectedIndexChanged);
            // 
            // informationBar1
            // 
            this.informationBar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("informationBar1.BackgroundImage")));
            this.informationBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.informationBar1.Image = null;
            this.informationBar1.LabelForeColor = System.Drawing.Color.DarkGreen;
            this.informationBar1.LabelImage = global::ClientManage.Properties.Resources.ok_small;
            this.informationBar1.LabelText = "      התור נשמר בהצלחה";
            this.informationBar1.LabelVisible = false;
            this.informationBar1.Location = new System.Drawing.Point(0, 42);
            this.informationBar1.Name = "informationBar1";
            this.informationBar1.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.informationBar1.PanelText = "InformationPanel";
            this.informationBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.informationBar1.Size = new System.Drawing.Size(1024, 28);
            this.informationBar1.TabIndex = 92;
            // 
            // pnlRemark
            // 
            this.pnlRemark.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRemark.Controls.Add(this.txtRemark);
            this.pnlRemark.Controls.Add(this.lblMsgPast);
            this.pnlRemark.Controls.Add(this.label5);
            this.pnlRemark.Controls.Add(this.carePicker1);
            this.pnlRemark.Location = new System.Drawing.Point(27, 282);
            this.pnlRemark.Name = "pnlRemark";
            this.pnlRemark.Size = new System.Drawing.Size(870, 370);
            this.pnlRemark.TabIndex = 93;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(243)))));
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(164, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(6, 370);
            this.label5.TabIndex = 91;
            // 
            // carePicker1
            // 
            this.carePicker1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(207)))), ((int)(((byte)(213)))));
            this.carePicker1.ButtonsVisible = false;
            this.carePicker1.Dock = System.Windows.Forms.DockStyle.Left;
            this.carePicker1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.carePicker1.Location = new System.Drawing.Point(0, 0);
            this.carePicker1.Name = "carePicker1";
            this.carePicker1.Padding = new System.Windows.Forms.Padding(2);
            this.carePicker1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.carePicker1.ShowBorder = true;
            this.carePicker1.ShowToolBar = false;
            this.carePicker1.Size = new System.Drawing.Size(164, 370);
            this.carePicker1.TabIndex = 90;
            this.carePicker1.BindingComplete += new System.EventHandler(this.CarePicker1BindingComplete);
            // 
            // chkRemainder
            // 
            this.chkRemainder.AutoSize = true;
            this.chkRemainder.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chkRemainder.Location = new System.Drawing.Point(381, 133);
            this.chkRemainder.Name = "chkRemainder";
            this.chkRemainder.Size = new System.Drawing.Size(72, 18);
            this.chkRemainder.TabIndex = 94;
            this.chkRemainder.Text = "תזכורת:";
            this.chkRemainder.UseVisualStyleBackColor = true;
            this.chkRemainder.CheckedChanged += new System.EventHandler(this.ChkRemainderCheckedChanged);
            // 
            // lblDateEnd
            // 
            this.lblDateEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateEnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(227)))), ((int)(((byte)(233)))));
            this.lblDateEnd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblDateEnd.Location = new System.Drawing.Point(765, 155);
            this.lblDateEnd.Name = "lblDateEnd";
            this.lblDateEnd.Size = new System.Drawing.Size(132, 23);
            this.lblDateEnd.TabIndex = 95;
            this.lblDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDateEnd.Paint += new System.Windows.Forms.PaintEventHandler(this.LblDateEndPaint);
            // 
            // cmbEndHour
            // 
            this.cmbEndHour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEndHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEndHour.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbEndHour.FormattingEnabled = true;
            this.cmbEndHour.Location = new System.Drawing.Point(673, 155);
            this.cmbEndHour.Name = "cmbEndHour";
            this.cmbEndHour.Size = new System.Drawing.Size(40, 22);
            this.cmbEndHour.TabIndex = 100;
            this.cmbEndHour.SelectedIndexChanged += new System.EventHandler(this.CmbEndHourSelectedIndexChanged);
            this.cmbEndHour.EnabledChanged += new System.EventHandler(this.CmbEnabledChanged);
            this.cmbEndHour.Enter += new System.EventHandler(this.CmbTimeEnter);
            this.cmbEndHour.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CmbTimeMouseDown);
            // 
            // cmbEndMin
            // 
            this.cmbEndMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEndMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEndMin.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbEndMin.FormattingEnabled = true;
            this.cmbEndMin.Items.AddRange(new object[] {
            "00",
            "15",
            "30",
            "45"});
            this.cmbEndMin.Location = new System.Drawing.Point(719, 155);
            this.cmbEndMin.Name = "cmbEndMin";
            this.cmbEndMin.Size = new System.Drawing.Size(40, 22);
            this.cmbEndMin.TabIndex = 99;
            this.cmbEndMin.SelectedIndexChanged += new System.EventHandler(this.CmbEndMinSelectedIndexChanged);
            this.cmbEndMin.EnabledChanged += new System.EventHandler(this.CmbEnabledChanged);
            this.cmbEndMin.Enter += new System.EventHandler(this.CmbTimeEnter);
            this.cmbEndMin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CmbTimeMouseDown);
            // 
            // lblEndSep
            // 
            this.lblEndSep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEndSep.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblEndSep.Location = new System.Drawing.Point(714, 158);
            this.lblEndSep.Name = "lblEndSep";
            this.lblEndSep.Size = new System.Drawing.Size(8, 19);
            this.lblEndSep.TabIndex = 101;
            this.lblEndSep.Text = ":";
            // 
            // cmbStartHour
            // 
            this.cmbStartHour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStartHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartHour.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbStartHour.FormattingEnabled = true;
            this.cmbStartHour.Location = new System.Drawing.Point(673, 128);
            this.cmbStartHour.Name = "cmbStartHour";
            this.cmbStartHour.Size = new System.Drawing.Size(40, 22);
            this.cmbStartHour.TabIndex = 97;
            this.cmbStartHour.SelectedIndexChanged += new System.EventHandler(this.CmbStartHourSelectedIndexChanged);
            this.cmbStartHour.EnabledChanged += new System.EventHandler(this.CmbEnabledChanged);
            this.cmbStartHour.Enter += new System.EventHandler(this.CmbTimeEnter);
            this.cmbStartHour.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CmbTimeMouseDown);
            // 
            // cmbStartMin
            // 
            this.cmbStartMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStartMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartMin.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbStartMin.FormattingEnabled = true;
            this.cmbStartMin.Items.AddRange(new object[] {
            "00",
            "15",
            "30",
            "45"});
            this.cmbStartMin.Location = new System.Drawing.Point(719, 128);
            this.cmbStartMin.Name = "cmbStartMin";
            this.cmbStartMin.Size = new System.Drawing.Size(40, 22);
            this.cmbStartMin.TabIndex = 96;
            this.cmbStartMin.SelectedIndexChanged += new System.EventHandler(this.CmbStartMinSelectedIndexChanged);
            this.cmbStartMin.EnabledChanged += new System.EventHandler(this.CmbEnabledChanged);
            this.cmbStartMin.Enter += new System.EventHandler(this.CmbTimeEnter);
            this.cmbStartMin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CmbTimeMouseDown);
            // 
            // lblStartSep
            // 
            this.lblStartSep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStartSep.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblStartSep.Location = new System.Drawing.Point(714, 131);
            this.lblStartSep.Name = "lblStartSep";
            this.lblStartSep.Size = new System.Drawing.Size(8, 19);
            this.lblStartSep.TabIndex = 98;
            this.lblStartSep.Text = ":";
            // 
            // lblAppLength
            // 
            this.lblAppLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAppLength.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblAppLength.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(127)))), ((int)(((byte)(133)))));
            this.lblAppLength.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAppLength.Location = new System.Drawing.Point(487, 128);
            this.lblAppLength.Name = "lblAppLength";
            this.lblAppLength.Size = new System.Drawing.Size(183, 20);
            this.lblAppLength.TabIndex = 102;
            this.lblAppLength.Text = "משך התור:...";
            this.lblAppLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "cmbColor2.png");
            this.imageList2.Images.SetKeyName(1, "cmbColor1.png");
            this.imageList2.Images.SetKeyName(2, "cmbColor3.png");
            this.imageList2.Images.SetKeyName(3, "cmbColor4.png");
            this.imageList2.Images.SetKeyName(4, "cmbColor5.png");
            this.imageList2.Images.SetKeyName(5, "cmbColor9.png");
            this.imageList2.Images.SetKeyName(6, "cmbColor7.png");
            this.imageList2.Images.SetKeyName(7, "cmbColor8.png");
            this.imageList2.Images.SetKeyName(8, "cmbColor6.png");
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label11.Location = new System.Drawing.Point(634, 227);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 20);
            this.label11.TabIndex = 104;
            this.label11.Text = "קטגוריה:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.ImageList = this.imageList2;
            this.cmbCategory.ItemHeight = 48;
            this.cmbCategory.Location = new System.Drawing.Point(445, 224);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(206, 54);
            this.cmbCategory.TabIndex = 103;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label12.Location = new System.Drawing.Point(310, 226);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 20);
            this.label12.TabIndex = 105;
            this.label12.Text = "נשלח זימון ל:";
            // 
            // lblAttendee
            // 
            this.lblAttendee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAttendee.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblAttendee.Location = new System.Drawing.Point(199, 246);
            this.lblAttendee.Name = "lblAttendee";
            this.lblAttendee.Size = new System.Drawing.Size(215, 20);
            this.lblAttendee.TabIndex = 106;
            // 
            // FormEventDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(1024, 665);
            this.CloseFormByEsc = true;
            this.Controls.Add(this.lblAttendee);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblAppLength);
            this.Controls.Add(this.cmbEndHour);
            this.Controls.Add(this.cmbEndMin);
            this.Controls.Add(this.lblEndSep);
            this.Controls.Add(this.cmbStartHour);
            this.Controls.Add(this.cmbStartMin);
            this.Controls.Add(this.lblStartSep);
            this.Controls.Add(this.lblDateEnd);
            this.Controls.Add(this.pnlRemark);
            this.Controls.Add(this.informationBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmbRemainder);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbWorkers);
            this.Controls.Add(this.pnlClientDetails);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbAllDay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.chkRemainder);
            this.KeyPreview = true;
            this.Name = "FormEventDetails";
            this.Text = "frmEventDetails";
            this.RequestForClose += new System.EventHandler(this.FrmEventDetailsRequestForClose);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEventDetailsFormClosing);
            this.Load += new System.EventHandler(this.FrmEventDetailsLoad);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmEventDetailsKeyDown);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.pnlClientDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picView)).EndInit();
            this.pnlRemark.ResumeLayout(false);
            this.pnlRemark.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tbbSave;
        private System.Windows.Forms.ToolStripButton tbbSaveAndNew;
        private System.Windows.Forms.ToolStripButton tbbPrint;
        private System.Windows.Forms.ToolStripButton tbbDelete;
        private System.Windows.Forms.ToolStripButton tbbClose;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbAllDay;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlClientDetails;
        private System.Windows.Forms.PictureBox picView;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Button btnClearClient;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAttachClient;
        private ClientManage.UserControls.ImageComboBox cmbWorkers;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbRemainder;
        internal System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMsgPast;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private ClientManage.UserControls.InformationBar informationBar1;
        private System.Windows.Forms.Panel pnlRemark;
        private System.Windows.Forms.ToolStripButton tbbShowCal;
        private System.Windows.Forms.CheckBox chkRemainder;
        private System.Windows.Forms.Label lblDateEnd;
        private System.Windows.Forms.ComboBox cmbEndHour;
        private System.Windows.Forms.ComboBox cmbEndMin;
        private System.Windows.Forms.Label lblEndSep;
        private System.Windows.Forms.ComboBox cmbStartHour;
        private System.Windows.Forms.ComboBox cmbStartMin;
        private System.Windows.Forms.Label lblStartSep;
        private System.Windows.Forms.Label lblAppLength;
        private ClientManage.UserControls.CarePicker carePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Label label11;
        private ClientManage.UserControls.ImageComboBox cmbCategory;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblAttendee;
    }
}