using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SoftHairQuickLanch.Library;
using SoftHairQuickLanch.Properties;
using SoftHairQuickLanch.SmsFactory;
using Application = System.Windows.Forms.Application;

namespace SoftHairQuickLanch.Forms
{
    public partial class FrmSupport2 : Form
    {
        private readonly Color _errorColor = Color.FromArgb(255, 192, 192);
        private readonly SupportParameters _settings;
        private bool _isAdminKey;
        private bool _isFormTextChanged;

        public FrmSupport2()
        {
            InitializeComponent();
            _settings = new SupportParameters();

            txtPhone.Text = _settings.PhoneNo;
        }

        private void CreateMessageFile()
        {
            var filename = Path.Combine(Application.StartupPath, "LastSupportRequest.txt");
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(filename, true, Encoding.Default);
                writer.WriteLine(string.Empty.PadLeft(80, '-'));
                writer.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm") + ", Client ID: " + _settings.ClientId + ", Client Name: " + _settings.ClientName);
                writer.WriteLine(string.Empty.PadLeft(80, '-'));
                writer.WriteLine(_settings.Remark);                
                writer.WriteLine();                
            }
            catch { }
            finally
            {
                if (writer != null) writer.Close();
            }
        }

        private ValidationResult ValidateForm()
        {
            var res = new ValidationResult();

            txtPhone.Text = txtPhone.Text.Trim();
            txtRemark.Text = txtRemark.Text.Trim();

            var phone = txtPhone.Text.Replace(" ", string.Empty).Replace("-", string.Empty);

            if (string.IsNullOrEmpty(phone))
            {
                res.Add("אנא הזן את השדה טלפון לחזרה, זהו שדה חובה");
            }
            else
            {
                if (phone.Length < 9 || phone.Length > 10)
                {
                    res.Add("השדה טלפון אינו תקין, אנא הזן מחדש");
                    txtPhone.BackColor = _errorColor;
                }
            }

            if (string.IsNullOrEmpty(txtRemark.Text))
            {
                res.Add("אנא הזן את השדה תיאור התקלה, זהו שדה חובה");
                txtRemark.BackColor = _errorColor;
            }

            return res;
        }

        private void TxtPhoneKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar != '\b' && e.KeyChar != ' ' && e.KeyChar != '-')
                {
                    e.Handled = true;
                }
            }
        }

        private void TxtPhoneEnter(object sender, EventArgs e)
        {
            if (((TextBox)sender).ReadOnly) return;
            ((TextBox)sender).BackColor = Color.LemonChiffon;
        }

        private void TxtPhoneLeave(object sender, EventArgs e)
        {
            if (((TextBox)sender).ReadOnly) return;
            ((TextBox)sender).BackColor = Color.White;
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisableForm()
        {
            btnSend.Text = "  אנא המתן...";
            btnSend.Enabled = false;
            btnCancel.Enabled = false;
            txtPhone.ReadOnly = true;
            txtRemark.ReadOnly = true;
            txtPhone.BackColor = Color.White;
            txtRemark.BackColor = Color.White;
            Application.DoEvents();
        }

        private void EnableForm()
        {
            btnSend.Text = "  שלח קריאה";
            btnSend.Enabled = true;
            btnCancel.Enabled = true;
            txtPhone.ReadOnly = false;
            txtRemark.ReadOnly = false;
            Application.DoEvents();
        }

        private void FrmSupport2Load(object sender, EventArgs e)
        {
            if (DateTime.Now.AddHours(-1) < _settings.LastCall)
            {
                var message = "לא ניתן לפתוח קריאת שירות!\n\nקיימת קריאת שירות פתוחה משעה: " +
                    _settings.LastCall.ToShortTimeString() + "\nנציגנו יצרו עמך קשר בהקדם האפשרי.";

                ShowWarningMessage(message);
            }
            else
            {
                if (string.IsNullOrEmpty(txtPhone.Text))
                {
                    txtPhone.Select();
                    txtPhone.Focus();
                }
                else
                {
                    txtRemark.Select();
                    txtRemark.Focus();
                }
            }
        }

        private void Label2Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(230, 230, 230)), 0, 0, label2.Width - 1, label2.Height - 1);
        }

        private void SendProcess()
        {
            _settings.PhoneNo = txtPhone.Text;
            _settings.Remark = txtRemark.Text;

            var text = string.Format("{0} {1}", _settings.Remark, _settings.PhoneNo);
            var server = new CommonServicesClient();

            if (string.IsNullOrEmpty(_settings.CustomerUniqueId))
            {
                _settings.CustomerUniqueId = Resources.UniqueId;
            }

            try
            {
                server.ReportCustomerServiceCall(new UserCredentials { Username = Resources.Username, Password = Resources.Password }, _settings.CustomerUniqueId, text);
            }
            catch
            {
                server.ReportCustomerServiceCall(new UserCredentials { Username = Resources.Username, Password = Resources.Password }, Resources.UniqueId, text);
            }
        }

        private void BtnSendClick(object sender, EventArgs e)
        {
            var res = ValidateForm();
            if (res.Count > 0)
            {
                ShowErrorMessage(res.ToString());
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                DisableForm();
                Application.DoEvents();

                try
                {
                    SendProcess();

                    _settings.LastCall = DateTime.Now;
                    CreateMessageFile();
                    panel1.BringToFront();
                    panel1.Top = 92;
                    panel1.Left = 7;
                    panel1.Visible = true;
                }
                catch (Exception)
                {
                    ShowErrorMessage("שגיאה בשליחת קריאת השירות!\n\nאנא ודא כי הנך מחובר לרשת האינטרנט");
                    EnableForm();
                }

                this.Cursor = Cursors.Default;
            }
        }

        private void BtnConfirmClick(object sender, EventArgs e)
        {
            pnlError.Visible = false;
        }

        private void ShowErrorMessage(string message)
        {
            pnlError.BringToFront();
            pnlError.Top = 92;
            pnlError.Left = 7;
            lblErrorMsgText.Text = message;
            pnlError.Visible = true;
            btnConfirm.Select();
        }

        private void ShowWarningMessage(string message)
        {
            pnlWarning.BringToFront();
            pnlWarning.Top = 92;
            pnlWarning.Left = 7;
            lblWarnMsg.Text = message;
            pnlWarning.Visible = true;
            btnWarnOk.Select();
        }

        private void FrmSupport2KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Shift && !e.Control && !e.Alt)
            {
                if (e.KeyCode == Keys.F1 && _isAdminKey)
                {
                    timer1.Enabled = false;
                    _isAdminKey = false;
                    panel1.Visible = false;
                    pnlWarning.Visible = false;
                    _settings.LastCall = DateTime.MinValue;
                }
            }
            else if (e.Shift && e.Control && !e.Alt)
            {
                if (e.KeyCode == Keys.F1)
                {
                    _isAdminKey = true;
                    timer1.Enabled = true;
                }
            }
        }

        private void BtnWarnOkClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Timer1Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            _isAdminKey = false;
        }

        private void Label1Click(object sender, EventArgs e)
        {
            if (!_isFormTextChanged)
            {
                _isFormTextChanged = true;
                this.Text += " - " + _settings.ClientName + " (" + _settings.ClientId + ")";
            }
        }
    }
}