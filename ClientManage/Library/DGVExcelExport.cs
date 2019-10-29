using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.IO;
using ClientManage.BL.Library;

namespace ClientManage.Library
{
    public class DGVExcelExport
    {
        public static void ExportToExcel(DataGridView grid, string fileName)
        {
            StreamWriter writer;
            var line = string.Empty;

            try
            {
                writer = new StreamWriter(fileName, false, Encoding.Default);
            }
            catch (Exception ex)
            {
                EventLogManager.AddErrorMessage("Error creating export file", ex);
                return;
            }

            foreach (DataGridViewColumn col in grid.Columns)
            {
                if (col.Visible)
                {
                    line += col.HeaderText.Replace(",", string.Empty) + ",";
                }
            }
            if (line.EndsWith(",")) line = line.Substring(0, line.Length - 1);
            line += "\r\n";
            writer.Write(line);

            foreach (DataGridViewRow row in grid.Rows)
            {
                line = string.Empty;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Visible)
                    {
                        line += DBNull.Value.Equals(cell.FormattedValue) ? string.Empty : Convert.ToString(cell.FormattedValue).Replace(",", string.Empty) + ",";
                    }
                }
                if (line.EndsWith(",")) line = line.Substring(0, line.Length - 1);
                line += "\r\n"; writer.Write(line);
            }

            writer.Close();
        }
    }
}