namespace ClientManage.Forms.OptionForms
{
    partial class FormOptContact
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
            this.rbLastNameFirst = new System.Windows.Forms.RadioButton();
            this.rbFnameFirst = new System.Windows.Forms.RadioButton();
            this.lstPhoneBook = new System.Windows.Forms.CheckedListBox();
            this.btnDownContact = new System.Windows.Forms.Button();
            this.btnUpContact = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rbLastNameFirst
            // 
            this.rbLastNameFirst.Location = new System.Drawing.Point(15, 294);
            this.rbLastNameFirst.Name = "rbLastNameFirst";
            this.rbLastNameFirst.Size = new System.Drawing.Size(218, 17);
            this.rbLastNameFirst.TabIndex = 15;
            this.rbLastNameFirst.Text = "שם משפחה קודם לשם פרטי";
            this.rbLastNameFirst.UseVisualStyleBackColor = true;
            // 
            // rbFnameFirst
            // 
            this.rbFnameFirst.Checked = true;
            this.rbFnameFirst.Location = new System.Drawing.Point(15, 275);
            this.rbFnameFirst.Name = "rbFnameFirst";
            this.rbFnameFirst.Size = new System.Drawing.Size(218, 17);
            this.rbFnameFirst.TabIndex = 14;
            this.rbFnameFirst.TabStop = true;
            this.rbFnameFirst.Text = "שם פרטי קודם לשם משפחה";
            this.rbFnameFirst.UseVisualStyleBackColor = true;
            // 
            // lstPhoneBook
            // 
            this.lstPhoneBook.FormattingEnabled = true;
            this.lstPhoneBook.Items.AddRange(new object[] {
            "FirstName",
            "LastName",
            "Street",
            "City",
            "Phone"});
            this.lstPhoneBook.Location = new System.Drawing.Point(15, 78);
            this.lstPhoneBook.Name = "lstPhoneBook";
            this.lstPhoneBook.Size = new System.Drawing.Size(287, 191);
            this.lstPhoneBook.TabIndex = 11;
            this.lstPhoneBook.SelectedIndexChanged += new System.EventHandler(this.lstPhoneBook_SelectedIndexChanged);
            // 
            // btnDownContact
            // 
            this.btnDownContact.Image = global::ClientManage.Properties.Resources.arr_down;
            this.btnDownContact.Location = new System.Drawing.Point(304, 103);
            this.btnDownContact.Name = "btnDownContact";
            this.btnDownContact.Size = new System.Drawing.Size(25, 23);
            this.btnDownContact.TabIndex = 13;
            this.btnDownContact.UseVisualStyleBackColor = true;
            this.btnDownContact.Click += new System.EventHandler(this.btnDownContact_Click);
            // 
            // btnUpContact
            // 
            this.btnUpContact.Image = global::ClientManage.Properties.Resources.arr_up;
            this.btnUpContact.Location = new System.Drawing.Point(304, 77);
            this.btnUpContact.Name = "btnUpContact";
            this.btnUpContact.Size = new System.Drawing.Size(25, 23);
            this.btnUpContact.TabIndex = 12;
            this.btnUpContact.UseVisualStyleBackColor = true;
            this.btnUpContact.Click += new System.EventHandler(this.btnUpContact_Click);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label11.Location = new System.Drawing.Point(12, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(307, 19);
            this.label11.TabIndex = 10;
            this.label11.Text = "חפש אנשי קשר לפי השדות הבאים ולפי סדר הצגתן:";
            // 
            // frmOptContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 620);
            this.Controls.Add(this.rbLastNameFirst);
            this.Controls.Add(this.rbFnameFirst);
            this.Controls.Add(this.lstPhoneBook);
            this.Controls.Add(this.btnDownContact);
            this.Controls.Add(this.btnUpContact);
            this.Controls.Add(this.label11);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmOptContact";
            this.Text = "frmOptContact";
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.btnUpContact, 0);
            this.Controls.SetChildIndex(this.btnDownContact, 0);
            this.Controls.SetChildIndex(this.lstPhoneBook, 0);
            this.Controls.SetChildIndex(this.rbFnameFirst, 0);
            this.Controls.SetChildIndex(this.rbLastNameFirst, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbLastNameFirst;
        private System.Windows.Forms.RadioButton rbFnameFirst;
        private System.Windows.Forms.CheckedListBox lstPhoneBook;
        private System.Windows.Forms.Button btnDownContact;
        private System.Windows.Forms.Button btnUpContact;
        private System.Windows.Forms.Label label11;
    }
}