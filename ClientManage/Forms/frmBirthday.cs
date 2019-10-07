using System;
using System.Data;
using System.Windows.Forms;
using ClientManage.BL;
using ClientManage.Interfaces;
using ClientManage.Library;

namespace ClientManage.Forms
{
    public partial class FormBirthday : BasePopupForm
    {
        #region Private

            #region Private Memebers
        
        private enum EntityType { Birthday, MarriedDate };
        
            #endregion

            #region Private Functions
            #endregion

        #endregion

        #region Public

            #region Events

        // fire event when user select client from list and press the button or dubble click it in list
        public event DlgShowClientCardEventHandler ShowClientCard;

        // fire event when user press button that close this form and open the report of "today birthday clients"
        public event EventHandler<ShowReportEventArgs> ShowReport;

        public event OpenFormEventHandler OpenForm;


            #endregion

            #region Properties
            #endregion

        #endregion

        #region Constructor

        // initialize controls on form
        public FormBirthday(DataTable clients, DataTable marriedClients)
        {
            InitializeComponent();

            bool isBday = false, isMarried = false;

            if (clients.Rows.Count > 0)
            {
                listBox1.DataSource = clients;
                listBox1.DisplayMember = "full_name";
                listBox1.ValueMember = "id";
                listBox1.SelectedIndex = -1;
                lblInfo1.Text = string.Format(lblInfo1.Text, listBox1.Items.Count);
                isBday = true;
            }
            else
            {
                pnlBday.Visible = false;
                lblDiv.Visible = false;
            }

            if (marriedClients.Rows.Count > 0)
            {
                listBox2.DataSource = marriedClients;
                listBox2.DisplayMember = "full_name";
                listBox2.ValueMember = "id";
                listBox2.SelectedIndex = -1;
                lblInfo2.Text = string.Format(lblInfo2.Text, listBox2.Items.Count);
                isMarried = true;
            }
            else
            {
                pnlMarried.Visible = false;
                lblDiv.Visible = false;
            }

            var height = (isBday ? pnlBday.Height : 0) +
                    (isMarried ? pnlMarried.Height : 0) +
                    ((isBday && isMarried) ? lblDiv.Height : 0) + 
                    this.Padding.Top + this.Padding.Bottom;

            this.Height = height;            
        }

        #endregion

        #region Controls Event

        // open the selected client card without closing this form
        private void ShowClient(int id)
        {
            if (ShowClientCard != null)
            {
                ShowClientCard(this, new ShowClientCardEventArgs(id));
            }
        }

        #endregion

        // open the selected client card without closing this form
        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                if (listBox1.SelectedValue is int)
                {
                    listBox2.SelectedIndex = -1;
                    ShowClient((int)listBox1.SelectedValue);
                }
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            // close this form & open report of "today birthday clients"
            this.Cursor = Cursors.WaitCursor;

            if (ShowReport != null)
            {
                ShowReport(this, new ShowReportEventArgs("לקוחות", 10003, new object[] { DateTime.Now.Day, DateTime.Now.Month }));
            }

            this.Cursor = Cursors.Default;
        }

        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                if (listBox2.SelectedValue is int)
                {
                    listBox1.SelectedIndex = -1;
                    ShowClient((int)listBox2.SelectedValue);
                }
            }
        }

        private void XpFlatButton2_Click(object sender, EventArgs e)
        {
            // close this form & open report of "today birthday clients"
            this.Cursor = Cursors.WaitCursor;

            if (ShowReport != null)
            {
                ShowReport(this, new ShowReportEventArgs("לקוחות", 10031, new object[] { DateTime.Now.Day, DateTime.Now.Month }));
            }

            this.Cursor = Cursors.Default;
        }

        private void BtnBdaySms_Click(object sender, EventArgs e)
        {
            ShowSmsForm(EntityType.Birthday);
        }

        private void ShowSmsForm(EntityType type)
        {
            this.Cursor = Cursors.WaitCursor;
            var key = (type== EntityType.Birthday ? "SMS_BIRTHDAY_PARAMS" : "SMS_MARRIED_PARAMS");
            const string msg2 = "תזכורת יום הולדת ויום נישואין...";
            var smsParams = new AutoSmsParameters(AppSettingsHelper.GetParamValue(key));

            // alert if sms already sent today
            if (smsParams.LastSubmit.Date == DateTime.Now.Date)
            {
                var msg1 = "הודעת SMS נשלחה כבר היום בשעה: " + smsParams.LastSubmit.ToShortTimeString() + "\nהאם אתה בטוח שברצונך לשלוח הודעה נוספת?";
                MyMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo);
                if (MyMessageBox.Show(this) == DialogResult.No)
                {
                    this.Cursor = Cursors.Default;
                    return;
                }
            }

            // get clients data from database
            var ids = Utils.GetDataSourceIds(type == EntityType.Birthday ? (DataTable)listBox1.DataSource : (DataTable)listBox2.DataSource);
            var table = ReportHelper.GetClientsCellPhones(ids);
            var list = General.TableToPostAddresseeList(table);

            // open manual SMS form
            if (OpenForm != null)
            {
                var args = new OpenFormEventArgs("frmSMS", list) {Id = smsParams.MessageId};
                OpenForm(this, args);
            }

            this.Cursor = Cursors.Default;
        }

        private void XpFlatButton1_Click(object sender, EventArgs e)
        {
            ShowSmsForm(EntityType.MarriedDate);
        }

        private void FrmBirthday_RequestForClose(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}