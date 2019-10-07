using ClientManage.BL;
using ClientManage.BL.Library;
using ClientManage.Forms;
using ClientManage.Interfaces;
using ClientManage.Interfaces.Schemas;
using ClientManage.Library;
using ClientManage.SmsFactoryService;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ClientManage.UserControls
{
    public partial class ReportParametersPanel : UserControl
    {
        public event EventHandler SelectedReportChanged;

        private ReportSchema _report;
        private DataGridView _dataGrid;
        private readonly DgvLoadImages _imageLoader = new DgvLoadImages();
        private int _calcHeight;
        private const int FieldControlWidth = 210;
        private readonly string _rowsCountSyntax = string.Empty;
        private Timer _timer;
        private static int _reportId = -1;
        private bool _isLogOn;
        private string _savedParametersString = string.Empty;

        public ReportParametersPanel()
        {
            InitializeComponent();
            _imageLoader.PicturePathColumn = "gdv_column_picture";
            _imageLoader.ImageColumn = "gdv_column_image";
            _rowsCountSyntax = lblRowsCount.Text;
        }

        public DataGridView DataGrid
        {
            get { return _dataGrid; }
            set { _dataGrid = value; }
        }

        public static int ReportId
        {
            get { return _reportId; }
        }

        public string SavedParametersString
        {
            get { return _savedParametersString; }
        }

        public string DoubleClickCommand
        {
            get
            {
                if (_report == null) return string.Empty;

                return _report.General[0].DoubleClickCommand;
            }
        }

        public string ReportName
        {
            get
            {
                return cmbReport.Text;
            }
        }

        public string ReportExportFileName
        {
            get
            {
                var name = this.ReportName;
                name = name.Replace("/", string.Empty)
                    .Replace("\\", string.Empty)
                    .Replace(":", string.Empty)
                    .Replace("*", string.Empty)
                    .Replace("?", string.Empty)
                    .Replace("<", string.Empty)
                    .Replace(">", string.Empty)
                    .Replace("|", string.Empty);

                return name;
            }
        }

        private void InitializeCombos()
        {
            try
            {
                cmbGroup.DisplayMember = "report_group";
                cmbGroup.ValueMember = "report_group";
                cmbGroup.DataSource = ReportHelper.GetReportsGroup();
                //cmbGroup.SelectedIndex = -1;
            }
            catch { Utils.CatchException(); }
        }

        private static void FillCares(DataTable table)
        {
            if (table.Columns.Contains("cares_tofill"))
            {
                for (var i = 0; i < table.Rows.Count; i++)
                {
                    table.Rows[i]["cares_tofill"] = CalendarHelper.GetCaresDescription(Utils.GetDBValue<string>(table.Rows[i]["cares_tofill"]));
                }
            }
        }

        private void Initialize()
        {
            pnlFields.Visible = false;
            pnlFields.Controls.Clear();
            if (_report == null) return;

            var i = 4;
            var maxWidth = 0;
            ReportParameterField field;
            DateRangeData rangeData = null;

            foreach (ReportSchema.ParametersRow row in _report.Parameters.Rows)
            {
                var dataType = (ReportParameterField.FieldDataType)row.DataType;

                if (dataType == ReportParameterField.FieldDataType.DateTimeRange && row.Name.StartsWith("dtFromRange"))
                {
                    rangeData = new DateRangeData
                    {
                        ParameterName = row.Name,
                        Caption = row.Text,
                        DefaultValue = row.DefaultValue
                    };
                    continue;
                }

                field = new ReportParameterField(dataType);

                if (dataType == ReportParameterField.FieldDataType.QueryListCombo || dataType == ReportParameterField.FieldDataType.QuerySimpleCombo)
                {
                    if (row.ComboConstantId != -1)
                    {
                        var rows = _report.Constants.Select("id=" + row.ComboConstantId, "Order");
                        field.DataSource = ReportHelper.GetConstantsTableFromRows(rows);
                        field.DisplayMember = "text";
                        field.ValueMember = "value";
                    }
                    else
                    {
                        field.DataSource = ReportHelper.GetFieldQuery(row.ComboQuery);
                        field.DefaultComboDisplay = row.DefaultComboDisplay;
                        field.DisplayMember = row.ComboDisplayMember;
                        field.ValueMember = row.ComboValueMember;
                        field.ForceAddDefaultValue = row.ForceAddDefaultValue;
                    }
                }

                field.IsRequired = row.IsRequired;
                if (dataType == ReportParameterField.FieldDataType.DateTimeRange)
                {
                    if (rangeData != null)
                    {
                        field.Caption = rangeData.Caption + "\n" + row.Text;
                        field.DefaultValue = rangeData.DefaultValue + "," + row.DefaultValue;
                        field.ParameterName = rangeData.ParameterName + "," + row.Name;
                    }
                    field.Size = new Size(FieldControlWidth + 100, 51);
                    field.Name = "dtRange";
                }
                else
                {
                    field.Caption = row.Text;
                    field.Size = new Size(FieldControlWidth + 100, 26);
                    field.DefaultValue = row.DefaultValue;
                    field.Name = row.Name;
                    field.ParameterName = row.Name;
                }
                field.FieldControlWidth = FieldControlWidth;
                field.QueryMergeType = (ReportParameterField.FieldQueryMerge)row.Type;
                field.Location = new Point(8, i);
                field.Visible = true;
                i += 24;
                if (dataType == ReportParameterField.FieldDataType.DateTimeRange) i += 25;
                var curWidth = Convert.ToInt32(this.CreateGraphics().MeasureString(field.Caption, field.CaptionFont).Width);
                if (curWidth > maxWidth) maxWidth = curWidth;

                pnlFields.Controls.Add(field);
            }

            _calcHeight = i + 8;
            if (pnlFields.Controls.Count == 0) _calcHeight = 0;
            if (maxWidth < 63) maxWidth = 63;
            this.Height = pnlButton.Height + _calcHeight;
            ShowParameters();
            pnlFields.Width = FieldControlWidth + maxWidth + 40;
            ArrangePnlButtons();
            SetFieldsWidth();
            pnlFields.Visible = true;
        }

        private void SetFieldsWidth()
        {
            foreach (ReportParameterField field in pnlFields.Controls)
            {
                field.Width = pnlFields.Width - 16;
                field.Initialize();
            }
        }

        private void ArrangePnlButtons()
        {
            var left = this.Width - pnlFields.Width + 26;
            var width = pnlFields.Width - 22;

            cmbGroup.Left = left;
            cmbReport.Left = left;
            lblErrGroup.Left = left - 19;
            lblErrReport.Left = left - 19;
            cmbGroup.Width = width - 80;
            cmbReport.Width = width - 80;
            lblDiv2.Left = left - 8;
            lblDiv2.Width = width;
            lblDiv2.Visible = pnlFields.Controls.Count > 0;
            xpFlatButton1.Visible = lblDiv2.Visible;
            btnShowReport.Left = this.Width - pnlFields.Width - btnShowReport.Width - 8;
            lblRowsCount.Left = btnShowReport.Left;
        }

        private bool ValidateFields()
        {
            var msg = string.Empty;
            var cnt = 0;

            if (cmbGroup.SelectedIndex < 0)
            {
                msg += "• " + "בחר תחילה את קבוצת הדוחות הרצויה\n";
                lblErrGroup.Visible = true;
                cnt++;
            }
            else
            {
                lblErrGroup.Visible = false;
            }
            if (cmbReport.SelectedIndex < 0)
            {
                msg += "• " + "בחר תחילה את הדוח הרצוי\n";
                lblErrReport.Visible = true;
                cnt++;
            }
            else
            {
                lblErrReport.Visible = false;
            }

            foreach (ReportParameterField field in pnlFields.Controls)
            {
                field.ValidateField();
                if (field.ErrorMessage.Length > 0)
                {
                    msg += field.ErrorMessage + "\n";
                    cnt++;
                }
            }

            if (13 * cnt > _calcHeight)
            {
                this.Height = pnlButton.Height + (13 * cnt) + 8;
                ShowParameters();
            }
            else
            {
                this.Height = pnlButton.Height + _calcHeight;
                ShowParameters();
            }

            if (msg.Length == 0) msg = ValidateCustom();

            lblErrorMessage.Text = msg;
            return msg.Length == 0;
        }

        private string ValidateCustom()
        {
            var msg = string.Empty;
            CodeExecuter exec;
            var code = string.Empty;

            foreach (ReportSchema.CustomValidationRow row in _report.CustomValidation.Rows)
            {
                if (code.Length == 0) code = GetCustomValidationFieldsDeclare();
                exec = new CodeExecuter(code + row.Code);
                var res = exec.Execute();

                if (res == CodeExecuter.ExecutionResult.Success)
                {
                    var ret = (bool)exec.ReturnValue;
                    if (ret == false)
                    {
                        msg += "• " + row.ErrorMessage + "\n";
                    }
                }
            }

            return msg;
        }

        private string GetCustomValidationFieldsDeclare()
        {
            var ret = string.Empty;

            // ReSharper disable LoopCanBeConvertedToQuery
            foreach (ReportParameterField field in pnlFields.Controls)
            // ReSharper restore LoopCanBeConvertedToQuery
            {
                ret += field.GetCustomValidationCode() + "\r\n";
            }
            return ret;
        }

        private void SortColumns()
        {
            var displayIndex = 0;
            foreach (ReportSchema.ColumnsRow row in _report.Columns.Rows)
            {
                if (row.Visible)
                {
                    var col = _dataGrid.Columns["gdv_column_" + row.Name];
                    if (col != null)
                    {
                        col.DisplayIndex = displayIndex++;
                    }
                }
            }
        }

        private void BuildDataGridColumns()
        {
            if (_dataGrid == null) return;

            _dataGrid.DataSource = null;
            _dataGrid.Columns.Clear();
            lblRowsCount.Visible = false;
            btnClear.Visible = false;
            DataGridViewColumn col;

            foreach (ReportSchema.ColumnsRow row in _report.Columns.Rows)
            {
                switch (row.ColumnType)
                {
                    case 1:
                        col = new DataGridViewButtonColumn();
                        break;

                    case 2:
                        col = new DataGridViewCheckBoxColumn();
                        break;

                    case 3:
                        col = new DataGridViewComboBoxColumn();
                        break;

                    case 4:
                        col = new DataGridViewImageColumn();
                        ((DataGridViewImageColumn)col).Image = Properties.Resources.hourglass;
                        ((DataGridViewImageColumn)col).ImageLayout = DataGridViewImageCellLayout.Stretch;
                        break;

                    case 5:
                        col = new DataGridViewLinkColumn();
                        ((DataGridViewLinkColumn)col).ActiveLinkColor = Color.Orange;
                        ((DataGridViewLinkColumn)col).LinkColor = Color.FromArgb(0, 0, 80);
                        ((DataGridViewLinkColumn)col).TrackVisitedState = false;
                        break;

                    case 6:
                        col = new DataGridViewTextBoxColumn();
                        break;

                    default:
                        col = new DataGridViewColumn();
                        break;
                }

                col.AutoSizeMode = row.AutoSize ? DataGridViewAutoSizeColumnMode.AllCells : DataGridViewAutoSizeColumnMode.None;
                col.DataPropertyName = row.DataPropertyName;
                col.DividerWidth = row.DividerWidth;
                col.FillWeight = row.FillWeight;
                col.Frozen = row.Frozen;
                col.ReadOnly = true;
                col.HeaderText = row.HeaderText;
                col.MinimumWidth = row.MinimumWidth;
                col.Name = "gdv_column_" + row.Name;
                col.Resizable = row.Resizable ? DataGridViewTriState.True : DataGridViewTriState.False;
                col.SortMode = row.EnableSort ? DataGridViewColumnSortMode.Automatic : DataGridViewColumnSortMode.NotSortable;
                col.ToolTipText = row.ToolTipText;
                col.Visible = row.Visible;

                col.Width = (General.ScreenResolutionFactorWidth == 1 || row.Name == "image") ?
                    row.Width :
                    Convert.ToInt32(row.Width * General.ScreenResolutionFactorWidth);

                if (row.DefaultCellStyle.Length > 0)
                {
                    col.DefaultCellStyle = DataGridViewCellStyleParser.GetCellStyle(row.DefaultCellStyle);
                }

                _dataGrid.Columns.Add(col);
            }
            AddUniqueKeyColumn();
        }

        private void AddUniqueKeyColumn()
        {
            var col = new DataGridViewTextBoxColumn
            {
                Name = "unique_row_number",
                DataPropertyName = "unique_row_number",
                Visible = false
            };
            _dataGrid.Columns.Add(col);
        }

        private void LoadImages()
        {
            if (_dataGrid.Columns.Contains("gdv_column_picture") || _dataGrid.Columns.Contains("gdv_column_image"))
            {
                _imageLoader.BeginLoadImages(_dataGrid);
            }
        }

        private void LoadReport(int reportId)
        {
            var xml = ReportHelper.GetReport(reportId);
            if (xml.Length == 0) return;
            _report = Security.DecryptReport(xml);
            Initialize();
        }

        private void ShowRowCountLabel()
        {
            var cnt = 0;
            if (_dataGrid.DataSource != null) cnt = ((DataTable)_dataGrid.DataSource).Rows.Count;
            lblRowsCount.Text = string.Format(_rowsCountSyntax, cnt);
            lblRowsCount.Visible = true;
        }

        private void BtnShowReportClick(object sender, EventArgs e)
        {
            ResetTimer();
            this.Cursor = Cursors.WaitCursor;

            if (ValidateFields())
            {
                var row = (ReportSchema.GeneralRow)_report.General.Rows[0];
                if (row.IsSecureReport && !_isLogOn)
                {
                    if (RequestAdminPassword())
                    {
                        LogOn();
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        return;
                    }
                }
                var query = ((ReportSchema.GeneralRow)_report.General.Rows[0]).SqlQuery;
                //SetReplaceParameters(ref query);
                var cares = GetCaresParameter();
                var p = GetValues();
                object[] parameters;
                if (cares == null)
                {
                    parameters = p;
                }
                else
                {
                    var list = p.ToList();
                    list.Add(cares);
                    parameters = list.ToArray();
                }

                DataTable table;

                try
                {
                    table = GetReportDataSource(query, parameters, row.ReportId);
                }
                catch (Exception ex)
                {
                    const string msg = "לא ניתן להציג את הנתונים לדוח המבוקש\nוודא כי הנך מחובר לרשת האינטרנט";
                    General.ShowErrorMessageDialog(this, this.Text, "קריאת נתונים לדוח", msg, ex, string.Empty);
                    this.Cursor = Cursors.Default;
                    return;
                }

                FillCares(table);
                SyncVisibleColumns(table);
                _dataGrid.DataBindingComplete += DataGrid_DataBindingComplete;
                _dataGrid.DataSource = table;
                LoadImages();
                ShowRowCountLabel();
                _dataGrid.Select();

                btnClear.Left = btnShowReport.Left - btnClear.Width - 1;
                btnClear.Visible = _dataGrid.Rows.Count > 0;
                _savedParametersString = GetParametersString();
            }
            else
            {
                BtnClearClick(null, null);
                lblRowsCount.Visible = false;
            }

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Handles the DataBindingComplete event of the DataGrid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.DataGridViewBindingCompleteEventArgs"/> instance containing the event data.</param>
        private void DataGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SortColumns();
        }

        /// <summary>
        /// Syncs the visible columns.
        /// </summary>
        /// <param name="table">The table.</param>
        private void SyncVisibleColumns(DataTable table)
        {
            foreach (DataColumn col in table.Columns)
            {
                if (!DataGrid.Columns.Contains("gdv_column_" + col.ColumnName))
                {
                    var column = new DataGridViewTextBoxColumn { DataPropertyName = col.ColumnName, Name = "gdv_column_" + col.ColumnName, Visible = false };
                    DataGrid.Columns.Add(column);
                }
            }
        }

        private static DataTable GetReportDataSource(string query, object[] parameters, int reportId)
        {
            DataTable table;
            SmsEngine smsEngine;
            if (query.StartsWith("[WebMethod]"))
            {
                var name = query.Replace("[WebMethod]", string.Empty).Trim();
                switch (name)
                {
                    case "GetMessagesDetailsReport":
                        smsEngine = new SmsEngine();
                        if (parameters[1] != null) parameters[1] = ((DateTime)parameters[1]).AddDays(1).AddSeconds(-1);
                        table = smsEngine.GetMessagesDetailsReport(new HistoryMessageFilter
                        {
                            DateCreatedFrom = (DateTime)parameters[0],
                            DateCreatedTo = (DateTime)parameters[1],
                            StatusId = parameters[2].Equals("1") ? (int?)1 : null, // : (int?)Convert.ToUInt32(parameters[2]),
                            EntityType = parameters[3].Equals(0) ? null : (int?)parameters[3],
                            NotSuccessStatus = parameters[2].Equals("0"),
                        }).Tables[0];
                        break;

                    case "GetMessagesCountReport":
                        smsEngine = new SmsEngine();
                        if (parameters[1] != null) parameters[1] = ((DateTime)parameters[1]).AddDays(1).AddSeconds(-1);
                        table = smsEngine.GetTotalMessagesPerDayReport(new TotalMessagesPerDayFilter
                        {
                            DateCreatedFrom = (DateTime)parameters[0],
                            DateCreatedTo = (DateTime)parameters[1]
                        }).Tables[0];
                        break;

                    default:
                        table = null;
                        break;
                }

                if (table != null)
                {
                    ReportHelper.AttachEntityToDataTable(table);
                    ReportHelper.AddCustomFieldsToDsReportDataTable(name, table);
                    //ReportHelper.SetCustomFilterToDsReportDataTable(name, ref table, parameters);
                }
            }
            else if (reportId == 10008)
            {
                table = CalendarHelper.GetCalendarDateReport((DateTime)parameters[0], (DateTime)parameters[1], (int)parameters[2]);
            }
            else if (reportId == 10019)
            {
                table = CalendarHelper.GetCalendarCaresReport((DateTime)parameters[0], (DateTime)parameters[1], (string[])parameters[2]);
            }
            else
            {
                if (reportId == 10006) query = string.Format(query, parameters[2]);
                else if (reportId == 10007) query = string.Format(query, parameters[1]);
                table = ReportHelper.GetReportDataSource(query, parameters);
            }

            return table;
        }

        private void CmbGroupSelectedIndexChanged(object sender, EventArgs e)
        {
            cmbReport.DisplayMember = "report_name";
            cmbReport.ValueMember = "id";
            cmbReport.DataSource = ReportHelper.GetReportsName(Convert.ToString(cmbGroup.SelectedValue));
            if (cmbGroup.SelectedIndex >= 0) lblErrGroup.Visible = false;
        }

        private void CmbReportSelectedIndexChanged(object sender, EventArgs e)
        {
            ResetTimer();
            lblErrorMessage.Text = string.Empty;
            if (cmbReport.SelectedIndex >= 0)
            {
                _reportId = (int)cmbReport.SelectedValue;
                lblErrReport.Visible = false;
                LoadReport(_reportId);
                BuildDataGridColumns();
                if (SelectedReportChanged != null) SelectedReportChanged(this, new EventArgs());
            }
        }

        private void ShowParameters()
        {
            const string title = "       הסתר פרמטרים";
            xpFlatButton1.Tag = null;
            xpFlatButton1.Image = Properties.Resources.hide_params;
            xpFlatButton1.Text = title;
            pnlFields.Refresh();
        }

        private object[] GetValues()
        {
            var arr = new ArrayList();

            for (var i = 0; i < pnlFields.Controls.Count; i++)
            {
                if (((ReportParameterField)pnlFields.Controls[i]).QueryMergeType == ReportParameterField.FieldQueryMerge.RegularParameter)
                {
                    var value = ((ReportParameterField)pnlFields.Controls[i]).GetParameterValue();
                    if (value is Array)
                    {
                        foreach (var obj in (Array)value)
                        {
                            arr.Add(obj);
                        }
                    }
                    else
                    {
                        arr.Add(value);
                    }
                }
            }

            var ret = new object[arr.Count];
            arr.CopyTo(ret);
            return ret;
        }

        private object GetCaresParameter()
        {
            for (var i = 0; i < pnlFields.Controls.Count; i++)
            {
                if (((ReportParameterField)pnlFields.Controls[i]).QueryMergeType == ReportParameterField.FieldQueryMerge.QueryReplace)
                {
                    return ((ReportParameterField)pnlFields.Controls[i]).GetParameterValue();
                }
            }
            return null;
        }

        private void SetReplaceParameters(ref string sql)
        {
            var arr = new ArrayList();

            for (var i = 0; i < pnlFields.Controls.Count; i++)
            {
                if (((ReportParameterField)pnlFields.Controls[i]).QueryMergeType == ReportParameterField.FieldQueryMerge.QueryReplace)
                {
                    var value = ((ReportParameterField)pnlFields.Controls[i]).GetParameterValue();
                    if (value is Array)
                    {
                        foreach (var obj in (Array)value)
                        {
                            arr.Add(obj.ToString());
                        }
                    }
                    else
                    {
                        arr.Add(value.ToString());
                    }
                }
            }

            var ret = new string[arr.Count];
            arr.CopyTo(ret);
            sql = string.Format(sql, ret);
        }

        private void ReportParametersPanel_Load(object sender, EventArgs e)
        {
            //this.Height = pnlButton.Height;
            InitializeCombos();
            ArrangePnlButtons();
            if (_dataGrid != null) _dataGrid.CellMouseDown += DataGridCellMouseDown;
        }

        private void DataGridCellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            ResetTimer();
        }

        private void SetValues(object[] parameters)
        {
            if (parameters != null)
            {
                for (var i = 0; i < pnlFields.Controls.Count; i++)
                {
                    if (parameters.Length <= i) break;
                    ((ReportParameterField)pnlFields.Controls[i]).SetValue(parameters[i]);
                }
            }
        }

        public void SelectReport(string reportGroup, int reportId, object[] parameters)
        {
            try { cmbGroup.SelectedValue = reportGroup; }
            catch { cmbGroup.SelectedIndex = -1; return; }
            if (cmbGroup.SelectedIndex < 0) return;

            try { cmbReport.SelectedValue = reportId; }
            catch { cmbReport.SelectedIndex = -1; return; }
            if (cmbReport.SelectedIndex < 0) return;

            SetValues(parameters);
        }

        public void ShowReport(string reportGroup, int reportId, object[] parameters)
        {
            SelectReport(reportGroup, reportId, parameters);
            BtnShowReportClick(null, null);
        }

        public bool EnableEmailCampaign
        {
            get { return ((ReportSchema.GeneralRow)_report.General.Rows[0]).EnableEmailCampaign; }
        }

        public bool EnablePrintStickers
        {
            get { return ((ReportSchema.GeneralRow)_report.General.Rows[0]).EnablePrintStickers; }
        }

        public bool EnableSendSms
        {
            get { return ((ReportSchema.GeneralRow)_report.General.Rows[0]).EnableSendSMS; }
        }

        public bool EnableExport
        {
            get { return ((ReportSchema.GeneralRow)_report.General.Rows[0]).EnableExport; }
        }

        private void XpFlatButton1Click(object sender, EventArgs e)
        {
            ResetTimer();
            if (xpFlatButton1.Tag == null)
            {
                const string title = "       הצג פרמטרים";
                xpFlatButton1.Tag = this.Height;
                this.Height = pnlButton.Height;
                xpFlatButton1.Image = Properties.Resources.show_params;
                xpFlatButton1.Text = title;
            }
            else
            {
                this.Height = (int)xpFlatButton1.Tag;
                xpFlatButton1.Tag = null;
                ShowParameters();
            }
        }

        private static bool RequestAdminPassword()
        {
            const string caption = "דוח זה ניתן להרצה ע\"י מנהל מערכת בלבד!\nאנא הזן את סיסמת המנהל שלך";
            var fPassword = new FormPassword(string.Empty, caption);
            var res = fPassword.ShowDialog();
            var ret = (res == DialogResult.OK);
            return ret;
        }

        private void LogOn()
        {
            _isLogOn = true;
            lblAdminInfo.Visible = true;
            btnLogOff.Visible = true;

            if (_timer == null)
            {
                _timer = new Timer
                {
                    Interval = AppSettingsHelper.GetParamValue<int>("REPORT_ADMIN_TIMEOUT") * 60000
                };
                _timer.Tick += TimerTick;
            }
            else
            {
                _timer.Enabled = false;
            }

            _timer.Enabled = true;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            BtnLogOffClick(null, null);
        }

        private void LogOff()
        {
            _isLogOn = false;
            lblAdminInfo.Visible = false;
            btnLogOff.Visible = false;
            if (_timer != null) _timer.Enabled = false;
        }

        private void ResetTimer()
        {
            if (_timer != null)
            {
                _timer.Enabled = false;
                _timer.Enabled = true;
            }
        }

        private void BtnLogOffClick(object sender, EventArgs e)
        {
            BuildDataGridColumns();
            LogOff();
        }

        public void LogOffAdmin()
        {
            BtnLogOffClick(null, null);
        }

        private void BtnClearClick(object sender, EventArgs e)
        {
            BuildDataGridColumns();
            btnClear.Visible = false;
        }

        public string GetParametersString()
        {
            var str = string.Empty;

            // ReSharper disable LoopCanBeConvertedToQuery
            foreach (ReportParameterField field in pnlFields.Controls)
            // ReSharper restore LoopCanBeConvertedToQuery
            {
                str += field.Caption + ": " + field.GetDisplayString() + ", ";
            }

            if (str.EndsWith(", ")) str = str.Substring(0, str.Length - 2);
            str = str.Trim();
            if (str.Length == 0) str = "ללא פרמטרים";
            return str;
        }
    }

    internal class DateRangeData
    {
        public string DefaultValue = string.Empty;
        public string Caption = string.Empty;
        public string ParameterName = string.Empty;
    }
}