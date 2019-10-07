namespace ClientManage.UserControls
{
    partial class ReportParameterField
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
            this.lblErrorIcon = new System.Windows.Forms.Label();
            this.lblCaption = new System.Windows.Forms.Label();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lblErrorIcon
            // 
            this.lblErrorIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblErrorIcon.Location = new System.Drawing.Point(0, 0);
            this.lblErrorIcon.Name = "lblErrorIcon";
            this.lblErrorIcon.Size = new System.Drawing.Size(19, 25);
            this.lblErrorIcon.TabIndex = 0;
            // 
            // lblCaption
            // 
            this.lblCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblCaption.Location = new System.Drawing.Point(180, 0);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(124, 24);
            this.lblCaption.TabIndex = 1;
            this.lblCaption.Text = "Report Field Caption";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCaption.SizeChanged += new System.EventHandler(this.LblCaptionSizeChanged);
            // 
            // ToolTip
            // 
            this.ToolTip.IsBalloon = true;
            // 
            // ReportParamField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.lblErrorIcon);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Name = "ReportParamField";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(304, 25);
            this.SizeChanged += new System.EventHandler(this.ReportParamField_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblErrorIcon;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.ToolTip ToolTip;
    }
}
