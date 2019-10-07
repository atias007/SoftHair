namespace ClientManage.Forms
{
    partial class FormCarePick
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCarePick));
            this.carePicker1 = new ClientManage.UserControls.CarePicker();
            this.SuspendLayout();
            // 
            // carePicker1
            // 
            this.carePicker1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.carePicker1.ButtonsVisible = true;
            this.carePicker1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.carePicker1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.carePicker1.Location = new System.Drawing.Point(7, 2);
            this.carePicker1.Name = "carePicker1";
            this.carePicker1.Padding = new System.Windows.Forms.Padding(2);
            this.carePicker1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.carePicker1.ShowBorder = false;
            this.carePicker1.ShowToolBar = false;
            this.carePicker1.Size = new System.Drawing.Size(164, 375);
            this.carePicker1.TabIndex = 0;
            this.carePicker1.ClearClicked += new System.EventHandler(this.carePicker1_ClearClicked);
            this.carePicker1.OkClicked += new System.EventHandler(this.carePicker1_OkClicked);
            this.carePicker1.BindingComplete += new System.EventHandler(this.carePicker1_BindingComplete);
            this.carePicker1.CancelClicked += new System.EventHandler(this.carePicker1_CancelClicked);
            // 
            // frmCarePick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(178, 379);
            this.Controls.Add(this.carePicker1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCarePick";
            this.Padding = new System.Windows.Forms.Padding(7, 2, 7, 2);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "בחירת טיפול לתור";
            this.Deactivate += new System.EventHandler(this.frmCarePick_Deactivate);
            this.Load += new System.EventHandler(this.frmCarePick_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmCarePick_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private ClientManage.UserControls.CarePicker carePicker1;
    }
}