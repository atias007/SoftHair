using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ClientManage.Interfaces;
using ClientManage.Library;
using ClientManage.BL;
using ClientManage.BL.Library;

namespace ClientManage.Forms
{
    public partial class FormWorkerDetails : BaseMdiChild
    {
        Worker _worker;
        private bool _isOkNew;
        private bool _isNeedToReloadWorkers;
        private bool _isLoadProc;
        private bool _ignoreEvent;
        private string _lastAutoPassword = string.Empty;
        private readonly string _saveMsg = string.Empty;
        private FormCard _fCard;
        private string _cardId;

        public event WorkerUpdateEventHandler WorkerChange;

        public FormWorkerDetails()
        {
            _isLoadProc = true;
            InitializeComponent();

            imagePicker1.EnableWebCam = AppSettingsHelper.GetParamValue<bool>("MAIN_ENABLE_WEBCAM");
            imagePicker1.DefaultImage = Properties.Resources.worker;
            dtpStartWork.CustomFormat = AppSettingsHelper.GetParamValue("APP_DATE_FORMAT");
            dtpEndWorkDate.CustomFormat = AppSettingsHelper.GetParamValue("APP_DATE_FORMAT");

            _saveMsg = informationBar1.LabelText;
            _worker = new Worker();
            imagePicker1.ClearImage();
            tbbDelete.Enabled = false;
            dtpStartWork.Value = DateTime.Now.Date;
            dtpBirthDate.Value = null;
            cmbGender.SelectedIndex = -1;
            informationBar1.PanelText = "הוספת עובד חדש";
            informationBar1.Image = Properties.Resources.new_small;
            tbbCancelCard.Enabled = false;
            _isLoadProc = false;
        }

        public FormWorkerDetails(int id)
        {
            _isLoadProc = true;
            InitializeComponent();

            imagePicker1.EnableWebCam = AppSettingsHelper.GetParamValue<bool>("MAIN_ENABLE_WEBCAM");
            imagePicker1.DefaultImage = Properties.Resources.worker;
            dtpStartWork.CustomFormat = AppSettingsHelper.GetParamValue("APP_DATE_FORMAT");
            dtpEndWorkDate.CustomFormat = AppSettingsHelper.GetParamValue("APP_DATE_FORMAT");

            _saveMsg = informationBar1.LabelText;
            _worker = WorkersHelper.GetWorker(id);
            LoadWorkerData();
            tbbSaveAndNew.Enabled = false;
            informationBar1.PanelText = "עדכון פרטי עובד: " + _worker.FullName;
            informationBar1.Image = Properties.Resources.tb_edit_small;

            if (chkActive.Checked == false)
            {
                chkAdmin.Enabled = false;
                chkCalPresent.Enabled = false;
                chkTraffic.Enabled = false;
            }

            _isLoadProc = false;
        }

        private void LoadWorkerData()
        {
            _cardId = _worker.CardId;
            txtAddress.Text = _worker.Address;
            txtCity.Text = _worker.City;
            txtEmail.Text = _worker.Email;
            txtFirstName.Text = _worker.FirstName;
            txtIdentity.Text = _worker.IdNumber;
            txtJob.Text = _worker.JobTitle;
            txtLastName.Text = _worker.LastName;
            txtMailCell.Text = _worker.MailCell;
            txtNotes.Text = _worker.Remark;
            txtPassword.Text = _worker.PersonalPassword;
            txtPhone1.Text = _worker.CellPhone1;
            txtPhone2.Text = _worker.CellPhone2;
            txtPhone3.Text = _worker.HomePhone;
            txtZipCode.Text = _worker.ZipCode;
            txtCardId.Text = _worker.CardId;
            cmbGender.SelectedIndex = Convert.ToInt32(_worker.Gender);
            dtpBirthDate.Value = _worker.BirthDate.HasValue ? _worker.BirthDate : null;
            dtpStartWork.Value = _worker.StartWorkDate.Equals(DateTime.MinValue) ? DateTime.Now.Date : _worker.StartWorkDate;
            chkActive.Checked = _worker.IsActive;
            chkAdmin.Checked = _worker.IsAdmin;
            chkTraffic.Checked = _worker.IsFillTraffic;
            dtpEndWorkDate.Value = _worker.EndWorkDate.Equals(DateTime.MinValue) ? DateTime.Now.Date : _worker.EndWorkDate;
            chkCalPresent.Checked = _worker.IsCalPresent;
            imagePicker1.ImageFilename = _worker.Picture;

            tbbCancelCard.Enabled = !string.IsNullOrEmpty(_worker.CardId);
        }

        private Worker UpdateWorkerData()
        {
            var w = new Worker
                        {
                            Address = txtAddress.Text,
                            City = txtCity.Text,
                            Email = txtEmail.Text,
                            FirstName = txtFirstName.Text,
                            IdNumber = txtIdentity.Text,
                            JobTitle = txtJob.Text,
                            CardId = _cardId,
                            LastName = txtLastName.Text,
                            MailCell = txtMailCell.Text,
                            Remark = txtNotes.Text,
                            PersonalPassword = txtPassword.Text,
                            CellPhone1 = txtPhone1.Text,
                            CellPhone2 = txtPhone2.Text,
                            HomePhone = txtPhone3.Text,
                            ZipCode = txtZipCode.Text,
                            Gender = (Worker.WorkerGender) Convert.ToInt32(cmbGender.SelectedIndex),
                            BirthDate = dtpBirthDate.Value,
                            StartWorkDate = dtpStartWork.Value,
                            IsActive = chkActive.Checked,
                            IsAdmin = chkAdmin.Checked,
                            IsFillTraffic = chkTraffic.Checked,
                            IsCalPresent = chkCalPresent.Checked,
                            EndWorkDate = dtpEndWorkDate.Visible ? dtpEndWorkDate.Value.Date : DateTime.MinValue,
                            Picture = imagePicker1.ImageFilename
                        };

            return w;
        }

        private void ClearForm()
        {
            _worker = new Worker();
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    if (!((TextBox)ctrl).ReadOnly)
                    {
                        ctrl.Text = string.Empty;
                        ctrl.BackColor = Color.White;
                    }
                }
            }
            tbbDelete.Enabled = false;
            dtpStartWork.Value = DateTime.Now.Date;
            dtpBirthDate.Value = DateTime.Now.Date;
            dtpBirthDate.Value = null;
            cmbGender.SelectedIndex = -1;
            _cardId = null;
            txtCardId.Clear();
            chkActive.Checked = true;
            chkAdmin.Checked = false;
            chkTraffic.Checked = true;
            txtFirstName.Select();
            imagePicker1.ClearImage();
            tbbCancelCard.Enabled = false;
        }

        private void SetAutoComplete()
        {
            var col = new AutoCompleteStringCollection();
            var table = ReportHelper.GetCities();

            foreach (DataRow row in table.Rows)
            {
                col.Add(row[0].ToString());
            }

            txtCity.AutoCompleteCustomSource = col;
        }

        private string ValidateForm()
        {
            var msg = string.Empty;

            // trim all text boxes
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = ctrl.Text.Trim();
                }
            }

            #region First Name

            if (txtFirstName.Text.Length == 0)
            {
                txtFirstName.BackColor = Validation.ErrorColor;
                msg += "לא הוזן שם פרטי. שדה זה הינו שדה חובה\n";
            }
            else
            {
                if (txtFirstName.Text.Length < 2)
                {
                    txtFirstName.BackColor = Validation.ErrorColor;
                    msg += "אנא הזן לפחות 2 תווים בשם הפרטי\n";
                }
                if (!Char.IsLetter(txtFirstName.Text, 0))
                {
                    txtFirstName.BackColor = Validation.ErrorColor;
                    msg += "שם פרטי חייב להתחיל באות עברית או לועזית\n";
                }
            }

            #endregion

            #region Last Name

            if (txtLastName.Text.Length == 0)
            {
                txtLastName.BackColor = Validation.ErrorColor;
                msg += "לא הוזן שם משפחה. שדה זה הינו שדה חובה\n";
            }
            else
            {
                if (txtLastName.Text.Length < 2)
                {
                    txtLastName.BackColor = Validation.ErrorColor;
                    msg += "אנא הזן לפחות 2 תווים בשם המשפחה\n";
                }
                if (!Char.IsLetter(txtLastName.Text, 0))
                {
                    txtLastName.BackColor = Validation.ErrorColor;
                    msg += "שם משפחה חייב להתחיל באות עברית או לועזית\n";
                }
            }

            #endregion

            #region birth date
            if (dtpBirthDate.Value.HasValue)
            {
                if (dtpBirthDate.Value.GetValueOrDefault().Date >= DateTime.Now.Date)
                {
                    msg += "תאריך הלידה צריך להיות קטן מהיום\n";
                }
            }
            #endregion

            #region Password

            if (txtPassword.Text.Length == 0)
            {
                txtPassword.BackColor = Validation.ErrorColor;
                msg += "לא הוזנה סיסמה אישית. שדה זה הינו שדה חובה\n";
            }
            else
            {
                if (txtPassword.Text.Length < 4)
                {
                    txtPassword.BackColor = Validation.ErrorColor;
                    msg += "אנא הזן לפחות 4 תווים בסיסמה האישית\n";
                }
            }

            #endregion

            #region Id

            if (!Validation.IsPersonIdNumberValid(txtIdentity.Text))
            {
                txtIdentity.BackColor = Validation.ErrorColor;
                msg += "מספר תעודת הזהות אינו תקין. יש להזין 9 ספרות\n";
            }
            else
            {
                if(_worker.Id == 0 || (_worker.Id > 0 && _worker.IdNumber != txtIdentity.Text))
                if (WorkersHelper.IsWorkerIdExist(txtIdentity.Text))
                {
                    txtIdentity.BackColor = Validation.ErrorColor;
                    msg += "מספר תעודת הזהות כבר קיים במאגר הנתונים\n";
                }
            }

            #endregion

            #region gender

            if (cmbGender.SelectedIndex == -1)
            {
                cmbGender.BackColor = Validation.ErrorColor;
                msg += "לא נבחר מין עבור העובד\n";
            }

            #endregion

            #region Email

            var email = txtEmail.Text;
            if (!Validation.IsEmailValid(email))
            {
                txtEmail.BackColor = Validation.ErrorColor;
                msg += "כתובת הדוא\"ל אינה תקינה\n";
            }

            #endregion

            #region city

            if (txtCity.Text.Length > 0)
            {
                if (!Char.IsLetter(txtCity.Text, 0))
                {
                    txtCity.BackColor = Validation.ErrorColor;
                    msg += "עיר חייבת להתחיל באות עברית או לועזית\n";
                }
            }

            #endregion

            #region ZipCode

            var zip = txtZipCode.Text;
            if (!Validation.IsZipCodeValid(zip))
            {
                txtZipCode.BackColor = Validation.ErrorColor;
                msg += "המיקוד אינו תקין\n";
            }

            #endregion

            #region Phones

            // validate phones
            var phone = Utils.DistilPhone(this.txtPhone1.Text);
            if (!Validation.IsCellPhoneValid(phone))
            {
                txtPhone1.BackColor = Validation.ErrorColor;
                if(Validation.IsLinePhoneValid(phone)) 
                    msg += "מספר הטלפון הנייד אינו תקין. המספר שהוזן הינו מספר קווי\n";
                else 
                    msg += "מספר הטלפון הנייד אינו תקין\n";
            }
            phone = Utils.DistilPhone(this.txtPhone3.Text);
            if (!Validation.IsLinePhoneValid(phone))
            {
                txtPhone3.BackColor = Validation.ErrorColor;
                if (Validation.IsCellPhoneValid(phone))
                    msg += "מספר הטלפון בבית אינו תקין. המספר שהוזן הינו מספר נייד\n";
                else
                    msg += "מספר הטלפון בבית אינו תקין\n";
            }
            phone = Utils.DistilPhone(this.txtPhone2.Text);
            if (!Validation.IsPhoneValid(phone))
            {
                txtPhone2.BackColor = Validation.ErrorColor;
                msg += "מספר הטלפון הנוסף אינו תקין\n";
            }

            #endregion

            #region StartWorkDate vs EndWorkDate

            if (dtpEndWorkDate.Visible)
            {
                if (dtpEndWorkDate.Value.Date < dtpStartWork.Value.Date)
                {
                    msg += "תאריך סיום העסקה קטן מתאריך תחילת העסקה\n";
                }
            }

            #endregion

            // ***** Must be the last validation *****
            #region Validate CellPhone at right place

            if (msg.Length == 0)
            {
                if (txtPhone1.Text.Length == 0)
                {
                    if (txtPhone2.Text.Length > 0 && Validation.IsCellPhoneValid(Utils.DistilPhone(txtPhone2.Text)))
                    {
                        txtPhone1.Text = txtPhone2.Text;
                        txtPhone2.Text = string.Empty;
                    }
                }
            }

            #endregion

            msg = msg.Trim();
            if (msg.Length == 0)
            {
                txtPhone1.Text = Validation.FormatPhone(txtPhone1.Text);
                txtPhone2.Text = Validation.FormatPhone(txtPhone2.Text);
                txtPhone3.Text = Validation.FormatPhone(txtPhone3.Text);
            }

            return msg;
        }

        private bool SaveData()
        {
            var msg1 = ValidateForm();
            const string msg2 = "שמירת פרטי עובד...";
            var isOk = false;

            if (msg1.Length == 0)
            {
                this.Cursor = Cursors.WaitCursor;

                var id = _worker.Id;
                var isCalPresent = _worker.IsCalPresent;
                _worker = UpdateWorkerData();
                _worker.Id = id;

                WorkerUpdateEventArgs.WorkerState state;

                if (_worker.Id == 0)
                {
                    _worker.Id = WorkersHelper.AddWorker(_worker);
                    if (_worker.Id > 0) isOk = true;
                    state = WorkerUpdateEventArgs.WorkerState.NewWorker;
                }
                else
                {
                    isOk = WorkersHelper.UpdateWorker(_worker);
                    if (isCalPresent && _worker.IsCalPresent == false) WorkersHelper.RemoveWorkerFromCalendar();
                    state = WorkerUpdateEventArgs.WorkerState.UpdatedWorker;
                }

                if (isOk)
                {
                    if (!_isOkNew && WorkerChange != null)
                        WorkerChange(this, new WorkerUpdateEventArgs(_worker, state));
                }
                else
                {
                    const string title = "שגיאה בניהול עובדים...";
                    var head = "שמירת נתוני העובד " + _worker.FullName;
                    const string desc = "שמירת נתוני העובד נכשלה\nשים לב כי הפרטים שהזנת בטופס לא נשמרו";
                    General.ShowErrorMessageDialog(this, title, head, desc, null, "frmWorkerDetails");
                }
            }
            else
            {
                informationBar1.LabelVisible = false;
                this.Cursor = Cursors.Default;
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
            }

            this.Cursor = Cursors.Default;
            return isOk;
        }

        private void FrmWorkerDetails_Load(object sender, EventArgs e)
        {
            _isLoadProc = true;
            SetAutoComplete();
            txtFirstName.Select();
            _isLoadProc = false;
        }

        public override void SetElementsResolutionFactor()
        {
            var width = Convert.ToInt32(pnlLeft.Width * General.ScreenResolutionFactorWidth);
            var left = Convert.ToInt32(pnlLeft.Left * General.ScreenResolutionFactorWidth);

            pnlLeft.Width = width;
            pnlRight.Width = width;
            pnlButtom.Width = Convert.ToInt32(pnlButtom.Width * General.ScreenResolutionFactorWidth);

            pnlLeft.Left = left;
            pnlButtom.Left = left;
            pnlRight.Left = pnlLeft.Right;
        }

        private void TbbSave_Click(object sender, EventArgs e)
        {
            if (SaveData()) this.Close();
        }

        private void TbbSaveAndNew_Click(object sender, EventArgs e)
        {
            _isOkNew = true;
            if (SaveData())
            {
                informationBar1.LabelText = string.Format(_saveMsg, "\"" + _worker.FullName + "\"");
                informationBar1.LabelVisible = true;
                _isNeedToReloadWorkers = true;
                ClearForm();
                SetAutoComplete();
            }
            _isOkNew = false;
        }

        private void TbbCloseClick(object sender, EventArgs e)
        {
            if (_isNeedToReloadWorkers && WorkerChange != null)
            {
                WorkerChange(this, new WorkerUpdateEventArgs(_worker, WorkerUpdateEventArgs.WorkerState.NewWorker));
            }
            this.Close();
        }

        private void TbbDeleteClick(object sender, EventArgs e)
        {
            const string msg2 = "מחיקת עובד...";

            if (_worker == null) return;

            if (_worker.IsAdmin)
            {
                var isLast = WorkersHelper.IsWorkerLastAdmin(_worker.Id);
                if (isLast)
                {
                    var msg4 = "המשתמש " + _worker.FullName + " הנו מנהל המערכת היחיד\nולא ניתן למחוק אותו מהמערכת";
                    MsgBox = new MyMessageBox(msg4, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                    MsgBox.Show(this);
                    return;
                }
            }

            var msg1 = "האם אתה בטוח שברצונך למחוק את העובד:\n" + _worker.FullName + "\n\nשים לב: כל התורים המקושרים לעובד זה לא יהיו מקושרים לאף עובד\nוכל רישומי הנוכחות של העובד ימחקו אף הם";
            MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
            var res = MsgBox.Show(this);

            if (res == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                var isOk = WorkersHelper.DeleteWorker(_worker.Id);
                this.Cursor = Cursors.Default;

                if (isOk)
                {
                    if (WorkerChange != null) WorkerChange(this, new WorkerUpdateEventArgs(_worker, WorkerUpdateEventArgs.WorkerState.DeleteWorker));
                    this.Close();
                }
                else
                {
                    const string title = "שגיאה בניהול עובדים...";
                    var head = "מחיקת העובד " + _worker.FullName;
                    const string desc = "מחיקת העובד נכשלה\nשים לב כי העובד עדיין במאגר העובדים שלך.\nמומלץ להפוך את העובד ללא פעיל ולא למחוק אותו";
                    General.ShowErrorMessageDialog(this, title, head, desc, null, "frmWorkerDetails");
                }
            }
        }

        private void ImagePicker1WebCamCapture(object sender, ImagePicker.WebCamCaptureEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                var filename = Utils.SaveImageFile(e.CaptureImage);
                imagePicker1.ImageFilename = filename;
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                const string title = "שגיאה בניהול עובדים...";
                const string head = "שמירת תמונה ממצלמה";
                var desc = "שמירת התמונה שצילמת במצלמה נכשלה\nשים לב כי לעובד " + _worker.FullName + " לא עודכנה התמונה";
                General.ShowErrorMessageDialog(this, title, head, desc, ex, "frmWorkerDetails");
            }
        }

        protected void TextBoxFocus(object sender, EventArgs e)
        {
            base.TextBoxEnter((TextBox)sender);
        }

        protected void TextBoxLostFocus(object sender, EventArgs e)
        {
            base.TextBoxLeave((TextBox)sender);
        }

        private void TbbPrintClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var w = UpdateWorkerData();
            var parameters = w.GetPrintData();
            //parameters[16] = cmbCard.Text;
            var printer = new HtmlPrinter("WORKER_FORM", parameters);
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
        }

        private bool IsLastAdmin()
        {
            var result = false;
            var isLast = WorkersHelper.IsWorkerLastAdmin(_worker.Id);
            if ((!(_worker.Id == 0 || _worker.IsAdmin == false)) && isLast)
            {
                var msg1 = "העובד " + _worker.FullName + " הנו מנהל המערכת היחיד\nולא ניתן להגדיר אותו כלא פעיל";
                const string msg2 = "עדכון פרטי עובד...";
                chkActive.Checked = true;
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
                result = true;
            }
            return result;
        }

        private bool IsConfirmDetachWorker()
        {
            var result = true;
            string msg1;
            const string msg2 = "עדכון פרטי עובד...";

            if (WorkersHelper.GetCalendarWorkersCount(_worker.Id) == 0)
            {
                msg1 = "לא ניתן להסיר את העובד מהיומן\nזהו העובד היחיד ביומן";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
                return false;
            }

            if (_worker.IsCalPresent)
            {
                msg1 = "שים לב! כל התורים ביומן של העובד " + _worker.FullName + " לא יהיו משוייכם לאף עובד\nניתן יהיה לראות אותם ביומן ולשייך אותם לעובד אחר\nהאם אתה בטוח שברצונך להסיר אותו מהיומן";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
                var res = MsgBox.Show(this);
                result = (res == DialogResult.Yes);
            }

            return result;
        }

        private void ChkActiveCheckedChanged(object sender, EventArgs e)
        {
            var cb = (CheckBox)sender;
            cb.BackColor = cb.Checked ? Color.LightSteelBlue : Color.FromArgb(232, 237, 243);
            if (_ignoreEvent) return;
            if (_isLoadProc) return;

            if (sender.Equals(chkActive))
            {
                #region chkActive
                if (chkActive.Checked)
                {
                    _ignoreEvent = true;
                    chkAdmin.Enabled = true;
                    chkTraffic.Enabled = true;
                    chkCalPresent.Enabled = true;
                    cmbEndWorkDate.Visible = true;
                    dtpEndWorkDate.Visible = false;
                    _ignoreEvent = false;
                }
                else
                {
                    var check = !IsLastAdmin();
                    if (_worker.IsCalPresent) check = check && IsConfirmDetachWorker();
                    if (check)
                    {
                        _ignoreEvent = true;
                        chkAdmin.Checked = false;
                        chkTraffic.Checked = false;
                        chkCalPresent.Checked = false;
                        chkAdmin.Enabled = false;
                        chkTraffic.Enabled = false;
                        chkCalPresent.Enabled = false;
                        dtpEndWorkDate.Value = DateTime.Now.Date;
                        dtpEndWorkDate.Visible = true;
                        cmbEndWorkDate.Visible = false;
                        _ignoreEvent = false;
                    }
                    else
                    {
                        _ignoreEvent = true;
                        chkActive.Checked = true;
                        _ignoreEvent = false;
                    }
                }
                #endregion
            }
            else if (sender.Equals(chkTraffic))
            {
                if (chkTraffic.Checked)
                {
                    _ignoreEvent = true;
                    //cmbCard.Enabled = true;
                    //cmbCard.SelectedValue = worker.CardId;
                    _ignoreEvent = false;
                }
                else
                {
                    _ignoreEvent = true;
                    //cmbCard.Enabled = false;
                    //cmbCard.SelectedIndex = -1;
                    _ignoreEvent = false;
                }
            }
            else if (sender.Equals(chkAdmin))
            {
                #region Alert Admin Mode

                if (_worker.IsAdmin == false && chkAdmin.Checked)
                {
                    var msg1 = "שים לב! הנך עומד לתת לעובד " + _worker.FullName + " הרשאות מנהל מערכת\nהאם אתה בטוח שברצונך לבצע פעולה זו";
                    const string msg2 = "הרשאות מנהל...";
                    MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
                    var res = MsgBox.Show(this);

                    if (res == DialogResult.No) chkAdmin.Checked = false;
                }

                #endregion

                #region Last Admin Check

                if (chkAdmin.Checked == false)
                {
                    if (!(_worker.Id == 0 || _worker.IsAdmin == false))
                    {
                        if (WorkersHelper.IsWorkerLastAdmin(_worker.Id))
                        {
                            var msg1 = "המשתמש " + _worker.FullName + " הנו מנהל המערכת היחיד\nולא ניתן לבטל לו את הרשאות מנהל המערכת";
                            const string msg2 = "הרשאות מנהל...";
                            chkAdmin.Checked = true;
                            MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                            MsgBox.Show(this);
                        }
                    }
                }

                #endregion
            }
            else if(sender.Equals(chkCalPresent))
            {
                if (chkCalPresent.Checked == false)
                {
                    if (!IsConfirmDetachWorker()) chkCalPresent.Checked = true;
                }
            }
        }

        private void FrmWorkerDetailsRequestForClose(object sender, EventArgs e)
        {
            TbbCloseClick(null, null);
        }

        private void CmbGenderDropDown(object sender, EventArgs e)
        {
            base.ControlClearBgColor(cmbGender);
        }

        private void FrmWorkerDetailsKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.S:
                    if (e.Control && !e.Alt && !e.Shift)
                    {
                        if (tbbSave.Enabled) TbbSave_Click(null, null);
                    }
                    break;
            }
        }

        private void DtpBirthDateValidating(object sender, CancelEventArgs e)
        {
            if (_isLoadProc) return;
            var cur = txtPassword.Text.Trim();
            if (cur.Length == 0 || cur.Equals(_lastAutoPassword))
            {
                txtPassword.Text = dtpBirthDate.Value.HasValue ? dtpBirthDate.Value.GetValueOrDefault().ToString("ddMM") : string.Empty;
                _lastAutoPassword = txtPassword.Text;
            }
        }

        //private void SetCardIdField(string cardId)
        //{

        //}

        public void ProcessCard(string value)
        {
            var cardId = value.Substring(General.WorkerCardPattern.FromIndex, General.WorkerCardPattern.Length);
            var id = WorkersHelper.GetWorkerIdByCardId(cardId);
            
            if (!(_fCard == null || _fCard.IsDisposed))
            {
                if (id > 0)
                {
                    if (_worker.Id == id)
                    {
                        if (string.IsNullOrEmpty(_cardId))
                        {
                            _fCard.Hide();
                            _fCard.Close();
                            _cardId = cardId;
                            txtCardId.Text = _cardId;
                            tbbCancelCard.Enabled = true;
                        }
                        else
                        {
                            _fCard.ShowErrorMessage("הכרטיס שהועבר כבר משוייך\nלעובד הנוכחי");
                        }
                    }
                    else
                    {
                        var w = WorkersHelper.GetWorker(id);
                        _fCard.ShowErrorMessage("הכרטיס שהועבר משוייך לעובד\n" + w.FullName);
                    }
                }
                else
                {
                    _fCard.Hide();
                    _fCard.Close();
                    _cardId = cardId;
                    txtCardId.Text = _cardId;
                    tbbCancelCard.Enabled = true;
                }
            }
        }

        private void TbbCancelCardClick(object sender, EventArgs e)
        {
            _cardId = null;
            txtCardId.Clear();
            tbbCancelCard.Enabled = false;
        }

        private void TbbAddCardClick(object sender, EventArgs e)
        {
            using (_fCard = new FormCard(FormCard.CardEntityType.Worke))
            {
                _fCard.ShowDialog();
            }
        }

        private void TbbMagneticCardButtonClick(object sender, EventArgs e)
        {
            if (!tbbCancelCard.Enabled) TbbAddCardClick(null, null);
            else tbbMagneticCard.ShowDropDown();
        }

        private void FormWorkerDetails_SizeChanged(object sender, EventArgs e)
        {
            pnlButtom.Height = this.Height - pnlButtom.Top - 16;
        }
    }
}

