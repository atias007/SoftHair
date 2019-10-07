namespace ClientManage.Forms.OptionForms
{
    partial class FormOptWorkers
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
            this.grdMagneticCards = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPlaySoundWork = new System.Windows.Forms.Button();
            this.cmbWorkSound = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.cmbWorkLeaveHour = new System.Windows.Forms.ComboBox();
            this.cmbWorkLeaveMin = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.cmbWorkEnterHour = new System.Windows.Forms.ComboBox();
            this.cmbWorkEnterMin = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdMagneticCards)).BeginInit();
            this.SuspendLayout();
            // 
            // grdMagneticCards
            // 
            this.grdMagneticCards.AllowUserToResizeRows = false;
            this.grdMagneticCards.BackgroundColor = System.Drawing.Color.White;
            this.grdMagneticCards.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdMagneticCards.ColumnHeadersHeight = 24;
            this.grdMagneticCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdMagneticCards.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn1,
            this.dataGridViewTextBoxColumn5});
            this.grdMagneticCards.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.grdMagneticCards.Location = new System.Drawing.Point(15, 78);
            this.grdMagneticCards.MultiSelect = false;
            this.grdMagneticCards.Name = "grdMagneticCards";
            this.grdMagneticCards.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdMagneticCards.RowHeadersVisible = false;
            this.grdMagneticCards.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdMagneticCards.RowTemplate.Height = 24;
            this.grdMagneticCards.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdMagneticCards.ShowEditingIcon = false;
            this.grdMagneticCards.Size = new System.Drawing.Size(283, 182);
            this.grdMagneticCards.TabIndex = 40;
            this.grdMagneticCards.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grdMagneticCards_CellValidating);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "id";
            this.dataGridViewImageColumn1.HeaderText = "מספר כרטיס";
            this.dataGridViewImageColumn1.MinimumWidth = 64;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewImageColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "card_id";
            this.dataGridViewTextBoxColumn5.HeaderText = "מזהה כרטיס";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 250;
            // 
            // btnPlaySoundWork
            // 
            this.btnPlaySoundWork.Image = global::ClientManage.Properties.Resources.play2;
            this.btnPlaySoundWork.Location = new System.Drawing.Point(343, 320);
            this.btnPlaySoundWork.Name = "btnPlaySoundWork";
            this.btnPlaySoundWork.Size = new System.Drawing.Size(23, 24);
            this.btnPlaySoundWork.TabIndex = 39;
            this.btnPlaySoundWork.UseVisualStyleBackColor = true;
            this.btnPlaySoundWork.Click += new System.EventHandler(this.btnPlaySoundWork_Click);
            // 
            // cmbWorkSound
            // 
            this.cmbWorkSound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkSound.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbWorkSound.FormattingEnabled = true;
            this.cmbWorkSound.Location = new System.Drawing.Point(197, 321);
            this.cmbWorkSound.Name = "cmbWorkSound";
            this.cmbWorkSound.Size = new System.Drawing.Size(146, 22);
            this.cmbWorkSound.TabIndex = 38;
            this.cmbWorkSound.SelectedIndexChanged += new System.EventHandler(this.cmbWorkSound_SelectedIndexChanged);
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(12, 325);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(155, 19);
            this.label26.TabIndex = 45;
            this.label26.Text = "צליל קליטת דיווח נוכחות";
            // 
            // cmbWorkLeaveHour
            // 
            this.cmbWorkLeaveHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkLeaveHour.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbWorkLeaveHour.FormattingEnabled = true;
            this.cmbWorkLeaveHour.Items.AddRange(new object[] {
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
            this.cmbWorkLeaveHour.Location = new System.Drawing.Point(247, 295);
            this.cmbWorkLeaveHour.Name = "cmbWorkLeaveHour";
            this.cmbWorkLeaveHour.Size = new System.Drawing.Size(42, 22);
            this.cmbWorkLeaveHour.TabIndex = 37;
            // 
            // cmbWorkLeaveMin
            // 
            this.cmbWorkLeaveMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkLeaveMin.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbWorkLeaveMin.FormattingEnabled = true;
            this.cmbWorkLeaveMin.Items.AddRange(new object[] {
            "00",
            "15",
            "30",
            "45"});
            this.cmbWorkLeaveMin.Location = new System.Drawing.Point(197, 295);
            this.cmbWorkLeaveMin.Name = "cmbWorkLeaveMin";
            this.cmbWorkLeaveMin.Size = new System.Drawing.Size(42, 22);
            this.cmbWorkLeaveMin.TabIndex = 36;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label24.Location = new System.Drawing.Point(237, 299);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(8, 19);
            this.label24.TabIndex = 44;
            this.label24.Text = ":";
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(12, 298);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(203, 19);
            this.label25.TabIndex = 43;
            this.label25.Text = "שעת מעבר שעון למצב \"יציאה\"";
            // 
            // cmbWorkEnterHour
            // 
            this.cmbWorkEnterHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkEnterHour.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbWorkEnterHour.FormattingEnabled = true;
            this.cmbWorkEnterHour.Items.AddRange(new object[] {
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
            this.cmbWorkEnterHour.Location = new System.Drawing.Point(247, 270);
            this.cmbWorkEnterHour.Name = "cmbWorkEnterHour";
            this.cmbWorkEnterHour.Size = new System.Drawing.Size(42, 22);
            this.cmbWorkEnterHour.TabIndex = 35;
            // 
            // cmbWorkEnterMin
            // 
            this.cmbWorkEnterMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkEnterMin.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbWorkEnterMin.FormattingEnabled = true;
            this.cmbWorkEnterMin.Items.AddRange(new object[] {
            "00",
            "15",
            "30",
            "45"});
            this.cmbWorkEnterMin.Location = new System.Drawing.Point(197, 270);
            this.cmbWorkEnterMin.Name = "cmbWorkEnterMin";
            this.cmbWorkEnterMin.Size = new System.Drawing.Size(42, 22);
            this.cmbWorkEnterMin.TabIndex = 34;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label22.Location = new System.Drawing.Point(237, 273);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(8, 19);
            this.label22.TabIndex = 42;
            this.label22.Text = ":";
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(12, 273);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(203, 19);
            this.label23.TabIndex = 41;
            this.label23.Text = "שעת מעבר שעון למצב \"כניסה\"";
            // 
            // label69
            // 
            this.label69.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label69.Location = new System.Drawing.Point(12, 62);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(203, 19);
            this.label69.TabIndex = 46;
            this.label69.Text = "כרטיסים מגנטיים:";
            // 
            // frmOptWorkers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 620);
            this.Controls.Add(this.grdMagneticCards);
            this.Controls.Add(this.btnPlaySoundWork);
            this.Controls.Add(this.cmbWorkSound);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.cmbWorkLeaveHour);
            this.Controls.Add(this.cmbWorkLeaveMin);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.cmbWorkEnterHour);
            this.Controls.Add(this.cmbWorkEnterMin);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label69);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmOptWorkers";
            this.Text = "frmOptWorkers";
            this.Controls.SetChildIndex(this.label69, 0);
            this.Controls.SetChildIndex(this.label23, 0);
            this.Controls.SetChildIndex(this.label22, 0);
            this.Controls.SetChildIndex(this.cmbWorkEnterMin, 0);
            this.Controls.SetChildIndex(this.cmbWorkEnterHour, 0);
            this.Controls.SetChildIndex(this.label25, 0);
            this.Controls.SetChildIndex(this.label24, 0);
            this.Controls.SetChildIndex(this.cmbWorkLeaveMin, 0);
            this.Controls.SetChildIndex(this.cmbWorkLeaveHour, 0);
            this.Controls.SetChildIndex(this.label26, 0);
            this.Controls.SetChildIndex(this.cmbWorkSound, 0);
            this.Controls.SetChildIndex(this.btnPlaySoundWork, 0);
            this.Controls.SetChildIndex(this.grdMagneticCards, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdMagneticCards)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdMagneticCards;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Button btnPlaySoundWork;
        private System.Windows.Forms.ComboBox cmbWorkSound;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox cmbWorkLeaveHour;
        private System.Windows.Forms.ComboBox cmbWorkLeaveMin;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox cmbWorkEnterHour;
        private System.Windows.Forms.ComboBox cmbWorkEnterMin;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label69;
    }
}