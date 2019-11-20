using System;
using ClientManage.Interfaces;
using ClientManage.BL;
using Newtonsoft.Json;

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
            var json = AppSettingsHelper.GetParamValue("APP_LICENSE");
            var result = JsonConvert.DeserializeObject<CustomerLicense>(json);
            licenseInfo1.ShowLicenseInfo(result);
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}