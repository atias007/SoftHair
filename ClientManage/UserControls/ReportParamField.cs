using ClientManage.BL;
using ClientManage.BL.Library;
using ClientManage.Forms;
using ClientManage.Interfaces;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ClientManage.UserControls
{
    public partial class ReportParameterField : UserControl
    {
        #region Private Members

        private readonly FieldDataType _dataType = FieldDataType.None;
        private Control _fieldControl;
        private DropDownButton _ddlButton;
        private DataTable _dataSource;
        private FieldQueryMerge _queryMergeType = FieldQueryMerge.RegularParameter;
        private FormClientQuickSearch _fClientQuickSearch;
        private FormCarePick _fCarePick;
        private Label _secLabel;
        private int _fieldControlWidth = 160;
        private bool _isRequired = true;
        private bool _forceAddDefaultValue;
        private string _caption = "Report Field Caption";
        private string _defaultValue;
        private string _defaultComboDisplay;
        private string _displayMember = string.Empty;
        private string _valueMember = string.Empty;
        private string _errorMessage = string.Empty;
        private string _parameterName = string.Empty;

        private const string MsgPrefix = "• ";

        #endregion Private Members

        public enum FieldDataType { None, GeneralText, NumericText, IntegerText, DateTime, QueryListCombo, QuerySimpleCombo, ClientPicker, CarePicker, DateTimeRange }

        public enum FieldQueryMerge { RegularParameter, QueryReplace }

        #region Public Properties

        public FieldDataType DataType
        {
            get { return _dataType; }
        }

        public int FieldControlWidth
        {
            get { return _fieldControlWidth; }
            set { _fieldControlWidth = value; }
        }

        public string DefaultComboDisplay
        {
            get { return _defaultComboDisplay; }
            set { _defaultComboDisplay = value; }
        }

        public string Caption
        {
            get { return _caption; }
            set { _caption = value; }
        }

        public string DefaultValue
        {
            get { return _defaultValue; }
            set { _defaultValue = value; }
        }

        public string DisplayMember
        {
            get { return _displayMember; }
            set { _displayMember = value; }
        }

        public string ValueMember
        {
            get { return _valueMember; }
            set { _valueMember = value; }
        }

        public DataTable DataSource
        {
            get { return _dataSource; }
            set { _dataSource = value; }
        }

        public bool ForceAddDefaultValue
        {
            get { return _forceAddDefaultValue; }
            set { _forceAddDefaultValue = value; }
        }

        public bool IsRequired
        {
            get { return _isRequired; }
            set { _isRequired = value; }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
        }

        public string ParameterName
        {
            get { return _parameterName; }
            set { _parameterName = value; }
        }

        public Font CaptionFont
        {
            get { return lblCaption.Font; }
        }

        public FieldQueryMerge QueryMergeType
        {
            get { return _queryMergeType; }
            set { _queryMergeType = value; }
        }

        #endregion Public Properties

        #region Constructor

        public ReportParameterField(FieldDataType dataType)
        {
            InitializeComponent();
            _dataType = dataType;
        }

        #endregion Constructor

        #region Private Functions

        private void SetFieldControl()
        {
            if (_fieldControl != null) this.Controls.Remove(_fieldControl);

            switch (_dataType)
            {
                case FieldDataType.GeneralText:
                    _fieldControl = new TextBox();
                    ((TextBox)_fieldControl).MaxLength = 50;
                    _fieldControl.Enter += TextBox_Focus;
                    _fieldControl.Leave += TextBox_LostFocus;
                    break;

                case FieldDataType.IntegerText:
                case FieldDataType.NumericText:

                    _fieldControl = new TextBox();
                    ((TextBox)_fieldControl).MaxLength = 50;
                    _fieldControl.Enter += TextBox_Focus;
                    _fieldControl.Leave += TextBox_LostFocus;
                    _fieldControl.RightToLeft = RightToLeft.No;
                    ((TextBox)_fieldControl).TextAlign = HorizontalAlignment.Right;
                    break;

                case FieldDataType.DateTime:
                    var format = AppSettingsHelper.GetParamValue("APP_DATE_FORMAT");
                    _fieldControl = new DateTimePicker();
                    ((DateTimePicker)_fieldControl).Format = DateTimePickerFormat.Custom;
                    ((DateTimePicker)_fieldControl).CustomFormat = format;
                    ((DateTimePicker)_fieldControl).RightToLeftLayout = true;
                    ((DateTimePicker)_fieldControl).CalendarFont = new Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 177);
                    ((DateTimePicker)_fieldControl).CalendarTitleBackColor = Color.FromArgb(187, 199, 255);
                    _fieldControl.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 177);
                    break;

                case FieldDataType.DateTimeRange:

                    _fieldControl = new SoftHairDTRange { Height = 48 };
                    ((SoftHairDTRange)_fieldControl).IsReportVisualFix = true;
                    break;

                case FieldDataType.QueryListCombo:

                    _fieldControl = new ComboBox();
                    ((ComboBox)_fieldControl).DropDownStyle = ComboBoxStyle.DropDownList;
                    ((ComboBox)_fieldControl).FormattingEnabled = true;
                    break;

                case FieldDataType.QuerySimpleCombo:

                    _fieldControl = new ComboBox();
                    ((ComboBox)_fieldControl).DropDownStyle = ComboBoxStyle.DropDown;
                    ((ComboBox)_fieldControl).FormattingEnabled = true;
                    ((ComboBox)_fieldControl).MaxLength = 50;
                    break;

                case FieldDataType.ClientPicker:

                    _fieldControl = new TextBox();
                    ((TextBox)_fieldControl).ReadOnly = true;
                    _fieldControl.BackColor = Color.FromArgb(250, 250, 250);
                    _fieldControl.LocationChanged += FieldControlLocationChanged;
                    _ddlButton = new DropDownButton { Size = new Size(17, 18) };
                    _ddlButton.MouseDown += DdlButtonMouseDown;
                    this.Controls.Add(_ddlButton);
                    break;

                case FieldDataType.CarePicker:

                    _fieldControl = new TextBox();
                    ((TextBox)_fieldControl).ReadOnly = true;
                    _fieldControl.BackColor = Color.FromArgb(250, 250, 250);
                    _fieldControl.LocationChanged += FieldControlLocationChanged;
                    _ddlButton = new DropDownButton { Size = new Size(17, 18) };
                    _ddlButton.MouseDown += DdlButtonMouseDown;
                    this.Controls.Add(_ddlButton);
                    break;

                default:
                    return;
            }

            _fieldControl.Location = new Point(19, 2);
            _fieldControl.Visible = true;
            if (_dataType != FieldDataType.ClientPicker) _fieldControl.BackColor = Color.White;
            _fieldControl.BringToFront();
            if (_dataType == FieldDataType.ClientPicker) _ddlButton.BringToFront();
            this.Controls.Add(_fieldControl);
            _fieldControl.Width = _fieldControlWidth;
            if (_dataType == FieldDataType.DateTimeRange) _fieldControl.Left -= 3;
        }

        private void DdlButtonMouseDown(object sender, MouseEventArgs e)
        {
            if (_dataType == FieldDataType.ClientPicker)
            {
                ShowClientPickerForm();
            }
            else if (_dataType == FieldDataType.CarePicker)
            {
                ShowCarePickerForm();
            }
        }

        private void FieldControlLocationChanged(object sender, EventArgs e)
        {
            LocateDropDownButton();
        }

        private void LocateDropDownButton()
        {
            if (_ddlButton != null)
            {
                _ddlButton.Left = _fieldControl.Left + 2;
                _ddlButton.Top = _fieldControl.Top + 2;
                _ddlButton.Size = new Size(17, 18);
            }
        }

        private void ShowCarePickerForm()
        {
            var rect = _ddlButton.RectangleToScreen(_fieldControl.DisplayRectangle);
            if (_fCarePick == null || _fCarePick.IsDisposed)
            {
                this.Cursor = Cursors.WaitCursor;
                _fCarePick = new FormCarePick(Convert.ToString(_fieldControl.Tag))
                                 {
                                     Left = rect.Left - 2,
                                     Width = _fieldControl.Width,
                                     Top = rect.Bottom + 2
                                 };
                if (!_isRequired) _fCarePick.ShowToolBar = true;
                _fCarePick.SetAppointmentCares += FCarePickSetAppointmentCares;
                _fCarePick.Show();
                this.Cursor = Cursors.Default;
            }
            else
            {
                _fCarePick.ClearSelected();
                _fCarePick.SelectCares(Convert.ToString(_fieldControl.Tag));
                _fCarePick.Left = rect.Left + _fieldControl.Width - _fCarePick.Width;
                _fCarePick.Top = rect.Bottom + 2;
            }
            _fCarePick.Select();
        }

        private void FCarePickSetAppointmentCares(object sender, EventArgs e)
        {
            _fieldControl.Tag = FormCarePick.SelectedCares;
            SetCareText(FormCarePick.SelectedCares);
        }

        private void ShowClientPickerForm()
        {
            var rect = _ddlButton.RectangleToScreen(_fieldControl.DisplayRectangle);

            if (_fClientQuickSearch == null || _fClientQuickSearch.IsDisposed)
            {
                this.Cursor = Cursors.WaitCursor;
                _fClientQuickSearch = new FormClientQuickSearch { VisibleItems = 6 };
                _fClientQuickSearch.Left = rect.Left + _fieldControl.Width - _fClientQuickSearch.Width;
                _fClientQuickSearch.Top = rect.Bottom + 2;
                _fClientQuickSearch.ClientSelected += FClientQuickSearchClientSelected;
                _fClientQuickSearch.ShowToolBar = true;
                _fClientQuickSearch.Show();
                this.Cursor = Cursors.Default;
            }
            else
            {
                _fClientQuickSearch.Left = rect.Left + _fieldControl.Width - _fClientQuickSearch.Width;
                _fClientQuickSearch.Top = rect.Bottom + 2;
            }
            _fClientQuickSearch.Select();
        }

        private void FClientQuickSearchClientSelected(object sender, EventArgs e)
        {
            SetValue(FormClientQuickSearch.SelectedClientId);
        }

        private static string ParseDefaultValueExpression(string value)
        {
            switch (value)
            {
                case "=String.Empty;":
                    return string.Empty;

                case "=DateTime.Now.Day;":
                    return DateTime.Now.Day.ToString();

                case "=DateTime.Now.Month;":
                    return DateTime.Now.Month.ToString();

                case "=DateTime.Now;":
                    return DateTime.Now.ToString();

                case "=DateTime.Now.AddMonths(-3);":
                    return DateTime.Now.AddMonths(-3).ToString();

                case ",=D":
                    return DateUtils.GetStartOfCurrentDay().ToShortDateString() + "," + DateUtils.GetEndOfCurrentDay().ToShortDateString();

                case ",=D+":
                    return DateUtils.GetStartOfNextDay().ToShortDateString() + "," + DateUtils.GetEndOfNextDay().ToShortDateString();

                case ",=D-":
                    return DateUtils.GetStartOfLastDay().ToShortDateString() + "," + DateUtils.GetEndOfLastDay().ToShortDateString();

                case ",=W":
                    return DateUtils.GetStartOfCurrentWeek().ToShortDateString() + "," + DateUtils.GetEndOfCurrentWeek().ToShortDateString();

                case ",=W+":
                    return DateUtils.GetStartOfNextWeek().ToShortDateString() + "," + DateUtils.GetEndOfNextWeek().ToShortDateString();

                case ",=W-":
                    return DateUtils.GetStartOfLastWeek().ToShortDateString() + "," + DateUtils.GetEndOfLastWeek().ToShortDateString();

                case ",=M+":
                    return DateUtils.GetStartOfNextMonth().ToShortDateString() + "," + DateUtils.GetEndOfNextQuarter().ToShortDateString();

                case ",=M-":
                    return DateUtils.GetStartOfLastMonth().ToShortDateString() + "," + DateUtils.GetEndOfLastMonth().ToShortDateString();

                case ",=M":
                    return DateUtils.GetStartOfCurrentMonth().ToShortDateString() + "," + DateUtils.GetEndOfCurrentQuarter().ToShortDateString();

                case ",=Q+":
                    return DateUtils.GetStartOfNextQuarter().ToShortDateString() + "," + DateUtils.GetEndOfNextQuarter().ToShortDateString();

                case ",=Q-":
                    return DateUtils.GetStartOfLastQuarter().ToShortDateString() + "," + DateUtils.GetEndOfLastQuarter().ToShortDateString();

                case ",=Q":
                    return DateUtils.GetStartOfCurrentQuarter().ToShortDateString() + "," + DateUtils.GetEndOfCurrentQuarter().ToShortDateString();

                case ",=Y+":
                    return DateUtils.GetStartOfNextYear().ToShortDateString() + "," + DateUtils.GetEndOfNextYear().ToShortDateString();

                case ",=Y-":
                    return DateUtils.GetStartOfLastYear().ToShortDateString() + "," + DateUtils.GetEndOfLastYear().ToShortDateString();

                case ",=Y":
                    return DateUtils.GetStartOfCurrentYear().ToShortDateString() + "," + DateUtils.GetEndOfCurrentYear().ToShortDateString();

                case ",=L3M":
                    return DateTime.Now.AddMonths(-3).ToShortDateString() + "," + DateTime.Now.ToShortDateString();
            }

            var code = "return (object)" + value.Substring(1);
            var exec = new CodeExecuter(code);
            var res = exec.Execute();

            return res == CodeExecuter.ExecutionResult.Success ? Convert.ToString(exec.ReturnValue) : string.Empty;
        }

        private void SetFieldDefaultValue()
        {
            if (_defaultValue == null) return;

            if (_defaultValue.StartsWith("=") || _defaultValue.StartsWith(",="))
                _defaultValue = ParseDefaultValueExpression(_defaultValue);

            switch (_dataType)
            {
                case FieldDataType.GeneralText:
                case FieldDataType.IntegerText:
                case FieldDataType.NumericText:
                    try
                    {
                        _fieldControl.Text = Convert.ToString(_defaultValue);
                    }
                    catch { Utils.CatchException(); }
                    break;

                case FieldDataType.DateTime:
                    try
                    {
                        ((DateTimePicker)_fieldControl).Value = Convert.ToDateTime(_defaultValue);
                    }
                    catch { Utils.CatchException(); }
                    break;

                case FieldDataType.QueryListCombo:
                    try
                    {
                        ((ComboBox)_fieldControl).SelectedValue = _defaultValue;
                    }
                    catch { Utils.CatchException(); }
                    if (((ComboBox)_fieldControl).Items.Count > 0 && ((ComboBox)_fieldControl).SelectedIndex < 0)
                    {
                        ((ComboBox)_fieldControl).SelectedIndex = 0;
                    }

                    break;

                case FieldDataType.QuerySimpleCombo:
                    try
                    {
                        _fieldControl.Text = DefaultValue;
                    }
                    catch { Utils.CatchException(); }
                    break;

                case FieldDataType.ClientPicker:
                    try
                    {
                        SetValue(_defaultValue);
                    }
                    catch { Utils.CatchException(); }
                    break;

                case FieldDataType.CarePicker:
                    try
                    {
                        SetCareText(_defaultValue);
                        _fieldControl.Tag = _defaultValue;
                    }
                    catch { Utils.CatchException(); }
                    break;

                case FieldDataType.DateTimeRange:
                    var sValues = _defaultValue.Split(',');
                    var dValues = new DateTime?[2];
                    if (sValues.Length == 2)
                    {
                        if (sValues[0].Length == 0) dValues[0] = null; else dValues[0] = Convert.ToDateTime(sValues[0]);
                        if (sValues[1].Length == 0) dValues[1] = null; else dValues[1] = Convert.ToDateTime(sValues[1]);
                        ((SoftHairDTRange)_fieldControl).SetValues(dValues);
                    }
                    break;
            }
        }

        private void SetCareText(string value)
        {
            value = value == "-1" ? "-1" : CalendarHelper.GetCaresDescription(value);
            if (value == "-1") _fieldControl.Text = "< כל הטיפולים >";
            else if (value.Length == 0) _fieldControl.Text = "< ללא טיפול >";
            else _fieldControl.Text = value;
        }

        private void SetFieldCaption()
        {
            if (_caption.IndexOf('\n') >= 0)
            {
                var caps = _caption.Split('\n');
                _secLabel = new Label();
                this.Controls.Add(_secLabel);
                _secLabel.Size = lblCaption.Size;
                _secLabel.Top = lblCaption.Height;
                _secLabel.Font = lblCaption.Font;
                _secLabel.TextAlign = lblCaption.TextAlign;
                lblCaption.Text = caps[0];
                _secLabel.Text = caps[1];
                lblCaption.Width = this.Width - 22 - _fieldControlWidth;
                _secLabel.Width = lblCaption.Width;
                _secLabel.Left = lblCaption.Left;

                ((SoftHairDTRange)_fieldControl).SetNullsText();
            }
            else
            {
                lblCaption.Text = _caption;
                lblCaption.Width = this.Width - 22 - _fieldControlWidth;
            }
        }

        private void SetComboListData()
        {
            if (_dataType == FieldDataType.QuerySimpleCombo || _dataType == FieldDataType.QueryListCombo)
            {
                var cb = ((ComboBox)_fieldControl);

                if (_forceAddDefaultValue && _defaultComboDisplay != null && _defaultValue != null)
                {
                    var row = _dataSource.NewRow();
                    row[_displayMember] = _defaultComboDisplay;
                    if (_displayMember != _valueMember) row[_valueMember] = _defaultValue;
                    _dataSource.Rows.InsertAt(row, 0);
                }
                cb.DataSource = _dataSource;

                cb.DisplayMember = _displayMember;
                cb.ValueMember = _valueMember;
                if (cb.SelectedIndex < 0 && cb.Items.Count > 0) cb.SelectedIndex = 0;
            }
        }

        private void LocateCaption()
        {
            lblCaption.Left = this.Width - lblCaption.Width;
            if (_secLabel != null)
            {
                _secLabel.Left = lblCaption.Left;
            }
        }

        #endregion Private Functions

        #region Public Methods

        public void Initialize()
        {
            SetFieldControl();
            SetFieldCaption();
            SetComboListData();
            SetFieldDefaultValue();
        }

        public string GetCustomValidationCode()
        {
            switch (_dataType)
            {
                case FieldDataType.GeneralText:
                    return string.Format("string var_{0} = \"{1}\";", _parameterName, _fieldControl.Text);
                case FieldDataType.IntegerText:
                    return string.Format("int var_{0} = {1};", _parameterName, _fieldControl.Text);
                case FieldDataType.NumericText:
                    return string.Format("double var_{0} = {1};", _parameterName, _fieldControl.Text);
                case FieldDataType.DateTime:
                    return string.Format("DateTime var_{0} = DateTime.Parse(\"{1}\");", _parameterName, ((DateTimePicker)_fieldControl).Value);
                case FieldDataType.DateTimeRange:
                    var values = ((SoftHairDTRange)_fieldControl).ValueRange;
                    var valFrom = string.Empty;
                    var pname = _parameterName.Split(',');
                    for (var i = 0; i < 2; i++)
                    {
                        if (values[i].HasValue)
                            valFrom += string.Format("DateTime? var_{0} = DateTime.Parse(\"{1}\");", pname[i], values[i].GetValueOrDefault());
                        else
                            valFrom += "DateTime? var_" + pname[i] + " = null;";
                    }

                    return valFrom;

                case FieldDataType.QueryListCombo:
                    return string.Format("string var_{0} = \"{1}\";", _parameterName, Convert.ToString(((ComboBox)_fieldControl).SelectedValue));
                case FieldDataType.QuerySimpleCombo:
                    return string.Format("string var_{0} = \"{1}\";", _parameterName, _fieldControl.Text);
                case FieldDataType.ClientPicker:
                    return string.Format("int var_{0} = {1};", _parameterName, _fieldControl.Tag);
                default:
                    return string.Empty;
            }
        }

        public string GetDisplayString()
        {
            switch (_dataType)
            {
                case FieldDataType.GeneralText:
                case FieldDataType.IntegerText:
                case FieldDataType.NumericText:
                    return _fieldControl.Text;

                case FieldDataType.DateTime:
                    return ((DateTimePicker)_fieldControl).Value.ToString("dd/MM/yyyy");

                case FieldDataType.DateTimeRange:
                    return ((SoftHairDTRange)_fieldControl).DisplayString();

                case FieldDataType.QueryListCombo:
                case FieldDataType.QuerySimpleCombo:
                    return _fieldControl.Text;

                case FieldDataType.ClientPicker:
                case FieldDataType.CarePicker:
                    return _fieldControl.Text;

                default:
                    return string.Empty;
            }
        }

        public object GetParameterValue()
        {
            switch (_dataType)
            {
                case FieldDataType.GeneralText:
                    return _fieldControl.Text.Trim();

                case FieldDataType.IntegerText:
                    var iret = 0;
                    try
                    {
                        iret = Convert.ToInt32(_fieldControl.Text.Trim());
                    }
                    catch { Utils.CatchException(); }
                    return iret;

                case FieldDataType.NumericText:
                    double dret = 0;
                    try
                    {
                        dret = Convert.ToDouble(_fieldControl.Text.Trim());
                    }
                    catch { Utils.CatchException(); }
                    return dret;

                case FieldDataType.DateTime:
                    return ((DateTimePicker)_fieldControl).Value;

                case FieldDataType.DateTimeRange:
                    return ((SoftHairDTRange)_fieldControl).ValueRange;

                case FieldDataType.QueryListCombo:
                    return ((ComboBox)_fieldControl).SelectedValue;

                case FieldDataType.QuerySimpleCombo:
                    return _fieldControl.Text.Trim();

                case FieldDataType.ClientPicker:
                    return _fieldControl.Tag;

                case FieldDataType.CarePicker:
                    if ((string)_fieldControl.Tag == "-1") return "1=1";
                    var all = Convert.ToString(_fieldControl.Tag);
                    var cares = all.Split(' ');
                    var value = string.Empty;

                    //foreach (var cr in cares)
                    //{
                    //    if (cr.Length > 0)
                    //    {
                    //        if (value.Length > 0) value += " OR ";
                    //        value += "\" \" + " + _parameterName + " + \" \" LIKE \"% " + cr + " %\"";
                    //    }
                    //}
                    //if (value.Length == 0) value = _parameterName + " IS NULL";

                    //return value;
                    return cares;

                default:
                    return null;
            }
        }

        public void SetValue(object value)
        {
            try
            {
                switch (_dataType)
                {
                    case FieldDataType.GeneralText:
                        _fieldControl.Text = value.ToString();
                        break;

                    case FieldDataType.IntegerText:
                        _fieldControl.Text = Convert.ToString(value);
                        break;

                    case FieldDataType.NumericText:
                        _fieldControl.Text = Convert.ToString(value);
                        break;

                    case FieldDataType.DateTime:
                        ((DateTimePicker)_fieldControl).Value = Convert.ToDateTime(value);
                        break;

                    case FieldDataType.DateTimeRange:
                        var dt = (DateTime?[])value;
                        ((SoftHairDTRange)_fieldControl).SetValues(dt);
                        break;

                    case FieldDataType.QueryListCombo:
                        ((ComboBox)_fieldControl).SelectedValue = value;
                        break;

                    case FieldDataType.QuerySimpleCombo:
                        _fieldControl.Text = Convert.ToString(value);
                        break;

                    case FieldDataType.ClientPicker:
                        var id = Convert.ToInt32(value);
                        if (id > 0) _fieldControl.Text = ClientHelper.GetFullName(id);
                        else
                        {
                            if (id == 0) _fieldControl.Text = "< ללא לקוח >";
                            if (id == -1) _fieldControl.Text = "< כל הלקוחות >";
                        }

                        _fieldControl.Tag = id;
                        break;

                    case FieldDataType.CarePicker:
                        SetCareText(Convert.ToString(value));
                        _fieldControl.Tag = value;
                        break;

                    default:
                        return;
                }
            }
            catch { Utils.CatchException(); }
        }

        public bool ValidateField()
        {
            var ret = true;
            string val;
            _errorMessage = string.Empty;
            var errColor = Color.FromArgb(255, 222, 222);

            ToolTip.RemoveAll();

            switch (_dataType)
            {
                case FieldDataType.DateTimeRange:
                    if (!((SoftHairDTRange)_fieldControl).ValidateValues())
                    {
                        ret = false;
                        _errorMessage = MsgPrefix + "תאריך התחלה גדול מתאריך הסיום";
                        ToolTip.SetToolTip(lblErrorIcon, "תאריך התחלה גדול מתאריך הסיום");
                    }
                    break;

                case FieldDataType.GeneralText:
                    val = _fieldControl.Text.Trim();
                    if (_isRequired && val.Length == 0)
                    {
                        ret = false;
                        _errorMessage = MsgPrefix + "הפרמטר \"" + _caption + "\" הנו שדה חובה";
                        ToolTip.SetToolTip(lblErrorIcon, "חובה למלא שדה זה");
                        _fieldControl.BackColor = errColor;
                    }
                    break;

                case FieldDataType.IntegerText:
                    val = _fieldControl.Text.Trim();
                    if (_isRequired && val.Length == 0)
                    {
                        ret = false;
                        _errorMessage = MsgPrefix + "הפרמטר \"" + _caption + "\" הנו שדה חובה";
                        ToolTip.SetToolTip(lblErrorIcon, "חובה למלא שדה זה");
                        _fieldControl.BackColor = errColor;
                    }
                    else if (!_isRequired && val.Length == 0)
                    {
                        // do nothing //
                    }
                    else
                    {
                        int ires;
                        if (!(int.TryParse(val, out ires)))
                        {
                            ret = false;
                            _errorMessage = MsgPrefix + "הפרמטר \"" + _caption + "\" אינו חוקי. אנא הזן מספר שלם";
                            ToolTip.SetToolTip(lblErrorIcon, "ערך השדה אינו חוקי. אנא הזן מספר שלם");
                            _fieldControl.BackColor = errColor;
                        }
                        else
                        {
                            _fieldControl.Text = ires.ToString();
                        }
                    }
                    break;

                case FieldDataType.NumericText:
                    val = _fieldControl.Text.Trim();
                    if (_isRequired && val.Length == 0)
                    {
                        ret = false;
                        _errorMessage = MsgPrefix + "הפרמטר \"" + _caption + "\" הנו שדה חובה";
                        ToolTip.SetToolTip(lblErrorIcon, "חובה למלא שדה זה");
                        _fieldControl.BackColor = errColor;
                    }
                    else
                    {
                        double dres;
                        if (!double.TryParse(val, out dres))
                        {
                            ret = false;
                            _errorMessage = MsgPrefix + "הפרמטר \"" + _caption + "\" אינו חוקי. אנא הזן מספר";
                            ToolTip.SetToolTip(lblErrorIcon, "ערך השדה אינו חוקי. אנא הזן מספר");
                            _fieldControl.BackColor = errColor;
                        }
                        else
                        {
                            _fieldControl.Text = dres.ToString();
                        }
                    }
                    break;

                case FieldDataType.QuerySimpleCombo:
                    val = _fieldControl.Text.Trim();
                    if (_isRequired && val.Length == 0)
                    {
                        _errorMessage = MsgPrefix + "הפרמטר \"" + _caption + "\" הנו שדה חובה";
                        ToolTip.SetToolTip(lblErrorIcon, "חובה למלא שדה זה");
                        ret = false;
                    }
                    break;

                case FieldDataType.QueryListCombo:
                    val = ((ComboBox)_fieldControl).SelectedValue.ToString();
                    if (IsRequired && val.Length == 0)
                    {
                        _errorMessage = MsgPrefix + "הפרמטר \"" + _caption + "\" הנו שדה חובה";
                        ToolTip.SetToolTip(lblErrorIcon, "חובה למלא שדה זה");
                        ret = false;
                    }
                    break;

                case FieldDataType.ClientPicker:
                    val = Convert.ToString(_fieldControl.Tag);
                    if (IsRequired && val.Length == 0)
                    {
                        _errorMessage = MsgPrefix + "הפרמטר \"" + _caption + "\" הנו שדה חובה";
                        ToolTip.SetToolTip(lblErrorIcon, "חובה למלא שדה זה");
                        ret = false;
                    }
                    break;

                case FieldDataType.CarePicker:
                    //val = Convert.ToString(_fieldControl.Tag);
                    //if (IsRequired && val.Length == 0)
                    //{
                    //    _errorMessage = MSG_PREFIX + "הפרמטר \"" + _caption + "\" הנו שדה חובה";
                    //    ToolTip.SetToolTip(lblErrorIcon, "חובה למלא שדה זה");
                    //    ret = false;
                    //}
                    break;
            }
            lblErrorIcon.Image = !ret ? Properties.Resources.field_error : null;

            return ret;
        }

        #endregion Public Methods

        #region Control Events

        private static void TextBox_Focus(object sender, EventArgs e)
        {
            if (((TextBox)sender).ReadOnly) return;
            ((TextBox)sender).BackColor = Color.LemonChiffon;
        }

        private static void TextBox_LostFocus(object sender, EventArgs e)
        {
            if (((TextBox)sender).ReadOnly) return;
            ((TextBox)sender).BackColor = Color.White;
        }

        private void LblCaptionSizeChanged(object sender, EventArgs e)
        {
            LocateCaption();
        }

        private void ReportParamField_SizeChanged(object sender, EventArgs e)
        {
            LocateCaption();
        }

        #endregion Control Events
    }
}