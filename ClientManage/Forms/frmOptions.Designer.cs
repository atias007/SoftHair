namespace ClientManage.Forms
{
    partial class FormOptions
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("����");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("������");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("�����", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("����", 1, 2);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("������ / �������", 1, 2);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("������", 0, 2, new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("������� �����", 1, 2);
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("�����", 0, 2, new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("����", 1, 2);
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("������ ���", 1, 2);
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("����� �������", 1, 2);
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("����", 0, 2, new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("�����", 0, 2);
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("������", 0, 2);
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("��������", 0, 2);
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("����� ������", 0, 2);
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("������ ����", 0, 2);
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("������ SMS", 0, 2);
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("���\"�", 0, 2);
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("������", 0, 2);
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("����", 0, 2);
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("�����", 0, 2);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOptions));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbbCall = new System.Windows.Forms.Button();
            this.tbbTeam = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tbbSave = new System.Windows.Forms.ToolStripButton();
            this.tbbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.tbbLogin = new System.Windows.Forms.ToolStripButton();
            this.tbbLogout = new System.Windows.Forms.ToolStripButton();
            this.txtPassword = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 42);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(1024, 654);
            this.splitContainer1.SplitterDistance = 218;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitContainer1_SplitterMoved);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(187)))), ((int)(((byte)(193)))));
            this.panel1.Controls.Add(this.tbbCall);
            this.panel1.Controls.Add(this.tbbTeam);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 534);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(218, 120);
            this.panel1.TabIndex = 3;
            // 
            // tbbCall
            // 
            this.tbbCall.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tbbCall.Image = global::ClientManage.Properties.Resources.tbbRemote_Image;
            this.tbbCall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbbCall.Location = new System.Drawing.Point(51, 8);
            this.tbbCall.Name = "tbbCall";
            this.tbbCall.Size = new System.Drawing.Size(157, 51);
            this.tbbCall.TabIndex = 55;
            this.tbbCall.Text = "   ����� �����";
            this.tbbCall.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tbbCall.UseVisualStyleBackColor = true;
            this.tbbCall.Click += new System.EventHandler(this.TbbCall_Click);
            // 
            // tbbTeam
            // 
            this.tbbTeam.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tbbTeam.Image = global::ClientManage.Properties.Resources.teamviewer;
            this.tbbTeam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbbTeam.Location = new System.Drawing.Point(51, 61);
            this.tbbTeam.Name = "tbbTeam";
            this.tbbTeam.Size = new System.Drawing.Size(157, 51);
            this.tbbTeam.TabIndex = 54;
            this.tbbTeam.Text = "   ����� �����";
            this.tbbTeam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tbbTeam.UseVisualStyleBackColor = true;
            this.tbbTeam.Click += new System.EventHandler(this.TbbTeam_Click);
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(243)))));
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.ItemHeight = 20;
            this.treeView1.Location = new System.Drawing.Point(0, 50);
            this.treeView1.Name = "treeView1";
            treeNode1.ImageIndex = 1;
            treeNode1.Name = "Node0_1";
            treeNode1.SelectedImageKey = "node_sel.gif";
            treeNode1.Text = "����";
            treeNode2.ImageIndex = 1;
            treeNode2.Name = "Node0_2";
            treeNode2.SelectedImageKey = "node_sel.gif";
            treeNode2.Text = "������";
            treeNode3.ImageKey = "parent.gif";
            treeNode3.Name = "Node0";
            treeNode3.SelectedImageKey = "node_sel.gif";
            treeNode3.Text = "�����";
            treeNode4.ImageIndex = 1;
            treeNode4.Name = "Node1_1";
            treeNode4.SelectedImageIndex = 2;
            treeNode4.Text = "����";
            treeNode5.ImageIndex = 1;
            treeNode5.Name = "Node1_2";
            treeNode5.SelectedImageIndex = 2;
            treeNode5.Text = "������ / �������";
            treeNode6.ImageIndex = 0;
            treeNode6.Name = "Node1";
            treeNode6.SelectedImageIndex = 2;
            treeNode6.Text = "������";
            treeNode7.ImageIndex = 1;
            treeNode7.Name = "Node2_1";
            treeNode7.SelectedImageIndex = 2;
            treeNode7.Text = "������� �����";
            treeNode8.ImageIndex = 0;
            treeNode8.Name = "Node2";
            treeNode8.SelectedImageIndex = 2;
            treeNode8.Text = "�����";
            treeNode9.ImageIndex = 1;
            treeNode9.Name = "Node3_1";
            treeNode9.SelectedImageIndex = 2;
            treeNode9.Text = "����";
            treeNode10.ImageIndex = 1;
            treeNode10.Name = "Node3_2";
            treeNode10.SelectedImageIndex = 2;
            treeNode10.Text = "������ ���";
            treeNode11.ImageIndex = 1;
            treeNode11.Name = "Node3_3";
            treeNode11.SelectedImageIndex = 2;
            treeNode11.Text = "����� �������";
            treeNode12.ImageIndex = 0;
            treeNode12.Name = "Node3";
            treeNode12.SelectedImageIndex = 2;
            treeNode12.Text = "����";
            treeNode13.ImageIndex = 0;
            treeNode13.Name = "Node4";
            treeNode13.SelectedImageIndex = 2;
            treeNode13.Text = "�����";
            treeNode14.ImageIndex = 0;
            treeNode14.Name = "Node5";
            treeNode14.SelectedImageIndex = 2;
            treeNode14.Text = "������";
            treeNode15.ImageIndex = 0;
            treeNode15.Name = "Node6";
            treeNode15.SelectedImageIndex = 2;
            treeNode15.Text = "��������";
            treeNode16.ImageIndex = 0;
            treeNode16.Name = "Node7";
            treeNode16.SelectedImageIndex = 2;
            treeNode16.Text = "����� ������";
            treeNode17.ImageIndex = 0;
            treeNode17.Name = "Node8";
            treeNode17.SelectedImageIndex = 2;
            treeNode17.Text = "������ ����";
            treeNode18.ImageIndex = 0;
            treeNode18.Name = "Node9";
            treeNode18.SelectedImageIndex = 2;
            treeNode18.Text = "������ SMS";
            treeNode19.ImageIndex = 0;
            treeNode19.Name = "Node10";
            treeNode19.SelectedImageIndex = 2;
            treeNode19.Text = "���\"�";
            treeNode20.ImageIndex = 0;
            treeNode20.Name = "Node11";
            treeNode20.SelectedImageIndex = 2;
            treeNode20.Text = "������";
            treeNode21.ImageIndex = 0;
            treeNode21.Name = "Node12";
            treeNode21.SelectedImageIndex = 2;
            treeNode21.Text = "����";
            treeNode22.ImageIndex = 0;
            treeNode22.Name = "Node13";
            treeNode22.SelectedImageIndex = 2;
            treeNode22.Text = "�����";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6,
            treeNode8,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22});
            this.treeView1.RightToLeftLayout = true;
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.Size = new System.Drawing.Size(218, 604);
            this.treeView1.TabIndex = 0;
            this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeView1_BeforeSelect);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "parent.gif");
            this.imageList1.Images.SetKeyName(1, "child.gif");
            this.imageList1.Images.SetKeyName(2, "node_sel.gif");
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 4);
            this.label2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.SlateGray;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(0, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "�������";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackgroundImage = global::ClientManage.Properties.Resources.toolbar_bg;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbSave,
            this.tbbDelete,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripTextBox1,
            this.tbbLogin,
            this.tbbLogout});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1024, 42);
            this.toolStrip.TabIndex = 59;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tbbSave
            // 
            this.tbbSave.AutoToolTip = false;
            this.tbbSave.Image = global::ClientManage.Properties.Resources.Floppy;
            this.tbbSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbSave.Name = "tbbSave";
            this.tbbSave.Size = new System.Drawing.Size(63, 39);
            this.tbbSave.Text = "����";
            this.tbbSave.ToolTipText = "����� �� �������� �������";
            this.tbbSave.Click += new System.EventHandler(this.TbbSave_Click);
            // 
            // tbbDelete
            // 
            this.tbbDelete.AutoToolTip = false;
            this.tbbDelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbDelete.ForeColor = System.Drawing.Color.Black;
            this.tbbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tbbDelete.Image")));
            this.tbbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbDelete.Name = "tbbDelete";
            this.tbbDelete.Size = new System.Drawing.Size(64, 39);
            this.tbbDelete.Text = "�����";
            this.tbbDelete.ToolTipText = "����� �� �������� �������";
            this.tbbDelete.Click += new System.EventHandler(this.TbbDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 42);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(107, 39);
            this.toolStripLabel1.Text = "����� ���� �����";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.AutoSize = false;
            this.toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripTextBox1.HideSelection = false;
            this.toolStripTextBox1.MaxLength = 50;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.ReadOnly = true;
            this.toolStripTextBox1.Size = new System.Drawing.Size(150, 26);
            // 
            // tbbLogin
            // 
            this.tbbLogin.AutoToolTip = false;
            this.tbbLogin.Image = ((System.Drawing.Image)(resources.GetObject("tbbLogin.Image")));
            this.tbbLogin.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbLogin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbLogin.Name = "tbbLogin";
            this.tbbLogin.Size = new System.Drawing.Size(77, 39);
            this.tbbLogin.Text = "�����";
            this.tbbLogin.Click += new System.EventHandler(this.TbbLogin_Click);
            // 
            // tbbLogout
            // 
            this.tbbLogout.AutoToolTip = false;
            this.tbbLogout.Enabled = false;
            this.tbbLogout.Image = ((System.Drawing.Image)(resources.GetObject("tbbLogout.Image")));
            this.tbbLogout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbLogout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbLogout.Name = "tbbLogout";
            this.tbbLogout.Size = new System.Drawing.Size(76, 39);
            this.tbbLogout.Text = "�����";
            this.tbbLogout.Click += new System.EventHandler(this.TbbLogout_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtPassword.ForeColor = System.Drawing.Color.DimGray;
            this.txtPassword.Location = new System.Drawing.Point(624, 7);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(126, 29);
            this.txtPassword.TabIndex = 94;
            this.txtPassword.Enter += new System.EventHandler(this.TxtPassword_Enter);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPassword_KeyDown);
            this.txtPassword.Leave += new System.EventHandler(this.TxtPassword_Leave);
            // 
            // FormOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 696);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip);
            this.Name = "FormOptions";
            this.Text = "frmOptions";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmOptions_FormClosing);
            this.Load += new System.EventHandler(this.FrmOptions_Load);
            this.SizeChanged += new System.EventHandler(this.FrmOptions_SizeChanged);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tbbSave;
        private System.Windows.Forms.ToolStripButton tbbDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripButton tbbLogin;
        private System.Windows.Forms.ToolStripButton tbbLogout;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button tbbCall;
        private System.Windows.Forms.Button tbbTeam;
    }
}