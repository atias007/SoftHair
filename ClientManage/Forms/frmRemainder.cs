using BizCare.Calendar.Library;
using ClientManage.BL;
using ClientManage.BL.Library;
using ClientManage.Interfaces;
using ClientManage.Library;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClientManage.Forms
{
    public partial class FormRemainder : BasePopupForm
    {
        #region Events

        // Open event details form when click the lnkMsg
        public event OpenFormEventHandler OpenForm;

        #endregion Events

        private RemainderItem[] _events = null;
        private readonly string strStartTime = string.Empty;
        private bool _inProc = false;

        public FormRemainder(RemainderItem[] events)
        {
            InitializeComponent();
            _events = events;
            strStartTime = lblStartDate.Text;
        }

        private void UpdateFormText()
        {
            var i = lstItems.Items.Count;
            if (i > 1)
            {
                this.Text = " " + i.ToString() + " תזכורות";
            }
            else
            {
                this.Text = "תזכורת אחת";
            }
        }

        private string GetDueDateString(TimeSpan dueMinutes)
        {
            var ret = string.Empty;

            if (dueMinutes.Days != 0) ret = Math.Abs(dueMinutes.Days) + " ימים";
            else if (dueMinutes.Hours != 0) ret = Math.Abs(dueMinutes.Hours) + " שעות";
            else if (dueMinutes.Minutes != 0) ret = Math.Abs(dueMinutes.Minutes) + " דקות";
            if (ret.Length == 0)
            {
                ret = "מתרחש ברגע זה";
            }
            else
            {
                if (dueMinutes.TotalMinutes < 0) ret = "באיחור של " + ret;
            }
            return ret;
        }

        public void AddNewItems(RemainderItem[] items)
        {
            var list = new ArrayList();
            for (var i = 0; i < _events.Length; i++)
            {
                if (_events[i] != null) list.Add(_events[i]);
            }
            for (var i = 0; i < items.Length; i++)
            {
                list.Add(items[i]);
            }
            list.Sort();

            _events = new RemainderItem[list.Count];
            list.CopyTo(_events);
            lstItems.Items.Clear();
            RefreshItems();
            Utils.PlayWavFile(Remainder.SoundFile);
            Utils.FocusWindow(this.Handle, true);
        }

        private void RefreshItems()
        {
            ListViewItem item;
            string clientName, subject, cares;
            for (var i = 0; i < _events.Length; i++)
            {
                if (_events[i] == null) continue;
                clientName = ClientHelper.GetFullName(Utils.GetDBValue<int>(_events[i].EventRow["client_id"]));
                subject = Utils.GetDBValue<string>(Utils.GetDBValue<string>(_events[i].EventRow["subject"]));
                cares = CalendarHelper.GetCaresDescription(Utils.GetDBValue<string>(_events[i].EventRow["cares"]));
                item = new ListViewItem(Appointment.GetAppointmentString(subject, clientName, cares));
                item.SubItems.Add(GetDueDateString(_events[i].DueMinutes));
                item.SubItems[0].Tag = Convert.ToInt32(_events[i].EventRow["id"]);
                item.Tag = Utils.GetDBValue<DateTime>(_events[i].EventRow["date_start"]).ToString("dddd d MMMM yyyy בשעה HH:mm");
                lstItems.Items.Add(item);
            }

            if (lstItems.Items.Count > 0) lstItems.Items[0].Selected = true;
            else this.Close();

            UpdateFormText();
            Utils.PlayWavFile(Remainder.SoundFile);
            Utils.FocusWindow(this.Handle, true);
        }

        private void frmRemainder_Load(object sender, EventArgs e)
        {
            RefreshItems();

            cmbSnooze.DataSource = CalendarHelper.GetRemainderValues().Tables[0];
            cmbSnooze.DisplayMember = "description";
            cmbSnooze.ValueMember = "min_value";
            if (cmbSnooze.Items.Count > 0) cmbSnooze.SelectedIndex = 0;
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_inProc) return;

            var sel = lstItems.SelectedItems.Count > 0;
            if (sel)
            {
                lblSubject.Text = lstItems.SelectedItems[0].Text;
                lblStartDate.Text = string.Format(strStartTime, lstItems.SelectedItems[0].Tag.ToString());
            }
            else
            {
                lblStartDate.Text = "בחר תזכורת מהרשימה להצגת פרטיה";
                lblSubject.Text = string.Empty;
            }
            btnRemove.Enabled = sel;
            btnRemoveAll.Enabled = sel;
            btnShowItem.Enabled = sel;
            btnSnooze.Enabled = sel;
            cmbSnooze.Enabled = sel;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstItems.SelectedItems.Count > 0)
            {
                _inProc = true;
                var i = lstItems.SelectedItems[0].Index;
                //CalendarHelper.SetRemainderDismiss((int)lstItems.Items[i].SubItems[0].Tag);
                LocalRemoveEvent((int)lstItems.Items[i].SubItems[0].Tag);
                lstItems.Items.Remove(lstItems.SelectedItems[0]);
                if (i >= lstItems.Items.Count) i = lstItems.Items.Count - 1;
                if (i >= 0)
                {
                    lstItems.Items[i].Selected = true;
                    UpdateFormText();
                    _inProc = false;
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < lstItems.Items.Count; i++)
            {
                //CalendarHelper.SetRemainderDismiss((int)lstItems.Items[i].SubItems[0].Tag);
                LocalRemoveEvent((int)lstItems.Items[i].SubItems[0].Tag);
            }

            this.Close();
        }

        private void btnSnooze_Click(object sender, EventArgs e)
        {
            if (lstItems.SelectedItems.Count > 0)
            {
                _inProc = true;
                var i = lstItems.SelectedItems[0].Index;
                //CalendarHelper.SetRemainderSnooze((int)lstItems.Items[i].SubItems[0].Tag, (int)cmbSnooze.SelectedValue);
                LocalRemoveEvent((int)lstItems.Items[i].SubItems[0].Tag);
                lstItems.Items.Remove(lstItems.SelectedItems[0]);
                if (i >= lstItems.Items.Count) i = lstItems.Items.Count - 1;
                if (i >= 0)
                {
                    lstItems.Items[i].Selected = true;
                    UpdateFormText();
                    _inProc = false;
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void LocalRemoveEvent(int id)
        {
            for (var i = 0; i < _events.Length; i++)
            {
                if (_events[i] == null) continue;
                if ((int)_events[i].EventRow["id"] == id)
                {
                    _events[i] = null;
                }
            }
        }

        public void RemoveRemainder(string id)
        {
            for (var i = 0; i < _events.Length; i++)
            {
                if (_events[i] == null) continue;
                if (Convert.ToString(_events[i].EventRow["id"]) == id)
                {
                    _events[i] = null;
                    break;
                }
            }

            for (var i = 0; i < lstItems.Items.Count; i++)
            {
                if (Convert.ToString(lstItems.Items[i].SubItems[0].Tag) == id)
                {
                    lstItems.Items.RemoveAt(i);
                    UpdateFormText();
                    break;
                }
            }
        }

        private void btnShowItem_Click(object sender, EventArgs e)
        {
            ShowItem();
        }

        private void ShowItem()
        {
            if (OpenForm != null)
            {
                if (lstItems.SelectedItems.Count > 0)
                {
                    var id = (string)lstItems.SelectedItems[0].SubItems[0].Tag;
                    DataRow row;
                    try
                    {
                        row = CalendarHelper.GetAppointment(id);
                    }
                    catch (Exception ex)
                    {
                        General.ShowCommunicationError(ex, this);
                        return;
                    }
                    var app = FormCalendar.GetAppointmentFromDataRow(row);
                    OpenForm(this, new OpenFormEventArgs("frmCalendar", app));
                }
            }
        }

        private void lstItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowItem();
        }
    }
}