using ClientManage.BL;
using ClientManage.Interfaces.Schemas;
using ClientManage.Library;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ClientManage.Forms
{
    public partial class FormCalArchive : BasePopupForm
    {
        public event EventHandler ReloadAppointments;

        public FormCalArchive()
        {
            InitializeComponent();

            dtpFromDate.CustomFormat = AppSettingsHelper.GetParamValue("APP_DATE_FORMAT");
            dtpToDate.CustomFormat = AppSettingsHelper.GetParamValue("APP_DATE_FORMAT");
        }

        private void OptArchiveCheckedChanged(object sender, EventArgs e)
        {
            if (sender.Equals(optArchive1))
            {
                optArchive1.ForeColor = Color.Black;
                optArchive2.ForeColor = Color.DimGray;
                optArchive3.ForeColor = Color.DimGray;
                optArchive4.ForeColor = Color.DimGray;
                optArchive5.ForeColor = Color.DimGray;
                optArchive6.ForeColor = Color.DimGray;
                lblFromDate.Enabled = false;
                lblToDate.Enabled = false;
                lblToDate2.Enabled = false;
                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = false;
                dtpFromDate.CalendarMonthBackground = Color.WhiteSmoke;
                dtpToDate.CalendarMonthBackground = Color.WhiteSmoke;
                cmbPeriod.Enabled = false;
                cmbPeriod.BackColor = Color.WhiteSmoke;
                lblPeriod.Enabled = false;
                txtFilename.Enabled = false;
                txtFilename.BackColor = Color.WhiteSmoke;
                btnBrowse.Enabled = false;
                btnOk.Text = "העבר לארכיון";
                txtRemark.Enabled = true;
                txtRemark.BackColor = Color.White;
            }
            else if (sender.Equals(optArchive2))
            {
                optArchive2.ForeColor = Color.Black;
                optArchive1.ForeColor = Color.DimGray;
                optArchive3.ForeColor = Color.DimGray;
                optArchive4.ForeColor = Color.DimGray;
                optArchive5.ForeColor = Color.DimGray;
                optArchive6.ForeColor = Color.DimGray;
                lblFromDate.Enabled = false;
                lblToDate.Enabled = false;
                lblToDate2.Enabled = false;
                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = false;
                dtpFromDate.CalendarMonthBackground = Color.WhiteSmoke;
                dtpToDate.CalendarMonthBackground = Color.WhiteSmoke;
                cmbPeriod.Enabled = false;
                cmbPeriod.BackColor = Color.WhiteSmoke;
                lblPeriod.Enabled = false;
                txtFilename.Enabled = false;
                txtFilename.BackColor = Color.WhiteSmoke;
                btnBrowse.Enabled = false;
                btnOk.Text = "העבר לארכיון";
                txtRemark.Enabled = true;
                txtRemark.BackColor = Color.White;
            }
            else if (sender.Equals(optArchive3))
            {
                optArchive3.ForeColor = Color.Black;
                optArchive1.ForeColor = Color.DimGray;
                optArchive2.ForeColor = Color.DimGray;
                optArchive4.ForeColor = Color.DimGray;
                optArchive5.ForeColor = Color.DimGray;
                optArchive6.ForeColor = Color.DimGray;
                lblFromDate.Enabled = true;
                lblToDate.Enabled = true;
                lblToDate2.Enabled = true;
                dtpFromDate.Enabled = true;
                dtpToDate.Enabled = true;
                dtpFromDate.CalendarMonthBackground = Color.White;
                dtpToDate.CalendarMonthBackground = Color.White;
                cmbPeriod.Enabled = false;
                cmbPeriod.BackColor = Color.WhiteSmoke;
                lblPeriod.Enabled = false;
                txtFilename.Enabled = false;
                txtFilename.BackColor = Color.WhiteSmoke;
                btnBrowse.Enabled = false;
                btnOk.Text = "העבר לארכיון";
                txtRemark.Enabled = true;
                txtRemark.BackColor = Color.White;
            }
            else if (sender.Equals(optArchive4))
            {
                optArchive4.ForeColor = Color.Black;
                optArchive1.ForeColor = Color.DimGray;
                optArchive2.ForeColor = Color.DimGray;
                optArchive3.ForeColor = Color.DimGray;
                optArchive5.ForeColor = Color.DimGray;
                optArchive6.ForeColor = Color.DimGray;
                lblFromDate.Enabled = false;
                lblToDate.Enabled = false;
                lblToDate2.Enabled = false;
                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = false;
                dtpFromDate.CalendarMonthBackground = Color.WhiteSmoke;
                dtpToDate.CalendarMonthBackground = Color.WhiteSmoke;
                cmbPeriod.Enabled = true;
                cmbPeriod.BackColor = Color.White;
                lblPeriod.Enabled = true;
                txtFilename.Enabled = false;
                txtFilename.BackColor = Color.WhiteSmoke;
                btnBrowse.Enabled = false;
                btnOk.Text = "העבר לארכיון";
                txtRemark.Enabled = true;
                txtRemark.BackColor = Color.White;
            }
            else if (sender.Equals(optArchive5))
            {
                optArchive5.ForeColor = Color.Black;
                optArchive1.ForeColor = Color.DimGray;
                optArchive2.ForeColor = Color.DimGray;
                optArchive4.ForeColor = Color.DimGray;
                optArchive3.ForeColor = Color.DimGray;
                optArchive6.ForeColor = Color.DimGray;
                lblFromDate.Enabled = false;
                lblToDate.Enabled = false;
                lblToDate2.Enabled = false;
                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = false;
                dtpFromDate.CalendarMonthBackground = Color.WhiteSmoke;
                dtpToDate.CalendarMonthBackground = Color.WhiteSmoke;
                cmbPeriod.Enabled = false;
                cmbPeriod.BackColor = Color.WhiteSmoke;
                lblPeriod.Enabled = false;
                txtFilename.Enabled = true;
                txtFilename.BackColor = Color.WhiteSmoke;
                btnBrowse.Enabled = true;
                btnOk.Text = "טען קובץ";
                txtRemark.Enabled = false;
                txtRemark.BackColor = Color.WhiteSmoke;
            }
            else if (sender.Equals(optArchive6))
            {
                optArchive6.ForeColor = Color.Black;
                optArchive1.ForeColor = Color.DimGray;
                optArchive2.ForeColor = Color.DimGray;
                optArchive4.ForeColor = Color.DimGray;
                optArchive3.ForeColor = Color.DimGray;
                optArchive5.ForeColor = Color.DimGray;
                lblFromDate.Enabled = false;
                lblToDate.Enabled = false;
                lblToDate2.Enabled = false;
                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = false;
                dtpFromDate.CalendarMonthBackground = Color.WhiteSmoke;
                dtpToDate.CalendarMonthBackground = Color.WhiteSmoke;
                cmbPeriod.Enabled = false;
                cmbPeriod.BackColor = Color.WhiteSmoke;
                lblPeriod.Enabled = false;
                txtFilename.Enabled = false;
                txtFilename.BackColor = Color.WhiteSmoke;
                btnBrowse.Enabled = false;
                btnOk.Text = "העבר לארכיון";
                txtRemark.Enabled = true;
                txtRemark.BackColor = Color.White;
            }
        }

        private void BtnBrowseClick(object sender, EventArgs e)
        {
            var res = openFileDialog1.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                txtFilename.Text = openFileDialog1.FileName;
                txtFilename.SelectionStart = txtFilename.Text.Length;
            }
        }

        private void FrmCalArchiveLoad(object sender, EventArgs e)
        {
            cmbPeriod.SelectedIndex = 2;
            dtpFromDate.Value = DateTime.Parse("1/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            dtpToDate.Value = dtpFromDate.Value.AddMonths(1).AddDays(-1);
        }

        private void CmbPeriodSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbPeriod.SelectedIndex)
            {
                case 0:
                    dtpFromDate.Value = DateTime.Now;
                    dtpToDate.Value = DateTime.Now;
                    break;

                case 1:
                    dtpFromDate.Value = DateTime.Now.AddDays(-1 * (int)DateTime.Now.DayOfWeek);
                    dtpToDate.Value = dtpFromDate.Value.AddDays(6);
                    break;

                case 2:
                    dtpFromDate.Value = DateTime.Parse("1/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
                    dtpToDate.Value = dtpFromDate.Value.AddMonths(1).AddDays(-1);
                    break;

                case 3:
                    dtpFromDate.Value = DateTime.Parse("1/" + Convert.ToString(DateTime.Now.Month - 1) + "/" + DateTime.Now.Year);
                    dtpToDate.Value = dtpFromDate.Value.AddMonths(1).AddDays(-1);
                    break;

                case 4:
                    dtpFromDate.Value = DateTime.Parse("1/1/" + Convert.ToString(DateTime.Now.Year));
                    dtpToDate.Value = dtpFromDate.Value.AddYears(1).AddDays(-1);
                    break;

                case 5:
                    dtpFromDate.Value = DateTime.Parse("1/1/" + Convert.ToString(DateTime.Now.Year - 1));
                    dtpToDate.Value = dtpFromDate.Value.AddYears(1).AddDays(-1);
                    break;
            }
        }

        private void BtnOkClick(object sender, EventArgs e)
        {
            var msg1 = ValidateFrom();
            const string msg2 = "ארכיון...";

            if (msg1.Length == 0)
            {
                var count = 0;
                if (!optArchive5.Checked)
                {
                    var res = saveFileDialog1.ShowDialog(this);
                    string filename;
                    if (res == DialogResult.OK) filename = saveFileDialog1.FileName;
                    else return;

                    msg1 = "שים לב: הנך עומד להעביר את כל התורים בטווח הנבחר לארכיון.\nכל התורים הנ\"ל ימחקו מהיומן!\n\nהאם אתה בטוח שברצונך להמשיך?";
                    MyMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
                    res = MyMessageBox.Show(this);
                    if (res == DialogResult.Yes)
                    {
                        try
                        {
                            var option = (optArchive6.Checked ? 1 : (chkOnlyOld.Checked ? 0 : -1));
                            if (optArchive1.Checked || optArchive2.Checked || optArchive6.Checked)
                            {
                                //count = CalendarHelper.ArchiveCalendar(filename, txtRemark.Text, null, null, option, optArchive2.Checked);
                            }
                            else
                            {
                                //count = CalendarHelper.ArchiveCalendar(filename, txtRemark.Text, dtpFromDate.Value, dtpToDate.Value, option, optArchive2.Checked);
                            }
                        }
                        catch (Exception ex)
                        {
                            const string title = "שגיאה בארכיון...";
                            const string head = "העברת התורים לארכיון";
                            const string desc = "תהליך העברת התורים לארכיון נכשל.\nודא כי היעד אינו מדיה לקריאה בלבד.";
                            General.ShowErrorMessageDialog(this, title, head, desc, ex, "frmCalArchive");
                        }

                        if (count == 0) msg1 = "לא נמצאו תורים להעברה לארכיון בטווח התאריכים הנבחר";
                        else
                        {
                            msg1 = count + " תורים הועברו לקובץ הארכיון בהצלחה";
                            if (ReloadAppointments != null) ReloadAppointments(this, new EventArgs());
                        }
                        MyMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Information, MyMessageBox.MyMessageButton.Ok);
                        MyMessageBox.Show(this);

                        this.Close();
                    }
                }
                else
                {
                    DataSet ds = null;
                    var archive = new ArchiveCalendar();
                    var info = archive.General.NewGeneralRow();

                    try
                    {
                        //ds = CalendarHelper.GetArchiveDataSet(txtFilename.Text);
                        var row = ds.Tables[0].Rows[0];
                        count = ds.Tables[1].Rows.Count;
                        info.ClientId = Convert.ToInt32(row["ClientId"]);
                        info.DateArchive = Convert.ToDateTime(row["DateArchive"]);
                        try { info.FromDate = Convert.ToDateTime(row["FromDate"]); }
                        catch { info.FromDate = DateTime.MinValue; }
                        info.Remark = Convert.ToString(row["remark"]);
                        try { info.ToDate = Convert.ToDateTime(row["ToDate"]); }
                        catch { info.ToDate = DateTime.MinValue; }
                        info.Mode = Convert.ToInt32(row["Mode"]);
                        info.OnlyOld = Convert.ToBoolean(row["OnlyOld"]);
                    }
                    catch (Exception ex)
                    {
                        const string title = "שגיאה בארכיון...";
                        const string head = "טעינת קובץ ארכיון";
                        const string desc = "ארעה שגיאה בקריאת קובץ הארכיון.\nייתכן כי קובץ זה אינו קובץ ארכיון חוקי או שהקובץ פגום";
                        General.ShowErrorMessageDialog(this, title, head, desc, ex, "frmCalArchive");
                        return;
                    }

                    if (AppSettingsHelper.GetParamValue<int>("APP_CLIENT_ID") == info.ClientId)
                    {
                        using (var fCalArchiveInfo = new FormCalArchiveInfo(info, count, txtFilename.Text))
                        {
                            fCalArchiveInfo.ReloadAppointments += FCalArchiveInfoReloadAppointments;
                            fCalArchiveInfo.ShowDialog(this);
                        }
                    }
                    else
                    {
                        const string title = "שגיאה בארכיון...";
                        const string head = "טעינת קובץ ארכיון";
                        const string desc = "מספר הלקוח בקובץ הארכיון אינו תואם את המספר הלקוח שלך.\nלא ניתן לטעון את קובץ הארכיון";
                        General.ShowErrorMessageDialog(this, title, head, desc, null, "frmCalArchive");
                    }
                }
            }
            else
            {
                MyMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MyMessageBox.Show(this);
            }
        }

        private void FCalArchiveInfoReloadAppointments(object sender, EventArgs e)
        {
            if (ReloadAppointments != null) ReloadAppointments(this, new EventArgs());
        }

        private string ValidateFrom()
        {
            var msg = string.Empty;
            txtFilename.Text = txtFilename.Text.Trim();

            if (optArchive3.Checked || optArchive4.Checked)
            {
                if (dtpToDate.Value < dtpFromDate.Value)
                {
                    msg += "תאריך היעד חייב להיות גדול מתאריך ההתחלה\n";
                }
            }
            if (optArchive5.Checked)
            {
                if (txtFilename.Text.Length == 0)
                {
                    msg += "לא נבחר קובץ לטעינה\n";
                }
                else
                {
                    if (!File.Exists(txtFilename.Text))
                    {
                        msg += "הקובץ שנבחר לטעינה אינו קיים. בחר בקובץ אחר\n";
                    }
                }
            }

            msg = msg.Trim();
            return msg;
        }

        private void Label3Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.FromArgb(182, 187, 193)), 0, 0, label3.Width, 0);
        }

        private void TxtRemarkLeave(object sender, EventArgs e)
        {
            base.TextBoxLeave((TextBox)sender);
        }

        private void TxtRemarkEnter(object sender, EventArgs e)
        {
            base.TextBoxEnter((TextBox)sender);
        }
    }
}