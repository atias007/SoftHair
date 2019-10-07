namespace ClientManage.Forms
{
    partial class FormClientsPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClientsPopup));
            this.SuspendLayout();
            // 
            // frmClientsPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(514, 361);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmClientsPopUp";
            this.Padding = new System.Windows.Forms.Padding(8, 28, 8, 8);
            this.ShowMaximizeControl = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "כרטיס לקוח";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmClientsPopUp_FormClosing);
            this.Load += new System.EventHandler(this.frmClientsPopUp_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
