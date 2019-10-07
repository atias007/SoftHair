using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ClientManage.Interfaces;
using ClientManage.BL;
using ClientManage.Library;

namespace ClientManage.Forms
{
    public partial class FormSubscription : BasePopupForm
    {
        public enum FormStatus { View, Edit };
        public event EventHandler RefreshClientBullets;

        private readonly Client _client;
        private readonly string _usageCount;
        private int _lastFilter = -1;
        private bool _loadProc;
        private FormStatus _status = FormStatus.View;
        private readonly Color _colorTodayUsage = Color.FromArgb(197, 240, 158);

        public FormSubscription(Client client)
        {
            InitializeComponent();
            _client = client;
            _usageCount = lblUsageCount.Text;
            informationBar1.PanelText = string.Format(informationBar1.PanelText, client.FullName);
            SubscriberHelper.SetAllStatus();
            ClearUsageLabel();
            LoadSubscribers();
// ReSharper disable PossibleNullReferenceException
            grdSubscription.Columns["c_button"].DefaultCellStyle.NullValue = null;
// ReSharper restore PossibleNullReferenceException
        }

        public FormStatus Status
        {
            get { return _status; }
        }

        private int SelectedSubId
        {
            get
            {
                var id = -1;
                if (grdSubscription.SelectedRows.Count > 0)
                {
                    id = (int)grdSubscription.SelectedRows[0].Cells["c_id"].Value;
                }
                return id;
            }
        }

        private int SelectedStatus
        {
            get
            {
                var status = -1;
                if (grdSubscription.SelectedRows.Count > 0)
                {
                    status = (int)grdSubscription.SelectedRows[0].Cells["c_status_id"].Value;
                }
                return status;
            }
        }

        private string SelectedName
        {
            get
            {
                var name = string.Empty;
                if (grdSubscription.SelectedRows.Count > 0)
                {
                    name = (string)grdSubscription.SelectedRows[0].Cells["c_name"].Value;
                }
                return name;
            }
        }

        private void LoadUsageGrid()
        {
            SaveUsageGrid();
            grdUsage.DataSource = SubscriberHelper.GetSubscriberUsages(SelectedSubId);
            grdUsage.DataMember = "SubscriberUsages";
            lblUsageCount.Text = string.Format(_usageCount, grdUsage.Rows.Count);
        }

        private void SaveUsageGrid()
        {
            var ds = (DataSet)grdUsage.DataSource;
            SubscriberHelper.SaveSubscriberUsages(ds);
        }

        private void ClearUsageLabel()
        {
            lblUsageCount.Text = string.Format(_usageCount, 0);
        }

        private void LoadSubscribers()
        {
            _loadProc = true;
            var table = SubscriberHelper.GetSubscriptionList(_client.Id);
            grdSubscription.Rows.Clear();
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    var index = grdSubscription.Rows.Add();
                    foreach (DataGridViewColumn col in grdSubscription.Columns)
                    {
                        if (!string.IsNullOrEmpty(col.DataPropertyName))
                        {
                            grdSubscription[col.Index, index].Value = row[col.DataPropertyName];
                        }
                    }
                }
                _lastFilter = -1;
                FilterSubscribers();
                _loadProc = false;

                GrdSubscription_SelectionChanged(null, null);
            }
            else
            {
                LoadUsageGrid();
            }
        }

        private void ReloadSubscriber(int id)
        {
            var table = SubscriberHelper.GetSubscriptionList(_client.Id);

            if (table.Rows.Count > 0)
            {
                SubscriberHelper.FormatSubscriptionList(table, id);
                foreach (DataRow row in table.Rows)
                {
                    if (id.Equals(row["id"]))
                    {
                        foreach (DataGridViewRow grow in grdSubscription.Rows)
                        {
                            if (id.Equals(grow.Cells["c_id"].Value))
                            {
                                foreach (DataGridViewColumn col in grdSubscription.Columns)
                                {
                                    if (!string.IsNullOrEmpty(col.DataPropertyName))
                                    {
                                        grow.Cells[col.Index].Value = row[col.DataPropertyName];
                                    }
                                }
                                grdSubscription.Refresh();
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }

        private void FilterSubscribers()
        {
            if (_lastFilter == cmbShow.SelectedIndex) return;

            _lastFilter = cmbShow.SelectedIndex;
            foreach (DataGridViewRow row in grdSubscription.Rows)
            {
                switch (cmbShow.SelectedIndex)
                {
                    case -1:
                    case 0:
                        _lastFilter = 0;
                        row.Visible = true;
                        break;

                    case 1: // Active
                        row.Visible = row.Cells["c_status_id"].Value.Equals(1);
                        break;

                    case 2: // Future
                        row.Visible = row.Cells["c_status_id"].Value.Equals(2);
                        break;

                    case 3: // History
                        row.Visible = row.Cells["c_status_id"].Value.Equals(3);
                        break;

                    case 4: // Froze
                        row.Visible = row.Cells["c_status_id"].Value.Equals(4);
                        break;

                    case 5: // No Future
                        row.Visible = !row.Cells["c_status_id"].Value.Equals(2);
                        break;

                    case 6: // No History
                        row.Visible = !row.Cells["c_status_id"].Value.Equals(3);
                        break;

                    case 7: // No Froze
                        row.Visible = !row.Cells["c_status_id"].Value.Equals(4);
                        break;

                }
            }

            if (grdSubscription.SelectedRows.Count > 0)
            {
                if (grdSubscription.SelectedRows[0].Visible == false)
                {
                    grdSubscription.SelectedRows[0].Selected = false;
                    SelectFirstSubscriber();
                }
            }

            grdSubscription.Focus();
        }

        private void TbbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GrdSubscription_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
// ReSharper disable PossibleNullReferenceException
            grdSubscription.Columns["c_status"].DisplayIndex = 0;
            grdSubscription.Columns["c_status_name"].DisplayIndex = 1;
            grdSubscription.Columns["c_name"].DisplayIndex = 2;
            grdSubscription.Columns["c_type"].DisplayIndex = 3;
            grdSubscription.Columns["c_remain_desc"].DisplayIndex = 4;
            grdSubscription.Columns["c_datecreate"].DisplayIndex = 5;
            grdSubscription.Columns["c_button"].DisplayIndex = 6;
// ReSharper restore PossibleNullReferenceException
        }

        private void GrdSubscription_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int status;

            if (grdSubscription.Columns[e.ColumnIndex].Name == "c_status")
            {
                status = (int)grdSubscription["c_status_id", e.RowIndex].Value;
                switch (status)
                {
                    case 1: // Active
                        e.Value = Properties.Resources.status1;
                        break;
                    case 2:
                        e.Value = Properties.Resources.status2;
                        break;
                    case 3:
                        e.Value = Properties.Resources.status3;
                        break;
                    case 4:
                        e.Value = Properties.Resources.status4;
                        break;
                }
            }
            else if (grdSubscription.Columns[e.ColumnIndex].Name == "c_button")
            {
                status = (int)grdSubscription["c_status_id", e.RowIndex].Value;
                e.Value = status == 1 ? Properties.Resources.reg_button : Properties.Resources.reg_button_dis;
            }
        }

        private void GrdSubscription_SelectionChanged(object sender, EventArgs e)
        {
            if (_loadProc) return;
            LoadUsageGrid();
            SetFreezButtonState();
        }

        private void SetFreezButtonState()
        {
            var status = SelectedStatus;
            switch (status)
            {
                case 4:
                    const string caption1 = "בטל הקפאת מנוי";
                    tbbFreez.Text = caption1;
                    tbbFreez.Checked = true;
                    break;

                default:
                    const string caption2 = "הקפא מנוי";
                    tbbFreez.Text = caption2;
                    tbbFreez.Checked = false;
                    break;
            }
        }

        private void GrdUsage_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
// ReSharper disable PossibleNullReferenceException
            grdUsage.Columns["c_uid"].DisplayIndex = 0;
            grdUsage.Columns["c_date"].DisplayIndex = 1;
            grdUsage.Columns["c_time"].DisplayIndex = 2;
            grdUsage.Columns["c_remark"].DisplayIndex = 3;
            grdUsage.Columns["c_delete"].DisplayIndex = 4;
// ReSharper restore PossibleNullReferenceException
            grdUsage.ClearSelection();
        }

        private void FrmSubscription_Load(object sender, EventArgs e)
        {
            cmbShow.SelectedIndex = 0;
        }

        private void FrmSubscription_RequestForClose(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmbShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterSubscribers();
        }

        private void GrdSubscription_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var status = (int)grdSubscription["c_status_id", e.RowIndex].Value;
            if (e.RowIndex >= 0 && status == 1)
            {
// ReSharper disable PossibleNullReferenceException
                if (grdSubscription.Columns["c_button"].Index == e.ColumnIndex)
// ReSharper restore PossibleNullReferenceException
                {
                    Exception procEx = null;
                    bool ok;
                    const string caption = "רישום שימוש במנוי...";

                    // ask for subscribe usage
                    var msg = "האם אתה בטוח שברצונך לרשום שימוש במנוי\n" + SelectedName;
                    MyMessageBox = new MyMessageBox(msg, caption, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
                    var res = MyMessageBox.Show(this);
                    if (res == DialogResult.No) return;

                    // do subscribe usage
                    try
                    {
                        var id = SelectedSubId;
                        ok = SubscriberHelper.AddSubscriberUsage(id);
                        ReloadSubscriber(id);
                    }
                    catch (Exception ex)
                    {
                        ok = false;
                        procEx = ex;
                    }

                    if (ok)
                    {
                        // subscribe usage complete successfuly
                        // refresh usage grid
                        LoadUsageGrid();

                        // select the new usage
                        if (grdSubscription.Rows.Count > 0)
                        {
                            var row = grdUsage.Rows[0];
                            //row.Selected = true;
                            try { grdSubscription.CurrentCell = row.Cells["c_date"]; }
                            catch { Utils.CatchException(); }
                            if (!row.Displayed) grdUsage.FirstDisplayedScrollingRowIndex = row.Index;
                        }

                        // show user confirm for action
                        msg = "השימוש במנוי נרשם בהצלחה\n שם הלקוח: " + _client.FullName;
                        MyMessageBox = new MyMessageBox(msg, caption, MyMessageBox.MyMessageType.Confirm, MyMessageBox.MyMessageButton.None) 
                            {CloseInterval = 3000};

                        MyMessageBox.Show(this);

                        _lastFilter = -1;
                        FilterSubscribers();
                    }
                    else
                    {
                        // ERROR subscribe usage 
                        msg = "רישום המנוי נכשל\n(שם הלקוח: " + _client.FullName + ")";
                        const string process = "רישום שימוש במנוי";
                        General.ShowErrorMessageDialog(this, caption, process, msg, procEx, this.Name);
                    }
                }
            }
        }

        private void SelectFirstSubscriber()
        {
            for (var i = 0; i < grdSubscription.Rows.Count; i++)
            {
                if (grdSubscription.Rows[i].Visible)
                {
                    grdSubscription.Rows[i].Selected = true;
                    try { grdSubscription.CurrentCell = grdSubscription.Rows[i].Cells["c_status_name"]; }
                    catch { Utils.CatchException(); }
                    grdSubscription.FirstDisplayedScrollingRowIndex = i;
                    break;
                }
            }
        }

        private void FrmSubscription_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Validate();
            SaveUsageGrid();
        }

        private void TbbAdd_Click(object sender, EventArgs e)
        {
            SaveUsageGrid();
            var fSubscriptionDetails = new FormSubscriptionDetails(-1, _client, FormSubscriptionDetails.SubscriberMode.New)
            {
                Location = this.Location
            };
            fSubscriptionDetails.FormClosed += FSubscriptionDetails_FormClosed;
            fSubscriptionDetails.RefreshClientBullets += FSubscriptionDetails_RefreshClientBullets;
            _status = FormStatus.Edit;
            fSubscriptionDetails.Show(this);
            this.Hide();
        }

        void FSubscriptionDetails_RefreshClientBullets(object sender, EventArgs e)
        {
            if (RefreshClientBullets != null) RefreshClientBullets(this, new EventArgs());
        }

        void FSubscriptionDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            var res = ((Form)sender).DialogResult;
            if (res == DialogResult.OK)
            {
                LoadSubscribers();
            }

            this.Location = ((Form)sender).Location;
            _status = FormStatus.View;
            this.Show();
        }

        void FSubscriptionDetails_FormClosed2(object sender, FormClosedEventArgs e)
        {
            var res = ((Form)sender).DialogResult;
            if (res == DialogResult.OK)
            {
                var id = SelectedSubId;
                ReloadSubscriber(id);
                _lastFilter = -1;
                FilterSubscribers();
                LoadUsageGrid();
            }

            this.Location = ((Form)sender).Location;
            _status = FormStatus.View;
            this.Show();
        }

        private void TbbEdit_Click(object sender, EventArgs e)
        {
            SaveUsageGrid();
            var id = SelectedSubId;

            if (id > 0)
            {
                var fSubscriptionDetails = new FormSubscriptionDetails(id, _client, FormSubscriptionDetails.SubscriberMode.Edit)
                {
                    Location = this.Location
                };
                fSubscriptionDetails.FormClosed += FSubscriptionDetails_FormClosed2;
                _status = FormStatus.Edit;
                fSubscriptionDetails.Show(this);
                this.Hide();
            }
            else
            {
                const string msg = "לא נבחר מנוי לעריכה";
                const string caption = "עדכון פרטי מנוי...";
                MyMessageBox = new MyMessageBox(msg, caption, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MyMessageBox.Show(this);
            }
        }

        private void TbbDelete_Click(object sender, EventArgs e)
        {
            SaveUsageGrid();
            var id = SelectedSubId;
            const string caption = "מחיקת מנוי...";
            string msg;

            if (id > 0)
            {
                if (SelectedStatus == 3)
                {
                    msg = "לא ניתן למחוק מנוי היסטורי";
                    MyMessageBox = new MyMessageBox(msg, caption, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                    MyMessageBox.Show(this);
                }
                else
                {
                    msg = "האם אתה בטוח שברצונך למחוק את המנוי המסומן\nשים לב: כל רישומי הביקורים של המנוי ימחקו אף הם!";
                    MyMessageBox = new MyMessageBox(msg, caption, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
                    var res = MyMessageBox.Show(this);
                    if (res == DialogResult.Yes)
                    {
                        var ok = false;
                        Exception procEx = null;
                        try
                        {
                            ok = SubscriberHelper.DeleteSubscriber(id);
                        }
                        catch (Exception ex)
                        {
                            procEx = ex;
                        }

                        if (ok)
                        {
                            if (RefreshClientBullets != null) RefreshClientBullets(this, new EventArgs());
                            LoadSubscribers();
                            msg = "מחיקת המנוי התבצעה בהצלחה";
                            MyMessageBox = new MyMessageBox(msg, caption, MyMessageBox.MyMessageType.Confirm, MyMessageBox.MyMessageButton.None)
                            {
                                CloseInterval = 3000
                            };
                            MyMessageBox.Show(this);
                        }
                        else
                        {
                            msg = "מחיקת המנוי נכשלה";
                            General.ShowErrorMessageDialog(this, caption, "מחיקת מנוי", msg, procEx, this.Name);
                        }
                    }
                }
            }
            else
            {
                msg = "לא נבחר מנוי למחיקה";
                MyMessageBox = new MyMessageBox(msg, caption, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MyMessageBox.Show(this);
            }
        }

        private void TbbFreez_Click(object sender, EventArgs e)
        {
            SaveUsageGrid();
            var status = SelectedStatus;
            var id = SelectedSubId;
            string msg, caption;

            if (id > 0)
            {
                DialogResult res;
                switch (status)
                {
                    case 1:
                        #region Freez Subscribe

                        caption = "הקפאת מנוי...";
                        msg = "האם אתה בטוח שברצונך להקפיא את המנוי";
                        MyMessageBox = new MyMessageBox(msg, caption, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
                        res = MyMessageBox.Show(this);
                        if (res == DialogResult.Yes)
                        {
                            #region Do Freez

                            var ok = false;
                            Exception procEx = null;
                            try
                            {
                                ok = SubscriberHelper.UpdateSubscriberStatus(id, 4);
                                ok = ok && SubscriberHelper.FrozeSubscribe(id);
                            }
                            catch (Exception ex)
                            {
                                procEx = ex;
                            }

                            #endregion

                            if (ok)
                            {
                                if (RefreshClientBullets != null) RefreshClientBullets(this, new EventArgs());
                                ReloadSubscriber(id);
                                SetFreezButtonState();
                                msg = "הקפאת המנוי התבצעה בהצלחה";
                                MyMessageBox = new MyMessageBox(msg, caption, MyMessageBox.MyMessageType.Confirm, MyMessageBox.MyMessageButton.None)
                                {
                                    CloseInterval = 3000
                                };
                                MyMessageBox.Show(this);
                                _lastFilter = -1;
                                FilterSubscribers();
                            }
                            else
                            {
                                General.ShowErrorMessageDialog(this, caption, "הקפאת המנוי", "הקפאת המנוי נכשלה", procEx, this.Name);
                            }
                        }

                        #endregion
                        break;

                    case 4:
                        #region UnFreez Subscribe

                        caption = "ביטול הקפאת מנוי...";
                        msg = "האם אתה בטוח שברצונך לבטל הקפאת המנוי";
                        MyMessageBox = new MyMessageBox(msg, caption, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
                        res = MyMessageBox.Show(this);
                        if (res == DialogResult.Yes)
                        {
                            #region Do UnFreez

                            var ok = false;
                            Exception procEx = null;
                            try
                            {
                                ok = SubscriberHelper.UpdateSubscriberStatus(id, 1);
                                ok = ok && SubscriberHelper.UnFrozeSubscribe(id);
                            }
                            catch (Exception ex)
                            {
                                procEx = ex;
                            }

                            if (ok)
                            {
                                if (RefreshClientBullets != null) RefreshClientBullets(this, new EventArgs());
                                ReloadSubscriber(id);
                                SetFreezButtonState();
                                msg = "ביטול הקפאת המנוי התבצע בהצלחה";
                                MyMessageBox = new MyMessageBox(msg, caption, MyMessageBox.MyMessageType.Confirm, MyMessageBox.MyMessageButton.None)
                                {
                                    CloseInterval = 3000
                                };
                                MyMessageBox.Show(this);
                                _lastFilter = -1;
                                FilterSubscribers();
                            }
                            else
                            {
                                General.ShowErrorMessageDialog(this, caption, "ביטול הקפאת המנוי", "ביטול הקפאת המנוי נכשל", procEx, this.Name);
                            }

                            #endregion
                        }

                        #endregion
                        break;

                    case 2:
                    case 3:
                        caption = "הקפאת מנוי...";
                        msg = "המנוי המסומן אינו פעיל\nניתן להקפיא מנויים פעילים בלבד";
                        MyMessageBox = new MyMessageBox(msg, caption, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                        MyMessageBox.Show(this);
                        break;

                    //case -1:
                    default:
                        break;
                }
            }
            else
            {
                msg = "לא נבחר מנוי להקפאה";
                caption = "הקפאת מנוי...";
                MyMessageBox = new MyMessageBox(msg, caption, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MyMessageBox.Show(this);
            }
        }

        private void GrdSubscription_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var info = grdSubscription.HitTest(e.X, e.Y);
// ReSharper disable PossibleNullReferenceException
            if (info.RowIndex >= 0 && info.ColumnIndex != grdSubscription.Columns["c_button"].Index)
// ReSharper restore PossibleNullReferenceException
            {
                TbbEdit_Click(null, null);
            }
        }

        public void RegisterSingleSubscription()
        {
            cmbShow.SelectedIndex = 1;
            SelectFirstSubscriber();

            bool ok;
            string msg;
            const string caption = "רישום שימוש במנוי...";
            Exception procEx = null;

            try
            {
                var id = SelectedSubId;
                ok = SubscriberHelper.AddSubscriberUsage(id);
                ReloadSubscriber(id);
            }
            catch (Exception ex)
            {
                ok = false;
                procEx = ex;
            }

            if (ok)
            {
                // subscribe usage complete successfuly
                // refresh usage grid
                LoadUsageGrid();

                // show user confirm for action

                msg = "השימוש במנוי נרשם בהצלחה\n שם הלקוח: " + _client.FullName;
                MyMessageBox = new MyMessageBox(msg, caption, MyMessageBox.MyMessageType.Confirm, MyMessageBox.MyMessageButton.None)
                {
                    CloseInterval = 3000
                };
                MyMessageBox.Show(this);

                _lastFilter = -1;
                FilterSubscribers();
            }
            else
            {
                // ERROR subscribe usage 
                msg = "רישום המנוי נכשל\n(שם הלקוח: " + _client.FullName + ")";
                const string process = "רישום שימוש במנוי";
                General.ShowErrorMessageDialog(this, caption, process, msg, procEx, this.Name);
            }
        }

        private void GrdUsage_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
// ReSharper disable PossibleNullReferenceException
                if (grdUsage.Columns["c_date"].Index == e.ColumnIndex)
// ReSharper restore PossibleNullReferenceException
                {
                    try
                    {
                        var value = (DateTime)e.Value;
                        if (value.Date == DateTime.Now.Date)
                        {
                            grdUsage["c_date", e.RowIndex].Style.BackColor = _colorTodayUsage;
                            grdUsage["c_time", e.RowIndex].Style.BackColor = _colorTodayUsage;
                        }
                    }
                    catch { Utils.CatchException(); }
                }
            }
        }

        private void GrdSubscription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void GrdUsage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        }
    }
}