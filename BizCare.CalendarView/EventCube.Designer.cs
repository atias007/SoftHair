namespace BizCare.Calendar
{
    partial class EventCube
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
            this.lblText = new System.Windows.Forms.Label();
            this.lblAlert = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.AutoEllipsis = true;
            this.lblText.BackColor = System.Drawing.Color.Transparent;
            this.lblText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblText.Location = new System.Drawing.Point(3, 2);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(151, 86);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "טקסט";
            this.lblText.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.EventCube_MouseDoubleClick);
            this.lblText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EventCube_MouseDown);
            this.lblText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LblTextMouseMove);
            this.lblText.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LblTextMouseUp);
            // 
            // lblAlert
            // 
            this.lblAlert.BackColor = System.Drawing.Color.SteelBlue;
            this.lblAlert.Location = new System.Drawing.Point(1, 1);
            this.lblAlert.Name = "lblAlert";
            this.lblAlert.Size = new System.Drawing.Size(6, 6);
            this.lblAlert.TabIndex = 1;
            // 
            // EventCube
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblAlert);
            this.Controls.Add(this.lblText);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Name = "EventCube";
            this.Padding = new System.Windows.Forms.Padding(3, 2, 3, 1);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(157, 89);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.EventCube_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EventCube_KeyDown);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.EventCube_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EventCube_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EventCube_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EventCube_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblAlert;

    }
}
