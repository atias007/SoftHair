using System;
using System.Drawing;
using System.Windows.Forms;
using ClientManage.Interfaces;

namespace ClientManage.UserControls
{
    public partial class IncomeCallerId : UserControl
    {
        public event DlgShowClientCardEventHandler ShowClientCard;
        public event CreateNewClientEventHandler CreateNewClient;
        private string _phoneNumber = string.Empty;
        CallerIdPerson _person;

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set 
            { 
                _phoneNumber = value;
                btnNew.Visible = (_phoneNumber.Length > 0);
                btnSetApp2.Visible = btnNew.Visible;
            }
        }

        // open calendar and remember to attach client to the new appointment
        public event CalendarSetAppointmentEventHandler SetAppointment;

        public IncomeCallerId()
        {
            InitializeComponent();
        }

        public int UserId
        {
            get { return _person.Id; }
        }

        public void DisableLinkToClientCard()
        {
            btnShowCard.Enabled = false;
        }

        public void LoadData(CallerIdPerson person)
        {
            if (person == null) return;
            _person = person;
            lblName.Text = person.FullName;

            switch (person.Entity)
            {
                case CallerIdPerson.PersonEntity.Client:
                    lblAddress.Text = @"כתובת: " + person.Address + (person.Address.Length > 0 ? ", " : string.Empty) + person.City;
                    lblGender.Text = @"מין: " + (person.Gender == CallerIdPerson.PersonGender.Male ? "זכר" : "נקבה");
                    btnShowCard.Visible = true;
                    btnSetApp.Visible = true;
                    break;

                case CallerIdPerson.PersonEntity.Contact:
                    lblAddress.Text = @"חברה: " + person.Company;
                    lblGender.Text = @"תפקיד: " + person.JobTitle;
                    btnShowCard.Visible = false;
                    btnSetApp.Visible = false;
                    break;

                default:
                    return;
            }

            lblNoId.Visible = false;
            btnNew.Visible = false;

            try
            {
                picClient.BackgroundImage = Image.FromFile(person.Picture);
            }
            catch
            {
                picClient.BackgroundImage = Properties.Resources.no_image_big;
            }
        }

        private void IncomeCallerId_Paint(object sender, PaintEventArgs e)
        {
            var pen = new Pen(Color.FromArgb(192, 197, 203));
            e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, this.Width-1, this.Height-1));
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (_person.Entity == CallerIdPerson.PersonEntity.Client)
            {
                if (ShowClientCard != null) ShowClientCard(this, new ShowClientCardEventArgs(_person.Id));
            }
        }

        private void BtnSetAppointment_Click(object sender, EventArgs e)
        {
            if (_person.Entity == CallerIdPerson.PersonEntity.Client)
            {
                if (SetAppointment != null) SetAppointment(this, new SetAppointmentEventArgs(_person.Id));
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            if (CreateNewClient != null)
            {
                CreateNewClient(this, new NewClientEventArgs(_phoneNumber));
            }
        }

        private void PicClient_MouseDown(object sender, MouseEventArgs e)
        {
            if (_person == null) return;

            if (_person.Entity == CallerIdPerson.PersonEntity.Client)
            {
                if (ShowClientCard != null && !lblNoId.Visible)
                {
                    ShowClientCard(this, new ShowClientCardEventArgs(_person.Id));
                }
            }
        }

        private void BtnNew_VisibleChanged(object sender, EventArgs e)
        {
            btnSetApp2.Visible = btnNew.Visible;
        }

        private void BtnSetApp2_Click(object sender, EventArgs e)
        {
            if (_person == null)
            {
                if (SetAppointment != null) SetAppointment(this, new SetAppointmentEventArgs(-1));
            }
        }
    }
}
