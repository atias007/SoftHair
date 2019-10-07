using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClientManage.Library;
using ClientManage.BL;
using ClientManage.Interfaces;

namespace ClientManage.Forms.OptionForms
{
    public partial class FormOptEmail : BaseMdiOptionForm
    {
        private ListViewItem lvItem;

        public FormOptEmail()
        {
            InitializeComponent();
        }

        public override void LoadSettings()
        {
            txtMailFrom.Text = LoadSettingValue<string>("MAIL_FROM");
            txtMailWS.Text = WebServices.OnlineUpdateUrl;

            var table = MailCampaignHelper.GetAllMailTemplates();
            lstMailTemplates.Items.Clear();
            foreach (DataRow row in table.Rows)
            {
                lvItem = new ListViewItem(Utils.GetDBValue<string>(row, "template_name"));
                lvItem.SubItems.Add(Utils.GetDBValue<string>(row, "mail_subject"));
                lvItem.Tag = row["id"].ToString();
                lstMailTemplates.Items.Add(lvItem);
            }
            if (lstMailTemplates.Items.Count > 0) lstMailTemplates.Items[0].Selected = true;
        }

        public override void SaveSettings()
        {
            SaveSettingValue("MAIL_FROM", txtMailFrom.Text);
        }

        private void lstMailTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMailTemplates.SelectedItems.Count == 0) return;

            var id = lstMailTemplates.SelectedItems[0].Tag.ToString();
            try
            {
                lblPreview.Image = Image.FromFile("MailTemlates\\preview_" + id + ".jpg");
            }
            catch
            {
                lblPreview.Image = null;
            }
        }

        private void btnValidUrlEmail_Click(object sender, EventArgs e)
        {
            OpenUrl(txtMailWS.Text);
        }
    }
}