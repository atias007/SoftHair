namespace ClientManage.Forms
{
    partial class FormSubscriptionDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSubscriptionDetails));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.informationBar1 = new ClientManage.UserControls.InformationBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbbAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.lblMustFields1 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblWarn = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblStatusIcon = new System.Windows.Forms.Label();
            this.txtDateFroze = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtLastUpdate = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.NumericUpDown();
            this.chkAmount = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkToDate = new System.Windows.Forms.CheckBox();
            this.dtpToDate = new ClientManage.UserControls.SoftHairDtPicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpFromDate = new ClientManage.UserControls.SoftHairDtPicker();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCares = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCares = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsageCount = new System.Windows.Forms.Label();
            this.grdUsage = new System.Windows.Forms.DataGridView();
            this.c_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsage)).BeginInit();
            this.SuspendLayout();
            // 
            // informationBar1
            // 
            this.informationBar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("informationBar1.BackgroundImage")));
            this.informationBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.informationBar1.Image = global::ClientManage.Properties.Resources.ticke_smallt;
            this.informationBar1.LabelForeColor = System.Drawing.Color.DarkGreen;
            this.informationBar1.LabelImage = null;
            this.informationBar1.LabelText = "";
            this.informationBar1.LabelVisible = false;
            this.informationBar1.Location = new System.Drawing.Point(8, 53);
            this.informationBar1.Name = "informationBar1";
            this.informationBar1.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.informationBar1.PanelText = "פרטי מנוי";
            this.informationBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.informationBar1.Size = new System.Drawing.Size(716, 28);
            this.informationBar1.TabIndex = 73;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImage = global::ClientManage.Properties.Resources.toolbar_bg_small;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbAdd,
            this.toolStripButton1});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(8, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(716, 25);
            this.toolStrip1.TabIndex = 72;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbbAdd
            // 
            this.tbbAdd.AutoToolTip = false;
            this.tbbAdd.Image = global::ClientManage.Properties.Resources.save_small;
            this.tbbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbAdd.Name = "tbbAdd";
            this.tbbAdd.Size = new System.Drawing.Size(54, 22);
            this.tbbAdd.Text = "שמור";
            this.tbbAdd.ToolTipText = "שמירת השינויים בטופס";
            this.tbbAdd.Click += new System.EventHandler(this.tbbAdd_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoToolTip = false;
            this.toolStripButton1.Image = global::ClientManage.Properties.Resources.cancel_small;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(50, 22);
            this.toolStripButton1.Text = "בטל";
            this.toolStripButton1.ToolTipText = "ביטול כל השינויים בטופס";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.lblMustFields1);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.lblWarn);
            this.panel1.Controls.Add(this.txtRemark);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.lblStatusIcon);
            this.panel1.Controls.Add(this.txtDateFroze);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtLastUpdate);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtStatus);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtAmount);
            this.panel1.Controls.Add(this.chkAmount);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.chkToDate);
            this.panel1.Controls.Add(this.dtpToDate);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.dtpFromDate);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnCares);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.txtCares);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblUsageCount);
            this.panel1.Controls.Add(this.grdUsage);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(8, 81);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(716, 468);
            this.panel1.TabIndex = 74;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(71, 128);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(13, 16);
            this.label19.TabIndex = 104;
            this.label19.Text = "*";
            // 
            // lblMustFields1
            // 
            this.lblMustFields1.BackColor = System.Drawing.Color.Transparent;
            this.lblMustFields1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblMustFields1.ForeColor = System.Drawing.Color.DimGray;
            this.lblMustFields1.Location = new System.Drawing.Point(8, 127);
            this.lblMustFields1.Name = "lblMustFields1";
            this.lblMustFields1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMustFields1.Size = new System.Drawing.Size(67, 20);
            this.lblMustFields1.TabIndex = 103;
            this.lblMustFields1.Text = "(שדות חובה)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(702, 30);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(13, 16);
            this.label17.TabIndex = 101;
            this.label17.Text = "*";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(687, 168);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 100;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // lblWarn
            // 
            this.lblWarn.BackColor = System.Drawing.Color.White;
            this.lblWarn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWarn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarn.ForeColor = System.Drawing.Color.Sienna;
            this.lblWarn.Image = global::ClientManage.Properties.Resources.warn;
            this.lblWarn.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblWarn.Location = new System.Drawing.Point(374, 139);
            this.lblWarn.Name = "lblWarn";
            this.lblWarn.Size = new System.Drawing.Size(221, 21);
            this.lblWarn.TabIndex = 99;
            this.lblWarn.Text = "       לעדכון תוקף המנוי יש לבטל הקפאה";
            this.lblWarn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblWarn.Visible = false;
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtRemark.Location = new System.Drawing.Point(8, 79);
            this.txtRemark.MaxLength = 255;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemark.Size = new System.Drawing.Size(587, 47);
            this.txtRemark.TabIndex = 3;
            this.txtRemark.Leave += new System.EventHandler(this.txt_Leave);
            this.txtRemark.Enter += new System.EventHandler(this.txt_Enter);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label14.Location = new System.Drawing.Point(601, 82);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 20);
            this.label14.TabIndex = 98;
            this.label14.Text = "הערות:";
            // 
            // lblStatusIcon
            // 
            this.lblStatusIcon.Image = global::ClientManage.Properties.Resources.status1;
            this.lblStatusIcon.Location = new System.Drawing.Point(11, 166);
            this.lblStatusIcon.Name = "lblStatusIcon";
            this.lblStatusIcon.Size = new System.Drawing.Size(16, 16);
            this.lblStatusIcon.TabIndex = 97;
            // 
            // txtDateFroze
            // 
            this.txtDateFroze.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.txtDateFroze.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtDateFroze.Location = new System.Drawing.Point(8, 215);
            this.txtDateFroze.MaxLength = 50;
            this.txtDateFroze.Name = "txtDateFroze";
            this.txtDateFroze.ReadOnly = true;
            this.txtDateFroze.Size = new System.Drawing.Size(223, 23);
            this.txtDateFroze.TabIndex = 9;
            this.txtDateFroze.Text = "< ללא תאריך >";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label13.Location = new System.Drawing.Point(237, 220);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 20);
            this.label13.TabIndex = 95;
            this.label13.Text = "קפוא מתאריך:";
            // 
            // txtLastUpdate
            // 
            this.txtLastUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.txtLastUpdate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtLastUpdate.Location = new System.Drawing.Point(8, 189);
            this.txtLastUpdate.MaxLength = 50;
            this.txtLastUpdate.Name = "txtLastUpdate";
            this.txtLastUpdate.ReadOnly = true;
            this.txtLastUpdate.Size = new System.Drawing.Size(223, 23);
            this.txtLastUpdate.TabIndex = 8;
            this.txtLastUpdate.Text = "< ללא תאריך >";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label12.Location = new System.Drawing.Point(237, 194);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 20);
            this.label12.TabIndex = 93;
            this.label12.Text = "עודכן לאחרונה:";
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.txtStatus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtStatus.Location = new System.Drawing.Point(8, 163);
            this.txtStatus.MaxLength = 50;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(223, 23);
            this.txtStatus.TabIndex = 7;
            this.txtStatus.Text = "פעיל";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label11.Location = new System.Drawing.Point(237, 168);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 20);
            this.label11.TabIndex = 91;
            this.label11.Text = "סטאטוס המנוי:";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(74)))), ((int)(((byte)(147)))));
            this.label9.Location = new System.Drawing.Point(254, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 17);
            this.label9.TabIndex = 89;
            this.label9.Text = "פרטים נוספים";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.LightSlateGray;
            this.label10.Location = new System.Drawing.Point(8, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(340, 1);
            this.label10.TabIndex = 90;
            // 
            // txtAmount
            // 
            this.txtAmount.Enabled = false;
            this.txtAmount.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(544, 214);
            this.txtAmount.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(51, 22);
            this.txtAmount.TabIndex = 6;
            // 
            // chkAmount
            // 
            this.chkAmount.AutoSize = true;
            this.chkAmount.Location = new System.Drawing.Point(687, 219);
            this.chkAmount.Name = "chkAmount";
            this.chkAmount.Size = new System.Drawing.Size(15, 14);
            this.chkAmount.TabIndex = 87;
            this.chkAmount.UseVisualStyleBackColor = true;
            this.chkAmount.CheckedChanged += new System.EventHandler(this.chkAmount_CheckedChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label8.Location = new System.Drawing.Point(599, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 20);
            this.label8.TabIndex = 86;
            this.label8.Text = "ביקורים:";
            // 
            // chkToDate
            // 
            this.chkToDate.AutoSize = true;
            this.chkToDate.Location = new System.Drawing.Point(687, 194);
            this.chkToDate.Name = "chkToDate";
            this.chkToDate.Size = new System.Drawing.Size(15, 14);
            this.chkToDate.TabIndex = 85;
            this.chkToDate.UseVisualStyleBackColor = true;
            this.chkToDate.CheckedChanged += new System.EventHandler(this.chkToDate_CheckedChanged);
            // 
            // dtpToDate
            // 
            this.dtpToDate.BackColor = System.Drawing.Color.White;
            this.dtpToDate.ClearButtonEnable = true;
            this.dtpToDate.ClearButtonVisible = true;
            this.dtpToDate.DefaultValue = new System.DateTime(2009, 2, 24, 0, 0, 0, 0);
            this.dtpToDate.Enabled = false;
            this.dtpToDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.dtpToDate.Location = new System.Drawing.Point(433, 189);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.NullText = "ללא תאריך";
            this.dtpToDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpToDate.Size = new System.Drawing.Size(162, 22);
            this.dtpToDate.TabIndex = 5;
            this.dtpToDate.Value = new System.DateTime(2009, 2, 24, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label7.Location = new System.Drawing.Point(599, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 20);
            this.label7.TabIndex = 84;
            this.label7.Text = "עד תאריך:";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(243)))));
            this.dtpFromDate.ClearButtonEnable = true;
            this.dtpFromDate.ClearButtonVisible = false;
            this.dtpFromDate.DefaultValue = new System.DateTime(2009, 2, 24, 0, 0, 0, 0);
            this.dtpFromDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.dtpFromDate.Location = new System.Drawing.Point(433, 164);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.NullText = "ללא תאריך";
            this.dtpFromDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpFromDate.Size = new System.Drawing.Size(162, 22);
            this.dtpFromDate.TabIndex = 4;
            this.dtpFromDate.Value = new System.DateTime(2009, 2, 24, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(599, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 20);
            this.label6.TabIndex = 82;
            this.label6.Text = "החל מתאריך:";
            // 
            // btnCares
            // 
            this.btnCares.Image = global::ClientManage.Properties.Resources.point;
            this.btnCares.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCares.Location = new System.Drawing.Point(8, 52);
            this.btnCares.Name = "btnCares";
            this.btnCares.Size = new System.Drawing.Size(112, 25);
            this.btnCares.TabIndex = 2;
            this.btnCares.Text = "       בחר טיפול...";
            this.btnCares.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCares.UseVisualStyleBackColor = true;
            this.btnCares.Click += new System.EventHandler(this.btnCares_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(74)))), ((int)(((byte)(147)))));
            this.label4.Location = new System.Drawing.Point(661, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 17);
            this.label4.TabIndex = 78;
            this.label4.Text = "כללי";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.LightSlateGray;
            this.label5.Location = new System.Drawing.Point(8, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(700, 1);
            this.label5.TabIndex = 79;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(74)))), ((int)(((byte)(147)))));
            this.label15.Location = new System.Drawing.Point(627, 143);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 17);
            this.label15.TabIndex = 76;
            this.label15.Text = "תוקף המנוי";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.LightSlateGray;
            this.label16.Location = new System.Drawing.Point(368, 151);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(340, 1);
            this.label16.TabIndex = 77;
            // 
            // txtCares
            // 
            this.txtCares.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.txtCares.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtCares.Location = new System.Drawing.Point(120, 53);
            this.txtCares.MaxLength = 50;
            this.txtCares.Name = "txtCares";
            this.txtCares.ReadOnly = true;
            this.txtCares.Size = new System.Drawing.Size(475, 23);
            this.txtCares.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(601, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 74;
            this.label3.Text = "טיפולים ומוצרים:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtName.Location = new System.Drawing.Point(8, 27);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(587, 23);
            this.txtName.TabIndex = 0;
            this.txtName.Leave += new System.EventHandler(this.txt_Leave);
            this.txtName.Enter += new System.EventHandler(this.txt_Enter);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(601, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 72;
            this.label1.Text = "תיאור המנוי:";
            // 
            // lblUsageCount
            // 
            this.lblUsageCount.BackColor = System.Drawing.Color.Transparent;
            this.lblUsageCount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblUsageCount.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblUsageCount.ForeColor = System.Drawing.Color.Black;
            this.lblUsageCount.Location = new System.Drawing.Point(4, 256);
            this.lblUsageCount.Name = "lblUsageCount";
            this.lblUsageCount.Size = new System.Drawing.Size(708, 18);
            this.lblUsageCount.TabIndex = 71;
            this.lblUsageCount.Text = "רשימת ביקורים למנוי  ({0} ביקורים)";
            this.lblUsageCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grdUsage
            // 
            this.grdUsage.AllowUserToAddRows = false;
            this.grdUsage.AllowUserToDeleteRows = false;
            this.grdUsage.AllowUserToResizeRows = false;
            this.grdUsage.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.grdUsage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdUsage.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdUsage.ColumnHeadersHeight = 24;
            this.grdUsage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdUsage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_id,
            this.c_date,
            this.c_time,
            this.c_remark,
            this.c_delete});
            this.grdUsage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdUsage.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(182)))), ((int)(((byte)(206)))));
            this.grdUsage.Location = new System.Drawing.Point(4, 274);
            this.grdUsage.Margin = new System.Windows.Forms.Padding(0);
            this.grdUsage.MultiSelect = false;
            this.grdUsage.Name = "grdUsage";
            this.grdUsage.RowHeadersVisible = false;
            this.grdUsage.RowTemplate.Height = 24;
            this.grdUsage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdUsage.Size = new System.Drawing.Size(708, 190);
            this.grdUsage.TabIndex = 10;
            this.grdUsage.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdUsage_CellFormatting);
            this.grdUsage.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdUsage_DataBindingComplete);
            this.grdUsage.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdUsage_CellContentClick);
            // 
            // c_id
            // 
            this.c_id.DataPropertyName = "id";
            this.c_id.HeaderText = "id";
            this.c_id.Name = "c_id";
            this.c_id.Visible = false;
            // 
            // c_date
            // 
            this.c_date.DataPropertyName = "date_usage";
            dataGridViewCellStyle1.Format = "d";
            this.c_date.DefaultCellStyle = dataGridViewCellStyle1;
            this.c_date.HeaderText = "תאריך";
            this.c_date.Name = "c_date";
            this.c_date.ReadOnly = true;
            this.c_date.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.c_date.Width = 120;
            // 
            // c_time
            // 
            this.c_time.DataPropertyName = "date_usage";
            dataGridViewCellStyle2.Format = "dddd בשעה HH:mm";
            dataGridViewCellStyle2.NullValue = null;
            this.c_time.DefaultCellStyle = dataGridViewCellStyle2;
            this.c_time.HeaderText = "יום ושעה";
            this.c_time.Name = "c_time";
            this.c_time.ReadOnly = true;
            this.c_time.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c_time.Width = 150;
            // 
            // c_remark
            // 
            this.c_remark.DataPropertyName = "remark";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(210)))));
            this.c_remark.DefaultCellStyle = dataGridViewCellStyle3;
            this.c_remark.HeaderText = "הערות";
            this.c_remark.MaxInputLength = 255;
            this.c_remark.Name = "c_remark";
            this.c_remark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c_remark.Width = 378;
            // 
            // c_delete
            // 
            this.c_delete.HeaderText = "";
            this.c_delete.Image = global::ClientManage.Properties.Resources.cancel_small;
            this.c_delete.Name = "c_delete";
            this.c_delete.ReadOnly = true;
            this.c_delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.c_delete.Width = 24;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(708, 12);
            this.label2.TabIndex = 70;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(701, 166);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(13, 16);
            this.label18.TabIndex = 102;
            this.label18.Text = "*";
            // 
            // FormSubscriptionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(732, 561);
            this.CloseFormByEsc = true;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.informationBar1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSubscriptionDetails";
            this.Padding = new System.Windows.Forms.Padding(8, 28, 8, 12);
            this.ShowInTaskbar = false;
            this.ShowMaximizeControl = false;
            this.ShowMinimizeControl = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "פרטי מנוי";
            this.RequestForClose += new System.EventHandler(this.frmSubscriptionDetails_RequestForClose);
            this.Activated += new System.EventHandler(this.frmSubscriptionDetails_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSubscriptionDetails_FormClosing);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.Controls.SetChildIndex(this.informationBar1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ClientManage.UserControls.InformationBar informationBar1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbbAdd;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUsageCount;
        private System.Windows.Forms.DataGridView grdUsage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCares;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private ClientManage.UserControls.SoftHairDtPicker dtpFromDate;
        private System.Windows.Forms.Button btnCares;
        private System.Windows.Forms.CheckBox chkToDate;
        private ClientManage.UserControls.SoftHairDtPicker dtpToDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown txtAmount;
        private System.Windows.Forms.CheckBox chkAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDateFroze;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtLastUpdate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblStatusIcon;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblWarn;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblMustFields1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_remark;
        private System.Windows.Forms.DataGridViewImageColumn c_delete;
    }
}
