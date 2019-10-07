namespace SoftHairQuickLanch.Forms
{
    partial class FrmSupport2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSupport2));
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMsgIcon = new System.Windows.Forms.Label();
            this.lblMsgText = new System.Windows.Forms.Label();
            this.pnlError = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblErrorMsgText = new System.Windows.Forms.Label();
            this.pnlWarning = new System.Windows.Forms.Panel();
            this.btnWarnOk = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblWarnMsg = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.pnlError.SuspendLayout();
            this.pnlWarning.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRemark
            // 
            this.txtRemark.AcceptsReturn = true;
            this.txtRemark.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtRemark.ForeColor = System.Drawing.Color.Black;
            this.txtRemark.Location = new System.Drawing.Point(12, 243);
            this.txtRemark.MaxLength = 1000;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRemark.Size = new System.Drawing.Size(250, 112);
            this.txtRemark.TabIndex = 9;
            this.txtRemark.Leave += new System.EventHandler(this.TxtPhoneLeave);
            this.txtRemark.Enter += new System.EventHandler(this.TxtPhoneEnter);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(260, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 55);
            this.label4.TabIndex = 11;
            this.label4.Text = "תיאור התקלה / קריאת שירות";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(278, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "טלפון לחזרה";
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtPhone.ForeColor = System.Drawing.Color.Black;
            this.txtPhone.Location = new System.Drawing.Point(12, 218);
            this.txtPhone.MaxLength = 15;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPhone.Size = new System.Drawing.Size(250, 22);
            this.txtPhone.TabIndex = 8;
            this.txtPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPhone.Leave += new System.EventHandler(this.TxtPhoneLeave);
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPhoneKeyPress);
            this.txtPhone.Enter += new System.EventHandler(this.TxtPhoneEnter);
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
            this.btnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSend.Location = new System.Drawing.Point(86, 361);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(122, 38);
            this.btnSend.TabIndex = 12;
            this.btnSend.Text = "  שלח קריאה";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.BtnSendClick);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(12, 361);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 38);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "  בטל";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label5.Location = new System.Drawing.Point(5, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 22);
            this.label5.TabIndex = 106;
            this.label5.Text = "תמיכה ושירות מקוון";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(87)))), ((int)(((byte)(92)))));
            this.label2.Location = new System.Drawing.Point(52, 116);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(8);
            this.label2.Size = new System.Drawing.Size(261, 81);
            this.label2.TabIndex = 107;
            this.label2.Text = "לקוח יקר,\r\nאנא הזן בשדות שלהלן את מספר הטלפון שלך\r\nוכן פרט את תיאור התקלה ו/או קר" +
                "יאת השירות.\r\n\r\nנציגנו יצרו עמך קשר בהקדם האפשרי.";
            this.label2.Paint += new System.Windows.Forms.PaintEventHandler(this.Label2Paint);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(28, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 48);
            this.label1.TabIndex = 108;
            this.label1.Click += new System.EventHandler(this.Label1Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::SoftHairQuickLanch.Properties.Resources.b2;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.lblMsgIcon);
            this.panel1.Controls.Add(this.lblMsgText);
            this.panel1.Location = new System.Drawing.Point(339, 279);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(349, 307);
            this.panel1.TabIndex = 109;
            this.panel1.Visible = false;
            // 
            // lblMsgIcon
            // 
            this.lblMsgIcon.BackColor = System.Drawing.Color.Transparent;
            this.lblMsgIcon.Image = global::SoftHairQuickLanch.Properties.Resources.msg_ok;
            this.lblMsgIcon.Location = new System.Drawing.Point(10, 46);
            this.lblMsgIcon.Name = "lblMsgIcon";
            this.lblMsgIcon.Size = new System.Drawing.Size(48, 48);
            this.lblMsgIcon.TabIndex = 0;
            // 
            // lblMsgText
            // 
            this.lblMsgText.BackColor = System.Drawing.Color.Transparent;
            this.lblMsgText.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblMsgText.Location = new System.Drawing.Point(10, 96);
            this.lblMsgText.Name = "lblMsgText";
            this.lblMsgText.Size = new System.Drawing.Size(328, 127);
            this.lblMsgText.TabIndex = 1;
            this.lblMsgText.Text = "בקשתך נשלחה בהצלחה.\r\n\r\nאנא השאר חלון זה פתוח,\r\nסגור כל תוכנה פתוחה לשיתוף קבצים.\r" +
                "\nנציגנו יצרו עמך קשר בהקדם האפשרי.";
            this.lblMsgText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlError
            // 
            this.pnlError.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlError.BackgroundImage")));
            this.pnlError.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlError.Controls.Add(this.btnConfirm);
            this.pnlError.Controls.Add(this.label7);
            this.pnlError.Controls.Add(this.lblErrorMsgText);
            this.pnlError.Location = new System.Drawing.Point(309, 279);
            this.pnlError.Name = "pnlError";
            this.pnlError.Size = new System.Drawing.Size(349, 307);
            this.pnlError.TabIndex = 110;
            this.pnlError.Visible = false;
            // 
            // btnConfirm
            // 
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnConfirm.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirm.Location = new System.Drawing.Point(131, 232);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(72, 38);
            this.btnConfirm.TabIndex = 6;
            this.btnConfirm.Text = "אישור";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.BtnConfirmClick);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Image = global::SoftHairQuickLanch.Properties.Resources.msg_err1;
            this.label7.Location = new System.Drawing.Point(10, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 48);
            this.label7.TabIndex = 0;
            // 
            // lblErrorMsgText
            // 
            this.lblErrorMsgText.BackColor = System.Drawing.Color.Transparent;
            this.lblErrorMsgText.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblErrorMsgText.Location = new System.Drawing.Point(10, 100);
            this.lblErrorMsgText.Name = "lblErrorMsgText";
            this.lblErrorMsgText.Size = new System.Drawing.Size(328, 125);
            this.lblErrorMsgText.TabIndex = 1;
            this.lblErrorMsgText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlWarning
            // 
            this.pnlWarning.BackgroundImage = global::SoftHairQuickLanch.Properties.Resources.b3;
            this.pnlWarning.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlWarning.Controls.Add(this.btnWarnOk);
            this.pnlWarning.Controls.Add(this.label6);
            this.pnlWarning.Controls.Add(this.lblWarnMsg);
            this.pnlWarning.Location = new System.Drawing.Point(278, 279);
            this.pnlWarning.Name = "pnlWarning";
            this.pnlWarning.Size = new System.Drawing.Size(349, 307);
            this.pnlWarning.TabIndex = 111;
            this.pnlWarning.Visible = false;
            // 
            // btnWarnOk
            // 
            this.btnWarnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnWarnOk.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnWarnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWarnOk.Location = new System.Drawing.Point(131, 232);
            this.btnWarnOk.Name = "btnWarnOk";
            this.btnWarnOk.Size = new System.Drawing.Size(72, 38);
            this.btnWarnOk.TabIndex = 6;
            this.btnWarnOk.Text = "אישור";
            this.btnWarnOk.UseVisualStyleBackColor = true;
            this.btnWarnOk.Click += new System.EventHandler(this.BtnWarnOkClick);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Image = global::SoftHairQuickLanch.Properties.Resources.msg_wrn1;
            this.label6.Location = new System.Drawing.Point(10, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 48);
            this.label6.TabIndex = 0;
            // 
            // lblWarnMsg
            // 
            this.lblWarnMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblWarnMsg.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblWarnMsg.Location = new System.Drawing.Point(10, 100);
            this.lblWarnMsg.Name = "lblWarnMsg";
            this.lblWarnMsg.Size = new System.Drawing.Size(328, 125);
            this.lblWarnMsg.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
            // 
            // frmSupport2
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(364, 407);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.pnlError);
            this.Controls.Add(this.pnlWarning);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmSupport2";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "תמיכה ושירות מקוון";
            this.Load += new System.EventHandler(this.FrmSupport2Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSupport2KeyDown);
            this.panel1.ResumeLayout(false);
            this.pnlError.ResumeLayout(false);
            this.pnlWarning.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMsgIcon;
        private System.Windows.Forms.Label lblMsgText;
        private System.Windows.Forms.Panel pnlError;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblErrorMsgText;
        private System.Windows.Forms.Panel pnlWarning;
        private System.Windows.Forms.Button btnWarnOk;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblWarnMsg;
        private System.Windows.Forms.Timer timer1;
    }
}