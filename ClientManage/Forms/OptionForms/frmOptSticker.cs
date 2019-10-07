using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.Management;
using ClientManage.Forms;
using ClientManage.Interfaces.Schemas;
using ClientManage.BL.Library;
using ClientManage.Library;

namespace ClientManage.Forms.OptionForms
{
    public partial class FormOptStickers : BaseMdiOptionForm
    {
        public override void LoadSettings()
        {
            var value = LoadSettingValue<string>("STICKERS_PRINT_SETUP");
            var gen = new StickersReportGenerator(value);
            LoadSettingsToScreen(gen);
        }

        public override void SaveSettings()
        {
            var value = GetSettingsFromScreen();
            SaveSettingValue("STICKERS_PRINT_SETUP", value);
        }

        #region Private Members

        private const float INCHES_TO_METER = 39.370079F;
        private MinimumMargins _minMargins = new MinimumMargins();

        public struct MinimumMargins
        {
            public decimal Left { get; set; }
            public decimal Right { get; set; }
            public decimal Top { get; set; }
            public decimal Bottom { get; set; }
        }

        #endregion Private Members

        #region Constructor

        public FormOptStickers()
        {
            InitializeComponent();

            foreach (var item in PrinterSettings.InstalledPrinters)
            {
                cmbPrinters.Items.Add(item);
            }
        }

        #endregion Constructor

        #region Private Functions

        private void LoadSettingsToScreen(StickersReportGenerator generator)
        {
            txtCountWidth.Value = generator.Columns;
            txtCountHeight.Value = generator.Rows;
            txtWidth.Value = generator.PageWidth;
            txtHeight.Value = generator.PageHeight;
            txtMarginUp.Value = generator.TopMargin;
            txtMarginDown.Value = generator.BottomMargin;
            txtMarginRight.Value = generator.RightMargin;
            txtMarginLeft.Value = generator.LeftMargin;
            cmbSize.SelectedIndex = cmbSize.FindString(generator.FontSize.ToString());
            chkBorder.Checked = (generator.StickerBorderStyle == StickersReportGenerator.BorderStyle.Solid);

            if (string.IsNullOrEmpty(generator.PrinterName) || cmbPrinters.FindString(generator.PrinterName) == -1)
            {
                var doc = new PrintDocument();
                generator.PrinterName = doc.PrinterSettings.PrinterName;
            }

            cmbPrinters.SelectedIndex = cmbPrinters.FindString(generator.PrinterName);
        }

        private string GetSettingsFromScreen()
        {
            var settings = string.Empty;

            settings = txtCountWidth.Value.ToString("N0") + "," +
                txtCountHeight.Value.ToString("N0") + "," +
                txtWidth.Value.ToString("N2") + "," +
                txtHeight.Value.ToString("N2") + "," +
                txtMarginUp.Value.ToString("N2") + "," +
                txtMarginDown.Value.ToString("N2") + "," +
                txtMarginRight.Value.ToString("N2") + "," +
                txtMarginLeft.Value.ToString("N2") + "," +
                cmbSize.Text + "," +
                chkBorder.Checked.ToString() + "," +
                cmbPrinters.Text;

            return settings;
        }

        private void ShowReport()
        {
            var generator = GetReportGenerator();
            var dataSource = GetReportDataSource();

            reportViewer1.Reset();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.LoadReportDefinition(generator.GetReportDefinition());
            reportViewer1.LocalReport.DataSources.Add(dataSource);
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.RefreshReport();
        }

        private PrinterSettings GetPrinterSettings()
        {
            var ps = new PrinterSettings();
            ps.PrinterName = cmbPrinters.Text;
            return ps;
        }

        private StickersReportGenerator GetReportGenerator()
        {
            var generator = new StickersReportGenerator();

            generator.RightMargin = txtMarginRight.Value;
            generator.LeftMargin = txtMarginLeft.Value;
            generator.TopMargin = txtMarginUp.Value;
            generator.BottomMargin = txtMarginDown.Value;
            generator.PageWidth = txtWidth.Value;
            generator.PageHeight = txtHeight.Value;
            generator.Columns = Convert.ToInt32(txtCountWidth.Value);
            generator.Rows = Convert.ToInt32(txtCountHeight.Value);
            generator.FontSize = cmbSize.SelectedIndex < 0 ? 1 : cmbSize.SelectedIndex + 1;
            generator.StickerBorderStyle = chkBorder.Checked ?
                StickersReportGenerator.BorderStyle.Solid :
                StickersReportGenerator.BorderStyle.None;

            return generator;
        }

        private ReportDataSource GetReportDataSource()
        {
            var ds = new dsStickers();
            for (var i = 0; i < Convert.ToInt32(txtCount.Value); i++)
            {
                ds.Addresses.AddAddressesRow("(" + (i + 1).ToString() + ") לכבוד ישראל ישראלי\nדרך השלום 20 דירה 10\nתל אביב יפו 12345");
            }
            var dataSource = new ReportDataSource("dsStickers_Addresses", ds.Addresses as DataTable);
            return dataSource;
        }

        #endregion Private Functions

        #region Form Events

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            using (var printer = new LocalReportPrinter())
            {
                var report = new LocalReport();
                var generator = GetReportGenerator();
                var dataSource = GetReportDataSource();

                generator.LeftMargin -= _minMargins.Left;
                generator.RightMargin -= _minMargins.Right;
                generator.TopMargin -= _minMargins.Top;
                generator.BottomMargin -= _minMargins.Bottom;

                if (generator.LeftMargin < 0) generator.LeftMargin = 0;
                if (generator.RightMargin < 0) generator.RightMargin = 0;
                if (generator.TopMargin < 0) generator.TopMargin = 0;
                if (generator.BottomMargin < 0) generator.BottomMargin = 0;

                report.DataSources.Clear();
                report.LoadReportDefinition(generator.GetReportDefinition());
                report.DataSources.Add(dataSource);

                printer.Print(report, GetPrinterSettings());
            }
        }

        private void cmbPrinters_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ps = GetPrinterSettings();
            _minMargins = GetPrinterMinimumMargins(ps);

            txtMarginDown.Minimum = Math.Floor(_minMargins.Bottom);
            txtMarginLeft.Minimum = Math.Floor(_minMargins.Left);
            txtMarginRight.Minimum = Math.Floor(_minMargins.Right);
            txtMarginUp.Minimum = Math.Floor(_minMargins.Top);
        }

        #endregion Form Events

        public static MinimumMargins GetPrinterMinimumMargins(PrinterSettings printerSettings)
        {
            var margins = new MinimumMargins();
            var area = printerSettings.DefaultPageSettings.PrintableArea;
            var paper = printerSettings.DefaultPageSettings.PaperSize;

            margins.Bottom = Convert.ToDecimal((Convert.ToDouble(paper.Height) - area.Bottom) / INCHES_TO_METER);
            margins.Left = Convert.ToDecimal(area.Left / INCHES_TO_METER);
            margins.Right = Convert.ToDecimal((Convert.ToDouble(paper.Width) - area.Right) / INCHES_TO_METER);
            margins.Top = Convert.ToDecimal(area.Top / INCHES_TO_METER);

            if (margins.Bottom < 0) margins.Bottom = 0;
            if (margins.Left < 0) margins.Left = 0;
            if (margins.Right < 0) margins.Right = 0;
            if (margins.Top < 0) margins.Top = 0;

            return margins;
        }
    }
}