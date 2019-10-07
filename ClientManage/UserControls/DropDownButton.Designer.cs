namespace ClientManage.UserControls
{
    partial class DropDownButton
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
            this.SuspendLayout();
            // 
            // DropDownButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "DropDownButton";
            this.Size = new System.Drawing.Size(17, 18);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DropDownButton_MouseDown);
            this.MouseEnter += new System.EventHandler(this.DropDownButton_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.DropDownButton_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DropDownButton_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
