namespace ClientManage.UserControls
{
    partial class FilmstripPreview
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
            ((System.ComponentModel.ISupportInitialize)(this.picPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // picPicture
            // 
            this.picPicture.BackColor = System.Drawing.Color.White;
            this.picPicture.BackgroundImage = global::ClientManage.Properties.Resources.hourglass_big;
            this.picPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPicture.Location = new System.Drawing.Point(5, 5);
            this.picPicture.Name = "picPicture";
            this.picPicture.Size = new System.Drawing.Size(170, 128);
            this.picPicture.TabIndex = 0;
            this.picPicture.TabStop = false;
            this.picPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.picPicture.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDoubleClick);
            // 
            // FilmStripPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(243)))));
            this.Controls.Add(this.picPicture);
            this.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.Name = "FilmStripPreview";
            this.Size = new System.Drawing.Size(180, 138);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FilmStripPreview_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.picPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picPicture;

    }
}
