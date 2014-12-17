using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using TSCD.Entities;
using System.Collections.Generic;
using TSCD.DataFilter;

namespace TSCD_GUI.ReportTSCD
{
    public partial class XtraReport_SoChiTietTaiSanCoDinh : DevExpress.XtraReports.UI.XtraReport
    {
        const int padding = 5;

        public XtraReport_SoChiTietTaiSanCoDinh()
        {
            InitializeComponent();
        }

        public XtraReport_SoChiTietTaiSanCoDinh(Object Data, int Year, String TenDonVi)
        {
            InitializeComponent();
            if (!Object.Equals(Data, null))
            {
                this.DataSource = Data;
                xrLabel_Nam.Text = "Năm " + Year.ToString();
                xrLabel_PhongBan.Text = "Phòng ban: " + TenDonVi;
                IntReport();
            }
        }

        public XtraReport_SoChiTietTaiSanCoDinh(Object Data)
        {
            InitializeComponent();
            if (!Object.Equals(Data, null))
            {
                this.DataSource = Data;
                IntReport();
            }
        }

        private void IntReport()
        {
            if (!Object.Equals(this.DataSource, null))
            {
                xrTable_Detail.Padding = padding;
                xrTable1.Padding = padding;
                xrTable3.Padding = padding;

                xrTableCell_TenTSCD.DataBindings.Add("Text", null, "ten");
                xrTableCell_NuocSanXuat.DataBindings.Add("Text", null, "nuocsx");
                xrTableCell_NgaySuDung.DataBindings.Add("Text", null, "ngay", "{0:dd/MM/yyyy}");

                xrTableCell_NguyenGia.DataBindings.Add("Text", null, "dongia", "{0:### ### ### ###}");
                xrTableCell_TyLeHM.DataBindings.Add("Text", null, "phantramhaomon_32", "{0:0.00}");
                xrTableCell_NguyenGia.XlsxFormatString = "### ### ### ###";

                xrTableCell_GiaTriHMDauKi.DataBindings.Add("Text", null, "haomonnamtruocchuyensang", "{0:### ### ### ###}");
                xrTableCell_SoHMTrongKi.DataBindings.Add("Text", null, "haomon_1nam", "{0:### ### ### ###}");
                xrTableCell_GiaTriHMLuyKe.DataBindings.Add("Text", null, "haomonluyke", "{0:### ### ### ###}");
                xrTableCell_GiaTriHMDauKi.XlsxFormatString = "### ### ### ###";
                xrTableCell_SoHMTrongKi.XlsxFormatString = "### ### ### ###";
                xrTableCell_GiaTriHMLuyKe.XlsxFormatString = "### ### ### ###";

                xrTableCell_GiaTriConLai.DataBindings.Add("Text", null, "giatriconlai_final", "{0:### ### ### ###}");
                xrTableCell_GiaTriConLai.XlsxFormatString = "### ### ### ###";

                IntGROUP();
                IntSUM();
            }
        }

        private void IntGROUP()
        {
            GroupField _GroupFieldLoaiTaiSan = new GroupField("loaitaisan");
            GroupHeader_LoaiTaiSan.GroupFields.Add(_GroupFieldLoaiTaiSan);

            xrTableCell_GROUP_Name.DataBindings.Add("Text", this.DataSource, "tenloaitaisan");

            xrTableCell_GROUP_NguyenGia.DataBindings.Add("Text", this.DataSource, "dongia");
            xrTableCell_GROUP_NguyenGia.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_GROUP_NguyenGia.Summary.IgnoreNullValues = true;
            xrTableCell_GROUP_NguyenGia.Summary.Func = SummaryFunc.Sum;
            xrTableCell_GROUP_NguyenGia.Summary.Running = SummaryRunning.Group;
            xrTableCell_GROUP_NguyenGia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            xrTableCell_GROUP_NguyenGia.XlsxFormatString = "### ### ### ###";

            xrTableCell_GROUP_HaoMonDauKy.DataBindings.Add("Text", this.DataSource, "haomonnamtruocchuyensang");
            xrTableCell_GROUP_HaoMonDauKy.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_GROUP_HaoMonDauKy.Summary.IgnoreNullValues = true;
            xrTableCell_GROUP_HaoMonDauKy.Summary.Func = SummaryFunc.Sum;
            xrTableCell_GROUP_HaoMonDauKy.Summary.Running = SummaryRunning.Group;
            xrTableCell_GROUP_HaoMonDauKy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            xrTableCell_GROUP_HaoMonDauKy.XlsxFormatString = "### ### ### ###";

            xrTableCell_GROUP_HaoMonTrongKy.DataBindings.Add("Text", this.DataSource, "haomon_1nam");
            xrTableCell_GROUP_HaoMonTrongKy.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_GROUP_HaoMonTrongKy.Summary.IgnoreNullValues = true;
            xrTableCell_GROUP_HaoMonTrongKy.Summary.Func = SummaryFunc.Sum;
            xrTableCell_GROUP_HaoMonTrongKy.Summary.Running = SummaryRunning.Group;
            xrTableCell_GROUP_HaoMonTrongKy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            xrTableCell_GROUP_HaoMonTrongKy.XlsxFormatString = "### ### ### ###";

            xrTableCell_GROUP_HaoMonLuyKe.DataBindings.Add("Text", this.DataSource, "haomonluyke");
            xrTableCell_GROUP_HaoMonLuyKe.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_GROUP_HaoMonLuyKe.Summary.IgnoreNullValues = true;
            xrTableCell_GROUP_HaoMonLuyKe.Summary.Func = SummaryFunc.Sum;
            xrTableCell_GROUP_HaoMonLuyKe.Summary.Running = SummaryRunning.Group;
            xrTableCell_GROUP_HaoMonLuyKe.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            xrTableCell_GROUP_HaoMonLuyKe.XlsxFormatString = "### ### ### ###";

            xrTableCell_GROUP_GiaTriConLai.DataBindings.Add("Text", this.DataSource, "giatriconlai_final");
            xrTableCell_GROUP_GiaTriConLai.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_GROUP_GiaTriConLai.Summary.IgnoreNullValues = true;
            xrTableCell_GROUP_GiaTriConLai.Summary.Func = SummaryFunc.Sum;
            xrTableCell_GROUP_GiaTriConLai.Summary.Running = SummaryRunning.Group;
            xrTableCell_GROUP_GiaTriConLai.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            xrTableCell_GROUP_GiaTriConLai.XlsxFormatString = "### ### ### ###";
        }

        private void IntSUM()
        {
            xrTableCell_SUM_NguyenGia.DataBindings.Add("Text", this.DataSource, "dongia");
            xrTableCell_SUM_NguyenGia.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_SUM_NguyenGia.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_NguyenGia.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_NguyenGia.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_NguyenGia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            xrTableCell_SUM_NguyenGia.XlsxFormatString = "### ### ### ###";

            xrTableCell_SUM_GiaTriHMDauKi.DataBindings.Add("Text", this.DataSource, "haomonnamtruocchuyensang");
            xrTableCell_SUM_GiaTriHMDauKi.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_SUM_GiaTriHMDauKi.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_GiaTriHMDauKi.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_GiaTriHMDauKi.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_GiaTriHMDauKi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            xrTableCell_SUM_GiaTriHMDauKi.XlsxFormatString = "### ### ### ###";

            xrTableCell_SUM_SoHaoMonTrongKy.DataBindings.Add("Text", this.DataSource, "haomon_1nam");
            xrTableCell_SUM_SoHaoMonTrongKy.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_SUM_SoHaoMonTrongKy.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_SoHaoMonTrongKy.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_SoHaoMonTrongKy.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_SoHaoMonTrongKy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            xrTableCell_SUM_SoHaoMonTrongKy.XlsxFormatString = "### ### ### ###";

            xrTableCell_SUM_GiaTriHMLuyKe.DataBindings.Add("Text", this.DataSource, "haomonluyke");
            xrTableCell_SUM_GiaTriHMLuyKe.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_SUM_GiaTriHMLuyKe.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_GiaTriHMLuyKe.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_GiaTriHMLuyKe.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_GiaTriHMLuyKe.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            xrTableCell_SUM_GiaTriHMLuyKe.XlsxFormatString = "### ### ### ###";

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
