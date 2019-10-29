using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using ClientManage.Interfaces;
using ClientManage.BL;
using ClientManage.Library;
using ClientManage.UserControls;
using ClientManage.BL.Library;

namespace ClientManage.Forms
{
    public partial class FormIncomingCall : BasePopupForm
    {
        #region Events

        public event DlgShowClientCardEventHandler ShowClientCard;

        public event CreateNewClientEventHandler CreateNewClient;

        // open calendar and remember to attach client to the new appointment
        public event CalendarSetAppointmentEventHandler SetAppointment;

        #endregion Events

        #region Private Memebers

        private delegate void SaveCallLogHandler(CallerIdPerson[] persons, string callerId);

        private readonly ArrayList _callers = new ArrayList();
        private readonly bool _showLinkToClientCard;
        private readonly CallerIdPerson[] _persons;
        private DataTable _table;
        private readonly DateTime _curCallTime;
        private readonly DgvLoadImages _imageLoader = new DgvLoadImages();
        private readonly string _callerId;

        #endregion Private Memebers

        #region Constructor

        public FormIncomingCall(string callerId, bool showLinkToClientCard) : this(callerId, showLinkToClientCard, null)
        {
        }

        // initialize form controls
        public FormIncomingCall(string callerId, bool showLinkToClientCard, DataTable table)
        {
            InitializeComponent();
            _curCallTime = DateTime.Now;
            _callerId = callerId;
            _showLinkToClientCard = showLinkToClientCard;
            _table = table;
            if (callerId.ToLower().Equals("private")) callerId = string.Empty;
            if (callerId.Length > 0 && char.IsDigit(callerId[0]) && callerId[0] != '0') callerId = AppSettingsHelper.GetParamValue("PHONE_AREA_CODE") + callerId;

            // display the caller id phone
            IcId1.PhoneNumber = callerId;
            lblCallerId.Text = callerId;
            if (callerId.Length == 0)
            {
                lblCallerId.Text = @"מס' לא מזוהה";
                BeginSaveCallLog(null, string.Empty);
            }
            else
            {
                // get array of clients with the caller id phone
                _persons = ClientHelper.GetUsersByCallerId(callerId) ?? PhoneBookHelper.GetContactsByCallerId(callerId);

                // exit if no client has the caller id phone
                if (_persons != null)
                {
                    // add the first client to array list
                    _callers.Add(IcId1);

                    // set the clients data to user control (name, address, gender, etc)
                    IcId1.LoadData(_persons[0]);
                    if (!_showLinkToClientCard) IcId1.DisableLinkToClientCard();
                }

                // Save call log
                BeginSaveCallLog(_persons, callerId);
            }

            // add all others clients to array list ang initialite theis user control
            AddCallers(_persons, callerId);
        }

        private static void BeginSaveCallLog(CallerIdPerson[] persons, string callerId)
        {
            var handler = new SaveCallLogHandler(SaveCallLog);
            handler.BeginInvoke(persons, callerId, null, null);
        }

        private static void SaveCallLog(CallerIdPerson[] persons, string callerId)
        {
            if (!AppSettingsHelper.GetParamValue<bool>("PHONE_LOG_CALLS")) return;

            try
            {
                if (callerId.Length == 0) callerId = "לא מזוהה";

                if (persons == null)
                {
                    PhoneHelper.AddCallLog(-1, callerId, 0, 0);
                }
                else
                {
                    foreach (var p in persons)
                    {
                        PhoneHelper.AddCallLog(p.Id, callerId, 0, (int)p.Entity);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLogManager.AddErrorMessage("Error save call log. caller id=" + callerId, ex);
            }
        }

        #endregion Constructor

        public DataTable GetHistoryTable()
        {
            DataRow row;
            if (_table == null) InitTable();
            if (_table == null) return null;

            if (_persons == null)
            {
                row = _table.NewRow();
                row["id"] = 0;
                row["picture"] = string.Empty;
                row["full_name"] = "לקוח לא מזוהה";
                row["date_call"] = _curCallTime;
                row["phone_no"] = _callerId.Length == 0 ? "מס' לא מזוהה" : _callerId;
                _table.Rows.InsertAt(row, 0);
            }
            else
            {
                foreach (var p in _persons)
                {
                    row = _table.NewRow();
                    row["id"] = (p.Entity == CallerIdPerson.PersonEntity.Client) ? p.Id : 0;
                    row["picture"] = p.Picture;
                    row["full_name"] = p.FullName;
                    row["date_call"] = _curCallTime;
                    row["phone_no"] = _callerId;
                    _table.Rows.InsertAt(row, 0);
                }
            }

            return _table;
        }

        #region Private Functions

        private void InitTable()
        {
            _table = new DataTable();
            _table.Columns.Add("id", typeof(Int32));
            _table.Columns.Add("picture", typeof(string));
            _table.Columns.Add("full_name", typeof(string));
            _table.Columns.Add("date_call", typeof(DateTime));
            _table.Columns.Add("phone_no", typeof(string));
        }

        // build all user controls to each client in array list
        private void AddCallers(IList<CallerIdPerson> clients, string phoneNumber)
        {
            IncomeCallerId icid;
            IncomeCallerId last;
            var count = 0;

            if (clients != null)
            {
                for (var i = 1; i < clients.Count; i++)
                {
                    icid = new IncomeCallerId
                    {
                        PhoneNumber = phoneNumber,
                        Name = "IcId" + (i + 1)
                    };
                    last = (IncomeCallerId)_callers[_callers.Count - 1];
                    icid.Location = new Point(last.Location.X, last.Location.Y + last.Size.Height + 4);
                    icid.ShowClientCard += IcId1_ShowClientCard;
                    icid.SetAppointment += IcidSetAppointment;
                    icid.CreateNewClient += IcidCreateNewClient;
                    icid.LoadData(clients[i]);
                    if (!_showLinkToClientCard) icid.DisableLinkToClientCard();
                    pnlCallers.Controls.Add(icid);
                    _callers.Add(icid);
                }

                if (clients.Count < 2) count = clients.Count - 1;
                else count = 1;
            }

            // expand the form size according to the clients count (max 3 is visible)
            var height = (count * (IcId1.Height + 4));
            if (count > 1) height += 20;
            pnlCallers.Height += height;

            if (_table != null)
            {
                pnlCallLog.Visible = true;
                grdClients.DataSource = _table;
                pnlCallLog.Top = pnlCallers.Top + pnlCallers.Height;
                //height += pnlCallLog.Height + 8;
            }
            else
            {
                pnlCallLog.Visible = false;
            }
        }

        private void IcidCreateNewClient(object sender, NewClientEventArgs e)
        {
            if (CreateNewClient != null)
            {
                CreateNewClient(this, e);
                this.Close();
            }
        }

        private void IcidSetAppointment(object sender, SetAppointmentEventArgs e)
        {
            this.Hide();
            var args = new SetAppointmentEventArgs(e.ClientId) { PhoneNumber = _callerId };
            if (SetAppointment != null) SetAppointment(this, args);
            this.Close();
        }

        #endregion Private Functions

        #region Controls Event

        // close the form
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // when user press link, close the form and show client card
        private void IcId1_ShowClientCard(object sender, ShowClientCardEventArgs e)
        {
            if (ShowClientCard != null)
            {
                ShowClientCard(this, new ShowClientCardEventArgs(e.UserId));
                this.Close();
            }
        }

        #endregion Controls Event



        //private void grdClients_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    _imageLoader.BeginLoadImages(grdClients);
        //}

        private void FrmIncomingCallLoad(object sender, EventArgs e)
        {
            this.IcId1.CreateNewClient += IcidCreateNewClient;

            if (pnlCallLog.Visible)
            {
                this.Height = pnlCallLog.Top + pnlCallLog.Height + 55;
            }
            else
            {
                this.Height = pnlCallers.Top + pnlCallers.Height + 55;
            }

            lblCallerId.Left = label1.Right;
            lblCallerId.Width = this.Width - lblCallerId.Left;

            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
        }

        private void GrdClientsCellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var selectedId = Convert.ToInt32(grdClients.Rows[e.RowIndex].Cells["clmId"].Value);
            if (selectedId > 0)
            {
                if (ShowClientCard != null)
                {
                    ShowClientCard(this, new ShowClientCardEventArgs(selectedId));
                    this.Close();
                }
            }
        }

        private void GrdClients_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            _imageLoader.BeginLoadImages(grdClients);
        }
    }
}