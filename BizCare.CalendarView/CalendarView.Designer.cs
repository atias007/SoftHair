namespace BizCare.Calendar
{
    partial class CalendarView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalendarView));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblDayCaption = new System.Windows.Forms.Label();
            this.pnlHours = new System.Windows.Forms.Panel();
            this.pnlWorkers = new System.Windows.Forms.Panel();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Cut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPic = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSendSms = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddAttedee = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMove = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCat1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCat2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCat3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCat4 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCat5 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCat6 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCat7 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCat8 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCat9 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnDiv1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDiv2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlHeader.SuspendLayout();
            this.ctxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.pnlHeader.Controls.Add(this.lblDayCaption);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(1, 1);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(582, 26);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlHeader_MouseDown);
            // 
            // lblDayCaption
            // 
            this.lblDayCaption.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDayCaption.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblDayCaption.ForeColor = System.Drawing.Color.Black;
            this.lblDayCaption.Location = new System.Drawing.Point(150, 0);
            this.lblDayCaption.Name = "lblDayCaption";
            this.lblDayCaption.Size = new System.Drawing.Size(432, 26);
            this.lblDayCaption.TabIndex = 1;
            this.lblDayCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDayCaption.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblDayCaption_MouseDown);
            // 
            // pnlHours
            // 
            this.pnlHours.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.pnlHours.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlHours.Location = new System.Drawing.Point(1, 27);
            this.pnlHours.Name = "pnlHours";
            this.pnlHours.Size = new System.Drawing.Size(50, 423);
            this.pnlHours.TabIndex = 2;
            this.pnlHours.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlHours_Paint);
            this.pnlHours.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlHours_MouseDown);
            // 
            // pnlWorkers
            // 
            this.pnlWorkers.AutoScroll = true;
            this.pnlWorkers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.pnlWorkers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWorkers.Location = new System.Drawing.Point(51, 27);
            this.pnlWorkers.Name = "pnlWorkers";
            this.pnlWorkers.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.pnlWorkers.Size = new System.Drawing.Size(532, 423);
            this.pnlWorkers.TabIndex = 3;
            this.pnlWorkers.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlWorkers_Paint);
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.mnuPaste,
            this.mnuEdit,
            this.mnuDelete,
            this.mnuCopy,
            this.mnu_Cut,
            this.mnuPic,
            this.mnuSendSms,
            this.mnuAddAttedee,
            this.mnuMove,
            this.mnuCategory,
            this.mnDiv1,
            this.mnuUpdate,
            this.mnuDiv2,
            this.mnuHistory});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctxMenu.Size = new System.Drawing.Size(196, 324);
            // 
            // mnuNew
            // 
            this.mnuNew.Image = global::BizCare.Calendar.Properties.Resources.new_small;
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.ShortcutKeyDisplayString = "Enter";
            this.mnuNew.Size = new System.Drawing.Size(195, 22);
            this.mnuNew.Tag = "X";
            this.mnuNew.Text = "חדש";
            this.mnuNew.Visible = false;
            // 
            // mnuPaste
            // 
            this.mnuPaste.Name = "mnuPaste";
            this.mnuPaste.Size = new System.Drawing.Size(195, 22);
            this.mnuPaste.Tag = "X";
            this.mnuPaste.Text = "הדבק";
            this.mnuPaste.Visible = false;
            this.mnuPaste.Click += new System.EventHandler(this.MnuPaste_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Image = ((System.Drawing.Image)(resources.GetObject("mnuEdit.Image")));
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.ShortcutKeyDisplayString = "F2";
            this.mnuEdit.Size = new System.Drawing.Size(195, 22);
            this.mnuEdit.Text = "תיאור התור";
            this.mnuEdit.Click += new System.EventHandler(this.MnuEdit_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = global::BizCare.Calendar.Properties.Resources.delete_small;
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.ShortcutKeyDisplayString = "Delete";
            this.mnuDelete.Size = new System.Drawing.Size(195, 22);
            this.mnuDelete.Text = "בטל";
            this.mnuDelete.Click += new System.EventHandler(this.MnuDelete_Click);
            // 
            // mnuCopy
            // 
            this.mnuCopy.Image = global::BizCare.Calendar.Properties.Resources.copy;
            this.mnuCopy.Name = "mnuCopy";
            this.mnuCopy.Size = new System.Drawing.Size(195, 22);
            this.mnuCopy.Text = "העתק";
            this.mnuCopy.Click += new System.EventHandler(this.MnuCopy_Click);
            // 
            // mnu_Cut
            // 
            this.mnu_Cut.Name = "mnu_Cut";
            this.mnu_Cut.Size = new System.Drawing.Size(195, 22);
            this.mnu_Cut.Text = "גזור";
            this.mnu_Cut.Click += new System.EventHandler(this.Mnu_Cut_Click);
            // 
            // mnuPic
            // 
            this.mnuPic.Image = ((System.Drawing.Image)(resources.GetObject("mnuPic.Image")));
            this.mnuPic.Name = "mnuPic";
            this.mnuPic.Size = new System.Drawing.Size(195, 22);
            this.mnuPic.Text = "צלם לאלבום לקוח";
            this.mnuPic.Click += new System.EventHandler(this.MnuPic_Click);
            // 
            // mnuSendSms
            // 
            this.mnuSendSms.Image = global::BizCare.Calendar.Properties.Resources.send_small;
            this.mnuSendSms.Name = "mnuSendSms";
            this.mnuSendSms.Size = new System.Drawing.Size(195, 22);
            this.mnuSendSms.Text = "שלח תזכורת SMS";
            this.mnuSendSms.Click += new System.EventHandler(this.MnuSendSms_Click);
            // 
            // mnuAddAttedee
            // 
            this.mnuAddAttedee.Name = "mnuAddAttedee";
            this.mnuAddAttedee.Size = new System.Drawing.Size(195, 22);
            this.mnuAddAttedee.Text = "שלח זימון ליומן הלקוח";
            this.mnuAddAttedee.Click += new System.EventHandler(this.mnuAddAttedee_Click);
            // 
            // mnuMove
            // 
            this.mnuMove.Image = ((System.Drawing.Image)(resources.GetObject("mnuMove.Image")));
            this.mnuMove.Name = "mnuMove";
            this.mnuMove.ShortcutKeyDisplayString = "";
            this.mnuMove.Size = new System.Drawing.Size(195, 22);
            this.mnuMove.Text = "העבר ל...";
            // 
            // mnuCategory
            // 
            this.mnuCategory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCat1,
            this.mnuCat2,
            this.mnuCat3,
            this.mnuCat4,
            this.mnuCat5,
            this.mnuCat6,
            this.mnuCat7,
            this.mnuCat8,
            this.mnuCat9});
            this.mnuCategory.Name = "mnuCategory";
            this.mnuCategory.Size = new System.Drawing.Size(195, 22);
            this.mnuCategory.Text = "קטגוריה";
            // 
            // mnuCat1
            // 
            this.mnuCat1.Image = global::BizCare.Calendar.Properties.Resources.mnuColor4;
            this.mnuCat1.Name = "mnuCat1";
            this.mnuCat1.Size = new System.Drawing.Size(192, 22);
            this.mnuCat1.Tag = "0";
            this.mnuCat1.Text = "תכלת (ברירת מחדל)";
            this.mnuCat1.Click += new System.EventHandler(this.MnuCat_Click);
            // 
            // mnuCat2
            // 
            this.mnuCat2.Image = global::BizCare.Calendar.Properties.Resources.mnuColor1;
            this.mnuCat2.Name = "mnuCat2";
            this.mnuCat2.Size = new System.Drawing.Size(192, 22);
            this.mnuCat2.Tag = "-1";
            this.mnuCat2.Text = "כתום";
            this.mnuCat2.Click += new System.EventHandler(this.MnuCat_Click);
            // 
            // mnuCat3
            // 
            this.mnuCat3.Image = global::BizCare.Calendar.Properties.Resources.mnuColor3;
            this.mnuCat3.Name = "mnuCat3";
            this.mnuCat3.Size = new System.Drawing.Size(192, 22);
            this.mnuCat3.Tag = "1";
            this.mnuCat3.Text = "סגול";
            this.mnuCat3.Click += new System.EventHandler(this.MnuCat_Click);
            // 
            // mnuCat4
            // 
            this.mnuCat4.Image = global::BizCare.Calendar.Properties.Resources.mnuColor2;
            this.mnuCat4.Name = "mnuCat4";
            this.mnuCat4.Size = new System.Drawing.Size(192, 22);
            this.mnuCat4.Tag = "2";
            this.mnuCat4.Text = "אדום";
            this.mnuCat4.Click += new System.EventHandler(this.MnuCat_Click);
            // 
            // mnuCat5
            // 
            this.mnuCat5.Image = global::BizCare.Calendar.Properties.Resources.mnuColor5;
            this.mnuCat5.Name = "mnuCat5";
            this.mnuCat5.Size = new System.Drawing.Size(192, 22);
            this.mnuCat5.Tag = "3";
            this.mnuCat5.Text = "ירוק";
            this.mnuCat5.Click += new System.EventHandler(this.MnuCat_Click);
            // 
            // mnuCat6
            // 
            this.mnuCat6.Image = global::BizCare.Calendar.Properties.Resources.mnuColor9;
            this.mnuCat6.Name = "mnuCat6";
            this.mnuCat6.Size = new System.Drawing.Size(192, 22);
            this.mnuCat6.Tag = "4";
            this.mnuCat6.Text = "כחול כהה";
            this.mnuCat6.Click += new System.EventHandler(this.MnuCat_Click);
            // 
            // mnuCat7
            // 
            this.mnuCat7.Image = global::BizCare.Calendar.Properties.Resources.mnuColor7;
            this.mnuCat7.Name = "mnuCat7";
            this.mnuCat7.Size = new System.Drawing.Size(192, 22);
            this.mnuCat7.Tag = "5";
            this.mnuCat7.Text = "אפור";
            this.mnuCat7.Click += new System.EventHandler(this.MnuCat_Click);
            // 
            // mnuCat8
            // 
            this.mnuCat8.Image = global::BizCare.Calendar.Properties.Resources.mnuColor8;
            this.mnuCat8.Name = "mnuCat8";
            this.mnuCat8.Size = new System.Drawing.Size(192, 22);
            this.mnuCat8.Tag = "6";
            this.mnuCat8.Text = "אפור כהה";
            this.mnuCat8.Click += new System.EventHandler(this.MnuCat_Click);
            // 
            // mnuCat9
            // 
            this.mnuCat9.Image = global::BizCare.Calendar.Properties.Resources.mnuColor6;
            this.mnuCat9.Name = "mnuCat9";
            this.mnuCat9.Size = new System.Drawing.Size(192, 22);
            this.mnuCat9.Tag = "7";
            this.mnuCat9.Text = "תורכיז";
            this.mnuCat9.Click += new System.EventHandler(this.MnuCat_Click);
            // 
            // mnDiv1
            // 
            this.mnDiv1.Name = "mnDiv1";
            this.mnDiv1.Size = new System.Drawing.Size(192, 6);
            // 
            // mnuUpdate
            // 
            this.mnuUpdate.Image = ((System.Drawing.Image)(resources.GetObject("mnuUpdate.Image")));
            this.mnuUpdate.Name = "mnuUpdate";
            this.mnuUpdate.Size = new System.Drawing.Size(195, 22);
            this.mnuUpdate.Text = "עדכן פרטים";
            this.mnuUpdate.Click += new System.EventHandler(this.MnuUpdate_Click);
            // 
            // mnuDiv2
            // 
            this.mnuDiv2.Name = "mnuDiv2";
            this.mnuDiv2.Size = new System.Drawing.Size(192, 6);
            // 
            // mnuHistory
            // 
            this.mnuHistory.Name = "mnuHistory";
            this.mnuHistory.Size = new System.Drawing.Size(195, 22);
            this.mnuHistory.Text = "היסטוריה";
            this.mnuHistory.Click += new System.EventHandler(this.mnuHistory_Click);
            // 
            // CalendarView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlWorkers);
            this.Controls.Add(this.pnlHours);
            this.Controls.Add(this.pnlHeader);
            this.Name = "CalendarView";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(584, 451);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CalendarView_Paint);
            this.Enter += new System.EventHandler(this.CalendarView_Enter);
            this.pnlHeader.ResumeLayout(false);
            this.ctxMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlHours;
        private System.Windows.Forms.Label lblDayCaption;
        private System.Windows.Forms.Panel pnlWorkers;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuNew;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuMove;
        private System.Windows.Forms.ToolStripMenuItem mnuPic;
        private System.Windows.Forms.ToolStripMenuItem mnuCategory;
        private System.Windows.Forms.ToolStripMenuItem mnuCat1;
        private System.Windows.Forms.ToolStripMenuItem mnuCat2;
        private System.Windows.Forms.ToolStripMenuItem mnuCat3;
        private System.Windows.Forms.ToolStripMenuItem mnuCat4;
        private System.Windows.Forms.ToolStripMenuItem mnuCat5;
        private System.Windows.Forms.ToolStripMenuItem mnuCat6;
        private System.Windows.Forms.ToolStripMenuItem mnuCat7;
        private System.Windows.Forms.ToolStripMenuItem mnuCat8;
        private System.Windows.Forms.ToolStripMenuItem mnuCat9;
        private System.Windows.Forms.ToolStripSeparator mnDiv1;
        private System.Windows.Forms.ToolStripMenuItem mnuUpdate;
        private System.Windows.Forms.ToolStripMenuItem mnuSendSms;
        private System.Windows.Forms.ToolStripMenuItem mnuCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuPaste;
        private System.Windows.Forms.ToolStripMenuItem mnu_Cut;
        private System.Windows.Forms.ToolStripMenuItem mnuAddAttedee;
        private System.Windows.Forms.ToolStripSeparator mnuDiv2;
        private System.Windows.Forms.ToolStripMenuItem mnuHistory;
    }
}
