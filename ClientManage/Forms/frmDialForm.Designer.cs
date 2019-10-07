namespace ClientManage.Forms
{
    partial class FormDialForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDialForm));
            this.label2 = new System.Windows.Forms.Label();
            this.lblPhoneNo = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnHangUp = new System.Windows.Forms.Button();
            this.btnRedial = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(18, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 60);
            this.label2.TabIndex = 9;
            // 
            // lblPhoneNo
            // 
            this.lblPhoneNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhoneNo.BackColor = System.Drawing.Color.Transparent;
            this.lblPhoneNo.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNo.ForeColor = System.Drawing.Color.Maroon;
            this.lblPhoneNo.Location = new System.Drawing.Point(85, 52);
            this.lblPhoneNo.Margin = new System.Windows.Forms.Padding(0);
            this.lblPhoneNo.Name = "lblPhoneNo";
            this.lblPhoneNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPhoneNo.Size = new System.Drawing.Size(238, 37);
            this.lblPhoneNo.TabIndex = 10;
            this.lblPhoneNo.Text = "9999999999";
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(85, 33);
            this.lblName.Margin = new System.Windows.Forms.Padding(0);
            this.lblName.Name = "lblName";
            this.lblName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblName.Size = new System.Drawing.Size(235, 19);
            this.lblName.TabIndex = 11;
            this.lblName.Text = " שם הנמען:";
            // 
            // btnHangUp
            // 
            this.btnHangUp.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnHangUp.Location = new System.Drawing.Point(220, 150);
            this.btnHangUp.Name = "btnHangUp";
            this.btnHangUp.Size = new System.Drawing.Size(98, 29);
            this.btnHangUp.TabIndex = 12;
            this.btnHangUp.Text = "נתק שיחה";
            this.btnHangUp.UseVisualStyleBackColor = true;
            this.btnHangUp.Click += new System.EventHandler(this.btnHangUp_Click);
            // 
            // btnRedial
            // 
            this.btnRedial.Enabled = false;
            this.btnRedial.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnRedial.Location = new System.Drawing.Point(117, 150);
            this.btnRedial.Name = "btnRedial";
            this.btnRedial.Size = new System.Drawing.Size(98, 29);
            this.btnRedial.TabIndex = 13;
            this.btnRedial.Text = "חייג שוב";
            this.btnRedial.UseVisualStyleBackColor = true;
            this.btnRedial.Click += new System.EventHandler(this.btnRedial_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnClose.Location = new System.Drawing.Point(14, 150);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 29);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "סגור";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.LightSlateGray;
            this.lblStatus.Location = new System.Drawing.Point(10, 95);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblStatus.Size = new System.Drawing.Size(313, 37);
            this.lblStatus.TabIndex = 15;
            this.lblStatus.Text = "מחייג כעת...";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormDialForm
            // 
            this.AcceptButton = this.btnHangUp;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(332, 196);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRedial);
            this.Controls.Add(this.btnHangUp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblPhoneNo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDialForm";
            this.ShowInTaskbar = false;
            this.ShowMaximizeControl = false;
            this.ShowMinimizeControl = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "חייגן";
            this.Load += new System.EventHandler(this.frmDialForm_Load);
            this.Controls.SetChildIndex(this.lblPhoneNo, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnHangUp, 0);
            this.Controls.SetChildIndex(this.btnRedial, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.lblStatus, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPhoneNo;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnHangUp;
        private System.Windows.Forms.Button btnRedial;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblStatus;
    }
}
