using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ClientManage.Interfaces;
using ClientManage.Library;
using ClientManage.BL;
using ClientManage.BL.Library;
using ClientManage.Properties;

namespace ClientManage.Forms
{
    public partial class FormContactDetails : BaseMdiChild
    {
        #region Private

            #region Members

        private PhoneBookContact _contact;
        private bool _isOkNew;
        private bool _isNeedToReloadContacts;
        private readonly string _saveMsg = string.Empty;

            #endregion

            #region Functions

        private void LoadContactData()
        {
            txtAddPhone2.Text = _contact.PhoneNo3;
            txtAddPhone1.Text = _contact.PhoneNo2;
            txtAddress.Text = _contact.Street;
            txtCellPhone.Text = _contact.PhoneNo1;
            txtCity.Text = _contact.City;
            txtCompany.Text = _contact.Company;
            txtEmail.Text = _contact.Email;
            txtFax.Text = _contact.Fax;
            txtFirstName.Text = _contact.FirstName;
            txtJob.Text = _contact.JobTitle;
            txtLastName.Text = _contact.LastName;
            txtMailCell.Text = _contact.MailCellNo;
            txtNotes.Text = _contact.Notes;
            txtWebSite.Text = _contact.WebSite;
            txtZipCode.Text = _contact.ZipCode;
            imagePicker1.ImageFilename = _contact.Picture;
        }

        private PhoneBookContact UpdateContactData()
        {
            var contact = new PhoneBookContact
            {
                PhoneNo3 = txtAddPhone2.Text,
                PhoneNo2 = txtAddPhone1.Text,
                Street = txtAddress.Text,
                PhoneNo1 = txtCellPhone.Text,
                City = txtCity.Text,
                Company = txtCompany.Text,
                Email = txtEmail.Text,
                Fax = txtFax.Text,
                FirstName = txtFirstName.Text,
                JobTitle = txtJob.Text,
                LastName = txtLastName.Text,
                MailCellNo = txtMailCell.Text,
                Notes = txtNotes.Text,
                WebSite = txtWebSite.Text,
                ZipCode = txtZipCode.Text,
                Picture = imagePicker1.ImageFilename
            };

            return contact;
        }

        private void ClearForm()
        {
            _contact = new PhoneBookContact();
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = string.Empty;
                    ctrl.BackColor = Color.White;
                }
            }
            txtFirstName.Select();
            imagePicker1.ClearImage();
        }

        // fill city field auto-complete values
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
            imagePicker1.Select();

            // validate fitst name
            if (txtFirstName.Text.Length == 0)
            {
                txtFirstName.BackColor = Validation.ErrorColor;
                msg += "לא הוזן שם פרטי/מלא. שדה זה הינו שדה חובה\n";
            }
            else
            {
                if (txtFirstName.Text.Length < 2)
                {
                    txtFirstName.BackColor = Validation.ErrorColor;
                    msg += "אנא הזן לפחות 2 תווים בשם הפרטי/מלא\n";
                }
                if (!Char.IsLetter(txtFirstName.Text, 0))
                {
                    txtFirstName.BackColor = Validation.ErrorColor;
                    msg += "שם פרטי/מלא חייב להתחיל באות עברית או לועזית\n";
                }
            }

            // validate email
            var email = txtEmail.Text;
            if (!Validation.IsEmailValid(email))
            {
                txtEmail.BackColor = Validation.ErrorColor;
                msg += "כתובת הדוא\"ל אינה תקינה\n";
            }

            // validate zipcode
            var zip = txtZipCode.Text;
            if (!Validation.IsZipCodeValid(zip))
            {
                txtZipCode.BackColor = Validation.ErrorColor;
                msg += "המיקוד אינו תקין\n";
            }

            // validate phones
            var phone = Utils.DistilPhone(this.txtAddPhone1.Text);
            if (!Validation.IsPhoneValid(phone))
            {
                txtAddPhone1.BackColor = Validation.ErrorColor;
                msg += "מספר הטלפון בעבודה אינו תקין\n";
            }
            phone = Utils.DistilPhone(this.txtAddPhone2.Text);
            if (!Validation.IsPhoneValid(phone))
            {
                txtAddPhone2.BackColor = Validation.ErrorColor;
                msg += "מספר הטלפון בבית / נוסף אינו תקין\n";
            }
            phone = Utils.DistilPhone(this.txtCellPhone.Text);
            if (!Validation.IsCellPhoneValid(phone))
            {
                txtCellPhone.BackColor = Validation.ErrorColor;
                if (Validation.IsLinePhoneValid(phone)) { msg += "מספר הטלפון הנייד אינו תקין. המספק שהוזן הינו מספר קווי\n"; }
                else { msg += "מספר הטלפון הנייד אינו תקין\n"; }
            }
            phone = Utils.DistilPhone(this.txtFax.Text);
            if (!Validation.IsPhoneValid(phone))
            {
                txtFax.BackColor = Validation.ErrorColor;
                msg += "מספר הפקס אינו תקין\n";
            }

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

            // ***** Must be the last validation *****
            #region Validate CellPhone at right place

            if (msg.Length == 0)
            {
                if (txtCellPhone.Text.Length == 0)
                {
                    if (txtAddPhone1.Text.Length > 0 && Validation.IsCellPhoneValid(Utils.DistilPhone(txtAddPhone1.Text)))
                    {
                        txtCellPhone.Text = txtAddPhone1.Text;
                        txtAddPhone1.Text = string.Empty;
                    }
                    else if(txtAddPhone2.Text.Length > 0 && Validation.IsCellPhoneValid(Utils.DistilPhone(txtAddPhone2.Text)))
                    {
                        txtCellPhone.Text = txtAddPhone2.Text;
                        txtAddPhone2.Text = string.Empty;
                    }
                }
            }

            #endregion

            msg = msg.Trim();
            if (msg.Length == 0)
            {
                txtCellPhone.Text = Validation.FormatPhone(txtCellPhone.Text);
                txtAddPhone1.Text = Validation.FormatPhone(txtAddPhone1.Text);
                txtAddPhone2.Text = Validation.FormatPhone(txtAddPhone2.Text);
                txtFax.Text = Validation.FormatPhone(txtFax.Text);
            }

            return msg;
        }

        private bool SaveData()
        {
            var msg1 = ValidateForm();
            var id = _contact.Id;
            _contact = UpdateContactData();
            _contact.Id = id;
            const string msg2 = "שמירת פרטי לקוח...";
            var isOk = false;

            if (msg1.Length == 0)
            {
                this.Cursor = Cursors.WaitCursor;

                int ret;
                ContactUpdateEventArgs.ContactState state;

                if (_contact.Id == 0)
                {
                    ret = PhoneBookHelper.AddContact(ref _contact);
                    state = ContactUpdateEventArgs.ContactState.NewContact;
                }
                else
                {
                    ret = PhoneBookHelper.UpdateContact(_contact);
                    state = ContactUpdateEventArgs.ContactState.UpdatedContact;
                }

                if (ret > 0)
                {
                    if (!_isOkNew && ContactUpdate != null)
                        ContactUpdate(this, new ContactUpdateEventArgs(_contact, state));
                    isOk = true;
                }
                else
                {
                    this.Cursor = Cursors.Default;

                    const string title = "שגיאה באלפון ספקים...";
                    const string head = "שמירת נתוני איש קשר";
                    const string desc = "ארעה שגיאה כלשהי בתהליך שמירת נתוני איש הקשר\nשים לב כי הנתונים שהזנת לא נשמרו";
                    General.ShowErrorMessageDialog(this, title, head, desc, null, "frmContactDetails");
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
        
        #endregion

        #endregion

        #region Public

        #region Events

        public event ContactUpdateEventHandler ContactUpdate;

            #endregion

        #endregion

        #region Constuctor

        public FormContactDetails()
        {
            InitializeComponent();
            _saveMsg = informationBar1.LabelText;
            imagePicker1.EnableWebCam = AppSettingsHelper.GetParamValue<bool>("MAIN_ENABLE_WEBCAM");
            imagePicker1.DefaultImage = Resources.no_image_big;

            _contact = new PhoneBookContact();
            imagePicker1.ClearImage();
            tbbDelete.Enabled = false;
            informationBar1.PanelText = "הוספת איש קשר חדש";
            informationBar1.Image = Resources.new_small;
        }

        public FormContactDetails(int id)
        {
            InitializeComponent();
            _saveMsg = informationBar1.LabelText;
            imagePicker1.EnableWebCam = AppSettingsHelper.GetParamValue<bool>("MAIN_ENABLE_WEBCAM");
            imagePicker1.DefaultImage = Resources.no_image_big;

            _contact = PhoneBookHelper.GetContact(id);
            LoadContactData();
            tbbSaveAndNew.Enabled = false;
            informationBar1.PanelText = "עדכון פרטי איש קשר: " + _contact.FullName;
            informationBar1.Image = Resources.tb_edit_small;
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

        #endregion

        #region Form & Controls Events

        private void FrmContactDetails_Load(object sender, EventArgs e)
        {           
            SetAutoComplete();
            txtFirstName.Select();
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
                informationBar1.LabelText = string.Format(_saveMsg, "\"" + _contact.FullName + "\"");
                informationBar1.LabelVisible = true;
                _isNeedToReloadContacts = true;
                ClearForm();
                SetAutoComplete();
            }
            _isOkNew = false;
        }

        private void TbbClose_Click(object sender, EventArgs e)
        {
            if (_isNeedToReloadContacts && ContactUpdate != null)
            {
                ContactUpdate(this, new ContactUpdateEventArgs(_contact, ContactUpdateEventArgs.ContactState.NewContact));
            }
            this.Close();
        }

        private void TbbDelete_Click(object sender, EventArgs e)
        {
            const string msg2 = "מחיקת איש קשר...";

            if (_contact == null) return;

            var msg1 = "האם אתה בטוח שברצונך למחוק את איש הקשר:\n" + _contact.FullName;
            MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
            var res = MsgBox.Show(this);
            if (res == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                PhoneBookHelper.DeleteContact(_contact.Id);
                this.Cursor = Cursors.Default;
                if(ContactUpdate != null) ContactUpdate(this, new ContactUpdateEventArgs(_contact, ContactUpdateEventArgs.ContactState.DeleteContact));
                this.Close();
            }
        }

        private void ImagePicker1_WebCamCapture(object sender, ImagePicker.WebCamCaptureEventArgs e)
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
                const string title = "שגיאה באלפון ספקים...";
                const string head = "הפעלת המצלמה";
                const string desc = "הפעלת מצלמת האינטרנט נכשלה\nוודא כי המצלמה מחוברת כראוי, אם כן נתק וחבר אותה שוב";
                General.ShowErrorMessageDialog(this, title, head, desc, ex, "frmContactDetails");
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

        private void TbbPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var contact = UpdateContactData();
            var printer = new HtmlPrinter("CONTACT_FORM", contact.GetPrintData());
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

        #endregion

        private void FrmContactDetails_RequestForClose(object sender, EventArgs e)
        {
            TbbClose_Click(null, null);
        }

        private void FrmContactDetails_KeyDown(object sender, KeyEventArgs e)
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

        private void FormContactDetails_SizeChanged(object sender, EventArgs e)
        {
            pnlButtom.Height = this.Height - pnlButtom.Top - 16;
        }
    }
}