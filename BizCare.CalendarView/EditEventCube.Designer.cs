namespace BizCare.Calendar
{
    partial class EditEventCube
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
            this.txtCaption = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtCaption
            // 
            this.txtCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(238)))), ((int)(((byte)(217)))));
            this.txtCaption.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCaption.Location = new System.Drawing.Point(6, 6);
            this.txtCaption.MaxLength = 255;
            this.txtCaption.Multiline = true;
            this.txtCaption.Name = "txtCaption";
            this.txtCaption.Size = new System.Drawing.Size(168, 57);
            this.txtCaption.TabIndex = 0;
            this.txtCaption.Leave += new System.EventHandler(this.txtCaption_Leave);
            this.txtCaption.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCaption_KeyDown);
            // 
            // EditEventCube
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(238)))), ((int)(((byte)(217)))));
            this.Controls.Add(this.txtCaption);
            this.Name = "EditEventCube";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Size = new System.Drawing.Size(180, 69);
            this.Enter += new System.EventHandler(this.EditEventCube_Enter);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.EditEventCube_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCaption;
    }
}
