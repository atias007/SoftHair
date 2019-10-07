namespace ClientManage.UserControls
{
    partial class SoftHairDTRange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoftHairDTRange));
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuToday = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWeek = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMonth = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuarter = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuYear = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHist = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuYesterday = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLastWeek = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLastMonth = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLastQuarter = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLastYear = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFeature = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTomorrow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNextWeek = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNextMonth = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNextQuarter = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNextYear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTillToday = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFromToday = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAlways = new System.Windows.Forms.ToolStripMenuItem();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new ClientManage.UserControls.SoftHairDtPicker();
            this.dtpFrom = new ClientManage.UserControls.SoftHairDtPicker();
            this.ctxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuToday,
            this.mnuWeek,
            this.mnuMonth,
            this.mnuQuarter,
            this.mnuYear,
            this.mnuHist,
            this.mnuFeature,
            this.toolStripMenuItem1,
            this.mnuTillToday,
            this.mnuFromToday,
            this.mnuAlways});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctxMenu.ShowImageMargin = false;
            this.ctxMenu.ShowItemToolTips = false;
            this.ctxMenu.Size = new System.Drawing.Size(144, 230);
            // 
            // mnuToday
            // 
            this.mnuToday.Name = "mnuToday";
            this.mnuToday.Size = new System.Drawing.Size(143, 22);
            this.mnuToday.Text = "היום";
            this.mnuToday.Click += new System.EventHandler(this.mnuToday_Click);
            // 
            // mnuWeek
            // 
            this.mnuWeek.Name = "mnuWeek";
            this.mnuWeek.Size = new System.Drawing.Size(143, 22);
            this.mnuWeek.Text = "השבוע";
            this.mnuWeek.Click += new System.EventHandler(this.mnuWeek_Click);
            // 
            // mnuMonth
            // 
            this.mnuMonth.Name = "mnuMonth";
            this.mnuMonth.Size = new System.Drawing.Size(143, 22);
            this.mnuMonth.Text = "החודש";
            this.mnuMonth.Click += new System.EventHandler(this.mnuMonth_Click);
            // 
            // mnuQuarter
            // 
            this.mnuQuarter.Name = "mnuQuarter";
            this.mnuQuarter.Size = new System.Drawing.Size(143, 22);
            this.mnuQuarter.Text = "הרבעון";
            this.mnuQuarter.Click += new System.EventHandler(this.mnuQuarter_Click);
            // 
            // mnuYear
            // 
            this.mnuYear.Name = "mnuYear";
            this.mnuYear.Size = new System.Drawing.Size(143, 22);
            this.mnuYear.Text = "השנה";
            this.mnuYear.Click += new System.EventHandler(this.mnuYear_Click);
            // 
            // mnuHist
            // 
            this.mnuHist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuHist.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuYesterday,
            this.mnuLastWeek,
            this.mnuLastMonth,
            this.mnuLastQuarter,
            this.mnuLastYear});
            this.mnuHist.Name = "mnuHist";
            this.mnuHist.Size = new System.Drawing.Size(143, 22);
            this.mnuHist.Text = "תקופות היסטוריות";
            // 
            // mnuYesterday
            // 
            this.mnuYesterday.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuYesterday.Name = "mnuYesterday";
            this.mnuYesterday.Size = new System.Drawing.Size(137, 22);
            this.mnuYesterday.Text = "אתמול";
            this.mnuYesterday.Click += new System.EventHandler(this.mnuYesterday_Click);
            // 
            // mnuLastWeek
            // 
            this.mnuLastWeek.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuLastWeek.Name = "mnuLastWeek";
            this.mnuLastWeek.Size = new System.Drawing.Size(137, 22);
            this.mnuLastWeek.Text = "שבוע שעבר";
            this.mnuLastWeek.Click += new System.EventHandler(this.mnuLastWeek_Click);
            // 
            // mnuLastMonth
            // 
            this.mnuLastMonth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuLastMonth.Name = "mnuLastMonth";
            this.mnuLastMonth.Size = new System.Drawing.Size(137, 22);
            this.mnuLastMonth.Text = "חודש שעבר";
            this.mnuLastMonth.Click += new System.EventHandler(this.mnuLastMonth_Click);
            // 
            // mnuLastQuarter
            // 
            this.mnuLastQuarter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuLastQuarter.Name = "mnuLastQuarter";
            this.mnuLastQuarter.Size = new System.Drawing.Size(137, 22);
            this.mnuLastQuarter.Text = "רבעון שעבר";
            this.mnuLastQuarter.Click += new System.EventHandler(this.mnuLastQuarter_Click);
            // 
            // mnuLastYear
            // 
            this.mnuLastYear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuLastYear.Name = "mnuLastYear";
            this.mnuLastYear.ShowShortcutKeys = false;
            this.mnuLastYear.Size = new System.Drawing.Size(137, 22);
            this.mnuLastYear.Text = "שנה שעברה";
            this.mnuLastYear.Click += new System.EventHandler(this.mnuLastYear_Click);
            // 
            // mnuFeature
            // 
            this.mnuFeature.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTomorrow,
            this.mnuNextWeek,
            this.mnuNextMonth,
            this.mnuNextQuarter,
            this.mnuNextYear});
            this.mnuFeature.Name = "mnuFeature";
            this.mnuFeature.Size = new System.Drawing.Size(143, 22);
            this.mnuFeature.Text = "תקופות עתידיות";
            // 
            // mnuTomorrow
            // 
            this.mnuTomorrow.Name = "mnuTomorrow";
            this.mnuTomorrow.Size = new System.Drawing.Size(130, 22);
            this.mnuTomorrow.Text = "מחר";
            this.mnuTomorrow.Click += new System.EventHandler(this.mnuTomorrow_Click);
            // 
            // mnuNextWeek
            // 
            this.mnuNextWeek.Name = "mnuNextWeek";
            this.mnuNextWeek.Size = new System.Drawing.Size(130, 22);
            this.mnuNextWeek.Text = "שבוע הבא";
            this.mnuNextWeek.Click += new System.EventHandler(this.mnuNextWeek_Click);
            // 
            // mnuNextMonth
            // 
            this.mnuNextMonth.Name = "mnuNextMonth";
            this.mnuNextMonth.Size = new System.Drawing.Size(130, 22);
            this.mnuNextMonth.Text = "חודש הבא";
            this.mnuNextMonth.Click += new System.EventHandler(this.mnuNextMonth_Click);
            // 
            // mnuNextQuarter
            // 
            this.mnuNextQuarter.Name = "mnuNextQuarter";
            this.mnuNextQuarter.Size = new System.Drawing.Size(130, 22);
            this.mnuNextQuarter.Text = "רבעון הבא";
            this.mnuNextQuarter.Click += new System.EventHandler(this.mnuNextQuarter_Click);
            // 
            // mnuNextYear
            // 
            this.mnuNextYear.Name = "mnuNextYear";
            this.mnuNextYear.Size = new System.Drawing.Size(130, 22);
            this.mnuNextYear.Text = "שנה הבאה";
            this.mnuNextYear.Click += new System.EventHandler(this.mnuNextYear_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(140, 6);
            // 
            // mnuTillToday
            // 
            this.mnuTillToday.Name = "mnuTillToday";
            this.mnuTillToday.Size = new System.Drawing.Size(143, 22);
            this.mnuTillToday.Text = "עד היום";
            this.mnuTillToday.Click += new System.EventHandler(this.mnuTillToday_Click);
            // 
            // mnuFromToday
            // 
            this.mnuFromToday.Name = "mnuFromToday";
            this.mnuFromToday.Size = new System.Drawing.Size(143, 22);
            this.mnuFromToday.Text = "מהיום והלאה";
            this.mnuFromToday.Click += new System.EventHandler(this.mnuFromToday_Click);
            // 
            // mnuAlways
            // 
            this.mnuAlways.Name = "mnuAlways";
            this.mnuAlways.Size = new System.Drawing.Size(143, 22);
            this.mnuAlways.Text = "מאז ומתמיד";
            this.mnuAlways.Click += new System.EventHandler(this.mnuAlways_Click);
            // 
            // lblPeriod
            // 
            this.lblPeriod.Image = ((System.Drawing.Image)(resources.GetObject("lblPeriod.Image")));
            this.lblPeriod.Location = new System.Drawing.Point(0, 0);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(21, 45);
            this.lblPeriod.TabIndex = 3;
            this.lblPeriod.MouseLeave += new System.EventHandler(this.lblPeriod_MouseLeave);
            this.lblPeriod.Paint += new System.Windows.Forms.PaintEventHandler(this.lblPeriod_Paint);
            this.lblPeriod.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblPeriod_MouseDown);
            this.lblPeriod.MouseEnter += new System.EventHandler(this.lblPeriod_MouseEnter);
            // 
            // dtpTo
            // 
            this.dtpTo.BackColor = System.Drawing.Color.White;
            this.dtpTo.DefaultValue = new System.DateTime(2008, 4, 30, 0, 0, 0, 0);
            this.dtpTo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.dtpTo.Location = new System.Drawing.Point(21, 25);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.NullText = "ללא תאריך";
            this.dtpTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpTo.Size = new System.Drawing.Size(249, 22);
            this.dtpTo.TabIndex = 1;
            this.dtpTo.Value = new System.DateTime(2008, 4, 30, 0, 0, 0, 0);
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // dtpFrom
            // 
            this.dtpFrom.BackColor = System.Drawing.Color.White;
            this.dtpFrom.DefaultValue = new System.DateTime(2008, 4, 30, 0, 0, 0, 0);
            this.dtpFrom.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.dtpFrom.Location = new System.Drawing.Point(21, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.NullText = "ללא תאריך";
            this.dtpFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpFrom.Size = new System.Drawing.Size(249, 22);
            this.dtpFrom.TabIndex = 0;
            this.dtpFrom.Value = new System.DateTime(2008, 4, 30, 0, 0, 0, 0);
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // SoftHairDTRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.lblPeriod);
            this.Name = "SoftHairDTRange";
            this.Size = new System.Drawing.Size(270, 71);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SoftHairDTRange_Paint);
            this.SizeChanged += new System.EventHandler(this.SoftHairDTRange_SizeChanged);
            this.ctxMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SoftHairDtPicker dtpFrom;
        private SoftHairDtPicker dtpTo;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuToday;
        private System.Windows.Forms.ToolStripMenuItem mnuWeek;
        private System.Windows.Forms.ToolStripMenuItem mnuMonth;
        private System.Windows.Forms.ToolStripMenuItem mnuQuarter;
        private System.Windows.Forms.ToolStripMenuItem mnuYear;
        private System.Windows.Forms.ToolStripMenuItem mnuHist;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuTillToday;
        private System.Windows.Forms.ToolStripMenuItem mnuFromToday;
        private System.Windows.Forms.ToolStripMenuItem mnuAlways;
        private System.Windows.Forms.ToolStripMenuItem mnuYesterday;
        private System.Windows.Forms.ToolStripMenuItem mnuLastWeek;
        private System.Windows.Forms.ToolStripMenuItem mnuLastMonth;
        private System.Windows.Forms.ToolStripMenuItem mnuLastYear;
        private System.Windows.Forms.ToolStripMenuItem mnuFeature;
        private System.Windows.Forms.ToolStripMenuItem mnuTomorrow;
        private System.Windows.Forms.ToolStripMenuItem mnuNextWeek;
        private System.Windows.Forms.ToolStripMenuItem mnuNextMonth;
        private System.Windows.Forms.ToolStripMenuItem mnuNextYear;
        private System.Windows.Forms.ToolStripMenuItem mnuLastQuarter;
        private System.Windows.Forms.ToolStripMenuItem mnuNextQuarter;
        private System.Windows.Forms.Label lblPeriod;
    }
}
