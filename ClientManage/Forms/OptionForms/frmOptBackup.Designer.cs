namespace ClientManage.Forms.OptionForms
{
    partial class FormOptBackup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOptBackup));
            this.chkFtpMinimize = new System.Windows.Forms.CheckBox();
            this.btnFtpBackup = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lblLastBackup = new System.Windows.Forms.Label();
            this.chkFTPFreez = new System.Windows.Forms.CheckBox();
            this.cmbFTPHour = new System.Windows.Forms.ComboBox();
            this.cmbFTPMin = new System.Windows.Forms.ComboBox();
            this.lblFtp1 = new System.Windows.Forms.Label();
            this.lblFtp2 = new System.Windows.Forms.Label();
            this.cmbFTPPeriod = new System.Windows.Forms.ComboBox();
            this.lblFtp3 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.fBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.chkAllPictures = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkFtpMinimize
            // 
            this.chkFtpMinimize.Enabled = false;
            this.chkFtpMinimize.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chkFtpMinimize.Location = new System.Drawing.Point(15, 110);
            this.chkFtpMinimize.Name = "chkFtpMinimize";
            this.chkFtpMinimize.Size = new System.Drawing.Size(388, 19);
            this.chkFtpMinimize.TabIndex = 58;
            this.chkFtpMinimize.Text = "פתח את חלון הגיבוי ממוזער";
            this.chkFtpMinimize.UseVisualStyleBackColor = true;
            // 
            // btnFtpBackup
            // 
            this.btnFtpBackup.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnFtpBackup.Image = ((System.Drawing.Image)(resources.GetObject("btnFtpBackup.Image")));
            this.btnFtpBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFtpBackup.Location = new System.Drawing.Point(15, 222);
            this.btnFtpBackup.Name = "btnFtpBackup";
            this.btnFtpBackup.Size = new System.Drawing.Size(146, 51);
            this.btnFtpBackup.TabIndex = 53;
            this.btnFtpBackup.Text = "גבה ברשת   ";
            this.btnFtpBackup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFtpBackup.UseVisualStyleBackColor = true;
            this.btnFtpBackup.Click += new System.EventHandler(this.BtnFtpBackupClick);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(15, 166);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(146, 51);
            this.button3.TabIndex = 52;
            this.button3.Text = "בצע גיבוי ידני";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3Click);
            // 
            // lblLastBackup
            // 
            this.lblLastBackup.BackColor = System.Drawing.Color.Transparent;
            this.lblLastBackup.ForeColor = System.Drawing.Color.Maroon;
            this.lblLastBackup.Location = new System.Drawing.Point(12, 132);
            this.lblLastBackup.Name = "lblLastBackup";
            this.lblLastBackup.Size = new System.Drawing.Size(336, 19);
            this.lblLastBackup.TabIndex = 56;
            this.lblLastBackup.Text = "גיבוי נתונים אוטומטי בוצע לאחרונה בתאריך {0}";
            // 
            // chkFTPFreez
            // 
            this.chkFTPFreez.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chkFTPFreez.Location = new System.Drawing.Point(15, 88);
            this.chkFTPFreez.Name = "chkFTPFreez";
            this.chkFTPFreez.Size = new System.Drawing.Size(388, 19);
            this.chkFTPFreez.TabIndex = 50;
            this.chkFTPFreez.Text = "אפשר גיבוי נתונים אוטומטי";
            this.chkFTPFreez.UseVisualStyleBackColor = true;
            this.chkFTPFreez.CheckedChanged += new System.EventHandler(this.ChkFtpFreezCheckedChanged);
            // 
            // cmbFTPHour
            // 
            this.cmbFTPHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFTPHour.Enabled = false;
            this.cmbFTPHour.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbFTPHour.FormattingEnabled = true;
            this.cmbFTPHour.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.cmbFTPHour.Location = new System.Drawing.Point(306, 60);
            this.cmbFTPHour.Name = "cmbFTPHour";
            this.cmbFTPHour.Size = new System.Drawing.Size(42, 22);
            this.cmbFTPHour.TabIndex = 49;
            // 
            // cmbFTPMin
            // 
            this.cmbFTPMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFTPMin.Enabled = false;
            this.cmbFTPMin.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbFTPMin.FormattingEnabled = true;
            this.cmbFTPMin.Items.AddRange(new object[] {
            "00",
            "05",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55"});
            this.cmbFTPMin.Location = new System.Drawing.Point(256, 60);
            this.cmbFTPMin.Name = "cmbFTPMin";
            this.cmbFTPMin.Size = new System.Drawing.Size(42, 22);
            this.cmbFTPMin.TabIndex = 47;
            // 
            // lblFtp1
            // 
            this.lblFtp1.Enabled = false;
            this.lblFtp1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblFtp1.Location = new System.Drawing.Point(296, 63);
            this.lblFtp1.Name = "lblFtp1";
            this.lblFtp1.Size = new System.Drawing.Size(8, 19);
            this.lblFtp1.TabIndex = 55;
            this.lblFtp1.Text = ":";
            // 
            // lblFtp2
            // 
            this.lblFtp2.Enabled = false;
            this.lblFtp2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblFtp2.Location = new System.Drawing.Point(178, 63);
            this.lblFtp2.Name = "lblFtp2";
            this.lblFtp2.Size = new System.Drawing.Size(81, 19);
            this.lblFtp2.TabIndex = 54;
            this.lblFtp2.Text = "ימים, בשעה:";
            // 
            // cmbFTPPeriod
            // 
            this.cmbFTPPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFTPPeriod.Enabled = false;
            this.cmbFTPPeriod.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbFTPPeriod.FormattingEnabled = true;
            this.cmbFTPPeriod.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cmbFTPPeriod.Location = new System.Drawing.Point(133, 60);
            this.cmbFTPPeriod.Name = "cmbFTPPeriod";
            this.cmbFTPPeriod.Size = new System.Drawing.Size(42, 22);
            this.cmbFTPPeriod.TabIndex = 45;
            // 
            // lblFtp3
            // 
            this.lblFtp3.Enabled = false;
            this.lblFtp3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblFtp3.Location = new System.Drawing.Point(107, 63);
            this.lblFtp3.Name = "lblFtp3";
            this.lblFtp3.Size = new System.Drawing.Size(31, 19);
            this.lblFtp3.TabIndex = 51;
            this.lblFtp3.Text = "כל";
            // 
            // label80
            // 
            this.label80.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label80.Location = new System.Drawing.Point(12, 63);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(100, 19);
            this.label80.TabIndex = 48;
            this.label80.Text = "תזמון:";
            // 
            // label76
            // 
            this.label76.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label76.Location = new System.Drawing.Point(12, 289);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(115, 19);
            this.label76.TabIndex = 38;
            this.label76.Text = "לוג גיבוי:";
            // 
            // fBrowserDialog
            // 
            this.fBrowserDialog.Description = "בחר את ההתקן והמחיצה בה ישמר הגיבוי";
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLog.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtLog.Location = new System.Drawing.Point(15, 306);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(724, 124);
            this.txtLog.TabIndex = 39;
            this.txtLog.Tag = "";
            // 
            // chkAllPictures
            // 
            this.chkAllPictures.AutoSize = true;
            this.chkAllPictures.Enabled = false;
            this.chkAllPictures.Location = new System.Drawing.Point(168, 241);
            this.chkAllPictures.Name = "chkAllPictures";
            this.chkAllPictures.Size = new System.Drawing.Size(91, 18);
            this.chkAllPictures.TabIndex = 59;
            this.chkAllPictures.Tag = "SuperUser";
            this.chkAllPictures.Text = "כל התמונות";
            this.chkAllPictures.UseVisualStyleBackColor = true;
            // 
            // FormOptBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 620);
            this.Controls.Add(this.chkAllPictures);
            this.Controls.Add(this.btnFtpBackup);
            this.Controls.Add(this.chkFtpMinimize);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lblLastBackup);
            this.Controls.Add(this.chkFTPFreez);
            this.Controls.Add(this.cmbFTPHour);
            this.Controls.Add(this.cmbFTPMin);
            this.Controls.Add(this.lblFtp1);
            this.Controls.Add(this.lblFtp2);
            this.Controls.Add(this.cmbFTPPeriod);
            this.Controls.Add(this.lblFtp3);
            this.Controls.Add(this.label76);
            this.Controls.Add(this.label80);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormOptBackup";
            this.Text = "frmOptBackup";
            this.Enter += new System.EventHandler(this.FormOptBackupEnter);
            this.Controls.SetChildIndex(this.label80, 0);
            this.Controls.SetChildIndex(this.label76, 0);
            this.Controls.SetChildIndex(this.lblFtp3, 0);
            this.Controls.SetChildIndex(this.cmbFTPPeriod, 0);
            this.Controls.SetChildIndex(this.lblFtp2, 0);
            this.Controls.SetChildIndex(this.lblFtp1, 0);
            this.Controls.SetChildIndex(this.cmbFTPMin, 0);
            this.Controls.SetChildIndex(this.cmbFTPHour, 0);
            this.Controls.SetChildIndex(this.chkFTPFreez, 0);
            this.Controls.SetChildIndex(this.lblLastBackup, 0);
            this.Controls.SetChildIndex(this.txtLog, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.Controls.SetChildIndex(this.chkFtpMinimize, 0);
            this.Controls.SetChildIndex(this.btnFtpBackup, 0);
            this.Controls.SetChildIndex(this.chkAllPictures, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkFtpMinimize;
        private System.Windows.Forms.Button btnFtpBackup;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblLastBackup;
        private System.Windows.Forms.CheckBox chkFTPFreez;
        private System.Windows.Forms.ComboBox cmbFTPHour;
        private System.Windows.Forms.ComboBox cmbFTPMin;
        private System.Windows.Forms.Label lblFtp1;
        private System.Windows.Forms.Label lblFtp2;
        private System.Windows.Forms.ComboBox cmbFTPPeriod;
        private System.Windows.Forms.Label lblFtp3;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.FolderBrowserDialog fBrowserDialog;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.CheckBox chkAllPictures;
    }
}