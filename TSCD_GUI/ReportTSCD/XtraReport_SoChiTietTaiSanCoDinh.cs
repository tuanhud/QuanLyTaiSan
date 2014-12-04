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
        DonVi obj = null;

        public XtraReport_SoChiTietTaiSanCoDinh()
        {
            InitializeComponent();
        }

        public XtraReport_SoChiTietTaiSanCoDinh(List<TaiSanHienThi> list, DonVi obj)
        {
            InitializeComponent();
            this.DataSource = list;
            this.obj = obj;
            IntReport();
        }

        public XtraReport_SoChiTietTaiSanCoDinh(List<TaiSanHienThi> list)
        {
            InitializeComponent();
            this.DataSource = list;
            IntReport();
        }

        private void IntReport()
        {
            if (!Object.Equals(this.DataSource, null))
            {
                xrTableCell_TenTSCD.DataBindings.Add("Text", null, "ten");
                xrTableCell_NuocSanXuat.DataBindings.Add("Text", null, "nuocsx");
                xrTableCell_NgaySuDung.DataBindings.Add("Text", null, "ngay", "{0:dd/MM/yyyy}");
                
                xrTableCell_NguyenGia.DataBindings.Add("Text", null, "thanhtien", "{0:### ### ### ###}");
                xrTableCell_TyLeHM.DataBindings.Add("Text", null, "phantramhaomon_32");
                
                IntSUM();
            }
            if (!Object.Equals(obj, null))
            {
                xrLabel_PhongBan.Text = "Phòng ban: " + obj.ten;
            }
        }

        private void IntSUM()
        {
            xrTableCell_SUM_NguyenGia.DataBindings.Add("Text", this.DataSource, "thanhtien", "{0:### ### ### ###}");
            xrTableCell_SUM_NguyenGia.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_NguyenGia.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_NguyenGia.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_NguyenGia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        }
    }
}
