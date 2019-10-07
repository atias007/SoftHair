using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BizCareAdmin
{
    public partial class frmDBCompare : Form
    {
        OpenFileDialog dialog = null;
        SqlExecute dbSource = null;
        SqlExecute dbTarget = null;
        string script = string.Empty;

        public frmDBCompare()
        {
            InitializeComponent();
        }

        private void btnFrom_Click(object sender, EventArgs e)
        {
            var res = dialog.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                txtFrom.Text = dialog.FileName;
            }
        }

        private void btnTo_Click(object sender, EventArgs e)
        {
            var res = dialog.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                txtTo.Text = dialog.FileName;
            }
        }

        private void frmDBCompare_Load(object sender, EventArgs e)
        {
            dialog = new OpenFileDialog();
            dialog.Filter = "Database Files (*.dat) | *.dat";
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            script = string.Empty;
            dbSource = new SqlExecute();
            dbTarget = new SqlExecute();
            dbSource.InitilizeDBConnection(txtFrom.Text);
            dbTarget.InitilizeDBConnection(txtTo.Text);
            txtRep.Text = string.Empty;
            var diff = string.Empty;
            string[] fields = null;
            DataTable dtTarget = null;
            DataTable dtSource = null;
            DataRow[] sel;

            #region Tables

            dtTarget = dbTarget.GetSchema("Tables");
            dtSource = dbSource.GetSchema("Tables");
            sel = null;

            foreach (DataRow row in dtSource.Rows)
            {
                sel = dtTarget.Select("TABLE_NAME='" + row["TABLE_NAME"].ToString() + "' AND TABLE_TYPE='" + row["TABLE_TYPE"].ToString() + "'");
                if (sel.Length == 0)
                {
                    txtRep.Text += "MISSING " + row["TABLE_TYPE"].ToString() + ": Name = " + row["TABLE_NAME"].ToString() + "\r\n";
                }
                else if (sel.Length > 1)
                {
                    diff = diff.Substring(0, diff.Length - 2);
                    txtRep.Text += "MORE THEN 1 MATCH " + row["TABLE_TYPE"].ToString() + "!!! Name = " + row["TABLE_NAME"].ToString() + "\r\n";
                }
            }

            foreach (DataRow row in dtTarget.Rows)
            {
                sel = dtSource.Select("TABLE_NAME='" + row["TABLE_NAME"].ToString() + "' AND TABLE_TYPE='" + row["TABLE_TYPE"].ToString() + "'");
                if (sel.Length == 0)
                {
                    txtRep.Text += "EXTRA " + row["TABLE_TYPE"].ToString() + ": Name = " + row["TABLE_NAME"].ToString() + "\r\n";
                    if (row["TABLE_TYPE"].ToString() == "TABLE")
                    {
                        script += "DROP TABLE " + row["TABLE_NAME"].ToString() + ";\r\n\r\n";
                    }
                }
            }

            #endregion

            #region Columns

            dtTarget = dbTarget.GetSchema("Columns");
            dtSource = dbSource.GetSchema("Columns");
            diff = string.Empty;
            sel = null;
            fields = "ORDINAL_POSITION,COLUMN_HASDEFAULT,COLUMN_DEFAULT,COLUMN_FLAGS,IS_NULLABLE,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH,CHARACTER_OCTET_LENGTH,NUMERIC_PRECISION,DATETIME_PRECISION".Split(',');

            foreach (DataRow row in dtSource.Rows)
            {
                sel = dtTarget.Select("TABLE_NAME='" + row["TABLE_NAME"].ToString() + "' AND COLUMN_NAME='" + row["COLUMN_NAME"].ToString() + "'");
                if (sel.Length == 0)
                {
                    txtRep.Text += "MISSING COLUMN: COLUMN_NAME=" + row["COLUMN_NAME"].ToString() + ", TABLE_NAME=" + row["TABLE_NAME"].ToString() + "\r\n";
                }
                else if (sel.Length == 1)
                {
                    diff = GetRowsDiff(row, sel[0], fields);
                    if (diff.Length > 0)
                    {
                        diff = diff.Substring(0, diff.Length - 2);
                        txtRep.Text += "DIFF COLUMN PROP: COLUMN_NAME=" + row["COLUMN_NAME"].ToString() + ", TABLE_NAME=" + row["TABLE_NAME"].ToString() + "  [" + diff + "]\r\n";
                    }
                }
            }

            foreach (DataRow row in dtTarget.Rows)
            {
                sel = dtSource.Select("TABLE_NAME='" + row["TABLE_NAME"].ToString() + "' AND COLUMN_NAME='" + row["COLUMN_NAME"].ToString() + "'");
                if (sel.Length == 0)
                {
                    txtRep.Text += "EXRTA COLUMN: COLUMN_NAME=" + row["COLUMN_NAME"].ToString() + ", TABLE_NAME=" + row["TABLE_NAME"].ToString() + "\r\n";
                }
            }

            #endregion

            #region Indexes

            dtTarget = dbTarget.GetSchema("Indexes");
            dtSource = dbSource.GetSchema("Indexes");
            diff = string.Empty;
            sel = null;
            fields = "PRIMARY_KEY,UNIQUE".Split(',');

            foreach (DataRow row in dtSource.Rows)
            {
                sel = dtTarget.Select("TABLE_NAME='" + row["TABLE_NAME"].ToString() + "' AND COLUMN_NAME='" + row["COLUMN_NAME"].ToString() + "' AND INDEX_NAME='" + row["INDEX_NAME"].ToString() + "'");
                if (sel.Length == 0)
                {
                    txtRep.Text += "MISSING INDEX: COLUMN_NAME=" + row["COLUMN_NAME"].ToString() + ", TABLE_NAME=" + row["TABLE_NAME"].ToString() + "\r\n";
                }
                else if (sel.Length == 1)
                {
                    diff = GetRowsDiff(row, sel[0], fields);
                    if (diff.Length > 0)
                    {
                        diff = diff.Substring(0, diff.Length - 2);
                        txtRep.Text += "DIFF INDEX PROP: COLUMN_NAME=" + row["COLUMN_NAME"].ToString() + ", TABLE_NAME=" + row["TABLE_NAME"].ToString() + "  [" + diff + "]\r\n";
                    }
                }
            }

            foreach (DataRow row in dtTarget.Rows)
            {
                sel = dtSource.Select("TABLE_NAME='" + row["TABLE_NAME"].ToString() + "' AND COLUMN_NAME='" + row["COLUMN_NAME"].ToString() + "'");
                if (sel.Length == 0)
                {
                    txtRep.Text += "EXTRA INDEX: COLUMN_NAME=" + row["COLUMN_NAME"].ToString() + ", TABLE_NAME=" + row["TABLE_NAME"].ToString() + "\r\n";
                }
            }

            #endregion

            #region Procedures

            dtTarget = dbTarget.GetSchema("Procedures");
            dtSource = dbSource.GetSchema("Procedures");
            diff = string.Empty;
            sel = null;
            fields = "PROCEDURE_TYPE,PROCEDURE_DEFINITION".Split(',');

            foreach (DataRow row in dtSource.Rows)
            {
                sel = dtTarget.Select("PROCEDURE_NAME='" + row["PROCEDURE_NAME"].ToString() + "'");
                if (sel.Length == 0)
                {
                    txtRep.Text += "MISSING PROCEDURE: PROCEDURE_NAME=" + row["PROCEDURE_NAME"].ToString() + "\r\n";
                    script += "CREATE PROCEDURE " + row["PROCEDURE_NAME"].ToString() + " AS \r\n" + row["PROCEDURE_DEFINITION"].ToString();
                    if (!row["PROCEDURE_DEFINITION"].ToString().Trim().EndsWith(";")) script += ";";
                    script += "\r\n\r\n";
                }
                else if (sel.Length == 1)
                {
                    diff = GetRowsDiff(row, sel[0], fields);
                    if (diff.Length > 0)
                    {
                        diff = diff.Substring(0, diff.Length - 2);
                        txtRep.Text += "DIFF PROCEDURE PROP: PROCEDURE_NAME=" + row["PROCEDURE_NAME"].ToString() + "  [" + diff + "]\r\n";
                        script += "DROP PROCEDURE " + row["PROCEDURE_NAME"].ToString() + ";\r\n\r\n";
                        script += "CREATE PROCEDURE " + row["PROCEDURE_NAME"].ToString() + " AS \r\n" + row["PROCEDURE_DEFINITION"].ToString();
                        if (!row["PROCEDURE_DEFINITION"].ToString().Trim().EndsWith(";")) script += ";";
                        script += "\r\n\r\n";
                    }
                }
            }

            foreach (DataRow row in dtTarget.Rows)
            {
                sel = dtSource.Select("PROCEDURE_NAME='" + row["PROCEDURE_NAME"].ToString() + "'");
                if (sel.Length == 0)
                {
                    txtRep.Text += "EXTRA PROCEDURE: PROCEDURE_NAME=" + row["PROCEDURE_NAME"].ToString() + "\r\n";
                }
            }

            #endregion

            #region Views

            dtTarget = dbTarget.GetSchema("Views");
            dtSource = dbSource.GetSchema("Views");
            diff = string.Empty;
            sel = null;
            fields = "VIEW_DEFINITION,CHECK_OPTION,IS_UPDATABLE".Split(',');

            foreach (DataRow row in dtSource.Rows)
            {
                sel = dtTarget.Select("TABLE_NAME='" + row["TABLE_NAME"].ToString() + "'");
                if (sel.Length == 0)
                {
                    txtRep.Text += "MISSING VIEW: NAME=" + row["TABLE_NAME"].ToString() + "\r\n";
                    script += "CREATE PROCEDURE " + row["TABLE_NAME"].ToString() + " AS \r\n" + row["VIEW_DEFINITION"].ToString();
                    if (!row["VIEW_DEFINITION"].ToString().Trim().EndsWith(";")) script += ";";
                    script += "\r\n\r\n";
                }
                else if (sel.Length == 1)
                {
                    diff = GetRowsDiff(row, sel[0], fields);
                    if (diff.Length > 0)
                    {
                        diff = diff.Substring(0, diff.Length - 2);
                        txtRep.Text += "DIFF VIEW PROP: NAME=" + row["TABLE_NAME"].ToString() + "  [" + diff + "]\r\n";
                        script += "DROP PROCEDURE " + row["TABLE_NAME"].ToString() + ";\r\n\r\n";
                        script += "CREATE PROCEDURE " + row["TABLE_NAME"].ToString() + " AS \r\n" + row["VIEW_DEFINITION"].ToString();
                        if (!row["VIEW_DEFINITION"].ToString().Trim().EndsWith(";")) script += ";";
                        script += "\r\n\r\n";
                    }
                }
            }

            foreach (DataRow row in dtTarget.Rows)
            {
                sel = dtSource.Select("TABLE_NAME='" + row["TABLE_NAME"].ToString() + "'");
                if (sel.Length == 0)
                {
                    txtRep.Text += "EXTRA VIEW: NAME=" + row["TABLE_NAME"].ToString() + "\r\n";
                }
            }

            #endregion

            if (txtRep.Text.Length == 0)
            {
                MessageBox.Show("Database structure are identical", "Compare...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (script.Length > 0)
                {
                    var f = new frmNotepad(script);
                    f.Show();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbSource = new SqlExecute();
            dbSource.InitilizeDBConnection(txtFrom.Text);
            comboBox1.DisplayMember = "CollectionName";
            comboBox1.ValueMember = "CollectionName";
            comboBox1.DataSource = dbSource.GetSchema();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dbSource.GetSchema(comboBox1.SelectedValue.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            script = string.Empty;
            dbSource = new SqlExecute();
            dbTarget = new SqlExecute();
            dbSource.InitilizeDBConnection(txtFrom.Text);
            dbTarget.InitilizeDBConnection(txtTo.Text);
            txtRep.Text = string.Empty;
            var diff = string.Empty;
            string[] fields = null;
            DataTable dtTarget = null;
            DataTable dtSource = null;
            DataRow[] sel;

            #region Parameters

            dtSource = dbSource.ExecuteDataset("SELECT param_name, param_value FROM tblParams").Tables[0];
            dtTarget = dbTarget.ExecuteDataset("SELECT param_name, param_value FROM tblParams").Tables[0];

            foreach (DataRow row in dtSource.Rows)
            {
                sel = dtTarget.Select("param_name='" + row["param_name"].ToString() + "'");
                if (sel.Length == 0)
                {
                    txtRep.Text += "MISSING PARAMETER: NAME=" + row["param_name"].ToString() + "\r\n";
                    script += "INSERT INTO tblParams (param_name, param_value) VALUES('" + row["param_name"].ToString() + "', '" + row["param_value"].ToString() + "');\r\n\r\n";
                }
            }
            foreach (DataRow row in dtTarget.Rows)
            {
                sel = dtSource.Select("param_name='" + row["param_name"].ToString()+ "'");
                if (sel.Length == 0)
                {
                    txtRep.Text += "EXTRA PARAMETER: NAME=" + row["param_name"].ToString() + "\r\n";
                    script += "DELETE FROM tblParams WHERE param_name = '" + row["param_name"].ToString() + "';\r\n\r\n";
                }
            }

            #endregion

            #region tblCallTypes

            dtSource = dbSource.ExecuteDataset("SELECT id, caption FROM tblCallTypes").Tables[0];
            dtTarget = dbTarget.ExecuteDataset("SELECT id, caption FROM tblCallTypes").Tables[0];
            fields = "caption".Split(',');

            foreach (DataRow row in dtSource.Rows)
            {
                sel = dtTarget.Select("id=" + row["id"].ToString());
                if (sel.Length == 0)
                {
                    txtRep.Text += "MISSING ROW AT tblCallTypes: id=" + row["id"].ToString() + ", caption=" + row["caption"].ToString() + "\r\n";
                }
                else if (sel.Length == 1)
                {
                    diff = GetRowsDiff(row, sel[0], fields);
                    if (diff.Length > 0)
                    {
                        txtRep.Text += "DIFF ROW VALUE AT tblCallTypes: id=" + row["id"].ToString() + "  [" + diff + "]\r\n";
                    }
                }
            }
            foreach (DataRow row in dtTarget.Rows)
            {
                sel = dtSource.Select("id=" + row["id"].ToString());
                if (sel.Length == 0)
                {
                    txtRep.Text += "EXTRA ROW AT tblCallTypes: id=" + row["id"].ToString() + ", caption=" + row["caption"].ToString() + "\r\n";
                }
            }

            #endregion

            #region tblMailTemplates

            dtSource = dbSource.ExecuteDataset("SELECT * FROM tblMailTemplates").Tables[0];
            dtTarget = dbTarget.ExecuteDataset("SELECT * FROM tblMailTemplates WHERE id < 20000").Tables[0];
            fields = "template_name,mail_body,mail_subject,mail_html_content".Split(',');

            foreach (DataRow row in dtSource.Rows)
            {
                sel = dtTarget.Select("id=" + row["id"].ToString());
                if (sel.Length == 0)
                {
                    txtRep.Text += "MISSING ROW AT tblMailTemplates: id=" + row["id"].ToString() + ", template_name=" + row["template_name"].ToString() + "\r\n";
                }
                else if (sel.Length == 1)
                {
                    diff = GetRowsDiff(row, sel[0], fields);
                    if (diff.Length > 0)
                    {
                        txtRep.Text += "DIFF ROW VALUE AT tblMailTemplates: id=" + row["id"].ToString() + "  [" + diff + "]\r\n";
                    }
                }
            }
            foreach (DataRow row in dtTarget.Rows)
            {
                sel = dtSource.Select("id=" + row["id"].ToString());
                if (sel.Length == 0)
                {
                    txtRep.Text += "EXTRA ROW AT tblMailTemplates: id=" + row["id"].ToString() + ", template_name=" + row["template_name"].ToString() + "\r\n";
                }
            }

            #endregion

            #region tblPrintTemplates

            dtSource = dbSource.ExecuteDataset("SELECT * FROM tblPrintTemplates").Tables[0];
            dtTarget = dbTarget.ExecuteDataset("SELECT * FROM tblPrintTemplates").Tables[0];
            fields = new string[] { "template" };

            foreach (DataRow row in dtSource.Rows)
            {
                sel = dtTarget.Select("key='" + row["key"].ToString() + "'");
                if (sel.Length == 0)
                {
                    txtRep.Text += "MISSING ROW AT tblPrintTemplates: key=" + row["key"].ToString() + "\r\n";
                }
                else if (sel.Length == 1)
                {
                    diff = GetRowsDiff(row, sel[0], fields);
                    if (diff.Length > 0)
                    {
                        txtRep.Text += "DIFF ROW VALUE AT tblPrintTemplates: key=" + row["key"].ToString() + "  [" + diff + "]\r\n";
                    }
                }
            }
            foreach (DataRow row in dtTarget.Rows)
            {
                sel = dtSource.Select("key='" + row["key"].ToString() + "'");
                if (sel.Length == 0)
                {
                    txtRep.Text += "EXTRA ROW AT tblMailTemplates: key=" + row["key"].ToString() + "\r\n";
                }
            }

            #endregion

            #region tblRemainderValues

            dtSource = dbSource.ExecuteDataset("SELECT * FROM tblRemainderValues").Tables[0];
            dtTarget = dbTarget.ExecuteDataset("SELECT * FROM tblRemainderValues").Tables[0];
            fields = new string[] { "description" };

            foreach (DataRow row in dtSource.Rows)
            {
                sel = dtTarget.Select("min_value=" + row["min_value"].ToString());
                if (sel.Length == 0)
                {
                    txtRep.Text += "MISSING ROW AT tblRemainderValues: min_value=" + row["min_value"].ToString() + "\r\n";
                }
                else if (sel.Length == 1)
                {
                    diff = GetRowsDiff(row, sel[0], fields);
                    if (diff.Length > 0)
                    {
                        txtRep.Text += "DIFF ROW VALUE AT tblRemainderValues: min_value=" + row["min_value"].ToString() + "  [" + diff + "]\r\n";
                    }
                }
            }
            foreach (DataRow row in dtTarget.Rows)
            {
                sel = dtSource.Select("min_value=" + row["min_value"].ToString());
                if (sel.Length == 0)
                {
                    txtRep.Text += "EXTRA ROW AT tblRemainderValues: min_value=" + row["min_value"].ToString() + "\r\n";
                }
            }

            #endregion

            #region tblReports

            dtSource = dbSource.ExecuteDataset("SELECT * FROM tblReports").Tables[0];
            dtTarget = dbTarget.ExecuteDataset("SELECT * FROM tblReports WHERE id < 20000").Tables[0];
            fields = new string[] { "report_name", "report_group", "report_xml" };

            foreach (DataRow row in dtSource.Rows)
            {
                sel = dtTarget.Select("id=" + row["id"].ToString());
                if (sel.Length == 0)
                {
                    txtRep.Text += "MISSING ROW AT tblReports: id=" + row["id"].ToString() + ", report_name=" + row["report_name"].ToString() + "\r\n";
                }
                else if (sel.Length == 1)
                {
                    diff = GetRowsDiff(row, sel[0], fields);
                    if (diff.Length > 0)
                    {
                        txtRep.Text += "DIFF ROW VALUE AT tblReports: id=" + row["id"].ToString() + "  [" + diff + "]\r\n";
                    }
                }
            }
            foreach (DataRow row in dtTarget.Rows)
            {
                sel = dtSource.Select("id=" + row["id"].ToString());
                if (sel.Length == 0)
                {
                    txtRep.Text += "EXTRA ROW AT tblReports: id=" + row["id"].ToString() + ", report_name=" + row["report_name"].ToString() + "\r\n";
                }
            }

            #endregion

            #region tblSMSTypes

            dtSource = dbSource.ExecuteDataset("SELECT id, caption FROM tblSMSTypes").Tables[0];
            dtTarget = dbTarget.ExecuteDataset("SELECT id, caption FROM tblSMSTypes").Tables[0];
            fields = "caption".Split(',');

            foreach (DataRow row in dtSource.Rows)
            {
                sel = dtTarget.Select("id=" + row["id"].ToString());
                if (sel.Length == 0)
                {
                    txtRep.Text += "MISSING ROW AT tblSMSTypes: id=" + row["id"].ToString() + ", caption=" + row["caption"].ToString() + "\r\n";
                }
                else if (sel.Length == 1)
                {
                    diff = GetRowsDiff(row, sel[0], fields);
                    if (diff.Length > 0)
                    {
                        txtRep.Text += "DIFF ROW VALUE AT tblSMSTypes: id=" + row["id"].ToString() + "  [" + diff + "]\r\n";
                    }
                }
            }
            foreach (DataRow row in dtTarget.Rows)
            {
                sel = dtSource.Select("id=" + row["id"].ToString());
                if (sel.Length == 0)
                {
                    txtRep.Text += "EXTRA ROW AT tblSMSTypes: id=" + row["id"].ToString() + ", caption=" + row["caption"].ToString() + "\r\n";
                }
            }

            #endregion

            #region tblReportGroupOrder

            dtSource = dbSource.ExecuteDataset("SELECT group_name, group_order FROM tblReportGroupOrder").Tables[0];
            dtTarget = dbTarget.ExecuteDataset("SELECT group_name, group_order FROM tblReportGroupOrder").Tables[0];
            fields = "group_order".Split(',');

            foreach (DataRow row in dtSource.Rows)
            {
                sel = dtTarget.Select("group_name='" + row["group_name"].ToString() + "'");
                if (sel.Length == 0)
                {
                    txtRep.Text += "MISSING ROW AT tblReportGroupOrder: group_name=" + row["group_name"].ToString() + ", group_order=" + row["group_order"].ToString() + "\r\n";
                }
                else if (sel.Length == 1)
                {
                    diff = GetRowsDiff(row, sel[0], fields);
                    if (diff.Length > 0)
                    {
                        txtRep.Text += "DIFF ROW VALUE AT tblReportGroupOrder: group_name=" + row["group_name"].ToString() + "  [" + diff + "]\r\n";
                    }
                }
            }
            foreach (DataRow row in dtTarget.Rows)
            {
                sel = dtSource.Select("group_name='" + row["group_name"].ToString() + "'");
                if (sel.Length == 0)
                {
                    txtRep.Text += "EXTRA ROW AT tblReportGroupOrder: group_name=" + row["group_name"].ToString() + ", group_order=" + row["group_order"].ToString() + "\r\n";
                }
            }

            #endregion

            #region tblSubscribersStatus

            dtSource = dbSource.ExecuteDataset("SELECT id, title, order_id FROM tblSubscribersStatus").Tables[0];
            dtTarget = dbTarget.ExecuteDataset("SELECT id, title, order_id FROM tblSubscribersStatus").Tables[0];
            fields = "title,order_id".Split(',');

            foreach (DataRow row in dtSource.Rows)
            {
                sel = dtTarget.Select("id=" + row["id"].ToString());
                if (sel.Length == 0)
                {
                    txtRep.Text += "MISSING ROW AT tblSubscribersStatus: id=" + row["id"].ToString() + ", title=" + row["title"].ToString() + "\r\n";
                }
                else if (sel.Length == 1)
                {
                    diff = GetRowsDiff(row, sel[0], fields);
                    if (diff.Length > 0)
                    {
                        txtRep.Text += "DIFF ROW VALUE AT tblSubscribersStatus: id=" + row["id"].ToString() + "  [" + diff + "]\r\n";
                    }
                }
            }
            foreach (DataRow row in dtTarget.Rows)
            {
                sel = dtSource.Select("id=" + row["id"].ToString());
                if (sel.Length == 0)
                {
                    txtRep.Text += "EXTRA ROW AT tblSubscribersStatus: id=" + row["id"].ToString() + ", title=" + row["title"].ToString() + "\r\n";
                }
            }


            #endregion

            if (txtRep.Text.Length == 0)
            {
                MessageBox.Show("Database data are identical", "Compare...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (script.Length > 0)
                {
                    var f = new frmNotepad(script);
                    f.Show();
                }
            }
        }

        private string GetRowsDiff(DataRow srcRow, DataRow destRow, string[] fields)
        {
            var diff = string.Empty;
            string strSrc, strTar;
            foreach (var fld in fields)
            {
                strSrc = srcRow[fld].ToString();
                strTar = destRow[fld].ToString();
                if (strSrc.Length == 0) strSrc = "[Null]";
                if (strTar.Length == 0) strTar = "[Null]";
                if (strSrc.Length > 15) strSrc = strSrc.Substring(0, 12) + "...";
                if (strTar.Length > 15) strTar = strTar.Substring(0, 12) + "...";
                if (!(srcRow[fld].ToString() == destRow[fld].ToString())) diff = fld + ":" + strSrc + "-->" + strTar + ", ";
            }
            if (diff.Length > 2) diff = diff.Substring(0, diff.Length - 2);
            return diff.Trim();
        }

    }
}