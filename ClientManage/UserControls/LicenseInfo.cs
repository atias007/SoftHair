using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ClientManage.Interfaces.Schemas;
using ClientManage.Interfaces;
using System.IO;
using ClientManage.BL;

namespace ClientManage.UserControls
{
    public partial class LicenseInfo : UserControl
    {
        public LicenseInfo()
        {
            InitializeComponent();
        }

        private bool _drawBorder = false;

        public bool DrawBorder
        {
            get { return _drawBorder; }
            set { _drawBorder = value; }
        }

        public void ShowLicenseInfo(ProductLicense license)
        {
            if (license != null)
            {
                var row = license.License[0];
                lblEndDate.Text = row.to_date.ToString("dd/MM/yyyy");
                lblId.Text = row.cpu_id;
                lblLastCheck.Text = row.last_used.ToString("dd/MM/yyyy");
                lblStartDate.Text = row.from_date.ToString("dd/MM/yyyy");
                lblType.Text = row.type;
                lblKey.Text = row.key;

                lstFeatures.DataSource = license.LicenseFeatures;
                lstFeatures.DisplayMember = "description";
                lstFeatures.ValueMember = "id";
            }
        }

        public void Clear()
        {
            lblEndDate.Text = string.Empty;
            lblId.Text = string.Empty;
            lblLastCheck.Text = string.Empty;
            lblStartDate.Text = string.Empty;
            lblType.Text = string.Empty;
            lblKey.Text = string.Empty;
            lstFeatures.DataSource = null;
            lstFeatures.Items.Clear();
        }

        private void LicenseInfo_Paint(object sender, PaintEventArgs e)
        {
            if (_drawBorder)
            {
                var c = Color.FromArgb(127, 157, 185);
                var rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                e.Graphics.DrawRectangle(new Pen(c), rect);
            }
        }
    }
}
