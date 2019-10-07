using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClientManage.BL;

namespace ClientManage.Forms
{
    public partial class frmBackup : Form
    {
        public frmBackup()
        {
            InitializeComponent();
        }

        private void frmBackup_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;

            var dt = AppSettingsHelper.GetParamValue<DateTime>("FTP_LAST_BACKUP");
            var val = dt.ToString("HH:mm");
            if (dt == DateTime.MinValue) val = "< לא בוצע מעולם >";
            lblLastBackup.Text = val;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
