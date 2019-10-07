using BizCare.Calendar.Library;
using ClientManage.BL;
using ClientManage.Interfaces;
using ClientManage.Library;
using ClientManage.UserControls;
using System;
using System.Data;
using System.Windows.Forms;

namespace ClientManage.Forms
{
    public partial class FormDynamicReport : BaseMdiChild
    {
        public event DlgShowClientCardEventHandler ShowClientCard;

        public event OpenFormEventHandler OpenForm;

        private static string _selectedId;

        private readonly DgvLoadImages _imageLoader = new DgvLoadImages();

        public static string SelectedId
        {
            get { return _selectedId; }
        }

        public FormDynamicReport()
        {
            InitializeComponent();
            _imageLoader.PicturePathColumn = "gdv_column_picture";
            _imageLoader.ImageColumn = "gdv_column_image";
        }

        private void FrmDynamicReportLoad(object sender, EventArgs e)
        {
            SetFavMenu();
            dataGridView.Select();
        }

        private void ParamPanel_SizeChanged(object sender, EventArgs e)
        {
            groupBox1.Height = ParamPanel.Height + 20;
        }

        public void ShowReport(string reportGroup, int reportId, object[] parameters)
        {
            ParamPanel.ShowReport(reportGroup, reportId, parameters);
        }

        private void TbbPrintClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            // create html table
            var imgCol = new HtmlImageColumnsCollection
                             {
                                 new HtmlImageColumnMapper(HtmlImageColumnMapper.HtmlMapType.ByColumnRef,
                                                           "gdv_column_image", "gdv_column_picture")
                             };
            var htmlTable = HtmlPrinter.ConvertDataGridToHtml(dataGridView, imgCol);

            // create report parameters
            var parameters = new string[3];
            parameters[0] = "דוח: " + ParamPanel.ReportName;
            parameters[1] = ParamPanel.SavedParametersString;
            parameters[2] = htmlTable;

            var printer = new HtmlPrinter("REPORT_FORM", parameters);
            if (AppSettingsHelper.GetParamValue<bool>("APP_SHOW_PRINTER_DIALOG"))
            {
                printer.ShowPrintDialog();
                this.Cursor = Cursors.Default;
            }
            else
            {
                printer.Print();
                this.Cursor = Cursors.Default;
            }

            this.Cursor = Cursors.Default;
        }

        private void TbbStickersClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable table;

            if (!ParamPanel.EnablePrintStickers)
            {
                const string msg1 = "דוח זה אינו מאפשר הדפסת מדבקות\nיש למלא את רשימת הנמענים באופן ידני";
                const string msg2 = "הדפסת מדבקות...";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Information, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
                table = null;
            }
            else
            {
                table = GetAddressDataSource();
            }

            if (OpenForm != null) OpenForm(this, new OpenFormEventArgs("frmStickers", table));
            this.Cursor = Cursors.Default;
        }

        private DataTable GetAddressDataSource()
        {
            var ids = Utils.GetDataSourceIds((DataTable)dataGridView.DataSource);
            if (ids.Length == 0) return null;

            switch (ParamPanel.DoubleClickCommand)
            {
                case "OpenClientCard":
                    return ReportHelper.GetClientsAddresses(ids);

                case "OpenWorkerCard":
                    return ReportHelper.GetWorkerAddresses(ids);

                case "OpenContactCard":
                    return ReportHelper.GetContactAddresses(ids);

                case "OpenCalendar":
                    return ReportHelper.GetCalendarAddress(ids);

                default:
                    return null;
            }
        }

        private DataTable GetPhonesDataSource()
        {
            var table = dataGridView.DataSource as DataTable;
            var ids = Utils.GetDataSourceIds(table);
            if (ids.Length == 0) return null;

            switch (ParamPanel.DoubleClickCommand)
            {
                case "OpenClientCard":
                    return ReportHelper.GetClientsCellPhones(ids);

                case "OpenWorkerCard":
                    return ReportHelper.GetWorkersCellPhones(ids);

                case "OpenContactCard":
                    return ReportHelper.GetContactsCellPhones(ids);

                case "OpenCalendar":
                    ids = Utils.GetDataSourceIds(table, "client_id");
                    return ReportHelper.GetCalendarCellPhones(ids);

                default:
                    return null;
            }
        }

        private DataTable GetEmailDataSource()
        {
            var ids = Utils.GetDataSourceIds((DataTable)dataGridView.DataSource);
            if (ids.Length == 0) return null;

            switch (ParamPanel.DoubleClickCommand)
            {
                case "OpenClientCard":
                    return ReportHelper.GetClientsEmails(ids);

                case "OpenWorkerCard":
                    return ReportHelper.GetWorkersEmails(ids);

                case "OpenContactCard":
                    return ReportHelper.GetContactsEmails(ids);

                case "OpenCalendar":
                    return ReportHelper.GetCalendarEmails(ids);

                default:
                    return null;
            }
        }

        private void TbbSmsClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable table;

            if (!ParamPanel.EnableSendSms)
            {
                const string msg1 = "דוח זה אינו מאפשר שליחת הודעות SMS\nיש למלא את רשימת הנמענים ידנית";
                const string msg2 = "שליחת הודעות SMS...";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Information, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
                table = null;
            }
            else
            {
                table = GetPhonesDataSource();
            }

            var list = General.TableToPostAddresseeList(table);
            if (OpenForm != null) OpenForm(this, new OpenFormEventArgs("frmSMS", list));
            this.Cursor = Cursors.Default;
        }

        private void TbbEmailClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable table;

            if (!ParamPanel.EnableEmailCampaign)
            {
                const string msg1 = "דוח זה אינו מאפשר שליחת הודעות דוא\"ל\nיש למלא את רשימת הנמענים ידנית";
                const string msg2 = "שליחת הודעות דוא\"ל";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Information, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
                table = null;
            }
            else
            {
                table = GetEmailDataSource();
            }

            if (OpenForm != null) OpenForm(this, new OpenFormEventArgs("frmMailCampaign", table));
            this.Cursor = Cursors.Default;
        }

        private void DataGridViewCellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (ParamPanel.DoubleClickCommand.Length == 0) return;

            if (dataGridView.Columns.Contains("gdv_column_id"))
            {
                var valId = dataGridView.Rows[e.RowIndex].Cells["gdv_column_id"].Value;
                _selectedId = DBNull.Value.Equals(valId) ? "0" : Convert.ToString(valId);
                var command = ParamPanel.DoubleClickCommand;
                OpenFormEventArgs arg2;

                if (command == "OpenFormByRow")
                {
                    valId = dataGridView.Rows[e.RowIndex].Cells["gdv_column_open_form_cmd"].Value;
                    if (!DBNull.Value.Equals(valId)) command = Convert.ToString(valId);
                }

                switch (command)
                {
                    case "OpenClientCard":
                        var arg = new ShowClientCardEventArgs(int.Parse(_selectedId), true)
                                      {
                                          DataSource = GetNavigateDataTable(dataGridView),
                                          CurrentIndex = e.RowIndex
                                      };
                        if (ShowClientCard != null) ShowClientCard(this, arg);
                        break;

                    case "OpenCalendar":
                        if (OpenForm != null)
                        {
                            Appointment app;
                            try
                            {
                                app = FormCalendar.GetAppointmentFromDataRow(CalendarHelper.GetAppointment(_selectedId.ToString()));
                            }
                            catch (Exception ex)
                            {
                                General.ShowCommunicationError(ex, this);
                                return;
                            }
                            OpenForm(this, new OpenFormEventArgs("frmCalendar", app));
                        }
                        break;

                    case "OpenWorkerCard":
                        if (OpenForm != null)
                        {
                            if (int.Parse(_selectedId) > 0)
                            {
                                arg2 = new OpenFormEventArgs("frmWorkerDetails", int.Parse(_selectedId), true) { ReturnToReportForm = true };
                                OpenForm(this, arg2);
                            }
                        }
                        break;

                    case "OpenContactCard":
                        if (OpenForm != null)
                        {
                            arg2 = new OpenFormEventArgs("frmContactDetails", int.Parse(_selectedId), true) { ReturnToReportForm = true };
                            OpenForm(this, arg2);
                        }
                        break;
                }
            }
        }

        private DataTable GetNavigateDataTable(DataGridView grid)
        {
            bool isFilter;
            var table = new DataTable();
            table.Columns.Add("key", typeof(int));
            table.Columns.Add("id", typeof(int));

            if (ParamPanel.DoubleClickCommand == "OpenFormByRow") isFilter = true;
            else if (ParamPanel.DoubleClickCommand == "OpenClientCard") isFilter = false;
            else return table;

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (isFilter)
                {
                    if (!DBNull.Value.Equals(row.Cells["gdv_column_open_form_cmd"].Value))
                    {
                        if (row.Cells["gdv_column_open_form_cmd"].Value.ToString() == "OpenClientCard")
                        {
                            AddTableRowFromGrid(table, row);
                        }
                    }
                }
                else
                {
                    AddTableRowFromGrid(table, row);
                }
            }

            return table;
        }

        private static void AddTableRowFromGrid(DataTable table, DataGridViewRow row)
        {
            var lastId = (table.Rows.Count > 0) ? (int)table.Rows[table.Rows.Count - 1]["id"] : 0;
            var id = Convert.ToInt32(row.Cells["gdv_column_id"].Value);
            if (id != lastId)
            {
                table.Rows.Add(Convert.ToInt32(row.Cells["unique_row_number"].Value), id);
            }
        }

        private void DataGridViewCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (dataGridView.Columns.Contains("gdv_column_email"))
            {
                if (e.ColumnIndex == dataGridView.Columns["gdv_column_email"].Index)
                {
                    var val = Convert.ToString(dataGridView.CurrentCell.Value);
                    if (val.Length > 0)
                    {
                        var name = dataGridView[dataGridView.Columns["gdv_column_full_name"].Index, e.RowIndex].Value.ToString();

                        if (OpenForm != null)
                        {
                            this.Cursor = Cursors.WaitCursor;

                            var table = new DataTable();
                            table.Columns.Add("full_name", typeof(string));
                            table.Columns.Add("email", typeof(string));

                            table.Rows.Add(name, val);

                            OpenForm(this, new OpenFormEventArgs("frmMailCampaign", table));

                            this.Cursor = Cursors.Default;
                        }
                    }
                }
            }
        }

        private void DataGridViewColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _imageLoader.BeginLoadImages(dataGridView);
        }

        public void RefreshImages()
        {
            _imageLoader.BeginLoadImages(dataGridView);
        }

        private void TbbExcelClick(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog
                             {
                                 AddExtension = true,
                                 DefaultExt = "csv",
                                 FileName = ParamPanel.ReportExportFileName,
                                 Filter = "CSV Excel Text File (*.csv) | *.csv",
                                 OverwritePrompt = true,
                                 RestoreDirectory = true,
                                 Title = "בחר שם לקובץ הדוח..."
                             };

            var res = dialog.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                const string msg2 = "ייצוא דוח לקובץ Excel...";
                try
                {
                    DGVExcelExport.ExportToExcel(dataGridView, dialog.FileName);
                    const string msg1 = "קובץ הדוח נשמר בהצלחה\nהאם ברצונך לפתוח אותו כעת";
                    MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button1);
                    var open = MsgBox.Show(this);

                    if (open == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(dialog.FileName);
                    }
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    const string title = "שגיאה בדוחות...";
                    const string head = "ייצוא לאקסל";
                    const string desc = "ייצוא הדוח לאקסל נכשל\nייתכן כי הקובץ תפוס או שהמדיה אינה מאפשרת כתיבה.\nנסה לשמור בשם שונה ו/או במיקום שונה";
                    General.ShowErrorMessageDialog(this, title, head, desc, ex, "frmContactDetails");
                }
            }
        }

        public void LogOffAdmin()
        {
            ParamPanel.LogOffAdmin();
        }

        public void SelectRowById(int id)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (id.Equals(row.Cells["gdv_column_id"].Value))
                {
                    if (!row.Displayed)
                    {
                        dataGridView.FirstDisplayedScrollingRowIndex = row.Index;
                    }
                    row.Selected = true;
                    break;
                }
            }
        }

        public void SelectRowByKey(int key)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (key.Equals(row.Cells["unique_row_number"].Value))
                {
                    if (!row.Displayed)
                    {
                        dataGridView.FirstDisplayedScrollingRowIndex = row.Index;
                    }
                    row.Selected = true;
                    break;
                }
            }
        }

        private void ParamPanel_SelectedReportChanged(object sender, EventArgs e)
        {
            tbbExcel.Visible = ParamPanel.EnableExport;
        }

        private void SetFavMenu()
        {
            tbbFav.DropDownItems.Clear();
            var ids = AppSettingsHelper.GetParamValue("REPORT_FAV");

            if (ids.Length == 0)
            {
                tbbFav.DropDownItems.Add("לא נמצאו דוחות מועדפים");
                tbbFav.DropDownItems[0].Enabled = false;
            }
            else
            {
                var table = ReportHelper.GetFavReportsNames(ids);
                foreach (DataRow row in table.Rows)
                {
                    tbbFav.DropDownItems.Add((string)row["report_name"], null, FavMenu_Click);
                    tbbFav.DropDownItems[tbbFav.DropDownItems.Count - 1].Tag = row;
                }
            }
        }

        private static bool IsExistInFav(int reportId)
        {
            var ids = AppSettingsHelper.GetParamValue("REPORT_FAV") + ",";
            var exist = ids.Contains(reportId.ToString());
            return exist;
        }

        private void FavMenu_Click(object sender, EventArgs e)
        {
            var row = (DataRow)((ToolStripItem)sender).Tag;
            ParamPanel.SelectReport((string)row["report_group"], (int)row["id"], null);
        }

        private void TbbFavButtonClick(object sender, EventArgs e)
        {
            tbbFav.ShowDropDown();
        }

        private void TbbAddToFavClick(object sender, EventArgs e)
        {
            string msg1;
            const string msg2 = "הוספה למועדפים...";
            var id = ReportParametersPanel.ReportId;
            if (IsExistInFav(id))
            {
                msg1 = "הדוח הנוכחי כבר נמצא ברשימת המועדפים שלך";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
            }
            else
            {
                var ids = AppSettingsHelper.GetParamValue("REPORT_FAV");
                ids = ReportParametersPanel.ReportId + "," + ids;
                AppSettingsHelper.SetParamValue("REPORT_FAV", ids);
                SetFavMenu();

                msg1 = "הדוח נוסף לרשימת המועדפים שלך";
                MsgBox = new MyMessageBox(msg1, msg2) { CloseInterval = 2000 };
                MsgBox.Show(this);
            }
        }

        private void TbbDelFavClick(object sender, EventArgs e)
        {
            string msg1;
            const string msg2 = "הסרה מהמועדפים...";
            var id = ReportParametersPanel.ReportId;
            if (IsExistInFav(id))
            {
                var ids = AppSettingsHelper.GetParamValue("REPORT_FAV");
                ids = ids.Replace(id.ToString(), string.Empty);
                ids = ids.Replace(",,", ",");
                if (ids.EndsWith(",")) ids = ids.Substring(0, ids.Length - 1);
                if (ids.StartsWith(",")) ids = ids.Substring(1);

                AppSettingsHelper.SetParamValue("REPORT_FAV", ids);
                SetFavMenu();

                msg1 = "הדוח הוסר מרשימת המועדפים שלך";
                MsgBox = new MyMessageBox(msg1, msg2) { CloseInterval = 2000 };
                MsgBox.Show(this);
            }
            else
            {
                msg1 = "הדוח הנוכחי אינו ברשימת המועדפים שלך";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
            }
        }

        private void DataGridViewDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // *** ON ERROR - DO NOTHING!!! Dont delete this event ***
        }

        private void DataGridViewCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is DateTime)
            {
                if (((DateTime)e.Value).Year == Utils.DefaultBdayYear)
                {
                    e.CellStyle.Format = e.CellStyle.Format.Replace("yyyy", "0000");
                }
            }
        }

        private void TbbExcelVisibleChanged(object sender, EventArgs e)
        {
            tsDiv.Visible = tbbExcel.Visible;
        }
    }
}