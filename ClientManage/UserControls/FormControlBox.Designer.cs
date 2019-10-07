namespace ClientManage.UserControls
{
    partial class FormControlBox
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
            this.lblMinimize = new System.Windows.Forms.Label();
            this.lblMaximize = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMinimize
            // 
            this.lblMinimize.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblMinimize.Image = global::ClientManage.Properties.Resources.btn_minimize;
            this.lblMinimize.Location = new System.Drawing.Point(0, 0);
            this.lblMinimize.Name = "lblMinimize";
            this.lblMinimize.Size = new System.Drawing.Size(26, 18);
            this.lblMinimize.TabIndex = 11;
            this.lblMinimize.Click += new System.EventHandler(this.LblMinimize_Click);
            this.lblMinimize.MouseEnter += new System.EventHandler(this.LblMinimize_MouseEnter);
            this.lblMinimize.MouseLeave += new System.EventHandler(this.LblMinimize_MouseLeave);
            // 
            // lblMaximize
            // 
            this.lblMaximize.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblMaximize.Image = global::ClientManage.Properties.Resources.btn_maximize;
            this.lblMaximize.Location = new System.Drawing.Point(26, 0);
            this.lblMaximize.Name = "lblMaximize";
            this.lblMaximize.Size = new System.Drawing.Size(25, 18);
            this.lblMaximize.TabIndex = 10;
            this.lblMaximize.Click += new System.EventHandler(this.LlMaximize_Click);
            this.lblMaximize.MouseEnter += new System.EventHandler(this.LblMaximize_MouseEnter);
            this.lblMaximize.MouseLeave += new System.EventHandler(this.LblMaximize_MouseLeave);
            // 
            // lblClose
            // 
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblClose.Image = global::ClientManage.Properties.Resources.btn_close;
            this.lblClose.Location = new System.Drawing.Point(51, 0);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(44, 18);
            this.lblClose.TabIndex = 9;
            this.lblClose.Click += new System.EventHandler(this.LblClose_Click);
            this.lblClose.MouseEnter += new System.EventHandler(this.LblClose_MouseEnter);
            this.lblClose.MouseLeave += new System.EventHandler(this.LblClose_MouseLeave);
            // 
            // FormControlBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblMinimize);
            this.Controls.Add(this.lblMaximize);
            this.Controls.Add(this.lblClose);
            this.Name = "FormControlBox";
            this.Size = new System.Drawing.Size(95, 18);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMinimize;
        private System.Windows.Forms.Label lblMaximize;
        private System.Windows.Forms.Label lblClose;
    }
}
