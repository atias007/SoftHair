namespace ClientManage.Forms
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.pnlForms = new System.Windows.Forms.Panel();
            this.lblCaption = new System.Windows.Forms.Label();
            this.controlBox = new ClientManage.UserControls.FormControlBox();
            this.TabStrip = new ClientManage.MainTabStrip();
            this.SuspendLayout();
            // 
            // pnlForms
            // 
            this.pnlForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForms.Location = new System.Drawing.Point(4, 74);
            this.pnlForms.Name = "pnlForms";
            this.pnlForms.Size = new System.Drawing.Size(1014, 658);
            this.pnlForms.TabIndex = 5;
            this.pnlForms.SizeChanged += new System.EventHandler(this.PnlFormsSizeChanged);
            // 
            // lblCaption
            // 
            this.lblCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblCaption.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(115)))), ((int)(((byte)(134)))));
            this.lblCaption.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCaption.Location = new System.Drawing.Point(10, 5);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(905, 17);
            this.lblCaption.TabIndex = 7;
            // 
            // controlBox
            // 
            this.controlBox.BackColor = System.Drawing.Color.Transparent;
            this.controlBox.DialogResult = System.Windows.Forms.DialogResult.None;
            this.controlBox.Location = new System.Drawing.Point(921, 1);
            this.controlBox.Name = "controlBox";
            this.controlBox.ShowControlBox = true;
            this.controlBox.ShowMaximize = false;
            this.controlBox.ShowMinimize = true;
            this.controlBox.Size = new System.Drawing.Size(95, 18);
            this.controlBox.TabIndex = 8;
            // 
            // TabStrip
            // 
            this.TabStrip.BackColor = System.Drawing.Color.White;
            this.TabStrip.Dock = System.Windows.Forms.DockStyle.Top;
            this.TabStrip.Location = new System.Drawing.Point(4, 26);
            this.TabStrip.Name = "TabStrip";
            this.TabStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TabStrip.Size = new System.Drawing.Size(1014, 48);
            this.TabStrip.TabIndex = 3;
            this.TabStrip.TabClick += new System.EventHandler(this.TabStripTabClick);
            this.TabStrip.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TabStripMouseDoubleClick);
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1022, 736);
            this.Controls.Add(this.controlBox);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.pnlForms);
            this.Controls.Add(this.TabStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1022, 726);
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(4, 26, 4, 4);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "SoftHair - מערכת לניהול מספרות ועסקי היופי";
            this.Activated += new System.EventHandler(this.FrmMainActivated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMainFormClosing);
            this.Load += new System.EventHandler(this.Form1Load);
            this.SizeChanged += new System.EventHandler(this.FormMainSizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private MainTabStrip TabStrip;
        private System.Windows.Forms.Panel pnlForms;
        private System.Windows.Forms.Label lblCaption;
        private UserControls.FormControlBox controlBox;


    }
}

