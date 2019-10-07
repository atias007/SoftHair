using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace SoftHairQuickLanch
{
    public partial class frmSupport : Form
    {
        private readonly XmlDocument _doc = null;
        private readonly Settings _settings;
        private readonly Color _errorColor = Color.FromArgb(255, 192, 192);

        public frmSupport(XmlDocument doc)
        {
            InitializeComponent();
            RelocateForm();
            _doc = doc;
            _settings = new Settings(_doc);

            txtId.Text = _settings.ID;
            txtPhone.Text = _settings.PhoneNo;
        }

        public void RelocateForm()
        {
            this.Left = ((Screen.PrimaryScreen.Bounds.Width - 280) / 2) - this.Width;
            this.Top = ((Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
        }

        private void SaveFile()
        {
            try
            {
                var filename = Path.Combine(Application.StartupPath, "QuickLaunch.xml");
                _doc.Save(filename);
            }
            catch { }
        }

        private void btnSend_Click(object sender, EventArgs e)
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
                    if (SendProcess())
                    {                        
                        panel1.BringToFront();
                        panel1.Top = 106;
                        panel1.Left = 7;
                        panel1.Visible = true;
                    }
                    else
                    {
                        ShowErrorMessage("השליחה נכשלה, אנא נסה שוב");
                        EnableForm();
                    }
                }
                catch (Exception)
                {
                    ShowErrorMessage("שגיאה בשליחת קריאת השירות!\n\nאנא ודא כי הנך מחובר לרשת האינטרנט");
                    EnableForm();
                }

                this.Cursor = Cursors.Default;
            }
        }

        private void CreateMessageFile()
        {
            var filename = Path.Combine(Application.StartupPath, "LastSupportRequest.txt");
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(filename, false, Encoding.Default);
                writer.WriteLine(_settings.ToString());
                writer.WriteLine();
                writer.WriteLine(_settings.Remark);
            }
            catch { }
            finally
            {
                if (writer != null) writer.Close();
            }
        }

        private bool SendProcess()
        {
            
            if (_settings.Credit > 0)
            {
                
            }
            else
            {
                throw new Exception("אין מספיק הודעות בחשבון לשליחת הקריאה");
            }

            return false;
        }

        private ValidationResult ValidateForm()
        {
            var res = new ValidationResult();
            string phone, id;

            txtId.Text = txtId.Text.Trim();
            txtPass.Text = txtPass.Text.Trim();
            txtPhone.Text = txtPhone.Text.Trim();
            txtRemark.Text = txtRemark.Text.Trim();

            id = txtId.Text.Replace(" ", string.Empty);
            phone = txtPhone.Text.Replace(" ", string.Empty).Replace("-", string.Empty);

            if (string.IsNullOrEmpty(txtId.Text))
            {
                res.Add("אנא הזן את השדה ID, זהו שדה חובה");
                txtId.BackColor = _errorColor;
            }
            else if (id.Length < 6 || id.Contains("."))
            {
                res.Add("השדה ID אינו תקין, אנא הזן מחדש");
                txtId.BackColor = _errorColor;
            }

            if (string.IsNullOrEmpty(txtPass.Text))
            {
                res.Add("אנא הזן את השדה Password, זהו שדה חובה");
                txtPass.BackColor = _errorColor;
            }
            else if (txtPass.Text.Length < 4)
            {
                res.Add("השדה Password אינו תקין, אנא הזן מחדש");
                txtId.BackColor = _errorColor;
            }

            if (string.IsNullOrEmpty(phone))
            {
                res.Add("אנא הזן את השדה טלפון, זהו שדה חובה");
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

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
               if (e.KeyChar != '\b' && e.KeyChar != ' ' && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar != '\b' && e.KeyChar != ' ' && e.KeyChar != '-')
                {
                    e.Handled = true;
                }
            }
        }

        private void txtPhone_Enter(object sender, EventArgs e)
        {
            if (((TextBox)sender).ReadOnly) return;
            ((TextBox)sender).BackColor = Color.LemonChiffon;
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).ReadOnly) return;
            ((TextBox)sender).BackColor = Color.White;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSupport_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                txtId.Select();
                txtId.Focus();
            }
            else
            {
                txtPass.Select();
                txtPass.Focus();
            }
        }

        private void DisableForm()
        {
            btnSend.Enabled = false;
            txtId.ReadOnly = true;
            txtPass.ReadOnly = true;
            txtPhone.ReadOnly = true;
            txtRemark.ReadOnly = true;
        }

        private void EnableForm()
        {
            btnSend.Enabled = true;
            txtId.ReadOnly = false;
            txtPass.ReadOnly = false;
            txtPhone.ReadOnly = false;
            txtRemark.ReadOnly = false;
        }

        private void frmSupport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.Control && !e.Alt)
            {
                if (e.KeyCode == Keys.F1)
                {
                    panel1.Visible = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlError.Visible = false;
        }

        private void ShowErrorMessage(string message)
        {
            pnlError.BringToFront();
            pnlError.Top = 106;
            pnlError.Left = 7;
            lblErrorMsgText.Text = message;
            pnlError.Visible = true;
        }
    }
}