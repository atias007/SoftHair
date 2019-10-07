namespace ClientManage.Forms.OptionForms
{
    partial class FormOptSystem2
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
            this.btnLoadHardware = new System.Windows.Forms.Button();
            this.lstHarware = new System.Windows.Forms.CheckedListBox();
            this.label84 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPatternClient = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPatternWorkers = new System.Windows.Forms.TextBox();
            this.txtPatternSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCardDelay = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkAutoRegisterSub = new System.Windows.Forms.CheckBox();
            this.txtScript = new System.Windows.Forms.TextBox();
            this.btnScript = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMasterCard = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnLoadHardware
            // 
            this.btnLoadHardware.Location = new System.Drawing.Point(14, 561);
            this.btnLoadHardware.Name = "btnLoadHardware";
            this.btnLoadHardware.Size = new System.Drawing.Size(209, 30);
            this.btnLoadHardware.TabIndex = 28;
            this.btnLoadHardware.Text = "טען את רשימת ההתקנים המלאה";
            this.btnLoadHardware.UseVisualStyleBackColor = true;
            this.btnLoadHardware.Click += new System.EventHandler(this.BtnLoadHardwareClick);
            // 
            // lstHarware
            // 
            this.lstHarware.FormattingEnabled = true;
            this.lstHarware.IntegralHeight = false;
            this.lstHarware.Location = new System.Drawing.Point(14, 82);
            this.lstHarware.Name = "lstHarware";
            this.lstHarware.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstHarware.Size = new System.Drawing.Size(353, 475);
            this.lstHarware.TabIndex = 27;
            // 
            // label84
            // 
            this.label84.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label84.Location = new System.Drawing.Point(14, 66);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(332, 20);
            this.label84.TabIndex = 29;
            this.label84.Tag = "";
            this.label84.Text = "נטרל את ההתקנים הבאים בעת הפעלת המערכת:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(389, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(332, 20);
            this.label2.TabIndex = 30;
            this.label2.Tag = "";
            this.label2.Text = "קורא כרטיסים:";
            // 
            // txtPatternClient
            // 
            this.txtPatternClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPatternClient.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtPatternClient.Location = new System.Drawing.Point(561, 89);
            this.txtPatternClient.MaxLength = 255;
            this.txtPatternClient.Name = "txtPatternClient";
            this.txtPatternClient.PasswordChar = '*';
            this.txtPatternClient.ReadOnly = true;
            this.txtPatternClient.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPatternClient.Size = new System.Drawing.Size(184, 22);
            this.txtPatternClient.TabIndex = 46;
            this.txtPatternClient.Tag = "SuperUser";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label7.Location = new System.Drawing.Point(389, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 20);
            this.label7.TabIndex = 73;
            this.label7.Tag = "";
            this.label7.Text = "תבנית כרטיס (לקוחות):";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(389, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 20);
            this.label3.TabIndex = 74;
            this.label3.Tag = "";
            this.label3.Text = "תבנית כרטיס (עובדים):";
            // 
            // txtPatternWorkers
            // 
            this.txtPatternWorkers.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPatternWorkers.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtPatternWorkers.Location = new System.Drawing.Point(561, 114);
            this.txtPatternWorkers.MaxLength = 255;
            this.txtPatternWorkers.Name = "txtPatternWorkers";
            this.txtPatternWorkers.PasswordChar = '*';
            this.txtPatternWorkers.ReadOnly = true;
            this.txtPatternWorkers.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPatternWorkers.Size = new System.Drawing.Size(184, 22);
            this.txtPatternWorkers.TabIndex = 75;
            this.txtPatternWorkers.Tag = "SuperUser";
            // 
            // txtPatternSize
            // 
            this.txtPatternSize.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPatternSize.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtPatternSize.Location = new System.Drawing.Point(561, 139);
            this.txtPatternSize.MaxLength = 255;
            this.txtPatternSize.Name = "txtPatternSize";
            this.txtPatternSize.ReadOnly = true;
            this.txtPatternSize.Size = new System.Drawing.Size(184, 22);
            this.txtPatternSize.TabIndex = 77;
            this.txtPatternSize.Tag = "SuperUser";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(389, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 20);
            this.label4.TabIndex = 76;
            this.label4.Tag = "";
            this.label4.Text = "כמות תווים במספר הסידורי:";
            // 
            // txtCardDelay
            // 
            this.txtCardDelay.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCardDelay.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtCardDelay.Location = new System.Drawing.Point(561, 164);
            this.txtCardDelay.MaxLength = 255;
            this.txtCardDelay.Name = "txtCardDelay";
            this.txtCardDelay.ReadOnly = true;
            this.txtCardDelay.Size = new System.Drawing.Size(184, 22);
            this.txtCardDelay.TabIndex = 79;
            this.txtCardDelay.Tag = "SuperUser";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(389, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 20);
            this.label5.TabIndex = 78;
            this.label5.Tag = "";
            this.label5.Text = "השהייה (Ticks):";
            // 
            // chkAutoRegisterSub
            // 
            this.chkAutoRegisterSub.Enabled = false;
            this.chkAutoRegisterSub.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chkAutoRegisterSub.Location = new System.Drawing.Point(392, 217);
            this.chkAutoRegisterSub.Name = "chkAutoRegisterSub";
            this.chkAutoRegisterSub.Size = new System.Drawing.Size(282, 20);
            this.chkAutoRegisterSub.TabIndex = 80;
            this.chkAutoRegisterSub.Tag = "Admin";
            this.chkAutoRegisterSub.Text = "רשום אוטומטית מנוי יחיד (אם הוא פעיל)";
            this.chkAutoRegisterSub.UseVisualStyleBackColor = true;
            // 
            // txtScript
            // 
            this.txtScript.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScript.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtScript.Location = new System.Drawing.Point(392, 261);
            this.txtScript.Multiline = true;
            this.txtScript.Name = "txtScript";
            this.txtScript.ReadOnly = true;
            this.txtScript.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtScript.Size = new System.Drawing.Size(353, 296);
            this.txtScript.TabIndex = 81;
            this.txtScript.Tag = "SuperUser";
            // 
            // btnScript
            // 
            this.btnScript.Enabled = false;
            this.btnScript.Location = new System.Drawing.Point(392, 563);
            this.btnScript.Name = "btnScript";
            this.btnScript.Size = new System.Drawing.Size(104, 30);
            this.btnScript.TabIndex = 82;
            this.btnScript.Tag = "SuperUser";
            this.btnScript.Text = "הרץ סקריפט";
            this.btnScript.UseVisualStyleBackColor = true;
            this.btnScript.Click += new System.EventHandler(this.btnScript_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(389, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 20);
            this.label6.TabIndex = 78;
            this.label6.Tag = "";
            this.label6.Text = "כרטיס מאסטר:";
            // 
            // txtMasterCard
            // 
            this.txtMasterCard.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMasterCard.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtMasterCard.Location = new System.Drawing.Point(561, 189);
            this.txtMasterCard.MaxLength = 255;
            this.txtMasterCard.Name = "txtMasterCard";
            this.txtMasterCard.ReadOnly = true;
            this.txtMasterCard.Size = new System.Drawing.Size(184, 22);
            this.txtMasterCard.TabIndex = 79;
            this.txtMasterCard.Tag = "SuperUser";
            // 
            // FormOptSystem2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 620);
            this.Controls.Add(this.btnScript);
            this.Controls.Add(this.txtScript);
            this.Controls.Add(this.chkAutoRegisterSub);
            this.Controls.Add(this.txtMasterCard);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCardDelay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPatternSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPatternWorkers);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPatternClient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstHarware);
            this.Controls.Add(this.btnLoadHardware);
            this.Controls.Add(this.label84);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormOptSystem2";
            this.Text = "frmSysOptSystem2";
            this.Controls.SetChildIndex(this.label84, 0);
            this.Controls.SetChildIndex(this.btnLoadHardware, 0);
            this.Controls.SetChildIndex(this.lstHarware, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtPatternClient, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtPatternWorkers, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtPatternSize, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtCardDelay, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtMasterCard, 0);
            this.Controls.SetChildIndex(this.chkAutoRegisterSub, 0);
            this.Controls.SetChildIndex(this.txtScript, 0);
            this.Controls.SetChildIndex(this.btnScript, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadHardware;
        private System.Windows.Forms.CheckedListBox lstHarware;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPatternClient;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPatternWorkers;
        private System.Windows.Forms.TextBox txtPatternSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCardDelay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkAutoRegisterSub;
        private System.Windows.Forms.TextBox txtScript;
        private System.Windows.Forms.Button btnScript;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMasterCard;
    }
}