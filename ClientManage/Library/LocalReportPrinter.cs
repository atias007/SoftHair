using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Collections.Generic;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;
using System.Drawing;


namespace ClientManage.Library
{
    public class LocalReportPrinter : IDisposable
    {
        #region Private Members

        private int _currentPageIndex;
        private IList<Stream> _streams;
        private PrinterSettings _printerSettings;
        private Padding _margins = new Padding(0);

        #endregion

        #region Public Methods

        public void Print(LocalReport report, string printerName)
        {
            var ps = new PrinterSettings();
            ps.PrinterName = printerName;
            if (!ps.IsValid) throw new ArgumentException("Printer " + printerName + "does not exist", "printerName");
            Print(report, printerName);
        }

        public void Print(LocalReport report, PrinterSettings printerSettings)
        {
            _printerSettings = printerSettings;
            Render(report);

            _currentPageIndex = 0;
            PrintPage();
        }

        public void Dispose()
        {
            if (_streams != null)
            {
                foreach (var stream in _streams)
                {
                    stream.Close();
                }
                _streams = null;
            }
        }

        #endregion

        #region Private Functions

        private void Render(LocalReport report)
        {
            var deviceInfo = new ImageDeviceInfo();
            var reportSetting = report.GetDefaultPageSettings();
            var margins = reportSetting.Margins;
            var paperSize = reportSetting.PaperSize;

            
            deviceInfo.OutputFormat = ImageDeviceInfo.OutputFormatType.EMF;
            deviceInfo.PageWidth = paperSize.Width / 100.0M;
            deviceInfo.PageHeight = paperSize.Height / 100.0M;
            deviceInfo.MarginTop = margins.Top / 100.0M;
            deviceInfo.MarginLeft = margins.Left / 100.0M;
            deviceInfo.MarginRight = margins.Right / 100.0M;
            deviceInfo.MarginBottom = margins.Bottom / 100.0M;

            Warning[] warnings;
            _streams = new List<Stream>();
            report.Render("Image", deviceInfo.GetXml(), CreateStream, out warnings);

            foreach (var stream in _streams)
            {
                stream.Position = 0;
            }
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            var pageImage = new Metafile(_streams[_currentPageIndex]);

            e.Graphics.DrawImage(pageImage, 0, 0, _printerSettings.DefaultPageSettings.PrintableArea.Width, _printerSettings.DefaultPageSettings.PrintableArea.Height);

            _currentPageIndex++;
            e.HasMorePages = (_currentPageIndex < _streams.Count);
        }

        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            //Stream stream = new FileStream(name + "." + fileNameExtension, FileMode.Create);
            Stream stream = new MemoryStream();
            _streams.Add(stream);
            return stream;
        }

        private void PrintPage()
        {
            if (_streams == null || _streams.Count == 0) return;

            var printDoc = new PrintDocument();
            printDoc.PrinterSettings = _printerSettings;

            if (!printDoc.PrinterSettings.IsValid)
            {
                var msg = String.Format("Can't find printer \"{0}\".", printDoc.PrinterSettings.PrinterName);
                throw new Exception(msg);
            }
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            printDoc.QueryPageSettings += new QueryPageSettingsEventHandler(printDoc_QueryPageSettings);

            printDoc.Print();
        }

        #endregion

        #region Private Event Procedures

        void printDoc_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
        {
            e.PageSettings.PrinterSettings = _printerSettings;
        }

        #endregion
    }
}