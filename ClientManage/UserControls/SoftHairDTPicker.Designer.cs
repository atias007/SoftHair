namespace ClientManage.UserControls
{
    partial class SoftHairDtPicker
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
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblClear = new System.Windows.Forms.Label();
            this.lblNoDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpDate
            // 
            this.dtpDate.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.dtpDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(199)))), ((int)(((byte)(255)))));
            this.dtpDate.CustomFormat = "yyyy/MM/dd";
            this.dtpDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(21, 0);
            this.dtpDate.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.RightToLeftLayout = true;
            this.dtpDate.Size = new System.Drawing.Size(179, 22);
            this.dtpDate.TabIndex = 2;
            this.dtpDate.CloseUp += new System.EventHandler(this.DtpDateCloseUp);
            this.dtpDate.ValueChanged += new System.EventHandler(this.DtpDateValueChanged);
            this.dtpDate.Validating += new System.ComponentModel.CancelEventHandler(this.DtpDateValidating);
            // 
            // lblClear
            // 
            this.lblClear.BackColor = System.Drawing.Color.White;
            this.lblClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClear.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblClear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblClear.Image = global::ClientManage.Properties.Resources.cancel_small;
            this.lblClear.Location = new System.Drawing.Point(0, 0);
            this.lblClear.Name = "lblClear";
            this.lblClear.Size = new System.Drawing.Size(22, 22);
            this.lblClear.TabIndex = 4;
            this.lblClear.Click += new System.EventHandler(this.LblClearClick);
            this.lblClear.Paint += new System.Windows.Forms.PaintEventHandler(this.LblClearPaint);
            this.lblClear.MouseEnter += new System.EventHandler(this.LblClearMouseEnter);
            this.lblClear.MouseLeave += new System.EventHandler(this.LblClearMouseLeave);
            // 
            // lblNoDate
            // 
            this.lblNoDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblNoDate.ForeColor = System.Drawing.Color.Black;
            this.lblNoDate.Location = new System.Drawing.Point(45, 3);
            this.lblNoDate.Name = "lblNoDate";
            this.lblNoDate.Size = new System.Drawing.Size(152, 16);
            this.lblNoDate.TabIndex = 5;
            this.lblNoDate.Text = "ללא תאריך";
            this.lblNoDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNoDate.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LblNoDateMouseDoubleClick);
            // 
            // SoftHairDTPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblNoDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblClear);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Name = "SoftHairDtPicker";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(200, 22);
            this.EnabledChanged += new System.EventHandler(this.SoftHairDtPickerEnabledChanged);
            this.SizeChanged += new System.EventHandler(this.SoftHairDtPickerSizeChanged);
            this.PaddingChanged += new System.EventHandler(this.SoftHairDtPickerPaddingChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblClear;
        private System.Windows.Forms.Label lblNoDate;
    }
}
