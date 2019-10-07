namespace ClientManage.UserControls
{
    partial class IncomeCallerId
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IncomeCallerId));
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.picClient = new System.Windows.Forms.PictureBox();
            this.lblNoId = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnNew = new ClientManage.UserControls.XPFlatButton();
            this.btnSetApp = new ClientManage.UserControls.XPFlatButton();
            this.btnShowCard = new ClientManage.UserControls.XPFlatButton();
            this.btnSetApp2 = new ClientManage.UserControls.XPFlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.picClient)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAddress
            // 
            this.lblAddress.BackColor = System.Drawing.Color.Transparent;
            this.lblAddress.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblAddress.Location = new System.Drawing.Point(182, 49);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAddress.Size = new System.Drawing.Size(324, 20);
            this.lblAddress.TabIndex = 49;
            // 
            // lblGender
            // 
            this.lblGender.BackColor = System.Drawing.Color.Transparent;
            this.lblGender.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGender.Location = new System.Drawing.Point(182, 69);
            this.lblGender.Name = "lblGender";
            this.lblGender.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblGender.Size = new System.Drawing.Size(321, 20);
            this.lblGender.TabIndex = 50;
            // 
            // picClient
            // 
            this.picClient.BackColor = System.Drawing.Color.White;
            this.picClient.BackgroundImage = global::ClientManage.Properties.Resources.no_image_big;
            this.picClient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClient.Location = new System.Drawing.Point(3, 3);
            this.picClient.Name = "picClient";
            this.picClient.Size = new System.Drawing.Size(170, 128);
            this.picClient.TabIndex = 41;
            this.picClient.TabStop = false;
            this.picClient.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicClient_MouseDown);
            // 
            // lblNoId
            // 
            this.lblNoId.BackColor = System.Drawing.Color.Transparent;
            this.lblNoId.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblNoId.ForeColor = System.Drawing.Color.IndianRed;
            this.lblNoId.Location = new System.Drawing.Point(274, 108);
            this.lblNoId.Name = "lblNoId";
            this.lblNoId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNoId.Size = new System.Drawing.Size(235, 24);
            this.lblNoId.TabIndex = 52;
            this.lblNoId.Text = "המתקשר אינו במאגר הלקוחות";
            this.lblNoId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblName
            // 
            this.lblName.AutoEllipsis = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblName.ForeColor = System.Drawing.Color.Maroon;
            this.lblName.Location = new System.Drawing.Point(179, 9);
            this.lblName.Name = "lblName";
            this.lblName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblName.Size = new System.Drawing.Size(333, 40);
            this.lblName.TabIndex = 53;
            this.lblName.Text = "לא מזוהה";
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.White;
            this.btnNew.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(198, 109);
            this.btnNew.Name = "btnNew";
            this.btnNew.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnNew.Size = new System.Drawing.Size(103, 22);
            this.btnNew.TabIndex = 58;
            this.btnNew.Text = "       צור לקוח חדש";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Visible = false;
            this.btnNew.VisibleChanged += new System.EventHandler(this.BtnNew_VisibleChanged);
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // btnSetApp
            // 
            this.btnSetApp.BackColor = System.Drawing.Color.White;
            this.btnSetApp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetApp.Image = ((System.Drawing.Image)(resources.GetObject("btnSetApp.Image")));
            this.btnSetApp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetApp.Location = new System.Drawing.Point(296, 109);
            this.btnSetApp.Name = "btnSetApp";
            this.btnSetApp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSetApp.Size = new System.Drawing.Size(83, 22);
            this.btnSetApp.TabIndex = 57;
            this.btnSetApp.Text = "        קבע תור";
            this.btnSetApp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetApp.Click += new System.EventHandler(this.BtnSetAppointment_Click);
            // 
            // btnShowCard
            // 
            this.btnShowCard.BackColor = System.Drawing.Color.White;
            this.btnShowCard.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowCard.Image = ((System.Drawing.Image)(resources.GetObject("btnShowCard.Image")));
            this.btnShowCard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowCard.Location = new System.Drawing.Point(382, 109);
            this.btnShowCard.Name = "btnShowCard";
            this.btnShowCard.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnShowCard.Size = new System.Drawing.Size(124, 22);
            this.btnShowCard.TabIndex = 56;
            this.btnShowCard.Text = "        הצג כרטיס לקוח";
            this.btnShowCard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowCard.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnSetApp2
            // 
            this.btnSetApp2.BackColor = System.Drawing.Color.White;
            this.btnSetApp2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetApp2.Image = ((System.Drawing.Image)(resources.GetObject("btnSetApp2.Image")));
            this.btnSetApp2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetApp2.Location = new System.Drawing.Point(198, 86);
            this.btnSetApp2.Name = "btnSetApp2";
            this.btnSetApp2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSetApp2.Size = new System.Drawing.Size(103, 22);
            this.btnSetApp2.TabIndex = 59;
            this.btnSetApp2.Text = "        קבע תור";
            this.btnSetApp2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetApp2.Visible = false;
            this.btnSetApp2.Click += new System.EventHandler(this.BtnSetApp2_Click);
            // 
            // IncomeCallerId
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.Controls.Add(this.btnSetApp2);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.picClient);
            this.Controls.Add(this.lblNoId);
            this.Controls.Add(this.btnSetApp);
            this.Controls.Add(this.btnShowCard);
            this.Name = "IncomeCallerId";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(512, 136);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.IncomeCallerId_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.picClient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picClient;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblNoId;
        private System.Windows.Forms.Label lblName;
        private ClientManage.UserControls.XPFlatButton btnShowCard;
        private ClientManage.UserControls.XPFlatButton btnSetApp;
        private ClientManage.UserControls.XPFlatButton btnNew;
        private XPFlatButton btnSetApp2;
    }
}
