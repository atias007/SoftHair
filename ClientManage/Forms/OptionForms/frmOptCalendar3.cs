using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ClientManage.Library;
using ClientManage.BL;

namespace ClientManage.Forms.OptionForms
{
    public partial class FormOptCalendar3 : BaseMdiOptionForm
    {
        public event EventHandler ClientsDSChanged;

        public FormOptCalendar3()
        {
            InitializeComponent();

            grdCares.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8);

            #region Combo columns

            var table = new DataTable();
            table.Columns.Add("id", typeof (Int32));
            table.Columns.Add("title", typeof (string));
            table.Rows.Add(0, "תכלת (ברירת מחדל)");
            table.Rows.Add(-1, "כתום");
            table.Rows.Add(1, "סגול");
            table.Rows.Add(2, "אדום");
            table.Rows.Add(3, "ירוק");
            table.Rows.Add(4, "כחול כהה");
            table.Rows.Add(5, "אפור");
            table.Rows.Add(6, "אפור כהה");
            table.Rows.Add(7, "תורכיז");

            // ReSharper disable PossibleNullReferenceException
            ((DataGridViewComboBoxColumn) grdCares.Columns["col_color"]).DataSource = table;
            ((DataGridViewComboBoxColumn) grdCares.Columns["col_color"]).DisplayMember = "title";
            ((DataGridViewComboBoxColumn) grdCares.Columns["col_color"]).ValueMember = "id";
            // ReSharper restore PossibleNullReferenceException

            var table2 = new DataTable();
            table2.Columns.Add("id", typeof(Int32));
            table2.Columns.Add("title", typeof (string));
            table2.Rows.Add(15, "15 דקות");
            table2.Rows.Add(30, "30 דקות");
            table2.Rows.Add(45, "45 דקות");
            table2.Rows.Add(60, "שעה");
            table2.Rows.Add(75, "שעה ו-15 דקות");
            table2.Rows.Add(90, "שעה וחצי");
            table2.Rows.Add(105, "שעה ו-45 דקות");
            table2.Rows.Add(120, "שעתיים");
            table2.Rows.Add(135, "שעתיים ו-15 דקות");
            table2.Rows.Add(150, "שעתיים וחצי");
            table2.Rows.Add(165, "שעתיים ו-45 דקות");
            table2.Rows.Add(180, "3 שעות");
            table2.Rows.Add(195, "3 שעות ו-15 דקות");
            table2.Rows.Add(210, "3 שעות וחצי");
            table2.Rows.Add(225, "3 שעות ו-45 דקות");
            table2.Rows.Add(240, "4 שעות");
            table2.Rows.Add(255, "4 שעות ו-15 דקות");
            table2.Rows.Add(270, "4 שעות וחצי");
            table2.Rows.Add(285, "4 שעות ו-45 דקות");
            table2.Rows.Add(300, "5 שעות");
            table2.Rows.Add(315, "5 שעות ו-15 דקות");
            table2.Rows.Add(330, "5 שעות וחצי");
            table2.Rows.Add(345, "5 שעות ו-45 דקות");
            table2.Rows.Add(360, "6 שעות");

            // ReSharper disable PossibleNullReferenceException
            ((DataGridViewComboBoxColumn) grdCares.Columns["col_duration"]).DataSource = table2;
            ((DataGridViewComboBoxColumn) grdCares.Columns["col_duration"]).DisplayMember = "title";
            ((DataGridViewComboBoxColumn) grdCares.Columns["col_duration"]).ValueMember = "id";
            // ReSharper restore PossibleNullReferenceException

            #endregion
        }

        private DataSet _dsCares;
        public DataSet DSCares
        {
            get { return _dsCares; }
            set { _dsCares = value; }
        }


        public override void LoadSettings()
        {
            if (_dsCares == null)
            {
                _dsCares = CalendarHelper.GetCares();
            }
            _dsCares.Tables[0].RowChanged += frmPreferences_RowChanged;
            _dsCares.Tables[0].RowDeleted += frmPreferences_RowChanged;
            grdCares.DataMember = "tblCares";
            grdCares.DataSource = _dsCares;
            var column = grdCares.Columns["c_score"];
            if (column != null)
            {
                grdCares.Sort(column, ListSortDirection.Ascending);
            }

            chkColor.Checked = LoadSettingValue<bool>("CAL_AUTO_SET_COLOR");
            chkDuration.Checked = LoadSettingValue<bool>("CAL_AUTO_SET_DURATION");
        }

        private int GetMaxScore()
        {
            var max = 0;
            for (var i = 0; i < _dsCares.Tables[0].Rows.Count; i++)
            {
                if (_dsCares.Tables[0].Rows[i].RowState != DataRowState.Deleted)
                {
                    if ((int)_dsCares.Tables[0].Rows[i]["score"] > max)
                    {
                        max = (int)_dsCares.Tables[0].Rows[i]["score"];
                    }
                }
            }
            return max;
        }

        public override void SaveSettings()
        {
            if (_dsCares.HasChanges())
            {
                if (ClientsDSChanged != null) ClientsDSChanged(_dsCares, new EventArgs());
            }

            SaveSettingValue("CAL_AUTO_SET_COLOR", chkColor.Checked);
            SaveSettingValue("CAL_AUTO_SET_DURATION", chkDuration.Checked);
        }

        public override void ResetForm()
        {
            btnUpCare.Enabled = true;
            btnDownCare.Enabled = true;
            _dsCares = null;
            base.ResetForm();
        }

        void frmPreferences_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            if (e.Action == DataRowAction.Add || e.Action == DataRowAction.Delete)
            {
                btnUpCare.Enabled = false;
                btnDownCare.Enabled = false;
            }
        }

        private void grdCares_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (IsGridContainsValue(grdCares, e.FormattedValue.ToString(), 1, e.RowIndex))
                {
                    var msg1 = "הטיפול \"" + e.FormattedValue + "\" כבר קיים ברשימה\nשנה את שם הטיפול או לחץ Esc לביטול";
                    const string msg2 = "טיפולים לתור ביומן...";
                    if (e.FormattedValue.ToString().Length == 0) msg1 = "לא הוזן טיפול. אנא הזן שם טיפול או לחץ Esc לביטול";
                    MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                    MsgBox.Show(this);
                    e.Cancel = true;
                }
            }
        }

        private void btnUpCare_Click(object sender, EventArgs e)
        {
            if (grdCares.SelectedRows.Count > 0)
            {
                var index = grdCares.SelectedRows[0].Index;
                if (index > 0)
                {
                    var id1 = (int)grdCares["c_id", index].Value;
                    var id2 = (int)grdCares["c_id", index - 1].Value;
                    var score = (int)grdCares["c_score", index].Value;
                    var row1 = FindRow(id1);
                    var row2 = FindRow(id2);
                    row1["score"] = row2["score"];
                    row2["score"] = score;
                    SelectRowById(id1);
                }
            }
        }

        private void btnDownCare_Click(object sender, EventArgs e)
        {
            if (grdCares.SelectedRows.Count > 0)
            {
                var index = grdCares.SelectedRows[0].Index;
                if (index < grdCares.Rows.Count - 2)
                {
                    var id1 = (int)grdCares["c_id", index].Value;
                    var id2 = (int)grdCares["c_id", index + 1].Value;
                    var score = (int)grdCares["c_score", index].Value;
                    var row1 = FindRow(id1);
                    var row2 = FindRow(id2);
                    row1["score"] = row2["score"];
                    row2["score"] = score;
                    SelectRowById(id1);
                }
            }
        }

        private DataRow FindRow(int id)
        {
            foreach (DataRow row in _dsCares.Tables[0].Rows)
            {
                if (row["id"].Equals(id)) return row;
            }

            return null;
        }

        private void SelectRowById(int id)
        {
            foreach (DataGridViewRow row in grdCares.Rows)
            {
                if (row.Cells["c_id"].Value.Equals(id))
                {
                    grdCares.ClearSelection();
                    grdCares.CurrentCell = grdCares["c_desc", row.Index];
                    row.Selected = true;
                    if (!row.Displayed) grdCares.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        //private void SetScore()
        //{
        //    for (var i = 0; i < grdCares.Rows.Count; i++)
        //    {
        //        grdCares.Rows[i].Cells["c_score"].Value = i;
        //    }
        //}

        private void grdCares_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            grdCares["c_score", e.Row.Index - 1].Value = GetMaxScore() + 1;
        }
    }
}