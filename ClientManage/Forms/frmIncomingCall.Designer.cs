using ClientManage.UserControls;
namespace ClientManage.Forms
{
    partial class FormIncomingCall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIncomingCall));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCallerId = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlCallers = new System.Windows.Forms.Panel();
            this.IcId1 = new ClientManage.UserControls.IncomeCallerId();
            this.pnlCallerId = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlCallLog = new System.Windows.Forms.Panel();
            this.grdClients = new System.Windows.Forms.DataGridView();
            this.clmImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.clmPicture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPhoneNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDateCall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlCallers.SuspendLayout();
            this.pnlCallerId.SuspendLayout();
            this.pnlCallLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdClients)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(97, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(147, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "מתקשר...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCallerId
            // 
            this.lblCallerId.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCallerId.ForeColor = System.Drawing.Color.Maroon;
            this.lblCallerId.Location = new System.Drawing.Point(244, 9);
            this.lblCallerId.Name = "lblCallerId";
            this.lblCallerId.Size = new System.Drawing.Size(321, 56);
            this.lblCallerId.TabIndex = 2;
            this.lblCallerId.Text = "מס\' לא מזוהה";
            this.lblCallerId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnClose.Location = new System.Drawing.Point(11, 470);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 35);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "סגור חלון";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // pnlCallers
            // 
            this.pnlCallers.AutoScroll = true;
            this.pnlCallers.Controls.Add(this.IcId1);
            this.pnlCallers.Location = new System.Drawing.Point(12, 109);
            this.pnlCallers.Name = "pnlCallers";
            this.pnlCallers.Size = new System.Drawing.Size(557, 144);
            this.pnlCallers.TabIndex = 6;
            // 
            // IcId1
            // 
            this.IcId1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.IcId1.Location = new System.Drawing.Point(23, 4);
            this.IcId1.Name = "IcId1";
            this.IcId1.PhoneNumber = "";
            this.IcId1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.IcId1.Size = new System.Drawing.Size(512, 136);
            this.IcId1.TabIndex = 4;
            this.IcId1.ShowClientCard += new ClientManage.Interfaces.DlgShowClientCardEventHandler(this.IcId1_ShowClientCard);
            this.IcId1.SetAppointment += new ClientManage.Interfaces.CalendarSetAppointmentEventHandler(this.IcidSetAppointment);
            // 
            // pnlCallerId
            // 
            this.pnlCallerId.BackColor = System.Drawing.Color.White;
            this.pnlCallerId.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlCallerId.Controls.Add(this.label1);
            this.pnlCallerId.Controls.Add(this.label2);
            this.pnlCallerId.Controls.Add(this.label3);
            this.pnlCallerId.Controls.Add(this.lblCallerId);
            this.pnlCallerId.Location = new System.Drawing.Point(8, 28);
            this.pnlCallerId.Name = "pnlCallerId";
            this.pnlCallerId.Size = new System.Drawing.Size(565, 74);
            this.pnlCallerId.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 71);
            this.label2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(0, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(565, 3);
            this.label3.TabIndex = 4;
            // 
            // pnlCallLog
            // 
            this.pnlCallLog.Controls.Add(this.grdClients);
            this.pnlCallLog.Controls.Add(this.label4);
            this.pnlCallLog.Location = new System.Drawing.Point(12, 259);
            this.pnlCallLog.Name = "pnlCallLog";
            this.pnlCallLog.Size = new System.Drawing.Size(557, 206);
            this.pnlCallLog.TabIndex = 10;
            this.pnlCallLog.Visible = false;
            // 
            // grdClients
            // 
            this.grdClients.AllowUserToAddRows = false;
            this.grdClients.AllowUserToDeleteRows = false;
            this.grdClients.AllowUserToResizeRows = false;
            this.grdClients.BackgroundColor = System.Drawing.Color.White;
            this.grdClients.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdClients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdClients.ColumnHeadersHeight = 24;
            this.grdClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmImage,
            this.clmPicture,
            this.clmId,
            this.clmName,
            this.clmPhoneNo,
            this.clmDateCall});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdClients.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdClients.Location = new System.Drawing.Point(0, 16);
            this.grdClients.MultiSelect = false;
            this.grdClients.Name = "grdClients";
            this.grdClients.ReadOnly = true;
            this.grdClients.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdClients.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdClients.RowHeadersVisible = false;
            this.grdClients.RowHeadersWidth = 48;
            this.grdClients.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdClients.RowTemplate.Height = 48;
            this.grdClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdClients.ShowEditingIcon = false;
            this.grdClients.Size = new System.Drawing.Size(557, 190);
            this.grdClients.TabIndex = 12;
            this.grdClients.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GrdClients_DataBindingComplete);
            this.grdClients.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GrdClientsCellMouseDoubleClick);
            // 
            // clmImage
            // 
            this.clmImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clmImage.Frozen = true;
            this.clmImage.HeaderText = "תמונה";
            this.clmImage.Image = ((System.Drawing.Image)(resources.GetObject("clmImage.Image")));
            this.clmImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.clmImage.MinimumWidth = 64;
            this.clmImage.Name = "clmImage";
            this.clmImage.ReadOnly = true;
            this.clmImage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmImage.Width = 64;
            // 
            // clmPicture
            // 
            this.clmPicture.DataPropertyName = "picture";
            this.clmPicture.HeaderText = "Picture Filename";
            this.clmPicture.Name = "clmPicture";
            this.clmPicture.ReadOnly = true;
            this.clmPicture.Visible = false;
            // 
            // clmId
            // 
            this.clmId.DataPropertyName = "id";
            this.clmId.HeaderText = "id";
            this.clmId.Name = "clmId";
            this.clmId.ReadOnly = true;
            this.clmId.Visible = false;
            // 
            // clmName
            // 
            this.clmName.DataPropertyName = "full_name";
            this.clmName.HeaderText = "שם המתקשר";
            this.clmName.MinimumWidth = 50;
            this.clmName.Name = "clmName";
            this.clmName.ReadOnly = true;
            this.clmName.Width = 150;
            // 
            // clmPhoneNo
            // 
            this.clmPhoneNo.DataPropertyName = "phone_no";
            this.clmPhoneNo.HeaderText = "מספר טלפון";
            this.clmPhoneNo.Name = "clmPhoneNo";
            this.clmPhoneNo.ReadOnly = true;
            this.clmPhoneNo.Width = 120;
            // 
            // clmDateCall
            // 
            this.clmDateCall.DataPropertyName = "date_call";
            this.clmDateCall.HeaderText = "תאריך השיחה";
            this.clmDateCall.MinimumWidth = 50;
            this.clmDateCall.Name = "clmDateCall";
            this.clmDateCall.ReadOnly = true;
            this.clmDateCall.Width = 150;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(557, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "שיחות נכנסות אחרונות:";
            // 
            // frmIncomingCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(243)))));
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(581, 517);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlCallLog);
            this.Controls.Add(this.pnlCallers);
            this.Controls.Add(this.pnlCallerId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIncomingCall";
            this.ShowInTaskbar = false;
            this.ShowMaximizeControl = false;
            this.ShowMinimizeControl = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = " שיחה נכנסת... ";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmIncomingCallLoad);
            this.Controls.SetChildIndex(this.pnlCallerId, 0);
            this.Controls.SetChildIndex(this.pnlCallers, 0);
            this.Controls.SetChildIndex(this.pnlCallLog, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlCallers.ResumeLayout(false);
            this.pnlCallerId.ResumeLayout(false);
            this.pnlCallLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdClients)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCallerId;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlCallers;
        private System.Windows.Forms.Panel pnlCallerId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlCallLog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView grdClients;
        private IncomeCallerId IcId1;
        private System.Windows.Forms.DataGridViewImageColumn clmImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPicture;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPhoneNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDateCall;
    }
}