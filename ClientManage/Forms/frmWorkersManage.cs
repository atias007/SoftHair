using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ClientManage.BL;
using ClientManage.Interfaces;
using ClientManage.Library;
using ClientManage.BL.Library;

namespace ClientManage.Forms
{
    public partial class FormWorkersManage : BaseMdiChild
    {
        private readonly DgvLoadImages _imageLoader = new DgvLoadImages();

        //private readonly DgvLoadImages _imageLoaderTraffic = new DgvLoadImages();
        private readonly DgvLoadImages _imageLoaderWorkers = new DgvLoadImages();

        private readonly string _soundfile = AppSettingsHelper.GetParamValue("TRAFFIC_SOUND_FILE");

        private string _workerName = string.Empty;
        private bool _isEnter = true;
        private bool _inLoadProc;
        private DateTime _lastStartDateSelected = DateTime.MinValue;
        private DateTime _lastEndDateSelected = DateTime.MinValue;
        private FormClientQuickSearch _fClientQuickSearch;

        public static bool NeedToSetLeave;

        public event EventHandler WorkerDeleted;

        public event DialRequestEventHandler DialRequest;

        public event OpenFormEventHandler OpenForm;

        public event EventHandler SelectWorkerTab;

        public FormWorkersManage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the elements resolution factor.
        /// </summary>
        public override void SetElementsResolutionFactor()
        {
            General.SetGridColumnsWidthByResolutionFactor(grdManageWorkers);
            //General.SetGridColumnsWidthByResolutionFactor(grdWorkers);
            General.SetGridColumnsWidthByResolutionFactor(grdTraffic);
        }

        /// <summary>
        /// Refreshes the grids.
        /// </summary>
        public void RefreshGrids()
        {
            RefreshGrids(false);
        }

        /// <summary>
        /// Refreshes the grids.
        /// </summary>
        /// <param name="withoutManageGrid">if set to <c>true</c> [without manage grid].</param>
        public void RefreshGrids(bool withoutManageGrid)
        {
            var wId = GetSelectedRowIndex(grdWorkers);
            var tId = GetSelectedRowIndex(grdTraffic);
            var mId = withoutManageGrid ? 0 : GetSelectedRowIndex(grdManageWorkers);

            grdWorkers.DataSource = WorkersHelper.GetWorkersNameForTraffic().Tables[0];

            if (withoutManageGrid == false && grdManageWorkers.DataSource != null)
            {
                RefreshManageWorkersGrid();
            }
            RefreshTrafficGrid();

            SelectDataGridRow(grdWorkers, wId);
            SelectDataGridRow(grdTraffic, tId);
            if (withoutManageGrid == false) SelectDataGridRow(grdManageWorkers, mId);
        }

        /// <summary>
        /// Refreshes the manage workers grid.
        /// </summary>
        private void RefreshManageWorkersGrid()
        {
            grdManageWorkers.DataSource = WorkersHelper.GetWorkersToManage(LogOnPermission != PermissionMember.StandardUser);
        }

        private void FrmWorkersManageLoad(object sender, EventArgs e)
        {
            grdWorkers.DataSource = WorkersHelper.GetWorkersNameForTraffic().Tables[0];
            _imageLoader.DefaultImage = Properties.Resources.worker_small;
            //_imageLoaderTraffic.DefaultImage = Properties.Resources.worker_small;
            _imageLoaderWorkers.DefaultImage = Properties.Resources.worker_small;
            //_imageLoaderTraffic.ImageColumn += "2";
            //_imageLoaderTraffic.PicturePathColumn += "2";
            _imageLoaderWorkers.ImageColumn += "3";
            _imageLoaderWorkers.PicturePathColumn += "3";
            SetDate();

            if (NeedToSetLeave) SetLeaveMode();
            else SetEnterMode();

            dtPicker.SelectionStart = DateTime.Now;
            DoLogOut();
            RefreshManageWorkersGrid();

            _imageLoader.BeginLoadImages(grdWorkers);
            grdManageWorkers.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8);
            toolStrip1.Visible = true;
            toolStrip2.Visible = true;
        }

        public void SetDate()
        {
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy  dddd");
            const string title = "החודש ({0})";
            tbbMonthTraffic.Text = string.Format(title, DateTime.Now.Month);
        }

        public void SetEnterMode()
        {
            BtnEnterClick(null, null);
        }

        public void SetLeaveMode()
        {
            BtnLeaveClick(null, null);
        }

        private void FrmWorkersManageEnter(object sender, EventArgs e)
        {
            _imageLoader.BeginLoadImages(grdWorkers);
            TabControl1SelectedIndexChanged(null, null);
        }

        public void SelectWorker(int id)
        {
            if (id >= 0)
            {
                foreach (DataGridViewRow row in grdManageWorkers.Rows)
                {
                    if (row.Cells["w_clmId"].Value.Equals(id))
                    {
                        if (!row.Displayed)
                        {
                            grdManageWorkers.FirstDisplayedScrollingRowIndex = row.Index;
                        }
                        row.Selected = true;
                        break;
                    }
                }
            }
        }

        private static int GetSelectedWorkerId(DataGridView grid, string column)
        {
            var row = -1;
            var selectedId = -1;

            if (grid.SelectedRows.Count > 0) row = grid.SelectedRows[0].Index;
            if (row >= 0)
            {
                selectedId = Convert.ToInt32(grid.Rows[row].Cells[column].Value);
            }
            return selectedId;
        }

        private static int GetSelectedRowIndex(DataGridView grid)
        {
            var row = -1;
            if (grid.SelectedRows.Count > 0) row = grid.SelectedRows[0].Index;
            return row;
        }

        private static void SelectDataGridRow(DataGridView grid, int index)
        {
            if (index < 0) return;
            var cnt = grid.Rows.Count;
            if (cnt == 0) return;
            if (index >= cnt) index = cnt - 1;
            grid.Rows[index].Selected = true;
        }

        private void SelectWorkerInTraffic(int id)
        {
            foreach (DataGridViewRow row in grdWorkers.Rows)
            {
                var workerId = Convert.ToInt32(row.Cells["clmId"].Value);
                if (workerId == id)
                {
                    row.Selected = true;
                    break;
                }
            }
        }

        public string GetSelectedWorkerName(DataGridView grid, string column)
        {
            var row = -1;
            var ret = string.Empty;

            if (grid.SelectedRows.Count > 0) row = grid.SelectedRows[0].Index;
            if (row >= 0)
            {
                ret = Utils.GetDBValue<string>(grid.Rows[row].Cells[column].Value);
            }
            return ret;
        }

        public string GetSelectedPassword()
        {
            var row = -1;
            var ret = string.Empty;

            if (grdWorkers.SelectedRows.Count > 0) row = grdWorkers.SelectedRows[0].Index;
            if (row >= 0)
            {
                ret = Convert.ToString(grdWorkers.Rows[row].Cells["clmPassword"].Value);
            }
            return ret;
        }

        private void BtnEnterClick(object sender, EventArgs e)
        {
            _isEnter = true;
            lblButtonReport2.Caption = "דווח כניסה";
            btnEnter.ForeColor = Color.Maroon;
            btnLeave.ForeColor = Color.DimGray;
            btnEnter.SetState(true);
            btnLeave.SetState(false);
            NeedToSetLeave = false;
        }

        private void BtnLeaveClick(object sender, EventArgs e)
        {
            _isEnter = false;
            lblButtonReport2.Caption = "דווח יציאה";
            btnLeave.ForeColor = Color.Maroon;
            btnEnter.ForeColor = Color.DimGray;
            btnLeave.SetState(true);
            btnEnter.SetState(false);
            NeedToSetLeave = false;
        }

        private void DtPickerDateChanged(object sender, DateRangeEventArgs e)
        {
            try
            {
                if (!(e.Start.Date.Equals(_lastStartDateSelected) && e.End.Date.Equals(_lastEndDateSelected)))
                {
                    RefreshTrafficGrid(e.Start.Date, e.End.Date);
                    tslDatesLabel.Text = e.Start.ToString("dd/MM/yyyy");
                    if (!e.Start.Date.Equals(e.End.Date))
                    {
                        const string title = "מ-{0} עד-{1}";
                        tslDatesLabel.Text = string.Format(title, tslDatesLabel.Text, e.End.ToString("dd/MM/yyyy"));
                    }
                }
            }
            catch (Exception ex)
            {
                EventLogManager.AddErrorMessage("Error when refresh traffic grid (date changed)", ex);
            }
        }

        private void RefreshTrafficGrid()
        {
            RefreshTrafficGrid(_lastStartDateSelected, _lastEndDateSelected);
        }

        private void RefreshTrafficGrid(DateTime startDate, DateTime endDate)
        {
            grdTraffic.DataSource = WorkersHelper.GetTrafficByDate(startDate, endDate);

            _lastStartDateSelected = dtPicker.SelectionStart;
            _lastEndDateSelected = dtPicker.SelectionEnd;
            // _imageLoaderTraffic.BeginLoadImages(grdTraffic);
        }

        private void GrdTrafficDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            const string msg1 = "דיווח כניסה/יציאה...";
            const string msg2 = "שעת הכניסה/יציאה שהוזנה אינה חוקית\nלחץ Esc לביטול העדכון";
            MsgBox = new MyMessageBox(msg2, msg1, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
            MsgBox.Show(this);
            e.Cancel = true;
        }

        private void TpageTrafficPaint(object sender, PaintEventArgs e)
        {
            var c = Color.FromArgb(127, 157, 185);
            e.Graphics.DrawRectangle(new Pen(c), dtPicker.Left - 1, dtPicker.Top - 1, dtPicker.Width + 2, dtPicker.Height + 2);
        }

        private void GrdTrafficCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            grdTraffic.Rows[e.RowIndex].ErrorText = string.Empty;
            var traffic = new WorkerTraffic
            {
                Id = (int)grdTraffic.Rows[e.RowIndex].Cells["t_clmId"].Value,
                EnterDate =
                                      Utils.GetDBValue<DateTime>(grdTraffic.Rows[e.RowIndex].Cells["clmEnterDate"].Value),
                LeaveDate =
                                      Utils.GetDBValue<DateTime>(grdTraffic.Rows[e.RowIndex].Cells["clmLeaveDate"].Value),
                Remark =
                                      Utils.GetDBValue<string>(grdTraffic.Rows[e.RowIndex].Cells["clmRemark"].Value)
            };
            traffic.SetSameEnterLeaveDate((DateTime)grdTraffic.Rows[e.RowIndex].Cells["clmDateCreate"].Value);
            var feed = WorkerTraffic.TrafficFeed.Admin;

            if (traffic.EnterDate.Equals(DateTime.MinValue) && traffic.LeaveDate.Equals(DateTime.MinValue))
            {
                DeleteCurrentTrafficRow();
                return;
            }

            if (grdTraffic.Columns[e.ColumnIndex].Name == "clmEnterDate")
            {
                if (traffic.EnterDate == DateTime.MinValue)
                {
                    traffic.EnterFeed = WorkerTraffic.TrafficFeed.None;
                    feed = traffic.EnterFeed;
                }
                else
                { traffic.EnterFeed = WorkerTraffic.TrafficFeed.Admin; }
                traffic.LeaveFeed = ((WorkerTraffic.TrafficFeed)Convert.ToInt32(grdTraffic.Rows[e.RowIndex].Cells["clmLeaveFeedValue"].Value));
            }
            else if (grdTraffic.Columns[e.ColumnIndex].Name == "clmLeaveDate")
            {
                if (traffic.LeaveDate == DateTime.MinValue)
                {
                    traffic.LeaveFeed = WorkerTraffic.TrafficFeed.None;
                    feed = traffic.LeaveFeed;
                }
                else
                { traffic.LeaveFeed = WorkerTraffic.TrafficFeed.Admin; }
                traffic.EnterFeed = ((WorkerTraffic.TrafficFeed)Convert.ToInt32(grdTraffic.Rows[e.RowIndex].Cells["clmEnterFeedValue"].Value));
            }
            else
            {
                traffic.LeaveFeed = ((WorkerTraffic.TrafficFeed)Convert.ToInt32(grdTraffic.Rows[e.RowIndex].Cells["clmLeaveFeedValue"].Value));
                traffic.EnterFeed = ((WorkerTraffic.TrafficFeed)Convert.ToInt32(grdTraffic.Rows[e.RowIndex].Cells["clmEnterFeedValue"].Value));
            }

            var isOk = WorkersHelper.UpdateTraffic(traffic);
            if (!isOk)
            {
                const string title = "שגיאה בניהול עובדים...";
                const string head = "עדכון דיווח נוכחות";
                const string desc = "עדכון דיווח הנוכחות נכשל\nשים לב שהפרטים שעדכנת בטופס לא נשמרו";
                General.ShowErrorMessageDialog(this, title, head, desc, null, "frmWorkerManage");
                RefreshTrafficGrid();
            }
            else
            {
                if (grdTraffic.Columns[e.ColumnIndex].Name == "clmEnterDate" || grdTraffic.Columns[e.ColumnIndex].Name == "clmLeaveDate")
                {
                    grdTraffic[e.ColumnIndex + 1, e.RowIndex].Value = feed;
                }
            }
        }

        private void GrdTrafficUserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var msg1 = "האם אתה בטוח שברצונך להסיר את דיווח הנוכחות של:\n" + Utils.GetDBValue<string>(e.Row.Cells["clmWorkerName"].Value);
            const string msg2 = "מחיקת דיווח נוכחות...";
            MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
            var res = MsgBox.Show(this);

            if (res == DialogResult.Yes)
            {
                var isOk = WorkersHelper.DeleteTraffic((int)e.Row.Cells["t_clmId"].Value);
                if (!isOk)
                {
                    e.Cancel = true;

                    const string title = "שגיאה בניהול עובדים...";
                    const string head = "מחיקת דיווח נוכחות";
                    const string desc = "מחיקת דיווח הנוכחות נכשל\nשים לב כי הדיווח לא נמחק והוא עדיין קיים במאגר הנתונים";
                    General.ShowErrorMessageDialog(this, title, head, desc, null, "frmWorkerManage");
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void GrdTrafficCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var name = grdTraffic.Columns[e.ColumnIndex].Name;
            int index;
            WorkerTraffic.TrafficFeed feed;

            switch (name)
            {
                case "clmEnterDate":
                    // ReSharper disable PossibleNullReferenceException
                    index = grdTraffic.Columns["clmEnterFeedValue"].Index;
                    // ReSharper restore PossibleNullReferenceException
                    feed = (WorkerTraffic.TrafficFeed)Convert.ToInt32(grdTraffic[index, e.RowIndex].Value);
                    if (feed == WorkerTraffic.TrafficFeed.Admin)
                    {
                        e.CellStyle.ForeColor = Color.Brown;
                        grdTraffic.Rows[e.RowIndex].Tag = "1";
                    }
                    break;

                case "clmLeaveDate":
                    // ReSharper disable PossibleNullReferenceException
                    index = grdTraffic.Columns["clmLeaveFeedValue"].Index;
                    // ReSharper restore PossibleNullReferenceException
                    feed = (WorkerTraffic.TrafficFeed)Convert.ToInt32(grdTraffic[index, e.RowIndex].Value);
                    if (feed == WorkerTraffic.TrafficFeed.Admin)
                    {
                        e.CellStyle.ForeColor = Color.Brown;
                        grdTraffic.Rows[e.RowIndex].Tag = "1";
                    }
                    break;

                case "clmLeaveFeedValue":
                    var isAdmin = ("1".Equals(grdTraffic.Rows[e.RowIndex].Tag));
                    if (isAdmin)
                    {
                        e.Value = "*";
                        e.CellStyle.ForeColor = Color.Brown;
                    }
                    else
                    {
                        e.Value = string.Empty;
                        e.CellStyle.ForeColor = Color.Black;
                    }
                    e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
                    break;
            }
        }

        private void GrdTrafficCellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!(grdTraffic.Columns[e.ColumnIndex].Name == "clmEnterDate" || grdTraffic.Columns[e.ColumnIndex].Name == "clmLeaveDate")) return;

            // ReSharper disable PossibleNullReferenceException
            var iFrom = grdTraffic.Columns["clmEnterDate"].Index;
            var iTo = grdTraffic.Columns["clmLeaveDate"].Index;
            var iDate = grdTraffic.Columns["clmDateCreate"].Index;
            // ReSharper restore PossibleNullReferenceException
            var val = e.FormattedValue.ToString();
            if (val.Trim().Length == 0) return;

            DateTime dFrom, dTo;
            var curDate = Utils.GetDBValue<DateTime>(grdTraffic[iDate, e.RowIndex].Value);
            try
            {
                if (grdTraffic.Columns[e.ColumnIndex].Name == "clmEnterDate")
                {
                    if (DBNull.Value.Equals(grdTraffic[iTo, e.RowIndex].Value)) return;

                    dTo = DateTime.Parse(curDate.ToString("dd/MM/yyyy") + " " + ((DateTime)grdTraffic[iTo, e.RowIndex].Value).ToShortTimeString());
                    dFrom = DateTime.Parse(curDate.ToString("dd/MM/yyyy") + " " + val);
                }
                else if (grdTraffic.Columns[e.ColumnIndex].Name == "clmLeaveDate")
                {
                    if (DBNull.Value.Equals(grdTraffic[iFrom, e.RowIndex].Value)) return;
                    dFrom = DateTime.Parse(curDate.ToString("dd/MM/yyyy") + " " + ((DateTime)grdTraffic[iFrom, e.RowIndex].Value).ToShortTimeString());
                    dTo = DateTime.Parse(curDate.ToString("dd/MM/yyyy") + " " + val);
                }
                else
                {
                    return;
                }
            }
            catch { return; }

            if (dTo < dFrom)
            {
                const string msg1 = "שעת הכניסה מאוחרת או שווה לשעת היציאה";
                const string msg2 = "עדכון דיווח נוכחות...";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
                e.Cancel = true;
                grdTraffic.Rows[e.RowIndex].ErrorText = msg1;
            }
        }

        private void FClientQuickSearchClientSelected(object sender, EventArgs e)
        {
            var traffic = new WorkerTraffic
            {
                WorkerId = FormClientQuickSearch.SelectedClientId,
                CreateDate =
                                      DateTime.Parse(dtPicker.SelectionStart.ToString("dd/MM/yyyy") + " " +
                                                     DateTime.Now.ToShortTimeString())
            };

            var isOk = WorkersHelper.SetEnterTraffic(traffic);
            if (isOk)
            {
                RefreshTrafficGrid();
                // ReSharper disable PossibleNullReferenceException
                var index = grdTraffic.Columns["clmEnterDate"].Index;
                // ReSharper restore PossibleNullReferenceException
                grdTraffic.Select();
                grdTraffic.CurrentCell = grdTraffic[index, 0];
                //grdTraffic.BeginEdit(true);
                SendKeys.Send("{F2}");
            }
            else
            {
                const string title = "שגיאה בניהול עובדים...";
                const string head = "הוספת דיווח נוכחות";
                const string desc = "הוספת דיווח הנוכחות נכשל\nשים לב שהפרטים שעדכנת בטופס לא נשמרו";
                General.ShowErrorMessageDialog(this, title, head, desc, null, "frmWorkerManage");
            }
        }

        private void DoLogOut()
        {
            LogOnPermission = PermissionMember.StandardUser;
            var index = tabControl1.SelectedIndex;
            tabControl1.Visible = false;
            tabControl1.TabPages.Remove(tpageTraffic);
            if (!tabControl1.TabPages.Contains(tpageAdmin)) tabControl1.TabPages.Add(tpageAdmin);
            tabControl1.SelectedIndex = index;
            tabControl1.Visible = true;
            txtPass.Enabled = true;
            txtPass.BackColor = Color.White;
            tbbLogin.Enabled = true;
            tbbLogout.Enabled = false;
            tbbAddUser.Enabled = false;
            tbbEditUser.Enabled = false;
            tbbDeleteUser.Enabled = false;
        }

        private void TabControl1SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                //_imageLoaderTraffic.BeginLoadImages(grdTraffic);
            }
            else if (tabControl1.SelectedIndex == 0)
            {
                _imageLoaderWorkers.BeginLoadImages(grdManageWorkers);
            }
        }

        private void GrdWorkersColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _imageLoader.BeginLoadImages(grdWorkers);
        }

        private void GrdTrafficColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //_imageLoaderTraffic.BeginLoadImages(grdTraffic);
        }

        private void TbbCallButtonClick(object sender, EventArgs e)
        {
            tbbCall.ShowDropDown();
        }

        private void TbbCallDropDownOpening(object sender, EventArgs e)
        {
            // bulid phone toolStrip items
            tbbCall.DropDownItems.Clear();

            var row = -1;
            string phone;

            if (grdManageWorkers.SelectedRows.Count > 0) row = grdManageWorkers.SelectedRows[0].Index;
            if (row >= 0)
            {
                phone = Utils.GetDBValue<string>(grdManageWorkers.Rows[row].Cells["clm_phone_no_1"].Value);
                phone = Utils.DistilPhone(phone);
                if (phone.Length > 0) tbbCall.DropDownItems.Add(phone, null, SplitPhoneItemButtonClick);

                phone = Utils.GetDBValue<string>(grdManageWorkers.Rows[row].Cells["clm_phone_no_3"].Value);
                phone = Utils.DistilPhone(phone);
                if (phone.Length > 0) tbbCall.DropDownItems.Add(phone, null, SplitPhoneItemButtonClick);

                phone = Utils.GetDBValue<string>(grdManageWorkers.Rows[row].Cells["clm_phone_no_2"].Value);
                phone = Utils.DistilPhone(phone);
                if (phone.Length > 0) tbbCall.DropDownItems.Add(phone, null, SplitPhoneItemButtonClick);
            }
            else return;
        }

        private void SplitPhoneItemButtonClick(object sender, EventArgs e)
        {
            var phone = Utils.DistilPhone(((ToolStripDropDownItem)(sender)).Text);
            var name = GetSelectedWorkerName(grdManageWorkers, "clm_full_name");
            var id = GetSelectedWorkerId(grdManageWorkers, "w_clmId");

            if (DialRequest != null)
            {
                var arg = new DialRequestEventArgs(phone, name, id) { Entity = 2 };
                DialRequest(this, arg);
            }
        }

        private void TbbDeleteUserClick(object sender, EventArgs e)
        {
            grdManageWorkers.Select();
            SendKeys.Send("{DELETE}");
        }

        private void GrdManageWorkersUserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var id = Utils.GetDBValue<int>(e.Row.Cells["w_clmId"].Value);
            var worker = WorkersHelper.GetWorker(Utils.GetDBValue<int>(e.Row.Cells["w_clmId"].Value));
            if (worker == null) { e.Cancel = true; return; }

            var msg1 = "האם אתה בטוח שברצונך למחוק את העובד: " + worker.FullName + "\n\nשים לב: כל התורים המקושרים לעובד זה לא יהיו מקושרים לאף עובד\nוכל רישומי הנוכחות של העובד ימחקו אף הם";
            var msg2 = "מחיקת עובד...";
            MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
            var res = MsgBox.Show(this);

            if (res == DialogResult.Yes)
            {
                if (WorkersHelper.IsWorkerLastAdmin(worker.Id))
                {
                    msg1 = "העובד " + worker.FullName + " הנו מנהל המערכת היחיד\nולא ניתן למחוק אותו מהמערכת";
                    msg2 = "עדכון פרטי עובד...";
                    MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                    MsgBox.Show(this);
                    e.Cancel = true;
                    return;
                }

                this.Cursor = Cursors.WaitCursor;
                var isOk = WorkersHelper.DeleteWorker(id);
                this.Cursor = Cursors.Default;

                if (isOk)
                {
                    if (WorkerDeleted != null) WorkerDeleted(this, new EventArgs());
                    _workerName = worker.FullName;
                    e.Cancel = false;
                }
                else
                {
                    const string title = "שגיאה בניהול עובדים...";
                    var head = "מחיקת העובד " + worker.FullName;
                    var desc = "מחיקת העובד " + worker.FullName + " נכשלה\nשים לב שהעובד עדיין קיים במאגר הנתונים.\nמומלץ להפוך את העובד ללא פעיל ולא למחוק אותו";
                    General.ShowErrorMessageDialog(this, title, head, desc, null, "frmWorkerManage");
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void GrdManageWorkersUserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            RefreshGrids(true);
            var msg1 = "העובד " + _workerName + " נמחק בהצלחה";
            const string msg2 = "מחיקת עובד...";
            _workerName = string.Empty;
            MsgBox = new MyMessageBox(msg1, msg2);
            MsgBox.Show(this);
        }

        private void TbbAddUserClick(object sender, EventArgs e)
        {
            if (OpenForm != null) OpenForm(this, new OpenFormEventArgs("frmWorkerDetails"));
        }

        private void TbbEditUserClick(object sender, EventArgs e)
        {
            if (OpenForm != null)
            {
                var id = GetSelectedWorkerId(grdManageWorkers, "w_clmId");
                OpenForm(this, new OpenFormEventArgs("frmWorkerDetails", id));
            }
        }

        private void GrdManageWorkersColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _imageLoaderWorkers.BeginLoadImages(grdManageWorkers);
        }

        private void GrdManageWorkersCellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (tbbEditUser.Enabled) TbbEditUserClick(null, null);
        }

        private void LblButtonReport2Click(object sender, EventArgs e)
        {
            grdWorkers.Select();
            var id = GetSelectedWorkerId(grdWorkers, "clmId");
            if (id == -1)
            {
                const string msg1 = "לא נמצאו עובדים לדיווח נוכחות";
                const string msg2 = "דיווח נוכחות...";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
                return;
            }

            var workerName = GetSelectedWorkerName(grdWorkers, "clmName");

            var msg = workerName + "\nעל מנת לאמת את זהותך (לצורך דיווח " + (_isEnter ? "כניסה" : "יציאה") + ")\nאנא הזן/י את סיסמך...";
            var fPassword = new FormPassword(GetSelectedPassword(), msg);
            var res = fPassword.ShowDialog(this);
            if (res != DialogResult.OK) return;

            Application.DoEvents();
            CreateWorkerTraffic(id);
        }

        private void CreateWorkerTraffic(int workerId)
        {
            string t1;
            string t2;
            bool isOk;

            var traffic = new WorkerTraffic { WorkerId = workerId, Remark = string.Empty };

            if (_isEnter)
            {
                t1 = "הכניסה";
                t2 = DateTime.Now.ToShortTimeString();
                traffic.EnterDate = DateTime.Now;
                traffic.EnterFeed = WorkerTraffic.TrafficFeed.Manual;
                traffic.CreateDate = DateTime.Now.Date;
                isOk = WorkersHelper.SetEnterTraffic(traffic);
            }
            else
            {
                t1 = "היציאה";
                t2 = DateTime.Now.ToShortTimeString();
                traffic.LeaveDate = DateTime.Now;
                traffic.LeaveFeed = WorkerTraffic.TrafficFeed.Manual;
                traffic.CreateDate = DateTime.Now.Date;
                isOk = WorkersHelper.SetLeaveTraffic(traffic);
            }

            var workerName = GetSelectedWorkerName(grdWorkers, "clmName");

            if (isOk)
            {
                if (LogOnPermission != PermissionMember.StandardUser) RefreshTrafficGrid();
                Utils.PlayWavFile(_soundfile);
                var box = new MyMessageBox
                {
                    Text = "דיווח " + t1 + " נקלט בהצלחה" + "\nשם העובד: " + workerName + "\nשעת דיווח: " + t2,
                    Caption = "דווח כניסת/יציאת עובדים...",
                    MessageFont = new Font("Arial", 18f, FontStyle.Bold),
                    MessageType = MyMessageBox.MyMessageType.Confirm,
                    CloseInterval = 3000
                };
                box.Show(this);
            }
            else
            {
                const string title = "שגיאה בניהול עובדים...";
                const string head = "דווח כניסה/יציאה של עובד ";
                var desc = "דווח כניסה/יציאה של העובד " + workerName + " נכשל ולא נקלט במערכת";
                General.ShowErrorMessageDialog(this, title, head, desc, null, "frmWorkerManage");
            }
        }

        private void TbbLoginClick(object sender, EventArgs e)
        {
            var isAdmin = WorkersHelper.IsAdminPassword(txtPass.Text) ||
                txtPass.Text == AppSettingsHelper.GetParamValue("APP_MASTER_PASSWORD");
            var isSuper = Utils.IsSuperUserPassword(txtPass.Text, AppSettingsHelper.GetParamValue("APP_SUPER_USER_PASS"));

            if (isAdmin || isSuper)
            {
                LogOnPermission = isSuper ? PermissionMember.SuperUser : PermissionMember.Admin;

                tabControl1.Visible = false;
                var index = tabControl1.SelectedIndex;
                tabControl1.TabPages.Add(tpageTraffic);
                tabControl1.TabPages.Remove(tpageAdmin);
                tabControl1.SelectedIndex = index;
                tabControl1.Visible = true;
                txtPass.Text = string.Empty;
                tbbLogout.Enabled = true;
                tbbLogin.Enabled = false;
                tbbAddUser.Enabled = true;
                tbbEditUser.Enabled = true;
                tbbDeleteUser.Enabled = true;
                txtPass.Enabled = false;
                txtPass.BackColor = Color.WhiteSmoke;
                RefreshTrafficGrid();
                RefreshManageWorkersGrid();
            }
            else
            {
                txtPass.Text = string.Empty;
                txtPass.Select();
                const string msg1 = "סיסמת מנהל שגוייה";
                const string msg2 = "סיסמת מנהל";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Error, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
            }
        }

        private void TbbLogoutClick(object sender, EventArgs e)
        {
            DoLogOut();
            RefreshManageWorkersGrid();

            txtPass.Select();
        }

        private void TxtPassEnter(object sender, EventArgs e)
        {
            base.TextBoxEnter((TextBox)sender);
        }

        private void TxtPassLeave(object sender, EventArgs e)
        {
            base.TextBoxLeave((TextBox)sender);
        }

        private void TxtPassKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TbbLoginClick(null, null);
            }
        }

        private void TbbRemoveTrafficClick(object sender, EventArgs e)
        {
            grdTraffic.Select();
            SendKeys.Send("{DELETE}");
        }

        private void TbbAddTrafficClick(object sender, EventArgs e)
        {
            if (!dtPicker.SelectionStart.Date.Equals(dtPicker.SelectionEnd.Date))
            {
                const string msg1 = "לא ניתן להוסיף דיווח כאשר בתאריכון נבחר טווח תאריכים\nאנא בחר בתאריך בודד ולחץ על הוסף דיווח";
                const string msg2 = "הוספת דיווח...";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
            }
            else
            {
                var rect = toolStrip2.RectangleToScreen(toolStrip2.DisplayRectangle);

                if (_fClientQuickSearch == null || _fClientQuickSearch.IsDisposed)
                {
                    this.Cursor = Cursors.WaitCursor;
                    _fClientQuickSearch = new FormClientQuickSearch(true) { VisibleItems = 6 };
                    _fClientQuickSearch.Left = rect.Right - _fClientQuickSearch.Width + 10;
                    _fClientQuickSearch.Top = rect.Top - _fClientQuickSearch.Height;// -1;
                    _fClientQuickSearch.ClientSelected += FClientQuickSearchClientSelected;
                    _fClientQuickSearch.Show();
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    _fClientQuickSearch.Left = rect.Left;
                    _fClientQuickSearch.Top = rect.Top - _fClientQuickSearch.Height - 1;
                }
                _fClientQuickSearch.Select();
            }
        }

        private void TbbWeekTrafficClick(object sender, EventArgs e)
        {
            var f = Utils.GetFirstDayOfWeekDate();
            dtPicker.SelectionStart = f;
            dtPicker.SelectionEnd = dtPicker.SelectionStart.AddDays(6);
        }

        private void TbbTodayTrafficClick(object sender, EventArgs e)
        {
            dtPicker.SelectionStart = DateTime.Now;
            dtPicker.SelectionEnd = DateTime.Now;
        }

        private void TbbMonthTrafficButtonClick(object sender, EventArgs e)
        {
            var from = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var to = from.AddMonths(1).AddDays(-1);

            dtPicker.SelectionStart = from;
            dtPicker.SelectionEnd = to;
        }

        private void MnuAnyMonthClick(object sender, EventArgs e)
        {
            var month = Convert.ToInt32(((ToolStripMenuItem)sender).Tag);
            var from = new DateTime(_lastStartDateSelected.Year, month, 1);
            var to = from.AddMonths(1).AddDays(-1);

            dtPicker.SelectionStart = from;
            dtPicker.SelectionEnd = to;
        }

        private void DeleteCurrentTrafficRow()
        {
            // ReSharper disable PossibleNullReferenceException
            var isOk = WorkersHelper.DeleteTraffic((int)grdTraffic.CurrentRow.Cells["t_clmId"].Value);
            // ReSharper restore PossibleNullReferenceException
            if (isOk) grdTraffic.Rows.Remove(grdTraffic.CurrentRow);
        }

        private void TbbPrintTrafficClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            // create html table
            var imgCol = new HtmlImageColumnsCollection
                             {
                                 new HtmlImageColumnMapper(HtmlImageColumnMapper.HtmlMapType.ByColumnRef, "clmImage2",
                                                           "clmPicture2")
                             };
            var htmlTable = HtmlPrinter.ConvertDataGridToHtml(grdTraffic, imgCol);

            // create report parameters
            var parameters = new string[3];
            parameters[0] = "דיווח נוכחות עובדים";
            parameters[1] = tslDatesLabel.Text;
            parameters[2] = htmlTable;

            if (parameters[1].Contains("עד"))
            {
                parameters[1] = parameters[1].Replace("מ-", "מתאריך: ").Replace("עד-", " ועד תאריך:");
            }
            else
            {
                parameters[1] = "לתאריך: " + parameters[1];
            }

            if (cmbWorkers.SelectedIndex == 0) parameters[1] = "כל העובדים, " + parameters[1];
            else parameters[1] = "לעובד: " + cmbWorkers.Text + ", " + parameters[1];

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

        private void GrdManageWorkersCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var name = grdManageWorkers.Columns[e.ColumnIndex].Name;
            if (name == "clmActiveImage")
            {
                // ReSharper disable PossibleNullReferenceException
                var index = grdManageWorkers.Columns["clm_is_active"].Index;
                // ReSharper restore PossibleNullReferenceException
                var value = (bool)grdManageWorkers[index, e.RowIndex].Value;
                e.Value = (value ? Properties.Resources.ok : Properties.Resources.cancel_small);
            }
        }

        private void GrdManageWorkersCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            // ReSharper disable PossibleNullReferenceException
            if (e.ColumnIndex == grdManageWorkers.Columns["clm_email"].Index)
            // ReSharper restore PossibleNullReferenceException
            {
                var val = Convert.ToString(grdManageWorkers.CurrentCell.Value);
                if (val.Length > 0)
                {
                    // ReSharper disable PossibleNullReferenceException
                    var name = grdManageWorkers[grdManageWorkers.Columns["clm_full_name"].Index, e.RowIndex].Value.ToString();
                    // ReSharper restore PossibleNullReferenceException

                    if (OpenForm != null)
                    {
                        this.Cursor = Cursors.WaitCursor;

                        var table = new DataTable();
                        table.Columns.Add("full_name", typeof(string));
                        table.Columns.Add("email", typeof(string));

                        table.Rows.Add(name, val);

                        OpenForm(this, new OpenFormEventArgs("frmMailCampaign", table));

                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        public void LogOffAdmin()
        {
            DoLogOut();
            RefreshManageWorkersGrid();
        }

        public void CancelEditGrid()
        {
            grdTraffic.CancelEdit();
        }

        private void GrdTrafficDataSourceChanged(object sender, EventArgs e)
        {
            _inLoadProc = true;
            var table = (DataTable)grdTraffic.DataSource;
            if (table == null) return;

            cmbWorkers.Items.Clear();
            cmbWorkers.Items.Add("< כל העובדים >");

            foreach (DataGridViewRow row in grdTraffic.Rows)
            {
                var curr = Utils.GetDBValue<string>(row.Cells["clmWorkerName"].Value);
                if (cmbWorkers.FindString(curr) == -1)
                {
                    cmbWorkers.Items.Add(curr);
                }
            }

            cmbWorkers.SelectedIndex = 0;
            _inLoadProc = false;
        }

        private void CmbWorkersSelectedIndexChanged(object sender, EventArgs e)
        {
            if (_inLoadProc) return;
            var table = (DataTable)grdTraffic.DataSource;
            if (cmbWorkers.SelectedIndex == 0)
            {
                table.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                table.DefaultView.RowFilter = "full_name = '" + cmbWorkers.Text + "'";
            }
            //_imageLoaderTraffic.BeginLoadImages(grdTraffic);
            grdTraffic.Select();
        }

        private void TbbSendSmsClick(object sender, EventArgs e)
        {
            if (OpenForm != null)
            {
                this.Cursor = Cursors.WaitCursor;
                var id = GetSelectedWorkerId(grdManageWorkers, "w_clmId");
                var table = General.GetSmsEntity(id, General.EntityType.Worker);
                var list = General.TableToPostAddresseeList(table);
                if (table != null) OpenForm(this, new OpenFormEventArgs("frmSMS", list));
                this.Cursor = Cursors.Default;
            }
        }

        private void TbbSendMailClick(object sender, EventArgs e)
        {
            if (OpenForm != null)
            {
                this.Cursor = Cursors.WaitCursor;
                var id = GetSelectedWorkerId(grdManageWorkers, "w_clmId");
                var table = General.GetEmailEntity(id, General.EntityType.Worker);
                OpenForm(this, new OpenFormEventArgs("frmMailCampaign", table));
                this.Cursor = Cursors.Default;
            }
        }

        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            // create html table
            var imgCol = new HtmlImageColumnsCollection
                             {
                                 new HtmlImageColumnMapper(HtmlImageColumnMapper.HtmlMapType.ByColumnRef, "clmImage3",
                                                           "clmPicture3")
                             };
            var map = new HtmlImageColumnMapper(HtmlImageColumnMapper.HtmlMapType.ByImageValue, "clmActiveImage")
            { Layout = DataGridViewImageCellLayout.Normal };
            imgCol.Add(map);
            var htmlTable = HtmlPrinter.ConvertDataGridToHtml(grdManageWorkers, imgCol);

            // create report parameters
            var parameters = new string[3];
            parameters[0] = "רשימת עובדים";
            parameters[1] = tbbLogin.Enabled ? "כל העובדים הפעילים במערכת" : "כל העובדים במערכת (פעיל / לא פעיל)";
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

        private void GrdWorkersDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            _imageLoader.BeginLoadImages(grdWorkers);
        }

        private void GrdTrafficDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //_imageLoaderTraffic.BeginLoadImages(grdTraffic);
        }

        private void GrdManageWorkersDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            _imageLoaderWorkers.BeginLoadImages(grdManageWorkers);
        }

        private void GrdWorkersDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // *** ON ERROR - DO NOTHING!!! Dont delete this event ***
        }

        private void GrdManageWorkersDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // *** ON ERROR - DO NOTHING!!! Dont delete this event ***
        }

        public void ProcessCard(string value)
        {
            var cardId = value.Substring(General.ClientCardPattern.FromIndex, General.ClientCardPattern.Length);
            var id = WorkersHelper.GetWorkerIdByCardId(cardId);

            if (id > 0)
            {
                if (SelectWorkerTab != null)
                {
                    SelectWorkerTab(this, EventArgs.Empty);
                }

                SelectWorkerInTraffic(id);
                CreateWorkerTraffic(id);
            }
        }

        private void FormWorkersManage_SizeChanged(object sender, EventArgs e)
        {
            const double w1 = 175.0 / 367;
            const double w2 = 100.0 / 367;
            const double w3 = 375.0 / 1004;

            groupBox1.Height = (this.Height - toolStrip1.Height) / 2;
            if (groupBox1.Height > 300) groupBox1.Height = 300;
            pnlRight.Width = Convert.ToInt32(groupBox1.Width * w3);
            pnlLock.Left = (this.Width - pnlLock.Width) / 2;
            // ReSharper disable PossibleNullReferenceException
            grdWorkers.Columns["clmName"].Width = Convert.ToInt32(grdWorkers.Width * w1);
            grdWorkers.Columns["clmIdNumber"].Width = Convert.ToInt32(grdWorkers.Width * w2);
            // ReSharper restore PossibleNullReferenceException
        }
    }
}