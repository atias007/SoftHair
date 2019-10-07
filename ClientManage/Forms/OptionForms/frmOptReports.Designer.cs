namespace ClientManage.Forms.OptionForms
{
    partial class FormOptReports
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
            this.button5 = new System.Windows.Forms.Button();
            this.btnDownGroup = new System.Windows.Forms.Button();
            this.btnUpGroup = new System.Windows.Forms.Button();
            this.lstGroup = new System.Windows.Forms.ListView();
            this.clmGroup2 = new System.Windows.Forms.ColumnHeader();
            this.lstExistReports = new System.Windows.Forms.ListView();
            this.clmId = new System.Windows.Forms.ColumnHeader();
            this.clmGroup = new System.Windows.Forms.ColumnHeader();
            this.clmName = new System.Windows.Forms.ColumnHeader();
            this.nudReportAdminTimeout = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudReportAdminTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button5.Location = new System.Drawing.Point(584, 81);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(79, 21);
            this.button5.TabIndex = 14;
            this.button5.Text = "מחק דוח";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // btnDownGroup
            // 
            this.btnDownGroup.Image = global::ClientManage.Properties.Resources.arr_down;
            this.btnDownGroup.Location = new System.Drawing.Point(278, 392);
            this.btnDownGroup.Name = "btnDownGroup";
            this.btnDownGroup.Size = new System.Drawing.Size(25, 23);
            this.btnDownGroup.TabIndex = 15;
            this.btnDownGroup.UseVisualStyleBackColor = true;
            this.btnDownGroup.Click += new System.EventHandler(this.btnDownGroup_Click);
            // 
            // btnUpGroup
            // 
            this.btnUpGroup.Image = global::ClientManage.Properties.Resources.arr_up;
            this.btnUpGroup.Location = new System.Drawing.Point(278, 367);
            this.btnUpGroup.Name = "btnUpGroup";
            this.btnUpGroup.Size = new System.Drawing.Size(25, 23);
            this.btnUpGroup.TabIndex = 13;
            this.btnUpGroup.UseVisualStyleBackColor = true;
            this.btnUpGroup.Click += new System.EventHandler(this.btnUpGroup_Click);
            // 
            // lstGroup
            // 
            this.lstGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmGroup2});
            this.lstGroup.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lstGroup.FullRowSelect = true;
            this.lstGroup.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstGroup.HideSelection = false;
            this.lstGroup.Location = new System.Drawing.Point(15, 367);
            this.lstGroup.MultiSelect = false;
            this.lstGroup.Name = "lstGroup";
            this.lstGroup.RightToLeftLayout = true;
            this.lstGroup.ShowGroups = false;
            this.lstGroup.Size = new System.Drawing.Size(261, 245);
            this.lstGroup.TabIndex = 12;
            this.lstGroup.UseCompatibleStateImageBehavior = false;
            this.lstGroup.View = System.Windows.Forms.View.Details;
            this.lstGroup.SelectedIndexChanged += new System.EventHandler(this.lstGroup_SelectedIndexChanged);
            // 
            // clmGroup2
            // 
            this.clmGroup2.Text = "שם הקבוצה";
            this.clmGroup2.Width = 220;
            // 
            // lstExistReports
            // 
            this.lstExistReports.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmId,
            this.clmGroup,
            this.clmName});
            this.lstExistReports.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lstExistReports.FullRowSelect = true;
            this.lstExistReports.HideSelection = false;
            this.lstExistReports.Location = new System.Drawing.Point(15, 102);
            this.lstExistReports.MultiSelect = false;
            this.lstExistReports.Name = "lstExistReports";
            this.lstExistReports.RightToLeftLayout = true;
            this.lstExistReports.ShowGroups = false;
            this.lstExistReports.Size = new System.Drawing.Size(648, 245);
            this.lstExistReports.TabIndex = 11;
            this.lstExistReports.UseCompatibleStateImageBehavior = false;
            this.lstExistReports.View = System.Windows.Forms.View.Details;
            // 
            // clmId
            // 
            this.clmId.Text = "מספר דוח";
            this.clmId.Width = 100;
            // 
            // clmGroup
            // 
            this.clmGroup.Text = "קבוצה";
            this.clmGroup.Width = 200;
            // 
            // clmName
            // 
            this.clmName.Text = "שם הדוח";
            this.clmName.Width = 300;
            // 
            // nudReportAdminTimeout
            // 
            this.nudReportAdminTimeout.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.nudReportAdminTimeout.Location = new System.Drawing.Point(248, 58);
            this.nudReportAdminTimeout.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudReportAdminTimeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudReportAdminTimeout.Name = "nudReportAdminTimeout";
            this.nudReportAdminTimeout.Size = new System.Drawing.Size(45, 23);
            this.nudReportAdminTimeout.TabIndex = 8;
            this.nudReportAdminTimeout.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(299, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(240, 19);
            this.label10.TabIndex = 10;
            this.label10.Text = "דקות של חוסר פעילות במסך הדוחות";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(12, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(240, 19);
            this.label9.TabIndex = 9;
            this.label9.Text = "נתק הרשאות מנהל ואפס דוח נוכחי לאחר";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(12, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(240, 19);
            this.label6.TabIndex = 16;
            this.label6.Text = "רשימת דוחות קיימים במערכת:";
            // 
            // label65
            // 
            this.label65.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label65.Location = new System.Drawing.Point(12, 351);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(240, 19);
            this.label65.TabIndex = 17;
            this.label65.Text = "רשימת קבוצות וסדר הופעתן:";
            // 
            // frmOptReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 620);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnDownGroup);
            this.Controls.Add(this.btnUpGroup);
            this.Controls.Add(this.lstGroup);
            this.Controls.Add(this.lstExistReports);
            this.Controls.Add(this.nudReportAdminTimeout);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label65);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmOptReports";
            this.Text = "frmOptReports";
            this.Controls.SetChildIndex(this.label65, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.nudReportAdminTimeout, 0);
            this.Controls.SetChildIndex(this.lstExistReports, 0);
            this.Controls.SetChildIndex(this.lstGroup, 0);
            this.Controls.SetChildIndex(this.btnUpGroup, 0);
            this.Controls.SetChildIndex(this.btnDownGroup, 0);
            this.Controls.SetChildIndex(this.button5, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nudReportAdminTimeout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnDownGroup;
        private System.Windows.Forms.Button btnUpGroup;
        private System.Windows.Forms.ListView lstGroup;
        private System.Windows.Forms.ColumnHeader clmGroup2;
        private System.Windows.Forms.ListView lstExistReports;
        private System.Windows.Forms.ColumnHeader clmId;
        private System.Windows.Forms.ColumnHeader clmGroup;
        private System.Windows.Forms.ColumnHeader clmName;
        private System.Windows.Forms.NumericUpDown nudReportAdminTimeout;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label65;
    }
}