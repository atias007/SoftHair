namespace ClientManage.Forms.OptionForms
{
    partial class FormOptClients1
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
            this.grdClientTypes = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label72 = new System.Windows.Forms.Label();
            this.chkEnableQuickSearch = new System.Windows.Forms.CheckBox();
            this.lstClientOrder = new System.Windows.Forms.CheckedListBox();
            this.btnDownClient = new System.Windows.Forms.Button();
            this.btnUpClient = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaxClients = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdClientTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // grdClientTypes
            // 
            this.grdClientTypes.AllowUserToResizeRows = false;
            this.grdClientTypes.BackgroundColor = System.Drawing.Color.White;
            this.grdClientTypes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdClientTypes.ColumnHeadersHeight = 24;
            this.grdClientTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdClientTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6});
            this.grdClientTypes.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.grdClientTypes.Location = new System.Drawing.Point(15, 78);
            this.grdClientTypes.MultiSelect = false;
            this.grdClientTypes.Name = "grdClientTypes";
            this.grdClientTypes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdClientTypes.RowHeadersWidth = 24;
            this.grdClientTypes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdClientTypes.RowTemplate.Height = 24;
            this.grdClientTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdClientTypes.ShowEditingIcon = false;
            this.grdClientTypes.Size = new System.Drawing.Size(287, 202);
            this.grdClientTypes.TabIndex = 43;
            this.grdClientTypes.Tag = "SuperUser";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "description";
            this.dataGridViewTextBoxColumn3.HeaderText = "תיאור";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 64;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 230;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn4.HeaderText = "id";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "score";
            this.dataGridViewTextBoxColumn6.HeaderText = "score";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // label72
            // 
            this.label72.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label72.Location = new System.Drawing.Point(12, 62);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(237, 28);
            this.label72.TabIndex = 44;
            this.label72.Text = "רשימת סוגי לקוחות:";
            // 
            // chkEnableQuickSearch
            // 
            this.chkEnableQuickSearch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chkEnableQuickSearch.Location = new System.Drawing.Point(15, 509);
            this.chkEnableQuickSearch.Name = "chkEnableQuickSearch";
            this.chkEnableQuickSearch.Size = new System.Drawing.Size(479, 20);
            this.chkEnableQuickSearch.TabIndex = 42;
            this.chkEnableQuickSearch.Text = "אפשר חיפוש מהיר על ידי לחיצה כפולה בכרטיס הלקוח";
            this.chkEnableQuickSearch.UseVisualStyleBackColor = true;
            // 
            // lstClientOrder
            // 
            this.lstClientOrder.FormattingEnabled = true;
            this.lstClientOrder.Items.AddRange(new object[] {
            "שם פרטי",
            "שם משפחה",
            "שם פרטי + משפחה",
            "רחוב",
            "עיר",
            "מספרי טלפון"});
            this.lstClientOrder.Location = new System.Drawing.Point(15, 311);
            this.lstClientOrder.Name = "lstClientOrder";
            this.lstClientOrder.Size = new System.Drawing.Size(287, 191);
            this.lstClientOrder.TabIndex = 39;
            this.lstClientOrder.SelectedIndexChanged += new System.EventHandler(this.lstClientOrder_SelectedIndexChanged);
            // 
            // btnDownClient
            // 
            this.btnDownClient.Image = global::ClientManage.Properties.Resources.arr_down;
            this.btnDownClient.Location = new System.Drawing.Point(304, 338);
            this.btnDownClient.Name = "btnDownClient";
            this.btnDownClient.Size = new System.Drawing.Size(25, 23);
            this.btnDownClient.TabIndex = 41;
            this.btnDownClient.UseVisualStyleBackColor = true;
            this.btnDownClient.Click += new System.EventHandler(this.btnDownClient_Click);
            // 
            // btnUpClient
            // 
            this.btnUpClient.Image = global::ClientManage.Properties.Resources.arr_up;
            this.btnUpClient.Location = new System.Drawing.Point(304, 312);
            this.btnUpClient.Name = "btnUpClient";
            this.btnUpClient.Size = new System.Drawing.Size(25, 23);
            this.btnUpClient.TabIndex = 40;
            this.btnUpClient.UseVisualStyleBackColor = true;
            this.btnUpClient.Click += new System.EventHandler(this.btnUpClient_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(349, 20);
            this.label2.TabIndex = 38;
            this.label2.Text = "חפש לקוחות לפי השדות הבאים ולפי סדר הצגתן:";
            // 
            // txtMaxClients
            // 
            this.txtMaxClients.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtMaxClients.Location = new System.Drawing.Point(172, 540);
            this.txtMaxClients.MaxLength = 5;
            this.txtMaxClients.Name = "txtMaxClients";
            this.txtMaxClients.ReadOnly = true;
            this.txtMaxClients.Size = new System.Drawing.Size(55, 22);
            this.txtMaxClients.TabIndex = 48;
            this.txtMaxClients.Tag = "SuperUser";
            // 
            // label38
            // 
            this.label38.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label38.Location = new System.Drawing.Point(12, 543);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(211, 19);
            this.label38.TabIndex = 47;
            this.label38.Text = "מקסימום לקוחות במערכת:";
            // 
            // FormOptClients1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 620);
            this.Controls.Add(this.txtMaxClients);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.grdClientTypes);
            this.Controls.Add(this.label72);
            this.Controls.Add(this.chkEnableQuickSearch);
            this.Controls.Add(this.lstClientOrder);
            this.Controls.Add(this.btnDownClient);
            this.Controls.Add(this.btnUpClient);
            this.Controls.Add(this.label2);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormOptClients1";
            this.Text = "frmOptClients1";
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnUpClient, 0);
            this.Controls.SetChildIndex(this.btnDownClient, 0);
            this.Controls.SetChildIndex(this.lstClientOrder, 0);
            this.Controls.SetChildIndex(this.chkEnableQuickSearch, 0);
            this.Controls.SetChildIndex(this.label72, 0);
            this.Controls.SetChildIndex(this.grdClientTypes, 0);
            this.Controls.SetChildIndex(this.label38, 0);
            this.Controls.SetChildIndex(this.txtMaxClients, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdClientTypes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdClientTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.CheckBox chkEnableQuickSearch;
        private System.Windows.Forms.CheckedListBox lstClientOrder;
        private System.Windows.Forms.Button btnDownClient;
        private System.Windows.Forms.Button btnUpClient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaxClients;
        private System.Windows.Forms.Label label38;
    }
}