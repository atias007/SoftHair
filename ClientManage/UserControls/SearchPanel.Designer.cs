namespace ClientManage.UserControls
{
    partial class SearchPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchPanel));
            this.lblText = new System.Windows.Forms.Label();
            this.lblIcon = new System.Windows.Forms.Label();
            this.txtSearch = new ClientManage.UserControls.DelayTextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblClear = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.BackColor = System.Drawing.Color.Transparent;
            this.lblText.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(140)))));
            this.lblText.Location = new System.Drawing.Point(32, 2);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(128, 22);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "SearchPanel";
            // 
            // lblIcon
            // 
            this.lblIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIcon.BackColor = System.Drawing.Color.Transparent;
            this.lblIcon.Location = new System.Drawing.Point(1007, 9);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(9, 10);
            this.lblIcon.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Delay = 1000;
            this.txtSearch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtSearch.ForeColor = System.Drawing.Color.DimGray;
            this.txtSearch.Location = new System.Drawing.Point(778, 3);
            this.txtSearch.MaxLength = 50;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(223, 22);
            this.txtSearch.TabIndex = 54;
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearch.BackColor = System.Drawing.Color.Transparent;
            this.lblSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSearch.Image = ((System.Drawing.Image)(resources.GetObject("lblSearch.Image")));
            this.lblSearch.Location = new System.Drawing.Point(783, 5);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(16, 18);
            this.lblSearch.TabIndex = 55;
            this.lblSearch.Click += new System.EventHandler(this.lblSearch_Click);
            // 
            // lblClear
            // 
            this.lblClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClear.Image = ((System.Drawing.Image)(resources.GetObject("lblClear.Image")));
            this.lblClear.Location = new System.Drawing.Point(738, 3);
            this.lblClear.Name = "lblClear";
            this.lblClear.Size = new System.Drawing.Size(40, 22);
            this.lblClear.TabIndex = 57;
            this.lblClear.Visible = false;
            this.lblClear.MouseLeave += new System.EventHandler(this.lblClear_MouseLeave);
            this.lblClear.Click += new System.EventHandler(this.lblClear_Click);
            this.lblClear.MouseEnter += new System.EventHandler(this.lblClear_MouseEnter);
            // 
            // SearchPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ClientManage.Properties.Resources.search_panel_bgblue;
            this.Controls.Add(this.lblClear);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblIcon);
            this.Controls.Add(this.lblText);
            this.Name = "SearchPanel";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1024, 28);
            this.Load += new System.EventHandler(this.SearchPanel_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SearchPanel_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblIcon;
        private ClientManage.UserControls.DelayTextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblClear;
    }
}
