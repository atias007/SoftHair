namespace ClientManage.Forms.OptionForms
{
    partial class FormOptLicense
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
            this.licenseInfo1 = new ClientManage.UserControls.LicenseInfo();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // licenseInfo1
            // 
            this.licenseInfo1.BackColor = System.Drawing.Color.White;
            this.licenseInfo1.DrawBorder = false;
            this.licenseInfo1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.licenseInfo1.Location = new System.Drawing.Point(12, 57);
            this.licenseInfo1.Name = "licenseInfo1";
            this.licenseInfo1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.licenseInfo1.Size = new System.Drawing.Size(341, 323);
            this.licenseInfo1.TabIndex = 1;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnStop.Image = global::ClientManage.Properties.Resources.cancel;
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStop.Location = new System.Drawing.Point(359, 57);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(105, 51);
            this.btnStop.TabIndex = 56;
            this.btnStop.Tag = "SuperUser";
            this.btnStop.Text = "      עצור   ";
            this.btnStop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnPause.Image = global::ClientManage.Properties.Resources.msg_wrn_small;
            this.btnPause.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPause.Location = new System.Drawing.Point(359, 114);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(105, 51);
            this.btnPause.TabIndex = 57;
            this.btnPause.Tag = "SuperUser";
            this.btnPause.Text = "      השהה";
            this.btnPause.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button1.Image = global::ClientManage.Properties.Resources.change;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(359, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 51);
            this.button1.TabIndex = 58;
            this.button1.Tag = "SuperUser";
            this.button1.Text = "      בדוק   ";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormOptLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 585);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.licenseInfo1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormOptLicense";
            this.Text = "frmOptLicense";
            this.Controls.SetChildIndex(this.licenseInfo1, 0);
            this.Controls.SetChildIndex(this.btnStop, 0);
            this.Controls.SetChildIndex(this.btnPause, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private ClientManage.UserControls.LicenseInfo licenseInfo1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button button1;
    }
}