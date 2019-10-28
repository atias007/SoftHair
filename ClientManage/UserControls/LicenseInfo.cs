using System.Drawing;
using System.Windows.Forms;
using ClientManage.Interfaces;

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

        public void ShowLicenseInfo(CustomerLicense license)
        {
            if (license != null)
            {
                lblEndDate.Text = license.To.ToString("dd/MM/yyyy");
                lblId.Text = "-";
                lblLastCheck.Text = "-";
                lblStartDate.Text = license.From.ToString("dd/MM/yyyy");
                lblType.Text = "-";
                lblKey.Text = "-";

                lstFeatures.DataSource = null;
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