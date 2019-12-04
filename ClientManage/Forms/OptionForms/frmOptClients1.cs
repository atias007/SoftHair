using System;
using System.Data;
using System.Drawing;
using ClientManage.BL;
using ClientManage.Interfaces;

namespace ClientManage.Forms.OptionForms
{
    public partial class FormOptClients1 : BaseMdiOptionForm
    {
        public event EventHandler ClientsDSChanged;

        public FormOptClients1()
        {
            InitializeComponent();
            InitFilterField();

            grdClientTypes.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8);
        }

        private DataSet _dsClientTypes;

        public DataSet DSClientTypes
        {
            get { return _dsClientTypes; }
            set { _dsClientTypes = value; }
        }

        public override void LoadSettings()
        {
            txtMaxClients.Text = LoadSettingValue<string>("CLIENT_MAX_CLIENT");
            var dbfields = Utils.GetStringArray(LoadSettingValue<string>("CLIENT_FILTER_BY"));
            var pos = 0;
            lstClientOrder.SuspendLayout();
            lstClientOrder.Items.Clear();
            lstClientOrder.Items.AddRange(new object[] { "FirstName", "LastName", "ClientName", "Street", "City", "ClientPhones" });
            for (var i = dbfields.Length - 1; i >= 0; i--)
            {
                pos = lstClientOrder.Items.IndexOf(dbfields[i]);
                if (pos >= 0)
                {
                    lstClientOrder.Items.RemoveAt(pos);
                    lstClientOrder.Items.Insert(0, dbfields[i]);
                    lstClientOrder.SetItemChecked(0, true);
                }
            }
            DecodeFilterFields(lstClientOrder);
            lstClientOrder.ResumeLayout(true);

            chkEnableQuickSearch.Checked = LoadSettingValue<bool>("CLIENT_ENABLE_SEARCH_SHORTCUT");

            if (_dsClientTypes == null) _dsClientTypes = ClientHelper.GetClientTypeTable();
            grdClientTypes.DataSource = _dsClientTypes.Tables[0];
        }

        public override void SaveSettings()
        {
            SaveSettingValue("CLIENT_MAX_CLIENT", txtMaxClients.Text);
            SaveSettingValue("CLIENT_FILTER_BY", EncodeFilterFields(lstClientOrder));
            SaveSettingValue("CLIENT_ENABLE_SEARCH_SHORTCUT", chkEnableQuickSearch.Checked);
            if (_dsClientTypes.HasChanges())
            {
                ClientsDSChanged(_dsClientTypes, new EventArgs());
            }
        }

        public override void ResetForm()
        {
            _dsClientTypes = null;
            base.ResetForm();
        }

        private void lstClientOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnUpClient.Enabled = (lstClientOrder.SelectedIndex > 0);
            btnDownClient.Enabled = (lstClientOrder.SelectedIndex < lstClientOrder.Items.Count - 1);
        }

        private void btnUpClient_Click(object sender, EventArgs e)
        {
            var tmp = (string)lstClientOrder.Items[lstClientOrder.SelectedIndex];
            lstClientOrder.Items[lstClientOrder.SelectedIndex] = lstClientOrder.Items[lstClientOrder.SelectedIndex - 1];
            lstClientOrder.Items[lstClientOrder.SelectedIndex - 1] = tmp;
            lstClientOrder.SelectedIndex = lstClientOrder.SelectedIndex - 1;
            lstClientOrder_SelectedIndexChanged(null, null);
            lstClientOrder.Select();
        }

        private void btnDownClient_Click(object sender, EventArgs e)
        {
            var tmp = (string)lstClientOrder.Items[lstClientOrder.SelectedIndex];
            lstClientOrder.Items[lstClientOrder.SelectedIndex] = lstClientOrder.Items[lstClientOrder.SelectedIndex + 1];
            lstClientOrder.Items[lstClientOrder.SelectedIndex + 1] = tmp;
            lstClientOrder.SelectedIndex = lstClientOrder.SelectedIndex + 1;
            lstClientOrder_SelectedIndexChanged(null, null);
            lstClientOrder.Select();
        }
    }
}