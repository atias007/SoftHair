namespace ClientManage.Forms
{
    partial class FormContactDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormContactDetails));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtJob = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddPhone1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCellPhone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtWebSite = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAddPhone2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtZipCode = new System.Windows.Forms.TextBox();
            this.txtMailCell = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblMust = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tbbSave = new System.Windows.Forms.ToolStripButton();
            this.tbbSaveAndNew = new System.Windows.Forms.ToolStripButton();
            this.tbbPrint = new System.Windows.Forms.ToolStripButton();
            this.tbbDelete = new System.Windows.Forms.ToolStripButton();
            this.tbbClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.imagePicker1 = new ImagePicker.ImagePicker();
            this.informationBar1 = new ClientManage.UserControls.InformationBar();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlButtom = new System.Windows.Forms.Panel();
            this.toolStrip.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlButtom.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(243, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "שם פרטי / מלא:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(243, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "שם משפחה:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtFirstName.Location = new System.Drawing.Point(18, 22);
            this.txtFirstName.MaxLength = 50;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(219, 23);
            this.txtFirstName.TabIndex = 0;
            this.txtFirstName.Enter += new System.EventHandler(this.TextBoxFocus);
            this.txtFirstName.Leave += new System.EventHandler(this.TextBoxLostFocus);
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtLastName.Location = new System.Drawing.Point(18, 48);
            this.txtLastName.MaxLength = 50;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(219, 23);
            this.txtLastName.TabIndex = 1;
            this.txtLastName.Enter += new System.EventHandler(this.TextBoxFocus);
            this.txtLastName.Leave += new System.EventHandler(this.TextBoxLostFocus);
            // 
            // txtCompany
            // 
            this.txtCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompany.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtCompany.Location = new System.Drawing.Point(18, 74);
            this.txtCompany.MaxLength = 50;
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(219, 23);
            this.txtCompany.TabIndex = 2;
            this.txtCompany.Enter += new System.EventHandler(this.TextBoxFocus);
            this.txtCompany.Leave += new System.EventHandler(this.TextBoxLostFocus);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(243, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "שם חברה:";
            // 
            // txtJob
            // 
            this.txtJob.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJob.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtJob.Location = new System.Drawing.Point(18, 100);
            this.txtJob.MaxLength = 50;
            this.txtJob.Name = "txtJob";
            this.txtJob.Size = new System.Drawing.Size(219, 23);
            this.txtJob.TabIndex = 3;
            this.txtJob.Enter += new System.EventHandler(this.TextBoxFocus);
            this.txtJob.Leave += new System.EventHandler(this.TextBoxLostFocus);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(243, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "תפקיד בחברה:";
            // 
            // txtAddPhone1
            // 
            this.txtAddPhone1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddPhone1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtAddPhone1.Location = new System.Drawing.Point(18, 238);
            this.txtAddPhone1.MaxLength = 50;
            this.txtAddPhone1.Name = "txtAddPhone1";
            this.txtAddPhone1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAddPhone1.Size = new System.Drawing.Size(219, 23);
            this.txtAddPhone1.TabIndex = 7;
            this.txtAddPhone1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAddPhone1.Enter += new System.EventHandler(this.TextBoxFocus);
            this.txtAddPhone1.Leave += new System.EventHandler(this.TextBoxLostFocus);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(242, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "טלפון בעבודה:";
            // 
            // txtCellPhone
            // 
            this.txtCellPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCellPhone.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtCellPhone.Location = new System.Drawing.Point(18, 212);
            this.txtCellPhone.MaxLength = 50;
            this.txtCellPhone.Name = "txtCellPhone";
            this.txtCellPhone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCellPhone.Size = new System.Drawing.Size(219, 23);
            this.txtCellPhone.TabIndex = 6;
            this.txtCellPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCellPhone.Enter += new System.EventHandler(this.TextBoxFocus);
            this.txtCellPhone.Leave += new System.EventHandler(this.TextBoxLostFocus);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(242, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "טלפון נייד:";
            // 
            // txtWebSite
            // 
            this.txtWebSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWebSite.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtWebSite.Location = new System.Drawing.Point(18, 152);
            this.txtWebSite.MaxLength = 255;
            this.txtWebSite.Name = "txtWebSite";
            this.txtWebSite.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtWebSite.Size = new System.Drawing.Size(219, 23);
            this.txtWebSite.TabIndex = 5;
            this.txtWebSite.Enter += new System.EventHandler(this.TextBoxFocus);
            this.txtWebSite.Leave += new System.EventHandler(this.TextBoxLostFocus);
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtEmail.Location = new System.Drawing.Point(18, 126);
            this.txtEmail.MaxLength = 255;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEmail.Size = new System.Drawing.Size(219, 23);
            this.txtEmail.TabIndex = 4;
            this.txtEmail.Enter += new System.EventHandler(this.TextBoxFocus);
            this.txtEmail.Leave += new System.EventHandler(this.TextBoxLostFocus);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label7.Location = new System.Drawing.Point(243, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "אתר אינטרנט:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label8.Location = new System.Drawing.Point(242, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "דוא\"ל";
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtAddress.Location = new System.Drawing.Point(13, 212);
            this.txtAddress.MaxLength = 50;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(219, 23);
            this.txtAddress.TabIndex = 10;
            this.txtAddress.Enter += new System.EventHandler(this.TextBoxFocus);
            this.txtAddress.Leave += new System.EventHandler(this.TextBoxLostFocus);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label9.Location = new System.Drawing.Point(237, 215);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "כתובת:";
            // 
            // txtFax
            // 
            this.txtFax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFax.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtFax.Location = new System.Drawing.Point(18, 290);
            this.txtFax.MaxLength = 50;
            this.txtFax.Name = "txtFax";
            this.txtFax.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFax.Size = new System.Drawing.Size(219, 23);
            this.txtFax.TabIndex = 9;
            this.txtFax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFax.Enter += new System.EventHandler(this.TextBoxFocus);
            this.txtFax.Leave += new System.EventHandler(this.TextBoxLostFocus);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label10.Location = new System.Drawing.Point(242, 293);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(155, 20);
            this.label10.TabIndex = 18;
            this.label10.Text = "מספר פקס:";
            // 
            // txtAddPhone2
            // 
            this.txtAddPhone2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddPhone2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtAddPhone2.Location = new System.Drawing.Point(18, 264);
            this.txtAddPhone2.MaxLength = 50;
            this.txtAddPhone2.Name = "txtAddPhone2";
            this.txtAddPhone2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAddPhone2.Size = new System.Drawing.Size(219, 23);
            this.txtAddPhone2.TabIndex = 8;
            this.txtAddPhone2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAddPhone2.Enter += new System.EventHandler(this.TextBoxFocus);
            this.txtAddPhone2.Leave += new System.EventHandler(this.TextBoxLostFocus);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label11.Location = new System.Drawing.Point(242, 267);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(155, 20);
            this.label11.TabIndex = 16;
            this.label11.Text = "טלפון בבית / נוסף:";
            // 
            // txtCity
            // 
            this.txtCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCity.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtCity.Location = new System.Drawing.Point(13, 238);
            this.txtCity.MaxLength = 50;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(219, 23);
            this.txtCity.TabIndex = 11;
            this.txtCity.Enter += new System.EventHandler(this.TextBoxFocus);
            this.txtCity.Leave += new System.EventHandler(this.TextBoxLostFocus);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label12.Location = new System.Drawing.Point(237, 241);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(155, 20);
            this.label12.TabIndex = 22;
            this.label12.Text = "עיר:";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(74)))), ((int)(((byte)(147)))));
            this.label13.Location = new System.Drawing.Point(321, 4);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 17);
            this.label13.TabIndex = 24;
            this.label13.Text = "פרטים אישיים";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.BackColor = System.Drawing.Color.LightSlateGray;
            this.label14.Location = new System.Drawing.Point(22, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(392, 1);
            this.label14.TabIndex = 25;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(74)))), ((int)(((byte)(147)))));
            this.label15.Location = new System.Drawing.Point(325, 193);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 17);
            this.label15.TabIndex = 26;
            this.label15.Text = "מספרי טלפון";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.BackColor = System.Drawing.Color.LightSlateGray;
            this.label16.Location = new System.Drawing.Point(22, 201);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(392, 1);
            this.label16.TabIndex = 27;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(74)))), ((int)(((byte)(147)))));
            this.label17.Location = new System.Drawing.Point(349, 194);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 17);
            this.label17.TabIndex = 28;
            this.label17.Text = "כתובת";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.BackColor = System.Drawing.Color.LightSlateGray;
            this.label18.Location = new System.Drawing.Point(17, 201);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(392, 1);
            this.label18.TabIndex = 29;
            // 
            // txtZipCode
            // 
            this.txtZipCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtZipCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtZipCode.Location = new System.Drawing.Point(13, 264);
            this.txtZipCode.MaxLength = 50;
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(219, 23);
            this.txtZipCode.TabIndex = 12;
            this.txtZipCode.Enter += new System.EventHandler(this.TextBoxFocus);
            this.txtZipCode.Leave += new System.EventHandler(this.TextBoxLostFocus);
            // 
            // txtMailCell
            // 
            this.txtMailCell.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMailCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtMailCell.Location = new System.Drawing.Point(13, 290);
            this.txtMailCell.MaxLength = 50;
            this.txtMailCell.Name = "txtMailCell";
            this.txtMailCell.Size = new System.Drawing.Size(219, 23);
            this.txtMailCell.TabIndex = 13;
            this.txtMailCell.Enter += new System.EventHandler(this.TextBoxFocus);
            this.txtMailCell.Leave += new System.EventHandler(this.TextBoxLostFocus);
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label19.Location = new System.Drawing.Point(237, 267);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(155, 20);
            this.label19.TabIndex = 32;
            this.label19.Text = "מיקוד:";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label20.Location = new System.Drawing.Point(238, 293);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(155, 20);
            this.label20.TabIndex = 33;
            this.label20.Text = "תא דואר:";
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(74)))), ((int)(((byte)(147)))));
            this.label21.Location = new System.Drawing.Point(786, 5);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(40, 17);
            this.label21.TabIndex = 34;
            this.label21.Text = "שונות";
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.BackColor = System.Drawing.Color.LightSlateGray;
            this.label22.Location = new System.Drawing.Point(17, 13);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(825, 1);
            this.label22.TabIndex = 35;
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label23.Location = new System.Drawing.Point(749, 27);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(76, 20);
            this.label23.TabIndex = 36;
            this.label23.Text = "הערות:";
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtNotes.Location = new System.Drawing.Point(13, 42);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(810, 180);
            this.txtNotes.TabIndex = 14;
            this.txtNotes.Enter += new System.EventHandler(this.TextBoxFocus);
            this.txtNotes.Leave += new System.EventHandler(this.TextBoxLostFocus);
            // 
            // lblMust
            // 
            this.lblMust.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMust.AutoSize = true;
            this.lblMust.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblMust.ForeColor = System.Drawing.Color.Red;
            this.lblMust.Location = new System.Drawing.Point(395, 29);
            this.lblMust.Name = "lblMust";
            this.lblMust.Size = new System.Drawing.Size(13, 16);
            this.lblMust.TabIndex = 45;
            this.lblMust.Text = "*";
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label25.Location = new System.Drawing.Point(722, 225);
            this.label25.Name = "label25";
            this.label25.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label25.Size = new System.Drawing.Size(91, 20);
            this.label25.TabIndex = 49;
            this.label25.Text = " (שדות חובה)";
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label26.ForeColor = System.Drawing.Color.Red;
            this.label26.Location = new System.Drawing.Point(807, 226);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(13, 16);
            this.label26.TabIndex = 48;
            this.label26.Text = "*";
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(74)))), ((int)(((byte)(147)))));
            this.label24.Location = new System.Drawing.Point(268, 4);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(125, 17);
            this.label24.TabIndex = 52;
            this.label24.Text = "תמונה / תצוגה מקדימה";
            // 
            // label27
            // 
            this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label27.BackColor = System.Drawing.Color.LightSlateGray;
            this.label27.Location = new System.Drawing.Point(18, 12);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(392, 1);
            this.label27.TabIndex = 53;
            // 
            // dlgOpenFile
            // 
            this.dlgOpenFile.RestoreDirectory = true;
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackgroundImage = global::ClientManage.Properties.Resources.toolbar_bg;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbSave,
            this.tbbSaveAndNew,
            this.tbbPrint,
            this.tbbDelete,
            this.tbbClose,
            this.toolStripSeparator1});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1024, 42);
            this.toolStrip.TabIndex = 56;
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
            this.tbbSave.Text = "שמור";
            this.tbbSave.ToolTipText = "שמירה וסגירת החלון  (Ctrl + S)";
            this.tbbSave.Click += new System.EventHandler(this.TbbSave_Click);
            // 
            // tbbSaveAndNew
            // 
            this.tbbSaveAndNew.AutoToolTip = false;
            this.tbbSaveAndNew.Image = ((System.Drawing.Image)(resources.GetObject("tbbSaveAndNew.Image")));
            this.tbbSaveAndNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbSaveAndNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbSaveAndNew.Name = "tbbSaveAndNew";
            this.tbbSaveAndNew.Size = new System.Drawing.Size(96, 39);
            this.tbbSaveAndNew.Text = "שמור וחדש";
            this.tbbSaveAndNew.ToolTipText = "שמירה ופתיחת כרטיס איש קשר חדש";
            this.tbbSaveAndNew.Click += new System.EventHandler(this.TbbSaveAndNew_Click);
            // 
            // tbbPrint
            // 
            this.tbbPrint.AutoToolTip = false;
            this.tbbPrint.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tbbPrint.Image")));
            this.tbbPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbPrint.Name = "tbbPrint";
            this.tbbPrint.Size = new System.Drawing.Size(67, 39);
            this.tbbPrint.Text = "הדפס";
            this.tbbPrint.ToolTipText = "הדפסת פרטי איש הקשר";
            this.tbbPrint.Click += new System.EventHandler(this.TbbPrint_Click);
            // 
            // tbbDelete
            // 
            this.tbbDelete.AutoToolTip = false;
            this.tbbDelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbDelete.ForeColor = System.Drawing.Color.SaddleBrown;
            this.tbbDelete.Image = global::ClientManage.Properties.Resources.tb_delete;
            this.tbbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbDelete.Name = "tbbDelete";
            this.tbbDelete.Size = new System.Drawing.Size(107, 39);
            this.tbbDelete.Text = "מחק איש קשר";
            this.tbbDelete.ToolTipText = "מחיקת איש הקשר";
            this.tbbDelete.Click += new System.EventHandler(this.TbbDelete_Click);
            // 
            // tbbClose
            // 
            this.tbbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbbClose.AutoToolTip = false;
            this.tbbClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbClose.Image = global::ClientManage.Properties.Resources.close_form2;
            this.tbbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbClose.Name = "tbbClose";
            this.tbbClose.Size = new System.Drawing.Size(125, 39);
            this.tbbClose.Text = "סגור / בטל עדכון";
            this.tbbClose.ToolTipText = "סגירת החלון וביטול כל השינויים  (Esc)";
            this.tbbClose.Click += new System.EventHandler(this.TbbClose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 42);
            // 
            // imagePicker1
            // 
            this.imagePicker1.BackColor = System.Drawing.Color.Transparent;
            this.imagePicker1.DefaultImage = null;
            this.imagePicker1.EnableWebCam = true;
            this.imagePicker1.ImageFilename = "";
            this.imagePicker1.Location = new System.Drawing.Point(13, 22);
            this.imagePicker1.MenuButtonEnable = true;
            this.imagePicker1.MenuButtonVisible = true;
            this.imagePicker1.Name = "imagePicker1";
            this.imagePicker1.OpenFileDialogFilter = "JPEG Compressed Image (*.jpg)|*.jpg|CompuServ File Format (*.gif)|*.gif";
            this.imagePicker1.OpenFileDialogTitle = "";
            this.imagePicker1.Size = new System.Drawing.Size(170, 153);
            this.imagePicker1.TabIndex = 57;
            this.imagePicker1.WebCamCapture += new ImagePicker.ImagePicker.WebCamCaptureHandler(this.ImagePicker1_WebCamCapture);
            // 
            // informationBar1
            // 
            this.informationBar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("informationBar1.BackgroundImage")));
            this.informationBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.informationBar1.Image = null;
            this.informationBar1.LabelForeColor = System.Drawing.Color.DarkGreen;
            this.informationBar1.LabelImage = global::ClientManage.Properties.Resources.ok_small;
            this.informationBar1.LabelText = "      איש הקשר {0} נשמר בהצלחה";
            this.informationBar1.LabelVisible = false;
            this.informationBar1.Location = new System.Drawing.Point(0, 42);
            this.informationBar1.Name = "informationBar1";
            this.informationBar1.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.informationBar1.PanelText = "InformationPanel";
            this.informationBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.informationBar1.Size = new System.Drawing.Size(1024, 28);
            this.informationBar1.TabIndex = 58;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.label17);
            this.pnlLeft.Controls.Add(this.imagePicker1);
            this.pnlLeft.Controls.Add(this.label9);
            this.pnlLeft.Controls.Add(this.txtAddress);
            this.pnlLeft.Controls.Add(this.label12);
            this.pnlLeft.Controls.Add(this.label24);
            this.pnlLeft.Controls.Add(this.txtCity);
            this.pnlLeft.Controls.Add(this.label18);
            this.pnlLeft.Controls.Add(this.label27);
            this.pnlLeft.Controls.Add(this.txtZipCode);
            this.pnlLeft.Controls.Add(this.txtMailCell);
            this.pnlLeft.Controls.Add(this.label19);
            this.pnlLeft.Controls.Add(this.label20);
            this.pnlLeft.Location = new System.Drawing.Point(84, 78);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(428, 330);
            this.pnlLeft.TabIndex = 59;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.label13);
            this.pnlRight.Controls.Add(this.label1);
            this.pnlRight.Controls.Add(this.label2);
            this.pnlRight.Controls.Add(this.txtFirstName);
            this.pnlRight.Controls.Add(this.txtLastName);
            this.pnlRight.Controls.Add(this.label3);
            this.pnlRight.Controls.Add(this.lblMust);
            this.pnlRight.Controls.Add(this.txtCompany);
            this.pnlRight.Controls.Add(this.label4);
            this.pnlRight.Controls.Add(this.txtJob);
            this.pnlRight.Controls.Add(this.label8);
            this.pnlRight.Controls.Add(this.label7);
            this.pnlRight.Controls.Add(this.label15);
            this.pnlRight.Controls.Add(this.txtEmail);
            this.pnlRight.Controls.Add(this.label16);
            this.pnlRight.Controls.Add(this.txtWebSite);
            this.pnlRight.Controls.Add(this.label6);
            this.pnlRight.Controls.Add(this.label14);
            this.pnlRight.Controls.Add(this.txtCellPhone);
            this.pnlRight.Controls.Add(this.txtFax);
            this.pnlRight.Controls.Add(this.label5);
            this.pnlRight.Controls.Add(this.label10);
            this.pnlRight.Controls.Add(this.txtAddPhone1);
            this.pnlRight.Controls.Add(this.txtAddPhone2);
            this.pnlRight.Controls.Add(this.label11);
            this.pnlRight.Location = new System.Drawing.Point(512, 78);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(428, 330);
            this.pnlRight.TabIndex = 60;
            // 
            // pnlButtom
            // 
            this.pnlButtom.Controls.Add(this.label21);
            this.pnlButtom.Controls.Add(this.label26);
            this.pnlButtom.Controls.Add(this.txtNotes);
            this.pnlButtom.Controls.Add(this.label22);
            this.pnlButtom.Controls.Add(this.label23);
            this.pnlButtom.Controls.Add(this.label25);
            this.pnlButtom.Location = new System.Drawing.Point(84, 408);
            this.pnlButtom.Name = "pnlButtom";
            this.pnlButtom.Size = new System.Drawing.Size(856, 249);
            this.pnlButtom.TabIndex = 61;
            // 
            // FormContactDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(1024, 665);
            this.CloseFormByEsc = true;
            this.Controls.Add(this.pnlButtom);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.informationBar1);
            this.Controls.Add(this.toolStrip);
            this.KeyPreview = true;
            this.Name = "FormContactDetails";
            this.Text = " | כרטיס איש קשר {0} |";
            this.RequestForClose += new System.EventHandler(this.FrmContactDetails_RequestForClose);
            this.Load += new System.EventHandler(this.FrmContactDetails_Load);
            this.SizeChanged += new System.EventHandler(this.FormContactDetails_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmContactDetails_KeyDown);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlButtom.ResumeLayout(false);
            this.pnlButtom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtJob;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAddPhone1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCellPhone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtWebSite;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAddPhone2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtZipCode;
        private System.Windows.Forms.TextBox txtMailCell;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblMust;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tbbSave;
        private System.Windows.Forms.ToolStripButton tbbSaveAndNew;
        private System.Windows.Forms.ToolStripButton tbbPrint;
        private System.Windows.Forms.ToolStripButton tbbDelete;
        private System.Windows.Forms.ToolStripButton tbbClose;
        private ImagePicker.ImagePicker imagePicker1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private ClientManage.UserControls.InformationBar informationBar1;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlButtom;
    }
}