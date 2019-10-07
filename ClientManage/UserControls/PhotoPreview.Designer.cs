namespace ClientManage.UserControls
{
    partial class PhotoPreview
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
            this.picPicture = new System.Windows.Forms.PictureBox();
            this.lblCap1 = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblCap2 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // picPicture
            // 
            this.picPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPicture.Location = new System.Drawing.Point(16, 16);
            this.picPicture.Name = "picPicture";
            this.picPicture.Size = new System.Drawing.Size(200, 150);
            this.picPicture.TabIndex = 0;
            this.picPicture.TabStop = false;
            this.picPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.picPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.picPicture_Paint);
            this.picPicture.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDoubleClick);
            // 
            // lblCap1
            // 
            this.lblCap1.BackColor = System.Drawing.Color.Transparent;
            this.lblCap1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblCap1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(115)))), ((int)(((byte)(122)))));
            this.lblCap1.Location = new System.Drawing.Point(172, 169);
            this.lblCap1.Name = "lblCap1";
            this.lblCap1.Size = new System.Drawing.Size(47, 17);
            this.lblCap1.TabIndex = 1;
            this.lblCap1.Text = "תיאור:";
            this.lblCap1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.lblCap1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDoubleClick);
            // 
            // lblDescription
            // 
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(75)))), ((int)(((byte)(82)))));
            this.lblDescription.Location = new System.Drawing.Point(18, 169);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(158, 17);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.lblDescription.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDoubleClick);
            // 
            // lblCap2
            // 
            this.lblCap2.BackColor = System.Drawing.Color.Transparent;
            this.lblCap2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblCap2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(115)))), ((int)(((byte)(122)))));
            this.lblCap2.Location = new System.Drawing.Point(172, 186);
            this.lblCap2.Name = "lblCap2";
            this.lblCap2.Size = new System.Drawing.Size(47, 17);
            this.lblCap2.TabIndex = 3;
            this.lblCap2.Text = "תאריך:";
            this.lblCap2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.lblCap2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDoubleClick);
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(75)))), ((int)(((byte)(82)))));
            this.lblDate.Location = new System.Drawing.Point(18, 186);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(158, 17);
            this.lblDate.TabIndex = 4;
            this.lblDate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.lblDate.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDoubleClick);
            // 
            // PhotoPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblCap2);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblCap1);
            this.Controls.Add(this.picPicture);
            this.Name = "PhotoPreview";
            this.Padding = new System.Windows.Forms.Padding(22, 16, 22, 0);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(232, 220);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PhotoPreview_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.picPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picPicture;
        private System.Windows.Forms.Label lblCap1;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblCap2;
        private System.Windows.Forms.Label lblDate;

    }
}
