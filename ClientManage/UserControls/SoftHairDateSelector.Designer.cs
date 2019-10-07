namespace ClientManage.UserControls
{
    partial class SoftHairDateSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoftHairDateSelector));
            this.lblClear = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.cmbDay = new System.Windows.Forms.ComboBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.lblClear.Size = new System.Drawing.Size(22, 24);
            this.lblClear.TabIndex = 3;
            this.lblClear.MouseLeave += new System.EventHandler(this.lblClear_MouseLeave);
            this.lblClear.Click += new System.EventHandler(this.lblClear_Click);
            this.lblClear.MouseEnter += new System.EventHandler(this.lblClear_MouseEnter);
            this.lblClear.Paint += new System.Windows.Forms.PaintEventHandler(this.lblClear_Paint);
            // 
            // cmbYear
            // 
            this.cmbYear.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(112, 0);
            this.cmbYear.MaxLength = 4;
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(60, 24);
            this.cmbYear.TabIndex = 2;
            this.cmbYear.Leave += new System.EventHandler(this.cmbYear_Leave);
            this.cmbYear.Enter += new System.EventHandler(this.cmbYear_Enter);
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            this.cmbYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbYear_KeyPress);
            // 
            // cmbMonth
            // 
            this.cmbMonth.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Items.AddRange(new object[] {
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
            "12"});
            this.cmbMonth.Location = new System.Drawing.Point(67, 0);
            this.cmbMonth.MaxLength = 2;
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(45, 24);
            this.cmbMonth.TabIndex = 1;
            this.cmbMonth.Enter += new System.EventHandler(this.cmbMonth_Enter);
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged);
            // 
            // cmbDay
            // 
            this.cmbDay.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmbDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDay.FormattingEnabled = true;
            this.cmbDay.Items.AddRange(new object[] {
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
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cmbDay.Location = new System.Drawing.Point(22, 0);
            this.cmbDay.MaxLength = 2;
            this.cmbDay.Name = "cmbDay";
            this.cmbDay.Size = new System.Drawing.Size(45, 24);
            this.cmbDay.TabIndex = 0;
            this.cmbDay.Enter += new System.EventHandler(this.cmbDay_Enter);
            this.cmbDay.SelectedIndexChanged += new System.EventHandler(this.cmbDay_SelectedIndexChanged);
            // 
            // lblMonth
            // 
            this.lblMonth.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(127)))), ((int)(((byte)(155)))));
            this.lblMonth.Image = ((System.Drawing.Image)(resources.GetObject("lblMonth.Image")));
            this.lblMonth.Location = new System.Drawing.Point(85, 2);
            this.lblMonth.Margin = new System.Windows.Forms.Padding(0);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(25, 20);
            this.lblMonth.TabIndex = 4;
            this.lblMonth.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblMonth_MouseDown);
            // 
            // lblYear
            // 
            this.lblYear.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblYear.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(127)))), ((int)(((byte)(155)))));
            this.lblYear.Image = ((System.Drawing.Image)(resources.GetObject("lblYear.Image")));
            this.lblYear.Location = new System.Drawing.Point(149, 15);
            this.lblYear.Margin = new System.Windows.Forms.Padding(0);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(21, 6);
            this.lblYear.TabIndex = 5;
            this.lblYear.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblYear_MouseDown);
            // 
            // lblDay
            // 
            this.lblDay.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblDay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(127)))), ((int)(((byte)(155)))));
            this.lblDay.Image = ((System.Drawing.Image)(resources.GetObject("lblDay.Image")));
            this.lblDay.Location = new System.Drawing.Point(40, 2);
            this.lblDay.Margin = new System.Windows.Forms.Padding(0);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(25, 20);
            this.lblDay.TabIndex = 6;
            this.lblDay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblDay_MouseDown);
            // 
            // SoftHairDateSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblDay);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.cmbDay);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.lblClear);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "SoftHairDateSelector";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(172, 24);
            this.Enter += new System.EventHandler(this.SoftHairDateSelector_Enter);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblClear;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.ComboBox cmbDay;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblDay;
    }
}
