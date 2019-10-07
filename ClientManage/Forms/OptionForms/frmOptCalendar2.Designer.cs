namespace ClientManage.Forms.OptionForms
{
    partial class FormOptCalendar2
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
            this.grdRemainder = new System.Windows.Forms.DataGridView();
            this.clmImage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label59 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdRemainder)).BeginInit();
            this.SuspendLayout();
            // 
            // grdRemainder
            // 
            this.grdRemainder.AllowUserToResizeRows = false;
            this.grdRemainder.BackgroundColor = System.Drawing.Color.White;
            this.grdRemainder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdRemainder.ColumnHeadersHeight = 24;
            this.grdRemainder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdRemainder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmImage,
            this.dataGridViewTextBoxColumn2});
            this.grdRemainder.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.grdRemainder.Location = new System.Drawing.Point(15, 78);
            this.grdRemainder.MultiSelect = false;
            this.grdRemainder.Name = "grdRemainder";
            this.grdRemainder.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdRemainder.RowHeadersWidth = 24;
            this.grdRemainder.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdRemainder.RowTemplate.Height = 24;
            this.grdRemainder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdRemainder.ShowEditingIcon = false;
            this.grdRemainder.Size = new System.Drawing.Size(283, 500);
            this.grdRemainder.TabIndex = 34;
            this.grdRemainder.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grdRemainder_CellValidating);
            this.grdRemainder.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grdRemainder_DataError);
            // 
            // clmImage
            // 
            this.clmImage.DataPropertyName = "description";
            this.clmImage.HeaderText = "תיאור";
            this.clmImage.MinimumWidth = 64;
            this.clmImage.Name = "clmImage";
            this.clmImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmImage.Width = 130;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "min_value";
            this.dataGridViewTextBoxColumn2.HeaderText = "ערך (בדקות)";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label59
            // 
            this.label59.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label59.Location = new System.Drawing.Point(12, 62);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(203, 19);
            this.label59.TabIndex = 35;
            this.label59.Text = "זמני תזכורת תור ביומן:";
            // 
            // frmOptCalendar2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 620);
            this.Controls.Add(this.grdRemainder);
            this.Controls.Add(this.label59);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmOptCalendar2";
            this.Text = "frmOptCalendar2";
            this.Controls.SetChildIndex(this.label59, 0);
            this.Controls.SetChildIndex(this.grdRemainder, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdRemainder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdRemainder;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label59;
    }
}