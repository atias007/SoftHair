using System;
using System.Windows.Forms;
using ClientManage.BL;
using ClientManage.Interfaces;
using ClientManage.BL.Library;

namespace ClientManage.Forms
{
    public partial class FormLicense : BasePopupForm
    {
        private DialogResult _result = DialogResult.OK;
        private CustomerLicense _license = null;

        // initialize components and variables
        public FormLicense(CustomerLicense license)
        {
            InitializeComponent();
            _license = license;
        }

        // property, hold the expire days that remain in license

        // initialize form text according license validation result
        private void FrmLicence_Load(object sender, EventArgs e)
        {
            Height -= panel1.Height;
            CenterMe();
            var msg = string.Empty;

            switch (_license.Status)
            {
                case LicenseStatus.None:
                case LicenseStatus.Block:
                    msg = "קובץ הרשיון של התוכנה חסר או פגום,\nאי לכך ובהתאם לזאת לא תוכל להמשיך להפעילה.";
                    button2.Enabled = false;
                    break;

                case LicenseStatus.OutOfDate:
                    msg = "תאריך רשיון התוכנה שברשותך פג והוא אינו בתוקף,  אי לכך ובהתאם לזאת לא תוכל להמשיך להפעילה.";
                    break;

                case LicenseStatus.Valid:

                    if (_license.ExpireDays > 1)
                    {
                        msg = "שים לב! תאריך רשיון התוכנה שברשותך יפוג בעוד...   " + _license.ExpireDays + " ימים";
                    }
                    else if (_license.ExpireDays == 1)
                    {
                        msg = "שים לב! תאריך רשיון התוכנה שברשותך יפוג היום.   ממחר לא תוכל להפעילה...   ";
                    }
                    break;
            }

            lblInfo.Text = msg;
            lblManager.Text = AppSettingsHelper.GetParamValue("APP_SYSTEM_MGR");
            txtCpuId.Text = Security.CpuId;

            licenseInfo1.ShowLicenseInfo(_license);
        }

        // show message box with license details
        private void Button2_Click(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                panel1.Visible = false;
                this.Height -= panel1.Height;
                this.Refresh();
                button2.Text = "הצג פרטי רשיון...";
            }
            else
            {
                panel1.Visible = true;
                this.Height += panel1.Height;
                this.Refresh();
                button2.Text = "הסתר פרטי רשיון";
            }

            base.CenterMe();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLicence_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = _result;
        }
    }
}