namespace ClientManage.Forms.OptionForms
{
    partial class FormOptEmail
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
            this.txtMailWS = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.txtMailFrom = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.btnValidUrlEmail = new System.Windows.Forms.Button();
            this.label71 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cTemplateName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cTemplateSubject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstMailTemplates = new System.Windows.Forms.ListView();
            this.lblPreview = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtMailWS
            // 
            this.txtMailWS.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMailWS.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtMailWS.Location = new System.Drawing.Point(181, 84);
            this.txtMailWS.Name = "txtMailWS";
            this.txtMailWS.ReadOnly = true;
            this.txtMailWS.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMailWS.Size = new System.Drawing.Size(462, 22);
            this.txtMailWS.TabIndex = 41;
            this.txtMailWS.Tag = "SuperUser";
            // 
            // label37
            // 
            this.label37.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label37.Location = new System.Drawing.Point(12, 87);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(195, 19);
            this.label37.TabIndex = 40;
            this.label37.Text = "כתובת עבור שירות הדוא\"ל:";
            // 
            // txtMailFrom
            // 
            this.txtMailFrom.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtMailFrom.Location = new System.Drawing.Point(181, 59);
            this.txtMailFrom.Name = "txtMailFrom";
            this.txtMailFrom.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMailFrom.Size = new System.Drawing.Size(462, 22);
            this.txtMailFrom.TabIndex = 39;
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label34.Location = new System.Drawing.Point(12, 62);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(123, 19);
            this.label34.TabIndex = 38;
            this.label34.Text = "מאת, כתובת דוא\"ל:";
            // 
            // btnValidUrlEmail
            // 
            this.btnValidUrlEmail.Enabled = false;
            this.btnValidUrlEmail.Image = global::ClientManage.Properties.Resources.ok;
            this.btnValidUrlEmail.Location = new System.Drawing.Point(642, 58);
            this.btnValidUrlEmail.Name = "btnValidUrlEmail";
            this.btnValidUrlEmail.Size = new System.Drawing.Size(23, 24);
            this.btnValidUrlEmail.TabIndex = 42;
            this.btnValidUrlEmail.Tag = "Admin";
            this.btnValidUrlEmail.UseVisualStyleBackColor = true;
            this.btnValidUrlEmail.Click += new System.EventHandler(this.btnValidUrlEmail_Click);
            // 
            // label71
            // 
            this.label71.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label71.Location = new System.Drawing.Point(12, 124);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(240, 21);
            this.label71.TabIndex = 78;
            this.label71.Text = "רשימת תבניות קיימות במערכת:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(539, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 21);
            this.label2.TabIndex = 81;
            this.label2.Text = "תצוגה מקדימה:";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button1.Location = new System.Drawing.Point(457, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 21);
            this.button1.TabIndex = 79;
            this.button1.Text = "מחק תבנית";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cTemplateName
            // 
            this.cTemplateName.Text = "שם תבנית";
            this.cTemplateName.Width = 200;
            // 
            // cTemplateSubject
            // 
            this.cTemplateSubject.Text = "נושא";
            this.cTemplateSubject.Width = 300;
            // 
            // lstMailTemplates
            // 
            this.lstMailTemplates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cTemplateName,
            this.cTemplateSubject});
            this.lstMailTemplates.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lstMailTemplates.FullRowSelect = true;
            this.lstMailTemplates.HideSelection = false;
            this.lstMailTemplates.Location = new System.Drawing.Point(12, 140);
            this.lstMailTemplates.MultiSelect = false;
            this.lstMailTemplates.Name = "lstMailTemplates";
            this.lstMailTemplates.RightToLeftLayout = true;
            this.lstMailTemplates.ShowGroups = false;
            this.lstMailTemplates.Size = new System.Drawing.Size(524, 200);
            this.lstMailTemplates.TabIndex = 77;
            this.lstMailTemplates.UseCompatibleStateImageBehavior = false;
            this.lstMailTemplates.View = System.Windows.Forms.View.Details;
            this.lstMailTemplates.SelectedIndexChanged += new System.EventHandler(this.lstMailTemplates_SelectedIndexChanged);
            // 
            // lblPreview
            // 
            this.lblPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPreview.Location = new System.Drawing.Point(539, 140);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(240, 200);
            this.lblPreview.TabIndex = 80;
            // 
            // FormOptEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 620);
            this.Controls.Add(this.lblPreview);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstMailTemplates);
            this.Controls.Add(this.label71);
            this.Controls.Add(this.txtMailWS);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.txtMailFrom);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.btnValidUrlEmail);
            this.Controls.Add(this.label2);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormOptEmail";
            this.Text = "frmOptEmail1";
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnValidUrlEmail, 0);
            this.Controls.SetChildIndex(this.label34, 0);
            this.Controls.SetChildIndex(this.txtMailFrom, 0);
            this.Controls.SetChildIndex(this.label37, 0);
            this.Controls.SetChildIndex(this.txtMailWS, 0);
            this.Controls.SetChildIndex(this.label71, 0);
            this.Controls.SetChildIndex(this.lstMailTemplates, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.lblPreview, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMailWS;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox txtMailFrom;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button btnValidUrlEmail;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader cTemplateName;
        private System.Windows.Forms.ColumnHeader cTemplateSubject;
        private System.Windows.Forms.ListView lstMailTemplates;
        private System.Windows.Forms.Label lblPreview;
    }
}