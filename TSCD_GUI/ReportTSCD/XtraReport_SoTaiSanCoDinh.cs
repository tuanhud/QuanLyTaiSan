using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using TSCD.DataFilter;

namespace TSCD_GUI.ReportTSCD
{
    public partial class XtraReport_SoTaiSanCoDinh : DevExpress.XtraReports.UI.XtraReport
    {
        const int padding = 5;

        public XtraReport_SoTaiSanCoDinh()
        {
            InitializeComponent();
        }

        public XtraReport_SoTaiSanCoDinh(Object List, int Year)
        {
            InitializeComponent();
            this.DataSource = List;
            IntReport();
            xrLabel_Nam.Text = "Năm " + Year.ToString();
        }

        private void IntReport()
        {
            if (!Object.Equals(this.DataSource, null))
            {
                xrTable_Detail.Padding = padding;
                xrTable_SUM.Padding = padding;

                xrTableCell_SoHieuTang.DataBindings.Add("Text", null, "sohieu_ct_tang");
                xrTableCell_NgayThangTang.DataBindings.Add("Text", null, "ngay_ct_tang", "{0:dd/MM/yyyy}");
                xrTableCell_TenTSCD.DataBindings.Add("Text", null, "ten");
                xrTableCell_NuocSX.DataBindings.Add("Text", null, "nuocsx");

                xrTableCell_NamSD.DataBindings.Add("Text", null, "ngay", "{0:yyyy}");
                xrTableCell_SoHieuTSCD.DataBindings.Add("Text", null, "sohieu_ct");
                xrTableCell_NguyenGia.DataBindings.Add("Text", null, "dongia_tang", "{0:### ### ### ###}");
                xrTableCell_TyLeHaoMon.DataBindings.Add("Text", null, "phantramhaomon_32", "{0:0.00}");
                xrTableCell_SoTienHaoMon.DataBindings.Add("Text", null, "sotientrongmotnam", "{0:### ### ### ###}");
                xrTableCell_NamSD.XlsxFormatString = "yyyy";
                xrTableCell_NguyenGia.XlsxFormatString = "### ### ### ###";
                xrTableCell_SoTienHaoMon.XlsxFormatString = "### ### ### ###";

                xrTableCell_SoHMChuyenGiao.DataBindings.Add("Text", null, "haomonnamtruocchuyensang", "{0:### ### ### ###}");
                xrTableCell_SoHMNamNay.DataBindings.Add("Text", null, "haomon_1nam", "{0:### ### ### ###}");
                xrTableCell_SoHMLuyKe.DataBindings.Add("Text", null, "haomonluyke", "{0:### ### ### ###}");
                xrTableCell_SoHMChuyenGiao.XlsxFormatString = "### ### ### ###";
                xrTableCell_SoHMNamNay.XlsxFormatString = "### ### ### ###";
                xrTableCell_SoHMLuyKe.XlsxFormatString = "### ### ### ###";
                
                xrTableCell_SoHieuGiam.DataBindings.Add("Text", null, "sohieu_ct_giam");
                xrTableCell_NgayThangGiam.DataBindings.Add("Text", null, "ngay_ct_giam", "{0:dd/MM/yyyy}");
                xrTableCell_LyDoGiam.DataBindings.Add("Text", null, "ghichu");
                xrTableCell_GiaTriConLai.DataBindings.Add("Text", null, "giatriconlai_final", "{0:### ### ### ###}");
                xrTableCell_GiaTriConLai.XlsxFormatString = "### ### ### ###";
                IntSUM();
            }
        }

        private void IntSUM()
        {
            xrTableCell_SUM_NguyenGiaTang.DataBindings.Add("Text", this.DataSource, "dongia_tang");
            xrTableCell_SUM_NguyenGiaTang.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_SUM_NguyenGiaTang.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_NguyenGiaTang.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_NguyenGiaTang.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_NguyenGiaTang.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            xrTableCell_SUM_NguyenGiaTang.XlsxFormatString = "### ### ### ###";

            xrTableCell_SUM_SoTienHM.DataBindings.Add("Text", this.DataSource, "sotientrongmotnam");
            xrTableCell_SUM_SoTienHM.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_SUM_SoTienHM.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_SoTienHM.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_SoTienHM.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_SoTienHM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            xrTableCell_SUM_SoTienHM.XlsxFormatString = "### ### ### ###";

            xrTableCell_SUM_SoHMNam.DataBindings.Add("Text", this.DataSource, "haomonnamtruocchuyensang");
            xrTableCell_SUM_SoHMNam.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_SUM_SoHMNam.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_SoHMNam.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_SoHMNam.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_SoHMNam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            xrTableCell_SUM_SoHMNam.XlsxFormatString = "### ### ### ###";

            xrTableCell_SUM_SoHaoMonNamNay.DataBindings.Add("Text", this.DataSource, "haomon_1nam");
            xrTableCell_SUM_SoHaoMonNamNay.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_SUM_SoHaoMonNamNay.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_SoHaoMonNamNay.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_SoHaoMonNamNay.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_SoHaoMonNamNay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            xrTableCell_SUM_SoHaoMonNamNay.XlsxFormatString = "### ### ### ###";

            xrTableCell_SUM_SoHMLuyKe.DataBindings.Add("Text", this.DataSource, "haomonluyke");
            xrTableCell_SUM_SoHMLuyKe.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_SUM_SoHMLuyKe.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_SoHMLuyKe.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_SoHMLuyKe.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_SoHMLuyKe.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            xrTableCell_SUM_SoHMLuyKe.XlsxFormatString = "### ### ### ###";

            xrTableCell_SUM_GiaTriConLai.DataBindings.Add("Text", this.DataSource, "giatriconlai_final");
            xrTableCell_SUM_GiaTriConLai.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_SUM_GiaTriConLai.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_GiaTriConLai.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_GiaTriConLai.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_GiaTriConLai.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            xrTableCell_SUM_GiaTriConLai.XlsxFormatString = "### ### ### ###";
        }
    }
}
