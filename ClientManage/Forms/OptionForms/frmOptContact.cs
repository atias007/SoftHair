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
    public partial class FormOptContact : BaseMdiOptionForm
    {
        public FormOptContact()
        {
            InitializeComponent();
            InitFilterField();
        }

        public override void LoadSettings()
        {
            var dbfields = Utils.GetStringArray(LoadSettingValue<string>("CONTACT_FILTER_BY"));
            var pos = 0;
            lstPhoneBook.SuspendLayout();
            lstPhoneBook.Items.Clear();
            lstPhoneBook.Items.AddRange(new object[] { "FirstName", "LastName", "ContactName", "Street", "City", "Phone" });
            for (var i = dbfields.Length - 1; i >= 0; i--)
            {
                pos = lstPhoneBook.Items.IndexOf(dbfields[i]);
                if (pos >= 0)
                {
                    lstPhoneBook.Items.RemoveAt(pos);
                    lstPhoneBook.Items.Insert(0, dbfields[i]);
                    lstPhoneBook.SetItemChecked(0, true);
                }
            }
            DecodeFilterFields(lstPhoneBook);
            lstPhoneBook.ResumeLayout(true);

            rbLastNameFirst.Checked = LoadSettingValue<bool>("CONTACT_LASTNAME_BEFORE");
        }

        public override void SaveSettings()
        {
            SaveSettingValue("CONTACT_FILTER_BY", EncodeFilterFields(lstPhoneBook));
            SaveSettingValue("CONTACT_LASTNAME_BEFORE", rbLastNameFirst.Checked);
        }

        private void lstPhoneBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnUpContact.Enabled = (lstPhoneBook.SelectedIndex > 0);
            btnDownContact.Enabled = (lstPhoneBook.SelectedIndex < lstPhoneBook.Items.Count - 1);
        }

        private void btnUpContact_Click(object sender, EventArgs e)
        {
            var tmp = (string)lstPhoneBook.Items[lstPhoneBook.SelectedIndex];
            lstPhoneBook.Items[lstPhoneBook.SelectedIndex] = lstPhoneBook.Items[lstPhoneBook.SelectedIndex - 1];
            lstPhoneBook.Items[lstPhoneBook.SelectedIndex - 1] = tmp;
            lstPhoneBook.SelectedIndex = lstPhoneBook.SelectedIndex - 1;
            lstPhoneBook_SelectedIndexChanged(null, null);
            lstPhoneBook.Select();
        }

        private void btnDownContact_Click(object sender, EventArgs e)
        {
            var tmp = (string)lstPhoneBook.Items[lstPhoneBook.SelectedIndex];
            lstPhoneBook.Items[lstPhoneBook.SelectedIndex] = lstPhoneBook.Items[lstPhoneBook.SelectedIndex + 1];
            lstPhoneBook.Items[lstPhoneBook.SelectedIndex + 1] = tmp;
            lstPhoneBook.SelectedIndex = lstPhoneBook.SelectedIndex + 1;
            lstPhoneBook_SelectedIndexChanged(null, null);
            lstPhoneBook.Select();
        }
    }
}