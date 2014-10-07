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
            Refactor(list);
            this.obj = obj;
            IntReport();
        }

        private void Refactor(List<TaiSan_ThongKe> list)
        {
            var bind = list.Select(x => new
            {
                id = x.id,
                ngay = x.ngay,
                sohieu_ct = x.sohieu_ct,
                ngay_ct = x.ngay_ct,
                ngay_ct_STRING = ((DateTime)(x.ngay_ct)).ToString("dd/MM/yyyy"),
                ten = x.ten,
                loaits = x.loaits,
                donvitinh = x.donvitinh,
                soluong_tang = x.soluong_tang,
                dongia_tang = x.dongia_tang,
                thanhtien_tang = x.thanhtien_tang,
                soluong_giam = x.soluong_giam,
                dongia_giam = x.dongia_giam,
                thanhtien_giam = x.thanhtien_giam,
                nuocsx = x.nuocsx,
                nguongoc = x.nguongoc,
                tinhtrang = x.tinhtrang,
                ghichu = x.ghichu,
                childs = x.childs,
                phong = x.phong,
                vitri = x.vitri,
                dvquanly = x.dvquanly,
                dvsudung = x.dvsudung
            }).ToList();
            this.DataSource = bind;
        }

        private void IntReport()
        {
            if (!Object.Equals(this.DataSource, null))
            {
                xrTableCell_SoHieu.DataBindings.Add("Text", null, "sohieu_ct");

                xrTableCell_NgayThang.DataBindings.Add("Text", null, "ngay_ct_STRING");


                xrTableCell_Ten.DataBindings.Add("Text", null, "ten");
                xrTableCell_DonViTinh.DataBindings.Add("Text", null, "donvitinh");

                xrTableCell_SoLuongTang.DataBindings.Add("Text", null, "soluong_tang");
                xrTableCell_DonGiaTang.DataBindings.Add("Text", null, "dongia_tang");
                xrTableCell_ThanhTienTang.DataBindings.Add("Text", null, "thanhtien_tang");

                xrTableCell_LyDo.DataBindings.Add("Text", null, "ghichu");
                xrTableCell_SoLuongGiam.DataBindings.Add("Text", null, "soluong_giam");
                xrTableCell_DonGiaGiam.DataBindings.Add("Text", null, "dongia_giam");
                xrTableCell_ThanhTienGiam.DataBindings.Add("Text", null, "thanhtien_giam");
            }
            if (!Object.Equals(obj, null))
            {
                xrLabel_PhongBan.Text = "Phòng ban: " + obj.ten;            
            }
        }
    }
}
