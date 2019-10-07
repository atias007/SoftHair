using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Reporting.WinForms;
using System.IO;

namespace ClientManage.Library
{
    // According to: http://msdn.microsoft.com/en-us/library/ms155397.aspx

    public enum ReportRenderFormat { Pdf, Image, Excel, Csv, Html, MHtml, Xml, Word}

    public class LocalReportRenderer
    {
        private readonly LocalReport _report;

        public LocalReportRenderer(LocalReport report)
        {
            _report = report;
        }

        public ReportRenderResult Render(ReportRenderFormat format)
        {
            return this.Render(format, null);
        }

        public ReportRenderResult Render(ReportRenderFormat format, DeviceInfoBase deviceInfo)
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;
            var info = (deviceInfo == null ? null : deviceInfo.GetXml());

            var bytes = _report.Render(format.ToString(), info, out mimeType, out encoding, out extension, out streamids, out warnings);
            return new ReportRenderResult(bytes, warnings);
        }
    }

    public class DeviceInfoBase
    {
        private readonly Dictionary<string, string> dict = new Dictionary<string, string>();

        protected void PropertyChanged(string name, string value)
        {
            if (dict.ContainsKey(name))
            {
                dict[name] = value;
            }
            else
            {
                dict.Add(name, value);
            }
        }

        public string GetXml()
        {
            string value = null;
            if (dict.Count > 0)
            {
                var xml = @"<DeviceInfo>{0}</DeviceInfo>";
                var innerPattern = @"<{0}>{1}</{0}>";
                var innerXml = string.Empty;
                foreach (var item in dict)
                {
                    innerXml += string.Format(innerPattern, item.Key, item.Value);
                }
                value = string.Format(xml, innerXml);
            }
            return value;
        }
    }

    public class ExcelDeviceInfo : DeviceInfoBase
    {
        /// <summary>
        /// Indicates whether to omit the document map for reports that support it. 
        /// The default value is false.
        /// </summary>
        private bool _omitDocumentMap;
        public bool OmitDocumentMap
        {
            get { return _omitDocumentMap; }
            set 
            { 
                _omitDocumentMap = value;
                PropertyChanged("OmitDocumentMap", value.ToString());
            }
        }

        /// <summary>
        /// Indicates whether to omit formulas from the rendered report. 
        /// The default value is false.
        /// </summary>
        private bool _omitFormulas;
        public bool OmitFormulas
        {
            get { return _omitFormulas; }
            set 
            { 
                _omitFormulas = value;
                PropertyChanged("OmitFormulas", value.ToString());
            }
        }

        /// <summary>
        /// Indicates whether to omit rows or columns that do not contain data and are smaller than the given size. 
        /// Use this setting to remove extra rows or columns that do not contain report items. 
        /// You must include an integer or decimal value followed by "in" (for example, 0.5in). 
        /// The default value is 0.125in.
        /// </summary>
        private decimal _removeSpace;
        public decimal RemoveSpace
        {
            get { return _removeSpace; }
            set 
            { 
                _removeSpace = value;
                PropertyChanged("RemoveSpace", value.ToString("N4") + "in");
            }
        }

        /// <summary>
        /// ndicates whether the page header of the report is rendered to the Excel page header. 
        /// A value of false indicates that the page header is rendered to the first row of the worksheet. 
        /// The default value is false.
        /// </summary>
        private bool _simplePageHeaders;
        public bool SimplePageHeaders
        {
            get { return _simplePageHeaders; }
            set 
            { 
                _simplePageHeaders = value;
                PropertyChanged("SimplePageHeaders", value.ToString());
            }
        }
    }

    public class PdfDeviceInfo : DeviceInfoBase
    {
        private int _columns;
        /// <summary>
        /// The number of columns to set for the report. This value overrides the report's original settings.
        /// </summary>
        public int Columns
        {
            get { return _columns; }
            set 
            { 
                _columns = value;
                PropertyChanged("Columns", value.ToString());
            }
        }

        private decimal _columnSpacing;
        /// <summary>
        /// The column spacing to set for the report. This value overrides the report's original settings.
        /// </summary>
        public decimal ColumnSpacing
        {
            get { return _columnSpacing; }
            set 
            { 
                _columnSpacing = value;
                PropertyChanged("ColumnSpacing", value.ToString("N4"));
            }
        }

        private int _endPage;
        /// <summary>
        /// The last page of the report to render. The default value is the value for StartPage.
        /// </summary>
        public int EndPage
        {
            get { return _endPage; }
            set
            {
                _endPage = value;
                PropertyChanged("EndPage", value.ToString());
            }
        }

        private decimal _marginBottom;
        /// <summary>
        /// The bottom margin value, in inches, to set for the report. 
        /// You must include an integer or decimal value followed by "in" (for example, 1in). 
        /// This value overrides the report's original settings.
        /// </summary>
        public decimal MarginBottom
        {
            get { return _marginBottom; }
            set 
            { 
                _marginBottom = value;
                PropertyChanged("MarginBottom", value.ToString("N4") + "in");
            }
        }

        private decimal _marginLeft;
        /// <summary>
        /// The left margin value, in inches, to set for the report. 
        /// You must include an integer or decimal value followed by "in" (for example, 1in). 
        /// This value overrides the report's original settings.
        /// </summary>
        public decimal MarginLeft
        {
            get { return _marginLeft; }
            set 
            { 
                _marginLeft = value;
                PropertyChanged("MarginLeft", value.ToString("N4") + "in");
            }
        }

        private decimal _marginRight;
        /// <summary>
        /// The right margin value, in inches, to set for the report. 
        /// You must include an integer or decimal value followed by "in" (for example, 1in). 
        /// This value overrides the report's original settings.
        /// </summary>
        public decimal MarginRight
        {
            get { return _marginRight; }
            set 
            {
                _marginRight = value;
                PropertyChanged("MarginRight", value.ToString("N4") + "in");
            }
        }

        private decimal _marginTop;
        /// <summary>
        /// The top margin value, in inches, to set for the report. 
        /// You must include an integer or decimal value followed by "in" (for example, 1in). 
        /// This value overrides the report's original settings.
        /// </summary>
        public decimal MarginTop
        {
            get { return _marginTop; }
            set 
            {
                _marginTop = value;
                PropertyChanged("MarginTop", value.ToString("N4") + "in");
            }
        }

        private decimal _pageHeight;
        /// <summary>
        /// The page height, in inches, to set for the report. 
        /// You must include an integer or decimal value followed by "in" (for example, 11in). 
        /// This value overrides the report's original settings.
        /// </summary>
        public decimal PageHeight
        {
            get { return _pageHeight; }
            set 
            {
                _pageHeight = value;
                PropertyChanged("PageHeight", value.ToString("N4") + "in");
            }
        }

        private decimal _pageWidth;
        /// <summary>
        /// The page width, in inches, to set for the report. 
        /// You must include an integer or decimal value followed by "in" (for example, 8.5in). 
        /// This value overrides the report's original settings.
        /// </summary>
        public decimal PageWidth
        {
            get { return _pageWidth; }
            set 
            { 
                _pageWidth = value;
                PropertyChanged("PageWidth", value.ToString("N4") + "in");
            }
        }

        private int _startPage;
        /// <summary>
        /// The first page of the report to render. 
        /// A value of 0 indicates that all pages are rendered. The default value is 1.
        /// </summary>
        public int StartPage
        {
            get { return _startPage; }
            set 
            {
                _startPage = value;
                PropertyChanged("StartPage", value.ToString());
            }
        }
    }

    public class CsvDeviceInfo : DeviceInfoBase
    {
        public enum CsvDeviceEncoding { ASCII, UTF_7, UTF_8, Unicode };
        private CsvDeviceEncoding _encoding = CsvDeviceEncoding.UTF_8;
        /// <summary>
        /// One of the character encoding schemas: ASCII, UTF-7, UTF-8, or Unicode. The default value is UTF-8.
        /// </summary>
        public CsvDeviceEncoding Encoding
        {
            get { return _encoding; }
            set 
            { 
                _encoding = value;
                PropertyChanged("Encoding", value.ToString().Replace("_", "-"));
            }
        }

        private bool _excelMode;
        /// <summary>
        /// Specifies that the target output is for Excel. The default value is true.
        /// </summary>
        public bool ExcelMode
        {
            get { return _excelMode; }
            set 
            {
                _excelMode = value;
                PropertyChanged("ExcelMode", value.ToString());
            }
        }

        private string _fieldDelimiter;
        /// <summary>
        /// The delimiter string to put in the result. The default value is a comma (,). 
        /// You should URL encode the value of this device information when passing it on a URL. 
        /// For example, a tab character as a delimiter should be "%09"
        /// </summary>
        public string FieldDelimiter
        {
            get { return _fieldDelimiter; }
            set
            {
                _fieldDelimiter = value;
                PropertyChanged("FieldDelimiter", value.ToString());
            }
        }

        private string _fileExtension;
        /// <summary>
        /// The file extension to put on the result. The default value is .CSV. 
        /// If both FileExtension and Extension are specified then FileExtension will take precedence.
        /// </summary>
        public string FileExtension
        {
            get { return _fileExtension; }
            set
            {
                _fileExtension = value;
                PropertyChanged("FileExtension", value.ToString());
            }
        }

        private bool _noHeader;
        /// <summary>
        /// Indicates whether the header row is excluded from the output. The default value is false.
        /// </summary>
        public bool NoHeader
        {
            get { return _noHeader; }
            set
            {
                _noHeader = value;
                PropertyChanged("NoHeader", value.ToString());
            }
        }

        private string _qualifier;
        /// <summary>
        /// The qualifier string to put around results that contain the field delimiter or record delimiter. 
        /// If the results contain the qualifier, the qualifier is repeated. 
        /// The Qualifier setting must be different from the FieldDelimiter and RecordDelimiter settings. 
        /// The default value is a quotation mark (").
        /// </summary>
        public string Qualifier
        {
            get { return _qualifier; }
            set
            {
                _qualifier = value;
                PropertyChanged("Qualifier", value.ToString());
            }
        }

        private string _recordDelimiter;
        /// <summary>
        /// The record delimiter to put at the end of each record. The default value is <cr><lf>.
        /// </summary>
        public string RecordDelimiter
        {
            get { return _recordDelimiter; }
            set
            {
                _recordDelimiter = value;
                PropertyChanged("RecordDelimiter", value.ToString());
            }
        }

        private bool _suppressLineBreaks;
        /// <summary>
        /// Indicates whether line breaks are removed from the data included in the output. 
        /// The default value is false. If the value is true, the FieldDelimiter, RecordDelimiter, 
        /// and Qualifier settings cannot be a space character.
        /// </summary>
        public bool SuppressLineBreaks
        {
            get { return _suppressLineBreaks; }
            set
            {
                _suppressLineBreaks = value;
                PropertyChanged("SuppressLineBreaks", value.ToString());
            }
        }

        private bool _useFormattedValues;
        /// <summary>
        /// Indicates whether formatted strings are put into the CSV output. 
        /// The default value is true when ExcelMode is true; otherwise it is false.
        /// </summary>
        public bool UseFormattedValues
        {
            get { return _useFormattedValues; }
            set
            {
                _useFormattedValues = value;
                PropertyChanged("UseFormattedValues", value.ToString());
            }
        }
    }

    public class HtmlDeviceInfo : DeviceInfoBase
    {
        private string _bookmarkID;
        /// <summary>
        /// The bookmark ID to jump to in the report.
        /// </summary>
        public string BookmarkID
        {
            get { return _bookmarkID; }
            set 
            { 
                _bookmarkID = value;
                PropertyChanged("BookmarkID", value.ToString());
            }
        }

        private bool _docMap;
        /// <summary>
        /// Indicates whether to show or hide the report document map. The default value of this parameter is true.
        /// </summary>
        public bool DocMap
        {
            get { return _docMap; }
            set
            {
                _docMap = value;
                PropertyChanged("DocMap", value.ToString());
            }
        }

        private bool _expandContent;
        /// <summary>
        /// Indicates whether the report should be enclosed in a table structure which constricts horizontal size.
        /// </summary>
        public bool ExpandContent
        {
            get { return _expandContent; }
            set
            {
                _expandContent = value;
                PropertyChanged("ExpandContent", value.ToString());
            }
        }

        private sbyte _findString;
        /// <summary>
        /// The text to search for in the report. The default value of this parameter is an empty string.
        /// </summary>
        public sbyte FindString
        {
            get { return _findString; }
            set
            {
                _findString = value;
                PropertyChanged("FindString", value.ToString());
            }
        }

        private bool _getImage;
        /// <summary>
        /// Gets a particular icon for the HTML Viewer user interface.
        /// </summary>
        public bool GetImage
        {
            get { return _getImage; }
            set
            {
                _getImage = value;
                PropertyChanged("GetImage", value.ToString());
            }
        }

        private bool _htmlFragment;
        /// <summary>
        /// ndicates whether an HTML fragment is created in place of a full HTML document. 
        /// An HTML fragment includes the report content in a TABLE element and omits the HTML and BODY elements. 
        /// The default value is false
        /// </summary>
        public bool HtmlFragment
        {
            get { return _htmlFragment; }
            set
            {
                _htmlFragment = value;
                PropertyChanged("HTMLFragment", value.ToString());
            }
        }

        private bool _javaScript;
        /// <summary>
        /// Indicates whether JavaScript is supported in the rendered report. The default value is true.
        /// </summary>
        public bool JavaScript
        {
            get { return _javaScript; }
            set
            {
                _javaScript = value;
                PropertyChanged("JavaScript", value.ToString());
            }
        }

        private string _linkTarget;
        /// <summary>
        /// The target for hyperlinks in the report. You can target a window or frame by providing the name of the window, 
        /// like LinkTarget=window_name, or you can target a new window using LinkTarget=_blank. 
        /// Other valid target names include _self, _parent, and _top.
        /// </summary>
        public string LinkTarget
        {
            get { return _linkTarget; }
            set
            {
                _linkTarget = value;
                PropertyChanged("LinkTarget", value.ToString());
            }
        }

        private bool _onlyVisibleStyles;
        /// <summary>
        /// Indicates that only shared styles for currently rendered page are generated.
        /// </summary>
        public bool OnlyVisibleStyles
        {
            get { return _onlyVisibleStyles; }
            set
            {
                _onlyVisibleStyles = value;
                PropertyChanged("OnlyVisibleStyles", value.ToString());
            }
        }

        private bool _parameters;
        /// <summary>
        /// Indicates whether to show or hide the parameters area of the toolbar. 
        /// If you set this parameter to a value of true, the parameters area of the toolbar is displayed. 
        /// The default value of this parameter is true.
        /// </summary>
        public bool Parameters
        {
            get { return _parameters; }
            set
            {
                _parameters = value;
                PropertyChanged("Parameters", value.ToString());
            }
        }

        private int _section;
        /// <summary>
        /// The page number of the report to render. A value of 0 indicates that all sections of the report are rendered. 
        /// The default value is 1.
        /// </summary>
        public int Section
        {
            get { return _section; }
            set
            {
                _section = value;
                PropertyChanged("Section", value.ToString());
            }
        }

        private string _streamRoot;
        /// <summary>
        /// The path used for prefixing the value of the src attribute of the IMG element in the HTML report 
        /// returned by the report server. By default, the report server provides the path. 
        /// You can use this setting to specify a root path for the images in a report 
        /// </summary>
        public string StreamRoot
        {
            get { return _streamRoot; }
            set
            {
                _streamRoot = value;
                PropertyChanged("StreamRoot", value.ToString());
            }
        }

        private bool _styleStream;
        /// <summary>
        /// Indicates whether styles and scripts are created as a separate stream instead of in the document.
        /// The default value is false.
        /// </summary>
        public bool StyleStream
        {
            get { return _styleStream; }
            set
            {
                _styleStream = value;
                PropertyChanged("StyleStream", value.ToString());
            }
        }

        private bool _toolbar = true;
        /// <summary>
        /// Indicates whether to show or hide the toolbar. The default of this parameter is true. 
        /// If the value of this parameter is false, all remaining options (except the document map) are ignored. 
        /// If you omit this parameter, the toolbar is automatically displayed for rendering formats that support it.
        /// </summary>
        public bool Toolbar
        {
            get { return _toolbar; }
            set
            {
                _toolbar = value;
                PropertyChanged("Toolbar", value.ToString());
            }
        }

        private int _zoom;
        /// <summary>
        /// The report zoom value as an integer percentage or a string constant. 
        /// Standard string values include Page Width and Whole Page. This parameter is ignored by versions of 
        /// Microsoft Internet Explorer earlier than Internet Explorer 5.0 and all non-Microsoft browsers. 
        /// The default value of this parameter is 100.
        /// </summary>
        public int Zoom
        {
            get { return _zoom; }
            set
            {
                _zoom = value;
                PropertyChanged("Zoom", value.ToString());
            }
        }
    }

    public class MHtmlDeviceInfo : DeviceInfoBase
    {
        private bool _javaScript;
        /// <summary>
        /// Indicates whether JavaScript is supported in the rendered report.
        /// </summary>
        public bool JavaScript
        {
            get { return _javaScript; }
            set 
            { 
                _javaScript = value;
                PropertyChanged("JavaScript", value.ToString());
            }
        }

        private bool _MHtmlFragment;
        /// <summary>
        /// Indicates whether an MHTML fragment is created in place of a full MHTML document. 
        /// An MHTML fragment includes the report content in a TABLE element and omits the HTML and BODY elements. 
        /// The default value is false.
        /// </summary>
        public bool MHtmlFragment
        {
            get { return _MHtmlFragment; }
            set 
            { 
                _MHtmlFragment = value;
                PropertyChanged("MHTML Fragment", value.ToString());
            }
        }
    }

    public class WordDeviceInfo : DeviceInfoBase
    {
        public enum AutoFitType { False, True, Never, Default };

        private AutoFitType _autoFit;
        /// <summary>
        /// False. AutoFit is set to false set on any Word table.
        /// True. AutoFit is set to true on every Word table. 
        /// Never. AutoFit values are not set on any Word table and behavior reverts to the Word default. 
        /// Default. AutoFit is set on tables that are narrower than the physical drawing area (physical page width excluding margins) per logical page.
        /// </summary>
        public AutoFitType AutoFit
        {
            get { return _autoFit; }
            set 
            { 
                _autoFit = value;
                PropertyChanged("AutoFit", value.ToString());
            }
        }

        private bool _expandToggles;
        /// <summary>
        /// Indicates whether all items that can be toggled should render in their fully-expanded state. The default value is false.
        /// </summary>
        public bool ExpandToggles
        {
            get { return _expandToggles; }
            set
            {
                _expandToggles = value;
                PropertyChanged("ExpandToggles", value.ToString());
            }
        }

        private bool _fixedPageWidth;
        /// <summary>
        /// Indicates whether the Page Width written to the DOC file will grow to accommodate the width of the largest page in the Report Body. The default value is false.
        /// </summary>
        public bool FixedPageWidth
        {
            get { return _fixedPageWidth; }
            set
            {
                _fixedPageWidth = value;
                PropertyChanged("FixedPageWidth", value.ToString());
            }
        }

        private bool _omitHyperlinks;
        /// <summary>
        /// Indicates whether to omit the Hyperlink action on all items where it is set. The default value is false
        /// </summary>
        public bool OmitHyperlinks
        {
            get { return _omitHyperlinks; }
            set
            {
                _omitHyperlinks = value;
                PropertyChanged("OmitHyperlinks", value.ToString());
            }
        }

        private bool _omitDrillthroughs;
        /// <summary>
        /// Indicates whether to omit the Drillthrough action on all items where it is set. The default value is false
        /// </summary>
        public bool OmitDrillthroughs
        {
            get { return _omitDrillthroughs; }
            set
            {
                _omitDrillthroughs = value;
                PropertyChanged("OmitDrillthroughs", value.ToString());
            }
        }
    }

    public class ImageDeviceInfo : DeviceInfoBase
    {
        public enum ColorDepthType { Bit1, Bit4, Bit8, Bit24, Bit32 }
        public enum OutputFormatType { BMP, EMF, GIF, JPEG, PNG, TIFF }

        private ColorDepthType _colorDepth;
        /// <summary>
        /// The pixel depth of the color range supported by the image output. Valid values are 1, 4, 8, 24, and 32. 
        /// The default value is 24. ColorDepth is only supported for TIFF rendering and is otherwise ignored by 
        /// the report server for other image output formats. 
        /// </summary>
        public ColorDepthType ColorDepth
        {
            get { return _colorDepth; }
            set 
            { 
                _colorDepth = value;
                PropertyChanged("ColorDepth", value.ToString().Substring(3));
            }
        }

        private int _columns;
        /// <summary>
        /// The number of columns to set for the report. This value overrides the report's original settings.
        /// </summary>
        public int Columns
        {
            get { return _columns; }
            set 
            { 
                _columns = value;
                PropertyChanged("Columns", value.ToString());
            }
        }

        private int _columnSpacing;
        /// <summary>
        /// The column spacing to set for the report. This value overrides the report's original settings.
        /// </summary>
        public int ColumnSpacing
        {
            get { return _columnSpacing; }
            set 
            { 
                _columnSpacing = value;
                PropertyChanged("ColumnSpacing", value.ToString());
            }
        }

        private int _dpiX;
        /// <summary>
        /// The resolution of the output device in x-direction. The default value is 96.
        /// </summary>
        public int DpiX
        {
            get { return _dpiX; }
            set 
            { 
                _dpiX = value;
                PropertyChanged("DpiX", value.ToString());
            }
        }

        private int _dpiY;
        /// <summary>
        /// The resolution of the output device in y-direction. The default value is 96.
        /// </summary>
        public int DpiY
        {
            get { return _dpiY; }
            set 
            { 
                _dpiY = value;
                PropertyChanged("DpiY", value.ToString());
            }
        }

        private int _endPage;
        /// <summary>
        /// The last page of the report to render. The default value is the value for StartPage.
        /// </summary>
        public int EndPage
        {
            get { return _endPage; }
            set 
            { 
                _endPage = value;
                PropertyChanged("EndPage", value.ToString());
            }
        }

        private decimal _marginBottom;
        /// <summary>
        /// The bottom margin value, in inches, to set for the report. 
        /// You must include an integer or decimal value followed by "in" (for example, 1in). 
        /// This value overrides the report's original settings.
        /// </summary>
        public decimal MarginBottom
        {
            get { return _marginBottom; }
            set 
            { 
                _marginBottom = value;
                PropertyChanged("MarginBottom", value.ToString("N4") + "in");
            }
        }

        private decimal _marginLeft;
        /// <summary>
        /// The left margin value, in inches, to set for the report. 
        /// You must include an integer or decimal value followed by "in" (for example, 1in). 
        /// This value overrides the report's original settings.
        /// </summary>
        public decimal MarginLeft
        {
            get { return _marginLeft; }
            set
            {
                _marginLeft = value;
                PropertyChanged("MarginLeft", value.ToString("N4") + "in");
            }
        }

        private decimal _marginRight;
        /// <summary>
        /// The right margin value, in inches, to set for the report. 
        /// You must include an integer or decimal value followed by "in" (for example, 1in). 
        /// This value overrides the report's original settings.
        /// </summary>
        public decimal MarginRight
        {
            get { return _marginRight; }
            set 
            {
                _marginRight = value;
                PropertyChanged("MarginRight", value.ToString("N4") + "in");
            }
        }

        private decimal _marginTop;
        /// <summary>
        /// The top margin value, in inches, to set for the report. 
        /// You must include an integer or decimal value followed by "in" (for example, 1in). 
        /// This value overrides the report's original settings.
        /// </summary>
        public decimal MarginTop
        {
            get { return _marginTop; }
            set
            {
                _marginTop = value;
                PropertyChanged("MarginTop", value.ToString("N4") + "in");
            }
        }

        private decimal _pageHeight;
        /// <summary>
        /// The page height, in inches, to set for the report. 
        /// You must include an integer or decimal value followed by "in" (for example, 11in). 
        /// This value overrides the report's original settings.
        /// </summary>
        public decimal PageHeight
        {
            get { return _pageHeight; }
            set 
            { 
                _pageHeight = value;
                PropertyChanged("_pageHeight", value.ToString("N4") + "in");
            }
        }

        private OutputFormatType _outputFormat;
        /// <summary>
        /// One of the Graphics Device Interface (GDI) supported output formats: BMP, EMF, GIF, JPEG, PNG, or TIFF.
        /// </summary>
        public OutputFormatType OutputFormat
        {
            get { return _outputFormat; }
            set 
            { 
                _outputFormat = value;
                PropertyChanged("OutputFormat", value.ToString());
            }
        }
	
        private decimal _pageWidth;
        /// <summary>
        /// The page width, in inches, to set for the report. 
        /// You must include an integer or decimal value followed by "in" (for example, 8.5in). 
        /// This value overrides the report's original settings.
        /// </summary>
        public decimal PageWidth
        {
            get { return _pageWidth; }
            set 
            { 
                _pageWidth = value;
                PropertyChanged("PageWidth", value.ToString("N4") + "in");
            }
        }

        private int _startPage;
        /// <summary>
        /// The first page of the report to render. 
        /// A value of 0 indicates that all pages are rendered. The default value is 1.
        /// </summary>
        public int StartPage
        {
            get { return _startPage; }
            set 
            { 
                _startPage = value;
                PropertyChanged("StartPage", value.ToString());
            }
        }
    }

    public class ReportRenderResult
    {
        private readonly byte[] _bytes;
        private readonly Warning[] _warnings;

        internal ReportRenderResult(byte[] bytes, Warning[] warnings)
        {
            _bytes = bytes;
            _warnings = warnings;
        }

        public byte[] Result
        {
            get { return _bytes; }
        }

        public Warning[] Warnings
        {
            get { return _warnings; }
        }

        public void Save(string filename)
        {
            var fs = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite);
            fs.Write(_bytes, 0, _bytes.Length);
            fs.Close();
        }
    }
}
