using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ClientManage.Interfaces;
using ClientManage.BL;
using ClientManage.Library;
using ClientManage.BL.Library;

namespace ClientManage.Forms
{
    public partial class FormSms : BasePopupForm
    {
        private List<PostAddressee> _posts;
        private DataTable _messages;
        private int _activeUsers;
        private int _credits = -2;
        private int _maxUserLength;
        private int _maxSmsChars = -1;
        private int _msgCount;
        private int _defaultMessageId;
        private bool _refreshList;
        private bool _cancelClose;
        private const string TotalChars = "סה\"כ {0} תווים";
        private const string TotalClientsFormat = "סה\"כ {0} נמענים";
        private const string TotalMsgFormat = " ({0} הודעות)";
        private FormClientQuickSearch _fClientQuickSearch;
        private readonly SmsEngine _smsEngine = new SmsEngine();

        public FormSms(List<PostAddressee> posts)
        {
            InitializeComponent();
            RefreshClients(posts);
        }

        public int TotalClients
        {
            get
            {
                return lstClients.Items.Count;
            }
        }

        public void AddPerson(PostAddressee post)
        {
            if (_posts.Any(p => IsExist(post))) return;

            _posts.Add(post);
            RefreshClients();
        }

        public void AddPersonsRange(List<PostAddressee> posts)
        {
            foreach (var p in posts)
            {
                if (!IsExist(p)) _posts.Add(p);
            }
            RefreshClients();
        }

        private bool IsExist(PostAddressee post)
        {
            return _posts.Any(p => post.FullName == p.FullName && post.CellPhone == p.CellPhone);
        }

        public void RefreshClients(List<PostAddressee> posts)
        {
            _posts = posts;
            if (posts != null) RefreshClients();
        }

        public int DefaultMessageId
        {
            get { return _defaultMessageId; }
            set { _defaultMessageId = value; }
        }

        private void GetSmsCredits()
        {
            const string title = "בבדיקה, אנא המתן...";
            lblCredits.Text = title;
            lnkRetry.Visible = false;
            MethodInvoker th = SetCredits;
            th.BeginInvoke(null, null);
        }

        private void TxtMsgTextChanged(object sender, EventArgs e)
        {
            var text = txtMsg.Text.Replace(Utils.AddUsername, string.Empty.PadLeft(_maxUserLength, 'x'));
            _msgCount = Convert.ToInt32(Math.Floor(Convert.ToDouble(text.Length) / _maxSmsChars));
            var i = text.Length - (_msgCount * _maxSmsChars);
            if (i == 0 && text.Length > 0)
            {
                i = _maxSmsChars;
                _msgCount--;
            }

            lblTotalChars.Text = string.Format(TotalChars, i);

            if (_msgCount > 0)
            {
                lblTotalChars.Text += string.Format(TotalMsgFormat, _msgCount + 1);
                lblTotalChars.ForeColor = Color.Maroon;
            }
            else
            {
                lblTotalChars.ForeColor = Color.DarkBlue;
            }
        }

        private void FrmSmsLoad(object sender, EventArgs e)
        {
            RefreshSmsMessages();
            _maxSmsChars = AppSettingsHelper.GetParamValue<int>("SMS_MAX_CHARS");
            lblMaxChars.Text = _maxSmsChars.ToString();
            txtMsg.MaxLength = 5 * _maxSmsChars;
            pnlNewMsg.Top = 64;
            if (_defaultMessageId > 0) SelectMessage(_defaultMessageId);
            GetSmsCredits();
            txtMsg.Select();
        }

        private void RefreshSmsMessages(int selectedItem = 0)
        {
            _messages = SmsHelper.GetSmsMessages();
            cmbMessages.DataSource = _messages;
            cmbMessages.DisplayMember = "msg_title";
            cmbMessages.ValueMember = "id";
            if (cmbMessages.Items.Count > 0)
            {
                if (selectedItem >= cmbMessages.Items.Count)
                {
                    cmbMessages.SelectedIndex = cmbMessages.Items.Count - 1;
                }
                else
                {
                    cmbMessages.SelectedIndex = selectedItem;
                }
            }
        }

        private void CalculateMaxUserLength()
        {
            string name;
            _maxUserLength = 0;

            foreach (ListViewItem item in lstClients.Items)
            {
                if (item.Tag.ToString() == "Active")
                {
                    name = item.Text;
                    var pos = name.IndexOf(" ");
                    if (pos > 1) name = name.Substring(0, pos);
                    if (name.Length > _maxUserLength) _maxUserLength = name.Length;
                }
            }
        }

        private bool IsItemExist(string value1, string value2)
        {
            return lstClients.Items.Cast<ListViewItem>().Any(item => item.SubItems[0].Text == value1 && item.SubItems[1].Text == value2);
        }

        private void RefreshClients()
        {
            SuspendLayout();
            lstClients.Items.Clear();
            _activeUsers = 0;

            if (_posts == null)
            {
                lblTotalClients.Text = string.Format(TotalClientsFormat, "0");
                ResumeLayout(true);
                return;
            }

            ListViewItem item;

            foreach (var p in _posts)
            {
                item = new ListViewItem();
                if (p.FullName.Length + p.CellPhone.Length == 0) continue;
                if (IsItemExist(p.FullName, p.CellPhone)) continue;
                item.Text = p.FullName;

                if (p.CellPhone.Length == 0)
                {
                    item.ImageIndex = 2;
                    p.Enable = false;
                }
                else if (p.CellPhone.Length == 10)
                {
                    var nameLength = p.FirstName.Length;
                    if (nameLength > _maxUserLength) _maxUserLength = nameLength;
                    item.ImageIndex = 0;
                    p.Enable = true;
                    _activeUsers++;
                }
                else
                {
                    item.ImageIndex = 1;
                    p.Enable = false;
                }

                item.Tag = p;
                item.SubItems.Add(p.CellPhone);
                lstClients.Items.Add(item);
            }

            lblTotalClients.Text = string.Format(TotalClientsFormat, _activeUsers);
            ResumeLayout(false);
        }

        private bool ValidateForm()
        {
            string msg1;
            const string msg2 = "שליחת הודעת SMS";
            var totalMsg = (_msgCount + 1) * _activeUsers;
            txtMsg.Text = txtMsg.Text.Trim();

            if (txtMsg.Text.Length == 0)
            {
                msg1 = "תוכן ההודעה ריק\nאנא הזן הודעה לשליחה";
                MyMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MyMessageBox.Show(this);
                return false;
            }

            if (_activeUsers == 0)
            {
                msg1 = "לא נמצאו נמענים עם מספר טלפון תקין ברשימה\nאנא מלא לפחות נמען אחד";
                MyMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MyMessageBox.Show(this);
                return false;
            }

            if (_credits >= 0 && totalMsg > _credits)
            {
                msg1 = "לא נותרו בחשבונך מספיק הודעות לשליחה לכל הנמענים ברשימה\n" +
                    "בחשבונך יש " + _credits + " הודעות\n" +
                    "וכמות ההודעות המיועדות לשליחה היא  " + totalMsg + "\n" +
                    "פעולת השליחה מבוטלת\nפנה אל שירות הלקוחות לרכישת הודעות נוספות\n\n";

                MyMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok, MyMessageBox.MyMessageDefaultButton.Button1);
                MyMessageBox.Show(this);
                return false;
            }

            if (_msgCount > 0)
            {
                msg1 = "שים לב!\nלכל נמען ברשימה ישלחו " + Convert.ToString(_msgCount + 1) +
                    " הודעות\nובסה\"כ ישלחו " + Convert.ToString(totalMsg) +
                " הודעות SMS.\n\nהאם אתה בטוח שברצונך להמשיך ולשלוח את ההודעות";

                MyMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
                var res = MyMessageBox.Show(this);
                if (res != DialogResult.Yes) return false;
            }

            if (_credits < 0)
            {
                msg1 = "לא ניתן לשלוח את ההודעה, שגיאה בהתחברות אל שרת ההודעות\n" +
                    "וודא כי המחשב מחובר אל רשת האינטרנט ונסה לשלוח שוב\n" +
                    "פעולת השליחה מבוטלת. אם התקלה חוזרת על עצמה פנה אל שירות הלקוחות\n\n";

                MyMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok, MyMessageBox.MyMessageDefaultButton.Button1);
                MyMessageBox.Show(this);
                GetSmsCredits();
                return false;
            }

            return true;
        }

        private void TextBox_Focus(object sender, EventArgs e)
        {
            base.TextBoxEnter((TextBox)sender);
        }

        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            base.TextBoxLeave((TextBox)sender);
        }

        private void SetCredits()
        {
            _credits = SmsHelper.GetCredit();
            MethodInvoker th = SetCreditsTh;
            try
            {
                this.Invoke(th);
            }
            catch { Utils.CatchException(); }
        }

        private void SetCreditsTh()
        {
            if (_credits != -2)
            {
                if (_credits == -1)
                {
                    const string title = "שגיאה בהתחברות לשרת SMS";
                    lblCredits.Text = title;
                    lnkRetry.Visible = true;
                }
                else
                {
                    lblCredits.Text = _credits.ToString();
                }
            }
        }

        private void CmbMessagesSelectedIndexChanged(object sender, EventArgs e)
        {
            var val = cmbMessages.SelectedValue as DataRowView;
            var msg = string.Empty;
            try
            {
                msg = Utils.GetDBValue<string>(_messages.Select("id=" + val.Row[0])[0]["msg_body"]);
            }
            catch { Utils.CatchException(); }

            txtMsg.Text = msg;
            txtMsg.Select();
        }

        private void Label8Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(127, 157, 185)), 0, 0, label8.Width - 1, label8.Height - 1);
        }

        private void FrmSmsFormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cancelClose)
            {
                _cancelClose = false;
                e.Cancel = true;
            }
            else
            {
                lstClients.Clear();
            }
        }

        private void BtnMsgCancelClick(object sender, EventArgs e)
        {
            txtNewMsg.Text = string.Empty;
            pnlNewMsg.Visible = false;
            txtMsg.Select();
        }

        private void BtnMsgSaveClick(object sender, EventArgs e)
        {
            txtNewMsg.Text = txtNewMsg.Text.Trim();
            if (SmsHelper.IsSmsTitleExist(txtNewMsg.Text))
            {
                const string msg1 = "כותרת ההודעה כבר קיימת ברשימה\nהאם לעדכן את תוכן ההודעה\n\n" +
                                    "לחץ 'כן' לעדכון תוכן ההודעה\nלחץ 'לא' לשינוי הכותרת";
                const string msg2 = "שמירת הודעת SMS...";
                MyMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
                var res = MyMessageBox.Show(this);

                if (res == DialogResult.Yes)
                {
                    SmsHelper.UpdateSmsMessage(txtNewMsg.Text, txtMsg.Text.Trim());
                    BtnMsgCancelClick(null, null);
                }
            }
            else
            {
                SmsHelper.AddSmsMessage(txtNewMsg.Text, txtMsg.Text.Trim());
                RefreshSmsMessages(cmbMessages.Items.Count);
                BtnMsgCancelClick(null, null);
            }
        }

        private void TxtNewMsgTextChanged(object sender, EventArgs e)
        {
            btnMsgSave.Enabled = (txtNewMsg.Text.Trim().Length > 0);
        }

        private void BtnDeleteMsgClick(object sender, EventArgs e)
        {
            string msg1;
            const string msg2 = "מחיקת הודעת SMS שמורה";

            if (cmbMessages.SelectedIndex > 0)
            {
                msg1 = "האם אתה בטוח שברצונך למחוק את ההודעה השמורה:\n" + cmbMessages.Text;
                MyMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
                var res = MyMessageBox.Show(this);
                if (res == DialogResult.Yes)
                {
                    SmsHelper.DeleteSmsMessage((int)cmbMessages.SelectedValue);
                    RefreshSmsMessages(cmbMessages.SelectedIndex);
                }
            }
            else
            {
                msg1 = "לא נבחרה הודעה למחיקה";
                MyMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MyMessageBox.Show(this);
                txtMsg.Select();
            }
        }

        private void BtnSaveMsgClick(object sender, EventArgs e)
        {
            if (txtMsg.Text.Trim().Length == 0)
            {
                const string msg1 = "תוכן ההודעה ריק. פעולת השמירה מבוטלת";
                const string msg2 = "שמירת הודעת SMS...";

                MyMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MyMessageBox.Show(this);
            }
            else
            {
                if (cmbMessages.SelectedIndex > 0) txtNewMsg.Text = cmbMessages.Text;
                pnlNewMsg.Visible = true;
                txtNewMsg.Select();
            }
        }

        private void FrmSmsActivated(object sender, EventArgs e)
        {
            if (_refreshList) return;
            _refreshList = true;
            if (lstClients.Items.Count > 0) lstClients.Items[0].Selected = true;
        }

        private void PnlPersonsPaint(object sender, PaintEventArgs e)
        {
            var c = Color.FromArgb(107, 137, 165);
            var rec = new Rectangle(0, 0, pnlPersons.Width - 1, pnlPersons.Height - 1);
            e.Graphics.DrawRectangle(new Pen(c), rec);
        }

        private void PnlNewMsgPaint(object sender, PaintEventArgs e)
        {
            var c = Color.FromArgb(107, 137, 165);
            var rec = new Rectangle(0, 0, pnlNewMsg.Width - 1, pnlNewMsg.Height - 1);
            e.Graphics.DrawRectangle(new Pen(c), rec);
        }

        private void BtnAddPersonClick(object sender, EventArgs e)
        {
            var msg = string.Empty;
            var p = (PostAddressee)btnAddPerson.Tag;
            btnAddPerson.Tag = null;

            txtPersonName.Text = txtPersonName.Text.Trim();
            txtPersonPhone.Text = Utils.DistilPhone(txtPersonPhone.Text).Trim();

            if (txtPersonName.Text.Length < 2)
            {
                txtPersonName.BackColor = Validation.ErrorColor;
                msg += "אנא הזן לפחות 2 תווים בשם הנמען\n";
            }

            if (txtPersonPhone.Text.Length > 0)
            {
                if (!Validation.IsCellPhoneValid(txtPersonPhone.Text))
                {
                    txtPersonPhone.BackColor = Validation.ErrorColor;
                    msg += "מספר הטלפון הנייד של הנמען אינו תקין\n";
                }
            }
            else
            {
                txtPersonPhone.BackColor = Validation.ErrorColor;
                msg += "אנא הזן מספר טלפון נייד של הנמען\n";
            }

            if (msg.Length > 0)
            {
                const string msg1 = "הוספת נמען...";
                MyMessageBox = new MyMessageBox(msg, msg1, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MyMessageBox.Show(this);
                return;
            }

            string name;
            if (p == null)
            {
                p = new PostAddressee();
                name = txtPersonName.Text.Trim();
                var pos = name.IndexOf(" ");
                if (pos > 1)
                {
                    p.FirstName = name.Substring(0, pos);
                    p.LastName = name.Substring(pos + 1).Trim();
                }
                else
                {
                    p.FirstName = name;
                    p.LastName = string.Empty;
                }

                p.CellPhone = txtPersonPhone.Text;
                p.EntityId = -1;
                p.EntityType = -1;
            }

            var item = new ListViewItem(txtPersonName.Text);
            _activeUsers++;
            if (p.FirstName.Length > _maxUserLength) _maxUserLength = p.FirstName.Length;

            item.ImageIndex = 0;
            item.Tag = p;
            item.SubItems.Add(p.CellPhone);
            lstClients.Items.Add(item);
            item.Selected = true;
            item.Focused = true;
            lstClients.Select();
            item.EnsureVisible();

            lblTotalClients.Text = string.Format(TotalClientsFormat, _activeUsers);
            BtnCancelPersonClick(null, null);
            TxtMsgTextChanged(null, null);
        }

        private void BtnCancelPersonClick(object sender, EventArgs e)
        {
            SuspendLayout();

            lstClients.Height = 354;
            lstClients.Top = 84;
            pnlPersons.Visible = false;
            txtPersonPhone.Text = string.Empty;
            txtPersonName.Text = string.Empty;
            txtPersonName.BackColor = Color.White;
            txtPersonPhone.BackColor = Color.White;

            ResumeLayout(true);
        }

        private void BtnSendMessageClick(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                txtMsg.Select();
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            var msg = txtMsg.Text;
            var hasParamaters = txtMsg.Text.Contains(Utils.SmsParameterIdentifier);
            var package = new SmsPackage { Messages = new List<SmsMessage>() };
            if (!hasParamaters) package.DefaultMessageText = msg;

            PostAddressee p;

            foreach (ListViewItem item in lstClients.Items)
            {
                p = (PostAddressee)item.Tag;
                if (p.Enable)
                {
                    var sms = new SmsMessage
                    {
                        ToPhone = p.CellPhone,
                        EntityId = p.EntityId,
                        EntityType = (int)SmsEngine.SmsMessageType.ManualForm,
                        MessageText = (hasParamaters ? msg.Replace(Utils.AddUsername, p.FirstName) : null)
                    };
                    package.Messages.Add(sms);
                }
            }

            try
            {
                if (_smsEngine.SendMessage(package, SmsEngine.SmsMessageType.ManualForm))
                {
                    this.Hide();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                General.ShowErrorMessageDialog(null, "שליחת SMS", "שליחת הודעות SMS", "שליחת ההודעה/ות לשרת נכשלו אנא נסה שוב מאוחר יותר", ex, "SMS");
            }

            this.Cursor = Cursors.Default;
        }

        private void LnkRetryLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetSmsCredits();
            lnkRetry.Visible = false;
        }

        private void TbbAddUserClick(object sender, EventArgs e)
        {
            const string text1 = "הוספת נמען חדש...";
            const string text2 = "הוסף";

            SuspendLayout();
            lstClients.Height = 258;
            lstClients.Top = 180;
            pnlPersons.Visible = true;
            lblPersonText.Text = text1;
            btnAddPerson.Text = text2;
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

        private void TbbDeleteUserClick(object sender, EventArgs e)
        {
            if (pnlPersons.Visible)
            {
                BtnCancelPersonClick(null, null);
            }

            if (lstClients.SelectedItems.Count > 0)
            {
                var item = lstClients.SelectedItems[0];
                var post = (PostAddressee)item.Tag;
                var msg1 = "האם אתה בטוח שברצונך להסיר את הנמען:\n\"" + item.Text + "\" מהרשימה";
                const string msg2 = "הסרת מנמען מהרשימה...";
                MyMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
                var res = MyMessageBox.Show(this);

                if (res == DialogResult.Yes)
                {
                    if (post.Enable)
                    {
                        _activeUsers--;
                        lblTotalClients.Text = string.Format(TotalClientsFormat, _activeUsers);
                    }
                    var index = item.Index;
                    lstClients.Items.Remove(item);
                    _posts.Remove(post);
                    CalculateMaxUserLength();
                    TxtMsgTextChanged(null, null);

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

        private void XpFlatButton1Click(object sender, EventArgs e)
        {
            txtMsg.SelectedText = Utils.AddUsername;
            txtMsg.Select();
        }

        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TbbSendClick(object sender, EventArgs e)
        {
            BtnSendMessageClick(null, null);
        }

        private void BtnBrowseClick(object sender, EventArgs e)
        {
            var rect = btnBrowse.RectangleToScreen(btnBrowse.DisplayRectangle);

            if (_fClientQuickSearch == null || _fClientQuickSearch.IsDisposed)
            {
                this.Cursor = Cursors.WaitCursor;
                _fClientQuickSearch = new FormClientQuickSearch
                {
                    VisibleItems = 6,
                    Left = rect.Left,
                    Top = rect.Bottom
                };
                _fClientQuickSearch.ClientSelected += FClientQuickSearchClientSelected;
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

        private void FClientQuickSearchClientSelected(object sender, EventArgs e)
        {
            var p = new PostAddressee();
            var c = ClientHelper.GetClient(FormClientQuickSearch.SelectedClientId);
            p.EntityId = c.Id;
            p.EntityType = (int)General.EntityType.Client;
            p.FirstName = c.FirstName;
            p.LastName = c.LastName;
            p.EntityType = (int)General.EntityType.Client;
            p.CellPhone = c.CellPhone1;

            txtPersonName.Text = p.FullName;
            txtPersonPhone.Text = p.CellPhone;
            btnAddPerson.Tag = p;

            BtnAddPersonClick(null, null);
        }

        private void FrmSmsRequestForClose(object sender, EventArgs e)
        {
            ToolStripButton1Click(null, null);
        }

        private void TxtMsgKeyDown(object sender, KeyEventArgs e)
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

        public void SelectMessage(int id)
        {
            cmbMessages.SelectedValue = id;
        }
    }
}