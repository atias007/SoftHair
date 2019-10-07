namespace ClientManage.Forms
{
    partial class FormPhonebook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPhonebook));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.tbbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbPrint = new System.Windows.Forms.ToolStripButton();
            this.tbbEmail = new System.Windows.Forms.ToolStripButton();
            this.tbbSendSMS = new System.Windows.Forms.ToolStripButton();
            this.splitPhone = new System.Windows.Forms.ToolStripSplitButton();
            this.tbbNext = new System.Windows.Forms.ToolStripButton();
            this.tbbPrev = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRequestCall = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.searchPanel1 = new ClientManage.UserControls.SearchPanel();
            this.lblPhoneBookTabs = new System.Windows.Forms.Panel();
            this.phoneBookButton23 = new ClientManage.UserControls.PhonebookButton();
            this.phoneBookButton22 = new ClientManage.UserControls.PhonebookButton();
            this.phoneBookButton21 = new ClientManage.UserControls.PhonebookButton();
            this.phoneBookButton20 = new ClientManage.UserControls.PhonebookButton();
            this.phoneBookButton19 = new ClientManage.UserControls.PhonebookButton();
            this.phoneBookButton18 = new ClientManage.UserControls.PhonebookButton();
            this.phoneBookButton17 = new ClientManage.UserControls.PhonebookButton();
            this.phoneBookButton16 = new ClientManage.UserControls.PhonebookButton();
            this.phoneBookButton15 = new ClientManage.UserControls.PhonebookButton();
            this.phoneBookButton14 = new ClientManage.UserControls.PhonebookButton();
            this.phoneBookButton13 = new ClientManage.UserControls.PhonebookButton();
            this.phoneBookButton12 = new ClientManage.UserControls.PhonebookButton();
            this.phoneBookButton11 = new ClientManage.UserControls.PhonebookButton();
            this.phoneBookButton10 = new ClientManage.UserControls.PhonebookButton();
            this.phoneBookButton9 = new ClientManage.UserControls.PhonebookButton();
            this.phoneBookButton8 = new ClientManage.UserControls.PhonebookButton();
            this.phoneBookButton7 = new ClientManage.UserControls.PhonebookButton();
            this.phoneBookButton6 = new ClientManage.UserControls.PhonebookButton();
            this.phoneBookButton5 = new ClientManage.UserControls.PhonebookButton();
            this.phoneBookButton4 = new ClientManage.UserControls.PhonebookButton();
            this.phoneBookButton3 = new ClientManage.UserControls.PhonebookButton();
            this.phoneBookButton2 = new ClientManage.UserControls.PhonebookButton();
            this.phoneBookButton1 = new ClientManage.UserControls.PhonebookButton();
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip.SuspendLayout();
            this.lblPhoneBookTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackgroundImage = global::ClientManage.Properties.Resources.toolbar_bg;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton4,
            this.tbbDelete,
            this.toolStripSeparator1,
            this.tbbPrint,
            this.tbbEmail,
            this.tbbSendSMS,
            this.splitPhone,
            this.tbbNext,
            this.tbbPrev,
            this.toolStripSeparator2});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1024, 42);
            this.toolStrip.TabIndex = 47;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoToolTip = false;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(115, 39);
            this.toolStripButton1.Text = "איש קשר חדש";
            this.toolStripButton1.ToolTipText = "פתיחת כרטיס איש קשר חדש";
            this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.AutoToolTip = false;
            this.toolStripButton4.Image = global::ClientManage.Properties.Resources.tb_edit2;
            this.toolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(101, 39);
            this.toolStripButton4.Text = "עדכן פרטים";
            this.toolStripButton4.ToolTipText = "עדכון פרטי איש הקשר המסומן";
            this.toolStripButton4.Click += new System.EventHandler(this.ToolStripButton4_Click);
            // 
            // tbbDelete
            // 
            this.tbbDelete.AutoToolTip = false;
            this.tbbDelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbDelete.ForeColor = System.Drawing.Color.SaddleBrown;
            this.tbbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tbbDelete.Image")));
            this.tbbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbDelete.Name = "tbbDelete";
            this.tbbDelete.Size = new System.Drawing.Size(107, 39);
            this.tbbDelete.Text = "מחק איש קשר";
            this.tbbDelete.ToolTipText = "מחיקת איש הקשר המסומן";
            this.tbbDelete.Click += new System.EventHandler(this.TbbDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 42);
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
            this.tbbPrint.ToolTipText = "הדפסת כל אנשי הקשר המופיעים";
            this.tbbPrint.Click += new System.EventHandler(this.TbbPrint_Click);
            // 
            // tbbEmail
            // 
            this.tbbEmail.AutoSize = false;
            this.tbbEmail.AutoToolTip = false;
            this.tbbEmail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbEmail.Image = ((System.Drawing.Image)(resources.GetObject("tbbEmail.Image")));
            this.tbbEmail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbEmail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbEmail.Name = "tbbEmail";
            this.tbbEmail.Size = new System.Drawing.Size(35, 39);
            this.tbbEmail.Text = "שלח דוא\"ל";
            this.tbbEmail.ToolTipText = "שלח דוא\"ל";
            this.tbbEmail.Click += new System.EventHandler(this.TbbEmail_Click);
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
            this.tbbSendSMS.Click += new System.EventHandler(this.TbbSendSms_Click);
            // 
            // splitPhone
            // 
            this.splitPhone.AutoToolTip = false;
            this.splitPhone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.splitPhone.Image = ((System.Drawing.Image)(resources.GetObject("splitPhone.Image")));
            this.splitPhone.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.splitPhone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.splitPhone.Name = "splitPhone";
            this.splitPhone.Size = new System.Drawing.Size(40, 39);
            this.splitPhone.Text = "חייג";
            this.splitPhone.ToolTipText = "חיוג אל איש הקשר המסומן";
            this.splitPhone.ButtonClick += new System.EventHandler(this.SplitPhone_ButtonClick);
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
            this.tbbNext.Text = "עבור לאיש קשר הבא";
            this.tbbNext.ToolTipText = "עבור לאיש קשר הבא";
            this.tbbNext.Click += new System.EventHandler(this.TbbNext_Click);
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
            this.tbbPrev.Text = "עבור לאיש קשר הקודם";
            this.tbbPrev.ToolTipText = "עבור לאיש קשר הקודם";
            this.tbbPrev.Click += new System.EventHandler(this.TbbPrev_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 42);
            // 
            // mnuRequestCall
            // 
            this.mnuRequestCall.Name = "mnuRequestCall";
            this.mnuRequestCall.Size = new System.Drawing.Size(61, 4);
            // 
            // searchPanel1
            // 
            this.searchPanel1.AlwaysOnFocus = false;
            this.searchPanel1.BackgroundImage = global::ClientManage.Properties.Resources.search_panel_bgblue;
            this.searchPanel1.DefaultSearchBoxText = "הזן טקסט לחיפוש איש קשר...";
            this.searchPanel1.DelaySearchTextBox = 1300;
            this.searchPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPanel1.Image = global::ClientManage.Properties.Resources.search_panel_logo;
            this.searchPanel1.IsFilter = false;
            this.searchPanel1.Location = new System.Drawing.Point(0, 42);
            this.searchPanel1.Name = "searchPanel1";
            this.searchPanel1.PanelText = "אלפון - אנשי קשר";
            this.searchPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.searchPanel1.SearchString = "";
            this.searchPanel1.Size = new System.Drawing.Size(1024, 28);
            this.searchPanel1.TabIndex = 99;
            this.searchPanel1.SearchClicked += new System.EventHandler(this.SearchPanel1_SearchClicked);
            this.searchPanel1.ClearClicked += new System.EventHandler(this.SearchPanel1_ClearClicked);
            // 
            // lblPhoneBookTabs
            // 
            this.lblPhoneBookTabs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.lblPhoneBookTabs.Controls.Add(this.phoneBookButton23);
            this.lblPhoneBookTabs.Controls.Add(this.phoneBookButton22);
            this.lblPhoneBookTabs.Controls.Add(this.phoneBookButton21);
            this.lblPhoneBookTabs.Controls.Add(this.phoneBookButton20);
            this.lblPhoneBookTabs.Controls.Add(this.phoneBookButton19);
            this.lblPhoneBookTabs.Controls.Add(this.phoneBookButton18);
            this.lblPhoneBookTabs.Controls.Add(this.phoneBookButton17);
            this.lblPhoneBookTabs.Controls.Add(this.phoneBookButton16);
            this.lblPhoneBookTabs.Controls.Add(this.phoneBookButton15);
            this.lblPhoneBookTabs.Controls.Add(this.phoneBookButton14);
            this.lblPhoneBookTabs.Controls.Add(this.phoneBookButton13);
            this.lblPhoneBookTabs.Controls.Add(this.phoneBookButton12);
            this.lblPhoneBookTabs.Controls.Add(this.phoneBookButton11);
            this.lblPhoneBookTabs.Controls.Add(this.phoneBookButton10);
            this.lblPhoneBookTabs.Controls.Add(this.phoneBookButton9);
            this.lblPhoneBookTabs.Controls.Add(this.phoneBookButton8);
            this.lblPhoneBookTabs.Controls.Add(this.phoneBookButton7);
            this.lblPhoneBookTabs.Controls.Add(this.phoneBookButton6);
            this.lblPhoneBookTabs.Controls.Add(this.phoneBookButton5);
            this.lblPhoneBookTabs.Controls.Add(this.phoneBookButton4);
            this.lblPhoneBookTabs.Controls.Add(this.phoneBookButton3);
            this.lblPhoneBookTabs.Controls.Add(this.phoneBookButton2);
            this.lblPhoneBookTabs.Controls.Add(this.phoneBookButton1);
            this.lblPhoneBookTabs.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPhoneBookTabs.Location = new System.Drawing.Point(931, 70);
            this.lblPhoneBookTabs.Name = "lblPhoneBookTabs";
            this.lblPhoneBookTabs.Size = new System.Drawing.Size(93, 595);
            this.lblPhoneBookTabs.TabIndex = 56;
            // 
            // phoneBookButton23
            // 
            this.phoneBookButton23.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("phoneBookButton23.BackgroundImage")));
            this.phoneBookButton23.Caption = "ת";
            this.phoneBookButton23.Location = new System.Drawing.Point(22, 541);
            this.phoneBookButton23.Name = "phoneBookButton23";
            this.phoneBookButton23.Size = new System.Drawing.Size(45, 18);
            this.phoneBookButton23.TabIndex = 22;
            this.phoneBookButton23.ButtonClick += new System.EventHandler(this.PhoneBookButton1_Click);
            // 
            // phoneBookButton22
            // 
            this.phoneBookButton22.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("phoneBookButton22.BackgroundImage")));
            this.phoneBookButton22.Caption = "ש";
            this.phoneBookButton22.Location = new System.Drawing.Point(22, 517);
            this.phoneBookButton22.Name = "phoneBookButton22";
            this.phoneBookButton22.Size = new System.Drawing.Size(45, 18);
            this.phoneBookButton22.TabIndex = 21;
            this.phoneBookButton22.ButtonClick += new System.EventHandler(this.PhoneBookButton1_Click);
            // 
            // phoneBookButton21
            // 
            this.phoneBookButton21.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("phoneBookButton21.BackgroundImage")));
            this.phoneBookButton21.Caption = "ר";
            this.phoneBookButton21.Location = new System.Drawing.Point(22, 493);
            this.phoneBookButton21.Name = "phoneBookButton21";
            this.phoneBookButton21.Size = new System.Drawing.Size(45, 18);
            this.phoneBookButton21.TabIndex = 20;
            this.phoneBookButton21.ButtonClick += new System.EventHandler(this.PhoneBookButton1_Click);
            // 
            // phoneBookButton20
            // 
            this.phoneBookButton20.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("phoneBookButton20.BackgroundImage")));
            this.phoneBookButton20.Caption = "ק";
            this.phoneBookButton20.Location = new System.Drawing.Point(22, 469);
            this.phoneBookButton20.Name = "phoneBookButton20";
            this.phoneBookButton20.Size = new System.Drawing.Size(45, 18);
            this.phoneBookButton20.TabIndex = 19;
            this.phoneBookButton20.ButtonClick += new System.EventHandler(this.PhoneBookButton1_Click);
            // 
            // phoneBookButton19
            // 
            this.phoneBookButton19.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("phoneBookButton19.BackgroundImage")));
            this.phoneBookButton19.Caption = "צ";
            this.phoneBookButton19.Location = new System.Drawing.Point(22, 445);
            this.phoneBookButton19.Name = "phoneBookButton19";
            this.phoneBookButton19.Size = new System.Drawing.Size(45, 18);
            this.phoneBookButton19.TabIndex = 18;
            this.phoneBookButton19.ButtonClick += new System.EventHandler(this.PhoneBookButton1_Click);
            // 
            // phoneBookButton18
            // 
            this.phoneBookButton18.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("phoneBookButton18.BackgroundImage")));
            this.phoneBookButton18.Caption = "פ";
            this.phoneBookButton18.Location = new System.Drawing.Point(22, 421);
            this.phoneBookButton18.Name = "phoneBookButton18";
            this.phoneBookButton18.Size = new System.Drawing.Size(45, 18);
            this.phoneBookButton18.TabIndex = 17;
            this.phoneBookButton18.ButtonClick += new System.EventHandler(this.PhoneBookButton1_Click);
            // 
            // phoneBookButton17
            // 
            this.phoneBookButton17.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("phoneBookButton17.BackgroundImage")));
            this.phoneBookButton17.Caption = "ע";
            this.phoneBookButton17.Location = new System.Drawing.Point(22, 397);
            this.phoneBookButton17.Name = "phoneBookButton17";
            this.phoneBookButton17.Size = new System.Drawing.Size(45, 18);
            this.phoneBookButton17.TabIndex = 16;
            this.phoneBookButton17.ButtonClick += new System.EventHandler(this.PhoneBookButton1_Click);
            // 
            // phoneBookButton16
            // 
            this.phoneBookButton16.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("phoneBookButton16.BackgroundImage")));
            this.phoneBookButton16.Caption = "ס";
            this.phoneBookButton16.Location = new System.Drawing.Point(22, 373);
            this.phoneBookButton16.Name = "phoneBookButton16";
            this.phoneBookButton16.Size = new System.Drawing.Size(45, 18);
            this.phoneBookButton16.TabIndex = 15;
            this.phoneBookButton16.ButtonClick += new System.EventHandler(this.PhoneBookButton1_Click);
            // 
            // phoneBookButton15
            // 
            this.phoneBookButton15.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("phoneBookButton15.BackgroundImage")));
            this.phoneBookButton15.Caption = "נ";
            this.phoneBookButton15.Location = new System.Drawing.Point(22, 349);
            this.phoneBookButton15.Name = "phoneBookButton15";
            this.phoneBookButton15.Size = new System.Drawing.Size(45, 18);
            this.phoneBookButton15.TabIndex = 14;
            this.phoneBookButton15.ButtonClick += new System.EventHandler(this.PhoneBookButton1_Click);
            // 
            // phoneBookButton14
            // 
            this.phoneBookButton14.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("phoneBookButton14.BackgroundImage")));
            this.phoneBookButton14.Caption = "מ";
            this.phoneBookButton14.Location = new System.Drawing.Point(22, 324);
            this.phoneBookButton14.Name = "phoneBookButton14";
            this.phoneBookButton14.Size = new System.Drawing.Size(45, 18);
            this.phoneBookButton14.TabIndex = 13;
            this.phoneBookButton14.ButtonClick += new System.EventHandler(this.PhoneBookButton1_Click);
            // 
            // phoneBookButton13
            // 
            this.phoneBookButton13.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("phoneBookButton13.BackgroundImage")));
            this.phoneBookButton13.Caption = "ל";
            this.phoneBookButton13.Location = new System.Drawing.Point(22, 300);
            this.phoneBookButton13.Name = "phoneBookButton13";
            this.phoneBookButton13.Size = new System.Drawing.Size(45, 18);
            this.phoneBookButton13.TabIndex = 12;
            this.phoneBookButton13.ButtonClick += new System.EventHandler(this.PhoneBookButton1_Click);
            // 
            // phoneBookButton12
            // 
            this.phoneBookButton12.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("phoneBookButton12.BackgroundImage")));
            this.phoneBookButton12.Caption = "כ";
            this.phoneBookButton12.Location = new System.Drawing.Point(22, 276);
            this.phoneBookButton12.Name = "phoneBookButton12";
            this.phoneBookButton12.Size = new System.Drawing.Size(45, 18);
            this.phoneBookButton12.TabIndex = 11;
            this.phoneBookButton12.ButtonClick += new System.EventHandler(this.PhoneBookButton1_Click);
            // 
            // phoneBookButton11
            // 
            this.phoneBookButton11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("phoneBookButton11.BackgroundImage")));
            this.phoneBookButton11.Caption = "י";
            this.phoneBookButton11.Location = new System.Drawing.Point(22, 252);
            this.phoneBookButton11.Name = "phoneBookButton11";
            this.phoneBookButton11.Size = new System.Drawing.Size(45, 18);
            this.phoneBookButton11.TabIndex = 10;
            this.phoneBookButton11.ButtonClick += new System.EventHandler(this.PhoneBookButton1_Click);
            // 
            // phoneBookButton10
            // 
            this.phoneBookButton10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("phoneBookButton10.BackgroundImage")));
            this.phoneBookButton10.Caption = "ט";
            this.phoneBookButton10.Location = new System.Drawing.Point(22, 228);
            this.phoneBookButton10.Name = "phoneBookButton10";
            this.phoneBookButton10.Size = new System.Drawing.Size(45, 18);
            this.phoneBookButton10.TabIndex = 9;
            this.phoneBookButton10.ButtonClick += new System.EventHandler(this.PhoneBookButton1_Click);
            // 
            // phoneBookButton9
            // 
            this.phoneBookButton9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("phoneBookButton9.BackgroundImage")));
            this.phoneBookButton9.Caption = "ח";
            this.phoneBookButton9.Location = new System.Drawing.Point(22, 204);
            this.phoneBookButton9.Name = "phoneBookButton9";
            this.phoneBookButton9.Size = new System.Drawing.Size(45, 18);
            this.phoneBookButton9.TabIndex = 8;
            this.phoneBookButton9.ButtonClick += new System.EventHandler(this.PhoneBookButton1_Click);
            // 
            // phoneBookButton8
            // 
            this.phoneBookButton8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("phoneBookButton8.BackgroundImage")));
            this.phoneBookButton8.Caption = "ז";
            this.phoneBookButton8.Location = new System.Drawing.Point(22, 180);
            this.phoneBookButton8.Name = "phoneBookButton8";
            this.phoneBookButton8.Size = new System.Drawing.Size(45, 18);
            this.phoneBookButton8.TabIndex = 7;
            this.phoneBookButton8.ButtonClick += new System.EventHandler(this.PhoneBookButton1_Click);
            // 
            // phoneBookButton7
            // 
            this.phoneBookButton7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("phoneBookButton7.BackgroundImage")));
            this.phoneBookButton7.Caption = "ו";
            this.phoneBookButton7.Location = new System.Drawing.Point(22, 156);
            this.phoneBookButton7.Name = "phoneBookButton7";
            this.phoneBookButton7.Size = new System.Drawing.Size(45, 18);
            this.phoneBookButton7.TabIndex = 6;
            this.phoneBookButton7.ButtonClick += new System.EventHandler(this.PhoneBookButton1_Click);
            // 
            // phoneBookButton6
            // 
            this.phoneBookButton6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("phoneBookButton6.BackgroundImage")));
            this.phoneBookButton6.Caption = "ה";
            this.phoneBookButton6.Location = new System.Drawing.Point(22, 132);
            this.phoneBookButton6.Name = "phoneBookButton6";
            this.phoneBookButton6.Size = new System.Drawing.Size(45, 18);
            this.phoneBookButton6.TabIndex = 5;
            this.phoneBookButton6.ButtonClick += new System.EventHandler(this.PhoneBookButton1_Click);
            // 
            // phoneBookButton5
            // 
            this.phoneBookButton5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("phoneBookButton5.BackgroundImage")));
            this.phoneBookButton5.Caption = "ד";
            this.phoneBookButton5.Location = new System.Drawing.Point(22, 108);
            this.phoneBookButton5.Name = "phoneBookButton5";
            this.phoneBookButton5.Size = new System.Drawing.Size(45, 18);
            this.phoneBookButton5.TabIndex = 4;
            this.phoneBookButton5.ButtonClick += new System.EventHandler(this.PhoneBookButton1_Click);
            // 
            // phoneBookButton4
            // 
            this.phoneBookButton4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("phoneBookButton4.BackgroundImage")));
            this.phoneBookButton4.Caption = "ג";
            this.phoneBookButton4.Location = new System.Drawing.Point(22, 84);
            this.phoneBookButton4.Name = "phoneBookButton4";
            this.phoneBookButton4.Size = new System.Drawing.Size(45, 18);
            this.phoneBookButton4.TabIndex = 3;
            this.phoneBookButton4.ButtonClick += new System.EventHandler(this.PhoneBookButton1_Click);
            // 
            // phoneBookButton3
            // 
            this.phoneBookButton3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("phoneBookButton3.BackgroundImage")));
            this.phoneBookButton3.Caption = "ב";
            this.phoneBookButton3.Location = new System.Drawing.Point(22, 60);
            this.phoneBookButton3.Name = "phoneBookButton3";
            this.phoneBookButton3.Size = new System.Drawing.Size(45, 18);
            this.phoneBookButton3.TabIndex = 2;
            this.phoneBookButton3.ButtonClick += new System.EventHandler(this.PhoneBookButton1_Click);
            // 
            // phoneBookButton2
            // 
            this.phoneBookButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("phoneBookButton2.BackgroundImage")));
            this.phoneBookButton2.Caption = "א";
            this.phoneBookButton2.Location = new System.Drawing.Point(22, 36);
            this.phoneBookButton2.Name = "phoneBookButton2";
            this.phoneBookButton2.Size = new System.Drawing.Size(45, 18);
            this.phoneBookButton2.TabIndex = 1;
            this.phoneBookButton2.ButtonClick += new System.EventHandler(this.PhoneBookButton1_Click);
            // 
            // phoneBookButton1
            // 
            this.phoneBookButton1.BackgroundImage = global::ClientManage.Properties.Resources.ph_button2;
            this.phoneBookButton1.Caption = "123";
            this.phoneBookButton1.Location = new System.Drawing.Point(22, 12);
            this.phoneBookButton1.Name = "phoneBookButton1";
            this.phoneBookButton1.Size = new System.Drawing.Size(45, 18);
            this.phoneBookButton1.TabIndex = 0;
            this.phoneBookButton1.ButtonClick += new System.EventHandler(this.PhoneBookButton1_Click);
            // 
            // flowPanel
            // 
            this.flowPanel.AutoScroll = true;
            this.flowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanel.Location = new System.Drawing.Point(0, 70);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Padding = new System.Windows.Forms.Padding(16);
            this.flowPanel.Size = new System.Drawing.Size(931, 595);
            this.flowPanel.TabIndex = 0;
            // 
            // FormPhonebook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 665);
            this.Controls.Add(this.flowPanel);
            this.Controls.Add(this.lblPhoneBookTabs);
            this.Controls.Add(this.searchPanel1);
            this.Controls.Add(this.toolStrip);
            this.KeyPreview = true;
            this.Name = "FormPhonebook";
            this.Text = "frmPhoneBook";
            this.Load += new System.EventHandler(this.FrmPhoneBook_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPhoneBook_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmPhoneBook_KeyPress);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.lblPhoneBookTabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton tbbPrint;
        private System.Windows.Forms.ToolStripButton tbbDelete;
        private System.Windows.Forms.ContextMenuStrip mnuRequestCall;
        private ClientManage.UserControls.SearchPanel searchPanel1;
        private System.Windows.Forms.Panel lblPhoneBookTabs;
        private ClientManage.UserControls.PhonebookButton phoneBookButton23;
        private ClientManage.UserControls.PhonebookButton phoneBookButton22;
        private ClientManage.UserControls.PhonebookButton phoneBookButton21;
        private ClientManage.UserControls.PhonebookButton phoneBookButton20;
        private ClientManage.UserControls.PhonebookButton phoneBookButton19;
        private ClientManage.UserControls.PhonebookButton phoneBookButton18;
        private ClientManage.UserControls.PhonebookButton phoneBookButton17;
        private ClientManage.UserControls.PhonebookButton phoneBookButton16;
        private ClientManage.UserControls.PhonebookButton phoneBookButton15;
        private ClientManage.UserControls.PhonebookButton phoneBookButton14;
        private ClientManage.UserControls.PhonebookButton phoneBookButton13;
        private ClientManage.UserControls.PhonebookButton phoneBookButton12;
        private ClientManage.UserControls.PhonebookButton phoneBookButton11;
        private ClientManage.UserControls.PhonebookButton phoneBookButton10;
        private ClientManage.UserControls.PhonebookButton phoneBookButton9;
        private ClientManage.UserControls.PhonebookButton phoneBookButton8;
        private ClientManage.UserControls.PhonebookButton phoneBookButton7;
        private ClientManage.UserControls.PhonebookButton phoneBookButton6;
        private ClientManage.UserControls.PhonebookButton phoneBookButton5;
        private ClientManage.UserControls.PhonebookButton phoneBookButton4;
        private ClientManage.UserControls.PhonebookButton phoneBookButton3;
        private ClientManage.UserControls.PhonebookButton phoneBookButton2;
        private ClientManage.UserControls.PhonebookButton phoneBookButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton splitPhone;
        private System.Windows.Forms.ToolStripButton tbbSendSMS;
        private System.Windows.Forms.ToolStripButton tbbEmail;
        private System.Windows.Forms.ToolStripButton tbbPrev;
        private System.Windows.Forms.ToolStripButton tbbNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
    }
}