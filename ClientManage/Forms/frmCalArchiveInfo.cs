using ClientManage.BL;
using ClientManage.Interfaces;
using ClientManage.Interfaces.Schemas;
using ClientManage.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClientManage.Forms
{
    public partial class FormCalArchiveInfo : BasePopupForm
    {
        public event EventHandler ReloadAppointments;

        private readonly string _fileName = string.Empty;
        private ProcProgress proc = null;
        private readonly string _info = string.Empty;
        private readonly int _count = 0;
        private readonly string _caption = string.Empty;

        public FormCalArchiveInfo(ArchiveCalendar.GeneralRow info, int count, string fileName)
        {
            InitializeComponent();

            _fileName = fileName;
            _count = count;
            _info = lblInfo.Text;
            _caption = lblCap.Text;

            try
            {
                LoadInformation(info, count);
            }
            catch { }
        }

        private void frmCalArchiveInfo_Activated(object sender, EventArgs e)
        {
            btnCancel.Select();
        }

        private void LoadInformation(ArchiveCalendar.GeneralRow info, int count)
        {
            txtRemark.Text = info.Remark;
            lblArchiveDate.Text = info.DateArchive.ToString("dd/MM/yyyy בשעה: HH:mm");
            lblCap.Text = string.Format(_caption, count);
            switch (info.Mode)
            {
                case 1:
                    lblCalScope.Text = "כל התורים";
                    break;

                case 2:
                    lblCalScope.Text = "כל התורים מלבד תור אחרון ללקוח";
                    break;

                case 3:
                    lblCalScope.Text = "מ- " + info.FromDate.ToShortDateString() + " עד " + info.ToDate.ToShortDateString();
                    break;

                default:
                    break;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var msg1 = string.Empty;
            var msg2 = "ארכיון...";
            var count = 0;

            try
            {
                progressBar1.Maximum = _count;
                progressBar1.Value = 0;
                progressBar1.Visible = true;
                btnCancel.Visible = false;
                btnOk.Visible = false;
                lblInfo.Visible = true;
                proc = new ProcProgress(_count);
                proc.ValueChanged += new EventHandler(proc_ValueChanged);
                Application.DoEvents();

                //count = CalendarHelper.LoadArchiveToCalendar(_fileName, ref proc);

                progressBar1.Value = progressBar1.Maximum;
                lblInfo.Text = string.Format(_info, "100%");
                Application.DoEvents();

                msg1 = count.ToString() + " תורים הועברו ליומן בהצלחה";
                ReloadAppointments?.Invoke(this, new EventArgs());
                MyMessageBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Information, MyMessageBox.MyMessageButton.Ok);
                this.Hide();
                MyMessageBox.Show(this);
            }
            catch (Exception ex)
            {
                var title = "שגיאה בארכיון...";
                var head = "טעינת קובץ ארכיון";
                var desc = "ארעה שגיאה בקריאת קובץ הארכיון.\nייתכן כי קובץ זה אינו קובץ ארכיון חוקי או שהקובץ פגום";
                General.ShowErrorMessageDialog(this, title, head, desc, ex, "frmCalArchiveInfo");
            }
            this.Close();
        }

        private void proc_ValueChanged(object sender, EventArgs e)
        {
            if (progressBar1 != null)
            {
                progressBar1.Value = proc.Value;
                lblInfo.Text = string.Format(_info, proc.PercentValue.ToString("##0%"));
                Application.DoEvents();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}