using System;
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
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}