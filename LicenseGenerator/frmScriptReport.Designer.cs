namespace BizCareAdmin
{
    partial class FrmScriptReport
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
            this.lstReports = new System.Windows.Forms.CheckedListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.rbInsert = new System.Windows.Forms.RadioButton();
            this.rbUpdate = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lstReports
            // 
            this.lstReports.FormattingEnabled = true;
            this.lstReports.Location = new System.Drawing.Point(12, 12);
            this.lstReports.Name = "lstReports";
            this.lstReports.Size = new System.Drawing.Size(315, 259);
            this.lstReports.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(93, 286);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(12, 286);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 27);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // rbInsert
            // 
            this.rbInsert.AutoSize = true;
            this.rbInsert.Location = new System.Drawing.Point(185, 295);
            this.rbInsert.Name = "rbInsert";
            this.rbInsert.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbInsert.Size = new System.Drawing.Size(57, 18);
            this.rbInsert.TabIndex = 5;
            this.rbInsert.Text = "Insert";
            this.rbInsert.UseVisualStyleBackColor = true;
            // 
            // rbUpdate
            // 
            this.rbUpdate.AutoSize = true;
            this.rbUpdate.Checked = true;
            this.rbUpdate.Location = new System.Drawing.Point(185, 277);
            this.rbUpdate.Name = "rbUpdate";
            this.rbUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbUpdate.Size = new System.Drawing.Size(65, 18);
            this.rbUpdate.TabIndex = 6;
            this.rbUpdate.TabStop = true;
            this.rbUpdate.Text = "Update";
            this.rbUpdate.UseVisualStyleBackColor = true;
            // 
            // frmScriptReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 325);
            this.Controls.Add(this.rbUpdate);
            this.Controls.Add(this.rbInsert);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lstReports);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmScriptReport";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "Select reports to script...";
            this.Load += new System.EventHandler(this.FrmScriptReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox lstReports;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.RadioButton rbInsert;
        private System.Windows.Forms.RadioButton rbUpdate;
    }
}