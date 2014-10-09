using SHARED.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSCD.Entities;

namespace TSCD.DataFilter
{
    public class TaiSanHienThi : _FilterAbstract<TaiSanHienThi>
    {
        public Guid id { get; set; }
        public DateTime? ngay { get; set; }
        public String sohieu_ct { get; set; }
        public DateTime? ngay_ct { get; set; }
        public String ten { get; set; }
        public String loaits { get; set; }
        public String donvitinh { get; set; }
        public int soluong { get; set; }
        public long dongia { get; set; }
        public long thanhtien { get; set; }
        public String nuocsx { get; set; }
        public String nguongoc { get; set; }
        public String tinhtrang { get; set; }
        public String ghichu { get; set; }
        public String phong { get; set; }
        public String vitri { get; set; }
        public String dvquanly { get; set; }
        public String dvsudung { get; set; }
        public ICollection<CTTaiSan> childs { get; set; }
        public CTTaiSan obj { get; set; }

        public static List<TaiSanHienThi> Convert(ICollection<CTTaiSan> list)
        {
            try
            {
                if (list == null || list.Count == 0)
                    return null;
                List<TaiSanHienThi> re =
                list.Select(ct => new TaiSanHienThi
                {
                    id = ct.id,
                    ngay = ct.ngay,
                    sohieu_ct = ct.chungtu != null ? ct.chungtu.sohieu : "",
                    ngay_ct = ct.chungtu != null ? ct.chungtu.ngay : null,
                    ten = ct.taisan.ten,
                    loaits = ct.taisan.loaitaisan.ten,
                    donvitinh = ct.taisan.loaitaisan.donvitinh != null ? ct.taisan.loaitaisan.donvitinh.ten : "",
                    soluong = ct.soluong,
                    dongia = ct.taisan.dongia,
                    thanhtien = ct.soluong * ct.taisan.dongia,
                    nuocsx = ct.taisan.nuocsx,
                    nguongoc = ct.nguongoc,
                    tinhtrang = ct.tinhtrang.value,
                    ghichu = ct.mota,
                    childs = ct.childs,
                    phong = ct.phong != null ? ct.phong.ten : "",
                    vitri = ct.vitri != null ? (ct.vitri.coso != null ? ct.vitri.coso.ten + (ct.vitri.day != null ? " - " +
                    ct.vitri.day.ten + (ct.vitri.tang != null ? " - " + ct.vitri.tang.ten : "") : "") : "") : "",
                    dvquanly = ct.donviquanly != null ? ct.donviquanly.ten : "",
                    dvsudung = ct.donvisudung != null ? ct.donvisudung.ten : "",
                    obj = ct,
                }).ToList();
                return re;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("TaiSanHienThi->Convert:" + ex.Message);
                return null;
            }
        }

        public static List<TaiSanHienThi> Convert(IQueryable<CTTaiSan> list)
        {
            try
            {
                if (list == null)
                    return null;
                List<TaiSanHienThi> re =
                list.Select(ct => new TaiSanHienThi
                {
                    id = ct.id,
                    ngay = ct.ngay,
                    sohieu_ct = ct.chungtu != null ? ct.chungtu.sohieu : "",
                    ngay_ct = ct.chungtu != null ? ct.chungtu.ngay : null,
                    ten = ct.taisan.ten,
                    loaits = ct.taisan.loaitaisan.ten,
                    donvitinh = ct.taisan.loaitaisan.donvitinh != null ? ct.taisan.loaitaisan.donvitinh.ten : "",
                    soluong = ct.soluong,
                    dongia = ct.taisan.dongia,
                    thanhtien = ct.soluong * ct.taisan.dongia,
                    nuocsx = ct.taisan.nuocsx,
                    nguongoc = ct.nguongoc,
                    tinhtrang = ct.tinhtrang.value,
                    ghichu = ct.mota,
                    childs = ct.childs,
                    phong = ct.phong != null ? ct.phong.ten : "",
                    vitri = ct.vitri != null ? (ct.vitri.coso != null ? ct.vitri.coso.ten + (ct.vitri.day != null ? " - " +
                    ct.vitri.day.ten + (ct.vitri.tang != null ? " - " + ct.vitri.tang.ten : "") : "") : "") : "",
                    dvquanly = ct.donviquanly != null ? ct.donviquanly.ten : "",
                    dvsudung = ct.donvisudung != null ? ct.donvisudung.ten : "",
                    obj = ct,
                }).ToList();
                return re;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("TaiSanHienThi->Convert:" + ex.Message);
                return null;
            }
        }
    }
}
