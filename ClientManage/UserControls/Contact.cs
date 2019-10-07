using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ClientManage.BL;
using ClientManage.Interfaces;
using System.Security.Permissions;

namespace ClientManage.UserControls
{
    public partial class Contact : UserControl
    {
        public event EventHandler RequestForUpdate;
        public event OpenFormEventHandler OpenForm;
        public event EventHandler ContactTabbedNext;
        public event EventHandler ContactTabbedPrevious;
        public event EventHandler<ContactSelectedMoveEventArgs> ContactSelectedMove;

        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _jobCompany = string.Empty;
        private string _email = string.Empty;
        private string _phoneNo1 = string.Empty;
        private string _phoneNo2 = string.Empty;
        private string _phoneNo3 = string.Empty;
        private string _fax = string.Empty;
        private string _street = string.Empty;
        private string _city = string.Empty;
        private string _zipCode = string.Empty;
        private string _mailCellNo = string.Empty;
        private bool _selected = false;
        private static bool _lastNameBefore = false;

        Pen pen1;
        Rectangle rect1, rect2, rect3, rect4;
        LinearGradientBrush brush1, brush2, brush3, brush4;

        
        public Contact()
        {
            InitializeComponent();
            InitGraphics();
        }

        private void InitGraphics()
        {
            rect1 = new Rectangle(0, 0, 249, 16);
            rect2 = new Rectangle(1, 1, 248, 5);
            rect3 = new Rectangle(1, 6, 248, 10);
            rect4 = new Rectangle(0, 0, this.Width - 6, this.Height - 6);
//            rect5 = new Rectangle(249, 6, 5, 160);
//            rect6 = new Rectangle(5, 166, 244, 5);

            pen1 = new Pen(Color.FromArgb(101, 147, 207));
            brush1 = new LinearGradientBrush(rect2, Color.FromArgb(255, 212, 159), Color.FromArgb(255, 190, 116), LinearGradientMode.Vertical);
            brush2 = new LinearGradientBrush(rect3, Color.FromArgb(255, 171, 63), Color.FromArgb(254, 122, 170), LinearGradientMode.Vertical);
            brush3 = new LinearGradientBrush(rect2, Color.FromArgb(222, 236, 255), Color.FromArgb(200, 223, 255), LinearGradientMode.Vertical);
            brush4 = new LinearGradientBrush(rect3, Color.FromArgb(172, 209, 255), Color.FromArgb(192, 219, 255), LinearGradientMode.Vertical);
        }

        public bool Selected
        {
            get { return _selected; }
            set 
            {
                if (_selected != value)
                {
                    _selected = value;

                    if (_selected) lblSelected.Image = global::ClientManage.Properties.Resources.phone_book_header2;
                    else lblSelected.Image = null;
                }
            }
        }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                //lblName.Text = value;
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                //lblName.Text = value;
            }
        }
        public string JobCompany
        {
            get { return _jobCompany; }
            set 
            {
                _jobCompany = value;
                //lblDetails.Text = value;
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                //lnkEmail.Text = value;
            }
        }
        public string PhoneNo1
        {
            get { return _phoneNo1; }
            set { _phoneNo1 = value; }
        }
        public string PhoneNo2
        {
            get { return _phoneNo2; }
            set { _phoneNo2 = value; }
        }
        public string PhoneNo3
        {
            get { return _phoneNo3; }
            set { _phoneNo3 = value; }
        }
        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }
        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public string ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; }
        }
        public string MailCellNo
        {
            get { return _mailCellNo; }
            set { _mailCellNo = value; }
        }

        public int Id { get; set; }

        public static bool LastNameBefore
        {
            get { return _lastNameBefore; }
            set { _lastNameBefore = value; }
        }

        private void Contact_MouseDown(object sender, MouseEventArgs e)
        {
            this.Selected = true;
            this.Select();
        }

        public void ShowData()
        {
            SetFlowControls();
            if (_lastNameBefore) lblName.Text = _lastName + " " + _firstName;
            else lblName.Text = FullName;
            lnkEmail.Text = _email;

            LoadField(_phoneNo1, lblCellPhone, lblCellPhoneCap);
            LoadField(_phoneNo2, lblWorkPhone, lblWorkPhoneCap);
            LoadField(_phoneNo3, lblHomePhone, lblHomePhoneCap);
            LoadField(_fax, lblFax, lblFaxCap);

            lblAddress1.Text = _street;
            lblAddress1.Visible = (lblAddress1.Text.Length > 0);

            var city = _city;

            if (_zipCode.Length > 0)
            {
                city += ", " + _zipCode;
                if (string.IsNullOrEmpty(_city)) city = "(ללא עיר)" + city;
            }

            if (_mailCellNo.Length > 0)
            {
                city += ", ת.ד. " + MailCellNo;
            }

            if (city.StartsWith(", ")) city = city.Substring(2);
            lblAddress2.Text = city;
            lblAddress2.Visible = (lblAddress2.Text.Length > 0);

            lblSelected.Text = _jobCompany.Trim();
            if (lblSelected.Text.EndsWith("-"))
                lblSelected.Text = lblSelected.Text.Substring(0, lblSelected.Text.Length - 1).Trim();
            if (lblSelected.Text.StartsWith("-"))
                lblSelected.Text = lblSelected.Text.Substring(1).Trim();
        }

        private void LoadField(string field, Label lblField, Label lblCaption)
        {
            var show = (field.Length > 0);
            lblField.Visible = show;
            lblCaption.Visible = show;
            lblField.Text = field;
        }

        private void FlowControl_SizeOrLocationChanged(object sender, EventArgs e)
        {
            var src = (Control)sender;
            var tar = (Control)((Control)sender).Tag;
            if (src == null || tar == null) return;
            var height = src.Visible ? src.Height : 0;
            tar.Top = src.Top + height;
        }
        private void CreateFlowControl(Control source, Control target)
        {
            source.Tag = target;
            source.SizeChanged += new EventHandler(FlowControl_SizeOrLocationChanged);
            source.LocationChanged += new EventHandler(FlowControl_SizeOrLocationChanged);
            source.VisibleChanged += new EventHandler(FlowControl_SizeOrLocationChanged);
        }

        private void SetFlowControls()
        {
            CreateFlowControl(lblCellPhone, lblWorkPhone);
            CreateFlowControl(lblWorkPhone, lblHomePhone);
            CreateFlowControl(lblHomePhone, lblFax);

            CreateFlowControl(lblCellPhoneCap, lblWorkPhoneCap);
            CreateFlowControl(lblWorkPhoneCap, lblHomePhoneCap);
            CreateFlowControl(lblHomePhoneCap, lblFaxCap);

            CreateFlowControl(lblFax, lblSpace);
            CreateFlowControl(lblSpace, lblAddress1);
            CreateFlowControl(lblAddress1, lblAddress2);
            CreateFlowControl(lblAddress2, lblSpace2);
            CreateFlowControl(lblSpace2, lnkEmail);
        }

        private void lnkEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var name = FullName;
            var mail = lnkEmail.Text;

            if (OpenForm != null)
            {
                this.Cursor = Cursors.WaitCursor;

                var table = new DataTable();
                table.Columns.Add("full_name", typeof(string));
                table.Columns.Add("email", typeof(string));

                table.Rows.Add(name, mail);

                OpenForm(this, new OpenFormEventArgs("frmMailCampaign", table));

                this.Cursor = Cursors.Default;
            }
        }

        private void Contact_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (RequestForUpdate != null) RequestForUpdate(this, new EventArgs());
        }

        private void Contact_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen1, rect1);
            e.Graphics.FillRectangle(brush3, rect2);
            e.Graphics.FillRectangle(brush4, rect3);
            e.Graphics.DrawRectangle(pen1, rect4);

            e.Graphics.DrawImage(global::ClientManage.Properties.Resources.ccard_botom_shaddow, 0, 166);
            e.Graphics.DrawImage(global::ClientManage.Properties.Resources.ccard_right_shaddow, 250, 0);
            e.Graphics.DrawImage(global::ClientManage.Properties.Resources.ccard_logo, 1, 17);
        }

        public string GetPrintHtml()
        {
            var template = AppSettingsHelper.GetPrintTemplate("CONTACT_CARD_TEMPLATE");
            var parameters = new string[13];

            parameters[0] = lblSelected.Text;
            parameters[1] = lblName.Text;
            parameters[2] = lblCellPhone.Text;
            parameters[3] = lblCellPhoneCap.Visible ? lblCellPhoneCap.Text : string.Empty;
            parameters[4] = lblWorkPhone.Text;
            parameters[5] = lblWorkPhoneCap.Visible ? lblWorkPhoneCap.Text : string.Empty;
            parameters[6] = lblHomePhone.Text;
            parameters[7] = lblHomePhoneCap.Visible ? lblHomePhoneCap.Text : string.Empty;
            parameters[8] = lblFax.Text;
            parameters[9] = lblFaxCap.Visible ? lblFaxCap.Text : string.Empty;
            parameters[10] = lblAddress1.Text;
            parameters[11] = lblAddress2.Text;
            parameters[12] = lnkEmail.Text + "&nbsp;";

            var html = string.Format(template, parameters);
            return html;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;

            if ((msg.Msg == WM_KEYDOWN) || msg.Msg == WM_SYSKEYDOWN)
            {
                switch (keyData)
                {
                    case Keys.Left:
                        if (ContactSelectedMove != null) ContactSelectedMove(this, new ContactSelectedMoveEventArgs(ContactSelectedMoveEventArgs.DirectionType.Left));
                        return true;

                    case Keys.Right:
                        if (ContactSelectedMove != null) ContactSelectedMove(this, new ContactSelectedMoveEventArgs(ContactSelectedMoveEventArgs.DirectionType.Right));
                        return true;

                    case Keys.Down:
                        if (ContactSelectedMove != null) ContactSelectedMove(this, new ContactSelectedMoveEventArgs(ContactSelectedMoveEventArgs.DirectionType.Down));
                        return true;

                    case Keys.Up:
                        if (ContactSelectedMove != null) ContactSelectedMove(this, new ContactSelectedMoveEventArgs(ContactSelectedMoveEventArgs.DirectionType.Up));
                        return true;

                    case Keys.Tab:
                        if (ContactTabbedNext != null) ContactTabbedNext(this, new EventArgs());
                        return true;

                    case Keys.Shift | Keys.Tab:
                        if (ContactTabbedPrevious != null) ContactTabbedPrevious(this, new EventArgs());
                        return true;

                    case Keys.Enter:
                        if (RequestForUpdate != null) RequestForUpdate(this, new EventArgs());
                        return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Contact_Enter(object sender, EventArgs e)
        {
            lblFocus.Select();
        }

        public string FullName
        {
            get
            {
                var name = _firstName + " " + _lastName;
                return name.Trim();
            }
        }
    }
}
