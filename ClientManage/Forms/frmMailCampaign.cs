using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ClientManage.BL;
using ClientManage.Library;
using ClientManage.Interfaces;
using ClientManage.BL.Library;
using System.Net.Mail;

namespace ClientManage.Forms
{
    public partial class FormMailCampaign : BasePopupForm
    {
        private readonly string _totalClients = string.Empty;
        private readonly string _connectingText = string.Empty;
        private DataTable _clients;
        private readonly DataTable _mailTemplates;
        private int _activeUsers;
        private int _templateId = -1;
        private bool _isConnectionOk;
        private bool _refreshList;
        private Exception _error;
        private FormClientQuickSearch _fClientQuickSearch;

        public FormMailCampaign(DataTable clients)
        {
            InitializeComponent();
            this.CenterToScreen();

            _totalClients = lblTotalClients.Text;
            _connectingText = lblConnecting.Text;
            _clients = clients;
            _mailTemplates = MailCampaignHelper.GetMailTemplates();
            RefreshClients();
        }

        public int TotalClients
        {
            get { return lstClients.Items.Count; }
        }

        private void Label8_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(127, 157, 185)), 0, 0, label8.Width - 1, label8.Height - 1);
        }

        private void TbbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMailCampaign_Load(object sender, EventArgs e)
        {
            txtFrom.Text = @"<" + AppSettingsHelper.GetParamValue("MAIL_FROM") + @"> " + AppSettingsHelper.GetParamValue("APP_CLIENT_NAME");
            lstMailTemplates.DisplayMember = "template_name";
            lstMailTemplates.ValueMember = "id";
            lstMailTemplates.DataSource = _mailTemplates;
            lstMailTemplates.Select();
            //_tbSubject = new TBSavedWords(txtSubject);
            //_tbBody = new TBSavedWords(txtMailBody);
        }

        private bool IsItemExist(string value1, string value2)
        {
            var ret = false;
            foreach (ListViewItem item in lstClients.Items)
            {
                if (item.SubItems[0].Text == value1 && item.SubItems[1].Text == value2)
                {
                    ret = true;
                    break;
                }
            }

            return ret;
        }

        public void RefreshClients(DataTable clients)
        {
            _clients = clients;
            RefreshClients();
        }

        public void AddPerson(string name, string value)
        {
            _clients.Rows.Add(name, value);
            RefreshClients();
        }

        public void AddPersonsRange(DataTable persons)
        {
            foreach (DataRow p in persons.Rows)
            {
                if (!IsExist(p)) _clients.Rows.Add(p["full_name"], Utils.GetDBValue<string>(p["email"]));
            }
            RefreshClients();
        }

        public bool IsExist(DataRow person)
        {
            foreach (DataRow row in _clients.Rows)
            {
                if (person["full_name"] == row[0] && person["email"] == row[1]) return true;
            }
            return false;
        }

        private void RefreshClients()
        {
            SuspendLayout();
            lstClients.Items.Clear();
            _activeUsers = 0;

            if (_clients == null)
            {
                lblTotalClients.Text = string.Format(_totalClients, "0");
                ResumeLayout(true);
                return;
            }

            ListViewItem item;
            string email, name;

            foreach (DataRow row in _clients.Rows)
            {
                item = new ListViewItem();
                name = Utils.GetDBValue(row, "full_name", string.Empty);
                email = Utils.GetDBValue(row, "email", string.Empty);
                if (name.Length + email.Length == 0) continue;
                if (IsItemExist(name, email)) continue;
                item.Text = name;

                if (email.Length == 0)
                {
                    item.ImageIndex = 2;
                    item.Tag = "InActive";
                }
                else if (Validation.IsEmailValid(email))
                {
                    item.ImageIndex = 0;
                    item.Tag = "Active";
                    _activeUsers++;
                }
                else
                {
                    item.ImageIndex = 1;
                    item.Tag = "InActive";
                }

                item.SubItems.Add(email);
                lstClients.Items.Add(item);
            }

            if (lstClients.Items.Count > 0) lstClients.Items[0].Selected = true;
            lblTotalClients.Text = string.Format(_totalClients, _activeUsers);
            ResumeLayout(false);
        }

        private void lnkRetry_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lnkRetry.Visible = false;
            lblConnecting.ForeColor = Color.Maroon;
            lblConnecting.Text = _connectingText;
            lblConnecting.Image = null;
            lblConnecting.Visible = true;
        }

        private void TextBox_Focus(object sender, EventArgs e)
        {
            base.TextBoxEnter((TextBox)sender);
        }

        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            base.TextBoxLeave((TextBox)sender);
        }

        private void frmMailCampaign_Activated(object sender, EventArgs e)
        {
            if (_refreshList) return;
            _refreshList = true;
            if (lstClients.Items.Count > 0) lstClients.Items[0].Selected = true;
        }

        private void pnlPersons_Paint(object sender, PaintEventArgs e)
        {
            var c = Color.FromArgb(107, 137, 165);
            var rec = new Rectangle(0, 0, pnlPersons.Width - 1, pnlPersons.Height - 1);
            e.Graphics.DrawRectangle(new Pen(c), rec);
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            var msg = string.Empty;
            txtPersonName.Text = txtPersonName.Text.Trim();
            txtPersonPhone.Text = txtPersonPhone.Text.Trim();

            if (txtPersonName.Text.Length < 2)
            {
                txtPersonName.BackColor = Validation.ErrorColor;
                msg += "אנא הזן לפחות 2 תווים בשם הנמען\n";
            }

            if (txtPersonPhone.Text.Length > 0)
            {
                if (!Validation.IsEmailValid(txtPersonPhone.Text))
                {
                    txtPersonPhone.BackColor = Validation.ErrorColor;
                    msg += "כתובת הדוא\"ל של הנמען אינה תקינה\n";
                }
            }
            else
            {
                txtPersonPhone.BackColor = Validation.ErrorColor;
                msg += "אנא הזן את כתובת הדוא\"ל של הנמען\n";
            }

            if (msg.Length > 0)
            {
                const string msg1 = "הוספת נמען...";
                MyMessageBox = new MyMessageBox(msg, msg1, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MyMessageBox.Show(this);
                return;
            }

            ListViewItem item;
            if (pnlPersons.Tag.ToString() == "New")
            {
                item = new ListViewItem(txtPersonName.Text);
                _activeUsers++;
            }
            else
            {
                item = lstClients.SelectedItems[0];
                if (item.Tag.ToString() == "InActive") _activeUsers++;
            }

            item.ImageIndex = 0;
            item.Tag = "Active";

            if (pnlPersons.Tag.ToString() == "New")
            {
                item.SubItems.Add(txtPersonPhone.Text);
                //item.SubItems.Add(name);
                lstClients.Items.Add(item);
                item.Selected = true;
                lstClients.Select();
                item.EnsureVisible();
            }
            else
            {
                item.Text = txtPersonName.Text;
                item.SubItems[1].Text = txtPersonPhone.Text;
            }

            lblTotalClients.Text = string.Format(_totalClients, _activeUsers);
            btnCancelPerson_Click(null, null);
        }

        private void btnCancelPerson_Click(object sender, EventArgs e)
        {
            SuspendLayout();
            if (pnlPersons.Visible)
            {
                lstClients.Height = 546;
                lstClients.Top = 78;
                pnlPersons.Visible = false;
            }
            txtPersonPhone.Text = string.Empty;
            txtPersonName.Text = string.Empty;
            txtPersonName.BackColor = Color.White;
            txtPersonPhone.BackColor = Color.White;

            ResumeLayout(true);
        }

        private void tbbAddClient_Click(object sender, EventArgs e)
        {
            SuspendLayout();
            if (!pnlPersons.Visible)
            {
                lstClients.Height = 450;
                lstClients.Top = 174;
                pnlPersons.Visible = true;
            }
            pnlPersons.Tag = "New";
            lblPersonText.Text = @"הוספת נמען חדש...";
            btnAddPerson.Text = @"הוסף";
            txtPersonName.Enabled = true;
            txtPersonName.Text = string.Empty;
            txtPersonName.Left = txtPersonPhone.Left + btnBrowse.Width;
            txtPersonName.Width = txtPersonPhone.Width - btnBrowse.Width;
            btnBrowse.Visible = true;
            txtPersonPhone.Text = string.Empty;
            txtPersonName.Select();
            TextBox_Focus(txtPersonName, null);
            ResumeLayout(true);
        }

        private void tbbUpdate_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count == 0) return;
            SuspendLayout();
            if (!pnlPersons.Visible)
            {
                lstClients.Height = 450;
                lstClients.Top = 174;
                pnlPersons.Visible = true;
            }
            pnlPersons.Tag = "Edit";
            lblPersonText.Text = @"עדכון נמען קיים...";
            btnAddPerson.Text = @"עדכן";
            txtPersonName.Text = lstClients.SelectedItems[0].Text;
            txtPersonName.Text = lstClients.SelectedItems[0].Text;
            txtPersonName.Left = txtPersonPhone.Left;
            txtPersonName.Width = txtPersonPhone.Width;
            btnBrowse.Visible = false;
            txtPersonPhone.Text = lstClients.SelectedItems[0].SubItems[1].Text;
            txtPersonName.Select();
            TextBox_Focus(txtPersonName, null);
            ResumeLayout(true);
        }

        private void lstMailTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            _templateId = (int)lstMailTemplates.SelectedValue;
            var rows = _mailTemplates.Select("id=" + _templateId);
            if (rows.Length > 0)
            {
                try
                {
                    lblPreview.Image = Image.FromFile("MailTemlates\\preview_" + _templateId + ".jpg");
                }
                catch
                {
                    lblPreview.Image = null;
                }

                var client = AppSettingsHelper.GetParamValue("APP_CLIENT_NAME");
                var subject = Utils.GetDBValue<string>(rows[0], "mail_subject");
                var body = Utils.GetDBValue(rows[0], "mail_body", string.Empty);

                txtSubject.Text = subject.Replace(Utils.AddClientname, client);
                txtMailBody.Text = body.Replace(Utils.AddClientname, client);
            }
        }

        private void txtAddName1_Click(object sender, EventArgs e)
        {
            txtSubject.SelectedText = Utils.AddUsername;
            txtSubject.Select();
        }

        private void txAddName2_Click(object sender, EventArgs e)
        {
            txtMailBody.SelectedText = Utils.AddUsername;
            txtMailBody.Select();
        }

        private void tbbReset_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (pnlPersons.Visible)
            {
                btnCancelPerson_Click(null, null);
            }
            RefreshClients();
            if (lstClients.Items.Count > 0) lstClients.Items[0].Selected = true;
            this.Cursor = Cursors.Default;
        }

        private void tbbDelete_Click(object sender, EventArgs e)
        {
            if (pnlPersons.Visible)
            {
                btnCancelPerson_Click(null, null);
            }

            if (lstClients.SelectedItems.Count > 0)
            {
                var item = lstClients.SelectedItems[0];
                var msg1 = "האם אתה בטוח שברצונך להסיר את הנמען:\n\"" + item.Text + "\" מהרשימה";
                const string msg2 = "הסרת מנמען מהרשימה...";

                MyMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
                var res = MyMessageBox.Show(this);

                if (res == DialogResult.Yes)
                {
                    if (item.Tag.ToString() == "Active")
                    {
                        _activeUsers--;
                        lblTotalClients.Text = string.Format(_totalClients, _activeUsers);
                    }
                    var index = item.Index;
                    lstClients.Items.Remove(item);

                    if (lstClients.Items.Count > 0)
                    {
                        if (lstClients.Items.Count - 1 < index)
                        {
                            lstClients.Items[lstClients.Items.Count - 1].Selected = true;
                        }
                        else
                        {
                            lstClients.Items[index].Selected = true;
                        }
                    }
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var list = new List<string>();
            var email = AppSettingsHelper.GetParamValue("MAIL_FROM");
            var exist = false;
            foreach (ListViewItem item in lstClients.Items)
            {
                exist = (item.SubItems[0].Text == email);
                if (item.Tag.Equals("Active"))
                {
                    list.Add(item.SubItems[1].Text);
                }
            }

            if (list.Count == 0)
            {
                var msg = new MyMessageBox("לא נמצאו נמענים עם כתובת דוא\"ל ברשימה", "שים לב...", MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                msg.Show();
                return;
            }

            if (!exist && Validation.IsEmailValid(email, true))
            {
                list.Add(email);
            }

            using (var form = new FrmAddressList(list))
            {
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
        }

        private bool IsFormValid()
        {
            string msg1;
            const string msg2 = "שליחת דוא\"ל...";
            txtSubject.Text = txtSubject.Text.Trim();
            txtMailBody.Text = txtMailBody.Text.Trim();

            if (_activeUsers == 0)
            {
                msg1 = "לא נמצאו נמענים לשליחת דוא\"ל\nסה\"כ נמענים שווה 0\nפעולת השליחה מבוטלת";
                MyMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MyMessageBox.Show(this);
                return false;
            }

            if (!_isConnectionOk)
            {
                msg1 = "לא ניתן לשלוח את הדוא\"ל, שגיאה בהתחברות אל שרת הדואר\n" +
                    "וודא כי המחשב מחובר אל רשת האינטרנט ונסה לשלוח שוב\n" +
                    "פעולת השליחה מבוטלת. אם התקלה חוזרת על עצמה פנה אל שירות הלקוחות\n\n";

                MyMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok, MyMessageBox.MyMessageDefaultButton.Button1);
                MyMessageBox.Show(this);
                return false;
            }

            msg1 = "הנך עומד לשלוח דוא\"ל לכל " + _activeUsers + " הנמענים ברשימה\nהאם אתה בטוח שברצונך לבצע פעולה זו";
            MyMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
            var res = MyMessageBox.Show(this);
            if (res == DialogResult.No) return false;

            return true;
        }

        /// <summary>
        /// Sends the single mail.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="email">The email.</param>
        /// <param name="html">The HTML.</param>
        /// <returns></returns>
        private bool SendSingleMail(string name, string email, string html)
        {
            var ret = false;

            var mail = new MailMessage
            {
                IsBodyHtml = true,
                From = new MailAddress(AppSettingsHelper.GetParamValue("MAIL_FROM"), AppSettingsHelper.GetParamValue("APP_CLIENT_NAME")),
                Body = html.Replace("{שם הלקוח}", name),
                Subject = txtSubject.Text.Trim().Replace("\n", "<br />").Replace("{שם הלקוח}", name),
            };
            var address = new MailAddress(email, name);
            mail.To.Add(address);

            foreach (AttachmentComboItem item in cmbFiles.Items)
            {
                mail.Attachments.Add(item.Attachment);
            }

            try
            {
                // TODO: ***
                ret = true;
            }
            catch (Exception ex)
            {
                _error = ex;
                EventLogManager.AddErrorMessage("Error sending mail", ex);
            }

            return ret;
        }

        private bool SendMail()
        {
            this.Cursor = Cursors.WaitCursor;
            var ret = false;
            var exist = false;
            var email = AppSettingsHelper.GetParamValue("MAIL_FROM");

            var template = MailCampaignHelper.GetMailTemplateHtml(_templateId).Replace("images/", "http://smsfactorystorage.blob.core.windows.net/softhair/Admin/images/");
            var body = txtMailBody.Text.Trim().Replace("\n", "<br />");
            var html = template.Replace("{Place holder for main mail text content}", body);

            foreach (ListViewItem item in lstClients.Items)
            {
                exist = (item.SubItems[0].Text == email);
                if (item.Tag.Equals("Active"))
                {
                    ret |= SendSingleMail(item.Text, item.SubItems[1].Text, html);
                }
            }

            if (!exist && Validation.IsEmailValid(email, true))
            {
                ret |= SendSingleMail(AppSettingsHelper.GetParamValue("APP_CLIENT_NAME"), email, html);
            }

            this.Cursor = Cursors.Default;
            return ret;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (IsFormValid())
            {
                const string msg2 = "שליחת דוא\"ל...";
                if (SendMail())
                {
                    const string msg1 = "שליחת הדוא\"ל התבצעה בהצלחה\nוהוא יתקבל בדקות הקרובות בתיבות הנמענים";
                    MyMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Information, MyMessageBox.MyMessageButton.Ok);
                    MyMessageBox.Show(this);
                    this.Close();
                }
                else
                {
                    const string title = "שגיאה שליחת דוא\"ל...";
                    const string head = "שליחת הודעת דוא\"ל";
                    const string desc = "שליחת הודעת הדוא\"ל נכשלה\nשים לב כי ההודעת ששלחת לא הגיעה אל הנמענים";
                    General.ShowErrorMessageDialog(this, title, head, desc, _error, "frmMailCampaign");
                }
            }
        }

        private void tbbSend_Click(object sender, EventArgs e)
        {
            btnSend_Click(null, null);
        }

        private void lstClients_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tbbUpdate_Click(null, null);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var rect = btnBrowse.RectangleToScreen(btnBrowse.DisplayRectangle);

            if (_fClientQuickSearch == null || _fClientQuickSearch.IsDisposed)
            {
                this.Cursor = Cursors.WaitCursor;
                _fClientQuickSearch = new FormClientQuickSearch { VisibleItems = 6, Left = rect.Left, Top = rect.Bottom };
                _fClientQuickSearch.ClientSelected += fClientQuickSearch_ClientSelected;
                _fClientQuickSearch.Show();
                this.Cursor = Cursors.Default;
            }
            else
            {
                _fClientQuickSearch.Left = rect.Left;
                _fClientQuickSearch.Top = rect.Bottom;
            }
            _fClientQuickSearch.Select();
        }

        private void fClientQuickSearch_ClientSelected(object sender, EventArgs e)
        {
            txtPersonName.Text = ClientHelper.GetFullName(FormClientQuickSearch.SelectedClientId);
            txtPersonPhone.Text = ClientHelper.GetClientEmail(FormClientQuickSearch.SelectedClientId);
        }

        private void frmMailCampaign_RequestForClose(object sender, EventArgs e)
        {
            TbbClose_Click(null, null);
        }

        private void txtMailBody_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Control)
            {
                var data = Clipboard.GetText();
                if (!string.IsNullOrEmpty(data))
                {
                    data = data.Replace("{", string.Empty).Replace("}", string.Empty);
                    Clipboard.SetText(data);
                }
            }
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.CheckFileExists = true;
                dialog.CheckPathExists = true;
                dialog.Multiselect = true;
                dialog.Title = @"בחר קובץ לצירף לאימייל...";
                var result = dialog.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    foreach (var name in dialog.FileNames)
                    {
                        try
                        {
                            var file = FileReader.GetAttachment(name);
                            cmbFiles.Items.Insert(0, new AttachmentComboItem { Attachment = file });
                        }
                        catch (Exception ex)
                        {
                            General.ShowErrorMessageDialog(this, "שגיאה בקריאת קובץ", "שגיאה בקריאת קובץ מצורף", "ייתכן והקובץ פתוח בתוכנה אחרת", ex, "Email");
                        }
                    }
                    SetToolbarAttachButtons();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (cmbFiles.SelectedIndex < 0) return;
            cmbFiles.Items.RemoveAt(cmbFiles.SelectedIndex);
            SetToolbarAttachButtons();
        }

        private void SetToolbarAttachButtons()
        {
            if (cmbFiles.Items.Count > 0) cmbFiles.SelectedIndex = 0;
            cmbFiles.Visible = cmbFiles.Items.Count > 0;
            btnRemove.Visible = cmbFiles.Visible;
        }
    }
}