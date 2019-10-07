using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ClientManage.Interfaces;

namespace ClientManage.Forms
{
    public partial class FormClientsPopup : BasePopupForm
    {
        private readonly FormClients _fClients;
        private bool _isTerminate;

        public event ClientOperationEventHandler ClientUpdated;
        public event ClientOperationEventHandler RequestForUpdateClient;
        public event DialRequestEventHandler DialRequest;
        public event OpenFormEventHandler OpenForm;
        public event CalendarSetAppointmentEventHandler SetAppointment;
        public event EventHandler RefreshCalendar;
        public event EventHandler NavigateNextClient;
        public event EventHandler NavigatePreviousClient;
        public event EventHandler SyncClients;
        //public event ClientOperationEventHandler RefreshClient;

        public FormClientsPopup(int id)
        {
            InitializeComponent();
            _fClients = new FormClients(id, true);
        }

        public void SetNavigateParameters(DataTable dataSource, int currentIndex)
        {
            _fClients.SetNavigateParameters(dataSource, currentIndex);
        }

        public FormClients.FormStatus Status
        {
            get 
            { 
                return _fClients.Status; 
            }
        }
        public bool AllowNavigation
        {
            get { return _fClients.AllowNavigation; }
            set { _fClients.AllowNavigation = value; }
        }

        public Client Client
        {
            get { return _fClients.Client; }
        }

        public bool CalendarEnabled
        {
            get { return _fClients.CalendarEnabled; }
            set { _fClients.CalendarEnabled = value; }
        }

        public void RefreshNavigateData()
        {
            _fClients.RefreshNavigateData();
        }

        public void RefreshData()
        {
            _fClients.RefreshData();
        }

        public void RefreshData(int userId)
        {
            _fClients.RefreshData(userId);
        }

        public void TerminateForm()
        {
            _isTerminate = true;
            this.Close();
        }

        private void frmClientsPopUp_Load(object sender, EventArgs e)
        {
            this.Size = new Size(872, 678);
            this.CenterMe();
            _fClients.TopLevel = false;
            _fClients.Dock = DockStyle.Fill;
            _fClients.ClientUpdated += fClients_ClientUpdated;
            _fClients.OpenForm += fClients_OpenForm;
            _fClients.SetAppointment += fClients_SetAppointment;
            _fClients.RefreshCalendar += fClients_RefreshCalendar;
            _fClients.RequestForUpdateClient += fClients_RequestForUpdateClient;
            _fClients.NavigateNextClient += fClients_NavigateNextClient;
            _fClients.NavigatePreviousClient += fClients_NavigatePrevClient;
            _fClients.CloseMe += fClients_CloseMe;
            _fClients.SyncClients += FClientsSyncClients;
            _fClients.DialRequest += fClients_DialRequest;
            this.Controls.Add(_fClients);
            _fClients.Show();
            _fClients.Select();
        }

        void FClientsSyncClients(object sender, EventArgs e)
        {
            if (SyncClients != null) SyncClients(this, e);
        }

        void fClients_DialRequest(object sender, DialRequestEventArgs e)
        {
            e.Entity = 0;
            if (DialRequest != null) DialRequest(this, e);
        }

        void fClients_CloseMe(object sender, EventArgs e)
        {
            this.Hide();
        }

        void fClients_NavigatePrevClient(object sender, EventArgs e)
        {
            if (NavigatePreviousClient != null) NavigatePreviousClient(this, e);
        }

        void fClients_NavigateNextClient(object sender, EventArgs e)
        {
            if (NavigateNextClient != null) NavigateNextClient(this, e);
        }

        void fClients_RequestForUpdateClient(object sender, ClientOperationEventArgs e)
        {
            if (RequestForUpdateClient != null) RequestForUpdateClient(sender, e);
        }

        void fClients_ClientUpdated(object sender, ClientOperationEventArgs e)
        {
            if (ClientUpdated != null) ClientUpdated(this, e);
        }

        void fClients_RefreshCalendar(object sender, EventArgs e)
        {
            this.Close();
            if (RefreshCalendar != null) RefreshCalendar(sender, e);
        }

        void fClients_SetAppointment(object sender, SetAppointmentEventArgs e)
        {
            this.Close();
            if (SetAppointment != null) SetAppointment(sender, e);
        }

        void fClients_OpenForm(object sender, OpenFormEventArgs e)
        {
            if(e.FormName != "frmPhotoAlbum") this.Close();
            if (OpenForm != null) OpenForm(sender, e);
        }

        private void frmClientsPopUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isTerminate)
            {
                _fClients.CancelEdit();
                this.Hide();
                e.Cancel = true;
            }
        }
    }
}

