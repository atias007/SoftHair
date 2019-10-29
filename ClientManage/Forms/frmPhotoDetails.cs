using BizCare.Calendar.Library;
using BizCare.WebCam;
using ClientManage.BL;
using ClientManage.BL.Library;
using ClientManage.Interfaces;
using ClientManage.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ClientManage.Forms
{
    public partial class FormPhotoDetails : ClientManage.Forms.BasePopupForm
    {
        public event EventHandler MoveNext;

        public event EventHandler MovePrevious;

        public event OpenFormEventHandler OpenForm;

        public event EventHandler<PhotoAlbumEventArgs> RefreshPhoto;

        public event EventHandler<PhotoAlbumEventArgs> AddPhoto;

        public event EventHandler<PhotoAlbumEventArgs> DeletePhoto;

        // web camera component
        private ClientPhoto _photo;

        private bool _isLock = false;
        private bool _isNewMode = false;
        private Appointment _app = null;
        private WebCamViewer _viewer = null;

        public FormPhotoDetails(int clientId)
        {
            InitializeComponent();
            _photo = new ClientPhoto();
            _photo.ClientId = clientId;
            _photo.DateCreated = DateTime.Now;
            _photo.CalendarId = PhotoAlbumHelper.GetPhotoAppointmentId(clientId);
            ShowNavigation(false);
            _isNewMode = true;
            ShowNoImageLabel();

            DataRow row;
            try
            {
                row = CalendarHelper.GetAppointment(_photo.CalendarId);
            }
            catch (Exception ex)
            {
                General.ShowCommunicationError(ex, this);
                return;
            }
            _app = FormCalendar.GetAppointmentFromDataRow(row);
        }

        public FormPhotoDetails(Appointment app)
        {
            InitializeComponent();
            _photo = new ClientPhoto();
            _photo.ClientId = app.ClientId;
            _photo.DateCreated = DateTime.Now;
            _photo.CalendarId = app.Id;
            ShowNavigation(false);
            _isNewMode = true;
            ShowNoImageLabel();

            _app = app;
        }

        public FormPhotoDetails(ClientPhoto photo)
        {
            InitializeComponent();
            _photo = photo;
            ShowNavigation(true);
        }

        public bool IsNewMode
        {
            get { return _isNewMode; }
        }

        private void SetCalendarIcon()
        {
            if (string.IsNullOrEmpty(_photo.CalendarId) == false)
            {
                lblCalendar.Visible = true;
                txtRemark.Left = lblCalendar.Right + 8;
                this.Tooltip.SetToolTip(lblCalendar, "לחץ להצגת התור ביומן המקושר לתמונה");
            }
            else
            {
                lblCalendar.Visible = false;
                txtRemark.Left = txtDateCreate.Left;
            }

            txtRemark.Width = txtSubject.Right - txtRemark.Left;
        }

        private void SetPrintButton()
        {
            var pic = Convert.ToString(picView.Tag);
            if (pic.Length == 0 || pic.Equals("Capture"))
            {
                tbbPrint.Enabled = false;
            }
            else
            {
                picView.Enabled = true;
            }
        }

        private void ShowNavigation(bool value)
        {
            tbbNext.Visible = value;
            tbbPrev.Visible = value;
            tbbSep.Visible = value;
        }

        private void LoadData()
        {
            txtDateCreate.Text = _photo.DateCreated.ToString("dd/MM/yyyy בשעה HH:mm");
            txtRemark.Text = _photo.Remark;
            txtSubject.Text = _photo.Subject;
            SetCalendarIcon();

            if (string.IsNullOrEmpty(_photo.CalendarId) == false && _photo.Id == 0)
            {
                if (_app != null)
                {
                    var msg = "התמונה מקושרת לתור ביומן\r\nבתאריך {0} בין השעות {1} - {2}\r\n";
                    msg = string.Format(msg, Utils.GetDateTimeShortString(_app.StartDate),
                        _app.EndDate.ToShortTimeString(), _app.StartDate.ToShortTimeString());

                    if (_app.CaresDescription.Length > 0)
                    {
                        msg += "טיפול שבוצע: " + _app.CaresDescription + "\r\n";
                    }

                    if (_app.Text.Length > 0)
                    {
                        msg += "תיאור התור: " + _app.Text;
                    }

                    txtRemark.Text = msg;
                }
            }

            var mi = new MethodInvoker(LoadImage);
            mi.BeginInvoke(null, null);
        }

        public void CancelWebcamMode()
        {
            _isLock = false;
            if (_viewer != null)
            {
                _viewer.Stop();
                _viewer.Close();
                _viewer = null;
            }
            picView.Image = null;

            foreach (ToolStripItem item in toolStrip.Items)
            {
                item.Visible = true;
            }
            ShowNavigation(!_isNewMode);
            tbbTakePic.Visible = false;
            tbbFreezPic.Visible = false;
            tbbCancelPic.Visible = false;
            if (picView.Tag == null || picView.Tag.ToString() == string.Empty) ShowNoImageLabel();
        }

        private void EnterWebcamMode()
        {
            _isLock = true;
            foreach (ToolStripItem item in toolStrip.Items)
            {
                item.Visible = false;
            }
            tbbTakePic.Visible = true;
            tbbFreezPic.Visible = true;
            tbbCancelPic.Visible = true;
            tbbClose.Visible = true;
            tssClose.Visible = true;

            tbbTakePic.Enabled = true;
            tbbFreezPic.Enabled = true;

            _viewer = new WebCamViewer(picView);
            lblNoImage.Visible = false;

            try
            {
                _viewer.CaptureVideo();
            }
            catch (Exception)
            {
                ShowError();
            }
        }

        private void ClearForm()
        {
            var client = _photo.ClientId;
            _photo = new ClientPhoto();
            _photo.DateCreated = DateTime.Now;
            _photo.ClientId = client;
            _photo.CalendarId = PhotoAlbumHelper.GetPhotoAppointmentId(client);
            ShowNavigation(false);
            LoadData();
        }

        private void SetInformationBar()
        {
            var name = ClientHelper.GetFullName(_photo.ClientId);
            var caption = _isNewMode ? "תמונה חדשה לאלבום הלקוח: " : "תמונה מאלבום הלקוח: ";
            informationBar1.PanelText = caption + name;
        }

        private bool SaveData()
        {
            if (!ValidateForm()) return false;

            var result = false;
            _photo.AcceptChanges();
            _photo.SuspendEvents();
            _photo.Picture = Convert.ToString(picView.Tag);
            _photo.Remark = txtRemark.Text.Trim();
            _photo.Subject = txtSubject.Text.Trim();
            _photo.ReleaseEvents();
            _photo.OnPhotoChanged();
            if (!_photo.HasChanges) return true;

            if (_photo.Picture == "[Capture]")
            {
                _photo.Picture = Utils.SaveImageFile(picView.BackgroundImage, true);
            }

            if (!_photo.Picture.StartsWith(Path.Combine(General.StartupPath, "AlbumImages")))
            {
                try
                {
                    var image = Image.FromFile(_photo.Picture);
                    image = Utils.GetThumbnailBigImage(image);
                    _photo.Picture = Utils.SaveImageFile(image, true);
                    image.Dispose();
                }
                catch (Exception ex)
                {
                    var msg = "Error at save Album Image";
                    EventLogManager.AddErrorMessage(msg, ex);
                }
            }

            try
            {
                if (_photo.Id == 0)
                {
                    _photo.DateCreated = DateTime.Now;
                    var id = PhotoAlbumHelper.AddPhoto(_photo);
                    _photo.Id = id;
                    if (AddPhoto != null) AddPhoto(this, new PhotoAlbumEventArgs(_photo));
                    result = true;
                }
                else
                {
                    PhotoAlbumHelper.UpdatePhoto(_photo);
                    if (RefreshPhoto != null) RefreshPhoto(this, new PhotoAlbumEventArgs(_photo));
                    result = true;
                }
            }
            catch (Exception ex)
            {
                var title = "שגיאה באלבום תמונות...";
                var head = "שמירת נתוני התמונה";
                var desc = "שמירת נתוני התמונה נכשלה\nשים לב כי הנתונים שהזנת בטופס לא נשמרו";
                ClientManage.Library.General.ShowErrorMessageDialog(this, title, head, desc, ex, "frmPhotoDetails");
            }
            return result;
        }

        public bool ValidateForm()
        {
            var result = true;

            if (_isNewMode)
            {
                var picture = Convert.ToString(picView.Tag);
                if (picture.Length == 0)
                {
                    MyMessageBox = new MyMessageBox("לא נמצאה תמונה. יש לצלם או לטעון תמונה לפני השמירה", "שמירת תמונת לקוח...", MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                    MyMessageBox.Show(this);
                    result = false;
                }
            }
            return result;
        }

        private void LoadImage()
        {
            LoadImage(_photo.Picture);
        }

        private void LoadImage(string picture)
        {
            try
            {
                picView.BackgroundImage = Image.FromFile(picture);
                picView.Tag = picture;
                lblNoImage.Visible = false;
            }
            catch
            {
                picView.BackgroundImage = null;
                picView.Tag = string.Empty;
                this.Invoke(new MethodInvoker(ShowNoImageLabel));
            }
            this.Invoke(new MethodInvoker(SetPrintButton));
        }

        private void ShowNoImageLabel()
        {
            if (_viewer == null)
            {
                lblNoImage.Visible = true;
            }
        }

        public void SetAppointment(Appointment app)
        {
            _app = app;
        }

        public void RefreshData(ClientPhoto photo)
        {
            if (_isLock) CancelWebcamMode();
            if (!_isNewMode) SaveData();

            if (photo == null)
            {
                ClearForm();
                _isNewMode = true;
                SetInformationBar();
            }
            else
            {
                if (_photo.ClientId != photo.ClientId) SetInformationBar();
                _photo = photo;
                LoadData();
            }
        }

        private void frmPhotoDetails_Load(object sender, EventArgs e)
        {
            LoadData();
            SetInformationBar();

            if (_isNewMode) tbbWebCam_ButtonClick(null, null);
        }

        private void tbbSave_Click(object sender, EventArgs e)
        {
            if (SaveData()) this.Close();
        }

        private void tbbNext_Click(object sender, EventArgs e)
        {
            if (MoveNext != null) MoveNext(this, new EventArgs());
        }

        private void tbbPrev_Click(object sender, EventArgs e)
        {
            if (MovePrevious != null) MovePrevious(this, new EventArgs());
        }

        private void txtRemark_Enter(object sender, EventArgs e)
        {
            base.TextBoxEnter((TextBox)sender);
        }

        private void txtRemark_Leave(object sender, EventArgs e)
        {
            base.TextBoxLeave((TextBox)sender);
        }

        private void frmPhotoDetails_RequestForClose(object sender, EventArgs e)
        {
            tbbClose_Click(null, null);
        }

        private void tbbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPhotoDetails_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.S:
                    if (e.Control && !e.Alt && !e.Shift)
                    {
                        if (tbbSave.Enabled) tbbSave_Click(null, null);
                    }
                    break;
            }
        }

        private void tbbCancelPic_Click(object sender, EventArgs e)
        {
            CancelWebcamMode();
            LoadImage();
        }

        private void mnuWebCam_Click(object sender, EventArgs e)
        {
            EnterWebcamMode();
        }

        private void tbbWebCam_ButtonClick(object sender, EventArgs e)
        {
            EnterWebcamMode();
        }

        private void mnuFile_Click(object sender, EventArgs e)
        {
            var filter = "JPEG Compressed Image (*.jpg)|*.jpg|CompuServ File Format (*.gif)|*.gif";
            // browse for a picture in file system
            this.Cursor = Cursors.WaitCursor;
            dlgOpenFile.Title = string.Empty;
            dlgOpenFile.Filter = filter;
            var ret = dlgOpenFile.ShowDialog(this);
            this.Cursor = Cursors.Default;

            if (ret == DialogResult.OK)
            {
                LoadImage(dlgOpenFile.FileName);
            }
        }

        private void tbbDelete_Click(object sender, EventArgs e)
        {
            if (DeletePhoto != null) DeletePhoto(this, new PhotoAlbumEventArgs(_photo));
        }

        private void tbbFreezPic_Click(object sender, EventArgs e)
        {
            if (tbbFreezPic.Tag == null)
            {
                _viewer.Pause();
                tbbFreezPic.Text = "הפעל";
                tbbFreezPic.Tag = "Continue";
            }
            else
            {
                _viewer.Run();
                tbbFreezPic.Text = "הקפא";
                tbbFreezPic.Tag = null;
            }
        }

        private void tbbTakePic_Click(object sender, EventArgs e)
        {
            try { _viewer.Pause(); }
            catch { }
            var image = _viewer.GetImage();
            _viewer.Stop();
            picView.Image = null;
            picView.Tag = "[Capture]";
            SetPrintButton();
            CancelWebcamMode();
            picView.BackgroundImage = image;
        }

        private void frmPhotoDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            CancelWebcamMode();
        }

        private void tbbPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var parameters = new string[4];
            parameters[0] = Convert.ToString(picView.Tag);
            parameters[1] = txtDateCreate.Text.Trim();
            parameters[2] = txtSubject.Text.Trim();
            parameters[3] = txtRemark.Text.Trim().Replace("\n", "<br />");
            var printer = new HtmlPrinter("PHOTO_FORM", parameters);
            if (AppSettingsHelper.GetParamValue<bool>("APP_SHOW_PRINTER_DIALOG"))
            {
                printer.ShowPrintDialog();
                this.Cursor = Cursors.Default;
            }
            else
            {
                printer.Print();
                this.Cursor = Cursors.Default;
            }

            printer = null;
        }

        private void lblCalendar_Click(object sender, EventArgs e)
        {
            if (OpenForm != null)
            {
                if (string.IsNullOrEmpty(_photo.CalendarId) == false)
                {
                    DataRow row;
                    try
                    {
                        row = CalendarHelper.GetAppointment(_photo.CalendarId);
                    }
                    catch (Exception ex)
                    {
                        General.ShowCommunicationError(ex, this);
                        return;
                    }
                    if (_app == null) _app = FormCalendar.GetAppointmentFromDataRow(row);
                    OpenForm(this, new OpenFormEventArgs("frmCalendar", -1, _app));
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            try
            {
                if (_viewer != null)
                {
                    _viewer.WndProc(ref m);
                }
                base.WndProc(ref m);
            }
            catch
            {
                ShowError();
            }
        }

        private void ShowError()
        {
            var msg1 = "ארעה שגיאה בהצגת תמונה ממצלמת האינטרנט שלך\nודא כי המצלמה מחוברת ופועלת ונסה שנית";
            var msg2 = "מצלמת אינטרנט...";
            MessageBox.Show(msg1, msg2, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            CancelWebcamMode();
        }
    }
}