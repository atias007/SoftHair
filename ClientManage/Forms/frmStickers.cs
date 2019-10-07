using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClientManage.BL;
using ClientManage.Interfaces;
using ClientManage.Library;
using ClientManage.BL.Library;
using System.Collections;
using ClientManage.Interfaces.Schemas;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using ClientManage.Forms.OptionForms;

namespace ClientManage.Forms
{
    public partial class FormStickers : BasePopupForm
    {
        private readonly ArrayList _clients = new ArrayList();
        private FormClientQuickSearch fClientQuickSearch = null;
        private int _activeUsers = 0;
        private const string TOTAL_CLIENTS = "סה\"כ {0} נמענים";
        private bool _refreshList = false;

        public FormStickers(DataTable clients)
        {
            InitializeComponent();

            RefreshClients(clients);
        }

        public int TotalClients
        {
            get { return lstClients.Items.Count; }
        }

        public void RefreshClients(DataTable clients)
        {
            _clients.Clear();
            if (clients != null)
            {
                foreach (DataRow row in clients.Rows)
                {
                    _clients.Add(GetStickerFromRow(row));
                }
            }
            RefreshClients();
        }

        private StickerClient GetStickerFromRow(DataRow row)
        {
            var stick = new StickerClient();
            stick.FullName = Utils.GetDBValue<string>(row, "full_name");
            stick.Address = Utils.GetDBValue<string>(row, "address");
            stick.City = Utils.GetDBValue<string>(row, "city");
            stick.ZipCode = Utils.GetDBValue<string>(row, "zipcode");

            return stick;
        }

        public void AddPerson(DataRow row)
        {
            _clients.Add(GetStickerFromRow(row));
            RefreshClients();
        }

        public void AddPersonsRange(DataTable persons)
        {
            foreach (DataRow p in persons.Rows)
            {
                if (!IsExist(p)) _clients.Add(GetStickerFromRow(p));
            }
            RefreshClients();
        }

        public bool IsExist(DataRow person)
        {
            foreach (StickerClient s in _clients)
            {
                if (s.FullName.Equals(person["full_name"]) && s.Address.Equals(person["address"])
                    && s.City.Equals(person["city"]) && s.ZipCode.Equals(person["zipcode"])) return true;
            }
            return false;
        }

        private bool ValidateForm()
        {
            var msg1 = string.Empty;
            var msg2 = "הדפסת מדבקות";

            if (_activeUsers == 0)
            {
                msg1 = "לא נמצאו נמענים עם כתובת תקינה ברשימה\nאנא מלא לפחות נמען אחד";
                MyMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MyMessageBox.Show(this);
                return false;
            }

            return true;
        }

        private void RefreshClients()
        {
            ListViewItem item;
            SuspendLayout();
            lstClients.Items.Clear();
            _activeUsers = 0;

            foreach (StickerClient stick in _clients)
            {
                item = new ListViewItem();

                if (stick.IsEmpty) continue;
                if (IsItemExist(stick)) continue;
                item.Text = stick.FullName;

                if (stick.IsEmpty)
                {
                    item.ImageIndex = 2;
                }
                else
                {
                    if (stick.IsValid)
                    {
                        item.ImageIndex = 0;
                        _activeUsers++;
                    }
                    else
                    {
                        item.ImageIndex = 1;
                    }
                }

                item.SubItems.Add(stick.ToString());
                item.SubItems.Add(stick.FullName);
                item.Tag = stick;
                lstClients.Items.Add(item);
            }

            lblTotalClients.Text = string.Format(TOTAL_CLIENTS, _activeUsers.ToString());
            ResumeLayout(false);
        }

        private bool IsItemExist(StickerClient stick)
        {
            foreach (ListViewItem item in lstClients.Items)
            {
                if (stick.Equals(item.Tag)) return true;
            }

            return false;
        }

        private void pnlPersons_Paint(object sender, PaintEventArgs e)
        {
            var c = Color.FromArgb(107, 137, 165);
            var rec = new Rectangle(0, 0, pnlPersons.Width - 1, pnlPersons.Height - 1);
            e.Graphics.DrawRectangle(new Pen(c), rec);
        }

        private void label8_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(127, 157, 185)), 0, 0, label8.Width - 1, label8.Height - 1);
        }

        private void PrintStickers()
        {
            try
            {
                PrintStickersReport();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                var captopn = "הדפסת מדבקות...";
                var msg = "תהליך הדפסת המדבקות נכשל\n" + ex.Message;
                MyMessageBox = new MyMessageBox(msg, captopn, MyMessageBox.MyMessageType.Error, MyMessageBox.MyMessageButton.Ok);
                MyMessageBox.Show(this);
            }
        }

        private void PrintStickersReport()
        {
            this.Cursor = Cursors.WaitCursor;

            var ds = new dsStickers();
            var stickers = GetAllStickers();
            var pattern = "לכבוד: {0}\n{1}\n{2} {3}";
            string value;

            foreach (var s in stickers)
            {
                value = string.Format(pattern, s.FullName, s.Address, s.City, s.ZipCode);
                ds.Addresses.AddAddressesRow(value);
            }

            var dataSource = new ReportDataSource("dsStickers_Addresses", ds.Addresses as DataTable);

            using (var printer = new LocalReportPrinter())
            {
                var report = new LocalReport();
                var setting = AppSettingsHelper.GetParamValue<string>("STICKERS_PRINT_SETUP");
                var generator = new StickersReportGenerator(setting);

                var ps = new PrinterSettings();
                ps.PrinterName = generator.PrinterName;
                if (!ps.IsValid) throw new ArgumentException("המדפסת " + ps.PrinterName + " לא נמצאה");
                var margins = FormOptStickers.GetPrinterMinimumMargins(ps);

                generator.LeftMargin -= margins.Left;
                generator.RightMargin -= margins.Right;
                generator.TopMargin -= margins.Top;
                generator.BottomMargin -= margins.Bottom;

                if (generator.LeftMargin < 0) generator.LeftMargin = 0;
                if (generator.RightMargin < 0) generator.RightMargin = 0;
                if (generator.TopMargin < 0) generator.TopMargin = 0;
                if (generator.BottomMargin < 0) generator.BottomMargin = 0;

                report.DataSources.Clear();
                report.LoadReportDefinition(generator.GetReportDefinition());
                report.DataSources.Add(dataSource);

                printer.Print(report, ps);
            }

            this.Cursor = Cursors.Default;
            this.Close();
        }

        private StickerClient[] GetAllStickers()
        {
            var list = new ArrayList();
            foreach (ListViewItem item in lstClients.Items)
            {
                if (item.ImageIndex == 0)
                {
                    if (item.Tag is StickerClient) list.Add(item.Tag);
                }
            }

            var stikers = new StickerClient[list.Count];
            list.CopyTo(stikers);
            return stikers;
        }

        private void TextBox_Focus(object sender, EventArgs e)
        {
            base.TextBoxEnter((TextBox)sender);
        }

        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            base.TextBoxLeave((TextBox)sender);
        }

        private void frmStickers_Activated(object sender, EventArgs e)
        {
            if (_refreshList) return;
            _refreshList = true;
            if (lstClients.Items.Count > 0) lstClients.Items[0].Selected = true;
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            var msg = string.Empty;
            var stick = new StickerClient();
            stick.FullName = txtPersonName.Text.Trim();
            stick.Address = txtAdress.Text.Trim();
            stick.City = txtCity.Text.Trim();
            stick.ZipCode = txtZipCode.Text.Trim();

            if (stick.FullName.Length < 2)
            {
                txtPersonName.BackColor = Validation.ErrorColor;
                msg += "אנא הזן לפחות 2 תווים בשם הנמען\n";
            }

            if (stick.Address.Length + stick.City.Length == 0)
            {
                txtAdress.BackColor = Validation.ErrorColor;
                txtCity.BackColor = Validation.ErrorColor;
                msg += "אנא הזן רחוב ו/או עיר\n";
            }

            if (!Validation.IsZipCodeValid(stick.ZipCode))
            {
                txtZipCode.BackColor = Validation.ErrorColor;
                msg += "המיקוד שהוזן אינו חוקי\n";
            }

            if (msg.Length > 0)
            {
                var msg1 = "הוספת נמען...";
                MyMessageBox = new MyMessageBox(msg, msg1, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MyMessageBox.Show(this);
                return;
            }

            ListViewItem item;
            if (pnlPersons.Tag.ToString() == "New")
            {
                item = new ListViewItem(stick.FullName);
                _activeUsers++;
            }
            else
            {
                item = lstClients.SelectedItems[0];
                if (item.ImageIndex > 0) _activeUsers++;
            }

            item.ImageIndex = 0;

            if (pnlPersons.Tag.ToString() == "New")
            {
                item.SubItems.Add(stick.ToString());
                item.SubItems.Add(stick.FullName);
                item.Tag = stick;
                lstClients.Items.Add(item);
                item.Selected = true;
                lstClients.Select();
                item.EnsureVisible();
            }
            else
            {
                item.Text = stick.ToString();
                item.SubItems[1].Text = stick.ToString();
                item.SubItems[2].Text = stick.FullName; ;
                item.Tag = stick;
            }

            lblTotalClients.Text = string.Format(TOTAL_CLIENTS, _activeUsers.ToString());
            btnCancelPerson_Click(null, null);
        }

        private void btnCancelPerson_Click(object sender, EventArgs e)
        {
            SuspendLayout();

            lstClients.Height = 354;
            lstClients.Top = 80;
            pnlPersons.Visible = false;
            txtAdress.Text = string.Empty;
            txtPersonName.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtZipCode.Text = string.Empty;
            txtPersonName.BackColor = Color.White;
            txtAdress.BackColor = Color.White;
            txtCity.BackColor = Color.White;
            txtZipCode.BackColor = Color.White;

            ResumeLayout(true);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (ValidateForm()) PrintStickersReport();
        }

        private void tbbPrint_Click(object sender, EventArgs e)
        {
            if (ValidateForm()) PrintStickersReport();
        }

        private void tbbRefresh_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            RefreshClients();
            if (lstClients.Items.Count > 0) lstClients.Items[0].Selected = true;
            this.Cursor = Cursors.Default;
        }

        private void tbbAddUser_Click(object sender, EventArgs e)
        {
            SuspendLayout();

            if (pnlPersons.Visible) btnCancelPerson_Click(null, null);

            lstClients.Height = 208;
            lstClients.Top = 226;
            pnlPersons.Visible = true;
            pnlPersons.Tag = "New";
            lblPersonText.Text = "הוספת נמען חדש...";
            btnAddPerson.Text = "הוסף";
            txtPersonName.Enabled = true;
            txtPersonName.Left = txtAdress.Left + btnBrowse.Width;
            txtPersonName.Width = txtAdress.Width - btnBrowse.Width;
            btnBrowse.Visible = true;
            txtPersonName.Select();
            TextBox_Focus(txtPersonName, null);
            ResumeLayout(true);
        }

        private void tbbEditUser_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count == 0) return;

            SuspendLayout();
            lstClients.Height = 184;
            lstClients.Top = 226;
            pnlPersons.Visible = true;
            pnlPersons.Tag = "Edit";
            lblPersonText.Text = "עדכון נמען קיים...";
            btnAddPerson.Text = "עדכן";
            txtPersonName.Left = txtAdress.Left;
            txtPersonName.Width = txtAdress.Width;
            btnBrowse.Visible = false;

            var stick = (StickerClient)lstClients.SelectedItems[0].Tag;
            txtAdress.Text = stick.Address;
            txtCity.Text = stick.City;
            txtPersonName.Text = stick.FullName;
            txtZipCode.Text = stick.ZipCode;

            txtPersonName.Select();
            TextBox_Focus(txtPersonName, null);
            ResumeLayout(true);
        }

        private void tbbDeleteUser_Click(object sender, EventArgs e)
        {
            if (pnlPersons.Visible) btnCancelPerson_Click(null, null);

            if (lstClients.SelectedItems.Count > 0)
            {
                var index = -1;
                var item = lstClients.SelectedItems[0];
                var msg1 = "האם אתה בטוח שברצונך להסיר את הנמען:\n\"" + item.Text + "\" מהרשימה";
                var msg2 = "הסרת מנמען מהרשימה...";
                MyMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
                var res = MyMessageBox.Show(this);

                if (res == DialogResult.Yes)
                {
                    if (item.ImageIndex == 0)
                    {
                        _activeUsers--;
                        lblTotalClients.Text = string.Format(TOTAL_CLIENTS, _activeUsers.ToString());
                    }
                    index = item.Index;
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

        private void tbbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstClients_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tbbEditUser_Click(null, null);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var rect = btnBrowse.RectangleToScreen(btnBrowse.DisplayRectangle);

            if (fClientQuickSearch == null || fClientQuickSearch.IsDisposed)
            {
                this.Cursor = Cursors.WaitCursor;
                fClientQuickSearch = new FormClientQuickSearch();
                fClientQuickSearch.VisibleItems = 6;
                fClientQuickSearch.Left = rect.Left;
                fClientQuickSearch.Top = rect.Bottom;
                fClientQuickSearch.ClientSelected += new EventHandler(fClientQuickSearch_ClientSelected);
                fClientQuickSearch.Show();
                this.Cursor = Cursors.Default;
            }
            else
            {
                fClientQuickSearch.Left = rect.Left;
                fClientQuickSearch.Top = rect.Bottom;
            }
            fClientQuickSearch.Select();
        }

        private void fClientQuickSearch_ClientSelected(object sender, EventArgs e)
        {
            var c = ClientHelper.GetClient(FormClientQuickSearch.SelectedClientId);
            if (c != null)
            {
                txtPersonName.Text = c.FullName;
                txtAdress.Text = c.Address;
                txtCity.Text = c.City;
                txtZipCode.Text = c.ZipCode;
            }
        }

        private void frmStickers_RequestForClose(object sender, EventArgs e)
        {
            tbbClose_Click(null, null);
        }
    }
}