#region Using

using System;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;
using ClientManage.BL;
using ClientManage.BL.Library;
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Reflection;
using ClientManage.Interfaces.Schemas;
using ClientManage.Interfaces;

#endregion Using

namespace BizCareAdmin
{
    public partial class Form1 : Form
    {
        #region Private Members

        private readonly string _dbFilename;
        private DataSet _dsTable;
        private OleDbConnection _odbConn;
        private OleDbCommand _odbCommand;
        private OleDbDataAdapter _odbAdapter;
        private OleDbCommandBuilder _odbBuilder;
        private readonly ComPort _cid = new ComPort();
        private readonly ComPort.CommCallHandler _commCallerDelegate;
        private SqlExecute _sqlEx;
        private readonly List<ProductLicense.LicenseRow> _licenses = new List<ProductLicense.LicenseRow>();
        private readonly List<int> _licensesIds = new List<int>();
        private readonly PropertyInfo[] _propInfos = typeof(Client).GetProperties();

        #endregion Private Members

        #region Constructor

        public Form1()
        {
            //ImportUsers(@"c:\src.txt", @"c:\tar.txt");
            //return;

            var login = new Login();
            login.ShowDialog();
            if (!Login.IsOk) Environment.Exit(0);

            InitializeComponent();
            _cid.CommIncomeData += cid_CommIncomeData;
            _commCallerDelegate = new ComPort.CommCallHandler(RaiseCallerEvent);
            Common.DB = DatabaseFactory.CreateDatabase();
            AppSettingsHelper.SetCustomDatabase(Common.DB);

            _dbFilename = Login.DbFilename;
            ConnectExecuteSqlTab(_dbFilename);
        }

        #endregion Constructor

        #region Tab Modules

        #region Licence Generator

        private void BtnLocalClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Security.ClearCpuId();
            txtId.Text = Security.CpuId;
            this.Cursor = Cursors.Default;
        }

        private void BtnSetValueClick(object sender, EventArgs e)
        {
            var val = txtRegValue.Text.Trim();

            if (val == "CPU" || val == "MAC" || val == "VOL")
            {
                RegistryFactory.Write("KEYTYPE", txtRegValue.Text.Trim());
                MessageBox.Show("Value written successfuly", "Set registry value...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Incorrect Registry Value", "Login...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private string GetLicenseFromScreen()
        {
            var licence = Security.GetNewLicense();
            var row = licence.License[0];

            row.cpu_id = txtId.Text;
            row.from_date = new DateTime(dtpFrom.Value.Year, dtpFrom.Value.Month, dtpFrom.Value.Day);
            row.to_date = new DateTime(dtpTo.Value.Year, dtpTo.Value.Month, dtpTo.Value.Day, 23, 59, 59);
            row.last_used = new DateTime(dtpLast.Value.Year, dtpLast.Value.Month, dtpLast.Value.Day);
            row.type = cmbLicenseType.Text;
            row.key = txtPrimaryKey.Text;

            return Security.SaveLicence(licence);
        }

        private void btnAddNewLicence_Click(object sender, EventArgs e)
        {
            LicenceHelper.ClearAllLicenses();
            txtPrimaryKey.Text = txtPrimaryKey.Text.Trim();
            if (IsLicenseKeyExist(txtPrimaryKey.Text))
            {
                MessageBox.Show("Primary Key " + txtPrimaryKey.Text + " already exist", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var key = GetLicenseFromScreen();
                if (LicenceHelper.AddLicense(key))
                {
                    MessageBox.Show("License created successfuly", "Information...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillLicenseCombo();
                    if (cmbLicense.Items.Count > 0) cmbLicense.SelectedIndex = cmbLicense.Items.Count - 1;
                }
                else
                {
                    MessageBox.Show("Error while create license", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ShowLicense(ProductLicense.LicenseRow row)
        {
            if (row == null)
            {
                txtId.Text = string.Empty;
                txtPrimaryKey.Text = "XXXXX";
                dtpFrom.Value = DateTime.Now;
                dtpTo.Value = DateTime.Now.AddYears(1).AddDays(-1);
                dtpLast.Value = DateTime.Now;
                cmbLicenseType.SelectedIndex = -1;
            }
            else
            {
                txtId.Text = row.cpu_id;
                txtPrimaryKey.Text = row.key;
                dtpFrom.Value = row.from_date;
                dtpTo.Value = row.to_date;
                dtpLast.Value = row.last_used;
                cmbLicenseType.SelectedIndex = cmbLicenseType.FindString(row.type);
            }
        }

        #endregion Licence Generator

        #region Serial Comm Test

        private void cid_CommIncomeData(object sender, CommCallEventArgs e)
        {
            this.Invoke(_commCallerDelegate, new object[] { sender, e });
        }

        public void RaiseCallerEvent(object sender, CommCallEventArgs e)
        {
            lstEvents.Items.Add(e.ModemData);
            lstEvents.Items.Add("[Type=" + e.Type.ToString() + ", Parameters=" + e.EventData + "]");
            lstEvents.Items.Add(string.Empty);
            lstEvents.SelectedIndex = lstEvents.Items.Count - 1;
        }

        private void SetEnableCombos(bool val)
        {
            foreach (Control c in tabComm.Controls)
            {
                if (c is ComboBox)
                {
                    ((ComboBox)c).Enabled = val;
                }
            }
            txtModemCommand.Enabled = !val;
            lstEvents.Enabled = !val;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "Connect")
            {
                btnConnect.Text = "Disconnect";
                SetEnableCombos(false);
                SetPortProperties();
                _cid.Connect();
                txtModemCommand.Select();
            }
            else
            {
                btnConnect.Text = "Connect";
                SetEnableCombos(true);
                _cid.Disconnect();
            }
        }

        private void txtModemCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _cid.SendCommand(txtModemCommand.Text);
                lstEvents.Items.Add(txtModemCommand.Text);
                txtModemCommand.Text = string.Empty;
            }
        }

        private void btnClearEvents_Click(object sender, EventArgs e)
        {
            lstEvents.Items.Clear();
        }

        private void SetPortProperties()
        {
            _cid.Port.PortName = cmbPort.Text;
            _cid.Port.BaudRate = Convert.ToInt32(cmbSpeed.Text);
            _cid.Port.Parity = (Parity)cmbParity.SelectedIndex;
            _cid.Port.DataBits = Convert.ToInt32(cmbDataBits.Text);
            _cid.Port.StopBits = (StopBits)cmbStopBits.SelectedIndex;
            //cid.InitCallerIdCommand = string.Empty;
        }

        #endregion Serial Comm Test

        #region Import Database

        private void button2_Click(object sender, EventArgs e)
        {
            var res = openFileDialogData.ShowDialog(this);

            if (res == DialogResult.OK)
            {
                txtSourceFile.Text = openFileDialogData.FileName;
                txtSourceFile.SelectionStart = txtSourceFile.Text.Length + 1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var res = saveFileDialogData.ShowDialog(this);

            if (res == DialogResult.OK)
            {
                txtTargetfile.Text = saveFileDialogData.FileName;
                txtTargetfile.SelectionStart = txtTargetfile.Text.Length + 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSourceFile.Text.Length == 0)
            {
                MessageBox.Show("Select source file first");
                return;
            }
            //if (txtTargetfile.Text.Length == 0)
            //{
            //    MessageBox.Show("Select target file first");
            //    return;
            //}
            ImportUsers(txtSourceFile.Text);
            MessageBox.Show("Operation complete successfuly");
        }

        private void ImportUsers(string sourceFile)
        {
            var reader = new StreamReader(sourceFile, Encoding.Default);
            //StreamWriter writer = new StreamWriter(targetFile, false, Encoding.Default);

            var data = reader.ReadToEnd();
            if (!data.EndsWith("\0")) data.PadLeft(10, '\0');
            var pos = 0;
            Client c;
            reader.Close();

            while (true)
            {
                pos = data.IndexOf("\0");
                if (pos == -1) break;
                c = GetClient(data.Substring(pos - 298, pos));
                ClientHelper.AddClient(c);
                ClientHelper.SetCreateDate(c);
                data = data.Substring(pos + 10);
            }

            reader.Close();
            //writer.Close();
        }

        private Client GetClient(string data)
        {
            var c = new Client();

            var name = data.Substring(0, 30).Trim();
            var bdate = data.Substring(175, 15).Trim();
            var cdate = data.Substring(225, 23).Trim();
            string phone1, phone2;

            if (cdate.Length > 0)
            {
                cdate = cdate.Substring(0, 2) + "/" + cdate.Substring(2, 2) + "/" + cdate.Substring(4);
            }
            if (bdate.Length > 0)
            {
                if (bdate.IndexOf("-") > 0) bdate = bdate.Replace("-", "/");
                if (bdate.IndexOf("\\") > 0) bdate = bdate.Replace("\\", "/");
                if (bdate.Length == 4) bdate = bdate.Substring(0, 1) + "/" + bdate.Substring(1, 1) + "/" + bdate.Substring(2);
            }

            c.Picture = data.Substring(30, 30).Trim();
            data.Substring(60, 30);
            c.Address = data.Substring(90, 30).Trim();
            c.City = data.Substring(120, 15).Trim();
            data.Substring(137, 10);
            phone2 = data.Substring(145, 30).Trim();
            if (bdate.Length > 0) c.BirthDate = DateTime.Parse(bdate.Replace("-", "/"));

            if (cdate.Length > 0) c.CreateDate = DateTime.Parse(cdate);
            else c.CreateDate = DateTime.Parse("01/01/1900");

            phone1 = data.Substring(190, 35).Trim();
            c.Remark = data.Substring(248, 20).Trim();
            c.Gender = (Client.ClientGender)(data.Substring(268, 5).Trim() == "גברים" ? 1 : 0);

            if (name.IndexOf(" ") > 0)
            {
                c.FirstName = name.Substring(0, name.IndexOf(" ")).Trim();
                c.LastName = name.Substring(name.IndexOf(" ") + 1);
            }
            else
            {
                c.FirstName = name;
                c.LastName = string.Empty;
            }

            if (Validation.IsCellPhoneValid(Utils.DistilPhone(phone1)))
            {
                if (c.CellPhone1.Length == 0) c.CellPhone1 = phone1;
                else c.CellPhone2 = phone1;
            }
            else
            {
                if (c.HomePhone.Length == 0) c.HomePhone = phone1;
                else c.WorkPhone = phone1;
            }

            if (Validation.IsCellPhoneValid(Utils.DistilPhone(phone2)))
            {
                if (c.CellPhone1.Length == 0) c.CellPhone1 = phone2;
                else c.CellPhone2 = phone2;
            }
            else
            {
                if (c.HomePhone.Length == 0) c.HomePhone = phone2;
                else c.WorkPhone = phone2;
            }

            if (c.Picture.ToLower().StartsWith(@"c:\pictures")) c.Picture = @"C:\Program Files\SoftHair" + c.Picture.Substring(11);

            c.EnableEmail = true;
            c.EnableSMS = true;
            c.CellPhone1 = Validation.FormatPhone(c.CellPhone1);
            c.CellPhone2 = Validation.FormatPhone(c.CellPhone2);
            c.HomePhone = Validation.FormatPhone(c.HomePhone);
            c.WorkPhone = Validation.FormatPhone(c.WorkPhone);

            return c;
        }

        private string GetReaderValue(StreamReader reader, int size)
        {
            var ret = string.Empty;
            int intChar;

            for (var i = 0; i < size; i++)
            {
                intChar = reader.Read();
                ret += Convert.ToChar(intChar);
            }
            return ret.Trim();
        }

        private void ReadToNext(StreamReader reader)
        {
            int pk;
            while (true)
            {
                pk = reader.Peek();
                if (pk > 0 && pk != 32) break;
                if (pk == -1) break;
                reader.Read();
            }
        }

        #endregion Import Database

        #region Application Table

        private void cmbTablesName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveTableData();
            _odbCommand = new OleDbCommand("SELECT * FROM " + cmbTablesName.Text, _odbConn);
            _odbAdapter = new OleDbDataAdapter(_odbCommand);
            _odbBuilder = new OleDbCommandBuilder(_odbAdapter);
            _odbAdapter.InsertCommand = _odbBuilder.GetInsertCommand();
            _odbAdapter.UpdateCommand = _odbBuilder.GetUpdateCommand();
            _odbAdapter.DeleteCommand = _odbBuilder.GetDeleteCommand();

            _dsTable = new DataSet();
            _odbAdapter.Fill(_dsTable);
            dataGridView1.DataSource = _dsTable.Tables[0];
        }

        private void SaveTableData()
        {
            if (_dsTable != null && _odbAdapter != null)
            {
                _odbAdapter.Update(_dsTable);
            }
        }

        private void btnSaveTable_Click(object sender, EventArgs e)
        {
            try
            {
                SaveTableData();
                MessageBox.Show("Saved successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data\n" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Application Table

        #region Report Editor

        private string _currentFilename = string.Empty;
        private int _currentId = 0;
        private ReportSchema _report = new ReportSchema();

        public string CurrentFilename
        {
            get { return _currentFilename; }
            set
            {
                _currentFilename = value;
                btnSaveReport.Enabled = (_currentFilename.Length > 0);
            }
        }

        private void LoadReport(string xml)
        {
            _report = Security.DecryptReport(xml);
            try
            {
                _report = Security.DecryptReport(xml);
                LoadTablesList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading report file\n\n" + ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTablesList()
        {
            lstReportTables.Items.Clear();
            dgvw.DataSource = null;
            foreach (DataTable table in _report.Tables)
            {
                lstReportTables.Items.Add(table.TableName);
            }
            if (lstReportTables.Items.Count > 0) lstReportTables.SelectedIndex = 0;
        }

        private void btnImportReport_Click(object sender, EventArgs e)
        {
            var res = openFileDialog1.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                var reader = new System.IO.StreamReader(openFileDialog1.FileName);
                var xml = reader.ReadToEnd();
                reader.Close();
                LoadReport(xml);
                //_currentFilename = openFileDialog1.FileName;
                //_currentId = 0;
                //this.Text = "Report Editor [filename: " + _currentFilename + "]";

                _currentFilename = string.Empty;
                _currentId = -1;
                //LoadTablesList();
            }
        }

        private void btnNewReport_Click(object sender, EventArgs e)
        {
            _currentFilename = string.Empty;
            _currentId = -1;
            _report = new ReportSchema();
            LoadTablesList();
        }

        private void lstReportTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            var table = _report.Tables[lstReportTables.SelectedItem.ToString()];
            dgvw.DataSource = table;
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            var res = saveFileDialog1.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                var ds = Security.EncryptReport(_report);
                ds.WriteXml(saveFileDialog1.FileName);
                MessageBox.Show("Saves successfuly");
            }
        }

        private void btnOpenReport_Click(object sender, EventArgs e)
        {
            var f = new frmSelectReportcs();
            var res = f.ShowDialog(this);

            if (res == DialogResult.OK)
            {
                if (frmSelectReportcs.id > 0)
                {
                    var xml = ReportHelper.GetReport(frmSelectReportcs.id);
                    LoadReport(xml);
                    _currentFilename = string.Empty;
                    _currentId = frmSelectReportcs.id;
                    this.Text = "Report Editor [Database Report id: " + _currentId.ToString() + "]";
                }
            }
        }

        private void btnSaveReport_Click(object sender, EventArgs e)
        {
            if (_report == null) return;
            DataSet ds;

            if (_currentFilename.Length > 0)
            {
                ds = Security.EncryptReport(_report);
                ds.WriteXml(_currentFilename);
                MessageBox.Show("Saves successfuly");
            }
            else if (_currentId > 0)
            {
                var ret = ReportHelper.UpdateReport(_currentId, _report);
                if (ret > 0) MessageBox.Show("Saves successfuly");
                else MessageBox.Show("Error saving report", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (_currentId == -1)
            {
                var ret = ReportHelper.AddReport(_report);
                if (ret > 0) MessageBox.Show("Saves successfuly");
                else MessageBox.Show("Error saving report", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Report Editor

        #endregion Tab Modules

        private void Form1_Load(object sender, EventArgs e)
        {
            _odbConn = (OleDbConnection)Common.DB.CreateConnection();

            FillLicenseCombo();

            dtpFrom.Value = DateTime.Now.AddDays(-1);
            dtpTo.Value = DateTime.Now;
            dtpLast.Value = DateTime.Now;
            RegistryFactory.SubKeyName = "SOFTWARE\\SYSSOLUTIONS";
            txtRegValue.Text = RegistryFactory.Read("KEYTYPE");

            cmbPort.SelectedIndex = 0;
            cmbSpeed.SelectedIndex = 5;
            cmbDataBits.SelectedIndex = 4;
            cmbParity.SelectedIndex = 0;
            cmbStopBits.SelectedIndex = 1;
            cmbFlow.SelectedIndex = 2;

            if (cmbLicense.Items.Count > 0) cmbLicense.SelectedIndex = cmbLicense.Items.Count - 1;

            Validation.CellPhonePrefix = Utils.GetStringArray(AppSettingsHelper.GetParamValue<string>("PHONE_CELL_PREFIX"));
            Validation.LinePhonePrefix = Utils.GetStringArray(AppSettingsHelper.GetParamValue<string>("PHONE_LINE_PREFIX"));
        }

        private void FillLicenseCombo()
        {
            cmbLicense.Items.Clear();
            _licenses.Clear();
            _licensesIds.Clear();
            int index;
            ProductLicense.LicenseRow row;

            var tbl = LicenceHelper.GetAllLicences();
            foreach (DataRow trow in tbl.Rows)
            {
                _licenses.Add(Security.GetLicense((string)trow["license_key"]).License[0]);
                _licensesIds.Add((int)trow["id"]);
            }

            for (var i = 0; i < _licenses.Count; i++)
            {
                row = _licenses[i];
                index = cmbLicense.Items.Add(_licensesIds[i].ToString() + ". Key=" + row.key + ", Scope=" + row.from_date.ToShortDateString() + "-" + row.to_date.ToShortDateString());
            }
        }

        private bool IsLicenseKeyExist(string key)
        {
            var ret = false;
            foreach (var row in _licenses)
            {
                if (row.key == key)
                {
                    ret = true;
                    break;
                }
            }

            return ret;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveTableData();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            var table = (DataTable)dgvw.DataSource;
            table.Rows.InsertAt(table.NewRow(), dgvw.CurrentCell.RowIndex);
        }

        private void btnDn_Click(object sender, EventArgs e)
        {
            var table = (DataTable)dgvw.DataSource;
            table.Rows.InsertAt(table.NewRow(), dgvw.CurrentCell.RowIndex + 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog { Filter = "Database Files (*.dat) | *.dat" };
            var res = dialog.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                ConnectExecuteSqlTab(dialog.FileName);
            }
        }

        private void ConnectExecuteSqlTab(string dbFilename)
        {
            _sqlEx = new SqlExecute();
            _sqlEx.InitilizeDBConnection(dbFilename);
            txtDbFilename.Text = dbFilename;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (_sqlEx != null)
            {
                var queries = txtSQL.Text.Split(';');
                var error = string.Empty;
                var success = string.Empty;
                var countError = 0;
                var countSuccess = 0;

                foreach (var sql in queries)
                {
                    if (sql.Trim().Length > 0)
                    {
                        try
                        {
                            _sqlEx.ExecuteSqlStatement(sql);
                            countSuccess++;
                            success +=
                                string.Empty.PadLeft(20, '-')
                                + "\r\n-- SUCCESS QUERY:\r\n"
                                + string.Empty.PadLeft(20, '-')
                                + "\r\n" + sql + "\r\n\r\n";
                        }
                        catch (Exception ex)
                        {
                            countError++;
                            error +=
                                string.Empty.PadLeft(20, '-')
                                + "\r\n-- ERROR QUERY MESSAGE:" + ex.Message + "\r\n"
                                + string.Empty.PadLeft(20, '-')
                                + "\r\n" + sql + "\r\n\r\n";
                        }
                    }
                }

                if (countError == 0)
                {
                    MessageBox.Show("Execute of " + countSuccess.ToString() + " queries finish successfuly", "Execute SQL...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(countSuccess.ToString() + " Executed successfuly\n" + countError.ToString() + " Fails!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    var text =
                        "Error Scripts:\r\n\r\n" + error + string.Empty.PadLeft(20, '*') +
                        "\r\n" + string.Empty.PadLeft(20, '*') + "\r\n\r\n" +
                        "Success Scripts:\r\n\r\n" + success;

                    var f = new frmNotepad(text);
                    f.Show();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var f = new frmDBCompare();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var text = string.Empty;
            if (cmbLicense.SelectedIndex >= 0)
            {
                text = Security.SaveLicence((ProductLicense)_licenses[cmbLicense.SelectedIndex].Table.DataSet);
                text = text.Replace("\"", "\"\"");
                text = text.Replace("\n", string.Empty);

                text = string.Format("INSERT INTO tblLicenses (license_key, date_register) VALUES (\"{0}\", Now())", text);
            }

            txtLicenseSQL.Text = text;
        }

        private string GetAddress(string[] parts)
        {
            var tmp = string.Empty;
            for (var i = 1; i < parts.Length; i++)
            {
                tmp += parts[i] + " ";
            }
            return tmp.Trim();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            #region iMaster Import

            var reader = new StreamReader(txtSourceFile.Text, Encoding.Default);
            var writer = new StreamWriter(txtTargetfile.Text, false, Encoding.Default);

            string srcLine;
            string tarLine;
            string[] parts;
            var phones = new string[4];

            srcLine = reader.ReadLine();
            var counter = 0;

            while (reader.Peek() != 0)
            {
                counter++;
                tarLine = string.Empty;
                phones[0] = string.Empty;
                phones[1] = string.Empty;
                phones[2] = string.Empty;
                phones[3] = string.Empty;

                parts = srcLine.Split(',');
                if (parts.Length == 1) tarLine += GetFullName(parts[0].Trim()) + ",,,";
                else if (parts.Length > 1) tarLine += GetFullName(parts[0].Trim()) + "," + GetImportAddress(parts) + ",";
                else throw new Exception("Too few parts");

                srcLine = reader.ReadLine();
                if (srcLine == null) break;
                if (srcLine.EndsWith("2008 Created with iMaster"))
                {
                    srcLine = reader.ReadLine();
                    if (srcLine == null) break;
                }

                srcLine = srcLine.Replace("ת. לידה", string.Empty);
                tarLine += srcLine.Trim() + ",";

                srcLine = reader.ReadLine();
                if (srcLine == null) break;
                if (srcLine.EndsWith("2008 Created with iMaster"))
                {
                    srcLine = reader.ReadLine();
                    if (srcLine == null) break;
                }
                srcLine = reader.ReadLine();
                if (srcLine == null) break;
                if (srcLine.EndsWith("2008 Created with iMaster"))
                {
                    srcLine = reader.ReadLine();
                    if (srcLine == null) break;
                }
                srcLine = srcLine.Replace("ת. רישום", string.Empty);
                tarLine += srcLine.Trim() + ",";

                srcLine = reader.ReadLine();
                if (srcLine == null) break;
                if (srcLine.EndsWith("2008 Created with iMaster"))
                {
                    srcLine = reader.ReadLine();
                    if (srcLine == null) break;
                }
                srcLine = reader.ReadLine();
                if (srcLine == null) break;
                if (srcLine.EndsWith("2008 Created with iMaster"))
                {
                    srcLine = reader.ReadLine();
                    if (srcLine == null) break;
                }
                srcLine = srcLine.Replace("מין", string.Empty);
                if (srcLine.Length > 0) srcLine = "0";
                else srcLine = "1";
                tarLine += srcLine.Trim() + ",";

                #region Phone1

                srcLine = reader.ReadLine();
                if (srcLine == null) break;
                if (srcLine.EndsWith("2008 Created with iMaster"))
                {
                    srcLine = reader.ReadLine();
                    if (srcLine == null) break;
                }
                if (srcLine.StartsWith("נייד"))
                {
                    if (phones[0].Length == 0) phones[0] = srcLine.Replace("נייד", string.Empty).Trim();
                    else phones[1] = srcLine.Replace("נייד", string.Empty).Trim();
                }
                else if (srcLine.StartsWith("בית"))
                {
                    if (phones[2].Length == 0) phones[2] = srcLine.Replace("בית", string.Empty).Trim();
                    else phones[3] = srcLine.Replace("בית", string.Empty).Trim();
                }
                else if (srcLine.StartsWith("[ בית"))
                {
                    if (phones[2].Length == 0) phones[2] = srcLine.Replace("בית", string.Empty).Trim();
                    else phones[3] = srcLine.Replace("[ בית", string.Empty).Trim();
                }
                else if (srcLine.StartsWith("0"))
                {
                    phones[3] = srcLine.Trim();
                }
                else
                {
                    WriteLineToFile(writer, tarLine, phones);
                    continue;
                }

                #endregion Phone1

                #region Phone2

                srcLine = reader.ReadLine();
                if (srcLine == null) break;
                if (srcLine.EndsWith("2008 Created with iMaster"))
                {
                    srcLine = reader.ReadLine();
                    if (srcLine == null) break;
                }
                if (srcLine.StartsWith("נייד"))
                {
                    if (phones[0].Length == 0) phones[0] = srcLine.Replace("נייד", string.Empty).Trim();
                    else phones[1] = srcLine.Replace("נייד", string.Empty).Trim();
                }
                else if (srcLine.StartsWith("בית"))
                {
                    if (phones[2].Length == 0) phones[2] = srcLine.Replace("בית", string.Empty).Trim();
                    else phones[3] = srcLine.Replace("בית", string.Empty).Trim();
                }
                else if (srcLine.StartsWith("[ בית"))
                {
                    if (phones[2].Length == 0) phones[2] = srcLine.Replace("בית", string.Empty).Trim();
                    else phones[3] = srcLine.Replace("[ בית", string.Empty).Trim();
                }
                else if (srcLine.StartsWith("0"))
                {
                    phones[3] = srcLine.Trim();
                }
                else
                {
                    WriteLineToFile(writer, tarLine, phones);
                    continue;
                }

                #endregion Phone2

                #region Phone3

                srcLine = reader.ReadLine();
                if (srcLine == null) break;
                if (srcLine.EndsWith("2008 Created with iMaster"))
                {
                    srcLine = reader.ReadLine();
                    if (srcLine == null) break;
                }
                if (srcLine.StartsWith("נייד"))
                {
                    if (phones[0].Length == 0) phones[0] = srcLine.Replace("נייד", string.Empty).Trim();
                    else phones[1] = srcLine.Replace("נייד", string.Empty).Trim();
                }
                else if (srcLine.StartsWith("בית"))
                {
                    if (phones[2].Length == 0) phones[2] = srcLine.Replace("בית", string.Empty).Trim();
                    else phones[3] = srcLine.Replace("בית", string.Empty).Trim();
                }
                else if (srcLine.StartsWith("[ בית"))
                {
                    if (phones[2].Length == 0) phones[2] = srcLine.Replace("בית", string.Empty).Trim();
                    else phones[3] = srcLine.Replace("[ בית", string.Empty).Trim();
                }
                else if (srcLine.StartsWith("0"))
                {
                    phones[3] = srcLine.Trim();
                }
                else
                {
                    WriteLineToFile(writer, tarLine, phones);
                    continue;
                }

                #endregion Phone3

                #region Phone4

                srcLine = reader.ReadLine();
                if (srcLine == null) break;
                if (srcLine.EndsWith("2008 Created with iMaster"))
                {
                    srcLine = reader.ReadLine();
                    if (srcLine == null) break;
                }
                if (srcLine.StartsWith("נייד"))
                {
                    if (phones[0].Length == 0) phones[0] = srcLine.Replace("נייד", string.Empty).Trim();
                    else phones[1] = srcLine.Replace("נייד", string.Empty).Trim();
                }
                else if (srcLine.StartsWith("בית"))
                {
                    if (phones[2].Length == 0) phones[2] = srcLine.Replace("בית", string.Empty).Trim();
                    else phones[3] = srcLine.Replace("בית", string.Empty).Trim();
                }
                else if (srcLine.StartsWith("[ בית"))
                {
                    if (phones[2].Length == 0) phones[2] = srcLine.Replace("בית", string.Empty).Trim();
                    else phones[3] = srcLine.Replace("[ בית", string.Empty).Trim();
                }
                else if (srcLine.StartsWith("0"))
                {
                    phones[3] = srcLine.Trim();
                }
                else
                {
                    WriteLineToFile(writer, tarLine, phones);
                    continue;
                }

                #endregion Phone4

                WriteLineToFile(writer, tarLine, phones);
            }

            reader.Close();
            writer.Close();

            #endregion iMaster Import
        }

        private void WriteLineToFile(StreamWriter writer, string baseLine, string[] phones)
        {
            writer.WriteLine(baseLine + phones[0] + "," + phones[1] + "," + phones[2] + "," + phones[3]);
        }

        private string GetFullName(string name)
        {
            var parts = name.Split(' ');

            if (parts.Length == 2) return parts[0].Trim() + "," + parts[1].Trim();
            else if (parts.Length > 2) return parts[0].Trim() + "," + name.Substring(name.IndexOf(' ')).Trim();
            else return name + ",";
        }

        private string GetImportAddress(string[] parts)
        {
            var tmp = string.Empty;
            for (var i = 1; i < parts.Length; i++)
            {
                tmp += parts[i];
            }
            tmp = tmp.Trim();

            tmp = ReplaceCity(tmp, "תל אביב");
            tmp = ReplaceCity(tmp, "רמת גן");
            tmp = ReplaceCity(tmp, "גבעתיים");
            tmp = ReplaceCity(tmp, "הרצליה");
            tmp = ReplaceCity(tmp, "ראשון לציון");
            tmp = ReplaceCity(tmp, "יהוד");
            tmp = ReplaceCity(tmp, "חיפה");
            tmp = ReplaceCity(tmp, "בני ברק");
            tmp = ReplaceCity(tmp, "חולון");
            tmp = ReplaceCity(tmp, "קרית אונו");
            tmp = ReplaceCity(tmp, "בת ים");
            tmp = ReplaceCity(tmp, "נצרת");
            tmp = ReplaceCity(tmp, "צור יגאל");
            tmp = ReplaceCity(tmp, "ירושלים");
            tmp = ReplaceCity(tmp, "ראש העין");
            tmp = ReplaceCity(tmp, "רחובות");
            tmp = ReplaceCity(tmp, "עמק בית שאן");
            tmp = ReplaceCity(tmp, "פתח תקוה");
            tmp = ReplaceCity(tmp, "גנות");
            tmp = ReplaceCity(tmp, "עומר");
            tmp = ReplaceCity(tmp, "גני תקוה");
            tmp = ReplaceCity(tmp, "רעות");
            tmp = ReplaceCity(tmp, "נתניה");
            tmp = ReplaceCity(tmp, "רמלה");
            tmp = ReplaceCity(tmp, "כפר אז\"ר");
            tmp = ReplaceCity(tmp, "רמת השרון");
            tmp = ReplaceCity(tmp, "שיקמים");
            tmp = ReplaceCity(tmp, "אשדוד");
            tmp = ReplaceCity(tmp, "קרית טבעון");
            tmp = ReplaceCity(tmp, "רעננה");
            tmp = ReplaceCity(tmp, "חבצלת השרון");
            tmp = ReplaceCity(tmp, "אור יהודה");
            tmp = ReplaceCity(tmp, "זיתן");
            tmp = ReplaceCity(tmp, "סביון");
            tmp = ReplaceCity(tmp, "רמת אפעל");
            tmp = ReplaceCity(tmp, "כפש שמריהו");
            tmp = ReplaceCity(tmp, "כפר סבא");
            tmp = ReplaceCity(tmp, "קרית מלאכי");
            tmp = ReplaceCity(tmp, "נס ציונה");
            tmp = ReplaceCity(tmp, "כפר סילבר");
            tmp = ReplaceCity(tmp, "אשקלון");

            tmp = ReplaceCity(tmp, "מושב ערוגות");
            tmp = ReplaceCity(tmp, "כפר מרדכי");
            tmp = ReplaceCity(tmp, "רגבה");
            tmp = ReplaceCity(tmp, "גבעת דאוונס ");
            tmp = ReplaceCity(tmp, "כפר שמריהו");
            tmp = ReplaceCity(tmp, "יפו");
            tmp = ReplaceCity(tmp, "אורנית");
            tmp = ReplaceCity(tmp, "כפר תבור");
            tmp = ReplaceCity(tmp, "גבעת שמואל");
            tmp = ReplaceCity(tmp, "ערד");
            tmp = ReplaceCity(tmp, "שפיים");
            tmp = ReplaceCity(tmp, "בית חרות");
            tmp = ReplaceCity(tmp, "בת חפר");
            tmp = ReplaceCity(tmp, "מודיעין");
            tmp = ReplaceCity(tmp, "קיסריה");
            tmp = ReplaceCity(tmp, "בית יהושוע");
            tmp = ReplaceCity(tmp, "מרום גליל");
            tmp = ReplaceCity(tmp, "משגב");
            tmp = ReplaceCity(tmp, "קיבוץ חצרים");
            tmp = ReplaceCity(tmp, "הוד השרון");
            tmp = ReplaceCity(tmp, "כפר אחים");
            tmp = ReplaceCity(tmp, "בנימינה");
            tmp = ReplaceCity(tmp, "קיבות מעברות");
            tmp = ReplaceCity(tmp, "יבנה");
            tmp = ReplaceCity(tmp, "גני אביב");

            tmp = ReplaceCity(tmp, "אלקנה");
            tmp = ReplaceCity(tmp, "אילת");
            tmp = ReplaceCity(tmp, "גני תקווה");
            tmp = ReplaceCity(tmp, "כפר יהושוע");
            tmp = ReplaceCity(tmp, "משגב");
            tmp = ReplaceCity(tmp, "מתן");
            tmp = ReplaceCity(tmp, "לוד");
            tmp = ReplaceCity(tmp, "מעגן מיכאל");
            tmp = ReplaceCity(tmp, "עפולה");
            tmp = ReplaceCity(tmp, "כפר ויתקין");

            tmp = ReplaceCity(tmp, "נאות אחוה");
            tmp = ReplaceCity(tmp, "מושב בן-שמן");
            tmp = ReplaceCity(tmp, "קיבוץ מעברות");
            tmp = ReplaceCity(tmp, "מזכרת בתיה");
            tmp = ReplaceCity(tmp, "צורן");
            tmp = ReplaceCity(tmp, "מושב באר טוביה");
            tmp = ReplaceCity(tmp, "קרית קטירה");

            tmp = ReplaceCity(tmp, "מושב בני עטרות");
            tmp = ReplaceCity(tmp, "נהריה");
            tmp = ReplaceCity(tmp, "בית דגן");
            tmp = ReplaceCity(tmp, "כוכב יאיר");
            tmp = ReplaceCity(tmp, "מבשרת ציון");
            tmp = ReplaceCity(tmp, "כפר סירקין");

            if (tmp.IndexOf(',') == -1) tmp = tmp + ",";

            return tmp;
        }

        public string ReplaceCity(string tmp, string city)
        {
            var index = tmp.IndexOf(city);
            if (index >= 0)
            {
                tmp = tmp.Substring(0, index).Replace(",", string.Empty) + "," + city + tmp.Substring(index + city.Length).Replace(",", string.Empty);
                //tmp = tmp.Replace(city, "," + city);
            }
            return tmp;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var sConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"content.dat\";Persist Security Info=False;Jet OLEDB:Database Password=37614463";
            var conn = new OleDbConnection(sConn);

            var sSelectTar = "SELECT * FROM tblClients";
            var sSelectSrc = "SELECT * FROM res";

            var adpTar = new OleDbDataAdapter(sSelectTar, conn);
            var cb = new OleDbCommandBuilder(adpTar);
            adpTar.UpdateCommand = cb.GetUpdateCommand();
            var dsTar = new DataSet();
            adpTar.Fill(dsTar);

            var adpSrc = new OleDbDataAdapter(sSelectSrc, conn);
            var dsSrc = new DataSet();
            adpSrc.Fill(dsSrc);

            string tmp;
            var count = 0;
            foreach (DataRow tar in dsTar.Tables[0].Rows)
            {
                if (!DBNull.Value.Equals(tar["cell_phone_1"]))
                {
                    tmp = Convert.ToString(tar["cell_phone_1"]);
                    if (tmp.Length == 4)
                    {
                        tar["cell_phone_1"] = GetFixCellPhone(dsSrc, tar);
                        count++;
                    }
                }
            }

            adpTar.Update(dsTar);
            MessageBox.Show(count.ToString() + " row(s) updated");
        }

        private string GetFixCellPhone(DataSet ds, DataRow tar)
        {
            var phone = string.Empty;

            foreach (DataRow src in ds.Tables[0].Rows)
            {
                if (src["first_name"].Equals(tar["first_name"]))
                {
                    if (src["last_name"].Equals(tar["last_name"]))
                    {
                        if (src["city"].Equals(tar["city"]))
                        {
                            if (src["zip_code"].Equals(tar["zipcode"]))
                            {
                                if (phone.Length == 0)
                                {
                                    phone = DBNull.Value.Equals(src["cell_phone1"]) ? string.Empty : Convert.ToString(src["cell_phone1"]);
                                    break;
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                        }
                    }
                }
            }

            return phone;
        }

        private void cmbLicense_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLicense.SelectedIndex == -1)
            {
                ShowLicense(null);
            }
            else
            {
                ShowLicense(_licenses[cmbLicense.SelectedIndex]);
            }
        }

        private void tbbReset_Click(object sender, EventArgs e)
        {
            dtpLast.Value = DateTime.Now;
        }

        private void btnUpdateLic_Click(object sender, EventArgs e)
        {
            var key = GetLicenseFromScreen();
            var index = cmbLicense.SelectedIndex;
            var id = _licensesIds[index];
            if (LicenceHelper.UpdateLicense(id, key))
            {
                MessageBox.Show("License updated successfuly", "Information...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillLicenseCombo();
                if (cmbLicense.Items.Count > index) cmbLicense.SelectedIndex = index;
            }
            else
            {
                MessageBox.Show("Error while updated license", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteLic_Click(object sender, EventArgs e)
        {
            if (LicenceHelper.DeleteLicense(_licensesIds[cmbLicense.SelectedIndex]))
            {
                MessageBox.Show("License deleted successfuly", "Information...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillLicenseCombo();
                if (cmbLicense.Items.Count > 0) cmbLicense.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Error while deleted license", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetValue(DataRow row, string fieldName, Client client, string propName)
        {
            string value;
            foreach (var pi in _propInfos)
            {
                if (pi.Name == fieldName)
                {
                    value = Utils.GetDBValue<string>(row, fieldName);
                    pi.SetValue(client, Convert.ChangeType(value, pi.GetType()), null);
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"{0}\";Extended Properties=\"Excel 8.0;HDR={1};IMEX=1\";";
            connString = string.Format(connString, txtSourceFile.Text, "Yes");
            var conn = new OleDbConnection(connString);
            var adp = new OleDbDataAdapter("SELECT * FROM [" + txtWorksheet.Text + "$]", conn);
            var ds = new DataSet();
            adp.Fill(ds);

            string tmp;
            int i, index = 0;
            long l;
            var list = new List<Client>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                var c = new Client();

                foreach (DataColumn col in ds.Tables[0].Columns)
                {
                    switch (col.ColumnName)
                    {
                        case "first_name":
                            c.FirstName = Utils.GetDBValue<string>(row, col.ColumnName, string.Empty);
                            break;

                        case "last_name":
                            c.LastName = Utils.GetDBValue<string>(row, col.ColumnName, string.Empty);
                            break;

                        case "home_phone":
                            c.HomePhone = Utils.GetDBValue<string>(row, col.ColumnName, string.Empty);
                            break;

                        case "work_phone":
                            c.WorkPhone = Utils.GetDBValue<string>(row, col.ColumnName, string.Empty);
                            break;

                        case "cell_phone_1":
                            tmp = Utils.GetDBValue<string>(row, col.ColumnName, string.Empty).Trim();
                            if (tmp.Length > 0)
                            {
                                tmp = Utils.DistilPhone(tmp);
                                if (!tmp.StartsWith("0")) tmp = "0" + tmp;
                                if (Validation.IsCellPhoneValid(tmp)) c.CellPhone1 = Validation.FormatPhone(tmp);
                                else
                                {
                                    if (long.TryParse(tmp, out l)) c.CellPhone1 = Validation.FormatPhone(tmp);
                                }
                            }
                            break;

                        case "cell_phone_2":
                            tmp = Utils.GetDBValue<string>(row, col.ColumnName, string.Empty).Trim();
                            if (tmp.Length > 0)
                            {
                                tmp = Utils.DistilPhone(tmp);
                                if (!tmp.StartsWith("0")) tmp = "0" + tmp;
                                if (Validation.IsCellPhoneValid(tmp)) c.CellPhone2 = Validation.FormatPhone(tmp);
                                else
                                {
                                    if (long.TryParse(tmp, out l)) c.CellPhone2 = Validation.FormatPhone(tmp);
                                }
                            }
                            break;

                        case "birth_date":
                            c.BirthDate = Utils.GetDBValue<DateTime?>(row, col.ColumnName);
                            break;

                        case "address":
                            c.Address = Utils.GetDBValue<string>(row, col.ColumnName, string.Empty);
                            break;

                        case "city":
                            c.City = Utils.GetDBValue<string>(row, col.ColumnName, string.Empty);
                            break;

                        case "zipcode":
                            c.ZipCode = Utils.GetDBValue<string>(row, col.ColumnName, string.Empty);
                            break;

                        case "married_date":
                            c.MarriedDate = Utils.GetDBValue<DateTime?>(row, col.ColumnName);
                            break;

                        case "email":
                            c.Email = Utils.GetDBValue<string>(row, col.ColumnName, string.Empty);
                            break;

                        case "picture":
                            c.Picture = Utils.GetDBValue<string>(row, col.ColumnName, string.Empty);
                            break;

                        case "remark":
                            c.Remark = Utils.GetDBValue<string>(row, col.ColumnName, string.Empty);
                            break;

                        case "gender":
                            c.Gender = (Client.ClientGender)Utils.GetDBValue<int>(row, col.ColumnName);
                            tmp = Utils.GetDBValue<string>(row, col.ColumnName, string.Empty);
                            if (tmp.Trim() == "זכר") c.Gender = Client.ClientGender.Male;
                            else c.Gender = Client.ClientGender.Female;

                            break;

                        case "full_name":
                            tmp = Utils.GetDBValue<string>(row, col.ColumnName, string.Empty).Trim();
                            if (tmp.Length > 0)
                            {
                                i = tmp.IndexOf(" ");
                                if (i == -1)
                                {
                                    c.FirstName = tmp;
                                    c.LastName = "ללא שם";
                                }
                                else
                                {
                                    c.FirstName = tmp.Substring(0, i);
                                    c.LastName = tmp.Substring(i + 1).Trim();
                                }
                            }
                            break;

                        case "phone":
                            tmp = Utils.GetDBValue<string>(row, col.ColumnName, string.Empty).Trim();
                            if (tmp.Length > 0)
                            {
                                tmp = Utils.DistilPhone(tmp);
                                if (!tmp.StartsWith("0")) tmp = "0" + tmp;
                                if (tmp.StartsWith("06"))
                                {
                                    tmp = "04" + (tmp.Length == 8 ? "6" : string.Empty) + tmp.Substring(2);
                                }
                                if (Validation.IsLinePhoneValid(tmp)) c.HomePhone = Validation.FormatPhone(tmp);
                                else
                                {
                                    if (Validation.IsCellPhoneValid(tmp)) c.CellPhone1 = Validation.FormatPhone(tmp);
                                    else
                                    {
                                        if (long.TryParse(tmp, out l)) c.WorkPhone = tmp;
                                    }
                                }
                            }
                            break;

                        case "house_no":
                            tmp = Utils.GetDBValue<string>(row, col.ColumnName, string.Empty).Trim();
                            if (tmp.Length > 0) c.Address += " דירה " + tmp;
                            break;

                        default:
                            throw new Exception("Field " + col.ColumnName + " in file not recognized");
                    }
                }

                if (c.CellPhone1.Length == 0 && c.CellPhone2.Length > 0)
                {
                    c.CellPhone1 = c.CellPhone2;
                    c.CellPhone2 = string.Empty;
                }

                if (!string.IsNullOrEmpty(c.Picture))
                {
                    if (c.Picture.StartsWith("c:\\pictures\\")) c.Picture = c.Picture.Replace("c:\\pictures\\", "c:\\softhair\\clientimages\\");
                    if (c.Picture.EndsWith(".bmp")) c.Picture = c.Picture.Replace(".bmp", ".jpg");
                }

                c.CellPhone1 = FixOldCellPhone(c.CellPhone1);
                c.CellPhone2 = FixOldCellPhone(c.CellPhone2);

                list.Add(c);
            }

            foreach (var cl in list)
            {
                ClientHelper.AddClient(cl);
                index++;
                lblProgress.Text = index.ToString() + " of " + ds.Tables[0].Rows.Count.ToString();
                Application.DoEvents();
            }
        }

        private string FixOldCellPhone(string phone)
        {
            phone = Utils.DistilPhone(phone);

            if (phone.Length == 9)
            {
                if (phone.StartsWith("050")) phone = "0505" + phone.Substring(3);
                if (phone.StartsWith("051")) phone = "0507" + phone.Substring(3);
                if (phone.StartsWith("056")) phone = "0506" + phone.Substring(3);
                if (phone.StartsWith("068")) phone = "0508" + phone.Substring(3);

                if (phone.StartsWith("052")) phone = "0522" + phone.Substring(3);
                if (phone.StartsWith("053")) phone = "0523" + phone.Substring(3);
                if (phone.StartsWith("058")) phone = "0528" + phone.Substring(3);
                if (phone.StartsWith("064")) phone = "0524" + phone.Substring(3);
                if (phone.StartsWith("065")) phone = "0525" + phone.Substring(3);

                if (phone.StartsWith("054")) phone = "0544" + phone.Substring(3);
                if (phone.StartsWith("055")) phone = "0545" + phone.Substring(3);
                if (phone.StartsWith("066")) phone = "0546" + phone.Substring(3);
                if (phone.StartsWith("067")) phone = "0547" + phone.Substring(3);

                if (phone.StartsWith("057")) phone = "0577" + phone.Substring(3);

                if (phone.StartsWith("059")) phone = "0599" + phone.Substring(3);
            }

            phone = Validation.FormatPhone(phone);

            return phone;
        }

        private void btnScript_Click(object sender, EventArgs e)
        {
            var f = new FrmScriptReport();
            f.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSQL.Clear();
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            var d = new OpenFileDialog();
            d.CheckFileExists = true;
            d.CheckPathExists = true;
            d.DefaultExt = "txt";
            d.Filter = "Text files (*.txt)|*.txt";
            if (d.ShowDialog(this) == DialogResult.OK)
            {
                var reader = new StreamReader(d.FileName, Encoding.Default);
                txtSQL.Text = reader.ReadToEnd();
                reader.Close();
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(btnMenu, 0, btnMenu.Height);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
        }

        private void mnu1_Click(object sender, EventArgs e)
        {
            txtSQL.Text = GetResource("Script_Hair.txt");
        }

        public string GetResource(string filename)
        {
            var asm = Assembly.GetExecutingAssembly();
            var val = string.Empty;

            // resources are named using a fully qualified name
            using (var stream = asm.GetManifestResourceStream(asm.GetName().Name + "." + filename))
            {
                if (stream != null)
                {
                    // read the contents of the embedded file
                    var reader = new StreamReader(stream, Encoding.Default);
                    val = reader.ReadToEnd();
                    reader.Close();
                }
            }

            return val;
        }

        private void mnu2_Click(object sender, EventArgs e)
        {
            txtSQL.Text = GetResource("Script_Nail.txt");
        }
    }
}