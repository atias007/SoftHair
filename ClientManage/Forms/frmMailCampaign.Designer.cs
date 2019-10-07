namespace ClientManage.Forms
{
    partial class FormMailCampaign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMailCampaign));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tbbSend = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tbbClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbAddClient = new System.Windows.Forms.ToolStripButton();
            this.tbbUpdate = new System.Windows.Forms.ToolStripButton();
            this.tbbReset = new System.Windows.Forms.ToolStripButton();
            this.tbbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAttach = new System.Windows.Forms.ToolStripButton();
            this.cmbFiles = new System.Windows.Forms.ToolStripComboBox();
            this.btnRemove = new System.Windows.Forms.ToolStripButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalClients = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstClients = new System.Windows.Forms.ListView();
            this.clmClient = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblPreview = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.lnkRetry = new System.Windows.Forms.LinkLabel();
            this.lblConnecting = new System.Windows.Forms.Label();
            this.pnlPersons = new System.Windows.Forms.Panel();
            this.btnBrowse = new ClientManage.UserControls.XPFlatButton();
            this.btnCancelPerson = new System.Windows.Forms.Button();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.lblPersonText = new System.Windows.Forms.Label();
            this.txtPersonPhone = new System.Windows.Forms.TextBox();
            this.txtPersonName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lstMailTemplates = new System.Windows.Forms.ListBox();
            this.txtMailBody = new System.Windows.Forms.TextBox();
            this.ctxTBMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddName1 = new ClientManage.UserControls.XPFlatButton();
            this.txAddName2 = new ClientManage.UserControls.XPFlatButton();
            this.toolStrip.SuspendLayout();
            this.pnlPersons.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackgroundImage = global::ClientManage.Properties.Resources.toolbar_bg_small;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbSend,
            this.toolStripButton1,
            this.tbbClose,
            this.toolStripSeparator1,
            this.tbbAddClient,
            this.tbbUpdate,
            this.tbbReset,
            this.tbbDelete,
            this.toolStripSeparator2,
            this.toolStripSeparator3,
            this.btnAttach,
            this.cmbFiles,
            this.btnRemove});
            this.toolStrip.Location = new System.Drawing.Point(8, 28);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1008, 25);
            this.toolStrip.TabIndex = 58;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tbbSend
            // 
            this.tbbSend.AutoToolTip = false;
            this.tbbSend.Image = ((System.Drawing.Image)(resources.GetObject("tbbSend.Image")));
            this.tbbSend.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbSend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbSend.Name = "tbbSend";
            this.tbbSend.Size = new System.Drawing.Size(52, 22);
            this.tbbSend.Text = "שלח";
            this.tbbSend.ToolTipText = "שליחת דוא\"ל לכל הנמענים ברשימה";
            this.tbbSend.Click += new System.EventHandler(this.tbbSend_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoToolTip = false;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(111, 22);
            this.toolStripButton1.Text = "רשימת כתובות";
            this.toolStripButton1.ToolTipText = "פתיחת חלון תצוגה מקדימה של הדוא\"ל";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tbbClose
            // 
            this.tbbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbbClose.AutoToolTip = false;
            this.tbbClose.Image = global::ClientManage.Properties.Resources.close_form_small2;
            this.tbbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbClose.Name = "tbbClose";
            this.tbbClose.Size = new System.Drawing.Size(52, 22);
            this.tbbClose.Text = "סגור";
            this.tbbClose.ToolTipText = "סגירת החלון  (Esc)";
            this.tbbClose.Click += new System.EventHandler(this.TbbClose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbbAddClient
            // 
            this.tbbAddClient.AutoToolTip = false;
            this.tbbAddClient.Image = ((System.Drawing.Image)(resources.GetObject("tbbAddClient.Image")));
            this.tbbAddClient.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbAddClient.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbAddClient.Name = "tbbAddClient";
            this.tbbAddClient.Size = new System.Drawing.Size(85, 22);
            this.tbbAddClient.Text = "הוסף נמען";
            this.tbbAddClient.ToolTipText = "הוספת נמען חדש לרשימה";
            this.tbbAddClient.Click += new System.EventHandler(this.tbbAddClient_Click);
            // 
            // tbbUpdate
            // 
            this.tbbUpdate.AutoToolTip = false;
            this.tbbUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tbbUpdate.Image")));
            this.tbbUpdate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbUpdate.Name = "tbbUpdate";
            this.tbbUpdate.Size = new System.Drawing.Size(93, 22);
            this.tbbUpdate.Text = "עדכן פרטים";
            this.tbbUpdate.ToolTipText = "עדכון פרטי הנמען המסומן ברשימה";
            this.tbbUpdate.Click += new System.EventHandler(this.tbbUpdate_Click);
            // 
            // tbbReset
            // 
            this.tbbReset.AutoToolTip = false;
            this.tbbReset.Image = ((System.Drawing.Image)(resources.GetObject("tbbReset.Image")));
            this.tbbReset.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbReset.Name = "tbbReset";
            this.tbbReset.Size = new System.Drawing.Size(92, 22);
            this.tbbReset.Text = "אפס רשימה";
            this.tbbReset.ToolTipText = "איפוס השינויים ברשימה";
            this.tbbReset.Click += new System.EventHandler(this.tbbReset_Click);
            // 
            // tbbDelete
            // 
            this.tbbDelete.AutoToolTip = false;
            this.tbbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tbbDelete.Image")));
            this.tbbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbDelete.Name = "tbbDelete";
            this.tbbDelete.Size = new System.Drawing.Size(81, 22);
            this.tbbDelete.Text = "הסר נמען";
            this.tbbDelete.ToolTipText = "הסרת הנמען המסומן מתוך הרשימה";
            this.tbbDelete.Click += new System.EventHandler(this.tbbDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAttach
            // 
            this.btnAttach.AutoToolTip = false;
            this.btnAttach.Image = global::ClientManage.Properties.Resources.new_small;
            this.btnAttach.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAttach.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(80, 22);
            this.btnAttach.Text = "צרף קובץ";
            this.btnAttach.ToolTipText = "איפוס השינויים ברשימה";
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // cmbFiles
            // 
            this.cmbFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiles.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFiles.Name = "cmbFiles";
            this.cmbFiles.Size = new System.Drawing.Size(180, 25);
            this.cmbFiles.Visible = false;
            // 
            // btnRemove
            // 
            this.btnRemove.AutoToolTip = false;
            this.btnRemove.Image = global::ClientManage.Properties.Resources.cancel_small;
            this.btnRemove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(82, 22);
            this.btnRemove.Text = "הסר קובץ";
            this.btnRemove.ToolTipText = "איפוס השינויים ברשימה";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label7.Image = global::ClientManage.Properties.Resources.client_nophone_small;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(684, 626);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 17);
            this.label7.TabIndex = 64;
            this.label7.Text = "ללא כתובת";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Image = global::ClientManage.Properties.Resources.client_error_small;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(801, 626);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 63;
            this.label6.Text = "כתובת שגויה";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Image = global::ClientManage.Properties.Resources.client_ok_small;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(922, 626);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 62;
            this.label4.Text = "כתובת תקינה";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalClients
            // 
            this.lblTotalClients.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalClients.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblTotalClients.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTotalClients.Location = new System.Drawing.Point(668, 62);
            this.lblTotalClients.Name = "lblTotalClients";
            this.lblTotalClients.Size = new System.Drawing.Size(123, 16);
            this.lblTotalClients.TabIndex = 61;
            this.lblTotalClients.Text = "סה\"כ {0} נמענים";
            this.lblTotalClients.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(865, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 16);
            this.label1.TabIndex = 60;
            this.label1.Text = "רשימת נמענים:";
            // 
            // lstClients
            // 
            this.lstClients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmClient,
            this.clmEmail});
            this.lstClients.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lstClients.FullRowSelect = true;
            this.lstClients.HideSelection = false;
            this.lstClients.Location = new System.Drawing.Point(668, 78);
            this.lstClients.MultiSelect = false;
            this.lstClients.Name = "lstClients";
            this.lstClients.RightToLeftLayout = true;
            this.lstClients.ShowGroups = false;
            this.lstClients.Size = new System.Drawing.Size(338, 546);
            this.lstClients.SmallImageList = this.imageList1;
            this.lstClients.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstClients.TabIndex = 8;
            this.lstClients.UseCompatibleStateImageBehavior = false;
            this.lstClients.View = System.Windows.Forms.View.Details;
            this.lstClients.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstClients_MouseDoubleClick);
            // 
            // clmClient
            // 
            this.clmClient.Text = "שם לקוח";
            this.clmClient.Width = 125;
            // 
            // clmEmail
            // 
            this.clmEmail.Text = "כתובת דוא\"ל";
            this.clmEmail.Width = 178;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "client_ok.gif");
            this.imageList1.Images.SetKeyName(1, "client_error.gif");
            this.imageList1.Images.SetKeyName(2, "client_nophone.gif");
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Location = new System.Drawing.Point(668, 623);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(338, 23);
            this.label8.TabIndex = 65;
            this.label8.Paint += new System.Windows.Forms.PaintEventHandler(this.Label8_Paint);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(564, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 66;
            this.label2.Text = "בחר תבנית:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(564, 288);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "מאת:";
            // 
            // txtFrom
            // 
            this.txtFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFrom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFrom.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtFrom.Location = new System.Drawing.Point(18, 285);
            this.txtFrom.MaxLength = 255;
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.ReadOnly = true;
            this.txtFrom.Size = new System.Drawing.Size(599, 22);
            this.txtFrom.TabIndex = 1;
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtSubject.Location = new System.Drawing.Point(18, 313);
            this.txtSubject.MaxLength = 255;
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(599, 22);
            this.txtSubject.TabIndex = 2;
            this.txtSubject.Enter += new System.EventHandler(this.TextBox_Focus);
            this.txtSubject.Leave += new System.EventHandler(this.TextBox_LostFocus);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label9.Location = new System.Drawing.Point(564, 316);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 16);
            this.label9.TabIndex = 72;
            this.label9.Text = "נושא:";
            // 
            // lblPreview
            // 
            this.lblPreview.BackColor = System.Drawing.Color.White;
            this.lblPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPreview.Location = new System.Drawing.Point(18, 78);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(240, 200);
            this.lblPreview.TabIndex = 74;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label11.Location = new System.Drawing.Point(167, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 16);
            this.label11.TabIndex = 75;
            this.label11.Text = "תצוגה מקדימה:";
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
            this.btnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSend.Location = new System.Drawing.Point(564, 611);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(91, 35);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "     שלח  ";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lnkRetry
            // 
            this.lnkRetry.ActiveLinkColor = System.Drawing.Color.Black;
            this.lnkRetry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkRetry.AutoSize = true;
            this.lnkRetry.DisabledLinkColor = System.Drawing.Color.SlateGray;
            this.lnkRetry.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lnkRetry.LinkColor = System.Drawing.Color.SlateGray;
            this.lnkRetry.Location = new System.Drawing.Point(18, 631);
            this.lnkRetry.Name = "lnkRetry";
            this.lnkRetry.Size = new System.Drawing.Size(90, 15);
            this.lnkRetry.TabIndex = 44;
            this.lnkRetry.TabStop = true;
            this.lnkRetry.Text = "נסה להתחבר שוב";
            this.lnkRetry.Visible = false;
            this.lnkRetry.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRetry_LinkClicked);
            // 
            // lblConnecting
            // 
            this.lblConnecting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblConnecting.AutoSize = true;
            this.lblConnecting.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblConnecting.ForeColor = System.Drawing.Color.Maroon;
            this.lblConnecting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblConnecting.Location = new System.Drawing.Point(19, 631);
            this.lblConnecting.Name = "lblConnecting";
            this.lblConnecting.Size = new System.Drawing.Size(171, 15);
            this.lblConnecting.TabIndex = 81;
            this.lblConnecting.Text = "מתחבר לשרת הדואר, אנא המתן...";
            // 
            // pnlPersons
            // 
            this.pnlPersons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPersons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(227)))), ((int)(((byte)(233)))));
            this.pnlPersons.Controls.Add(this.btnBrowse);
            this.pnlPersons.Controls.Add(this.btnCancelPerson);
            this.pnlPersons.Controls.Add(this.btnAddPerson);
            this.pnlPersons.Controls.Add(this.lblPersonText);
            this.pnlPersons.Controls.Add(this.txtPersonPhone);
            this.pnlPersons.Controls.Add(this.txtPersonName);
            this.pnlPersons.Controls.Add(this.label10);
            this.pnlPersons.Controls.Add(this.label15);
            this.pnlPersons.Location = new System.Drawing.Point(668, 78);
            this.pnlPersons.Name = "pnlPersons";
            this.pnlPersons.Size = new System.Drawing.Size(338, 96);
            this.pnlPersons.TabIndex = 82;
            this.pnlPersons.Visible = false;
            this.pnlPersons.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPersons_Paint);
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.White;
            this.btnBrowse.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(6, 20);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBrowse.Size = new System.Drawing.Size(23, 22);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "...";
            this.btnBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnCancelPerson
            // 
            this.btnCancelPerson.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnCancelPerson.Location = new System.Drawing.Point(6, 68);
            this.btnCancelPerson.Name = "btnCancelPerson";
            this.btnCancelPerson.Size = new System.Drawing.Size(44, 23);
            this.btnCancelPerson.TabIndex = 4;
            this.btnCancelPerson.Text = "בטל";
            this.btnCancelPerson.UseVisualStyleBackColor = true;
            this.btnCancelPerson.Click += new System.EventHandler(this.btnCancelPerson_Click);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnAddPerson.Location = new System.Drawing.Point(50, 68);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(44, 23);
            this.btnAddPerson.TabIndex = 3;
            this.btnAddPerson.Text = "הוסף";
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // lblPersonText
            // 
            this.lblPersonText.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblPersonText.Location = new System.Drawing.Point(184, 2);
            this.lblPersonText.Name = "lblPersonText";
            this.lblPersonText.Size = new System.Drawing.Size(150, 16);
            this.lblPersonText.TabIndex = 13;
            this.lblPersonText.Text = "הוספת נמען חדש...";
            // 
            // txtPersonPhone
            // 
            this.txtPersonPhone.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtPersonPhone.Location = new System.Drawing.Point(6, 44);
            this.txtPersonPhone.MaxLength = 255;
            this.txtPersonPhone.Name = "txtPersonPhone";
            this.txtPersonPhone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPersonPhone.Size = new System.Drawing.Size(237, 22);
            this.txtPersonPhone.TabIndex = 2;
            this.txtPersonPhone.Enter += new System.EventHandler(this.TextBox_Focus);
            this.txtPersonPhone.Leave += new System.EventHandler(this.TextBox_LostFocus);
            // 
            // txtPersonName
            // 
            this.txtPersonName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtPersonName.Location = new System.Drawing.Point(29, 20);
            this.txtPersonName.MaxLength = 101;
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.Size = new System.Drawing.Size(214, 22);
            this.txtPersonName.TabIndex = 0;
            this.txtPersonName.Enter += new System.EventHandler(this.TextBox_Focus);
            this.txtPersonName.Leave += new System.EventHandler(this.TextBox_LostFocus);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label10.Location = new System.Drawing.Point(241, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 16);
            this.label10.TabIndex = 10;
            this.label10.Text = "כתובת דוא\"ל:";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label15.Location = new System.Drawing.Point(280, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 16);
            this.label15.TabIndex = 9;
            this.label15.Text = "שם הנמען:";
            // 
            // lstMailTemplates
            // 
            this.lstMailTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstMailTemplates.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lstMailTemplates.FormattingEnabled = true;
            this.lstMailTemplates.ItemHeight = 14;
            this.lstMailTemplates.Location = new System.Drawing.Point(270, 78);
            this.lstMailTemplates.Name = "lstMailTemplates";
            this.lstMailTemplates.Size = new System.Drawing.Size(385, 200);
            this.lstMailTemplates.TabIndex = 0;
            this.lstMailTemplates.SelectedIndexChanged += new System.EventHandler(this.lstMailTemplates_SelectedIndexChanged);
            // 
            // txtMailBody
            // 
            this.txtMailBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMailBody.ContextMenuStrip = this.ctxTBMenu;
            this.txtMailBody.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtMailBody.Location = new System.Drawing.Point(18, 365);
            this.txtMailBody.Multiline = true;
            this.txtMailBody.Name = "txtMailBody";
            this.txtMailBody.Size = new System.Drawing.Size(637, 235);
            this.txtMailBody.TabIndex = 4;
            this.txtMailBody.Enter += new System.EventHandler(this.TextBox_Focus);
            this.txtMailBody.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMailBody_KeyDown);
            this.txtMailBody.Leave += new System.EventHandler(this.TextBox_LostFocus);
            // 
            // ctxTBMenu
            // 
            this.ctxTBMenu.Name = "ctxTBMenu";
            this.ctxTBMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ctxTBMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctxTBMenu.ShowImageMargin = false;
            this.ctxTBMenu.ShowItemToolTips = false;
            this.ctxTBMenu.Size = new System.Drawing.Size(36, 4);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(564, 346);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 87;
            this.label3.Text = "תוכן ההודעה:";
            // 
            // txtAddName1
            // 
            this.txtAddName1.BackColor = System.Drawing.Color.White;
            this.txtAddName1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtAddName1.Image = global::ClientManage.Properties.Resources.pen;
            this.txtAddName1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtAddName1.Location = new System.Drawing.Point(18, 335);
            this.txtAddName1.Name = "txtAddName1";
            this.txtAddName1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAddName1.Size = new System.Drawing.Size(107, 22);
            this.txtAddName1.TabIndex = 3;
            this.txtAddName1.Text = "       הוסף שם נמען";
            this.txtAddName1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtAddName1.Click += new System.EventHandler(this.txtAddName1_Click);
            // 
            // txAddName2
            // 
            this.txAddName2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txAddName2.BackColor = System.Drawing.Color.White;
            this.txAddName2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txAddName2.Image = global::ClientManage.Properties.Resources.pen;
            this.txAddName2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txAddName2.Location = new System.Drawing.Point(18, 600);
            this.txAddName2.Name = "txAddName2";
            this.txAddName2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txAddName2.Size = new System.Drawing.Size(107, 22);
            this.txAddName2.TabIndex = 5;
            this.txAddName2.Text = "       הוסף שם נמען";
            this.txAddName2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txAddName2.Click += new System.EventHandler(this.txAddName2_Click);
            // 
            // FormMailCampaign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(1024, 668);
            this.CloseFormByEsc = true;
            this.Controls.Add(this.txAddName2);
            this.Controls.Add(this.txtAddName1);
            this.Controls.Add(this.txtMailBody);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstMailTemplates);
            this.Controls.Add(this.lnkRetry);
            this.Controls.Add(this.lblPreview);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.pnlPersons);
            this.Controls.Add(this.lblConnecting);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstClients);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.lblTotalClients);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormMailCampaign";
            this.Padding = new System.Windows.Forms.Padding(8, 28, 8, 8);
            this.ShowMaximizeControl = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "שליחת הודעת דוא\"ל";
            this.RequestForClose += new System.EventHandler(this.frmMailCampaign_RequestForClose);
            this.Activated += new System.EventHandler(this.frmMailCampaign_Activated);
            this.Load += new System.EventHandler(this.FrmMailCampaign_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblTotalClients, 0);
            this.Controls.SetChildIndex(this.toolStrip, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.lstClients, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.txtFrom, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.btnSend, 0);
            this.Controls.SetChildIndex(this.lblConnecting, 0);
            this.Controls.SetChildIndex(this.pnlPersons, 0);
            this.Controls.SetChildIndex(this.txtSubject, 0);
            this.Controls.SetChildIndex(this.lblPreview, 0);
            this.Controls.SetChildIndex(this.lnkRetry, 0);
            this.Controls.SetChildIndex(this.lstMailTemplates, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtMailBody, 0);
            this.Controls.SetChildIndex(this.txtAddName1, 0);
            this.Controls.SetChildIndex(this.txAddName2, 0);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.pnlPersons.ResumeLayout(false);
            this.pnlPersons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotalClients;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstClients;
        private System.Windows.Forms.ColumnHeader clmClient;
        private System.Windows.Forms.ColumnHeader clmEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.LinkLabel lnkRetry;
        private System.Windows.Forms.ToolStripButton tbbReset;
        private System.Windows.Forms.ToolStripButton tbbDelete;
        private System.Windows.Forms.ToolStripButton tbbAddClient;
        private System.Windows.Forms.ToolStripButton tbbUpdate;
        private System.Windows.Forms.ToolStripButton tbbSend;
        private System.Windows.Forms.ToolStripButton tbbClose;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblConnecting;
        private System.Windows.Forms.Panel pnlPersons;
        private System.Windows.Forms.Button btnCancelPerson;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.Label lblPersonText;
        private System.Windows.Forms.TextBox txtPersonPhone;
        private System.Windows.Forms.TextBox txtPersonName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ListBox lstMailTemplates;
        private System.Windows.Forms.TextBox txtMailBody;
        private System.Windows.Forms.Label label3;
        private ClientManage.UserControls.XPFlatButton txtAddName1;
        private ClientManage.UserControls.XPFlatButton txAddName2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private ClientManage.UserControls.XPFlatButton btnBrowse;
        private System.Windows.Forms.ContextMenuStrip ctxTBMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnRemove;
        private System.Windows.Forms.ToolStripComboBox cmbFiles;
        private System.Windows.Forms.ToolStripButton btnAttach;
    }
}
