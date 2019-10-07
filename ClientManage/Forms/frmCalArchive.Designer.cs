namespace ClientManage.Forms
{
    partial class FormCalArchive
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
            this.optArchive1 = new System.Windows.Forms.RadioButton();
            this.optArchive3 = new System.Windows.Forms.RadioButton();
            this.optArchive4 = new System.Windows.Forms.RadioButton();
            this.optArchive5 = new System.Windows.Forms.RadioButton();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.cmbPeriod = new System.Windows.Forms.ComboBox();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkOnlyOld = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.optArchive2 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.lblToDate2 = new System.Windows.Forms.Label();
            this.optArchive6 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // optArchive1
            // 
            this.optArchive1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.optArchive1.Location = new System.Drawing.Point(12, 40);
            this.optArchive1.Name = "optArchive1";
            this.optArchive1.Size = new System.Drawing.Size(386, 24);
            this.optArchive1.TabIndex = 9;
            this.optArchive1.TabStop = true;
            this.optArchive1.Text = "העבר לארכיון את כל התורים";
            this.optArchive1.UseVisualStyleBackColor = true;
            this.optArchive1.CheckedChanged += new System.EventHandler(this.OptArchiveCheckedChanged);
            // 
            // optArchive3
            // 
            this.optArchive3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.optArchive3.ForeColor = System.Drawing.Color.DimGray;
            this.optArchive3.Location = new System.Drawing.Point(12, 130);
            this.optArchive3.Name = "optArchive3";
            this.optArchive3.Size = new System.Drawing.Size(386, 24);
            this.optArchive3.TabIndex = 10;
            this.optArchive3.TabStop = true;
            this.optArchive3.Text = "העבר לארכיון רק את התורים בטווח התאריכים הבא:";
            this.optArchive3.UseVisualStyleBackColor = true;
            this.optArchive3.CheckedChanged += new System.EventHandler(this.OptArchiveCheckedChanged);
            // 
            // optArchive4
            // 
            this.optArchive4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.optArchive4.ForeColor = System.Drawing.Color.DimGray;
            this.optArchive4.Location = new System.Drawing.Point(12, 213);
            this.optArchive4.Name = "optArchive4";
            this.optArchive4.Size = new System.Drawing.Size(386, 24);
            this.optArchive4.TabIndex = 11;
            this.optArchive4.TabStop = true;
            this.optArchive4.Text = "העבר לארכיון רק את התורים בטווח התקופה הבא:";
            this.optArchive4.UseVisualStyleBackColor = true;
            this.optArchive4.CheckedChanged += new System.EventHandler(this.OptArchiveCheckedChanged);
            // 
            // optArchive5
            // 
            this.optArchive5.BackColor = System.Drawing.Color.White;
            this.optArchive5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.optArchive5.ForeColor = System.Drawing.Color.DimGray;
            this.optArchive5.Location = new System.Drawing.Point(12, 278);
            this.optArchive5.Name = "optArchive5";
            this.optArchive5.Size = new System.Drawing.Size(386, 24);
            this.optArchive5.TabIndex = 12;
            this.optArchive5.TabStop = true;
            this.optArchive5.Text = "טען תורים ליומן מקובץ ארכיון:";
            this.optArchive5.UseVisualStyleBackColor = false;
            this.optArchive5.CheckedChanged += new System.EventHandler(this.OptArchiveCheckedChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.dtpFromDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(199)))), ((int)(((byte)(255)))));
            this.dtpFromDate.CustomFormat = "yyyy/MM/dd";
            this.dtpFromDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpFromDate.Enabled = false;
            this.dtpFromDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(166, 160);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.RightToLeftLayout = true;
            this.dtpFromDate.Size = new System.Drawing.Size(119, 23);
            this.dtpFromDate.TabIndex = 13;
            this.dtpFromDate.Value = new System.DateTime(2007, 5, 27, 0, 0, 0, 0);
            // 
            // lblFromDate
            // 
            this.lblFromDate.Enabled = false;
            this.lblFromDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblFromDate.Location = new System.Drawing.Point(283, 164);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(82, 20);
            this.lblFromDate.TabIndex = 14;
            this.lblFromDate.Text = "החל מתאריך";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.dtpToDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(199)))), ((int)(((byte)(255)))));
            this.dtpToDate.CustomFormat = "yyyy/MM/dd";
            this.dtpToDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpToDate.Enabled = false;
            this.dtpToDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(166, 189);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpToDate.RightToLeftLayout = true;
            this.dtpToDate.Size = new System.Drawing.Size(119, 23);
            this.dtpToDate.TabIndex = 15;
            this.dtpToDate.Value = new System.DateTime(2007, 5, 27, 0, 0, 0, 0);
            // 
            // lblToDate
            // 
            this.lblToDate.Enabled = false;
            this.lblToDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblToDate.Location = new System.Drawing.Point(283, 193);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(82, 20);
            this.lblToDate.TabIndex = 16;
            this.lblToDate.Text = "ועד תאריך";
            // 
            // cmbPeriod
            // 
            this.cmbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriod.Enabled = false;
            this.cmbPeriod.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbPeriod.FormattingEnabled = true;
            this.cmbPeriod.Items.AddRange(new object[] {
            "היום",
            "השבוע",
            "החודש",
            "חודש קודם",
            "השנה",
            "שנה שעברה"});
            this.cmbPeriod.Location = new System.Drawing.Point(100, 243);
            this.cmbPeriod.Name = "cmbPeriod";
            this.cmbPeriod.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbPeriod.Size = new System.Drawing.Size(163, 22);
            this.cmbPeriod.TabIndex = 22;
            this.cmbPeriod.SelectedIndexChanged += new System.EventHandler(this.CmbPeriodSelectedIndexChanged);
            // 
            // lblPeriod
            // 
            this.lblPeriod.Enabled = false;
            this.lblPeriod.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblPeriod.Location = new System.Drawing.Point(260, 245);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(105, 20);
            this.lblPeriod.TabIndex = 23;
            this.lblPeriod.Text = "תורים שהתרחשו";
            // 
            // txtFilename
            // 
            this.txtFilename.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFilename.Enabled = false;
            this.txtFilename.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtFilename.Location = new System.Drawing.Point(56, 308);
            this.txtFilename.MaxLength = 50;
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.ReadOnly = true;
            this.txtFilename.Size = new System.Drawing.Size(323, 23);
            this.txtFilename.TabIndex = 25;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Enabled = false;
            this.btnBrowse.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnBrowse.Location = new System.Drawing.Point(12, 308);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(44, 23);
            this.btnBrowse.TabIndex = 26;
            this.btnBrowse.Text = "עיון...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowseClick);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnOk.Location = new System.Drawing.Point(251, 426);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(147, 43);
            this.btnOk.TabIndex = 27;
            this.btnOk.Text = "העבר לארכיון";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnClose.Location = new System.Drawing.Point(190, 426);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(59, 43);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "סגור";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // chkOnlyOld
            // 
            this.chkOnlyOld.AutoSize = true;
            this.chkOnlyOld.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(243)))));
            this.chkOnlyOld.Checked = true;
            this.chkOnlyOld.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnlyOld.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chkOnlyOld.Location = new System.Drawing.Point(9, 452);
            this.chkOnlyOld.Name = "chkOnlyOld";
            this.chkOnlyOld.Size = new System.Drawing.Size(162, 17);
            this.chkOnlyOld.TabIndex = 29;
            this.chkOnlyOld.Text = "העבר רק תורים שתם זמנם";
            this.chkOnlyOld.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(243)))));
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(354, 353);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 30;
            this.label1.Text = "הערות:";
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtRemark.Location = new System.Drawing.Point(12, 352);
            this.txtRemark.MaxLength = 255;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(346, 57);
            this.txtRemark.TabIndex = 31;
            this.txtRemark.Enter += new System.EventHandler(this.TxtRemarkEnter);
            this.txtRemark.Leave += new System.EventHandler(this.TxtRemarkLeave);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "sharc";
            this.saveFileDialog1.FileName = "SoftHairArchive";
            this.saveFileDialog1.Filter = "SoftHair Archive File (*.sharc) | *.sharc";
            this.saveFileDialog1.RestoreDirectory = true;
            this.saveFileDialog1.Title = "בחר שם לקובץ הארכיון...";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "arc";
            this.openFileDialog1.Filter = "SoftHair Archive File (*.sharc) | *.sharc";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.Title = "בחר קובץ ארכיון לטעינה...";
            // 
            // optArchive2
            // 
            this.optArchive2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.optArchive2.ForeColor = System.Drawing.Color.DimGray;
            this.optArchive2.Location = new System.Drawing.Point(12, 100);
            this.optArchive2.Name = "optArchive2";
            this.optArchive2.Size = new System.Drawing.Size(386, 24);
            this.optArchive2.TabIndex = 33;
            this.optArchive2.TabStop = true;
            this.optArchive2.Text = "העבר לארכיון את כל התורים מלבד ביקור אחרון לכל לקוח";
            this.optArchive2.UseVisualStyleBackColor = true;
            this.optArchive2.CheckedChanged += new System.EventHandler(this.OptArchiveCheckedChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(243)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(8, 339);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(399, 140);
            this.label3.TabIndex = 34;
            this.label3.Paint += new System.Windows.Forms.PaintEventHandler(this.Label3Paint);
            // 
            // lblToDate2
            // 
            this.lblToDate2.Enabled = false;
            this.lblToDate2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblToDate2.Location = new System.Drawing.Point(82, 193);
            this.lblToDate2.Name = "lblToDate2";
            this.lblToDate2.Size = new System.Drawing.Size(82, 20);
            this.lblToDate2.TabIndex = 35;
            this.lblToDate2.Text = "(כולל)";
            // 
            // optArchive6
            // 
            this.optArchive6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.optArchive6.ForeColor = System.Drawing.Color.DimGray;
            this.optArchive6.Location = new System.Drawing.Point(12, 70);
            this.optArchive6.Name = "optArchive6";
            this.optArchive6.Size = new System.Drawing.Size(386, 24);
            this.optArchive6.TabIndex = 36;
            this.optArchive6.TabStop = true;
            this.optArchive6.Text = "העבר לארכיון תורים מבוטלים";
            this.optArchive6.UseVisualStyleBackColor = true;
            this.optArchive6.CheckedChanged += new System.EventHandler(this.OptArchiveCheckedChanged);
            // 
            // FormCalArchive
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(415, 487);
            this.Controls.Add(this.optArchive6);
            this.Controls.Add(this.optArchive2);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkOnlyOld);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.cmbPeriod);
            this.Controls.Add(this.lblPeriod);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.optArchive5);
            this.Controls.Add(this.optArchive4);
            this.Controls.Add(this.optArchive3);
            this.Controls.Add(this.optArchive1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblToDate2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCalArchive";
            this.Padding = new System.Windows.Forms.Padding(8, 20, 8, 8);
            this.ShowMaximizeControl = false;
            this.ShowMinimizeControl = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ניהול ארכיון עבור יומן תורים";
            this.Load += new System.EventHandler(this.FrmCalArchiveLoad);
            this.Controls.SetChildIndex(this.lblToDate2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.optArchive1, 0);
            this.Controls.SetChildIndex(this.optArchive3, 0);
            this.Controls.SetChildIndex(this.optArchive4, 0);
            this.Controls.SetChildIndex(this.optArchive5, 0);
            this.Controls.SetChildIndex(this.lblFromDate, 0);
            this.Controls.SetChildIndex(this.dtpFromDate, 0);
            this.Controls.SetChildIndex(this.lblToDate, 0);
            this.Controls.SetChildIndex(this.dtpToDate, 0);
            this.Controls.SetChildIndex(this.lblPeriod, 0);
            this.Controls.SetChildIndex(this.cmbPeriod, 0);
            this.Controls.SetChildIndex(this.txtFilename, 0);
            this.Controls.SetChildIndex(this.btnBrowse, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.chkOnlyOld, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtRemark, 0);
            this.Controls.SetChildIndex(this.optArchive2, 0);
            this.Controls.SetChildIndex(this.optArchive6, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton optArchive1;
        private System.Windows.Forms.RadioButton optArchive3;
        private System.Windows.Forms.RadioButton optArchive4;
        private System.Windows.Forms.RadioButton optArchive5;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.ComboBox cmbPeriod;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkOnlyOld;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RadioButton optArchive2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblToDate2;
        private System.Windows.Forms.RadioButton optArchive6;
    }
}
