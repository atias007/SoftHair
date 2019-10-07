using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ClientManage.BL;
using ClientManage.Interfaces;
using ClientManage.Library;

namespace ClientManage.Forms.OptionForms
{
    public partial class FormOptClients2 : BaseMdiOptionForm
    {
        public event EventHandler ClientsDsChanged;

        public FormOptClients2()
        {
            InitializeComponent();
            grdComponents.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8);

            var table = new DataTable();
            table.Columns.Add("id", typeof(int));
            table.Columns.Add("title", typeof(string));
            table.Rows.Add(1, "טקסט חופשי");
            table.Rows.Add(2, "בחירה מרשימה");
            table.Rows.Add(3, "תאריך");
// ReSharper disable PossibleNullReferenceException
            ((DataGridViewComboBoxColumn)grdComponents.Columns["clmDataType"]).DataSource = table;
            ((DataGridViewComboBoxColumn)grdComponents.Columns["clmDataType"]).DisplayMember = "title";
            ((DataGridViewComboBoxColumn)grdComponents.Columns["clmDataType"]).ValueMember = "id";
// ReSharper restore PossibleNullReferenceException
        }

        private DataSet _dsComponents;
        public DataSet DsComponents
        {
            get { return _dsComponents; }
            set { _dsComponents = value; }
        }

        public override void LoadSettings()
        {
            txtTitle.Text = LoadSettingValue<string>("CLIENT_COMPONENTS_TITLE");

            if (_dsComponents == null)
            {
                _dsComponents = ClientHelper.GetComponentsConfig();
            }
            grdComponents.DataSource = _dsComponents;
            grdComponents.DataMember = "tblClientComponentsConfig";
        }

        public override void SaveSettings()
        {
            txtTitle.Text = txtTitle.Text.Trim();

            SaveSettingValue("CLIENT_COMPONENTS_TITLE", txtTitle.Text);

            if (_dsComponents.HasChanges())
            {
                if (ClientsDsChanged != null) ClientsDsChanged(_dsComponents, new EventArgs());
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            RunScript("ClientManage.Forms.OptionForms.Script_Hair.txt");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            RunScript("ClientManage.Forms.OptionForms.Script_Nail.txt");
        }

        private void RunScript(string filename)
        {
            const string caption = "שינוי הגדרות ברירת מחדל";
            const string title = "שגיאה בשינוי ההגדרות";
            const string msg1 = "האם אתה בטוח שברצונך לשנות את הגדרות המערכת";
            const string msg2 = "לא ניצן לבצע שינוי מספר {0}";
            const string msg3 = "הפעולה הסתיימה בהצלחה\nבלחיצה על אישור המערכת תיסגר";

            MsgBox = new MyMessageBox(msg1, caption, MyMessageBox.MyMessageType.Question, MyMessageBox.MyMessageButton.YesNo, MyMessageBox.MyMessageDefaultButton.Button2);
            var result = MsgBox.Show(this);
            if (result == DialogResult.No) return;

            var script = General.GetResource(filename);
            var index = 0;

            try
            {
                using (var executer = new SqlExecute(General.ConnectionString))
                {
                    foreach (var line in script.Split(';'))
                    {
                        index++;
                        var s = line.Trim();
                        if (!string.IsNullOrEmpty(s))
                        {
                            executer.ExecuteSqlStatement(s);
                        }
                    }
                }

                MsgBox = new MyMessageBox(msg3, caption, MyMessageBox.MyMessageType.Information, MyMessageBox.MyMessageButton.Ok);
                MsgBox.Show(this);
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                General.ShowErrorMessageDialog(this, title, caption, string.Format(msg2, index), ex, "SqlExecute");
            }
        }
    }
}