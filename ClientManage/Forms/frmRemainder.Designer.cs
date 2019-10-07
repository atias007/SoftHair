namespace ClientManage.Forms
{
    partial class FormRemainder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRemainder));
            this.lstItems = new System.Windows.Forms.ListView();
            this.lstColSubject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstColDueTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnShowItem = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.cmbSnooze = new System.Windows.Forms.ComboBox();
            this.btnSnooze = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblIcon = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstItems
            // 
            this.lstItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lstColSubject,
            this.lstColDueTo});
            this.lstItems.FullRowSelect = true;
            this.lstItems.HideSelection = false;
            this.lstItems.Location = new System.Drawing.Point(15, 102);
            this.lstItems.MultiSelect = false;
            this.lstItems.Name = "lstItems";
            this.lstItems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lstItems.RightToLeftLayout = true;
            this.lstItems.Size = new System.Drawing.Size(430, 136);
            this.lstItems.TabIndex = 0;
            this.lstItems.UseCompatibleStateImageBehavior = false;
            this.lstItems.View = System.Windows.Forms.View.Details;
            this.lstItems.SelectedIndexChanged += new System.EventHandler(this.lstItems_SelectedIndexChanged);
            this.lstItems.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstItems_MouseDoubleClick);
            // 
            // lstColSubject
            // 
            this.lstColSubject.Text = "תיאור";
            this.lstColSubject.Width = 300;
            // 
            // lstColDueTo
            // 
            this.lstColDueTo.Text = "יחל בעוד";
            this.lstColDueTo.Width = 120;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(356, 244);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(89, 23);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "הסר";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnShowItem
            // 
            this.btnShowItem.Location = new System.Drawing.Point(261, 244);
            this.btnShowItem.Name = "btnShowItem";
            this.btnShowItem.Size = new System.Drawing.Size(89, 23);
            this.btnShowItem.TabIndex = 2;
            this.btnShowItem.Text = "הצג פריט";
            this.btnShowItem.UseVisualStyleBackColor = true;
            this.btnShowItem.Click += new System.EventHandler(this.btnShowItem_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(15, 244);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(89, 23);
            this.btnRemoveAll.TabIndex = 3;
            this.btnRemoveAll.Text = "הסר הכל";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // cmbSnooze
            // 
            this.cmbSnooze.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSnooze.FormattingEnabled = true;
            this.cmbSnooze.Location = new System.Drawing.Point(110, 298);
            this.cmbSnooze.Name = "cmbSnooze";
            this.cmbSnooze.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbSnooze.Size = new System.Drawing.Size(335, 21);
            this.cmbSnooze.TabIndex = 4;
            // 
            // btnSnooze
            // 
            this.btnSnooze.Location = new System.Drawing.Point(15, 296);
            this.btnSnooze.Name = "btnSnooze";
            this.btnSnooze.Size = new System.Drawing.Size(89, 23);
            this.btnSnooze.TabIndex = 5;
            this.btnSnooze.Text = "השהה";
            this.btnSnooze.UseVisualStyleBackColor = true;
            this.btnSnooze.Click += new System.EventHandler(this.btnSnooze_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(110, 282);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(338, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "לחץ על דחה על מנת להציג את התזכורת  שוב בעוד:";
            // 
            // lblIcon
            // 
            this.lblIcon.Image = ((System.Drawing.Image)(resources.GetObject("lblIcon.Image")));
            this.lblIcon.Location = new System.Drawing.Point(381, 33);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblIcon.Size = new System.Drawing.Size(64, 64);
            this.lblIcon.TabIndex = 7;
            // 
            // lblSubject
            // 
            this.lblSubject.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblSubject.Location = new System.Drawing.Point(15, 55);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSubject.Size = new System.Drawing.Size(360, 13);
            this.lblSubject.TabIndex = 8;
            this.lblSubject.Text = "נושא התזכורת";
            // 
            // lblStartDate
            // 
            this.lblStartDate.Location = new System.Drawing.Point(15, 73);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblStartDate.Size = new System.Drawing.Size(360, 13);
            this.lblStartDate.TabIndex = 9;
            this.lblStartDate.Text = "זמן התחלה: {0}";
            // 
            // FormRemainder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(243)))));
            this.CaptionImage = ((System.Drawing.Image)(resources.GetObject("$this.CaptionImage")));
            this.ClientSize = new System.Drawing.Size(460, 337);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblIcon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSnooze);
            this.Controls.Add(this.cmbSnooze);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.btnShowItem);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lstItems);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormRemainder";
            this.ShowMaximizeControl = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmRemainder_Load);
            this.Controls.SetChildIndex(this.lstItems, 0);
            this.Controls.SetChildIndex(this.btnRemove, 0);
            this.Controls.SetChildIndex(this.btnShowItem, 0);
            this.Controls.SetChildIndex(this.btnRemoveAll, 0);
            this.Controls.SetChildIndex(this.cmbSnooze, 0);
            this.Controls.SetChildIndex(this.btnSnooze, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblIcon, 0);
            this.Controls.SetChildIndex(this.lblSubject, 0);
            this.Controls.SetChildIndex(this.lblStartDate, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstItems;
        private System.Windows.Forms.ColumnHeader lstColSubject;
        private System.Windows.Forms.ColumnHeader lstColDueTo;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnShowItem;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.ComboBox cmbSnooze;
        private System.Windows.Forms.Button btnSnooze;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIcon;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblStartDate;
    }
}