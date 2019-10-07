namespace ClientManage.UserControls
{
    partial class ReportParametersPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportParametersPanel));
            this.pnlButton = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.lblRowsCount = new System.Windows.Forms.Label();
            this.lblErrReport = new System.Windows.Forms.Label();
            this.lblErrGroup = new System.Windows.Forms.Label();
            this.lblDiv2 = new System.Windows.Forms.Label();
            this.lblReport = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.cmbReport = new System.Windows.Forms.ComboBox();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.lblAdminInfo = new System.Windows.Forms.Label();
            this.pnlFields = new System.Windows.Forms.Panel();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.btnLogOff = new ClientManage.UserControls.XPFlatButton();
            this.xpFlatButton1 = new ClientManage.UserControls.XPFlatButton();
            this.pnlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButton
            // 
            this.pnlButton.BackColor = System.Drawing.Color.White;
            this.pnlButton.Controls.Add(this.btnClear);
            this.pnlButton.Controls.Add(this.btnLogOff);
            this.pnlButton.Controls.Add(this.xpFlatButton1);
            this.pnlButton.Controls.Add(this.btnShowReport);
            this.pnlButton.Controls.Add(this.lblRowsCount);
            this.pnlButton.Controls.Add(this.lblErrReport);
            this.pnlButton.Controls.Add(this.lblErrGroup);
            this.pnlButton.Controls.Add(this.lblDiv2);
            this.pnlButton.Controls.Add(this.lblReport);
            this.pnlButton.Controls.Add(this.lblGroup);
            this.pnlButton.Controls.Add(this.cmbReport);
            this.pnlButton.Controls.Add(this.cmbGroup);
            this.pnlButton.Controls.Add(this.lblAdminInfo);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButton.Location = new System.Drawing.Point(0, 0);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(659, 68);
            this.pnlButton.TabIndex = 100;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(164, 6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(48, 37);
            this.btnClear.TabIndex = 92;
            this.btnClear.Text = "נקה";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.BtnClearClick);
            // 
            // btnShowReport
            // 
            this.btnShowReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowReport.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnShowReport.Image = ((System.Drawing.Image)(resources.GetObject("btnShowReport.Image")));
            this.btnShowReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowReport.Location = new System.Drawing.Point(212, 6);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(113, 37);
            this.btnShowReport.TabIndex = 7;
            this.btnShowReport.Text = "הצג דוח  ";
            this.btnShowReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShowReport.UseVisualStyleBackColor = true;
            this.btnShowReport.Click += new System.EventHandler(this.BtnShowReportClick);
            // 
            // lblRowsCount
            // 
            this.lblRowsCount.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblRowsCount.ForeColor = System.Drawing.Color.Navy;
            this.lblRowsCount.Location = new System.Drawing.Point(206, 41);
            this.lblRowsCount.Name = "lblRowsCount";
            this.lblRowsCount.Size = new System.Drawing.Size(115, 16);
            this.lblRowsCount.TabIndex = 88;
            this.lblRowsCount.Text = "{0} רשומות בדוח";
            this.lblRowsCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRowsCount.Visible = false;
            // 
            // lblErrReport
            // 
            this.lblErrReport.Image = global::ClientManage.Properties.Resources.field_error;
            this.lblErrReport.Location = new System.Drawing.Point(332, 36);
            this.lblErrReport.Name = "lblErrReport";
            this.lblErrReport.Size = new System.Drawing.Size(16, 16);
            this.lblErrReport.TabIndex = 85;
            this.lblErrReport.Visible = false;
            // 
            // lblErrGroup
            // 
            this.lblErrGroup.Image = global::ClientManage.Properties.Resources.field_error;
            this.lblErrGroup.Location = new System.Drawing.Point(332, 8);
            this.lblErrGroup.Name = "lblErrGroup";
            this.lblErrGroup.Size = new System.Drawing.Size(16, 16);
            this.lblErrGroup.TabIndex = 84;
            this.lblErrGroup.Visible = false;
            // 
            // lblDiv2
            // 
            this.lblDiv2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiv2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(187)))), ((int)(((byte)(193)))));
            this.lblDiv2.Location = new System.Drawing.Point(346, 64);
            this.lblDiv2.Name = "lblDiv2";
            this.lblDiv2.Size = new System.Drawing.Size(310, 1);
            this.lblDiv2.TabIndex = 83;
            this.lblDiv2.Visible = false;
            // 
            // lblReport
            // 
            this.lblReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReport.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblReport.ForeColor = System.Drawing.Color.Navy;
            this.lblReport.Location = new System.Drawing.Point(586, 37);
            this.lblReport.Name = "lblReport";
            this.lblReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblReport.Size = new System.Drawing.Size(67, 19);
            this.lblReport.TabIndex = 11;
            this.lblReport.Text = "בחר דוח:";
            // 
            // lblGroup
            // 
            this.lblGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGroup.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblGroup.ForeColor = System.Drawing.Color.Navy;
            this.lblGroup.Location = new System.Drawing.Point(586, 9);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblGroup.Size = new System.Drawing.Size(67, 19);
            this.lblGroup.TabIndex = 10;
            this.lblGroup.Text = "בחר קבוצה:";
            // 
            // cmbReport
            // 
            this.cmbReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbReport.BackColor = System.Drawing.Color.White;
            this.cmbReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReport.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cmbReport.FormattingEnabled = true;
            this.cmbReport.Location = new System.Drawing.Point(351, 34);
            this.cmbReport.MaxDropDownItems = 10;
            this.cmbReport.Name = "cmbReport";
            this.cmbReport.Size = new System.Drawing.Size(229, 22);
            this.cmbReport.TabIndex = 9;
            this.cmbReport.SelectedIndexChanged += new System.EventHandler(this.CmbReportSelectedIndexChanged);
            // 
            // cmbGroup
            // 
            this.cmbGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGroup.BackColor = System.Drawing.Color.White;
            this.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroup.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(351, 6);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(229, 22);
            this.cmbGroup.TabIndex = 8;
            this.cmbGroup.SelectedIndexChanged += new System.EventHandler(this.CmbGroupSelectedIndexChanged);
            // 
            // lblAdminInfo
            // 
            this.lblAdminInfo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblAdminInfo.ForeColor = System.Drawing.Color.IndianRed;
            this.lblAdminInfo.Image = ((System.Drawing.Image)(resources.GetObject("lblAdminInfo.Image")));
            this.lblAdminInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAdminInfo.Location = new System.Drawing.Point(132, 19);
            this.lblAdminInfo.Name = "lblAdminInfo";
            this.lblAdminInfo.Size = new System.Drawing.Size(262, 34);
            this.lblAdminInfo.TabIndex = 91;
            this.lblAdminInfo.Text = "  מנהל מערכת, שים לב: מגבלות השימוש בדוח    \r\nזה הוסרו. לחץ על בטל חיבור מנהל לנע" +
                "ילת הדוח";
            this.lblAdminInfo.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.lblAdminInfo.Visible = false;
            // 
            // pnlFields
            // 
            this.pnlFields.BackColor = System.Drawing.Color.White;
            this.pnlFields.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFields.Location = new System.Drawing.Point(346, 68);
            this.pnlFields.Name = "pnlFields";
            this.pnlFields.Size = new System.Drawing.Size(313, 81);
            this.pnlFields.TabIndex = 103;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.BackColor = System.Drawing.Color.White;
            this.lblErrorMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblErrorMessage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(0, 68);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Padding = new System.Windows.Forms.Padding(5);
            this.lblErrorMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblErrorMessage.Size = new System.Drawing.Size(346, 81);
            this.lblErrorMessage.TabIndex = 104;
            // 
            // btnLogOff
            // 
            this.btnLogOff.BackColor = System.Drawing.Color.White;
            this.btnLogOff.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnLogOff.Image = ((System.Drawing.Image)(resources.GetObject("btnLogOff.Image")));
            this.btnLogOff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogOff.Location = new System.Drawing.Point(8, 31);
            this.btnLogOff.Name = "btnLogOff";
            this.btnLogOff.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnLogOff.Size = new System.Drawing.Size(118, 22);
            this.btnLogOff.TabIndex = 90;
            this.btnLogOff.Text = "       בטל חיבור מנהל";
            this.btnLogOff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogOff.Visible = false;
            this.btnLogOff.Click += new System.EventHandler(this.BtnLogOffClick);
            // 
            // xpFlatButton1
            // 
            this.xpFlatButton1.BackColor = System.Drawing.Color.White;
            this.xpFlatButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.xpFlatButton1.Image = global::ClientManage.Properties.Resources.hide_params;
            this.xpFlatButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xpFlatButton1.Location = new System.Drawing.Point(8, 6);
            this.xpFlatButton1.Name = "xpFlatButton1";
            this.xpFlatButton1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.xpFlatButton1.Size = new System.Drawing.Size(118, 22);
            this.xpFlatButton1.TabIndex = 89;
            this.xpFlatButton1.Text = "       הסתר פרמטרים";
            this.xpFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xpFlatButton1.Click += new System.EventHandler(this.XpFlatButton1Click);
            // 
            // ReportParametersPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblErrorMessage);
            this.Controls.Add(this.pnlFields);
            this.Controls.Add(this.pnlButton);
            this.Name = "ReportParametersPanel";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(659, 149);
            this.Load += new System.EventHandler(this.ReportParametersPanel_Load);
            this.pnlButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.Panel pnlFields;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.ComboBox cmbReport;
        private System.Windows.Forms.Label lblReport;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label lblDiv2;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.Label lblErrReport;
        private System.Windows.Forms.Label lblErrGroup;
        private System.Windows.Forms.Label lblRowsCount;
        private XPFlatButton xpFlatButton1;
        private XPFlatButton btnLogOff;
        private System.Windows.Forms.Label lblAdminInfo;
        private System.Windows.Forms.Button btnClear;

    }
}
