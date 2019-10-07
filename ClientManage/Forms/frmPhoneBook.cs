using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ClientManage.BL;
using ClientManage.UserControls;
using ClientManage.Interfaces;
using ClientManage.Library;

namespace ClientManage.Forms
{
    public partial class FormPhonebook : BaseMdiChild
    {
        private bool _isDeselectContacts;
        private readonly List<Contact> _contacts = new List<Contact>();
        private readonly string[] _filterFields = Utils.GetStringArray(AppSettingsHelper.GetParamValue<string>("CONTACT_FILTER_BY"));

        public event DialRequestEventHandler DialRequest;
        public event OpenFormEventHandler OpenForm;

        public FormPhonebook()
        {
            InitializeComponent();
        }

        public void UpdateContact(PhoneBookContact contact)
        {
            foreach (var c in _contacts)
            {
                if (c.Id == contact.Id)
                {
                    c.FirstName = contact.FirstName;
                    c.LastName = contact.LastName;
                    c.JobCompany = contact.JobTitle + " - " + contact.Company;
                    c.Email = contact.Email;
                    c.PhoneNo1 = contact.PhoneNo1;
                    c.PhoneNo2 = contact.PhoneNo2;
                    c.PhoneNo3 = contact.PhoneNo3;
                    c.Fax = contact.Fax;
                    c.Street = contact.Street;
                    c.City = contact.City;
                    c.ZipCode = contact.ZipCode;
                    c.MailCellNo = contact.MailCellNo;
                    c.ShowData();
                }
            }
        }

        public void AddContact(PhoneBookContact contact)
        {
            flowPanel.SuspendLayout();
            flowPanel.Controls.Clear();
            _contacts.Clear();

            searchPanel1.ResetPanel();
            Contact current = null;

            var orderBy = Contact.LastNameBefore ? 0 : 1;
            var ds = PhoneBookHelper.GetAllContacts(orderBy);
            if (ds.Tables[0].Rows.Count == 0) return;

            for (var i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                _contacts.Add(GetContactByRow(ds.Tables[0].Rows[i]));
                if (!flowPanel.Contains(_contacts[i])) flowPanel.Controls.Add(_contacts[i]);
                if (_contacts[i].Id == contact.Id) current = _contacts[i];
            }
            if (current != null)
            {
                current.Selected = true;
                current.Select();
                flowPanel.ScrollControlIntoView(current);
            }
            flowPanel.ResumeLayout(true);
        }

        public void FocusSelectedContact()
        {
            foreach (Contact cn in flowPanel.Controls)
            {
                if (cn.Selected)
                {
                    cn.Select();
                    break;
                }
            }
        }

        private void ShowAllContacts()
        {
            flowPanel.SuspendLayout();
            flowPanel.Controls.Clear();
            flowPanel.ResumeLayout(true);

            FillContactsThread();
        }

        private void FilterContacts(string filterBy)
        {
            DeselectContacts(null);
            flowPanel.SuspendLayout();
            flowPanel.Controls.Clear();

            var cCount = 0;

            foreach (var field in _filterFields)
            {
                cCount += LoadContactsToTable(field, filterBy);
            }
            
            searchPanel1.IsFilter = true;
            if (cCount > 0) flowPanel.Controls[0].Select();
            flowPanel.ResumeLayout(true);
        }

        private int LoadContactsToTable(string property, string filterBy)
        {
            string field;
            string field2;
            filterBy = filterBy.ToLower();
            var cCount = 0;
            bool isMatch;

            switch (property)
            {
                #region By LastName
                case "LastName":
                    foreach (var c in _contacts)
                    {
                        field = c.LastName.ToLower();
                        isMatch = field.StartsWith(filterBy);

                        if (isMatch)
                        {
                            if (!flowPanel.Contains(c)) flowPanel.Controls.Add(c);
                            cCount++;
                        }
                    }
                    break;
                #endregion

                #region By FirstName
                case "FirstName":
                    foreach (var c in _contacts)
                    {
                        field = c.FirstName.ToLower();
                        isMatch = field.StartsWith(filterBy);

                        if (isMatch)
                        {
                            if (!flowPanel.Contains(c)) flowPanel.Controls.Add(c);
                            cCount++;
                        }
                    }
                    break;
                #endregion

                #region By ContactName
                case "ContactName":
                    foreach (var c in _contacts)
                    {
                        field = c.FirstName.ToLower() + " " + c.LastName.ToLower();
                        field2 = c.LastName.ToLower() + " " + c.FirstName.ToLower();
                        
                        isMatch = field.StartsWith(filterBy);
                        isMatch = isMatch || field2.StartsWith(filterBy);

                        if (isMatch)
                        {
                            if (!flowPanel.Contains(c)) flowPanel.Controls.Add(c);
                            cCount++;
                        }
                    }
                    break;
                #endregion

                #region By Street
                case "Street":
                    foreach (var c in _contacts)
                    {
                        field = c.Street.ToLower();
                        isMatch = field.IndexOf(filterBy) >= 0;

                        if (isMatch)
                        {
                            if (!flowPanel.Contains(c)) flowPanel.Controls.Add(c);
                            cCount++;
                        }
                    }
                    break;
                #endregion

                #region By City
                case "City":
                    foreach (var c in _contacts)
                    {
                        field = c.City.ToLower();
                        isMatch = field.Equals(filterBy);

                        if (isMatch)
                        {
                            if (!flowPanel.Contains(c)) flowPanel.Controls.Add(c);
                            cCount++;
                        }
                    }
                    break;
                #endregion

                #region By Phone & Fax
                case "Phone":
                    filterBy = Utils.DistilPhone(filterBy);
                    foreach (var c in _contacts)
                    {
                        field = Utils.DistilPhone(c.PhoneNo1);
                        isMatch = field.StartsWith(filterBy);

                        if (!isMatch)
                        {
                            field = Utils.DistilPhone(c.PhoneNo2);
                            isMatch = field.StartsWith(filterBy);
                        }
                        if (!isMatch)
                        {
                            field = Utils.DistilPhone(c.PhoneNo3);
                            isMatch = field.StartsWith(filterBy);
                        }
                        if (!isMatch)
                        {
                            field = Utils.DistilPhone(c.Fax);
                            isMatch = field.StartsWith(filterBy);
                        }

                        if (isMatch)
                        {
                            if (!flowPanel.Contains(c)) flowPanel.Controls.Add(c);
                            cCount++;
                        }
                    }
                    break;
                #endregion
            }

            return cCount;
        }

        private void FrmPhoneBook_Load(object sender, EventArgs e)
        {
            Contact.LastNameBefore = AppSettingsHelper.GetParamValue<bool>("CONTACT_LASTNAME_BEFORE");
            var orderBy = Contact.LastNameBefore ? 0 : 1;
            var ds = PhoneBookHelper.GetAllContacts(orderBy);
            if (ds.Tables[0].Rows.Count == 0) return;

            for (var i = 0; i < ds.Tables[0].Rows.Count; i++ )
            {
                _contacts.Add(GetContactByRow(ds.Tables[0].Rows[i]));
            }
            FillContactsThread();
        }

        private void FillContactsThread()
        {
            var mi = new MethodInvoker(FillContacts);
            this.Invoke(mi);
        }

        private void FillContacts()
        {
            foreach (var t in _contacts)
            {
                if (!flowPanel.Contains(t)) flowPanel.Controls.Add(t);
            }
        }

        private Contact GetContactByRow(DataRow row)
        {
            var c = new Contact
            {
                Id = Convert.ToInt32(row["id"]),
                FirstName = Utils.GetDBValue<string>(row, "first_name"),
                LastName = Utils.GetDBValue<string>(row, "last_name"),
                JobCompany = Utils.GetDBValue<string>(row, "job_company"),
                Email = Utils.GetDBValue<string>(row, "email"),
                PhoneNo1 = Utils.GetDBValue<string>(row, "phone_no_1"),
                PhoneNo2 = Utils.GetDBValue<string>(row, "phone_no_2"),
                PhoneNo3 = Utils.GetDBValue<string>(row, "phone_no_3"),
                Fax = Utils.GetDBValue<string>(row, "fax"),
                Street = Utils.GetDBValue<string>(row, "street"),
                City = Utils.GetDBValue<string>(row, "city"),
                ZipCode = Utils.GetDBValue<string>(row, "zip_code"),
                MailCellNo = Utils.GetDBValue<string>(row, "mail_cell_no")
            };

            c.ShowData();

            c.Enter += C_Enter;
            c.Leave += C_Leave;
            c.RequestForUpdate += C_DoubleClick;
            c.OpenForm += C_OpenForm;
            c.ContactTabbedNext += C_ContactTabbedNext;
            c.ContactTabbedPrevious += C_ContactTabbedPrev;
            c.ContactSelectedMove += C_ContactSelectedMove;

            return c;
        }

        void C_ContactSelectedMove(object sender, ContactSelectedMoveEventArgs e)
        {
            var pos = flowPanel.Controls.IndexOf((Control)sender);
            switch (e.Direction)
            {
                case ContactSelectedMoveEventArgs.DirectionType.Right:
                case ContactSelectedMoveEventArgs.DirectionType.Up:
                    pos -= 1;
                    if (pos < 0) return;
                    break;
                case ContactSelectedMoveEventArgs.DirectionType.Left:
                case ContactSelectedMoveEventArgs.DirectionType.Down:
                    pos += 1;
                    if (pos >= flowPanel.Controls.Count) return;
                    break;

                default:
                    return;
            }

            var cn = (Contact)flowPanel.Controls[pos];
            C_Enter(cn, null);
            cn.Selected = true;
            flowPanel.ScrollControlIntoView(cn);
        }

        void C_ContactTabbedPrev(object sender, EventArgs e)
        {
            var pos = flowPanel.Controls.IndexOf((Control)sender);
            if (pos == 0) pos = flowPanel.Controls.Count;
            SelectContact(pos - 1);
        }

        void C_ContactTabbedNext(object sender, EventArgs e)
        {
            var pos = flowPanel.Controls.IndexOf((Control)sender);
            if (pos == flowPanel.Controls.Count - 1) pos = -1;
            SelectContact(pos + 1);
        }

        void C_OpenForm(object sender, OpenFormEventArgs e)
        {
            if (OpenForm != null)
            {
                OpenForm(sender, e);
            }
        }

        void C_DoubleClick(object sender, EventArgs e)
        {
            C_Enter(sender, e);
            ((Contact)sender).Selected = true;
            ToolStripButton4_Click(null, null);   
        }

        void C_Leave(object sender, EventArgs e)
        {
            if (this.ActiveControl is Contact)
            {
                ((Contact)sender).Selected = false;
            }
            else
            {
                _isDeselectContacts = true;
            }
        }

        void C_Enter(object sender, EventArgs e)
        {
            this.Select();
            DeselectContacts((Contact)sender);
            ((Contact)sender).Select();
        }

        void MnuPhone_RequestForCall(object sender, EventArgs e)
        {
            var c = GetCurrentContact();
            if(c == null) return;

            var phone = Utils.DistilPhone(((ToolStripItem)sender).Text);
            var name = c.FullName;
            if (DialRequest != null)
            {
                var arg = new DialRequestEventArgs(phone, name, c.Id) {Entity = 1};
                DialRequest(this, arg);
            }
        }

        private void DeselectContacts(Contact current)
        {
            if (!_isDeselectContacts && current != null) return;

            foreach (Contact c in flowPanel.Controls)
            {
                if (!c.Equals(current))
                {
                    c.Selected = false;
                }
            }

            _isDeselectContacts = false;
        }

        private void ShowContactByFirstLetter(string letter)
        {
            if (letter == "123")
            {
                foreach (Contact c in flowPanel.Controls)
                {
                    var lt = Convert.ToChar(Contact.LastNameBefore ? c.LastName.Substring(0, 1) : c.FirstName.Substring(0, 1));

                    if (lt < 'א' || lt > 'ת')
                    {
                        SelectContact(c);
                        break;
                    }
                }
            }
            else
            {
                foreach (Contact c in flowPanel.Controls)
                {
                    var lt = Convert.ToChar(Contact.LastNameBefore ? c.LastName.Substring(0, 1) : c.FirstName.Substring(0, 1));

                    if (lt == Convert.ToChar(letter))
                    {
                        SelectContact(c);
                        break;
                    }
                }
            }
        }

        private void PhoneBookButton1_Click(object sender, EventArgs e)
        {
            var butt = (PhonebookButton)sender;
            ShowContactByFirstLetter(butt.Caption);
        }

        private Contact GetCurrentContact()
        {
            foreach(var c in _contacts)
            {
                if(c.Selected) return c;
            }
            return null;
        }

        private void TbbDelete_Click(object sender, EventArgs e)
        {
            string msg1;
            const string msg2 = "מחיקת איש קשר...";

            var c = GetCurrentContact();

            if (c == null)
            {
                msg1 = "לא נבחר איש קשר לעדכון\nסמן תחילה את איש הקשר הרצוי ולחץ על ''מחק איש קשר''";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
                return;
            }

            msg1 = "האם אתה בטוח שברצונך למחוק את איש הקשר\n" + c.FullName;
            MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
            var res = MsgBox.Show(this);

            if (res == DialogResult.Yes)
            {
                PhoneBookHelper.DeleteContact(c.Id);
                msg1 = "איש הקשר נמחק בהצלחה";
                flowPanel.SuspendLayout();
                _contacts.Remove(c);
                flowPanel.Controls.Remove(c);
                flowPanel.ResumeLayout(true);
                MsgBox = new MyMessageBox(msg1, msg2);
                MsgBox.Show(this);
                this.Select();
            }
        }

        public void RemoveContact(PhoneBookContact contact)
        {
            Contact ct = null;
            foreach (Contact tmp in flowPanel.Controls)
            {
                if (contact.Id == tmp.Id)
                {
                    ct = tmp;
                    break;
                }
            }
            flowPanel.SuspendLayout();
            _contacts.Remove(ct);

            searchPanel1.ResetPanel();
            flowPanel.ResumeLayout(true);
        }

        private void FrmPhoneBook_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    if (this.ActiveControl is SearchPanel) return;
                    {
                        TbbDelete_Click(null, null);
                    }
                    break;

                case Keys.Escape:
                    if (GetCurrentContact() == null)
                    {
                        searchPanel1.Clear();
                    }
                    else
                    {
                        DeselectContacts(null);
                    }
                    break;
            }
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            if (OpenForm != null)
            {
                OpenForm(this, new OpenFormEventArgs("frmContactDetails"));
            }
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            var c = GetCurrentContact();

            const string msg2 = "עדכון פרטי איש קשר...";

            if (c == null)
            {
                const string msg1 = "לא נבחר איש קשר לעדכון\nסמן תחילה את איש הקשר הרצוי ולחץ על ''עדכן פרטים''";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
            }
            else
            {
                if (OpenForm != null)
                {
                    OpenForm(this, new OpenFormEventArgs("frmContactDetails", c.Id));
                }
            }
        }

        private void SearchPanel1_ClearClicked(object sender, EventArgs e)
        {
            DeselectContacts(null);
            ShowAllContacts();
            flowPanel.Select();
        }

        private void SearchPanel1_SearchClicked(object sender, EventArgs e)
        {
            var search = searchPanel1.SearchString;
            if (search.Length > 0) FilterContacts(search);
        }

        private void TbbPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            var parameters = new string[3];
            parameters[0] = "רשימת אנשי קשר";
            parameters[1] = searchPanel1.SearchString.Length > 0 ? "תוצאות חיפוש עבור: " + searchPanel1.SearchString : "כל אנשי הקשר";
            parameters[2] = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">";

            var i = 0;
            foreach (Contact c in flowPanel.Controls)
            {
                if (i % 3 == 0) parameters[2] += "<tr>";
                parameters[2] +="<td>" + c.GetPrintHtml() + "</td>";
                i++;
                if (i % 3 == 0) parameters[2] += "</tr>";
            }
            parameters[2] += "</table>";

            var printer = new HtmlPrinter("REPORT_FORM", parameters);
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
            var c = GetCurrentContact();

            string msg1;
            const string msg2 = "חיוג אל איש קשר...";

            if (c == null)
            {
                msg1 = "לא נבחר איש קשר לחיוג\nסמן תחילה את איש הקשר הרצוי ולחץ על ''חייג''";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
                return;
            }

            splitPhone.DropDownItems.Clear();
            if (c.PhoneNo1.Length > 0) splitPhone.DropDownItems.Add(Utils.DistilPhone(c.PhoneNo1), null, MnuPhone_RequestForCall);
            if (c.PhoneNo2.Length > 0) splitPhone.DropDownItems.Add(Utils.DistilPhone(c.PhoneNo2), null, MnuPhone_RequestForCall);
            if (c.PhoneNo3.Length > 0) splitPhone.DropDownItems.Add(Utils.DistilPhone(c.PhoneNo3), null, MnuPhone_RequestForCall);

            if (splitPhone.DropDownItems.Count == 0)
            {
                msg1 = "לאיש הקשר " + c.FullName + " אין מספרי טלפון";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
                return;
            }
            
            splitPhone.ShowDropDown();
        }

        private void TbbEmail_Click(object sender, EventArgs e)
        {
            const string msg2 = "שליחת דוא\"ל...";
            
            var c = GetCurrentContact();
            if (c == null)
            {
                const string msg1 = "לשליחת דוא\"ל לאיש קשר מהרשימה\nבחר תחילה את איש הקשר";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
                c = new Contact();
            }

            if (OpenForm != null)
            {
                this.Cursor = Cursors.WaitCursor;
                var table = General.GetEmailEntity(c.Id, General.EntityType.Contact);
                if(table != null) OpenForm(this, new OpenFormEventArgs("frmMailCampaign", table));
                this.Cursor = Cursors.Default;
            }
        }

        private void TbbSendSms_Click(object sender, EventArgs e)
        {
            const string msg2 = "שליחת SMS...";

            var c = GetCurrentContact();
            if (c == null)
            {
                const string msg1 = "לשליחת SMS לאיש קשר מהרשימה\nבחר תחילה את איש הקשר";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
                c = new Contact();
            }

            if (OpenForm != null)
            {
                this.Cursor = Cursors.WaitCursor;
                var table = General.GetSmsEntity(c.Id, General.EntityType.Contact);
                var list = General.TableToPostAddresseeList(table);
                if(table != null) OpenForm(this, new OpenFormEventArgs("frmSMS", list));
                this.Cursor = Cursors.Default;
            }
        }

        private void SelectContact(int index)
        {
            var c = (Contact)flowPanel.Controls[index];
            SelectContact(c);
        }
        private void SelectContact(Contact c)
        {
            c.Select();
            DeselectContacts(c);
            c.Selected = true;
            flowPanel.ScrollControlIntoView(c);
        }

        private void TbbPrev_Click(object sender, EventArgs e)
        {
            var c = GetCurrentContact();
            if (c == null && flowPanel.Controls.Count > 0)
            {
                SelectContact(0);
            }
            else
            {
                C_ContactTabbedPrev(c, null);
            }
        }

        private void TbbNext_Click(object sender, EventArgs e)
        {
            var c = GetCurrentContact();
            if (c == null && flowPanel.Controls.Count > 0)
            {
                SelectContact(0);
            }
            else
            {
                C_ContactTabbedNext(c, null);
            }
        }

        private void FrmPhoneBook_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(ActiveControl is SearchPanel))
            {
                if (e.KeyChar == Convert.ToChar(27) || e.KeyChar == '\r') { }
                else if (e.KeyChar == Convert.ToChar(8))
                {
                    if (!string.IsNullOrEmpty(searchPanel1.SearchString))
                    {
                        searchPanel1.Select();
                        searchPanel1.SearchString = searchPanel1.SearchString.Substring(0, searchPanel1.SearchString.Length - 1);
                    }
                }
                else
                {
                    searchPanel1.Select();
                    searchPanel1.SearchString += e.KeyChar.ToString();
                }
            }
        }
    }
}