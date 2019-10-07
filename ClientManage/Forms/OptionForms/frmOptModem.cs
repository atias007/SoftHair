using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClientManage.Interfaces;

namespace ClientManage.Forms.OptionForms
{
    public partial class FormOptModem : BaseMdiOptionForm
    {
        public event ModemEventHandler ModemCommitCommand;

        private bool _isListenToModem = false;

        public FormOptModem()
        {
            InitializeComponent();
        }

        public override void LoadSettings()
        {
            var port = Utils.GetStringArray(LoadSettingValue<string>("APP_COMM_PORT1_SETTING"));
            var parity = (System.IO.Ports.Parity)Convert.ToInt32(port[2]);
            var stopBit = (System.IO.Ports.StopBits)Convert.ToInt32(port[4]);
            cmbModemCommand.Text = LoadSettingValue<string>("APP_COMM_PORT1_INIT");
            cmbModemPort.SelectedIndex = cmbModemPort.FindString("COM" + port[0]);
            cmbMaxSpeed.SelectedIndex = cmbMaxSpeed.FindString(port[1]);
            cmbModemParity.SelectedIndex = cmbModemParity.FindString(parity.ToString());
            cmbModemDataBits.SelectedIndex = cmbModemDataBits.FindString(port[3]);
            cmbModemStopBits.SelectedIndex = cmbModemStopBits.FindString(stopBit.ToString());
        }

        public override void SaveSettings()
        {
            var settings = string.Empty;
            settings += cmbModemPort.Text.Substring(3) + ",";
            settings += cmbMaxSpeed.Text + ",";
            settings += Convert.ToInt32(Enum.Parse(typeof(System.IO.Ports.Parity), cmbModemParity.Text)).ToString() + ",";
            settings += cmbModemDataBits.Text + ",";
            settings += Convert.ToInt32(Enum.Parse(typeof(System.IO.Ports.StopBits), cmbModemStopBits.Text)).ToString();

            SaveSettingValue("APP_COMM_PORT1_SETTING", settings);
            SaveSettingValue("APP_COMM_PORT1_INIT", cmbModemCommand.Text);
        }

        public override void LogOff()
        {
            base.LogOff();

            btnListen.Text = "       החל האזנה למודם";
            _isListenToModem = false;
            txtModemCommand.Text = string.Empty;
            txtModemOutput.Text = string.Empty;
        }

        public bool IsListenToModem
        {
            get { return _isListenToModem; }
        }

        private void txtModemCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!_isListenToModem)
                {
                    btnListen.Text = "       הפסק האזנה למודם";
                    _isListenToModem = true;
                }

                txtModemOutput.Text += txtModemCommand.Text + "\r\n";
                txtModemOutput.SelectionStart = txtModemOutput.Text.Length;
                txtModemOutput.ScrollToCaret();
                if (ModemCommitCommand != null) ModemCommitCommand(this, new ModemEventArgs(txtModemCommand.Text));
                txtModemCommand.Text = string.Empty;
            }
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            if (_isListenToModem)
            {
                btnListen.Text = "       החל האזנה למודם";
                txtModemOutput.Text = string.Empty;
            }
            else
            {
                btnListen.Text = "       הפסק האזנה למודם";
            }

            _isListenToModem = !_isListenToModem;
        }

        private void btnCallerIdReset_Click(object sender, EventArgs e)
        {
            if (_isListenToModem == false) btnListen_Click(null, null);
            txtModemOutput.Text = string.Empty;
            if (ModemCommitCommand != null)
            {
                ModemCommitCommand(this, new ModemEventArgs("ATZ"));
                ModemCommitCommand(this, new ModemEventArgs(cmbModemCommand.Text));
            }
        }

        private void btnTestModem_Click(object sender, EventArgs e)
        {
            if (_isListenToModem == false) btnListen_Click(null, null);
            txtModemOutput.Text = string.Empty;
            if (ModemCommitCommand != null)
            {
                ModemCommitCommand(this, new ModemEventArgs("AT+GMM"));
                ModemCommitCommand(this, new ModemEventArgs("ATI3"));
                ModemCommitCommand(this, new ModemEventArgs("ATI4"));
                ModemCommitCommand(this, new ModemEventArgs("ATI6"));
            }
        }

        public void AddModemEvent(string value)
        {
            txtModemOutput.Text += value + "\r\n";
            txtModemOutput.SelectionStart = txtModemOutput.Text.Length;
            txtModemOutput.ScrollToCaret();
        }
    }
}