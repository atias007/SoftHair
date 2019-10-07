using BizCare.Calendar.Library;
using ClientManage.BL;
using ClientManage.BL.Library;
using ClientManage.Interfaces;
using ClientManage.Library;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ClientManage.Forms
{
    public partial class FormClients : BaseMdiChild
    {
        public enum FormStatus { View, Edit, New, Delete };

        #region Private

        #region Private Memebers

        // client class, containg all current client information
        private Client _c;

        private Byte _curSubTab;

        // variable of the form status
        private FormStatus _myStatus = FormStatus.View;

        private FormStatus MyStatus
        {
            get { return _myStatus; }
            set
            {
                _myStatus = value;
                var isEditOrNew = (_myStatus == FormStatus.Edit || _myStatus == FormStatus.New);
                lblMustFields1.Visible = isEditOrNew;
                lblMustFields2.Visible = isEditOrNew;
                tbbPrivacy.Visible = isEditOrNew;
                tbbMagneticCard.Visible = isEditOrNew;
                tbbSave.Visible = isEditOrNew;
                tbbCancel.Visible = isEditOrNew;
                tbbSep1.Visible = isEditOrNew;
                // ReSharper disable PossibleNullReferenceException
                ((DataGridViewImageColumn)grdComponents.Columns["col_delete"]).Image =
                    // ReSharper restore PossibleNullReferenceException
                    (_myStatus == FormStatus.Edit || _myStatus == FormStatus.New) ?
                    Properties.Resources.cancel_small : Properties.Resources.cancel_small_dis;
            }
        }

        private bool _isBackToSearchForm;
        private bool _inCheckPhonesProc;
        private readonly bool _isPopup;
        private readonly ClientNavigator _navigator = new ClientNavigator();
        private Thread _bulletsThread;
        private FormCard _fCard;

        #endregion Private Memebers

        #region Private Functions

        private void SelectColorRow(int curColIndex, int rowIndex)
        {
            if (rowIndex >= 0 && curColIndex >= 0)
            {
                // ReSharper disable PossibleNullReferenceException
                if (curColIndex == grdComponents.Columns["col_delete"].Index)
                // ReSharper restore PossibleNullReferenceException
                {
                    grdComponents.Rows[rowIndex].Selected = true;
                }
            }
        }

        private void DeleteColorGridRow(int rowIndex)
        {
            if (!grdComponents.Rows[rowIndex].IsNewRow)
            {
                const string msg1 = "האם אתה בטוח שברצונך למחוק את צבע השיער המסומן ברשימה?";
                const string msg2 = "כרטיסיית צבעי שיער...";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
                var res = MsgBox.Show(this);

                if (res == DialogResult.Yes)
                {
                    grdComponents.Select();
                    SendKeys.Send("{DELETE}");
                }
            }
        }

        private void LoadCombos()
        {
            cmbClientType.DataSource = ClientHelper.GetClientsType();
            cmbClientType.DisplayMember = "description";
            cmbClientType.ValueMember = "id";

            RefreshWorkersList();
        }

        private void ShowItem()
        {
            if (OpenForm != null)
            {
                if (grdTopVisits.SelectedRows.Count > 0)
                {
                    var id = Convert.ToString(grdTopVisits.SelectedRows[0].Cells["clmId"].Value);
                    Appointment app;
                    try
                    {
                        app = FormCalendar.GetAppointmentFromDataRow(CalendarHelper.GetAppointment(id));
                    }
                    catch (Exception ex)
                    {
                        General.ShowCommunicationError(ex, this);
                        return;
                    }
                    OpenForm(this, new OpenFormEventArgs("frmCalendar", app));
                    if (_isPopup) this.Close();
                }
            }
        }

        private void EnableToolstrip(bool value)
        {
            foreach (ToolStripItem item in toolStrip.Items)
            {
                if (item.Tag == null) item.Visible = value;
            }
        }

        // load all user data from database to the controls of this form
        private void LoadData(Client c)
        {
            if (c == null)
            {
                const string title = "שגיאה בכרטיסי לקוחות...";
                const string head = "טעינת פרטי לקוח";
                const string desc = "ארעה שגיאה בטעינת פרטי לקוח במערכת\nייתכן והלקוח נמחק ואינו במאגר הנתונים.";
                General.ShowErrorMessageDialog(this, title, head, desc, null, "frmClients");
            }
            else
            {
                lblBulletCard.Tag = c.CardId;
                txtFirstName.Text = c.FirstName;
                txtAddress.Text = c.Address;
                txtCellPhone1.Text = c.CellPhone1;
                txtCellPhone2.Text = c.CellPhone2;
                txtCity.Text = c.City;
                txtDateCreated.Text = Utils.GetDateTimeShortString(c.CreateDate);
                txtEmail.Text = c.Email;
                txtHomePhone.Text = c.HomePhone;
                txtLastName.Text = c.LastName;

                txtRemark.Text = c.Remark;
                txtWorkPhone.Text = c.WorkPhone;
                txtZipCode.Text = c.ZipCode;
                dtpBirthDate.Value = c.BirthDate;
                dtpMarriedDate.Value = c.MarriedDate;
                cmbClientType.SelectedIndex = -1;
                cmbWorker.SelectedIndex = -1;
                cmbGender.SelectedIndex = Convert.ToInt32(c.Gender);
                cmbClientType.SelectedValue = c.ClientTypeId;
                cmbWorker.SelectedValue = c.WorkerId;
                if (cmbClientType.SelectedIndex == -1) cmbClientType.SelectedIndex = 0;
                if (cmbWorker.SelectedIndex == -1) cmbWorker.SelectedIndex = 0;

                var bday = c.BirthDate.HasValue ? c.BirthDate.GetValueOrDefault().ToString("dd/MM/yyyy") : "ללא תאריך לידה";
                if (bday.EndsWith(Utils.DefaultBdayYear.ToString(CultureInfo.InvariantCulture))) bday = bday.Replace(Utils.DefaultBdayYear.ToString(CultureInfo.InvariantCulture), "0000");
                txtBirthDate.Text = bday;

                var mday = c.MarriedDate.HasValue ? c.MarriedDate.GetValueOrDefault().ToString("dd/MM/yyyy") : "ללא תאריך נישואין";
                if (mday.EndsWith(Utils.DefaultBdayYear.ToString(CultureInfo.InvariantCulture))) mday = mday.Replace(Utils.DefaultBdayYear.ToString(CultureInfo.InvariantCulture), "0000");
                txtMarriedDate.Text = mday;

                txtGender.Text = cmbGender.Text;
                txtClientType.Text = cmbClientType.Text;
                txtWorker.Text = cmbWorker.Text;
                lblCellPrivacy.Visible = !c.EnableSMS;
                lblEmailPrivacy.Visible = !c.EnableEmail;
                mnuSMSPrivacy.Checked = c.EnableSMS;
                mnuEmailPrivacy.Checked = c.EnableEmail;

                StartShowBulletsThread();

                imagePicker1.ImageFilename = c.Picture;

                FillTopVisits(c);
                SetColorsGridData(c.Id);

                RefreshNavigateData();

                // bulid phone toolStrip items
                splitPhone.DropDownItems.Clear();
                mnuCall.DropDownItems.Clear();
                if (!string.IsNullOrEmpty(c.CellPhone1)) splitPhone.DropDownItems.Add(Utils.DistilPhone(c.CellPhone1), null, SplitPhoneItem_ButtonClick);
                if (!string.IsNullOrEmpty(c.CellPhone2)) splitPhone.DropDownItems.Add(Utils.DistilPhone(c.CellPhone2), null, SplitPhoneItem_ButtonClick);
                if (!string.IsNullOrEmpty(c.HomePhone)) splitPhone.DropDownItems.Add(Utils.DistilPhone(c.HomePhone), null, SplitPhoneItem_ButtonClick);
                if (!string.IsNullOrEmpty(c.WorkPhone)) splitPhone.DropDownItems.Add(Utils.DistilPhone(c.WorkPhone), null, SplitPhoneItem_ButtonClick);
                foreach (ToolStripItem item in splitPhone.DropDownItems)
                {
                    mnuCall.DropDownItems.Add(item.Text, null, SplitPhoneItem_ButtonClick);
                }
                splitPhone.Enabled = splitPhone.DropDownItems.Count > 0;
                mnuCall.Enabled = splitPhone.Enabled;
                tbbCancelCard.Enabled = !string.IsNullOrEmpty(c.CardId);
            }
        }

        private void FillTopVisits(Client c)
        {
            if (grdTopVisits.Visible == false) return;
            try
            {
                grdTopVisits.DataSource = CalendarHelper.GetTopClientsVisits(c.Id);
            }
            catch (Exception ex)
            {
                General.ShowCommunicationError(ex, this, false);
                grdTopVisits.DataSource = null;
            }
        }

        public void StartShowBulletsThread()
        {
            HideBullets();
            if (_isPopup || _c == null) return;
            if (_bulletsThread != null && _bulletsThread.IsAlive) _bulletsThread.Abort();
            _bulletsThread = null;
            GC.Collect();
            _bulletsThread = new Thread(ShowBulletsThread);
            _bulletsThread.Start();
        }

        private void ShowBulletsThread()
        {
            Application.DoEvents();
            Thread.Sleep(333);
            ClientHelper.SetTotalValues(_c);

            try
            {
                if (this.InvokeRequired) this.Invoke(new MethodInvoker(ShowBullets));
                else ShowBullets();
            }
            catch
            {
                Thread.Sleep(1000);
                if (this.InvokeRequired) this.Invoke(new MethodInvoker(ShowBullets));
                else ShowBullets();
            }
        }

        public void ShowBulletsTotals()
        {
            ClientHelper.SetTotalValues(_c);
            lblBulletPic.Visible = _c.TotalPhotos > 0;
            lblBulletPic.Text = _c.TotalPhotos.ToString(CultureInfo.InvariantCulture);
            lblBulletSub.Visible = _c.TotalSubscriptions > 0;

            lblBulletSub.Text = _c.TotalSubscriptions.ToString(CultureInfo.InvariantCulture);
        }

        private void ShowBullets()
        {
            lblBulletBday.Visible = _c.IsTodayBirthday;
            lblBulletMarr.Visible = _c.IsTodayMarriedDay;
            lblBulletCard.Visible = !string.IsNullOrEmpty(_c.CardId);
            lblBulletPic.Visible = _c.TotalPhotos > 0;
            lblBulletPic.Text = _c.TotalPhotos.ToString(CultureInfo.InvariantCulture);
            lblBulletSub.Visible = _c.TotalSubscriptions > 0;
            lblBulletSub.Text = _c.TotalSubscriptions.ToString(CultureInfo.InvariantCulture);
        }

        private void HideBullets()
        {
            lblBulletBday.Visible = false;
            lblBulletCard.Visible = false;
            lblBulletMarr.Visible = false;
            lblBulletPic.Visible = false;
            lblBulletSub.Visible = false;
        }

        public void RefreshNavigateData()
        {
            var pos = _navigator.GetNextAndPrevClientId();
            _c.NextClientId = pos[1];
            _c.PrevClientId = pos[0];
            _c.Key = _navigator.Key;
            tbbPrev.Enabled = (_c.PrevClientId > 0);
            tbbNext.Enabled = (_c.NextClientId > 0);
            mnuPrev.Enabled = tbbPrev.Enabled;
            mnuNext.Enabled = tbbNext.Enabled;
        }

        // save / update all data on form into database
        private bool SaveData()
        {
            // create new client
            if (MyStatus == FormStatus.New) _c = new Client();

            // set client properties
            _c.CardId = Utils.GetDBValue<string>(lblBulletCard.Tag);
            _c.FirstName = txtFirstName.Text;
            _c.Address = txtAddress.Text;
            _c.CellPhone1 = txtCellPhone1.Text;
            _c.CellPhone2 = txtCellPhone2.Text;
            _c.City = txtCity.Text;
            _c.Email = txtEmail.Text;
            _c.HomePhone = txtHomePhone.Text;
            _c.LastName = txtLastName.Text;
            _c.MarriedDate = dtpMarriedDate.Value;
            _c.Remark = txtRemark.Text;
            _c.WorkPhone = txtWorkPhone.Text;
            _c.ZipCode = txtZipCode.Text;
            _c.Gender = (Client.ClientGender)cmbGender.SelectedIndex;
            _c.ClientTypeId = (int)cmbClientType.SelectedValue;
            _c.WorkerId = (int)cmbWorker.SelectedValue;
            _c.BirthDate = dtpBirthDate.Value;
            _c.Picture = imagePicker1.ImageFilename;
            _c.EnableEmail = mnuEmailPrivacy.Checked;
            _c.EnableSMS = mnuSMSPrivacy.Checked;

            if (!string.IsNullOrEmpty(_c.Picture))
            {
                if (!_c.Picture.StartsWith(Path.Combine(General.StartupPath, "ClientImages")))
                {
                    try
                    {
                        var image = Image.FromFile(_c.Picture);
                        image = Utils.GetThumbnailImage(image);
                        _c.Picture = Utils.SaveImageFile(image);
                        image.Dispose();
                    }
                    catch (Exception ex)
                    {
                        var msg = "Error loading client picture in save proccess: client id=" + _c.Id + ", picture=" + _c.Picture;
                        EventLogManager.AddErrorMessage(msg, ex);
                    }
                }
            }

            var ret = 0;
            if (MyStatus == FormStatus.Edit)
            {
                ret = ClientHelper.UpdateClient(_c);
                OnSyncClients();
                _navigator.CurrentClientId = _c.Id;
            }
            else if (MyStatus == FormStatus.New)
            {
                ret = ClientHelper.AddClient(_c);
                OnSyncClients();
                _c = ClientHelper.GetClient(ret) ?? new Client(ret);
                _navigator.CurrentClientId = ret;
            }
            SaveColorGrid();
            RefreshNavigateData();
            return ret > 0;
        }

        // validate all information the user set in the form, return string of all error messages
        private string ValidateForm()
        {
            var msg = string.Empty;

            // trim all text boxes
            foreach (Control ctrl in pnlMain.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = ctrl.Text.Trim();
                }
            }
            grdTopVisits.Select();

            #region fitst name

            txtFirstName.Text = Utils.InnerSpaceTrim(txtFirstName.Text);
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

            #endregion fitst name

            #region last name

            txtLastName.Text = Utils.InnerSpaceTrim(txtLastName.Text);
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

            #endregion last name

            #region birth date

            if (!dtpBirthDate.Validate())
            {
                msg += "תאריך הלידה שנבחר אינו חוקי\n";
            }

            #endregion birth date

            #region married date

            if (!dtpMarriedDate.Validate())
            {
                msg += "תאריך הנישואין שנבחר אינו חוקי\n";
            }

            #endregion married date

            #region email

            var email = txtEmail.Text;
            if (!Validation.IsEmailValid(email))
            {
                txtEmail.BackColor = Validation.ErrorColor;
                msg += "כתובת הדוא\"ל אינה תקינה\n";
            }

            #endregion email

            #region city

            txtAddress.Text = Utils.InnerSpaceTrim(txtAddress.Text);
            txtCity.Text = Utils.InnerSpaceTrim(txtCity.Text);

            if (txtCity.Text.Length > 0)
            {
                if (!Char.IsLetter(txtCity.Text, 0))
                {
                    txtCity.BackColor = Validation.ErrorColor;
                    msg += "עיר חייבת להתחיל באות עברית או לועזית\n";
                }
            }

            #endregion city

            #region zipcode

            var zip = txtZipCode.Text;
            if (!Validation.IsZipCodeValid(zip))
            {
                txtZipCode.BackColor = Validation.ErrorColor;
                msg += "המיקוד אינו תקין\n";
            }

            #endregion zipcode

            #region phones

            var phone = Utils.DistilPhone(txtHomePhone.Text);
            var isPhoneExist = (phone.Length > 0);
            if (!Validation.IsLinePhoneValid(phone))
            {
                txtHomePhone.BackColor = Validation.ErrorColor;
                if (Validation.IsCellPhoneValid(phone))
                { msg += "מספר הטלפון בבית אינו תקין. המספר שהוזן הינו טלפון סלולרי\n"; }
                else
                { msg += "מספר הטלפון בבית אינו תקין\n"; }
            }
            phone = Utils.DistilPhone(txtWorkPhone.Text);
            isPhoneExist = isPhoneExist || (phone.Length > 0);
            if (!Validation.IsPhoneValid(phone))
            {
                txtWorkPhone.BackColor = Validation.ErrorColor;
                msg += "מספר הטלפון בעבודה אינו תקין\n";
            }
            phone = Utils.DistilPhone(txtCellPhone1.Text);
            isPhoneExist = isPhoneExist || (phone.Length > 0);
            if (!Validation.IsCellPhoneValid(phone))
            {
                txtCellPhone1.BackColor = Validation.ErrorColor;
                if (Validation.IsLinePhoneValid(phone))
                { msg += "מספר הטלפון הסלולרי אינו תקין. המספר שהוזן הינו טלפון קוי"; }
                else
                { msg += "מספר הטלפון הסלולרי אינו תקין\n"; }
            }
            phone = Utils.DistilPhone(txtCellPhone2.Text);
            isPhoneExist = isPhoneExist || (phone.Length > 0);
            if (!Validation.IsPhoneValid(phone))
            {
                txtCellPhone2.BackColor = Validation.ErrorColor;
                msg += "מספר הטלפון הנוסף אינו תקין\n";
            }
            if (!isPhoneExist)
            {
                msg += "לא הוזן מספר טלפון ללקוח. יש להזין לפחות מספר טלפון אחד\n";
            }

            #endregion phones

            #region gender

            if (cmbGender.SelectedIndex == -1)
            {
                msg += "לא נבחר מין הלקוח\n";
                cmbGender.BackColor = Validation.ErrorColor;
            }

            #endregion gender

            // ***** Must be the last validation *****

            #region Validate CellPhone at right place

            if (msg.Length == 0)
            {
                if (txtCellPhone1.Text.Length == 0)
                {
                    if (txtCellPhone2.Text.Length > 0 && Validation.IsCellPhoneValid(Utils.DistilPhone(txtCellPhone2.Text)))
                    {
                        txtCellPhone1.Text = txtCellPhone2.Text;
                        txtCellPhone2.Text = string.Empty;
                    }
                    else if (txtWorkPhone.Text.Length > 0 && Validation.IsCellPhoneValid(Utils.DistilPhone(txtWorkPhone.Text)))
                    {
                        txtCellPhone1.Text = txtWorkPhone.Text;
                        txtWorkPhone.Text = string.Empty;
                    }
                }
            }

            #endregion Validate CellPhone at right place

            msg = msg.Trim();
            if (msg.Length == 0)
            {
                txtCellPhone1.Text = Validation.FormatPhone(txtCellPhone1.Text);
                txtCellPhone2.Text = Validation.FormatPhone(txtCellPhone2.Text);
                txtHomePhone.Text = Validation.FormatPhone(txtHomePhone.Text);
                txtWorkPhone.Text = Validation.FormatPhone(txtWorkPhone.Text);
            }

            return msg;
        }

        // enable all the controls on the form to enable user to edit them
        private void OpenFormForEdit()
        {
            imagePicker1.MenuButtonVisible = true;
            EnableToolstrip(false);
            txtGender.Visible = false;
            txtClientType.Visible = false;
            txtWorker.Visible = false;
            txtBirthDate.Visible = false;
            txtMarriedDate.Visible = false;

            EnableComponentGrid(true);
            //((DataGridViewComboBoxColumn)grdComponents.Columns["col_company"]).DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;

            foreach (Control ctrl in pnlMain.Controls)
            {
                var box = ctrl as TextBox;
                if (box != null)
                {
                    var tb = box;
                    if (Convert.ToString(tb.Tag) != "ReadOnly")
                    {
                        tb.BackColor = Color.White;
                        tb.ReadOnly = false;
                    }
                }
            }
        }

        // disable all the controls on the form to prevent user from edit them
        private void CloseFormFromEdit()
        {
            imagePicker1.MenuButtonVisible = false;
            EnableToolstrip(true);
            txtGender.Visible = true;
            txtClientType.Visible = true;
            txtWorker.Visible = true;
            txtBirthDate.Visible = true;
            txtMarriedDate.Visible = true;
            EnableComponentGrid(false);

            foreach (Control ctrl in pnlMain.Controls)
            {
                var box = ctrl as TextBox;
                if (box != null)
                {
                    var tb = box;
                    tb.BackColor = Color.FromArgb(241, 242, 245);
                    tb.ReadOnly = true;
                }
                else if (ctrl is ComboBox)
                {
                    ctrl.BackColor = Color.White;
                }
            }
        }

        // clear all data from the controls and prepare the form to insert a new client
        private void ClearForm()
        {
            imagePicker1.MenuButtonVisible = true;
            EnableToolstrip(false);
            txtGender.Visible = false;
            txtClientType.Visible = false;
            txtWorker.Visible = false;
            txtBirthDate.Visible = false;
            txtMarriedDate.Visible = false;

            foreach (Control ctrl in pnlMain.Controls)
            {
                var box = ctrl as TextBox;
                if (box != null)
                {
                    var tb = box;
                    tb.Text = string.Empty;
                    if (Convert.ToString(tb.Tag) != "ReadOnly")
                    {
                        tb.BackColor = Color.White;
                        tb.ReadOnly = false;
                    }
                }
            }

            FillTopVisits(new Interfaces.Client { Id = -1 });
            SetColorsGridData(-1);
            EnableComponentGrid(true);
            txtDateCreated.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cmbGender.SelectedIndex = -1;
            cmbClientType.SelectedIndex = 0;
            cmbWorker.SelectedIndex = 0;
            dtpBirthDate.Value = null;
            dtpMarriedDate.Value = null;
            imagePicker1.ClearImage();
            lblCellPrivacy.Visible = false;
            lblEmailPrivacy.Visible = false;
            lblBulletCard.Tag = string.Empty;
            tbbCancelCard.Enabled = false;
            mnuEmailPrivacy.Checked = true;
            mnuSMSPrivacy.Checked = true;
            HideBullets();
        }

        private void CustInitialize()
        {
            InitializeComponent();
            BuildComponentsGrid();
            imagePicker1.DefaultImage = Properties.Resources.no_image_big;
            LoadCombos();
            if (_isPopup)
            {
                tbbFind.Visible = false;
                tbbFind.Tag = "Hide";
                tbbAddNew.Visible = false;
                tbbAddNew.Tag = "Hide";
                toolSep1.Visible = false;
                toolSep1.Tag = "Hide";
                tbbDelete.Visible = false;
                tbbDelete.Tag = "Hide";
                tbbClose.Visible = true;
                tbbClose.Tag = null;
                tssClose.Visible = true;
                tssClose.Tag = null;

                mnuFind.Visible = false;
                mnuNew.Visible = false;
                mnuDel.Visible = false;
                mnuDiv4.Visible = true;
                mnuClose.Visible = true;

                pnlBullets.Visible = false;
            }
            SetAutoComplete();
            imagePicker1.EnableWebCam = AppSettingsHelper.GetParamValue<bool>("MAIN_ENABLE_WEBCAM");

            //string[] comps = Utils.GetStringArray(AppSettingsHelper.GetParamValue<string>("CLIENT_COLOR_COMPANIES"));
            //col_company.Items.Clear();
            //foreach (string c in comps) col_company.Items.Add(c);

            //string[] oxigen = Utils.GetStringArray(AppSettingsHelper.GetParamValue<string>("CLIENT_COLOR_OXIGEN"));
            //col_oxigen.Items.Clear();
            //foreach (string o in oxigen) col_oxigen.Items.Add(o);

            //string[] wait = Utils.GetStringArray(AppSettingsHelper.GetParamValue<string>("CLIENT_COLOR_WAITTIME"));
            //col_waitTime.Items.Clear();
            //foreach (string w in wait) col_waitTime.Items.Add(w);

            Tooltip.SetToolTip(lblCellPrivacy, "לקוח זה אינו בתפוצת הודעות SMS");
            Tooltip.SetToolTip(lblEmailPrivacy, "לקוח זה אינו בתפוצת הודעות דוא\"ל");
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

        private void GoBackToSearchForm()
        {
            _isBackToSearchForm = false;
            TbbFind_Click(null, null);
        }

        private void DeleteCurrentClient()
        {
            DeleteUser(_c.Id);
        }

        private void ValidateExistCellPhone(TextBox sender, string controlName)
        {
            base.TextBoxLeave(sender);

            var phone = Utils.DistilPhone(sender.Text);
            if (_inCheckPhonesProc) return;
            if (MyStatus != FormStatus.Edit && MyStatus != FormStatus.New) return;
            if (tbbCancel.Equals(this.ActiveControl)) return;
            if (phone.Length == 0 || !Validation.IsCellPhoneValid(phone)) return;

            int id;
            var focusControl = this.ActiveControl;
            var name = ClientHelper.GetUserNameByCellPhone(phone, out id);
            if (MyStatus == FormStatus.Edit && id == _c.Id) return;

            if (!string.IsNullOrEmpty(name))
            {
                _inCheckPhonesProc = true;

                sender.BackColor = Validation.ErrorColor;
                var msg1 = "שים לב! קיים במאגר לקוח בשם: " + name + "\nעם מספר טלפון: " + sender.Text + " הזהה למספר שהוזן בשדה " + controlName + "\n\n";
                msg1 += "האם להציג את כרטיס הלקוח של \"" + name + "\" ?";
                var msg2 = MyStatus == FormStatus.Edit ? "עריכת פרטי לקוח..." : "הוספת לקוח חדש...";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button1);
                var res = MsgBox.Show(this);

                sender.BackColor = Color.White;

                if (res == DialogResult.Yes)
                {
                    _isBackToSearchForm = false;
                    CancelEditForm(false);
                    _navigator.CurrentClientId = id;
                    RefreshData(id);
                }
                else
                {
                    focusControl.Select();
                }

                base.TextBoxLeave(sender);
                (sender).SelectionLength = 0;
                var box = focusControl as TextBox;
                if (box != null)
                {
                    box.SelectionLength = 0;
                }
                _inCheckPhonesProc = false;
            }
        }

        private void ValidateExistLinePhone(TextBox sender, string controlName)
        {
            base.TextBoxLeave(sender);
            if (_inCheckPhonesProc) return;
            var phone = Utils.DistilPhone(sender.Text);
            if (MyStatus != FormStatus.Edit && MyStatus != FormStatus.New) return;
            if (tbbCancel.Equals(this.ActiveControl)) return;
            if (phone.Length == 0 || !Validation.IsLinePhoneValid(phone)) return;

            var focusControl = this.ActiveControl;
            var id = MyStatus == FormStatus.Edit ? _c.Id : 0;
            var name = ClientHelper.GetUsersNamesByLinePhone(phone, id);

            if (!string.IsNullOrEmpty(name))
            {
                _inCheckPhonesProc = true;

                var msg1 = "לתשומת לבך, קיים במאגר לקוח/ות בשם:\n" + name + "\nעם מספר טלפון " + sender.Text + " הזהה למספר שהוזן בשדה: " + controlName + "\n";
                var msg2 = MyStatus == FormStatus.Edit ? "עריכת פרטי לקוח..." : "הוספת לקוח חדש...";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Information, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
                focusControl.Select();

                _inCheckPhonesProc = false;
            }
        }

        private void BuildComponentsGrid()
        {
            var table = ClientHelper.GetComponentsConfig().Tables[0].Copy();
            table.Columns.Add("data_property", typeof(string));
            for (var i = 0; i < table.Rows.Count; i++)
            {
                table.Rows[i]["data_property"] = "com" + i;
            }
            var rows = table.Select(null, "order_id");
            var index = 0;
            grdComponents.Columns.Clear();

            const string col1 = "id";
            const string col2 = "client_id";

            DataGridViewColumn col = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "id",
                HeaderText = col1,
                Name = "col_id",
                ReadOnly = true,
                Visible = false
            };
            grdComponents.Columns.Add(col);

            col = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "client_id",
                HeaderText = col2,
                Name = "col_client_id",
                ReadOnly = true,
                Visible = false
            };
            grdComponents.Columns.Add(col);

            col = new DataGridViewImageColumn();
            var style = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                NullValue = null,
                SelectionBackColor = Color.White
            };
            col.DefaultCellStyle = style;
            col.HeaderText = "";
            ((DataGridViewImageColumn)col).Image = Properties.Resources.cancel_small_dis;
            col.Name = "col_delete";
            col.ReadOnly = true;
            col.Width = 22;
            grdComponents.Columns.Add(col);

            foreach (var row in rows)
            {
                var defaultValue = Utils.GetDBValue<string>(row, "default_value");

                switch (Utils.GetDBValue<int>(row, "data_type"))
                {
                    case 1:
                        col = new DataGridViewTextBoxColumn();
                        ((DataGridViewTextBoxColumn)col).MaxInputLength = 50;
                        if (!string.IsNullOrEmpty(defaultValue)) col.Tag = defaultValue;
                        break;

                    case 2:
                        col = new DataGridViewComboBoxColumn();
                        ((DataGridViewComboBoxColumn)col).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        ((DataGridViewComboBoxColumn)col).DisplayStyleForCurrentCellOnly = true;
                        col.Resizable = DataGridViewTriState.True;

                        var values = Utils.GetStringArray(Utils.GetDBValue<string>(row, "fix_values"));
                        foreach (var v in values)
                        {
                            ((DataGridViewComboBoxColumn)col).Items.Add(v);
                        }
                        if (!string.IsNullOrEmpty(defaultValue)) col.Tag = defaultValue;
                        break;

                    case 3:
                        col = new DataGridViewCalendarColumn { DefaultCellStyle = { Format = "dd/MM/yyyy" } };
                        if (!string.IsNullOrEmpty(defaultValue))
                        {
                            try
                            {
                                if (defaultValue == "{now}")
                                {
                                    col.Tag = defaultValue;
                                }
                                else
                                {
                                    col.Tag = DateTime.Parse(defaultValue);
                                }
                            }
                            catch
                            {
                                col.Tag = defaultValue;
                            }
                        }
                        break;

                    default:
                        throw new ApplicationException("Data type is not supported in components grid");
                }

                col.DataPropertyName = Utils.GetDBValue<string>(row, "data_property");
                col.HeaderText = Utils.GetDBValue<string>(row, "caption");
                col.Name = "col_" + col.DataPropertyName;
                col.ReadOnly = false;
                col.MinimumWidth = 50;
                col.Resizable = DataGridViewTriState.True;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.Width = Utils.GetDBValue<int>(row, "width");

                grdComponents.Columns.Add(col);
                index++;
            }

            // ReSharper disable PossibleNullReferenceException
            if (index == 0) grdComponents.Columns["col_delete"].Visible = false;
            // ReSharper restore PossibleNullReferenceException
        }

        public void SaveComponentsConfig()
        {
            var table = ClientHelper.GetComponentsConfig().Tables[0];
            for (var i = 0; i < table.Rows.Count; i++)
            {
                var col = grdComponents.Columns["col_com" + i];
                if (col != null)
                {
                    table.Rows[i]["width"] = col.Width;
                    table.Rows[i]["order_id"] = col.DisplayIndex;
                }
            }
            ClientHelper.SaveComponentsConfig();
        }

        #endregion Private Functions

        #endregion Private

        #region Public

        #region Events

        public event CalendarSetAppointmentEventHandler SetAppointment;

        public event EventHandler RefreshCalendar;

        public event EventHandler NavigateNextClient;

        public event EventHandler NavigatePreviousClient;

        public event EventHandler CloseMe;

        public event EventHandler SyncClients;

        public event OpenFormEventHandler OpenForm;

        public event ClientOperationEventHandler ClientUpdated;

        public event EventHandler ClientAdded;

        public event ClientOperationEventHandler ClientDeleted;

        public event ClientOperationEventHandler RequestForUpdateClient;

        public event DialRequestEventHandler DialRequest;

        #endregion Events

        #region Properties

        public bool AllowNavigation
        {
            get { return tbbNext.Visible; }
            set
            {
                tbbNext.Visible = value;
                tbbNext.Tag = value ? null : "Hide";
                tbbPrev.Visible = value;
                tbbPrev.Tag = value ? null : "Hide";
                tssNav.Visible = value;
                tssNav.Tag = value ? null : "Hide";
            }
        }

        public bool CalendarEnabled
        {
            get { return tbbMakeApp.Enabled; }
            set
            {
                tbbMakeApp.Enabled = value;
                mnuCal.Enabled = value;
            }
        }

        public FormStatus Status
        {
            get { return MyStatus; }
        }

        public Client Client
        {
            get { return _c; }
        }

        #endregion Properties

        #region Methods

        public void CancelEdit()
        {
            CancelEditForm(true);
        }

        public void SetNavigateClientId(int clientId)
        {
            _navigator.CurrentClientId = clientId;
            RefreshNavigateData();
        }

        public void SetNavigateParameters(DataTable dataSource, int currentIndex)
        {
            _navigator.DataSource = dataSource;
            _navigator.CurrentIndex = currentIndex;
            RefreshNavigateData();
        }

        public void AddNewClient()
        {
            TbbAddNew_Click(null, null);
            _isBackToSearchForm = true;
        }

        public void AddNewClient(string phone)
        {
            TbbAddNew_Click(null, null);

            if (phone.Length > 0)
            {
                if (Validation.IsCellPhoneValid(phone))
                {
                    txtCellPhone1.Text = phone;
                }
                else if (Validation.IsLinePhoneValid(phone))
                {
                    txtHomePhone.Text = phone;
                }
            }
        }

        public void EditClient(int id)
        {
            _navigator.CurrentClientId = id;
            RefreshData(id);
            TbbUpdate_Click(null, null);
            _isBackToSearchForm = true;
        }

        public void DeleteUser(int id)
        {
            const string msg2 = "הלקוח נמחק בהצלחה";
            const string msg3 = "מחיקת לקוח...";

            this.Cursor = Cursors.WaitCursor;
            var cnt = ClientHelper.DeleteClient(id);
            OnSyncClients();
            MyStatus = FormStatus.View;
            if (cnt == 1)
            {
                if (ClientHelper.CachedClientsTable.Rows.Count > 0)
                {
                    RefreshNavigateData();
                    if (_c.Id == id)
                    {
                        RefreshData(_navigator.CurrentClientId);
                    }
                }

                if (RefreshCalendar != null) RefreshCalendar(this, new EventArgs());
                if (ClientDeleted != null) ClientDeleted(this, new ClientOperationEventArgs("ClientDeleted", id));
                MsgBox = new MyMessageBox(msg2, msg3);
                MsgBox.Show(this);
            }
            else
            {
                const string title = "שגיאה בכרטיסי לקוחות...";
                var head = "מחיקת הלקוח: " + _c.FullName;
                var desc = "ארעה שגיאה במחיקת הלקוח " + _c.FullName + "\nהלקוח נשאר במאגר הלקוחות.";
                General.ShowErrorMessageDialog(this, title, head, desc, null, "frmClients");
            }

            this.Cursor = Cursors.Default;
        }

        // refresh / reload data to the form
        public void RefreshData()
        {
            if (_c == null) return;
            RefreshData(_c.Id);
        }

        public void RefreshWorkersList()
        {
            cmbWorker.DataSource = WorkersHelper.GetWorkersList();
            cmbWorker.DisplayMember = "full_name";
            cmbWorker.ValueMember = "id";
        }

        // refresh / reload data to the form
        public void RefreshData(int userId)
        {
            if (MyStatus != FormStatus.View)
            {
                var msg1 = "כרטיס לקוח אחר נמצא כעת במערכת במצב\nעריכה/מחיקה ולא ניתן להציג כעת את כרטיס\nהלקוח של " + ClientHelper.GetFullName(userId) + ".\n\nיש לשמור/לבטל את השינויים בטופס";
                const string msg2 = "כרטיס לקוח...";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            _c = ClientHelper.GetClient(userId);
            LoadData(_c);
            if (_c == null) _c = new Client(userId);
            this.Select();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Processes the current client card.
        /// </summary>
        /// <param name="clientId">The client id.</param>
        /// <returns></returns>
        public bool ProcessCurrentClientCard(int clientId)
        {
            bool registerSubscription;
            var client = ClientHelper.GetClient(clientId);

            if (string.IsNullOrEmpty(client.CardId)) return false;

            var cardId = string.Empty.PadLeft(General.ClientCardPattern.FromIndex, '-') + client.CardId;
            return ProcessCard(cardId, out registerSubscription);
        }

        /// <summary>
        /// Processes the card.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="registerSubscription">if set to <c>true</c> [register subscription].</param>
        /// <returns></returns>
        public bool ProcessCard(string value, out bool registerSubscription)
        {
            Trace.TraceInformation("1. ProcessCard");
            var showTab = false;
            var autoReg = AppSettingsHelper.GetParamValue<bool>("CARD_AUTO_REGISTER_SUB");
            registerSubscription = false;

            var cardId = value.Substring(General.ClientCardPattern.FromIndex, General.ClientCardPattern.Length);
            var id = ClientHelper.GetClientIdByCardId(cardId);

            Trace.TraceInformation("2. Client Id = " + id);

            if (AppSettingsHelper.GetParamValue<int>("APP_CLIENT_ID") == 90001 && id > 0)
            {
                Trace.TraceInformation("2.1. Create App (Daniel Levi)");
                var workerId = WorkersHelper.GetDefaultWorkerId();
                var endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
                endDate = endDate.AddMinutes(-5);
                try
                {
                    CalendarHelper.AddAppointment(new BizCareAppointment
                            {
                                ClientId = id,
                                EndDate = endDate,
                                StartDate = endDate.AddMinutes(-30),
                                Text = "מקור: כרטיס מגנטי",
                                WorkerId = workerId
                            });
                }
                catch (Exception ex)
                {
                    General.ShowCommunicationError(ex, this);
                }
                FillTopVisits(_c);
            }

            Trace.TraceInformation("3. Start Switch");

            switch (this.Status)
            {
                case FormStatus.View:
                    Trace.TraceInformation("4. View (1)");
                    if (id > 0)
                    {
                        showTab = true;

                        if (_c.Id != id)
                        {
                            Trace.TraceInformation("4. View (2)");
                            RefreshData(id);
                            SetNavigateClientId(id);
                        }
                        var subCount = autoReg ? ClientHelper.GetSubscriptionCount(id) : 0;
                        Trace.TraceInformation("4. View (3) subcount = " + subCount);

                        if (subCount > 0)
                        {
                            TbbSub_Click(null, null);
                            Trace.TraceInformation("4. View (4)");
                            if (subCount == 1)
                            {
                                Trace.TraceInformation("4. View (5)");
                                registerSubscription = true;
                            }
                        }
                    }
                    Trace.TraceInformation("4. View (6)");
                    break;

                case FormStatus.Edit:
                case FormStatus.New:
                    Trace.TraceInformation("4. Edit/New");
                    if (!(_fCard == null || _fCard.IsDisposed))
                    {
                        Trace.TraceInformation("4. Edit/New 1");
                        if (id > 0)
                        {
                            Trace.TraceInformation("4. Edit/New 2");
                            if (_c.Id == id)
                            {
                                Trace.TraceInformation("4. Edit/New 3");
                                if (lblBulletCard.Visible)
                                {
                                    Trace.TraceInformation("4. Edit/New 4");
                                    _fCard.ShowErrorMessage("הכרטיס שהועבר כבר משוייך\nללקוח הנוכחי");
                                }
                                else
                                {
                                    Trace.TraceInformation("4. Edit/New 5");
                                    _fCard.Hide();
                                    _fCard.Close();
                                    lblBulletCard.Tag = cardId;
                                    lblBulletCard.Visible = true;
                                    tbbCancelCard.Enabled = true;
                                }
                            }
                            else
                            {
                                Trace.TraceInformation("4. Edit/New 6");
                                var tmpC = ClientHelper.GetClient(id);
                                _fCard.ShowErrorMessage("הכרטיס שהועבר משוייך ללקוח\n" + tmpC.FullName);
                            }
                        }
                        else
                        {
                            Trace.TraceInformation("4. Edit/New 7");
                            _fCard.Hide();
                            _fCard.Close();
                            lblBulletCard.Tag = cardId;
                            lblBulletCard.Visible = true;
                            tbbCancelCard.Enabled = true;
                        }
                    }
                    Trace.TraceInformation("4. Edit/New 8");
                    break;
                //case FormStatus.Delete:
                default:
                    Trace.TraceInformation("4. default");
                    break;
            }
            return showTab;
        }

        #endregion Methods

        #endregion Public

        #region Constructor

        // open the form with the firs user in database
        public FormClients()
        {
            CustInitialize();
            _c = ClientHelper.GetFirstUser();
            if (_c == null)
            {
                TbbAddNew_Click(null, null);
            }
            else
            {
                LoadData(_c);
            }
            SelectSubTab(1);
        }

        // open the form with specific user
        public FormClients(int id)
            : this(id, false)
        {
        }

        public FormClients(int id, bool isPopup)
        {
            _isPopup = isPopup;
            CustInitialize();
            _c = ClientHelper.GetClient(id);
            LoadData(_c);
            if (_c == null) _c = new Client(id);
            SelectSubTab(1);
        }

        #endregion Constructor

        #region From & Controls Event

        private void CancelEditForm(bool withRefreshData)
        {
            if (MyStatus == FormStatus.Delete || MyStatus == FormStatus.View) return;

            CloseFormFromEdit();
            if (withRefreshData) LoadData(_c);
            MyStatus = FormStatus.View;
            informationBar1.PanelText = "תצוגת כרטיס לקוח";
            informationBar1.Image = Properties.Resources.clients_small;
            if (_isBackToSearchForm) GoBackToSearchForm();
            grdTopVisits.Select();
        }

        // open the search form in right click in the form
        private void FrmClients_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (AppSettingsHelper.GetParamValue<bool>("CLIENT_ENABLE_SEARCH_SHORTCUT"))
            {
                if (MyStatus == FormStatus.View && e.Button == MouseButtons.Left)
                {
                    TbbFind_Click(null, null);
                }
            }
        }

        // prevent from closing mdi form by click the X button
        private static void FrmClients_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.MdiFormClosing) e.Cancel = true;
        }

        // navigate to the previous client
        private void TbbPrev_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _navigator.MovePrevious();
            RefreshData(_c.PrevClientId);
            if (NavigatePreviousClient != null) NavigatePreviousClient(this, new EventArgs());
            this.Cursor = Cursors.Default;
        }

        // navigate to the next client
        private void TbbNext_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _navigator.MoveNext();
            RefreshData(_c.NextClientId);
            if (NavigateNextClient != null) NavigateNextClient(this, new EventArgs());
            this.Cursor = Cursors.Default;
        }

        // change the form to update mode
        private void TbbUpdate_Click(object sender, EventArgs e)
        {
            var arg = new ClientOperationEventArgs("RequestForUpdateClient", _c.Id);
            if (RequestForUpdateClient != null) RequestForUpdateClient(this, arg);
            if (arg.Cancel)
            {
                var msg1 = "כרטיס לקוח של " + _c.FullName + " פתוח במצב עדכון/מחיקה בחלון אחר";
                const string msg2 = "עדכון פרטי לקוח...";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show();
            }
            else
            {
                OpenFormForEdit();
                MyStatus = FormStatus.Edit;
                informationBar1.PanelText = "עדכון פרטי לקוח: " + _c.FullName;
                informationBar1.Image = Properties.Resources.tb_edit_small;
                txtFirstName.Select();
                grdComponents.ClearSelection();
                grdTopVisits.ClearSelection();
                TextBoxFocus(txtFirstName, null);
            }
        }

        // change the form to new mode
        private void TbbAddNew_Click(object sender, EventArgs e)
        {
            MyStatus = FormStatus.New;
            ClearForm();
            informationBar1.PanelText = "הוספת לקוח חדש";
            informationBar1.Image = Properties.Resources.new_small;
            txtFirstName.Select();
            TextBoxFocus(txtFirstName, null);

            if (_c == null || ClientHelper.CachedClientsTable.Rows.Count == 0) tbbCancel.Visible = false;
        }

        // delete user
        private void TbbDelete_Click(object sender, EventArgs e)
        {
            const string msg3 = "מחיקת לקוח...";

            var msg1 = "האם אתה בטוח שברצונך למחוק את הלקוח " + _c.FullName + "\n\nשים לב: כל המידע לגבי התורים ורישומי השיחות של הלקוח ימחק";

            MyStatus = FormStatus.Delete;
            MsgBox = new MyMessageBox(msg1, msg3, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
            var res = MsgBox.Show(this);

            if (res == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                DeleteCurrentClient();
                this.Cursor = Cursors.Default;
            }
            MyStatus = FormStatus.View;

            if (ClientHelper.CachedClientsTable.Rows.Count == 0)
            {
                TbbAddNew_Click(null, null);
                tbbCancel.Visible = false;
            }
        }

        // open the search form
        private void TbbFind_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (OpenForm != null) OpenForm(this, new OpenFormEventArgs("frmSearchClient", _c.Id));
            this.Cursor = Cursors.Default;
        }

        // print all client information
        private void TbbPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var data = _c.GetPrintData();
            data[18] = HtmlPrinter.ConvertDataGridToHtml(grdTopVisits);
            data[19] = HtmlPrinter.ConvertDataGridToHtml(grdComponents);
            var printer = new HtmlPrinter("CLIENT_FORM", data);
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

        private void SplitPhone_ButtonClick(object sender, EventArgs e)
        {
            splitPhone.ShowDropDown();
        }

        private void SplitPhoneItem_ButtonClick(object sender, EventArgs e)
        {
            var name = txtFirstName.Text + " " + txtLastName.Text;
            var phone = Utils.DistilPhone(((ToolStripDropDownItem)(sender)).Text);

            if (DialRequest != null)
            {
                var arg = new DialRequestEventArgs(phone, name, _c.Id) { Entity = 0 };
                DialRequest(this, arg);
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
                const string title = "שגיאה בכרטיסי לקוחות...";
                const string head = "שמירת תמונה ממצלמה";
                const string desc = "ארעה שגיאה בשמירת התמונה מהמצלמה אל מאגר הלקוחות.";
                General.ShowErrorMessageDialog(this, title, head, desc, ex, "frmClients");
            }
        }

        private void FrmClients_SizeChanged(object sender, EventArgs e)
        {
            if (_isPopup)
            {
                pnlMain.Left = (this.Width - pnlMain.Width) / 2;
            }
            else
            {
                pnlMain.Left = (this.Width - pnlMain.Width + pnlBullets.Width) / 2;
                pnlBullets.Left = pnlMain.Left - pnlBullets.Width;
            }

            pnlMain.Top = (this.Height - pnlMain.Height + toolStrip.Height + informationBar1.Height) / 2;
            pnlBullets.Top = pnlMain.Top + 22;
        }

        private void TbbMakeApp_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (SetAppointment != null) SetAppointment(this, new SetAppointmentEventArgs(_c.Id));
            this.Cursor = Cursors.Default;
        }

        protected void TextBoxFocus(object sender, EventArgs e)
        {
            base.TextBoxEnter((TextBox)sender);
        }

        protected void TextBoxLostFocus(object sender, EventArgs e)
        {
            base.TextBoxLeave((TextBox)sender);
        }

        private void TxtCellPhone1_Leave(object sender, EventArgs e)
        {
            ValidateExistCellPhone((TextBox)sender, "טלפון סלולרי");
        }

        private void TxtCellPhone2_Leave(object sender, EventArgs e)
        {
            ValidateExistCellPhone((TextBox)sender, "טלפון נוסף");
        }

        private void TxtHomePhone_Leave(object sender, EventArgs e)
        {
            ValidateExistLinePhone((TextBox)sender, "טלפון בבית");
        }

        private void TxtWorkPhone_Leave(object sender, EventArgs e)
        {
            ValidateExistCellPhone((TextBox)sender, "טלפון בעבודה");
            ValidateExistLinePhone((TextBox)sender, "טלפון בעבודה");
        }

        #endregion From & Controls Event

        private void TbbSendSms_Click(object sender, EventArgs e)
        {
            if (OpenForm == null) return;
            this.Cursor = Cursors.WaitCursor;
            var table = General.GetSmsEntity(_c.Id, General.EntityType.Client);
            var list = General.TableToPostAddresseeList(table);
            if (table != null) OpenForm(this, new OpenFormEventArgs("frmSMS", list));
            this.Cursor = Cursors.Default;
        }

        private void TbbEmail_Click(object sender, EventArgs e)
        {
            if (OpenForm != null)
            {
                this.Cursor = Cursors.WaitCursor;
                var table = General.GetEmailEntity(_c.Id, General.EntityType.Client);
                if (table != null) OpenForm(this, new OpenFormEventArgs("frmMailCampaign", table));
                this.Cursor = Cursors.Default;
            }
        }

        private void CmbGender_DropDown(object sender, EventArgs e)
        {
            base.ControlClearBgColor(cmbGender);
        }

        public void OpenFindForm()
        {
            if (tbbFind.Enabled) TbbFind_Click(null, null);
        }

        private void TbbClose_Click(object sender, EventArgs e)
        {
            if (CloseMe != null) CloseMe(this, new EventArgs());
        }

        private void OnSyncClients()
        {
            if (SyncClients != null) SyncClients(this, EventArgs.Empty);
        }

        private void FrmClients_KeyDown(object sender, KeyEventArgs e)
        {
            var ctrl = e.Control && !e.Alt && !e.Shift;

            switch (e.KeyCode)
            {
                case Keys.S:
                    if (ctrl && tbbSave.Enabled && tbbSave.Visible) TbbSave_Click(null, null);
                    break;

                case Keys.F:
                    if (ctrl && tbbFind.Enabled && tbbFind.Visible) TbbFind_Click(null, null);
                    break;

                case Keys.N:
                    if (ctrl && tbbAddNew.Enabled && tbbAddNew.Visible) TbbAddNew_Click(null, null);
                    break;

                case Keys.E:
                    if (ctrl && tbbUpdate.Enabled && tbbUpdate.Visible) TbbUpdate_Click(null, null);
                    break;

                case Keys.Delete:
                    if (tbbDelete.Enabled && tbbDelete.Visible) TbbDelete_Click(null, null);
                    break;

                case Keys.Escape:
                    if (tbbClose.Enabled && tbbClose.Visible) TbbClose_Click(null, null);
                    else CancelEditForm(true);
                    break;
            }
        }

        private void TbbPrivacy_ButtonClick(object sender, EventArgs e)
        {
            tbbPrivacy.ShowDropDown();
        }

        private void MnuEmailPrivacy_Click(object sender, EventArgs e)
        {
            mnuEmailPrivacy.Checked = !mnuEmailPrivacy.Checked;
            lblEmailPrivacy.Visible = !mnuEmailPrivacy.Checked;
        }

        private void MnuSmsPrivacy_Click(object sender, EventArgs e)
        {
            mnuSMSPrivacy.Checked = !mnuSMSPrivacy.Checked;
            lblCellPrivacy.Visible = !mnuSMSPrivacy.Checked;
        }

        private void MnuEmailPrivacy_CheckedChanged(object sender, EventArgs e)
        {
            mnuEmailPrivacy.Text = mnuEmailPrivacy.Checked ? "הסר מתפוצת דוא\"ל" : "הוסף לתפוצת דוא\"ל";
        }

        private void MnuSmsPrivacy_CheckedChanged(object sender, EventArgs e)
        {
            mnuSMSPrivacy.Text = mnuSMSPrivacy.Checked ? "הסר מתפוצת SMS" : "הוסף לתפוצת SMS";
        }

        private void TbbSave_Click(object sender, EventArgs e)
        {
            var msg1 = ValidateForm();
            const string msg2 = "שמירת פרטי לקוח...";

            if (msg1.Length == 0)
            {
                this.Cursor = Cursors.WaitCursor;
                var tempClient = _c;
                if (SaveData())
                {
                    SetAutoComplete();
                    if (MyStatus == FormStatus.Edit)
                    {
                        if (ClientUpdated != null) ClientUpdated(this, new ClientOperationEventArgs("ClientUpdated", _c.Id));
                    }
                    else if (MyStatus == FormStatus.New)
                    {
                        if (ClientAdded != null) ClientAdded(this, new EventArgs());
                    }

                    CancelEditForm(true);
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    _c = tempClient;
                    const string title = "שגיאה בכרטיסי לקוחות...";
                    var head = "שמירת נתוני הלקוח " + _c.FullName;
                    var desc = "שמירת נתוני הלקוח " + _c.FullName + " נכשלה\nשים לב: המידע שהזנת אבד ותיאלץ להזינו שוב";
                    General.ShowErrorMessageDialog(this, title, head, desc, null, "frmClients");
                }
                this.Cursor = Cursors.Default;
            }
            else
            {
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
            }
        }

        private void TbbCancel_Click(object sender, EventArgs e)
        {
            txtRemark.Focus();
            CancelEditForm(true);
        }

        private void PnlMain_Paint(object sender, PaintEventArgs e)
        {
            var rect = new Rectangle(0, 22, pnlMain.Width - 1, pnlMain.Height - 23);
            var cFrom = Color.FromArgb(255, 255, 254);
            var cTo = Color.FromArgb(228, 235, 242);
            var cBorder = Color.FromArgb(129, 135, 142);
            var brush = new LinearGradientBrush(rect, cFrom, cTo, LinearGradientMode.Vertical);

            e.Graphics.FillRectangle(brush, rect);
            e.Graphics.DrawRectangle(new Pen(cBorder), rect);
            e.Graphics.DrawImage(Properties.Resources.client, pnlMain.Width - 141, 0, 141, 23);

            var cardBorder = Color.FromArgb(127, 157, 185);
            rect = new Rectangle(lblSubTab.Right - 1, lblSubTab.Top, grdTopVisits.Width + 4, grdTopVisits.Height + 4);
            e.Graphics.FillRectangle(Brushes.White, rect);
            e.Graphics.DrawRectangle(new Pen(cardBorder), rect);
        }

        private void GrdTopVisits_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (grdTopVisits.Rows.Count > 0) grdTopVisits.Rows[0].Selected = false;
        }

        private void GrdTopVisits_Leave(object sender, EventArgs e)
        {
            if (grdTopVisits.SelectedRows.Count > 0)
            {
                grdTopVisits.SelectedRows[0].Selected = false;
            }
        }

        private void GrdTopVisits_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ShowItem();
        }

        private void TbbPhotoAlbum_Click(object sender, EventArgs e)
        {
            if (OpenForm != null) OpenForm(this, new OpenFormEventArgs("frmPhotoAlbum", _c.Id));
        }

        private void SelectSubTab(byte id)
        {
            if (_curSubTab == id) return;
            switch (id)
            {
                case 0:
                    const string title = "ביקורים אחרונים:";
                    lblSubTab.Image = Properties.Resources.subtab_cal;
                    grdComponents.Visible = false;
                    grdTopVisits.Visible = true;
                    lblGridCaption.Text = title;
                    FillTopVisits(_c);
                    break;

                case 1:
                    lblSubTab.Image = Properties.Resources.subtab_color;
                    grdComponents.Visible = true;
                    grdTopVisits.Visible = false;
                    lblGridCaption.Text = string.Format("{0}:", AppSettingsHelper.GetParamValue<string>("CLIENT_COMPONENTS_TITLE"));
                    grdComponents.ClearSelection();
                    break;
            }
            _curSubTab = id;
        }

        private void LblSubTab_MouseDown(object sender, MouseEventArgs e)
        {
            switch (_curSubTab)
            {
                case 0:
                    if (e.Y >= 47) SelectSubTab(1);
                    break;

                case 1:
                    if (e.Y <= 43) SelectSubTab(0);
                    break;
            }
        }

        private void EnableComponentGrid(bool value)
        {
            if (value)
            {
                foreach (DataGridViewColumn col in grdComponents.Columns)
                {
                    var column = col as DataGridViewComboBoxColumn;
                    if (column != null)
                    {
                        column.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                    }
                }
                grdComponents.DefaultCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.Highlight);
                grdComponents.DefaultCellStyle.SelectionForeColor = Color.FromKnownColor(KnownColor.HighlightText);
                grdComponents.AllowUserToAddRows = true;
                grdComponents.ClearSelection();
            }
            else
            {
                foreach (DataGridViewColumn col in grdComponents.Columns)
                {
                    var column = col as DataGridViewComboBoxColumn;
                    if (column != null)
                    {
                        column.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                    }
                }
                grdComponents.DefaultCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.Control);
                grdComponents.DefaultCellStyle.SelectionForeColor = Color.FromKnownColor(KnownColor.ControlText);
            }
            grdComponents.ReadOnly = !value;
        }

        private void SaveColorGrid()
        {
            var ds = (DataSet)grdComponents.DataSource;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified)
                {
                    row["client_id"] = _c.Id;
                }
            }
            ClientHelper.UpdateComponents(ds);
        }

        private void SetColorsGridData(int clientId)
        {
            var ds = ClientHelper.GetClientComponents(clientId);
            grdComponents.DataSource = ds;
            grdComponents.AllowUserToAddRows = (ds.Tables[0].Rows.Count == 0);
            grdComponents.ClearSelection();
        }

        private static void GrdColors_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void TbbStickers_Click(object sender, EventArgs e)
        {
            if (OpenForm != null)
            {
                this.Cursor = Cursors.WaitCursor;
                var table = General.GetStickerEntity(_c.Id, General.EntityType.Client);
                if (table != null) OpenForm(this, new OpenFormEventArgs("frmStickers", table));
                this.Cursor = Cursors.Default;
            }
        }

        private void MnuFind_Click(object sender, EventArgs e)
        {
            TbbFind_Click(null, null);
        }

        private void MnuNew_Click(object sender, EventArgs e)
        {
            TbbAddNew_Click(null, null);
        }

        private void MnuNext_Click(object sender, EventArgs e)
        {
            TbbNext_Click(null, null);
        }

        private void MnuPrev_Click(object sender, EventArgs e)
        {
            TbbPrev_Click(null, null);
        }

        private void MnuEdit_Click(object sender, EventArgs e)
        {
            TbbUpdate_Click(null, null);
        }

        private void MnuCal_Click(object sender, EventArgs e)
        {
            TbbMakeApp_Click(null, null);
        }

        private void MnuDel_Click(object sender, EventArgs e)
        {
            TbbDelete_Click(null, null);
        }

        private void MnuAlbum_Click(object sender, EventArgs e)
        {
            TbbPhotoAlbum_Click(null, null);
        }

        private void MnuPrint_Click(object sender, EventArgs e)
        {
            TbbPrint_Click(null, null);
        }

        private void MnuSms_Click(object sender, EventArgs e)
        {
            TbbSendSms_Click(null, null);
        }

        private void MnuMail_Click(object sender, EventArgs e)
        {
            TbbEmail_Click(null, null);
        }

        private void MnuStick_Click(object sender, EventArgs e)
        {
            TbbStickers_Click(null, null);
        }

        private void FrmClients_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (_myStatus == FormStatus.View)
                {
                    if (!_isPopup) ctxMenuForm.Show(this, e.X, e.Y);
                }
            }
        }

        private void PnlMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (_myStatus == FormStatus.View)
                {
                    if (e.Y < 23 && e.X < pnlMain.Width - 143)
                    {
                        if (!_isPopup) ctxMenuForm.Show(pnlMain, e.X, e.Y);
                    }
                    else
                    {
                        ctxMenuCard.Show(pnlMain, e.X, e.Y);
                    }
                }
            }
        }

        private void MnuClose_Click(object sender, EventArgs e)
        {
            TbbClose_Click(null, null);
        }

        private void MnuBday_Click(object sender, EventArgs e)
        {
            if (OpenForm != null)
            {
                var args = new OpenFormEventArgs("frmBirthday");
                OpenForm(this, args);

                if (args.ReturnStatus == 0)
                {
                    const string msg1 = "חלון תזכורת...";
                    const string msg2 = "לא נמצאו לקוחות שיום הולדתם\nו/או יום הנישואין שלהם חל היום";
                    MsgBox = new MyMessageBox(msg2, msg1, MyMessageBox.MyMessageType.Information, MyMessageBox.MyMessageButton.Ok);
                    MsgBox.Show(this);
                }
            }
        }

        private void GrdColors_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // ReSharper disable PossibleNullReferenceException
            if (e.ColumnIndex == grdComponents.Columns["col_delete"].Index)
            // ReSharper restore PossibleNullReferenceException
            {
                if (grdComponents.Rows[e.RowIndex].IsNewRow)
                {
                    e.Value = null;
                }
            }
        }

        private void GrdColors_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (e.Row.Index >= 1)
            {
                grdComponents.Rows[e.Row.Index - 1].Cells["col_delete"].Value = Properties.Resources.cancel_small;

                foreach (DataGridViewColumn col in e.Row.DataGridView.Columns)
                {
                    if (col.Tag != null)
                    {
                        try
                        {
                            grdComponents.Rows[e.Row.Index - 1].Cells[col.Name].Value = col.Tag.ToString().ToLower() == "{now}" ? DateTime.Now.Date : col.Tag;
                        }
                        catch { Utils.CatchException(); }
                    }
                }
            }
        }

        private void GrdColors_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectColorRow(e.ColumnIndex, e.RowIndex);
        }

        private void GrdColors_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                SelectColorRow(e.ColumnIndex, e.RowIndex);
                // ReSharper disable PossibleNullReferenceException
                if (e.ColumnIndex == grdComponents.Columns["col_delete"].Index)
                // ReSharper restore PossibleNullReferenceException
                {
                    grdComponents.CurrentCell = grdComponents["col_com0", e.RowIndex];
                    if (_myStatus == FormStatus.Edit || _myStatus == FormStatus.New)
                    {
                        DeleteColorGridRow(e.RowIndex);
                    }
                }
            }
        }

        private void GrdColors_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (_myStatus == FormStatus.Edit || _myStatus == FormStatus.New)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // ReSharper disable PossibleNullReferenceException
                    if (e.ColumnIndex == grdComponents.Columns["col_delete"].Index)
                    // ReSharper restore PossibleNullReferenceException
                    {
                        if (!grdComponents.Rows[e.RowIndex].IsNewRow)
                        {
                            grdComponents.Cursor = Cursors.Hand;
                        }
                    }
                }
            }
        }

        private void GrdColors_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (_myStatus == FormStatus.Edit || _myStatus == FormStatus.New)
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    // ReSharper disable PossibleNullReferenceException
                    if (e.ColumnIndex == grdComponents.Columns["col_delete"].Index)
                    // ReSharper restore PossibleNullReferenceException
                    {
                        grdComponents.Cursor = Cursors.Default;
                    }
                }
            }
        }

        private void TbbSub_Click(object sender, EventArgs e)
        {
            if (OpenForm != null) OpenForm(this, new OpenFormEventArgs("frmSubscription", _c));
        }

        private void TbbAddCard_Click(object sender, EventArgs e)
        {
            grdTopVisits.Focus();
            _fCard = new FormCard(FormCard.CardEntityType.Client);
            _fCard.ShowDialog();
        }

        private void TbbMagneticCard_ButtonClick(object sender, EventArgs e)
        {
            if (!tbbCancelCard.Enabled) TbbAddCard_Click(null, null);
            else tbbMagneticCard.ShowDropDown();
        }

        private void TbbCancelCard_Click(object sender, EventArgs e)
        {
            lblBulletCard.Tag = string.Empty;
            lblBulletCard.Visible = false;
            tbbCancelCard.Enabled = false;
        }

        private void ImagePicker1_PictureClick(object sender, EventArgs e)
        {
            if (tbbPhotoAlbum.Visible && tbbPhotoAlbum.Enabled)
            {
                TbbPhotoAlbum_Click(null, null);
            }
        }

        private void LblBulletPic_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TbbPhotoAlbum_Click(null, null);
        }

        private void LblBulletSub_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TbbSub_Click(null, null);
        }

        private static void GrdComponents_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private static void GrdTopVisits_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        }
    }
}