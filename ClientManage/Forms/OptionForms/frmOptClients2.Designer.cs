namespace ClientManage.Forms.OptionForms
{
    partial class FormOptClients2
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
            this.label89 = new System.Windows.Forms.Label();
            this.grdComponents = new System.Windows.Forms.DataGridView();
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCaption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDataType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clmDefaultValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFixValues = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdComponents)).BeginInit();
            this.SuspendLayout();
            // 
            // label89
            // 
            this.label89.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label89.Location = new System.Drawing.Point(12, 97);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(225, 19);
            this.label89.TabIndex = 11;
            this.label89.Text = "מבנה רשימת החומרים / מרכיבים:";
            // 
            // grdComponents
            // 
            this.grdComponents.AllowUserToResizeRows = false;
            this.grdComponents.BackgroundColor = System.Drawing.Color.White;
            this.grdComponents.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdComponents.ColumnHeadersHeight = 24;
            this.grdComponents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdComponents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmId,
            this.clmCaption,
            this.clmDataType,
            this.clmDefaultValue,
            this.clmFixValues,
            this.clmWidth,
            this.clmOrderId});
            this.grdComponents.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.grdComponents.Location = new System.Drawing.Point(15, 113);
            this.grdComponents.MultiSelect = false;
            this.grdComponents.Name = "grdComponents";
            this.grdComponents.ReadOnly = true;
            this.grdComponents.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdComponents.RowHeadersWidth = 24;
            this.grdComponents.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdComponents.RowTemplate.Height = 24;
            this.grdComponents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdComponents.ShowEditingIcon = false;
            this.grdComponents.Size = new System.Drawing.Size(773, 263);
            this.grdComponents.TabIndex = 35;
            this.grdComponents.Tag = "SuperUser";
            // 
            // clmId
            // 
            this.clmId.DataPropertyName = "id";
            this.clmId.HeaderText = "id";
            this.clmId.MinimumWidth = 64;
            this.clmId.Name = "clmId";
            this.clmId.ReadOnly = true;
            this.clmId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmId.Visible = false;
            // 
            // clmCaption
            // 
            this.clmCaption.DataPropertyName = "caption";
            this.clmCaption.HeaderText = "כותרת";
            this.clmCaption.MinimumWidth = 50;
            this.clmCaption.Name = "clmCaption";
            this.clmCaption.ReadOnly = true;
            this.clmCaption.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmDataType
            // 
            this.clmDataType.DataPropertyName = "data_type";
            this.clmDataType.HeaderText = "סוג נתונים";
            this.clmDataType.Name = "clmDataType";
            this.clmDataType.ReadOnly = true;
            this.clmDataType.Width = 150;
            // 
            // clmDefaultValue
            // 
            this.clmDefaultValue.DataPropertyName = "default_value";
            this.clmDefaultValue.HeaderText = "ברירת מחדל";
            this.clmDefaultValue.Name = "clmDefaultValue";
            this.clmDefaultValue.ReadOnly = true;
            this.clmDefaultValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmDefaultValue.Width = 120;
            // 
            // clmFixValues
            // 
            this.clmFixValues.DataPropertyName = "fix_values";
            this.clmFixValues.HeaderText = "ערכים קבועים";
            this.clmFixValues.Name = "clmFixValues";
            this.clmFixValues.ReadOnly = true;
            this.clmFixValues.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmFixValues.Width = 350;
            // 
            // clmWidth
            // 
            this.clmWidth.DataPropertyName = "width";
            this.clmWidth.HeaderText = "width";
            this.clmWidth.Name = "clmWidth";
            this.clmWidth.ReadOnly = true;
            this.clmWidth.Visible = false;
            // 
            // clmOrderId
            // 
            this.clmOrderId.DataPropertyName = "order_id";
            this.clmOrderId.HeaderText = "order_id";
            this.clmOrderId.Name = "clmOrderId";
            this.clmOrderId.ReadOnly = true;
            this.clmOrderId.Visible = false;
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtTitle.Location = new System.Drawing.Point(85, 59);
            this.txtTitle.MaxLength = 50;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTitle.Size = new System.Drawing.Size(271, 22);
            this.txtTitle.TabIndex = 40;
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label34.Location = new System.Drawing.Point(12, 62);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(67, 19);
            this.label34.TabIndex = 41;
            this.label34.Text = "כותרת:";
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button3.Image = global::ClientManage.Properties.Resources.change;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(15, 382);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(170, 51);
            this.button3.TabIndex = 55;
            this.button3.Tag = "SuperUser";
            this.button3.Text = "קבע מספרה      ";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button1.Image = global::ClientManage.Properties.Resources.change;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(15, 439);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 51);
            this.button1.TabIndex = 55;
            this.button1.Tag = "SuperUser";
            this.button1.Text = "קבע קוסמטיקאית";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // FormOptClients2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 620);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.grdComponents);
            this.Controls.Add(this.label89);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormOptClients2";
            this.Text = "frmOptClients2";
            this.Controls.SetChildIndex(this.label89, 0);
            this.Controls.SetChildIndex(this.grdComponents, 0);
            this.Controls.SetChildIndex(this.label34, 0);
            this.Controls.SetChildIndex(this.txtTitle, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdComponents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.DataGridView grdComponents;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCaption;
        private System.Windows.Forms.DataGridViewComboBoxColumn clmDataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDefaultValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFixValues;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOrderId;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
    }
}