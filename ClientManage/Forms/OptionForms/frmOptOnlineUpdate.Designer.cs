namespace ClientManage.Forms.OptionForms
{
    partial class FormOptOnlineUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOptOnlineUpdate));
            this.btnOnlineUpdate = new System.Windows.Forms.Button();
            this.lblLastUpdate = new System.Windows.Forms.Label();
            this.chkEnableOnlineUpdate = new System.Windows.Forms.CheckBox();
            this.txtOnlineUpdateURL = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.btnValidUrlUpdate = new System.Windows.Forms.Button();
            this.pbarDownload = new System.Windows.Forms.ProgressBar();
            this.lblDownload = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOnlineUpdate
            // 
            this.btnOnlineUpdate.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnOnlineUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnOnlineUpdate.Image")));
            this.btnOnlineUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOnlineUpdate.Location = new System.Drawing.Point(12, 148);
            this.btnOnlineUpdate.Name = "btnOnlineUpdate";
            this.btnOnlineUpdate.Size = new System.Drawing.Size(146, 51);
            this.btnOnlineUpdate.TabIndex = 44;
            this.btnOnlineUpdate.Text = "עדכן עכשיו   ";
            this.btnOnlineUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOnlineUpdate.UseVisualStyleBackColor = true;
            this.btnOnlineUpdate.Click += new System.EventHandler(this.BtnOnlineUpdateClick);
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.BackColor = System.Drawing.Color.Transparent;
            this.lblLastUpdate.ForeColor = System.Drawing.Color.Maroon;
            this.lblLastUpdate.Location = new System.Drawing.Point(12, 109);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(613, 19);
            this.lblLastUpdate.TabIndex = 45;
            this.lblLastUpdate.Text = "עדכון אוטומטי בוצע לאחרונה בתאריך {0}";
            // 
            // chkEnableOnlineUpdate
            // 
            this.chkEnableOnlineUpdate.BackColor = System.Drawing.Color.Transparent;
            this.chkEnableOnlineUpdate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chkEnableOnlineUpdate.Location = new System.Drawing.Point(15, 87);
            this.chkEnableOnlineUpdate.Name = "chkEnableOnlineUpdate";
            this.chkEnableOnlineUpdate.Size = new System.Drawing.Size(510, 19);
            this.chkEnableOnlineUpdate.TabIndex = 40;
            this.chkEnableOnlineUpdate.Tag = "Admin";
            this.chkEnableOnlineUpdate.Text = "אפשר עדכון אוטומטי";
            this.chkEnableOnlineUpdate.UseVisualStyleBackColor = false;
            // 
            // txtOnlineUpdateURL
            // 
            this.txtOnlineUpdateURL.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtOnlineUpdateURL.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtOnlineUpdateURL.Location = new System.Drawing.Point(217, 59);
            this.txtOnlineUpdateURL.Name = "txtOnlineUpdateURL";
            this.txtOnlineUpdateURL.ReadOnly = true;
            this.txtOnlineUpdateURL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtOnlineUpdateURL.Size = new System.Drawing.Size(548, 22);
            this.txtOnlineUpdateURL.TabIndex = 41;
            this.txtOnlineUpdateURL.Tag = "Lock";
            // 
            // label68
            // 
            this.label68.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label68.Location = new System.Drawing.Point(12, 62);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(215, 19);
            this.label68.TabIndex = 42;
            this.label68.Text = "כתובת עבור שירות עדכון אוטומטי:";
            // 
            // btnValidUrlUpdate
            // 
            this.btnValidUrlUpdate.Enabled = false;
            this.btnValidUrlUpdate.Image = global::ClientManage.Properties.Resources.ok;
            this.btnValidUrlUpdate.Location = new System.Drawing.Point(764, 58);
            this.btnValidUrlUpdate.Name = "btnValidUrlUpdate";
            this.btnValidUrlUpdate.Size = new System.Drawing.Size(23, 24);
            this.btnValidUrlUpdate.TabIndex = 43;
            this.btnValidUrlUpdate.Tag = "Admin";
            this.btnValidUrlUpdate.UseVisualStyleBackColor = true;
            this.btnValidUrlUpdate.Click += new System.EventHandler(this.BtnValidUrlUpdateClick);
            // 
            // pbarDownload
            // 
            this.pbarDownload.Location = new System.Drawing.Point(15, 228);
            this.pbarDownload.Name = "pbarDownload";
            this.pbarDownload.Size = new System.Drawing.Size(259, 23);
            this.pbarDownload.TabIndex = 46;
            this.pbarDownload.Visible = false;
            // 
            // lblDownload
            // 
            this.lblDownload.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblDownload.Location = new System.Drawing.Point(12, 212);
            this.lblDownload.Name = "lblDownload";
            this.lblDownload.Size = new System.Drawing.Size(262, 19);
            this.lblDownload.TabIndex = 42;
            this.lblDownload.Text = "מוריד גרסה מהשרת, אנא המתן...";
            this.lblDownload.Visible = false;
            // 
            // FormOptOnlineUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 620);
            this.Controls.Add(this.pbarDownload);
            this.Controls.Add(this.btnOnlineUpdate);
            this.Controls.Add(this.lblLastUpdate);
            this.Controls.Add(this.chkEnableOnlineUpdate);
            this.Controls.Add(this.txtOnlineUpdateURL);
            this.Controls.Add(this.lblDownload);
            this.Controls.Add(this.label68);
            this.Controls.Add(this.btnValidUrlUpdate);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormOptOnlineUpdate";
            this.Text = "frmOptOnlineUpdate";
            this.Controls.SetChildIndex(this.btnValidUrlUpdate, 0);
            this.Controls.SetChildIndex(this.label68, 0);
            this.Controls.SetChildIndex(this.lblDownload, 0);
            this.Controls.SetChildIndex(this.txtOnlineUpdateURL, 0);
            this.Controls.SetChildIndex(this.chkEnableOnlineUpdate, 0);
            this.Controls.SetChildIndex(this.lblLastUpdate, 0);
            this.Controls.SetChildIndex(this.btnOnlineUpdate, 0);
            this.Controls.SetChildIndex(this.pbarDownload, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOnlineUpdate;
        private System.Windows.Forms.Label lblLastUpdate;
        private System.Windows.Forms.CheckBox chkEnableOnlineUpdate;
        private System.Windows.Forms.TextBox txtOnlineUpdateURL;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Button btnValidUrlUpdate;
        private System.Windows.Forms.ProgressBar pbarDownload;
        private System.Windows.Forms.Label lblDownload;
    }
}