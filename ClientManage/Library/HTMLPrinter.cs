using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using ClientManage.BL;
using ClientManage.Interfaces;
using System.IO;
using ClientManage.BL.Library;

namespace ClientManage.Library
{
    public class HtmlPrinter
    {
        private WebBrowser _browser = null;

        public HtmlPrinter(string key, string[] parameters)
        {
            CreateReport(key, parameters);
        }

        private WebBrowser browser
        {
            get
            {
                if (_browser == null || _browser.IsDisposed)
                {
                    _browser = new WebBrowser();
                    _browser.Dock = DockStyle.None;
                    _browser.Size = new System.Drawing.Size(1024, 768);
                }
                return _browser;
            }
            set { _browser = value; }
        }

        public static string ConvertDataGridToHtml(DataGridView grid)
        {
            return ConvertDataGridToHtml(grid, null, false);
        }

        public static string ConvertDataGridToHtml(DataGridView grid, bool onlySelected)
        {
            return ConvertDataGridToHtml(grid, null, onlySelected);
        }

        public static string ConvertDataGridToHtml(DataGridView grid, HtmlImageColumnsCollection imageColumns)
        {
            return ConvertDataGridToHtml(grid, imageColumns, false);
        }

        public static string ConvertDataGridToHtml(DataGridView grid, HtmlImageColumnsCollection imageColumns, bool onlySelected)
        {
            var sb = new StringBuilder();
            var isFilter = onlySelected && grid.Columns.Contains("clmSelect");
            string filename;
            var htmlImageRow = "\t\t<td style=\"width:{0}px;text-align:center;\"><img alt=\"\" width=\"{1}\" height=\"{2}\" src=\"{3}\"></td>\n";
            var htmlTextRow = "\t\t<td{0}>{1}</td>\n";
            sb.Append("<table border=\"1\">\n");

            // Header
            sb.Append("\t<tr>\n");
            for (var i = 0; i < grid.Columns.Count; i++)
            {
                if (grid.Columns[i].Visible)
                {
                    sb.Append("\t\t<th>" + grid.Columns[i].HeaderText.Replace("\n", "<br />") + "</th>\n");
                }
            }
            sb.Append("\t</tr>\n");

            // Body
            var id = Utils.GetDateTimeIdString();
            Image image = null;

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (isFilter && Utils.GetDBValue<bool>(row.Cells["clmSelect"].Value) == false) continue;
                sb.Append("\t<tr>\n");
                for (var i = 0; i < grid.Columns.Count; i++)
                {
                    if (grid.Columns[i].Visible)
                    {
                        if (grid.Columns[i] is DataGridViewImageColumn)
                        {
                            var map = GetImageMapper(imageColumns, grid.Columns[i].Name);
                            if (map != null)
                            {
                                filename = string.Empty;
                                if (map.MapType == HtmlImageColumnMapper.HtmlMapType.ByColumnRef)
                                {
                                    filename = Convert.ToString(row.Cells[map.ColumnRefName].Value.ToString());
                                    try { image = Image.FromFile(filename); }
                                    catch { filename = string.Empty; image = null; }
                                }
                                else if (map.MapType == HtmlImageColumnMapper.HtmlMapType.ByImageValue)
                                {
                                    filename = Utils.GetTempForderPath(id + "_" + row.Index.ToString());
                                    try
                                    {
                                        image = (System.Drawing.Image)row.Cells[i].FormattedValue;
                                        image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                                    }
                                    catch { filename = string.Empty; image = null; }
                                }
                                if (map.Layout == DataGridViewImageCellLayout.Stretch)
                                {
                                    sb.Append(string.Format(htmlImageRow, row.Cells[i].Size.Width, row.Cells[i].Size.Width, row.Cells[i].Size.Height, filename));
                                }
                                else
                                {
                                    sb.Append(string.Format(htmlImageRow, row.Cells[i].Size.Width, image.Width, image.Height, filename));
                                }
                            }
                        }
                        else
                        {
                            sb.Append(string.Format(htmlTextRow, GetStyleFromCell(row.Cells[i]), row.Cells[i].FormattedValue.ToString().Replace("\n", "<br />")));
                            //sb.Append("\t\t<td>" +  + "</td>\n");
                        }
                    }
                }
                sb.Append("\t</tr>\n");
            }

            sb.Append("</table>");

            return sb.ToString();
        }

        private static string GetStyleFromCell(DataGridViewCell cell)
        {
            //if (!cell.HasStyle) return string.Empty;
            var style = string.Empty;
            var cellStyle = cell.HasStyle ? cell.Style : cell.OwningColumn.DefaultCellStyle;

            #region Alignment

            switch (cellStyle.Alignment)
            {
                case DataGridViewContentAlignment.BottomCenter:
                    style += "text-align:center; vertical-align:bottom;";
                    break;

                case DataGridViewContentAlignment.BottomLeft:
                    style += "text-align:left; vertical-align:bottom;";
                    break;

                case DataGridViewContentAlignment.BottomRight:
                    style += "text-align:right; vertical-align:bottom;";
                    break;

                case DataGridViewContentAlignment.MiddleCenter:
                    style += "text-align:center; vertical-align:middle;";
                    break;

                case DataGridViewContentAlignment.MiddleLeft:
                    style += "text-align:left; vertical-align:middle;";
                    break;

                case DataGridViewContentAlignment.MiddleRight:
                    style += "text-align:right; vertical-align:middle;";
                    break;

                case DataGridViewContentAlignment.NotSet:
                    break;

                case DataGridViewContentAlignment.TopCenter:
                    style += "text-align:center; vertical-align:top;";
                    break;

                case DataGridViewContentAlignment.TopLeft:
                    style += "text-align:left; vertical-align:top;";
                    break;

                case DataGridViewContentAlignment.TopRight:
                    style += "text-align:right; vertical-align:top;";
                    break;
            }

            #endregion Alignment

            #region Color

            style += "color:" + ColorTranslator.ToHtml(cellStyle.ForeColor) + ";";

            #endregion Color

            if (style.Length > 0) style = " style=\"" + style + "\"";
            return style;
        }

        private string GetLogoFilename()
        {
            var filename = Path.Combine(General.StartupPath, "Media\\print_logo.jpg");
            if (!File.Exists(filename))
            {
                filename = Utils.GetTempForderPath("shlogo.jpg");
                try
                {
                    Properties.Resources.print_logo.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                catch (Exception ex)
                {
                    EventLogManager.AddErrorMessage("Error create logo file when pring", ex);
                    filename = string.Empty;
                }
            }
            return filename;
        }

        private void CreateReport(string key, string[] parameters)
        {
            var report = key.Length == 0 ? "{0}" : AppSettingsHelper.GetPrintTemplate(key);
            var html = AppSettingsHelper.GetPrintDefaultForm();
            if (report.Length > 0 && html.Length > 0)
            {
                var filename = GetLogoFilename();
                report = string.Format(report, parameters);
                html = html.Replace("{Form Body Here}", report);
                html = html.Replace("{Logo Here}", filename);

                System.Diagnostics.Debug.Print(html);

                browser.DocumentText = html;
                Application.DoEvents();
            }
        }

        public void ShowPageSetupDialog()
        {
            browser.ShowPageSetupDialog();
        }

        public void ShowPrintDialog()
        {
            browser.ShowPrintDialog();
        }

        public void ShowPrintPreviewDialog()
        {
            browser.ShowPrintPreviewDialog();
        }

        public void Print()
        {
            browser.Print();
        }

        private static HtmlImageColumnMapper GetImageMapper(HtmlImageColumnsCollection col, string columnName)
        {
            HtmlImageColumnMapper iColMap = null;
            if (col != null)
            {
                foreach (var map in col)
                {
                    if (map.ColumnName.Equals(columnName))
                    {
                        iColMap = map;
                        break;
                    }
                }
            }
            return iColMap;
        }
    }

    public class HtmlImageColumnMapper
    {
        public enum HtmlMapType { ByImageValue, ByColumnRef };

        //public enum

        private readonly HtmlMapType _mapType = HtmlMapType.ByColumnRef;
        private readonly string _columnName = string.Empty;
        private readonly string _columnRefName = string.Empty;
        private DataGridViewImageCellLayout _layout = DataGridViewImageCellLayout.Stretch;

        public HtmlImageColumnMapper(HtmlMapType mapType, string columnName)
        {
            _mapType = mapType;
            _columnName = columnName;
        }

        public HtmlImageColumnMapper(HtmlMapType mapType, string columnName, string columnRefName)
            : this(mapType, columnName)
        {
            _columnRefName = columnRefName;
        }

        public HtmlMapType MapType
        {
            get { return _mapType; }
        }

        public string ColumnName
        {
            get { return _columnName; }
        }

        public string ColumnRefName
        {
            get
            {
                return _columnRefName;
            }
        }

        public DataGridViewImageCellLayout Layout
        {
            get { return _layout; }
            set { _layout = value; }
        }
    }

    public class HtmlImageColumnsCollection : IList<HtmlImageColumnMapper>
    {
        private readonly List<HtmlImageColumnMapper> List = new List<HtmlImageColumnMapper>();

        #region IList<ImageColumnMapper> Members

        public int IndexOf(HtmlImageColumnMapper item)
        {
            return List.IndexOf(item);
        }

        public void Insert(int index, HtmlImageColumnMapper item)
        {
            List.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            List.RemoveAt(index);
        }

        public HtmlImageColumnMapper this[int index]
        {
            get
            {
                return List[index];
            }
            set
            {
                List[index] = value;
            }
        }

        #endregion IList<ImageColumnMapper> Members

        #region ICollection<ImageColumnMapper> Members

        public void Add(HtmlImageColumnMapper item)
        {
            List.Add(item);
        }

        public void Clear()
        {
            List.Clear();
        }

        public bool Contains(HtmlImageColumnMapper item)
        {
            return List.Contains(item);
        }

        public void CopyTo(HtmlImageColumnMapper[] array, int arrayIndex)
        {
            List.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return List.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(HtmlImageColumnMapper item)
        {
            return List.Remove(item);
        }

        #endregion ICollection<ImageColumnMapper> Members

        #region IEnumerable<ImageColumnMapper> Members

        public IEnumerator<HtmlImageColumnMapper> GetEnumerator()
        {
            return List.GetEnumerator();
        }

        #endregion IEnumerable<ImageColumnMapper> Members

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return List.GetEnumerator();
        }

        #endregion IEnumerable Members
    }
}