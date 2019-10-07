namespace ClientManage.Forms
{
    partial class FormCalArchiveInfo
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
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.lblCap = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblArchiveDate = new System.Windows.Forms.Label();
            this.lblCalScope = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRemark
            // 
            this.txtRemark.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtRemark.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtRemark.Location = new System.Drawing.Point(23, 126);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ReadOnly = true;
            this.txtRemark.Size = new System.Drawing.Size(346, 57);
            this.txtRemark.TabIndex = 32;
            // 
            // lblCap
            // 
            this.lblCap.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCap.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblCap.ForeColor = System.Drawing.Color.Navy;
            this.lblCap.Image = global::ClientManage.Properties.Resources.msg_qst;
            this.lblCap.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCap.Location = new System.Drawing.Point(16, 34);
            this.lblCap.Name = "lblCap";
            this.lblCap.Size = new System.Drawing.Size(403, 52);
            this.lblCap.TabIndex = 33;
            this.lblCap.Text = "שים לב: הנך עומד לטעון {0} תורים ליומן.\r\nהאם אתה בטוח שברצונך לבצע פעולה זו?";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(366, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "הערות:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnCancel.Location = new System.Drawing.Point(129, 193);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 29);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "לא";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnOk.Location = new System.Drawing.Point(222, 193);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(87, 29);
            this.btnOk.TabIndex = 36;
            this.btnOk.Text = "כן";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(285, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 20);
            this.label3.TabIndex = 37;
            this.label3.Text = "תאריך יצירת הארכיון:";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(285, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 20);
            this.label4.TabIndex = 38;
            this.label4.Text = "טווח תאריכים ביומן:";
            // 
            // lblArchiveDate
            // 
            this.lblArchiveDate.BackColor = System.Drawing.Color.White;
            this.lblArchiveDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblArchiveDate.Location = new System.Drawing.Point(67, 82);
            this.lblArchiveDate.Name = "lblArchiveDate";
            this.lblArchiveDate.Size = new System.Drawing.Size(222, 20);
            this.lblArchiveDate.TabIndex = 39;
            // 
            // lblCalScope
            // 
            this.lblCalScope.BackColor = System.Drawing.Color.White;
            this.lblCalScope.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblCalScope.Location = new System.Drawing.Point(25, 102);
            this.lblCalScope.Name = "lblCalScope";
            this.lblCalScope.Size = new System.Drawing.Size(274, 20);
            this.lblCalScope.TabIndex = 40;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(23, 201);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(393, 23);
            this.progressBar1.TabIndex = 41;
            this.progressBar1.Visible = false;
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.Color.White;
            this.lblInfo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblInfo.Location = new System.Drawing.Point(162, 184);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(255, 20);
            this.lblInfo.TabIndex = 42;
            this.lblInfo.Text = "טוען מקובץ הארכיון... {0} הסתיים";
            this.lblInfo.Visible = false;
            // 
            // frmCalArchiveInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(435, 238);
            this.Controls.Add(this.lblCalScope);
            this.Controls.Add(this.lblArchiveDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblCap);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblInfo);
            this.MinimizeBox = false;
            this.Name = "frmCalArchiveInfo";
            this.Padding = new System.Windows.Forms.Padding(16, 34, 16, 8);
            this.ShowInTaskbar = false;
            this.ShowMaximizeControl = false;
            this.ShowMinimizeControl = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.Activated += new System.EventHandler(this.frmCalArchiveInfo_Activated);
            this.Controls.SetChildIndex(this.lblInfo, 0);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtRemark, 0);
            this.Controls.SetChildIndex(this.lblCap, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lblArchiveDate, 0);
            this.Controls.SetChildIndex(this.lblCalScope, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label lblCap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblArchiveDate;
        private System.Windows.Forms.Label lblCalScope;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblInfo;
    }
}