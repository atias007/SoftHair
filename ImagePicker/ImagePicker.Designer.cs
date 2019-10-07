namespace ImagePicker
{
    partial class ImagePicker
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImagePicker));
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.pictureMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCamera = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemovePic = new System.Windows.Forms.ToolStripMenuItem();
            this.picView = new System.Windows.Forms.PictureBox();
            this.btnPicture = new System.Windows.Forms.Button();
            this.pictureMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picView)).BeginInit();
            this.SuspendLayout();
            // 
            // dlgOpenFile
            // 
            this.dlgOpenFile.RestoreDirectory = true;
            // 
            // pictureMenu
            // 
            this.pictureMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCamera,
            this.mnuFileSystem,
            this.mnuRemovePic});
            this.pictureMenu.Name = "pictureMenu";
            this.pictureMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pictureMenu.Size = new System.Drawing.Size(168, 70);
            // 
            // mnuCamera
            // 
            this.mnuCamera.Image = ((System.Drawing.Image)(resources.GetObject("mnuCamera.Image")));
            this.mnuCamera.Name = "mnuCamera";
            this.mnuCamera.Size = new System.Drawing.Size(167, 22);
            this.mnuCamera.Text = "תמונה ממצלמה...";
            this.mnuCamera.Click += new System.EventHandler(this.mnuCamera_Click);
            // 
            // mnuFileSystem
            // 
            this.mnuFileSystem.Image = global::ImagePicker.Properties.Resources.open_file;
            this.mnuFileSystem.Name = "mnuFileSystem";
            this.mnuFileSystem.Size = new System.Drawing.Size(167, 22);
            this.mnuFileSystem.Text = "תמונה מקובץ...";
            this.mnuFileSystem.Click += new System.EventHandler(this.mnuFileSystem_Click);
            // 
            // mnuRemovePic
            // 
            this.mnuRemovePic.Image = global::ImagePicker.Properties.Resources.delete_small;
            this.mnuRemovePic.Name = "mnuRemovePic";
            this.mnuRemovePic.Size = new System.Drawing.Size(167, 22);
            this.mnuRemovePic.Text = "הסר תמונה";
            this.mnuRemovePic.Click += new System.EventHandler(this.mnuRemovePic_Click);
            // 
            // picView
            // 
            this.picView.BackColor = System.Drawing.Color.White;
            this.picView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picView.Location = new System.Drawing.Point(0, 0);
            this.picView.Name = "picView";
            this.picView.Size = new System.Drawing.Size(170, 128);
            this.picView.TabIndex = 53;
            this.picView.TabStop = false;
            this.picView.Click += new System.EventHandler(this.picView_Click);
            // 
            // btnPicture
            // 
            this.btnPicture.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnPicture.Image = global::ImagePicker.Properties.Resources.pic;
            this.btnPicture.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPicture.Location = new System.Drawing.Point(0, 128);
            this.btnPicture.Name = "btnPicture";
            this.btnPicture.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPicture.Size = new System.Drawing.Size(170, 24);
            this.btnPicture.TabIndex = 52;
            this.btnPicture.Text = "אפשרויות תמונה...";
            this.btnPicture.UseVisualStyleBackColor = true;
            this.btnPicture.Click += new System.EventHandler(this.btnPicture_Click);
            // 
            // ImagePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.picView);
            this.Controls.Add(this.btnPicture);
            this.Name = "ImagePicker";
            this.Size = new System.Drawing.Size(170, 153);
            this.Enter += new System.EventHandler(this.ImagePicker_Enter);
            this.SizeChanged += new System.EventHandler(this.ImagePicker_SizeChanged);
            this.pictureMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picView;
        private System.Windows.Forms.Button btnPicture;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.ContextMenuStrip pictureMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuCamera;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSystem;
        private System.Windows.Forms.ToolStripMenuItem mnuRemovePic;
    }
}
