using System;
using System.Collections.Generic;
using System.Linq;
using ClientManage.Library;
using ClientManage.Interfaces;
using HardwareHelperLib;
using ClientManage.BL.Library;

namespace ClientManage.Forms.OptionForms
{
    public partial class FormOptSystem2 : BaseMdiOptionForm
    {
        public FormOptSystem2()
        {
            InitializeComponent();
        }

        public override void LogOn(bool isSuperUser)
        {
            base.LogOn(isSuperUser);

            if (isSuperUser)
            {
                txtPatternClient.PasswordChar = '\0';
                txtPatternWorkers.PasswordChar = '\0';
            }
        }

        public override void LogOff()
        {
            base.LogOff();

            txtPatternClient.PasswordChar = '*';
            txtPatternWorkers.PasswordChar = '*';
        }

        public override void LoadSettings()
        {
            var arr = Utils.GetStringArray(LoadSettingValue<string>("APP_EXCLUDE_HARDWARE"));
            SetExcludeHarware(arr);

            txtCardDelay.Text = LoadSettingValue<string>("CARD_MATCH_DELAY");
            txtPatternClient.Text = LoadSettingValue<string>("CARD_CLIENT_PATTERN");
            txtPatternSize.Text = LoadSettingValue<string>("CARD_PATTERN_PIPE_SIZE");
            txtPatternWorkers.Text = LoadSettingValue<string>("CARD_WORKER_PATTERN");
            chkAutoRegisterSub.Checked = LoadSettingValue<bool>("CARD_AUTO_REGISTER_SUB");
            txtMasterCard.Text = LoadSettingValue<string>("CARD_MASTER_VALUE");
        }

        public override void SaveSettings()
        {
            SaveSettingValue("APP_EXCLUDE_HARDWARE", GetExcludeHarware());
            SaveSettingValue("CARD_MATCH_DELAY", Utils.GetDBValue<int>(txtCardDelay.Text));
            SaveSettingValue("CARD_CLIENT_PATTERN", txtPatternClient.Text);
            SaveSettingValue("CARD_PATTERN_PIPE_SIZE", Utils.GetDBValue<int>(txtPatternSize.Text));
            SaveSettingValue("CARD_WORKER_PATTERN", txtPatternWorkers.Text);
            SaveSettingValue("CARD_AUTO_REGISTER_SUB", chkAutoRegisterSub.Checked);
            SaveSettingValue("CARD_MASTER_VALUE", txtMasterCard.Text);
        }

        public override void ResetForm()
        {
            lstHarware.Items.Clear();
            base.ResetForm();
        }

        private void SetExcludeHarware(IList<string> devices)
        {
            var isAdd = false;
            lstHarware.Items.Clear();
            lstHarware.ClearSelected();
            if (devices.Count > 0 && devices[0].Length == 0) return;

            foreach (var t in devices)
            {
                for (var i = 0; i < lstHarware.Items.Count; i++)
                {
                    if (lstHarware.Items[i].Equals(t))
                    {
                        lstHarware.SetItemChecked(i, true);
                        isAdd = true;
                        break;
                    }
                }
                if (!isAdd)
                {
                    lstHarware.Items.Add(t, true);
                }
                isAdd = false;
            }
        }

        private static bool IsArrayContain(IEnumerable<string> arr, string value)
        {
            return arr.Any(t => t.Equals(value));
        }

        private string GetExcludeHarware()
        {
            var hw = string.Empty;

            // ReSharper disable LoopCanBeConvertedToQuery
            foreach (var t in lstHarware.CheckedItems)
            // ReSharper restore LoopCanBeConvertedToQuery
            {
                hw += t + ",";
            }

            if (hw.EndsWith(",")) hw = hw.Substring(0, hw.Length - 1);
            return hw;
        }

        private void BtnLoadHardwareClick(object sender, EventArgs e)
        {
            // load harware list
            var exclude = Utils.GetStringArray(LoadSettingValue<string>("APP_EXCLUDE_HARDWARE"));
            lstHarware.Items.Clear();
            SetExcludeHarware(exclude);

            try
            {
                var hwh = new HH_Lib();
                var hardwareList = hwh.GetAll();
                Utils.SortArray(ref hardwareList);
                foreach (var s in hardwareList)
                {
                    if (!IsArrayContain(exclude, s))
                    {
                        lstHarware.Items.Add(s);
                    }
                }

                hwh.HookHardwareNotifications(this.Handle, true);
            }
            catch (Exception ex)
            {
                EventLogManager.AddErrorMessage("Error load hardware list", ex);
            }
        }

        private void btnScript_Click(object sender, EventArgs e)
        {
            var script = txtScript.Text.Trim();
            txtScript.Clear();

            using (var executer = new SqlExecute(General.ConnectionString))
            {
                foreach (var line in script.Split(';'))
                {
                    try
                    {
                        var s = line.Trim();
                        if (!string.IsNullOrEmpty(s))
                        {
                            var cnt = executer.ExecuteSqlStatement(s);
                            txtScript.AppendText(cnt + " row(s) effected\r\n");
                        }
                    }
                    catch (Exception ex)
                    {
                        txtScript.AppendText("********************* ERROR ********************* \r\n" + line +
                                             "\r\n**************************************\r\n" + ex +
                                             "\r\n**************************************\r\n");
                    }
                }
            }
        }
    }
}