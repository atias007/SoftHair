namespace ClientManage.Forms
{
    partial class FormStickers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStickers));
            this.pnlPersons = new System.Windows.Forms.Panel();
            this.txtZipCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowse = new ClientManage.UserControls.XPFlatButton();
            this.btnCancelPerson = new System.Windows.Forms.Button();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.lblPersonText = new System.Windows.Forms.Label();
            this.txtAdress = new System.Windows.Forms.TextBox();
            this.txtPersonName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalClients = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstClients = new System.Windows.Forms.ListView();
            this.clmClient = new System.Windows.Forms.ColumnHeader();
            this.clmCellPhone = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbbPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbAddUser = new System.Windows.Forms.ToolStripButton();
            this.tbbEditUser = new System.Windows.Forms.ToolStripButton();
            this.tbbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tbbDeleteUser = new System.Windows.Forms.ToolStripButton();
            this.tbbClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlPersons.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPersons
            // 
            this.pnlPersons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(227)))), ((int)(((byte)(233)))));
            this.pnlPersons.Controls.Add(this.txtZipCode);
            this.pnlPersons.Controls.Add(this.label3);
            this.pnlPersons.Controls.Add(this.txtCity);
            this.pnlPersons.Controls.Add(this.label2);
            this.pnlPersons.Controls.Add(this.btnBrowse);
            this.pnlPersons.Controls.Add(this.btnCancelPerson);
            this.pnlPersons.Controls.Add(this.btnAddPerson);
            this.pnlPersons.Controls.Add(this.lblPersonText);
            this.pnlPersons.Controls.Add(this.txtAdress);
            this.pnlPersons.Controls.Add(this.txtPersonName);
            this.pnlPersons.Controls.Add(this.label13);
            this.pnlPersons.Controls.Add(this.label12);
            this.pnlPersons.Location = new System.Drawing.Point(246, 80);
            this.pnlPersons.Name = "pnlPersons";
            this.pnlPersons.Size = new System.Drawing.Size(339, 146);
            this.pnlPersons.TabIndex = 1;
            this.pnlPersons.Visible = false;
            this.pnlPersons.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPersons_Paint);
            // 
            // txtZipCode
            // 
            this.txtZipCode.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtZipCode.Location = new System.Drawing.Point(6, 91);
            this.txtZipCode.MaxLength = 50;
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(260, 22);
            this.txtZipCode.TabIndex = 3;
            this.txtZipCode.Leave += new System.EventHandler(this.TextBox_LostFocus);
            this.txtZipCode.Enter += new System.EventHandler(this.TextBox_Focus);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(258, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "מיקוד:";
            // 
            // txtCity
            // 
            this.txtCity.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtCity.Location = new System.Drawing.Point(6, 67);
            this.txtCity.MaxLength = 50;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(260, 22);
            this.txtCity.TabIndex = 2;
            this.txtCity.Leave += new System.EventHandler(this.TextBox_LostFocus);
            this.txtCity.Enter += new System.EventHandler(this.TextBox_Focus);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(258, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "עיר:";
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
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnCancelPerson
            // 
            this.btnCancelPerson.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnCancelPerson.Location = new System.Drawing.Point(6, 117);
            this.btnCancelPerson.Name = "btnCancelPerson";
            this.btnCancelPerson.Size = new System.Drawing.Size(44, 23);
            this.btnCancelPerson.TabIndex = 6;
            this.btnCancelPerson.Text = "בטל";
            this.btnCancelPerson.UseVisualStyleBackColor = true;
            this.btnCancelPerson.Click += new System.EventHandler(this.btnCancelPerson_Click);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnAddPerson.Location = new System.Drawing.Point(50, 117);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(44, 23);
            this.btnAddPerson.TabIndex = 5;
            this.btnAddPerson.Text = "הוסף";
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // lblPersonText
            // 
            this.lblPersonText.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblPersonText.Location = new System.Drawing.Point(162, 1);
            this.lblPersonText.Name = "lblPersonText";
            this.lblPersonText.Size = new System.Drawing.Size(174, 16);
            this.lblPersonText.TabIndex = 13;
            this.lblPersonText.Text = "הוספת נמען חדש...";
            // 
            // txtAdress
            // 
            this.txtAdress.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtAdress.Location = new System.Drawing.Point(6, 43);
            this.txtAdress.MaxLength = 50;
            this.txtAdress.Name = "txtAdress";
            this.txtAdress.Size = new System.Drawing.Size(260, 22);
            this.txtAdress.TabIndex = 1;
            this.txtAdress.Leave += new System.EventHandler(this.TextBox_LostFocus);
            this.txtAdress.Enter += new System.EventHandler(this.TextBox_Focus);
            // 
            // txtPersonName
            // 
            this.txtPersonName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtPersonName.Location = new System.Drawing.Point(29, 19);
            this.txtPersonName.MaxLength = 101;
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.Size = new System.Drawing.Size(237, 22);
            this.txtPersonName.TabIndex = 0;
            this.txtPersonName.Leave += new System.EventHandler(this.TextBox_LostFocus);
            this.txtPersonName.Enter += new System.EventHandler(this.TextBox_Focus);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label13.Location = new System.Drawing.Point(258, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 16);
            this.label13.TabIndex = 10;
            this.label13.Text = "רחוב:";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label12.Location = new System.Drawing.Point(258, 22);
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
            this.label7.Location = new System.Drawing.Point(322, 435);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 17);
            this.label7.TabIndex = 46;
            this.label7.Text = "ללא כתובת";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Image = global::ClientManage.Properties.Resources.client_error_small;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(408, 435);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 45;
            this.label6.Text = "כתובת שגויה";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Image = global::ClientManage.Properties.Resources.client_ok_small;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(502, 435);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 44;
            this.label4.Text = "כתובת תקינה";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalClients
            // 
            this.lblTotalClients.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblTotalClients.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTotalClients.Location = new System.Drawing.Point(246, 63);
            this.lblTotalClients.Name = "lblTotalClients";
            this.lblTotalClients.Size = new System.Drawing.Size(123, 16);
            this.lblTotalClients.TabIndex = 43;
            this.lblTotalClients.Text = "סה\"כ 0 נמענים";
            this.lblTotalClients.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(491, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 42;
            this.label1.Text = "רשימת נמענים:";
            // 
            // lstClients
            // 
            this.lstClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmClient,
            this.clmCellPhone});
            this.lstClients.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lstClients.FullRowSelect = true;
            this.lstClients.HideSelection = false;
            this.lstClients.Location = new System.Drawing.Point(246, 80);
            this.lstClients.MultiSelect = false;
            this.lstClients.Name = "lstClients";
            this.lstClients.RightToLeftLayout = true;
            this.lstClients.ShowGroups = false;
            this.lstClients.Size = new System.Drawing.Size(339, 354);
            this.lstClients.SmallImageList = this.imageList1;
            this.lstClients.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstClients.TabIndex = 0;
            this.lstClients.UseCompatibleStateImageBehavior = false;
            this.lstClients.View = System.Windows.Forms.View.Details;
            this.lstClients.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstClients_MouseDoubleClick);
            // 
            // clmClient
            // 
            this.clmClient.Text = "שם לקוח";
            this.clmClient.Width = 125;
            // 
            // clmCellPhone
            // 
            this.clmCellPhone.Text = "כתובת";
            this.clmCellPhone.Width = 180;
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
            this.label8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Location = new System.Drawing.Point(246, 432);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(339, 23);
            this.label8.TabIndex = 47;
            this.label8.Paint += new System.Windows.Forms.PaintEventHandler(this.label8_Paint);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImage = global::ClientManage.Properties.Resources.toolbar_bg_small;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbPrint,
            this.toolStripSeparator1,
            this.tbbAddUser,
            this.tbbEditUser,
            this.tbbRefresh,
            this.tbbDeleteUser,
            this.tbbClose,
            this.toolStripSeparator2});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(9, 29);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(582, 25);
            this.toolStrip1.TabIndex = 53;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbbPrint
            // 
            this.tbbPrint.AutoToolTip = false;
            this.tbbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tbbPrint.Image")));
            this.tbbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbPrint.Name = "tbbPrint";
            this.tbbPrint.Size = new System.Drawing.Size(110, 22);
            this.tbbPrint.Text = "הדפס מדבקות";
            this.tbbPrint.ToolTipText = "הדפסת מדבקות לכל הנמענים ברשימה";
            this.tbbPrint.Click += new System.EventHandler(this.tbbPrint_Click);
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
            this.tbbAddUser.Size = new System.Drawing.Size(85, 22);
            this.tbbAddUser.Text = "הוסף נמען";
            this.tbbAddUser.ToolTipText = "הוספת נמען חדש לרשימה";
            this.tbbAddUser.Click += new System.EventHandler(this.tbbAddUser_Click);
            // 
            // tbbEditUser
            // 
            this.tbbEditUser.AutoToolTip = false;
            this.tbbEditUser.Image = ((System.Drawing.Image)(resources.GetObject("tbbEditUser.Image")));
            this.tbbEditUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbEditUser.Name = "tbbEditUser";
            this.tbbEditUser.Size = new System.Drawing.Size(93, 22);
            this.tbbEditUser.Text = "עדכן פרטים";
            this.tbbEditUser.ToolTipText = "עדכון פרטי הנמען המסומן ברשימה";
            this.tbbEditUser.Click += new System.EventHandler(this.tbbEditUser_Click);
            // 
            // tbbRefresh
            // 
            this.tbbRefresh.AutoToolTip = false;
            this.tbbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tbbRefresh.Image")));
            this.tbbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbRefresh.Name = "tbbRefresh";
            this.tbbRefresh.Size = new System.Drawing.Size(92, 22);
            this.tbbRefresh.Text = "אפס רשימה";
            this.tbbRefresh.ToolTipText = "איפוס השינויים ברשימה";
            this.tbbRefresh.Click += new System.EventHandler(this.tbbRefresh_Click);
            // 
            // tbbDeleteUser
            // 
            this.tbbDeleteUser.AutoToolTip = false;
            this.tbbDeleteUser.Image = ((System.Drawing.Image)(resources.GetObject("tbbDeleteUser.Image")));
            this.tbbDeleteUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbDeleteUser.Name = "tbbDeleteUser";
            this.tbbDeleteUser.Size = new System.Drawing.Size(81, 22);
            this.tbbDeleteUser.Text = "הסר נמען";
            this.tbbDeleteUser.ToolTipText = "הסרת הנמען המסומן מתוך הרשימה";
            this.tbbDeleteUser.Click += new System.EventHandler(this.tbbDeleteUser_Click);
            // 
            // tbbClose
            // 
            this.tbbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbbClose.Image = global::ClientManage.Properties.Resources.close_form_small2;
            this.tbbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbClose.Name = "tbbClose";
            this.tbbClose.Size = new System.Drawing.Size(52, 22);
            this.tbbClose.Text = "סגור";
            this.tbbClose.ToolTipText = "סגירת החלון  (Esc)";
            this.tbbClose.Click += new System.EventHandler(this.tbbClose_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(16, 420);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(155, 35);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "    הדפס מדבקות";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label9
            // 
            this.label9.Image = ((System.Drawing.Image)(resources.GetObject("label9.Image")));
            this.label9.Location = new System.Drawing.Point(16, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(206, 137);
            this.label9.TabIndex = 55;
            // 
            // FormStickers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(600, 475);
            this.CloseFormByEsc = true;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pnlPersons);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTotalClients);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstClients);
            this.Controls.Add(this.label8);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormStickers";
            this.Padding = new System.Windows.Forms.Padding(9, 29, 9, 0);
            this.ShowMaximizeControl = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "הדפסת מדבקות";
            this.RequestForClose += new System.EventHandler(this.frmStickers_RequestForClose);
            this.Activated += new System.EventHandler(this.frmStickers_Activated);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.lstClients, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblTotalClients, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.pnlPersons, 0);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.pnlPersons.ResumeLayout(false);
            this.pnlPersons.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPersons;
        private ClientManage.UserControls.XPFlatButton btnBrowse;
        private System.Windows.Forms.Button btnCancelPerson;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.Label lblPersonText;
        private System.Windows.Forms.TextBox txtAdress;
        private System.Windows.Forms.TextBox txtPersonName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotalClients;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstClients;
        private System.Windows.Forms.ColumnHeader clmClient;
        private System.Windows.Forms.ColumnHeader clmCellPhone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbbPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbbAddUser;
        private System.Windows.Forms.ToolStripButton tbbEditUser;
        private System.Windows.Forms.ToolStripButton tbbRefresh;
        private System.Windows.Forms.ToolStripButton tbbDeleteUser;
        private System.Windows.Forms.ToolStripButton tbbClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtZipCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ImageList imageList1;
    }
}
