using System;
using System.Text;
using System.IO;

namespace ClientManage.BL.Library
{
    public class StickersReportGenerator
    {
        public StickersReportGenerator()
        {

        }

        public StickersReportGenerator(string settings)
        {
            var s = settings.Split(',');

            Columns = Convert.ToInt32(s[0]);
            Rows = Convert.ToInt32(s[1]);
            PageWidth = Convert.ToDecimal(s[2]);
            PageHeight = Convert.ToDecimal(s[3]);
            TopMargin = Convert.ToDecimal(s[4]);
            BottomMargin = Convert.ToDecimal(s[5]);
            RightMargin = Convert.ToDecimal(s[6]);
            LeftMargin = Convert.ToDecimal(s[7]);
            FontSize = Convert.ToInt32(s[8]);
            StickerBorderStyle = Convert.ToBoolean(s[9]) ? BorderStyle.Solid : BorderStyle.None;
            PrinterName = s[10];
        }

        public enum BorderStyle { None, Solid }

        public decimal InteractiveHeight
        {
            get
            {
                return PageHeight - TopMargin - BottomMargin;
            }
        }
        public decimal InteractiveWidth
        {
            get
            {
                return PageWidth - RightMargin - LeftMargin;
            }
        }
        public decimal RightMargin { get; set; }
        public decimal LeftMargin { get; set; }
        public decimal TopMargin { get; set; }
        public decimal BottomMargin { get; set; }
        public decimal PageWidth { get; set; }
        public decimal PageHeight { get; set; }
        public int Columns { get; set; }
        public int Rows { get; set; }
        public int FontSize { get; set; }
        public decimal Width
        {
            get
            {
                return (Math.Truncate(100 * InteractiveWidth / Convert.ToDecimal(Columns)) / 100) - 0.01M;
            }
        }
        public decimal Height
        {
            get
            {
                return (Math.Truncate(100 * InteractiveHeight / Convert.ToDecimal(Rows)) / 100) - 0.01M;
            }
        }
        public string PrinterName { get; set; }
        public BorderStyle StickerBorderStyle { get; set; }

        private static string GetResource(string filename, string assemblyNamespace)
        {
            var asm = System.Reflection.Assembly.GetExecutingAssembly();

            //' resources are named using a fully qualified name
            var strm = asm.GetManifestResourceStream(assemblyNamespace + "." + filename);

            //' read the contents of the embedded file
            if (strm == null) return null;
            var reader = new StreamReader(strm, Encoding.Default);
            var val = reader.ReadToEnd();
            reader.Close();

            return val;
        }

        public Stream GetReportDefinition()
        {
            Stream stream = new MemoryStream(Encoding.Default.GetBytes(this.ToString()));
            return stream;
        }

        public override string ToString()
        {
            var xml = GetResource("Report.xml", this.GetType().Namespace);
            var fontSize = 8 + ((this.FontSize < 0 ? 1 : this.FontSize) * 2);

            xml = xml.Replace("{InteractiveHeight}", this.InteractiveHeight.ToString("N4") + "cm");
            xml = xml.Replace("{InteractiveWidth}", this.InteractiveWidth.ToString("N4") + "cm");
            xml = xml.Replace("{RightMargin}", this.RightMargin.ToString("N4") + "cm");
            xml = xml.Replace("{LeftMargin}", this.LeftMargin.ToString("N4") + "cm");
            xml = xml.Replace("{TopMargin}", this.TopMargin.ToString("N4") + "cm");
            xml = xml.Replace("{BottomMargin}", this.BottomMargin.ToString("N4") + "cm");
            xml = xml.Replace("{PageWidth}", this.PageWidth.ToString("N4") + "cm");
            xml = xml.Replace("{PageHeight}", this.PageHeight.ToString("N4") + "cm");
            xml = xml.Replace("{Columns}", this.Columns.ToString());
            xml = xml.Replace("{Width}", this.Width.ToString("N4") + "cm");
            xml = xml.Replace("{Height}", this.Height.ToString("N4") + "cm");
            xml = xml.Replace("{StickerBorderStyle}", this.StickerBorderStyle.ToString());
            xml = xml.Replace("{FontSize}", fontSize + "pt");

            return xml;
        }
    }
}
