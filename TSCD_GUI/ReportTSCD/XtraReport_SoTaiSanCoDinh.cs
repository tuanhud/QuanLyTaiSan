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
        public XtraReport_SoTaiSanCoDinh()
        {
            InitializeComponent();
        }

        public XtraReport_SoTaiSanCoDinh(List<TaiSan_ThongKe> List)
        {
            InitializeComponent();
            this.DataSource = List;
            IntReport();
        }

        private void IntReport()
        {
            if (!Object.Equals(this.DataSource, null))
            {
                xrTableCell_SoHieuTang.DataBindings.Add("Text", null, "sohieu_ct_tang");
                xrTableCell_NgayThangTang.DataBindings.Add("Text", null, "ngay_ct_tang", "{0:dd/MM/yyyy}");
                xrTableCell_TenTSCD.DataBindings.Add("Text", null, "ten");
                xrTableCell_NuocSX.DataBindings.Add("Text", null, "nuocsx");

                xrTableCell_NamSD.DataBindings.Add("Text", null, "ngay", "{0:yyyy}");
                xrTableCell_SoHieuTSCD.DataBindings.Add("Text", null, "sohieu_ct");
                xrTableCell_NguyenGia.DataBindings.Add("Text", null, "dongia_tang", "{0:### ### ### ###}");
                xrTableCell_TyLeHaoMon.DataBindings.Add("Text", null, "phantramhaomon_32", "{0:0.00}");
                xrTableCell_SoTienHaoMon.DataBindings.Add("Text", null, "sotientrongmotnam", "{0:### ### ### ###}");
                
                xrTableCell_SoHMChuyenGiao.DataBindings.Add("Text", null, "dongia_tang", "{0:### ### ### ###}");
                //xrTableCell_SoHMLuyKe.DataBindings.Add("Text", null, "dongia_tang", "{0:### ### ### ###}");

                xrTableCell_SoHieuGiam.DataBindings.Add("Text", null, "sohieu_ct_giam");
                xrTableCell_NgayThangGiam.DataBindings.Add("Text", null, "ngay_ct_giam", "{0:dd/MM/yyyy}");
                xrTableCell_LyDoGiam.DataBindings.Add("Text", null, "ghichu");

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


            xrTableCell_SUM_SoTienHM.DataBindings.Add("Text", this.DataSource, "sotientrongmotnam");
            xrTableCell_SUM_SoTienHM.Summary.FormatString = "{0:### ### ### ### ### ###}";
            xrTableCell_SUM_SoTienHM.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_SoTienHM.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_SoTienHM.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_SoTienHM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        }
    }
}
