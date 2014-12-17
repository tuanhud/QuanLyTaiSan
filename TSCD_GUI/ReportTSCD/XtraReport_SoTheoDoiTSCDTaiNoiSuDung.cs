using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using TSCD.DataFilter;
using System.Collections.Generic;
using TSCD.Entities;
using System.Linq;

namespace TSCD_GUI.ReportTSCD
{
    public partial class XtraReport_SoTheoDoiTSCDTaiNoiSuDung : DevExpress.XtraReports.UI.XtraReport
    {

        const int padding = 5;

        public XtraReport_SoTheoDoiTSCDTaiNoiSuDung()
        {
            InitializeComponent();
        }

        public XtraReport_SoTheoDoiTSCDTaiNoiSuDung(Object Data, String strTenDonVi)
        {
            InitializeComponent();
            if (!Object.Equals(Data, null))
            {
                this.DataSource = Data;
                xrLabel_PhongBan.Text = "Phòng ban: " + strTenDonVi;
                IntReport();
            }
        }

        public XtraReport_SoTheoDoiTSCDTaiNoiSuDung(Object Data)
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

                xrTableCell_SoHieu.DataBindings.Add("Text", null, "sohieu_ct");
                xrTableCell_NgayThang.DataBindings.Add("Text", null, "ngay_ct", "{0:dd/MM/yyyy}");
                xrTableCell_Ten.DataBindings.Add("Text", null, "ten");
                xrTableCell_DonViTinh.DataBindings.Add("Text", null, "donvitinh");

                xrTableCell_SoLuongTang.DataBindings.Add("Text", null, "soluong_tang", "{0:### ### ### ###}");
                xrTableCell_DonGiaTang.DataBindings.Add("Text", null, "dongia_tang", "{0:### ### ### ###}");
                xrTableCell_ThanhTienTang.DataBindings.Add("Text", null, "thanhtien_tang", "{0:### ### ### ###}");
                xrTableCell_SoLuongTang.XlsxFormatString = "### ### ### ###";
                xrTableCell_DonGiaTang.XlsxFormatString = "### ### ### ###";
                xrTableCell_ThanhTienTang.XlsxFormatString = "### ### ### ###";

                xrTableCell_LyDo.DataBindings.Add("Text", null, "ghichu");
                xrTableCell_SoLuongGiam.DataBindings.Add("Text", null, "soluong_giam", "{0:### ### ### ###}");
                xrTableCell_DonGiaGiam.DataBindings.Add("Text", null, "dongia_giam", "{0:### ### ### ###}");
                xrTableCell_ThanhTienGiam.DataBindings.Add("Text", null, "thanhtien_giam", "{0:### ### ### ###}");
                xrTableCell_SoLuongGiam.XlsxFormatString = "### ### ### ###";
                xrTableCell_DonGiaGiam.XlsxFormatString = "### ### ### ###";
                xrTableCell_ThanhTienGiam.XlsxFormatString = "### ### ### ###";

                IntSUM();
            }
        }

        private void IntSUM()
        {
            xrTableCell_SUM_SoLuongTang.DataBindings.Add("Text", this.DataSource, "soluong_tang");
            xrTableCell_SUM_SoLuongTang.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_SUM_SoLuongTang.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_SoLuongTang.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_SoLuongTang.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_SoLuongTang.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            xrTableCell_SUM_SoLuongTang.XlsxFormatString = "### ### ### ###";

            xrTableCell_SUM_DonGiaTang.DataBindings.Add("Text", this.DataSource, "dongia_tang");
            xrTableCell_SUM_DonGiaTang.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_SUM_DonGiaTang.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_DonGiaTang.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_DonGiaTang.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_DonGiaTang.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            xrTableCell_SUM_DonGiaTang.XlsxFormatString = "### ### ### ###";

            xrTableCell_SUM_ThanhTienTang.DataBindings.Add("Text", this.DataSource, "thanhtien_tang");
            xrTableCell_SUM_ThanhTienTang.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_SUM_ThanhTienTang.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_ThanhTienTang.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_ThanhTienTang.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_ThanhTienTang.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            xrTableCell_SUM_ThanhTienTang.XlsxFormatString = "### ### ### ###";

            xrTableCell_SUM_SoLuongGiam.DataBindings.Add("Text", this.DataSource, "soluong_giam");
            xrTableCell_SUM_SoLuongGiam.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_SUM_SoLuongGiam.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_SoLuongGiam.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_SoLuongGiam.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_SoLuongGiam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            xrTableCell_SUM_SoLuongGiam.XlsxFormatString = "### ### ### ###";

            xrTableCell_SUM_DonGiaGiam.DataBindings.Add("Text", this.DataSource, "dongia_giam");
            xrTableCell_SUM_DonGiaGiam.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_SUM_DonGiaGiam.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_DonGiaGiam.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_DonGiaGiam.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_DonGiaGiam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            xrTableCell_SUM_DonGiaGiam.XlsxFormatString = "### ### ### ###";

            xrTableCell_SUM_ThanhTienGiam.DataBindings.Add("Text", this.DataSource, "thanhtien_giam");
            xrTableCell_SUM_ThanhTienGiam.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_SUM_ThanhTienGiam.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_ThanhTienGiam.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_ThanhTienGiam.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_ThanhTienGiam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            xrTableCell_SUM_ThanhTienGiam.XlsxFormatString = "### ### ### ###";

            //WordWrap
            //xrTableCell_SUM_DonGiaTang.WordWrap = false;
            //xrTableCell_SUM_ThanhTienTang.WordWrap = false;
            //xrTableCell_SUM_DonGiaGiam.WordWrap = false;
            //xrTableCell_SUM_ThanhTienGiam.WordWrap = false;
        }
    }
}
