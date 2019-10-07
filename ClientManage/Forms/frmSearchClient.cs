using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ClientManage.Library;
using ClientManage.Interfaces;
using ClientManage.BL;

namespace ClientManage.Forms
{
    public partial class FormSearchClient : BaseMdiChild
    {
        public event DlgShowClientCardEventHandler ShowClientCard;
        public event DialRequestEventHandler DialRequest;
        public event OpenFormEventHandler OpenForm;

        readonly DgvLoadImages _dgvLoadImages = new DgvLoadImages();
        private bool _isLastActive;
        private readonly SearchEngine _se = new SearchEngine(SearchEngine.SearchType.FullSearch);
        private readonly Color _selectColor = Color.FromArgb(247, 230, 164);
        private readonly Color _selectCursorColor = Color.FromArgb(225, 122, 0);
        private readonly string _status;

        public event OpenFormEventHandler HideForm;
        public event CalendarSetAppointmentEventHandler SetAppointment;
        public event EventHandler DeleteClient;

        public FormSearchClient()
        {
            InitializeComponent();
            _status = lblStatus.Text;
        }

        public override void SetElementsResolutionFactor()
        {
            General.SetGridColumnsWidthByResolutionFactor(grdClients);
        }

        public bool IsLastActive
        {
            get { return _isLastActive; }
            set { _isLastActive = value; }
        }

        public void Clear()
        {
            searchPanel1.Clear();
        }

        private void BindData(SearchItemCollection col)
        {
            try
            {
                grdClients.DataSource = col;
            }
            catch { Utils.CatchException(); }
// ReSharper disable PossibleNullReferenceException
            grdClients.Columns["clmSelect"].DisplayIndex = 0;
// ReSharper restore PossibleNullReferenceException
            SetCountLabel();
        }

        public void SelectClient(int id)
        {
            try
            {
                if (id > 0)
                {
                    foreach (DataGridViewRow row in grdClients.Rows)
                    {
                        if (row.DataGridView.Columns.Contains("clmId"))
                        {
                            if (id.Equals(row.Cells["clmId"].Value))
                            {
                                if (!row.Displayed)
                                {
                                    var index = row.Index == 0 ? 0 : row.Index - 1;
                                    try
                                    {
                                        if (!row.Displayed) grdClients.FirstDisplayedScrollingRowIndex = index;
                                    }
                                    catch { Utils.CatchException(); }
                                }
                                row.Selected = true;
                                break;
                            }
                        }
                    }
                }
            }
            catch { Utils.CatchException(); }
        }

        private void FrmSearchClient_Load(object sender, EventArgs e)
        {
            BindData(_se.FilterClientTable(string.Empty));
            grdClients.Select();
        }

        private void GrdClients_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _dgvLoadImages.BeginLoadImages(grdClients);
        }

        private void GrdClients_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(27) || e.KeyChar == '\r' ) {}
            else if(e.KeyChar == Convert.ToChar(8))
            {
                if (searchPanel1.SearchString.Length > 0)
                {
                    searchPanel1.SearchString = searchPanel1.SearchString.Substring(0, searchPanel1.SearchString.Length - 1);
                    searchPanel1.Select();
                }
            }
            else
            {
                if (char.IsLetterOrDigit(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSeparator(e.KeyChar))
                {
                    searchPanel1.SearchString += e.KeyChar.ToString();
                    searchPanel1.Select();
                }
            }
        }

        private void SearchPanel1_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdClients.Rows.Count == 0) return;
            int cur;

            if (e.KeyCode == Keys.Down)
            {
                cur = grdClients.SelectedRows[0].Index;
                if (cur == grdClients.Rows.Count - 1) return;
                grdClients.Rows[cur + 1].Selected = true;
                grdClients.CurrentCell = grdClients.Rows[cur + 1].Cells[1];
                grdClients.Select();
            }

            if (e.KeyCode == Keys.Up)
            {
                cur = grdClients.SelectedRows[0].Index;
                if (cur == 0) return;
                grdClients.Rows[cur - 1].Selected = true;
                grdClients.CurrentCell = grdClients.Rows[cur - 1].Cells[1];
                grdClients.Select();
            }
        }

        private void SearchPanel1_SearchClicked(object sender, EventArgs e)
        {
            var pattern = searchPanel1.SearchString;
            var filterCol = _se.FilterClientTable(pattern);
            BindData(filterCol);

            searchPanel1.IsFilter = true;
            grdClients.Select();
        }

        private void SearchPanel1_ClearClicked(object sender, EventArgs e)
        {
            var id = GetSelectedClientId();
            BindData(_se.FilterClientTable(string.Empty));
            SelectClient(id);
            grdClients.Select();
        }

        private void TbbFind_Click(object sender, EventArgs e)
        {
            _isLastActive = false;
            DoShowClientCard();
        }

        public void ActivateMe()
        {
            grdClients.Select();
            RefreshGrid();
            _dgvLoadImages.BeginLoadImages(grdClients);
            _isLastActive = true;
        }

        private void RefreshGrid()
        {
            if (ClientHelper.IsClientCacheHasChanges)
            {
                ClientHelper.ClientCacheAcceptChanges();
                if (searchPanel1.SearchString.Length > 0)
                {
                    SearchPanel1_SearchClicked(null, null);
                }
                else
                {
                    SearchPanel1_ClearClicked(null, null);
                }
            }
        }

        private void GrdClients_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex > 0) DoShowClientCard();
        }

        private void DoShowClientCard()
        {
            var selectedId = GetSelectedClientId();
            if (selectedId > 0)
            {
                if (ShowClientCard != null) ShowClientCard(this, new ShowClientCardEventArgs(selectedId));
            }
        }

        private void GrdClients_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.Handled = true;
                    DoShowClientCard();
                    break;

                case Keys.Escape:
                    searchPanel1.Clear();
                    break;

                case Keys.Delete:
                    TbbDelete_Click(null, null);
                    break;

                //case Keys.Space:
                //    if(grdClients.CurrentCell != null && grdClients.CurrentCell.ColumnIndex > 0)
                //    {
                //        grdClients_CellContentClick(grdClients, new DataGridViewCellEventArgs(0, grdClients.CurrentCell.RowIndex));
                //    }
                //    break;

                case Keys.Tab:
                    searchPanel1.Select();
                    e.Handled = true;
                    break;

                case Keys.Home:
                    if (grdClients.Rows.Count > 1)
                    {
                        grdClients.FirstDisplayedScrollingRowIndex = 0;
                        grdClients.Rows[0].Selected = true;
                        grdClients.CurrentCell = grdClients.Rows[0].Cells[1];
                        e.Handled = true;
                    }
                    break;

                case Keys.End:
                    var cnt = grdClients.Rows.Count;
                    if (cnt > 1)
                    {
                        grdClients.FirstDisplayedScrollingRowIndex = cnt - 1;
                        grdClients.Rows[cnt - 1].Selected = true;
                        grdClients.CurrentCell = grdClients.Rows[cnt - 1].Cells[1];
                        e.Handled = true;
                    }
                    break;
            }
        }

        private void TbbAddNew_Click(object sender, EventArgs e)
        {
            if (HideForm != null)
            {
                _isLastActive = false;
                    HideForm(this, new OpenFormEventArgs("frmSearchClient", 0, "NewClient"));
            }
        }

        private void TbbUpdate_Click(object sender, EventArgs e)
        {
            if (HideForm != null)
            {
                var selectedId = GetSelectedClientId();
                if (selectedId > 0)
                {
                    _isLastActive = false;
                    HideForm(this, new OpenFormEventArgs("frmSearchClient", selectedId, "EditClient"));
                }
            }
        }

        private void TbbMakeApp_Click(object sender, EventArgs e)
        {
            var id = GetSelectedClientId();
            if (id > 0)
            {
                if (SetAppointment != null) SetAppointment(this, new SetAppointmentEventArgs(id));
            }
        }

        public int GetSelectedClientId()
        {
            var row = -1;
            var selectedId = -1;

            if (grdClients.SelectedRows.Count > 0) row = grdClients.SelectedRows[0].Index;
            if (row >= 0)
            {
                selectedId = Convert.ToInt32(grdClients.Rows[row].Cells["clmId"].Value);
            }
            return selectedId;
        }

        public string GetSelectedClientName()
        {
            var row = -1;
            var name = string.Empty;

            if (grdClients.SelectedRows.Count > 0) row = grdClients.SelectedRows[0].Index;
            if (row >= 0)
            {
                name = Convert.ToString(grdClients.Rows[row].Cells["clmName"].Value);
            }
            return name;
        }

        private void TbbDelete_Click(object sender, EventArgs e)
        {
            var row = -1;
            string name;

            if (grdClients.SelectedRows.Count > 0) row = grdClients.SelectedRows[0].Index;
            if (row >= 0)
            {
                name = Convert.ToString(grdClients.Rows[row].Cells["clmName"].Value);
            }
            else return;

            var msg1 = "האם אתה בטוח שברצונך למחוק את הלקוח:\n" + name + "\n\nשים לב: כל המידע לגבי התורים ורישומי השיחות של הלקוח ימחק";
            const string msg3 = "מחיקת לקוח...";

            MsgBox = new MyMessageBox(msg1, msg3, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
            var res = MsgBox.Show(this);

            if (res == DialogResult.Yes)
            {
                if (DeleteClient != null)
                {
                    DeleteClient(this, new EventArgs());
                    RefreshGrid();
                    if (ClientHelper.CachedClientsTable.Rows.Count == 0) TbbAddNew_Click(null, null);
                }
            }
        }

        private void SplitPhone_ButtonClick(object sender, EventArgs e)
        {
            splitPhone.ShowDropDown();
        }

        private void SplitPhone_DropDownOpening(object sender, EventArgs e)
        {
            // bulid phone toolStrip items
            splitPhone.DropDownItems.Clear();
            mnuCall.DropDownItems.Clear();

            var row = -1;
            string phones;

            if (grdClients.SelectedRows.Count > 0) row = grdClients.SelectedRows[0].Index;
            if (row >= 0)
            {
                phones = Convert.ToString(ClientHelper.GetAllPhones(GetSelectedClientId()));
            }
            else return;

            var arrPhones = phones.Split(' ');
            string temp;

            foreach (var p in arrPhones)
            {
                temp = Utils.DistilPhone(p.Trim());
                if (temp.Length > 0)
                {
                    splitPhone.DropDownItems.Add(temp, null, SplitPhoneItem_ButtonClick);
                    mnuCall.DropDownItems.Add(temp, null, SplitPhoneItem_ButtonClick);
                }
            }
        }

        private void SplitPhoneItem_ButtonClick(object sender, EventArgs e)
        {
            if (DialRequest != null)
            {
                var phone = Utils.DistilPhone(((ToolStripDropDownItem)(sender)).Text);
                var name = GetSelectedClientName();
                var id = GetSelectedClientId();
                var arg = new DialRequestEventArgs(phone, name, id) {Entity = 0};
                DialRequest(this, arg);
            }
        }

        private void TbbPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            // create html table
            var imgCol = new HtmlImageColumnsCollection
                         {
                             new HtmlImageColumnMapper(HtmlImageColumnMapper.HtmlMapType.ByColumnRef, "clmImage",
                                                       "clmPicture")
                         };
            var htmlTable = HtmlPrinter.ConvertDataGridToHtml(grdClients, imgCol, lblStatus.Visible);

            // create report parameters
            var parameters =  new string[3];
            parameters[0] = "חיפוש לקוחות";
            parameters[1] = "תוצאות חיפוש עבור: " + (searchPanel1.SearchString.Length == 0 ? "כל הלקוחות" : searchPanel1.SearchString);
            parameters[2] = htmlTable;

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

        private void TbbEmail_Click(object sender, EventArgs e)
        {
            if (OpenForm == null) return;
            this.Cursor = Cursors.WaitCursor;

            var table = lblStatus.Visible ? 
                        ReportHelper.GetClientsEmails(GetSelectedIds()) : 
                        General.GetEmailEntity(GetSelectedClientId(), General.EntityType.Client);

            if (table != null) OpenForm(this, new OpenFormEventArgs("frmMailCampaign", table));

            this.Cursor = Cursors.Default;
        }

        private void TbbSendSms_Click(object sender, EventArgs e)
        {
            if (OpenForm == null) return;
            DataTable table;
            this.Cursor = Cursors.WaitCursor;

            if (lblStatus.Visible)
            {
                table = ReportHelper.GetClientsCellPhones(GetSelectedIds());
            }
            else
            {
                var clientId = GetSelectedClientId();
                table = General.GetSmsEntity(clientId, General.EntityType.Client);
            }

            var list = General.TableToPostAddresseeList(table);
            if (table != null) OpenForm(this, new OpenFormEventArgs("frmSMS", list));

            this.Cursor = Cursors.Default;
        }

        public void OpenClientCard()
        {
            if(tbbFind.Enabled) TbbFind_Click(null, null);
        }

        private void GrdClients_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            _dgvLoadImages.BeginLoadImages(grdClients);
        }

        private void TbbPhotoAlbum_Click(object sender, EventArgs e)
        {
            if(OpenForm != null) OpenForm(this, new OpenFormEventArgs("frmPhotoAlbum", GetSelectedClientId()));
        }

        private void TbbStickers_Click(object sender, EventArgs e)
        {
            DataTable table;
            if (OpenForm == null) return;
            this.Cursor = Cursors.WaitCursor;

            if (lblStatus.Visible)
            {
                table = ReportHelper.GetClientsAddresses(GetSelectedIds());
            }
            else
            {
                var id = GetSelectedClientId();
                table = General.GetStickerEntity(id, General.EntityType.Client);
            }
             
            if (table != null) OpenForm(this, new OpenFormEventArgs("frmStickers", table));

            this.Cursor = Cursors.Default;
        }

        private void TbbPrev_Click(object sender, EventArgs e)
        {
            var rowId = -1;

            if (grdClients.SelectedRows.Count > 0) rowId = grdClients.SelectedRows[0].Index;
            if (rowId >= grdClients.Rows.Count - 1) rowId = -1;
            
            rowId++;
            grdClients.Rows[rowId].Selected = true;
            if (!grdClients.Rows[rowId].Displayed) grdClients.FirstDisplayedScrollingRowIndex = rowId;
        }

        private void TbbNext_Click(object sender, EventArgs e)
        {
            var rowId = grdClients.Rows.Count;

            if (grdClients.SelectedRows.Count > 0) rowId = grdClients.SelectedRows[0].Index;
            if (rowId <= 0) rowId = grdClients.Rows.Count;

            rowId--;
            grdClients.Rows[rowId].Selected = true;
            if (!grdClients.Rows[rowId].Displayed) grdClients.FirstDisplayedScrollingRowIndex = rowId;
        }

        private void GrdClients_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // *** ON ERROR - DO NOTHING!!! Dont delete this event ***
        }

        private void GrdClients_MouseDown(object sender, MouseEventArgs e)
        {
            var info = grdClients.HitTest(e.X, e.Y);
            if (e.Button == MouseButtons.Right)
            {
                grdClients.Rows[info.RowIndex].Selected = true;
                SplitPhone_DropDownOpening(null, null);
                ctxMenu.Show(grdClients, e.X, e.Y);
            }
        }

        private void MnuCall_Click(object sender, EventArgs e)
        {

        }

        private void MnuCard_Click(object sender, EventArgs e)
        {
            TbbFind_Click(null, null);
        }

        private void MnuNew_Click(object sender, EventArgs e)
        {
            TbbAddNew_Click(null, null);
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

        private void FrmSearchClient_KeyDown(object sender, KeyEventArgs e)
        {
            var ctrl = e.Control && !e.Alt && !e.Shift;

            switch (e.KeyCode)
            {
                case Keys.N:
                    if (ctrl) TbbAddNew_Click(null, null);
                    break;

                case Keys.E:
                    if (ctrl) TbbUpdate_Click(null, null);
                    break;

                case Keys.P:
                    if (ctrl) TbbPrint_Click(null, null);
                    break;

            }
        }

        private void GrdClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var value = Convert.ToBoolean(grdClients[e.ColumnIndex, e.RowIndex].Value);
                grdClients[e.ColumnIndex, e.RowIndex].Value = !value;

                grdClients.Rows[e.RowIndex].DefaultCellStyle.BackColor = value ? Color.White : _selectColor;
                grdClients.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = value ? Color.FromKnownColor(KnownColor.Highlight) : _selectCursorColor;
                SetCountLabel();
            }
        }

        private void SetCountLabel()
        {
            var cnt = GetSelectedCount();
            SetCountLabel(cnt);
        }

        private void SetCountLabel(int count)
        {
            lblStatus.Visible = (count > 0);
            btnClearSelect.Visible = lblStatus.Visible;
            lblStatus.Text = string.Format(_status, count);
        }

        private int GetSelectedCount()
        {
            var cnt = 0;
            try
            {
                for (var i = 0; i < grdClients.Rows.Count; i++)
                {
                    if (true.Equals(grdClients[0, i].Value)) cnt++;
                }
            }
            catch
            {
                cnt = 0;
            }  
            return cnt;
        }

        private string GetSelectedIds()
        {
            var ids = string.Empty;

            for (var i = 0; i < grdClients.Rows.Count; i++)
            {
                if (true.Equals(grdClients[0, i].Value))
                {
                    ids += grdClients["clmId", i].Value + ",";
                }
            }
            if (ids.EndsWith(",")) ids = ids.Substring(0, ids.Length - 1);
            return ids;
        }

        private void BtnClearSelect_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < grdClients.Rows.Count; i++)
            {
                grdClients[0, i].Value = false;
                grdClients.Rows[i].DefaultCellStyle.BackColor = Color.White;
                grdClients.Rows[i].DefaultCellStyle.SelectionBackColor = Color.FromKnownColor(KnownColor.Highlight);
                SetCountLabel(0);
            }
        }

        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < grdClients.Rows.Count; i++)
            {
                grdClients[0, i].Value = true;
                grdClients.Rows[i].DefaultCellStyle.BackColor = _selectColor;
                SetCountLabel(grdClients.Rows.Count);
            }
        }

        public void RefreshForm()
        {
            BindData(_se.FilterClientTable(string.Empty));
            grdClients.Select();
        }

        private void TbbSub_Click(object sender, EventArgs e)
        {
            var id = GetSelectedClientId();
            if (id > 0)
            {
                var c = ClientHelper.GetClient(id);
                if (OpenForm != null) OpenForm(this, new OpenFormEventArgs("frmSubscription", c));
            }
        }
    }
}
