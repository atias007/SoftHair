using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ClientManage.Forms.OptionForms;
using ClientManage.BL;
using ClientManage.Interfaces;
using ClientManage.Library;
using System.Collections;
using System.Diagnostics;

namespace ClientManage.Forms
{
    public partial class FormOptions : BaseMdiChild
    {
        public event ModemEventHandler ModemCommitCommand;

        public enum LogOnType { LogOff, Admin, SuperUser };

        private string _formKey = string.Empty;
        private BaseMdiOptionForm _form;

        private readonly Hashtable _settings = new Hashtable();
        private DataSet _dsClientTypes;
        private DataSet _dsRemainderValues;
        private DataSet _dsCares;
        private DataSet _dsMagneticCards;
        private DataSet _dsComponents;
        private LogOnType _loginType = LogOnType.LogOff;

        public FormOptions()
        {
            InitializeComponent();
            var width = tbbSave.Width + tbbDelete.Width + toolStripSeparator1.Width + toolStripLabel1.Width + toolStripTextBox1.Width;
            txtPassword.Left = toolStrip.Width - width - 10 - toolStrip.Padding.Horizontal;
            txtPassword.Width = toolStripTextBox1.Width;
        }

        private void FrmOptions_Load(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
            treeView1.SelectedNode = treeView1.Nodes[0];

            treeView1.Select();
            splitContainer1.SplitterDistance = 218;
        }

        private bool IsFormExist()
        {
            return !(_form == null || _form.IsDisposed);
        }

        private string GetFormCaption()
        {
            var node = treeView1.SelectedNode;
            var text = string.Empty;

            if (node != null)
            {
                text = node.Parent == null ?
                    node.Text :
                    string.Format("{0} ({1})", node.Parent.Text, node.Text);
            }

            return text;
        }

        private void SaveSettings()
        {
            if (IsFormExist()) _form.SaveSettings();

            foreach (string key in _settings.Keys)
            {
                AppSettingsHelper.SetParamValue(key, _settings[key], false);
            }
            _settings.Clear();

            if (_dsClientTypes != null) ClientHelper.UpdateClientTypeTable(_dsClientTypes);
            if (_dsRemainderValues != null) CalendarHelper.UpdateRemainderValues(_dsRemainderValues);
            if (_dsCares != null) CalendarHelper.UpdateCares(_dsCares);
            if (_dsMagneticCards != null) WorkersHelper.UpdateMagneticCards(_dsMagneticCards);
            if (_dsComponents != null) ClientHelper.SaveComponentsConfig();

            if (IsFormExist()) _form.ResetForm();
            AppSettingsHelper.ResetParams();
        }

        private void LoadSettings()
        {
            if (IsFormExist()) _form.LoadSettings();
        }

        private void ResetForm()
        {
            if (IsFormExist()) _form.ResetForm();
        }

        public void LogOn(bool isSuperUser)
        {
            _loginType = isSuperUser ? LogOnType.SuperUser : LogOnType.Admin;
            if (IsFormExist()) _form.LogOn(isSuperUser);

            txtPassword.Enabled = false;
            tbbLogin.Enabled = false;
            tbbLogout.Enabled = true;
            treeView1.Select();
        }

        public void LogOff()
        {
            _loginType = LogOnType.LogOff;
            if (IsFormExist()) _form.LogOff();

            txtPassword.Enabled = true;
            tbbLogin.Enabled = true;
            tbbLogout.Enabled = false;
            tbbLogout.Enabled = false;
        }

        public void CloseForm()
        {
            if (IsFormExist()) _form.Close();
            _form = null;
            _formKey = string.Empty;
        }

        public void OpenForm()
        {
            TreeView1_AfterSelect(treeView1, new TreeViewEventArgs(treeView1.SelectedNode));
        }

        private void InitForm(string key)
        {
            _formKey = key;
            _form.Top = 4;
            _form.Settings = _settings;
            _form.TopLevel = false;
            _form.LogOnType = _loginType;
            _form.Size = new Size(splitContainer1.Panel2.Width, splitContainer1.Panel2.Height);
            _form.Caption = GetFormCaption();
            splitContainer1.Panel2.Controls.Add(_form);
            _form.Show();
            _form.Select();
        }

        public bool IsListenToModem
        {
            get
            {
                var ret = false;
                if (IsFormExist())
                {
                    if (_form is FormOptModem)
                    {
                        ret = ((FormOptModem)_form).IsListenToModem;
                    }
                }
                return ret;
            }
        }

        public void AddModemEvent(string value)
        {
            if (IsFormExist())
            {
                if (_form is FormOptModem)
                {
                    ((FormOptModem)_form).AddModemEvent(value);
                }
            }
        }

        public void SetFtpLastBackupLabel()
        {
            if (IsFormExist())
            {
                if (_form is FormOptBackup)
                {
                    ((FormOptBackup)_form).SetFtpLastBackupLabel();
                }
            }
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (splitContainer1.Panel2.Controls.Count > 1) splitContainer1.Panel2.Controls.RemoveAt(0);

            switch (e.Node.Name)
            {
                case "Node0":
                case "Node1":
                case "Node2":
                    treeView1.SelectedNode = e.Node.Nodes[0];
                    break;

                case "Node0_1":
                    if (_formKey == "frmOptSystem1") break;
                    CloseForm();
                    _form = new FormOptSystem1();
                    InitForm("frmOptSystem1");
                    break;

                case "Node0_2":
                    if (_formKey == "frmOptSystem2") break;
                    CloseForm();
                    _form = new FormOptSystem2();
                    InitForm("frmOptSystem2");
                    break;

                case "Node1_1":
                    if (_formKey == "frmOptClients1") break;
                    CloseForm();
                    _form = new FormOptClients1();
                    ((FormOptClients1)_form).DSClientTypes = _dsClientTypes;
                    ((FormOptClients1)_form).ClientsDSChanged += FrmOptClients1_ClientsDsChanged;
                    InitForm("frmOptClients1");
                    break;

                case "Node1_2":
                    if (_formKey == "frmOptClients2") break;
                    CloseForm();
                    _form = new FormOptClients2();
                    ((FormOptClients2)_form).ClientsDsChanged += FrmOptions_ClientsDsChanged;
                    InitForm("frmOptClients2");
                    break;

                case "Node2_1":
                    if (_formKey == "frmOptContact") break;
                    CloseForm();
                    _form = new FormOptContact();
                    InitForm("frmOptContact");
                    break;

                case "Node3":
                    treeView1.SelectedNode = e.Node.Nodes[0];
                    break;

                case "Node3_1":
                    if (_formKey == "frmOptCalendar1") break;
                    CloseForm();
                    _form = new FormOptCalendar1();
                    InitForm("frmOptCalendar1");
                    break;

                case "Node3_2":
                    if (_formKey == "frmOptCalendar2") break;
                    CloseForm();
                    _form = new FormOptCalendar2();
                    ((FormOptCalendar2)_form).DSRemainderValues = _dsRemainderValues;
                    ((FormOptCalendar2)_form).ClientsDSChanged += FrmOptCalendar2_ClientsDsChanged;
                    InitForm("frmOptCalendar2");
                    break;

                case "Node3_3":
                    if (_formKey == "frmOptCalendar3") break;
                    CloseForm();
                    _form = new FormOptCalendar3();
                    ((FormOptCalendar3)_form).DSCares = _dsCares;
                    ((FormOptCalendar3)_form).ClientsDSChanged += FrmOptCalendar3_ClientsDsChanged;
                    InitForm("frmOptCalendar3");
                    break;

                case "Node4":
                    if (_formKey == "frmOptReports") break;
                    CloseForm();
                    _form = new FormOptReports();
                    InitForm("frmOptReports");
                    break;

                case "Node5":
                    if (_formKey == "frmOptWorkers") break;
                    CloseForm();
                    _form = new FormOptWorkers();
                    ((FormOptWorkers)_form).DSMagneticCards = _dsMagneticCards;
                    ((FormOptWorkers)_form).ClientsDSChanged += FrmOptWorkers_ClientsDsChanged;
                    InitForm("frmOptWorkers");
                    break;

                case "Node6":
                    if (_formKey == "frmOptHistory") break;
                    CloseForm();
                    _form = new FormOptHistory();
                    InitForm("frmOptHistory");
                    break;

                case "Node7":
                    if (_formKey == "frmOptBackup") break;
                    CloseForm();
                    _form = new FormOptBackup();
                    InitForm("frmOptBackup");
                    break;

                case "Node8":
                    if (_formKey == "frmOptOnlineUpdate") break;
                    CloseForm();
                    _form = new FormOptOnlineUpdate();
                    InitForm("frmOptOnlineUpdate");
                    break;

                case "Node9":
                    if (_formKey == "frmOptSMS1") break;
                    CloseForm();
                    _form = new FormOptSms1();
                    InitForm("frmOptSMS1");
                    break;

                case "Node10":
                    if (_formKey == "frmOptEmail") break;
                    CloseForm();
                    _form = new FormOptEmail();
                    InitForm("frmOptEmail");
                    break;

                case "Node11":
                    var msg = new MyMessageBox("חלון לא נתמך", "שגיאה...");
                    msg.Show();
                    break;

                case "Node12":
                    if (_formKey == "frmOptModem") break;
                    CloseForm();
                    _form = new FormOptModem();
                    ((FormOptModem)_form).ModemCommitCommand += FrmOptions_ModemCommitCommand;
                    InitForm("frmOptModem");
                    break;

                case "Node13":
                    if (_formKey == "frmOptLicense") break;
                    CloseForm();
                    _form = new FormOptLicense();
                    InitForm("frmOptLicense");
                    break;

                default:
                    _formKey = string.Empty;
                    CloseForm();
                    break;
            }

            var node = treeView1.SelectedNode;
            if (node != null)
            {
                node.BackColor = Color.FromKnownColor(KnownColor.Highlight);
                node.ForeColor = Color.FromKnownColor(KnownColor.HighlightText);
            }

            treeView1.Select();
        }

        private void FrmOptions_ClientsDsChanged(object sender, EventArgs e)
        {
            _dsComponents = (DataSet)sender;
            var maxId = ClientHelper.GetComponentsMaxOrder();
            foreach (DataRow row in _dsComponents.Tables[0].Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    if (Utils.GetDBValue<int>(row, "width") == 0) row["width"] = 100;
                    if (Utils.GetDBValue<int>(row, "order_id") == 0) row["order_id"] = (++maxId);
                }
            }
        }

        private void FrmOptions_ModemCommitCommand(object sender, ModemEventArgs e)
        {
            if (ModemCommitCommand != null) ModemCommitCommand(this, e);
        }

        private void FrmOptWorkers_ClientsDsChanged(object sender, EventArgs e)
        {
            _dsMagneticCards = (DataSet)sender;
        }

        private void FrmOptCalendar3_ClientsDsChanged(object sender, EventArgs e)
        {
            _dsCares = (DataSet)sender;
        }

        private void FrmOptCalendar2_ClientsDsChanged(object sender, EventArgs e)
        {
            _dsRemainderValues = (DataSet)sender;
        }

        private void FrmOptClients1_ClientsDsChanged(object sender, EventArgs e)
        {
            _dsClientTypes = (DataSet)sender;
        }

        private void TbbSave_Click(object sender, EventArgs e)
        {
            if (!this.Validate()) return;

            this.Cursor = Cursors.WaitCursor;

            SaveSettings();
            ResetForm();
            LoadSettings();
            const string msg1 = "ההגדרות נשמרו בהצלחה";
            const string msg2 = "הגדרות מערכת...";
            MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Confirm, MyMessageBox.MyMessageButton.None)
            { CloseInterval = 1500 };
            MsgBox.Show();
            treeView1.Select();

            this.Cursor = Cursors.Default;
        }

        private void TbbDelete_Click(object sender, EventArgs e)
        {
            _settings.Clear();
            _dsCares = null;
            _dsClientTypes = null;
            _dsMagneticCards = null;
            _dsRemainderValues = null;

            if (IsFormExist()) _form.ResetForm();

            LoadSettings();
            treeView1.Select();
        }

        private void TxtPassword_Enter(object sender, EventArgs e)
        {
            base.TextBoxEnter((TextBox)sender);
        }

        private void TxtPassword_Leave(object sender, EventArgs e)
        {
            base.TextBoxLeave((TextBox)sender);
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TbbLogin_Click(null, null);
            }
        }

        private void TbbLogin_Click(object sender, EventArgs e)
        {
            if (Utils.IsSuperUserPassword(txtPassword.Text, AppSettingsHelper.GetParamValue("APP_SUPER_USER_PASS")))
            {
                LogOn(true);
            }
            else
            {
                if (WorkersHelper.IsAdminPassword(txtPassword.Text))
                {
                    LogOn(false);
                }
                else
                {
                    txtPassword.Select();
                    const string msg1 = "סיסמת מנהל שגוייה";
                    const string msg2 = "סיסמת מנהל";
                    MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Error, MyMessageBox.MyMessageButton.Ok);
                    MsgBox.Show(this);
                }
            }
            txtPassword.Text = string.Empty;
        }

        private void TbbLogout_Click(object sender, EventArgs e)
        {
            LogOff();
            txtPassword.Select();
        }

        private void FrmOptions_SizeChanged(object sender, EventArgs e)
        {
            if (IsFormExist())
            {
                _form.Size = new Size(splitContainer1.Panel2.Width, splitContainer1.Panel2.Height);
                treeView1.Select();
            }
        }

        private void SplitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (IsFormExist())
            {
                _form.Size = new Size(splitContainer1.Panel2.Width, splitContainer1.Panel2.Height);
                treeView1.Select();
            }
        }

        private void TreeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            var node = treeView1.SelectedNode;
            if (node != null)
            {
                node.BackColor = treeView1.BackColor;
                node.ForeColor = Color.Black;
            }
        }

        private void FrmOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                foreach (Form f in splitContainer1.Panel2.Controls)
                {
                    try
                    {
                        if (!(f == null || f.IsDisposed))
                        {
                            f.Close();
                        }
                    }
                    catch { Utils.CatchException(); }
                }
            }
            catch { Utils.CatchException(); }
            {
            }

            splitContainer1.Panel2.Controls.Clear();
        }

        private void TbbCall_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("QuickLaunch.exe", "-support");
            }
            catch (Exception ex)
            {
                const string msg = "קובץ קריאת השירות לא נמצא\n";
                const string title = "שגיאה...";
                MessageBox.Show(msg + ex.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TbbTeam_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("TeamViewerQS.exe");
            }
            catch (Exception ex)
            {
                const string msg = "קובץ חלון התמיכה לא נמצא\n";
                const string title = "שגיאה...";
                MessageBox.Show(msg + ex.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}