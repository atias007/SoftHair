namespace ClientManage.Forms.OptionForms
{
    partial class FormOptCalendar3
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
            this.btnDownCare = new System.Windows.Forms.Button();
            this.btnUpCare = new System.Windows.Forms.Button();
            this.grdCares = new System.Windows.Forms.DataGridView();
            this.c_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_color = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_duration = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.c_score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label14 = new System.Windows.Forms.Label();
            this.chkDuration = new System.Windows.Forms.CheckBox();
            this.chkColor = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdCares)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDownCare
            // 
            this.btnDownCare.Image = global::ClientManage.Properties.Resources.arr_down;
            this.btnDownCare.Location = new System.Drawing.Point(596, 109);
            this.btnDownCare.Name = "btnDownCare";
            this.btnDownCare.Size = new System.Drawing.Size(25, 23);
            this.btnDownCare.TabIndex = 41;
            this.btnDownCare.UseVisualStyleBackColor = true;
            this.btnDownCare.Click += new System.EventHandler(this.btnDownCare_Click);
            // 
            // btnUpCare
            // 
            this.btnUpCare.Image = global::ClientManage.Properties.Resources.arr_up;
            this.btnUpCare.Location = new System.Drawing.Point(596, 84);
            this.btnUpCare.Name = "btnUpCare";
            this.btnUpCare.Size = new System.Drawing.Size(25, 23);
            this.btnUpCare.TabIndex = 40;
            this.btnUpCare.UseVisualStyleBackColor = true;
            this.btnUpCare.Click += new System.EventHandler(this.btnUpCare_Click);
            // 
            // grdCares
            // 
            this.grdCares.AllowUserToResizeRows = false;
            this.grdCares.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdCares.BackgroundColor = System.Drawing.Color.White;
            this.grdCares.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdCares.ColumnHeadersHeight = 24;
            this.grdCares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdCares.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_id,
            this.c_desc,
            this.col_color,
            this.col_duration,
            this.c_score});
            this.grdCares.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.grdCares.Location = new System.Drawing.Point(15, 81);
            this.grdCares.MultiSelect = false;
            this.grdCares.Name = "grdCares";
            this.grdCares.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdCares.RowHeadersWidth = 24;
            this.grdCares.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdCares.RowTemplate.Height = 24;
            this.grdCares.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCares.ShowEditingIcon = false;
            this.grdCares.Size = new System.Drawing.Size(579, 481);
            this.grdCares.TabIndex = 38;
            this.grdCares.Tag = "";
            this.grdCares.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grdCares_CellValidating);
            this.grdCares.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.grdCares_UserAddedRow);
            // 
            // c_id
            // 
            this.c_id.DataPropertyName = "id";
            this.c_id.HeaderText = "id";
            this.c_id.Name = "c_id";
            this.c_id.Visible = false;
            // 
            // c_desc
            // 
            this.c_desc.DataPropertyName = "description";
            this.c_desc.HeaderText = "תיאור";
            this.c_desc.MinimumWidth = 64;
            this.c_desc.Name = "c_desc";
            this.c_desc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c_desc.Width = 230;
            // 
            // col_color
            // 
            this.col_color.DataPropertyName = "display_color";
            this.col_color.HeaderText = "צבע";
            this.col_color.Name = "col_color";
            this.col_color.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_color.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_color.Width = 150;
            // 
            // col_duration
            // 
            this.col_duration.DataPropertyName = "duration";
            this.col_duration.HeaderText = "משך";
            this.col_duration.Name = "col_duration";
            this.col_duration.Width = 150;
            // 
            // c_score
            // 
            this.c_score.DataPropertyName = "score";
            this.c_score.HeaderText = "סדר";
            this.c_score.Name = "c_score";
            this.c_score.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.c_score.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c_score.Visible = false;
            this.c_score.Width = 50;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label14.Location = new System.Drawing.Point(12, 65);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(203, 26);
            this.label14.TabIndex = 39;
            this.label14.Text = "רשימת טיפולים לתור ביומן:";
            // 
            // chkDuration
            // 
            this.chkDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDuration.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chkDuration.Location = new System.Drawing.Point(24, 589);
            this.chkDuration.Name = "chkDuration";
            this.chkDuration.Size = new System.Drawing.Size(388, 19);
            this.chkDuration.TabIndex = 42;
            this.chkDuration.Text = "קבע משך תור אוטומטית";
            this.chkDuration.UseVisualStyleBackColor = true;
            // 
            // chkColor
            // 
            this.chkColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkColor.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chkColor.Location = new System.Drawing.Point(24, 568);
            this.chkColor.Name = "chkColor";
            this.chkColor.Size = new System.Drawing.Size(388, 19);
            this.chkColor.TabIndex = 43;
            this.chkColor.Text = "קבע צבע תור אוטומטית (הצבע יקבע לפי הטיפול הראשון שנבחר)";
            this.chkColor.UseVisualStyleBackColor = true;
            // 
            // FormOptCalendar3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 620);
            this.Controls.Add(this.chkColor);
            this.Controls.Add(this.chkDuration);
            this.Controls.Add(this.btnDownCare);
            this.Controls.Add(this.btnUpCare);
            this.Controls.Add(this.grdCares);
            this.Controls.Add(this.label14);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormOptCalendar3";
            this.Text = "frmOptCalendar3";
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.grdCares, 0);
            this.Controls.SetChildIndex(this.btnUpCare, 0);
            this.Controls.SetChildIndex(this.btnDownCare, 0);
            this.Controls.SetChildIndex(this.chkDuration, 0);
            this.Controls.SetChildIndex(this.chkColor, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdCares)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDownCare;
        private System.Windows.Forms.Button btnUpCare;
        private System.Windows.Forms.DataGridView grdCares;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_desc;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_color;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_score;
        private System.Windows.Forms.CheckBox chkDuration;
        private System.Windows.Forms.CheckBox chkColor;
    }
}