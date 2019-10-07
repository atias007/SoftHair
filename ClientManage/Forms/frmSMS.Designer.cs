namespace ClientManage.Forms
{
    partial class FormSms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSms));
            this.lstClients = new System.Windows.Forms.ListView();
            this.clmClient = new System.Windows.Forms.ColumnHeader();
            this.clmCellPhone = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cmbMessages = new System.Windows.Forms.ComboBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.ctxTBMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalChars = new System.Windows.Forms.Label();
            this.lblTotalClients = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCredits = new System.Windows.Forms.Label();
            this.lblMaxChars = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlNewMsg = new System.Windows.Forms.Panel();
            this.btnMsgCancel = new System.Windows.Forms.Button();
            this.btnMsgSave = new System.Windows.Forms.Button();
            this.txtNewMsg = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlPersons = new System.Windows.Forms.Panel();
            this.btnBrowse = new ClientManage.UserControls.XPFlatButton();
            this.btnCancelPerson = new System.Windows.Forms.Button();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.lblPersonText = new System.Windows.Forms.Label();
            this.txtPersonPhone = new System.Windows.Forms.TextBox();
            this.txtPersonName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lnkRetry = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbbSend = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbAddUser = new System.Windows.Forms.ToolStripButton();
            this.tbbDeleteUser = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDeleteMsg = new ClientManage.UserControls.XPFlatButton();
            this.btnSaveMsg = new ClientManage.UserControls.XPFlatButton();
            this.xpFlatButton1 = new ClientManage.UserControls.XPFlatButton();
            this.pnlNewMsg.SuspendLayout();
            this.pnlPersons.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstClients
            // 
            this.lstClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmClient,
            this.clmCellPhone});
            this.lstClients.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lstClients.FullRowSelect = true;
            this.lstClients.HideSelection = false;
            this.lstClients.Location = new System.Drawing.Point(352, 84);
            this.lstClients.MultiSelect = false;
            this.lstClients.Name = "lstClients";
            this.lstClients.RightToLeftLayout = true;
            this.lstClients.ShowGroups = false;
            this.lstClients.Size = new System.Drawing.Size(246, 354);
            this.lstClients.SmallImageList = this.imageList1;
            this.lstClients.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstClients.TabIndex = 0;
            this.lstClients.UseCompatibleStateImageBehavior = false;
            this.lstClients.View = System.Windows.Forms.View.Details;
            // 
            // clmClient
            // 
            this.clmClient.Text = "שם לקוח";
            this.clmClient.Width = 125;
            // 
            // clmCellPhone
            // 
            this.clmCellPhone.Text = "מספר טלפון";
            this.clmCellPhone.Width = 90;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "client_ok.gif");
            this.imageList1.Images.SetKeyName(1, "client_error.gif");
            this.imageList1.Images.SetKeyName(2, "client_nophone.gif");
            // 
            // cmbMessages
            // 
            this.cmbMessages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMessages.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbMessages.FormattingEnabled = true;
            this.cmbMessages.Location = new System.Drawing.Point(69, 83);
            this.cmbMessages.Name = "cmbMessages";
            this.cmbMessages.Size = new System.Drawing.Size(277, 22);
            this.cmbMessages.TabIndex = 1;
            this.cmbMessages.SelectedIndexChanged += new System.EventHandler(this.CmbMessagesSelectedIndexChanged);
            // 
            // txtMsg
            // 
            this.txtMsg.ContextMenuStrip = this.ctxTBMenu;
            this.txtMsg.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtMsg.Location = new System.Drawing.Point(17, 129);
            this.txtMsg.MaxLength = 200;
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsg.Size = new System.Drawing.Size(329, 196);
            this.txtMsg.TabIndex = 2;
            this.txtMsg.TextChanged += new System.EventHandler(this.TxtMsgTextChanged);
            this.txtMsg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtMsgKeyDown);
            this.txtMsg.Leave += new System.EventHandler(this.TextBox_LostFocus);
            this.txtMsg.Enter += new System.EventHandler(this.TextBox_Focus);
            // 
            // ctxTBMenu
            // 
            this.ctxTBMenu.Name = "ctxTBMenu";
            this.ctxTBMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ctxTBMenu.ShowImageMargin = false;
            this.ctxTBMenu.ShowItemToolTips = false;
            this.ctxTBMenu.Size = new System.Drawing.Size(36, 4);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(504, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "רשימת נמענים:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(228, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "הודעות שמורות:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(225, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "תוכן ההודעה:";
            // 
            // lblTotalChars
            // 
            this.lblTotalChars.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblTotalChars.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTotalChars.Location = new System.Drawing.Point(17, 113);
            this.lblTotalChars.Name = "lblTotalChars";
            this.lblTotalChars.Size = new System.Drawing.Size(231, 16);
            this.lblTotalChars.TabIndex = 9;
            this.lblTotalChars.Text = "סה\"כ 0 תווים";
            this.lblTotalChars.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalClients
            // 
            this.lblTotalClients.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblTotalClients.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTotalClients.Location = new System.Drawing.Point(355, 67);
            this.lblTotalClients.Name = "lblTotalClients";
            this.lblTotalClients.Size = new System.Drawing.Size(123, 16);
            this.lblTotalClients.TabIndex = 11;
            this.lblTotalClients.Text = "סה\"כ 0 נמענים";
            this.lblTotalClients.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(212, 358);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "מקסימום תווים להודעה:";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label9.Location = new System.Drawing.Point(212, 378);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 16);
            this.label9.TabIndex = 22;
            this.label9.Text = "מספר הודעות בחשבונך:";
            // 
            // lblCredits
            // 
            this.lblCredits.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblCredits.ForeColor = System.Drawing.Color.Maroon;
            this.lblCredits.Location = new System.Drawing.Point(93, 378);
            this.lblCredits.Name = "lblCredits";
            this.lblCredits.Size = new System.Drawing.Size(120, 16);
            this.lblCredits.TabIndex = 23;
            this.lblCredits.Text = "בבדיקה, אנא המתן...";
            // 
            // lblMaxChars
            // 
            this.lblMaxChars.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblMaxChars.ForeColor = System.Drawing.Color.Maroon;
            this.lblMaxChars.Location = new System.Drawing.Point(167, 358);
            this.lblMaxChars.Name = "lblMaxChars";
            this.lblMaxChars.Size = new System.Drawing.Size(46, 16);
            this.lblMaxChars.TabIndex = 24;
            this.lblMaxChars.Text = "999";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Location = new System.Drawing.Point(352, 436);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(246, 23);
            this.label8.TabIndex = 27;
            this.label8.Paint += new System.Windows.Forms.PaintEventHandler(this.Label8Paint);
            // 
            // pnlNewMsg
            // 
            this.pnlNewMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(227)))), ((int)(((byte)(233)))));
            this.pnlNewMsg.Controls.Add(this.btnMsgCancel);
            this.pnlNewMsg.Controls.Add(this.btnMsgSave);
            this.pnlNewMsg.Controls.Add(this.txtNewMsg);
            this.pnlNewMsg.Controls.Add(this.label10);
            this.pnlNewMsg.Location = new System.Drawing.Point(17, 172);
            this.pnlNewMsg.Name = "pnlNewMsg";
            this.pnlNewMsg.Size = new System.Drawing.Size(329, 44);
            this.pnlNewMsg.TabIndex = 32;
            this.pnlNewMsg.Visible = false;
            this.pnlNewMsg.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlNewMsgPaint);
            // 
            // btnMsgCancel
            // 
            this.btnMsgCancel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnMsgCancel.Location = new System.Drawing.Point(2, 18);
            this.btnMsgCancel.Name = "btnMsgCancel";
            this.btnMsgCancel.Size = new System.Drawing.Size(44, 23);
            this.btnMsgCancel.TabIndex = 15;
            this.btnMsgCancel.Text = "בטל";
            this.btnMsgCancel.UseVisualStyleBackColor = true;
            this.btnMsgCancel.Click += new System.EventHandler(this.BtnMsgCancelClick);
            // 
            // btnMsgSave
            // 
            this.btnMsgSave.Enabled = false;
            this.btnMsgSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnMsgSave.Location = new System.Drawing.Point(46, 18);
            this.btnMsgSave.Name = "btnMsgSave";
            this.btnMsgSave.Size = new System.Drawing.Size(44, 23);
            this.btnMsgSave.TabIndex = 14;
            this.btnMsgSave.Text = "שמור";
            this.btnMsgSave.UseVisualStyleBackColor = true;
            this.btnMsgSave.Click += new System.EventHandler(this.BtnMsgSaveClick);
            // 
            // txtNewMsg
            // 
            this.txtNewMsg.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtNewMsg.Location = new System.Drawing.Point(91, 19);
            this.txtNewMsg.MaxLength = 50;
            this.txtNewMsg.Name = "txtNewMsg";
            this.txtNewMsg.Size = new System.Drawing.Size(234, 22);
            this.txtNewMsg.TabIndex = 9;
            this.txtNewMsg.TextChanged += new System.EventHandler(this.TxtNewMsgTextChanged);
            this.txtNewMsg.Leave += new System.EventHandler(this.TextBox_LostFocus);
            this.txtNewMsg.Enter += new System.EventHandler(this.TextBox_Focus);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label10.Location = new System.Drawing.Point(90, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(238, 16);
            this.label10.TabIndex = 8;
            this.label10.Text = "כותרת הודעה חדשה...";
            // 
            // pnlPersons
            // 
            this.pnlPersons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(227)))), ((int)(((byte)(233)))));
            this.pnlPersons.Controls.Add(this.btnBrowse);
            this.pnlPersons.Controls.Add(this.btnCancelPerson);
            this.pnlPersons.Controls.Add(this.btnAddPerson);
            this.pnlPersons.Controls.Add(this.lblPersonText);
            this.pnlPersons.Controls.Add(this.txtPersonPhone);
            this.pnlPersons.Controls.Add(this.txtPersonName);
            this.pnlPersons.Controls.Add(this.label13);
            this.pnlPersons.Controls.Add(this.label12);
            this.pnlPersons.Location = new System.Drawing.Point(352, 84);
            this.pnlPersons.Name = "pnlPersons";
            this.pnlPersons.Size = new System.Drawing.Size(246, 96);
            this.pnlPersons.TabIndex = 40;
            this.pnlPersons.Visible = false;
            this.pnlPersons.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlPersonsPaint);
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.White;
            this.btnBrowse.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(6, 19);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBrowse.Size = new System.Drawing.Size(23, 22);
            this.btnBrowse.TabIndex = 15;
            this.btnBrowse.Text = "...";
            this.btnBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowseClick);
            // 
            // btnCancelPerson
            // 
            this.btnCancelPerson.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnCancelPerson.Location = new System.Drawing.Point(6, 68);
            this.btnCancelPerson.Name = "btnCancelPerson";
            this.btnCancelPerson.Size = new System.Drawing.Size(44, 23);
            this.btnCancelPerson.TabIndex = 14;
            this.btnCancelPerson.Text = "בטל";
            this.btnCancelPerson.UseVisualStyleBackColor = true;
            this.btnCancelPerson.Click += new System.EventHandler(this.BtnCancelPersonClick);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnAddPerson.Location = new System.Drawing.Point(50, 68);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(44, 23);
            this.btnAddPerson.TabIndex = 13;
            this.btnAddPerson.Text = "הוסף";
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.BtnAddPersonClick);
            // 
            // lblPersonText
            // 
            this.lblPersonText.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblPersonText.Location = new System.Drawing.Point(69, 1);
            this.lblPersonText.Name = "lblPersonText";
            this.lblPersonText.Size = new System.Drawing.Size(174, 16);
            this.lblPersonText.TabIndex = 13;
            this.lblPersonText.Text = "הוספת נמען חדש...";
            // 
            // txtPersonPhone
            // 
            this.txtPersonPhone.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtPersonPhone.Location = new System.Drawing.Point(6, 43);
            this.txtPersonPhone.MaxLength = 50;
            this.txtPersonPhone.Name = "txtPersonPhone";
            this.txtPersonPhone.Size = new System.Drawing.Size(169, 22);
            this.txtPersonPhone.TabIndex = 12;
            this.txtPersonPhone.Leave += new System.EventHandler(this.TextBox_LostFocus);
            this.txtPersonPhone.Enter += new System.EventHandler(this.TextBox_Focus);
            // 
            // txtPersonName
            // 
            this.txtPersonName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtPersonName.Location = new System.Drawing.Point(29, 19);
            this.txtPersonName.MaxLength = 101;
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.Size = new System.Drawing.Size(146, 22);
            this.txtPersonName.TabIndex = 11;
            this.txtPersonName.Leave += new System.EventHandler(this.TextBox_LostFocus);
            this.txtPersonName.Enter += new System.EventHandler(this.TextBox_Focus);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label13.Location = new System.Drawing.Point(165, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 16);
            this.label13.TabIndex = 10;
            this.label13.Text = "טלפון נייד:";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label12.Location = new System.Drawing.Point(165, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 16);
            this.label12.TabIndex = 9;
            this.label12.Text = "שם הנמען:";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label7.Image = global::ClientManage.Properties.Resources.client_nophone_small;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(372, 439);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "ללא מספר";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Image = global::ClientManage.Properties.Resources.client_error_small;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(446, 439);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "מספר שגוי";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Image = global::ClientManage.Properties.Resources.client_ok_small;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(524, 439);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "מספר פעיל";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lnkRetry
            // 
            this.lnkRetry.ActiveLinkColor = System.Drawing.Color.Black;
            this.lnkRetry.AutoSize = true;
            this.lnkRetry.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lnkRetry.LinkColor = System.Drawing.Color.SlateGray;
            this.lnkRetry.Location = new System.Drawing.Point(29, 378);
            this.lnkRetry.Name = "lnkRetry";
            this.lnkRetry.Size = new System.Drawing.Size(90, 15);
            this.lnkRetry.TabIndex = 43;
            this.lnkRetry.TabStop = true;
            this.lnkRetry.Text = "נסה להתחבר שוב";
            this.lnkRetry.Visible = false;
            this.lnkRetry.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkRetryLinkClicked);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(17, 423);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 35);
            this.button1.TabIndex = 44;
            this.button1.Text = "  שלח הודעה";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BtnSendMessageClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImage = global::ClientManage.Properties.Resources.toolbar_bg_small;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbSend,
            this.toolStripSeparator1,
            this.tbbAddUser,
            this.tbbDeleteUser,
            this.toolStripButton1,
            this.toolStripSeparator2});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(9, 29);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(597, 25);
            this.toolStrip1.TabIndex = 52;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbbSend
            // 
            this.tbbSend.AutoToolTip = false;
            this.tbbSend.Image = global::ClientManage.Properties.Resources.send_small;
            this.tbbSend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbSend.Name = "tbbSend";
            this.tbbSend.Size = new System.Drawing.Size(88, 22);
            this.tbbSend.Text = "שלח הודעה";
            this.tbbSend.ToolTipText = "שליחת SMS לכל הנמענים ברשימה";
            this.tbbSend.Click += new System.EventHandler(this.TbbSendClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbbAddUser
            // 
            this.tbbAddUser.AutoToolTip = false;
            this.tbbAddUser.Image = ((System.Drawing.Image)(resources.GetObject("tbbAddUser.Image")));
            this.tbbAddUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbAddUser.Name = "tbbAddUser";
            this.tbbAddUser.Size = new System.Drawing.Size(80, 22);
            this.tbbAddUser.Text = "הוסף נמען";
            this.tbbAddUser.ToolTipText = "הוספת נמען חדש לרשימה";
            this.tbbAddUser.Click += new System.EventHandler(this.TbbAddUserClick);
            // 
            // tbbDeleteUser
            // 
            this.tbbDeleteUser.AutoToolTip = false;
            this.tbbDeleteUser.Image = ((System.Drawing.Image)(resources.GetObject("tbbDeleteUser.Image")));
            this.tbbDeleteUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbDeleteUser.Name = "tbbDeleteUser";
            this.tbbDeleteUser.Size = new System.Drawing.Size(77, 22);
            this.tbbDeleteUser.Text = "הסר נמען";
            this.tbbDeleteUser.ToolTipText = "הסרת הנמען המסומן מתוך הרשימה";
            this.tbbDeleteUser.Click += new System.EventHandler(this.TbbDeleteUserClick);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.Image = global::ClientManage.Properties.Resources.close_form_small2;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton1.Text = "סגור";
            this.toolStripButton1.ToolTipText = "סגירת החלון  (Esc)";
            this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButton1Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDeleteMsg
            // 
            this.btnDeleteMsg.BackColor = System.Drawing.Color.White;
            this.btnDeleteMsg.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteMsg.Image = global::ClientManage.Properties.Resources.tb_delete_small;
            this.btnDeleteMsg.Location = new System.Drawing.Point(17, 83);
            this.btnDeleteMsg.Name = "btnDeleteMsg";
            this.btnDeleteMsg.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDeleteMsg.Size = new System.Drawing.Size(24, 22);
            this.btnDeleteMsg.TabIndex = 47;
            this.btnDeleteMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteMsg.Click += new System.EventHandler(this.BtnDeleteMsgClick);
            // 
            // btnSaveMsg
            // 
            this.btnSaveMsg.BackColor = System.Drawing.Color.White;
            this.btnSaveMsg.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveMsg.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveMsg.Image")));
            this.btnSaveMsg.Location = new System.Drawing.Point(43, 83);
            this.btnSaveMsg.Name = "btnSaveMsg";
            this.btnSaveMsg.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSaveMsg.Size = new System.Drawing.Size(24, 22);
            this.btnSaveMsg.TabIndex = 46;
            this.btnSaveMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveMsg.Click += new System.EventHandler(this.BtnSaveMsgClick);
            // 
            // xpFlatButton1
            // 
            this.xpFlatButton1.BackColor = System.Drawing.Color.White;
            this.xpFlatButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.xpFlatButton1.Image = global::ClientManage.Properties.Resources.pen;
            this.xpFlatButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xpFlatButton1.Location = new System.Drawing.Point(17, 325);
            this.xpFlatButton1.Name = "xpFlatButton1";
            this.xpFlatButton1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.xpFlatButton1.Size = new System.Drawing.Size(107, 22);
            this.xpFlatButton1.TabIndex = 91;
            this.xpFlatButton1.Text = "       הוסף שם נמען";
            this.xpFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xpFlatButton1.Click += new System.EventHandler(this.XpFlatButton1Click);
            // 
            // FormSms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(615, 475);
            this.CloseFormByEsc = true;
            this.ControlBox = false;
            this.Controls.Add(this.xpFlatButton1);
            this.Controls.Add(this.pnlNewMsg);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnDeleteMsg);
            this.Controls.Add(this.btnSaveMsg);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lnkRetry);
            this.Controls.Add(this.pnlPersons);
            this.Controls.Add(this.lblMaxChars);
            this.Controls.Add(this.lblCredits);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTotalClients);
            this.Controls.Add(this.lblTotalChars);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.cmbMessages);
            this.Controls.Add(this.lstClients);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormSms";
            this.Padding = new System.Windows.Forms.Padding(9, 29, 9, 0);
            this.ShowMaximizeControl = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "שליחת SMS";
            this.Load += new System.EventHandler(this.FrmSmsLoad);
            this.RequestForClose += new System.EventHandler(this.FrmSmsRequestForClose);
            this.Activated += new System.EventHandler(this.FrmSmsActivated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSmsFormClosing);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.lstClients, 0);
            this.Controls.SetChildIndex(this.cmbMessages, 0);
            this.Controls.SetChildIndex(this.txtMsg, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblTotalChars, 0);
            this.Controls.SetChildIndex(this.lblTotalClients, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.lblCredits, 0);
            this.Controls.SetChildIndex(this.lblMaxChars, 0);
            this.Controls.SetChildIndex(this.pnlPersons, 0);
            this.Controls.SetChildIndex(this.lnkRetry, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.btnSaveMsg, 0);
            this.Controls.SetChildIndex(this.btnDeleteMsg, 0);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.Controls.SetChildIndex(this.pnlNewMsg, 0);
            this.Controls.SetChildIndex(this.xpFlatButton1, 0);
            this.pnlNewMsg.ResumeLayout(false);
            this.pnlNewMsg.PerformLayout();
            this.pnlPersons.ResumeLayout(false);
            this.pnlPersons.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstClients;
        private System.Windows.Forms.ComboBox cmbMessages;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalChars;
        private System.Windows.Forms.Label lblTotalClients;
        private System.Windows.Forms.ColumnHeader clmClient;
        private System.Windows.Forms.ColumnHeader clmCellPhone;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCredits;
        private System.Windows.Forms.Label lblMaxChars;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pnlNewMsg;
        private System.Windows.Forms.Button btnMsgCancel;
        private System.Windows.Forms.Button btnMsgSave;
        private System.Windows.Forms.TextBox txtNewMsg;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pnlPersons;
        private System.Windows.Forms.Label lblPersonText;
        private System.Windows.Forms.TextBox txtPersonPhone;
        private System.Windows.Forms.TextBox txtPersonName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnCancelPerson;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.LinkLabel lnkRetry;
        private System.Windows.Forms.Button button1;
        private ClientManage.UserControls.XPFlatButton btnSaveMsg;
        private ClientManage.UserControls.XPFlatButton btnDeleteMsg;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbbAddUser;
        private System.Windows.Forms.ToolStripButton tbbDeleteUser;
        private ClientManage.UserControls.XPFlatButton xpFlatButton1;
        private System.Windows.Forms.ToolStripButton tbbSend;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private ClientManage.UserControls.XPFlatButton btnBrowse;
        private System.Windows.Forms.ContextMenuStrip ctxTBMenu;
    }
}