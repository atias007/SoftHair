using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClientManage.Interfaces;
using ClientManage.BL;
using ClientManage.Library;

namespace ClientManage.Forms
{
    public partial class FormSubscriptionDetails : ClientManage.Forms.BasePopupForm
    {
        public event EventHandler RefreshClientBullets;
        
        public enum SubscriberMode { New, Edit };
        private readonly Subscriber _subscriber;
        private readonly Client _client;
        private readonly SubscriberMode _mode;
        private readonly string _usageCount;
        private FormCarePick fCarePick;
        private bool _hasActivate = false;
        private readonly Color _colorTodayUsage = Color.FromArgb(197, 240, 158);

        public FormSubscriptionDetails(int id, Client client, SubscriberMode mode)
        {
            InitializeComponent();
            _usageCount = lblUsageCount.Text;
            _client = client;
            _mode = mode;
            dtpToDate.Value = null;
            dtpFromDate.DefaultValue = DateTime.Now.Date;
            dtpToDate.DefaultValue = DateTime.Now.Date;
            dtpToDate.Value = null;
            ClearUsageLabel();

            switch (_mode)
            {
                case SubscriberMode.Edit:
                    _subscriber = SubscriberHelper.GetSubscriber(id);
                    this.Text = "עדכון פרטי מנוי";
                    informationBar1.PanelText = this.Text + ": " + _subscriber.Name;
                    LoadSubscriber();
                    break;
                case SubscriberMode.New:
                    _subscriber = new Subscriber();
                    ReadSubscriberFromScreen();
                    this.Text = "יצירת מנוי חדש ללקוח: " + _client.FullName;
                    informationBar1.PanelText = this.Text;
                    break;
                default:
                    break;
            }
            
            CheckFreez();
            _subscriber.ClientId = _client.Id;
            _subscriber.ResetChanges();
        }

        private void CheckFreez()
        {
            if (_subscriber.Status == Subscriber.SubscribeStatus.Frozen)
            {
                lblWarn.Visible = true;
                chkAmount.Enabled = false;
                chkToDate.Enabled = false;
                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = false;
                txtAmount.Enabled = false;
            }
        }

        private void LoadUsageGrid()
        {
            grdUsage.DataSource = SubscriberHelper.GetSubscriberUsages(_subscriber.Id);
            grdUsage.DataMember = "SubscriberUsages";
            lblUsageCount.Text = string.Format(_usageCount, grdUsage.Rows.Count);
            grdUsage.BackgroundColor = Color.White;
        }

        private void ClearUsageLabel()
        {
            lblUsageCount.Text = string.Format(_usageCount, 0);
        }

        private int SelectedId
        {
            get
            {
                var id = -1;
                if (grdUsage.SelectedRows.Count > 0)
                {
                    id = (int)grdUsage.SelectedRows[0].Cells["c_id"].Value;
                }
                return id;
            }
        }

        private void SaveUsageGrid()
        {
            var ds = (DataSet)grdUsage.DataSource;
            SubscriberHelper.SaveSubscriberUsages(ds);
        }

        private ValidationResult ValidateForm()
        {
            var valid = new ValidationResult();

            if (chkAmount.Checked && txtAmount.Value > 0 && chkToDate.Checked && dtpToDate.Value.HasValue == false) chkToDate.Checked = false;
            if (string.IsNullOrEmpty(_subscriber.Cares) == false && string.IsNullOrEmpty(txtName.Text.Trim())) txtName.Text = txtCares.Text;
            txtName.Text = txtName.Text.Trim();
            txtRemark.Text = txtRemark.Text.Trim();

            if (chkAmount.Checked && txtAmount.Value == 0)
            {
                valid.Add("יש להזין כמות ביקורים גדולה מ-0 או להסיר את הסימון");
            }

            if (string.IsNullOrEmpty(_subscriber.Cares) && string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                valid.Add("יש להזין לפחות אחד מהשדות הבאים: תיאור מנוי, טיפולים ומוצרים");
            }

            if (chkAmount.Checked == false && chkToDate.Checked == false)
            {
                valid.Add("יש לקבוע את תוקף המנוי: עד תאריך ו/או מספר ביקורים");
            }

            if (dtpToDate.Value.HasValue)
            {
                if (dtpToDate.Value.Value <= dtpFromDate.Value.Value)
                {
                    valid.Add("תאריך ההתחלת המנוי גדול או שווה לתאריך סיום המנוי");
                }
            }

            if (chkAmount.Checked && txtAmount.Value > 0)
            {
                var usage = grdUsage.Rows.Count;

                if (txtAmount.Value < usage)
                {
                    valid.Add("כמות הביקורים שנקבעה קטנה מכמות השימושים בפועל");
                }
            }

            return valid;
        }

        private void grdUsage_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdUsage.Columns["c_id"].DisplayIndex = 0;
            grdUsage.Columns["c_date"].DisplayIndex = 1;
            grdUsage.Columns["c_time"].DisplayIndex = 2;
            grdUsage.Columns["c_remark"].DisplayIndex = 3;
            grdUsage.Columns["c_delete"].DisplayIndex = 4;
        }

        private void frmSubscriptionDetails_RequestForClose(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbbAdd_Click(object sender, EventArgs e)
        {
            this.Validate();

            var res = ValidateForm();
            if (res.HasResult)
            {
                MyMessageBox = new MyMessageBox(res.ToString(), "שמירת נתונים...", MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MyMessageBox.Show(this);
            }
            else
            {
                if (SaveData())
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private bool SaveData()
        {
            SaveUsageGrid();
            ReadSubscriberFromScreen();

            if (!_subscriber.HasChanges) return true;

            var ok = false;
            Exception procEx = null;

            try
            {
                if (_mode == SubscriberMode.New)
                {
                    _subscriber.Id = SubscriberHelper.AddSubscriber(_subscriber);
                    ok = _subscriber.Id > 0;
                    if (ok && RefreshClientBullets != null) RefreshClientBullets(this, new EventArgs());
                }
                else if (_mode == SubscriberMode.Edit) ok = SubscriberHelper.UpdateSubscriber(_subscriber);
            }
            catch (Exception ex)
            {
                procEx = ex;
            }

            if (ok)
            {
                _subscriber.ResetChanges();
            }
            else
            {
                var msg = "שמירת נתוני המנוי נכשלה";
                var title = "שמירת נתונים...";
                General.ShowErrorMessageDialog(this, title, "שמירת נתוני המנוי", msg, procEx, this.Name);
            }

            return ok;
        }

        private void chkToDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpToDate.Enabled = chkToDate.Checked;
            if (!dtpToDate.Enabled) dtpToDate.Value = null;
        }

        private void chkAmount_CheckedChanged(object sender, EventArgs e)
        {
            txtAmount.Enabled = chkAmount.Checked;
            if (!txtAmount.Enabled) txtAmount.Value = 0;
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            base.TextBoxEnter((TextBox)sender);
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            base.TextBoxLeave((TextBox)sender);
        }

        private void btnCares_Click(object sender, EventArgs e)
        {
            var rect = btnCares.RectangleToScreen(btnCares.DisplayRectangle);

            if (fCarePick == null || fCarePick.IsDisposed)
            {
                this.Cursor = Cursors.WaitCursor;
                fCarePick = new FormCarePick(_subscriber.Cares);
                fCarePick.Left = rect.Left;
                fCarePick.Top = rect.Bottom + 2;
                fCarePick.SetAppointmentCares += new EventHandler(fCarePick_SetAppointmentCares);
                fCarePick.FormClosed += new FormClosedEventHandler(fCarePick_FormClosed);
                fCarePick.Show();
                this.Cursor = Cursors.Default;
            }
            else
            {
                fCarePick.ClearSelected();
                fCarePick.SelectCares(_subscriber.Cares);
                fCarePick.Left = rect.Left;
                fCarePick.Top = rect.Top - fCarePick.Height - 2;
            }
            fCarePick.Select();
        }
        
        void fCarePick_SetAppointmentCares(object sender, EventArgs e)
        {
            var cares = FormCarePick.SelectedCares;
            txtCares.Text = CalendarHelper.GetCaresDescription(cares);
            _subscriber.Cares = cares;
        }

        void fCarePick_FormClosed(object sender, FormClosedEventArgs e)
        {
            txtCares.Select();
        }

        private void ReadSubscriberFromScreen()
        {
            _subscriber.Name = txtName.Text;
            _subscriber.FromDate = dtpFromDate.Value.Value;
            _subscriber.ToDate = dtpToDate.Value;
            _subscriber.Amount = (Convert.ToInt32(txtAmount.Value) > 0 ? Convert.ToInt32(txtAmount.Value) : -1);
            _subscriber.Remark = txtRemark.Text;
            _subscriber.Status = _subscriber.CalcStatus(SubscriberHelper.GetUsageCount(_subscriber.Id));
            _subscriber.Type = _subscriber.CalcType();
        }

        private void LoadSubscriber()
        {
            txtName.Text = _subscriber.Name;
            txtCares.Text = CalendarHelper.GetCaresDescription(_subscriber.Cares);
            txtRemark.Text = _subscriber.Remark;
            dtpFromDate.Value = _subscriber.FromDate;
            dtpToDate.Value = _subscriber.ToDate;
            txtAmount.Value = (_subscriber.Amount > 0 ? _subscriber.Amount : 0);
            chkAmount.Checked = _subscriber.Amount > 0;
            chkToDate.Checked = (_subscriber.Type == Subscriber.SubscribeType.Period || _subscriber.Type == Subscriber.SubscribeType.QuantityAndPeriod);
            txtStatus.Text = _subscriber.StatusTitle;
            txtLastUpdate.Text = (_subscriber.DateUpdate.HasValue ? _subscriber.DateUpdate.Value.ToString("dd/MM/yyyy בשעה HH:mm") : "< ללא תאריך >");
            txtDateFroze.Text = (_subscriber.DateFrozen.HasValue ? _subscriber.DateFrozen.Value.ToString("dd/MM/yyyy בשעה HH:mm") : "< ללא תאריך >");
            switch (_subscriber.Status)
            {
                case Subscriber.SubscribeStatus.Active:
                    lblStatusIcon.Image = Properties.Resources.status1;
                    break;
                case Subscriber.SubscribeStatus.History:
                    lblStatusIcon.Image = Properties.Resources.status3;
                    break;
                case Subscriber.SubscribeStatus.Future:
                    lblStatusIcon.Image = Properties.Resources.status2;
                    break;
                case Subscriber.SubscribeStatus.Frozen:
                    lblStatusIcon.Image = Properties.Resources.status4;
                    break;
                default:
                    break;
            }

            LoadUsageGrid();
        }

        private void grdUsage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (grdUsage.Columns["c_delete"].Index == e.ColumnIndex)
                {
                    var id = SelectedId;
                    if (id > 0)
                    {
                        var msg = "האם אתה בטוח שברצונך למחוק את הביקור המסומן";
                        var caption = "מחיקת ביקור...";
                        MyMessageBox = new MyMessageBox(msg, caption, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
                        var res = MyMessageBox.Show(this);

                        if (res == DialogResult.Yes)
                        {
                            var table = ((DataSet)grdUsage.DataSource).Tables[0];
                            for (var i = 0; i < table.Rows.Count; i++)
                            {
                                if (table.Rows[i].RowState != DataRowState.Deleted)
                                {
                                    if (id.Equals(table.Rows[i]["id"]))
                                    {
                                        table.Rows[i].Delete();
                                        _subscriber.SetHasChanges();
                                        lblUsageCount.Text = string.Format(_usageCount, grdUsage.Rows.Count);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void frmSubscriptionDetails_Activated(object sender, EventArgs e)
        {
            if (_hasActivate) return;
            _hasActivate = true;
            txtName.Focus();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmSubscriptionDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReadSubscriberFromScreen();
            if (this.DialogResult != DialogResult.OK && _subscriber.HasChanges)
            {
                var msg = "האם אתה בטוח שברצונך לצאת ללא שמירת השינויים";
                MyMessageBox = new MyMessageBox(msg, this.Text, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
                var res = MyMessageBox.Show(this);
                if (res == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void grdUsage_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (grdUsage.Columns["c_date"].Index == e.ColumnIndex)
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
                    catch { }
                }
            }
        }
    }
}

