namespace ClientManage.Forms
{
    partial class FormClientQuickSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClientQuickSearch));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grdClients = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCount2 = new System.Windows.Forms.Label();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.lblAllUsers = new System.Windows.Forms.Label();
            this.lblNoUser = new System.Windows.Forms.Label();
            this.clmImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.clmPicture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_AllPhones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdClients)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(239, 426);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseDown);
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grdClients);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(231, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "כל המאגר";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grdClients
            // 
            this.grdClients.AllowUserToAddRows = false;
            this.grdClients.AllowUserToDeleteRows = false;
            this.grdClients.AllowUserToResizeRows = false;
            this.grdClients.BackgroundColor = System.Drawing.Color.White;
            this.grdClients.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdClients.ColumnHeadersHeight = 24;
            this.grdClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmImage,
            this.clmPicture,
            this.clmId,
            this.clmName,
            this.col_AllPhones,
            this.col_Address,
            this.col_DateCreated});
            this.grdClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdClients.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.grdClients.Location = new System.Drawing.Point(0, 38);
            this.grdClients.MultiSelect = false;
            this.grdClients.Name = "grdClients";
            this.grdClients.ReadOnly = true;
            this.grdClients.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdClients.RowHeadersVisible = false;
            this.grdClients.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdClients.RowTemplate.Height = 48;
            this.grdClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdClients.ShowEditingIcon = false;
            this.grdClients.Size = new System.Drawing.Size(231, 362);
            this.grdClients.TabIndex = 4;
            this.grdClients.Enter += new System.EventHandler(this.grdClients_Enter);
            this.grdClients.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdClients_CellMouseDown);
            this.grdClients.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdClients_ColumnHeaderMouseClick);
            this.grdClients.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdClients_DataBindingComplete);
            this.grdClients.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdClients_CellMouseEnter);
            this.grdClients.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grdClients_DataError);
            this.grdClients.SelectionChanged += new System.EventHandler(this.grdClients_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblCount);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 38);
            this.panel1.TabIndex = 53;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(112, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "הזן את שם הלקוח...";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(207)))), ((int)(((byte)(213)))));
            this.lblCount.Location = new System.Drawing.Point(3, 4);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(56, 14);
            this.lblCount.TabIndex = 52;
            this.lblCount.Text = "{0} לקוחות";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(0, 18);
            this.txtSearch.MaxLength = 255;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(231, 21);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Enter += new System.EventHandler(this.TextBox_Focus);
            this.txtSearch.Leave += new System.EventHandler(this.TextBox_LostFocus);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(231, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "התקשרו לאחרונה";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblCount2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(231, 38);
            this.panel2.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(0, 18);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5, 0, 3, 0);
            this.label2.Size = new System.Drawing.Size(231, 21);
            this.label2.TabIndex = 52;
            this.label2.Text = "לא ניתן לבצע חיפוש מהיר ברשימה זו...";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Paint += new System.Windows.Forms.PaintEventHandler(this.label2_Paint);
            // 
            // lblCount2
            // 
            this.lblCount2.AutoSize = true;
            this.lblCount2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblCount2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(207)))), ((int)(((byte)(213)))));
            this.lblCount2.Location = new System.Drawing.Point(3, 4);
            this.lblCount2.Name = "lblCount2";
            this.lblCount2.Size = new System.Drawing.Size(56, 14);
            this.lblCount2.TabIndex = 51;
            this.lblCount2.Text = "{0} לקוחות";
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Controls.Add(this.lblAllUsers);
            this.pnlToolbar.Controls.Add(this.lblNoUser);
            this.pnlToolbar.Location = new System.Drawing.Point(4, 3);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(38, 16);
            this.pnlToolbar.TabIndex = 55;
            this.pnlToolbar.Visible = false;
            // 
            // lblAllUsers
            // 
            this.lblAllUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAllUsers.Image = ((System.Drawing.Image)(resources.GetObject("lblAllUsers.Image")));
            this.lblAllUsers.Location = new System.Drawing.Point(22, 0);
            this.lblAllUsers.Name = "lblAllUsers";
            this.lblAllUsers.Size = new System.Drawing.Size(16, 16);
            this.lblAllUsers.TabIndex = 1;
            this.lblAllUsers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblAllUsers_MouseDown);
            // 
            // lblNoUser
            // 
            this.lblNoUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNoUser.Image = global::ClientManage.Properties.Resources.trash;
            this.lblNoUser.Location = new System.Drawing.Point(0, 0);
            this.lblNoUser.Name = "lblNoUser";
            this.lblNoUser.Size = new System.Drawing.Size(16, 16);
            this.lblNoUser.TabIndex = 0;
            this.lblNoUser.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblNoUser_MouseDown);
            // 
            // clmImage
            // 
            this.clmImage.Frozen = true;
            this.clmImage.HeaderText = "תמונה";
            this.clmImage.Image = ((System.Drawing.Image)(resources.GetObject("clmImage.Image")));
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
            // col_AllPhones
            // 
            this.col_AllPhones.DataPropertyName = "AllPhones";
            this.col_AllPhones.HeaderText = "AllPhones";
            this.col_AllPhones.Name = "col_AllPhones";
            this.col_AllPhones.ReadOnly = true;
            this.col_AllPhones.Visible = false;
            // 
            // col_Address
            // 
            this.col_Address.DataPropertyName = "Address";
            this.col_Address.HeaderText = "Address";
            this.col_Address.Name = "col_Address";
            this.col_Address.ReadOnly = true;
            this.col_Address.Visible = false;
            // 
            // col_DateCreated
            // 
            this.col_DateCreated.DataPropertyName = "DateCreated";
            this.col_DateCreated.HeaderText = "DateCreated";
            this.col_DateCreated.Name = "col_DateCreated";
            this.col_DateCreated.ReadOnly = true;
            this.col_DateCreated.Visible = false;
            // 
            // frmClientQuickSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(243, 430);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmClientQuickSearch";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = " חיפוש מהיר של לקוח ";
            this.Deactivate += new System.EventHandler(this.frmClientQuickSearch_Deactivate);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmClientQuickSearch_Paint);
            this.Activated += new System.EventHandler(this.frmClientQuickSearch_Activated);
            this.Load += new System.EventHandler(this.frmClientQuickSearch_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdClients)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdClients;
        private System.Windows.Forms.Label lblCount2;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Label lblNoUser;
        private System.Windows.Forms.Label lblAllUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewImageColumn clmImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPicture;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_AllPhones;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DateCreated;

    }
}