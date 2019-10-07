namespace ClientManage.UserControls
{
    partial class InformationBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformationBar));
            this.lblText = new System.Windows.Forms.Label();
            this.lblIcon = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
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
            this.lblText.Size = new System.Drawing.Size(168, 22);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "InformationPanel";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIcon
            // 
            this.lblIcon.BackColor = System.Drawing.Color.Transparent;
            this.lblIcon.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblIcon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblIcon.Location = new System.Drawing.Point(1000, 0);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(20, 28);
            this.lblIcon.TabIndex = 1;
            // 
            // lblMsg
            // 
            this.lblMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblMsg.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMsg.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblMsg.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblMsg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMsg.Location = new System.Drawing.Point(791, 0);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(209, 28);
            this.lblMsg.TabIndex = 51;
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMsg.Visible = false;
            // 
            // InformationBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.lblIcon);
            this.Controls.Add(this.lblText);
            this.Name = "InformationBar";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1024, 28);
            this.Load += new System.EventHandler(this.InformationBar_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SearchPanel_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblIcon;
        private System.Windows.Forms.Label lblMsg;

    }
}
