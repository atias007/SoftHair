using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using ClientManage.BL;

namespace ClientManage.Forms
{
    public partial class BaseMdiOptionForm : BaseMdiChild
    {
        public BaseMdiOptionForm()
        {
            InitializeComponent();
        }

        private string[,] _filterFields;

        public virtual void SaveSettings() { }
        public virtual void LoadSettings() { }

        private Hashtable _settings;
        public Hashtable Settings
        {
            get { return _settings; }
            set { _settings = value; }
        }

        private FormOptions.LogOnType _logOnType = FormOptions.LogOnType.LogOff;
        public FormOptions.LogOnType LogOnType
        {
            get { return _logOnType; }
            set { _logOnType = value; }
        }

        public string Caption
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        public virtual void LogOn(bool isSuperUser)
        {
            LogOn(isSuperUser, this);
        }

        public virtual void LogOn(bool isSuperUser, Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.Tag != null)
                {
                    if ((isSuperUser && c.Tag.ToString() == "SuperUser") || c.Tag.ToString() == "Admin")
                    {
                        if (c is TextBox) ((TextBox)c).ReadOnly = false;
                        else if (c is DataGridView) { ((DataGridView)c).ReadOnly = false; c.Refresh(); }
                        else c.Enabled = true;
                        
                        if (!(c is Button || c is CheckBox)) c.BackColor = Color.White;
                    }
                }
                if (c.Controls.Count > 0) LogOn(isSuperUser, c);
            }
        }

        public virtual void LogOff()
        {
            LogOff(this);
        }

        public virtual void LogOff(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.Tag != null)
                {
                    if (c.Tag.ToString() == "SuperUser" || c.Tag.ToString() == "Admin")
                    {
                        if (c is TextBox) ((TextBox)c).ReadOnly = true;
                        else if (c is DataGridView) { ((DataGridView)c).ReadOnly = true; c.Refresh(); }
                        else c.Enabled = false;

                        if (!(c is Button || c is CheckBox)) c.BackColor = Color.WhiteSmoke;
                    }
                }
                if (c.Controls.Count > 0) LogOff(c);
            }
        }

        public virtual void ResetForm()
        {
            // *** Do Nothing ***
        }

        protected void SaveSettingValue(string key, object value)
        {
            if (_settings.Contains(key))
            {
                _settings[key] = value;
            }
            else
            {
                _settings.Add(key, value);
            }
        }

        public enum SettingValueType { String, Bool, DateTime, Int, IntArray, StringArray };
        
        protected T LoadSettingValue<T>(string key)
        {
            if (_settings.Contains(key))
            {
                return (T)Convert.ChangeType(_settings[key], typeof(T));
            }
            
            return AppSettingsHelper.GetParamValue<T>(key);
        }

        protected void OpenUrl(string url)
        {
            System.Diagnostics.Process.Start(url);
        }

        private void BaseMdiOptionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void BaseMdiOptionForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
            if (_logOnType == FormOptions.LogOnType.Admin) LogOn(false);
            else if (_logOnType == FormOptions.LogOnType.SuperUser) LogOn(true);
        }

        private void BaseMdiOptionForm_Paint(object sender, PaintEventArgs e)
        {
            const int height = 46;
            e.Graphics.DrawLine(new Pen(Color.FromArgb(127, 157, 185)), 0, height, this.Width, height);
        }

        protected void DecodeFilterFields(CheckedListBox list)
        {
            for (var i = 0; i < list.Items.Count; i++)
            {
                var pos = ArrIndexOf(0, (string)list.Items[i]);
                if (pos >= 0)
                {
                    list.Items[i] = _filterFields[pos, 1];
                }
            }
            if (list.Items.Count > 0) list.SelectedIndex = 0;
        }

        protected string EncodeFilterFields(CheckedListBox list)
        {
            var res = string.Empty;
            foreach (string item in list.CheckedItems)
            {
                var pos = ArrIndexOf(1, item);
                if (pos >= 0)
                {
                    res += _filterFields[pos, 0] + ",";
                }
            }
            if (res.EndsWith(",")) res = res.Substring(0, res.Length - 1);
            return res;
        }

        private int ArrIndexOf(int index, string value)
        {
            var ret = -1;
            for (var i = 0; i < _filterFields.Length; i++)
            {
                if (_filterFields[i, index].Equals(value))
                {
                    ret = i;
                    break;
                }
            }
            return ret;
        }

        protected bool IsGridContainsValue(DataGridView grid, string value, int columnIndex, int sourceRowIndex)
        {
            var res = false;
            for (var i = 0; i < grid.Rows.Count; i++)
            {
                if (i != sourceRowIndex)
                {
                    if (value == Convert.ToString(grid[columnIndex, i].Value))
                    {
                        res = true;
                        break;
                    }
                }
            }
            return res;
        }

        protected void InitFilterField()
        {
            _filterFields = new[,]{
                { "FirstName", "שם פרטי" },
                { "LastName", "שם משפחה" },
                { "ClientName", "שם פרטי + משפחה" },
                { "ContactName", "שם פרטי + שם משפחה" },
                { "Street", "רחוב" },
                { "City", "עיר" },
                { "ClientPhones", "מספרי טלפון" },
                { "Phone", "מספרי טלפון + פקס"}
            };
        }
    }
}