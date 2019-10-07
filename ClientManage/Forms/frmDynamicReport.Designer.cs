namespace ClientManage.Forms
{
    partial class FormDynamicReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDynamicReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tbbExcel = new System.Windows.Forms.ToolStripButton();
            this.tsDiv = new System.Windows.Forms.ToolStripSeparator();
            this.tbbDelFav = new System.Windows.Forms.ToolStripButton();
            this.tbbAddToFav = new System.Windows.Forms.ToolStripButton();
            this.tbbFav = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbPrint = new System.Windows.Forms.ToolStripButton();
            this.tbbSMS = new System.Windows.Forms.ToolStripButton();
            this.tbbEmail = new System.Windows.Forms.ToolStripButton();
            this.tbbStickers = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.lblSpacer = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ParamPanel = new ClientManage.UserControls.ReportParametersPanel();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuFavRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.ctxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackgroundImage = global::ClientManage.Properties.Resources.toolbar_bg;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbExcel,
            this.tsDiv,
            this.tbbDelFav,
            this.tbbAddToFav,
            this.tbbFav,
            this.toolStripSeparator2,
            this.tbbPrint,
            this.tbbSMS,
            this.tbbEmail,
            this.tbbStickers});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1024, 42);
            this.toolStrip.TabIndex = 47;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tbbExcel
            // 
            this.tbbExcel.AutoToolTip = false;
            this.tbbExcel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbExcel.Image = ((System.Drawing.Image)(resources.GetObject("tbbExcel.Image")));
            this.tbbExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbExcel.Name = "tbbExcel";
            this.tbbExcel.Size = new System.Drawing.Size(97, 39);
            this.tbbExcel.Text = "ייצא לאקסל";
            this.tbbExcel.ToolTipText = "שמירת הדו\"ח כקובץ אקסל";
            this.tbbExcel.Visible = false;
            this.tbbExcel.Click += new System.EventHandler(this.TbbExcelClick);
            this.tbbExcel.VisibleChanged += new System.EventHandler(this.TbbExcelVisibleChanged);
            // 
            // tsDiv
            // 
            this.tsDiv.Name = "tsDiv";
            this.tsDiv.Size = new System.Drawing.Size(6, 42);
            this.tsDiv.Visible = false;
            // 
            // tbbDelFav
            // 
            this.tbbDelFav.AutoSize = false;
            this.tbbDelFav.AutoToolTip = false;
            this.tbbDelFav.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbDelFav.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbDelFav.Image = ((System.Drawing.Image)(resources.GetObject("tbbDelFav.Image")));
            this.tbbDelFav.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbDelFav.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbDelFav.Name = "tbbDelFav";
            this.tbbDelFav.Size = new System.Drawing.Size(35, 39);
            this.tbbDelFav.ToolTipText = "הסרת הדוח הנוכחי מרשימת המועדפים";
            this.tbbDelFav.Click += new System.EventHandler(this.TbbDelFavClick);
            // 
            // tbbAddToFav
            // 
            this.tbbAddToFav.AutoToolTip = false;
            this.tbbAddToFav.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbAddToFav.Image = ((System.Drawing.Image)(resources.GetObject("tbbAddToFav.Image")));
            this.tbbAddToFav.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbAddToFav.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbAddToFav.Name = "tbbAddToFav";
            this.tbbAddToFav.Size = new System.Drawing.Size(116, 39);
            this.tbbAddToFav.Text = "הוסף למועדפים";
            this.tbbAddToFav.ToolTipText = "הוספת הדוח הנוכחי לרשימת המועדפים";
            this.tbbAddToFav.Click += new System.EventHandler(this.TbbAddToFavClick);
            // 
            // tbbFav
            // 
            this.tbbFav.AutoToolTip = false;
            this.tbbFav.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbFav.Image = ((System.Drawing.Image)(resources.GetObject("tbbFav.Image")));
            this.tbbFav.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbFav.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbFav.Name = "tbbFav";
            this.tbbFav.Size = new System.Drawing.Size(91, 39);
            this.tbbFav.Text = "מועדפים";
            this.tbbFav.ToolTipText = "רשימת הדוחות המועדפים שלך";
            this.tbbFav.ButtonClick += new System.EventHandler(this.TbbFavButtonClick);
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
            this.tbbPrint.ToolTipText = "הדפסת פלט הדו\"ח";
            this.tbbPrint.Click += new System.EventHandler(this.TbbPrintClick);
            // 
            // tbbSMS
            // 
            this.tbbSMS.AutoSize = false;
            this.tbbSMS.AutoToolTip = false;
            this.tbbSMS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbSMS.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbSMS.Image = ((System.Drawing.Image)(resources.GetObject("tbbSMS.Image")));
            this.tbbSMS.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbSMS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbSMS.Name = "tbbSMS";
            this.tbbSMS.Size = new System.Drawing.Size(35, 39);
            this.tbbSMS.Text = "שלח SMS";
            this.tbbSMS.Click += new System.EventHandler(this.TbbSmsClick);
            // 
            // tbbEmail
            // 
            this.tbbEmail.AutoSize = false;
            this.tbbEmail.AutoToolTip = false;
            this.tbbEmail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbEmail.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbEmail.Image = ((System.Drawing.Image)(resources.GetObject("tbbEmail.Image")));
            this.tbbEmail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbEmail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbEmail.Name = "tbbEmail";
            this.tbbEmail.Size = new System.Drawing.Size(35, 39);
            this.tbbEmail.Text = "שלח דוא\"ל";
            this.tbbEmail.Click += new System.EventHandler(this.TbbEmailClick);
            // 
            // tbbStickers
            // 
            this.tbbStickers.AutoSize = false;
            this.tbbStickers.AutoToolTip = false;
            this.tbbStickers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbStickers.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbStickers.Image = global::ClientManage.Properties.Resources.stickers;
            this.tbbStickers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbStickers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbStickers.Name = "tbbStickers";
            this.tbbStickers.Size = new System.Drawing.Size(35, 39);
            this.tbbStickers.Text = "מדבקות";
            this.tbbStickers.ToolTipText = "הדפסת מדבקות דואר";
            this.tbbStickers.Click += new System.EventHandler(this.TbbStickersClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView);
            this.panel1.Controls.Add(this.lblSpacer);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 42);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8, 10, 8, 8);
            this.panel1.Size = new System.Drawing.Size(1024, 623);
            this.panel1.TabIndex = 57;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(222)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeight = 30;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(182)))), ((int)(((byte)(206)))));
            this.dataGridView.Location = new System.Drawing.Point(8, 112);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 48;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1008, 503);
            this.dataGridView.TabIndex = 62;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCellContentClick);
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewCellFormatting);
            this.dataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewCellMouseDoubleClick);
            this.dataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewColumnHeaderMouseClick);
            this.dataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGridViewDataError);
            // 
            // lblSpacer
            // 
            this.lblSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSpacer.Location = new System.Drawing.Point(8, 102);
            this.lblSpacer.Name = "lblSpacer";
            this.lblSpacer.Size = new System.Drawing.Size(1008, 10);
            this.lblSpacer.TabIndex = 61;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ParamPanel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(8, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.groupBox1.Size = new System.Drawing.Size(1008, 92);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "בחירת דוח וקביעת פרמטרים";
            // 
            // ParamPanel
            // 
            this.ParamPanel.BackColor = System.Drawing.Color.Transparent;
            this.ParamPanel.DataGrid = this.dataGridView;
            this.ParamPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParamPanel.Location = new System.Drawing.Point(6, 17);
            this.ParamPanel.Name = "ParamPanel";
            this.ParamPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ParamPanel.Size = new System.Drawing.Size(996, 72);
            this.ParamPanel.TabIndex = 51;
            this.ParamPanel.SelectedReportChanged += new System.EventHandler(this.ParamPanel_SelectedReportChanged);
            this.ParamPanel.SizeChanged += new System.EventHandler(this.ParamPanel_SizeChanged);
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFavRemove});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctxMenu.Size = new System.Drawing.Size(165, 26);
            // 
            // mnuFavRemove
            // 
            this.mnuFavRemove.Image = global::ClientManage.Properties.Resources.delete_small;
            this.mnuFavRemove.Name = "mnuFavRemove";
            this.mnuFavRemove.Size = new System.Drawing.Size(164, 22);
            this.mnuFavRemove.Text = "הסר מהמועדפים";
            // 
            // FormDynamicReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1024, 665);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip);
            this.Name = "FormDynamicReport";
            this.Load += new System.EventHandler(this.FrmDynamicReportLoad);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ctxMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tbbStickers;
        private System.Windows.Forms.ToolStripButton tbbPrint;
        private System.Windows.Forms.ToolStripSeparator tsDiv;
        private System.Windows.Forms.ToolStripButton tbbSMS;
        private System.Windows.Forms.ToolStripButton tbbEmail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ClientManage.UserControls.ReportParametersPanel ParamPanel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label lblSpacer;
        private System.Windows.Forms.ToolStripButton tbbExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tbbAddToFav;
        private System.Windows.Forms.ToolStripSplitButton tbbFav;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuFavRemove;
        private System.Windows.Forms.ToolStripButton tbbDelFav;
    }
}
