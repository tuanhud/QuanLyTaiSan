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
    public partial class XtraReport_PhongBan : DevExpress.XtraReports.UI.XtraReport
    {
        DonVi obj = new DonVi();

        public XtraReport_PhongBan()
        {
            InitializeComponent();
        }

        public XtraReport_PhongBan(List<TaiSan_ThongKe> list, DonVi obj)
        {
            InitializeComponent();
            this.DataSource = list;
            this.obj = obj;
            IntReport();
        }

        private void IntReport()
        {
            if (!Object.Equals(this.DataSource, null))
            {
                xrTableCell_SoHieu.DataBindings.Add("Text", null, "sohieu_ct");
                xrTableCell_NgayThang.DataBindings.Add("Text", null, "ngay_ct", "{0:dd/MM/yyyy}");
                xrTableCell_Ten.DataBindings.Add("Text", null, "ten");
                xrTableCell_DonViTinh.DataBindings.Add("Text", null, "donvitinh");

                xrTableCell_SoLuongTang.DataBindings.Add("Text", null, "soluong_tang");
                xrTableCell_DonGiaTang.DataBindings.Add("Text", null, "dongia_tang");
                xrTableCell_ThanhTienTang.DataBindings.Add("Text", null, "thanhtien_tang");

                xrTableCell_LyDo.DataBindings.Add("Text", null, "ghichu");
                xrTableCell_SoLuongGiam.DataBindings.Add("Text", null, "soluong_giam");
                xrTableCell_DonGiaGiam.DataBindings.Add("Text", null, "dongia_giam");
                xrTableCell_ThanhTienGiam.DataBindings.Add("Text", null, "thanhtien_giam");

                IntSUM();
            }
            if (!Object.Equals(obj, null))
            {
                xrLabel_PhongBan.Text = "Phòng ban: " + obj.ten;
            }
        }

        private void IntSUM()
        {
            xrTableCell_SUM_SoLuongTang.DataBindings.Add("Text", this.DataSource, "soluong_tang");
            xrTableCell_SUM_SoLuongTang.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_SoLuongTang.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_SoLuongTang.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_SoLuongTang.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

            xrTableCell_SUM_ThanhTienTang.DataBindings.Add("Text", this.DataSource, "thanhtien_tang");
            xrTableCell_SUM_ThanhTienTang.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_ThanhTienTang.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_ThanhTienTang.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_ThanhTienTang.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

            xrTableCell_SUM_SoLuongGiam.DataBindings.Add("Text", this.DataSource, "soluong_giam");
            xrTableCell_SUM_SoLuongGiam.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_SoLuongGiam.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_SoLuongGiam.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_SoLuongGiam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

            xrTableCell_SUM_ThanhTienGiam.DataBindings.Add("Text", this.DataSource, "thanhtien_giam");
            xrTableCell_SUM_ThanhTienGiam.Summary.IgnoreNullValues = true;
            xrTableCell_SUM_ThanhTienGiam.Summary.Func = SummaryFunc.Sum;
            xrTableCell_SUM_ThanhTienGiam.Summary.Running = SummaryRunning.Report;
            xrTableCell_SUM_ThanhTienGiam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        }
    }
}
