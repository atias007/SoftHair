using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClientManage.BL.Library;
using ClientManage.Interfaces;
using ClientManage.BL;
using ClientManage.Library;

namespace ClientManage.Forms
{
    public partial class FormDialForm : ClientManage.Forms.BasePopupForm
    {
        private readonly DialRequestEventArgs _arg = null;
        private readonly ComPort _cid = null;

        public event DialRequestEventHandler AddDialCallLog;

        public FormDialForm(DialRequestEventArgs arg, ComPort cid)
        {
            InitializeComponent();

            _arg = arg;
            _cid = cid;

            lblPhoneNo.Text = _arg.PhoneNo;
            lblName.Text = "שם הנמען: " + (_arg.Name.Length == 0 ? "ללא שם" : _arg.Name);
            _cid.CommIncomeData += new ComPort.CommCallHandler(_cid_CommIncomeData);
        }

        private void _cid_CommIncomeData(object sender, CommCallEventArgs e)
        {
            if (this.IsDisposed) return;

            MethodInvoker mi;
            switch (e.Type)
            {
                case CommCallEventArgs.CommCallEventType.NoAnswer:
                case CommCallEventArgs.CommCallEventType.NoCarrier:
                    DisconnectCall();
                    mi = new MethodInvoker(NoCarrierAction);
                    this.Invoke(mi);
                    break;

                case CommCallEventArgs.CommCallEventType.Busy:
                    DisconnectCall();
                    mi = new MethodInvoker(BusyAction);
                    this.Invoke(mi);
                    break;

                case CommCallEventArgs.CommCallEventType.NoDialTone:
                    mi = new MethodInvoker(NoDialToneAction);
                    this.Invoke(mi);
                    break;

                case CommCallEventArgs.CommCallEventType.Connect:
                    mi = new MethodInvoker(ConnectAction);
                    this.Invoke(mi);
                    break;

                case CommCallEventArgs.CommCallEventType.Error:
                    mi = new MethodInvoker(ErrorAction);
                    this.Invoke(mi);
                    break;

                default:
                    break;
            }
        }

        private void NoCarrierAction()
        {
            lblStatus.Text = "אין מענה";
            btnRedial.Enabled = true;
            btnHangUp.Enabled = false;
        }

        private void BusyAction()
        {
            lblStatus.Text = "הקו תפוס";
            btnRedial.Enabled = true;
            btnHangUp.Enabled = false;
        }

        private void NoDialToneAction()
        {
            lblStatus.Text = "אין צליל חיוג";
            btnRedial.Enabled = true;
            btnHangUp.Enabled = false;
        }

        private void ErrorAction()
        {
            lblStatus.Text = "שגיאה";
            btnRedial.Enabled = true;
            btnHangUp.Enabled = false;
        }

        private void ConnectAction()
        {
            lblStatus.Text = "מחובר";
        }

        private void frmDialForm_Load(object sender, EventArgs e)
        {
            CenterMe();
            btnRedial_Click(null, null);
        }

        private void btnHangUp_Click(object sender, EventArgs e)
        {
            DisconnectCall();
            lblStatus.Text = "מנתק שיחה...";
            btnHangUp.Enabled = false;
        }

        private void btnRedial_Click(object sender, EventArgs e)
        {
            btnHangUp.Enabled = true;
            lblStatus.Text = "מחייג כעת...";

            var phone = _arg.PhoneNo;
            var areaCode = AppSettingsHelper.GetParamValue<string>("PHONE_AREA_CODE");
            if (phone.StartsWith(areaCode))
            {
                if (!AppSettingsHelper.GetParamValue<bool>("PHONE_DIAL_AREA_CODE"))
                {
                    phone = phone.Substring(areaCode.Length);
                }
            }

            try
            {
                _cid.SendCommand("ATDT " + phone);
            }
            catch (Exception ex)
            {
                MyMessageBox = new Library.MyMessageBox(ex.Message, this.Text, ClientManage.Library.MyMessageBox.MyMessageType.Error, ClientManage.Library.MyMessageBox.MyMessageButton.Ok);
                MyMessageBox.Show(this);
                EventLogManager.AddExceptionToLogFile(ex);
            }
            var mi = new MethodInvoker(AddCallLog);
            mi.BeginInvoke(null, null);
            //mi.Invoke();
            btnRedial.Enabled = false;
        }

        private void AddCallLog()
        {
            if (AddDialCallLog != null) AddDialCallLog(this, _arg);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            TerminateForm();
        }

        public void TerminateForm()
        {
            DisconnectCall();
            this.Hide();
            Application.DoEvents();
            btnHangUp_Click(null, null);
            this.Close();
        }

        private void DisconnectCall()
        {
            try
            {
                _cid.SendCommand("ATH");
            }
            catch (Exception ex)
            {
                EventLogHelper.AddEvent(new LogInfo(LogInfo.LogType.Error, ex.Message, Utils.GetExceptionMessage(ex)));
                EventLogManager.AddExceptionToLogFile(ex);
            }
        }
    }
}