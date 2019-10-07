namespace ClientManage.Forms
{
    partial class FormPhotoDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPhotoDetails));
            this.informationBar1 = new ClientManage.UserControls.InformationBar();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tbbClose = new System.Windows.Forms.ToolStripButton();
            this.tssClose = new System.Windows.Forms.ToolStripSeparator();
            this.tbbNext = new System.Windows.Forms.ToolStripButton();
            this.tbbPrev = new System.Windows.Forms.ToolStripButton();
            this.tbbSep = new System.Windows.Forms.ToolStripSeparator();
            this.tbbSave = new System.Windows.Forms.ToolStripButton();
            this.tbbPrint = new System.Windows.Forms.ToolStripButton();
            this.tbbDelete = new System.Windows.Forms.ToolStripButton();
            this.tbbWebCam = new System.Windows.Forms.ToolStripSplitButton();
            this.mnuWebCam = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tbbTakePic = new System.Windows.Forms.ToolStripButton();
            this.tbbFreezPic = new System.Windows.Forms.ToolStripButton();
            this.tbbCancelPic = new System.Windows.Forms.ToolStripButton();
            this.picView = new System.Windows.Forms.PictureBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDateCreate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNoImage = new System.Windows.Forms.Label();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.lblCalendar = new System.Windows.Forms.Label();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picView)).BeginInit();
            this.SuspendLayout();
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
            this.informationBar1.Size = new System.Drawing.Size(654, 28);
            this.informationBar1.TabIndex = 52;
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackgroundImage = global::ClientManage.Properties.Resources.toolbar_bg;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbClose,
            this.tssClose,
            this.tbbNext,
            this.tbbPrev,
            this.tbbSep,
            this.tbbSave,
            this.tbbPrint,
            this.tbbDelete,
            this.tbbWebCam,
            this.tbbTakePic,
            this.tbbFreezPic,
            this.tbbCancelPic});
            this.toolStrip.Location = new System.Drawing.Point(8, 28);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(654, 42);
            this.toolStrip.TabIndex = 51;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tbbClose
            // 
            this.tbbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbbClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbClose.Image = ((System.Drawing.Image)(resources.GetObject("tbbClose.Image")));
            this.tbbClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbClose.Name = "tbbClose";
            this.tbbClose.Size = new System.Drawing.Size(125, 39);
            this.tbbClose.Tag = "Popup";
            this.tbbClose.Text = "סגור / בטל עדכון";
            this.tbbClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbbClose.ToolTipText = "סגירת החלון וביטול כל השינויים  (Esc)";
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
            // tbbSep
            // 
            this.tbbSep.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbbSep.Name = "tbbSep";
            this.tbbSep.Size = new System.Drawing.Size(6, 42);
            // 
            // tbbSave
            // 
            this.tbbSave.AutoToolTip = false;
            this.tbbSave.Image = global::ClientManage.Properties.Resources.Floppy;
            this.tbbSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbSave.Name = "tbbSave";
            this.tbbSave.Size = new System.Drawing.Size(62, 39);
            this.tbbSave.Text = "שמור";
            this.tbbSave.ToolTipText = "שמירה וסגירת החלון  (Ctrl + S)";
            this.tbbSave.Click += new System.EventHandler(this.tbbSave_Click);
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
            this.tbbPrint.ToolTipText = "הדפסת פרטי התמונה הנוכחית";
            this.tbbPrint.Click += new System.EventHandler(this.tbbPrint_Click);
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
            this.tbbDelete.Size = new System.Drawing.Size(93, 39);
            this.tbbDelete.Text = "מחק תמונה";
            this.tbbDelete.ToolTipText = "מחיקת התמונה";
            this.tbbDelete.Click += new System.EventHandler(this.tbbDelete_Click);
            // 
            // tbbWebCam
            // 
            this.tbbWebCam.AutoToolTip = false;
            this.tbbWebCam.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuWebCam,
            this.mnuFile});
            this.tbbWebCam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbWebCam.Image = ((System.Drawing.Image)(resources.GetObject("tbbWebCam.Image")));
            this.tbbWebCam.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbWebCam.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbWebCam.Name = "tbbWebCam";
            this.tbbWebCam.Size = new System.Drawing.Size(91, 39);
            this.tbbWebCam.Text = "תמונה...";
            this.tbbWebCam.ToolTipText = "הוספת תמונה ממצלמה או מקובץ";
            this.tbbWebCam.ButtonClick += new System.EventHandler(this.tbbWebCam_ButtonClick);
            // 
            // mnuWebCam
            // 
            this.mnuWebCam.Image = ((System.Drawing.Image)(resources.GetObject("mnuWebCam.Image")));
            this.mnuWebCam.Name = "mnuWebCam";
            this.mnuWebCam.Size = new System.Drawing.Size(167, 22);
            this.mnuWebCam.Text = "תמונה ממצלמה...";
            this.mnuWebCam.Click += new System.EventHandler(this.mnuWebCam_Click);
            // 
            // mnuFile
            // 
            this.mnuFile.Image = ((System.Drawing.Image)(resources.GetObject("mnuFile.Image")));
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(167, 22);
            this.mnuFile.Text = "תמונה מקובץ...";
            this.mnuFile.Click += new System.EventHandler(this.mnuFile_Click);
            // 
            // tbbTakePic
            // 
            this.tbbTakePic.AutoToolTip = false;
            this.tbbTakePic.Image = ((System.Drawing.Image)(resources.GetObject("tbbTakePic.Image")));
            this.tbbTakePic.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbTakePic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbTakePic.Name = "tbbTakePic";
            this.tbbTakePic.Size = new System.Drawing.Size(57, 39);
            this.tbbTakePic.Text = "צלם";
            this.tbbTakePic.ToolTipText = "לכידת התמונה המוצגת והעברתה אל האלבום";
            this.tbbTakePic.Visible = false;
            this.tbbTakePic.Click += new System.EventHandler(this.tbbTakePic_Click);
            // 
            // tbbFreezPic
            // 
            this.tbbFreezPic.AutoToolTip = false;
            this.tbbFreezPic.Image = ((System.Drawing.Image)(resources.GetObject("tbbFreezPic.Image")));
            this.tbbFreezPic.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbFreezPic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbFreezPic.Name = "tbbFreezPic";
            this.tbbFreezPic.Size = new System.Drawing.Size(65, 39);
            this.tbbFreezPic.Text = "הקפא";
            this.tbbFreezPic.ToolTipText = "הקפא את התמונה המוצגת מהמצלמה";
            this.tbbFreezPic.Visible = false;
            this.tbbFreezPic.Click += new System.EventHandler(this.tbbFreezPic_Click);
            // 
            // tbbCancelPic
            // 
            this.tbbCancelPic.AutoToolTip = false;
            this.tbbCancelPic.Image = global::ClientManage.Properties.Resources.cancel;
            this.tbbCancelPic.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbbCancelPic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbCancelPic.Name = "tbbCancelPic";
            this.tbbCancelPic.Size = new System.Drawing.Size(58, 39);
            this.tbbCancelPic.Text = "בטל";
            this.tbbCancelPic.ToolTipText = "ביטול הצילום מהמצלמה";
            this.tbbCancelPic.Visible = false;
            this.tbbCancelPic.Click += new System.EventHandler(this.tbbCancelPic_Click);
            // 
            // picView
            // 
            this.picView.BackColor = System.Drawing.Color.White;
            this.picView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picView.Location = new System.Drawing.Point(15, 105);
            this.picView.Name = "picView";
            this.picView.Size = new System.Drawing.Size(640, 480);
            this.picView.TabIndex = 53;
            this.picView.TabStop = false;
            // 
            // txtSubject
            // 
            this.txtSubject.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtSubject.Location = new System.Drawing.Point(254, 592);
            this.txtSubject.MaxLength = 50;
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(352, 22);
            this.txtSubject.TabIndex = 55;
            this.txtSubject.Leave += new System.EventHandler(this.txtRemark_Leave);
            this.txtSubject.Enter += new System.EventHandler(this.txtRemark_Enter);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(600, 595);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 54;
            this.label1.Text = "תיאור:";
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtRemark.Location = new System.Drawing.Point(91, 621);
            this.txtRemark.MaxLength = 255;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemark.Size = new System.Drawing.Size(515, 54);
            this.txtRemark.TabIndex = 57;
            this.txtRemark.Leave += new System.EventHandler(this.txtRemark_Leave);
            this.txtRemark.Enter += new System.EventHandler(this.txtRemark_Enter);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(605, 625);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 56;
            this.label2.Text = "הערות:";
            // 
            // txtDateCreate
            // 
            this.txtDateCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(227)))), ((int)(((byte)(233)))));
            this.txtDateCreate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtDateCreate.Location = new System.Drawing.Point(15, 592);
            this.txtDateCreate.MaxLength = 50;
            this.txtDateCreate.Name = "txtDateCreate";
            this.txtDateCreate.ReadOnly = true;
            this.txtDateCreate.Size = new System.Drawing.Size(152, 22);
            this.txtDateCreate.TabIndex = 59;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(157, 595);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 58;
            this.label3.Text = "תאריך צילום:";
            // 
            // lblNoImage
            // 
            this.lblNoImage.AutoSize = true;
            this.lblNoImage.BackColor = System.Drawing.Color.White;
            this.lblNoImage.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblNoImage.ForeColor = System.Drawing.Color.DimGray;
            this.lblNoImage.Location = new System.Drawing.Point(63, 323);
            this.lblNoImage.Name = "lblNoImage";
            this.lblNoImage.Size = new System.Drawing.Size(545, 44);
            this.lblNoImage.TabIndex = 60;
            this.lblNoImage.Text = "לחץ על הלחצן \"תמונה...\" על מנת להפעיל את המצלמה.\r\nלאפשרויות טעינת תמונה נוספות לח" +
                "ץ על סמל החץ הצמוד ללחצן \"תמונה...\"";
            this.lblNoImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNoImage.Visible = false;
            // 
            // dlgOpenFile
            // 
            this.dlgOpenFile.RestoreDirectory = true;
            // 
            // lblCalendar
            // 
            this.lblCalendar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCalendar.Image = ((System.Drawing.Image)(resources.GetObject("lblCalendar.Image")));
            this.lblCalendar.Location = new System.Drawing.Point(15, 619);
            this.lblCalendar.Name = "lblCalendar";
            this.lblCalendar.Size = new System.Drawing.Size(70, 56);
            this.lblCalendar.TabIndex = 61;
            this.lblCalendar.Visible = false;
            this.lblCalendar.Click += new System.EventHandler(this.lblCalendar_Click);
            // 
            // FormPhotoDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(670, 690);
            this.CloseFormByEsc = true;
            this.Controls.Add(this.lblCalendar);
            this.Controls.Add(this.lblNoImage);
            this.Controls.Add(this.txtDateCreate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picView);
            this.Controls.Add(this.informationBar1);
            this.Controls.Add(this.toolStrip);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(670, 690);
            this.Name = "FormPhotoDetails";
            this.Padding = new System.Windows.Forms.Padding(8, 28, 8, 8);
            this.ShowMaximizeControl = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "עדכון וצפייה בתמונת לקוח";
            this.Load += new System.EventHandler(this.frmPhotoDetails_Load);
            this.RequestForClose += new System.EventHandler(this.frmPhotoDetails_RequestForClose);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPhotoDetails_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPhotoDetails_KeyDown);
            this.Controls.SetChildIndex(this.toolStrip, 0);
            this.Controls.SetChildIndex(this.informationBar1, 0);
            this.Controls.SetChildIndex(this.picView, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtSubject, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtRemark, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtDateCreate, 0);
            this.Controls.SetChildIndex(this.lblNoImage, 0);
            this.Controls.SetChildIndex(this.lblCalendar, 0);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ClientManage.UserControls.InformationBar informationBar1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tbbClose;
        private System.Windows.Forms.ToolStripSeparator tssClose;
        private System.Windows.Forms.ToolStripButton tbbNext;
        private System.Windows.Forms.ToolStripButton tbbPrev;
        private System.Windows.Forms.ToolStripSeparator tbbSep;
        private System.Windows.Forms.PictureBox picView;
        private System.Windows.Forms.ToolStripButton tbbPrint;
        private System.Windows.Forms.ToolStripButton tbbSave;
        private System.Windows.Forms.ToolStripButton tbbDelete;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDateCreate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripSplitButton tbbWebCam;
        private System.Windows.Forms.ToolStripMenuItem mnuWebCam;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripButton tbbTakePic;
        private System.Windows.Forms.ToolStripButton tbbFreezPic;
        private System.Windows.Forms.ToolStripButton tbbCancelPic;
        private System.Windows.Forms.Label lblNoImage;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.Label lblCalendar;
    }
}
