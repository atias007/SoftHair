namespace ClientManage.Forms
{
    partial class BasePopupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasePopupForm));
            this.lblCaption = new System.Windows.Forms.Label();
            this.controlBox = new ClientManage.UserControls.FormControlBox();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblCaption.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(115)))), ((int)(((byte)(134)))));
            this.lblCaption.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCaption.Location = new System.Drawing.Point(10, 5);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(333, 17);
            this.lblCaption.TabIndex = 6;
            this.lblCaption.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblCaption_MouseDown);
            // 
            // controlBox
            // 
            this.controlBox.BackColor = System.Drawing.Color.Transparent;
            this.controlBox.DialogResult = System.Windows.Forms.DialogResult.None;
            this.controlBox.Location = new System.Drawing.Point(349, 1);
            this.controlBox.Name = "controlBox";
            this.controlBox.ShowControlBox = true;
            this.controlBox.ShowMaximize = true;
            this.controlBox.ShowMinimize = true;
            this.controlBox.Size = new System.Drawing.Size(95, 18);
            this.controlBox.TabIndex = 9;
            // 
            // BasePopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(450, 250);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.controlBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BasePopupForm";
            this.Padding = new System.Windows.Forms.Padding(9, 28, 9, 8);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "BasePopUpForm";
            this.Activated += new System.EventHandler(this.BasePopupForm_Activated);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCaption;
        private UserControls.FormControlBox controlBox;
    }
}