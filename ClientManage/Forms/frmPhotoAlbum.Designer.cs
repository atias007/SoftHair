namespace ClientManage.Forms
{
    partial class FormPhotoAlbum
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPhotoAlbum));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tbbNew = new System.Windows.Forms.ToolStripButton();
            this.tbbUpdate = new System.Windows.Forms.ToolStripButton();
            this.tbbDelete = new System.Windows.Forms.ToolStripButton();
            this.tbbSetToCard = new System.Windows.Forms.ToolStripButton();
            this.tbbView = new System.Windows.Forms.ToolStripSplitButton();
            this.mnuViewIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewFilm = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbPrint = new System.Windows.Forms.ToolStripButton();
            this.tbbEmail = new System.Windows.Forms.ToolStripButton();
            this.tbbSendSMS = new System.Windows.Forms.ToolStripButton();
            this.splitPhone = new System.Windows.Forms.ToolStripSplitButton();
            this.tbbClose = new System.Windows.Forms.ToolStripButton();
            this.tssClose = new System.Windows.Forms.ToolStripSeparator();
            this.tbbNext = new System.Windows.Forms.ToolStripButton();
            this.tbbPrev = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.informationBar1 = new ClientManage.UserControls.InformationBar();
            this.lblNoItems = new System.Windows.Forms.Label();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackgroundImage = global::ClientManage.Properties.Resources.toolbar_bg;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbNew,
            this.tbbUpdate,
            this.tbbDelete,
            this.tbbSetToCard,
            this.tbbView,
            this.toolStripSeparator1,
            this.tbbPrint,
            this.tbbEmail,
            this.tbbSendSMS,
            this.splitPhone,
            this.tbbClose,
            this.tssClose,
            this.tbbNext,
            this.tbbPrev,
            this.toolStripSeparator2});
            this.toolStrip.Location = new System.Drawing.Point(8, 28);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1008, 42);
            this.toolStrip.TabIndex = 48;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tbbNew
            // 
            this.tbbNew.AutoToolTip = false;
            this.tbbNew.Image = ((System.Drawing.Image)(resources.GetObject("tbbNew.Image")));
            this.tbbNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbNew.Name = "tbbNew";
            this.tbbNew.Size = new System.Drawing.Size(97, 39);
            this.tbbNew.Text = "הוסף תמונה";
            this.tbbNew.ToolTipText = "הוספת תמונה חדשה ללקוח";
            this.tbbNew.Click += new System.EventHandler(this.tbbNew_Click);
            // 
            // tbbUpdate
            // 
            this.tbbUpdate.AutoToolTip = false;
            this.tbbUpdate.Image = global::ClientManage.Properties.Resources.tb_edit2;
            this.tbbUpdate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbUpdate.Name = "tbbUpdate";
            this.tbbUpdate.Size = new System.Drawing.Size(97, 39);
            this.tbbUpdate.Text = "עדכן פרטים";
            this.tbbUpdate.ToolTipText = "עדכון פרטי התמונה המסומנת";
            this.tbbUpdate.Click += new System.EventHandler(this.tbbUpdate_Click);
            // 
            // tbbDelete
            // 
            this.tbbDelete.AutoToolTip = false;
            this.tbbDelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbDelete.ForeColor = System.Drawing.Color.SaddleBrown;
            this.tbbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tbbDelete.Image")));
            this.tbbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbDelete.Name = "tbbDelete";
            this.tbbDelete.Size = new System.Drawing.Size(93, 39);
            this.tbbDelete.Text = "מחק תמונה";
            this.tbbDelete.ToolTipText = "מחק תמונה מאלבום התמונות";
            this.tbbDelete.Click += new System.EventHandler(this.tbbDelete_Click);
            // 
            // tbbSetToCard
            // 
            this.tbbSetToCard.AutoToolTip = false;
            this.tbbSetToCard.Image = ((System.Drawing.Image)(resources.GetObject("tbbSetToCard.Image")));
            this.tbbSetToCard.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbSetToCard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbSetToCard.Name = "tbbSetToCard";
            this.tbbSetToCard.Size = new System.Drawing.Size(109, 39);
            this.tbbSetToCard.Text = "העבר לכרטיס";
            this.tbbSetToCard.ToolTipText = "העבר את התמונה המסומנת לכרטיס הלקוח";
            this.tbbSetToCard.Click += new System.EventHandler(this.tbbSetToCard_Click);
            // 
            // tbbView
            // 
            this.tbbView.AutoToolTip = false;
            this.tbbView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewIcons,
            this.mnuViewFilm,
            this.mnuViewDetails});
            this.tbbView.Image = global::ClientManage.Properties.Resources.view_icons;
            this.tbbView.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbView.Name = "tbbView";
            this.tbbView.Size = new System.Drawing.Size(80, 39);
            this.tbbView.Text = "תצוגה";
            this.tbbView.ToolTipText = "מעבר בין מצבי התצוגה";
            this.tbbView.ButtonClick += new System.EventHandler(this.tbbView_ButtonClick);
            // 
            // mnuViewIcons
            // 
            this.mnuViewIcons.Image = ((System.Drawing.Image)(resources.GetObject("mnuViewIcons.Image")));
            this.mnuViewIcons.Name = "mnuViewIcons";
            this.mnuViewIcons.Size = new System.Drawing.Size(115, 22);
            this.mnuViewIcons.Text = "סמלים";
            this.mnuViewIcons.Click += new System.EventHandler(this.mnuViewIcons_Click);
            // 
            // mnuViewFilm
            // 
            this.mnuViewFilm.Image = ((System.Drawing.Image)(resources.GetObject("mnuViewFilm.Image")));
            this.mnuViewFilm.Name = "mnuViewFilm";
            this.mnuViewFilm.Size = new System.Drawing.Size(115, 22);
            this.mnuViewFilm.Text = "שקופיות";
            this.mnuViewFilm.Click += new System.EventHandler(this.mnuViewFilm_Click);
            // 
            // mnuViewDetails
            // 
            this.mnuViewDetails.Image = ((System.Drawing.Image)(resources.GetObject("mnuViewDetails.Image")));
            this.mnuViewDetails.Name = "mnuViewDetails";
            this.mnuViewDetails.Size = new System.Drawing.Size(115, 22);
            this.mnuViewDetails.Text = "פרטים";
            this.mnuViewDetails.Click += new System.EventHandler(this.mnuViewDetails_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 42);
            // 
            // tbbPrint
            // 
            this.tbbPrint.AutoSize = false;
            this.tbbPrint.AutoToolTip = false;
            this.tbbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbPrint.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tbbPrint.Image")));
            this.tbbPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbPrint.Name = "tbbPrint";
            this.tbbPrint.Size = new System.Drawing.Size(35, 39);
            this.tbbPrint.Text = "הדפס";
            this.tbbPrint.ToolTipText = "הדפסת כל התמונות באלבום";
            this.tbbPrint.Click += new System.EventHandler(this.tbbPrint_Click);
            // 
            // tbbEmail
            // 
            this.tbbEmail.AutoSize = false;
            this.tbbEmail.AutoToolTip = false;
            this.tbbEmail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbEmail.Image = ((System.Drawing.Image)(resources.GetObject("tbbEmail.Image")));
            this.tbbEmail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbEmail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbEmail.Name = "tbbEmail";
            this.tbbEmail.Size = new System.Drawing.Size(35, 39);
            this.tbbEmail.Text = "שלח דוא\"ל";
            this.tbbEmail.ToolTipText = "שלח דוא\"ל";
            this.tbbEmail.Click += new System.EventHandler(this.tbbEmail_Click);
            // 
            // tbbSendSMS
            // 
            this.tbbSendSMS.AutoSize = false;
            this.tbbSendSMS.AutoToolTip = false;
            this.tbbSendSMS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbSendSMS.Image = ((System.Drawing.Image)(resources.GetObject("tbbSendSMS.Image")));
            this.tbbSendSMS.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbSendSMS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbSendSMS.Name = "tbbSendSMS";
            this.tbbSendSMS.Size = new System.Drawing.Size(35, 39);
            this.tbbSendSMS.Text = "שלח הודעת SMS";
            this.tbbSendSMS.ToolTipText = "שלח הודעת SMS";
            this.tbbSendSMS.Click += new System.EventHandler(this.tbbSendSMS_Click);
            // 
            // splitPhone
            // 
            this.splitPhone.AutoToolTip = false;
            this.splitPhone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.splitPhone.Image = ((System.Drawing.Image)(resources.GetObject("splitPhone.Image")));
            this.splitPhone.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.splitPhone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.splitPhone.Name = "splitPhone";
            this.splitPhone.Size = new System.Drawing.Size(40, 39);
            this.splitPhone.Text = "חייג";
            this.splitPhone.ToolTipText = "חיוג אל איש הקשר המסומן";
            this.splitPhone.ButtonClick += new System.EventHandler(this.splitPhone_ButtonClick);
            // 
            // tbbClose
            // 
            this.tbbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbbClose.AutoSize = false;
            this.tbbClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbClose.Image = ((System.Drawing.Image)(resources.GetObject("tbbClose.Image")));
            this.tbbClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbClose.Name = "tbbClose";
            this.tbbClose.Size = new System.Drawing.Size(70, 39);
            this.tbbClose.Tag = "Popup";
            this.tbbClose.Text = "סגור";
            this.tbbClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbbClose.ToolTipText = "סגור חלון  (Esc)";
            this.tbbClose.Click += new System.EventHandler(this.tbbClose_Click);
            // 
            // tssClose
            // 
            this.tssClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tssClose.Name = "tssClose";
            this.tssClose.Size = new System.Drawing.Size(6, 42);
            this.tssClose.Tag = "Popup";
            // 
            // tbbNext
            // 
            this.tbbNext.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbbNext.AutoSize = false;
            this.tbbNext.AutoToolTip = false;
            this.tbbNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbNext.Image = global::ClientManage.Properties.Resources.prev;
            this.tbbNext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbNext.Margin = new System.Windows.Forms.Padding(4, 1, 0, 2);
            this.tbbNext.Name = "tbbNext";
            this.tbbNext.Size = new System.Drawing.Size(35, 39);
            this.tbbNext.ToolTipText = "תמונה הבאה";
            this.tbbNext.Click += new System.EventHandler(this.tbbNext_Click);
            // 
            // tbbPrev
            // 
            this.tbbPrev.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbbPrev.AutoSize = false;
            this.tbbPrev.AutoToolTip = false;
            this.tbbPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbPrev.Image = global::ClientManage.Properties.Resources.next;
            this.tbbPrev.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbPrev.Name = "tbbPrev";
            this.tbbPrev.Size = new System.Drawing.Size(35, 39);
            this.tbbPrev.ToolTipText = "תמונה קודמת";
            this.tbbPrev.Click += new System.EventHandler(this.tbbPrev_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 42);
            // 
            // informationBar1
            // 
            this.informationBar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("informationBar1.BackgroundImage")));
            this.informationBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.informationBar1.Image = ((System.Drawing.Image)(resources.GetObject("informationBar1.Image")));
            this.informationBar1.LabelForeColor = System.Drawing.Color.DarkGreen;
            this.informationBar1.LabelImage = null;
            this.informationBar1.LabelText = "";
            this.informationBar1.LabelVisible = false;
            this.informationBar1.Location = new System.Drawing.Point(8, 70);
            this.informationBar1.Name = "informationBar1";
            this.informationBar1.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.informationBar1.PanelText = "InformationPanel";
            this.informationBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.informationBar1.Size = new System.Drawing.Size(1008, 28);
            this.informationBar1.TabIndex = 50;
            // 
            // lblNoItems
            // 
            this.lblNoItems.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblNoItems.ForeColor = System.Drawing.Color.DimGray;
            this.lblNoItems.Location = new System.Drawing.Point(291, 352);
            this.lblNoItems.Name = "lblNoItems";
            this.lblNoItems.Size = new System.Drawing.Size(443, 65);
            this.lblNoItems.TabIndex = 53;
            this.lblNoItems.Text = "לא נמצאו תמונות באלבום הלקוח\r\nלחץ \"הוסף תמונה\" להוספת תמונה חדשה לאלבום";
            this.lblNoItems.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNoItems.Visible = false;
            // 
            // FormPhotoAlbum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CanDragForm = false;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.CloseFormByEsc = true;
            this.Controls.Add(this.lblNoItems);
            this.Controls.Add(this.informationBar1);
            this.Controls.Add(this.toolStrip);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormPhotoAlbum";
            this.Padding = new System.Windows.Forms.Padding(8, 28, 8, 8);
            this.ShowMaximizeControl = false;
            this.Text = "אלבום תמונות";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPhotoAlbum_Load);
            this.SizeChanged += new System.EventHandler(this.frmPhotoAlbum_SizeChanged);
            this.RequestForClose += new System.EventHandler(this.frmPhotoAlbum_RequestForClose);
            this.Controls.SetChildIndex(this.toolStrip, 0);
            this.Controls.SetChildIndex(this.informationBar1, 0);
            this.Controls.SetChildIndex(this.lblNoItems, 0);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tbbNew;
        private System.Windows.Forms.ToolStripButton tbbUpdate;
        private System.Windows.Forms.ToolStripButton tbbDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbbPrint;
        private System.Windows.Forms.ToolStripButton tbbEmail;
        private System.Windows.Forms.ToolStripButton tbbSendSMS;
        private System.Windows.Forms.ToolStripSplitButton splitPhone;
        private System.Windows.Forms.ToolStripButton tbbNext;
        private System.Windows.Forms.ToolStripButton tbbPrev;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tbbSetToCard;
        private System.Windows.Forms.ToolStripSplitButton tbbView;
        private System.Windows.Forms.ToolStripMenuItem mnuViewIcons;
        private System.Windows.Forms.ToolStripMenuItem mnuViewDetails;
        private System.Windows.Forms.ToolStripMenuItem mnuViewFilm;
        private ClientManage.UserControls.InformationBar informationBar1;
        private System.Windows.Forms.ToolStripButton tbbClose;
        private System.Windows.Forms.ToolStripSeparator tssClose;
        private System.Windows.Forms.Label lblNoItems;
    }
}