using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using TSCD.Entities;
using System.Linq;
using TSCD;

namespace TSCD_GUI.ReportTSCD
{
    public partial class XtraReport_BienBanGiaoNhanTSCD : DevExpress.XtraReports.UI.XtraReport
    {
        CTTaiSan objCTTaiSan = null;
        ChungTu objChungTu = null;
        DonVi objDonVi = null;

        public XtraReport_BienBanGiaoNhanTSCD()
        {
            InitializeComponent();
        }

        public XtraReport_BienBanGiaoNhanTSCD(CTTaiSan _CTTaiSan, ChungTu _ChungTu, DonVi _DonVi)
        {
            InitializeComponent();
            this.objCTTaiSan = _CTTaiSan;
            this.objChungTu = _ChungTu;
            this.objDonVi = _DonVi;
            IntReport();
        }

        private void IntReport()
        {
            if (!Object.Equals(this.objCTTaiSan, null))
            {
                xrTableCell_STTTSCD.Text = "1";
                xrTableCell_TenKiHieuQuiCach.Text = objCTTaiSan.taisan != null ? objCTTaiSan.taisan.ten : "";
                xrTableCell_SoLuongTSCD.Text = string.Format("{0:### ### ### ###}", objCTTaiSan.soluong);
                xrTableCell_SoHieuTSCD.Text = objChungTu != null ? objChungTu.sohieu : "";
                xrTableCell_NuocSanXuatTSCD.Text = objCTTaiSan.taisan != null ? objCTTaiSan.taisan.nuocsx : "";
                xrTableCell_NamSanXuatTSCD.Text = "";
                xrTableCell_CongSuatTSCD.Text = "";
                xrTableCell_GiaMuaTSCD.Text = "";
                xrTableCell_CPCTTSCD.Text = "";
                xrTableCell_CPVCTSCD.Text = "";
                xrTableCell_NguyenGiaTSCD.Text = objCTTaiSan.taisan != null ? string.Format("{0:### ### ### ###}", objCTTaiSan.taisan.dongia) : "";
                xrTableCell_TinhTrangTSCD.Text = objCTTaiSan.tinhtrang != null ? objCTTaiSan.tinhtrang.value : "";

                IntSUM();
                IntKemTheo();
            }
            if (!Object.Equals(Global.current_quantrivien_login, null))
            {
                if (!Global.current_quantrivien_login.username.ToUpper().Equals("ROOT"))
                {
                    xrLabel_OngBaGiao.Text = xrLabel_OngBaGiao.Text + " " + Global.current_quantrivien_login.hoten;
                }
            }
            if (!Object.Equals(objDonVi, null))
            {
                xrLabel_OngBaNhan.Text = xrLabel_OngBaNhan.Text + " " + objDonVi.ten;
            }
        }

        private void IntSUM()
        {
            xrTableCell_SUM_NguyenGia.Text = objCTTaiSan.taisan != null ? string.Format("{0:### ### ### ###}", objCTTaiSan.taisan.dongia) : "";
        }

        private void IntKemTheo()
        {
            if (!Object.Equals(objCTTaiSan, null))
            {
                if (!Object.Equals(objCTTaiSan.childs, null))
                {
                    if (objCTTaiSan.childs.Count > 0)
                    {
                        var bind = objCTTaiSan.childs.Select(a => new
                        {
                            id = a.id,
                            tentaisan = a.taisan != null ? a.taisan.ten : "",
                            donvitinh = a.taisan != null ? a.taisan.loaitaisan != null ? a.taisan.loaitaisan.donvitinh != null ? a.taisan.loaitaisan.donvitinh.ten : "" : "" : "",
                            soluong = a.soluong,
                            giatri = a.taisan != null ? a.taisan.dongia : 0
                        }).ToList();


                        xrTableCell_STTKEMTHEO.DataBindings.Add("Text", bind, "id");
                        xrTableCell_STTKEMTHEO.Summary.IgnoreNullValues = true;
                        xrTableCell_STTKEMTHEO.Summary.Func = SummaryFunc.RecordNumber;
                        xrTableCell_STTKEMTHEO.Summary.Running = SummaryRunning.Report;
                        xrTableCell_STTKEMTHEO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;

                        xrTableCell_TenQuiCachKEMTHEO.DataBindings.Add("Text", bind, "tentaisan");
                        xrTableCell_DonViTinhKEMTHEO.DataBindings.Add("Text", bind, "donvitinh");
                        xrTableCell_SoLuongKEMTHEO.DataBindings.Add("Text", bind, "soluong");
                        xrTableCell_GiaTriKEMTHEO.DataBindings.Add("Text", bind, "giatri");
                    }
                    else
                        XuliTable_PhuTungKemTheo();
                }
                else
                    XuliTable_PhuTungKemTheo();
            }
            else
                XuliTable_PhuTungKemTheo();
        }

        private void XuliTable_PhuTungKemTheo()
        {
            DisposeTable(xrTable_PhuTungKemTheo);
            xrLabel_NguoiGiao.LocationF = new PointF(xrLabel_NguoiGiao.LocationF.X, xrLabel_NguoiGiao.LocationF.Y - 100);
            xrLabel_NguoiNhan.LocationF = new PointF(xrLabel_NguoiNhan.LocationF.X, xrLabel_NguoiNhan.LocationF.Y - 100);
            xrLabel_KeToanTruongBenNhan.LocationF = new PointF(xrLabel_KeToanTruongBenNhan.LocationF.X, xrLabel_KeToanTruongBenNhan.LocationF.Y - 100);
            xrLabel_ThuTruongDonVi.LocationF = new PointF(xrLabel_ThuTruongDonVi.LocationF.X, xrLabel_ThuTruongDonVi.LocationF.Y - 100);
        }

        private void DisposeTable(XRTable _XRTable)
        {
            if (!Object.Equals(xrTable_PhuTungKemTheo, null))
            {
                for (int i = 0; i < _XRTable.Rows.Count; i++)
                {
                    for (int j = 0; j < _XRTable.Rows[i].Cells.Count; j++)
                    {
                        _XRTable.Rows[i].Cells[j].Dispose();
                    }
                    _XRTable.Rows[i].Dispose();
                }
                _XRTable.Rows.Clear();
                _XRTable.Dispose();
            }
        }
    }
}
