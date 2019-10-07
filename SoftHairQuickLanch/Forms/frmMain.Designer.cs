namespace SoftHairQuickLanch.Forms
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbbSoftHair = new System.Windows.Forms.ToolStripButton();
            this.tbbRemote = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tbbWebSite = new System.Windows.Forms.ToolStripButton();
            this.tbbContact = new System.Windows.Forms.ToolStripButton();
            this.tbbOnlineUpdate = new System.Windows.Forms.ToolStripButton();
            this.tbbClientForm = new System.Windows.Forms.ToolStripButton();
            this.tbbTeam = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbSoftHair,
            this.tbbRemote,
            this.toolStripLabel1,
            this.tbbWebSite,
            this.tbbContact,
            this.tbbOnlineUpdate,
            this.tbbClientForm,
            this.tbbTeam});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(212, 62);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ToolStrip1MouseDown);
            this.toolStrip1.MouseEnter += new System.EventHandler(this.toolStrip1_MouseEnter);
            this.toolStrip1.MouseLeave += new System.EventHandler(this.toolStrip1_MouseLeave);
            this.toolStrip1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolStrip1_MouseMove);
            // 
            // tbbSoftHair
            // 
            this.tbbSoftHair.AutoToolTip = false;
            this.tbbSoftHair.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbSoftHair.Image = ((System.Drawing.Image)(resources.GetObject("tbbSoftHair.Image")));
            this.tbbSoftHair.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbSoftHair.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbSoftHair.Name = "tbbSoftHair";
            this.tbbSoftHair.Size = new System.Drawing.Size(59, 59);
            this.tbbSoftHair.Tag = "";
            this.tbbSoftHair.Text = "SoftHair לנהל בראש טוב";
            this.tbbSoftHair.Click += new System.EventHandler(this.tbbSoftHair_Click);
            this.tbbSoftHair.MouseEnter += new System.EventHandler(this.TbbSoftHairMouseEnter);
            this.tbbSoftHair.MouseLeave += new System.EventHandler(this.TbbSoftHairMouseLeave);
            this.tbbSoftHair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolStrip1_MouseMove);
            // 
            // tbbRemote
            // 
            this.tbbRemote.AutoToolTip = false;
            this.tbbRemote.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbRemote.Image = ((System.Drawing.Image)(resources.GetObject("tbbRemote.Image")));
            this.tbbRemote.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbRemote.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbRemote.Name = "tbbRemote";
            this.tbbRemote.Size = new System.Drawing.Size(59, 59);
            this.tbbRemote.Text = "SoftHair תמיכה ושירות מקוון";
            this.tbbRemote.Click += new System.EventHandler(this.tbbRemote_Click);
            this.tbbRemote.MouseEnter += new System.EventHandler(this.TbbSoftHairMouseEnter);
            this.tbbRemote.MouseLeave += new System.EventHandler(this.TbbSoftHairMouseLeave);
            this.tbbRemote.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolStrip1_MouseMove);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel1.Image")));
            this.toolStripLabel1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(55, 55);
            this.toolStripLabel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ToolStripLabel1MouseDown);
            this.toolStripLabel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolStrip1_MouseMove);
            // 
            // tbbWebSite
            // 
            this.tbbWebSite.AutoSize = false;
            this.tbbWebSite.AutoToolTip = false;
            this.tbbWebSite.Image = ((System.Drawing.Image)(resources.GetObject("tbbWebSite.Image")));
            this.tbbWebSite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbbWebSite.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbWebSite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbWebSite.Name = "tbbWebSite";
            this.tbbWebSite.Size = new System.Drawing.Size(140, 36);
            this.tbbWebSite.Text = "אתר הבית";
            this.tbbWebSite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbbWebSite.Click += new System.EventHandler(this.tbbWebSite_Click);
            // 
            // tbbContact
            // 
            this.tbbContact.AutoSize = false;
            this.tbbContact.AutoToolTip = false;
            this.tbbContact.Image = ((System.Drawing.Image)(resources.GetObject("tbbContact.Image")));
            this.tbbContact.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbbContact.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbContact.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbContact.Name = "tbbContact";
            this.tbbContact.Size = new System.Drawing.Size(140, 36);
            this.tbbContact.Text = "צור קשר";
            this.tbbContact.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbbContact.Click += new System.EventHandler(this.tbbContact_Click);
            // 
            // tbbOnlineUpdate
            // 
            this.tbbOnlineUpdate.AutoSize = false;
            this.tbbOnlineUpdate.AutoToolTip = false;
            this.tbbOnlineUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tbbOnlineUpdate.Image")));
            this.tbbOnlineUpdate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbOnlineUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbOnlineUpdate.Name = "tbbOnlineUpdate";
            this.tbbOnlineUpdate.Size = new System.Drawing.Size(140, 36);
            this.tbbOnlineUpdate.Text = "עדכונים אוטומטים";
            this.tbbOnlineUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbbOnlineUpdate.Click += new System.EventHandler(this.tbbOnlineUpdate_Click);
            // 
            // tbbClientForm
            // 
            this.tbbClientForm.AutoSize = false;
            this.tbbClientForm.AutoToolTip = false;
            this.tbbClientForm.Image = ((System.Drawing.Image)(resources.GetObject("tbbClientForm.Image")));
            this.tbbClientForm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbClientForm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbClientForm.Name = "tbbClientForm";
            this.tbbClientForm.Size = new System.Drawing.Size(140, 36);
            this.tbbClientForm.Text = "טופס פרטי לקוח";
            this.tbbClientForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbbClientForm.Click += new System.EventHandler(this.tbbClientForm_Click);
            // 
            // tbbTeam
            // 
            this.tbbTeam.AutoSize = false;
            this.tbbTeam.AutoToolTip = false;
            this.tbbTeam.Image = global::SoftHairQuickLanch.Properties.Resources.teamviewer;
            this.tbbTeam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbbTeam.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbTeam.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbTeam.Name = "tbbTeam";
            this.tbbTeam.Size = new System.Drawing.Size(140, 36);
            this.tbbTeam.Text = "תמיכה מרחוק";
            this.tbbTeam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbbTeam.Click += new System.EventHandler(this.tbbTeam_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLabel});
            this.toolStrip2.Location = new System.Drawing.Point(0, 62);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip2.Size = new System.Drawing.Size(212, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            this.toolStrip2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ToolStrip2MouseDown);
            this.toolStrip2.MouseEnter += new System.EventHandler(this.toolStrip2_MouseEnter);
            this.toolStrip2.MouseLeave += new System.EventHandler(this.toolStrip2_MouseLeave);
            this.toolStrip2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolStrip1_MouseMove);
            // 
            // tsLabel
            // 
            this.tsLabel.Name = "tsLabel";
            this.tsLabel.Size = new System.Drawing.Size(143, 22);
            this.tsLabel.Text = "SoftHair לנהל בראש טוב";
            this.tsLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TsLabelMouseDown);
            this.tsLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolStrip1_MouseMove);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(135)))), ((int)(((byte)(135)))));
            this.ClientSize = new System.Drawing.Size(212, 92);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Opacity = 0.7D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SoftHair חלון הפעלה מהירה";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(135)))), ((int)(((byte)(135)))));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbbSoftHair;
        private System.Windows.Forms.ToolStripButton tbbRemote;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel tsLabel;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tbbOnlineUpdate;
        private System.Windows.Forms.ToolStripButton tbbWebSite;
        private System.Windows.Forms.ToolStripButton tbbContact;
        private System.Windows.Forms.ToolStripButton tbbClientForm;
        private System.Windows.Forms.ToolStripButton tbbTeam;

    }
}

