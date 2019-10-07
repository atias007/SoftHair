using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ImagePicker
{
    public partial class ImagePicker : UserControl
    {
        public ImagePicker()
        {
            InitializeComponent();
            if (_imageFilename.Length == 0)
            {
                picView.BackgroundImage = _defaultImage;
            }
        }

        public delegate void WebCamCaptureHandler(object sender, WebCamCaptureEventArgs e);

        public event WebCamCaptureHandler WebCamCapture;

        public event EventHandler PictureClick;

        // constant of message box, cause the information appear right to left
        protected const MessageBoxOptions _msgOpt = MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading;

        private frmWebCamCapture fWebCamCapture;
        private Image _defaultImage = null;
        private string _imageFilename = string.Empty;
        private bool _enableWebCam = true;
        private bool _menuButtonEnable = true;
        private bool _menuButtonVisible = true;
        private string _openFileDialogFilter = "JPEG Compressed Image (*.jpg)|*.jpg|CompuServ File Format (*.gif)|*.gif";
        private string _openFileDialogTitle = string.Empty;

        public Image DefaultImage
        {
            get { return _defaultImage; }
            set
            {
                _defaultImage = value;
                if (_imageFilename.Length == 0)
                {
                    picView.BackgroundImage = _defaultImage;
                }
            }
        }

        public string ImageFilename
        {
            get { return _imageFilename; }
            set
            {
                _imageFilename = value;
                LoadClientPicture(_imageFilename);
            }
        }

        public bool EnableWebCam
        {
            get { return _enableWebCam; }
            set
            {
                _enableWebCam = value;
                mnuCamera.Enabled = _enableWebCam;
            }
        }

        public string OpenFileDialogFilter
        {
            get { return _openFileDialogFilter; }
            set { _openFileDialogFilter = value; }
        }

        public string OpenFileDialogTitle
        {
            get { return _openFileDialogTitle; }
            set { _openFileDialogTitle = value; }
        }

        public bool MenuButtonEnable
        {
            get { return _menuButtonEnable; }
            set
            {
                _menuButtonEnable = value;
                btnPicture.Enabled = value;
            }
        }

        public bool MenuButtonVisible
        {
            get { return _menuButtonVisible; }
            set
            {
                _menuButtonVisible = value;
                btnPicture.Visible = value;
                picView.Cursor = value ? Cursors.Default : Cursors.Hand;
            }
        }

        public void ClearImage()
        {
            this.ImageFilename = string.Empty;
        }

        // set the picture of current client in the form
        private void LoadClientPicture(string filename)
        {
            try
            {
                if (File.Exists(filename))
                {
                    picView.BackgroundImage = Image.FromFile(filename);
                    mnuRemovePic.Enabled = true;
                }
                else
                {
                    picView.BackgroundImage = _defaultImage;
                    mnuRemovePic.Enabled = false;
                }
            }
            catch
            {
                // show default picture in case of exception
                picView.BackgroundImage = _defaultImage;
                mnuRemovePic.Enabled = false;
            }
        }

        private void mnuRemovePic_Click(object sender, EventArgs e)
        {
            ClearImage();
        }

        private void mnuFileSystem_Click(object sender, EventArgs e)
        {
            // browse for a picture in file system
            this.Cursor = Cursors.WaitCursor;
            dlgOpenFile.Title = _openFileDialogTitle;
            dlgOpenFile.Filter = _openFileDialogFilter;
            var ret = dlgOpenFile.ShowDialog(this);
            this.Cursor = Cursors.Default;

            if (ret == DialogResult.OK)
            {
                this.ImageFilename = dlgOpenFile.FileName;
            }
        }

        private void ImagePicker_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(170, 153);
        }

        private void mnuCamera_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var res = DialogResult.Cancel;
            var rec = picView.RectangleToScreen(DisplayRectangle);

            try
            {
                fWebCamCapture = null;
                fWebCamCapture = new frmWebCamCapture();
                fWebCamCapture.Location = new Point(rec.X + ((picView.Width - fWebCamCapture.Width) / 2), rec.Y + ((picView.Height - fWebCamCapture.Height) / 2));
                res = fWebCamCapture.ShowDialog();
                this.Cursor = Cursors.Default;
            }
            catch (Exception)
            {
                this.Cursor = Cursors.Default;
                var msg1 = "לא נמצאה מצלמת אינטרנט מחוברת למחשב\nאנא וודא שהמצלמה מחוברת כראוי ונסה שנית";
                var msg2 = "תמונה ממצלמה...";
                MessageBox.Show(msg1, msg2, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, _msgOpt);
            }

            if (res == DialogResult.OK)
            {
                if (frmWebCamCapture.CaptureImage == null)
                {
                    this.Cursor = Cursors.Default;
                    var msg1 = "ארעה שגיאה בעת קריאת התמונה מהמצלמה";
                    var msg2 = "תמונה ממצלמה...";
                    MessageBox.Show(msg1, msg2, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, _msgOpt);
                    return;
                }
                this.Cursor = Cursors.WaitCursor;
                picView.BackgroundImage = frmWebCamCapture.CaptureImage;
                mnuRemovePic.Enabled = true;
                if (WebCamCapture != null) WebCamCapture(this, new WebCamCaptureEventArgs(frmWebCamCapture.CaptureImage));
                this.Cursor = Cursors.Default;
            }
        }

        private void btnPicture_Click(object sender, EventArgs e)
        {
            pictureMenu.Show(btnPicture, btnPicture.Width, btnPicture.Height);
        }

        private void ImagePicker_Enter(object sender, EventArgs e)
        {
            btnPicture.Select();
        }

        private void picView_Click(object sender, EventArgs e)
        {
            if (MenuButtonVisible == false && PictureClick != null) PictureClick(this, e);
        }
    }
}