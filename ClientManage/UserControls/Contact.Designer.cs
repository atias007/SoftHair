namespace ClientManage.UserControls
{
    partial class Contact
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblSelected = new System.Windows.Forms.Label();
            this.lblCellPhone = new System.Windows.Forms.Label();
            this.lblCellPhoneCap = new System.Windows.Forms.Label();
            this.lblWorkPhone = new System.Windows.Forms.Label();
            this.lblWorkPhoneCap = new System.Windows.Forms.Label();
            this.lblHomePhone = new System.Windows.Forms.Label();
            this.lblHomePhoneCap = new System.Windows.Forms.Label();
            this.lblFax = new System.Windows.Forms.Label();
            this.lblFaxCap = new System.Windows.Forms.Label();
            this.lblSpace = new System.Windows.Forms.Label();
            this.lblAddress1 = new System.Windows.Forms.Label();
            this.lblAddress2 = new System.Windows.Forms.Label();
            this.lblSpace2 = new System.Windows.Forms.Label();
            this.lnkEmail = new System.Windows.Forms.LinkLabel();
            this.lblFocus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblName.Location = new System.Drawing.Point(46, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(197, 25);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "שם איש קשר";
            this.lblName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Contact_MouseDoubleClick);
            this.lblName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Contact_MouseDown);
            // 
            // lblSelected
            // 
            this.lblSelected.BackColor = System.Drawing.Color.Transparent;
            this.lblSelected.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblSelected.ForeColor = System.Drawing.Color.Navy;
            this.lblSelected.Location = new System.Drawing.Point(0, 0);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(250, 17);
            this.lblSelected.TabIndex = 3;
            this.lblSelected.Text = "חברה - תפקיד";
            this.lblSelected.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSelected.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Contact_MouseDoubleClick);
            this.lblSelected.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Contact_MouseDown);
            // 
            // lblCellPhone
            // 
            this.lblCellPhone.BackColor = System.Drawing.Color.Transparent;
            this.lblCellPhone.Location = new System.Drawing.Point(170, 48);
            this.lblCellPhone.Name = "lblCellPhone";
            this.lblCellPhone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCellPhone.Size = new System.Drawing.Size(71, 13);
            this.lblCellPhone.TabIndex = 16;
            this.lblCellPhone.Text = "999-1234567";
            this.lblCellPhone.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Contact_MouseDoubleClick);
            this.lblCellPhone.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Contact_MouseDown);
            // 
            // lblCellPhoneCap
            // 
            this.lblCellPhoneCap.BackColor = System.Drawing.Color.Transparent;
            this.lblCellPhoneCap.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblCellPhoneCap.ForeColor = System.Drawing.Color.DimGray;
            this.lblCellPhoneCap.Location = new System.Drawing.Point(89, 48);
            this.lblCellPhoneCap.Name = "lblCellPhoneCap";
            this.lblCellPhoneCap.Size = new System.Drawing.Size(81, 13);
            this.lblCellPhoneCap.TabIndex = 17;
            this.lblCellPhoneCap.Text = "(נייד)";
            this.lblCellPhoneCap.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Contact_MouseDoubleClick);
            this.lblCellPhoneCap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Contact_MouseDown);
            // 
            // lblWorkPhone
            // 
            this.lblWorkPhone.BackColor = System.Drawing.Color.Transparent;
            this.lblWorkPhone.Location = new System.Drawing.Point(170, 61);
            this.lblWorkPhone.Name = "lblWorkPhone";
            this.lblWorkPhone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblWorkPhone.Size = new System.Drawing.Size(71, 13);
            this.lblWorkPhone.TabIndex = 18;
            this.lblWorkPhone.Text = "999-999999";
            this.lblWorkPhone.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Contact_MouseDoubleClick);
            this.lblWorkPhone.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Contact_MouseDown);
            // 
            // lblWorkPhoneCap
            // 
            this.lblWorkPhoneCap.BackColor = System.Drawing.Color.Transparent;
            this.lblWorkPhoneCap.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblWorkPhoneCap.ForeColor = System.Drawing.Color.DimGray;
            this.lblWorkPhoneCap.Location = new System.Drawing.Point(89, 61);
            this.lblWorkPhoneCap.Name = "lblWorkPhoneCap";
            this.lblWorkPhoneCap.Size = new System.Drawing.Size(81, 13);
            this.lblWorkPhoneCap.TabIndex = 19;
            this.lblWorkPhoneCap.Text = "(עבודה)";
            this.lblWorkPhoneCap.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Contact_MouseDoubleClick);
            this.lblWorkPhoneCap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Contact_MouseDown);
            // 
            // lblHomePhone
            // 
            this.lblHomePhone.BackColor = System.Drawing.Color.Transparent;
            this.lblHomePhone.Location = new System.Drawing.Point(170, 74);
            this.lblHomePhone.Name = "lblHomePhone";
            this.lblHomePhone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblHomePhone.Size = new System.Drawing.Size(71, 13);
            this.lblHomePhone.TabIndex = 20;
            this.lblHomePhone.Text = "999-999999";
            this.lblHomePhone.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Contact_MouseDoubleClick);
            this.lblHomePhone.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Contact_MouseDown);
            // 
            // lblHomePhoneCap
            // 
            this.lblHomePhoneCap.BackColor = System.Drawing.Color.Transparent;
            this.lblHomePhoneCap.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblHomePhoneCap.ForeColor = System.Drawing.Color.DimGray;
            this.lblHomePhoneCap.Location = new System.Drawing.Point(71, 74);
            this.lblHomePhoneCap.Name = "lblHomePhoneCap";
            this.lblHomePhoneCap.Size = new System.Drawing.Size(99, 13);
            this.lblHomePhoneCap.TabIndex = 21;
            this.lblHomePhoneCap.Text = "(בית/נוסף)";
            this.lblHomePhoneCap.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Contact_MouseDoubleClick);
            this.lblHomePhoneCap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Contact_MouseDown);
            // 
            // lblFax
            // 
            this.lblFax.BackColor = System.Drawing.Color.Transparent;
            this.lblFax.Location = new System.Drawing.Point(170, 87);
            this.lblFax.Name = "lblFax";
            this.lblFax.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblFax.Size = new System.Drawing.Size(71, 13);
            this.lblFax.TabIndex = 22;
            this.lblFax.Text = "999-999999";
            this.lblFax.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Contact_MouseDoubleClick);
            this.lblFax.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Contact_MouseDown);
            // 
            // lblFaxCap
            // 
            this.lblFaxCap.BackColor = System.Drawing.Color.Transparent;
            this.lblFaxCap.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblFaxCap.ForeColor = System.Drawing.Color.DimGray;
            this.lblFaxCap.Location = new System.Drawing.Point(89, 87);
            this.lblFaxCap.Name = "lblFaxCap";
            this.lblFaxCap.Size = new System.Drawing.Size(81, 13);
            this.lblFaxCap.TabIndex = 23;
            this.lblFaxCap.Text = "(פקס)";
            this.lblFaxCap.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Contact_MouseDoubleClick);
            this.lblFaxCap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Contact_MouseDown);
            // 
            // lblSpace
            // 
            this.lblSpace.BackColor = System.Drawing.Color.Transparent;
            this.lblSpace.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblSpace.ForeColor = System.Drawing.Color.DimGray;
            this.lblSpace.Location = new System.Drawing.Point(83, 100);
            this.lblSpace.Name = "lblSpace";
            this.lblSpace.Size = new System.Drawing.Size(158, 7);
            this.lblSpace.TabIndex = 24;
            this.lblSpace.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Contact_MouseDown);
            // 
            // lblAddress1
            // 
            this.lblAddress1.BackColor = System.Drawing.Color.Transparent;
            this.lblAddress1.Location = new System.Drawing.Point(44, 107);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(198, 13);
            this.lblAddress1.TabIndex = 25;
            this.lblAddress1.Text = "רחוב, מס בית + דירה";
            this.lblAddress1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Contact_MouseDoubleClick);
            this.lblAddress1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Contact_MouseDown);
            // 
            // lblAddress2
            // 
            this.lblAddress2.BackColor = System.Drawing.Color.Transparent;
            this.lblAddress2.Location = new System.Drawing.Point(44, 120);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(197, 13);
            this.lblAddress2.TabIndex = 26;
            this.lblAddress2.Text = "עיר, מיקוד, ת\"ד";
            this.lblAddress2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Contact_MouseDoubleClick);
            this.lblAddress2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Contact_MouseDown);
            // 
            // lblSpace2
            // 
            this.lblSpace2.BackColor = System.Drawing.Color.Transparent;
            this.lblSpace2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblSpace2.ForeColor = System.Drawing.Color.DimGray;
            this.lblSpace2.Location = new System.Drawing.Point(83, 133);
            this.lblSpace2.Name = "lblSpace2";
            this.lblSpace2.Size = new System.Drawing.Size(158, 7);
            this.lblSpace2.TabIndex = 27;
            this.lblSpace2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Contact_MouseDown);
            // 
            // lnkEmail
            // 
            this.lnkEmail.BackColor = System.Drawing.Color.Transparent;
            this.lnkEmail.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lnkEmail.Location = new System.Drawing.Point(44, 140);
            this.lnkEmail.Name = "lnkEmail";
            this.lnkEmail.Size = new System.Drawing.Size(197, 19);
            this.lnkEmail.TabIndex = 28;
            this.lnkEmail.TabStop = true;
            this.lnkEmail.Text = "mail.bizcare@gmail.com";
            this.lnkEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEmail_LinkClicked);
            this.lnkEmail.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Contact_MouseDoubleClick);
            this.lnkEmail.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Contact_MouseDown);
            // 
            // lblFocus
            // 
            this.lblFocus.BackColor = System.Drawing.Color.Transparent;
            this.lblFocus.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblFocus.Location = new System.Drawing.Point(0, 0);
            this.lblFocus.Name = "lblFocus";
            this.lblFocus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblFocus.Size = new System.Drawing.Size(2, 171);
            this.lblFocus.TabIndex = 29;
            // 
            // Contact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblCellPhone);
            this.Controls.Add(this.lblCellPhoneCap);
            this.Controls.Add(this.lblWorkPhone);
            this.Controls.Add(this.lblWorkPhoneCap);
            this.Controls.Add(this.lblHomePhone);
            this.Controls.Add(this.lblHomePhoneCap);
            this.Controls.Add(this.lblFax);
            this.Controls.Add(this.lblFaxCap);
            this.Controls.Add(this.lblSpace);
            this.Controls.Add(this.lblAddress1);
            this.Controls.Add(this.lblAddress2);
            this.Controls.Add(this.lblSpace2);
            this.Controls.Add(this.lnkEmail);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblFocus);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Name = "Contact";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(255, 171);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Contact_Paint);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Contact_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Contact_MouseDown);
            this.Enter += new System.EventHandler(this.Contact_Enter);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Label lblCellPhone;
        private System.Windows.Forms.Label lblCellPhoneCap;
        private System.Windows.Forms.Label lblWorkPhone;
        private System.Windows.Forms.Label lblWorkPhoneCap;
        private System.Windows.Forms.Label lblHomePhone;
        private System.Windows.Forms.Label lblHomePhoneCap;
        private System.Windows.Forms.Label lblFax;
        private System.Windows.Forms.Label lblFaxCap;
        private System.Windows.Forms.Label lblSpace;
        private System.Windows.Forms.Label lblAddress1;
        private System.Windows.Forms.Label lblAddress2;
        private System.Windows.Forms.Label lblSpace2;
        private System.Windows.Forms.LinkLabel lnkEmail;
        private System.Windows.Forms.Label lblFocus;
    }
}
