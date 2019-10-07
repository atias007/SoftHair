namespace ClientManage.Forms
{
    partial class FormSearchClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSearchClient));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tbbFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbAddNew = new System.Windows.Forms.ToolStripButton();
            this.tbbUpdate = new System.Windows.Forms.ToolStripButton();
            this.tbbMakeApp = new System.Windows.Forms.ToolStripButton();
            this.tbbDelete = new System.Windows.Forms.ToolStripButton();
            this.tbbPhotoAlbum = new System.Windows.Forms.ToolStripButton();
            this.tbbSub = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbPrint = new System.Windows.Forms.ToolStripButton();
            this.tbbSendSMS = new System.Windows.Forms.ToolStripButton();
            this.tbbEmail = new System.Windows.Forms.ToolStripButton();
            this.tbbStickers = new System.Windows.Forms.ToolStripButton();
            this.splitPhone = new System.Windows.Forms.ToolStripSplitButton();
            this.tbbPrev = new System.Windows.Forms.ToolStripButton();
            this.tbbNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.searchPanel1 = new ClientManage.UserControls.SearchPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClearSelect = new ClientManage.UserControls.XPFlatButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelectAll = new ClientManage.UserControls.XPFlatButton();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grdClients = new System.Windows.Forms.DataGridView();
            this.clmSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.clmPicture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPhones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCard = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDiv1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAlbum = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDiv2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSms = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMail = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStick = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCall = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdClients)).BeginInit();
            this.ctxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackgroundImage = global::ClientManage.Properties.Resources.toolbar_bg;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbFind,
            this.toolStripSeparator1,
            this.tbbAddNew,
            this.tbbUpdate,
            this.tbbMakeApp,
            this.tbbDelete,
            this.tbbPhotoAlbum,
            this.tbbSub,
            this.toolStripSeparator2,
            this.tbbPrint,
            this.tbbSendSMS,
            this.tbbEmail,
            this.tbbStickers,
            this.splitPhone,
            this.tbbPrev,
            this.tbbNext,
            this.toolStripSeparator3});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1024, 42);
            this.toolStrip.TabIndex = 46;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tbbFind
            // 
            this.tbbFind.AutoToolTip = false;
            this.tbbFind.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbFind.Image = ((System.Drawing.Image)(resources.GetObject("tbbFind.Image")));
            this.tbbFind.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbFind.Name = "tbbFind";
            this.tbbFind.Size = new System.Drawing.Size(97, 39);
            this.tbbFind.Text = "כרטיס לקוח";
            this.tbbFind.ToolTipText = "פתיחת כרטיס הלקוח המסומן (Enter)";
            this.tbbFind.Click += new System.EventHandler(this.TbbFind_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 42);
            // 
            // tbbAddNew
            // 
            this.tbbAddNew.AutoToolTip = false;
            this.tbbAddNew.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbAddNew.Image = ((System.Drawing.Image)(resources.GetObject("tbbAddNew.Image")));
            this.tbbAddNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbAddNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbAddNew.Name = "tbbAddNew";
            this.tbbAddNew.Size = new System.Drawing.Size(88, 39);
            this.tbbAddNew.Text = "לקוח חדש";
            this.tbbAddNew.ToolTipText = "פתיחת כרטיס לקוח חדש (Ctrl+N)";
            this.tbbAddNew.Click += new System.EventHandler(this.TbbAddNew_Click);
            // 
            // tbbUpdate
            // 
            this.tbbUpdate.AutoToolTip = false;
            this.tbbUpdate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbUpdate.Image = global::ClientManage.Properties.Resources.tb_edit2;
            this.tbbUpdate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbUpdate.Name = "tbbUpdate";
            this.tbbUpdate.Size = new System.Drawing.Size(97, 39);
            this.tbbUpdate.Text = "עדכן פרטים";
            this.tbbUpdate.ToolTipText = "עדכון פרטי הלקוח המסומן (Ctrl+E)";
            this.tbbUpdate.Click += new System.EventHandler(this.TbbUpdate_Click);
            // 
            // tbbMakeApp
            // 
            this.tbbMakeApp.AutoToolTip = false;
            this.tbbMakeApp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbMakeApp.Image = ((System.Drawing.Image)(resources.GetObject("tbbMakeApp.Image")));
            this.tbbMakeApp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbMakeApp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbMakeApp.Name = "tbbMakeApp";
            this.tbbMakeApp.Size = new System.Drawing.Size(79, 39);
            this.tbbMakeApp.Text = "קבע תור";
            this.tbbMakeApp.ToolTipText = "מעבר ליומן וקביעת תור ללקוח המסומן";
            this.tbbMakeApp.Click += new System.EventHandler(this.TbbMakeApp_Click);
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
            this.tbbDelete.Size = new System.Drawing.Size(86, 39);
            this.tbbDelete.Text = "מחק לקוח";
            this.tbbDelete.ToolTipText = "מחיקת הלקוח המסומן (Del)";
            this.tbbDelete.Click += new System.EventHandler(this.TbbDelete_Click);
            // 
            // tbbPhotoAlbum
            // 
            this.tbbPhotoAlbum.AutoToolTip = false;
            this.tbbPhotoAlbum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbPhotoAlbum.Image = ((System.Drawing.Image)(resources.GetObject("tbbPhotoAlbum.Image")));
            this.tbbPhotoAlbum.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbPhotoAlbum.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbPhotoAlbum.Name = "tbbPhotoAlbum";
            this.tbbPhotoAlbum.Size = new System.Drawing.Size(69, 39);
            this.tbbPhotoAlbum.Text = "אלבום";
            this.tbbPhotoAlbum.ToolTipText = "ניהול אלבום תמונות ללקוח";
            this.tbbPhotoAlbum.Click += new System.EventHandler(this.TbbPhotoAlbum_Click);
            // 
            // tbbSub
            // 
            this.tbbSub.AutoToolTip = false;
            this.tbbSub.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbSub.Image = global::ClientManage.Properties.Resources.ticket;
            this.tbbSub.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbSub.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbSub.Name = "tbbSub";
            this.tbbSub.Size = new System.Drawing.Size(64, 39);
            this.tbbSub.Text = "מנויים";
            this.tbbSub.ToolTipText = "ניהול מנויים ללקוח";
            this.tbbSub.Click += new System.EventHandler(this.TbbSub_Click);
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
            this.tbbPrint.Text = "הדפס (Ctrl+P)";
            this.tbbPrint.ToolTipText = "הדפסת פרטי הלקוח המסומן (Ctrl+P)";
            this.tbbPrint.Click += new System.EventHandler(this.TbbPrint_Click);
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
            this.tbbEmail.Click += new System.EventHandler(this.TbbEmail_Click);
            // 
            // tbbStickers
            // 
            this.tbbStickers.AutoSize = false;
            this.tbbStickers.AutoToolTip = false;
            this.tbbStickers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbStickers.Image = global::ClientManage.Properties.Resources.stickers;
            this.tbbStickers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbStickers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbStickers.Name = "tbbStickers";
            this.tbbStickers.Size = new System.Drawing.Size(35, 39);
            this.tbbStickers.Text = "הדפסת מדבקות";
            this.tbbStickers.ToolTipText = "הדפסת מדבקות";
            this.tbbStickers.Click += new System.EventHandler(this.TbbStickers_Click);
            // 
            // splitPhone
            // 
            this.splitPhone.AutoToolTip = false;
            this.splitPhone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.splitPhone.Image = global::ClientManage.Properties.Resources.tb_phone2;
            this.splitPhone.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.splitPhone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.splitPhone.Name = "splitPhone";
            this.splitPhone.Size = new System.Drawing.Size(40, 39);
            this.splitPhone.Text = "חייג";
            this.splitPhone.ToolTipText = "חייג ללקוח";
            this.splitPhone.ButtonClick += new System.EventHandler(this.SplitPhone_ButtonClick);
            this.splitPhone.DropDownOpening += new System.EventHandler(this.SplitPhone_DropDownOpening);
            // 
            // tbbPrev
            // 
            this.tbbPrev.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbbPrev.AutoSize = false;
            this.tbbPrev.AutoToolTip = false;
            this.tbbPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbPrev.Image = global::ClientManage.Properties.Resources.prev;
            this.tbbPrev.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbPrev.Margin = new System.Windows.Forms.Padding(4, 1, 0, 2);
            this.tbbPrev.Name = "tbbPrev";
            this.tbbPrev.Size = new System.Drawing.Size(35, 39);
            this.tbbPrev.Text = "עבור אל הלקוח הבא";
            this.tbbPrev.ToolTipText = "עבור אל הלקוח הבא";
            this.tbbPrev.Click += new System.EventHandler(this.TbbPrev_Click);
            // 
            // tbbNext
            // 
            this.tbbNext.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbbNext.AutoSize = false;
            this.tbbNext.AutoToolTip = false;
            this.tbbNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbNext.Image = global::ClientManage.Properties.Resources.next;
            this.tbbNext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbNext.Name = "tbbNext";
            this.tbbNext.Size = new System.Drawing.Size(35, 39);
            this.tbbNext.Text = "עבור אל הלקוח הקודם";
            this.tbbNext.ToolTipText = "עבור אל הלקוח הקודם";
            this.tbbNext.Click += new System.EventHandler(this.TbbNext_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 42);
            // 
            // searchPanel1
            // 
            this.searchPanel1.AlwaysOnFocus = false;
            this.searchPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("searchPanel1.BackgroundImage")));
            this.searchPanel1.DefaultSearchBoxText = "הזן טקסט לחיפוש לקוח...";
            this.searchPanel1.DelaySearchTextBox = 1300;
            this.searchPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPanel1.Image = ((System.Drawing.Image)(resources.GetObject("searchPanel1.Image")));
            this.searchPanel1.IsFilter = false;
            this.searchPanel1.Location = new System.Drawing.Point(0, 42);
            this.searchPanel1.Name = "searchPanel1";
            this.searchPanel1.PanelText = "חיפוש לקוח";
            this.searchPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.searchPanel1.SearchString = "";
            this.searchPanel1.Size = new System.Drawing.Size(1024, 28);
            this.searchPanel1.TabIndex = 47;
            this.searchPanel1.SearchClicked += new System.EventHandler(this.SearchPanel1_SearchClicked);
            this.searchPanel1.ClearClicked += new System.EventHandler(this.SearchPanel1_ClearClicked);
            this.searchPanel1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchPanel1_KeyDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(243)))));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.lblStatus);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 70);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.panel2.Size = new System.Drawing.Size(145, 595);
            this.panel2.TabIndex = 53;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClearSelect);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnSelectAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 64);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(50, 5, 5, 0);
            this.panel1.Size = new System.Drawing.Size(145, 57);
            this.panel1.TabIndex = 103;
            // 
            // btnClearSelect
            // 
            this.btnClearSelect.BackColor = System.Drawing.Color.White;
            this.btnClearSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClearSelect.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnClearSelect.Image")));
            this.btnClearSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearSelect.Location = new System.Drawing.Point(50, 29);
            this.btnClearSelect.Name = "btnClearSelect";
            this.btnClearSelect.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClearSelect.Size = new System.Drawing.Size(90, 22);
            this.btnClearSelect.TabIndex = 104;
            this.btnClearSelect.Text = "       נקה הכל";
            this.btnClearSelect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearSelect.Visible = false;
            this.btnClearSelect.Click += new System.EventHandler(this.BtnClearSelect_Click);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(50, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 2);
            this.label2.TabIndex = 103;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.BackColor = System.Drawing.Color.White;
            this.btnSelectAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSelectAll.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectAll.Image")));
            this.btnSelectAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectAll.Location = new System.Drawing.Point(50, 5);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSelectAll.Size = new System.Drawing.Size(90, 22);
            this.btnSelectAll.TabIndex = 102;
            this.btnSelectAll.Text = "       סמן הכל";
            this.btnSelectAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectAll.Click += new System.EventHandler(this.BtnSelectAll_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatus.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblStatus.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblStatus.Image = ((System.Drawing.Image)(resources.GetObject("lblStatus.Image")));
            this.lblStatus.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblStatus.Location = new System.Drawing.Point(0, 7);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(145, 57);
            this.lblStatus.TabIndex = 101;
            this.lblStatus.Text = "{0} לקוחות סומנו ברשימה";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblStatus.Visible = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Location = new System.Drawing.Point(0, 440);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 155);
            this.label1.TabIndex = 100;
            // 
            // grdClients
            // 
            this.grdClients.AllowUserToAddRows = false;
            this.grdClients.AllowUserToDeleteRows = false;
            this.grdClients.AllowUserToResizeRows = false;
            this.grdClients.BackgroundColor = System.Drawing.Color.White;
            this.grdClients.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdClients.ColumnHeadersHeight = 32;
            this.grdClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmSelect,
            this.clmImage,
            this.clmPicture,
            this.clmId,
            this.clmName,
            this.clmPhones,
            this.clmAddress,
            this.clmCreateDate});
            this.grdClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdClients.GridColor = System.Drawing.SystemColors.Control;
            this.grdClients.Location = new System.Drawing.Point(145, 70);
            this.grdClients.MultiSelect = false;
            this.grdClients.Name = "grdClients";
            this.grdClients.ReadOnly = true;
            this.grdClients.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdClients.RowHeadersVisible = false;
            this.grdClients.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdClients.RowTemplate.Height = 48;
            this.grdClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdClients.ShowEditingIcon = false;
            this.grdClients.Size = new System.Drawing.Size(879, 595);
            this.grdClients.TabIndex = 99;
            this.grdClients.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdClients_CellContentClick);
            this.grdClients.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GrdClients_CellMouseDoubleClick);
            this.grdClients.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GrdClients_ColumnHeaderMouseClick);
            this.grdClients.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GrdClients_DataBindingComplete);
            this.grdClients.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.GrdClients_DataError);
            this.grdClients.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrdClients_KeyDown);
            this.grdClients.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GrdClients_KeyPress);
            this.grdClients.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GrdClients_MouseDown);
            // 
            // clmSelect
            // 
            this.clmSelect.HeaderText = "";
            this.clmSelect.Name = "clmSelect";
            this.clmSelect.ReadOnly = true;
            this.clmSelect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmSelect.Width = 20;
            // 
            // clmImage
            // 
            this.clmImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clmImage.HeaderText = "תמונה";
            this.clmImage.Image = global::ClientManage.Properties.Resources.hourglass;
            this.clmImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.clmImage.MinimumWidth = 64;
            this.clmImage.Name = "clmImage";
            this.clmImage.ReadOnly = true;
            this.clmImage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmImage.Width = 64;
            // 
            // clmPicture
            // 
            this.clmPicture.DataPropertyName = "Picture";
            this.clmPicture.HeaderText = "Picture Filename";
            this.clmPicture.Name = "clmPicture";
            this.clmPicture.ReadOnly = true;
            this.clmPicture.Visible = false;
            // 
            // clmId
            // 
            this.clmId.DataPropertyName = "Id";
            this.clmId.HeaderText = "Id";
            this.clmId.Name = "clmId";
            this.clmId.ReadOnly = true;
            this.clmId.Visible = false;
            // 
            // clmName
            // 
            this.clmName.DataPropertyName = "FullName";
            this.clmName.HeaderText = "שם הלקוח";
            this.clmName.MinimumWidth = 50;
            this.clmName.Name = "clmName";
            this.clmName.ReadOnly = true;
            this.clmName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmName.Width = 140;
            // 
            // clmPhones
            // 
            this.clmPhones.DataPropertyName = "AllPhones";
            this.clmPhones.HeaderText = "מספרי טלפון";
            this.clmPhones.MinimumWidth = 50;
            this.clmPhones.Name = "clmPhones";
            this.clmPhones.ReadOnly = true;
            this.clmPhones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmPhones.Width = 290;
            // 
            // clmAddress
            // 
            this.clmAddress.DataPropertyName = "Address";
            this.clmAddress.HeaderText = "כתובת";
            this.clmAddress.Name = "clmAddress";
            this.clmAddress.ReadOnly = true;
            this.clmAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmAddress.Width = 230;
            // 
            // clmCreateDate
            // 
            this.clmCreateDate.DataPropertyName = "DateCreated";
            this.clmCreateDate.HeaderText = "תאריך רישום";
            this.clmCreateDate.Name = "clmCreateDate";
            this.clmCreateDate.ReadOnly = true;
            this.clmCreateDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmCreateDate.Width = 110;
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCard,
            this.mnuDiv1,
            this.mnuNew,
            this.mnuEdit,
            this.mnuCal,
            this.mnuDel,
            this.mnuAlbum,
            this.mnuDiv2,
            this.mnuPrint,
            this.mnuSms,
            this.mnuMail,
            this.mnuStick,
            this.mnuCall});
            this.ctxMenu.Name = "contextMenuStrip1";
            this.ctxMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctxMenu.Size = new System.Drawing.Size(181, 258);
            // 
            // mnuCard
            // 
            this.mnuCard.Image = ((System.Drawing.Image)(resources.GetObject("mnuCard.Image")));
            this.mnuCard.Name = "mnuCard";
            this.mnuCard.Size = new System.Drawing.Size(180, 22);
            this.mnuCard.Text = "כרטיס לקוח";
            this.mnuCard.Click += new System.EventHandler(this.MnuCard_Click);
            // 
            // mnuDiv1
            // 
            this.mnuDiv1.Name = "mnuDiv1";
            this.mnuDiv1.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuNew
            // 
            this.mnuNew.Image = global::ClientManage.Properties.Resources.new_small;
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuNew.Size = new System.Drawing.Size(180, 22);
            this.mnuNew.Text = "לקוח חדש";
            this.mnuNew.Click += new System.EventHandler(this.MnuNew_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Image = global::ClientManage.Properties.Resources.tb_edit_small;
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuEdit.Size = new System.Drawing.Size(180, 22);
            this.mnuEdit.Text = "עדכן פרטים";
            this.mnuEdit.Click += new System.EventHandler(this.MnuEdit_Click);
            // 
            // mnuCal
            // 
            this.mnuCal.Image = ((System.Drawing.Image)(resources.GetObject("mnuCal.Image")));
            this.mnuCal.Name = "mnuCal";
            this.mnuCal.Size = new System.Drawing.Size(180, 22);
            this.mnuCal.Text = "קבע תור";
            this.mnuCal.Click += new System.EventHandler(this.MnuCal_Click);
            // 
            // mnuDel
            // 
            this.mnuDel.Image = global::ClientManage.Properties.Resources.delete_small;
            this.mnuDel.Name = "mnuDel";
            this.mnuDel.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.mnuDel.Size = new System.Drawing.Size(180, 22);
            this.mnuDel.Text = "מחק לקוח";
            this.mnuDel.Click += new System.EventHandler(this.MnuDel_Click);
            // 
            // mnuAlbum
            // 
            this.mnuAlbum.Image = ((System.Drawing.Image)(resources.GetObject("mnuAlbum.Image")));
            this.mnuAlbum.Name = "mnuAlbum";
            this.mnuAlbum.Size = new System.Drawing.Size(180, 22);
            this.mnuAlbum.Text = "אלבום";
            this.mnuAlbum.Click += new System.EventHandler(this.MnuAlbum_Click);
            // 
            // mnuDiv2
            // 
            this.mnuDiv2.Name = "mnuDiv2";
            this.mnuDiv2.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuPrint
            // 
            this.mnuPrint.Image = global::ClientManage.Properties.Resources.print_small;
            this.mnuPrint.Name = "mnuPrint";
            this.mnuPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.mnuPrint.Size = new System.Drawing.Size(180, 22);
            this.mnuPrint.Text = "הדפס";
            this.mnuPrint.Click += new System.EventHandler(this.MnuPrint_Click);
            // 
            // mnuSms
            // 
            this.mnuSms.Image = global::ClientManage.Properties.Resources.send_small;
            this.mnuSms.Name = "mnuSms";
            this.mnuSms.Size = new System.Drawing.Size(180, 22);
            this.mnuSms.Text = "שלח SMS";
            this.mnuSms.Click += new System.EventHandler(this.MnuSms_Click);
            // 
            // mnuMail
            // 
            this.mnuMail.Image = global::ClientManage.Properties.Resources.mail_small;
            this.mnuMail.Name = "mnuMail";
            this.mnuMail.Size = new System.Drawing.Size(180, 22);
            this.mnuMail.Text = "שלח דוא\"ל";
            this.mnuMail.Click += new System.EventHandler(this.MnuMail_Click);
            // 
            // mnuStick
            // 
            this.mnuStick.Image = global::ClientManage.Properties.Resources.stickers_small;
            this.mnuStick.Name = "mnuStick";
            this.mnuStick.Size = new System.Drawing.Size(180, 22);
            this.mnuStick.Text = "הדפס מדבקה";
            this.mnuStick.Click += new System.EventHandler(this.MnuStick_Click);
            // 
            // mnuCall
            // 
            this.mnuCall.Image = global::ClientManage.Properties.Resources.call;
            this.mnuCall.Name = "mnuCall";
            this.mnuCall.Size = new System.Drawing.Size(180, 22);
            this.mnuCall.Text = "חייג";
            this.mnuCall.Click += new System.EventHandler(this.MnuCall_Click);
            // 
            // FormSearchClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1024, 665);
            this.Controls.Add(this.grdClients);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.searchPanel1);
            this.Controls.Add(this.toolStrip);
            this.KeyPreview = true;
            this.Name = "FormSearchClient";
            this.Load += new System.EventHandler(this.FrmSearchClient_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSearchClient_KeyDown);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdClients)).EndInit();
            this.ctxMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tbbAddNew;
        private System.Windows.Forms.ToolStripButton tbbUpdate;
        private System.Windows.Forms.ToolStripButton tbbFind;
        private System.Windows.Forms.ToolStripButton tbbPrint;
        private System.Windows.Forms.ToolStripButton tbbMakeApp;
        private System.Windows.Forms.ToolStripSplitButton splitPhone;
        private System.Windows.Forms.ToolStripButton tbbDelete;
        private ClientManage.UserControls.SearchPanel searchPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView grdClients;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tbbEmail;
        private System.Windows.Forms.ToolStripButton tbbSendSMS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton tbbPrev;
        private System.Windows.Forms.ToolStripButton tbbNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tbbPhotoAlbum;
        private System.Windows.Forms.ToolStripButton tbbStickers;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuCard;
        private System.Windows.Forms.ToolStripSeparator mnuDiv1;
        private System.Windows.Forms.ToolStripMenuItem mnuNew;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuCal;
        private System.Windows.Forms.ToolStripMenuItem mnuDel;
        private System.Windows.Forms.ToolStripMenuItem mnuAlbum;
        private System.Windows.Forms.ToolStripSeparator mnuDiv2;
        private System.Windows.Forms.ToolStripMenuItem mnuPrint;
        private System.Windows.Forms.ToolStripMenuItem mnuSms;
        private System.Windows.Forms.ToolStripMenuItem mnuMail;
        private System.Windows.Forms.ToolStripMenuItem mnuStick;
        private System.Windows.Forms.ToolStripMenuItem mnuCall;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmSelect;
        private System.Windows.Forms.DataGridViewImageColumn clmImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPicture;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPhones;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCreateDate;
        private System.Windows.Forms.Panel panel1;
        private ClientManage.UserControls.XPFlatButton btnSelectAll;
        private System.Windows.Forms.Label label2;
        private ClientManage.UserControls.XPFlatButton btnClearSelect;
        private System.Windows.Forms.ToolStripButton tbbSub;
    }
}
