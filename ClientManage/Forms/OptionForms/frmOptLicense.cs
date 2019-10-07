using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClientManage.BL;
using ClientManage.Interfaces;
using ClientManage.Library;

namespace ClientManage.Forms.OptionForms
{
    public partial class FormOptLicense : BaseMdiOptionForm
    {
        public FormOptLicense()
        {
            InitializeComponent();
        }

        public override void LoadSettings()
        {
            licenseInfo1.ShowLicenseInfo(Utils.CurrentLicense);
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            var key = Security.EndLicense(Utils.CurrentLicense);
            LicenceHelper.UpdateLicense(key);
            LoadSettings();
            btnStop.Enabled = false;
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            LicenceHelper.ClearAllLicenses();
            LoadSettings();
            btnPause.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = Library.LicenseManager.GetLicenseOnline();
            var info = string.Format("Status: {0}\nCustomerStatus: {1}\nFromDate: {2}\nToDate: {3}\nLicenseKey: {4}\nServerDate: {5}\nFeatures: {6}",
                result.Item2, result.Item1.CustomerStatus, result.Item1.FromDate, result.Item1.ToDate, result.Item1.LicenseKey, result.Item1.ServerDate, result.Item1.Features);

            var msg = new MyMessageBox(info, "Info...", MyMessageBox.MyMessageType.Information, MyMessageBox.MyMessageButton.Ok);
            msg.Show(this);
        }
    }
}