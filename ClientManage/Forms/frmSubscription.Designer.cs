namespace ClientManage.Forms
{
    partial class FormSubscription
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSubscription));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbbAdd = new System.Windows.Forms.ToolStripButton();
            this.tbbEdit = new System.Windows.Forms.ToolStripButton();
            this.tbbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbClose = new System.Windows.Forms.ToolStripButton();
            this.tbbFreez = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbShow = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdUsage = new System.Windows.Forms.DataGridView();
            this.c_uid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblUsageCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grdSubscription = new System.Windows.Forms.DataGridView();
            this.c_status = new System.Windows.Forms.DataGridViewImageColumn();
            this.c_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_status_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_status_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_type2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_used = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_remain_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_datecreate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_to_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_from_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_button = new System.Windows.Forms.DataGridViewImageColumn();
            this.informationBar1 = new ClientManage.UserControls.InformationBar();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubscription)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImage = global::ClientManage.Properties.Resources.toolbar_bg_small;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbAdd,
            this.tbbEdit,
            this.tbbDelete,
            this.toolStripSeparator1,
            this.tbbClose,
            this.tbbFreez,
            this.toolStripSeparator2,
            this.cmbShow,
            this.toolStripLabel1});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(8, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(716, 25);
            this.toolStrip1.TabIndex = 68;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbbAdd
            // 
            this.tbbAdd.AutoToolTip = false;
            this.tbbAdd.Image = global::ClientManage.Properties.Resources.new_small;
            this.tbbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbAdd.Name = "tbbAdd";
            this.tbbAdd.Size = new System.Drawing.Size(78, 22);
            this.tbbAdd.Text = "הוסף מנוי";
            this.tbbAdd.ToolTipText = "הוספת מנוי חדש ללקוח";
            this.tbbAdd.Click += new System.EventHandler(this.TbbAdd_Click);
            // 
            // tbbEdit
            // 
            this.tbbEdit.AutoToolTip = false;
            this.tbbEdit.Image = ((System.Drawing.Image)(resources.GetObject("tbbEdit.Image")));
            this.tbbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbEdit.Name = "tbbEdit";
            this.tbbEdit.Size = new System.Drawing.Size(78, 22);
            this.tbbEdit.Text = "עדכן מנוי";
            this.tbbEdit.ToolTipText = "עדכון פרטי המנוי המסומן ברשימה";
            this.tbbEdit.Click += new System.EventHandler(this.TbbEdit_Click);
            // 
            // tbbDelete
            // 
            this.tbbDelete.AutoToolTip = false;
            this.tbbDelete.Image = global::ClientManage.Properties.Resources.delete_small;
            this.tbbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbDelete.Name = "tbbDelete";
            this.tbbDelete.Size = new System.Drawing.Size(74, 22);
            this.tbbDelete.Text = "הסר מנוי";
            this.tbbDelete.ToolTipText = "מחיקת המנוי המסומן ברשימה";
            this.tbbDelete.Click += new System.EventHandler(this.TbbDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            this.tbbClose.Click += new System.EventHandler(this.TbbClose_Click);
            // 
            // tbbFreez
            // 
            this.tbbFreez.AutoToolTip = false;
            this.tbbFreez.Image = global::ClientManage.Properties.Resources.freez;
            this.tbbFreez.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbFreez.Name = "tbbFreez";
            this.tbbFreez.Size = new System.Drawing.Size(82, 22);
            this.tbbFreez.Text = "הקפא מנוי";
            this.tbbFreez.ToolTipText = "הקפאה / ביטול הקפאת המנוי המסומן ברשימה";
            this.tbbFreez.Click += new System.EventHandler(this.TbbFreez_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(10, 25);
            // 
            // cmbShow
            // 
            this.cmbShow.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbShow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShow.Items.AddRange(new object[] {
            "כל המנויים",
            "מנויים פעילים",
            "מנויים עתידיים",
            "מנויים היסטוריים",
            "מנויים קפואים",
            "ללא עתידיים",
            "ללא היסטוריים",
            "ללא קפואים"});
            this.cmbShow.Name = "cmbShow";
            this.cmbShow.Size = new System.Drawing.Size(121, 25);
            this.cmbShow.SelectedIndexChanged += new System.EventHandler(this.CmbShow_SelectedIndexChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(26, 22);
            this.toolStripLabel1.Text = "הצג";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grdUsage);
            this.panel1.Controls.Add(this.lblUsageCount);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.grdSubscription);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(8, 81);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(716, 468);
            this.panel1.TabIndex = 69;
            // 
            // grdUsage
            // 
            this.grdUsage.AllowUserToAddRows = false;
            this.grdUsage.AllowUserToDeleteRows = false;
            this.grdUsage.AllowUserToResizeRows = false;
            this.grdUsage.BackgroundColor = System.Drawing.Color.White;
            this.grdUsage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdUsage.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdUsage.ColumnHeadersHeight = 24;
            this.grdUsage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdUsage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_uid,
            this.c_date,
            this.c_time,
            this.c_remark,
            this.c_delete});
            this.grdUsage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUsage.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(182)))), ((int)(((byte)(206)))));
            this.grdUsage.Location = new System.Drawing.Point(4, 274);
            this.grdUsage.Margin = new System.Windows.Forms.Padding(0);
            this.grdUsage.MultiSelect = false;
            this.grdUsage.Name = "grdUsage";
            this.grdUsage.RowHeadersVisible = false;
            this.grdUsage.RowTemplate.Height = 24;
            this.grdUsage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdUsage.Size = new System.Drawing.Size(708, 190);
            this.grdUsage.TabIndex = 69;
            this.grdUsage.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GrdUsage_CellFormatting);
            this.grdUsage.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GrdUsage_DataBindingComplete);
            this.grdUsage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrdUsage_KeyDown);
            // 
            // c_uid
            // 
            this.c_uid.DataPropertyName = "id";
            this.c_uid.HeaderText = "id";
            this.c_uid.Name = "c_uid";
            this.c_uid.Visible = false;
            // 
            // c_date
            // 
            this.c_date.DataPropertyName = "date_usage";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.c_date.DefaultCellStyle = dataGridViewCellStyle1;
            this.c_date.HeaderText = "תאריך";
            this.c_date.Name = "c_date";
            this.c_date.ReadOnly = true;
            this.c_date.Width = 120;
            // 
            // c_time
            // 
            this.c_time.DataPropertyName = "date_usage";
            dataGridViewCellStyle2.Format = "dddd בשעה HH:mm";
            dataGridViewCellStyle2.NullValue = null;
            this.c_time.DefaultCellStyle = dataGridViewCellStyle2;
            this.c_time.HeaderText = "יום ושעה";
            this.c_time.Name = "c_time";
            this.c_time.ReadOnly = true;
            this.c_time.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c_time.Width = 150;
            // 
            // c_remark
            // 
            this.c_remark.DataPropertyName = "remark";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(210)))));
            this.c_remark.DefaultCellStyle = dataGridViewCellStyle3;
            this.c_remark.HeaderText = "הערות";
            this.c_remark.MaxInputLength = 255;
            this.c_remark.Name = "c_remark";
            this.c_remark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c_remark.Width = 402;
            // 
            // c_delete
            // 
            this.c_delete.HeaderText = "";
            this.c_delete.Image = global::ClientManage.Properties.Resources.cancel_small;
            this.c_delete.Name = "c_delete";
            this.c_delete.ReadOnly = true;
            this.c_delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.c_delete.Visible = false;
            this.c_delete.Width = 24;
            // 
            // lblUsageCount
            // 
            this.lblUsageCount.BackColor = System.Drawing.Color.Transparent;
            this.lblUsageCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUsageCount.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblUsageCount.ForeColor = System.Drawing.Color.Black;
            this.lblUsageCount.Location = new System.Drawing.Point(4, 256);
            this.lblUsageCount.Name = "lblUsageCount";
            this.lblUsageCount.Size = new System.Drawing.Size(708, 18);
            this.lblUsageCount.TabIndex = 71;
            this.lblUsageCount.Text = "רשימת ביקורים למנוי  ({0} ביקורים)";
            this.lblUsageCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(4, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(708, 12);
            this.label2.TabIndex = 70;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grdSubscription
            // 
            this.grdSubscription.AllowUserToAddRows = false;
            this.grdSubscription.AllowUserToDeleteRows = false;
            this.grdSubscription.AllowUserToOrderColumns = true;
            this.grdSubscription.AllowUserToResizeRows = false;
            this.grdSubscription.BackgroundColor = System.Drawing.Color.White;
            this.grdSubscription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdSubscription.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(222)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSubscription.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdSubscription.ColumnHeadersHeight = 30;
            this.grdSubscription.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdSubscription.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_status,
            this.c_id,
            this.c_status_id,
            this.c_status_name,
            this.c_type2,
            this.c_name,
            this.c_amount,
            this.c_used,
            this.c_type,
            this.c_remain_desc,
            this.c_datecreate,
            this.c_to_date,
            this.c_from_date,
            this.c_button});
            this.grdSubscription.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdSubscription.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdSubscription.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(182)))), ((int)(((byte)(206)))));
            this.grdSubscription.Location = new System.Drawing.Point(4, 4);
            this.grdSubscription.Margin = new System.Windows.Forms.Padding(0);
            this.grdSubscription.MultiSelect = false;
            this.grdSubscription.Name = "grdSubscription";
            this.grdSubscription.ReadOnly = true;
            this.grdSubscription.RowHeadersVisible = false;
            this.grdSubscription.RowTemplate.Height = 48;
            this.grdSubscription.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSubscription.Size = new System.Drawing.Size(708, 240);
            this.grdSubscription.TabIndex = 68;
            this.grdSubscription.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdSubscription_CellContentClick);
            this.grdSubscription.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GrdSubscription_CellFormatting);
            this.grdSubscription.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GrdSubscription_DataBindingComplete);
            this.grdSubscription.SelectionChanged += new System.EventHandler(this.GrdSubscription_SelectionChanged);
            this.grdSubscription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrdSubscription_KeyDown);
            this.grdSubscription.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.GrdSubscription_MouseDoubleClick);
            // 
            // c_status
            // 
            this.c_status.HeaderText = "";
            this.c_status.Name = "c_status";
            this.c_status.ReadOnly = true;
            this.c_status.Width = 26;
            // 
            // c_id
            // 
            this.c_id.DataPropertyName = "id";
            this.c_id.HeaderText = "id";
            this.c_id.Name = "c_id";
            this.c_id.ReadOnly = true;
            this.c_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c_id.Visible = false;
            // 
            // c_status_id
            // 
            this.c_status_id.DataPropertyName = "status_id";
            this.c_status_id.HeaderText = "status_id";
            this.c_status_id.Name = "c_status_id";
            this.c_status_id.ReadOnly = true;
            this.c_status_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c_status_id.Visible = false;
            // 
            // c_status_name
            // 
            this.c_status_name.DataPropertyName = "status_title";
            this.c_status_name.HeaderText = "מצב";
            this.c_status_name.Name = "c_status_name";
            this.c_status_name.ReadOnly = true;
            this.c_status_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c_status_name.Width = 64;
            // 
            // c_type2
            // 
            this.c_type2.DataPropertyName = "type";
            this.c_type2.HeaderText = "type";
            this.c_type2.Name = "c_type2";
            this.c_type2.ReadOnly = true;
            this.c_type2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c_type2.Visible = false;
            // 
            // c_name
            // 
            this.c_name.DataPropertyName = "sub_name";
            this.c_name.HeaderText = "שם מנוי";
            this.c_name.Name = "c_name";
            this.c_name.ReadOnly = true;
            this.c_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c_name.Width = 200;
            // 
            // c_amount
            // 
            this.c_amount.DataPropertyName = "amount";
            this.c_amount.HeaderText = "amount";
            this.c_amount.Name = "c_amount";
            this.c_amount.ReadOnly = true;
            this.c_amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c_amount.Visible = false;
            // 
            // c_used
            // 
            this.c_used.DataPropertyName = "used";
            this.c_used.HeaderText = "used";
            this.c_used.Name = "c_used";
            this.c_used.ReadOnly = true;
            this.c_used.Visible = false;
            // 
            // c_type
            // 
            this.c_type.DataPropertyName = "c_type_desc";
            this.c_type.HeaderText = "סוג מנוי";
            this.c_type.Name = "c_type";
            this.c_type.ReadOnly = true;
            this.c_type.Width = 90;
            // 
            // c_remain_desc
            // 
            this.c_remain_desc.DataPropertyName = "c_remain_desc";
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.c_remain_desc.DefaultCellStyle = dataGridViewCellStyle5;
            this.c_remain_desc.HeaderText = "יתרה";
            this.c_remain_desc.Name = "c_remain_desc";
            this.c_remain_desc.ReadOnly = true;
            this.c_remain_desc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c_remain_desc.Width = 144;
            // 
            // c_datecreate
            // 
            this.c_datecreate.DataPropertyName = "date_create";
            dataGridViewCellStyle6.Format = "d";
            this.c_datecreate.DefaultCellStyle = dataGridViewCellStyle6;
            this.c_datecreate.HeaderText = "תאריך יצירה";
            this.c_datecreate.Name = "c_datecreate";
            this.c_datecreate.ReadOnly = true;
            this.c_datecreate.Width = 90;
            // 
            // c_to_date
            // 
            this.c_to_date.DataPropertyName = "to_date_real";
            this.c_to_date.HeaderText = "to_date_real";
            this.c_to_date.Name = "c_to_date";
            this.c_to_date.ReadOnly = true;
            this.c_to_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c_to_date.Visible = false;
            // 
            // c_from_date
            // 
            this.c_from_date.DataPropertyName = "from_date";
            this.c_from_date.HeaderText = "from_date";
            this.c_from_date.Name = "c_from_date";
            this.c_from_date.ReadOnly = true;
            this.c_from_date.Visible = false;
            // 
            // c_button
            // 
            this.c_button.HeaderText = "ביקור";
            this.c_button.Name = "c_button";
            this.c_button.ReadOnly = true;
            this.c_button.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.c_button.Width = 60;
            // 
            // informationBar1
            // 
            this.informationBar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("informationBar1.BackgroundImage")));
            this.informationBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.informationBar1.Image = global::ClientManage.Properties.Resources.ticke_smallt;
            this.informationBar1.LabelForeColor = System.Drawing.Color.DarkGreen;
            this.informationBar1.LabelImage = null;
            this.informationBar1.LabelText = "";
            this.informationBar1.LabelVisible = false;
            this.informationBar1.Location = new System.Drawing.Point(8, 53);
            this.informationBar1.Name = "informationBar1";
            this.informationBar1.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.informationBar1.PanelText = "ניהול מנויים ללקוח: {0}";
            this.informationBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.informationBar1.Size = new System.Drawing.Size(716, 28);
            this.informationBar1.TabIndex = 71;
            // 
            // FormSubscription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(732, 561);
            this.CloseFormByEsc = true;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.informationBar1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSubscription";
            this.Padding = new System.Windows.Forms.Padding(8, 28, 8, 12);
            this.ShowInTaskbar = false;
            this.ShowMaximizeControl = false;
            this.ShowMinimizeControl = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ניהול מנויים";
            this.RequestForClose += new System.EventHandler(this.FrmSubscription_RequestForClose);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSubscription_FormClosing);
            this.Load += new System.EventHandler(this.FrmSubscription_Load);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.Controls.SetChildIndex(this.informationBar1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUsage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubscription)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbbAdd;
        private System.Windows.Forms.ToolStripButton tbbEdit;
        private System.Windows.Forms.ToolStripButton tbbDelete;
        private System.Windows.Forms.ToolStripButton tbbClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbbFreez;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView grdUsage;
        private System.Windows.Forms.Label lblUsageCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grdSubscription;
        private System.Windows.Forms.ToolStripComboBox cmbShow;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private ClientManage.UserControls.InformationBar informationBar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_uid;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_remark;
        private System.Windows.Forms.DataGridViewImageColumn c_delete;
        private System.Windows.Forms.DataGridViewImageColumn c_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_status_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_status_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_type2;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_used;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_remain_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_datecreate;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_to_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_from_date;
        private System.Windows.Forms.DataGridViewImageColumn c_button;
    }
}
