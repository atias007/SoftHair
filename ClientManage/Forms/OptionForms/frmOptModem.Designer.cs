namespace ClientManage.Forms.OptionForms
{
    partial class FormOptModem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOptModem));
            this.btnTestModem = new System.Windows.Forms.Button();
            this.btnListen = new System.Windows.Forms.Button();
            this.btnCallerIdReset = new System.Windows.Forms.Button();
            this.txtModemCommand = new System.Windows.Forms.TextBox();
            this.txtModemOutput = new System.Windows.Forms.TextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.cmbModemStopBits = new System.Windows.Forms.ComboBox();
            this.cmbModemParity = new System.Windows.Forms.ComboBox();
            this.cmbModemDataBits = new System.Windows.Forms.ComboBox();
            this.cmbMaxSpeed = new System.Windows.Forms.ComboBox();
            this.cmbModemPort = new System.Windows.Forms.ComboBox();
            this.cmbModemCommand = new System.Windows.Forms.ComboBox();
            this.label58 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTestModem
            // 
            this.btnTestModem.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnTestModem.Image = ((System.Drawing.Image)(resources.GetObject("btnTestModem.Image")));
            this.btnTestModem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTestModem.Location = new System.Drawing.Point(15, 340);
            this.btnTestModem.Name = "btnTestModem";
            this.btnTestModem.Size = new System.Drawing.Size(199, 51);
            this.btnTestModem.TabIndex = 68;
            this.btnTestModem.Text = "       הפעל בדיקת מודם";
            this.btnTestModem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTestModem.UseVisualStyleBackColor = true;
            this.btnTestModem.Click += new System.EventHandler(this.btnTestModem_Click);
            // 
            // btnListen
            // 
            this.btnListen.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnListen.Image = ((System.Drawing.Image)(resources.GetObject("btnListen.Image")));
            this.btnListen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListen.Location = new System.Drawing.Point(15, 226);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(199, 51);
            this.btnListen.TabIndex = 65;
            this.btnListen.Tag = "";
            this.btnListen.Text = "       החל האזנה למודם";
            this.btnListen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // btnCallerIdReset
            // 
            this.btnCallerIdReset.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnCallerIdReset.Image = ((System.Drawing.Image)(resources.GetObject("btnCallerIdReset.Image")));
            this.btnCallerIdReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCallerIdReset.Location = new System.Drawing.Point(15, 283);
            this.btnCallerIdReset.Name = "btnCallerIdReset";
            this.btnCallerIdReset.Size = new System.Drawing.Size(199, 51);
            this.btnCallerIdReset.TabIndex = 66;
            this.btnCallerIdReset.Text = "       אפס שיחה מזוהה";
            this.btnCallerIdReset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCallerIdReset.UseVisualStyleBackColor = true;
            this.btnCallerIdReset.Click += new System.EventHandler(this.btnCallerIdReset_Click);
            // 
            // txtModemCommand
            // 
            this.txtModemCommand.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtModemCommand.Location = new System.Drawing.Point(300, 78);
            this.txtModemCommand.Name = "txtModemCommand";
            this.txtModemCommand.ReadOnly = true;
            this.txtModemCommand.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtModemCommand.Size = new System.Drawing.Size(488, 22);
            this.txtModemCommand.TabIndex = 69;
            this.txtModemCommand.Tag = "SuperUser";
            this.txtModemCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtModemCommand_KeyDown);
            // 
            // txtModemOutput
            // 
            this.txtModemOutput.BackColor = System.Drawing.Color.White;
            this.txtModemOutput.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtModemOutput.Location = new System.Drawing.Point(300, 106);
            this.txtModemOutput.Multiline = true;
            this.txtModemOutput.Name = "txtModemOutput";
            this.txtModemOutput.ReadOnly = true;
            this.txtModemOutput.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtModemOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtModemOutput.Size = new System.Drawing.Size(488, 510);
            this.txtModemOutput.TabIndex = 70;
            // 
            // label60
            // 
            this.label60.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label60.Location = new System.Drawing.Point(12, 196);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(100, 18);
            this.label60.TabIndex = 75;
            this.label60.Text = "Stop Bits:";
            // 
            // label61
            // 
            this.label61.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label61.Location = new System.Drawing.Point(12, 169);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(100, 18);
            this.label61.TabIndex = 74;
            this.label61.Text = "Parity:";
            // 
            // label62
            // 
            this.label62.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label62.Location = new System.Drawing.Point(12, 146);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(100, 18);
            this.label62.TabIndex = 73;
            this.label62.Text = "Data Bits:";
            // 
            // label63
            // 
            this.label63.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label63.Location = new System.Drawing.Point(12, 115);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(100, 18);
            this.label63.TabIndex = 72;
            this.label63.Text = "Max Speed:";
            // 
            // label64
            // 
            this.label64.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label64.Location = new System.Drawing.Point(12, 88);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(100, 18);
            this.label64.TabIndex = 71;
            this.label64.Text = "Com Port:";
            // 
            // cmbModemStopBits
            // 
            this.cmbModemStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModemStopBits.Enabled = false;
            this.cmbModemStopBits.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbModemStopBits.FormattingEnabled = true;
            this.cmbModemStopBits.Items.AddRange(new object[] {
            "None",
            "One",
            "OnePointFive",
            "Two"});
            this.cmbModemStopBits.Location = new System.Drawing.Point(165, 192);
            this.cmbModemStopBits.Name = "cmbModemStopBits";
            this.cmbModemStopBits.Size = new System.Drawing.Size(126, 24);
            this.cmbModemStopBits.TabIndex = 64;
            this.cmbModemStopBits.Tag = "SuperUser";
            // 
            // cmbModemParity
            // 
            this.cmbModemParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModemParity.Enabled = false;
            this.cmbModemParity.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbModemParity.FormattingEnabled = true;
            this.cmbModemParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.cmbModemParity.Location = new System.Drawing.Point(165, 165);
            this.cmbModemParity.Name = "cmbModemParity";
            this.cmbModemParity.Size = new System.Drawing.Size(126, 24);
            this.cmbModemParity.TabIndex = 63;
            this.cmbModemParity.Tag = "SuperUser";
            // 
            // cmbModemDataBits
            // 
            this.cmbModemDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModemDataBits.Enabled = false;
            this.cmbModemDataBits.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbModemDataBits.FormattingEnabled = true;
            this.cmbModemDataBits.Items.AddRange(new object[] {
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cmbModemDataBits.Location = new System.Drawing.Point(165, 138);
            this.cmbModemDataBits.Name = "cmbModemDataBits";
            this.cmbModemDataBits.Size = new System.Drawing.Size(126, 24);
            this.cmbModemDataBits.TabIndex = 62;
            this.cmbModemDataBits.Tag = "SuperUser";
            // 
            // cmbMaxSpeed
            // 
            this.cmbMaxSpeed.Enabled = false;
            this.cmbMaxSpeed.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbMaxSpeed.FormattingEnabled = true;
            this.cmbMaxSpeed.Items.AddRange(new object[] {
            "110",
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "56000",
            "57600",
            "115200",
            "128000",
            "256000",
            "512000"});
            this.cmbMaxSpeed.Location = new System.Drawing.Point(165, 111);
            this.cmbMaxSpeed.Name = "cmbMaxSpeed";
            this.cmbMaxSpeed.Size = new System.Drawing.Size(126, 24);
            this.cmbMaxSpeed.TabIndex = 61;
            this.cmbMaxSpeed.Tag = "SuperUser";
            // 
            // cmbModemPort
            // 
            this.cmbModemPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModemPort.Enabled = false;
            this.cmbModemPort.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbModemPort.FormattingEnabled = true;
            this.cmbModemPort.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15",
            "COM16",
            "COM17",
            "COM18",
            "COM19",
            "COM20"});
            this.cmbModemPort.Location = new System.Drawing.Point(165, 84);
            this.cmbModemPort.Name = "cmbModemPort";
            this.cmbModemPort.Size = new System.Drawing.Size(126, 24);
            this.cmbModemPort.TabIndex = 60;
            this.cmbModemPort.Tag = "SuperUser";
            // 
            // cmbModemCommand
            // 
            this.cmbModemCommand.Enabled = false;
            this.cmbModemCommand.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbModemCommand.FormattingEnabled = true;
            this.cmbModemCommand.Items.AddRange(new object[] {
            "AT+VCID=1",
            "AT#CID=1",
            "AT%CCID=1",
            "AT#CC1",
            "AT*ID1"});
            this.cmbModemCommand.Location = new System.Drawing.Point(165, 59);
            this.cmbModemCommand.Name = "cmbModemCommand";
            this.cmbModemCommand.Size = new System.Drawing.Size(126, 22);
            this.cmbModemCommand.TabIndex = 59;
            this.cmbModemCommand.Tag = "SuperUser";
            // 
            // label58
            // 
            this.label58.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label58.Location = new System.Drawing.Point(12, 62);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(147, 19);
            this.label58.TabIndex = 67;
            this.label58.Text = "פקודת אתחול זיהוי שיחה:";
            // 
            // label35
            // 
            this.label35.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label35.Location = new System.Drawing.Point(297, 62);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(271, 19);
            this.label35.TabIndex = 76;
            this.label35.Text = "מעקב אירועים בשער המודם:";
            // 
            // frmOptModem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 620);
            this.Controls.Add(this.btnTestModem);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.btnCallerIdReset);
            this.Controls.Add(this.txtModemCommand);
            this.Controls.Add(this.txtModemOutput);
            this.Controls.Add(this.label60);
            this.Controls.Add(this.label61);
            this.Controls.Add(this.label62);
            this.Controls.Add(this.label63);
            this.Controls.Add(this.label64);
            this.Controls.Add(this.cmbModemStopBits);
            this.Controls.Add(this.cmbModemParity);
            this.Controls.Add(this.cmbModemDataBits);
            this.Controls.Add(this.cmbMaxSpeed);
            this.Controls.Add(this.cmbModemPort);
            this.Controls.Add(this.cmbModemCommand);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.label35);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmOptModem";
            this.Text = "frmOptModem";
            this.Controls.SetChildIndex(this.label35, 0);
            this.Controls.SetChildIndex(this.label58, 0);
            this.Controls.SetChildIndex(this.cmbModemCommand, 0);
            this.Controls.SetChildIndex(this.cmbModemPort, 0);
            this.Controls.SetChildIndex(this.cmbMaxSpeed, 0);
            this.Controls.SetChildIndex(this.cmbModemDataBits, 0);
            this.Controls.SetChildIndex(this.cmbModemParity, 0);
            this.Controls.SetChildIndex(this.cmbModemStopBits, 0);
            this.Controls.SetChildIndex(this.label64, 0);
            this.Controls.SetChildIndex(this.label63, 0);
            this.Controls.SetChildIndex(this.label62, 0);
            this.Controls.SetChildIndex(this.label61, 0);
            this.Controls.SetChildIndex(this.label60, 0);
            this.Controls.SetChildIndex(this.txtModemOutput, 0);
            this.Controls.SetChildIndex(this.txtModemCommand, 0);
            this.Controls.SetChildIndex(this.btnCallerIdReset, 0);
            this.Controls.SetChildIndex(this.btnListen, 0);
            this.Controls.SetChildIndex(this.btnTestModem, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTestModem;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.Button btnCallerIdReset;
        private System.Windows.Forms.TextBox txtModemCommand;
        private System.Windows.Forms.TextBox txtModemOutput;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.ComboBox cmbModemStopBits;
        private System.Windows.Forms.ComboBox cmbModemParity;
        private System.Windows.Forms.ComboBox cmbModemDataBits;
        private System.Windows.Forms.ComboBox cmbMaxSpeed;
        private System.Windows.Forms.ComboBox cmbModemPort;
        private System.Windows.Forms.ComboBox cmbModemCommand;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label35;
    }
}