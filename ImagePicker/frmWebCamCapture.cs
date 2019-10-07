using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BizCare.WebCam;

namespace ImagePicker
{
    internal partial class frmWebCamCapture : Form
    {
        private readonly WebCamViewer _viewer;
        private static Image _captureImage = null;

        #region Constructor

        public frmWebCamCapture()
        {
            InitializeComponent();

            _viewer = new WebCamViewer(pictureBox1);
        }

        #endregion

        #region Properties

        // the cupture image property
        internal static Image CaptureImage
        {
            get
            {
                return _captureImage;
            }
        }

        #endregion

        // draw border to the form
        private void frmWebCamCapture_Paint(object sender, PaintEventArgs e)
        {
            var pen = new Pen(Color.FromArgb(62, 78, 94));
            e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
        }

        private void btnFreez_Click(object sender, EventArgs e)
        {
            if (btnFreez.Tag == null)
            {
                _viewer.Pause();
                btnFreez.Text = "הפעל";
                btnFreez.Tag = "Continue";
            }
            else
            {
                _viewer.Run();
                btnFreez.Text = "הקפא!";
                btnFreez.Tag = null;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_viewer != null)
            {
                _viewer.Pause();
                Application.DoEvents();
                _captureImage = _viewer.GetImage();
                _viewer.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _viewer.Close();
        }

        private void frmWebCamCapture_Load(object sender, EventArgs e)
        {
            try
            {
                _viewer.CaptureVideo();
            }
            catch
            {
                ShowError();
            }
        }

        private void frmWebCamCapture_FormClosing(object sender, FormClosingEventArgs e)
        {
            _viewer.Close();
        }

        protected override void WndProc(ref Message m)
        {
            try
            {
                _viewer.WndProc(ref m);
                base.WndProc(ref m);
            }
            catch 
            {
                ShowError();
            }
        }

        private void lblError_Paint(object sender, PaintEventArgs e)
        {
            var pen = new Pen(Color.FromArgb(210, 210, 210));
            e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, lblError.Width - 1, lblError.Height - 1));
        }

        private void ShowError()
        {
            lblError.Visible = true;
            btnOk.Enabled = false;
            btnFreez.Enabled = false;
        }
    }
}