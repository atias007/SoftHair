using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClientManage.BL;
using ClientManage.Library;

namespace ClientManage.Forms.OptionForms
{
    public partial class FormOptCalendar2 : BaseMdiOptionForm
    {
        public event EventHandler ClientsDSChanged;

        public FormOptCalendar2()
        {
            InitializeComponent();

            grdRemainder.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8);
        }

        private DataSet _dsRemainderValues;
        public DataSet DSRemainderValues
        {
            get { return _dsRemainderValues; }
            set { _dsRemainderValues = value; }
        }


        public override void LoadSettings()
        {
            if (_dsRemainderValues == null) _dsRemainderValues = CalendarHelper.GetAllRemainderValues(); ;
            grdRemainder.DataSource = _dsRemainderValues;
            grdRemainder.DataMember = "tblRemainderValues";
        }

        public override void SaveSettings()
        {

            if (_dsRemainderValues.HasChanges())
            {
                if (ClientsDSChanged != null)
                {
                    ClientsDSChanged(_dsRemainderValues, new EventArgs());
                }
            }
        }

        public override void ResetForm()
        {
            _dsRemainderValues = null;
            base.ResetForm();
        }

        private void grdRemainder_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (IsGridContainsValue(grdRemainder, e.FormattedValue.ToString(), 0, e.RowIndex))
            {
                var msg1 = "הערך " + e.FormattedValue.ToString() + " כבר קיים";
                var msg2 = "זמני תזכורת תור ביומן...";
                if (e.FormattedValue.ToString().Length == 0) msg1 = "לא הוזן טיפול. אנא הזן שם טיפול או לחץ Esc לביטול";
                MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
                e.Cancel = true;
            }
        }

        private void grdRemainder_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var msg1 = "הערך שהזנת בשורה אינו חוקי\nלביטול העדכון לחץ Esc";
            var msg2 = "זמני תזכורת שגויים...";
            MsgBox = new MyMessageBox(msg1, msg2, MyMessageBox.MyMessageType.Warning, MyMessageBox.MyMessageButton.Ok);
            MsgBox.Show(this);
        }
    }
}